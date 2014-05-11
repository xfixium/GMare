#region MIT

// 
// GMare.
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

namespace GMare.Objects
{
    /// <summary>
    /// Describes a direction to shift room tiles
    /// </summary>
    public enum ShiftDirectionType
    {
        Up,
        Right,
        Down,
        Left
    }

    /// <summary>
    /// Describes the flip direction types
    /// </summary>
    public enum FlipDirectionType
    {
        Horizontal,
        Vertical
    }

    /// <summary>
    /// Describes different flip flag types
    /// </summary>
    public enum FlipType : byte
    {
        None = 0,
        Horizontal = 1,
        Vertical = 2,
        Both = 3
    }

    /// <summary>
    /// Describes different edit types
    /// </summary>
    public enum EditType
    {
        Layers,
        Objects
    }

    /// <summary>
    /// Describes different tool types
    /// </summary>
    public enum ToolType
    {
        Eraser,
        Brush,
        Bucket,
        Selection,
    }

    /// <summary>
    /// Describes the drawing type of a grid
    /// </summary>
    public enum GridType
    {
        Normal,
        Isometric
    }
    
    /// <summary>
    /// Describes the method to write tiles for binary export
    /// </summary>
    public enum BinaryMethodType : byte
    {
        Tiled = 0,
        Standard = 1
    }

    /// <summary>
    /// Describes layer calculation method types
    /// </summary>
    public enum LayerMethodType : byte
    {
        AllTiled = 0,
        AllSectored = 1,
        Optimized = 2
    }

    /// <summary>
    /// Describes different data node types
    /// </summary>
    public enum DataNodeType
    {
        Parent,
        PropertyEnforced,
        PropertyRoomName,
        PropertyRoomCaption,
        PropertyRoomCode,
        PropertyRoomSpeed,
        PropertyRoomPersistent,
        PropertyRoomColor,
        PropertyRoomWidth,
        PropertyRoomHeight,
        PropertyRoomColumns,
        PropertyRoomRows,
        PropertyBackgroundTileWidth,
        PropertyBackgroundTileHeight,
        PropertyBackgroundSeparationX,
        PropertyBackgroundSeparationY,
        PropertyBackgroundOffsetX,
        PropertyBackgroundOffsetY,
        PropertyBackgroundWidth,
        PropertyBackgroundHeight,
        PropertyBackgroundColumns,
        PropertyBackgroundRows,
        PropertyLayerName,
        PropertyLayerDepth,
        PropertyTileId,
        PropertyTileColor,
        PropertyTileScaleX,
        PropertyTileScaleY,
        PropertyInstanceObjectId,
        PropertyInstanceCode,
        PropertyInstanceX,
        PropertyInstanceY
    }
}
