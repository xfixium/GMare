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

namespace OcarinaRoomEditor
{
    [Serializable]
    public class Shape
    {
        #region Fields

        private Point[] _points;       // Shape points array.
        private ShapeType _shapeMode;  // The shape type.

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the array of shape points.
        /// </summary>
        public Point[] Points
        {
            get { return this._points; }
            set { _points = value; }
        }

        /// <summary>
        /// Gets or sets the shape type.
        /// </summary>
        public ShapeType ShapeMode
        {
            get { return this._shapeMode; }
            set { _shapeMode = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new shape.
        /// </summary>
        /// <param name="type">The kind of shape.</param>
        public Shape(ShapeType type)
        {
            // Set points based on shape type.
            switch (type)
            {
                case ShapeType.Rectangle:
                    _points = new Point[] { new Point(0, 0), new Point(16, 0), new Point(16, 16), new Point(0, 16) };
                    break;

                case ShapeType.Triangle:
                    _points = new Point[] { new Point(0, 0), new Point(0, 16), new Point(16, 16) };
                    break;
            }

            _shapeMode = type;
        }

        #endregion
    }
}

