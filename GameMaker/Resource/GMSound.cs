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
    public class GMSound : GMResource
    {
        #region Fields

        private byte[] _data = null;
        private double _volume = 1.0d;
        private double _pan = 0.0d;
        private string _fileType = "";
        private string _fileName = "";
        private string _filePath = "";
        private string _extension = "";
        private int _effects = 0;
        private int _type = 0;
        private int _kind = 0;
        private int _buffers = 1;
        private int _bitRate = 192;
        private int _bitDepth = 192;
        private int _oggQuality = -20;
        private int _sampleRate = 44100;
        private int _mp3BitRate = 128;
        private bool _allowSoundEffects = false;
        private bool _loadOnlyOnUse = false;
        private bool _preload = true;
        private bool _streamed = false;
        private bool _uncompressOnLoad = false;
        private bool _compressed = false;

        #endregion

        #region Properties

        public byte[] Data
        {
            get { return _data; }
            set { _data = value; }
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

        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        public string Extension
        {
            get { return _extension; }
            set { _extension = value; }
        }

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int Kind
        {
            get { return _kind; }
            set { _kind = value; }
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

        public int BitRate
        {
            get { return _bitRate; }
            set { _bitRate = value; }
        }

        public int BitDepth
        {
            get { return _bitDepth; }
            set { _bitDepth = value; }
        }

        public int OGGQuality
        {
            get { return _oggQuality; }
            set { _oggQuality = value; }
        }

        public int SampleRate
        {
            get { return _sampleRate; }
            set { _sampleRate = value; }
        }

        public int Mp3BitRate
        {
            get { return _mp3BitRate; }
            set { _mp3BitRate = value; }
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

        public bool Streamed
        {
            get { return _streamed; }
            set { _streamed = value; }
        }

        public bool UncompressOnLoad
        {
            get { return _uncompressOnLoad; }
            set { _uncompressOnLoad = value; }
        }

        public bool Compressed
        {
            get { return _compressed; }
            set { _compressed = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Reads all GMX sounds from a directory
        /// </summary>
        /// <param name="file">The XML (.GMX) file path</param>
        /// <returns>A list of sounds</returns>
        public static GMList<GMSound> ReadSoundsGMX(string directory, ref List<string> assets)
        {
            // A list of sounds
            GMList<GMSound> sounds = new GMList<GMSound>();
            sounds.AutoIncrementIds = false;

            // Iterate through .gmx files in the directory
            foreach (string file in Directory.GetFiles(directory, "*.gmx"))
            {
                // Set name of the sound
                string name = GetResourceName(file);

                // If the file is not in the asset list, it has been orphaned, continue
                if (!assets.Contains(name))
                    continue;

                // Create a dictionary of sound properties
                Dictionary<string, string> properties = new Dictionary<string, string>();
                foreach (GMXSoundProperty property in Enum.GetValues(typeof(GMXSoundProperty)))
                    properties.Add(GMXEnumString(property), "");

                // Create an xml reader
                using (XmlReader reader = XmlReader.Create(file))
                {
                    // Seek to content
                    reader.MoveToContent();

                    // Read the GMX file
                    while (reader.Read())
                    {
                        // If the node is not an element, continue
                        if (reader.NodeType != XmlNodeType.Element)
                            continue;

                        // Get the element name
                        string nodeName = reader.Name;

                        // Read element
                        reader.Read();

                        // If the element value is null or empty, continue
                        if (String.IsNullOrEmpty(reader.Value))
                            continue;

                        // Set the property value
                        properties[nodeName] = reader.Value;
                    }
                }

                // Create a new sound, set properties
                GMSound sound = new GMSound();
                sound.Id = GetIdFromName(name);
                sound.Name = name;
                sound.Kind = GMXInt(properties[GMXEnumString(GMXSoundProperty.Kind)], sound.Kind);
                sound.Extension = GMXString(properties[GMXEnumString(GMXSoundProperty.Extension)], sound.Extension);
                sound.FilePath = GMXString(properties[GMXEnumString(GMXSoundProperty.Origname)], sound.FilePath);
                sound.Effects = GMXInt(properties[GMXEnumString(GMXSoundProperty.Effects)], sound.Effects);
                sound.Volume = GMXDouble(properties[GMXEnumString(GMXSoundProperty.Volume)], sound.Volume);
                sound.Pan = GMXDouble(properties[GMXEnumString(GMXSoundProperty.Pan)], sound.Pan);
                sound.OGGQuality = GMXInt(properties[GMXEnumString(GMXSoundProperty.OggQuality)], sound.OGGQuality);
                sound.Preload = GMXBool(properties[GMXEnumString(GMXSoundProperty.Preload)], sound.Preload);
                sound.FileName = GMXString(properties[GMXEnumString(GMXSoundProperty.Data)], sound.FileName);
                sound.SampleRate = GMXInt(properties[GMXEnumString(GMXSoundProperty.SampleRate)], sound.SampleRate);
                sound.Type = GMXInt(properties[GMXEnumString(GMXSoundProperty.Type)], sound.Type);
                sound.BitDepth = GMXInt(properties[GMXEnumString(GMXSoundProperty.BitDepth)], sound.BitDepth);
                sound.Streamed = GMXBool(properties[GMXEnumString(GMXSoundProperty.Streamed)], sound.Streamed);
                sound.UncompressOnLoad = GMXBool(properties[GMXEnumString(GMXSoundProperty.UncompressOnLoad)], sound.UncompressOnLoad);
                sound.Compressed = GMXBool(properties[GMXEnumString(GMXSoundProperty.Compressed)], sound.Compressed);

                // Set bit rate
                if (properties.ContainsKey(GMXEnumString(GMXSoundProperty.BitRate)))
                    sound.BitRate = GMXInt(properties[GMXEnumString(GMXSoundProperty.BitRate)], sound.BitRate);
                else if (properties.ContainsKey(GMXEnumString(GMXSoundProperty.Mp3BitRate)))
                    sound.BitRate = GMXInt(properties[GMXEnumString(GMXSoundProperty.Mp3BitRate)], sound.BitRate);

                // Add the sound
                sounds.Add(sound);
            }

            // Return the list of sounds
            return sounds;
        }

        /// <summary>
        /// Reads all sounds from Game Maker project file stream.
        /// </summary>
        public static GMList<GMSound> ReadSounds(GMFileReader reader)
        {
            // Get version.
            int version = reader.ReadGMInt();

            // Check version.
            if (version != 400 && version != 800)
                throw new Exception("Unsupported Pre-Sound object version.");

            // Create a new sound list.
            GMList<GMSound> sounds = new GMList<GMSound>();

            // Amount of sound ids.
            int num = reader.ReadGMInt();

            // Iterate through sounds.
            for (int i = 0; i < num; i++)
            {
                // If version is 8.0, start inflate.
                if (version == 800)
                    reader.Decompress();

                // If the sound at index does not exists, continue.
                if (reader.ReadGMBool() == false)
                {
                    sounds.LastId++;
                    reader.EndDecompress();
                    continue;
                }

                // Create sound object.
                GMSound sound = new GMSound();

                // Set sound id.
                sound.Id = i;

                // Read sound data.
                sound.Name = reader.ReadGMString();

                // If version is 8.0, get last changed.
                if (version == 800)
                    sound.LastChanged = reader.ReadGMDouble();

                // Get version.
                version = reader.ReadGMInt();

                // Check version.
                if (version != 440 && version != 600 && version != 800)
                    throw new Exception("Unsupported Sound object version.");

                // Check version.
                if (version == 440)
                    sound.Kind = reader.ReadGMInt();
                else
                    // Read sound data.
                    sound.Type = reader.ReadGMInt();

                // Read sound data.
                sound.FileType = reader.ReadGMString();

                // Check version.
                if (version == 440)
                {
                    // If sound data exists, read it.
                    if ((int)sound.Kind != -1)
                        sound.Data = reader.ReadGMBytes(reader.ReadGMInt());

                    // Read sound data.
                    sound.AllowSoundEffects = reader.ReadGMBool();
                    sound.Buffers = reader.ReadGMInt();
                    sound.LoadOnlyOnUse = reader.ReadGMBool();
                }
                else
                {
                    // Read sound data.
                    sound.FileName = reader.ReadGMString();

                    // If sound data exists, read it.
                    if (reader.ReadGMBool() == true)
                        sound.Data = reader.ReadGMBytes(reader.ReadGMInt());

                    // Read sound data.
                    sound.Effects = reader.ReadGMInt();
                    sound.Volume = reader.ReadGMDouble();
                    sound.Pan = reader.ReadGMDouble();
                    sound.Preload = reader.ReadGMBool();
                }

                // End object inflate.
                reader.EndDecompress();

                // Add sound.
                sounds.Add(sound);
            }

            // Return sounds.
            return sounds;
        }

        #endregion
    }
}