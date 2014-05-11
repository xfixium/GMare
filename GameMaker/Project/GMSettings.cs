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
    public class GMSettings
    {
        #region Fields

        private LoadProgressBarType _loadBarMode = LoadProgressBarType.None;
        private ColorDepthType1 _colorDepth1 = ColorDepthType1.Color16Bit;
        private ColorDepthType2 _colorDepth2 = ColorDepthType2.None;
        private ResolutionType1 _resolution1 = ResolutionType1.Resolution800x600;
        private ResolutionType2 _resolution2 = ResolutionType2.NoChange;
        private FrequencyType1 _frequency1 = FrequencyType1.NoChange;
        private FrequencyType2 _frequency2 = FrequencyType2.NoChange;
        private PriorityType _gamePriority = PriorityType.Normal;
        private GMConstant[] _constants = null;
        private GMInclude[] _includes = null;
        private double _projectLastChanged = 0;
        private double _settingsLastChanged = 0;
        private string _company = "";
        private string _product = "";
        private string _copyright = "";
        private string _description = "";
        private string _author = "";
        private string _version = "";
        private string _information = "";
        private int _gameIdentifier = 0;
        private int _major = 0;
        private int _minor = 0;
        private int _release = 0;
        private int _build = 0;
        private int _loadImageAlpha = 255;
        private int _colorOutsideRoom = 0;
        private int _scaling = -1;
        private int _scaleInWindowedMode = 100;
        private int _scaleInFullScreenMode = 100;
        private int _includeFolder = 0;
        private bool _startFullscreen = false;
        private bool _scaleOnHardwareSupport = true;
        private bool _useExclusiveGraphicsMode = false;
        private bool _interpolate = false;
        private bool _dontDrawBorder = false;
        private bool _displayCursor = true;
        private bool _displayCaptionInFullScreenMode = true;
        private bool _allowWindowResize = false;
        private bool _alwaysOnTop = false;
        private bool _setResolution = false;
        private bool _showCustomLoadImage = false;
        private bool _imagePartiallyTransparent = false;
        private bool _scaleProgressBar = true;
        private bool _displayErrors = true;
        private bool _writeToLog = false;
        private bool _abortOnError = false;
        private bool _treatUninitializedAsZero = false;
        private bool _treatCloseButtonAsESC = true;
        private bool _dontShowButtons = false;
        private bool _useSynchronization = false;
        private bool _disableScreensaver = true;
        private bool _letF9TakeScreenShot = true;
        private bool _letF4SwitchFullscreen = true;
        private bool _letF1ShowGameInfo = true;
        private bool _letEscEndGame = true;
        private bool _letF5SaveF6Load = true;
        private bool _freezeOnLoseFocus = false;
        private bool _overwriteExisting = false;
        private bool _removeAtGameEnd = false;
        private byte[] _loadingImage = null;
        private byte[] _frontLoadBarImage = null;
        private byte[] _backLoadBarImage = null;
        private byte[] _gameIcon = null;

        #endregion

        #region Properties

        public LoadProgressBarType LoadBarMode
        {
            get { return _loadBarMode; }
            set { _loadBarMode = value; }
        }

        public ColorDepthType1 ColorDepth1
        {
            get { return _colorDepth1; }
            set { _colorDepth1 = value; }
        }

        public ColorDepthType2 ColorDepth2
        {
            get { return _colorDepth2; }
            set { _colorDepth2 = value; }
        }

        public ResolutionType1 Resolution1
        {
            get { return _resolution1; }
            set { _resolution1 = value; }
        }

        public ResolutionType2 Resolution2
        {
            get { return _resolution2; }
            set { _resolution2 = value; }
        }

        public FrequencyType1 Frequency1
        {
            get { return _frequency1; }
            set { _frequency1 = value; }
        }

        public FrequencyType2 Frequency2
        {
            get { return _frequency2; }
            set { _frequency2 = value; }
        }

        public PriorityType GamePriority
        {
            get { return _gamePriority; }
            set { _gamePriority = value; }
        }

        public GMConstant[] Constants
        {
            get { return _constants; }
            set { _constants = value; }
        }

        public GMInclude[] Includes
        {
            get { return _includes; }
            set { _includes = value; }
        }

        public double ProjectLastChanged
        {
            get { return _projectLastChanged; }
            set { _projectLastChanged = value; }
        }

        public double SettingsLastChanged
        {
            get { return _settingsLastChanged; }
            set { _settingsLastChanged = value; }
        }

        public string Company
        {
            get { return _company; }
            set { _company = value; }
        }

        public string Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public string Copyright
        {
            get { return _copyright; }
            set { _copyright = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        public string Information
        {
            get { return _information; }
            set { _information = value; }
        }

        public int GameIdentifier
        {
            get { return _gameIdentifier; }
            set { _gameIdentifier = value; }
        }

        public int Major
        {
            get { return _major; }
            set { _major = value; }
        }

        public int Minor
        {
            get { return _minor; }
            set { _minor = value; }
        }

        public int Release
        {
            get { return _release; }
            set { _release = value; }
        }

        public int Build
        {
            get { return _build; }
            set { _build = value; }
        }

        public int LoadImageAlpha
        {
            get { return _loadImageAlpha; }
            set { _loadImageAlpha = value; }
        }

        public int ColorOutsideRoom
        {
            get { return _colorOutsideRoom; }
            set { _colorOutsideRoom = value; }
        }

        public int Scaling
        {
            get { return _scaling; }
            set { _scaling = value; }
        }

        public int ScaleInWindowedMode
        {
            get { return _scaleInWindowedMode; }
            set { _scaleInWindowedMode = value; }
        }

        public int ScaleInFullScreenMode
        {
            get { return _scaleInFullScreenMode; }
            set { _scaleInFullScreenMode = value; }
        }

        public int IncludeFolder
        {
            get { return _includeFolder; }
            set { _includeFolder = value; }
        }

        public bool StartFullscreen
        {
            get { return _startFullscreen; }
            set { _startFullscreen = value; }
        }

        public bool ScaleOnHardwareSupport
        {
            get { return _scaleOnHardwareSupport; }
            set { _scaleOnHardwareSupport = value; }
        }

        public bool UseExclusiveGraphicsMode
        {
            get { return _useExclusiveGraphicsMode; }
            set { _useExclusiveGraphicsMode = value; }
        }

        public bool Interpolate
        {
            get { return _interpolate; }
            set { _interpolate = value; }
        }

        public bool DontDrawBorder
        {
            get { return _dontDrawBorder; }
            set { _dontDrawBorder = value; }
        }

        public bool DisplayCursor
        {
            get { return _displayCursor; }
            set { _displayCursor = value; }
        }

        public bool DisplayCaptionInFullScreenMode
        {
            get { return _displayCaptionInFullScreenMode; }
            set { _displayCaptionInFullScreenMode = value; }
        }

        public bool AllowWindowResize
        {
            get { return _allowWindowResize; }
            set { _allowWindowResize = value; }
        }

        public bool AlwaysOnTop
        {
            get { return _alwaysOnTop; }
            set { _alwaysOnTop = value; }
        }

        public bool SetResolution
        {
            get { return _setResolution; }
            set { _setResolution = value; }
        }

        public bool ShowCustomLoadImage
        {
            get { return _showCustomLoadImage; }
            set { _showCustomLoadImage = value; }
        }

        public bool ImagePartiallyTransparent
        {
            get { return _imagePartiallyTransparent; }
            set { _imagePartiallyTransparent = value; }
        }

        public bool ScaleProgressBar
        {
            get { return _scaleProgressBar; }
            set { _scaleProgressBar = value; }
        }

        public bool DisplayErrors
        {
            get { return _displayErrors; }
            set { _displayErrors = value; }
        }

        public bool WriteToLog
        {
            get { return _writeToLog; }
            set { _writeToLog = value; }
        }

        public bool AbortOnError
        {
            get { return _abortOnError; }
            set { _abortOnError = value; }
        }

        public bool TreatUninitializedAsZero
        {
            get { return _treatUninitializedAsZero; }
            set { _treatUninitializedAsZero = value; }
        }

        public bool TreatCloseButtonAsESC
        {
            get { return _treatCloseButtonAsESC; }
            set { _treatCloseButtonAsESC = value; }
        }

        public bool DontShowButtons
        {
            get { return _dontShowButtons; }
            set { _dontShowButtons = value; }
        }

        public bool UseSynchronization
        {
            get { return _useSynchronization; }
            set { _useSynchronization = value; }
        }

        public bool DisableScreensaver
        {
            get { return _disableScreensaver; }
            set { _disableScreensaver = value; }
        }

        public bool LetF9TakeScreenShot
        {
            get { return _letF9TakeScreenShot; }
            set { _letF9TakeScreenShot = value; }
        }

        public bool LetF4SwitchFullscreen
        {
            get { return _letF4SwitchFullscreen; }
            set { _letF4SwitchFullscreen = value; }
        }

        public bool LetF1ShowGameInfo
        {
            get { return _letF1ShowGameInfo; }
            set { _letF1ShowGameInfo = value; }
        }

        public bool LetEscEndGame
        {
            get { return _letEscEndGame; }
            set { _letEscEndGame = value; }
        }

        public bool LetF5SaveF6Load
        {
            get { return _letF5SaveF6Load; }
            set { _letF5SaveF6Load = value; }
        }

        public bool FreezeOnLoseFocus
        {
            get { return _freezeOnLoseFocus; }
            set { _freezeOnLoseFocus = value; }
        }

        public bool OverwriteExisting
        {
            get { return _overwriteExisting; }
            set { _overwriteExisting = value; }
        }

        public bool RemoveAtGameEnd
        {
            get { return _removeAtGameEnd; }
            set { _removeAtGameEnd = value; }
        }

        public byte[] LoadingImage
        {
            get { return _loadingImage; }
            set { _loadingImage = value; }
        }

        public byte[] FrontLoadBarImage
        {
            get { return _frontLoadBarImage; }
            set { _frontLoadBarImage = value; }
        }

        public byte[] BackLoadBarImage
        {
            get { return _backLoadBarImage; }
            set { _backLoadBarImage = value; }
        }

        public byte[] GameIcon
        {
            get { return _gameIcon; }
            set { _gameIcon = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetSize(GMVersionType version)
        {
            int size = 126 + _company.Length + _product.Length + _copyright.Length + _description.Length + _author.Length + _version.Length + _information.Length;

            if (_constants != null)
                foreach (GMConstant constant in _constants)
                    size += constant.GetSize(version);

            if (_includes != null)
                foreach (GMInclude include in _includes)
                    size += include.GetSize(version);

            if (_loadingImage != null)
                size += _loadingImage.Length;

            if (_frontLoadBarImage != null)
                size += _frontLoadBarImage.Length;

            if (_backLoadBarImage != null)
                size += _backLoadBarImage.Length;

            if (_gameIcon != null)
                size += _gameIcon.Length;

            return size;
        }

        /// <summary>
        /// Reads game settings from GM file reader stream.
        /// </summary>
        public static GMSettings ReadSettings(GMFileReader reader)
        {
            // Create a new game maker settings object.
            GMSettings settings = new GMSettings();

            // Get Game Settings object version.
            int version = reader.ReadGMInt();

            // Check version.
            if (version != 500 && version != 510 && version != 520 && version != 530 && version != 542 &&
                version != 600 && version != 702 && version != 800)
                throw new Exception("Unsupported Game Settings object version.");

            // If version is GM8, start inflater stream.
            if (version == 800)
                reader.Decompress();

            // Read settings data
            settings.StartFullscreen = reader.ReadGMBool();

            // Versions greater than 5.3 support interpolation.
            if (version > 542)
                settings.Interpolate = reader.ReadGMBool();

            // Read settings data.
            settings.DontDrawBorder = reader.ReadGMBool();
            settings.DisplayCursor = reader.ReadGMBool();

            // Versions greater than 5.3 support the below variables.
            if (version > 530)
            {
                // Read settings data.
                settings.Scaling = reader.ReadGMInt();
                settings.AllowWindowResize = reader.ReadGMBool();
                settings.AlwaysOnTop = reader.ReadGMBool();
                settings.ColorOutsideRoom = reader.ReadGMInt();
            }
            else
            {
                // Read settings data.
                settings.ScaleInWindowedMode = reader.ReadGMInt();
                settings.ScaleInFullScreenMode = reader.ReadGMInt();
                settings.ScaleOnHardwareSupport = reader.ReadGMBool();
            }

            // Read settings data.
            settings.SetResolution = reader.ReadGMBool();

            // Versions greater than 5.3 support the below variables.
            if (version > 530)
            {
                // Read settings data.
                settings.ColorDepth2 = (ColorDepthType2)reader.ReadGMInt();
                settings.Resolution2 = (ResolutionType2)reader.ReadGMInt();
                settings.Frequency2 = (FrequencyType2)reader.ReadGMInt();
            }
            else
            {
                // Read settings data.
                settings.ColorDepth1 = (ColorDepthType1)reader.ReadGMInt();
                settings.UseExclusiveGraphicsMode = reader.ReadGMBool();
                settings.Resolution1 = (ResolutionType1)reader.ReadGMInt();
                settings.Frequency1 = (FrequencyType1)reader.ReadGMInt();
                settings.UseSynchronization = reader.ReadGMBool();
                settings.DisplayCaptionInFullScreenMode = reader.ReadGMBool();
            }

            // Read settings data.
            settings.DontShowButtons = reader.ReadGMBool();

            // Versions greater than 5.3 support screen synchronization.
            if (version > 530)
                settings.UseSynchronization = reader.ReadGMBool();

            // Versions greater than 7.0 support disabling the screensaver, and power saving options.
            if (version > 720)
                settings.DisableScreensaver = reader.ReadGMBool();

            // Read settings.
            settings.LetF4SwitchFullscreen = reader.ReadGMBool();
            settings.LetF1ShowGameInfo = reader.ReadGMBool();
            settings.LetEscEndGame = reader.ReadGMBool();
            settings.LetF5SaveF6Load = reader.ReadGMBool();

            // Skip reserved bytes.
            if (version < 542)
                reader.ReadGMBytes(8);

            // Versions greater than 6.0, treat close as esc, F9 screenshot.
            if (version > 600)
            {
                settings.LetF9TakeScreenShot = reader.ReadGMBool();
                settings.TreatCloseButtonAsESC = reader.ReadGMBool();
            }

            // Versions greater than 5.1 support game priority.
            if (version > 510)
                settings.GamePriority = (PriorityType)reader.ReadGMInt();

            // Read settings data.
            settings.FreezeOnLoseFocus = reader.ReadGMBool();
            settings.LoadBarMode = (LoadProgressBarType)reader.ReadGMInt();

            // If the loadbar type is a custom loadbar.
            if (settings.LoadBarMode == LoadProgressBarType.Custom)
            {
                // If version is greater than 7.0.
                if (version > 702)
                {
                    // If a back loadbar image exists.
                    if (reader.ReadGMBool() == true)
                    {
                        // Get size of image data.
                        int size = reader.ReadGMInt();

                        // Get back loadbar image data.
                        settings.BackLoadBarImage = reader.ReadGMBytes(size);
                    }

                    // If a front loadbar image exists.
                    if (reader.ReadGMBool() == true)
                    {
                        // Get size of image data.
                        int size = reader.ReadGMInt();

                        // Get ffront loadbar image data.
                        settings.FrontLoadBarImage = reader.ReadGMBytes(size);
                    }
                }
                else
                {
                    // If a back loadbar image exists.
                    if (reader.ReadGMInt() != -1)
                    {
                        // Get size of image data.
                        int size = reader.ReadGMInt();

                        // Get back loadbar image data.
                        settings.BackLoadBarImage = reader.ReadGMBytes(size);
                    }

                    // If a front loadbar image exists.
                    if (reader.ReadGMInt() != -1)
                    {
                        // Get size of image data.
                        int size = reader.ReadGMInt();

                        // Get front loadbar image data.
                        settings.FrontLoadBarImage = reader.ReadGMBytes(size);
                    }
                }
            }

            // Read settings data.
            settings.ShowCustomLoadImage = reader.ReadGMBool();

            // If a custom load image must be shown
            if (settings.ShowCustomLoadImage == true)
            {
                // If version is greater than 7.0.
                if (version > 702)
                {
                    // If a custom load image is present
                    if (reader.ReadGMBool() == true)
                    {
                        // Get size of image data
                        int size = reader.ReadGMInt();

                        // Get custom load image data
                        settings.LoadingImage = reader.ReadGMBytes(size);
                    }
                }
                else
                {
                    // If a custom load image is present
                    if (reader.ReadGMInt() != -1)
                    {
                        // Get size of image data
                        int size = reader.ReadGMInt();

                        // Get custom load image data
                        settings.LoadingImage = reader.ReadGMBytes(size);
                    }
                }
            }

            // Versions greater than 5.0 support loading image alpha.
            if (version > 500)
            {
                // Read settings data.
                settings.ImagePartiallyTransparent = reader.ReadGMBool();
                settings.LoadImageAlpha = reader.ReadGMInt();
                settings.ScaleProgressBar = reader.ReadGMBool();
            }

            // Get size of icon image data.
            int iconSize = reader.ReadGMInt();

            // Read settings data.
            settings.GameIcon = reader.ReadGMBytes(iconSize);
            settings.DisplayErrors = reader.ReadGMBool();
            settings.WriteToLog = reader.ReadGMBool();
            settings.AbortOnError = reader.ReadGMBool();
            settings.TreatUninitializedAsZero = reader.ReadGMBool();
            settings.Author = reader.ReadGMString();

            // Versions greater than 6.0 use a string for the version data.
            if (version > 600)
                settings.Version = reader.ReadGMString();
            else
                settings.Version = reader.ReadGMInt().ToString();

            // Read settings data.
            settings.ProjectLastChanged = reader.ReadGMDouble();
            settings.Information = reader.ReadGMString();

            // Versions greater than 5.2 support constants. Versions greater than 7 read constants elsewhere.
            if (version > 520 && version < 800)
            {
                // Number of constants defined.
                settings.Constants = new GMConstant[reader.ReadGMInt()];

                // Iterate through constants.
                for (int i = 0; i < settings.Constants.Length; i++)
                {
                    // Create a new constant.
                    GMConstant constant = new GMConstant();

                    // Get constant data.
                    constant.Name = reader.ReadGMString();
                    constant.Value = reader.ReadGMString();

                    // Add constant to settings.
                    settings.Constants[i] = constant;
                }
            }

            // If version is greater than 6.0.
            if (version > 600)
            {
                // Read build information.
                settings.Major = reader.ReadGMInt();
                settings.Minor = reader.ReadGMInt();
                settings.Release = reader.ReadGMInt();
                settings.Build = reader.ReadGMInt();
                settings.Company = reader.ReadGMString();
                settings.Product = reader.ReadGMString();
                settings.Copyright = reader.ReadGMString();
                settings.Description = reader.ReadGMString();

                // If the version is greater than 7.0, read last time global settings were changed.
                if (version > 702)
                    settings.SettingsLastChanged = reader.ReadGMDouble();
            }
            else if (version > 530)  // If version is greater than 5.3.
            {
                // Number of include files.
                settings.Includes = new GMInclude[reader.ReadGMInt()];

                // Get each include file.
                for (int i = 0; i < settings.Includes.Length; i++)
                {
                    // Read settings include file data.
                    settings.Includes[i].FileName = reader.ReadGMString();
                }

                // Read settings data.
                settings.IncludeFolder = reader.ReadGMInt();
                settings.OverwriteExisting = reader.ReadGMBool();
                settings.RemoveAtGameEnd = reader.ReadGMBool();
            }

            // End inflater.
            reader.EndDecompress();

            // Return a GMProject settings object.
            return settings;
        }

        #endregion
    }

    public class GMConstant
    {
        #region Fields

        private static double _lastChanged = 0;  // Last changed date.
        private string _name = "";               // Personalized name.
        private string _value = "";              // Value.

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the
        /// </summary>
        public static double LastChanged
        {
            get { return _lastChanged; }
            set { _lastChanged = value; }
        }

        /// <summary>
        /// Gets or sets the
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets the
        /// </summary>
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public int GetSize(GMVersionType version)
        {
            return 8 + _name.Length + _value.Length;
        }

        /// <summary>
        /// Reads all constants from GM file stream.
        /// </summary>
        public static GMConstant[] ReadConstants(GMFileReader reader)
        {
            // Get version.
            int version = reader.ReadGMInt();

            // Check version.
            if (version != 800)
                throw new Exception("Unsupported Pre-Sound object version.");

            // Number of constants defined.
            GMConstant[] constants = new GMConstant[reader.ReadGMInt()];

            // Iterate through constants.
            for (int i = 0; i < constants.Length; i++)
            {
                // Create a new constant.
                GMConstant constant = new GMConstant();

                // Get constant data.
                constant.Name = reader.ReadGMString();
                constant.Value = reader.ReadGMString();

                // Add constant.
                constants[i] = constant;
            }

            // Last changed.
            GMConstant.LastChanged = reader.ReadGMDouble();

            // Return constants.
            return constants;
        }

        #endregion
    }

    public class GMInclude
    {
        #region Fields

        private ExportType _exportMode = ExportType.WorkingFolder;
        private string _fileName = "";
		private string _filePath = "";
        private double _lastChanged = 0;
		private int _originalFileSize = 0;
		private int _folderToExport = 0;
        private bool _originalFileChosen = false;
        private bool _storeInEditableGMKFile = false;
		private bool _overwriteIfExists = false;
        private bool _freeMemoryAfterExport = true;
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

		public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        public double LastChanged
        {
            get { return _lastChanged; }
            set { _lastChanged = value; }
        }

		public int OriginalFileSize
        {
            get { return _originalFileSize; }
            set { _originalFileSize = value; }
        }

		public int FolderToExport
        {
            get { return _folderToExport; }
            set { _folderToExport = value; }
        }

        public bool OriginalFileChosen
        {
            get { return _originalFileChosen; }
            set { _originalFileChosen = value; }
        }

        public bool StoreInEditableGMKFile
        {
            get { return _storeInEditableGMKFile; }
            set { _storeInEditableGMKFile = value; }
        }

		public bool OverwriteIfExists
        {
            get { return _overwriteIfExists; }
            set { _overwriteIfExists = value; }
        }

        public bool FreeMemoryAfterExport
        {
            get { return _freeMemoryAfterExport; }
            set { _freeMemoryAfterExport = value; }
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetSize(GMVersionType version)
        {
            int size = 30 + _fileName.Length + _filePath.Length;

            if (_data != null)
                size += _data.Length;

            return size;
        }

        /// <summary>
        /// Reads game includes from GM file stream.
        /// </summary>
        public static GMInclude[] ReadIncludes(GMFileReader reader)
        {
            // Get version.
            int version = reader.ReadGMInt();

            // Check version.
            if (version != 430 && version != 600 && version != 620 && version != 800)
                throw new Exception("Unsupported Pre-Includes object version.");

            // Create a new array of includes.
            GMInclude[] includes = new GMInclude[reader.ReadGMInt()];

            // Iterate through includes.
            for (int i = 0; i < includes.Length; i++)
            {
                // Create a new include object.
                GMInclude include = new GMInclude();

                // If version is 8.0, get last changed.
                if (version == 800)
                    include.LastChanged = reader.ReadGMDouble();

                // Get version.
                version = reader.ReadGMInt();

                // Check version.
                if (version != 620 && version != 800)
                    throw new Exception("Unsupported Includes object version.");

                // Read include data.
                include.FileName = reader.ReadGMString();
                include.FilePath = reader.ReadGMString();
                include.OriginalFileChosen = reader.ReadGMBool();
                include.OriginalFileSize = reader.ReadGMInt();
                include.StoreInEditableGMKFile = reader.ReadGMBool();

                // If the include file will be stored within the executable, read data.
                if (include.StoreInEditableGMKFile == true)
                    include.Data = reader.ReadGMBytes(reader.ReadGMInt());

                // Read include data.
                include.ExportMode = (ExportType)(reader.ReadGMInt());
                include.FolderToExport = reader.ReadGMInt();
                include.OverwriteIfExists = reader.ReadGMBool();
                include.FreeMemoryAfterExport = reader.ReadGMBool();
                include.RemoveAtGameEnd = reader.ReadGMBool();

                // Set include object.
                includes[i] = include;
            }

            // Return include objects.
            return includes;
        }

        #endregion
    }

    public class ConfigOptions
    {
        #region Fields

        string _optionAbortErrors = "";
        string _optionAndroidGPUDevice = "";
        string _optionAndroidAdcolonyEnableV4VC = "";
        string _optionAndroidAdvertisingEnable = "";
        string _optionAndroidAdvertisingKey = "";
        string _optionAndroidAdvertisingType = "";
        string _optionAndroidAmazonGameCircle = "";
        string _optionAndroidAmazonGcAchievements = "";
        string _optionAndroidAmazonGcLeaderboards = "";
        string _optionAndroidAmazonGcWhispersync = "";
        string _optionAndroidAmazonIap = "";
        string _optionAndroidApkExpansion = "";
        string _optionAndroidArchArmv5 = "";
        string _optionAndroidArchArmv7 = "";
        string _optionAndroidArchMips = "";
        string _optionAndroidArchMipsr2 = "";
        string _optionAndroidArchMipsr2sf = "";
        string _optionAndroidArchX86 = "";
        string _optionAndroidBuildVersion = "";
        string _optionAndroidColorDepth = "";
        string _optionAndroidDisplayName = "";
        string _optionAndroidFlurryEnable = "";
        string _optionAndroidFlurryId = "";
        string _optionAndroidGoogleAnalyticsEnable = "";
        string _optionAndroidGooglePlay = "";
        string _optionAndroidGooglePlayId = "";
        string _optionAndroidGoogleTrackingId = "";
        string _optionAndroidIapSuppressToast = "";
        string _optionAndroidIcadeSupport = "";
        string _optionAndroidIconHdpi = "";
        string _optionAndroidIconLdpi = "";
        string _optionAndroidIconMdpi = "";
        string _optionAndroidIconXhdpi = "";
        string _optionAndroidIconXxhdpi = "";
        string _optionAndroidIconXxxhdpi = "";
        string _optionAndroidInstallLocation = "";
        string _optionAndroidInterpolate = "";
        string _optionAndroidLicensingEnable = "";
        string _optionAndroidLicensingKey = "";
        string _optionAndroidMajorVersion = "";
        string _optionAndroidMinorVersion = "";
        string _optionAndroidOrientLandscape = "";
        string _optionAndroidOrientPortrait = "";
        string _optionAndroidOrientation = "";
        string _optionAndroidOuyaIcon = "";
        string _optionAndroidPackageCompany = "";
        string _optionAndroidPackageDomain = "";
        string _optionAndroidPackageProduct = "";
        string _optionAndroidPermissionFlags = "";
        string _optionAndroidPocketchangeEnable = "";
        string _optionAndroidPocketchangeId = "";
        string _optionAndroidPocketchangeTestEnable = "";
        string _optionAndroidPushEnable = "";
        string _optionAndroidPushId = "";
        string _optionAndroidScale = "";
        string _optionAndroidSetDeviceId = "";
        string _optionAndroidSplashPng = "";
        string _optionAndroidTexturePage = "";
        string _optionAndroidUseTestAds = "";
        string _optionArgumentErrors = "";
        string _optionAuthor = "";
        string _optionBackImage = "";
        string _optionChanged = "";
        string _optionChangeResolution = "";
        string _optionCloseEsc = "";
        string _optionColordepth = "";
        string _optionDisplayName = "";
        string _optionDisplayErrors = "";
        string _optionFacebookAppId = "";
        string _optionFacebookEnable = "";
        string _optionFreeze = "";
        string _optionFrequency = "";
        string _optionFrontimage = "";
        string _optionFullscreen = "";
        string _optionGameguid = "";
        string _optionGameid = "";
        string _optionHapticEffects = "";
        string _optionHasloadimage = "";
        string _optionHelpkey = "";
        string _optionHtml5CreationEventOrder = "";
        string _optionHtml5WebGL = "";
        string _optionHtml5AdvertisingEnable = "";
        string _optionHtml5AdvertisingKey = "";
        string _optionHtml5AdvertisingType = "";
        string _optionHtml5AllowFullscreen = "";
        string _optionHtml5Alwaysreload = "";
        string _optionHtml5Centergame = "";
        string _optionHtml5FlurryEnable = "";
        string _optionHtml5FlurryId = "";
        string _optionHtml5Foldername = "";
        string _optionHtml5GenerateSpotifyApp = "";
        string _optionHtml5GoogleAnalyticsEnable = "";
        string _optionHtml5GoogleTrackingId = "";
        string _optionHtml5Icon = "";
        string _optionHtml5Index = "";
        string _optionHtml5Interpolate = "";
        string _optionHtml5Jsprepend = "";
        string _optionHtml5Loadingbar = "";
        string _optionHtml5Outputdebugtoconsole = "";
        string _optionHtml5Outputname = "";
        string _optionHtml5Scale = "";
        string _optionHtml5SplashPng = "";
        string _optionHtml5TexturePage = "";
        string _optionHtml5UseTestAds = "";
        string _optionHtml5Usesplash = "";
        string _optionIcon = "";
        string _optionInAppPurchaseEnable = "";
        string _optionInAppPurchaseSandboxMode = "";
        string _optionInAppPurchaseServerUrl = "";
        string _optionInformation = "";
        string _optionInterpolate = "";
        string _optionIosAdcolonyEnableV4VC = "";
        string _optionIosAdvertisingEnable = "";
        string _optionIosAdvertisingKey = "";
        string _optionIosAdvertisingType = "";
        string _optionIosAppId = "";
        string _optionIosBuildVersion = "";
        string _optionIosCertificate = "";
        string _optionIosDeviceType = "";
        string _optionIosDisplayName = "";
        string _optionIosFlurryEnable = "";
        string _optionIosFlurryId = "";
        string _optionIosGoogleAnalyticsEnable = "";
        string _optionIosGooglePlayId = "";
        string _optionIosGoogleTrackingId = "";
        string _optionIosIcon114 = "";
        string _optionIosIcon120 = "";
        string _optionIosIcon144 = "";
        string _optionIosIcon152 = "";
        string _optionIosIcon57 = "";
        string _optionIosIcon72 = "";
        string _optionIosIcon76 = "";
        string _optionIosInterpolate = "";
        string _optionIosIpadRetinaSplashPng = "";
        string _optionIosIpadSplashPng = "";
        string _optionIosIphone5SplashPng = "";
        string _optionIosIphoneRetinaSplashPng = "";
        string _optionIosIphoneSplashPng = "";
        string _optionIosMajorVersion = "";
        string _optionIosMinorVersion = "";
        string _optionIosOrientLandscape = "";
        string _optionIosOrientLandscapeRight = "";
        string _optionIosOrientPortrait = "";
        string _optionIosOrientPortraitUpsideDown = "";
        string _optionIosProvisioning = "";
        string _optionIosPushEnable = "";
        string _optionIosScale = "";
        string _optionIosSetDeviceId = "";
        string _optionIosSplashPng = "";
        string _optionIosTexturePage = "";
        string _optionIosUseTestAds = "";
        string _optionLastchanged = "";
        string _optionLinuxDisplayName = "";
        string _optionLinuxEnableSteam = "";
        string _optionLinuxFullscreen = "";
        string _optionLinuxIcon = "";
        string _optionLinuxInterpolate = "";
        string _optionLinuxScale = "";
        string _optionLinuxScreenKey = "";
        string _optionLinuxSizeable = "";
        string _optionLinuxSplashPng = "";
        string _optionLinuxSteaAppId = "";
        string _optionLinuxSync = "";
        string _optionLinuxTexturePage = "";
        string _optionLoadalpha = "";
        string _optionLoadimage = "";
        string _optionLoadtransparent = "";
        string _optionMacAppCategory = "";
        string _optionMacAppId = "";
        string _optionMacAppstoreIncomingAllow = "";
        string _optionMacAppstoreOutgoingAllow = "";
        string _optionMacBuildVersion = "";
        string _optionMacCopyrightInfo = "";
        string _optionMacCreateAppStore = "";
        string _optionMacDisplayName = "";
        string _optionMacEnableSteam = "";
        string _optionMacFullscreen = "";
        string _optionMacIconPng = "";
        string _optionMacInterpolate = "";
        string _optionMacMajorVersion = "";
        string _optionMacMenuDock = "";
        string _optionMacMinorVersion = "";
        string _optionMacOutputDir = "";
        string _optionMacScale = "";
        string _optionMacScreenkey = "";
        string _optionMacShowcursor = "";
        string _optionMacSizeable = "";
        string _optionMacSplashPng = "";
        string _optionMacSteaAppId = "";
        string _optionMacSync = "";
        string _optionMacTexturePage = "";
        string _optionNoborder = "";
        string _optionNobuttons = "";
        string _optionNoscreensaver = "";
        string _optionOuyaPackaging = "";
        string _optionPriority = "";
        string _optionPs4Interpolate = "";
        string _optionPs4Nptitleid = "";
        string _optionPs4Nptitlesecret = "";
        string _optionPs4PackageId = "";
        string _optionPs4Passcode = "";
        string _optionPs4Scale = "";
        string _optionPs4TexturePage = "";
        string _optionPsvitaInterpolation = "";
        string _optionPsvitaPackageId = "";
        string _optionPsvitaPasscode = "";
        string _optionQuitkey = "";
        string _optionResolution = "";
        string _optionSavekey = "";
        string _optionScale = "";
        string _optionScaleProgress = "";
        string _optionScreenKey = "";
        string _optionScreenshotKey = "";
        string _optionShortCircuit = "";
        string _optionShowCursor = "";
        string _optionShowProgress = "";
        string _optionSizeable = "";
        string _optionStayontop = "";
        string _optionSyncVertex = "";
        string _optionTextureGroup0Border = "";
        string _optionTextureGroup0Nocropping = "";
        string _optionTextureGroup0Parent = "";
        string _optionTextureGroup0Scaled = "";
        string _optionTextureGroup0Targets = "";
        string _optionTextureGroupCount = "";
        string _optionTextureGroups0 = "";
        string _optionTizenAppId = "";
        string _optionTizenBuildVersion = "";
        string _optionTizenDisplayName = "";
        string _optionTizenFlurryEnable = "";
        string _optionTizenFlurryId = "";
        string _optionTizenGoogleAnalyticsEnable = "";
        string _optionTizenGoogleTrackingId = "";
        string _optionTizenIapGroupID = "";
        string _optionTizenIcon = "";
        string _optionTizenInterpolate = "";
        string _optionTizenMajorVersion = "";
        string _optionTizenMinorVersion = "";
        string _optionTizenNetworkUrls = "";
        string _optionTizenOrientation = "";
        string _optionTizenPushEnable = "";
        string _optionTizenScaling = "";
        string _optionTizenSplashPng = "";
        string _optionTizenTexturePage = "";
        string _optionTizenUsesplash = "";
        string _optionUseNewAudio = "";
        string _optionVariableErrors = "";
        string _optionVersion = "";
        string _optionVersionBuild = "";
        string _optionVersionCompany = "";
        string _optionVersionCopyright = "";
        string _optionVersionDescription = "";
        string _optionVersionMajor = "";
        string _optionVersionMinor = "";
        string _optionVersionProduct = "";
        string _optionVersionRelease = "";
        string _optionWin8AdvertisingAppid = "";
        string _optionWin8AdvertisingEnable = "";
        string _optionWin8AdvertisingKey = "";
        string _optionWin8AdvertisingTestingEnable = "";
        string _optionWin8AdvertisingType = "";
        string _optionWin8AnalyticsEnable = "";
        string _optionWin8AnalyticsId = "";
        string _optionWin8BuildVersion = "";
        string _optionWin8CertificateLocation = "";
        string _optionWin8DisplayName = "";
        string _optionWin8InternetCapable = "";
        string _optionWin8Interpolate = "";
        string _optionWin8LandscapeAllowed = "";
        string _optionWin8LandscapeFlippedAllowed = "";
        string _optionWin8Logo = "";
        string _optionWin8LogoBackgroundColour = "";
        string _optionWin8LogoForegroundText = "";
        string _optionWin8MajorVersion = "";
        string _optionWin8MinorVersion = "";
        string _optionWin8NativeCertificateLocation = "";
        string _optionWin8NativeCpu = "";
        string _optionWin8PackageDisplayName = "";
        string _optionWin8PackageName = "";
        string _optionWin8PortraitAllowed = "";
        string _optionWin8PortraitFlippedAllowed = "";
        string _optionWin8PublisherDisplayName = "";
        string _optionWin8RevisionVersion = "";
        string _optionWin8ScalingStretch = "";
        string _optionWin8SearchCapable = "";
        string _optionWin8SmallLogo = "";
        string _optionWin8SplashBackgroundColour = "";
        string _optionWin8SplashPng = "";
        string _optionWin8StoreLogo = "";
        string _optionWin8TexturePage = "";
        string _optionWin8WideLogo = "";
        string _optionWindowcolor = "";
        string _optionWindowsBuildVersion = "";
        string _optionWindowsCompanyInfo = "";
        string _optionWindowsCopyrightInfo = "";
        string _optionWindowsDescriptionInfo = "";
        string _optionWindowsEnableSteam = "";
        string _optionWindowsGameIcon = "";
        string _optionWindowsLicense = "";
        string _optionWindowsMinorVersion = "";
        string _optionWindowsMajorVersion = "";
        string _optionWindowsNsisFile = "";
        string _optionWindowsProductInfo = "";
        string _optionWindowsReleaseVersion = "";
        string _optionWindowsRunnerFinished = "";
        string _optionWindowsRunnerHeader = "";
        string _optionWindowsSaveLocation = "";
        string _optionWindowsSplashScreen = "";
        string _optionWindowsSteaAppId = "";
        string _optionWindowsTexturePage = "";
        string _optionWinphone480SplashImage = "";
        string _optionWinphone720SplashImage = "";
        string _optionWinphone768SplashImage = "";
        string _optionWinphoneAdvertisingAppid = "";
        string _optionWinphoneAdvertisingEnable = "";
        string _optionWinphoneAdvertisingKey = "";
        string _optionWinphoneAdvertisingTestingEnable = "";
        string _optionWinphoneAdvertisingType = "";
        string _optionWinphoneAuthor = "";
        string _optionWinphoneBuildVersion = "";
        string _optionWinphoneCycleSmallImage = "";
        string _optionWinphoneCycleWideImage1 = "";
        string _optionWinphoneCycleWideImage2 = "";
        string _optionWinphoneCycleWideImage3 = "";
        string _optionWinphoneCycleWideImage4 = "";
        string _optionWinphoneCycleWideImage5 = "";
        string _optionWinphoneCycleWideImage6 = "";
        string _optionWinphoneCycleWideImage7 = "";
        string _optionWinphoneCycleWideImage8 = "";
        string _optionWinphoneCycleWideImage9 = "";
        string _optionWinphoneDescription = "";
        string _optionWinphoneDisplayName = "";
        string _optionWinphoneFlipContentBack = "";
        string _optionWinphoneFlipContentFront = "";
        string _optionWinphoneFlipMediuBackImage = "";
        string _optionWinphoneFlipMediuFrontImage = "";
        string _optionWinphoneFlipSmallBackImage = "";
        string _optionWinphoneFlipSmallFrontImage = "";
        string _optionWinphoneFlipWideBackImage = "";
        string _optionWinphoneFlipWideFrontImage = "";
        string _optionWinphoneFlurryEnable = "";
        string _optionWinphoneFlurryId = "";
        string _optionWinphoneGenre = "";
        string _optionWinphoneGoogleAnalyticsEnable = "";
        string _optionWinphoneGoogleTrackingId = "";
        string _optionWinphoneIconImage = "";
        string _optionWinphoneIconicBackgroundColour = "";
        string _optionWinphoneIconicMessage = "";
        string _optionWinphoneIconicSmallImage = "";
        string _optionWinphoneIconicWideContent1 = "";
        string _optionWinphoneIconicWideContent2 = "";
        string _optionWinphoneIconicWideContent3 = "";
        string _optionWinphoneIconicWideImage = "";
        string _optionWinphoneInterpolate = "";
        string _optionWinphoneLandscapeAllowed = "";
        string _optionWinphoneLandscapeFlippedAllowed = "";
        string _optionWinphoneMajorVersion = "";
        string _optionWinphoneMinorVersion = "";
        string _optionWinphonePortraitAllowed = "";
        string _optionWinphonePublisher = "";
        string _optionWinphonePublisherId = "";
        string _optionWinphoneRevisionVersion = "";
        string _optionWinphoneScale = "";
        string _optionWinphoneSupports720p = "";
        string _optionWinphoneSupportsWvga = "";
        string _optionWinphoneSupportsWxga = "";
        string _optionWinphoneTexturePage = "";
        string _optionWinphoneTileType = "";
        string _optionWriteErrors = "";
        string _optionXboneBackgroundColour = "";
        string _optionXboneBuildVersion = "";
        string _optionXboneDescription = "";
        string _optionXboneDisplayName = "";
        string _optionXboneForegroundText = "";
        string _optionXboneInterpolation = "";
        string _optionXboneMajorVersion = "";
        string _optionXboneMinorVersion = "";
        string _optionXbonePublisher = "";
        string _optionXbonePublisherDisplayName = "";
        string _optionXboneRevisionVersion = "";
        string _optionXboneScale = "";
        string _optionXboneSplashScreenColour = "";
        string _optionXboneTexturePage = "";

        #endregion

        #region Properties

        public string OptionAborterrors
        {
            get { return _optionAbortErrors; }
            set { _optionAbortErrors = value; }
        }
        public string OptionAndroidGPUDevice
        {
            get { return _optionAndroidGPUDevice; }
            set { _optionAndroidGPUDevice = value; }
        }
        public string OptionAndroidAdcolonyEnableV4VC
        {
            get { return _optionAndroidAdcolonyEnableV4VC; }
            set { _optionAndroidAdcolonyEnableV4VC = value; }
        }
        public string OptionAndroidAdvertisingEnable
        {
            get { return _optionAndroidAdvertisingEnable; }
            set { _optionAndroidAdvertisingEnable = value; }
        }
        public string OptionAndroidAdvertisingKey
        {
            get { return _optionAndroidAdvertisingKey; }
            set { _optionAndroidAdvertisingKey = value; }
        }
        public string OptionAndroidAdvertisingType
        {
            get { return _optionAndroidAdvertisingType; }
            set { _optionAndroidAdvertisingType = value; }
        }
        public string OptionAndroidAmazonGameCircle
        {
            get { return _optionAndroidAmazonGameCircle; }
            set { _optionAndroidAmazonGameCircle = value; }
        }
        public string OptionAndroidAmazonGcAchievements
        {
            get { return _optionAndroidAmazonGcAchievements; }
            set { _optionAndroidAmazonGcAchievements = value; }
        }
        public string OptionAndroidAmazonGcLeaderboards
        {
            get { return _optionAndroidAmazonGcLeaderboards; }
            set { _optionAndroidAmazonGcLeaderboards = value; }
        }
        public string OptionAndroidAmazonGcWhispersync
        {
            get { return _optionAndroidAmazonGcWhispersync; }
            set { _optionAndroidAmazonGcWhispersync = value; }
        }
        public string OptionAndroidAmazonIap
        {
            get { return _optionAndroidAmazonIap; }
            set { _optionAndroidAmazonIap = value; }
        }
        public string OptionAndroidApkExpansion
        {
            get { return _optionAndroidApkExpansion; }
            set { _optionAndroidApkExpansion = value; }
        }
        public string OptionAndroidArchArmv5
        {
            get { return _optionAndroidArchArmv5; }
            set { _optionAndroidArchArmv5 = value; }
        }
        public string OptionAndroidArchArmv7
        {
            get { return _optionAndroidArchArmv7; }
            set { _optionAndroidArchArmv7 = value; }
        }
        public string OptionAndroidArchMips
        {
            get { return _optionAndroidArchMips; }
            set { _optionAndroidArchMips = value; }
        }
        public string OptionAndroidArchMipsr2
        {
            get { return _optionAndroidArchMipsr2; }
            set { _optionAndroidArchMipsr2 = value; }
        }
        public string OptionAndroidArchMipsr2sf
        {
            get { return _optionAndroidArchMipsr2sf; }
            set { _optionAndroidArchMipsr2sf = value; }
        }
        public string OptionAndroidArchX86
        {
            get { return _optionAndroidArchX86; }
            set { _optionAndroidArchX86 = value; }
        }
        public string OptionAndroidBuildVersion
        {
            get { return _optionAndroidBuildVersion; }
            set { _optionAndroidBuildVersion = value; }
        }
        public string OptionAndroidColorDepth
        {
            get { return _optionAndroidColorDepth; }
            set { _optionAndroidColorDepth = value; }
        }
        public string OptionAndroidDisplayName
        {
            get { return _optionAndroidDisplayName; }
            set { _optionAndroidDisplayName = value; }
        }
        public string OptionAndroidFlurryEnable
        {
            get { return _optionAndroidFlurryEnable; }
            set { _optionAndroidFlurryEnable = value; }
        }
        public string OptionAndroidFlurryId
        {
            get { return _optionAndroidFlurryId; }
            set { _optionAndroidFlurryId = value; }
        }
        public string OptionAndroidGoogleAnalyticsEnable
        {
            get { return _optionAndroidGoogleAnalyticsEnable; }
            set { _optionAndroidGoogleAnalyticsEnable = value; }
        }
        public string OptionAndroidGooglePlay
        {
            get { return _optionAndroidGooglePlay; }
            set { _optionAndroidGooglePlay = value; }
        }
        public string OptionAndroidGooglePlayId
        {
            get { return _optionAndroidGooglePlayId; }
            set { _optionAndroidGooglePlayId = value; }
        }
        public string OptionAndroidGoogleTrackingId
        {
            get { return _optionAndroidGoogleTrackingId; }
            set { _optionAndroidGoogleTrackingId = value; }
        }
        public string OptionAndroidIapSuppressToast
        {
            get { return _optionAndroidIapSuppressToast; }
            set { _optionAndroidIapSuppressToast = value; }
        }
        public string OptionAndroidIcadeSupport
        {
            get { return _optionAndroidIcadeSupport; }
            set { _optionAndroidIcadeSupport = value; }
        }
        public string OptionAndroidIconHdpi
        {
            get { return _optionAndroidIconHdpi; }
            set { _optionAndroidIconHdpi = value; }
        }
        public string OptionAndroidIconLdpi
        {
            get { return _optionAndroidIconLdpi; }
            set { _optionAndroidIconLdpi = value; }
        }
        public string OptionAndroidIconMdpi
        {
            get { return _optionAndroidIconMdpi; }
            set { _optionAndroidIconMdpi = value; }
        }
        public string OptionAndroidIconXhdpi
        {
            get { return _optionAndroidIconXhdpi; }
            set { _optionAndroidIconXhdpi = value; }
        }
        public string OptionAndroidIconXxhdpi
        {
            get { return _optionAndroidIconXxhdpi; }
            set { _optionAndroidIconXxhdpi = value; }
        }
        public string OptionAndroidIconXxxhdpi
        {
            get { return _optionAndroidIconXxxhdpi; }
            set { _optionAndroidIconXxxhdpi = value; }
        }
        public string OptionAndroidInstallLocation
        {
            get { return _optionAndroidInstallLocation; }
            set { _optionAndroidInstallLocation = value; }
        }
        public string OptionAndroidInterpolate
        {
            get { return _optionAndroidInterpolate; }
            set { _optionAndroidInterpolate = value; }
        }
        public string OptionAndroidLicensingEnable
        {
            get { return _optionAndroidLicensingEnable; }
            set { _optionAndroidLicensingEnable = value; }
        }
        public string OptionAndroidLicensingKey
        {
            get { return _optionAndroidLicensingKey; }
            set { _optionAndroidLicensingKey = value; }
        }
        public string OptionAndroidMajorVersion
        {
            get { return _optionAndroidMajorVersion; }
            set { _optionAndroidMajorVersion = value; }
        }
        public string OptionAndroidMinorVersion
        {
            get { return _optionAndroidMinorVersion; }
            set { _optionAndroidMinorVersion = value; }
        }
        public string OptionAndroidOrientLandscape
        {
            get { return _optionAndroidOrientLandscape; }
            set { _optionAndroidOrientLandscape = value; }
        }
        public string OptionAndroidOrientPortrait
        {
            get { return _optionAndroidOrientPortrait; }
            set { _optionAndroidOrientPortrait = value; }
        }
        public string OptionAndroidOrientation
        {
            get { return _optionAndroidOrientation; }
            set { _optionAndroidOrientation = value; }
        }
        public string OptionAndroidOuyaIcon
        {
            get { return _optionAndroidOuyaIcon; }
            set { _optionAndroidOuyaIcon = value; }
        }
        public string OptionAndroidPackageCompany
        {
            get { return _optionAndroidPackageCompany; }
            set { _optionAndroidPackageCompany = value; }
        }
        public string OptionAndroidPackageDomain
        {
            get { return _optionAndroidPackageDomain; }
            set { _optionAndroidPackageDomain = value; }
        }
        public string OptionAndroidPackageProduct
        {
            get { return _optionAndroidPackageProduct; }
            set { _optionAndroidPackageProduct = value; }
        }
        public string OptionAndroidPermissionFlags
        {
            get { return _optionAndroidPermissionFlags; }
            set { _optionAndroidPermissionFlags = value; }
        }
        public string OptionAndroidPocketchangeEnable
        {
            get { return _optionAndroidPocketchangeEnable; }
            set { _optionAndroidPocketchangeEnable = value; }
        }
        public string OptionAndroidPocketchangeId
        {
            get { return _optionAndroidPocketchangeId; }
            set { _optionAndroidPocketchangeId = value; }
        }
        public string OptionAndroidPocketchangeTestEnable
        {
            get { return _optionAndroidPocketchangeTestEnable; }
            set { _optionAndroidPocketchangeTestEnable = value; }
        }
        public string OptionAndroidPushEnable
        {
            get { return _optionAndroidPushEnable; }
            set { _optionAndroidPushEnable = value; }
        }
        public string OptionAndroidPushId
        {
            get { return _optionAndroidPushId; }
            set { _optionAndroidPushId = value; }
        }
        public string OptionAndroidScale
        {
            get { return _optionAndroidScale; }
            set { _optionAndroidScale = value; }
        }
        public string OptionAndroidSetDeviceId
        {
            get { return _optionAndroidSetDeviceId; }
            set { _optionAndroidSetDeviceId = value; }
        }
        public string OptionAndroidSplashPng
        {
            get { return _optionAndroidSplashPng; }
            set { _optionAndroidSplashPng = value; }
        }
        public string OptionAndroidTexturePage
        {
            get { return _optionAndroidTexturePage; }
            set { _optionAndroidTexturePage = value; }
        }
        public string OptionAndroidUseTestAds
        {
            get { return _optionAndroidUseTestAds; }
            set { _optionAndroidUseTestAds = value; }
        }
        public string OptionArgumenterrors
        {
            get { return _optionArgumentErrors; }
            set { _optionArgumentErrors = value; }
        }
        public string OptionAuthor
        {
            get { return _optionAuthor; }
            set { _optionAuthor = value; }
        }
        public string OptionBackimage
        {
            get { return _optionBackImage; }
            set { _optionBackImage = value; }
        }
        public string OptionChanged
        {
            get { return _optionChanged; }
            set { _optionChanged = value; }
        }
        public string OptionChangeresolution
        {
            get { return _optionChangeResolution; }
            set { _optionChangeResolution = value; }
        }
        public string OptionCloseesc
        {
            get { return _optionCloseEsc; }
            set { _optionCloseEsc = value; }
        }
        public string OptionColordepth
        {
            get { return _optionColordepth; }
            set { _optionColordepth = value; }
        }
        public string OptionDisplayName
        {
            get { return _optionDisplayName; }
            set { _optionDisplayName = value; }
        }
        public string OptionDisplayerrors
        {
            get { return _optionDisplayErrors; }
            set { _optionDisplayErrors = value; }
        }
        public string OptionFacebookAppid
        {
            get { return _optionFacebookAppId; }
            set { _optionFacebookAppId = value; }
        }
        public string OptionFacebookEnable
        {
            get { return _optionFacebookEnable; }
            set { _optionFacebookEnable = value; }
        }
        public string OptionFreeze
        {
            get { return _optionFreeze; }
            set { _optionFreeze = value; }
        }
        public string OptionFrequency
        {
            get { return _optionFrequency; }
            set { _optionFrequency = value; }
        }
        public string OptionFrontimage
        {
            get { return _optionFrontimage; }
            set { _optionFrontimage = value; }
        }
        public string OptionFullscreen
        {
            get { return _optionFullscreen; }
            set { _optionFullscreen = value; }
        }
        public string OptionGameguid
        {
            get { return _optionGameguid; }
            set { _optionGameguid = value; }
        }
        public string OptionGameid
        {
            get { return _optionGameid; }
            set { _optionGameid = value; }
        }
        public string OptionHapticEffects
        {
            get { return _optionHapticEffects; }
            set { _optionHapticEffects = value; }
        }
        public string OptionHasloadimage
        {
            get { return _optionHasloadimage; }
            set { _optionHasloadimage = value; }
        }
        public string OptionHelpkey
        {
            get { return _optionHelpkey; }
            set { _optionHelpkey = value; }
        }
        public string OptionHtml5CreationEventOrder
        {
            get { return _optionHtml5CreationEventOrder; }
            set { _optionHtml5CreationEventOrder = value; }
        }
        public string OptionHtml5WebGL
        {
            get { return _optionHtml5WebGL; }
            set { _optionHtml5WebGL = value; }
        }
        public string OptionHtml5AdvertisingEnable
        {
            get { return _optionHtml5AdvertisingEnable; }
            set { _optionHtml5AdvertisingEnable = value; }
        }
        public string OptionHtml5AdvertisingKey
        {
            get { return _optionHtml5AdvertisingKey; }
            set { _optionHtml5AdvertisingKey = value; }
        }
        public string OptionHtml5AdvertisingType
        {
            get { return _optionHtml5AdvertisingType; }
            set { _optionHtml5AdvertisingType = value; }
        }
        public string OptionHtml5AllowFullscreen
        {
            get { return _optionHtml5AllowFullscreen; }
            set { _optionHtml5AllowFullscreen = value; }
        }
        public string OptionHtml5Alwaysreload
        {
            get { return _optionHtml5Alwaysreload; }
            set { _optionHtml5Alwaysreload = value; }
        }
        public string OptionHtml5Centergame
        {
            get { return _optionHtml5Centergame; }
            set { _optionHtml5Centergame = value; }
        }
        public string OptionHtml5FlurryEnable
        {
            get { return _optionHtml5FlurryEnable; }
            set { _optionHtml5FlurryEnable = value; }
        }
        public string OptionHtml5FlurryId
        {
            get { return _optionHtml5FlurryId; }
            set { _optionHtml5FlurryId = value; }
        }
        public string OptionHtml5Foldername
        {
            get { return _optionHtml5Foldername; }
            set { _optionHtml5Foldername = value; }
        }
        public string OptionHtml5GenerateSpotifyApp
        {
            get { return _optionHtml5GenerateSpotifyApp; }
            set { _optionHtml5GenerateSpotifyApp = value; }
        }
        public string OptionHtml5GoogleAnalyticsEnable
        {
            get { return _optionHtml5GoogleAnalyticsEnable; }
            set { _optionHtml5GoogleAnalyticsEnable = value; }
        }
        public string OptionHtml5GoogleTrackingId
        {
            get { return _optionHtml5GoogleTrackingId; }
            set { _optionHtml5GoogleTrackingId = value; }
        }
        public string OptionHtml5Icon
        {
            get { return _optionHtml5Icon; }
            set { _optionHtml5Icon = value; }
        }
        public string OptionHtml5Index
        {
            get { return _optionHtml5Index; }
            set { _optionHtml5Index = value; }
        }
        public string OptionHtml5Interpolate
        {
            get { return _optionHtml5Interpolate; }
            set { _optionHtml5Interpolate = value; }
        }
        public string OptionHtml5Jsprepend
        {
            get { return _optionHtml5Jsprepend; }
            set { _optionHtml5Jsprepend = value; }
        }
        public string OptionHtml5Loadingbar
        {
            get { return _optionHtml5Loadingbar; }
            set { _optionHtml5Loadingbar = value; }
        }
        public string OptionHtml5Outputdebugtoconsole
        {
            get { return _optionHtml5Outputdebugtoconsole; }
            set { _optionHtml5Outputdebugtoconsole = value; }
        }
        public string OptionHtml5Outputname
        {
            get { return _optionHtml5Outputname; }
            set { _optionHtml5Outputname = value; }
        }
        public string OptionHtml5Scale
        {
            get { return _optionHtml5Scale; }
            set { _optionHtml5Scale = value; }
        }
        public string OptionHtml5SplashPng
        {
            get { return _optionHtml5SplashPng; }
            set { _optionHtml5SplashPng = value; }
        }
        public string OptionHtml5TexturePage
        {
            get { return _optionHtml5TexturePage; }
            set { _optionHtml5TexturePage = value; }
        }
        public string OptionHtml5UseTestAds
        {
            get { return _optionHtml5UseTestAds; }
            set { _optionHtml5UseTestAds = value; }
        }
        public string OptionHtml5Usesplash
        {
            get { return _optionHtml5Usesplash; }
            set { _optionHtml5Usesplash = value; }
        }
        public string OptionIcon
        {
            get { return _optionIcon; }
            set { _optionIcon = value; }
        }
        public string OptionInAppPurchaseEnable
        {
            get { return _optionInAppPurchaseEnable; }
            set { _optionInAppPurchaseEnable = value; }
        }
        public string OptionInAppPurchaseSandboxMode
        {
            get { return _optionInAppPurchaseSandboxMode; }
            set { _optionInAppPurchaseSandboxMode = value; }
        }
        public string OptionInAppPurchaseServerUrl
        {
            get { return _optionInAppPurchaseServerUrl; }
            set { _optionInAppPurchaseServerUrl = value; }
        }
        public string OptionInformation
        {
            get { return _optionInformation; }
            set { _optionInformation = value; }
        }
        public string OptionInterpolate
        {
            get { return _optionInterpolate; }
            set { _optionInterpolate = value; }
        }
        public string OptionIosAdcolonyEnableV4VC
        {
            get { return _optionIosAdcolonyEnableV4VC; }
            set { _optionIosAdcolonyEnableV4VC = value; }
        }
        public string OptionIosAdvertisingEnable
        {
            get { return _optionIosAdvertisingEnable; }
            set { _optionIosAdvertisingEnable = value; }
        }
        public string OptionIosAdvertisingKey
        {
            get { return _optionIosAdvertisingKey; }
            set { _optionIosAdvertisingKey = value; }
        }
        public string OptionIosAdvertisingType
        {
            get { return _optionIosAdvertisingType; }
            set { _optionIosAdvertisingType = value; }
        }
        public string OptionIosAppId
        {
            get { return _optionIosAppId; }
            set { _optionIosAppId = value; }
        }
        public string OptionIosBuildVersion
        {
            get { return _optionIosBuildVersion; }
            set { _optionIosBuildVersion = value; }
        }
        public string OptionIosCertificate
        {
            get { return _optionIosCertificate; }
            set { _optionIosCertificate = value; }
        }
        public string OptionIosDeviceType
        {
            get { return _optionIosDeviceType; }
            set { _optionIosDeviceType = value; }
        }
        public string OptionIosDisplayName
        {
            get { return _optionIosDisplayName; }
            set { _optionIosDisplayName = value; }
        }
        public string OptionIosFlurryEnable
        {
            get { return _optionIosFlurryEnable; }
            set { _optionIosFlurryEnable = value; }
        }
        public string OptionIosFlurryId
        {
            get { return _optionIosFlurryId; }
            set { _optionIosFlurryId = value; }
        }
        public string OptionIosGoogleAnalyticsEnable
        {
            get { return _optionIosGoogleAnalyticsEnable; }
            set { _optionIosGoogleAnalyticsEnable = value; }
        }
        public string OptionIosGooglePlayId
        {
            get { return _optionIosGooglePlayId; }
            set { _optionIosGooglePlayId = value; }
        }
        public string OptionIosGoogleTrackingId
        {
            get { return _optionIosGoogleTrackingId; }
            set { _optionIosGoogleTrackingId = value; }
        }
        public string OptionIosIcon114
        {
            get { return _optionIosIcon114; }
            set { _optionIosIcon114 = value; }
        }
        public string OptionIosIcon120
        {
            get { return _optionIosIcon120; }
            set { _optionIosIcon120 = value; }
        }
        public string OptionIosIcon144
        {
            get { return _optionIosIcon144; }
            set { _optionIosIcon144 = value; }
        }
        public string OptionIosIcon152
        {
            get { return _optionIosIcon152; }
            set { _optionIosIcon152 = value; }
        }
        public string OptionIosIcon57
        {
            get { return _optionIosIcon57; }
            set { _optionIosIcon57 = value; }
        }
        public string OptionIosIcon72
        {
            get { return _optionIosIcon72; }
            set { _optionIosIcon72 = value; }
        }
        public string OptionIosIcon76
        {
            get { return _optionIosIcon76; }
            set { _optionIosIcon76 = value; }
        }
        public string OptionIosInterpolate
        {
            get { return _optionIosInterpolate; }
            set { _optionIosInterpolate = value; }
        }
        public string OptionIosIpadRetinaSplashPng
        {
            get { return _optionIosIpadRetinaSplashPng; }
            set { _optionIosIpadRetinaSplashPng = value; }
        }
        public string OptionIosIpadSplashPng
        {
            get { return _optionIosIpadSplashPng; }
            set { _optionIosIpadSplashPng = value; }
        }
        public string OptionIosIphone5SplashPng
        {
            get { return _optionIosIphone5SplashPng; }
            set { _optionIosIphone5SplashPng = value; }
        }
        public string OptionIosIphoneRetinaSplashPng
        {
            get { return _optionIosIphoneRetinaSplashPng; }
            set { _optionIosIphoneRetinaSplashPng = value; }
        }
        public string OptionIosIphoneSplashPng
        {
            get { return _optionIosIphoneSplashPng; }
            set { _optionIosIphoneSplashPng = value; }
        }
        public string OptionIosMajorVersion
        {
            get { return _optionIosMajorVersion; }
            set { _optionIosMajorVersion = value; }
        }
        public string OptionIosMinorVersion
        {
            get { return _optionIosMinorVersion; }
            set { _optionIosMinorVersion = value; }
        }
        public string OptionIosOrientLandscape
        {
            get { return _optionIosOrientLandscape; }
            set { _optionIosOrientLandscape = value; }
        }
        public string OptionIosOrientLandscapeRight
        {
            get { return _optionIosOrientLandscapeRight; }
            set { _optionIosOrientLandscapeRight = value; }
        }
        public string OptionIosOrientPortrait
        {
            get { return _optionIosOrientPortrait; }
            set { _optionIosOrientPortrait = value; }
        }
        public string OptionIosOrientPortraitUpsideDown
        {
            get { return _optionIosOrientPortraitUpsideDown; }
            set { _optionIosOrientPortraitUpsideDown = value; }
        }
        public string OptionIosProvisioning
        {
            get { return _optionIosProvisioning; }
            set { _optionIosProvisioning = value; }
        }
        public string OptionIosPushEnable
        {
            get { return _optionIosPushEnable; }
            set { _optionIosPushEnable = value; }
        }
        public string OptionIosScale
        {
            get { return _optionIosScale; }
            set { _optionIosScale = value; }
        }
        public string OptionIosSetDeviceId
        {
            get { return _optionIosSetDeviceId; }
            set { _optionIosSetDeviceId = value; }
        }
        public string OptionIosSplashPng
        {
            get { return _optionIosSplashPng; }
            set { _optionIosSplashPng = value; }
        }
        public string OptionIosTexturePage
        {
            get { return _optionIosTexturePage; }
            set { _optionIosTexturePage = value; }
        }
        public string OptionIosUseTestAds
        {
            get { return _optionIosUseTestAds; }
            set { _optionIosUseTestAds = value; }
        }
        public string OptionLastchanged
        {
            get { return _optionLastchanged; }
            set { _optionLastchanged = value; }
        }
        public string OptionLinuxDisplayName
        {
            get { return _optionLinuxDisplayName; }
            set { _optionLinuxDisplayName = value; }
        }
        public string OptionLinuxEnableSteam
        {
            get { return _optionLinuxEnableSteam; }
            set { _optionLinuxEnableSteam = value; }
        }
        public string OptionLinuxFullscreen
        {
            get { return _optionLinuxFullscreen; }
            set { _optionLinuxFullscreen = value; }
        }
        public string OptionLinuxIcon
        {
            get { return _optionLinuxIcon; }
            set { _optionLinuxIcon = value; }
        }
        public string OptionLinuxInterpolate
        {
            get { return _optionLinuxInterpolate; }
            set { _optionLinuxInterpolate = value; }
        }
        public string OptionLinuxScale
        {
            get { return _optionLinuxScale; }
            set { _optionLinuxScale = value; }
        }
        public string OptionLinuxScreenkey
        {
            get { return _optionLinuxScreenKey; }
            set { _optionLinuxScreenKey = value; }
        }
        public string OptionLinuxSizeable
        {
            get { return _optionLinuxSizeable; }
            set { _optionLinuxSizeable = value; }
        }
        public string OptionLinuxSplashPng
        {
            get { return _optionLinuxSplashPng; }
            set { _optionLinuxSplashPng = value; }
        }
        public string OptionLinuxSteaAppId
        {
            get { return _optionLinuxSteaAppId; }
            set { _optionLinuxSteaAppId = value; }
        }
        public string OptionLinuxSync
        {
            get { return _optionLinuxSync; }
            set { _optionLinuxSync = value; }
        }
        public string OptionLinuxTexturePage
        {
            get { return _optionLinuxTexturePage; }
            set { _optionLinuxTexturePage = value; }
        }
        public string OptionLoadalpha
        {
            get { return _optionLoadalpha; }
            set { _optionLoadalpha = value; }
        }
        public string OptionLoadimage
        {
            get { return _optionLoadimage; }
            set { _optionLoadimage = value; }
        }
        public string OptionLoadtransparent
        {
            get { return _optionLoadtransparent; }
            set { _optionLoadtransparent = value; }
        }
        public string OptionMacAppCategory
        {
            get { return _optionMacAppCategory; }
            set { _optionMacAppCategory = value; }
        }
        public string OptionMacAppId
        {
            get { return _optionMacAppId; }
            set { _optionMacAppId = value; }
        }
        public string OptionMacAppstoreIncomingAllow
        {
            get { return _optionMacAppstoreIncomingAllow; }
            set { _optionMacAppstoreIncomingAllow = value; }
        }
        public string OptionMacAppstoreOutgoingAllow
        {
            get { return _optionMacAppstoreOutgoingAllow; }
            set { _optionMacAppstoreOutgoingAllow = value; }
        }
        public string OptionMacBuildVersion
        {
            get { return _optionMacBuildVersion; }
            set { _optionMacBuildVersion = value; }
        }
        public string OptionMacCopyrightInfo
        {
            get { return _optionMacCopyrightInfo; }
            set { _optionMacCopyrightInfo = value; }
        }
        public string OptionMacCreateAppStore
        {
            get { return _optionMacCreateAppStore; }
            set { _optionMacCreateAppStore = value; }
        }
        public string OptionMacDisplayName
        {
            get { return _optionMacDisplayName; }
            set { _optionMacDisplayName = value; }
        }
        public string OptionMacEnableSteam
        {
            get { return _optionMacEnableSteam; }
            set { _optionMacEnableSteam = value; }
        }
        public string OptionMacFullscreen
        {
            get { return _optionMacFullscreen; }
            set { _optionMacFullscreen = value; }
        }
        public string OptionMacIconPng
        {
            get { return _optionMacIconPng; }
            set { _optionMacIconPng = value; }
        }
        public string OptionMacInterpolate
        {
            get { return _optionMacInterpolate; }
            set { _optionMacInterpolate = value; }
        }
        public string OptionMacMajorVersion
        {
            get { return _optionMacMajorVersion; }
            set { _optionMacMajorVersion = value; }
        }
        public string OptionMacMenuDock
        {
            get { return _optionMacMenuDock; }
            set { _optionMacMenuDock = value; }
        }
        public string OptionMacMinorVersion
        {
            get { return _optionMacMinorVersion; }
            set { _optionMacMinorVersion = value; }
        }
        public string OptionMacOutputDir
        {
            get { return _optionMacOutputDir; }
            set { _optionMacOutputDir = value; }
        }
        public string OptionMacScale
        {
            get { return _optionMacScale; }
            set { _optionMacScale = value; }
        }
        public string OptionMacScreenkey
        {
            get { return _optionMacScreenkey; }
            set { _optionMacScreenkey = value; }
        }
        public string OptionMacShowcursor
        {
            get { return _optionMacShowcursor; }
            set { _optionMacShowcursor = value; }
        }
        public string OptionMacSizeable
        {
            get { return _optionMacSizeable; }
            set { _optionMacSizeable = value; }
        }
        public string OptionMacSplashPng
        {
            get { return _optionMacSplashPng; }
            set { _optionMacSplashPng = value; }
        }
        public string OptionMacSteaAppId
        {
            get { return _optionMacSteaAppId; }
            set { _optionMacSteaAppId = value; }
        }
        public string OptionMacSync
        {
            get { return _optionMacSync; }
            set { _optionMacSync = value; }
        }
        public string OptionMacTexturePage
        {
            get { return _optionMacTexturePage; }
            set { _optionMacTexturePage = value; }
        }
        public string OptionNoborder
        {
            get { return _optionNoborder; }
            set { _optionNoborder = value; }
        }
        public string OptionNobuttons
        {
            get { return _optionNobuttons; }
            set { _optionNobuttons = value; }
        }
        public string OptionNoscreensaver
        {
            get { return _optionNoscreensaver; }
            set { _optionNoscreensaver = value; }
        }
        public string OptionOuyaPackaging
        {
            get { return _optionOuyaPackaging; }
            set { _optionOuyaPackaging = value; }
        }
        public string OptionPriority
        {
            get { return _optionPriority; }
            set { _optionPriority = value; }
        }
        public string OptionPs4Interpolate
        {
            get { return _optionPs4Interpolate; }
            set { _optionPs4Interpolate = value; }
        }
        public string OptionPs4Nptitleid
        {
            get { return _optionPs4Nptitleid; }
            set { _optionPs4Nptitleid = value; }
        }
        public string OptionPs4Nptitlesecret
        {
            get { return _optionPs4Nptitlesecret; }
            set { _optionPs4Nptitlesecret = value; }
        }
        public string OptionPs4PackageId
        {
            get { return _optionPs4PackageId; }
            set { _optionPs4PackageId = value; }
        }
        public string OptionPs4Passcode
        {
            get { return _optionPs4Passcode; }
            set { _optionPs4Passcode = value; }
        }
        public string OptionPs4Scale
        {
            get { return _optionPs4Scale; }
            set { _optionPs4Scale = value; }
        }
        public string OptionPs4TexturePage
        {
            get { return _optionPs4TexturePage; }
            set { _optionPs4TexturePage = value; }
        }
        public string OptionPsvitaInterpolation
        {
            get { return _optionPsvitaInterpolation; }
            set { _optionPsvitaInterpolation = value; }
        }
        public string OptionPsvitaPackageId
        {
            get { return _optionPsvitaPackageId; }
            set { _optionPsvitaPackageId = value; }
        }
        public string OptionPsvitaPasscode
        {
            get { return _optionPsvitaPasscode; }
            set { _optionPsvitaPasscode = value; }
        }
        public string OptionQuitkey
        {
            get { return _optionQuitkey; }
            set { _optionQuitkey = value; }
        }
        public string OptionResolution
        {
            get { return _optionResolution; }
            set { _optionResolution = value; }
        }
        public string OptionSavekey
        {
            get { return _optionSavekey; }
            set { _optionSavekey = value; }
        }
        public string OptionScale
        {
            get { return _optionScale; }
            set { _optionScale = value; }
        }
        public string OptionScaleprogress
        {
            get { return _optionScaleProgress; }
            set { _optionScaleProgress = value; }
        }
        public string OptionScreenkey
        {
            get { return _optionScreenKey; }
            set { _optionScreenKey = value; }
        }
        public string OptionScreenshotkey
        {
            get { return _optionScreenshotKey; }
            set { _optionScreenshotKey = value; }
        }
        public string OptionShortcircuit
        {
            get { return _optionShortCircuit; }
            set { _optionShortCircuit = value; }
        }
        public string OptionShowcursor
        {
            get { return _optionShowCursor; }
            set { _optionShowCursor = value; }
        }
        public string OptionShowprogress
        {
            get { return _optionShowProgress; }
            set { _optionShowProgress = value; }
        }
        public string OptionSizeable
        {
            get { return _optionSizeable; }
            set { _optionSizeable = value; }
        }
        public string OptionStayontop
        {
            get { return _optionStayontop; }
            set { _optionStayontop = value; }
        }
        public string OptionSyncVertex
        {
            get { return _optionSyncVertex; }
            set { _optionSyncVertex = value; }
        }
        public string OptionTextureGroup0Border
        {
            get { return _optionTextureGroup0Border; }
            set { _optionTextureGroup0Border = value; }
        }
        public string OptionTextureGroup0Nocropping
        {
            get { return _optionTextureGroup0Nocropping; }
            set { _optionTextureGroup0Nocropping = value; }
        }
        public string OptionTextureGroup0Parent
        {
            get { return _optionTextureGroup0Parent; }
            set { _optionTextureGroup0Parent = value; }
        }
        public string OptionTextureGroup0Scaled
        {
            get { return _optionTextureGroup0Scaled; }
            set { _optionTextureGroup0Scaled = value; }
        }
        public string OptionTextureGroup0Targets
        {
            get { return _optionTextureGroup0Targets; }
            set { _optionTextureGroup0Targets = value; }
        }
        public string OptionTextureGroupCount
        {
            get { return _optionTextureGroupCount; }
            set { _optionTextureGroupCount = value; }
        }
        public string OptionTextureGroups0
        {
            get { return _optionTextureGroups0; }
            set { _optionTextureGroups0 = value; }
        }
        public string OptionTizenAppId
        {
            get { return _optionTizenAppId; }
            set { _optionTizenAppId = value; }
        }
        public string OptionTizenBuildVersion
        {
            get { return _optionTizenBuildVersion; }
            set { _optionTizenBuildVersion = value; }
        }
        public string OptionTizenDisplayName
        {
            get { return _optionTizenDisplayName; }
            set { _optionTizenDisplayName = value; }
        }
        public string OptionTizenFlurryEnable
        {
            get { return _optionTizenFlurryEnable; }
            set { _optionTizenFlurryEnable = value; }
        }
        public string OptionTizenFlurryId
        {
            get { return _optionTizenFlurryId; }
            set { _optionTizenFlurryId = value; }
        }
        public string OptionTizenGoogleAnalyticsEnable
        {
            get { return _optionTizenGoogleAnalyticsEnable; }
            set { _optionTizenGoogleAnalyticsEnable = value; }
        }
        public string OptionTizenGoogleTrackingId
        {
            get { return _optionTizenGoogleTrackingId; }
            set { _optionTizenGoogleTrackingId = value; }
        }
        public string OptionTizenIapGroupID
        {
            get { return _optionTizenIapGroupID; }
            set { _optionTizenIapGroupID = value; }
        }
        public string OptionTizenIcon
        {
            get { return _optionTizenIcon; }
            set { _optionTizenIcon = value; }
        }
        public string OptionTizenInterpolate
        {
            get { return _optionTizenInterpolate; }
            set { _optionTizenInterpolate = value; }
        }
        public string OptionTizenMajorVersion
        {
            get { return _optionTizenMajorVersion; }
            set { _optionTizenMajorVersion = value; }
        }
        public string OptionTizenMinorVersion
        {
            get { return _optionTizenMinorVersion; }
            set { _optionTizenMinorVersion = value; }
        }
        public string OptionTizenNetworkUrls
        {
            get { return _optionTizenNetworkUrls; }
            set { _optionTizenNetworkUrls = value; }
        }
        public string OptionTizenOrientation
        {
            get { return _optionTizenOrientation; }
            set { _optionTizenOrientation = value; }
        }
        public string OptionTizenPushEnable
        {
            get { return _optionTizenPushEnable; }
            set { _optionTizenPushEnable = value; }
        }
        public string OptionTizenScaling
        {
            get { return _optionTizenScaling; }
            set { _optionTizenScaling = value; }
        }
        public string OptionTizenSplashPng
        {
            get { return _optionTizenSplashPng; }
            set { _optionTizenSplashPng = value; }
        }
        public string OptionTizenTexturePage
        {
            get { return _optionTizenTexturePage; }
            set { _optionTizenTexturePage = value; }
        }
        public string OptionTizenUsesplash
        {
            get { return _optionTizenUsesplash; }
            set { _optionTizenUsesplash = value; }
        }
        public string OptionUseNewAudio
        {
            get { return _optionUseNewAudio; }
            set { _optionUseNewAudio = value; }
        }
        public string OptionVariableerrors
        {
            get { return _optionVariableErrors; }
            set { _optionVariableErrors = value; }
        }
        public string OptionVersion
        {
            get { return _optionVersion; }
            set { _optionVersion = value; }
        }
        public string OptionVersionBuild
        {
            get { return _optionVersionBuild; }
            set { _optionVersionBuild = value; }
        }
        public string OptionVersionCompany
        {
            get { return _optionVersionCompany; }
            set { _optionVersionCompany = value; }
        }
        public string OptionVersionCopyright
        {
            get { return _optionVersionCopyright; }
            set { _optionVersionCopyright = value; }
        }
        public string OptionVersionDescription
        {
            get { return _optionVersionDescription; }
            set { _optionVersionDescription = value; }
        }
        public string OptionVersionMajor
        {
            get { return _optionVersionMajor; }
            set { _optionVersionMajor = value; }
        }
        public string OptionVersionMinor
        {
            get { return _optionVersionMinor; }
            set { _optionVersionMinor = value; }
        }
        public string OptionVersionProduct
        {
            get { return _optionVersionProduct; }
            set { _optionVersionProduct = value; }
        }
        public string OptionVersionRelease
        {
            get { return _optionVersionRelease; }
            set { _optionVersionRelease = value; }
        }
        public string OptionWin8AdvertisingAppid
        {
            get { return _optionWin8AdvertisingAppid; }
            set { _optionWin8AdvertisingAppid = value; }
        }
        public string OptionWin8AdvertisingEnable
        {
            get { return _optionWin8AdvertisingEnable; }
            set { _optionWin8AdvertisingEnable = value; }
        }
        public string OptionWin8AdvertisingKey
        {
            get { return _optionWin8AdvertisingKey; }
            set { _optionWin8AdvertisingKey = value; }
        }
        public string OptionWin8AdvertisingTestingEnable
        {
            get { return _optionWin8AdvertisingTestingEnable; }
            set { _optionWin8AdvertisingTestingEnable = value; }
        }
        public string OptionWin8AdvertisingType
        {
            get { return _optionWin8AdvertisingType; }
            set { _optionWin8AdvertisingType = value; }
        }
        public string OptionWin8AnalyticsEnable
        {
            get { return _optionWin8AnalyticsEnable; }
            set { _optionWin8AnalyticsEnable = value; }
        }
        public string OptionWin8AnalyticsId
        {
            get { return _optionWin8AnalyticsId; }
            set { _optionWin8AnalyticsId = value; }
        }
        public string OptionWin8BuildVersion
        {
            get { return _optionWin8BuildVersion; }
            set { _optionWin8BuildVersion = value; }
        }
        public string OptionWin8CertificateLocation
        {
            get { return _optionWin8CertificateLocation; }
            set { _optionWin8CertificateLocation = value; }
        }
        public string OptionWin8DisplayName
        {
            get { return _optionWin8DisplayName; }
            set { _optionWin8DisplayName = value; }
        }
        public string OptionWin8InternetCapable
        {
            get { return _optionWin8InternetCapable; }
            set { _optionWin8InternetCapable = value; }
        }
        public string OptionWin8Interpolate
        {
            get { return _optionWin8Interpolate; }
            set { _optionWin8Interpolate = value; }
        }
        public string OptionWin8LandscapeAllowed
        {
            get { return _optionWin8LandscapeAllowed; }
            set { _optionWin8LandscapeAllowed = value; }
        }
        public string OptionWin8LandscapeFlippedAllowed
        {
            get { return _optionWin8LandscapeFlippedAllowed; }
            set { _optionWin8LandscapeFlippedAllowed = value; }
        }
        public string OptionWin8Logo
        {
            get { return _optionWin8Logo; }
            set { _optionWin8Logo = value; }
        }
        public string OptionWin8LogoBackgroundColour
        {
            get { return _optionWin8LogoBackgroundColour; }
            set { _optionWin8LogoBackgroundColour = value; }
        }
        public string OptionWin8LogoForegroundText
        {
            get { return _optionWin8LogoForegroundText; }
            set { _optionWin8LogoForegroundText = value; }
        }
        public string OptionWin8MajorVersion
        {
            get { return _optionWin8MajorVersion; }
            set { _optionWin8MajorVersion = value; }
        }
        public string OptionWin8MinorVersion
        {
            get { return _optionWin8MinorVersion; }
            set { _optionWin8MinorVersion = value; }
        }
        public string OptionWin8NativeCertificateLocation
        {
            get { return _optionWin8NativeCertificateLocation; }
            set { _optionWin8NativeCertificateLocation = value; }
        }
        public string OptionWin8NativeCpu
        {
            get { return _optionWin8NativeCpu; }
            set { _optionWin8NativeCpu = value; }
        }
        public string OptionWin8PackageDisplayName
        {
            get { return _optionWin8PackageDisplayName; }
            set { _optionWin8PackageDisplayName = value; }
        }
        public string OptionWin8PackageName
        {
            get { return _optionWin8PackageName; }
            set { _optionWin8PackageName = value; }
        }
        public string OptionWin8PortraitAllowed
        {
            get { return _optionWin8PortraitAllowed; }
            set { _optionWin8PortraitAllowed = value; }
        }
        public string OptionWin8PortraitFlippedAllowed
        {
            get { return _optionWin8PortraitFlippedAllowed; }
            set { _optionWin8PortraitFlippedAllowed = value; }
        }
        public string OptionWin8PublisherDisplayName
        {
            get { return _optionWin8PublisherDisplayName; }
            set { _optionWin8PublisherDisplayName = value; }
        }
        public string OptionWin8RevisionVersion
        {
            get { return _optionWin8RevisionVersion; }
            set { _optionWin8RevisionVersion = value; }
        }
        public string OptionWin8ScalingStretch
        {
            get { return _optionWin8ScalingStretch; }
            set { _optionWin8ScalingStretch = value; }
        }
        public string OptionWin8SearchCapable
        {
            get { return _optionWin8SearchCapable; }
            set { _optionWin8SearchCapable = value; }
        }
        public string OptionWin8SmallLogo
        {
            get { return _optionWin8SmallLogo; }
            set { _optionWin8SmallLogo = value; }
        }
        public string OptionWin8SplashBackgroundColour
        {
            get { return _optionWin8SplashBackgroundColour; }
            set { _optionWin8SplashBackgroundColour = value; }
        }
        public string OptionWin8SplashPng
        {
            get { return _optionWin8SplashPng; }
            set { _optionWin8SplashPng = value; }
        }
        public string OptionWin8StoreLogo
        {
            get { return _optionWin8StoreLogo; }
            set { _optionWin8StoreLogo = value; }
        }
        public string OptionWin8TexturePage
        {
            get { return _optionWin8TexturePage; }
            set { _optionWin8TexturePage = value; }
        }
        public string OptionWin8WideLogo
        {
            get { return _optionWin8WideLogo; }
            set { _optionWin8WideLogo = value; }
        }
        public string OptionWindowcolor
        {
            get { return _optionWindowcolor; }
            set { _optionWindowcolor = value; }
        }
        public string OptionWindowsBuildVersion
        {
            get { return _optionWindowsBuildVersion; }
            set { _optionWindowsBuildVersion = value; }
        }
        public string OptionWindowsCompanyInfo
        {
            get { return _optionWindowsCompanyInfo; }
            set { _optionWindowsCompanyInfo = value; }
        }
        public string OptionWindowsCopyrightInfo
        {
            get { return _optionWindowsCopyrightInfo; }
            set { _optionWindowsCopyrightInfo = value; }
        }
        public string OptionWindowsDescriptionInfo
        {
            get { return _optionWindowsDescriptionInfo; }
            set { _optionWindowsDescriptionInfo = value; }
        }
        public string OptionWindowsEnableSteam
        {
            get { return _optionWindowsEnableSteam; }
            set { _optionWindowsEnableSteam = value; }
        }
        public string OptionWindowsGameIcon
        {
            get { return _optionWindowsGameIcon; }
            set { _optionWindowsGameIcon = value; }
        }
        public string OptionWindowsLicense
        {
            get { return _optionWindowsLicense; }
            set { _optionWindowsLicense = value; }
        }
        public string OptionWindowsMainorVersion
        {
            get { return _optionWindowsMinorVersion; }
            set { _optionWindowsMinorVersion = value; }
        }
        public string OptionWindowsMajorVersion
        {
            get { return _optionWindowsMajorVersion; }
            set { _optionWindowsMajorVersion = value; }
        }
        public string OptionWindowsNsisFile
        {
            get { return _optionWindowsNsisFile; }
            set { _optionWindowsNsisFile = value; }
        }
        public string OptionWindowsProductInfo
        {
            get { return _optionWindowsProductInfo; }
            set { _optionWindowsProductInfo = value; }
        }
        public string OptionWindowsReleaseVersion
        {
            get { return _optionWindowsReleaseVersion; }
            set { _optionWindowsReleaseVersion = value; }
        }
        public string OptionWindowsRunnerFinished
        {
            get { return _optionWindowsRunnerFinished; }
            set { _optionWindowsRunnerFinished = value; }
        }
        public string OptionWindowsRunnerHeader
        {
            get { return _optionWindowsRunnerHeader; }
            set { _optionWindowsRunnerHeader = value; }
        }
        public string OptionWindowsSaveLocation
        {
            get { return _optionWindowsSaveLocation; }
            set { _optionWindowsSaveLocation = value; }
        }
        public string OptionWindowsSplashScreen
        {
            get { return _optionWindowsSplashScreen; }
            set { _optionWindowsSplashScreen = value; }
        }
        public string OptionWindowsSteaAppId
        {
            get { return _optionWindowsSteaAppId; }
            set { _optionWindowsSteaAppId = value; }
        }
        public string OptionWindowsTexturePage
        {
            get { return _optionWindowsTexturePage; }
            set { _optionWindowsTexturePage = value; }
        }
        public string OptionWinphone480SplashImage
        {
            get { return _optionWinphone480SplashImage; }
            set { _optionWinphone480SplashImage = value; }
        }
        public string OptionWinphone720SplashImage
        {
            get { return _optionWinphone720SplashImage; }
            set { _optionWinphone720SplashImage = value; }
        }
        public string OptionWinphone768SplashImage
        {
            get { return _optionWinphone768SplashImage; }
            set { _optionWinphone768SplashImage = value; }
        }
        public string OptionWinphoneAdvertisingAppid
        {
            get { return _optionWinphoneAdvertisingAppid; }
            set { _optionWinphoneAdvertisingAppid = value; }
        }
        public string OptionWinphoneAdvertisingEnable
        {
            get { return _optionWinphoneAdvertisingEnable; }
            set { _optionWinphoneAdvertisingEnable = value; }
        }
        public string OptionWinphoneAdvertisingKey
        {
            get { return _optionWinphoneAdvertisingKey; }
            set { _optionWinphoneAdvertisingKey = value; }
        }
        public string OptionWinphoneAdvertisingTestingEnable
        {
            get { return _optionWinphoneAdvertisingTestingEnable; }
            set { _optionWinphoneAdvertisingTestingEnable = value; }
        }
        public string OptionWinphoneAdvertisingType
        {
            get { return _optionWinphoneAdvertisingType; }
            set { _optionWinphoneAdvertisingType = value; }
        }
        public string OptionWinphoneAuthor
        {
            get { return _optionWinphoneAuthor; }
            set { _optionWinphoneAuthor = value; }
        }
        public string OptionWinphoneBuildVersion
        {
            get { return _optionWinphoneBuildVersion; }
            set { _optionWinphoneBuildVersion = value; }
        }
        public string OptionWinphoneCycleSmallImage
        {
            get { return _optionWinphoneCycleSmallImage; }
            set { _optionWinphoneCycleSmallImage = value; }
        }
        public string OptionWinphoneCycleWideImage1
        {
            get { return _optionWinphoneCycleWideImage1; }
            set { _optionWinphoneCycleWideImage1 = value; }
        }
        public string OptionWinphoneCycleWideImage2
        {
            get { return _optionWinphoneCycleWideImage2; }
            set { _optionWinphoneCycleWideImage2 = value; }
        }
        public string OptionWinphoneCycleWideImage3
        {
            get { return _optionWinphoneCycleWideImage3; }
            set { _optionWinphoneCycleWideImage3 = value; }
        }
        public string OptionWinphoneCycleWideImage4
        {
            get { return _optionWinphoneCycleWideImage4; }
            set { _optionWinphoneCycleWideImage4 = value; }
        }
        public string OptionWinphoneCycleWideImage5
        {
            get { return _optionWinphoneCycleWideImage5; }
            set { _optionWinphoneCycleWideImage5 = value; }
        }
        public string OptionWinphoneCycleWideImage6
        {
            get { return _optionWinphoneCycleWideImage6; }
            set { _optionWinphoneCycleWideImage6 = value; }
        }
        public string OptionWinphoneCycleWideImage7
        {
            get { return _optionWinphoneCycleWideImage7; }
            set { _optionWinphoneCycleWideImage7 = value; }
        }
        public string OptionWinphoneCycleWideImage8
        {
            get { return _optionWinphoneCycleWideImage8; }
            set { _optionWinphoneCycleWideImage8 = value; }
        }
        public string OptionWinphoneCycleWideImage9
        {
            get { return _optionWinphoneCycleWideImage9; }
            set { _optionWinphoneCycleWideImage9 = value; }
        }
        public string OptionWinphoneDescription
        {
            get { return _optionWinphoneDescription; }
            set { _optionWinphoneDescription = value; }
        }
        public string OptionWinphoneDisplayName
        {
            get { return _optionWinphoneDisplayName; }
            set { _optionWinphoneDisplayName = value; }
        }
        public string OptionWinphoneFlipContentBack
        {
            get { return _optionWinphoneFlipContentBack; }
            set { _optionWinphoneFlipContentBack = value; }
        }
        public string OptionWinphoneFlipContentFront
        {
            get { return _optionWinphoneFlipContentFront; }
            set { _optionWinphoneFlipContentFront = value; }
        }
        public string OptionWinphoneFlipMediuBackImage
        {
            get { return _optionWinphoneFlipMediuBackImage; }
            set { _optionWinphoneFlipMediuBackImage = value; }
        }
        public string OptionWinphoneFlipMediuFrontImage
        {
            get { return _optionWinphoneFlipMediuFrontImage; }
            set { _optionWinphoneFlipMediuFrontImage = value; }
        }
        public string OptionWinphoneFlipSmallBackImage
        {
            get { return _optionWinphoneFlipSmallBackImage; }
            set { _optionWinphoneFlipSmallBackImage = value; }
        }
        public string OptionWinphoneFlipSmallFrontImage
        {
            get { return _optionWinphoneFlipSmallFrontImage; }
            set { _optionWinphoneFlipSmallFrontImage = value; }
        }
        public string OptionWinphoneFlipWideBackImage
        {
            get { return _optionWinphoneFlipWideBackImage; }
            set { _optionWinphoneFlipWideBackImage = value; }
        }
        public string OptionWinphoneFlipWideFrontImage
        {
            get { return _optionWinphoneFlipWideFrontImage; }
            set { _optionWinphoneFlipWideFrontImage = value; }
        }
        public string OptionWinphoneFlurryEnable
        {
            get { return _optionWinphoneFlurryEnable; }
            set { _optionWinphoneFlurryEnable = value; }
        }
        public string OptionWinphoneFlurryId
        {
            get { return _optionWinphoneFlurryId; }
            set { _optionWinphoneFlurryId = value; }
        }
        public string OptionWinphoneGenre
        {
            get { return _optionWinphoneGenre; }
            set { _optionWinphoneGenre = value; }
        }
        public string OptionWinphoneGoogleAnalyticsEnable
        {
            get { return _optionWinphoneGoogleAnalyticsEnable; }
            set { _optionWinphoneGoogleAnalyticsEnable = value; }
        }
        public string OptionWinphoneGoogleTrackingId
        {
            get { return _optionWinphoneGoogleTrackingId; }
            set { _optionWinphoneGoogleTrackingId = value; }
        }
        public string OptionWinphoneIconImage
        {
            get { return _optionWinphoneIconImage; }
            set { _optionWinphoneIconImage = value; }
        }
        public string OptionWinphoneIconicBackgroundColour
        {
            get { return _optionWinphoneIconicBackgroundColour; }
            set { _optionWinphoneIconicBackgroundColour = value; }
        }
        public string OptionWinphoneIconicMessage
        {
            get { return _optionWinphoneIconicMessage; }
            set { _optionWinphoneIconicMessage = value; }
        }
        public string OptionWinphoneIconicSmallImage
        {
            get { return _optionWinphoneIconicSmallImage; }
            set { _optionWinphoneIconicSmallImage = value; }
        }
        public string OptionWinphoneIconicWideContent1
        {
            get { return _optionWinphoneIconicWideContent1; }
            set { _optionWinphoneIconicWideContent1 = value; }
        }
        public string OptionWinphoneIconicWideContent2
        {
            get { return _optionWinphoneIconicWideContent2; }
            set { _optionWinphoneIconicWideContent2 = value; }
        }
        public string OptionWinphoneIconicWideContent3
        {
            get { return _optionWinphoneIconicWideContent3; }
            set { _optionWinphoneIconicWideContent3 = value; }
        }
        public string OptionWinphoneIconicWideImage
        {
            get { return _optionWinphoneIconicWideImage; }
            set { _optionWinphoneIconicWideImage = value; }
        }
        public string OptionWinphoneInterpolate
        {
            get { return _optionWinphoneInterpolate; }
            set { _optionWinphoneInterpolate = value; }
        }
        public string OptionWinphoneLandscapeAllowed
        {
            get { return _optionWinphoneLandscapeAllowed; }
            set { _optionWinphoneLandscapeAllowed = value; }
        }
        public string OptionWinphoneLandscapeFlippedAllowed
        {
            get { return _optionWinphoneLandscapeFlippedAllowed; }
            set { _optionWinphoneLandscapeFlippedAllowed = value; }
        }
        public string OptionWinphoneMajorVersion
        {
            get { return _optionWinphoneMajorVersion; }
            set { _optionWinphoneMajorVersion = value; }
        }
        public string OptionWinphoneMinorVersion
        {
            get { return _optionWinphoneMinorVersion; }
            set { _optionWinphoneMinorVersion = value; }
        }
        public string OptionWinphonePortraitAllowed
        {
            get { return _optionWinphonePortraitAllowed; }
            set { _optionWinphonePortraitAllowed = value; }
        }
        public string OptionWinphonePublisher
        {
            get { return _optionWinphonePublisher; }
            set { _optionWinphonePublisher = value; }
        }
        public string OptionWinphonePublisherId
        {
            get { return _optionWinphonePublisherId; }
            set { _optionWinphonePublisherId = value; }
        }
        public string OptionWinphoneRevisionVersion
        {
            get { return _optionWinphoneRevisionVersion; }
            set { _optionWinphoneRevisionVersion = value; }
        }
        public string OptionWinphoneScale
        {
            get { return _optionWinphoneScale; }
            set { _optionWinphoneScale = value; }
        }
        public string OptionWinphoneSupports720p
        {
            get { return _optionWinphoneSupports720p; }
            set { _optionWinphoneSupports720p = value; }
        }
        public string OptionWinphoneSupportsWvga
        {
            get { return _optionWinphoneSupportsWvga; }
            set { _optionWinphoneSupportsWvga = value; }
        }
        public string OptionWinphoneSupportsWxga
        {
            get { return _optionWinphoneSupportsWxga; }
            set { _optionWinphoneSupportsWxga = value; }
        }
        public string OptionWinphoneTexturePage
        {
            get { return _optionWinphoneTexturePage; }
            set { _optionWinphoneTexturePage = value; }
        }
        public string OptionWinphoneTileType
        {
            get { return _optionWinphoneTileType; }
            set { _optionWinphoneTileType = value; }
        }
        public string OptionWriteerrors
        {
            get { return _optionWriteErrors; }
            set { _optionWriteErrors = value; }
        }
        public string OptionXboneBackgroundColour
        {
            get { return _optionXboneBackgroundColour; }
            set { _optionXboneBackgroundColour = value; }
        }
        public string OptionXboneBuildVersion
        {
            get { return _optionXboneBuildVersion; }
            set { _optionXboneBuildVersion = value; }
        }
        public string OptionXboneDescription
        {
            get { return _optionXboneDescription; }
            set { _optionXboneDescription = value; }
        }
        public string OptionXboneDisplayName
        {
            get { return _optionXboneDisplayName; }
            set { _optionXboneDisplayName = value; }
        }
        public string OptionXboneForegroundText
        {
            get { return _optionXboneForegroundText; }
            set { _optionXboneForegroundText = value; }
        }
        public string OptionXboneInterpolation
        {
            get { return _optionXboneInterpolation; }
            set { _optionXboneInterpolation = value; }
        }
        public string OptionXboneMajorVersion
        {
            get { return _optionXboneMajorVersion; }
            set { _optionXboneMajorVersion = value; }
        }
        public string OptionXboneMinorVersion
        {
            get { return _optionXboneMinorVersion; }
            set { _optionXboneMinorVersion = value; }
        }
        public string OptionXbonePublisher
        {
            get { return _optionXbonePublisher; }
            set { _optionXbonePublisher = value; }
        }
        public string OptionXbonePublisherDisplayName
        {
            get { return _optionXbonePublisherDisplayName; }
            set { _optionXbonePublisherDisplayName = value; }
        }
        public string OptionXboneRevisionVersion
        {
            get { return _optionXboneRevisionVersion; }
            set { _optionXboneRevisionVersion = value; }
        }
        public string OptionXboneScale
        {
            get { return _optionXboneScale; }
            set { _optionXboneScale = value; }
        }
        public string OptionXboneSplashScreenColour
        {
            get { return _optionXboneSplashScreenColour; }
            set { _optionXboneSplashScreenColour = value; }
        }
        public string OptionXboneTexturePage
        {
            get { return _optionXboneTexturePage; }
            set { _optionXboneTexturePage = value; }
        }

        #endregion
    }
}