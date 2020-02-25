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
using Pyxosoft.Windows.Tools.PyxTools.Controls;
using GMare.Objects;

namespace GMare.Controls
{
    public partial class GMareTilesetRefactorEditor : PyxCanvas
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
        private List<Bitmap> _tiles = null;                // Collection of tile images
        private Bitmap _tileSelection = null;              // Tile selection bitmap
        private GMareBrush _targets = null;                // The target tiles
        private GMareBrush _swaps = null;                  // The swapping tiles
        private ColorMatrix _matrix = null;                // Grid color matrix
        private ImageAttributes _atts = null;              // Grid image attributes
        private Timer _antsTimer = new Timer();            // Marching ants timer
        private Point _pos = Point.Empty;                  // Selection draw origin
        private Size _max = Size.Empty;                    // The maximum size of the tile list
        private float[][] _elements = null;                // Grid color matrix elements
        private int _cols = 16;                            // The desired width of the tileset
        private int _rows = 16;                            // The desired hegiht of the tileset
        private int _antOffset = 0;                        // Marching ants offset
        private bool _showGrid = true;                     // If showing the tile grid
        private bool _dragging = false;                    // If the user is dragging a selection
        private bool _moving = false;                      // If the user is moving the slection
        private int _originalCols = 0;                     // The original size of the background 

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the source image
        /// </summary>
        public List<Bitmap> Tiles
        {
            get
            {
                // Only get the tiles shown
                List<Bitmap> tiles = new List<Bitmap>();

                for (int row = 0; row < _rows; row++)
                    for (int col = 0; col < _cols; col++)
                        tiles.Add(_tiles[col + (row * _cols)]);

                return tiles;
            }
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

                // If the dimensions are bigger than the current maximum, set to new dimensions
                _max.Width = _cols;
                _max.Height = _rows;
                _originalCols = _cols;
            }
        }

        /// <summary>
        /// Gets a list of replacements for targets
        /// </summary>
        public List<int> Replacements
        {
            get
            {
                // Only get the tiles shown
                List<int> tiles = new List<int>();

                // If the width of the tileset is less than the maximum edited
                if (_cols < _max.Width)
                {
                    List<Bitmap> source = GetShortList();
                    int start = _cols;
                    int end = _cols + (_max.Width - _cols);
                    //int mod = _cols;
                    int mod = 1;
                    //int diff = (_max.Width - _cols);
                    int diff2 = _originalCols - _cols < 0 ? 0 : _originalCols - _cols; //_max.Width > _originalCols && _cols < _originalCols ? _max.Width - _originalCols : 0;
                    int row = 0;
                    int tag = 0;
                    int test = 0;

                    int cols = (TilesetWidth / SnapSize.Width);

                    // Change the tile ids
                    for (int i = 0; i < source.Count; i++)
                    {
                        tag = (int)source[i].Tag;
                        //row = tag / _cols;
                        //row += (row * (diff2 - 1));
                        //test = tag - (tag < _cols ? 0 : row);
                        //tiles.Add(test);

                        //mod += diff2 > 0 && (i != 0 && i % cols == 0) ? diff2 : 0;
                        tiles.Add(i);// tag - (tag <= _cols ? 0 : mod));
                    }
                }
                else
                {
                    for (int i = 0; i < _tiles.Count; i++)
                        if (_tiles[i] != null)
                            tiles.Add(i);
                }

                return tiles;
            }
        }

        /// <summary>
        /// Gets a list of targets that will be replaced
        /// </summary>
        public List<int> Targets
        {
            get
            {
                // Only get the tiles shown
                List<int> tiles = new List<int>();

                // If the width of the tileset is less than the maximum edited
                if (_cols < _max.Width)
                {
                    int start = _cols;
                    int end = _cols + (_max.Width - _cols);
                    int mod = _cols;
                    int diff = (_max.Width - _cols);
                    int diff2 = _max.Width > _originalCols && _cols < _originalCols ? _max.Width - _originalCols : 0;
                    int index = 0;

                    // Change the tile ids
                    for (int i = 0; i < _tiles.Count; i++)
                    {
                        // Exclude any tiles outside the column bounds
                        if (i != 0 && i % (mod) == 0)
                        {
                            start = i;
                            end = i + _max.Width - _cols - 1;
                            mod = i + _cols + diff;
                            index += diff2;
                        }

                        // If out of bounds, continue
                        if (i <= end && i >= start)
                            continue;

                        tiles.Add(diff2 != 0 ? index : i);
                        index++;
                    }
                }
                else
                {
                    for (int i = 0; i < _tiles.Count; i++)
                        if (_tiles[i] != null && _tiles[i].Tag != null)
                            tiles.Add((int)_tiles[i].Tag);
                }

                return tiles;
            }
        }

        private List<Bitmap> GetShortList()
        {
            List<Bitmap> source = new List<Bitmap>();
            int start = _cols;
            int end = _cols + (_max.Width - _cols);
            int mod = _cols;
            int diff = (_max.Width - _cols);

            // Change the tile ids
            for (int i = 0; i < _tiles.Count; i++)
            {
                // Exclude any tiles outside the column bounds
                if (i != 0 && i % (mod) == 0)
                {
                    start = i;
                    end = i + _max.Width - _cols - 1;
                    mod = i + _cols + diff;
                }

                // If out of bounds, continue
                if (i <= end && i >= start)
                    continue;

                source.Add(_tiles[i]);
            }

            return source;
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

                // If the tiles are not empty and the width has increased, add padded tiles
                if (_tiles != null && _cols > _max.Width)
                {
                    ResetSelection();

                    // Insert the new tiles
                    for (int i = 0; i < _tiles.Count; i++)
                    {
                        // If a new empty tile, add it
                        if (i != 0 && i % (_cols) == 0)
                            _tiles.Insert(i - 1, GetEmptyTile(_tiles.Count));
                    }

                    // Tack a tile to the end of the array
                    _tiles.Add(GetEmptyTile(_tiles.Count));

                    // Set max width
                    _max.Width = _cols;
                }

                // Set canvas size
                CanvasSize = _tiles == null || _tiles.Count == 0 ? Size.Empty : new Size(TilesetWidth, TilesetHeight);
            }
        }

        /// <summary>
        /// Sets the number of desired columns for the tileset
        /// </summary>
        public int Rows
        {
            get { return _rows; }
            set
            {
                _rows = value;

                // If a slection exists, empty it
                if (_targets != null)
                    _targets = null;

                // If the tiles are not empty and the height has increased, add empty tiles
                if (_tiles != null && _rows > _max.Height)
                {
                    // Add a row of tiles
                    for (int i = 0; i < _cols + 1; i++)
                    {
                        Bitmap tile = new Bitmap(SnapSize.Width, SnapSize.Height);
                        tile.Tag = _tiles.Count;
                        _tiles.Add(tile);
                    }

                    // Set max height
                    _max.Height = _rows;
                }

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
        /// Gets or sets whether to show the cell grid
        /// </summary>
        public bool ShowGrid
        {
            get { return _showGrid; }
            set { _showGrid = value; UpdateBackBuffer(); }
        }

        /// <summary>
        /// Gets the max columns this control has made
        /// </summary>
        public int MaxCols
        {
            get { return _max.Width; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new image panel
        /// </summary>
        public GMareTilesetRefactorEditor()
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
                // If the tile is empty, continue
                if (_tiles[tile] == null)
                    continue;

                // Create a blank dummy tile
                Bitmap image = new Bitmap(_tiles[tile].Width, _tiles[tile].Height);
                image.Tag = (int)_tiles[tile].Tag;

                // Clear the tile
                _tiles[tile].Dispose();
                _tiles[tile] = image;
            }

            // Reset selection values
            ResetSelection();

            // Update backbuffer
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
                Rectangle rect = _targets.ToTargetRectangle();
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
                if (_targets != null && _targets.ToTargetRectangle().Contains(snap) == true)
                {
                    // Selection clicked
                    _moving = true;

                    // Set zero position
                    _pos.X = snap.X;
                    _pos.Y = snap.Y;
                }

                // If not moving a selection
                if (!_moving)
                {
                    // Dispose of old tile selection bitmap
                    if (_tileSelection != null)
                    {
                        _tileSelection.Dispose();
                        _tileSelection = null;
                    }

                    // Create a new brush
                    _targets = new GMareBrush();

                    // Start collecting tiles
                    _dragging = true;

                    // Set selection tile sector
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
                if (_targets == null || _targets.ToTargetRectangle().Contains(snap) == false)
                    return;

                // Show options menu
                mnuOptions.Show(this.PointToScreen(e.Location));
            }

            // Force redraw
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

            // If a selection exists, the mouse is within it's bounds, and currently not selecting, change to move cursor
            if (_targets != null && _targets.ToTargetRectangle().Contains(snap) == true && _dragging == false)
                this.Cursor = this.Cursor == Cursors.SizeAll ? this.Cursor : Cursors.SizeAll;
            else
                this.Cursor = this.Cursor == Cursors.Arrow ? this.Cursor : Cursors.Arrow;

            // If the backbuffer or tiles are empty, return
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

            // If selecting tiles
            if (_dragging == true)
            {
                // If selection is not within bounds, return
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

            // If the backbuffer or tiles are empty, return
            if (BackBuffer == null || _tiles == null || _tiles.Count == 0)
                return;

            // Get width based on column size versus the original size
            int width = _cols < _originalCols ? _max.Width * SnapSize.Width : TilesetWidth;
            
            // If selecting, and there are tiles selected
            if (_dragging && _targets != null)
            {
                // Stop selection operation
                _dragging = false;

                // Get an array of tile ids
                _targets.Tiles = GMareBrush.RectangleToTiles(_targets.ToTargetRectangle(), width, SnapSize);

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
                _tileSelection = GetImage().Clone(_targets.ToTargetRectangle(), PixelFormat.Format32bppArgb);

                // Create a copy of the selection for swapping
                _swaps = _targets.Clone();
            }

            // If the slection was moved and there are tiles
            if (_moving && _targets != null)
            {
                // Stop moving operation
                _moving = false;

                // Check tileset bounds
                if (new Rectangle(0, 0, TilesetWidth, TilesetHeight).Contains(_targets.ToTargetRectangle()) == false)
                {
                    // Reset to original selection, and return
                    _targets = _swaps;
                    _swaps = null;
                    Invalidate();
                    return;
                }

                // Get an array of selected tile ids
                _targets.Tiles = GMareBrush.RectangleToTiles(_targets.ToTargetRectangle(), width, SnapSize);

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
                SwapTiles(false);
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
            if (_targets == null || _targets.ToTargetRectangle().Contains(snap) == false)
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
            int cols = _max.Width;
            int rows = _rows <= _max.Height ? _rows : _max.Height;
            Point id = Point.Empty;
            // Iterate through rows
            for (int row = 0; row < rows; row++)
            {
                // Iterate through columns
                for (int col = 0; col < cols; col++)
                {
                    // If the tile is within bounds, and is not empty, draw tile
                    if (index < _tiles.Count && _tiles[index] != null)
                        gfx.DrawImageUnscaled(_tiles[index], (col * SnapSize.Width), (row * SnapSize.Height));

                    id.X = col * SnapSize.Width;
                    id.Y = row * SnapSize.Height;

                    // Draw tile ids
                    gfx.DrawString(_tiles[index].Tag.ToString(), Font, Brushes.Black, id.X - 1, id.Y);
                    gfx.DrawString(_tiles[index].Tag.ToString(), Font, Brushes.Black, id.X, id.Y - 1);
                    gfx.DrawString(_tiles[index].Tag.ToString(), Font, Brushes.Black, id.X + 1, id.Y);
                    gfx.DrawString(_tiles[index].Tag.ToString(), Font, Brushes.Black, id.X, id.Y + 1);
                    gfx.DrawString(_tiles[index].Tag.ToString(), Font, Brushes.Yellow, id);

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
        /// Swaps tiles from the selection grid
        /// </summary>
        private void SwapTiles(bool ignoreUpdate)
        {
            // If the targets or swaps grids are empty, return
            if (_targets == null || _swaps == null)
                return;

            // Get tile arrays
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

            // If not ignoring the update and there are listeners, the panel changed
            if (!ignoreUpdate && PanelChanged != null)
                PanelChanged();

            // Iterate through tiles
            for (int i = index; i != count; i += amount)
            {
                // New bitmaps
                Bitmap target = null;
                Bitmap swap = null;
                int targetId = targets[i];
                int swapId = swaps[i];

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
            if (!ignoreUpdate)
                UpdateBackBuffer();
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
            Bitmap tileset = new Bitmap(TilesetWidth, TilesetHeight, PixelFormat.Format32bppArgb);

            // Create graphics
            System.Drawing.Graphics gfx = System.Drawing.Graphics.FromImage(tileset);

            // Draw the tiles
            DrawTiles(gfx);

            // Return tileset
            return tileset;
        }

        /// <summary>
        /// Compiles the compiled tiles to a bitmap
        /// </summary>
        public Bitmap GetImage(Point offset, Size separation)
        {
            // If no tiles to draw, return nothing
            if (_tiles == null)
                return null;

            int width = TilesetWidth + (separation.Width * _cols) + offset.X;
            int height = TilesetHeight + (separation.Height * _rows) + offset.Y;

            // Create a new empty bitmap
            Bitmap tileset = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            // Create graphics
            System.Drawing.Graphics gfx = System.Drawing.Graphics.FromImage(tileset);

            // Tile indexer
            int index = 0;
            int offsetX = 0;
            int offsetY = 0;
            int cols = _max.Width;
            int rows = _rows <= _max.Height ? _rows : _max.Height;
            Rectangle rect = Rectangle.Empty;
            Point dest = Point.Empty;

            // Iterate through rows
            for (int row = 0; row < rows; row++)
            {
                // Iterate through columns
                for (int col = 0; col < cols; col++)
                {
                    // Calculate the destination
                    dest = new Point(col * SnapSize.Width, row * SnapSize.Height);
                    offsetX = (col * separation.Width) + offset.X;
                    offsetY = (row * separation.Height) + offset.Y;
                    rect = new Rectangle(dest.X + (col * separation.Width), dest.Y + (row * separation.Height), SnapSize.Width + separation.Width, SnapSize.Height + separation.Height);

                    // If the tile is within bounds, and is not empty, draw tile
                    if (index < _tiles.Count && _tiles[index] != null)
                        gfx.DrawImageUnscaled(_tiles[index], dest.X + offsetX, dest.Y + offsetY);

                    // Increment the indexer
                    index++;
                }
            }

            // Return tileset
            return tileset;
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

        /// <summary>
        /// Gets an empty image tile with the given tile id
        /// </summary>
        /// <param name="id">The tile id of the empty tile</param>
        /// <returns>An empty image tile</returns>
        private Bitmap GetEmptyTile(int id)
        {
            Bitmap tile = new Bitmap(SnapSize.Width, SnapSize.Height);
            tile.Tag = id;
            return tile;
        }

        #endregion
    }
}
