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

namespace GMare.Graphics
{
    public class Line
    {
        #region Fields

        private Point _start = Point.Empty;
        private Point _end = Point.Empty;
        private Color _color = Color.White;

        #endregion

        #region Properties

        public Point Start
        {
            get { return _start; }
        }

        public Point End
        {
            get { return _end; }
        }

        public Color Color
        {
            get { return _color; }
        }

        #endregion

        #region Constructor | Destructor

        public Line(Point start, Point end, Color color)
        {
            _start = start;
            _end = end;
            _color = color;
        }

        #endregion
    }

    public class Quad
    {
        #region Fields

        private uint _textureId = 0;
        private Point _texStart = new Point(0, 0);
        private Point _texEnd = new Point(1, 1);
        private PointF _quadStart = Point.Empty;
        private PointF _quadEnd = Point.Empty;
        private Color _color = Color.White;

        #endregion

        #region Properties

        public uint TextureId
        {
            get { return _textureId; }
        }

        public Point TexStart
        {
            get { return _texStart; }
        }

        public Point TexEnd
        {
            get { return _texEnd; }
        }

        public PointF QuadStart
        {
            get { return _quadStart; }
        }

        public PointF QuadEnd
        {
            get { return _quadEnd; }
        }

        public Color Color
        {
            get { return _color; }
        }

        #endregion

        #region Constructor | Destructor

        /// <summary>
        /// Constructs a new texture quad.
        /// </summary>
        public Quad(uint textureId, PointF quadStart, PointF quadEnd, Color color)
        {
            _textureId = textureId;
            _quadStart = quadStart;
            _quadEnd = quadEnd;
            _color = color;
        }

        /// <summary>
        /// Constructs a new texture quad, with specific texture coordinates.
        /// </summary>
        public Quad(uint textureId, PointF quadStart, PointF quadEnd, Point texStart, Point texEnd, Color color)
        {
            _textureId = textureId;
            _quadStart = quadStart;
            _quadEnd = quadEnd;
            _texStart = texStart;
            _texEnd = texEnd;
            _color = color;
        }

        #endregion
    }
}
