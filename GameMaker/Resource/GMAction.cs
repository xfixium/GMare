#region MIT

// 
// GMLib.
// Copyright (C) 2011, 2012, 2013, 2014 Michael Mercado
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

        private GMArgument[] _arguments = null;
        private string _executeCode = "";
        private string _functionName = "";
        private string _appliesToName = "self";
        private int _actionKind = 0;
        private int _executeMode = 1;
        private int _libraryId = 1;
        private int _actionId = 101;
        private int _appliesTo = -1;
        private bool _relative = false;
        private bool _not = false;
        private bool _allowRelative = false;
        private bool _question = false;
        private bool _canApplyTo = false;

        #endregion

        #region Properties

        public GMArgument[] Arguments
        {
            get { return _arguments; }
            set { _arguments = value; }
        }

        public string ExecuteCode
        {
            get { return _executeCode; }
            set { _executeCode = value; }
        }

        public string FunctionName
        {
            get { return _functionName; }
            set { _functionName = value; }
        }

        public string AppliesToName
        {
            get { return _appliesToName; }
            set { _appliesToName = value; }
        }

        public int ActionKind
        {
            get { return _actionKind; }
            set { _actionKind = value; }
        }

        public int ExecuteMode
        {
            get { return _executeMode; }
            set { _executeMode = value; }
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

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            int size = 30 + _executeCode.Length;

            foreach (GMArgument argument in _arguments)
            {
                size += argument.Value.Length + 8;
            }

            return size;
        }

        /// <summary>
        /// Reads all actions from a GM file reader stream.
        /// </summary>
        public static GMAction[] ReadActions(GMFileReader reader)
        {
            // Get version.
            int version = reader.ReadGMInt();

            // Check version.
            if (version != 400)
                throw new Exception("Unsupported Pre-Action object version.");

            // Create an array of actions.
            GMAction[] actions = new GMAction[reader.ReadGMInt()];

            // Iterate through actions.
            for (int i = 0; i < actions.Length; i++)
            {
                // Create new action
                actions[i] = new GMAction();

                // Get version.
                version = reader.ReadGMInt();

                // Check version.
                if (version != 440)
                    throw new Exception("Unsupported Action object version.");

                // Get action properties.
                actions[i].LibraryId = reader.ReadGMInt();
                actions[i].ActionId = reader.ReadGMInt();
                actions[i].ActionKind = reader.ReadGMInt();
                actions[i].AllowRelative = reader.ReadGMBool();
                actions[i].Question = reader.ReadGMBool();
                actions[i].CanApplyTo = reader.ReadGMBool();
                actions[i].ExecuteMode = reader.ReadGMInt();

                // If the execute mode is a prefabbed function.
                if (actions[i].ExecuteMode == (int)ExecutionType.Function)
                    actions[i].ExecuteCode = reader.ReadGMString();
                else
                    reader.ReadGMBytes(reader.ReadGMInt());

                // If the execute mode is a script.
                if (actions[i].ExecuteMode == (int)ExecutionType.Code)
                    actions[i].ExecuteCode = reader.ReadGMString();
                else
                    reader.ReadGMBytes(reader.ReadGMInt());

                // Create an array of arguments.
                actions[i].Arguments = new GMArgument[reader.ReadGMInt()];

                // Number of argument types.
                int[] argTypes = new int[reader.ReadGMInt()];

                // Iterate through argument types
                for (int j = 0; j < argTypes.Length; j++)
                {
                    // Read in argument type.
                    argTypes[j] = reader.ReadGMInt();
                }

                // Read action data.
                actions[i].AppliesTo = reader.ReadGMInt();
                actions[i].Relative = reader.ReadGMBool();

                // Get actual number of arguments, most likely 8.
                int argsNum = reader.ReadGMInt();

                // Iterate through argument types.
                for (int k = 0; k < argsNum; k++)
                {
                    // If the index is greater than or equal to the number of arguments, continue.
                    if (k >= actions[i].Arguments.Length)
                    {
                        reader.ReadGMBytes(reader.ReadGMInt());
                        continue;
                    }

                    // Create a new argument object.
                    actions[i].Arguments[k] = new GMArgument();

                    // Set what kind of argument.
                    actions[i].Arguments[k].Type = argTypes[k];

                    // Resource value.
                    actions[i].Arguments[k].Value = reader.ReadGMString();
                }

                // If not checkbox has been checked.
                actions[i].Not = reader.ReadGMBool();
            }

            // Return action object.
            return actions;
        }

        #endregion
    }

    [Serializable]
    public class GMArgument
    {
        #region Fields

        private string _value = "";
        private int _resource = -1;
        private int _type = 0;

        #endregion

        #region Properties

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public int Resource
        {
            get { return _resource; }
            set { _resource = value; }
        }

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        #endregion
    }
}
