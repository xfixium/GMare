#region MIT

// 
// GMLib.
// Copyright (C) 2011, 2012, 2013, 2014 Michael Mercado
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
using System.Xml;
using System.Collections.Generic;
using GameMaker.Common;
using GameMaker.Resource;

namespace GameMaker.Project
{
    public class GMProject
    {
        #region Fields

        public event ProgressChangedHandler OnProgressChanged;
        public delegate void ProgressChangedHandler(string message, int percentage);

        public static int InstanceIdMin = 100000;
        public static int TileIdMin = 10000000;
        public int LastInstanceId = InstanceIdMin;
        public int LastTileId = TileIdMin;
        public List<string> Assets = new List<string>();
        public GMVersionType GameMakerVersion = GMVersionType.GameMaker50;
        public GMNode ProjectTree = new GMNode();
        public GMSettings Settings = new GMSettings();
        public GMGameInformation GameInformation = new GMGameInformation();
        public GMList<GMTrigger> Triggers = new GMList<GMTrigger>();
        public GMList<GMSound> Sounds = new GMList<GMSound>();
        public GMList<GMSprite> Sprites = new GMList<GMSprite>();
        public GMList<GMBackground> Backgrounds = new GMList<GMBackground>();
        public GMList<GMPath> Paths = new GMList<GMPath>();
        public GMList<GMScript> Scripts = new GMList<GMScript>();
        public GMList<GMDataFile> DataFiles = new GMList<GMDataFile>();
        public GMList<GMFont> Fonts = new GMList<GMFont>();
        public GMList<GMTimeline> Timelines = new GMList<GMTimeline>();
        public GMList<GMObject> Objects = new GMList<GMObject>();
        public GMList<GMRoom> Rooms = new GMList<GMRoom>();
        public GMList<GMPackage> Packages = new GMList<GMPackage>();
        public GMList<GMLibrary> Libraries = new GMList<GMLibrary>();
        public GMList<GMShader> Shaders = new GMList<GMShader>();

        #endregion

        #region Methods

        #region Refactor

        /// <summary>
        /// Refactors the project's instance ids.
        /// </summary>
        public void RefactorInstanceIds()
        {
            // Reset the instance id.
            LastInstanceId = InstanceIdMin;

            // Iterate through rooms.
            foreach (GMRoom room in Rooms)
            {
                // If instances are empty, continue.
                if (room.Instances == null)
                    continue;

                // Iterate through instances.
                foreach (GMInstance instance in room.Instances)
                {
                    // Set instance id.
                    instance.Id = LastInstanceId;

                    // Increment project's last instance id.
                    LastInstanceId++;
                }
            }
        }

        /// <summary>
        /// Refactors the project's tile ids.
        /// </summary>
        public void RefactorTileIds()
        {
            // Reset the tile id.
            LastTileId = TileIdMin;

            // Iterate through rooms.
            foreach (GMRoom room in Rooms)
            {
                // If tiles are empty, continue.
                if (room.Tiles == null)
                    continue;

                // Iterate through tiles.
                foreach (GMTile tile in room.Tiles)
                {
                    // Set tile id.
                    tile.Id = LastTileId;

                    // Increment project's last tile id.
                    LastTileId++;
                }
            }
        }

        #endregion

        #region General

        /// <summary>
        /// Gets a valid random project id number.
        /// </summary>
        /// <returns>A valid random number for a project id.</returns>
        public int GetRandomProjectId()
        {
            Random random = new Random();
            return random.Next(0, 100000000);
        }

        #endregion

        #region Read

        /// <summary>
        /// Reads a Game Maker Studio project file
        /// </summary>
        private void ReadProjectGMS(string file)
        {
            // Set version
            GameMakerVersion = GMVersionType.GameMakerStudio;

            // Path with project file removed
            string folder = file.Remove(file.LastIndexOf("\\"));

            // Set up resource directory strings
            Dictionary<GMResourceType, string> directories = new Dictionary<GMResourceType, string>();
            directories.Add(GMResourceType.Assets, file);
            directories.Add(GMResourceType.DataFiles, file);
            directories.Add(GMResourceType.Configs, file);
            directories.Add(GMResourceType.Constants, file);
            directories.Add(GMResourceType.Hash, file);
            directories.Add(GMResourceType.Backgrounds, folder + "\\" + "background");
            directories.Add(GMResourceType.Objects, folder + "\\" + "objects");
            directories.Add(GMResourceType.Rooms, folder + "\\" + "rooms");
            directories.Add(GMResourceType.Sprites, folder + "\\" + "sprites");
            directories.Add(GMResourceType.Sounds, folder + "\\" + "sound");
            directories.Add(GMResourceType.TimeLines, folder + "\\" + "timelines");
            directories.Add(GMResourceType.Shaders, folder + "\\" + "shaders");
            directories.Add(GMResourceType.Scripts, folder + "\\" + "scripts");
            directories.Add(GMResourceType.Paths, folder + "\\" + "paths");

            // Resource load index
            int index = 0;

            // Iterate through directories
            foreach (KeyValuePair<GMResourceType, string> item in directories)
            {
                // Increment directory index
                index++;

                // If the directory does not exist, continue
                if (Path.GetExtension(item.Value) != ".gmx" && !Directory.Exists(item.Value))
                    continue;

                // Progress changed
                ProgressChanged("Reading " + item.Key.ToString() + "...", index, directories.Count);

                // Load data based on resource type
                switch (item.Key)
                {
                    case GMResourceType.Hash: Settings.Hash = ReadHashGMX(item.Value); break;
                    case GMResourceType.Assets: ProjectTree = GMNode.ReadTreeGMX(item.Value); Assets = (List<string>)ProjectTree.Tag; break;
                    case GMResourceType.DataFiles: DataFiles = GMDataFile.ReadDataFilesGMX(item.Value); break;
                    case GMResourceType.Sprites: Sprites = GMSprite.ReadSpritesGMX(item.Value, ref Assets); break;
                    //case GMResourceType.Configs: Settings.Configs = GMSettings.GetConfigsGMX(item.Value); break;
                    //case GMResourceType.Constants: Settings.Constants = GMSettings.ReadConstantsGMX(item.Value); break;
                    case GMResourceType.Backgrounds: Backgrounds = GMBackground.ReadBackgroundGMX(item.Value, ref Assets); break;
                    case GMResourceType.Objects: Objects = GMObject.ReadObjectsGMX(item.Value, ref Assets); break;
                    case GMResourceType.Rooms: Rooms = GMRoom.ReadRoomsGMX(item.Value, ref Assets, out LastTileId); break;
                    //case GMResourceType.TimeLines: Timelines = GMTimeline.ReadTimelinesGMX(item.Value, Assets); break;
                    //case GMResourceType.Sounds: Sounds = GMSound.ReadSoundsGMX(item.Value, ref Assets); break;
                    //case GMResourceType.Shaders: Shaders = GMShader.ReadShadersGMX(item.Value, ref Assets); break;
                    //case GMResourceType.Scripts: Scripts = GMScript.ReadScriptsGMX(item.Value, ref Assets); break;
                    //case GMResourceType.Paths: Paths = GMPath.ReadPathsGMX(item.Value, ref Assets); break;
                    //case GMResourceType.TimeLines: Timelines = GMTimeline.ReadTimelinesGMX(item.Value, Assets); break;
                }
            }

            // Retrieve tutorial data
            foreach (GMNode node in ProjectTree.Nodes)
            {
                // If the node is the tutorial state node and it has the nodes we're looking for
                if (node.ResourceType == GMResourceType.TutorialState && node.Nodes != null && node.Nodes.Length == 3)
                {
                    Settings.IsTutorial = node.Nodes[0].Nodes == null ? Settings.IsTutorial : GMResource.GMXBool(node.Nodes[0].Nodes[0].Name, true);
                    Settings.TutorialName = node.Nodes[1].Nodes == null ? Settings.TutorialName : GMResource.GMXString(node.Nodes[1].Nodes[0].FilePath, "");
                    Settings.TutorialPage = node.Nodes[2].Nodes == null ? Settings.TutorialPage : GMResource.GMXInt(node.Nodes[2].Nodes[0].Name, 0);
                }
            }

            // Progress event
            ProgressChanged("Finished Reading Project.", index, directories.Count);
        }

        /// <summary>
        /// Gets hash from project file
        /// </summary>
        /// <param name="path">File path to project file</param>
        private static string ReadHashGMX(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (XmlTextReader reader = new XmlTextReader(new StreamReader(fs)))
                {
                    reader.MoveToContent();
                    return reader.HasAttributes ? reader.GetAttribute(0) : "";
                }
            }
        }

        /// <summary>
        /// Reads a Game Maker project file
        /// </summary>
        public void ReadProject(string file)
        {
            // If the file does not exist, throw exception
            if (File.Exists(file) == false)
            {
                throw new Exception("The Game Maker project file does not exist.");
            }

            // Get file extension
            string ext = file.Substring(file.LastIndexOf('.')).ToLower();

            // If a GMS project file
            if (ext == ".gmx")
            {
                // Read in the project as a Game Maker Studio project and return
                ReadProjectGMS(file);
                return;
            }

            // Get file size
            FileInfo info = new FileInfo(file);
            long length = info.Length;

            // Create a new GM file reader
            using (GMFileReader reader = new GMFileReader(new FileStream(file, FileMode.Open, FileAccess.Read)))
            {
                // Progress event
                ProgressChanged("Starting project read...", reader.BaseStream.Position, length);

                // Read the magic number
                int id = reader.ReadGMInt();

                // If the magic number was incorrect, not a Game Maker project file
                if (id != 1234321)
                    throw new Exception("Not a valid Game Maker project file.");

                // Get Game Maker project file version
                int version = reader.ReadGMInt();

                // Check version
                switch (version)
                {
                    case 500: this.GameMakerVersion = GMVersionType.GameMaker50; break;
                    case 510: this.GameMakerVersion = GMVersionType.GameMaker51; break;
                    case 520: this.GameMakerVersion = GMVersionType.GameMaker52; break;
                    case 530: this.GameMakerVersion = GMVersionType.GameMaker53; break;
                    case 600: this.GameMakerVersion = GMVersionType.GameMaker60; break;
                    case 701: this.GameMakerVersion = GMVersionType.GameMaker70; break;
                    case 800: this.GameMakerVersion = GMVersionType.GameMaker80; break;
                    case 810: this.GameMakerVersion = GMVersionType.GameMaker81; break;
                }

                // Skip over reserved bytes
                if (version < 600)
                    reader.ReadGMBytes(4);

                // Game Maker 7 project file encryption
                if (version == 701)
                {
                    // Bill and Fred, psssttt they like each other ;)
                    int bill = reader.ReadGMInt();
                    int fred = reader.ReadGMInt();

                    // Skip bytes to treasure.
                    reader.ReadGMBytes(bill * 4);

                    // Get the seed for swap table
                    int seed = reader.ReadGMInt();

                    // Skip bytes to get out of the junk yard
                    reader.ReadGMBytes(fred * 4);

                    // Read first byte of Game id (Not encrypted)
                    byte b = reader.ReadByte();

                    // Set the seed
                    reader.SetSeed(seed);

                    // Read game id
                    id = reader.ReadGMInt(b);
                }
                else  // Read game id normally
                    id = reader.ReadGMInt();

                // Skip unknown bytes
                reader.ReadGMBytes(16);

                // Read settings
                ProgressChanged("Reading Settings...", reader.BaseStream.Position, length);

                // Read main project objects
                this.Settings = GMSettings.ReadSettings(reader);
                this.Settings.GameIdentifier = id;

                // If the version is greater than Game Maker 7.0
                if (version > 701)
                {
                    // Read triggers and constants.
                    this.Triggers = GMTrigger.ReadTriggers(reader);
                    this.Settings.Constants = GMConstant.ReadConstants(reader);
                }

                // Read sounds
                ProgressChanged("Reading Sounds...", reader.BaseStream.Position, length);
                this.Sounds = GMSound.ReadSounds(reader);

                // Read sprites
                ProgressChanged("Reading Sprites...", reader.BaseStream.Position, length);
                this.Sprites = GMSprite.ReadSprites(reader);

                // Read backgrounds
                ProgressChanged("Reading Backgrounds...", reader.BaseStream.Position, length);
                this.Backgrounds = GMBackground.ReadBackgrounds(reader);

                // Read paths
                ProgressChanged("Reading Paths...", reader.BaseStream.Position, length);
                this.Paths = GMPath.ReadPaths(reader);

                // Read scripts
                ProgressChanged("Reading Scripts...", reader.BaseStream.Position, length);
                this.Scripts = GMScript.ReadScripts(reader);

                // Get version
                int version2 = reader.ReadGMInt();

                // Check version
                if (version2 != 440 && version2 != 540 && version2 != 800)
                    throw new Exception("Unsupported Pre-Font/Pre-Data File object version.");

                // If version is old, read data files else, read fonts.
                if (version2 == 440)
                {
                    // Read data files
                    ProgressChanged("Reading Data Files...", reader.BaseStream.Position, length);
                    this.DataFiles = GMDataFile.ReadDataFiles(reader);
                }
                else
                {
                    // Read fonts
                    ProgressChanged("Reading Fonts...", reader.BaseStream.Position, length);
                    this.Fonts = GMFont.ReadFonts(version2, reader);
                }

                // Read timelines
                ProgressChanged("Reading Timelines...", reader.BaseStream.Position, length);
                this.Timelines = GMTimeline.ReadTimelines(reader);

                // Read objects
                ProgressChanged("Reading Objects...", reader.BaseStream.Position, length);
                this.Objects = GMObject.ReadObjects(reader);

                // Read rooms
                ProgressChanged("Reading Rooms...", reader.BaseStream.Position, length);
                this.Rooms = GMRoom.ReadRooms(this.Objects, reader);

                // Read last ids for instances and tiles
                this.LastInstanceId = reader.ReadGMInt();
                this.LastTileId = reader.ReadGMInt();

                // If the version is above 6.1, read include files and packages
                if (version >= 700)
                {
                    // Read includes
                    ProgressChanged("Reading Includes...", reader.BaseStream.Position, length);
                    this.Settings.Includes = GMInclude.ReadIncludes(reader);

                    // Read packages
                    ProgressChanged("Reading Packages...", reader.BaseStream.Position, length);
                    this.Packages.AddRange(GMPackage.ReadPackages(reader));
                }

                // Read game information
                ProgressChanged("Reading Game Information...", reader.BaseStream.Position, length);
                this.GameInformation = GMGameInformation.ReadGameInformation(reader);

                // Get version
                version = reader.ReadGMInt();

                // Check version
                if (version != 500)
                    throw new Exception("Unsupported Post-Game Information object version.");

                // Read libraries
                ProgressChanged("Reading Libraries...", reader.BaseStream.Position, length);
                this.Libraries = GMLibrary.ReadLibraries(reader);

                // Read project tree
                ProgressChanged("Reading Project Tree...", reader.BaseStream.Position, length);
                this.ProjectTree = GMNode.ReadTree(file.Substring(file.LastIndexOf(@"\") + 1), reader);

                // Progress event
                ProgressChanged("Finished Reading Project.", reader.BaseStream.Position, length);
            }
        }

        /// <summary>
        /// Call the progress changed event
        /// </summary>
        /// <param name="message">Object state message</param>
        private void ProgressChanged(string message, long position, long length)
        {
            // If no event subscribers, return
            if (OnProgressChanged == null)
                return;

            // Progress event
            OnProgressChanged(message, (int)(position * 100 / length));
        }

        #endregion

        #endregion
    }
}
