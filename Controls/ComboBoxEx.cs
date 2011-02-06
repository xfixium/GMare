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
using System.Windows.Forms.VisualStyles;

namespace GMare.Controls
{
    public partial class ComboBoxEx : ComboBox
    {
        #region Fields

        private int _lastIndex = -1;
        private int _maxWidth = 0;

        #endregion

        #region Ctor

        public ComboBoxEx()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Toolstrip combobox DrawItem
        /// </summary>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index > -1)
            {
                // Visual style variable.
                ProfessionalColorTable pct;

                // If we're using GMare's overridden visual style.
                if (VisualStyle.UserStyle)
                    pct = new VisualStyle();
                else
                    pct = new ProfessionalColorTable();

                // Set up item drawing elements.
                string text = this.Items[e.Index].ToString();
                Image glyph = this.GetImage(e.Index);

                // Colors.
                Color textColor;
                Color background;
                Color selection = pct.MenuItemSelected;
                Color gradient1 = pct.ToolStripGradientBegin;
                Color gradient2 = pct.ToolStripGradientEnd;

                // Gradient rectangle
                Rectangle gradientRect = new Rectangle(e.Bounds.X, e.Bounds.Y, 24, e.Bounds.Height);
                Rectangle selectionRect = new Rectangle(e.Bounds.X + 1, e.Bounds.Y, e.Bounds.Width - 2, e.Bounds.Height);
                LinearGradientBrush gradientBrush = new LinearGradientBrush(gradientRect, gradient1, gradient2, LinearGradientMode.Horizontal);

                // Create textbox text rectangle.
                Rectangle rect = new Rectangle(e.Bounds.X + 32, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height);

                // Change the text color
                if (this.Enabled)
                {
                    switch (e.Index)
                    {
                        case 0: { textColor = Color.Black; break; }
                        case 1: { textColor = Color.SlateBlue; break; }
                        case 2: { textColor = Color.Crimson; break; }
                        default: { textColor = Color.Green; break; }
                    }

                    // The background color
                    background = this.BackColor;
                }
                else
                {
                    // Gray out, disabled
                    textColor = SystemColors.GrayText;
                    background = SystemColors.Control;
                }

                // Fill item bounds with back color and gradient
                e.Graphics.FillRectangle(new SolidBrush(background), e.Bounds);
                e.Graphics.FillRectangle(gradientBrush, gradientBrush.Rectangle);

                // If the item is currently being selected
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    if (_lastIndex > -1)
                    {
                        DrawItemEventArgs diea = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds,
                            _lastIndex, DrawItemState.NoFocusRect);

                        base.OnDrawItem(diea);
                    }

                    // Draw the selection rectangle and text
                    e.Graphics.FillRectangle(new SolidBrush(selection), selectionRect);

                    // Set the last selected index to this event
                    _lastIndex = e.Index;
                }

                // Draw icon
                e.Graphics.DrawImage(glyph, e.Bounds.X + 3, e.Bounds.Y + 1);

                // Draw string
                e.Graphics.DrawString(text, Font, new SolidBrush(textColor), rect);

                // Dispose of temp objects
                if (glyph != null)
                    glyph.Dispose();
            }
        }

        /// <summary>
        /// On Measure item
        /// </summary>
        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            // Get item string
            string text = this.Items[e.Index].ToString();

            // Change Item width
            int width = (int)e.Graphics.MeasureString(text, this.Font).Width + 32;

            if (width > _maxWidth)
                _maxWidth = width;
            else
                _maxWidth = this.DropDownWidth;

        }

        #endregion

        #region Methods

        /// <summary>
        /// Get the combobox item image.
        /// </summary>
        private Image GetImage(int index)
        {
            // The image object
            Image image = null;

            // Set image depending on selected index.
            switch (index)
            {
                // View All.
                case 0:
                    image = GMare.Properties.Resources.eye;
                    break;

                // Shapes.
                case 1:
                    image = GMare.Properties.Resources.shape_rectangle;
                    break;
                
                case 2:
                    image = GMare.Properties.Resources.empty;
                    break;

                // Layers.
                default:
                    image = GMare.Properties.Resources.layer;
                    break;
            }

            // If this control is not enabled, grey scale image.
            if (!Enabled)
                image = ToolStripSystemRenderer.CreateDisabledImage(image);

            // Return image.
            return image;
        }

        #endregion
    }
}