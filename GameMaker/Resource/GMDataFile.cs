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
using System.IO;
using System.Xml;
using System.Collections.Generic;
using GameMaker.Common;

namespace GameMaker.Resource
{
    [Serializable]
    public class GMDataFile : GMResource
    {
        #region Fields

        private ExportType _exportMode = ExportType.WorkingFolder;
        private GMConfig[] _configs = null;
        private byte[] _data = null;
        private string _fileName = "";
        private string _exportDirectory = "";
        private int _size = 0;
        private int _exportAction = 2;
        private bool _freeDataMemory = true;
        private bool _overwriteFile = false;
        private bool _removeAtGameEnd = true;
        private bool _exists = true;
        private bool _store = false;

        #endregion

        #region Properties

        public ExportType ExportMode
        {
            get { return _exportMode; }
            set { _exportMode = value; }
        }

        public GMConfig[] Configs
        {
            get { return _configs; }
            set { _configs = value; }
        }

        public byte[] Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public string ExportDirectory
        {
            get { return _exportDirectory; }
            set { _exportDirectory = value; }
        }

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public int ExportAction
        {
            get { return _exportAction; }
            set { _exportAction = value; }
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

        public bool Exists
        {
            get { return _exists; }
            set { _exists = value; }
        }

        public bool Store
        {
            get { return _store; }
            set { _store = value; }
        }

        #endregion

        #region Methods

        #region Read

        #region Game Maker Studio

        /// <summary>
        /// Gets data files from project file
        /// </summary>
        /// <param name="path">File path to project file</param>
        public static GMList<GMDataFile> ReadDataFilesGMX(string path)
        {
            // Create a new list of data files
            GMList<GMDataFile> dataFiles = new GMList<GMDataFile>();
            dataFiles.AutoIncrementIds = false;

            // Create a dictionary of data file properties
            Dictionary<string, string> properties = new Dictionary<string, string>();
            foreach (GMXDataFileProperty property in Enum.GetValues(typeof(GMXDataFileProperty)))
                properties.Add(GMXEnumString(property), "");

            // List of configs
            List<GMConfig> configs = new List<GMConfig>();

            // Create an xml reader
            using (XmlReader reader = XmlReader.Create(path))
            {
                reader.MoveToContent();

                // Read the GMX file
                while (reader.Read())
                {
                    // If the node is not an element, continue
                    if (reader.NodeType != XmlNodeType.Element)
                        continue;

                    // Get the element name
                    string nodeName = reader.Name;

                    // If the node is a data file, read it in
                    if (nodeName.ToLower() == GMXEnumString(GMResourceSubType.DataFile))
                    {
                        // Seek to content
                        reader.MoveToContent();

                        // Create an xml reader
                        using (XmlReader reader2 = reader.ReadSubtree())
                        {
                            // Read in data file properties
                            while (reader2.Read())
                            {
                                // If the node is not an element, continue
                                if (reader2.NodeType != XmlNodeType.Element)
                                    continue;

                                // Get the element name
                                string nodeName2 = reader2.Name;

                                // If the node is a data file, read it in
                                if (nodeName2.ToLower() == GMXEnumString(GMResourceType.ConfigOptions).ToLower())
                                {
                                    reader2.MoveToContent();

                                    // Create an xml reader
                                    using (XmlReader reader3 = reader2.ReadSubtree())
                                    {
                                        // Read in data file properties
                                        while (reader3.Read())
                                        {
                                            // If the node is not an element, continue
                                            if (reader3.NodeType != XmlNodeType.Element)
                                                continue;

                                            // Get the element name
                                            string nodeName3 = reader3.Name;


                                            // If the node is a data file, read it in
                                            if (nodeName3.ToLower() == GMXEnumString(GMResourceSubType.Config).ToLower())
                                            {
                                                GMConfig config = new GMConfig();
                                                config.Name = GMXString(reader3.GetAttribute(GMXEnumString(GMXConfigProperty.Name)), config.Name);
                                                config.Id = GetIdFromName(config.Name);

                                                reader3.MoveToContent();

                                                // Create an xml reader
                                                using (XmlReader reader4 = reader3.ReadSubtree())
                                                {
                                                    // Read in data file properties
                                                    while (reader4.Read())
                                                    {
                                                        // If the node is not an element, continue
                                                        if (reader4.NodeType != XmlNodeType.Element)
                                                            continue;

                                                        // Get the element name
                                                        string nodeName4 = reader4.Name;

                                                        // If the node is a data file, read it in
                                                        if (nodeName4.ToLower() == GMXEnumString(GMXConfigProperty.CopyToMask).ToLower())
                                                        {
                                                            // Read element
                                                            reader4.Read();

                                                            // If the element value is null or empty, continue
                                                            if (String.IsNullOrEmpty(reader4.Value))
                                                                continue;

                                                            // Finally read the config file data
                                                            config.CopyToMask = GMXString(reader4.Value, config.CopyToMask);
                                                            configs.Add(config);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                // Read element
                                reader2.Read();

                                // If the element value is null or empty, continue
                                if (String.IsNullOrEmpty(reader2.Value))
                                    continue;

                                // Set the property value
                                properties[nodeName2] = reader2.Value;
                            }

                            // Create a new data file
                            GMDataFile dataFile = new GMDataFile();
                            dataFile.Name = GMXString(properties[GMXEnumString(GMXDataFileProperty.Name)], dataFile.Name);
                            dataFile.Id = GetIdFromName(dataFile.Name);
                            dataFile.Exists = GMXBool(properties[GMXEnumString(GMXDataFileProperty.Exists)], dataFile.Exists);
                            dataFile.Size = GMXInt(properties[GMXEnumString(GMXDataFileProperty.Size)], dataFile.Size);
                            dataFile.ExportAction = GMXInt(properties[GMXEnumString(GMXDataFileProperty.ExportAction)], dataFile.ExportAction);
                            dataFile.ExportDirectory = GMXString(properties[GMXEnumString(GMXDataFileProperty.ExportDir)], dataFile.ExportDirectory);
                            dataFile.OverwriteFile = GMXBool(properties[GMXEnumString(GMXDataFileProperty.Overwrite)], dataFile.OverwriteFile);
                            dataFile.FreeDataMemory = GMXBool(properties[GMXEnumString(GMXDataFileProperty.FreeData)], dataFile.FreeDataMemory);
                            dataFile.RemoveAtGameEnd = GMXBool(properties[GMXEnumString(GMXDataFileProperty.RemoveEnd)], dataFile.RemoveAtGameEnd);
                            dataFile.Store = GMXBool(properties[GMXEnumString(GMXDataFileProperty.Store)], dataFile.Store);
                            dataFile.FileName = GMXString(properties[GMXEnumString(GMXDataFileProperty.Filename)], dataFile.FileName);
                            dataFile.Configs = configs.ToArray();
                            configs.Clear();

                            // Add data file to the list
                            dataFiles.Add(dataFile);
                        }
                    }
                }
            }

            // Return the list of data files
            return dataFiles;
        }

        #endregion

        #region Game Maker 5 - 8.1

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

        #endregion

        #endregion
    }
}
