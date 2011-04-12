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
    public class GMTrigger : GMResource
    {
        #region Fields

        private static double _lastChanged = 0;
        private MomentType _moment = MomentType.Middle;
        private string _condition = "";
        private string _constant = "";

        #endregion

        #region Properties

        public static double TriggerLastChanged
        {
            get { return _lastChanged; }
            set { _lastChanged = value; }
        }

        public MomentType Moment
        {
            get { return _moment; }
            set { _moment = value; }
        }

        public string Condition
        {
            get { return _condition; }
            set { _condition = value; }
        }

        public string Constant
        {
            get { return _constant; }
            set { _constant = value; }
        }

        #endregion

        #region Methods

        public int GetSize()
        {
            return 16 + _condition.Length + _constant.Length + Name.Length;
        }

        #endregion
    }
}
