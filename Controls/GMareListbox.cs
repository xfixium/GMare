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
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using GameMaker.Common;
using GameMaker.Resource;
using GMare.Objects;
using Pyxosoft.Windows.Tools.PyxTools.Controls;
using Pyxosoft.Windows.Tools.PyxTools.Controls.Design;

namespace GMare.Controls
{
    /// <summary>
    /// A specialized listbox that does custom drawing and behaviors for GMare objects
    /// </summary>
    public partial class GMareListbox : PyxListBox
    {
        #region Enums

        /// <summary>
        /// Describes the sorting type
        /// </summary>
        public enum SortType
        {
            Standard,
            Ascending,
            Descending
        };

        /// <summary>
        /// Describes the type of listbox
        /// </summary>
        public enum ListboxType
        {
            Backgrounds,
            Instances,
            Objects
        };

        #endregion

        #region Fields

        private ListboxType _listboxMode = ListboxType.Backgrounds;  // The information displayed by this listbox
        private SortType _sortMode = SortType.Standard;              // Sorting mode of the listbox
        private GDI.Size _cellSize = new GDI.Size(16, 16);           // Cell size for a big glyph
        private bool _showBlocks = true;                             // If showing block instances

        #endregion

        #region Properties

        /// <summary>
        /// Gets or set the listbox type
        /// </summary>
        public ListboxType ListboxMode
        {
            get { return _listboxMode; }
            set { _listboxMode = value; }
        }

        /// <summary>
        /// set the sort mode
        /// </summary>
        public SortType SortMode
        {
            set { _sortMode = value; SortItems(); }
        }

        /// <summary>
        /// Gets or sets the image cell size
        /// </summary>
        public GDI.Size CellSize
        {
            get { return _cellSize; }
            set { _cellSize = value; }
        }

        /// <summary>
        /// Gets or sets whether or not to show block instances
        /// </summary>
        public bool ShowBlocks
        {
            get { return _showBlocks; }
            set { _showBlocks = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new gmare listbox
        /// </summary>
        public GMareListbox()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// On get glyph
        /// </summary>
        public override GDI.Bitmap OnGetGlyph(DrawItemEventArgs e)
        {
            // Do action based on listbox type
            switch (_listboxMode)
            {
                case ListboxType.Backgrounds:
                    // Get background
                    GMBackground background = Items[e.Index] as GMBackground;

                    // If the background is empty, return null
                    if (background == null)
                        return null;

                    // Image to draw
                    GDI.Bitmap image = null;

                    // Get the background image
                    if (background.Image != null)
                        image = ScaleBitmap(GMUtilities.GetBitmap(background.Image), _cellSize.Width, _cellSize.Height);
                    
                    // If the image is still empty, create blank image
                    if (image == null)
                        image = new GDI.Bitmap(_cellSize.Width, _cellSize.Height);

                    return image;

                case ListboxType.Instances:
                    // Get the instance from the list, also get the parent object of the instance
                    GMareInstance instance = Items[e.Index] as GMareInstance;
                    GMareObject gmObject = App.Room.Objects.Find(o => instance.ObjectId == o.Resource.Id);

                    // If the instance or object or object image is empty, return default glyph
                    if (instance == null || gmObject == null || gmObject.Image == null)
                        return GMare.Properties.Resources.instance;

                    // Create a new glyph
                    GDI.Bitmap glyph = new GDI.Bitmap(CellSize.Width * 2 + 2, CellSize.Height);
                    GDI.Bitmap icon = ScaleImage((GDI.Bitmap)gmObject.Image.ToBitmap(), CellSize.Width, CellSize.Height);
                    GDI.Graphics gfx = GDI.Graphics.FromImage(glyph);
                    gfx.DrawImageUnscaled(icon, GDI.Point.Empty);

                    // If there is creation code on the instance, show an icon for it
                    if (instance.CreationCode != string.Empty)
                        gfx.DrawImageUnscaled(GMare.Properties.Resources.script, new GDI.Point(icon.Width + 2, 0));

                    // Return glyph
                    return glyph;

                case ListboxType.Objects:
                    // Get the object
                    GMareObject gmObject2 = Items[e.Index] == null ? null : (Items[e.Index] as GMareObject);

                    // If the instance or object or object image is empty, return default glyph
                    if (gmObject2 == null || gmObject2.Image == null)
                        return GMare.Properties.Resources.instance;

                    // Create a new glyph
                    GDI.Bitmap glyph2 = new GDI.Bitmap(CellSize.Width * 2 + 2, CellSize.Height);
                    GDI.Bitmap icon2 = ScaleImage((GDI.Bitmap)gmObject2.Image.ToBitmap(), CellSize.Width, CellSize.Height);
                    GDI.Graphics gfx2 = GDI.Graphics.FromImage(glyph2);
                    gfx2.DrawImageUnscaled(icon2, GDI.Point.Empty);

                    // Return glyph
                    return glyph2;

                default: return Glyph;
            }
        }

        /// <summary>
        /// On get text
        /// </summary>
        public override string OnGetText(DrawItemEventArgs e)
        {
            // Do action based on listbox type
            switch (_listboxMode)
            {
                case ListboxType.Backgrounds:
                    // Get background
                    GMBackground background = Items[e.Index] as GMBackground;

                    // If the background is empty, return null
                    if (background == null)
                        return "";

                    // Convert tileset boolean
                    string convert = background.UseAsTileSet ? "Yes" : "No";

                    // Create a string with background data
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Name: " + background.Name + " (Id: " + background.Id + ")");
                    sb.AppendLine("Tileset: " + convert);
                    sb.AppendLine("Width: " + background.Width);
                    sb.AppendLine("Height: " + background.Height);
                    return sb.ToString();

                case ListboxType.Instances:
                    // Get instance
                    GMareInstance instance = Items[e.Index] as GMareInstance;

                    // If the instance is empty, return default text
                    if (instance == null)
                        return Items[e.Index].ToString();

                    return Items[e.Index].ToString() + " (X: " + instance.X + ", Y: " + instance.Y + ")";

                default: return Items[e.Index].ToString();
            }
        }

        /// <summary>
        /// On draw selected
        /// </summary>
        public override void OnDrawSelected(DrawItemEventArgs e, GDI.Font font, GDI.Rectangle rect, GDI.Size glyphSize, string text)
        {
            // Do action based on listbox type
            switch (_listboxMode)
            {
                case ListboxType.Backgrounds:

                    // Set selection text to cell width if less than cell width
                    rect.X = e.Bounds.X + (glyphSize.Width < _cellSize.Width ? _cellSize.Width : glyphSize.Width) + TextOffsetX;
                    base.OnDrawSelected(e, font, rect, glyphSize, text);
                    break;

                case ListboxType.Instances:

                    // If not a block instance, draw selection normally and return
                    if (!IsBlock(e.Index))
                    {
                        base.OnDrawSelected(e, font, rect, glyphSize, text);
                        return;
                    }

                    // Draw selection rectangle
                    CurrentTheme.Theme.DrawSelection(CurrentTheme.Theme.ControlSelectionStyle, e.Graphics, e.Bounds, GDI.Color.FromArgb(80, GDI.Color.White), 
                        GDI.Color.FromArgb(255, 103, 129), GDI.Color.FromArgb(205, 113, 133));

                    // Draw text using theme
                    CurrentTheme.Theme.DrawStyledText(e.Graphics, font, text, GDI.StringAlignment.Near, rect, CurrentTheme.Theme.ControlSelectionTextStyle,
                        CurrentTheme.Theme.ControlSelectionTextForeColor, CurrentTheme.Theme.ControlSelectionTextBackColor);

                    break;

                default: base.OnDrawSelected(e, font, rect, glyphSize, text); break;
            }
        }

        /// <summary>
        /// On draw text
        /// </summary>
        public override void OnDrawText(DrawItemEventArgs e, GDI.Font font, GDI.Rectangle rect, GDI.Size glyphSize, string text)
        {
            // Set selection text to cell width if less than cell width
            rect.X = e.Bounds.X + (glyphSize.Width < _cellSize.Width ? _cellSize.Width : glyphSize.Width) + TextOffsetX;
            base.OnDrawText(e, font, rect, glyphSize, text);
        }

        /// <summary>
        /// On back color even
        /// </summary>
        public override GDI.Color OnGetBackColorEven(DrawItemEventArgs e)
        {
            return IsBlock(e.Index) ? GDI.Color.FromArgb(255, 228, 225) : base.OnGetBackColorEven(e);
        }

        /// <summary>
        /// On back color odd
        /// </summary>
        public override GDI.Color OnGetBackColorOdd(DrawItemEventArgs e)
        {
            return IsBlock(e.Index) ? GDI.Color.FromArgb(255, 245, 238) : base.OnGetBackColorOdd(e);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Check item index to see if it is a block instance
        /// </summary>
        /// <param name="index">Item index to check</param>
        /// <returns>If a block instance or not</returns>
        private bool IsBlock(int index)
        {
            // Get instance
            GMareInstance instance = Items[index] as GMareInstance;

            // Return results
            return _listboxMode != ListboxType.Instances || instance.TileId == -1 ? false : true;
        }

        /// <summary>
        /// Sorts the listbox in the desired mode
        /// </summary>
        private void SortItems()
        {
            // Do action based on listbox mode
            switch (_listboxMode)
            {
                // Sorting instances
                case ListboxType.Instances:

                    // If no room was loaded, return
                    if (App.Room == null)
                        return;

                    // Create a new list of instances
                    List<GMareInstance> list = new List<GMareInstance>();

                    // Add all the current room instances
                    foreach (GMareInstance instance in App.Room.Instances)
                    {
                        // If the listbox is not dislpaying block instances, skip the instance
                        if (!_showBlocks && instance.TileId != -1)
                            continue;

                        // Add instance
                        list.Add(instance);
                    }

                    // Sort
                    switch (_sortMode)
                    {
                        case SortType.Ascending: list.Sort(delegate(GMareInstance inst1, GMareInstance inst2) { return inst1.Name.CompareTo(inst2.Name); }); break;
                        case SortType.Descending: list.Sort(delegate(GMareInstance inst1, GMareInstance inst2) { return inst2.Name.CompareTo(inst1.Name); }); break;
                    }

                    // Clear all the current items
                    this.Items.Clear();

                    // Add new item
                    this.Items.AddRange(list.ToArray());
                    break;

                // Sorting instances
                case ListboxType.Objects:

                    // If no room was loaded, return
                    if (App.Room == null)
                        return;

                    // Create a new list of instances
                    List<GMareObject> objList = new List<GMareObject>();

                    // Add all the current room instances
                    foreach (GMareObject obj in App.Room.Objects)
                        objList.Add(obj);

                    // Sort
                    switch (_sortMode)
                    {
                        case SortType.Ascending: objList.Sort(delegate(GMareObject inst1, GMareObject inst2) { return inst1.Resource.Name.CompareTo(inst2.Resource.Name); }); break;
                        case SortType.Descending: objList.Sort(delegate(GMareObject inst1, GMareObject inst2) { return inst2.Resource.Name.CompareTo(inst1.Resource.Name); }); break;
                    }

                    // Clear all the current items
                    this.Items.Clear();

                    // Add new item
                    this.Items.AddRange(objList.ToArray());
                    break;
            }
        }

        /// <summary>
        /// Scales an image and keeps the aspect ratio
        /// </summary>
        /// <param name="bitmap">The bitmap to scale</param>
        /// <param name="width">The canvas width</param>
        /// <param name="height">The canvas height</param>
        /// <returns>A scaled bitmap with a maintained aspect ratio</returns>
        public GDI.Bitmap ScaleBitmap(GDI.Bitmap bitmap, int width, int height)
        {
            // If the bitmap is empty, return null
            if (bitmap == null)
                return null;

            GDI.Rectangle src = new GDI.Rectangle(GDI.Point.Empty, bitmap.Size);
            GDI.Rectangle dest = GDI.Rectangle.Empty;

            float ratio = 0;
            float widthRatio = (float)width / (float)src.Width;
            float heightRatio = (float)height / (float)src.Height;

            // If the height is less than the width
            if (heightRatio < widthRatio)
            {
                ratio = heightRatio;
                dest.X = (int)((width - (src.Width * ratio)) / 2);
            }
            else
            {
                ratio = widthRatio;
                dest.Y = (int)((height - (src.Height * ratio)) / 2);
            }

            // Set destination size
            dest.Width = (int)(src.Width * ratio) == 0 ? 1 : (int)(src.Width * ratio);
            dest.Height = (int)(src.Height * ratio) == 0 ? 1 : (int)(src.Height * ratio);

            // Create a new scaled image
            GDI.Bitmap scaledImage = new GDI.Bitmap(width, height, PixelFormat.Format32bppArgb);

            // Create a graphics context to draw the scaled image
            using (GDI.Graphics gfx = GDI.Graphics.FromImage(scaledImage))
            {
                // Set image resolution
                scaledImage.SetResolution(gfx.DpiX, gfx.DpiY);
                
                // Create the scaled image
                gfx.InterpolationMode = InterpolationMode.Low;
                gfx.SmoothingMode = SmoothingMode.None;
                gfx.DrawImage(bitmap, dest, src, GDI.GraphicsUnit.Pixel);
            }

            // Dispose of original bitmap, return scaled bitmap
            bitmap.Dispose();
            return scaledImage;
        }

        #endregion
    }
}