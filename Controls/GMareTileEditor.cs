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
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using GMare.Objects;
using Pyxosoft.Windows.Tools.PyxTools.Controls;

namespace GMare.Controls
{
    public partial class GMareTileEditor : PyxCanvas
    {
        #region Enumerations

        /// <summary>
        /// Describes context action types
        /// </summary>
        public enum ContextActionType
        {
            Deselect,
            Clear
        }

        #endregion

        #region Fields

        public event PanelChangedHandler PanelChanged;     // Selected instance changed event
        public delegate void PanelChangedHandler();        // Selected instance changed event handler
        private Bitmap _tileSelection = null;              // Tile selection bitmap
        private List<Bitmap> _tiles = null;                // Collection of tile images
        private GMareBrush _targets = null;                // The target tiles
        private GMareBrush _swaps = null;                  // The swapping tiles
        private ColorMatrix _matrix = null;                // Grid color matrix
        private ImageAttributes _atts = null;              // Grid image attributes
        private Timer _antsTimer = new Timer();            // Marching ants timer
        private Point _pos = Point.Empty;                  // Selection draw origin
        private float[][] _elements = null;                // Grid color matrix elements
        private int _cols = 16;                            // The desired width of the tileset
        private int _rows = 16;                            // The calculated rows
        private int _antOffset = 0;                        // Marching ants offset
        private bool _showGrid = true;                     // Whether to show the tile grid
        private bool _dragging = false;                    // Whether the user is dragging a selection
        private bool _moving = false;                      // Whther the user is moving the slection

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the source image
        /// </summary>
        public List<Bitmap> Tiles
        {
            get { return _tiles; }
            set
            {
                _tiles = value;

                // If a slection exists, empty it
                if (_targets != null)
                    _targets = null;

                // Calculate the rows of the tileset
                _rows = _tiles == null || _tiles.Count == 0 ? 0 : (int)Math.Ceiling((double)_tiles.Count / (double)_cols);

                // Set canvas size
                CanvasSize = _tiles == null || _tiles.Count == 0 ? Size.Empty : new Size(TilesetWidth, TilesetHeight);
            }
        }

        /// <summary>
        /// Sets the number of desired columns for the tileset
        /// </summary>
        public int Columns
        {
            get { return _cols; }
            set
            {
                _cols = value;
                
                // If a slection exists, empty it
                if (_targets != null)
                    _targets = null;

                // Calculate the rows of the tileset
                _rows = _tiles == null || _tiles.Count == 0 ? 0 : (int)Math.Ceiling((double)_tiles.Count / (double)_cols);

                // Set canvas size
                CanvasSize = _tiles == null || _tiles.Count == 0 ? Size.Empty : new Size(TilesetWidth, TilesetHeight);
            }
        }

        /// <summary>
        /// Gets the width of tileset in pixels
        /// </summary>
        public int TilesetWidth
        {
            get { return _cols * SnapSize.Width; }
        }

        /// <summary>
        /// Gets the height of tileset in pixels
        /// </summary>
        public int TilesetHeight
        {
            get { return _rows * SnapSize.Height; }
        }

        /// <summary>
        /// Gets the tileset size in pixels
        /// </summary>
        public Size TilesetSize
        {
            get { return new Size(TilesetWidth, TilesetHeight); }
        }

        /// <summary>
        /// Gets or sets whether to show the cell grid
        /// </summary>
        public bool ShowGrid
        {
            get { return _showGrid; }
            set { _showGrid = value; UpdateBackBuffer(); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new image panel
        /// </summary>
        public GMareTileEditor()
        {
            InitializeComponent();

            // Set color matrix elements
            _elements = new float[][] {
                new float[] { -1,  0,  0,  0, 0 },
                new float[] { 0,  -1,  0,  0, 0 },
                new float[] { 0,  0,  -1,  0, 0 },
                new float[] { 0,  0,  0,  1,  0 },
                new float[] { 1,  1,  1,  0,  1 } };

            // Create new color matrix
            _matrix = new ColorMatrix(_elements);

            // Create image attributes
            _atts = new ImageAttributes();
            _atts.SetColorMatrix(_matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            // Update the backbuffer
            UpdateBackBuffer();

            // Set timer interval
            _antsTimer.Interval = 100;

            // Hook tick event
            _antsTimer.Tick += new EventHandler(Timer_Tick);

            // Start mask blink timer
            _antsTimer.Start();

            // Hook context menu events
            mnuClear.Click += new EventHandler(mnuClear_Click);
            mnuDeselect.Click += new EventHandler(mnuDeselect_Click);
        }

        #endregion

        #region Events

        /// <summary>
        /// Deselect Tile(s) button click
        /// </summary>
        private void mnuDeselect_Click(object sender, EventArgs e)
        {
            // Reset selection variables.
            ResetSelection();
        }

        /// <summary>
        /// Clears the selected tile(s) bitmap(s), not the tile id
        /// </summary>
        private void mnuClear_Click(object sender, EventArgs e)
        {
            // If targets are empty, return
            if (_targets == null)
                return;

            // Panel changed
            PanelChanged();

            // Get tile ids
            int[] tiles = _targets.ToArray();

            // Iterate through tiles
            foreach (int tile in tiles)
            {
                // If the tile is not already empty
                if (_tiles[tile] != null)
                {
                    // Create a blank dummy tile
                    Bitmap image = new Bitmap(_tiles[tile].Width, _tiles[tile].Height);
                    image.Tag = (int)_tiles[tile].Tag;

                    // Clear the tile
                    _tiles[tile].Dispose();
                    _tiles[tile] = image;
                }
            }

            // Reset selection values
            ResetSelection();

            // Update backbuffer
            UpdateBackBuffer();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// On draw after on paint
        /// </summary>
        protected override void OnDrawAfterOnPaint(ref PaintEventArgs e)
        {
            // If a tile has been selected for swapping, draw the selection rectangle
            if (_targets != null)
            {
                // Get destination point
                Point position = new Point(-AutoScrollPosition.X, -AutoScrollPosition.Y);

                // Calculate rectangle with scroll offset
                Rectangle rect = _targets.ToRectangle();
                rect.X -= (int)(position.X / Zoom);
                rect.Y -= (int)(position.Y / Zoom);

                // Draw selection rectangle
                DrawSelection(e.Graphics, rect);
            }
        }

        /// <summary>
        /// On draw on backbuffer
        /// </summary>
        protected override void OnDrawOnBackbuffer(ref System.Drawing.Graphics gfx)
        {
            // If there are tiles to draw, draw them
            if (_tiles == null)
                return;

            DrawTiles(gfx);

            // If showing the grid
            if (_showGrid)
                DrawGrid(gfx);
        }

        /// <summary>
        /// On mouse down
        /// </summary>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Allow hooking of this event
            base.OnMouseDown(e);

            // If the project and tileset do not exist, return
            if (BackBuffer == null || _tiles == null || _tiles.Count == 0)
                return;

            // Focus for scroll support
            Focus();

            // Get start snapped position
            Point snap = GetSnappedPoint(e.Location);

            // Check if the click is within bounds
            if (new Rectangle(0, 0, TilesetWidth, TilesetHeight).Contains(snap) == false)
                return;

            // If left button was clicked, and there are tiles to select
            if (e.Button == MouseButtons.Left && _tiles != null)
            {
                // If cursor is within selection
                if (_targets != null && _targets.ToRectangle().Contains(snap) == true)
                {
                    // Selection clicked
                    _moving = true;

                    // Set zero position
                    _pos.X = snap.X;
                    _pos.Y = snap.Y;
                }

                // If not moving a selection
                if (_moving == false)
                {
                    // Dispose of old bitmap
                    if (_tileSelection != null)
                    {
                        _tileSelection.Dispose();
                        _tileSelection = null;
                    }

                    // Create a new tile grid
                    _targets = new GMareBrush();

                    // Start collecting other tiles
                    _dragging = true;

                    // Set selection tile sector.
                    _targets.StartX = snap.X;
                    _targets.StartY = snap.Y;
                    _targets.EndX = _targets.StartX + SnapSize.Width;
                    _targets.EndY = _targets.StartY + SnapSize.Height;
                }
            }

            // If right button was clicked
            if (e.Button == MouseButtons.Right)
            {
                // Empty selection
                if (_targets == null || _targets.ToRectangle().Contains(snap) == false)
                    return;

                // Show options menu
                mnuOptions.Show(this.PointToScreen(e.Location));
            }

            // Force redraw.
            Invalidate();
        }

        /// <summary>
        /// On mouse move
        /// </summary>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // Allow hooking of this event
            base.OnMouseMove(e);

            // Calculate snapped tile position
            Point snap = GetSnappedPoint(e.Location);

            // If a selection exists, and within it's bounds
            if (_targets != null && _targets.ToRectangle().Contains(snap) == true && _dragging == false)
                this.Cursor = this.Cursor == Cursors.SizeAll ? this.Cursor : Cursors.SizeAll;
            else
                this.Cursor = this.Cursor == Cursors.Arrow ? this.Cursor : Cursors.Arrow;

            // If the project and tileset do not exist, return
            if (BackBuffer == null || _tiles == null || _tiles.Count == 0)
                return;

            // If moving a selection
            if (_moving == true)
            {
                // If there is a change in snapped position since last movement
                if (snap.X != _pos.X || snap.Y != _pos.Y)
                {
                    // Calculate move amount
                    Point pos = new Point(snap.X - _pos.X, snap.Y - _pos.Y);

                    // Set check to new value
                    _pos.X = snap.X;
                    _pos.Y = snap.Y;

                    // Set selection position
                    _targets.StartX += pos.X;
                    _targets.StartY += pos.Y;
                    _targets.EndX += pos.X;
                    _targets.EndY += pos.Y;

                    // Force redraw
                    Invalidate();
                }
            }

            // If dragging a rubberband rectangle
            if (_dragging == true)
            {
                // If drag is not within bounds, return
                if (!new Rectangle(0, 0, TilesetWidth, TilesetHeight).Contains(snap))
                    return;

                // If the snapped x is greater than the start x, add an extra tile width to contain the mouse cursor
                if (snap.X >= _targets.StartX)
                    snap.X += SnapSize.Width;

                // If the snapped y is greater than the start y, add an extra tile height to contain the mouse cursor
                if (snap.Y >= _targets.StartY)
                    snap.Y += SnapSize.Height;

                // If there is a change in snapped position since last movement
                if (snap.X != _targets.EndX || snap.Y != _targets.EndY)
                {
                    // If the end x coordinate is not equal to the start x coordinate, set it
                    if (snap.X != _targets.StartX)
                        _targets.EndX = snap.X;

                    // If the end y coordinate is not equal to the start y coordinate, set it
                    if (snap.Y != _targets.StartY)
                        _targets.EndY = snap.Y;

                    // Force redraw
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// On mouse up
        /// </summary>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            // Allow others to hook this event
            base.OnMouseUp(e);

            // If the project and tileset do not exist, return
            if (BackBuffer == null || _tiles == null || _tiles.Count == 0)
                return;

            // Stop dragging operation
            if (_dragging == true && _targets != null)
            {
                // Stop dragging operation
                _dragging = false;

                // Get an array of tile ids
                _targets.Tiles = GMareBrush.RectangleToTiles(_targets.ToRectangle(), TilesetWidth, SnapSize);

                // Get target tiles
                int[] tiles = _targets.ToArray();

                // Check if all selected tiles are valid
                foreach (int tile in tiles)
                {
                    // If the tile id is out of bounds
                    if (tile < 0 || tile >= _tiles.Count)
                    {
                        // Reset selection, and return
                        ResetSelection();
                        return;
                    }
                }

                // Set tile selection graphic
                _tileSelection = GetImage().Clone(_targets.ToRectangle(), PixelFormat.Format32bppArgb);

                // Create a copy of the selection for swapping
                _swaps = _targets.Clone();
            }

            // Set and swap tile bitmaps
            if (_moving && _targets != null)
            {
                // Stop moving operation
                _moving = false;

                // Check tileset bounds
                if (new Rectangle(0, 0, TilesetWidth, TilesetHeight).Contains(_targets.ToRectangle()) == false)
                {
                    // Reset to original selection, and return
                    _targets = _swaps;
                    _swaps = null;
                    Invalidate();
                    return;
                }

                // Get an array of selected tile ids
                _targets.Tiles = GMareBrush.RectangleToTiles(_targets.ToRectangle(), TilesetWidth, SnapSize);

                // Get new target tiles
                int[] tiles = _targets.ToArray();

                // Check to see if the drop is valid
                foreach (int tile in tiles)
                {
                    // If the tile id is out of bounds
                    if (tile < 0 || tile >= _tiles.Count)
                    {
                        // Reset to original selection, and return
                        _targets = _swaps;
                        _swaps = null;
                        Invalidate();
                        return;
                    }
                }

                // Swap tiles
                SwapTiles();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Calls a context menu command from the context menu
        /// </summary>
        /// <param name="type">The context action to execute</param>
        public void ExecuteContextAction(ContextActionType type)
        {
            // Get snapped position
            Point snap = GetSnappedPoint(PointToClient(Cursor.Position));

            // Empty selection
            if (_targets == null || _targets.ToRectangle().Contains(snap) == false)
                return;

            // Do action based on context action
            switch (type)
            {
                case ContextActionType.Deselect: mnuDeselect_Click(mnuDeselect, EventArgs.Empty); break;
                case ContextActionType.Clear: mnuClear_Click(mnuClear, EventArgs.Empty); break;
            }
        }

        /// <summary>
        /// Draws all the tiles
        /// </summary>
        private void DrawTiles(System.Drawing.Graphics gfx)
        {
            // Tile indexer
            int index = 0;

            // Iterate through rows
            for (int row = 0; row < _rows; row++)
            {
                // Iterate through columns
                for (int col = 0; col < _cols; col++)
                {
                    // If the tile is within bounds, and is not empty, draw tile
                    if (index < _tiles.Count && _tiles[index] != null)
                        gfx.DrawImageUnscaled(_tiles[index], (col * SnapSize.Width), (row * SnapSize.Height));

                    // Increment the indexer
                    index++;
                }
            }
        }

        /// <summary>
        /// Draw grid cells
        /// </summary>
        private void DrawGrid(System.Drawing.Graphics gfx)
        {
            // Save state
            GraphicsState state = gfx.Save();

            // Created invert pen
            Pen pen = new Pen(Color.Red);

            // Get rendering rectangle
            Rectangle rect = new Rectangle(0, 0, BackBuffer.Width, BackBuffer.Height);

            // Create a new graphics path for inverted lines
            GraphicsPath path = new GraphicsPath(FillMode.Alternate);

            // Iterate through vertical tiles
            for (int row = 0; row < _rows; row++)
            {
                // Iterate through horizontal tiles
                for (int col = 0; col < _cols; col++)
                {
                    // Get position coordinates
                    int x = col * SnapSize.Width;
                    int y = row * SnapSize.Height;

                    // Add rectangle path
                    path.AddRectangle(new Rectangle(x, y, SnapSize.Width, SnapSize.Height));
                }
            }

            // Widen the path with pen
            path.Widen(pen);

            // Create new region
            Region region = new Region(path);
            
            // Set the region
            gfx.Clip = region;

            // Draw the backbuffer image
            gfx.DrawImage(BackBuffer, rect, 0, 0, rect.Width, rect.Height, GraphicsUnit.Pixel, _atts);
            
            // Restore the graphics state to non-inverted
            gfx.Restore(state);
            
            // Dispose of all temp objects
            region.Dispose();
            pen.Dispose();
        }

        /// <summary>
        /// Draws the selected tiles rectangles
        /// </summary>
        private void DrawSelection(System.Drawing.Graphics gfx, Rectangle rect)
        {
            // Create a new pen
            Pen pen = new Pen(Color.White, 1);
            pen.DashStyle = DashStyle.Dash;
            pen.DashPattern = new float[2] { 4, 4 };
            pen.DashOffset = _antOffset;

            rect.X += 1;
            rect.Y += 1;

            // Draw tile selection
            if (_tileSelection != null)
                gfx.DrawImage(_tileSelection, rect.Location);

            // Draw marching ants rectangle
            gfx.DrawRectangle(Pens.Black, rect);
            gfx.DrawRectangle(pen, rect);

            // Dispose
            pen.Dispose();
        }

        /// <summary>
        /// Compiles the compiled tiles to a bitmap
        /// </summary>
        public Bitmap GetImage()
        {
            // If no tiles to draw, return nothing
            if (_tiles == null)
                return null;

            // Create a new empty bitmap
            Bitmap tileset = new Bitmap(TilesetWidth, TilesetHeight, PixelFormat.Format32bppPArgb);
            
            // Create graphics
            System.Drawing.Graphics gfx = System.Drawing.Graphics.FromImage(tileset);

            // Draw tiles to tileset bitmap
            DrawTiles(gfx);

            // Return tileset
            return tileset;
        }

        /// <summary>
        /// Swaps tiles from the selection grid
        /// </summary>
        private void SwapTiles()
        {
            // If the targets or swaps grids are empty, return
            if (_targets == null || _swaps == null)
                return;

            // Get tile arrays.
            int[] targets = _targets.ToArray();
            int[] swaps = _swaps.ToArray();

            // If the swaps are the same as the targets, return
            if (swaps[0] == targets[0])
                return;

            // Variables for correct swapping order
            int index = 0;
            int amount = 1;
            int count = targets.Length;

            // If the swap origin is less than the target origin
            if (swaps[0] < targets[0])
            {
                // Iterate backwards for the proper ordering
                amount = -1;
                count = -1;
                index = targets.Length - 1;
            }

            // Panel changed
            PanelChanged();

            // Iterate through tiles
            for (int i = index; i != count; i += amount)
            {
                // New bitmaps
                Bitmap target = null;
                Bitmap swap = null;

                // If the tile is not empty, copy it
                if (_tiles[swaps[i]] != null)
                {
                    swap = (Bitmap)_tiles[swaps[i]].Clone();
                    swap.Tag = (int)_tiles[swaps[i]].Tag;
                    _tiles[swaps[i]].Dispose();
                }

                // If the tile is not empty, copy it
                if (_tiles[targets[i]] != null)
                {
                    target = (Bitmap)_tiles[targets[i]].Clone();
                    target.Tag = (int)_tiles[targets[i]].Tag;
                    _tiles[targets[i]].Dispose();
                }

                // Swap tiles
                _tiles[targets[i]] = swap;
                _tiles[swaps[i]] = target;
            }

            // Reset selection
            ResetSelection();

            // Redraw backbuffer
            UpdateBackBuffer();
        }

        /// <summary>
        /// Marching ants timer tick
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Increase offset
            _antOffset++;

            // If at maximum offset, reset offset
            if (_antOffset % 8 == 0)
                _antOffset = 0;

            // As long as there is a target selection, force redraw
            if (_targets != null)
                Invalidate();
        }

        /// <summary>
        /// Resets selection variables
        /// </summary>
        private void ResetSelection()
        {
            // Empty selections
            _targets = null;
            _swaps = null;

            // If the tile selection is not empty, dispose and empty
            if (_tileSelection != null)
            {
                _tileSelection.Dispose();
                _tileSelection = null;
            }

            // Force redraw
            Invalidate();
        }

        #endregion
    }
}