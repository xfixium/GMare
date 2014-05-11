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
using System.Reflection;
using System.Collections.Generic;

namespace GameMaker.Common
{
        /// <summary>
    /// A string attribute used by enumerations to provide human readable values
    /// </summary>
    public class EnumString : Attribute
    {
        private string _value;  // A string that is associated with an enumeration

        /// <summary>
        /// Constructs a new string value attribute
        /// </summary>
        /// <param name="value">The string value</param>
        public EnumString(string value) : base()
        {
            _value = value;
        }

        /// <summary>
        /// Gets the string value of the enumeration
        /// </summary>
        public string Value
        {
            get { return _value; }
        }

        /// <summary>
        /// Get string of the enumeration
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumString(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            object[] attributes = fi.GetCustomAttributes(typeof(EnumString), false);

            if (attributes.Length > 0)
                return ((EnumString)attributes[0]).Value;
            else
                return value.ToString();
        }

        /// <summary>
        /// Gets an enumeration value from a string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stringValue"></param>
        /// <returns></returns>
        public static T? GetEnumFromString<T>(string stringValue)
            where T : struct
        {
            foreach (object e in Enum.GetValues(typeof(T)))
                if (GetEnumString((Enum)e).Equals(stringValue))
                    return (T)e;
            return null;
        }

        /// <summary>
        /// // Get a list of string values from the enumeration
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetEnumStrings(Type enumType)
        {
            List<string> strings = new List<string>();

            foreach (Enum e in Enum.GetValues(enumType))
                strings.Add(GetEnumString(e));
            
            return strings;
        }
    }

    /// <summary>
    /// Describes the different types of application priority
    /// </summary>
    public enum PriorityType : int
    {
        Normal = 0,
        High = 1,
        Highest = 2
    };

    /// <summary>
    /// Describes the different types of actions
    /// </summary>
    public enum ActionType : int
    {
        Normal = 0,
        Begin = 1,
        End = 2,
        Else = 3,
        Exit = 4,
        Repeat = 5,
        Variable = 6,
        Code = 7,
        PlaceHolder = 8,
        Seperator = 9,
        Label = 10
    };

    /// <summary>
    /// Describes the action type associated with a path object
    /// </summary>
    public enum ActionAtTheEnd : int
    {
        StopMoving = 0,
        JumpToStart = 1,
        MoveToStart = 2,
        Reverse = 3,
        Continue = 4
    };

    /// <summary>
    /// Describes the execution type of action
    /// </summary>
    public enum ExecutionType : int
    {
        None = 0,
        Function = 1,
        Code = 2
    };

    /// <summary>
    /// Describes the types of arguments
    /// </summary>
    public enum ArgumentType : int
    {
        Expression = 0,
        String = 1,
        Both = 2,
        Boolean = 3,
        Menu = 4,
        Sprite = 5,
        Sound = 6,
        Background = 7,
        Path = 8,
        Script = 9,
        Object = 10,
        Room = 11,
        Font = 12,
        Color = 13,
        Timeline = 14,
        FontString = 15
    };

    /// <summary>
    /// Describes the sub event types of main event types
    /// </summary>
    public enum SubEventType
    {
        Step,
        Mouse,
        Keyboard,
        Other
    };

    /// <summary>
    /// Describes the main event types
    /// </summary>
    public enum EventType : int
    {
        None = -1,
        Create = 0,
        Destroy = 1,
        Alarm = 2,
        Step = 3,
        Collision = 4,
        Keyboard = 5,
        Mouse = 6,
        Other = 7,
        Draw = 8,
        KeyPress = 9,
        KeyRelease = 10,
        Trigger = 11
    };

    /// <summary>
    /// Descibes the different mouse and joypad input types
    /// </summary>
    public enum MouseEventType : int
    {
        LeftButton = 0,
        RightButton = 1,
        MiddleButton = 2,
        NoButton = 3,
        LeftPress = 4,
        RightPress = 5,
        MiddlePress = 6,
        LeftRelease = 7,
        RightRelease = 8,
        MiddleRelease = 9,
        MouseEnter = 10,
        MouseLeave = 11,
        Joystick1Left = 16,
        Joystick1Right = 17,
        Joystick1Up = 18,
        Joystick1Down = 19,
        Joystick1Button1 = 21,
        Joystick1Button2 = 22,
        Joystick1Button3 = 23,
        Joystick1Button4 = 24,
        Joystick1Button5 = 25,
        Joystick1Button6 = 26,
        Joystick1Button7 = 27,
        Joystick1Button8 = 28,
        Joystick2Left = 31,
        Joystick2Right = 32,
        Joystick2Up = 33,
        Joystick2Down = 34,
        Joystick2Button1 = 36,
        Joystick2Button2 = 37,
        Joystick2Button3 = 38,
        Joystick2Button4 = 39,
        Joystick2Button5 = 40,
        Joystick2Button6 = 41,
        Joystick2Button7 = 42,
        Joystick2Button8 = 43,
        GlobalLeftButton = 50,
        GlobalRightButton = 51,
        GlobalMiddleButton = 52,
        GlobalLeftPress = 53,
        GlobalRightPress = 54,
        GlobalMiddlePress = 55,
        GlobalLeftRelease = 56,
        GlobalRightRelease = 57,
        GlobalMiddleRelease = 58,
        MouseWheelUp = 60,
        MouseWheelDown = 61,
    };

    /// <summary>
    /// Describes the other event types
    /// </summary>
    public enum OtherEventType : int
    {
        OutsideRoom = 0,
        IntersectBoundary = 1,
        GameStart = 2,
        GameEnd = 3,
        RoomStart = 4,
        RoomEnd = 5,
        NoMoreLives = 6,
        AnimationEnd = 7,
        EndOfPath = 8,
        NoMoreHealth = 9,
        User0 = 10,
        User1 = 11,
        User2 = 12,
        User3 = 13,
        User4 = 14,
        User5 = 15,
        User6 = 16,
        User7 = 17,
        User8 = 18,
        User9 = 19,
        User10 = 20,
        User11 = 21,
        User12 = 22,
        User13 = 23,
        User14 = 24,
        User15 = 25,
        CloseButton = 30,
        OutsideView0 = 40,
        OutsideView1 = 41,
        OutsideView2 = 42,
        OutsideView3 = 43,
        OutsideView4 = 44,
        OutsideView5 = 45,
        OutsideView6 = 46,
        OutsideView7 = 47,
        BoundaryView0 = 50,
        BoundaryView1 = 51,
        BoundaryView2 = 52,
        BoundaryView3 = 53,
        BoundaryView4 = 54,
        BoundaryView5 = 55,
        BoundaryView6 = 56,
        BoundaryView7 = 57
    };

    /// <summary>
    /// Describes the different keyboard key types
    /// </summary>
    public enum KeyboardEventType : int
    {
        KeyBackspace = 8,
        KeyEnter = 13,
        KeyShift = 16,
        KeyControl = 17,
        KeyAlt = 18,
        KeyEscape = 27,
        KeySpace = 32,
        KeyPageUp = 33,
        KeyPageDown = 34,
        KeyEnd = 35,
        KeyHome = 36,
        KeyLeft = 37,
        KeyUp = 38,
        KeyRight = 39,
        KeyDown = 40,
        KeyInsert = 45,
        KeyDelete = 46,
        Key0 = 48,
        Key1 = 49,
        Key2 = 50,
        Key3 = 51,
        Key4 = 52,
        Key5 = 53,
        Key6 = 54,
        Key7 = 55,
        Key8 = 56,
        Key9 = 57,
        KeyA = 65,
        KeyB = 66,
        KeyC = 67,
        KeyD = 68,
        KeyE = 69,
        KeyF = 70,
        KeyG = 71,
        KeyH = 72,
        KeyI = 73,
        KeyJ = 74,
        KeyK = 75,
        KeyL = 76,
        KeyM = 77,
        KeyN = 78,
        KeyO = 79,
        KeyP = 80,
        KeyQ = 81,
        KeyR = 82,
        KeyS = 83,
        KeyT = 84,
        KeyU = 85,
        KeyV = 86,
        KeyW = 87,
        KeyX = 88,
        KeyY = 89,
        KeyZ = 90,
        KeyNumpad0 = 96,
        KeyNumpad1 = 97,
        KeyNumpad2 = 98,
        KeyNumpad3 = 99,
        KeyNumpad4 = 100,
        KeyNumpad5 = 101,
        KeyNumpad6 = 102,
        KeyNumpad7 = 103,
        KeyNumpad8 = 104,
        KeyNumpad9 = 105,
        KeyMultiply = 106,
        KeyAdd = 107,
        KeySubtract = 109,
        KeyDecimal = 110,
        KeyDivide = 111,
        KeyF1 = 112,
        KeyF2 = 113,
        KeyF3 = 114,
        KeyF4 = 115,
        KeyF5 = 116,
        KeyF6 = 117,
        KeyF7 = 118,
        KeyF8 = 119,
        KeyF9 = 120,
        KeyF10 = 121,
        KeyF11 = 122,
        KeyF12 = 123
    };

    /// <summary>
    /// Describes the different step event types
    /// </summary>
    public enum StepEventType : int
    {
        StepNormal = 0,
        StepBegin = 1,
        StepEnd = 2
    };

    /// <summary>
    /// Descibes the different node types
    /// </summary>
    public enum GMNodeType : int
    {
        Parent = 1,
        Group = 2,
        Child = 3
    };

    /// <summary>
    /// Describes any resource type within a project
    /// </summary>
    public enum GMResourceType : int
    {
        Objects = 1,
        Sprites = 2,
        Sounds = 3,
        Rooms = 4,
        Backgrounds = 6,
        Scripts = 7,
        Paths = 8,
        DataFonts = 9,
        GameInformation = 10,
        Settings = 11,
        TimeLines = 12,
        Extensions = 13,
        Shaders = 14,
        Assets = 15,
        None = -1
    };

    /// <summary>
    /// Describes the main base game object types
    /// </summary>
    public enum GMBaseResourceType
    {
        Object,
        Sprite,
        Sound,
        Room,
        Background,
        Script,
        Path,
        Font,
        DataFile,
        Timeline
    };

    /// <summary>
    /// Describes the type of progress bar loading method
    /// </summary>
    public enum LoadProgressBarType : int
    {
        None = 0,
        Default = 1,
        Custom = 2
    };

    /// <summary>
    /// Describes the selected tab in a room
    /// </summary>
    public enum TabSetting : int
    {
        Objects = 0,
        Settings = 1,
        Tiles = 2,
        Backgrounds = 3,
        Views = 4
    };

    /// <summary>
    /// Describes the types of audio play back
    /// </summary>
    public enum SoundType : int
    {
        Normal = 0,
        Background = 1,
        ThreeDimesional = 2,
        Multimedia = 3
    };

    /// <summary>
    /// Descibes the type of sound file
    /// </summary>
    public enum SoundKind : int
    {
        None = -1,
        Wave = 0,
        Midi = 1,
        Mp3 = 2,
        Unknown = 10

    };

    /// <summary>
    /// Describes the bounding calculation types for sprites
    /// </summary>
    public enum BoundingBoxType : int
    {
        Auto = 0,
        Full = 1,
        Manual = 2
    };

    /// <summary>
    /// Describes the types of include file export methods
    /// </summary>
    public enum ExportType : int
    {
        DontExport = 0,
        TempFolder = 1,
        WorkingFolder = 2,
        InstallAsFont = 3
    };

    /// <summary>
    /// Describes the supported version types of a Game Maker project
    /// </summary>
    public enum GMVersionType : int
    {
        GameMaker50 = 500,
        GameMaker51 = 510,
        GameMaker52 = 520,
        GameMaker53 = 530,
        GameMaker60 = 600,
        GameMaker70 = 701,
        GameMaker80 = 800,
        GameMaker81 = 810,
        GameMakerStudio = 900
    };

    /// <summary>
    /// Describes color depth types for older versions of Game Maker
    /// </summary>
    public enum ColorDepthType1 : int
    {
        Color16Bit = 0,
        Color32Bit = 1
    };

    /// <summary>
    /// Describes color depth types for newer versions of Game Maker
    /// </summary>
    public enum ColorDepthType2 : int
    {
        None = 0,
        Color16Bit = 1,
        Color32Bit = 2
    };

    /// <summary>
    /// Describes screen resolution types for older versions of Game Maker
    /// </summary>
    public enum ResolutionType1 : int
    {
        Resolution640x480 = 0,
        Resolution800x600 = 1,
        Resolution1024x768 = 2,
        Resolution1280x1024 = 3,
        Resolution1600x1200 = 4,
        Resolution320x240 = 5,
        NoChange = 6,
    };

    /// <summary>
    /// Describes screen resolution types for newer versions of Game Maker
    /// </summary>
    public enum ResolutionType2 : int
    {
        NoChange = 0,
        Resolution320x240 = 1,
        Resolution640x480 = 2,
        Resolution800x600 = 3,
        Resolution1024x768 = 4,
        Resolution1280x1024 = 5,
        Resolution1600x1200 = 6
    };

    /// <summary>
    /// Describes screen refresh rate types for older versions of Game Maker
    /// </summary>
    public enum FrequencyType1 : int
    {
        Frequency60 = 0,
        Frequency70 = 1,
        Frequency85 = 2,
        Frequency100 = 3,
        NoChange = 4,
    };

    /// <summary>
    /// Describes screen refresh rate types for newer versions of Game Maker
    /// </summary>
    public enum FrequencyType2 : int
    {
        NoChange = 0,
        Frequency60 = 1,
        Frequency70 = 2,
        Frequency85 = 3,
        Frequency100 = 4,
        Frequency120 = 5,
    };

    /// <summary>
    /// Describes the moment checking types for triggers
    /// </summary>
    public enum MomentType : int
    {
        Begin = 0,
        Middle = 1,
        End = 2
    };

    /// <summary>
    /// Describes a sprite collision shape type
    /// </summary>
    public enum ShapeType : int
    {
        Precise = 0,
        Rectange = 1,
        Disk = 2,
        Diamond = 3
    };

    /// <summary>
    /// Defines object physics shape types
    /// </summary>
    public enum PhysicsShapeType : int
    {
        Circle = 0,
        Box = 1,
        Shape = 2
    };

    /// <summary>
    /// Defines properties of a GMX action
    /// </summary>
    public enum GMXActionProperty
    {
        [EnumString("libid")]
        LibId,
        [EnumString("id")]
        Id,
        [EnumString("kind")]
        Kind,
        [EnumString("userelative")]
        UseRelative,
        [EnumString("isquestion")]
        IsQuestion,
        [EnumString("useapplyto")]
        UseApplyTo,
        [EnumString("exetype")]
        ExeType,
        [EnumString("functionname")]
        FunctionName,
        [EnumString("codestring")]
        CodeString,
        [EnumString("whoName")]
        WhoName,
        [EnumString("relative")]
        Relative,
        [EnumString("isnot")]
        IsNot
    };

    /// <summary>
    /// Defines properties of a GMX argument
    /// </summary>
    public enum GMXArgumentProperty
    {
        [EnumString("kind")]
        Kind,
        [EnumString("string")]
        String
    };

    /// <summary>
    /// Defines properties of a GMX background
    /// </summary>
    public enum GMXBackgroundProperty
    {
        [EnumString("istileset")]
        IsTileset,
        [EnumString("tilewidth")]
        TileWidth,
        [EnumString("tileheight")]
        TileHeight,
        [EnumString("tilexoff")]
        TileXOff,
        [EnumString("tileyoff")]
        TileYOff,
        [EnumString("tilehsep")]
        TileHSep,
        [EnumString("tilevsep")]
        TileVSep,
        [EnumString("HTile")]
        HTile,
        [EnumString("VTile")]
        VTile,
        [EnumString("TextureGroup0")]
        TextureGroup0,
        [EnumString("For3D")]
        For3D,
        [EnumString("width")]
        Width,
        [EnumString("height")]
        Height,
        [EnumString("data")]
        Data
    };

    /// <summary>
    /// Defines properties of a GMX event
    /// </summary>
    public enum GMXEventProperty
    {
        [EnumString("eventtype")]
        Eventtype,
        [EnumString("enumb")]
        ENumb,
        [EnumString("ename")]
        EName
    };

    /// <summary>
    /// Defines properties of a GMX room
    /// </summary>
    public enum GMXObjectProperty
    {
        [EnumString("spriteName")]
        SpriteName,
        [EnumString("solid")]
        Solid,
        [EnumString("visible")]
        Visible,
        [EnumString("depth")]
        Depth,
        [EnumString("persistent")]
        Persistent,
        [EnumString("parentName")]
        ParentName,
        [EnumString("maskName")]
        MaskName,
        [EnumString("event")]
        Event,
        [EnumString("action")]
        Action,
        [EnumString("argument")]
        Argument,
        [EnumString("PhysicsObject")]
        PhysicsObject,
        [EnumString("PhysicsObjectSensor")]
        PhysicsObjectSensor,
        [EnumString("PhysicsObjectShape")]
        PhysicsObjectShape,
        [EnumString("PhysicsObjectDensity")]
        PhysicsObjectDensity,
        [EnumString("PhysicsObjectRestitution")]
        PhysicsObjectRestitution,
        [EnumString("PhysicsObjectGroup")]
        PhysicsObjectGroup,
        [EnumString("PhysicsObjectLinearDamping")]
        PhysicsObjectLinearDamping,
        [EnumString("PhysicsObjectAngularDamping")]
        PhysicsObjectAngularDamping,
        [EnumString("PhysicsObjectFriction")]
        PhysicsObjectFriction,
        [EnumString("PhysicsObjectAwake")]
        PhysicsObjectAwake,
        [EnumString("PhysicsObjectKinematic")]
        PhysicsObjectKinematic,
        [EnumString("PhysicsShapePoint")]
        PhysicsShapePoint
    };

    /// <summary>
    /// Defines properties of a GMX sprite
    /// </summary>
    public enum GMXSpriteProperty
    {
        [EnumString("type")]
        Type,
        [EnumString("xorig")]
        XOrigin,
        [EnumString("yorigin")]
        YOrigin,
        [EnumString("colkind")]
        ColKind,
        [EnumString("coltolerance")]
        ColTolerance,
        [EnumString("sepmasks")]
        SepMasks,
        [EnumString("bboxmode")]
        BBoxMode,
        [EnumString("bbox_left")]
        BBoxLeft,
        [EnumString("bbox_right")]
        BBoxRight,
        [EnumString("bbox_top")]
        BBoxTop,
        [EnumString("bbox_bottom")]
        BBoxBottom,
        [EnumString("HTile")]
        HTile,
        [EnumString("VTile")]
        VTile,
        [EnumString("TextureGroup0")]
        TextureGroup0,
        [EnumString("For3D")]
        For3D,
        [EnumString("width")]
        Width,
        [EnumString("height")]
        Height,
        [EnumString("frame")]
        Frame
    };

    /// <summary>
    /// Defines properties of a GMX tile
    /// </summary>
    public enum GMXTileProperty
    {
        [EnumString("bgName")]
        BGName,
        [EnumString("x")]
        X,
        [EnumString("y")]
        Y,
        [EnumString("w")]
        W,
        [EnumString("h")]
        H,
        [EnumString("xo")]
        XO,
        [EnumString("yo")]
        YO,
        [EnumString("id")]
        Id,
        [EnumString("name")]
        Name,
        [EnumString("depth")]
        Depth,
        [EnumString("locked")]
        Locked,
        [EnumString("colour")]
        Colour,
        [EnumString("scaleX")]
        ScaleX,
        [EnumString("scaleY")]
        ScaleY
    };

    /// <summary>
    /// Defines properties of a GMX room
    /// </summary>
    public enum GMXRoomProperty
    {
        [EnumString("caption")]
        Caption,
        [EnumString("width")]
        Width,
        [EnumString("height")]
        Height,
        [EnumString("vsnap")]
        VSnap,
        [EnumString("hsnap")]
        HSnap,
        [EnumString("isometric")]
        Isometric,
        [EnumString("speed")]
        Speed,
        [EnumString("persistent")]
        Persistent,
        [EnumString("colour")]
        Colour,
        [EnumString("showcolour")]
        ShowColour,
        [EnumString("code")]
        Code,
        [EnumString("enableViews")]
        EnableViews,
        [EnumString("clearViewBackground")]
        ClearViewBackground,
        [EnumString("isSet")]
        IsSet,
        [EnumString("w")]
        W,
        [EnumString("h")]
        H,
        [EnumString("showGrid")]
        ShowGrid,
        [EnumString("showObjects")]
        ShowObjects,
        [EnumString("showTiles")]
        ShowTiles,
        [EnumString("showBackgrounds")]
        ShowBackgrounds,
        [EnumString("showForegrounds")]
        ShowForegrounds,
        [EnumString("showViews")]
        ShowViews,
        [EnumString("deleteUnderlyingObj")]
        DeleteUnderlyingObj,
        [EnumString("deleteUnderlyingTiles")]
        DeleteUnderlyingTiles,
        [EnumString("page")]
        Page,
        [EnumString("xoffset")]
        XOffset,
        [EnumString("yoffset")]
        YOffset,
        [EnumString("background")]
        Background,
        [EnumString("view")]
        View,
        [EnumString("instance")]
        Instance,
        [EnumString("tile")]
        Tile,
        [EnumString("PhysicsWorld")]
        PhysicsWorld,
        [EnumString("PhysicsWorldTop")]
        PhysicsWorldTop,
        [EnumString("PhysicsWorldLeft")]
        PhysicsWorldLeft,
        [EnumString("PhysicsWorldRight")]
        PhysicsWorldRight,
        [EnumString("PhysicsWorldBottom")]
        PhysicsWorldBottom,
        [EnumString("PhysicsWorldGravityX")]
        PhysicsWorldGravityX,
        [EnumString("PhysicsWorldGravityY")]
        PhysicsWorldGravityY,
        [EnumString("PhysicsWorldPixToMeters")]
        PhysicsWorldPixToMeters
    };

    /// <summary>
    /// Defines properties of a GMX parallax
    /// </summary>
    public enum GMXParallaxProperty
    {
        [EnumString("visible")]
        Visible,
        [EnumString("foreground")]
        Foreground,
        [EnumString("name")]
        Name,
        [EnumString("x")]
        X,
        [EnumString("y")]
        Y,
        [EnumString("htiled")]
        HTiled,
        [EnumString("vtiled")]
        VTiled,
        [EnumString("hspeed")]
        HSpeed,
        [EnumString("vspeed")]
        VSpeed,
        [EnumString("stretch")]
        Stretch
    };

    /// <summary>
    /// Defines properties of a GMX view
    /// </summary>
    public enum GMXViewProperty
    {
        [EnumString("visible")]
        Visible,
        [EnumString("objName")]
        ObjName,
        [EnumString("xview")]
        XView,
        [EnumString("yview")]
        YView,
        [EnumString("wview")]
        WView,
        [EnumString("hview")]
        HView,
        [EnumString("xport")]
        XPort,
        [EnumString("yport")]
        YPort,
        [EnumString("wport")]
        WPort,
        [EnumString("hport")]
        HPort,
        [EnumString("hborder")]
        HBorder,
        [EnumString("vborder")]
        VBorder,
        [EnumString("hspeed")]
        HSpeed,
        [EnumString("vspeed")]
        VSpeed
    };

    /// <summary>
    /// Defines properties of a GMX instance
    /// </summary>
    public enum GMXInstanceProperty
    {
        [EnumString("objName")]
        ObjName,
        [EnumString("x")]
        X,
        [EnumString("y")]
        Y,
        [EnumString("name")]
        Name,
        [EnumString("locked")]
        Locked,
        [EnumString("code")]
        Code,
        [EnumString("scaleX")]
        ScaleX,
        [EnumString("scaleY")]
        ScaleY,
        [EnumString("colour")]
        Colour,
        [EnumString("rotation")]
        Rotation
    };
}
