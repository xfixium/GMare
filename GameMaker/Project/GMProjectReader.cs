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
    /// A class that reads a Game Maker project from disk.
    /// </summary>
    public class GMProjectReader
    {
        #region Fields

        private int[,] _swapTable = null;        // Table used for decryption.
        private MemoryStream _zipStream = null;  // A zip stream used for decompressing data.
        private BinaryReader _reader = null;     // The base underlining stream.

        #endregion

        #region Methods

        #region ReadGMProject

        /// <summary>
        /// Reads a Game Maker project file.
        /// </summary>
        public GMProject ReadProject(string filePath)
        {
            // Create a new stream decoder.
            using (_reader = new BinaryReader(new FileStream(filePath, FileMode.Open, FileAccess.Read)))
            {
                // Create a new project.
                GMProject project = new GMProject();

                // Read the magic number.
                int id = ReadInt();

                // If the magic number was incorrect, not a Game Maker project file
                if (id != 1234321)
                    throw new Exception("Not a valid Game Maker project file.");

                // Get Game Maker project file version.
                int version = ReadInt();

                // Check version.
                switch (version)
                {
                    case 500: project.GameMakerVersion = GMVersionType.GameMaker50; break;
                    case 510: project.GameMakerVersion = GMVersionType.GameMaker51; break;
                    case 520: project.GameMakerVersion = GMVersionType.GameMaker52; break;
                    case 530: project.GameMakerVersion = GMVersionType.GameMaker53; break;
                    case 600: project.GameMakerVersion = GMVersionType.GameMaker60; break;
                    case 701: project.GameMakerVersion = GMVersionType.GameMaker70; break;
                    case 800: project.GameMakerVersion = GMVersionType.GameMaker80; break;
                }

                // Skip over reserved bytes.
                if (version < 600)
                    ReadBytes(4);

                // Game Maker 7 project file encryption.
                if (version == 701)
                {
                    // Bill and Fred, psssttt they like each other ;).
                    int bill = ReadInt();
                    int fred = ReadInt();

                    // Skip bytes to treasure.
                    ReadBytes(bill * 4);

                    // Get the seed for swap table.
                    int seed = ReadInt();

                    // Skip bytes to get out of the junk yard.
                    ReadBytes(fred * 4);

                    // Read first byte of Game id. (Not encrypted).
                    byte b = ReadByte();

                    // Set the seed.
                    SetSeed(seed);

                    // Read game id.
                    id = ReadInt(b);
                }
                else  // Read game id normally.
                    id = ReadInt();

                // Skip unknown bytes.
                ReadBytes(16);

                // Read main project objects.
                project.Settings = ReadSettings();
                project.Settings.GameIdentifier = id;

                // If the version is greater than Game Maker 7.0.
                if (version > 701)
                {
                    // Read triggers and constants.
                    project.Triggers = ReadTriggers();
                    project.Settings.Constants = ReadConstants();
                }

                project.Sounds = ReadSounds();
                project.Sprites = ReadSprites();
                project.Backgrounds = ReadBackgrounds();
                project.Paths = ReadPaths();
                project.Scripts = ReadScripts();

                // Get version.
                int version2 = ReadInt();

                // Check version.
                if (version2 != 440 && version2 != 540  && version2 != 800)
                    throw new Exception("Unsupported Pre-Font/Pre-Data File object version.");

                // If version is old, read data files else, read fonts.
                if (version2 == 440)
                    project.DataFiles = ReadDataFiles();
                else
                    project.Fonts = ReadFonts(version);

                project.Timelines = ReadTimelines();
                project.Objects = ReadObjects();
                project.Rooms = ReadRooms(project.Objects);

                // Read last ids for instances and tiles.
                project.LastInstanceId = ReadInt();
                project.LastTileId = ReadInt();

                // If the version is above 6.1, read include files and packages.
                if (version >= 700)
                {
                    // Get include files.
                    project.Settings.Includes = ReadIncludes();

                    // Get packages.
                    project.Packages.AddRange(ReadPackages());
                }

                // Read game information.
                project.GameInformation = ReadGameInformation();

                // Get version.
                version = ReadInt();

                // Check version.
                if (version != 500)
                    throw new Exception("Unsupported Post-Game Information object version.");

                // Get number of libraries.
                int libNum = ReadInt();

                // Read libraries.
                for (int j = 0; j < libNum; j++)
                {
                    // Create a new library.
                    GMLibrary library = new GMLibrary();

                    // Read the library code.
                    library.Code = ReadString();

                    // Add the library.
                    project.Libraries.Add(library);
                }

                // Read project tree.
                project.ProjectTree = ReadTree(filePath.Substring(filePath.LastIndexOf(@"\") + 1));

                // Return the project.
                return project;
            }
        }

        #endregion

        #region ReadSettings

        /// <summary>
        /// Reads game settings from GM file.
        /// </summary>
        private GMSettings ReadSettings()
        {
            // Create a new game maker settings object.
            GMSettings settings = new GMSettings();

            // Get Game Settings object version.
            int version = ReadInt();

            // Check version.
            if (version != 500 && version != 510 && version != 520 && version != 530 && version != 542 && 
                version != 600 && version != 702 && version != 800)
                throw new Exception("Unsupported Game Settings object version.");

            // If version is GM8, start inflater stream.
            if (version == 800)
                Decompress();

            // Read settings data
            settings.StartFullscreen = ReadBool();

            // Versions greater than 5.3 support interpolation.
            if (version > 542)
                settings.Interpolate = ReadBool();

            // Read settings data.
            settings.DontDrawBorder = ReadBool();
            settings.DisplayCursor = ReadBool();

            // Versions greater than 5.3 support the below variables.
            if (version > 530)
            {
                // Read settings data.
                settings.Scaling = ReadInt();
                settings.AllowWindowResize = ReadBool();
                settings.AlwaysOnTop = ReadBool();
                settings.ColorOutsideRoom = ReadInt();
            }
            else
            {
                // Read settings data.
                settings.ScaleInWindowedMode = ReadInt();
                settings.ScaleInFullScreenMode = ReadInt();
                settings.ScaleOnHardwareSupport = ReadBool();
            }

            // Read settings data.
            settings.SetResolution = ReadBool();

            // Versions greater than 5.3 support the below variables.
            if (version > 530)
            {
                // Read settings data.
                settings.ColorDepth2 = (ColorDepthType2)ReadInt();
                settings.Resolution2 = (ResolutionType2)ReadInt();
                settings.Frequency2 = (FrequencyType2)ReadInt();
            }
            else
            {
                // Read settings data.
                settings.ColorDepth1 = (ColorDepthType1)ReadInt();
                settings.UseExclusiveGraphicsMode = ReadBool();
                settings.Resolution1 = (ResolutionType1)ReadInt();
                settings.Frequency1 = (FrequencyType1)ReadInt();
                settings.UseSynchronization = ReadBool();
                settings.DisplayCaptionInFullScreenMode = ReadBool();
            }

            // Read settings data.
            settings.DontShowButtons = ReadBool();

            // Versions greater than 5.3 support screen synchronization.
            if (version > 530)
                settings.UseSynchronization = ReadBool();

            // Versions greater than 7.0 support disabling the screensaver, and power saving options.
            if (version > 720)
                settings.DisableScreensaver = ReadBool();

            // Read settings.
            settings.LetF4SwitchFullscreen = ReadBool();
            settings.LetF1ShowGameInfo = ReadBool();
            settings.LetEscEndGame = ReadBool();
            settings.LetF5SaveF6Load = ReadBool();

            // Skip reserved bytes.
            if (version < 542)
                ReadBytes(8);

            // Versions greater than 6.0, treat close as esc, F9 screenshot.
            if (version > 600)
            {
                settings.LetF9TakeScreenShot = ReadBool();
                settings.TreatCloseButtonAsESC = ReadBool();
            }

            // Versions greater than 5.1 support game priority.
            if (version > 510)
                settings.GamePriority = (PriorityType)ReadInt();

            // Read settings data.
            settings.FreezeOnLoseFocus = ReadBool();
            settings.LoadBarMode = (LoadProgressBarType)ReadInt();

            // If the loadbar type is a custom loadbar.
            if (settings.LoadBarMode == LoadProgressBarType.Custom)
            {
                // If version is greater than 7.0.
                if (version > 702)
                {
                    // If a back loadbar image exists.
                    if (ReadBool() == true)
                    {
                        // Get size of image data.
                        int size = ReadInt();

                        // Get back loadbar image data.
                        settings.BackLoadBarImage = ReadBytes(size);
                    }

                    // If a front loadbar image exists.
                    if (ReadBool() == true)
                    {
                        // Get size of image data.
                        int size = ReadInt();

                        // Get ffront loadbar image data.
                        settings.FrontLoadBarImage = ReadBytes(size);
                    }
                }
                else
                {
                    // If a back loadbar image exists.
                    if (ReadInt() != -1)
                    {
                        // Get size of image data.
                        int size = ReadInt();

                        // Get back loadbar image data.
                        settings.BackLoadBarImage = ReadBytes(size);
                    }

                    // If a front loadbar image exists.
                    if (ReadInt() != -1)
                    {
                        // Get size of image data.
                        int size = ReadInt();

                        // Get front loadbar image data.
                        settings.FrontLoadBarImage = ReadBytes(size);
                    }
                }
            }

            // Read settings data.
            settings.ShowCustomLoadImage = ReadBool();

            // If a custom load image must be shown
            if (settings.ShowCustomLoadImage == true)
            {
                // If version is greater than 7.0.
                if (version > 702)
                {
                    // If a custom load image is present
                    if (ReadBool() == true)
                    {
                        // Get size of image data
                        int size = ReadInt();

                        // Get custom load image data
                        settings.LoadingImage = ReadBytes(size);
                    }
                }
                else
                {
                    // If a custom load image is present
                    if (ReadInt() != -1)
                    {
                        // Get size of image data
                        int size = ReadInt();

                        // Get custom load image data
                        settings.LoadingImage = ReadBytes(size);
                    }
                }
            }

            // Versions greater than 5.0 support loading image alpha.
            if (version > 500)
            {
                // Read settings data.
                settings.ImagePartiallyTransparent = ReadBool();
                settings.LoadImageAlpha = ReadInt();
                settings.ScaleProgressBar = ReadBool();
            }

            // Get size of icon image data.
            int iconSize = ReadInt();

            // Read settings data.
            settings.GameIcon = ReadBytes(iconSize);
            settings.DisplayErrors = ReadBool();
            settings.WriteToLog = ReadBool();
            settings.AbortOnError = ReadBool();
            settings.TreatUninitializedAsZero = ReadBool();
            settings.Author = ReadString();

            // Versions greater than 6.0 use a string for the version data.
            if (version > 600)
                settings.Version = ReadString();
            else
                settings.Version = ReadInt().ToString();

            // Read settings data.
            settings.ProjectLastChanged = ReadDouble();
            settings.Information = ReadString();

            // Versions greater than 5.2 support constants. Versions greater than 7 read constants elsewhere.
            if (version > 520 && version < 800)
            {
                // Number of constants defined.
                settings.Constants = new GMConstant[ReadInt()];

                // Iterate through constants.
                for (int i = 0; i < settings.Constants.Length; i++)
                {
                    // Create a new constant.
                    GMConstant constant = new GMConstant();

                    // Get constant data.
                    constant.Name = ReadString();
                    constant.Value = ReadString();

                    // Add constant to settings.
                    settings.Constants[i] = constant;
                }
            }

            // If version is greater than 6.0.
            if (version > 600)
            {
                // Read build information.
                settings.Major = ReadInt();
                settings.Minor = ReadInt();
                settings.Release = ReadInt();
                settings.Build = ReadInt();
                settings.Company = ReadString();
                settings.Product = ReadString();
                settings.Copyright = ReadString();
                settings.Description = ReadString();

                // If the version is greater than 7.0, read last time global settings were changed.
                if (version > 702)
                    settings.SettingsLastChanged = ReadDouble();
            }
            else if (version > 530)  // If version is greater than 5.3.
            {
                // Number of include files.
                settings.Includes = new GMInclude[ReadInt()];

                // Get each include file.
                for (int i = 0; i < settings.Includes.Length; i++)
                {
                    // Read settings include file data.
                    settings.Includes[i].FileName = ReadString();
                }

                // Read settings data.
                settings.IncludeFolder = ReadInt();
                settings.OverwriteExisting = ReadBool();
                settings.RemoveAtGameEnd = ReadBool();
            }

            // End inflater.
            EndDecompress();

            // Return a GMProject settings object.
            return settings;
        }

        #endregion

        #region ReadTriggers

        /// <summary>
        /// Reads all triggers from Game Maker project file.
        /// </summary>
        private GMList<GMTrigger> ReadTriggers()
        {
            // Get version.
            int version = ReadInt();

            // Check version.
            if (version != 800)
                throw new Exception("Unsupported Pre-Trigger object version.");

            // Create a new trigger list.
            GMList<GMTrigger> triggers = new GMList<GMTrigger>();

            // Amount of trigger ids.
            int num = ReadInt();

            // Iterate through triggers.
            for (int i = 0; i < num; i++)
            {
                // Start inflate.
                Decompress();

                // If the trigger at index does not exists, continue.
                if (ReadBool() == false)
                {
                    triggers.LastId++;
                    EndDecompress();
                    continue;
                }

                // Get version.
                version = ReadInt();

                // Check version.
                if (version != 800)
                    throw new Exception("Unsupported trigger object version.");

                // Create a new trigger.
                GMTrigger trigger = new GMTrigger();

                // Read trigger data.
                trigger.Name = ReadString();
                trigger.Condition = ReadString();
                trigger.Moment = (MomentType)ReadInt();
                trigger.Constant = ReadString();

                // End object inflate.
                EndDecompress();

                // Add trigger.
                triggers.Add(trigger);
            }

            // Get last changed.
            GMTrigger.LastChanged = ReadDouble();

            // Return triggers.
            return triggers;
        }

        #endregion

        #region ReadConstants

        /// <summary>
        /// Reads all constants from Game Maker project file.
        /// </summary>
        private GMConstant[] ReadConstants()
        {
            // Get version.
            int version = ReadInt();

            // Check version.
            if (version != 800)
                throw new Exception("Unsupported Pre-Sound object version.");

            // Number of constants defined.
            GMConstant[] constants = new GMConstant[ReadInt()];

            // Iterate through constants.
            for (int i = 0; i < constants.Length; i++)
            {
                // Create a new constant.
                GMConstant constant = new GMConstant();

                // Get constant data.
                constant.Name = ReadString();
                constant.Value = ReadString();

                // Add constant.
                constants[i] = constant;
            }

            // Last changed.
            GMConstant.LastChanged = ReadDouble();

            // Return constants.
            return constants;
        }

        #endregion

        #region ReadSounds

        /// <summary>
        /// Reads all sounds from Game Maker project file.
        /// </summary>
        private GMList<GMSound> ReadSounds()
        {
            // Get version.
            int version = ReadInt();

            // Check version.
            if (version != 400 && version != 800)
                throw new Exception("Unsupported Pre-Sound object version.");

            // Create a new sound list.
            GMList<GMSound> sounds = new GMList<GMSound>();

            // Amount of sound ids.
            int num = ReadInt();

            // Iterate through sounds.
            for (int i = 0; i < num; i++)
            {
                // If version is 8.0, start inflate.
                if (version == 800)
                    Decompress();
                
                // If the sound at index does not exists, continue.
                if (ReadBool() == false)
                {
                    sounds.LastId++;
                    EndDecompress();
                    continue;
                }

                // Create sound object.
                GMSound sound = new GMSound();

                // Set sound id.
                sound.Id = i;

                // Read sound data.
                sound.Name = ReadString();

                // If version is 8.0, get last changed.
                if (version == 800)
                    sound.LastChanged = ReadDouble();

                // Get version.
                version = ReadInt();

                // Check version.
                if (version != 440 && version != 600 && version != 800)
                    throw new Exception("Unsupported Sound object version.");

                // Check version.
                if (version == 440)
                    sound.Kind = (SoundKind)ReadInt();
                else
                    // Read sound data.
                    sound.Type = (SoundType)ReadInt();

                // Read sound data.
                sound.FileType = ReadString();

                // Check version.
                if (version == 440)
                {
                    // If sound data exists, read it.
                    if ((int)sound.Kind != -1)
                        sound.Data = ReadBytes(ReadInt());

                    // Read sound data.
                    sound.AllowSoundEffects = ReadBool();
                    sound.Buffers = ReadInt();
                    sound.LoadOnlyOnUse = ReadBool();
                }
                else
                {
                    // Read sound data.
                    sound.FileName = ReadString();

                    // If sound data exists, read it.
                    if (ReadBool() == true)
                        sound.Data = ReadBytes(ReadInt());

                    // Read sound data.
                    sound.Effects = ReadInt();
                    sound.Volume = ReadDouble();
                    sound.Pan = ReadDouble();
                    sound.Preload = ReadBool();
                }

                // End object inflate.
                EndDecompress();

                // Add sound.
                sounds.Add(sound);
            }

            // Return sounds.
            return sounds;
        }

        #endregion

        #region ReadSprites

        /// <summary>
        /// Reads sprites from Game Maker project file.
        /// </summary>
        private GMList<GMSprite> ReadSprites()
        {
            // Get version.
            int version = ReadInt();

            // Check version.
            if (version != 400 && version != 800)
                throw new Exception("Unsupported Pre-Sprite object version.");

            // Create a new list of sprites.
            GMList<GMSprite> sprites = new GMList<GMSprite>();

            // Amount of sprite ids.
            int num = ReadInt();

            // Iterate through sprites.
            for (int i = 0; i < num; i++)
            {
                // If version is 8.0, start inflate.
                if (version == 800)
                    Decompress();

                // If the sprite at index does not exists, continue.
                if (ReadBool() == false)
                {
                    sprites.LastId++;
                    EndDecompress();
                    continue;
                }

                // Create a new sprite object.
                GMSprite sprite = new GMSprite();

                // Set sprite id.
                sprite.Id = i;

                // Read sprite data.
                sprite.Name = ReadString();

                // If version is 8.0, get last changed.
                if (version == 800)
                    sprite.LastChanged = ReadDouble();

                // Get version.
                version = ReadInt();

                // Check version.
                if (version != 400 && version != 542 && version != 800)
                    throw new Exception("Unsupported Sprite object version.");

                // If less than version 8.0.
                if (version < 800)
                {
                    // Read sprite data
                    sprite.Width = ReadInt();
                    sprite.Height = ReadInt();
                    sprite.BoundingBoxLeft = ReadInt();
                    sprite.BoundingBoxRight = ReadInt();
                    sprite.BoundingBoxBottom = ReadInt();
                    sprite.BoundingBoxTop = ReadInt();
                    sprite.Transparent = ReadBool();

                    // Check version.
                    if (version > 400)
                    {
                        // Read sprite data
                        sprite.SmoothEdges = ReadBool();
                        sprite.Preload = ReadBool();
                    }

                    // Read sprite data.
                    sprite.BoundingBoxMode = (BoundingBoxType)ReadInt();
                    sprite.Precise = ReadBool();

                    // Check version.
                    if (version == 400)
                    {
                        // Read sprtie data.
                        sprite.UseVideoMemory = ReadBool();
                        sprite.LoadOnlyOnUse = ReadBool();
                    }

                    // Read sprite data.
                    sprite.OriginX = ReadInt();
                    sprite.OriginY = ReadInt();

                    // Sprite number of sub images
                    sprite.SubImages = new GMImage[ReadInt()];

                    // Iterate through sub-images
                    for (int j = 0; j < sprite.SubImages.Length; j++)
                    {
                        // If the sub-image at index does not exists, continue.
                        if (ReadInt() == -1)
                            continue;

                        // Create a new image object.
                        GMImage image = new GMImage();

                        // Get size of image data.
                        int size = ReadInt();

                        // Get image data.
                        image.Data = ReadBytes(size);

                        // Insert compressed image data.
                        sprite.SubImages[j] = image;
                    }
                }
                else
                {
                    // Read sprite data.
                    sprite.OriginX = ReadInt();
                    sprite.OriginY = ReadInt();

                    // Sprite number of sub images.
                    sprite.SubImages = new GMImage[ReadInt()];

                    // Iterate through sub-images.
                    for (int j = 0; j < sprite.SubImages.Length; j++)
                    {
                        // Get version.
                        version = ReadInt();

                        // Check version.
                        if (version != 800)
                            throw new Exception("Unsupported Sprite object version.");

                        // Get width and height of image.
                        int width = ReadInt();
                        int height = ReadInt();

                        // If the sprite size is not zero.
                        if (width != 0 && height != 0)
                        {
                            // Create a new image object.
                            GMImage image = new GMImage();
                            image.Compressed = false;

                            // Set image data.
                            image.Width = width;
                            image.Height = height;

                            // Get size of image data.
                            int size = ReadInt();

                            // Get image data.
                            image.Data = ReadBytes(size);

                            // Insert compressed image data.
                            sprite.SubImages[j] = image;
                        }
                    }

                    // Read sprite data.
                    sprite.ShapeMode = (ShapeType)ReadInt();
                    sprite.AlphaTolerance = ReadInt();
                    sprite.UseSeperateCollisionMasks = ReadBool();
                    sprite.BoundingBoxMode = (BoundingBoxType)ReadInt();
				    sprite.BoundingBoxLeft = ReadInt();
                    sprite.BoundingBoxRight = ReadInt();
                    sprite.BoundingBoxBottom = ReadInt();
                    sprite.BoundingBoxTop = ReadInt();
                }

                // End object inflate.
                EndDecompress();

                // Add sprite.
                sprites.Add(sprite);
            }

            // Return sprites.
            return sprites;
        }

        #endregion

        #region ReadBackgrounds

        /// <summary>
        /// Reads backgrounds from GM file.
        /// </summary>
        private GMList<GMBackground> ReadBackgrounds()
        {
            // Get version.
            int version = ReadInt();

            // Check version.
            if (version != 400 && version != 800)
                throw new Exception("Unsupported Pre-Background object version.");

            // Create a new list of backgrounds.
            GMList<GMBackground> backgrounds = new GMList<GMBackground>();

            // Amount of background ids.
            int num = ReadInt();

            // Iterate through backgrounds.
            for (int i = 0; i < num; i++)
            {
                // If version is 8.0, start inflate.
                if (version == 800)
                    Decompress();

                // If the background at index does not exists, continue.
                if (ReadBool() == false)
                {
                    backgrounds.LastId++;
                    EndDecompress();
                    continue;
                }

                // Create a new background object.
                GMBackground background = new GMBackground();

                // Set background id
                background.Id = i;

                // Get background data. 
                background.Name = ReadString();

                // If version is 8.0, get last changed.
                if (version == 800)
                    background.LastChanged = ReadDouble();

                // Get version.
                version = ReadInt();

                // Check version.
                if (version != 400 && version != 543 && version != 710)
                    throw new Exception("Unsupported Background object version.");

                // If version is less than 7.1.
                if (version < 710)
                {
                    // Background data
                    background.Width = ReadInt();
                    background.Height = ReadInt();
                    background.Transparent = ReadBool();

                    // Check version.
                    if (version > 400)
                    {
                        // Read background data.
                        background.SmoothEdges = ReadBool();
                        background.Preload = ReadBool();
                        background.UseAsTileSet = ReadBool();
                        background.TileWidth = ReadInt();
                        background.TileHeight = ReadInt();
                        background.HorizontalOffset = ReadInt();
                        background.VerticalOffset = ReadInt();
                        background.HorizontalSeperation = ReadInt();
                        background.VerticalSeperation = ReadInt();
                    }
                    else
                    {
                        // Read background data.
                        background.UseVideoMemory = ReadBool();
                        background.LoadOnlyOnUse = ReadBool();
                    }

                    // If image data exists.
                    if (ReadBool())
                    {
                        // If pixel data does not exist.
                        if (ReadInt() == -1)
                            continue;

                        // Create a new image.
                        GMImage image = new GMImage();

                        // Get size of image data.
                        int size = ReadInt();

                        // Get compressed image data.
                        image.Data = ReadBytes(size);

                        // Set background image.
                        background.Image = image;
                    }
                }
                else
                {
                    // Get background data.
                    background.UseAsTileSet = ReadBool();
                    background.TileWidth = ReadInt();
                    background.TileHeight = ReadInt();
                    background.HorizontalOffset = ReadInt();
                    background.VerticalOffset = ReadInt();
                    background.HorizontalSeperation = ReadInt();
                    background.VerticalSeperation = ReadInt();

                    // Get version.
				    version = ReadInt();

				    // Check version.
                    if (version != 800)
                        throw new Exception("Unsupported Background object version.");

                    // Get image data.
				    background.Width = ReadInt();
				    background.Height = ReadInt();

                    // If the sprite size is not zero.
                    if (background.Width != 0 && background.Height != 0)
                    {
                        // Create a new image object.
                        GMImage image = new GMImage();
                        image.Compressed = false;

                        // Set image data.
                        image.Width = background.Width;
                        image.Height = background.Height;

                        // Get size of image data.
                        int size = ReadInt();

                        // Get image data.
                        image.Data = ReadBytes(size);

                        // Insert compressed image data.
                        background.Image = image;
                    }
                }

                // End object inflate.
                EndDecompress();

                // Add background.
                backgrounds.Add(background);
            }

            // Return backgrounds.
            return backgrounds;
        }

        #endregion

        #region ReadPaths

        /// <summary>
        /// Reads paths from GM file.
        /// </summary>
        private GMList<GMPath> ReadPaths()
        {
            // Get version.
            int version = ReadInt();

            // Check version.
            if (version != 420 && version !=800)
                throw new Exception("Unsupported Pre-Path object version.");

            // Create a new list of paths.
            GMList<GMPath> paths = new GMList<GMPath>();

            // Amount of path indexes.
            int num = ReadInt();

            // Iterate through paths.
            for (int i = 0; i < num; i++)
            {
                // If version is 8.0, start inflate.
                if (version == 800)
                    Decompress();

                // If the path at index does not exists, continue.
                if (ReadBool() == false)
                {
                    paths.LastId++;
                    EndDecompress();
                    continue;
                }

                // Create a new path object.
                GMPath path = new GMPath();

                // Set path id.
                path.Id = i;

                // Read path data.
                path.Name = ReadString();

                // If version is 8.0, get last changed.
                if (version == 800)
                    path.LastChanged = ReadDouble();

                // Get version.
                int version2 = ReadInt();

                // Check version.
                if (version2 != 420 && version2 != 530)
                    throw new Exception("Unsupported Path object version.");

                // Check version.
                if (version2 > 420)
                {
                    // Read path data.
                    path.Smooth = ReadBool();
                    path.Closed = ReadBool();
                    path.Precision = ReadInt();
                    path.RoomId = ReadInt();
                    path.SnapX = ReadInt();
                    path.SnapY = ReadInt();
                }
                else
                {
                    // Read path data.
                    path.Smooth = ReadBool();
                    path.ActionAtTheEnd = (ActionAtTheEnd)ReadInt();
                    ReadBytes(4);
                }

                // Number of path points.
                path.Points = new GMPoint[ReadInt()];

                // Iterate through path points.
                for (int j = 0; j < path.Points.Length; j++)
                {
                    // Create a new point.
                    GMPoint point = new GMPoint();

                    // Read point data.
                    point.X = ReadDouble();
                    point.Y = ReadDouble();
                    point.Speed = ReadDouble();

                    // Set point.
                    path.Points[j] = point;
                }

                // End object inflate.
                EndDecompress();

                // Add path.
                paths.Add(path);
            }

            // Return paths.
            return paths;
        }

        #endregion

        #region ReadScripts

        /// <summary>
        /// Reads scripts from GM file
        /// </summary>
        private GMList<GMScript> ReadScripts()
        {
            // Get version.
            int version = ReadInt();

            // Check version.
            if (version != 400 && version != 800)
                throw new Exception("Unsupported Pre-Script object version.");

            // Create a new list of scripts.
            GMList<GMScript> scripts = new GMList<GMScript>();

            // Amount of script ids.
            int num = ReadInt();

            // Iterate through scripts.
            for (int i = 0; i < num; i++)
            {
                // If version is 8.0, start inflate.
                if (version == 800)
                    Decompress();

                // If the script at index does not exists, continue.
                if (ReadBool() == false)
                {
                    scripts.LastId++;
                    EndDecompress();
                    continue;
                }

                // Create a new script object.
                GMScript script = new GMScript();

                // Set script id.
                script.Id = i;

                // Read script data.
                script.Name = ReadString();

                // If version is 8.0, get last changed.
                if (version == 800)
                    script.LastChanged = ReadDouble();

                // Get version.
                version = ReadInt();

                // Check version.
                if (version != 400 && version != 800)
                    throw new Exception("Unsupported Script object version.");

                // Read script data.
                script.Code = ReadString();

                // End object inflate.
                EndDecompress();

                // Add script.
                scripts.Add(script);
            }

            // Return scripts.
            return scripts;
        }

        #endregion

        #region ReadDataFiles

        /// <summary>
        /// Reads data files from GM file.
        /// </summary>
        private GMList<GMDataFile> ReadDataFiles()
        {
            // Create a new list of data files.
            GMList<GMDataFile> dataFiles = new GMList<GMDataFile>();

            // Amount of data file ids.
            int num = ReadInt();

            // Iterate through data files.
            for (int i = 0; i < num; i++)
            {
                // If the data file at index does not exists, continue.
                if (ReadBool() == false)
                {
                    dataFiles.LastId++;
                    continue;
                }

                // Create a new data file object.
                GMDataFile dataFile = new GMDataFile();

                // Set data file id.
                dataFile.Id = i;

                // Read data file data.
                dataFile.Name = ReadString();

                // Get version.
                int version = ReadInt();

                // Check version.
                if (version != 440)
                    throw new Exception("Unsupported Data File object version.");

                // Read data file data.
                dataFile.FileName = ReadString();

                // If data file exists, read it in.
                if (ReadBool())
                    dataFile.Data = ReadBytes(ReadInt());
                
                // Read data file data.
                dataFile.ExportMode = (ExportType)(ReadInt());
                dataFile.OverwriteFile = ReadBool();
                dataFile.FreeDataMemory = ReadBool();
                dataFile.RemoveAtGameEnd = ReadBool();

                // Add data file.
                dataFiles.Add(dataFile);
            }

            // Return data files.
            return dataFiles;
        }

        #endregion

        #region ReadFonts

        /// <summary>
        /// Reads fonts from GM file.
        /// </summary>
        private GMList<GMFont> ReadFonts(int version)
        {
            // Create a new list of fonts.
            GMList<GMFont> fonts = new GMList<GMFont>();

            // Amount of font ids.
            int num = ReadInt();

            // Iterate through fonts.
            for (int i = 0; i < num; i++)
            {
                // If version is 8.0, start inflate.
                if (version == 800)
                    Decompress();

                // If the font at index does not exists, continue.
                if (ReadBool() == false)
                {
                    fonts.LastId++;
                    EndDecompress();
                    continue;
                }

                // Create a new font object.
                GMFont font = new GMFont();

                // Set font id.
                font.Id = i;

                // Read font data.
                font.Name = ReadString();

                // If version is 8.0, get last changed.
                if (version == 800)
                    font.LastChanged = ReadDouble();

                // Get version.
                version = ReadInt();

                // Check version.
                if (version != 540 && version != 800)
                    throw new Exception("Unsupported Font object version.");

                // Read font data.
                font.FontName = ReadString();
                font.Size = ReadInt();
                font.Bold = ReadBool();
                font.Italic = ReadBool();
                font.CharacterRangeMin = ReadInt();
                font.CharacterRangeMax = ReadInt();

                // End object inflate.
                EndDecompress();

                // Add font.
                fonts.Add(font);
            }

            // Return fonts.
            return fonts;
        }

        #endregion

        #region ReadTimelines

        /// <summary>
        /// Reads timelines from GM file.
        /// </summary>
        private GMList<GMTimeline> ReadTimelines()
        {
            // Get version.
            int version = ReadInt();

            // Check version.
            if (version != 500 && version != 800)
                throw new Exception("Unsupported Pre-Timeline object version.");

            // Create a new timeline list.
            GMList<GMTimeline> timelines = new GMList<GMTimeline>();

            // Amount of timeline ids.
            int num = ReadInt();

            // Iterate through timelines
            for (int i = 0; i < num; i++)
            {
                // If version is 8.0, start inflate.
                if (version == 800)
                    Decompress();

                // If the timeline at index does not exists, continue.
                if (ReadBool() == false)
                {
                    timelines.LastId++;
                    EndDecompress();
                    continue;
                }

                // Create a new timeline object.
                GMTimeline timeline = new GMTimeline();

                // Set timeline id.
                timeline.Id = i;

                // Read timeline data.
                timeline.Name = ReadString();

                // If version is 8.0, get last changed.
                if (version == 800)
                    timeline.LastChanged = ReadDouble();

                // Get version.
                int version2 = ReadInt();

                // Check version.
                if (version2 != 500)
                    throw new Exception("Unsupported Timeline object version.");

                // Get number of timeline moments.
                timeline.Moments = new GMMoment[ReadInt()];

                // Iterate through moments.
                for (int j = 0; j < timeline.Moments.Length; j++)
                {
                    // Create a new timeline moment object.
                    GMMoment moment = new GMMoment();

                    // Moment step number
                    moment.StepIndex = ReadInt();

                    // Read moment actions.
                    moment.Actions = ReadActions();

                    // Add moment to timeline.
                    timeline.Moments[j] = moment;
                }

                // End object inflate.
                EndDecompress();

                // Add timeline.
                timelines.Add(timeline);
            }

            // Return timelines.
            return timelines;
        }

        #endregion

        #region ReadObjects

        /// <summary>
        /// Reads objects from GM file
        /// </summary>
        private GMList<GMObject> ReadObjects()
        {
            // Get version.
            int version = ReadInt();

            // Check version.
            if (version != 400 && version != 800)
                throw new Exception("Unsupported Pre-Object object version.");

            // The number of objects.
            GMList<GMObject> objects = new GMList<GMObject>();

            // Amount of object ids.
            int num = ReadInt();

            // Iterate through objects
            for (int i = 0; i < num; i++)
            {
                // If version is 8.0, start inflate.
                if (version == 800)
                    Decompress();

                // If the object at index does not exists, continue.
                if (ReadBool() == false)
                {
                    objects.LastId++;
                    EndDecompress();
                    continue;
                }

                // Create a new script object.
                GMObject obj = new GMObject();

                // Set script id.
                obj.Id = i;

                // Read script data.
                obj.Name = ReadString();

                // If version is 8.0, get last changed.
                if (version == 800)
                    obj.LastChanged = ReadDouble();

                // Get version.
                int version2 = ReadInt();

                // Check version.
                if (version2 != 430)
                    throw new Exception("Unsupported Object object version.");

                // Read object data.
                obj.SpriteId = ReadInt();
                obj.Solid = ReadBool();
                obj.Visible = ReadBool();
                obj.Depth = ReadInt();
                obj.Persistent = ReadBool();
                obj.Parent = ReadInt();
                obj.Mask = ReadInt();

                // Skip data.
                ReadBytes(4);

                // The amount of main event types.
                int amount = 11;

                // If version 8.0, there are 12 main event types.
                if (version == 800)
                    amount = 12;

                // Iterate through events.
                for (int j = 0; j < amount; j++)
                {
                    // Not done processing.
                    bool done = false;

                    // While not done processing events.
                    while (!done)
                    {
                        // Check for event
                        int eventNum = ReadInt();

                        // If the event exists
                        if (eventNum != -1)
                        {
                            // Create new event.
                            GMEvent ev = new GMEvent();

                            // Set type of event.
                            ev.MainType = (EventType)(j);

                            // If a collision type of event set other object id.
                            if (ev.MainType == EventType.Collision)
                                ev.OtherId = eventNum;
                            else
                                ev.SubType = eventNum;

                            // Read event actions.
                            ev.Actions = ReadActions();

                            // Add new event.
                            obj.Events[j].Add(ev);
                        }
                        else
                            done = true;
                    }
                }

                // End object inflate.
                EndDecompress();

                // Add object to list.
                objects.Add(obj);
            }

            // Return objects.
            return objects;
        }

        #endregion

        #region ReadRooms

        /// <summary>
        /// Reads rooms from GM file
        /// </summary>
        private GMList<GMRoom> ReadRooms(GMList<GMObject> objects)
        {
            // Get version.
            int version = ReadInt();

            // Check version.
            if (version != 420 && version != 800)
                throw new Exception("Unsupported Pre-Room object version.");

            // Create a new list of rooms.
            GMList<GMRoom> rooms = new GMList<GMRoom>();

            // Amount of room indexes.
            int num = ReadInt();

            // Iterate through rooms.
            for (int i = 0; i < num; i++)
            {
                // If version is 8.0, start inflate.
                if (version == 800)
                    Decompress();

                // If the room at index does not exists, continue.
                if (ReadBool() == false)
                {
                    rooms.LastId++;
                    EndDecompress();
                    continue;
                }

                // Create a room object.
                GMRoom room = new GMRoom();

                // Set room id.
                room.Id = i;

                // Read room data.
                room.Name = ReadString();

                // If version is 8.0, get last changed.
                if (version == 800)
                    room.LastChanged = ReadDouble();

                // Get version.
                int version2 = ReadInt();

                // Check version.
                if (version2 != 500 && version2 != 520 && version2 != 541)
                    throw new Exception("Unsupported Room object version.");

                // Read room data.
                room.Caption = ReadString();
                room.Width = ReadInt();
                room.Height = ReadInt();
                room.SnapY = ReadInt();
                room.SnapX = ReadInt();

                // Versions greater than 5.1 support isometric grid.
                if (version2 > 500)
                    room.IsometricGrid = ReadBool();

                room.Speed = ReadInt();
                room.Persistent = ReadBool();
                room.BackgroundColor = ReadInt();
                room.DrawBackgroundColor = ReadBool();
                room.CreationCode = ReadString();

                // Create new parallax array.
                room.Parallaxes = new GMParallax[ReadInt()];

                // Iterate through parallaxs.
                for (int j = 0; j < room.Parallaxes.Length; j++)
                {
                    // Create a new parallax object.
                    room.Parallaxes[j] = new GMParallax();

                    // Read room parallax data.
                    room.Parallaxes[j].Visible = ReadBool();
                    room.Parallaxes[j].Foreground = ReadBool();
                    room.Parallaxes[j].BackgroundId = ReadInt();
                    room.Parallaxes[j].X = ReadInt();
                    room.Parallaxes[j].Y = ReadInt();
                    room.Parallaxes[j].TileHorizontally = ReadBool();
                    room.Parallaxes[j].TileVertically = ReadBool();
                    room.Parallaxes[j].HorizontalSpeed = ReadInt();
                    room.Parallaxes[j].VerticalSpeed = ReadInt();

                    // Versions greater than 5.1 support parallax stretching.
                    if (version2 > 500)
                        room.Parallaxes[j].Stretch = ReadBool();
                }

                // Read room data.
                room.EnableViews = ReadBool();

                // Create new view array.
                room.Views = new GMView[ReadInt()];

                // Iterate through views
                for (int k = 0; k < room.Views.Length; k++)
                {
                    // Create new view object.
                    room.Views[k] = new GMView();

                    // Read room view data.
                    room.Views[k].Visible = ReadBool();
                    room.Views[k].ViewX = ReadInt();
                    room.Views[k].ViewY = ReadInt();
                    room.Views[k].ViewWidth = ReadInt();
                    room.Views[k].ViewHeight = ReadInt();
                    room.Views[k].PortX = ReadInt();
                    room.Views[k].PortY = ReadInt();

                    // Versions greater than 5.3 support port dimensions.
                    if (version2 > 520)
                    {
                        room.Views[k].PortWidth = ReadInt();
                        room.Views[k].PortHeight = ReadInt();
                    }

                    // Read room view data.
                    room.Views[k].HorizontalBorder = ReadInt();
                    room.Views[k].VerticalBorder = ReadInt();
                    room.Views[k].HorizontalSpeed = ReadInt();
                    room.Views[k].VerticalSpeed = ReadInt();
                    room.Views[k].ObjectToFollow = ReadInt();
                }

                // Create a new array of instances.
                room.Instances = new GMInstance[ReadInt()];

                // Iterate through room instances.
                for (int l = 0; l < room.Instances.Length; l++)
                {
                    // Create new instance.
                    room.Instances[l] = new GMInstance();

                    // Read room instance data.
                    room.Instances[l].X = ReadInt();
                    room.Instances[l].Y = ReadInt();
                    room.Instances[l].ObjectId = ReadInt();
                    room.Instances[l].Id = ReadInt();

                    // Versions greater than 5.1 support creation code and instance locking.
                    if (version2 > 500)
                    {
                        // Read room instance data.
                        room.Instances[l].CreationCode = ReadString();
                        room.Instances[l].Locked = ReadBool();
                    }

                    // Get the object the instance references.
                    GMObject obj = objects.Find(delegate(GMObject o) { return o.Id == room.Instances[l].ObjectId; });

                    // If the object was found, set instance name and depth.
                    if (obj != null)
                    {
                        // Read room instance data.
                        room.Instances[l].Name = obj.Name;
                        room.Instances[l].Depth = obj.Depth;
                    }

                    // Skipped reserved bytes.
                    if (version2 < 520)
                        ReadBytes(8);
                }

                // Create a new array of tiles.
                room.Tiles = new GMTile[ReadInt()];

                // Iterate through room tiles.
                for (int m = 0; m < room.Tiles.Length; m++)
                {
                    // Create new tile object.
                    room.Tiles[m] = new GMTile();

                    // Read room tile data.
                    room.Tiles[m].X = ReadInt();
                    room.Tiles[m].Y = ReadInt();
                    room.Tiles[m].BackgroundId = ReadInt();
                    room.Tiles[m].BackgroundX = ReadInt();
                    room.Tiles[m].BackgroundY = ReadInt();
                    room.Tiles[m].Width = ReadInt();
                    room.Tiles[m].Height = ReadInt();
                    room.Tiles[m].Depth = ReadInt();
                    room.Tiles[m].Id = ReadInt();

                    // Versions greater than 5.1 support tile locking.
                    if (version2 > 500)
                        room.Tiles[m].Locked = ReadBool();
                }

                // Read room data.
                room.RememberWindowSize = ReadBool();
                room.EditorWidth = ReadInt();
                room.EditorHeight = ReadInt();
                room.ShowGrid = ReadBool();
                room.ShowObjects = ReadBool();
                room.ShowTiles = ReadBool();
                room.ShowBackgrounds = ReadBool();
                room.ShowForegrounds = ReadBool();
                room.ShowViews = ReadBool();
                room.DeleteUnderlyingObjects = ReadBool();
                room.DeleteUnderlyingTiles = ReadBool();

                // Versions greater than 5.3 don't support tile settings.
                if (version2 > 520)
                {
                    // Read room tile data.
                    room.CurrentTab = (TabSetting)(ReadInt());
                    room.ScrollBarX = ReadInt();
                    room.ScrollBarY = ReadInt();
                }
                else
                {
                    // Read room tile data.
                    room.TileWidth = ReadInt();
                    room.TileHeight = ReadInt();
                    room.TileHorizontalSeperation = ReadInt();
                    room.TileVerticalSeperation = ReadInt();
                    room.TileHorizontalOffset = ReadInt();
                    room.TileVerticalOffset = ReadInt();
                    room.CurrentTab = (TabSetting)(ReadInt());
                    room.ScrollBarX = ReadInt();
                    room.ScrollBarY = ReadInt();
                }

                // End object inflate.
                EndDecompress();

                // Set room.
                rooms.Add(room);
            }

            // Return rooms
            return rooms;
        }

        #endregion

        #region ReadActions

        /// <summary>
        /// Reads actions from a GM file
        /// </summary>
        private GMAction[] ReadActions()
        {
            // Get version.
            int version = ReadInt();

            // Check version.
            if (version != 400)
                throw new Exception("Unsupported Pre-Action object version.");

            // Create an array of actions.
            GMAction[] actions = new GMAction[ReadInt()];

            // Iterate through actions.
            for (int i = 0; i < actions.Length; i++)
            {
                // Create new action
                actions[i] = new GMAction();

                // Get version.
                version = ReadInt();

                // Check version.
                if (version != 440)
                    throw new Exception("Unsupported Action object version.");

                // Get action properties.
                actions[i].LibraryId = ReadInt();
                actions[i].ActionId = ReadInt();
                actions[i].ActionKind = (ActionType)(ReadInt());
                actions[i].AllowRelative = ReadBool();
                actions[i].Question = ReadBool();
                actions[i].CanApplyTo = ReadBool();
                actions[i].ExecuteMode = (ExecutionType)(ReadInt());

                // If the execute mode is a prefabbed function.
                if (actions[i].ExecuteMode == ExecutionType.Function)
					actions[i].ExecuteCode = ReadString();
				else
					ReadBytes(ReadInt());

                // If the execute mode is a script.
                if (actions[i].ExecuteMode == ExecutionType.Code)
                    actions[i].ExecuteCode = ReadString();
                else
                    ReadBytes(ReadInt());

                // Create an array of arguments.
                actions[i].Arguments = new GMArgument[ReadInt()];

                // Number of argument types.
                int[] argTypes = new int[ReadInt()];

                // Iterate through argument types
                for (int j = 0; j < argTypes.Length; j++)
                {
                    // Read in argument type.
                    argTypes[j] = ReadInt();
                }

                // Read action data.
                actions[i].AppliesTo = ReadInt();
                actions[i].Relative = ReadBool();

                // Get actual number of arguments, most likely 8.
                int argsNum = ReadInt();

                // Iterate through argument types.
                for (int k = 0; k < argsNum; k++)
                {
                    // If the index is greater than or equal to the number of arguments, continue.
                    if (k >= actions[i].Arguments.Length)
                    {
                        ReadBytes(ReadInt());
                        continue;
                    }

                    // Create a new argument object.
                    actions[i].Arguments[k] = new GMArgument();

                    // Set what kind of argument.
                    actions[i].Arguments[k].Type = (ArgumentType)(argTypes[k]);

                    // Resource value.
                    actions[i].Arguments[k].Value = ReadString();
                }

                // If not checkbox has been checked.
                actions[i].Not = ReadBool();
            }

            // Return action object.
            return actions;
        }

        #endregion

        #region ReadIncludes

        /// <summary>
        /// Reads game includes from GM file.
        /// </summary>
        private GMInclude[] ReadIncludes()
        {
            // Get version.
            int version = ReadInt();

            // Check version.
		    if (version != 430 && version != 600 && version != 620 && version != 800)
                throw new Exception("Unsupported Pre-Includes object version.");

            // Create a new array of includes.
            GMInclude[] includes = new GMInclude[ReadInt()];

            // Iterate through includes.
            for (int i = 0; i < includes.Length; i++)
            {
                // Create a new include object.
                GMInclude include = new GMInclude();

                // If version is 8.0, get last changed.
                if (version == 800)
                    include.LastChanged = ReadDouble();

                // Get version.
                version = ReadInt();

                // Check version.
                if (version != 620 && version != 800)
                    throw new Exception("Unsupported Includes object version.");

                // Read include data.
                include.FileName = ReadString();
                include.FilePath = ReadString();
                include.OriginalFileChosen = ReadBool();
                include.OriginalFileSize = ReadInt();
                include.StoreInEditableGMKFile = ReadBool();

                // If the include file will be stored within the executable, read data.
                if (include.StoreInEditableGMKFile == true)
                    include.Data = ReadBytes(ReadInt());

                // Read include data.
                include.ExportMode = (ExportType)(ReadInt());
                include.FolderToExport = ReadInt();
                include.OverwriteIfExists = ReadBool();
                include.FreeMemoryAfterExport = ReadBool();
                include.RemoveAtGameEnd = ReadBool();

                // Set include object.
                includes[i] = include;
            }

            // Return include objects.
            return includes;
        }

        #endregion

        #region ReadPackages

        /// <summary>
        /// Reads game packages from GM file.
        /// </summary>
        private GMPackage[] ReadPackages()
        {
            // Get version.
            int version = ReadInt();

            // Check version
            if (version != 700)
                throw new Exception("Unsupported Extension object version.");

            // Get the number of packages.
            GMPackage[] packages = new GMPackage[ReadInt()];

            // Read packages.
            for (int i = 0; i < packages.Length; i++)
            {
                // Create a new package.
                GMPackage package = new GMPackage();

                // Read package name.
                package.Name = ReadString();

                // Set package.
                packages[i] = package;
            }

            return packages;
        }

        #endregion

        #region ReadGameInformation

        /// <summary>
        /// Reads game information from GM file.
        /// </summary>
        private GMGameInformation ReadGameInformation()
        {
            // Get version.
            int version = ReadInt();

            // Check version.
            if (version != 430 && version != 600 && version != 620 && version != 800)
                throw new Exception("Unsupported Pre-Game Information object version.");

            // Create new game information.
            GMGameInformation gameInfo = new GMGameInformation();

            // If version is 8.0, start inflate.
            if (version == 800)
                Decompress();

            // Read game information data.
            gameInfo.BackgroundColor = ReadInt();
            gameInfo.MimicGameWindow = ReadBool();

            // Check version.
            if (version > 430)
            {
                // Read game information data.
                gameInfo.FormCaption = ReadString();
                gameInfo.X = ReadInt();
                gameInfo.Y = ReadInt();
                gameInfo.Width = ReadInt();
                gameInfo.Height = ReadInt();
                gameInfo.ShowBorder = ReadBool();
                gameInfo.AllowResize = ReadBool();
                gameInfo.AlwaysOnTop = ReadBool();
                gameInfo.PauseGame = ReadBool();
            }

            // If version is 8.0, get last changed.
            if (version == 800)
                gameInfo.LastChanged = ReadDouble();

            // Read game information data.
            gameInfo.Information = ReadString();

            // End object inflate.
            EndDecompress();

            // Return game information object.
            return gameInfo;
        }

        #endregion

        #region ReadTree

        /// <summary>
        /// Reads Object Tree from GM file
        /// </summary>
        private GMNode ReadTree(string name)
        {
            // Get version.
            int version = ReadInt();

            // Check version.
            if (version != 500 && version != 540 && version != 700)
                throw new Exception("Unsupported Project Tree object version.");

            // Room execution Order.
            ReadBytes(ReadInt() * 4);

            // Set the number of main resource nodes.
            int rootNum = (version > 540) ? 12 : 11;

            // Create a project node;
            GMNode projectTree = new GMNode();
            projectTree.Nodes = new GMNode[rootNum];
            projectTree.Name = name;
            projectTree.NodeType = GMNodeType.Parent;
            projectTree.Children = projectTree.Nodes.Length;

            // Iterate through Game Maker project root nodes
            for (int i = 0; i < rootNum; i++)
            {
                // Create new node
                GMNode node = new GMNode();

                // Read node data.
                node.NodeType = (GMNodeType)(ReadInt());
                node.ResourceType = (GMResourceType)(ReadInt());
                node.Id = ReadInt();
                node.Name = ReadString();
                node.Children = ReadInt();

                // If there is at least one child node.
                if (node.Children > 0)
                {
                    // Create a new node array.
                    node.Nodes = new GMNode[node.Children];

                    // Iterate through children.
                    for (int j = 0; j < node.Children; j++)
                    {
                        // Add new node.
                        node.Nodes[j] = new GMNode();
                    }

                    // Read in child nodes recursively.
                    ReadNodeRecursive(node);
                }

                // Add new main node.
                projectTree.Nodes[i] = node;
            }

            // Return project tree.
            return projectTree;
        }

        /// <summary>
        /// Reads a Game Maker tree node recursively.
        /// </summary>
        private  void ReadNodeRecursive(GMNode parent)
        {
            // Iterate through child nodes.
            foreach (GMNode node in parent.Nodes)
            {
                // Read node data.
                node.NodeType = (GMNodeType)(ReadInt());
                node.ResourceType = (GMResourceType)(ReadInt());
                node.Id = ReadInt();
                node.Name = ReadString();
                node.Children = ReadInt();

                // If the node has child nodes.
                if (node.Children > 0)
                {
                    // Create a new node array.
                    node.Nodes = new GMNode[node.Children];

                    // Iterate through children.
                    for (int i = 0; i < node.Children; i++)
                    {
                        // Add new node.
                        node.Nodes[i] = new GMNode();
                    }

                    // Read in child nodes recursively.
                    ReadNodeRecursive(node);
                }
            }
        }

        #endregion

        #region ReadMethods

        /// <summary>
        /// Reads a single byte, also decrypts GM 7 byte.
        /// </summary>
        /// <returns>A byte.</returns>
        private byte ReadByte()
        {
            // Return a single byte.
            if (_swapTable != null)
            {
                // data.
                int t = (byte)_reader.ReadByte() & 0xFF;

                // Return the decrypted byte.
                return (byte)((_swapTable[1, t] - _reader.BaseStream.Position + 1) & 0xFF);
            }
            else
            {
                // If a zip stream exists.
                if (_zipStream != null)
                    return (byte)_zipStream.ReadByte();
                else
                    // Normal stream read.
                    return _reader.ReadByte();
            }
        }

        /// <summary>
        /// Reads a desired amount of bytes.
        /// </summary>
        /// <param name="amount">The amount of bytes to read.</param>
        /// <returns>The read byte array.</returns>
        private byte[] ReadBytes(int amount)
        {
            // Create a new byte array.
            byte[] bytes = new byte[amount];

            // Iterate through stream bytes.
            for (int i = 0; i < amount; i++)
            {
                // Set byte.
                bytes[i] = ReadByte();
            }

            // Return a byte array.
            return bytes;
        }

        /// <summary>
        /// Reads a boolean from stream.
        /// </summary>
        /// <returns>A boolean.</returns>
        private bool ReadBool()
        {
            // Read a boolean from stream.
            return Convert.ToBoolean(ReadInt());
        }

        /// <summary>
        /// Reads an integer from file.
        /// </summary>
        /// <returns>An integer.</returns>
        private int ReadInt()
        {
            // Create a new byte array.
            byte[] bytes = new byte[4];

            // Read 4 bytes.
            bytes[0] = ReadByte();
            bytes[1] = ReadByte();
            bytes[2] = ReadByte();
            bytes[3] = ReadByte();

            // Return integer from bytes.
            return BitConverter.ToInt32(bytes, 0);
        }

        /// <summary>
        /// Reads an integer from file. With a pre-existing first byte.
        /// </summary>
        /// <returns>An integer.</returns>
        private int ReadInt(byte i)
        {
            // Create a new byte array.
            byte[] bytes = new byte[4];

            // Set first byte, read the rest.
            bytes[0] = i;
            bytes[1] = ReadByte();
            bytes[2] = ReadByte();
            bytes[3] = ReadByte();

            // Return integer from bytes.
            return BitConverter.ToInt32(bytes, 0);
        }

        /// <summary>
        /// Reads a double from file.
        /// </summary>
        /// <returns>A double.</returns>
        private double ReadDouble()
        {
            // Create new byte array.
            byte[] bytes = new byte[8];

            // Read eight bytes.
            bytes[0] = ReadByte();
            bytes[1] = ReadByte();
            bytes[2] = ReadByte();
            bytes[3] = ReadByte();
            bytes[4] = ReadByte();
            bytes[5] = ReadByte();
            bytes[6] = ReadByte();
            bytes[7] = ReadByte();

            // Return double from bytes.
            return BitConverter.ToDouble(bytes, 0);
        }

        /// <summary>
        /// Reads a string from file.
        /// </summary>
        private string ReadString()
        {
            // Length of string.
            int length = ReadInt();

            // Array of characters.
            char[] chars = new char[length];

            // Iterate through characters.
            for (int i = 0; i < length; i++)
            {
                chars[i] = (char)ReadByte();
            }

            // Return string.
            return new string(chars);
        }

        #endregion

        #region Decompression

        /// <summary>
        /// Start decompression.
        /// </summary>
        private void Decompress()
        {
            Inflater inf = new Inflater();
            int size = ReadInt();

            inf.SetInput(ReadBytes(size));
            byte[] result = new byte[size * 4];
            _zipStream = new MemoryStream();

            while (!inf.IsFinished)
            {
                int length = inf.Inflate(result);
                _zipStream.Write(result, 0, length);
            }

            _zipStream.Position = 0;
        }

        /// <summary>
        /// End decompression.
        /// </summary>
        private void EndDecompress()
        {
            // If not decompressing, ignore.
            if (_zipStream == null)
                return;

            _zipStream.Close();
            _zipStream = null;
        }

        #endregion

        #region Decryption

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