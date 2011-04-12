#region MIT

// 
// GMare.
// Copyright (C) 2011 Michael Mercado
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//

#endregion

using System;
using System.IO;
using System.Collections.Generic;
using ICSharpCode.SharpZipLib.Zip.Compression;
using GameMaker.Common;
using GameMaker.Resource;

namespace GameMaker.Project
{
    /// <summary>
    /// A class that writes a Game Maker project to disk.
    /// </summary>
    public class GMProjectWriter
    {
        #region Fields

        private int[,] _swapTable = null;                                             // Table used for encryption.
        private List<byte> _buffer = null;                                            // The uncompressed byte buffer.
        private Stream _writer = null;                                                // The base underlining write stream.

        #endregion

        #region Methods

        #region WriteGMProject

        /// <summary>
        /// Writes a Game Maker project to disk.
        /// </summary>
        /// <param name="filePath">The file path to write the project.</param>
        /// <param name="project">The project object to write.</param>
        /// <param name="version">The target Game Maker version.</param>
        public void WriteGMProject(string filePath, GMProject project, GMVersionType version)
        {
            // Create a new stream encoder.
            using (_writer = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                // Write GM identifier.
                WriteInt(1234321);

                // Write version.
                WriteInt((int)version);

                // Write reserved bytes.
                if ((int)version < 600)
                    WriteEmpty(4);

                // If target version is GM7, start Game Maker 7 project file encryption.
                if (version == GMVersionType.GameMaker70)
                {
                    // Create random numbers.
                    Random rand = new Random();

                    byte[] bytes = null;

                    // Get game id bytes. The first byte is not encrypted.
                    byte[] id = BitConverter.GetBytes(project.Settings.GameIdentifier);

                    // Bill and Fred, psssttt they like each other ;).
                    int bill = rand.Next() % 3000 + 123;
                    int fred = rand.Next() % 3000 + 231;

                    // Write trash and treasure.
                    WriteInt(bill);
                    WriteInt(fred);

                    // Write junk integers.
                    while (bill-- > 0)
                    {
                        bytes = BitConverter.GetBytes((int)(rand.Next() % 3000));
                        _writer.Write(bytes, 0, bytes.Length);
                    }

                    // Set the seed and swap table.
                    int seed = rand.Next() % 25600 + 3328;
                    bytes = BitConverter.GetBytes((int)seed);
                    _writer.Write(bytes, 0, bytes.Length);

                    // Write junk integers.
                    while (fred-- > 0)
                    {
                        bytes = BitConverter.GetBytes((int)(rand.Next() % 3000));
                        _writer.Write(bytes, 0, bytes.Length);
                    }

                    // Write first byte of game id (Not encrypted).
                    WriteByte(id[0]);

                    // Set the seed for encryption.
                    SetSeed(seed);

                    // Write rest of game id bytes, encrypted.
                    WriteByte(id[1]);
                    WriteByte(id[2]);
                    WriteByte(id[3]);
                }
                else  // Write game id.
                    WriteInt(project.Settings.GameIdentifier);

                // Write empty bytes.
                WriteEmpty(16);

                // Write project objects.
                WriteSettings(project.Settings, version);

                // If the version is greater than 7.0.
                if (version > GMVersionType.GameMaker70)
                {
                    // Read triggers and constants.
                    WriteTriggers(project.Triggers, version);
                    WriteConstants(project.Settings.Constants, version);
                }

                WriteSounds(project.Sounds, version);
                WriteSprites(project.Sprites, version);
                WriteBackgrounds(project.Backgrounds, version);
                WritePaths(project.Paths, version);
                WriteScripts(project.Scripts, version);
                WriteDataFiles(project.DataFiles, version);
                WriteFonts(project.Fonts, version);
                WriteTimelines(project.Timelines, version);
                WriteObjects(project.Objects, version);
                WriteRooms(project.Rooms, version);

                // Write last ids for instances and tiles.
                WriteInt(project.LastInstanceId);
                WriteInt(project.LastTileId);

                // Write version.
                if (version < GMVersionType.GameMaker60)
                    WriteInt(430);
                else if (version == GMVersionType.GameMaker60)
                    WriteInt(600);
                else if (version == GMVersionType.GameMaker70)
                    WriteInt(620);
                else if (version == GMVersionType.GameMaker80)
                    WriteInt(800);

                // Check version.
                if (version < GMVersionType.GameMaker70)
                    WriteGameInformation(project.GameInformation, version);
                else
                {
                    // Write includes.
                    WriteIncludes(project.Settings.Includes, version);

                    // Write packages.
                    WritePackages(project.Packages.ToArray(), version);

                    // Write version.
                    if (version == GMVersionType.GameMaker70)
                        WriteInt(600);
                    else if (version == GMVersionType.GameMaker80)
                        WriteInt(800);

                    // Write game information.
                    WriteGameInformation(project.GameInformation, version);
                }

                // Write version.
                WriteInt(500);

                // Write the amount of libraries.
                WriteInt(project.Libraries.Count);

                // Iterate throught libraries.
                for (int j = 0; j < project.Libraries.Count; j++)
                {
                    // Write the library code.
                    WriteString(project.Libraries[j].Code);
                }

                // Write project tree.
                WriteTree(project.ProjectTree, version);
            }
        }

        #endregion

        #region WriteSettings

        /// <summary>
        /// Writes Game Maker project settings.
        /// </summary>
        /// <param name="settings">Settings object to write.</param>
        /// <param name="version">Target Game Maker file version to write.</param>
        private void WriteSettings(GMSettings settings, GMVersionType version)
        {
            // Write version number.
            if (version != GMVersionType.GameMaker70)
                WriteInt((int)version);
            else
                WriteInt(702);

            // If version is GM8, start compressing.
            if (version == GMVersionType.GameMaker80)
                Compress();

            // Write settings data
            WriteBool(settings.StartFullscreen);

            // Versions greater than 5.3 support interpolation.
            if (version > GMVersionType.GameMaker53)
                WriteBool(settings.Interpolate);

            // Write settings data.
            WriteBool(settings.DontDrawBorder);
            WriteBool(settings.DisplayCursor);

            // Versions greater than 5.3 support the below variables.
            if (version > GMVersionType.GameMaker53)
            {
                // Write settings data.
                WriteInt(settings.Scaling);
                WriteBool(settings.AllowWindowResize);
                WriteBool(settings.AlwaysOnTop);
                WriteInt(settings.ColorOutsideRoom);
            }
            else
            {
                // Write settings data.
                WriteInt(settings.ScaleInWindowedMode);
                WriteInt(settings.ScaleInFullScreenMode);
                WriteBool(settings.ScaleOnHardwareSupport);
            }

            // Write settings data.
            WriteBool(settings.SetResolution);

            // Versions greater than 5.3 support the below variables.
            if (version > GMVersionType.GameMaker53)
            {
                // Write settings data.
                WriteInt((int)settings.ColorDepth2);
                WriteInt((int)settings.Resolution2);
                WriteInt((int)settings.Frequency2);
            }
            else
            {
                // Write settings data.
                WriteInt((int)settings.ColorDepth1);
                WriteBool(settings.UseExclusiveGraphicsMode);
                WriteInt((int)settings.Resolution1);
                WriteInt((int)settings.Frequency1);
                WriteBool(settings.UseSynchronization);
                WriteBool(settings.DisplayCaptionInFullScreenMode);
            }

            // Write settings data.
            WriteBool(settings.DontShowButtons);

            // Versions greater than 5.3 support screen synchronization.
            if (version > GMVersionType.GameMaker53)
                WriteBool(settings.UseSynchronization);

            // Versions greater than 7.0 support disabling the screensaver, and power saving options.
            if (version > GMVersionType.GameMaker70)
                WriteBool(settings.DisableScreensaver);

            // Write settings.
            WriteBool(settings.LetF4SwitchFullscreen);
            WriteBool(settings.LetF1ShowGameInfo);
            WriteBool(settings.LetEscEndGame);
            WriteBool(settings.LetF5SaveF6Load);

            // Write empty bytes.
            if (version < GMVersionType.GameMaker60)
                WriteEmpty(8);

            // Versions greater than 6.0, treat close as esc, F9 screenshot.
            if (version > GMVersionType.GameMaker60)
            {
                // Write settings data.
                WriteBool(settings.LetF9TakeScreenShot);
                WriteBool(settings.TreatCloseButtonAsESC);
            }

            // Versions greater than 5.1 support game priority.
            if (version > GMVersionType.GameMaker51)
                WriteInt((int)settings.GamePriority);

            // Write settings data.
            WriteBool(settings.FreezeOnLoseFocus);
            WriteInt((int)settings.LoadBarMode);

            // If the loadbar type is a custom loadbar.
            if (settings.LoadBarMode == LoadProgressBarType.Custom)
            {
                // If version greater than 7.0.
                if (version > GMVersionType.GameMaker70)
                {
                    // If a back loadbar image exists.
                    if (settings.BackLoadBarImage != null)
                    {
                        // Write that there is a back load bar image.
                        WriteBool(true);

                        // Write size of image data.
                        WriteInt(settings.BackLoadBarImage.Length);

                        // Write back loadbar image data.
                        WriteBytes(settings.BackLoadBarImage);
                    }
                    else  // No back load bar image.
                        WriteBool(false);

                    // If a front loadbar image exists.
                    if (settings.FrontLoadBarImage != null)
                    {
                        // Write that there is a front load bar image.
                        WriteBool(true);

                        // Write size of image data.
                        WriteInt(settings.FrontLoadBarImage.Length);

                        // Write front loadbar image data.
                        WriteBytes(settings.FrontLoadBarImage);
                    }
                    else  // No front load bar image.
                        WriteBool(false);
                }
                else
                {
                    // If a back loadbar image exists.
                    if (settings.BackLoadBarImage != null)
                    {
                        // Write that there is a back load bar image.
                        WriteInt(10);

                        // Write size of image data.
                        WriteInt(settings.BackLoadBarImage.Length);

                        // Write back loadbar image data.
                        WriteBytes(settings.BackLoadBarImage);
                    }
                    else  // No back load bar image.
                        WriteInt(-1);

                    // If a front loadbar image exists.
                    if (settings.FrontLoadBarImage != null)
                    {
                        // Write that there is a front load bar image.
                        WriteInt(10);

                        // Write size of image data.
                        WriteInt(settings.FrontLoadBarImage.Length);

                        // Write front loadbar image data.
                        WriteBytes(settings.FrontLoadBarImage);
                    }
                    else  // No front load bar image.
                        WriteInt(-1);
                }
            }

            // Write settings data.
            WriteBool(settings.ShowCustomLoadImage);

            // If a custom load image must be shown.
            if (settings.ShowCustomLoadImage == true)
            {
                // If version is greater than 7.0.
                if (version > GMVersionType.GameMaker70)
                {
                    // If a custom load image is present
                    if (settings.LoadingImage != null)
                    {
                        // Write that there is a custom load image.
                        WriteBool(true);

                        // Write size of image data.
                        WriteInt(settings.LoadingImage.Length);

                        // Write custom load image data
                        WriteBytes(settings.LoadingImage);
                    }
                    else  // No custom load image.
                        WriteBool(false);
                }
                else
                {
                    // If a custom load image is present
                    if (settings.LoadingImage != null)
                    {
                        // Write that there is a custom load image.
                        WriteInt(10);

                        // Write size of image data.
                        WriteInt(settings.LoadingImage.Length);

                        // Write custom load image data
                        WriteBytes(settings.LoadingImage);
                    }
                    else  // No custom load image.
                        WriteInt(-1);
                }
            }

            // Versions greater than 5.0 support loading image alpha.
            if (version > GMVersionType.GameMaker50)
            {
                // Write settings data.
                WriteBool(settings.ImagePartiallyTransparent);
                WriteInt(settings.LoadImageAlpha);
                WriteBool(settings.ScaleProgressBar);
            }

            // Write size of icon image data.
            WriteInt(settings.GameIcon.Length);

            // Write settings data.
            WriteBytes(settings.GameIcon);
            WriteBool(settings.DisplayErrors);
            WriteBool(settings.WriteToLog);
            WriteBool(settings.AbortOnError);
            WriteBool(settings.TreatUninitializedAsZero);
            WriteString(settings.Author);

            // Versions greater than 6.0 use a string for the version data.
            if (version > GMVersionType.GameMaker60)
                WriteString(settings.Version);
            else
                WriteInt(Convert.ToInt32(settings.Version));

            // Write settings data.
            WriteDouble(settings.ProjectLastChanged);
            WriteString(settings.Information);

            // Versions greater than 5.2 support constants. Versions greater than 7.0 write constants elsewhere.
            if (version > GMVersionType.GameMaker52 && version < GMVersionType.GameMaker80)
            {
                // If there are constants to write.
                if (settings.Constants != null)
                {
                    // Write the amount of constants.
                    WriteInt(settings.Constants.Length);

                    // Iterate through constants.
                    for (int i = 0; i < settings.Constants.Length; i++)
                    {
                        // Write constant data.
                        WriteString(settings.Constants[i].Name);
                        WriteString(settings.Constants[i].Value);
                    }
                }
                else  // There are no constants to write.
                    WriteInt(0);
            }

            // If version is greater than 6.0, write build data, else write includes.
            if (version > GMVersionType.GameMaker60)
            {
                // Write build information.
                WriteInt(settings.Major);
                WriteInt(settings.Minor);
                WriteInt(settings.Release);
                WriteInt(settings.Build);
                WriteString(settings.Company);
                WriteString(settings.Product);
                WriteString(settings.Copyright);
                WriteString(settings.Description);

                // If the version is greater than 7.0, write last time global settings were changed.
                if (version > GMVersionType.GameMaker70)
                    WriteDouble(settings.SettingsLastChanged);
            }
            else if (version > GMVersionType.GameMaker53)
            {
                // If there are include files to write.
                if (settings.Includes != null)
                {
                    // Number of include files.
                    WriteInt(settings.Includes.Length);

                    // Iterate through include files.
                    for (int i = 0; i < settings.Includes.Length; i++)
                    {
                        // Write include file data.
                        WriteString(settings.Includes[i].FileName);
                    }
                }
                else  // There are no includes to write.
                    WriteInt(0);

                // Write settings data.
                WriteInt(settings.IncludeFolder);
                WriteBool(settings.OverwriteExisting);
                WriteBool(settings.RemoveAtGameEnd);
            }

            // Write compressed data.
            EndCompress();
        }

        #endregion

        #region WriteTriggers

        /// <summary>
        /// Writes Game Maker project triggers.
        /// </summary>
        private void WriteTriggers(GMList<GMTrigger> triggers, GMVersionType version)
        {
            // Write version number.
            WriteInt((int)version);

            // Write amount of triggers.
            WriteInt(triggers.LastId + 1);

            // Iterate through triggers.
            for (int i = 0; i < triggers.LastId + 1; i++)
            {
                // Start compress.
                Compress();

                // Try to get the resource by the current id.
                GMTrigger trigger = triggers.Find(delegate(GMTrigger t) { return t.Id == i; });

                // If the sound with the current id does not exist, continue.
                if (trigger == null)
                {
                    // No object exists at this id.
                    WriteBool(false);
                    EndCompress();
                    continue;
                }
                else
                    WriteBool(true);

                // Write version number.
                WriteInt((int)version);

                // Write trigger data.
                WriteString(trigger.Name);
                WriteString(trigger.Condition);
                WriteInt((int)trigger.Moment);
                WriteString(trigger.Constant);

                // End compress.
                EndCompress();
            }

            // Write last changed.
            WriteDouble(GMTrigger.TriggerLastChanged);
        }

        #endregion

        #region WriteConstants

        /// <summary>
        /// Writes Game Maker project constants.
        /// </summary>
        private void WriteConstants(GMConstant[] constants, GMVersionType version)
        {
            // Write version number.
            WriteInt((int)version);

            // Write amount of constants.
            WriteInt(constants.Length);

            // Iterate through constants.
            for (int i = 0; i < constants.Length; i++)
            {
                // Write constant data.
                WriteString(constants[i].Name);
                WriteString(constants[i].Value);
            }

            // Write last changed.
            WriteDouble(GMConstant.LastChanged);
        }

        #endregion

        #region WriteSounds

        /// <summary>
        /// Writes sounds from Game Maker project.
        /// </summary>
        /// <param name="sounds">Sounds array to write.</param>
        /// <param name="version">Target Game Maker file version to write.</param>
        private void WriteSounds(GMList<GMSound> sounds, GMVersionType version)
        {
            // Write version number.
            if (version < GMVersionType.GameMaker80)
                WriteInt(400);
            else
                WriteInt(800);

            // Write number of sound ids.
            WriteInt(sounds.LastId + 1);

            // Iterate through sound ids.
            for (int i = 0; i < sounds.LastId + 1; i++)
            {
                // If version is 8.0, compress.
                if (version == GMVersionType.GameMaker80)
                    Compress();

                // Try to get the resource by the current id.
                GMSound sound = sounds.Find(delegate(GMSound s) { return s.Id == i; });

                // If the sound with the current id does not exist, continue.
                if (sound == null)
                {
                    // No object exists at this id.
                    WriteBool(false);
                    EndCompress();
                    continue;
                }
                else
                    WriteBool(true);

                // Write sound data.
                WriteString(sound.Name);

                // If version is 8.0, write last changed.
                if (version == GMVersionType.GameMaker80)
                    WriteDouble(sound.LastChanged);

                // Write version number.
                if (version < GMVersionType.GameMaker60)
                {
                    WriteInt(440);
                    WriteInt((int)sound.Kind);
                }
                else if (version == GMVersionType.GameMaker80)
                {
                    WriteInt(800);
                    WriteInt((int)sound.Type);
                }
                else
                {
                    WriteInt(600);
                    WriteInt((int)sound.Type);
                }   

                // Write sound data.
                WriteString(sound.FileType);

                // Versions less than 6.0, have different sound data.
                if (version < GMVersionType.GameMaker60)
                {
                    // If sound data exists, read it.
                    if (sound.Kind != SoundKind.None)
                    {
                        // Write sound data.
                        WriteInt(sound.Data.Length);
                        WriteBytes(sound.Data);
                    }

                    // Write sound data.
                    WriteBool(sound.AllowSoundEffects);
                    WriteInt(sound.Buffers);
                    WriteBool(sound.Preload);
                }
                else
                {
                    // Write sound data.
                    WriteString(sound.FileName);

                    // If sound data exists, write it.
                    if (sound.Data != null)
                    {
                        // Write sound data.
                        WriteBool(true);
                        WriteInt(sound.Data.Length);
                        WriteBytes(sound.Data);
                    }
                    else
                        WriteBool(false);

                    // Write sound data.
                    WriteInt(sound.Effects);
                    WriteDouble(sound.Volume);
                    WriteDouble(sound.Pan);
                    WriteBool(sound.Preload);
                }

                // End compression.
                EndCompress();
            }
        }

        #endregion

        #region WriteSprites

        /// <summary>
        /// Writes sprites from Game Maker project.
        /// </summary>
        private void WriteSprites(GMList<GMSprite> sprites, GMVersionType version)
        {
            // Write version number.
            if (version < GMVersionType.GameMaker80)
                WriteInt(400);
            else
                WriteInt(800);

            // Write number of sprite ids.
            WriteInt(sprites.LastId + 1);

            // Iterate through sprites.
            for (int i = 0; i < sprites.LastId + 1; i++)
            {
                // If version is 8.0, compress.
                if (version == GMVersionType.GameMaker80)
                    Compress();

                // Try to get the resource by the current id.
                GMSprite sprite = sprites.Find(delegate(GMSprite s) { return s.Id == i; });

                // If the sprite with the current id does not exist, continue.
                if (sprite == null)
                {
                    // No object exists at this id.
                    WriteBool(false);
                    EndCompress();
                    continue;
                }
                else
                    WriteBool(true);

                // Write sprite data.
                WriteString(sprite.Name);

                // If version is 8.0, write last changed.
                if (version == GMVersionType.GameMaker80)
                    WriteDouble(sprite.LastChanged);

                // Write version number.
                if (version < GMVersionType.GameMaker60)
                    WriteInt(400);
                else if (version == GMVersionType.GameMaker70 || version == GMVersionType.GameMaker60)
                    WriteInt(542);
                else if (version == GMVersionType.GameMaker80)
                    WriteInt(800);

                if (version < GMVersionType.GameMaker80)
                {
                    // Write sprite data
                    WriteInt(sprite.Width);
                    WriteInt(sprite.Height);
                    WriteInt(sprite.BoundingBoxLeft);
                    WriteInt(sprite.BoundingBoxRight);
                    WriteInt(sprite.BoundingBoxBottom);
                    WriteInt(sprite.BoundingBoxTop);
                    WriteBool(sprite.Transparent);

                    // Check version.
                    if (version > GMVersionType.GameMaker53)
                    {
                        // Write sprite data.
                        WriteBool(sprite.SmoothEdges);
                        WriteBool(sprite.Preload);
                    }

                    // Write sprite data.
                    WriteInt((int)sprite.BoundingBoxMode);
                    WriteBool(sprite.Precise);

                    // Check version.
                    if (version < GMVersionType.GameMaker60)
                    {
                        // Write sprite data.
                        WriteBool(sprite.UseVideoMemory);
                        WriteBool(sprite.LoadOnlyOnUse);
                    }

                    // Write sprite data.
                    WriteInt(sprite.OriginX);
                    WriteInt(sprite.OriginY);

                    // If there are sub-images to write.
                    if (sprite.SubImages != null)
                    {
                        // Write number of sub images.
                        WriteInt(sprite.SubImages.Length);

                        // Iterate through sub-images.
                        for (int j = 0; j < sprite.SubImages.Length; j++)
                        {
                            // If the sub-image at index does not exists, continue.
                            if (sprite.SubImages[j] == null)
                            {
                                // No object exists at this id.
                                WriteInt(-1);
                                continue;
                            }
                            else  // There's image data.
                                WriteInt(10);

                            // Write size of image data.
                            WriteInt(sprite.SubImages[j].Data.Length);

                            // Write image data.
                            WriteBytes(sprite.SubImages[j].Data);
                        }
                    }
                    else  // There are no sub-images to write.
                        WriteInt(0);
                }
                else  // Game Maker 8.0.
                {
                    // Write sprite data.
                    WriteInt(sprite.OriginX);
                    WriteInt(sprite.OriginY);

                    // Sprite number of sub images.
                    WriteInt(sprite.SubImages.Length);

                    // Iterate through sub-images.
                    for (int j = 0; j < sprite.SubImages.Length; j++)
                    {
                        // Write version.
                        WriteInt(800);

                        // Write width and height of image.
                        WriteInt(sprite.SubImages[j].Width);
                        WriteInt(sprite.SubImages[j].Height);

                        // If the image data is not size zero.
                        if (sprite.SubImages[j].Width != 0 && sprite.SubImages[j].Height != 0)
                        {
                            WriteInt(sprite.SubImages[j].Data.Length);
                            WriteBytes(sprite.SubImages[j].Data);
                        }
                    }

                    // Write sprite data.
                    WriteInt((int)sprite.ShapeMode);
                    WriteInt(sprite.AlphaTolerance);
                    WriteBool(sprite.UseSeperateCollisionMasks);
                    WriteInt((int)sprite.BoundingBoxMode);
				    WriteInt(sprite.BoundingBoxLeft);
                    WriteInt(sprite.BoundingBoxRight);
                    WriteInt(sprite.BoundingBoxBottom);
                    WriteInt(sprite.BoundingBoxTop);
                }

                // End compression.
                EndCompress();
            }
        }

        #endregion

        #region WriteBackgrounds

        /// <summary>
        /// Writes backgrounds from Game Maker project.
        /// </summary>
        private void WriteBackgrounds(GMList<GMBackground> backgrounds, GMVersionType version)
        {
            // Write version number.
            if (version < GMVersionType.GameMaker80)
                WriteInt(400);
            else
                WriteInt(800);

            // Amount of background ids.
            WriteInt(backgrounds.LastId + 1);

            // Iterate through backgrounds.
            for (int i = 0; i < backgrounds.LastId + 1; i++)
            {
                // If version is 8.0, compress.
                if (version == GMVersionType.GameMaker80)
                    Compress();

                // Try to get the resource by the current id.
                GMBackground background = backgrounds.Find(delegate(GMBackground b) { return b.Id == i; });

                // If the background at index does not exists, continue.
                if (background == null)
                {
                    // No object exists at this id.
                    WriteBool(false);
                    EndCompress();
                    continue;
                }
                else
                    WriteBool(true);

                // Get background data.
                WriteString(background.Name);

                // If version is 8.0, write last changed.
                if (version == GMVersionType.GameMaker80)
                    WriteDouble(background.LastChanged);

                // Write version number.
                if (version < GMVersionType.GameMaker60)
                    WriteInt(400);
                else if (version == GMVersionType.GameMaker60 || version == GMVersionType.GameMaker70)
                    WriteInt(543);
                else if (version == GMVersionType.GameMaker80)
                    WriteInt(710);

                // If version is less than GM 8.0.
                if (version < GMVersionType.GameMaker80)
                {
                    // Write background data
                    WriteInt(background.Width);
                    WriteInt(background.Height);
                    WriteBool(background.Transparent);

                    // Check version.
                    if (version > GMVersionType.GameMaker53)
                    {
                        // Write background data.
                        WriteBool(background.SmoothEdges);
                        WriteBool(background.Preload);
                        WriteBool(background.UseAsTileSet);
                        WriteInt(background.TileWidth);
                        WriteInt(background.TileHeight);
                        WriteInt(background.HorizontalOffset);
                        WriteInt(background.VerticalOffset);
                        WriteInt(background.HorizontalSeperation);
                        WriteInt(background.VerticalSeperation);
                    }
                    else
                    {
                        // Write background data.
                        WriteBool(background.UseVideoMemory);
                        WriteBool(background.LoadOnlyOnUse);
                    }

                    // If image data does not exist.
                    if (background.Image != null)
                    {
                        // There is image data, write flags.
                        WriteBool(true);
                        WriteInt(10);

                        // Write size of image data.
                        WriteInt(background.Image.Data.Length);

                        // Write image data.
                        WriteBytes(background.Image.Data);

                    }  // No image data exist.
                    else
                        WriteBool(false);
                }
                else  // GM 8.0.
                {
                    // Write background data.
                    WriteBool(background.UseAsTileSet);
                    WriteInt(background.TileWidth);
                    WriteInt(background.TileHeight);
                    WriteInt(background.HorizontalOffset);
                    WriteInt(background.VerticalOffset);
                    WriteInt(background.HorizontalSeperation);
                    WriteInt(background.VerticalSeperation);

                    // Write version.
                    WriteInt(800);

                    // Write background data.
                    WriteInt(background.Width);
                    WriteInt(background.Height);

                    // If the sprite size is not zero, write image data.
                    if (background.Width != 0 && background.Height != 0)
                    {
                        WriteInt(background.Image.Data.Length);
                        WriteBytes(background.Image.Data);
                    }
                }

                // End compression.
                EndCompress();
            }
        }

        #endregion

        #region WritePaths

        /// <summary>
        /// Writes paths from Game Maker project.
        /// </summary>
        private void WritePaths(GMList<GMPath> paths, GMVersionType version)
        {
            // Write version number.
            if (version < GMVersionType.GameMaker80)
                WriteInt(420);
            else
                WriteInt(800);

            // Amount of path ids.
            WriteInt(paths.LastId + 1);

            // Iterate through paths.
            for (int i = 0; i < paths.LastId + 1; i++)
            {
                // If version is 8.0, compress.
                if (version == GMVersionType.GameMaker80)
                    Compress();

                // Try to get the resource by the current id.
                GMPath path = paths.Find(delegate(GMPath p) { return p.Id == i; });

                // If the path at index does not exists, continue.
                if (path == null)
                {
                    // No object exists at this id.
                    WriteBool(false);
                    EndCompress();
                    continue;
                }
                else
                    WriteBool(true);

                // Write path data.
                WriteString(path.Name);

                // If version is 8.0, write last changed.
                if (version == GMVersionType.GameMaker80)
                    WriteDouble(path.LastChanged);

                // Write version.
                if (version < GMVersionType.GameMaker53)
                    WriteInt(420);
                else
                    WriteInt(530);

                // Versions greater than 5.2, support the following variables.
                if (version > GMVersionType.GameMaker52)
                {
                    // Write path data.
                    WriteBool(path.Smooth);
                    WriteBool(path.Closed);
                    WriteInt(path.Precision);
                    WriteInt(path.RoomId);
                    WriteInt(path.SnapX);
                    WriteInt(path.SnapY);
                }
                else
                {
                    // Write path data.
                    WriteBool(path.Smooth);
                    WriteInt((int)path.ActionAtTheEnd);
                    WriteEmpty(4);
                }

                // If there are points to write.
                if (path.Points != null)
                {
                    // Write number of points.
                    WriteInt(path.Points.Length);

                    // Iterate through path points.
                    for (int j = 0; j < path.Points.Length; j++)
                    {
                        // Write point data.
                        WriteDouble(path.Points[j].X);
                        WriteDouble(path.Points[j].Y);
                        WriteDouble(path.Points[j].Speed);
                    }
                }
                else  // There are no points to write.
                    WriteInt(0);

                // End compression.
                EndCompress();
            }
        }

        #endregion

        #region WriteScripts

        /// <summary>
        /// Writes scripts from Game Maker project.
        /// </summary>
        private void WriteScripts(GMList<GMScript> scripts, GMVersionType version)
        {
            // Write version number.
            if (version < GMVersionType.GameMaker80)
                WriteInt(400);
            else
                WriteInt(800);

            // Write amount of script ids.
            WriteInt(scripts.LastId + 1);

            // Iterate through scripts.
            for (int i = 0; i < scripts.LastId + 1; i++)
            {
                // If version is 8.0, compress.
                if (version == GMVersionType.GameMaker80)
                    Compress();

                // Try to get the resource by the current id.
                GMScript script = scripts.Find(delegate(GMScript s) { return s.Id == i; });

                // If the script at the current id does not exist, continue.
                if (script == null)
                {
                    // No object exists at this id.
                    WriteBool(false);
                    EndCompress();
                    continue;
                }
                else
                    WriteBool(true);

                // Write script name.
                WriteString(script.Name);

                // If version is 8.0, write last changed.
                if (version == GMVersionType.GameMaker80)
                    WriteDouble(script.LastChanged);

                // Write version.
                if (version == GMVersionType.GameMaker80)
                    WriteInt(800);
                else
                    WriteInt(400);

                // Write script data.
                WriteString(script.Code);

                // End compression.
                EndCompress();
            }
        }

        #endregion

        #region WriteDataFiles

        /// <summary>
        /// Writes data files from Game Maker project.
        /// </summary>
        private void WriteDataFiles(GMList<GMDataFile> dataFiles, GMVersionType version)
        {
            // If the version is greater than 5.3, return.
            if (version > GMVersionType.GameMaker53)
                return;

            // Write version.
            WriteInt(440);

            // Write amount of script ids.
            WriteInt(dataFiles.LastId + 1);

            // Iterate through data files.
            for (int i = 0; i < dataFiles.LastId + 1; i++)
            {
                // Try to get the resource by the current id.
                GMDataFile dataFile = dataFiles.Find(delegate(GMDataFile d) { return d.Id == i; });

                // If the script at current id does not exists, continue.
                if (dataFile == null)
                {
                    // No object exists at this id.
                    WriteBool(false);
                    continue;
                }
                else
                    WriteBool(true);

                // Write data file name.
                WriteString(dataFile.Name);

                // Write version.
                WriteInt(440);

                // Write data file data.
                WriteString(dataFile.FileName);

                // If data file exists.
                if (dataFile.Data != null)
                {
                    // Data exists.
                    WriteBool(true);

                    // Write the size of the data file.
                    WriteInt(dataFile.Data.Length);

                    // Write data file data.
                    WriteBytes(dataFile.Data);
                }
                else  // Data does not exist.
                    WriteBool(false);

                // Write data file data.
                WriteInt((int)dataFile.ExportMode);
                WriteBool(dataFile.OverwriteFile);
                WriteBool(dataFile.FreeDataMemory);
                WriteBool(dataFile.RemoveAtGameEnd);
            }
        }

        #endregion

        #region WriteFonts

        /// <summary>
        /// Writes fonts from Game Maker project.
        /// </summary>
        private void WriteFonts(GMList<GMFont> fonts, GMVersionType version)
        {
            // If the version is before Game Maker 6, return.
            if (version < GMVersionType.GameMaker60)
                return;

            // Write version number.
            if (version < GMVersionType.GameMaker80)
                WriteInt(540);
            else
                WriteInt(800);

            // Amount of font ids.
            WriteInt(fonts.LastId + 1);

            // Iterate through fonts.
            for (int i = 0; i < fonts.LastId + 1; i++)
            {
                // If version is 8.0, compress.
                if (version == GMVersionType.GameMaker80)
                    Compress();

                // Try to get the resource with the current id.
                GMFont font = fonts.Find(delegate(GMFont f) { return f.Id == i; });

                // If the resource at index does not exist, continue.
                if (font == null)
                {
                    // No object exists at this id.
                    WriteBool(false);
                    EndCompress();
                    continue;
                }
                else
                    WriteBool(true);

                // Write font name.
                WriteString(font.Name);

                // If version is 8.0, write last changed.
                if (version == GMVersionType.GameMaker80)
                    WriteDouble(font.LastChanged);

                // Write version.
                if (version == GMVersionType.GameMaker80)
                    WriteInt(800);
                else
                WriteInt(540);

                // Write font data.
                WriteString(font.FontName);
                WriteInt(font.Size);
                WriteBool(font.Bold);
                WriteBool(font.Italic);
                WriteInt(font.CharacterRangeMin);
                WriteInt(font.CharacterRangeMax);

                // End object compression.
                EndCompress();
            }
        }

        #endregion

        #region WriteTimelines

        /// <summary>
        /// Writes timelines from Game Maker project.
        /// </summary>
        private void WriteTimelines(GMList<GMTimeline> timelines, GMVersionType version)
        {
            // Write version number.
            if (version < GMVersionType.GameMaker80)
                WriteInt(500);
            else
                WriteInt(800);

            // Write the amount of timeline ids.
            WriteInt(timelines.LastId + 1);

            // Iterate through timelines.
            for (int i = 0; i < timelines.LastId + 1; i++)
            {
                // If version is 8.0, compress.
                if (version == GMVersionType.GameMaker80)
                    Compress();

                // Try to get the resource with the current id.
                GMTimeline timeline = timelines.Find(delegate(GMTimeline t) { return t.Id == i; });

                // If the resource at index does not exist, continue.
                if (timeline == null)
                {
                    // No object exists at this id.
                    WriteBool(false);
                    EndCompress();
                    continue;
                }
                else
                    WriteBool(true);

                // Write timeline name.
                WriteString(timeline.Name);

                // If version is 8.0, write last changed.
                if (version == GMVersionType.GameMaker80)
                    WriteDouble(timeline.LastChanged);

                // Write version.
                WriteInt(500);

                // If there are moments to write.
                if (timeline.Moments != null)
                {
                    // Write number of timeline moments.
                    WriteInt(timeline.Moments.Length);

                    // Iterate through moments.
                    for (int j = 0; j < timeline.Moments.Length; j++)
                    {
                        // Write moment step number.
                        WriteInt(timeline.Moments[j].StepIndex);

                        // Write moment actions.
                        WriteActions(timeline.Moments[j].Actions, version);
                    }
                }
                else  // There are no moments.
                    WriteInt(0);

                // End object compression.
                EndCompress();
            }
        }

        #endregion

        #region WriteObjects
        
        /// <summary>
        /// Writes objects from Game Maker project.
        /// </summary>
        private void WriteObjects(GMList<GMObject> objects, GMVersionType version)
        {
            // Write version number.
            if (version < GMVersionType.GameMaker80)
                WriteInt(400);
            else
                WriteInt(800);

            // Write the amount of object ids.
            WriteInt(objects.LastId + 1);

            // Iterate through objects
            for (int i = 0; i < objects.LastId + 1; i++)
            {
                // If version is 8.0, compress.
                if (version == GMVersionType.GameMaker80)
                    Compress();

                // Try to get the resource with the current id.
                GMObject obj = objects.Find(delegate(GMObject o) { return o.Id == i; });

                // If the resource at index does not exist, continue.
                if (obj == null)
                {
                    // No object exists at this id.
                    WriteBool(false);
                    EndCompress();
                    continue;
                }
                else
                    WriteBool(true);

                // Write object name.
                WriteString(obj.Name);

                // If version is 8.0, write last changed.
                if (version == GMVersionType.GameMaker80)
                    WriteDouble(obj.LastChanged);

                // Write version.
                WriteInt(430);

                // Write object data.
                WriteInt(obj.SpriteId);
                WriteBool(obj.Solid);
                WriteBool(obj.Visible);
                WriteInt(obj.Depth);
                WriteBool(obj.Persistent);
                WriteInt(obj.Parent);
                WriteInt(obj.Mask);

                // The amount of main event types.
                int amount = 11;

                // If version is 8.0.
                if (version == GMVersionType.GameMaker80)
                {
                    // 12 main events.
                    amount = 12;

                    // Write int.
                    WriteInt(11);
                }
                else  // Write int.
                    WriteInt(10);

                // Iterate through event types.
                for (int j = 0; j < amount; j++)
                {
                    // Iterate through object events.
                    foreach (GMEvent ev in obj.Events[j])
                    {
                        // If the event has actions in it, write the actions.
                        if (ev.Actions != null)
                        {
                            // Check if the event's type is a collision event, set other's id.
                            if (ev.MainType == EventType.Collision)
                                WriteInt(ev.OtherId);
                            else
                                WriteInt(ev.SubType);

                            // Write the event actions.
                            WriteActions(ev.Actions, version);
                        }
                    }

                    // End of event.
                    WriteInt(-1);
                }

                // End object compression.
                EndCompress();
            }
        }

        #endregion

        #region WriteRooms

        /// <summary>
        /// Writes rooms from Game Maker project.
        /// </summary>
        private void WriteRooms(GMList<GMRoom> rooms, GMVersionType version)
        {
            // Write version number.
            if (version < GMVersionType.GameMaker80)
                WriteInt(420);
            else
                WriteInt(800);

            // Write the amount of room ids.
            WriteInt(rooms.LastId + 1);

            // Iterate through rooms.
            for (int i = 0; i < rooms.LastId + 1; i++)
            {
                // If version is 8.0, compress.
                if (version == GMVersionType.GameMaker80)
                    Compress();

                // Try to get the resource with the current id.
                GMRoom room = rooms.Find(delegate(GMRoom r) { return r.Id == i; });

                // If the resource at index does not exist, continue.
                if (room == null)
                {
                    // No object exists at this id.
                    WriteBool(false);
                    EndCompress();
                    continue;
                }
                else
                    WriteBool(true);

                // Write room name.
                WriteString(room.Name);

                // If version is 8.0, write last changed.
                if (version == GMVersionType.GameMaker80)
                    WriteDouble(room.LastChanged);

                // Write version.
                switch (version)
                {
                    case GMVersionType.GameMaker50: WriteInt(500); break;
                    case GMVersionType.GameMaker51: WriteInt(500); break;
                    case GMVersionType.GameMaker52: WriteInt(520); break;
                    case GMVersionType.GameMaker53: WriteInt(520); break;
                    case GMVersionType.GameMaker60: WriteInt(541); break;
                    case GMVersionType.GameMaker70: WriteInt(541); break;
                    case GMVersionType.GameMaker80: WriteInt(541); break;
                }

                // Write room data.
                WriteString(room.Caption);
                WriteInt(room.Width);
                WriteInt(room.Height);
                WriteInt(room.SnapY);
                WriteInt(room.SnapX);

                // Versions greater than 5.1 support isometric grid.
                if (version > GMVersionType.GameMaker51)
                    WriteBool(room.IsometricGrid);

                WriteInt(room.Speed);
                WriteBool(room.Persistent);
                WriteInt(room.BackgroundColor);
                WriteBool(room.DrawBackgroundColor);
                WriteString(room.CreationCode);

                // Write the amount of room parallaxes.
                WriteInt(8);

                // Iterate through parallaxs.
                for (int j = 0; j < room.Parallaxes.Length; j++)
                {
                    // Write room parallax data.
                    WriteBool(room.Parallaxes[j].Visible);
                    WriteBool(room.Parallaxes[j].Foreground);
                    WriteInt(room.Parallaxes[j].BackgroundId);
                    WriteInt(room.Parallaxes[j].X);
                    WriteInt(room.Parallaxes[j].Y);
                    WriteBool(room.Parallaxes[j].TileHorizontally);
                    WriteBool(room.Parallaxes[j].TileVertically);
                    WriteInt(room.Parallaxes[j].HorizontalSpeed);
                    WriteInt(room.Parallaxes[j].VerticalSpeed);

                    // Versions greater than 5.1 support parallax stretching.
                    if (version > GMVersionType.GameMaker51)
                        WriteBool(room.Parallaxes[j].Stretch);
                }

                // Write room data.
                WriteBool(room.EnableViews);

                // Write the amount of room views.
                WriteInt(8);

                // Iterate through views
                for (int k = 0; k < room.Views.Length; k++)
                {
                    // Write room view data.
                    WriteBool(room.Views[k].Visible);
                    WriteInt(room.Views[k].ViewX);
                    WriteInt(room.Views[k].ViewY);
                    WriteInt(room.Views[k].ViewWidth);
                    WriteInt(room.Views[k].ViewHeight);
                    WriteInt(room.Views[k].PortX);
                    WriteInt(room.Views[k].PortY);

                    // Versions greater than 5.3 support port dimensions.
                    if (version > GMVersionType.GameMaker53)
                    {
                        // Write room view data.
                        WriteInt(room.Views[k].PortWidth);
                        WriteInt(room.Views[k].PortHeight);
                    }

                    // Write room view data.
                    WriteInt(room.Views[k].HorizontalBorder);
                    WriteInt(room.Views[k].VerticalBorder);
                    WriteInt(room.Views[k].HorizontalSpeed);
                    WriteInt(room.Views[k].VerticalSpeed);
                    WriteInt(room.Views[k].ObjectToFollow);
                }

                // If there are instances to write.
                if (room.Instances != null)
                {
                    // Write the amount of instances.
                    WriteInt(room.Instances.Length);

                    // Iterate through room instances.
                    for (int l = 0; l < room.Instances.Length; l++)
                    {
                        // Write room instance data.
                        WriteInt(room.Instances[l].X);
                        WriteInt(room.Instances[l].Y);
                        WriteInt(room.Instances[l].ObjectId);
                        WriteInt(room.Instances[l].Id);

                        // Versions greater than 5.1 support creation code and instance locking.
                        if (version > GMVersionType.GameMaker51)
                        {
                            WriteString(room.Instances[l].CreationCode);
                            WriteBool(room.Instances[l].Locked);
                        }

                        // Write empty reserved bytes.
                        if (version < GMVersionType.GameMaker52)
                            WriteEmpty(8);
                    }
                }
                else  // Write no instances.
                    WriteInt(0);

                // If there are tiles to write.
                if (room.Tiles != null)
                {
                    // Write the amount of room tiles.
                    WriteInt(room.Tiles.Length);

                    // Iterate through room tiles.
                    for (int m = 0; m < room.Tiles.Length; m++)
                    {
                        // Write room tile data.
                        WriteInt(room.Tiles[m].X);
                        WriteInt(room.Tiles[m].Y);
                        WriteInt(room.Tiles[m].BackgroundId);
                        WriteInt(room.Tiles[m].BackgroundX);
                        WriteInt(room.Tiles[m].BackgroundY);
                        WriteInt(room.Tiles[m].Width);
                        WriteInt(room.Tiles[m].Height);
                        WriteInt(room.Tiles[m].Depth);
                        WriteInt(room.Tiles[m].Id);

                        // Versions greater than 5.1 support tile locking.
                        if (version > GMVersionType.GameMaker51)
                            WriteBool(room.Tiles[m].Locked);
                    }
                }
                else  // Write no tiles.
                    WriteInt(0);

                // Write room data.
                WriteBool(room.RememberWindowSize);
                WriteInt(room.EditorWidth);
                WriteInt(room.EditorHeight);
                WriteBool(room.ShowGrid);
                WriteBool(room.ShowObjects);
                WriteBool(room.ShowTiles);
                WriteBool(room.ShowBackgrounds);
                WriteBool(room.ShowForegrounds);
                WriteBool(room.ShowViews);
                WriteBool(room.DeleteUnderlyingObjects);
                WriteBool(room.DeleteUnderlyingTiles);

                // Versions greater than 5.3 don't support tile settings.
                if (version > GMVersionType.GameMaker53)
                {
                    // Write room data.
                    WriteInt((int)room.CurrentTab);
                    WriteInt(room.ScrollBarX);
                    WriteInt(room.ScrollBarY);
                }
                else
                {
                    // Write room data.
                    WriteInt(room.TileWidth);
                    WriteInt(room.TileHeight);
                    WriteInt(room.TileHorizontalSeperation);
                    WriteInt(room.TileVerticalSeperation);
                    WriteInt(room.TileHorizontalOffset);
                    WriteInt(room.TileVerticalOffset);
                    WriteInt((int)room.CurrentTab);
                    WriteInt(room.ScrollBarX);
                    WriteInt(room.ScrollBarY);
                }

                // End object compression.
                EndCompress();
            }
        }

        #endregion

        #region WriteActions

        /// <summary>
        /// Writes actions from Game Maker project.
        /// </summary>
        private void WriteActions(GMAction[] actions, GMVersionType version)
        {
            // Write version.
            WriteInt(400);

            // Write the amount of actions.
            WriteInt(actions.Length);

            // Iterate through actions.
            for (int i = 0; i < actions.Length; i++)
            {
                // Write version.
                WriteInt(440);

                // Write action properties.
                WriteInt(actions[i].LibraryId);
                WriteInt(actions[i].ActionId);
                WriteInt((int)actions[i].ActionKind);
                WriteBool(actions[i].AllowRelative);
                WriteBool(actions[i].Question);
                WriteBool(actions[i].CanApplyTo);
                WriteInt((int)actions[i].ExecuteMode);

                // If the execute mode is a prefabbed function.
                if (actions[i].ExecuteMode == ExecutionType.Function)
                    WriteString(actions[i].ExecuteCode);
                else
                    WriteInt(0);

                // If the execute mode is a script.
                if (actions[i].ExecuteMode == ExecutionType.Code)
                    WriteString(actions[i].ExecuteCode);
                else
                    WriteInt(0);

                // Write the amount of arguments.
                WriteInt(actions[i].Arguments.Length);

                // Write the amount of argument types.
                WriteInt(8);

                // Iterate through argument types
                for (int j = 0; j < 8; j++)
                {
                    // If the index is less than the actual arguments, write the type, else empty.
                    if (j < actions[i].Arguments.Length)
                        WriteInt((int)actions[i].Arguments[j].Type);
                    else
                        WriteInt(0);
                }

                // Write action data.
                WriteInt(actions[i].AppliesTo);
                WriteBool(actions[i].Relative);

                // Write the amount of actual arguments.
                WriteInt(8);

                // Iterate through arguments.
                for (int k = 0; k < 8; k++)
                {
                    // If the index is greater than or equal to the number of arguments, continue.
                    if (k >= actions[i].Arguments.Length)
                    {
                        WriteInt(1);
                        WriteEmpty(1);
                        continue;
                    }

                    // Write resource value.
                    WriteString(actions[i].Arguments[k].Value);
                }

                // If not checkbox has been checked.
                WriteBool(actions[i].Not);
            }
        }

        #endregion

        #region WriteIncludes

        /// <summary>
        /// Writes includes from Game Maker project.
        /// </summary>
        private void WriteIncludes(GMInclude[] includes, GMVersionType version)
        {
            // Write the amount of includes.
            WriteInt(includes.Length);

            // Iterate through includes.
            for (int i = 0; i < includes.Length; i++)
            {
                // If version is 8.0, write last changed.
                if (version == GMVersionType.GameMaker80)
                    WriteDouble(includes[i].LastChanged);

                // Write version number.
                if (version < GMVersionType.GameMaker80)
                    WriteInt(620);
                else
                    WriteInt(800);

                // Write include data.
                WriteString(includes[i].FileName);
                WriteString(includes[i].FilePath);
                WriteBool(includes[i].OriginalFileChosen);
                WriteInt(includes[i].OriginalFileSize);
                WriteBool(includes[i].StoreInEditableGMKFile);

                // If the include file will be stored within the executable, write data.
                if (includes[i].StoreInEditableGMKFile == true)
                    WriteBytes(includes[i].Data);

                // Write include data.
                WriteInt((int)includes[i].ExportMode);
                WriteInt(includes[i].FolderToExport);
                WriteBool(includes[i].OverwriteIfExists);
                WriteBool(includes[i].FreeMemoryAfterExport);
                WriteBool(includes[i].RemoveAtGameEnd);
            }
        }

        #endregion

        #region WritePackages

        /// <summary>
        /// Writes packages from Game Maker project.
        /// </summary>
        private void WritePackages(GMPackage[] packages, GMVersionType version)
        {
            // Write version number.
            WriteInt(700);

            // Write the number of packages.
            WriteInt(packages.Length);

            // Iterate through packages.
            for (int i = 0; i < packages.Length; i++)
            {
                // Write package name.
                WriteString(packages[i].Name);
            }
        }

        #endregion

        #region WriteGameInformation

        /// <summary>
        /// Writes game information from Game Maker project.
        /// </summary>
        private void WriteGameInformation(GMGameInformation gameInfo, GMVersionType version)
        {
            // If version is 8.0, compress.
            if (version == GMVersionType.GameMaker80)
                Compress();

            // Write game information data.
            WriteInt(gameInfo.BackgroundColor);
            WriteBool(gameInfo.MimicGameWindow);

            // Versions greater than 5.3, support the following data.
            if (version > GMVersionType.GameMaker53)
            {
                // Write game information data.
                WriteString(gameInfo.FormCaption);
                WriteInt(gameInfo.X);
                WriteInt(gameInfo.Y);
                WriteInt(gameInfo.Width);
                WriteInt(gameInfo.Height);
                WriteBool(gameInfo.ShowBorder);
                WriteBool(gameInfo.AllowResize);
                WriteBool(gameInfo.AlwaysOnTop);
                WriteBool(gameInfo.PauseGame);
            }

            // If version is 8.0, write last changed.
            if (version == GMVersionType.GameMaker80)
                WriteDouble(gameInfo.LastChanged);

            // Write game information data.
            WriteString(gameInfo.Information);

            // End object compression.
            EndCompress();
        }

        #endregion

        #region WriteTree

        /// <summary>
        /// Writes object tree from Game Maker project.
        /// </summary>
        private void WriteTree(GMNode rootNode, GMVersionType version)
        {
            // Write version number.
            if (version < GMVersionType.GameMaker60)
                WriteInt(500);
            else if (version == GMVersionType.GameMaker60)
                WriteInt(540);
            else if (version >= GMVersionType.GameMaker70)
                WriteInt(700);

            // Write room execution Order.
            WriteInt(0);

            // Set the number of main resource nodes.
            int rootNum = (version > GMVersionType.GameMaker60) ? 12 : 11;

            // Iterate through Game Maker project root nodes
            for (int i = 0; i < rootNum; i++)
            {
                // Write child nodes recursively.
                WriteNodeRecursive(rootNode.Nodes[i]);
            }
        }

        /// <summary>
        /// Reads a Game Maker tree node recursively.
        /// </summary>
        private void WriteNodeRecursive(GMNode parent)
        {
            // Write node data.
            WriteInt((int)parent.NodeType);
            WriteInt((int)parent.ResourceType);
            WriteInt(parent.Id);
            WriteString(parent.Name);
            WriteInt(parent.Children);

            if (parent.Nodes != null)
            {
                // Iterate through children.
                for (int i = 0; i < parent.Children; i++)
                {
                    // Write child nodes recursively.
                    WriteNodeRecursive(parent.Nodes[i]);
                }
            }
        }

        #endregion

        #region WriteTypes

        /// <summary>
        /// Writes a single byte.
        /// </summary>
        /// <param name="b">Byte to write.</param>
        private void WriteByte(byte b)
        {
            // Writes a single byte.
            if (_swapTable != null)
            {
                // Write the encrypted byte.
                _writer.WriteByte((byte)(_swapTable[0, (b + _writer.Position) & 0xFF]));
            }
            else
            {
                // If being compressed, write byte compressed.
                if (_buffer != null)
                    _buffer.Add(b);
                else  // Normal byte write.
                    _writer.WriteByte(b);
            }
        }

        /// <summary>
        /// Writes a desired amount of bytes.
        /// </summary>
        /// <param name="bytes">Bytes to write.</param>
        private void WriteBytes(byte[] bytes)
        {
            // Iterate through stream bytes.
            for (int i = 0; i < bytes.Length; i++)
            {
                // Write byte.
                WriteByte(bytes[i]);
            }
        }

        /// <summary>
        /// Writes a zero byte.
        /// </summary>
        /// <param name="amount">The amount of zero bytes to write.</param>
        private void WriteEmpty(int amount)
        {
            // Iterate through byte writes.
            for (int i = 0; i < amount; i++)
            {
                // Write empty zero.
                WriteByte(0);
            }
        }

        /// <summary>
        /// Writes a boolean.
        /// </summary>
        /// <param name="boolean">Boolean to write.</param>
        private void WriteBool(bool b)
        {
            // Write a boolean.
            WriteInt(Convert.ToInt32(b));
        }

        /// <summary>
        /// Writes an integer.
        /// </summary>
        /// <param name="integer">Integer to write.</param>
        private void WriteInt(int i)
        {
            // Write bytes.
            WriteBytes(BitConverter.GetBytes(i));
        }

        /// <summary>
        /// Reads a double from file.
        /// </summary>
        /// <returns>A double.</returns>
        private void WriteDouble(double d)
        {
            // Write bytes.
            WriteBytes(BitConverter.GetBytes(d));
        }

        /// <summary>
        /// Writes a string.
        /// </summary>
        /// <param name="chars">The string to write.</param>
        private void WriteString(string s)
        {
            // Write length of string.
            WriteInt(s.Length);

            // Iterate through characters.
            for (int i = 0; i < s.Length; i++)
            {
                // Write character.
                WriteByte((byte)s[i]);
            }
        }

        #endregion

        #region Compression

        /// <summary>
        /// Start compression.
        /// </summary>
        private void Compress()
        {
            // Create a new buffer.
            _buffer = new List<byte>();
        }

        /// <summary>
        /// End compression.
        /// </summary>
        private void EndCompress()
        {
            // If no buffer exists, return.
            if (_buffer == null)
                return;

            // Input buffer.
            byte[] input = _buffer.ToArray();

            // Dump buffer
            _buffer.Clear();
            _buffer = null;

            // Create a new memory stream.
            using (MemoryStream ms = new MemoryStream())
            {
                Deflater compress = new Deflater();
                compress.SetInput(input);
                compress.Finish();

                // the result buffer
                byte[] result = new byte[input.Length];

                // Loop it just in case (shouldn't happen BUT, zlib's been known to cause a size increase)
                while (!compress.IsFinished)
                {
                    int length = compress.Deflate(result);
                    ms.Write(result, 0, length);
                }

                // Write the size of the compressed data, and the data.
                WriteInt((int)ms.Length);
                WriteBytes(ms.ToArray());
            }
        }

        #endregion

        #region Encryption

        /// <summary>
        /// Sets the swap table seed.
        /// </summary>
        /// <param name="s">The almighty seed.</param>
        private void SetSeed(int seed)
        {
            if (seed >= 0)
                _swapTable = MakeSwapTable(seed);
            else
                _swapTable = null;
        }

        /// <summary>
        /// Makes an encryption swap table.
        /// </summary>
        /// <param name="seed">The seed used to make the swap table.</param>
        /// <returns>A new swap table.</returns>
        private int[,] MakeSwapTable(int seed)
        {
            int[,] table = new int[2, 256];
            int a = 6 + (seed % 250);
            int b = seed / 250;

            for (int i = 0; i < 256; i++)
            {
                table[0, i] = i;
            }

            for (int i = 1; i < 10001; i++)
            {
                int j = 1 + ((i * a + b) % 254);
                int t = table[0, j];

                table[0, j] = table[0, j + 1];
                table[0, j + 1] = t;
            }

            for (int i = 1; i < 256; i++)
            {
                table[1, table[0, i]] = i;
            }

            return table;
        }

        #endregion

        #endregion
    }
}
