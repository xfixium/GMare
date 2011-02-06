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

        #endregion

        #region Constructor | Destructor

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

        public int GetSize()
        {
            int size = 106 + _creationCode.Length + _caption.Length + Name.Length;

            if (_instances != null)
            {
                foreach (GMInstance instance in _instances)
                    size += instance.GetSize();
            }

            if (_tiles != null)
            {
                foreach (GMTile tile in _tiles)
                    size += tile.GetSize();
            }

            if (_parallaxes != null)
            {
                foreach (GMParallax parallax in _parallaxes)
                    size += parallax.GetSize();
            }

            if (_views != null)
            {
                foreach (GMView view in _views)
                    size += view.GetSize();
            }

            return size;
        }

        #endregion
    }

    [Serializable]
    public class GMParallax
    {
        #region Fields

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

        private string _creationCode = "";
        private int _depth = 0;
        private int _x = 0;
        private int _y = 0;
        private int _objectId = -1;
        private bool _locked = false;

        #endregion

        #region Properties

        public string CreationCode
        {
            get { return _creationCode; }
            set { _creationCode = value; }
        }

        public int Depth
        {
            get { return _depth; }
            set { _depth = value; }
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