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
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;

namespace GMare.Controls
{
    public partial class CheckedListBoxEx : CheckedListBox
    {
        #region Fields

        private Bitmap _glyph = null;
        private int _lastSelectedIndex = -1;
        private int _maxWidth = 0;
        private int _offsetX = 0;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets glyph icon.
        /// </summary>
        public Bitmap Glyph
        {
            get { return _glyph; }
            set { _glyph = value; }
        }

        /// <summary>
        /// Gets or sets the item height of an item.
        /// </summary>
        public override int ItemHeight
        {
            get { return base.ItemHeight + 2; }
            set { base.ItemHeight = value; }
        }

        #endregion

        #region Constructor | Destructor

        /// <summary>
        /// Constructs a new checked list box extended.
        /// </summary>
        public CheckedListBoxEx()
        {
            InitializeComponent();

            // Set up defaults for ease of use
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 16;

            // Set drawing style to reduce flicker
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.Opaque, true);
        }

        #endregion

        #region Drawing

        /// <summary>
        /// OnPaint event
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Disable anti-aliasing.
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.SmoothingMode = SmoothingMode.None;

            // Draw item increment.
            int item = 0;

            // Get item starting index.
            int index = this.IndexFromPoint(0, 0);

            // Clear the control
            e.Graphics.FillRectangle(Brushes.White, this.ClientRectangle);

            // Set the maximum width of the client area.
            SetMaxWidth(e.Graphics);

            // If there are items to draw.
            if (Items.Count > 0)
            {
                // Draw each item, from the starting index.
                for (int i = index; i < this.Items.Count; i++)
                {
                    // Draw item arguments.
                    DrawItemEventArgs args;

                    // Rendering bounds.
                    Rectangle bounds = new Rectangle(0 - _offsetX, item * this.ItemHeight, _maxWidth, this.ItemHeight);

                    // Set draw item argument, based on item selected index.
                    if (i == this.SelectedIndex)
                        args = new DrawItemEventArgs(e.Graphics, Font, bounds, i, DrawItemState.Selected);
                    else
                        args = new DrawItemEventArgs(e.Graphics, Font, bounds, i, DrawItemState.None);

                    // Draw item.
                    OnDrawItem(args);

                    // Increment item draw index.
                    item++;
                }
            }

            // Reset the max width.
            _maxWidth = 0;
        }

        /// <summary>
        /// OnDrawItem override.
        /// </summary>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            // Disable anti-aliasing
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.SmoothingMode = SmoothingMode.None;

            // If there are items to draw, draw item.
            if (e.Index != -1)
                DrawItemEx(e);
        }

        /// <summary>
        /// Override measure item.
        /// </summary>
        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            // Do nothing.
        }

        #endregion

        #region WinMessages

        /// <summary>
        /// Override window messages.
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            // Filter horizontal scroll event.
            if (m.Msg == NativeMethods.WM_HSCROLL)
            {
                // Get the scroll information.
                NativeMethods.ScrollInfoStruct si = new NativeMethods.ScrollInfoStruct();
                si.fMask = NativeMethods.SIF_ALL;
                si.cbSize = Marshal.SizeOf(si);
                NativeMethods.GetScrollInfo(m.HWnd, 0, ref si);

                // Set the horizontal offset.
                _offsetX = si.nTrackPos;
            }

            base.WndProc(ref m);
        }

        #endregion

        #region Methods

        #region DrawItem

        /// <summary>
        /// Draw array item.
        /// </summary>
        private void DrawItemEx(DrawItemEventArgs e)
        {
            // Item string.
            string text = Items[e.Index].ToString();

            // Get check box state.
            CheckBoxState state = CheckBoxState.UncheckedNormal;
            bool check = this.GetItemChecked(e.Index);

            // If the checkbox is checked.
            if (check)
                state = CheckBoxState.CheckedNormal;

            // Points where to draw the glyph and text.
            Point checkLocation = new Point(e.Bounds.X + 2, e.Bounds.Y + 2);
            Point imageLocation = Point.Empty;
            Point textLocation = Point.Empty;

            // The text color.
            Color textColor = this.ForeColor;

            // If a glyph exists, take into consideration on calculations.
            if (_glyph != null)
            {
                imageLocation = new Point(e.Bounds.X + 17, e.Bounds.Y);
                textLocation = new Point(e.Bounds.X + 34, e.Bounds.Y + 1);
            }
            else
                textLocation = new Point(e.Bounds.X + 17, e.Bounds.Y + 1);

            // Do some fancy background painting.
            if (e.Index % 2 == 0)
                e.Graphics.FillRectangle(SystemBrushes.Control, e.Bounds);
            else
                e.Graphics.FillRectangle(new SolidBrush(this.BackColor), e.Bounds);

            // If the current item is selected.
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                if (_lastSelectedIndex > -1)
                {
                    DrawItemEventArgs diea = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, _lastSelectedIndex, DrawItemState.NoFocusRect);
                    base.OnDrawItem(diea);
                }

                // Draw the area in the selected state.
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                textColor = Color.White;
                _lastSelectedIndex = e.Index;
            }

            // If a glyph exists.
            if (_glyph != null)
            {
                // Draw checkbox.
                CheckBoxRenderer.DrawCheckBox(e.Graphics, checkLocation, state);

                // Draw glyph.
                e.Graphics.DrawImageUnscaled(_glyph, imageLocation);

                // Draw text.
                e.Graphics.DrawString(text, Font, new SolidBrush(textColor), textLocation.X, textLocation.Y);
            }
            else
            {
                // Draw checkbox.
                CheckBoxRenderer.DrawCheckBox(e.Graphics, checkLocation, state);

                // Draw text.
                e.Graphics.DrawString(text, Font, new SolidBrush(textColor), textLocation.X, textLocation.Y);
            }
        }

        #endregion

        #region SetMaxWidth

        /// <summary>
        /// Sets the maximum item width for horizontal scrolling, based on the current items.
        /// </summary>
        /// <param name="gfx">The graphics object to measure the item strings with.</param>
        private void SetMaxWidth(System.Drawing.Graphics gfx)
        {
            // Reset widths.
            int width = 0;

            // Iterate through items.
            foreach (object obj in Items)
            {
                // Get the object's width.
                width = (int)gfx.MeasureString(obj.ToString(), Font).Width + 32;

                // If the item's width is greater than the current max width, set it to the new value.
                if (width > _maxWidth)
                    _maxWidth = width;
            }

            // If the current max width is not greater than the client width, set it to the client width.
            if (_maxWidth < ClientSize.Width)
                _maxWidth = ClientSize.Width;

            // Set horizontal scroll
            HorizontalExtent = _maxWidth;
        }

        #endregion

        #endregion
    }
}
