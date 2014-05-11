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
    public class GMFont : GMResource
    {
        #region Fields

        private string _fontName = "Arial";
        private int _characterRangeMin = 32;
        private int _characterRangeMax = 127;
        private int _size = 12;
        private byte _antiAliasing = 3;
        private byte _characterSet = 1;
        private bool _bold = false;
        private bool _italic = false;

        #endregion

        #region Properties

        public string FontName
        {
            get { return _fontName; }
            set { _fontName = value; }
        }

        public int CharacterRangeMin
        {
            get { return _characterRangeMin; }
            set { _characterRangeMin = value; }
        }

        public int CharacterRangeMax
        {
            get { return _characterRangeMax; }
            set { _characterRangeMax = value; }
        }

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public byte AntiAliasing
        {
            get { return _antiAliasing; }
            set { _antiAliasing = value; }
        }

        public byte CharacterSet
        {
            get { return _characterSet; }
            set { _characterSet = value; }
        }

        public bool Bold
        {
            get { return _bold; }
            set { _bold = value; }
        }

        public bool Italic
        {
            get { return _italic; }
            set { _italic = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return 28 + _fontName.Length + Name.Length;
        }

        /// <summary>
        /// Reads all fonts from a GM file reader stream.
        /// </summary>
        public static GMList<GMFont> ReadFonts(int version, GMFileReader reader)
        {
            // Create a new list of fonts.
            GMList<GMFont> fonts = new GMList<GMFont>();

            // Amount of font ids.
            int num = reader.ReadGMInt();

            // Iterate through fonts.
            for (int i = 0; i < num; i++)
            {
                // If version is 8.0, start inflate.
                if (version == 800)
                    reader.Decompress();

                // If the font at index does not exists, continue.
                if (reader.ReadGMBool() == false)
                {
                    fonts.LastId++;
                    reader.EndDecompress();
                    continue;
                }

                // Create a new font object.
                GMFont font = new GMFont();

                // Set font id.
                font.Id = i;

                // Read font data.
                font.Name = reader.ReadGMString();

                // If version is 8.0, get last changed.
                if (version == 800)
                    font.LastChanged = reader.ReadGMDouble();

                // Get version.
                version = reader.ReadGMInt();

                // Check version.
                if (version != 540 && version != 800)
                    throw new Exception("Unsupported Font object version.");

                // Read font data.
                font.FontName = reader.ReadGMString();
                font.Size = reader.ReadGMInt();
                font.Bold = reader.ReadGMBool();
                font.Italic = reader.ReadGMBool();
                font.CharacterRangeMin = reader.ReadGMShort();
                font.CharacterSet = reader.ReadGMByte();
                font.AntiAliasing = reader.ReadGMByte();
                font.CharacterRangeMax = reader.ReadGMInt();

                // End object inflate.
                reader.EndDecompress();

                // Add font.
                fonts.Add(font);
            }

            // Return fonts.
            return fonts;
        }

        #endregion
    }
}
