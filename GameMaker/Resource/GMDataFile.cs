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

        /// <summary>
        /// Reads all data files from GM file reader stream.
        /// </summary>
        public static GMList<GMDataFile> ReadDataFiles(GMFileReader reader)
        {
            // Create a new list of data files.
            GMList<GMDataFile> dataFiles = new GMList<GMDataFile>();

            // Amount of data file ids.
            int num = reader.ReadGMInt();

            // Iterate through data files.
            for (int i = 0; i < num; i++)
            {
                // If the data file at index does not exists, continue.
                if (reader.ReadGMBool() == false)
                {
                    dataFiles.LastId++;
                    continue;
                }

                // Create a new data file object.
                GMDataFile dataFile = new GMDataFile();

                // Set data file id.
                dataFile.Id = i;

                // Read data file data.
                dataFile.Name = reader.ReadGMString();

                // Get version.
                int version = reader.ReadGMInt();

                // Check version.
                if (version != 440)
                    throw new Exception("Unsupported Data File object version.");

                // Read data file data.
                dataFile.FileName = reader.ReadGMString();

                // If data file exists, read it in.
                if (reader.ReadGMBool())
                    dataFile.Data = reader.ReadGMBytes(reader.ReadGMInt());

                // Read data file data.
                dataFile.ExportMode = (ExportType)(reader.ReadGMInt());
                dataFile.OverwriteFile = reader.ReadGMBool();
                dataFile.FreeDataMemory = reader.ReadGMBool();
                dataFile.RemoveAtGameEnd = reader.ReadGMBool();

                // Add data file.
                dataFiles.Add(dataFile);
            }

            // Return data files.
            return dataFiles;
        }

        #endregion
    }
}
