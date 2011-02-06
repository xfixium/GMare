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

using System.Drawing;

namespace GMare.Common
{
    /// <summary>
    /// Class that holds tile ids, and provides methods and properties to convert that data into various forms.
    /// </summary>
    public class TileGrid
    {
        #region Fields

        private int _startX = 0;         // The x coordinate of the top left vector.
        private int _startY = 0;         // The y coordinate of the top left vector.
        private int _endX = 16;          // The x coordinate of the bottom right vector.
        private int _endY = 16;          // The y coordinate of the bottom right vector.
        private int[,] _tileIds = null;  // An array of tile ids.

        #endregion

        #region Properties

        /// <summary>
        /// Gets the starting point of the tile grid.
        /// </summary>
        public Point Start
        {
            get { return new Point(_startX, _startY); }
        }

        /// <summary>
        /// Gets or sets the x coordinate of the top left vector.
        /// </summary>
        public int StartX
        {
            get { return _startX; }
            set { _startX = value; }
        }

        /// <summary>
        /// Gets or sets the y coordinate of the top left vector.
        /// </summary>
        public int StartY
        {
            get { return _startY; }
            set { _startY = value; }
        }

        /// <summary>
        /// Gets the ending point of the tile grid.
        /// </summary>
        public Point End
        {
            get { return new Point(_endX, _endY); }
        }

        /// <summary>
        /// Gets or sets the x coordinate of the bottom right vector.
        /// </summary>
        public int EndX
        {
            get { return _endX; }
            set { _endX = value; }
        }

        /// <summary>
        /// Gets or sets the y coordinate of the bottom right vector.
        /// </summary>
        public int EndY
        {
            get { return _endY; }
            set { _endY = value; }
        }

        /// <summary>
        /// Gets the amount of coulmns the grid has.
        /// </summary>
        public int Columns
        {
            get
            {
                if (_tileIds == null)
                    return 0;
                else
                    return _tileIds.GetLength(0);
            }
        }

        /// <summary>
        /// Gets the amount of rows the grid has.
        /// </summary>
        public int Rows
        {
            get
            {
                if (_tileIds == null)
                    return 0;
                else
                    return _tileIds.GetLength(1);
            }
        }

        /// <summary>
        /// Gets the width of the tile grid in pixels.
        /// </summary>
        public int Width
        {
            get { return ToRectangle().Width; }
        }

        /// <summary>
        /// Gets the height of the tile grid in pixels.
        /// </summary>
        public int Height
        {
            get { return ToRectangle().Height; }
        }

        /// <summary>
        /// Gets or sets the array of tile ids.
        /// </summary>
        public int[,] TileIds
        {
            get { return _tileIds; }
            set { _tileIds = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a shallow copy of this tile grid.
        /// </summary>
        /// <returns>A copy of this tile grid.</returns>
        public TileGrid Clone()
        {
            // Create a new tile grid.
            TileGrid grid = new TileGrid();
            
            // Set properties.
            grid.StartX = _startX;
            grid.StartY = _startY;
            grid.EndX = _endX;
            grid.EndY = _endY;
            grid._tileIds = (int[,])_tileIds.Clone();

            // Return copy.
            return grid;
        }

        /// <summary>
        /// Gets a rectangle representation of the tile sector.
        /// </summary>
        /// <returns>A rectangle version of the tile sector.</returns>
        public Rectangle ToRectangle()
        {
            // Create the sector points.
            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;

            // If start x is less than end x.
            if (_startX < _endX)
            {
                // Set the first x to start x.
                x1 = _startX;
                x2 = _endX;
            }
            else
            {
                // Set the first x to end x.
                x1 = _endX;
                x2 = _startX;
            }

            // If start y is less than end y.
            if (_startY < _endY)
            {
                // Set the first y to start y.
                y1 = _startY;
                y2 = _endY;
            }
            else
            {
                // Set the first y to end y.
                y1 = _endY;
                y2 = _startY;
            }

            // Create new rectangle based on sector points.
            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        /// <summary>
        /// Gets the tile ids within the grid as an array.
        /// </summary>
        /// <returns>An array of tile ids.</returns>
        public int[] ToArray()
        {
            // Create a new array of tile ids.
            int index = 0;
            int[] ids = new int[Columns * Rows];

            // Iterate through tile ids.
            for (int row = 0; row < _tileIds.GetLength(1); row++)
            {
                for (int col = 0; col < _tileIds.GetLength(0); col++)
                {
                    ids[index] = _tileIds[col, row];
                    index++;
                }
            }

            // Return tile ids as an array.
            return ids;
        }

        /// <summary>
        /// Creates a point from a tile id.
        /// </summary>
        /// <param name="tileId">The tile id to calculate the position with.</param>
        /// <param name="width">The width of the source tileset.</param>
        /// <param name="tileSize">The size of one tile.</param>
        /// <returns>The tile id's position.</returns>
        public static Point TileIdToPosition(int tileId, int width, Size tileSize)
        {
            // Calculate the number of columns the tileset has.
            int cols = width / tileSize.Width;

            // Calculate the poisition coordinates.
            int x = (tileId - (tileId / cols) * cols) * tileSize.Width;
            int y = (tileId / cols) * tileSize.Height;

            // Return the position of the tile id.
            return new Point(x, y);
        }

        /// <summary>
        /// Creates a tiled point from a tile id.
        /// </summary>
        /// <param name="tileId">The tile id to calculate the position with.</param>
        /// <param name="width">The width of the source tileset.</param>
        /// <param name="tileSize">The size of one tile.</param>
        /// <returns>The tile id's position.</returns>
        public static Point TileIdToSector(int tileId, int width, Size tileSize)
        {
            // Calculate the number of columns the tileset has.
            int cols = width / tileSize.Width;

            // Calculate the poisition coordinates.
            int x = (tileId - (tileId / cols) * cols) * tileSize.Width;
            int y = (tileId / cols) * tileSize.Height;

            // Return the position of the tile id.
            return new Point(x / tileSize.Width, y / tileSize.Height);
        }

        /// <summary>
        /// Gets a tile id from a position.
        /// </summary>
        /// <param name="x">The x coordinate to calculate.</param>
        /// <param name="y">The y coordinate to calculate.</param>
        /// <param name="width">The width of the source tileset.</param>
        /// <param name="tileSize">The tile size of a single tile.</param>
        /// <returns>A tile id.</returns>
        public static int PositionToTileId(int x, int y, int width, Size tileSize)
        {
            // Calculate number of columns.
            int cols = width / tileSize.Width;

            // Calculate coordinates.
            int col = x / tileSize.Width;
            int row = y / tileSize.Height;

            // Calculate tile id.
            int tileId = (row * cols) + col;

            // Return tile id.
            return tileId;
        }

        /// <summary>
        /// Converts a rectangle to an array of tile ids.
        /// </summary>
        /// <param name="rectangle">The source rectangle to copy tile ids from.</param>
        /// <param name="width">The width of the source tileset.</param>
        /// <param name="tileSize">The tile size of a single tile.</param>
        /// <returns>An array fo tile ids.</returns>
        public static int[,] RectangleToTileIds(Rectangle rectangle, int width, Size tileSize)
        {
            // Position variables.
            int x = 0;
            int y = 0;

            // Calculate columns and rows.
            int cols = rectangle.Width / tileSize.Width;
            int rows = rectangle.Height / tileSize.Height;

            // Create a new tile id array.
            int[,] tileIds = new int[cols, rows];

            // Iterate through columns.
            for (int col = 0; col < cols; col++)
            {
                // Iterate through rows.
                for (int row = 0; row < rows; row++)
                {
                    // Calculate tile position.
                    x = (col * tileSize.Width) + rectangle.X;
                    y = (row * tileSize.Height) + rectangle.Y;

                    // Get tile id based on position.
                    tileIds[col, row] = PositionToTileId(x, y, width, tileSize);
                }
            }

            // Return the array of tile ids.
            return tileIds;
        }

        #endregion
    }
}
