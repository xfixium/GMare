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

        public int GetSize()
        {
            int size = 126 + _company.Length + _product.Length + _copyright.Length + _description.Length + _author.Length + _version.Length + _information.Length;

            if (_constants != null)
                foreach (GMConstant constant in _constants)
                    size += constant.GetSize();

            if (_includes != null)
                foreach (GMInclude include in _includes)
                    size += include.GetSize();

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

        #endregion
    }

    public class GMConstant
    {
        #region Fields

        private static double _lastChanged = 0;
        private string _name = "";
        private string _value = "";

        #endregion

        #region Properties

        public static double LastChanged
        {
            get { return _lastChanged; }
            set { _lastChanged = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        #endregion

        #region Methods

        public int GetSize()
        {
            return 8 + _name.Length + _value.Length;
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

        public int GetSize()
        {
            int size = 30 + _fileName.Length + _filePath.Length;

            if (_data != null)
                size += _data.Length;

            return size;
        }

        #endregion
    }
}