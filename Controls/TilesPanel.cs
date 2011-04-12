using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using GMare.Common;

namespace GMare.Controls
{
    public partial class TilesPanel : PanelEx
    {
        #region Fields

        public event PanelChangedHandler PanelChanged;     // Selected instance changed event.
        public delegate void PanelChangedHandler();        // Selected instance changed event handler.
        private Bitmap _backBuffer = null;                 // Rendering surface.
        private Bitmap _tileSelection = null;              // Tile selection bitmap.     
        private List<Bitmap> _tiles = null;                // Collection of tile images.
        private GMareBrush _targets = null;                // The target tiles.
        private GMareBrush _swaps = null;                  // The swapping tiles.
        private Size _tileSize = new Size(16, 16);         // The size of a single tile in pixels.
        private ColorMatrix _matrix = null;                // Grid color matrix.
        private ImageAttributes _atts = null;              // Grid image attributes.
        private Timer _antsTimer = new Timer();            // Marching ants timer.
        private Point _pos = Point.Empty;                  // Selection draw origin.
        private float[][] _elements = null;                // Grid color matrix elements.
        private float _scale = 1.0f;                       // Image scaling factor.
        private int _cols = 16;                            // The desired width of the tileset.
        private int _rows = 16;                            // The calculated rows.
        private int _antOffset = 0;                        // Marching ants offset.
        private bool _showGrid = true;                     // Whether to show the tile grid.
        private bool _dragging = false;                    // Whether the user is dragging a selection.
        private bool _moving = false;                      // Whther the user is moving the slection.

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the source image.
        /// </summary>
        public List<Bitmap> Tiles
        {
            get { return _tiles; }
            set
            {
                _tiles = value;

                // If a slection exists, empty it.
                if (_targets != null)
                    _targets = null;

                // Redraw the backbuffer.
                UpdateBackBuffer();
            }
        }

        /// <summary>
        /// Gets the compiled tileset combined into a bitmap.
        /// </summary>
        public Bitmap Image
        {
            get { return CompileTileset(); }
        }

        /// <summary>
        /// Gets or sets the tilesize of the tileset image.
        /// </summary>
        public Size TileSize
        {
            get { return _tileSize; }
            set { _tileSize = value; }
        }

        /// <summary>
        /// Gets or sets image scale amount.
        /// </summary>
        public float Zoom
        {
            get { return _scale; }
            set { _scale = value; Invalidate(); }
        }

        /// <summary>
        /// Sets the number of desired columns for the tileset.
        /// </summary>
        public int Columns
        {
            get { return _cols; }
            set
            {
                _cols = value;
                
                // If a slection exists, empty it.
                if (_targets != null)
                    _targets = null;

                // Redraw the backbuffer.
                UpdateBackBuffer();
            }
        }

        /// <summary>
        /// Get the width of tileset in pixels.
        /// </summary>
        public int TilesetWidth
        {
            get { return _cols * _tileSize.Width; }
        }

        /// <summary>
        /// Get the height of tileset in pixels.
        /// </summary>
        public int TilesetHeight
        {
            get { return _rows * _tileSize.Height; }
        }

        /// <summary>
        /// Gets or sets whether to show the cell grid.
        /// </summary>
        public bool ShowGrid
        {
            get { return _showGrid; }
            set { _showGrid = value; UpdateBackBuffer(); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new image panel.
        /// </summary>
        public TilesPanel()
        {
            InitializeComponent();

            // Set-up panel
            AutoScroll = true;
            BorderStyle = BorderStyle.Fixed3D;
            BackColor = Color.White;

            // Set control style.
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // Set color matrix elements.
            _elements = new float[][] {
                new float[] { -1,  0,  0,  0, 0 },
                new float[] { 0,  -1,  0,  0, 0 },
                new float[] { 0,  0,  -1,  0, 0 },
                new float[] { 0,  0,  0,  1,  0 },
                new float[] { 1,  1,  1,  0,  1 } };

            // Create new color matrix.
            _matrix = new ColorMatrix(_elements);

            // Create image attributes.
            _atts = new ImageAttributes();
            _atts.SetColorMatrix(_matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            // Update the backbuffer.
            UpdateBackBuffer();

            // Set timer interval.
            _antsTimer.Interval = 100;

            // Hook tick event.
            _antsTimer.Tick += new EventHandler(Timer_Tick);

            // Start mask blink timer.
            _antsTimer.Start();

            // Hook context menu events.
            tsmi_Clear.Click += new EventHandler(tsmi_Clear_Click);
            tsmi_Deselect.Click += new EventHandler(tsmi_Deselect_Click);
        }

        #endregion

        #region Events

        /// <summary>
        /// Deselect Tile(s) button click.
        /// </summary>
        private void tsmi_Deselect_Click(object sender, EventArgs e)
        {
            // Reset selection variables.
            ResetSelection();
        }

        /// <summary>
        /// Clears the selected tile(s) bitmap(s), not the tile id.
        /// </summary>
        private void tsmi_Clear_Click(object sender, EventArgs e)
        {
            // If targets are empty, return.
            if (_targets == null)
                return;

            // Panel changed.
            PanelChanged();

            // Get tile ids.
            int[] tiles = _targets.ToArray();

            // Iterate through tiles.
            foreach (int tile in tiles)
            {
                // If the tile is not already empty.
                if (_tiles[tile] != null)
                {
                    // Create a blank dummy tile.
                    Bitmap image = new Bitmap(_tiles[tile].Width, _tiles[tile].Height);
                    image.Tag = (int)_tiles[tile].Tag;

                    // Clear the tile.
                    _tiles[tile].Dispose();
                    _tiles[tile] = image;
                }
            }

            // Reset selection values.
            ResetSelection();

            // Update backbuffer.
            UpdateBackBuffer();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// On control paint.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            // If the backbuffer is empty, return.
            if (_backBuffer == null)
                return;
            
            // Get destination point.
            Point position = new Point((int)(-AutoScrollPosition.X), (int)(-AutoScrollPosition.Y));

            // Get destination rectangle.
            Rectangle dest = new Rectangle((int)(position.X / _scale), (int)(position.Y / _scale), ClientRectangle.Width, ClientRectangle.Height);

            // Get source rectangle.
            Rectangle src = new Rectangle(0, 0, _backBuffer.Width, _backBuffer.Height);

            this.AutoScrollMinSize = new Size((int)(TilesetWidth * _scale), (int)(TilesetHeight * _scale));

            // Clear the control.
            e.Graphics.Clear(BackColor);

            // Set correct offset for scaling.
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;

            // Nearest neighbor interpolation for no blurring.
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;

            // Scale all drawing.
            e.Graphics.ScaleTransform(_scale, _scale);

            // Draw image.
            e.Graphics.DrawImage(_backBuffer, ClientRectangle, dest.X, dest.Y, dest.Width, dest.Height, GraphicsUnit.Pixel);

            // Reset pixel offset mode
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;

            e.Graphics.Clip = new System.Drawing.Region(new Rectangle(0, 0, TilesetWidth, TilesetHeight));

            // If a tile has been selected for swapping, draw the selection rectangle.
            if (_targets != null)
            {
                // Calculate rectangle with scroll offset.
                Rectangle rect = _targets.ToRectangle();
                rect.X -= (int)(position.X / _scale);
                rect.Y -= (int)(position.Y / _scale);

                // Draw selection rectangle.
                DrawSelection(e.Graphics, rect);
            }
        }

        /// <summary>
        /// On mouse down.
        /// </summary>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Allow hooking of this event.
            base.OnMouseDown(e);

            // If the project and tileset do not exist, return.
            if (_backBuffer == null || _tiles == null || _tiles.Count == 0)
                return;

            // Focus for scroll support.
            Focus();

            // Get start snapped position.
            Point snap = GetSnappedPoint(e.Location);

            // Check if the click is within bounds.
            if (new Rectangle(0, 0, TilesetWidth, TilesetHeight).Contains(snap) == false)
                return;

            // If left button was clicked, and there are tiles to select.
            if (e.Button == MouseButtons.Left && _tiles != null)
            {
                // If cursor is within selection.
                if (_targets != null && _targets.ToRectangle().Contains(snap) == true)
                {
                    // Selection clicked.
                    _moving = true;

                    // Set zero position.
                    _pos.X = snap.X;
                    _pos.Y = snap.Y;
                }

                // If not moving a selection.
                if (_moving == false)
                {
                    // Dispose of old bitmap.
                    if (_tileSelection != null)
                    {
                        _tileSelection.Dispose();
                        _tileSelection = null;
                    }

                    // Create a new tile grid.
                    _targets = new GMareBrush();

                    // Start collecting other tiles.
                    _dragging = true;

                    // Set selection tile sector.
                    _targets.StartX = snap.X;
                    _targets.StartY = snap.Y;
                    _targets.EndX = _targets.StartX + _tileSize.Width;
                    _targets.EndY = _targets.StartY + _tileSize.Height;
                }
            }

            // If right button was clicked.
            if (e.Button == MouseButtons.Right)
            {
                // Empty selection.
                if (_targets == null || _targets.ToRectangle().Contains(snap) == false)
                    return;

                // Show options menu.
                cms_Options.Show(this.PointToScreen(e.Location));
            }

            // Force redraw.
            Invalidate();
        }

        /// <summary>
        /// On mouse move.
        /// </summary>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // Allow hooking of this event.
            base.OnMouseMove(e);

            // Calculate snapped tile position.
            Point snap = GetSnappedPoint(e.Location);

            // If a selection exists, and within it's bounds.
            if (_targets != null && _targets.ToRectangle().Contains(snap) == true)
                this.Cursor = Cursors.SizeAll;
            else
                this.Cursor = Cursors.Arrow;

            // If the project and tileset do not exist, return.
            if (_backBuffer == null || _tiles == null || _tiles.Count == 0)
                return;

            // If a selection exists, cursor is within selection rectangle, and not dragging selection rectangle.
            if (_targets != null && _targets.ToRectangle().Contains(snap) == true && _dragging == false)
                this.Cursor = Cursors.SizeAll;
            else
                this.Cursor = Cursors.Arrow;

            // If moving a selection.
            if (_moving == true)
            {
                // If there is a change in snapped position since last movement.
                if (snap.X != _pos.X || snap.Y != _pos.Y)
                {
                    // Calculate move amount.
                    Point pos = new Point(snap.X - _pos.X, snap.Y - _pos.Y);

                    // Set check to new value.
                    _pos.X = snap.X;
                    _pos.Y = snap.Y;

                    // Set selection position.
                    _targets.StartX += pos.X;
                    _targets.StartY += pos.Y;
                    _targets.EndX += pos.X;
                    _targets.EndY += pos.Y;

                    // Force redraw.
                    Invalidate();
                }
            }

            // If dragging a rubberband rectangle.
            if (_dragging == true)
            {
                // If drag is not within bounds, return.
                if (!new Rectangle(0, 0, TilesetWidth, TilesetHeight).Contains(snap))
                    return;

                // If the snapped x is greater than the start x, add an extra tile width to contain the mouse cursor.
                if (snap.X >= _targets.StartX)
                    snap.X += _tileSize.Width;

                // If the snapped y is greater than the start y, add an extra tile height to contain the mouse cursor.
                if (snap.Y >= _targets.StartY)
                    snap.Y += _tileSize.Height;

                // If there is a change in snapped position since last movement.
                if (snap.X != _targets.EndX || snap.Y != _targets.EndY)
                {
                    // If the end x coordinate is not equal to the start x coordinate, set it.
                    if (snap.X != _targets.StartX)
                        _targets.EndX = snap.X;

                    // If the end y coordinate is not equal to the start y coordinate, set it.
                    if (snap.Y != _targets.StartY)
                        _targets.EndY = snap.Y;

                    // Force redraw.
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// On mouse up.
        /// </summary>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            // Allow others to hook this event.
            base.OnMouseUp(e);

            // If the project and tileset do not exist, return.
            if (_backBuffer == null || _tiles == null || _tiles.Count == 0)
                return;

            // Stop dragging operation.
            if (_dragging == true && _targets != null)
            {
                // Stop dragging operation.
                _dragging = false;

                // Get an array of tile ids.
                _targets.Tiles = GMareBrush.RectangleToTiles(_targets.ToRectangle(), TilesetWidth, _tileSize);

                // Get target tiles.
                int[] tiles = _targets.ToArray();

                // Check if all selected tiles are valid.
                foreach (int tile in tiles)
                {
                    // If the tile id is out of bounds.
                    if (tile < 0 || tile >= _tiles.Count)
                    {
                        // Reset selection, and return.
                        ResetSelection();
                        return;
                    }
                }

                // Set tile selection graphic.
                _tileSelection = (Bitmap)CompileTileset().Clone(_targets.ToRectangle(), PixelFormat.Format32bppPArgb);

                // Create a copy of the selection for swapping.
                _swaps = _targets.Clone();
            }

            // Set and swap tile bitmaps.
            if (_moving && _targets != null)
            {
                // Stop moving operation.
                _moving = false;

                // Check tileset bounds.
                if (new Rectangle(0, 0, TilesetWidth, TilesetHeight).Contains(_targets.ToRectangle()) == false)
                {
                    // Reset to original selection, and return.
                    _targets = _swaps;
                    _swaps = null;
                    Invalidate();
                    return;
                }

                // Get an array of selected tile ids.
                _targets.Tiles = GMareBrush.RectangleToTiles(_targets.ToRectangle(), TilesetWidth, _tileSize);

                // Get new target tiles.
                int[] tiles = _targets.ToArray();

                // Check to see if the drop is valid.
                foreach (int tile in tiles)
                {
                    // If the tile id is out of bounds.
                    if (tile < 0 || tile >= _tiles.Count)
                    {
                        // Reset to original selection, and return.
                        _targets = _swaps;
                        _swaps = null;
                        Invalidate();
                        return;
                    }
                }

                // Swap tiles.
                SwapTiles();
            }
        }

        /// <summary>
        /// On client size changed.
        /// </summary>
        protected override void OnClientSizeChanged(EventArgs e)
        {
            // Update drawing.
            UpdateBackBuffer();
        }

        /// <summary>
        /// On control scroll.
        /// </summary>
        protected override void OnScroll(ScrollEventArgs e)
        {
            // Redraw the control.
            Invalidate();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the backbuffer.
        /// </summary>
        private void UpdateBackBuffer()
        {
            // Create graphics.
            System.Drawing.Graphics gfx = this.CreateGraphics();

            // Dispose of previous backbuffer, uses insane ram if not done.
            if (_backBuffer != null)
                _backBuffer.Dispose();

            // If the edit room exists and edit room has a background.
            if (_tiles != null && _tiles.Count > 0)
            {
                // Calculate the rows of the tileset.
                _rows = (int)Math.Ceiling((double)_tiles.Count / (double)_cols);

                // Set-up the backbuffer.
                Size backBufferSize = CalculateSize(TilesetWidth, TilesetHeight);
                _backBuffer = new Bitmap(backBufferSize.Width, backBufferSize.Height, PixelFormat.Format32bppPArgb);
                _backBuffer.SetResolution(gfx.DpiX, gfx.DpiY);
                
                // Create graphics based on new backbuffer.
                gfx = System.Drawing.Graphics.FromImage(_backBuffer);

                // Fill the backbuffer.
                gfx.FillRectangle(new TextureBrush(GMare.Properties.Resources.background), 0, 0, _backBuffer.Width, _backBuffer.Height);

                // Draw tiles.
                DrawTiles(gfx);

                // If the cell grid should be shown.
                if (_showGrid == true)
                    DrawGrid(gfx);
            }
            else  // If no image, clear backbuffer.
            {
                // Reset Zoom.
                _scale = 1;

                // Calculate the position of the text, which is the center of the control.
                string text = "- No tiles compiled -";
                SizeF size = gfx.MeasureString(text, Font);
                int x = (int)((ClientSize.Width / 2) - (size.Width / 2));
                int y = (int)((ClientSize.Height / 2) - (size.Height / 2));

                // Create new backbuffer the size of the client area.
                _backBuffer = new Bitmap(ClientSize.Width, ClientSize.Height, PixelFormat.Format32bppPArgb);

                // Create new graphics device from backbuffer.
                gfx = System.Drawing.Graphics.FromImage(_backBuffer);

                // Checkerboard background.
                gfx.Clear(Color.White);
                gfx.DrawString(text, this.Font, Brushes.Gray, x, y);
            }

            // Dispose.
            gfx.Dispose();

            // Force redraw.
            Invalidate();
        }

        /// <summary>
        /// Draws all the tiles.
        /// </summary>
        private void DrawTiles(System.Drawing.Graphics gfx)
        {
            // Tile indexer.
            int index = 0;

            // Iterate through rows.
            for (int row = 0; row < _rows; row++)
            {
                // Iterate through columns.
                for (int col = 0; col < _cols; col++)
                {
                    // If the tile is within bounds, and is not empty, draw tile.
                    if (index < _tiles.Count && _tiles[index] != null)
                        gfx.DrawImageUnscaled(_tiles[index], (col * _tileSize.Width), (row * _tileSize.Height));

                    // Increment the indexer.
                    index++;
                }
            }
        }

        /// <summary>
        /// Draw grid cells.
        /// </summary>
        private void DrawGrid(System.Drawing.Graphics gfx)
        {
            // Save state.
            GraphicsState state = gfx.Save();

            // Created invert pen.
            Pen pen = new Pen(Color.Red);

            // Get rendering rectangle.
            Rectangle rect = new Rectangle(0, 0, _backBuffer.Width, _backBuffer.Height);

            // Create a new graphics path for inverted lines.
            GraphicsPath path = new GraphicsPath(FillMode.Alternate);

            // Iterate through vertical tiles.
            for (int row = 0; row < _rows; row++)
            {
                // Iterate through horizontal tiles.
                for (int col = 0; col < _cols; col++)
                {
                    // Get position coordinates.
                    int x = (int)col * _tileSize.Width;
                    int y = (int)row * _tileSize.Height;

                    // Add rectangle path.
                    path.AddRectangle(new Rectangle(x, y, _tileSize.Width, _tileSize.Height));
                }
            }

            // Widen the path with pen.
            path.Widen(pen);

            // Create new region.
            Region region = new Region(path);
            
            // Set the region.
            gfx.Clip = region;

            // Draw the backbuffer image.
            gfx.DrawImage(_backBuffer, rect, 0, 0, rect.Width, rect.Height, GraphicsUnit.Pixel, _atts);
            
            // Restore the graphics state to non-inverted.
            gfx.Restore(state);
            
            // Dispose of all temp objects.
            region.Dispose();
            pen.Dispose();
        }

        /// <summary>
        /// Draws the selected tiles rectangles.
        /// </summary>
        private void DrawSelection(System.Drawing.Graphics gfx, Rectangle rect)
        {
            // Create a new pen.
            Pen pen = new Pen(Color.White, 1);
            pen.DashStyle = DashStyle.Dash;
            pen.DashPattern = new float[2] { 4, 4 };
            pen.DashOffset = _antOffset;

            // Offset depending on scale.
            if (_scale == 1)
            {
                rect.Width -= 1;
                rect.Height -= 1;
            }

            // Draw tile selection.
            if (_tileSelection != null)
                gfx.DrawImage(_tileSelection, rect.Location);

            // Draw marching ants rectangle.
            gfx.DrawRectangle(Pens.Black, rect);
            gfx.DrawRectangle(pen, rect);

            // Dispose.
            pen.Dispose();
        }

        /// <summary>
        /// Compiles the compiled tiles to a bitmap.
        /// </summary>
        private Bitmap CompileTileset()
        {
            // If no tiles to draw, return nothing.
            if (_tiles == null)
                return null;

            // Create a new empty bitmap.
            Bitmap tileset = new Bitmap(TilesetWidth, TilesetHeight, PixelFormat.Format32bppPArgb);
            
            // Create graphics.
            System.Drawing.Graphics gfx = System.Drawing.Graphics.FromImage(tileset);

            // Draw tiles to tileset bitmap.
            DrawTiles(gfx);

            // Return tileset.
            return tileset;
        }

        /// <summary>
        /// Gets the backbuffer size
        /// </summary>
        private Size CalculateSize(int width, int height)
        {
            // New backbuffer size
            Size backBufferSize = new Size(width, height);

            // Set the backbuffer size
            if (backBufferSize.Width < ClientSize.Width)
                backBufferSize.Width = ClientSize.Width;

            if (backBufferSize.Height < ClientSize.Height)
                backBufferSize.Height = ClientSize.Height;

            // Return backbuffer size
            return backBufferSize;
        }

        /// <summary>
        /// Gets a snapped point from a point.
        /// </summary>
        /// <param name="position">Point to use as snapping origin.</param>
        /// <returns>A grid snapped point.</returns>
        private Point GetSnappedPoint(Point position)
        {
            int width = (int)(_tileSize.Width * _scale);
            int height = (int)(_tileSize.Height * _scale);
            int x = (int)((((position.X - AutoScrollPosition.X) / width) * width) / _scale);
            int y = (int)((((position.Y - AutoScrollPosition.Y) / height) * height) / _scale);

            return new Point(x, y);
        }

        /// <summary>
        /// Swaps tiles from the selection grid.
        /// </summary>
        private void SwapTiles()
        {
            // If the targets or swaps grids are empty, return.
            if (_targets == null || _swaps == null)
                return;

            // Get tile arrays.
            int[] targets = _targets.ToArray();
            int[] swaps = _swaps.ToArray();

            // If the swaps are the same as the targets, return.
            if (swaps[0] == targets[0])
                return;

            // Variables for correct swapping order.
            int index = 0;
            int amount = 1;
            int count = targets.Length;

            // If the swap origin is less than the target origin.
            if (swaps[0] < targets[0])
            {
                // Iterate backwards for the proper ordering.
                amount = -1;
                count = -1;
                index = targets.Length - 1;
            }

            // Panel changed.
            PanelChanged();

            // Iterate through tiles.
            for (int i = index; i != count; i += amount)
            {
                // New bitmaps.
                Bitmap target = null;
                Bitmap swap = null;

                // If the tile is not empty, copy it.
                if (_tiles[swaps[i]] != null)
                {
                    swap = (Bitmap)_tiles[swaps[i]].Clone();
                    swap.Tag = (int)_tiles[swaps[i]].Tag;
                    _tiles[swaps[i]].Dispose();
                }

                // If the tile is not empty, copy it.
                if (_tiles[targets[i]] != null)
                {
                    target = (Bitmap)_tiles[targets[i]].Clone();
                    target.Tag = (int)_tiles[targets[i]].Tag;
                    _tiles[targets[i]].Dispose();
                }

                // Swap tiles.
                _tiles[targets[i]] = swap;
                _tiles[swaps[i]] = target;
            }

            // Reset selection.
            ResetSelection();

            // Redraw backbuffer.
            UpdateBackBuffer();
        }

        /// <summary>
        /// Marching ants timer tick.
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Increase offset.
            _antOffset++;

            // If at maximum offset, reset offset.
            if (_antOffset % 8 == 0)
                _antOffset = 0;

            // As long as there is a target selection, force redraw.
            if (_targets != null)
                Invalidate();
        }

        /// <summary>
        /// Resets selection variables.
        /// </summary>
        private void ResetSelection()
        {
            // Empty selections.
            _targets = null;
            _swaps = null;

            // If the tile selection is not empty, dispose and empty.
            if (_tileSelection != null)
            {
                _tileSelection.Dispose();
                _tileSelection = null;
            }

            // Force redraw.
            Invalidate();
        }

        #endregion
    }
}