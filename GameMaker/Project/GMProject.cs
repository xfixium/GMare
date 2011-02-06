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
using System.Reflection;
using GameMaker.Common;
using GameMaker.Resource;

namespace GameMaker.Project
{
    public class GMProject
    {
        #region Fields

        public static int InstanceIdMin = 100000;
        public static int TileIdMin = 10000000;
        public int LastInstanceId = InstanceIdMin;
        public int LastTileId = TileIdMin;
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

        #endregion

        #region Methods

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

        /// <summary>
        /// Gets a valid random project id number.
        /// </summary>
        /// <returns>A valid random number for a project id.</returns>
        public int GetRandomProjectId()
        {
            Random random = new Random();
            return random.Next(0, 100000000);
        }

        public int GetSize()
        {
            int size = 20;

            size += ProjectTree.GetSize();
            size += Settings.GetSize();
            size += GameInformation.GetSize();

            foreach (GMTrigger trigger in Triggers)
                size += trigger.GetSize();

            foreach (GMSound sound in Sounds)
                size += sound.GetSize();

            foreach (GMSprite sprite in Sprites)
                size += sprite.GetSize();

            foreach (GMBackground background in Backgrounds)
                size += background.GetSize();

            foreach (GMPath path in Paths)
                size += path.GetSize();

            foreach (GMScript script in Scripts)
                size += script.GetSize();

            foreach (GMDataFile datafile in DataFiles)
                size += datafile.GetSize();

            foreach (GMFont font in Fonts)
                size += font.GetSize();

            foreach (GMTimeline timeline in Timelines)
                size += timeline.GetSize();

            foreach (GMObject obj in Objects)
                size += obj.GetSize();

            foreach (GMRoom room in Rooms)
                size += room.GetSize();

            foreach (GMPackage package in Packages)
                size += package.GetSize();

            foreach (GMLibrary lib in Libraries)
                size += lib.GetSize();

            return size;
        }

        #endregion
    }
}
