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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GameMaker.Common;
using GameMaker.Resource;
using GMare.Common;

namespace GMare.Controls
{
    public partial class ListboxEx : ListBox
    {
        #region Fields

        /// <summary>
        /// Describes the sorting type.
        /// </summary>
        public enum SortType
        {
            Standard,
            Ascending,
            Descending
        };

        /// <summary>
        /// Describes the type of listbox.
        /// </summary>
        public enum ListboxType
        {
            Backgrounds,
            BinaryFiles,
            Shapes,
            Instances
        };

        private ListboxType _listboxMode = ListboxType.Backgrounds;  // The information displayed by this listbox.
        private SortType _sortMode = SortType.Standard;              // Sorting mode of the listbox.
        private int _lastSelectedIndex = -1;                         // Last selected index.
        private int _cellWidth = 16;                                 // The width of the item cell.
        private int _cellHeight = 16;                                // The height of the item cell.
        private int _maxWidth = 0;                                   // The maximum inner width of the control.
        private int _offsetX = 0;                                    // Drawing offset.

        #endregion

        #region Properties

        public SortType SortMode
        {
            set { _sortMode = value; SortItems(); }
        }

        /// <summary>
        /// Gets or set the listbox mode.
        /// </summary>
        public ListboxType ListboxMode
        {
            get { return _listboxMode; }
            set { _listboxMode = value; }
        }

        /// <summary>
        /// The width of the icon cell.
        /// </summary>
        public int CellWidth
        {
            get { return _cellWidth; }
            set { _cellWidth = value; }
        }

        /// <summary>
        /// The height of the icon cell.
        /// </summary>
        public int CellHeight
        {
            get { return _cellHeight; }
            set { _cellHeight = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new list box extended.
        /// </summary>
        public ListboxEx()
        {
            InitializeComponent();

            // Set up defaults for ease of use
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = _cellHeight;

            // Set drawing style to reduce flicker
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.Opaque, true);
        }

        #endregion

        #region Overrides

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
            else
            {
                // Empty items text to be drawn.
                string text = string.Empty;

                // Get text based on the type of listbox.
                switch (_listboxMode)
                {
                    case ListboxType.Backgrounds: text = "- No Backgrounds -"; break;
                    case ListboxType.BinaryFiles: text = "- No Project Files -"; break;
                    case ListboxType.Shapes: text = "- No Collisions -"; break;
                    case ListboxType.Instances: text = "- No Instances -"; break;
                }

                // Calculate the position of the text, which is the center of the control.
                SizeF size = e.Graphics.MeasureString(text, Font);
                int x = (int)((ClientSize.Width / 2) - (size.Width / 2));
                int y = (int)((ClientSize.Height / 2) - (size.Height / 2));

                // Draw the text.
                e.Graphics.DrawString(text, Font, Brushes.Gray, x, y);
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

            // If there are items to draw
            if (e.Index != -1)
            {
                // Draw item based on list box mode.
                switch (_listboxMode)
                {
                    case ListboxType.Backgrounds: DrawBackground(e); break;
                    case ListboxType.BinaryFiles: DrawRoom(e); break;
                    case ListboxType.Shapes: DrawShape(e); break;
                    case ListboxType.Instances: DrawInstance(e); break;
                }
            }
        }

        /// <summary>
        /// Override measure item.
        /// </summary>
        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            // Do nothing.
        }

        #endregion

        #region Mouse

        /// <summary>
        /// OnMouseDown override.
        /// </summary>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            // The selected item index
            int index = this.IndexFromPoint(e.Location);

            // Left mouse button clicked.
            if (e.Button == MouseButtons.Left)
            {
                // If there was an item under the cursor, and there are items to select.
                if (index != -1 && Items.Count > 0)
                    this.SelectedIndex = index;
            }

            // Right mouse button clicked.
            if (e.Button == MouseButtons.Right)
            {
                // If there was an item under the cursor, and there are items to select.
                if (index != -1 && Items.Count > 0)
                {
                    // Select the item.
                    this.SelectedIndex = index;
                }
            }
        }

        #endregion

        #region Sort

        /// <summary>
        /// Sorts the listbox in the desired mode.
        /// </summary>
        private void SortItems()
        {
            // Do action based on listbox mode.
            switch (_listboxMode)
            {
                // Sorting instances.
                case ListboxType.Instances:
                    // If no room was loaded, return.
                    if (ProjectManager.Room == null)
                        return;

                    // Create a new list of instances.
                    List<GMareInstance> list = new List<GMareInstance>();

                    // Add all the current room instances.
                    foreach (GMareInstance instance in ProjectManager.Room.Instances)
                        list.Add(instance);

                    // Sort.
                    switch (_sortMode)
                    {
                        case SortType.Ascending: list.Sort(delegate(GMareInstance inst1, GMareInstance inst2) { return inst1.Name.CompareTo(inst2.Name); }); break;
                        case SortType.Descending: list.Sort(delegate(GMareInstance inst1, GMareInstance inst2) { return inst2.Name.CompareTo(inst1.Name); }); break;
                    }

                    // Clear all the current items.
                    this.Items.Clear();

                    // Add new item.
                    this.Items.AddRange(list.ToArray());
                    break;
            }
            
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

        #endregion

        #region Methods

        #region DrawBackground

        /// <summary>
        /// Draw array item
        /// </summary>
        private void DrawBackground(DrawItemEventArgs e)
        {
            // Image to draw.
            Bitmap image;

            // Get background.
            GMBackground background = Items[e.Index] as GMBackground;

            // Get the background image.
            if (background.Image != null)
                image = ScaleImage(GMUtilities.GetBitmap(background.Image), _cellWidth, _cellHeight);
            else
                image = new Bitmap(_cellWidth, _cellHeight);

            // Create a string with background data.
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Id: " + background.Id);
            sb.AppendLine("Tileset: " + background.UseAsTileSet);
            sb.AppendLine("Name: " + background.Name);
            sb.AppendLine("Width: " + background.Width);
            sb.AppendLine("Height: " + background.Height);

            // Set display text.
            string text = sb.ToString();

            // Set the points where to draw the glyph and text.
            Point imageLocation = new Point(e.Bounds.X + 1, e.Bounds.Y + 1);
            Point textLocation = new Point(e.Bounds.X + 130, e.Bounds.Y + 12);

            // The text color.
            Color textColor = this.ForeColor;

            // Clear drawing area with control back color.
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), e.Bounds);

            // If the current item is selected.
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                if (_lastSelectedIndex > -1)
                {
                    DrawItemEventArgs diea = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds,
                        _lastSelectedIndex, DrawItemState.NoFocusRect);
                    base.OnDrawItem(diea);
                }

                // Draw the area in the selected state.
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                textColor = Color.White;
                this._lastSelectedIndex = e.Index;
            }

            // Draw the glyph.
            e.Graphics.DrawImageUnscaled(image, imageLocation);

            // Draw the text.
            e.Graphics.DrawString(text, this.Font,
                new SolidBrush(textColor), new Rectangle(textLocation.X, textLocation.Y,
                e.Bounds.Width, e.Bounds.Height));

            // Dispose of glyph.
            image.Dispose();
        }

        /// <summary>
        /// Scales an image and keeps the aspect ratio.
        /// </summary>
        /// <param name="bitmap">The bitmap to resize.</param>
        /// <param name="maxWidth">The desired drawing width.</param>
        /// <param name="maxHeight">The desired drawing height.</param>
        /// <returns>A resized bitmap. With correct aspect ratio.</returns>
        private Bitmap ScaleImage(Bitmap bitmap, int maxWidth, int maxHeight)
        {
            // Calculate maximum and image ratios.
            float maxRatio = maxWidth / (float)maxHeight;
            float imgRatio = bitmap.Width / (float)bitmap.Height;

            // Get image width and height.
            int width = bitmap.Width;
            int height = bitmap.Height;

            // If the width and height are less or equal to the max width and height, return original.
            if (width <= maxWidth && height <= maxHeight)
                return bitmap;

            // If the image ratio is greater or equal to the maximum ratio.
            if (imgRatio >= maxRatio)
            {
                // Get ratio for height.
                int ratio = width / maxWidth;

                // If the ration is one, and the width is bigger than the max height, set to max height.
                if (ratio == 1 && height > maxHeight)
                    return new Bitmap(bitmap, maxWidth, maxHeight);
                else
                    return new Bitmap(bitmap, maxWidth, height / ratio);
            }
            else
            {
                // Get ratio for width.
                int ratio = height / maxHeight;

                // If the ration is one, and the width is bigger than the max width, set to max width.
                if (ratio == 1 && width > maxWidth)
                    return new Bitmap(bitmap, maxWidth, maxHeight);
                else
                    return new Bitmap(bitmap, width / ratio, maxHeight);
            }
        }

        #endregion

        #region DrawShape

        /// <summary>
        /// Draw array item
        /// </summary>
        private void DrawShape(DrawItemEventArgs e)
        {
            // Get the shape.
            GMareCollision shape = Items[e.Index] as GMareCollision;

            // Shape data.
            string text = string.Empty;

            // Set text.
            text = shape.ToString();

            // Set the points where to draw the glyph and text.
            Point imageLocation = new Point(e.Bounds.X + 1, e.Bounds.Y);
            Point textLocation = new Point(e.Bounds.X + _cellWidth + 1, e.Bounds.Y + 2);

            // The text color.
            Color textColor = this.ForeColor;

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

            // Draw the glyph.
            e.Graphics.DrawImageUnscaled(GMare.Properties.Resources.shape_rectangle, imageLocation);

            // Draw the text.
            e.Graphics.DrawString(text, Font, new SolidBrush(textColor), textLocation.X, textLocation.Y);
        }

        #endregion

        #region DrawRoom

        /// <summary>
        /// Draw array item.
        /// </summary>
        private void DrawRoom(DrawItemEventArgs e)
        {
            // Shape data.
            Bitmap image = GMare.Properties.Resources.room;
            string text = e.ToString();

            // Set the points where to draw the glyph and text.
            Point imageLocation = new Point(e.Bounds.X + 1, e.Bounds.Y);
            Point textLocation = new Point(e.Bounds.X + _cellWidth + 1, e.Bounds.Y + 2);

            // The text color.
            Color textColor = this.ForeColor;

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

            // Draw the glyph.
            e.Graphics.DrawImageUnscaled(image, imageLocation);

            // Draw the text.
            e.Graphics.DrawString(text, Font, new SolidBrush(textColor), textLocation.X, textLocation.Y);

            // Dispose of glyph.
            image.Dispose();
        }

        #endregion

        #region DrawInstance

        /// <summary>
        /// Draw array item.
        /// </summary>
        private void DrawInstance(DrawItemEventArgs e)
        {
            // If no room was loaded return.
            if (ProjectManager.Room == null)
                return;

            // Get instance.
            GMareInstance inst = (GMareInstance)Items[e.Index];

            // Get object.
            GMareObject obj = ProjectManager.Room.Objects.Find(delegate(GMareObject o) { return o.Resource.Id == inst.ObjectId; });

            // If no object was found, return.
            if (obj == null)
                return;

            // Image and text data.
            Bitmap image = (Bitmap)obj.Image.Clone();
            string text = inst.Name + " (X: " + inst.X + " Y: " + inst.Y + ")";

            // Set the points where to draw the glyph and text.
            Point imageLocation = new Point(e.Bounds.X + 1, e.Bounds.Y + 1);
            Point textLocation = new Point(e.Bounds.X + _cellWidth + 20, e.Bounds.Y + 2);

            // The text color.
            Color textColor = this.ForeColor;

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

            // Draw the glyph.
            e.Graphics.DrawImage(image, new Rectangle(imageLocation, new Size(16, 16)));

            // If the instance has creation code, draw glyph.
            if (inst.CreationCode != "")
                e.Graphics.DrawImageUnscaled(GMare.Properties.Resources.script, imageLocation.X + 18, imageLocation.Y);

            // Draw the text.
            e.Graphics.DrawString(text, this.Font, new SolidBrush(textColor), textLocation.X, textLocation.Y);

            // Dispose of glyph.
            image.Dispose();
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
                width = (int)gfx.MeasureString(obj.ToString(), Font).Width + _cellWidth;

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
