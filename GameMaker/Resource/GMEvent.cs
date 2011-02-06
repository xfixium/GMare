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
    public class GMEvent
    {
        #region Fields

        private EventType _mainType = EventType.None;
        private GMAction[] _actions = null;
        private int _subType = 0;
        private int _otherId = -1;

        #endregion

        #region Properties

        public EventType MainType
        {
            get { return _mainType; }
            set { _mainType = value; }
        }

        public GMAction[] Actions
        {
            get { return _actions; }
            set { _actions = value; }
        }

        public int SubType
        {
            get { return _subType; }
            set { _subType = value; }
        }

        public int OtherId
        {
            get { return _otherId; }
            set { _otherId = value; }
        }

        #endregion

        #region Methods

        public int GetSize()
        {
            int size = 12;

            if (_actions != null)
            {
                foreach (GMAction action in _actions)
                    size += action.GetSize();
            }

            return size;
        }

        #endregion
    }
}
