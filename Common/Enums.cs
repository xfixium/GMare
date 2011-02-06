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

namespace GMare.Common
{
    /// <summary>
    /// Describes a direction to shift room tiles.
    /// </summary>
    public enum ShiftDirection
    {
        Up,
        Right,
        Down,
        Left
    };

    /// <summary>
    /// Describes different layer levels.
    /// </summary>
    public enum EditType
    {
        ViewAll,
        Collisions,
        Instances,
        Layers
    };

    /// <summary>
    /// Describes different tool types.
    /// </summary>
    public enum ToolType
    {
        Pencil,
        Bucket,
        Selection,
        MultiTile
    };

    /// <summary>
    /// Describes different shape types.
    /// </summary>
    public enum ShapeType
    {
        Rectangle,
        Triangle
    };

    /// <summary>
    /// Describes the drawing type of a grid.
    /// </summary>
    public enum GridType
    {
        Normal,
        Isometric
    };
    
    /// <summary>
    /// Describes the method to read | write tiles on a binary level.
    /// </summary>
    public enum BinaryMethod : byte
    {
        Sector = 0,
        Tile = 1
    };

    /// <summary>
    /// 
    /// </summary>
    public enum SolidType : byte
    {
        Empty = 0,
        Full = 1,
        Top = 2,
        Right = 3,
        Bottom = 4,
        Left = 5
    };
}
