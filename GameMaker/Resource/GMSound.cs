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
    public class GMSound : GMResource
    {
        #region Fields

        private SoundType _type = SoundType.Normal;  // The type of playback.
        private SoundKind _kind = SoundKind.None;    // The kind of sound format.
        private double _volume = 1.0d;               // Volume.
        private double _pan = 0.0d;                  // Pan centering amount.
        private string _fileType = "";               // String representation of the sound kind.
        private string _fileName = "";               // The original file name.
        private int _effects = 0;                    // Sound effect flags.
        private int _buffers = 1;                    // The number of buffers.
        private bool _allowSoundEffects = false;     // If to allow sound effects.
        private bool _loadOnlyOnUse = false;         // If to load off disc when in use.
        private bool _preload = true;                // If to pre-load into audio memory.
        private byte[] _data = null;                 // Actual sound data.

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the type of playback.
        /// </summary>
        public SoundType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Gets or sets the kind of sound format.
        /// </summary>
        public SoundKind Kind
        {
            get { return _kind; }
            set { _kind = value; }
        }

        /// <summary>
        /// Gets or sets the volume
        /// </summary>
        public double Volume
        {
            get { return _volume; }
            set { _volume = value; }
        }

        /// <summary>
        /// Gets or sets the pan centering amount.
        /// </summary>
        public double Pan
        {
            get { return _pan; }
            set { _pan = value; }
        }

        /// <summary>
        /// Gets or sets the string representation of the sound kind.
        /// </summary>
        public string FileType
        {
            get { return _fileType; }
            set { _fileType = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Effects
        {
            get { return _effects; }
            set { _effects = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Buffers
        {
            get { return _buffers; }
            set { _buffers = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool AllowSoundEffects
        {
            get { return _allowSoundEffects; }
            set { _allowSoundEffects = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool LoadOnlyOnUse
        {
            get { return _loadOnlyOnUse; }
            set { _loadOnlyOnUse = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Preload
        {
            get { return _preload; }
            set { _preload = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public byte[] Data
        {
            get { return _data; }
            set { _data = value; }
        }

        #endregion

        #region Methods

        #region General

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            int size = 50 + _fileType.Length + _fileName.Length + Name.Length;

            if (_data != null)
                size += _data.Length;

            return size;
        }

        #endregion

        #region Read

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
                    sound.Kind = (SoundKind)reader.ReadGMInt();
                else
                    // Read sound data.
                    sound.Type = (SoundType)reader.ReadGMInt();

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

        #endregion
    }
}