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
    public class GMTimeline : GMResource
    {
        #region Fields

        private GMMoment[] _moments = null;

        #endregion

        #region Properties

        public GMMoment[] Moments
        {
            get { return _moments; }
            set { _moments = value; }
        }

        #endregion

        #region Methods

        public int GetSize()
        {
            int size = 12 + Name.Length;

            if (_moments != null)
            {
                foreach (GMMoment moment in _moments)
                    size += moment.GetSize();
            }

            return size;
        }

        #endregion
    }

    [Serializable]
    public class GMMoment
    {
        #region Fields

        private GMAction[] _actions = null;
        private int _stepIndex = 0;

        #endregion

        #region Properties

        public GMAction[] Actions
        {
            get { return _actions; }
            set { _actions = value; }
        }

        public int StepIndex
        {
            get { return _stepIndex; }
            set { _stepIndex = value; }
        }

        #endregion

        #region Methods

        public int GetSize()
        {
            int size = 4;

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