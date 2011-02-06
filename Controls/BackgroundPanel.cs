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
using GMare.Common;

namespace GMare.Controls
{
    /// <summary>
    /// A control that draws an image set be used as a tileset. Draws a rubber rectangle for tile selection.
    /// </summary>
    public partial class BackgroundPanel : PanelEx
    {
        #region Fields

        /// <summary>
        /// Tile selecion methods.
        /// </summary>
        public enum SelectType
        {
            Normal,
            Fixed
        };
        private SelectType _selectMode = SelectType.Normal;  // Mode of the tileset panel.
        private TileGrid _selection = new TileGrid();        // Selection of tiles.
        private Bitmap _backBuffer = null;                   // The drawing surface.
        private Bitmap _image = null;                        // The tileset image.
        private float _scale = 1.0f;                         // Scaling factor.
        private bool _dragging = false;                      // Whether in a dragging operation.

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the selection mode.
        /// </summary>
        public SelectType SelectMode
        {
            get { return _selectMode; }
            set { _selectMode = value; }
        }

        /// <summary>
        /// Gets or sets selection rectangle.
        /// </summary>
        public TileGrid Selection
        {
            get { return _selection; }
            set { _selection = value; UpdateBackBuffer(); }
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

                // Reset selection.
                OnMouseDown(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                OnMouseUp(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));

                // Redraw the backbuffer.
                UpdateBackBuffer();
            }
        }

        /// <summary>
        /// Gets or sets image scale amount.
        /// </summary>
        public float Zoom
        {
            get { return _scale; }
            set { _scale = value; Invalidate(); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new image panel.
        /// </summary>
        public BackgroundPanel()
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

            // Update the backbuffer.
            UpdateBackBuffer();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// OnPaint.
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

            // If an image does not exist, set autoscroll size for backbuffer else, set for image.
            if (_image != null)
                AutoScrollMinSize = new Size((int)(_image.Width * _scale), (int)(_image.Height * _scale));
            else
                AutoScrollMinSize = new Size((int)(_backBuffer.Width), (int)(_backBuffer.Height));

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
        }

        /// <summary>
        /// OnMouseDown.
        /// </summary>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Allow hooking of this event.
            base.OnMouseDown(e);

            // If the project and tileset do not exist, return.
            if (ProjectManager.Room == null || _image == null)
                return;

            // Focus for scroll support.
            Focus();

            // Get start snapped position.
            Point snap = GetSnappedPoint(e.Location);

            // If the mouse is within the image dimensions.
            if (!new Rectangle(0, 0, _image.Width, _image.Height).Contains(snap))
                return;

            // Get tile size.
            Size tileSize = ProjectManager.Room.TileSize;

            // If in normal selection mode.
            if (_selectMode == SelectType.Normal)
            {
                // Set selection tile sector.
                _selection.StartX = snap.X;
                _selection.StartY = snap.Y;
                _selection.EndX = _selection.StartX + tileSize.Width;
                _selection.EndY = _selection.StartY + tileSize.Height;

                // Allow dragging operation.
                _dragging = true;
            }
            else
            {
                // Set selection position.
                _selection.EndX = snap.X + _selection.Width;
                _selection.EndY = snap.Y + _selection.Height;
                _selection.StartX = snap.X;
                _selection.StartY = snap.Y;

                // If the selection is out of bounds, reposition till it is not.
                while (true)
                {
                    // If the selection is out of bounds horizontally, shift points.
                    if (_selection.EndX > _image.Width)
                    {
                        _selection.StartX -= tileSize.Width;
                        _selection.EndX -= tileSize.Width;
                    }

                    // If the selection is out of bounds vertically, shift points.
                    if (_selection.EndY > _image.Height)
                    {
                        _selection.StartY -= tileSize.Height;
                        _selection.EndY -= tileSize.Height;
                    }

                    // If within bounds, break.
                    if (new Rectangle(0, 0, _image.Width, _image.Height).Contains(_selection.ToRectangle()) == true)
                        break;
                }
            }

            // Update backbuffer.
            UpdateBackBuffer();
        }

        /// <summary>
        /// OnMouseMove.
        /// </summary>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // Allow hooking of this event.
            base.OnMouseMove(e);

            // If the project and tileset do not exist, and we're not tracking cursor changes return.
            if (ProjectManager.Room == null || _image == null || _dragging == false)
                return;

            // Calculate snapped tile position.
            Point snap = GetSnappedPoint(e.Location);

            // If the mouse is within the image dimensions.
            if (!new Rectangle(0, 0, _image.Width, _image.Height).Contains(snap))
                return;

            // If the snapped x is greater than the start x, add an extra tile width to contain the mouse cursor.
            if (snap.X >= _selection.StartX)
                snap.X += ProjectManager.Room.TileWidth;

            // If the snapped y is greater than the start y, add an extra tile height to contain the mouse cursor.
            if (snap.Y >= _selection.StartY)
                snap.Y += ProjectManager.Room.TileHeight;

            // If there is a change in snapped position since last movement.
            if (snap.X != _selection.EndX || snap.Y != _selection.EndY)
            {
                // If the end x coordinate is not equal to the start x coordinate, set it.
                if (snap.X != _selection.StartX)
                    _selection.EndX = snap.X;

                // If the end y coordinate is not equal to the start y coordinate, set it.
                if (snap.Y != _selection.StartY)
                    _selection.EndY = snap.Y;

                // Update drawing.
                UpdateBackBuffer();
            }
        }

        /// <summary>
        /// OnMouseUp.
        /// </summary>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            // Stop drawing.
            _dragging = false;

            // If the project and tileset do not exist, return.
            if (ProjectManager.Room == null || _image == null)
                return;

            // Get an array of tile ids.
            _selection.TileIds = TileGrid.RectangleToTileIds(_selection.ToRectangle(), _image.Width, ProjectManager.Room.TileSize);

            if (_selectMode == SelectType.Fixed)
                UpdateBackBuffer();

            // Allow others to hook this event.
            base.OnMouseUp(e);
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
            base.OnScroll(e);

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
            // If the client size is too small to create a backbuffer for, return.
            if (ClientSize.Width <= 0 || ClientSize.Height <= 0)
                return;

            // Create graphics.
            System.Drawing.Graphics gfx = this.CreateGraphics();

            // Dispose of previous backbuffer, uses insane ram if not done.
            if (_backBuffer != null)
                _backBuffer.Dispose();

            // If the edit room exists and edit room has a background.
            if (_image != null)
            {
                // Set GDI+ resolution.
                _image.SetResolution(gfx.DpiX, gfx.DpiY);

                // Set-up the backbuffer.
                Size backBufferSize = CalculateSize(_image.Width, _image.Height);
                _backBuffer = new Bitmap(backBufferSize.Width, backBufferSize.Height, PixelFormat.Format32bppPArgb);
                gfx = System.Drawing.Graphics.FromImage(_backBuffer);

                // Draw the image to the buffer.
                gfx.DrawImageUnscaled(_image, new Point(0, 0));

                // Draw selection rectangle.
                DrawSelection(gfx);
            }
            else  // If no image, clear backbuffer.
            {
                // Create new backbuffer the size of the client area.
                _backBuffer = new Bitmap(ClientSize.Width, ClientSize.Height, PixelFormat.Format32bppArgb);

                // Create new graphics device from backbuffer.
                gfx = System.Drawing.Graphics.FromImage(_backBuffer);
            }

            // Dispose
            gfx.Dispose();

            // Force redraw
            Invalidate();
        }

        /// <summary>
        /// Draws a selection rectyangle.
        /// </summary>
        /// <param name="gfx">Graphics object used to render.</param>
        private void DrawSelection(System.Drawing.Graphics gfx)
        {
            // Get selection rectangle.
            Rectangle rect = _selection.ToRectangle();

            // Offset rectangle.
            rect.Width -= 1;
            rect.Height -= 1;

            // Draw selection rectangle.
            gfx.DrawRectangle(Pens.Black, rect);

            // Offset rectangle.
            rect.X += 1;
            rect.Y += 1;
            rect.Width -= 2;
            rect.Height -= 2;

            // Draw selection rectangle.
            gfx.DrawRectangle(Pens.White, rect);

            // Offset rectangle.
            rect.X += 1;
            rect.Y += 1;
            rect.Width -= 2;
            rect.Height -= 2;

            // Draw selection rectangle.
            gfx.DrawRectangle(Pens.Black, rect);
        }

        /// <summary>
        /// Determines the size of the backbuffer.
        /// </summary>
        /// <param name="width">The width of the backbuffer.</param>
        /// <param name="height">The height of the backbuffer.</param>
        /// <returns>The calculated backbuffer size.</returns>
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
        /// Calculates a snapped version of a point.
        /// </summary>
        /// <param name="position">The point to calculate.</param>
        /// <returns>A snapped point.</returns>
        private Point GetSnappedPoint(Point position)
        {
            // Calculate snapped position.
            Size tileSize = ProjectManager.Room.TileSize;
            int width = (int)(tileSize.Width * _scale);
            int height = (int)(tileSize.Height * _scale);
            int x = (int)((((position.X - AutoScrollPosition.X) / width) * width) / _scale);
            int y = (int)((((position.Y - AutoScrollPosition.Y) / height) * height) / _scale);

            return new Point(x, y);
        }

        #endregion
    }
}