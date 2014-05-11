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
using System.Text;
using GDI = System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;
using GMare.Objects;
using Pyxosoft.Windows.Tools.PyxTools.Controls;

namespace GMare.Controls
{
    /// <summary>
    /// A custom checked listbox for GMare data types
    /// </summary>
    public partial class GMareCheckedListBox : PyxCheckedListBox
    {
        #region Enums

        /// <summary>
        /// Describes the type of listbox
        /// </summary>
        public enum ListboxType
        {
            Layers,
            Brushes,
            Projects
        }

        #endregion

        #region Fields

        private ListboxType _listboxMode = ListboxType.Layers;  // The data displayed by this listbox
        private GDI.Size _cellSize = new GDI.Size(16, 16);      // Cell size for a big glyph

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets The data displayed by this listbox
        /// </summary>
        public ListboxType ListboxMode
        {
            get { return _listboxMode; }
            set { _listboxMode = value; }
        }

        /// <summary>
        /// Gets or sets the image cell size
        /// </summary>
        public GDI.Size CellSize
        {
            get { return _cellSize; }
            set { _cellSize = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new GMareCheckedListBox
        /// </summary>
        public GMareCheckedListBox()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// On get glyph
        /// </summary>
        public override System.Drawing.Bitmap OnGetGlyph(DrawItemEventArgs e)
        {
            // Get glyph based on data type
            switch (_listboxMode)
            {
                case ListboxType.Brushes:

                    // Get brush, return the glyph of the brush
                    GMareBrush brush = Items[e.Index] as GMareBrush;
                    return brush == null || brush.Glyph == null ? (GDI.Bitmap)GMare.Properties.Resources.brush.Clone() : (GDI.Bitmap)brush.Glyph.Clone();

                case ListboxType.Projects:

                    // Get background
                    GMareBackground background = (Items[e.Index] as ExportProject).Background;

                    // If the background is empty, return null
                    if (background == null)
                        return null;

                    // Image to draw
                    GDI.Bitmap image = null;

                    // Get the background image
                    if (background.Image != null)
                        image = ScaleImage(background.Image.ToBitmap(), _cellSize.Width, _cellSize.Height);
                    else
                    {
                        // Create an empty image
                        image = new GDI.Bitmap(_cellSize.Width, _cellSize.Height);
                        GDI.Pen border = new GDI.Pen(GDI.Color.Gray);
                        GDI.Pen innerBorder = new GDI.Pen(GDI.Color.White);
                        GDI.Graphics gfx = GDI.Graphics.FromImage(image);
                        GDI.Rectangle rect = new GDI.Rectangle(0, 0, image.Width - 1, image.Height - 1);
                        GDI.RectangleF rectF = new GDI.RectangleF(0, 0, image.Width, image.Height);
                        LinearGradientBrush gradient = new LinearGradientBrush(rect.Location, new GDI.Point(rect.Right, rect.Bottom), GDI.Color.Gray, GDI.Color.LightGray);

                        // String render format
                        GDI.StringFormat stringFormat = new GDI.StringFormat();
                        stringFormat.Alignment = GDI.StringAlignment.Center;
                        stringFormat.LineAlignment = GDI.StringAlignment.Center;

                        // Draw image
                        gfx.FillRectangle(gradient, rect);
                        gfx.DrawRectangle(border, rect);
                        rect.Inflate(new GDI.Size(-1, -1));
                        gfx.DrawRectangle(innerBorder, rect);
                        rect.Inflate(new GDI.Size(-1, -1));
                        gfx.DrawRectangle(border, rect);
                        gfx.DrawString("?", this.DisplayFont, GDI.Brushes.White, rectF, stringFormat);

                        // Dispose
                        border.Dispose();
                        innerBorder.Dispose();
                        stringFormat.Dispose();
                        gradient.Dispose();
                        gfx.Dispose();
                    }

                    return image;

                default: return Glyph;
            }
        }

        /// <summary>
        /// On get text
        /// </summary>
        public override string OnGetText(DrawItemEventArgs e)
        {
            // Get text based on data type
            switch (_listboxMode)
            {
                case ListboxType.Layers:

                    // Create a custom string for project key value pairs
                    KeyValuePair<string, string> pair = (KeyValuePair<string, string>)Items[e.Index];
                    return pair.Value;

                case ListboxType.Projects:

                    // Get the project
                    ExportProject project = (ExportProject)Items[e.Index];

                    // Create a string for the project
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(project.Name == "" ? "<No Name>" : project.Name);
                    return sb.ToString();

                default: return Items[e.Index].ToString();
            }
        }

        /// <summary>
        /// On draw selected
        /// </summary>
        public override void OnDrawSelected(DrawItemEventArgs e, GDI.Font font, GDI.Rectangle rect, GDI.Size glyphSize, string text)
        {
            // Set selection text to cell width if less than cell width
            if (_listboxMode == ListboxType.Projects)
                rect.X = e.Bounds.X + (glyphSize.Width < _cellSize.Width ? _cellSize.Width : glyphSize.Width) + TextOffsetX + 17;

            base.OnDrawSelected(e, font, rect, glyphSize, text);
        }

        /// <summary>
        /// On draw text
        /// </summary>
        public override void OnDrawText(DrawItemEventArgs e, GDI.Font font, GDI.Rectangle rect, GDI.Size glyphSize, string text)
        {
            // Set selection text to cell width if less than cell width
            if (_listboxMode == ListboxType.Projects)
                rect.X = e.Bounds.X + (glyphSize.Width < _cellSize.Width ? _cellSize.Width : glyphSize.Width) + TextOffsetX + 17;

            base.OnDrawText(e, font, rect, glyphSize, text);
        }

        #endregion
    }
}
