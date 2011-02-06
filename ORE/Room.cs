#region MIT

// 
// GMare.
// Copyright (C) 2008 - 2010 Pyxosoft
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace OcarinaRoomEditor
{
    [Serializable]
    public class Room
    {
        #region Fields

        private List<Shape> _shapes = new List<Shape>();  // A list of shapes.
        private Bitmap[] _tiles;                          // An array of bitmap tiles.
        private Bitmap _tileset;                          // Original tileset bitmap.
        private Color _roomColor = Color.Gray;            // Room back color.
        private int[] _tilesLower;                        // Lower layer tile ids.
        private int[] _tilesUpper;                        // Upper layer tile ids.
        private int _tilesetWidth;                        // Tileset width in pixels.
        private int _tilesetHeight;                       // Tileset height in pixels.
        private int _width = 320;                         // Room width in pixels.
        private int _height = 240;                        // Room height in pixels.

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the lists of shapes.
        /// </summary>
        public List<Shape> Shapes
        {
            get { return _shapes; }
            set { _shapes = value; }
        }

        /// <summary>
        /// Gets or sets the array of tile images.
        /// </summary>
        public Bitmap[] Tiles
        {
            get { return _tiles; }
            set { _tiles = value; }
        }

        /// <summary>
        /// Gets or sets the tileset image.
        /// </summary>
        public Bitmap Tileset
        {
            get { return _tileset; }
            set { _tileset = value; }
        }

        /// <summary>
        /// Gets or sets the backcolor of the room.
        /// </summary>
        public Color RoomColor
        {
            get { return _roomColor; }
            set { _roomColor = value; }
        }

        /// <summary>
        /// Gets or sets the lower layer tiles.
        /// </summary>
        public int[] TilesLower
        {
            get { return _tilesLower; }
            set { _tilesLower = value; }
        }

        /// <summary>
        /// Gets or sets the upper layer tiles.
        /// </summary>
        public int[] TilesUpper
        {
            get { return _tilesUpper; }
            set { _tilesUpper = value; }
        }

        /// <summary>
        /// Gets or sets the tileset width.
        /// </summary>
        public int TilesetWidth
        {
            get { return _tilesetWidth; }
            set { _tilesetWidth = value; }
        }

        /// <summary>
        /// Gets or sets the tileset height.
        /// </summary>
        public int TilesetHeight
        {
            get { return _tilesetHeight; }
            set { _tilesetHeight = value; }
        }

        /// <summary>
        /// Gets or sets the width of the room.
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// The height of the room.
        /// </summary>
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        #endregion
    }
}

