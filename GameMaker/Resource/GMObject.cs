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
using System.Collections.Generic;
using GameMaker.Common;

namespace GameMaker.Resource
{
    [Serializable]
    public class GMObject : GMResource
    {
        #region Fields

        private List<GMEvent>[] _events = new List<GMEvent>[12];
        private int _spriteId = -1;
        private int _mask = -1;
        private int _parent = -1;
        private int _depth = 0;
        private bool _solid = false;
        private bool _visible = true;
        private bool _persistent = false;

        #endregion

        #region Properties

        public List<GMEvent>[] Events
        {
            get { return _events; }
            set { _events = value; }
        }

        public int SpriteId
        {
            get { return _spriteId; }
            set { _spriteId = value; }
        }

        public int Mask
        {
            get { return _mask; }
            set { _mask = value; }
        }

        public int Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public int Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }

        public bool Solid
        {
            get { return _solid; }
            set { _solid = value; }
        }

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public bool Persistent
        {
            get { return _persistent; }
            set { _persistent = value; }
        }

        #endregion

        #region Constructor

        public GMObject()
        {
            for (int i = 0; i < _events.Length; i++)
                _events[i] = new List<GMEvent>();
        }

        #endregion

        #region Methods

        public int GetSize()
        {
            int size = 34 + Name.Length;

            if (_events != null)
            {
                foreach (List<GMEvent> list in _events)
                    foreach (GMEvent ev in list)
                        size += ev.GetSize();
            }

            return size;
        }

        #endregion
    }
}