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
    public class GMSprite : GMResource
    {
        #region Fields

        private GMImage[] _subImages = null;
        private BoundingBoxType _boundingBoxMode = BoundingBoxType.Auto;
        private ShapeType _shapeMode = ShapeType.Rectange;
        private int _width = 32;
        private int _height = 32;
        private int _originX = 0;
        private int _originY = 0;
        private int _boundingBoxLeft = 0;
        private int _boundingBoxRight = 0;
        private int _boundingBoxTop = 0;
        private int _boundingBoxBottom = 0;
        private int _alphaTolerance = 0;
        private bool _transparent = true;
        private bool _precise = true;
        private bool _smoothEdges = false;
        private bool _preload = true;
        private bool _useVideoMemory = true;
        private bool _loadOnlyOnUse = false;
        private bool _useSeperateCollisionMasks = false;

        #endregion

        #region Properties

        public GMImage[] SubImages
        {
            get { return _subImages; }
            set { _subImages = value; }
        }

        public BoundingBoxType BoundingBoxMode
        {
            get { return _boundingBoxMode; }
            set { _boundingBoxMode = value; }
        }

        public ShapeType ShapeMode
        {
            get { return _shapeMode; }
            set { _shapeMode = value; }
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

        public int OriginX
        {
            get { return _originX; }
            set { _originX = value; }
        }

        public int OriginY
        {
            get { return _originY; }
            set { _originY = value; }
        }

        public int BoundingBoxLeft
        {
            get { return _boundingBoxLeft; }
            set { _boundingBoxLeft = value; }
        }

        public int BoundingBoxRight
        {
            get { return _boundingBoxRight; }
            set { _boundingBoxRight = value; }
        }

        public int BoundingBoxTop
        {
            get { return _boundingBoxTop; }
            set { _boundingBoxTop = value; }
        }

        public int BoundingBoxBottom
        {
            get { return _boundingBoxBottom; }
            set { _boundingBoxBottom = value; }
        }

        public int AlphaTolerance
        {
            get { return _alphaTolerance; }
            set { _alphaTolerance = value; }
        }

        public bool Transparent
        {
            get { return _transparent; }
            set { _transparent = value; }
        }

        public bool Precise
        {
            get { return _precise; }
            set { _precise = value; }
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

        public bool UseSeperateCollisionMasks
        {
            get { return _useSeperateCollisionMasks; }
            set { _useSeperateCollisionMasks = value; }
        }

        #endregion

        #region Methods

        public int GetSize()
        {
            int size = 106 + Name.Length;

            if (_subImages != null)
            {
                foreach (GMImage image in _subImages)
                    size += image.GetSize();
            }

            return size;
        }

        #endregion
    }
}
