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

using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using GenericUndoRedo;

namespace GMare.Objects
{
    /// <summary>
    /// Room owner interface
    /// </summary>
    public interface IRoomOwner
    {
        #region Members

        /// <summary>
        /// Room data property member
        /// </summary>
        RoomData Data
        {
            get;
            set;
        }

        #endregion
    }

    /// <summary>
    /// Tiles owner interface
    /// </summary>
    public interface ITilesOwner
    {
        #region Members

        /// <summary>
        /// Tile data property member
        /// </summary>
        TileData Data
        {
            get;
            set;
        }

        #endregion
    }

    /// <summary>
    /// A room memento class, used for undo/redo operations
    /// </summary>
    class RoomMemento : IMemento<IRoomOwner>
    {
        #region Fields

        private RoomData _data;  // Room data

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a new room memento
        /// </summary>
        /// <param name="data">The room to serialize</param>
        public RoomMemento(RoomData data)
        {
            // Set room data.
            _data = data;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Restore member
        /// </summary>
        /// <param name="target">The room owner</param>
        /// <returns>A restored momento</returns>
        public IMemento<IRoomOwner> Restore(IRoomOwner target)
        {
            IMemento<IRoomOwner> inverse = new RoomMemento(target.Data);
            target.Data = _data;
            return inverse;
        }

        #endregion
    }

    /// <summary>
    /// A tiles memento class, used for undo/redo operations
    /// </summary>
    class TilesMemento : IMemento<ITilesOwner>
    {
        #region Fields

        private TileData _data;  // Tiles data

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new tiles momento
        /// </summary>
        /// <param name="room">The tile data to store</param>
        public TilesMemento(TileData data)
        {
            // Set tile data.
            _data = data;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Restore memento
        /// </summary>
        /// <param name="target">Tiles owner, the target</param>
        /// <returns>A restored memento</returns>
        public IMemento<ITilesOwner> Restore(ITilesOwner target)
        {
            IMemento<ITilesOwner> inverse = new TilesMemento(target.Data);
            target.Data = _data;
            return inverse;
        }

        #endregion
    }

    /// <summary>
    /// A class that contains data for a tile owner
    /// </summary>
    public class TileData
    {
        #region Fields

        private List<Bitmap> _tiles;  // Tile bitmap collection.
        private int _cols;            // Number of columns.

        #endregion

        #region Properties

        /// <summary>
        /// Gets the tile bitmaps.
        /// </summary>
        public List<Bitmap> Tiles
        {
            get { return _tiles; }
        }

        /// <summary>
        /// Gets the columns amount.
        /// </summary>
        public int Columns
        {
            get { return _cols; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new tile data object
        /// </summary>
        /// <param name="tiles">The tile bitmap collection</param>
        /// <param name="layer">The layer data</param>
        /// <param name="cols">The number of columns</param>
        public TileData(List<Bitmap> tiles, int cols)
        {
            _tiles = tiles;
            _cols = cols;
        }

        #endregion
    }

    /// <summary>
    /// Room data for a room owner
    /// </summary>
    public class RoomData
    {
        #region Fields

        private GMareRoom _room = null;  // The room object

        #endregion

        #region Properties

        /// <summary>
        /// Gets the room object.
        /// </summary>
        public GMareRoom Room
        {
            get { return _room; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new room data object
        /// </summary>
        /// <param name="room">The room object</param>
        /// <param name="layer">The selected edit item</param>
        /// <param name="instance">The selected instance</param>
        /// <param name="shape">The selected shape</param>
        public RoomData(GMareRoom room)
        {
            // Set data
            _room = room;
        }

        #endregion
    }
}