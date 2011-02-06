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
    public class GMDataFile : GMResource
    {
        #region Fields

        private ExportType _exportMode = ExportType.WorkingFolder;
        private string _fileName = "";
        private bool _freeDataMemory = true;
        private bool _overwriteFile = false;
        private bool _removeAtGameEnd = true;
        private byte[] _data = null;

        #endregion

        #region Properties

        public ExportType ExportMode
        {
            get { return _exportMode; }
            set { _exportMode = value; }
        }

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public bool FreeDataMemory
        {
            get { return _freeDataMemory; }
            set { _freeDataMemory = value; }
        }

        public bool OverwriteFile
        {
            get { return _overwriteFile; }
            set { _overwriteFile = value; }
        }

        public bool RemoveAtGameEnd
        {
            get { return _removeAtGameEnd; }
            set { _removeAtGameEnd = value; }
        }

        public byte[] Data
        {
            get { return _data; }
            set { _data = value; }
        }

        #endregion

        #region Methods

        public int GetSize()
        {
            int size = 10 + _fileName.Length + Name.Length;

            if (_data != null)
                size += _data.Length;

            return size;
        }

        #endregion
    }
}
