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

namespace GameMaker.Resource
{
    [Serializable]
    public class GMRoom : GMResource
    {
        #region Fields

        private GMInstance[] _instances = null;
        private GMTile[] _tiles = null;
        private TabSetting _currentTab = TabSetting.Objects;
        private GMParallax[] _parallaxes = new GMParallax[8];
        private GMView[] _views = new GMView[8];
        private string _caption = "";
        private string _creationCode = "";
        private double _physicsWorldPixToMeters = 0.100000001490116;
        private int _width = 640;
        private int _height = 480;
        private int _speed = 30;
        private int _editorWidth = 200;
        private int _editorHeight = 200;
        private int _snapX = 16;
        private int _snapY = 16;
        private int _tileWidth = 16;
        private int _tileHeight = 16;
        private int _tileHorizontalSeperation = 1;
        private int _tileVerticalSeperation = 1;
        private int _tileHorizontalOffset = 0;
        private int _tileVerticalOffset = 0;
        private int _backgroundColor = 0;
        private int _scrollBarX = 0;
        private int _scrollBarY = 0;
        private int _physicsWorldTop = 0;
        private int _physicsWorldLeft = 0;
        private int _physicsWorldRight = 640;
        private int _physicsWorldBottom = 480;
        private int _physicsWorldGravityX = 0;
        private int _physicsWorldGravityY = 10;
        private bool _persistent = false;
        private bool _drawBackgroundColor = true;
        private bool _enableViews = false;
        private bool _rememberWindowSize = true;
        private bool _showGrid = true;
        private bool _isometricGrid = false;
        private bool _showObjects = true;
        private bool _showTiles = true;
        private bool _showBackgrounds = true;
        private bool _showForegrounds = true;
        private bool _showViews = false;
        private bool _deleteUnderlyingObjects = true;
        private bool _deleteUnderlyingTiles = true;
        private bool _clearViewBackground = false;
        private bool _physicsWorld = false;

        #endregion

        #region Properties

        public GMInstance[] Instances
        {
            get { return _instances; }
            set { _instances = value; }
        }

        public GMTile[] Tiles
        {
            get { return _tiles; }
            set { _tiles = value; }
        }

        public TabSetting CurrentTab
        {
            get { return _currentTab; }
            set { _currentTab = value; }
        }

        public GMParallax[] Parallaxes
        {
            get { return _parallaxes; }
            set { _parallaxes = value; }
        }

        public GMView[] Views
        {
            get { return _views; }
            set { _views = value; }
        }

        public string Caption
        {
            get { return _caption; }
            set { _caption = value; }
        }

        public string CreationCode
        {
            get { return _creationCode; }
            set { _creationCode = value; }
        }

        public double PhysicsWorldPixToMeters
        {
            get { return _physicsWorldPixToMeters; }
            set { _physicsWorldPixToMeters = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public int EditorWidth
        {
            get { return _editorWidth; }
            set { _editorWidth = value; }
        }

        public int EditorHeight
        {
            get { return _editorHeight; }
            set { _editorHeight = value; }
        }

        public int SnapX
        {
            get { return _snapX; }
            set { _snapX = value; }
        }

        public int SnapY
        {
            get { return _snapY; }
            set { _snapY = value; }
        }

        public int TileWidth
        {
            get { return _tileWidth; }
            set { _tileWidth = value; }
        }

        public int TileHeight
        {
            get { return _tileHeight; }
            set { _tileHeight = value; }
        }

        public int TileHorizontalSeperation
        {
            get { return _tileHorizontalSeperation; }
            set { _tileHorizontalSeperation = value; }
        }

        public int TileVerticalSeperation
        {
            get { return _tileVerticalSeperation; }
            set { _tileVerticalSeperation = value; }
        }

        public int TileHorizontalOffset
        {
            get { return _tileHorizontalOffset; }
            set { _tileHorizontalOffset = value; }
        }

        public int TileVerticalOffset
        {
            get { return _tileVerticalOffset; }
            set { _tileVerticalOffset = value; }
        }

        public int BackgroundColor
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }

        public int ScrollBarX
        {
            get { return _scrollBarX; }
            set { _scrollBarX = value; }
        }

        public int ScrollBarY
        {
            get { return _scrollBarY; }
            set { _scrollBarY = value; }
        }

        public int PhysicsWorldTop
        {
            get { return _physicsWorldTop; }
            set { _physicsWorldTop = value; }
        }

        public int PhysicsWorldLeft
        {
            get { return _physicsWorldLeft; }
            set { _physicsWorldLeft = value; }
        }

        public int PhysicsWorldRight
        {
            get { return _physicsWorldRight; }
            set { _physicsWorldRight = value; }
        }

        public int PhysicsWorldBottom
        {
            get { return _physicsWorldBottom; }
            set { _physicsWorldBottom = value; }
        }

        public int PhysicsWorldGravityX
        {
            get { return _physicsWorldGravityX; }
            set { _physicsWorldGravityX = value; }
        }

        public int PhysicsWorldGravityY
        {
            get { return _physicsWorldGravityY; }
            set { _physicsWorldGravityY = value; }
        }

        public bool Persistent
        {
            get { return _persistent; }
            set { _persistent = value; }
        }

        public bool DrawBackgroundColor
        {
            get { return _drawBackgroundColor; }
            set { _drawBackgroundColor = value; }
        }

        public bool EnableViews
        {
            get { return _enableViews; }
            set { _enableViews = value; }
        }

        public bool RememberWindowSize
        {
            get { return _rememberWindowSize; }
            set { _rememberWindowSize = value; }
        }

        public bool ShowGrid
        {
            get { return _showGrid; }
            set { _showGrid = value; }
        }

        public bool IsometricGrid
        {
            get { return _isometricGrid; }
            set { _isometricGrid = value; }
        }

        public bool ShowObjects
        {
            get { return _showObjects; }
            set { _showObjects = value; }
        }

        public bool ShowTiles
        {
            get { return _showTiles; }
            set { _showTiles = value; }
        }

        public bool ShowBackgrounds
        {
            get { return _showBackgrounds; }
            set { _showBackgrounds = value; }
        }

        public bool ShowForegrounds
        {
            get { return _showForegrounds; }
            set { _showForegrounds = value; }
        }

        public bool ShowViews
        {
            get { return _showViews; }
            set { _showViews = value; }
        }

        public bool DeleteUnderlyingObjects
        {
            get { return _deleteUnderlyingObjects; }
            set { _deleteUnderlyingObjects = value; }
        }

        public bool DeleteUnderlyingTiles
        {
            get { return _deleteUnderlyingTiles; }
            set { _deleteUnderlyingTiles = value; }
        }

        public bool ClearViewBackground
        {
            get { return _clearViewBackground; }
            set { _clearViewBackground = value; }
        }

        public bool PhysicsWorld
        {
            get { return _physicsWorld; }
            set { _physicsWorld = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Construct a new Game Maker room.
        /// </summary>
        public GMRoom()
        {
            // Create a new array of parallaxs.
            for (int i = 0; i < _parallaxes.Length; i++)
                _parallaxes[i] = new GMParallax();

            // Create a new array of views.
            for (int j = 0; j < _views.Length; j++)
                _views[j] = new GMView();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Reads all rooms from a GM file reader stream
        /// </summary>
        public static GMList<GMRoom> ReadRooms(GMList<GMObject> objects, GMFileReader reader)
        {
            // Get version
            int version = reader.ReadGMInt();

            // Check version
            if (version != 420 && version != 800)
                throw new Exception("Unsupported Pre-Room object version.");

            // Create a new list of rooms
            GMList<GMRoom> rooms = new GMList<GMRoom>();

            // Amount of room indexes
            int num = reader.ReadGMInt();

            // Iterate through rooms.
            for (int i = 0; i < num; i++)
            {
                // If version is 8.0, start inflate.
                if (version == 800)
                    reader.Decompress();

                // If the room at index does not exists, continue.
                if (reader.ReadGMBool() == false)
                {
                    rooms.LastId++;
                    reader.EndDecompress();
                    continue;
                }

                // Create a room object.
                GMRoom room = new GMRoom();

                // Set room id.
                room.Id = i;

                // Read room data.
                room.Name = reader.ReadGMString();

                // If version is 8.0, get last changed.
                if (version == 800)
                    room.LastChanged = reader.ReadGMDouble();

                // Get version.
                int version2 = reader.ReadGMInt();

                // Check version.
                if (version2 != 500 && version2 != 520 && version2 != 541)
                    throw new Exception("Unsupported Room object version.");

                // Read room data.
                room.Caption = reader.ReadGMString();
                room.Width = reader.ReadGMInt();
                room.Height = reader.ReadGMInt();
                room.SnapY = reader.ReadGMInt();
                room.SnapX = reader.ReadGMInt();

                // Versions greater than 5.1 support isometric grid.
                if (version2 > 500)
                    room.IsometricGrid = reader.ReadGMBool();

                room.Speed = reader.ReadGMInt();
                room.Persistent = reader.ReadGMBool();
                room.BackgroundColor = reader.ReadGMInt();
                room.DrawBackgroundColor = reader.ReadGMBool();
                room.CreationCode = reader.ReadGMString();

                // Create new parallax array.
                room.Parallaxes = new GMParallax[reader.ReadGMInt()];

                // Iterate through parallaxs.
                for (int j = 0; j < room.Parallaxes.Length; j++)
                {
                    // Create a new parallax object.
                    room.Parallaxes[j] = new GMParallax();

                    // Read room parallax data.
                    room.Parallaxes[j].Visible = reader.ReadGMBool();
                    room.Parallaxes[j].Foreground = reader.ReadGMBool();
                    room.Parallaxes[j].BackgroundId = reader.ReadGMInt();
                    room.Parallaxes[j].X = reader.ReadGMInt();
                    room.Parallaxes[j].Y = reader.ReadGMInt();
                    room.Parallaxes[j].TileHorizontally = reader.ReadGMBool();
                    room.Parallaxes[j].TileVertically = reader.ReadGMBool();
                    room.Parallaxes[j].HorizontalSpeed = reader.ReadGMInt();
                    room.Parallaxes[j].VerticalSpeed = reader.ReadGMInt();

                    // Versions greater than 5.1 support parallax stretching.
                    if (version2 > 500)
                        room.Parallaxes[j].Stretch = reader.ReadGMBool();
                }

                // Read room data.
                room.EnableViews = reader.ReadGMBool();

                // Create new view array.
                room.Views = new GMView[reader.ReadGMInt()];

                // Iterate through views
                for (int k = 0; k < room.Views.Length; k++)
                {
                    // Create new view object.
                    room.Views[k] = new GMView();

                    // Read room view data.
                    room.Views[k].Visible = reader.ReadGMBool();
                    room.Views[k].ViewX = reader.ReadGMInt();
                    room.Views[k].ViewY = reader.ReadGMInt();
                    room.Views[k].ViewWidth = reader.ReadGMInt();
                    room.Views[k].ViewHeight = reader.ReadGMInt();
                    room.Views[k].PortX = reader.ReadGMInt();
                    room.Views[k].PortY = reader.ReadGMInt();

                    // Versions greater than 5.3 support port dimensions.
                    if (version2 > 520)
                    {
                        room.Views[k].PortWidth = reader.ReadGMInt();
                        room.Views[k].PortHeight = reader.ReadGMInt();
                    }

                    // Read room view data.
                    room.Views[k].HorizontalBorder = reader.ReadGMInt();
                    room.Views[k].VerticalBorder = reader.ReadGMInt();
                    room.Views[k].HorizontalSpeed = reader.ReadGMInt();
                    room.Views[k].VerticalSpeed = reader.ReadGMInt();
                    room.Views[k].ObjectToFollow = reader.ReadGMInt();
                }

                // Create a new array of instances.
                room.Instances = new GMInstance[reader.ReadGMInt()];

                // Iterate through room instances.
                for (int l = 0; l < room.Instances.Length; l++)
                {
                    // Create new instance.
                    room.Instances[l] = new GMInstance();

                    // Read room instance data.
                    room.Instances[l].X = reader.ReadGMInt();
                    room.Instances[l].Y = reader.ReadGMInt();
                    room.Instances[l].ObjectId = reader.ReadGMInt();
                    room.Instances[l].Id = reader.ReadGMInt();

                    // Versions greater than 5.1 support creation code and instance locking.
                    if (version2 > 500)
                    {
                        // Read room instance data.
                        room.Instances[l].CreationCode = reader.ReadGMString();
                        room.Instances[l].Locked = reader.ReadGMBool();
                    }

                    // Get the object the instance references.
                    GMObject obj = objects.Find(delegate(GMObject o) { return o.Id == room.Instances[l].ObjectId; });

                    // If the object was found, set instance name.
                    if (obj != null)
                        room.Instances[l].Name = obj.Name;

                    // Skipped reserved bytes.
                    if (version2 < 520)
                        reader.ReadGMBytes(8);
                }

                // Create a new array of tiles.
                room.Tiles = new GMTile[reader.ReadGMInt()];

                // Iterate through room tiles.
                for (int m = 0; m < room.Tiles.Length; m++)
                {
                    // Create new tile object.
                    room.Tiles[m] = new GMTile();

                    // Read room tile data.
                    room.Tiles[m].X = reader.ReadGMInt();
                    room.Tiles[m].Y = reader.ReadGMInt();
                    room.Tiles[m].BackgroundId = reader.ReadGMInt();
                    room.Tiles[m].BackgroundX = reader.ReadGMInt();
                    room.Tiles[m].BackgroundY = reader.ReadGMInt();
                    room.Tiles[m].Width = reader.ReadGMInt();
                    room.Tiles[m].Height = reader.ReadGMInt();
                    room.Tiles[m].Depth = reader.ReadGMInt();
                    room.Tiles[m].Id = reader.ReadGMInt();

                    // Versions greater than 5.1 support tile locking.
                    if (version2 > 500)
                        room.Tiles[m].Locked = reader.ReadGMBool();
                }

                // Read room data.
                room.RememberWindowSize = reader.ReadGMBool();
                room.EditorWidth = reader.ReadGMInt();
                room.EditorHeight = reader.ReadGMInt();
                room.ShowGrid = reader.ReadGMBool();
                room.ShowObjects = reader.ReadGMBool();
                room.ShowTiles = reader.ReadGMBool();
                room.ShowBackgrounds = reader.ReadGMBool();
                room.ShowForegrounds = reader.ReadGMBool();
                room.ShowViews = reader.ReadGMBool();
                room.DeleteUnderlyingObjects = reader.ReadGMBool();
                room.DeleteUnderlyingTiles = reader.ReadGMBool();

                // Versions greater than 5.3 don't support tile settings.
                if (version2 > 520)
                {
                    // Read room tile data.
                    room.CurrentTab = (TabSetting)(reader.ReadGMInt());
                    room.ScrollBarX = reader.ReadGMInt();
                    room.ScrollBarY = reader.ReadGMInt();
                }
                else
                {
                    // Read room tile data.
                    room.TileWidth = reader.ReadGMInt();
                    room.TileHeight = reader.ReadGMInt();
                    room.TileHorizontalSeperation = reader.ReadGMInt();
                    room.TileVerticalSeperation = reader.ReadGMInt();
                    room.TileHorizontalOffset = reader.ReadGMInt();
                    room.TileVerticalOffset = reader.ReadGMInt();
                    room.CurrentTab = (TabSetting)(reader.ReadGMInt());
                    room.ScrollBarX = reader.ReadGMInt();
                    room.ScrollBarY = reader.ReadGMInt();
                }

                // End object inflate.
                reader.EndDecompress();

                // Set room.
                rooms.Add(room);
            }

            // Return rooms
            return rooms;
        }

        /// <summary>
        /// Reads all GMX rooms from a directory
        /// </summary>
        /// <param name="file">The XML (.GMX) file path</param>
        /// <returns>A list of rooms</returns>
        public static GMList<GMRoom> ReadRoomsGMX(string directory, List<string> assets, out int lastTileId)
        {
            // Last tile id counter
            lastTileId = 0;

            // A list of rooms
            GMList<GMRoom> rooms = new GMList<GMRoom>();

            // Iterate through .gmx files in the directory
            foreach (string file in Directory.GetFiles(directory, "*.gmx"))
            {
                // Set name of the room
                string name = GMFileReader.GetResourceName(file);

                // If the file is not in the asset list, it has been orphaned, continue
                if (!assets.Contains(name))
                    continue;

                // Create a dictionary of room properties
                Dictionary<GMXRoomProperty, string> properties = new Dictionary<GMXRoomProperty, string>();

                foreach (GMXRoomProperty property in Enum.GetValues(typeof(GMXRoomProperty)))
                    properties.Add(property, "");

                // Local variables
                List<GMTile> tiles = new List<GMTile>();
                List<GMParallax> backgrounds = new List<GMParallax>();
                List<GMView> views = new List<GMView>();
                List<GMInstance> instances = new List<GMInstance>();

                // Create an xml reader
                using (XmlReader xmlReader = XmlReader.Create(file))
                {
                    // Seek to content
                    xmlReader.MoveToContent();

                    // Read the GMX file
                    while (xmlReader.Read())
                    {
                        // If the node is not an element, continue
                        if (xmlReader.NodeType != XmlNodeType.Element)
                            continue;

                        // Get the element name
                        string nodeName = xmlReader.Name;

                        // If the element is a background element, else if a view, else if an instance, else a normal property
                        if (nodeName.ToLower() == EnumString.GetEnumString(GMXRoomProperty.Background).ToLower())
                        {
                            // Create a background and add it to the list of backgrounds
                            GMParallax background = new GMParallax();
                            background.Visible = GMFileReader.ReadGMXBool(xmlReader.GetAttribute(EnumString.GetEnumString(GMXParallaxProperty.Visible)));
                            background.Foreground = GMFileReader.ReadGMXBool(xmlReader.GetAttribute(EnumString.GetEnumString(GMXParallaxProperty.Visible)));
                            background.BackgroundName = xmlReader.GetAttribute(EnumString.GetEnumString(GMXParallaxProperty.Name));
                            background.X = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXParallaxProperty.X)));
                            background.Y = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXParallaxProperty.Y)));
                            background.TileHorizontally = GMFileReader.ReadGMXBool(xmlReader.GetAttribute(EnumString.GetEnumString(GMXParallaxProperty.HTiled)));
                            background.TileVertically = GMFileReader.ReadGMXBool(xmlReader.GetAttribute(EnumString.GetEnumString(GMXParallaxProperty.VTiled)));
                            background.HorizontalSpeed = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXParallaxProperty.HSpeed)));
                            background.VerticalSpeed = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXParallaxProperty.VSpeed)));
                            background.Stretch = GMFileReader.ReadGMXBool(xmlReader.GetAttribute(EnumString.GetEnumString(GMXParallaxProperty.Stretch)));
                            backgrounds.Add(background);
                        }
                        else if (nodeName.ToLower() == EnumString.GetEnumString(GMXRoomProperty.View).ToLower())
                        {
                            // Create a view and add it to the list of views
                            GMView view = new GMView();
                            view.Visible = GMFileReader.ReadGMXBool(xmlReader.GetAttribute(EnumString.GetEnumString(GMXViewProperty.Visible)));
                            view.ObjectToFollowName = xmlReader.GetAttribute(EnumString.GetEnumString(GMXViewProperty.ObjName));
                            view.ViewX = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXViewProperty.XView)));
                            view.ViewY = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXViewProperty.YView)));
                            view.ViewWidth = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXViewProperty.WView)));
                            view.ViewHeight = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXViewProperty.HView)));
                            view.PortX = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXViewProperty.XPort)));
                            view.PortY = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXViewProperty.YPort)));
                            view.PortWidth = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXViewProperty.WPort)));
                            view.PortHeight = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXViewProperty.HPort)));
                            view.HorizontalBorder = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXViewProperty.HBorder)));
                            view.VerticalBorder = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXViewProperty.VBorder)));
                            view.HorizontalSpeed = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXViewProperty.HSpeed)));
                            view.VerticalSpeed = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXViewProperty.VSpeed)));
                            views.Add(view);
                        }
                        else if (nodeName.ToLower() == EnumString.GetEnumString(GMXRoomProperty.Instance).ToLower())
                        {
                            // Create an instance and add it to the list of instances
                            GMInstance instance = new GMInstance();
                            instance.ObjectName = xmlReader.GetAttribute(EnumString.GetEnumString(GMXInstanceProperty.ObjName));
                            instance.X = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXInstanceProperty.X)));
                            instance.Y = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXInstanceProperty.Y)));
                            instance.Name = xmlReader.GetAttribute(EnumString.GetEnumString(GMXInstanceProperty.Name));
                            instance.Locked = GMFileReader.ReadGMXBool(xmlReader.GetAttribute(EnumString.GetEnumString(GMXInstanceProperty.Locked)));
                            instance.CreationCode = xmlReader.GetAttribute(EnumString.GetEnumString(GMXInstanceProperty.Code));
                            instance.ScaleX = GMFileReader.ReadGMXDouble(xmlReader.GetAttribute(EnumString.GetEnumString(GMXInstanceProperty.ScaleX)));
                            instance.ScaleY = GMFileReader.ReadGMXDouble(xmlReader.GetAttribute(EnumString.GetEnumString(GMXInstanceProperty.ScaleY)));
                            instance.BlendColor = GMFileReader.ReadGMXUInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXInstanceProperty.Colour)));
                            instance.Rotation = GMFileReader.ReadGMXDouble(xmlReader.GetAttribute(EnumString.GetEnumString(GMXInstanceProperty.Rotation)));
                            instances.Add(instance);
                        }
                        else if (nodeName.ToLower() == EnumString.GetEnumString(GMXRoomProperty.Tile).ToLower())
                        {
                            // Create an tile and add it to the list of tiles
                            GMTile tile = new GMTile();
                            tile.BackgroundName = xmlReader.GetAttribute(EnumString.GetEnumString(GMXTileProperty.BGName));
                            tile.BackgroundX = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXTileProperty.X)));
                            tile.BackgroundY = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXTileProperty.Y)));
                            tile.Width = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXTileProperty.W)));
                            tile.Height = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXTileProperty.H)));
                            tile.X = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXTileProperty.XO)));
                            tile.Y = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXTileProperty.YO)));
                            tile.Id = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXTileProperty.Id)));
                            tile.Name = xmlReader.GetAttribute(EnumString.GetEnumString(GMXTileProperty.Name));
                            tile.Depth = GMFileReader.ReadGMXInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXTileProperty.Depth)));
                            tile.Locked = GMFileReader.ReadGMXBool(xmlReader.GetAttribute(EnumString.GetEnumString(GMXTileProperty.Locked)));
                            tile.BlendColor = GMFileReader.ReadGMXUInt(xmlReader.GetAttribute(EnumString.GetEnumString(GMXTileProperty.Colour)));
                            tile.ScaleX = GMFileReader.ReadGMXDouble(xmlReader.GetAttribute(EnumString.GetEnumString(GMXTileProperty.ScaleX)));
                            tile.ScaleY = GMFileReader.ReadGMXDouble(xmlReader.GetAttribute(EnumString.GetEnumString(GMXTileProperty.ScaleY)));
                            tiles.Add(tile);

                            // If the tile id is greater than the current tile id
                            if (tile.Id > lastTileId)
                                lastTileId = tile.Id;
                        }

                        // Read element
                        xmlReader.Read();

                        // If the element value is null or empty, continue
                        if (String.IsNullOrEmpty(xmlReader.Value))
                            continue;

                        // Get the enumeration based on the node name
                        GMXRoomProperty? property = EnumString.GetEnumFromString<GMXRoomProperty>(nodeName);

                        // If no match was found, continue
                        if (property == null)
                            continue;

                        // Set the property value
                        properties[(GMXRoomProperty)property] = xmlReader.Value;
                    }
                }

                // Create a new room, set properties
                GMRoom room = new GMRoom();
                room.Id = GMResource.GetIdFromName(name);
                room.Name = name;
                room.Caption = properties[GMXRoomProperty.Caption];
                room.Width = GMFileReader.ReadGMXInt(properties[GMXRoomProperty.Width]);
                room.Height = GMFileReader.ReadGMXInt(properties[GMXRoomProperty.Height]);
                room.SnapY = GMFileReader.ReadGMXInt(properties[GMXRoomProperty.VSnap]);
                room.SnapX = GMFileReader.ReadGMXInt(properties[GMXRoomProperty.HSnap]);
                room.IsometricGrid = GMFileReader.ReadGMXBool(properties[GMXRoomProperty.Isometric]);
                room.Speed = GMFileReader.ReadGMXInt(properties[GMXRoomProperty.Speed]);
                room.Persistent = GMFileReader.ReadGMXBool(properties[GMXRoomProperty.Persistent]);
                room.BackgroundColor = GMFileReader.ReadGMXInt(properties[GMXRoomProperty.Colour]);
                room.DrawBackgroundColor = GMFileReader.ReadGMXBool(properties[GMXRoomProperty.ShowColour]);
                room.CreationCode = properties[GMXRoomProperty.Code];
                room.EnableViews = GMFileReader.ReadGMXBool(properties[GMXRoomProperty.EnableViews]);
                room.ClearViewBackground = GMFileReader.ReadGMXBool(properties[GMXRoomProperty.ClearViewBackground]);
                room.RememberWindowSize = GMFileReader.ReadGMXBool(properties[GMXRoomProperty.IsSet]);
                room.SnapX = GMFileReader.ReadGMXInt(properties[GMXRoomProperty.W]);
                room.SnapY = GMFileReader.ReadGMXInt(properties[GMXRoomProperty.H]);
                room.ShowGrid = GMFileReader.ReadGMXBool(properties[GMXRoomProperty.ShowGrid]);
                room.ShowObjects = GMFileReader.ReadGMXBool(properties[GMXRoomProperty.ShowObjects]);
                room.ShowTiles = GMFileReader.ReadGMXBool(properties[GMXRoomProperty.ShowTiles]);
                room.ShowBackgrounds = GMFileReader.ReadGMXBool(properties[GMXRoomProperty.ShowBackgrounds]);
                room.ShowForegrounds = GMFileReader.ReadGMXBool(properties[GMXRoomProperty.ShowForegrounds]);
                room.ShowViews = GMFileReader.ReadGMXBool(properties[GMXRoomProperty.ShowViews]);
                room.DeleteUnderlyingObjects = GMFileReader.ReadGMXBool(properties[GMXRoomProperty.DeleteUnderlyingObj]);
                room.DeleteUnderlyingTiles = GMFileReader.ReadGMXBool(properties[GMXRoomProperty.DeleteUnderlyingTiles]);
                room.CurrentTab = (TabSetting)GMFileReader.ReadGMXInt(properties[GMXRoomProperty.Page]);
                room.ScrollBarX = GMFileReader.ReadGMXInt(properties[GMXRoomProperty.XOffset]);
                room.ScrollBarY = GMFileReader.ReadGMXInt(properties[GMXRoomProperty.YOffset]);
                room.PhysicsWorld = GMFileReader.ReadGMXBool(properties[GMXRoomProperty.PhysicsWorld]);
                room.PhysicsWorldTop = GMFileReader.ReadGMXInt(properties[GMXRoomProperty.PhysicsWorldTop]);
                room.PhysicsWorldLeft = GMFileReader.ReadGMXInt(properties[GMXRoomProperty.PhysicsWorldLeft]);
                room.PhysicsWorldRight = GMFileReader.ReadGMXInt(properties[GMXRoomProperty.PhysicsWorldRight]);
                room.PhysicsWorldBottom = GMFileReader.ReadGMXInt(properties[GMXRoomProperty.PhysicsWorldBottom]);
                room.PhysicsWorldGravityX = GMFileReader.ReadGMXInt(properties[GMXRoomProperty.PhysicsWorldGravityX]);
                room.PhysicsWorldGravityY = GMFileReader.ReadGMXInt(properties[GMXRoomProperty.PhysicsWorldGravityY]);
                room.PhysicsWorldPixToMeters = GMFileReader.ReadGMXDouble(properties[GMXRoomProperty.PhysicsWorldPixToMeters]);
                room.Parallaxes = backgrounds.ToArray();
                room.Views = views.ToArray();
                room.Instances = instances.ToArray();
                room.Tiles = tiles.ToArray();

                // Add the room
                rooms.Add(room);
            }

            // Return the list of rooms
            return rooms;
        }

        #endregion
    }

    [Serializable]
    public class GMParallax
    {
        #region Fields

        private string _backgroundName = "";
        private int _backgroundId = -1; 
        private int _x = 0;
        private int _y = 0;
        private int _horizontalSpeed = 0;
        private int _verticalSpeed = 0;
        private bool _visible = false;
        private bool _foreground = false;
        private bool _tileHorizontally = true;
        private bool _tileVertically = true;
        private bool _stretch = false;

        #endregion

        #region Properties

        public string BackgroundName
        {
            get { return _backgroundName; }
            set { _backgroundName = value; }
        }

        public int BackgroundId
        {
            get { return _backgroundId; }
            set { _backgroundId = value; }
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public int HorizontalSpeed
        {
            get { return _horizontalSpeed; }
            set { _horizontalSpeed = value; }
        }

        public int VerticalSpeed
        {
            get { return _verticalSpeed; }
            set { _verticalSpeed = value; }
        }

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public bool Foreground
        {
            get { return _foreground; }
            set { _foreground = value; }
        }

        public bool TileHorizontally
        {
            get { return _tileHorizontally; }
            set { _tileHorizontally = value; }
        }

        public bool TileVertically
        {
            get { return _tileVertically; }
            set { _tileVertically = value; }
        }

        public bool Stretch
        {
            get { return _stretch; }
            set { _stretch = value; }
        }

        #endregion

        #region Methods

        public int GetSize()
        {
            return 30;
        }

        #endregion
    }

    [Serializable]
    public class GMView
    {
        #region Fields

        private string _objectToFollowName = "";
        private int _viewX = 0;
        private int _viewY = 0;
        private int _viewWidth = 640;
        private int _viewHeight = 480;
        private int _portX = 0;
        private int _portY = 0;
        private int _portWidth = 640;
        private int _portHeight = 480;
        private int _horizontalBorder = 32;
        private int _verticalBorder = 32;
        private int _horizontalSpeed = -1;
        private int _verticalSpeed = -1;
        private int _objectToFollow = -1;
        private bool _visible = false;

        #endregion

        #region Properties

        public string ObjectToFollowName
        {
            get { return _objectToFollowName; }
            set { _objectToFollowName = value; }
        }

        public int ViewX
        {
            get { return _viewX; }
            set { _viewX = value; }
        }

        public int ViewY
        {
            get { return _viewY; }
            set { _viewY = value; }
        }

        public int ViewWidth
        {
            get { return _viewWidth; }
            set { _viewWidth = value; }
        }

        public int ViewHeight
        {
            get { return _viewHeight; }
            set { _viewHeight = value; }
        }

        public int PortX
        {
            get { return _portX; }
            set { _portX = value; }
        }

        public int PortY
        {
            get { return _portY; }
            set { _portY = value; }
        }

        public int PortWidth
        {
            get { return _portWidth; }
            set { _portWidth = value; }
        }

        public int PortHeight
        {
            get { return _portHeight; }
            set { _portHeight = value; }
        }

        public int HorizontalBorder
        {
            get { return _horizontalBorder; }
            set { _horizontalBorder = value; }
        }

        public int VerticalBorder
        {
            get { return _verticalBorder; }
            set { _verticalBorder = value; }
        }

        public int HorizontalSpeed
        {
            get { return _horizontalSpeed; }
            set { _horizontalSpeed = value; }
        }

        public int VerticalSpeed
        {
            get { return _verticalSpeed; }
            set { _verticalSpeed = value; }
        }

        public int ObjectToFollow
        {
            get { return _objectToFollow; }
            set { _objectToFollow = value; }
        }

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        #endregion

        #region Methods

        public int GetSize()
        {
            return 58;
        }

        #endregion
    }

    [Serializable]
    public class GMInstance : GMResource
    {
        #region Fields

        private string _objectName = "";
        private string _creationCode = "";
        private double _scaleX = 0;
        private double _scaleY = 0;
        private double _rotation = 0;
        private int _x = 0;
        private int _y = 0;
        private int _objectId = -1;
        private uint _blendColor = 0;
        private bool _locked = false;

        #endregion

        #region Properties

        public string ObjectName
        {
            get { return _objectName; }
            set { _objectName = value; }
        }

        public string CreationCode
        {
            get { return _creationCode; }
            set { _creationCode = value; }
        }

        public double ScaleX
        {
            get { return _scaleX; }
            set { _scaleX = value; }
        }

        public double ScaleY
        {
            get { return _scaleY; }
            set { _scaleY = value; }
        }

        public double Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public int ObjectId
        {
            get { return _objectId; }
            set { _objectId = value; }
        }

        public uint BlendColor
        {
            get { return _blendColor; }
            set { _blendColor = value; }
        }

        public bool Locked
        {
            get { return _locked; }
            set { _locked = value; }
        }

        #endregion

        #region Methods

        public int GetSize()
        {
            return 22 + _creationCode.Length + Name.Length;
        }

        #endregion
    }

    [Serializable]
    public class GMTile : GMResource
    {
        #region Fields

        private string _backgroundName = "";
        private double _scaleX = 1;
        private double _scaleY = 1;
        private uint _blendColor = 0;
        private int _x = 0;
        private int _y = 0;
        private int _width = 16;
        private int _height = 16;
        private int _backgroundId = -1;
        private int _backgroundX = 0;
        private int _backgroundY = 0;
        private int _depth = 0;
        private bool _locked = false;

        #endregion

        #region Properties

        public string BackgroundName
        {
            get { return _backgroundName; }
            set { _backgroundName = value; }
        }

        public double ScaleX
        {
            get { return _scaleX; }
            set { _scaleX = value; }
        }

        public double ScaleY
        {
            get { return _scaleY; }
            set { _scaleY = value; }
        }

        public uint BlendColor
        {
            get { return _blendColor; }
            set { _blendColor = value; }
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public int BackgroundId
        {
            get { return _backgroundId; }
            set { _backgroundId = value; }
        }

        public int BackgroundX
        {
            get { return _backgroundX; }
            set { _backgroundX = value; }
        }

        public int BackgroundY
        {
            get { return _backgroundY; }
            set { _backgroundY = value; }
        }

        public int Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }

        public bool Locked
        {
            get { return _locked; }
            set { _locked = value; }
        }

        #endregion

        #region Methods

        public int GetSize()
        {
            return 38 + Name.Length;
        }

        #endregion
    }
}