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
using System.Linq;
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
        private GMParallax[] _parallaxes = new GMParallax[8];
        private GMView[] _views = new GMView[8];
        private string _caption = "";
        private string _creationCode = "";
        private double _physicsWorldGravityX = 0;
        private double _physicsWorldGravityY = 10;
        private double _physicsWorldPixToMeters = 0.100000001490116;
        private int _currentTab = 0;
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
        private int _windowWidth = 640;
        private int _windowHeight = 480;
        private int _physicsWorldTop = 0;
        private int _physicsWorldLeft = 0;
        private int _physicsWorldRight = 640;
        private int _physicsWorldBottom = 480;
        private bool _isSet = true;
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
        private bool _clearViewBackground = true;
        private bool _physicsWorld = false;
        private bool _clearDisplayBuffer = true;

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

        public int CurrentTab
        {
            get { return _currentTab; }
            set { _currentTab = value; }
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

        public double PhysicsWorldGravityX
        {
            get { return _physicsWorldGravityX; }
            set { _physicsWorldGravityX = value; }
        }

        public double PhysicsWorldGravityY
        {
            get { return _physicsWorldGravityY; }
            set { _physicsWorldGravityY = value; }
        }

        public int WindowWidth
        {
            get { return _windowWidth; }
            set { _windowWidth = value; }
        }

        public int WindowHeight
        {
            get { return _windowHeight; }
            set { _windowHeight = value; }
        }

        public bool IsSet
        {
            get { return _isSet; }
            set { _isSet = value; }
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

        public bool ClearDisplayBuffer
        {
            get { return _clearDisplayBuffer; }
            set { _clearDisplayBuffer = value; }
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

        #region Read

        #region Game Maker Studio

        /// <summary>
        /// Reads all GMX rooms from a directory
        /// </summary>
        /// <param name="file">The XML (.GMX) file path</param>
        /// <returns>A list of rooms</returns>
        public static GMList<GMRoom> ReadRoomsGMX(string directory, ref List<string> assets, out int lastTileId)
        {
            // Last tile id counter
            lastTileId = 0;

            // A list of rooms
            GMList<GMRoom> rooms = new GMList<GMRoom>();
            rooms.AutoIncrementIds = false;

            // Iterate through .gmx files in the directory
            foreach (string file in Directory.GetFiles(directory, "*.gmx"))
            {
                // Set name of the room
                string name = GetResourceName(file);

                // If the file is not in the asset list, it has been orphaned, continue
                if (!assets.Contains(name))
                    continue;

                // Create a dictionary of room properties
                Dictionary<string, string> properties = new Dictionary<string, string>();
                foreach (GMXRoomProperty property in Enum.GetValues(typeof(GMXRoomProperty)))
                    properties.Add(GMXEnumString(property), "");

                // Local variables
                List<GMTile> tiles = new List<GMTile>();
                List<GMParallax> backgrounds = new List<GMParallax>();
                List<GMView> views = new List<GMView>();
                List<GMInstance> instances = new List<GMInstance>();

                // Create an xml reader
                using (XmlReader reader = XmlReader.Create(file))
                {
                    // Seek to content
                    reader.MoveToContent();

                    // Read the GMX file
                    while (reader.Read())
                    {
                        // If the node is not an element, continue
                        if (reader.NodeType != XmlNodeType.Element)
                            continue;

                        // Get the element name
                        string nodeName = reader.Name;

                        // If the element is a background element, else if a view, else if an instance, else a normal property
                        if (nodeName.ToLower() == GMXEnumString(GMXBackgroundProperty.Background).ToLower())
                        {
                            // Create a background and add it to the list of backgrounds
                            GMParallax background = new GMParallax();
                            background.Visible = GMXBool(reader.GetAttribute(GMXEnumString(GMXParallaxProperty.Visible)), background.Visible);
                            background.Foreground = GMXBool(reader.GetAttribute(GMXEnumString(GMXParallaxProperty.Visible)), background.Foreground);
                            background.BackgroundName = GMXString(reader.GetAttribute(GMXEnumString(GMXParallaxProperty.Name)), background.BackgroundName);
                            background.BackgroundId = GetIdFromName(background.BackgroundName);
                            background.X = GMXInt(reader.GetAttribute(GMXEnumString(GMXParallaxProperty.X)), background.X);
                            background.Y = GMXInt(reader.GetAttribute(GMXEnumString(GMXParallaxProperty.Y)), background.Y);
                            background.TileHorizontally = GMXBool(reader.GetAttribute(GMXEnumString(GMXParallaxProperty.HTiled)), background.TileHorizontally);
                            background.TileVertically = GMXBool(reader.GetAttribute(GMXEnumString(GMXParallaxProperty.VTiled)), background.TileVertically);
                            background.HorizontalSpeed = GMXInt(reader.GetAttribute(GMXEnumString(GMXParallaxProperty.HSpeed)), background.HorizontalSpeed);
                            background.VerticalSpeed = GMXInt(reader.GetAttribute(GMXEnumString(GMXParallaxProperty.VSpeed)), background.VerticalSpeed);
                            background.Stretch = GMXBool(reader.GetAttribute(GMXEnumString(GMXParallaxProperty.Stretch)), background.Stretch);
                            backgrounds.Add(background);
                        }
                        else if (nodeName.ToLower() == GMXEnumString(GMXViewProperty.View).ToLower())
                        {
                            // Create a view and add it to the list of views
                            GMView view = new GMView();
                            view.Visible = GMXBool(reader.GetAttribute(GMXEnumString(GMXViewProperty.Visible)), view.Visible);
                            view.ObjectToFollowName = GMXString(reader.GetAttribute(GMXEnumString(GMXViewProperty.ObjName)), view.ObjectToFollowName);
                            view.ObjectToFollow = GetIdFromName(view.ObjectToFollowName);
                            view.ViewX = GMXInt(reader.GetAttribute(GMXEnumString(GMXViewProperty.XView)), view.ViewX);
                            view.ViewY = GMXInt(reader.GetAttribute(GMXEnumString(GMXViewProperty.YView)), view.ViewX);
                            view.ViewWidth = GMXInt(reader.GetAttribute(GMXEnumString(GMXViewProperty.WView)), view.ViewWidth);
                            view.ViewHeight = GMXInt(reader.GetAttribute(GMXEnumString(GMXViewProperty.HView)), view.ViewHeight);
                            view.PortX = GMXInt(reader.GetAttribute(GMXEnumString(GMXViewProperty.XPort)), view.PortX);
                            view.PortY = GMXInt(reader.GetAttribute(GMXEnumString(GMXViewProperty.YPort)), view.PortY);
                            view.PortWidth = GMXInt(reader.GetAttribute(GMXEnumString(GMXViewProperty.WPort)), view.PortWidth);
                            view.PortHeight = GMXInt(reader.GetAttribute(GMXEnumString(GMXViewProperty.HPort)), view.PortHeight);
                            view.HorizontalBorder = GMXInt(reader.GetAttribute(GMXEnumString(GMXViewProperty.HBorder)), view.HorizontalBorder);
                            view.VerticalBorder = GMXInt(reader.GetAttribute(GMXEnumString(GMXViewProperty.VBorder)), view.VerticalBorder);
                            view.HorizontalSpeed = GMXInt(reader.GetAttribute(GMXEnumString(GMXViewProperty.HSpeed)), view.HorizontalSpeed);
                            view.VerticalSpeed = GMXInt(reader.GetAttribute(GMXEnumString(GMXViewProperty.VSpeed)), view.VerticalSpeed);
                            views.Add(view);
                        }
                        else if (nodeName.ToLower() == GMXEnumString(GMXInstanceProperty.Instance).ToLower())
                        {
                            // Create an instance and add it to the list of instances
                            GMInstance instance = new GMInstance();
                            instance.ObjectName = GMXString(reader.GetAttribute(GMXEnumString(GMXInstanceProperty.ObjName)), instance.ObjectName);
                            instance.ObjectId = GetIdFromName(instance.ObjectName);
                            instance.X = GMXInt(reader.GetAttribute(GMXEnumString(GMXInstanceProperty.X)), instance.X);
                            instance.Y = GMXInt(reader.GetAttribute(GMXEnumString(GMXInstanceProperty.Y)), instance.Y);
                            instance.Name = GMXString(reader.GetAttribute(GMXEnumString(GMXInstanceProperty.Name)), instance.Name);
                            instance.Locked = GMXBool(reader.GetAttribute(GMXEnumString(GMXInstanceProperty.Locked)), instance.Locked);
                            instance.CreationCode = GMXString(reader.GetAttribute(GMXEnumString(GMXInstanceProperty.Code)), instance.CreationCode);
                            instance.ScaleX = GMXDouble(reader.GetAttribute(GMXEnumString(GMXInstanceProperty.ScaleX)), instance.ScaleX);
                            instance.ScaleY = GMXDouble(reader.GetAttribute(GMXEnumString(GMXInstanceProperty.ScaleY)), instance.ScaleY);
                            instance.UBlendColor = GMXUInt(reader.GetAttribute(GMXEnumString(GMXInstanceProperty.Colour)), instance.UBlendColor);
                            instance.Rotation = GMXDouble(reader.GetAttribute(GMXEnumString(GMXInstanceProperty.Rotation)), instance.Rotation);
                            instances.Add(instance);
                        }
                        else if (nodeName.ToLower() == GMXEnumString(GMXTileProperty.Tile).ToLower())
                        {
                            // Create an tile and add it to the list of tiles
                            GMTile tile = new GMTile();
                            tile.BackgroundName = GMXString(reader.GetAttribute(GMXEnumString(GMXTileProperty.BGName)), tile.BackgroundName);
                            tile.BackgroundId = GetIdFromName(tile.BackgroundName);
                            tile.BackgroundX = GMXInt(reader.GetAttribute(GMXEnumString(GMXTileProperty.X)), tile.BackgroundX);
                            tile.BackgroundY = GMXInt(reader.GetAttribute(GMXEnumString(GMXTileProperty.Y)), tile.BackgroundY);
                            tile.Width = GMXInt(reader.GetAttribute(GMXEnumString(GMXTileProperty.W)), tile.Width);
                            tile.Height = GMXInt(reader.GetAttribute(GMXEnumString(GMXTileProperty.H)), tile.Height);
                            tile.X = GMXInt(reader.GetAttribute(GMXEnumString(GMXTileProperty.XO)), tile.X);
                            tile.Y = GMXInt(reader.GetAttribute(GMXEnumString(GMXTileProperty.YO)), tile.Y);
                            tile.Id = GMXInt(reader.GetAttribute(GMXEnumString(GMXTileProperty.Id)), tile.Id);
                            tile.Name = GMXString(reader.GetAttribute(GMXEnumString(GMXTileProperty.Name), tile.Name), tile.Name);
                            tile.Depth = GMXInt(reader.GetAttribute(GMXEnumString(GMXTileProperty.Depth)), tile.Depth);
                            tile.Locked = GMXBool(reader.GetAttribute(GMXEnumString(GMXTileProperty.Locked)), tile.Locked);
                            tile.UBlendColor = GMXUInt(reader.GetAttribute(GMXEnumString(GMXTileProperty.Colour)), tile.UBlendColor);
                            tile.ScaleX = GMXDouble(reader.GetAttribute(GMXEnumString(GMXTileProperty.ScaleX)), tile.ScaleX);
                            tile.ScaleY = GMXDouble(reader.GetAttribute(GMXEnumString(GMXTileProperty.ScaleY)), tile.ScaleY);
                            tiles.Add(tile);

                            // If the tile id is greater than the current tile id
                            if (tile.Id > lastTileId)
                                lastTileId = tile.Id;
                        }

                        // Read element
                        reader.Read();

                        // If the element value is null or empty, continue
                        if (String.IsNullOrEmpty(reader.Value))
                            continue;

                        // Set the property value
                        properties[nodeName] = reader.Value;
                    }
                }

                // Create a new room, set properties
                GMRoom room = new GMRoom();
                room.Id = GetIdFromName(name);
                room.Name = name;
                room.Caption = GMXString(properties[GMXEnumString(GMXRoomProperty.Caption)], room.Caption);
                room.Width = GMXInt(properties[GMXEnumString(GMXRoomProperty.Width)], room.Width);
                room.Height = GMXInt(properties[GMXEnumString(GMXRoomProperty.Height)], room.Height);
                room.SnapX = GMXInt(properties[GMXEnumString(GMXRoomProperty.HSnap)], room.SnapX);
                room.SnapY = GMXInt(properties[GMXEnumString(GMXRoomProperty.VSnap)], room.SnapY);
                room.IsometricGrid = GMXBool(properties[GMXEnumString(GMXRoomProperty.Isometric)], room.IsometricGrid);
                room.Speed = GMXInt(properties[GMXEnumString(GMXRoomProperty.Speed)], room.Speed);
                room.Persistent = GMXBool(properties[GMXEnumString(GMXRoomProperty.Persistent)], room.Persistent);
                room.BackgroundColor = GMXInt(properties[GMXEnumString(GMXRoomProperty.Colour)], room.BackgroundColor);
                room.DrawBackgroundColor = GMXBool(properties[GMXEnumString(GMXRoomProperty.ShowColour)], room.DrawBackgroundColor);
                room.CreationCode = GMXString(properties[GMXEnumString(GMXRoomProperty.Code)], room.CreationCode);
                room.EnableViews = GMXBool(properties[GMXEnumString(GMXRoomProperty.EnableViews)], room.EnableViews);
                room.ClearViewBackground = GMXBool(properties[GMXEnumString(GMXRoomProperty.ClearViewBackground)], room.ClearViewBackground);
                room.ClearDisplayBuffer = GMXBool(properties[GMXEnumString(GMXRoomProperty.ClearDisplayBuffer)], room.ClearDisplayBuffer);
                room.IsSet = GMXBool(properties[GMXEnumString(GMXRoomProperty.IsSet)], room.IsSet);
                room.WindowWidth = GMXInt(properties[GMXEnumString(GMXRoomProperty.W)], room.WindowWidth);
                room.WindowHeight = GMXInt(properties[GMXEnumString(GMXRoomProperty.H)], room.WindowHeight);
                room.ShowGrid = GMXBool(properties[GMXEnumString(GMXRoomProperty.ShowGrid)], room.ShowGrid);
                room.ShowObjects = GMXBool(properties[GMXEnumString(GMXRoomProperty.ShowObjects)], room.ShowObjects);
                room.ShowTiles = GMXBool(properties[GMXEnumString(GMXRoomProperty.ShowTiles)], room.ShowTiles);
                room.ShowBackgrounds = GMXBool(properties[GMXEnumString(GMXRoomProperty.ShowBackgrounds)], room.ShowBackgrounds);
                room.ShowForegrounds = GMXBool(properties[GMXEnumString(GMXRoomProperty.ShowForegrounds)], room.ShowForegrounds);
                room.ShowViews = GMXBool(properties[GMXEnumString(GMXRoomProperty.ShowViews)], room.ShowViews);
                room.DeleteUnderlyingObjects = GMXBool(properties[GMXEnumString(GMXRoomProperty.DeleteUnderlyingObj)], room.DeleteUnderlyingObjects);
                room.DeleteUnderlyingTiles = GMXBool(properties[GMXEnumString(GMXRoomProperty.DeleteUnderlyingTiles)], room.DeleteUnderlyingTiles);
                room.CurrentTab = GMXInt(properties[GMXEnumString(GMXRoomProperty.Page)], room.CurrentTab);
                room.ScrollBarX = GMXInt(properties[GMXEnumString(GMXRoomProperty.XOffset)], room.ScrollBarX);
                room.ScrollBarY = GMXInt(properties[GMXEnumString(GMXRoomProperty.YOffset)], room.ScrollBarY);
                room.PhysicsWorld = GMXBool(properties[GMXEnumString(GMXRoomProperty.PhysicsWorld)], room.PhysicsWorld);
                room.PhysicsWorldTop = GMXInt(properties[GMXEnumString(GMXRoomProperty.PhysicsWorldTop)], room.PhysicsWorldTop);
                room.PhysicsWorldLeft = GMXInt(properties[GMXEnumString(GMXRoomProperty.PhysicsWorldLeft)], room.PhysicsWorldLeft);
                room.PhysicsWorldRight = GMXInt(properties[GMXEnumString(GMXRoomProperty.PhysicsWorldRight)], room.PhysicsWorldRight);
                room.PhysicsWorldBottom = GMXInt(properties[GMXEnumString(GMXRoomProperty.PhysicsWorldBottom)], room.PhysicsWorldBottom);
                room.PhysicsWorldGravityX = GMXDouble(properties[GMXEnumString(GMXRoomProperty.PhysicsWorldGravityX)], room.PhysicsWorldGravityX);
                room.PhysicsWorldGravityY = GMXDouble(properties[GMXEnumString(GMXRoomProperty.PhysicsWorldGravityY)], room.PhysicsWorldGravityY);
                room.PhysicsWorldPixToMeters = GMXDouble(properties[GMXEnumString(GMXRoomProperty.PhysicsWorldPixToMeters)], room.PhysicsWorldPixToMeters);
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

        #region Game Maker 5 - 8.1

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
                    room.CurrentTab = reader.ReadGMInt();
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
                    room.CurrentTab = reader.ReadGMInt();
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

        #endregion

        #endregion

        #region Write

        #region Game Maker Studio

        /// <summary>
        /// Writes a Game Maker GMX formatted room
        /// </summary>
        /// <param name="room">The given room to write</param>
        /// <param name="directory">The room directory</param>
        public static void WriteRoomGMX(GMRoom room, string directory)
        {
            // Write a single room
            WriteRoomsGMX(new List<GMRoom>() { room }, directory);
        }

        /// <summary>
        /// Writes a list of Game Maker GMX formatted rooms
        /// </summary>
        /// <param name="rooms">The given rooms to write</param>
        /// <param name="directory">The room directory</param>
        public static void WriteRoomsGMX(List<GMRoom> rooms, string directory)
        {
            // If the directory does not exist
            if (!Directory.Exists(directory))
                throw new Exception("The directory for " + directory + " does not exist. Write failed.");

            // If the directory does not have a trailing backslash, add it
            if (directory[directory.Length - 1] != '\\')
                directory += "\\";

            // Iterate through rooms
            foreach (GMRoom room in rooms)
            {
                // Create a file stream to write the file to
                using (FileStream fs = new FileStream(directory + room.Name + ".room.gmx", FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        // Create an XML writer for the project nodes
                        using (XmlTextWriter writer = new XmlTextWriter(sw))
                        {
                            // Same setup as Game Maker
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 2;

                            // GMX standard header comment
                            writer.WriteComment(GMUtilities.GMXHeaderComment);

                            // Start writing properties
                            writer.WriteStartElement(GMXEnumString(GMXRoomProperty.Room));
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.Caption), room.Caption);
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.Width), room.Width.ToString());
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.Height), room.Height.ToString());
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.VSnap), room.SnapY.ToString());
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.HSnap), room.SnapX.ToString());
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.Isometric), GetGMXBool(room.IsometricGrid));
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.Speed), room.Speed.ToString());
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.Persistent), GetGMXBool(room.Persistent));
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.Colour), room.BackgroundColor.ToString());
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.ShowColour), GetGMXBool(room.DrawBackgroundColor));
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.Code), room.CreationCode);
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.EnableViews), GetGMXBool(room.EnableViews));
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.ClearViewBackground), GetGMXBool(room.ClearViewBackground));
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.ClearDisplayBuffer), GetGMXBool(room.ClearDisplayBuffer));

                            // Write static room settings
                            writer.WriteStartElement(GMXEnumString(GMXRoomProperty.MakerSettings));
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.IsSet), GetGMXBool(room.RememberWindowSize));
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.W), room.WindowWidth.ToString());
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.H), room.WindowHeight.ToString());
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.ShowGrid), GetGMXBool(room.ShowGrid));
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.ShowObjects), GetGMXBool(room.ShowObjects));
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.ShowTiles), GetGMXBool(room.ShowTiles));
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.ShowBackgrounds), GetGMXBool(room.ShowBackgrounds));
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.ShowForegrounds), GetGMXBool(room.ShowForegrounds));
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.ShowViews), GetGMXBool(room.ShowViews));
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.DeleteUnderlyingObj), GetGMXBool(room.DeleteUnderlyingObjects));
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.DeleteUnderlyingTiles), GetGMXBool(room.DeleteUnderlyingTiles));
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.Page), ((int)room.CurrentTab).ToString());
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.XOffset), room.ScrollBarX.ToString());
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.YOffset), room.ScrollBarY.ToString());
                            writer.WriteEndElement();

                            // Iterate through parallaxes
                            writer.WriteStartElement(GMXEnumString(GMXParallaxProperty.Backgrounds));
                            foreach (GMParallax parallax in room.Parallaxes)
                            {
                                writer.WriteStartElement(GMXEnumString(GMXParallaxProperty.Background));
                                writer.WriteAttributeString(GMXEnumString(GMXParallaxProperty.Visible), GetGMXBool(parallax.Visible));
                                writer.WriteAttributeString(GMXEnumString(GMXParallaxProperty.Foreground), GetGMXBool(parallax.Foreground));
                                writer.WriteAttributeString(GMXEnumString(GMXParallaxProperty.Name), parallax.BackgroundName);
                                writer.WriteAttributeString(GMXEnumString(GMXParallaxProperty.X), parallax.X.ToString());
                                writer.WriteAttributeString(GMXEnumString(GMXParallaxProperty.Y), parallax.Y.ToString());
                                writer.WriteAttributeString(GMXEnumString(GMXParallaxProperty.HTiled), GetGMXBool(parallax.TileHorizontally));
                                writer.WriteAttributeString(GMXEnumString(GMXParallaxProperty.VTiled), GetGMXBool(parallax.TileVertically));
                                writer.WriteAttributeString(GMXEnumString(GMXParallaxProperty.HSpeed), parallax.HorizontalSpeed.ToString());
                                writer.WriteAttributeString(GMXEnumString(GMXParallaxProperty.VSpeed), parallax.VerticalSpeed.ToString());
                                writer.WriteAttributeString(GMXEnumString(GMXParallaxProperty.Stretch), GetGMXBool(parallax.Stretch));
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();

                            // Iterate through views
                            writer.WriteStartElement(GMXEnumString(GMXViewProperty.Views));
                            foreach (GMView view in room.Views)
                            {
                                writer.WriteStartElement(GMXEnumString(GMXViewProperty.View));
                                writer.WriteAttributeString(GMXEnumString(GMXViewProperty.Visible), GetGMXBool(view.Visible));
                                writer.WriteAttributeString(GMXEnumString(GMXViewProperty.ObjName), view.ObjectToFollowName == "" ? GMXEnumString(GMXViewProperty.Undefined) : view.ObjectToFollowName);
                                writer.WriteAttributeString(GMXEnumString(GMXViewProperty.XView), view.ViewX.ToString());
                                writer.WriteAttributeString(GMXEnumString(GMXViewProperty.YView), view.ViewY.ToString());
                                writer.WriteAttributeString(GMXEnumString(GMXViewProperty.WView), view.ViewWidth.ToString());
                                writer.WriteAttributeString(GMXEnumString(GMXViewProperty.HView), view.ViewHeight.ToString());
                                writer.WriteAttributeString(GMXEnumString(GMXViewProperty.XPort), view.PortX.ToString());
                                writer.WriteAttributeString(GMXEnumString(GMXViewProperty.YPort), view.PortY.ToString());
                                writer.WriteAttributeString(GMXEnumString(GMXViewProperty.WPort), view.PortWidth.ToString());
                                writer.WriteAttributeString(GMXEnumString(GMXViewProperty.HPort), view.PortHeight.ToString());
                                writer.WriteAttributeString(GMXEnumString(GMXViewProperty.HBorder), view.HorizontalBorder.ToString());
                                writer.WriteAttributeString(GMXEnumString(GMXViewProperty.VBorder), view.VerticalBorder.ToString());
                                writer.WriteAttributeString(GMXEnumString(GMXViewProperty.HSpeed), view.HorizontalSpeed.ToString());
                                writer.WriteAttributeString(GMXEnumString(GMXViewProperty.VSpeed), view.VerticalSpeed.ToString());
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();

                            // Iterate through instances
                            writer.WriteStartElement(GMXEnumString(GMXInstanceProperty.Instances));
                            if (room.Instances != null)
                            {
                                foreach (GMInstance instance in room.Instances)
                                {
                                    writer.WriteStartElement(GMXEnumString(GMXInstanceProperty.Instance));
                                    writer.WriteAttributeString(GMXEnumString(GMXInstanceProperty.ObjName), instance.ObjectName);
                                    writer.WriteAttributeString(GMXEnumString(GMXInstanceProperty.X), instance.X.ToString());
                                    writer.WriteAttributeString(GMXEnumString(GMXInstanceProperty.Y), instance.Y.ToString());
                                    writer.WriteAttributeString(GMXEnumString(GMXInstanceProperty.Name), instance.Name.ToString());
                                    writer.WriteAttributeString(GMXEnumString(GMXInstanceProperty.Locked), GetGMXBool(instance.Locked));
                                    writer.WriteAttributeString(GMXEnumString(GMXInstanceProperty.Code), instance.CreationCode);
                                    writer.WriteAttributeString(GMXEnumString(GMXInstanceProperty.ScaleX), instance.ScaleX.ToString());
                                    writer.WriteAttributeString(GMXEnumString(GMXInstanceProperty.ScaleY), instance.ScaleY.ToString());
                                    writer.WriteAttributeString(GMXEnumString(GMXInstanceProperty.Colour), instance.UBlendColor.ToString());
                                    writer.WriteAttributeString(GMXEnumString(GMXInstanceProperty.Rotation), instance.Rotation.ToString());
                                    writer.WriteEndElement();
                                }
                            }
                            writer.WriteEndElement();

                            // Iterate through tiles
                            writer.WriteStartElement(GMXEnumString(GMXTileProperty.Tiles));
                            if (room.Tiles != null)
                            {
                                foreach (GMTile tile in room.Tiles.OrderByDescending(t => t.Depth))
                                {
                                    writer.WriteStartElement(GMXEnumString(GMXTileProperty.Tile));
                                    writer.WriteAttributeString(GMXEnumString(GMXTileProperty.BGName), tile.BackgroundName);
                                    writer.WriteAttributeString(GMXEnumString(GMXTileProperty.X), tile.X.ToString());
                                    writer.WriteAttributeString(GMXEnumString(GMXTileProperty.Y), tile.Y.ToString());
                                    writer.WriteAttributeString(GMXEnumString(GMXTileProperty.W), tile.Width.ToString());
                                    writer.WriteAttributeString(GMXEnumString(GMXTileProperty.H), tile.Height.ToString());
                                    writer.WriteAttributeString(GMXEnumString(GMXTileProperty.XO), tile.BackgroundX.ToString());
                                    writer.WriteAttributeString(GMXEnumString(GMXTileProperty.YO), tile.BackgroundY.ToString());
                                    writer.WriteAttributeString(GMXEnumString(GMXTileProperty.Id), tile.Id.ToString());
                                    writer.WriteAttributeString(GMXEnumString(GMXTileProperty.Name), tile.Name);
                                    writer.WriteAttributeString(GMXEnumString(GMXTileProperty.Depth), tile.Depth.ToString());
                                    writer.WriteAttributeString(GMXEnumString(GMXTileProperty.Locked), GetGMXBool(tile.Locked));
                                    writer.WriteAttributeString(GMXEnumString(GMXTileProperty.Colour), tile.UBlendColor.ToString());
                                    writer.WriteAttributeString(GMXEnumString(GMXTileProperty.ScaleX), tile.ScaleX.ToString());
                                    writer.WriteAttributeString(GMXEnumString(GMXTileProperty.ScaleY), tile.ScaleY.ToString());
                                    writer.WriteEndElement();
                                }
                            }
                            writer.WriteEndElement();

                            // Continue writing room properties
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.PhysicsWorld), GetGMXBool(room.PhysicsWorld));
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.PhysicsWorldTop), room.PhysicsWorldTop.ToString());
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.PhysicsWorldLeft), room.PhysicsWorldLeft.ToString());
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.PhysicsWorldRight), room.PhysicsWorldRight.ToString());
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.PhysicsWorldBottom), room.PhysicsWorldBottom.ToString());
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.PhysicsWorldGravityX), room.PhysicsWorldGravityX.ToString());
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.PhysicsWorldGravityY), room.PhysicsWorldGravityY.ToString());
                            XMLWriteFullElement(writer, GMXEnumString(GMXRoomProperty.PhysicsWorldPixToMeters), room.PhysicsWorldPixToMeters.ToString());
                            writer.WriteEndElement();
                        }
                    }
                }
            }
        }

        #endregion

        #endregion

        #endregion
    }

    [Serializable]
    public class GMParallax
    {
        #region Fields

        private string _name = "";
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

        public string Name
        {
            get { return _name; }
        }

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

        #region Constructors

        public GMParallax()
        {
        }

        public GMParallax(string name)
        {
            _name = name;
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return _name;
        }

        #endregion
    }

    [Serializable]
    public class GMView
    {
        #region Fields

        private string _name = "";
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

        public string Name
        {
            get { return _name; }
        }

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

        #region Constructors

        public GMView()
        {
        }

        public GMView(string name)
        {
            _name = name;
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return _name;
        }

        #endregion
    }

    [Serializable]
    public class GMInstance : GMResource
    {
        #region Fields

        private string _objectName = "";
        private string _creationCode = "";
        private double _scaleX = 1;
        private double _scaleY = 1;
        private double _rotation = 0;
        private uint _uBlendColor = 4294967295;
        private int _x = 0;
        private int _y = 0;
        private int _objectId = -1;
        private int _blendColor = 0;
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

        public int BlendColor
        {
            get { return _blendColor; }
            set { _blendColor = value; _uBlendColor = GMUtilities.GMColorToGMSColor(value); }
        }

        public uint UBlendColor
        {
            get { return _uBlendColor; }
            set { _uBlendColor = value; _blendColor = GMUtilities.GMSColorToGMColor(value); }
        }

        public bool Locked
        {
            get { return _locked; }
            set { _locked = value; }
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
        private int _blendColor = 0;
        private uint _uBlendColor = 4294967295;
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

        public int BlendColor
        {
            get { return _blendColor; }
            set { _blendColor = value; _uBlendColor = GMUtilities.GMColorToGMSColor(value); }
        }

        public uint UBlendColor
        {
            get { return _uBlendColor; }
            set { _uBlendColor = value; _blendColor = GMUtilities.GMSColorToGMColor(value); }
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
    }
}