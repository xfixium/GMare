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

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace GMare.Controls
{
    /// <summary>
    /// A control that draws image data with scaling, blinking transparent color, as well as a xor grid.
    /// </summary>
    public partial class ImagePanel : PanelEx
    {
        #region Fields

        private Bitmap _backBuffer = null;          // Rendering service.
        private Bitmap _image = null;               // Image bitmap.
        private Color _colorKey = Color.Black;      // Color key of the image, if used.
        private Timer _blinkTimer = new Timer();    // Blink timer when blinking.
        private Size _tileSize = new Size(16, 16);  // The size of a single tile in pixels.
        private ColorMatrix _matrix = null;         // Grid color matrix.
        private ImageAttributes _atts = null;       // Grid image attributes.
        private float[][] _elements = null;         // Grid color matrix elements.
        private bool _showGrid = true;              // Whether to show the tile grid.
        private bool _setKey = false;               // Whether to set a color key.
        private bool _blink = false;                // Whether the color key color should blink.
        private int _offsetX = 0;                   // Tile horizontal offset.
        private int _offsetY = 0;                   // Tile vertical offset.
        private int _seperationX = 0;               // Tile horizontal seperation.
        private int _seperationY = 0;               // Tile vertical seperation.
        private float _scale = 1.0f;                // Magnification factor.

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets whether to show the cell grid.
        /// </summary>
        public bool ShowGrid
        {
            get { return _showGrid; }
            set { _showGrid = value; UpdateBackBuffer(); }
        }

        /// <summary>
        /// Gets or sets the source image.
        /// </summary>
        public Bitmap Image
        {
            get { return _image; }
            set
            {
                _image = value;

                // If there is an image, set the correct resolution.
                if (_image != null)
                {
                    System.Drawing.Graphics gfx = this.CreateGraphics();
                    _image.SetResolution(gfx.DpiX, gfx.DpiY);
                    gfx.Dispose();
                }

                UpdateBackBuffer();
            }
        }

        /// <summary>
        /// Gets or sets the color key.
        /// </summary>
        public Color ColorKey
        {
            get { return _colorKey; }
        }

        /// <summary>
        /// Gets or sets the tilesize of the tileset image.
        /// </summary>
        public Size TileSize
        {
            get { return _tileSize; }
            set { _tileSize = value; UpdateBackBuffer(); }
        }

        /// <summary>
        /// Gets or sets if the mask color should blink.
        /// </summary>
        public bool Blink
        {
            get { return _blink; }
            set { _blink = value; SetColorKey(); }
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
        /// Gets or sets the horizontal cell offset.
        /// </summary>
        public int OffsetX
        {
            get { return _offsetX; }
            set { _offsetX = value; UpdateBackBuffer(); }
        }

        /// <summary>
        /// Gets or sets the vertical cell offset.
        /// </summary>
        public int OffsetY
        {
            get { return _offsetY; }
            set { _offsetY = value; UpdateBackBuffer(); }
        }

        /// <summary>
        /// Gets or sets the horizontal cell seperation.
        /// </summary>
        public int SeperationX
        {
            get { return _seperationX; }
            set { _seperationX = value; UpdateBackBuffer(); }
        }

        /// <summary>
        /// Gets or sets the vertical cell seperation.
        /// </summary>
        public int SeperationY
        {
            get { return _seperationY; }
            set { _seperationY = value; UpdateBackBuffer(); }
        }

        /// <summary>
        /// Sets the color timer.
        /// </summary>
        public Timer BlinkTimer
        {
            get { return _blinkTimer; }
            set { _blinkTimer = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new image panel.
        /// </summary>
        public ImagePanel()
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
            _blinkTimer.Interval = 500;

            // Hook tick event.
            _blinkTimer.Tick += new EventHandler(BlinkTimer_Tick);

            // Start mask blink timer.
            _blinkTimer.Start();
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
            Point position = new Point(-AutoScrollPosition.X, -AutoScrollPosition.Y);

            // Get destination rectangle.
            Rectangle dest = new Rectangle((int)(position.X / _scale), (int)(position.Y / _scale), ClientRectangle.Width, ClientRectangle.Height);

            // Get source rectangle.
            Rectangle src = new Rectangle(0, 0, _backBuffer.Width, _backBuffer.Height);

            // Copy backbuffer section.
            Bitmap image = _backBuffer.Clone(src, _backBuffer.PixelFormat);

            // If there is a color key, and toggled to set key, make the image transaprent.
            if (_blink == true && _setKey == true)
                image.MakeTransparent(_colorKey);

            // If an image does not exist, set autoscroll size for backbuffer else, set for image.
            if (_image != null)
                AutoScrollMinSize = new Size((int)(_image.Width * _scale), (int)(_image.Height * _scale));
            else
                AutoScrollMinSize = new Size((int)(_backBuffer.Width), (int)(_backBuffer.Height));

            // Clear the control.
            e.Graphics.Clear(BackColor);

            // Set correct offset for scaling.
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;

            // Create clipping region.
            e.Graphics.Clip = new System.Drawing.Region(new Rectangle(0, 0, this.AutoScrollMinSize.Width, this.AutoScrollMinSize.Height));

            // Nearest neighbor interpolation for no blurring.
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;

            // Scale all drawing.
            e.Graphics.ScaleTransform(_scale, _scale);

            // Draw image.
            e.Graphics.DrawImage(image, ClientRectangle, dest.X, dest.Y, dest.Width, dest.Height, GraphicsUnit.Pixel);
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
        public void UpdateBackBuffer()
        {
            // Create graphics.
            System.Drawing.Graphics gfx = null;

            // Dispose of previous backbuffer, uses insane ram if not done.
            if (_backBuffer != null)
                _backBuffer.Dispose();

            // If the edit room exists and edit room has a background.
            if (_image != null)
            {
                // Set-up the backbuffer.
                Size backBufferSize = CalculateSize(_image.Width, _image.Height);
                _backBuffer = new Bitmap(backBufferSize.Width, backBufferSize.Height, PixelFormat.Format32bppPArgb);
                gfx = System.Drawing.Graphics.FromImage(_backBuffer);

                // Fill back buffer with checkered background.
                gfx.FillRectangle(new TextureBrush(GMare.Properties.Resources.background), 0, 0, _backBuffer.Width, _backBuffer.Height);

                // Draw the image to the buffer.
                gfx.DrawImage(_image, Point.Empty);

                // If the cell grid should be shown.
                if (_showGrid == true)
                    DrawGrid(gfx);
            }
            else  // If no image, clear backbuffer.
            {
                // Create new backbuffer the size of the client area.
                _backBuffer = new Bitmap(ClientSize.Width, ClientSize.Height, PixelFormat.Format32bppPArgb);

                // Create new graphics device from backbuffer.
                gfx = System.Drawing.Graphics.FromImage(_backBuffer);

                // Fill back buffer with checkered background.
                gfx.FillRectangle(new TextureBrush(GMare.Properties.Resources.background), 0, 0, _backBuffer.Width, _backBuffer.Height);
            }

            // Dispose.
            if (gfx != null)
                gfx.Dispose();

            // Force redraw.
            Invalidate();
        }

        /// <summary>
        /// Draw tiled cells.
        /// </summary>
        private void DrawGrid(System.Drawing.Graphics gfx)
        {
            // Save state.
            GraphicsState state = gfx.Save();

            // Create pen.
            Pen pen = new Pen(Color.Red);

            // Get rendering rectangle.
            Rectangle rect = new Rectangle(0, 0, _backBuffer.Width, _backBuffer.Height);

            // Create a new graphics path for inverted lines.
            GraphicsPath path = new GraphicsPath(FillMode.Alternate);

            // Calculate row and column amounts.
            int cols = (int)Math.Floor((double)(_image.Width - _offsetX) / (double)(_tileSize.Width + _seperationX));
            int rows = (int)Math.Floor((double)(_image.Height - _offsetY) / (double)(_tileSize.Height + _seperationY));

            // Iterate through vertical tiles.
            for (int row = 0; row < rows; row++)
            {
                // Iterate through horizontal tiles.
                for (int col = 0; col < cols; col++)
                {
                    // Get position coordinates.
                    int x = (int)(double)(col * _tileSize.Width + col * _seperationX) + _offsetX;
                    int y = (int)(double)(row * _tileSize.Height + row * _seperationY) + _offsetY;

                    // Add rectangle path.
                    path.AddRectangle(new Rectangle(x, y, _tileSize.Width - 1, _tileSize.Height - 1));
                }
            }

            // Path widen.
            path.Widen(pen);

            // Create new region from path.
            Region region = new Region(path);

            // Set the clip region.
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
        /// On blink timer tick.
        /// </summary>
        private void BlinkTimer_Tick(object sender, EventArgs e)
        {
            // Toggle blinker.
            _setKey = _setKey ? false : true;

            // Redraw control.
            Invalidate();
        }

        /// <summary>
        /// Gets a pixel from the loaded image.
        /// </summary>
        /// <param name="x">X pixel coordinate.</param>
        /// <param name="y">Y pixel coordinate.</param>
        private void SetColorKey()
        {
            // If no image has been loaded, return.
            if (_image == null)
                return;

            // Get color from image.
            _colorKey = _image.GetPixel(0, _image.Height - 1);
        }

        #endregion
    }
}
