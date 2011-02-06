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
    public class GMSound : GMResource
    {
        #region Fields

        private SoundType _type = SoundType.Normal;
        private SoundKind _kind = SoundKind.None;
        private double _volume = 1.0d;
        private double _pan = 0.0d;
        private string _fileType = "";
        private string _fileName = "";
        private int _effects = 0;
        private int _buffers = 1;
        private bool _allowSoundEffects = false;
        private bool _loadOnlyOnUse = false;
        private bool _preload = true;
        private byte[] _data = null;

        #endregion

        #region Properties

        public SoundType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public SoundKind Kind
        {
            get { return _kind; }
            set { _kind = value; }
        }

        public double Volume
        {
            get { return _volume; }
            set { _volume = value; }
        }

        public double Pan
        {
            get { return _pan; }
            set { _pan = value; }
        }

        public string FileType
        {
            get { return _fileType; }
            set { _fileType = value; }
        }

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public int Effects
        {
            get { return _effects; }
            set { _effects = value; }
        }

        public int Buffers
        {
            get { return _buffers; }
            set { _buffers = value; }
        }

        public bool AllowSoundEffects
        {
            get { return _allowSoundEffects; }
            set { _allowSoundEffects = value; }
        }

        public bool LoadOnlyOnUse
        {
            get { return _loadOnlyOnUse; }
            set { _loadOnlyOnUse = value; }
        }

        public bool Preload
        {
            get { return _preload; }
            set { _preload = value; }
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
            int size = 50 + _fileType.Length + _fileName.Length + Name.Length;

            if (_data != null)
                size += _data.Length;

            return size;
        }

        #endregion
    }
}