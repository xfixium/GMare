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
using System.Collections.Generic;
using GMare.Common;

namespace GMare.Forms
{
    /// <summary>
    /// Exports a GMare room to a selective layer image file.
    /// </summary>
    public partial class ExportImageForm : Form
    {
        #region Fields

        private Bitmap _background = null;    // The background used for the image.
        private Size _roomSize = Size.Empty;  // The room size in pixels.
        private Size _tileSize = Size.Empty;  // The size of a single tile in pixels.
        private int _backgroundWidth = 0;     // The width of the background in pixels.

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a nes export image form.
        /// </summary>
        /// <param name="layers">The layers to draw.</param>
        /// <param name="tileset">The tileset to use for tile rendering.</param>
        /// <param name="roomSize">The size of the room.</param>
        /// <param name="tileSize">The size of a single tile.</param>
        public ExportImageForm(List<GMareLayer> layers, Bitmap tileset, Size roomSize, Size tileSize)
        {
            InitializeComponent();

            // Set fields.
            _background = tileset;
            _roomSize = roomSize;
            _tileSize = tileSize;
            _backgroundWidth = _background.Width;

            // Add layers to the list box.
            clb_Layers.Items.AddRange(layers.ToArray());
        }

        #endregion

        #region Events

        /// <summary>
        /// Ok button click.
        /// </summary>
        private void tsmi_Ok_Click(object sender, EventArgs e)
        {
            // If no tileset, return.
            if (_background == null)
                return;

            // Create a save file dialog box.
            using (SaveFileDialog form = new SaveFileDialog())
            {
                // Set file format filter.
                form.Filter = "Portable Network Graphics (.png)|*.png|Windows Bitmap (.bmp)|*.bmp;";

                // If the dialog result was Ok.
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Create a new list of layers.
                    List<GMareLayer> layers = new List<GMareLayer>();

                    // Add the selected layers to the list.
                    foreach(object obj in clb_Layers.CheckedItems)
                    {
                        // Add selected layer.
                        layers.Add((GMareLayer)obj);
                    }

                    // If there are no layers to draw, return.
                    if (layers.Count == 0)
                        return;

                    // Create a bitmap the size of the room.
                    Bitmap image = new Bitmap(_roomSize.Width, _roomSize.Height, PixelFormat.Format32bppArgb);
                    System.Drawing.Graphics gfx = System.Drawing.Graphics.FromImage(image);

                    // Calculate rows and columns.
                    int cols = _roomSize.Width / _tileSize.Width;
                    int rows = _roomSize.Height / _tileSize.Height;

                    // Destination rectangle.
                    Rectangle dest = Rectangle.Empty;
                    dest.Width = _tileSize.Width;
                    dest.Height = _tileSize.Height;

                    // Source Rectangle.
                    Rectangle source = Rectangle.Empty;
                    source.Width = _tileSize.Width;
                    source.Height = _tileSize.Height;

                    // Sort by depth.
                    layers.Sort(delegate(GMareLayer p1, GMareLayer p2) { return p2.Depth.CompareTo(p1.Depth); } );

                    // Iterate through layers.
                    foreach (GMareLayer layer in layers)
                    {
                        // Iterate through columns.
                        for (int col = 0; col < cols; col++)
                        {
                            // Iterate through rows.
                            for (int row = 0; row < rows; row++)
                            {
                                // Get tile id.
                                int tileId = layer.Tiles2[col, row].TileId;

                                // If the tile is empty, continue looping.
                                if (tileId == -1)
                                    continue;

                                // Calculate destination rectangle.
                                dest.X = col * _tileSize.Width;
                                dest.Y = row * _tileSize.Height;

                                // Calculate source point.
                                source.Location = GMareBrush.TileIdToPosition(tileId, _backgroundWidth, _tileSize);

                                // Get tile.
                                Bitmap temp = Graphics.PixelMap.PixelDataToBitmap(Graphics.PixelMap.GetPixels(_background, source));

                                // Get converted blend color.
                                Color color = layer.Tiles2[col, row].Blend;
                                float red = color.R / 255.0f;
                                float green = color.G / 255.0f;
                                float blue = color.B / 255.0f;

                                // Alpha changing color matrix.
                                ColorMatrix cm = new ColorMatrix(new float[][] {
                                    new float[]{ red, 0.0f, 0.0f, 0.0f, 0.0f},
                                    new float[]{ 0.0f, green, 0.0f, 0.0f, 0.0f},
                                    new float[]{ 0.0f, 0.0f, blue, 0.0f, 0.0f},
                                    new float[]{ 0.0f, 0.0f, 0.0f, 1.0f, 0.0f},
                                    new float[]{ 0.0f, 0.0f, 0.0f, 0.0f, 1.0f} });

                                // Create new image attributes.
                                ImageAttributes ia = new ImageAttributes();
                                ia.SetColorMatrix(cm);
                                
                                // Flip tile.
                                switch (layer.Tiles2[col, row].FlipMode)
                                {
                                    case FlipType.Horizontal: temp.RotateFlip(RotateFlipType.RotateNoneFlipX); break;
                                    case FlipType.Vertical: temp.RotateFlip(RotateFlipType.RotateNoneFlipY); break;
                                    case FlipType.Both: temp.RotateFlip(RotateFlipType.RotateNoneFlipX); temp.RotateFlip(RotateFlipType.RotateNoneFlipY); break;
                                }

                                // Draw the image to the bitmap.
                                gfx.DrawImage(temp, dest, 0, 0, _tileSize.Width, _tileSize.Height, GraphicsUnit.Pixel, ia);

                                // Dispose of things.
                                temp.Dispose();
                                ia.Dispose();
                            }
                        }
                    }

                    // Save the room to file.
                    switch (form.FilterIndex)
                    {
                        case 1: image.Save(form.FileName, ImageFormat.Png); break;
                        case 2: image.Save(form.FileName, ImageFormat.Bmp); break;
                    }

                    // Close form.
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Cancel button click.
        /// </summary>
        private void tsmi_Cancel_Click(object sender, EventArgs e)
        {
            // Set dialog result and close.
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Toggle select all button click.
        /// </summary>
        private void tsmi_CheckAll_Click(object sender, EventArgs e)
        {
            // Iterate through items.
            for (int i = 0; i < clb_Layers.Items.Count; i++)
            {
                // Set checked state.
                clb_Layers.SetItemChecked(i, tsb_CheckAll.Checked);
            }
        }

        #endregion
    }
}