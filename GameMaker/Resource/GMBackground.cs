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

namespace GameMaker.Resource
{
    [Serializable]
    public class GMBackground : GMResource
    {
        #region Fields

        private GMImage _image = null;
        private int _width = 0;
        private int _height = 0;
        private int _tileWidth = 16;
        private int _tileHeight = 16;
        private int _horizontalOffset = 0;
        private int _verticalOffset = 0;
        private int _horizontalSeperation = 0;
        private int _verticalSeperation = 0;
        private bool _transparent = false;
        private bool _smoothEdges = false;
        private bool _preload = false;
        private bool _useAsTileSet = false;
        private bool _useVideoMemory = true;
        private bool _loadOnlyOnUse = true;

        #endregion

        #region Properties

        public GMImage Image
        {
            get { return _image; }
            set { _image = value; }
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

        public int HorizontalOffset
        {
            get { return _horizontalOffset; }
            set { _horizontalOffset = value; }
        }

        public int VerticalOffset
        {
            get { return _verticalOffset; }
            set { _verticalOffset = value; }
        }

        public int HorizontalSeperation
        {
            get { return _horizontalSeperation; }
            set { _horizontalSeperation = value; }
        }

        public int VerticalSeperation
        {
            get { return _verticalSeperation; }
            set { _verticalSeperation = value; }
        }

        public bool Transparent
        {
            get { return _transparent; }
            set { _transparent = value; }
        }

        public bool SmoothEdges
        {
            get { return _smoothEdges; }
            set { _smoothEdges = value; }
        }

        public bool Preload
        {
            get { return _preload; }
            set { _preload = value; }
        }

        public bool UseAsTileSet
        {
            get { return _useAsTileSet; }
            set { _useAsTileSet = value; }
        }

        public bool UseVideoMemory
        {
            get { return _useVideoMemory; }
            set { _useVideoMemory = value; }
        }

        public bool LoadOnlyOnUse
        {
            get { return _loadOnlyOnUse; }
            set { _loadOnlyOnUse = value; }
        }

        #endregion

        #region Methods

        public int GetSize()
        {
            int size = 56 + Name.Length;

            if (_image != null)
                size += _image.GetSize();

            return size;
        }

        #endregion
    }
}
