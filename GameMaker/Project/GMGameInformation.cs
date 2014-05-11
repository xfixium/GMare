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

namespace GameMaker.Project
{
    public class GMGameInformation
    {
        #region Fields

        private string _information = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil Arial;}}{\colortbl ;\red0\green0\blue0;}\viewkind4\uc1\pard\cf1\f0\fs24}";
        private string _formCaption = "Game Information";
        private double _lastChanged = 0;
        private int _x = -1;
        private int _y = -1;
        private int _width = 600;
        private int _height = 400;
        private int _backgroundColor = -16777192;
        private bool _mimicGameWindow = false;
        private bool _showBorder = true;
        private bool _allowResize = true;
        private bool _alwaysOnTop = false;
        private bool _pauseGame = true;

        #endregion

        #region Properties

        public string Information
        {
            get { return _information; }
            set { _information = value; }
        }

        public string FormCaption
        {
            get { return _formCaption; }
            set { _formCaption = value; }
        }

        public double LastChanged
        {
            get { return _lastChanged; }
            set { _lastChanged = value; }
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public int BackgroundColor
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }

        public bool MimicGameWindow
        {
            get { return _mimicGameWindow; }
            set { _mimicGameWindow = value; }
        }

        public bool ShowBorder
        {
            get { return _showBorder; }
            set { _showBorder = value; }
        }

        public bool AllowResize
        {
            get { return _allowResize; }
            set { _allowResize = value; }
        }

        public bool AlwaysOnTop
        {
            get { return _alwaysOnTop; }
            set { _alwaysOnTop = value; }
        }

        public bool PauseGame
        {
            get { return _pauseGame; }
            set { _pauseGame = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return 38 + _formCaption.Length + _information.Length;
        }

        /// <summary>
        /// Reads game information from GM file.
        /// </summary>
        public static GMGameInformation ReadGameInformation(GMFileReader reader)
        {
            // Get version.
            int version = reader.ReadGMInt();

            // Check version.
            if (version != 430 && version != 600 && version != 620 && version != 800)
                throw new Exception("Unsupported Pre-Game Information object version.");

            // Create new game information.
            GMGameInformation gameInfo = new GMGameInformation();

            // If version is 8.0, start inflate.
            if (version == 800)
                reader.Decompress();

            // Read game information data.
            gameInfo.BackgroundColor = reader.ReadGMInt();
            gameInfo.MimicGameWindow = reader.ReadGMBool();

            // Check version.
            if (version > 430)
            {
                // Read game information data.
                gameInfo.FormCaption = reader.ReadGMString();
                gameInfo.X = reader.ReadGMInt();
                gameInfo.Y = reader.ReadGMInt();
                gameInfo.Width = reader.ReadGMInt();
                gameInfo.Height = reader.ReadGMInt();
                gameInfo.ShowBorder = reader.ReadGMBool();
                gameInfo.AllowResize = reader.ReadGMBool();
                gameInfo.AlwaysOnTop = reader.ReadGMBool();
                gameInfo.PauseGame = reader.ReadGMBool();
            }

            // If version is 8.0, get last changed.
            if (version == 800)
                gameInfo.LastChanged = reader.ReadGMDouble();

            // Read game information data.
            gameInfo.Information = reader.ReadGMString();

            // End object inflate.
            reader.EndDecompress();

            // Return game information object.
            return gameInfo;
        }

        #endregion
    }
}