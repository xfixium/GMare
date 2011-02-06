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
    public class GMAction
    {
        #region Fields

        private bool _relative = false;
        private bool _not = false;
        private bool _allowRelative = false;
        private bool _question = false;
        private bool _canApplyTo = false;
        private int _libraryId = 1;
        private int _actionId = 101;
        private int _appliesTo = -1;
        private string _executeCode = "";
        private ActionType _actionKind = ActionType.Normal;
        private ExecutionType _executeMode = ExecutionType.Function;
        private GMArgument[] _arguments = null;

        #endregion

        #region Properties

        public bool Relative
        {
            get { return _relative; }
            set { _relative = value; }
        }

        public bool Not
        {
            get { return _not; }
            set { _not = value; }
        }

        public bool AllowRelative
        {
            get { return _allowRelative; }
            set { _allowRelative = value; }
        }

        public bool Question
        {
            get { return _question; }
            set { _question = value; }
        }

        public bool CanApplyTo
        {
            get { return _canApplyTo; }
            set { _canApplyTo = value; }
        }

        public int LibraryId
        {
            get { return _libraryId; }
            set { _libraryId = value; }
        }

        public int ActionId
        {
            get { return _actionId; }
            set { _actionId = value; }
        }

        public int AppliesTo
        {
            get { return _appliesTo; }
            set { _appliesTo = value; }
        }

        public string ExecuteCode
        {
            get { return _executeCode; }
            set { _executeCode = value; }
        }

        public ActionType ActionKind
        {
            get { return _actionKind; }
            set { _actionKind = value; }
        }

        public ExecutionType ExecuteMode
        {
            get { return _executeMode; }
            set { _executeMode = value; }
        }

        public GMArgument[] Arguments
        {
            get { return _arguments; }
            set { _arguments = value; }
        }

        #endregion

        #region Methods

        public int GetSize()
        {
            int size = 30 + _executeCode.Length;

            foreach (GMArgument argument in _arguments)
            {
                size += argument.Value.Length + 8;
            }

            return size;
        }

        #endregion
    }

    [Serializable]
    public class GMArgument
    {
        #region Fields

        private int _resource = -1;
        private string _value = "";
        private ArgumentType _type = ArgumentType.Expression;

        #endregion

        #region Properties

        public int Resource
        {
            get { return _resource; }
            set { _resource = value; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public ArgumentType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        #endregion
    }
}
