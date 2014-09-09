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
using GMare.Objects;
using Pyxosoft.Windows.Tools.PyxTools.Controls;

namespace GMare.Controls
{
    /// <summary>
    /// A control that uses a background like a tileset
    /// </summary>
    public partial class GMareBackgroundPanel : PyxPictureBox
    {
        #region Enums

        /// <summary>
        /// Tile selecion methods
        /// </summary>
        public enum SelectType
        {
            Normal,
            Fixed
        };

        #endregion

        #region Fields

        private ToolTip _tileIdTip = new ToolTip();
        private SelectType _selectMode = SelectType.Normal;  // Mode of the tileset panel
        private GMareBrush _tileBrush = null;                // Tile brush
        private GMareBrush _highlighter = null;              // Tile highlight brush
        private Rectangle _selection = new Rectangle();      // Selection rectangle
        private Point _origin = Point.Empty;                 // Origin point of the selection
        private bool _avoidMouseEvents = false;              // If avoiding mouse events

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the selection mode
        /// </summary>
        public SelectType SelectMode
        {
            get { return _selectMode; }
            set { _selectMode = value; }
        }

        /// <summary>
        /// Gets or sets selection rectangle
        /// </summary>
        public GMareBrush TileBrush
        {
            get { return _tileBrush; }
            set
            {
                _tileBrush = value;

                // If tiles, set selection rectangle
                if (_tileBrush != null)
                    _selection = _tileBrush.ToRectangle();

                UpdateBackBuffer();
            }
        }

        /// <summary>
        /// Gets or sets the highlighter brush
        /// </summary>
        public GMareBrush Highlighter
        {
            get { return _highlighter; }
            set
            {
                // If the value is null or the same as the current highlighter, set the highlighter to null, else copy the value
                _highlighter = value == null || (_highlighter != null && _highlighter.Same(_tileBrush)) ? null : value.Clone();
                UpdateBackBuffer();
            }
        }

        /// <summary>
        /// Gets or sets if mouse events should be ignored because of a dialog double click
        /// </summary>
        public bool AvoidMouseEvents
        {
            get { return _avoidMouseEvents; }
            set { _avoidMouseEvents = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new background panel
        /// </summary>
        public GMareBackgroundPanel()
        {
            InitializeComponent();

            // Set selected tiles tooltip
            _tileIdTip.ToolTipTitle = "Selected Tiles";
            _tileIdTip.AutomaticDelay = 1;
            _tileIdTip.AutoPopDelay = 1;
            _tileIdTip.InitialDelay = 1;
            _tileIdTip.UseFading = false;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// On draw on backbuffer
        /// </summary>
        protected override void OnDrawOnBackbuffer(ref System.Drawing.Graphics gfx)
        {
            // Draw highlights and selection rectangle
            DrawHighlights(gfx);
            DrawSelection(gfx);
        }

        /// <summary>
        /// On image set
        /// </summary>
        /// <param name="image">Image reference</param>
        protected override void OnImageSet(ref Bitmap image)
        {
            // Scale the image by the image scale value
            ScaleImage();

            // Set new selection rectangle
            _selection = new Rectangle(Point.Empty, SnapSize);

            // Create new tile brush
            if (!DesignMode)
                _tileBrush = new GMareBrush();

            // Reset selection
            _tileBrush = GMareBrush.RectangleToTileBrush(new Rectangle(Point.Empty, SnapSize), SnapSize.Width, SnapSize);

            // Update
            UpdateBackBuffer();

            // Scroll to zero
            AutoScrollPosition = Point.Empty;
        }

        /// <summary>
        /// On mouse down
        /// </summary>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Do base mouse down
            base.OnMouseDown(e);

            // Set focus on this control
            Focus();

            // If the image is empty or not pressing the left mouse button, return
            if (Image == null)
                return;

            // If the right mouse button was clicked, show brush information
            if (e.Button == MouseButtons.Right && _tileBrush != null)
            {
                _tileIdTip.Hide(this);
                _tileIdTip.Show(_tileBrush.To2DArrayString(), this, 5000);
            }
            
            // If the left mouse button was not clicked, return
            if (e.Button != MouseButtons.Left)
                return;

            // Get the snapped point
            Point snap = GetSnappedPoint(e.Location);

            // If not within bounds
            if (new Rectangle(0, 0, Image.Width, Image.Height).Contains(snap) == false)
                return;

            // Starting point of the selection
            _origin = snap;

            // Set new selection rectangle
            switch (_selectMode)
            {
                case SelectType.Normal: _selection = new Rectangle(_origin, SnapSize); break;
                case SelectType.Fixed:
                    _selection = new Rectangle(_origin, _selection.Size);

                    // If the selection is out of bounds, reposition till it is not
                    while (true)
                    {
                        // Move more in bounds
                        _selection.X -= _selection.Right > Image.Width ? SnapSize.Width : 0;
                        _selection.Y -= _selection.Bottom > Image.Height ? SnapSize.Height : 0;

                        // If within bounds, break
                        if (new Rectangle(0, 0, Image.Width, Image.Height).Contains(_selection) == true)
                            break;
                    }

                    break;
            }

            // Create tiles based on rectangle
            _tileBrush = GMareBrush.RectangleToTileBrush(_selection, ImageWidthUnscaled, SnapSize);

            // Update
            UpdateBackBuffer();
        }

        /// <summary>
        /// On mouse move
        /// </summary>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // Do base mouse move
            base.OnMouseMove(e);
            
            // If not pressing the left mouse button or if the image is empty or fixed selection, return
            if (_avoidMouseEvents || e.Button != MouseButtons.Left || Image == null || _selectMode == SelectType.Fixed)
            {
                _avoidMouseEvents = false;
                return;
            }

            // Get the snapped point
            Point snap = GetSnappedPoint(e.Location);
            snap.X += snap.X >= _origin.X ? SnapSize.Width : 0;
            snap.Y += snap.Y >= _origin.Y ? SnapSize.Height : 0;

            // Get selection rectangle
            Rectangle rect = new Rectangle();
            rect.X = Math.Max(Math.Min(_origin.X, snap.X), 0);
            rect.Y = Math.Max(Math.Min(_origin.Y, snap.Y), 0);
            rect.Width = Math.Abs(Math.Max(snap.X, 0) - _origin.X);
            rect.Height = Math.Abs(Math.Max(snap.Y, 0) - _origin.Y);

            // Stay in bounds
            rect.Width = rect.Right > Image.Width ? Image.Width - rect.X : rect.Width;
            rect.Height = rect.Bottom > Image.Height ? Image.Height - rect.Y : rect.Height;
            rect.Width = rect.Width <= 0 ? SnapSize.Width : rect.Width;
            rect.Height = rect.Height <= 0 ? SnapSize.Height : rect.Height;

            // If there has been no change in movement, return
            if (rect == _selection)
                return;

            // Set new selection rectangle
            _selection = rect;

            // Create tiles based on rectangle
            _tileBrush = GMareBrush.RectangleToTileBrush(_selection, ImageWidthUnscaled, SnapSize);

            // Update
            UpdateBackBuffer();
        }

        /// <summary>
        /// On mouse hover
        /// </summary>
        protected override void OnMouseHover(EventArgs e)
        {
            // Call base method and hide the tool tip
            base.OnMouseHover(e);
            _tileIdTip.Hide(this);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Draws highlight over tile
        /// </summary>
        private void DrawHighlights(System.Drawing.Graphics gfx)
        {
            // If there isn't a highlight brush, return
            if (_highlighter == null)
                return;

            // Calculate row and column amounts
            int cols = (int)Math.Floor((double)(Image.Width) / (double)(SnapSize.Width));
            int rows = (int)Math.Floor((double)(Image.Height) / (double)(SnapSize.Height));

            // Create a rectangle
            Rectangle cell = new Rectangle(0, 0, SnapSize.Width, SnapSize.Height);

            // Draw the tile highlight
            using (SolidBrush highlighter = new SolidBrush(Color.FromArgb(128, Color.Yellow)))
            {
                // Iterate through vertical tiles
                for (int row = 0; row < rows; row++)
                {
                    // Iterate through horizontal tiles
                    for (int col = 0; col < cols; col++)
                    {
                        // Get position coordinates
                        cell.X = (int)(col * SnapSize.Width);
                        cell.Y = (int)(row * SnapSize.Height);

                        // If the highlight brush does not contain the iterated tile id, continue
                        if (!_highlighter.Contains(GMareBrush.PositionToTileId(cell.X, cell.Y, Image.Width, SnapSize)))
                            continue;

                        // Draw highlight
                        gfx.FillRectangle(highlighter, cell);
                    }
                }
            }
        }

        /// <summary>
        /// Draws a selection rectangle
        /// </summary>
        private void DrawSelection(System.Drawing.Graphics gfx)
        {
            // If the image does not exist, return
            if (Image == null)
                return;

            // Create pens
            Pen black = new Pen(Color.Black);
            Pen white = new Pen(Color.White);

            // Draw rectangles
            Rectangle rect = _selection;
            rect.Width -= 1;
            rect.Height -= 1;

            gfx.DrawRectangle(black, rect);
            rect.Inflate(new System.Drawing.Size(-ImageScale, -ImageScale));
            gfx.DrawRectangle(white, rect);
            rect.Inflate(new System.Drawing.Size(-ImageScale, -ImageScale));
            gfx.DrawRectangle(black, rect);

            // Dispose
            black.Dispose();
            white.Dispose();
        }

        /// <summary>
        /// Creates the default brush
        /// </summary>
        public void CreateDefaultBrush()
        {
            // Set the brush by raising the click event
            OnMouseDown(new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
        }

        #endregion
    }
}