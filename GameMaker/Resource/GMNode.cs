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
    public class GMNode : GMResource
    {
        #region Fields

        private GMNodeType _nodeType = GMNodeType.Parent;
        private GMResourceType _resourceType = GMResourceType.Backgrounds;
        private GMNode[] _nodes = null;
        private int _children = 0;

        #endregion

        #region Properties

        public GMNodeType NodeType
        {
            get { return _nodeType; }
            set { _nodeType = value; }
        }

        public GMResourceType ResourceType
        {
            get { return _resourceType; }
            set { _resourceType = value; }
        }

        public GMNode[] Nodes
        {
            get { return _nodes; }
            set { _nodes = value; }
        }

        public int Children
        {
            get { return _children; }
            set { _children = value; }
        }

        #endregion

        #region Methods

        public int GetSize()
        {
            int size = 12;

            if (_nodes != null)
            {
                foreach (GMNode node in _nodes)
                    size += node.GetSize();
            }

            return size;
        }

        #endregion
    }
}