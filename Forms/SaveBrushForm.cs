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
using System.Drawing.Imaging;
using GMare.Objects;

namespace GMare.Forms
{
    /// <summary>
    /// UI to name and save a tile brush
    /// </summary>
    public partial class SaveBrushForm : Form
    {
        #region Fields

        private Bitmap _brushGlyph = null;         // The brush glyph
        private string _brushName = string.Empty;  // The name for the brush

        #endregion

        #region Properties

        /// <summary>
        /// Gets the brush glyph
        /// </summary>
        public Bitmap BrushGlyph
        {
            get { return _brushGlyph; }
        }

        /// <summary>
        /// Gets the brush name
        /// </summary>
        public string BrushName
        {
            get { return _brushName; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new brush form
        /// </summary>
        /// <param name="background">The background to render from</param>
        /// <param name="brush">Brush to save</param>
        /// <param name="tileSize">Size of a single tile</param>
        public SaveBrushForm(Bitmap background, GMareBrush brush, Size tileSize)
        {
            InitializeComponent();

            // Create new graphics object
            Bitmap image = new Bitmap(brush.Width, brush.Height);
            System.Drawing.Graphics gfx = System.Drawing.Graphics.FromImage(image);

            // Iterate through tiles horizontally
            for (int col = 0; col < brush.Columns; col++)
            {
                // Iterate through tiles vertically
                for (int row = 0; row < brush.Rows; row++)
                {
                    // If the tile is empty, continue looping
                    if (brush.Tiles[col, row].TileId == -1)
                        continue;

                    // Calculate source point
                    Rectangle source = new Rectangle(GMareBrush.TileIdToPosition(brush.Tiles[col, row].TileId, background.Width, tileSize), tileSize);
                    Rectangle dest = new Rectangle(new Point(col * tileSize.Width, row * tileSize.Height), tileSize);

                    // Get tile
                    Bitmap temp = Graphics.PixelMap.PixelDataToBitmap(Graphics.PixelMap.GetPixels(background, source));

                    Color color = brush.Tiles[col, row].Blend;
                    float red = color.R / 255.0f;
                    float green = color.G / 255.0f;
                    float blue = color.B / 255.0f;

                    // Alpha changing color matrix
                    ColorMatrix cm = new ColorMatrix(new float[][] {
                        new float[]{ red, 0.0f, 0.0f, 0.0f, 0.0f},
                        new float[]{ 0.0f, green, 0.0f, 0.0f, 0.0f},
                        new float[]{ 0.0f, 0.0f, blue, 0.0f, 0.0f},
                        new float[]{ 0.0f, 0.0f, 0.0f, 1.0f, 0.0f},
                        new float[]{ 0.0f, 0.0f, 0.0f, 0.0f, 1.0f} });

                    // Create new image attributes
                    ImageAttributes ia = new ImageAttributes();
                    ia.SetColorMatrix(cm);

                    // Flip tile
                    switch (brush.Tiles[col, row].FlipMode)
                    {
                        case FlipType.Horizontal: temp.RotateFlip(RotateFlipType.RotateNoneFlipX); break;
                        case FlipType.Vertical: temp.RotateFlip(RotateFlipType.RotateNoneFlipY); break;
                        case FlipType.Both: temp.RotateFlip(RotateFlipType.RotateNoneFlipX); temp.RotateFlip(RotateFlipType.RotateNoneFlipY); break;
                    }

                    // Draw tile
                    gfx.DrawImage(temp, dest, 0, 0, tileSize.Width, tileSize.Height, GraphicsUnit.Pixel, ia);

                    // Dispose
                    temp.Dispose();
                    ia.Dispose();
                }
            }

            // Set brush image
            pnlBrush.Image = image;

            // Dispose of the graphics
            gfx.Dispose();

            // Validate
            CheckText();
        }

        #endregion

        #region Events

        /// <summary>
        /// Text box text changed
        /// </summary>
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            // Set accept button
            CheckText();
        }

        /// <summary>
        /// Ok button click
        /// </summary>
        private void butOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Cancel button click
        /// </summary>
        private void butCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Form closing
        /// </summary>
        private void BrushForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If Ok was not clicked, return.
            if (this.DialogResult != DialogResult.OK)
                return;

            // Set new name
            _brushName = txtName.Text;

            // Create a new glyph bitmap
            Bitmap glyph = new Bitmap(16, 16);

            // Set graphics to bitmap
            System.Drawing.Graphics gfx = System.Drawing.Graphics.FromImage(glyph);

            // Draw brush to glyph
            gfx.DrawImage(pnlBrush.Image, new Rectangle(0, 0, 16, 16));

            // Set the brush glyph
            _brushGlyph = glyph;

            // Dispose of graphics
            gfx.Dispose();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Check if there is text
        /// </summary>
        private void CheckText()
        {
            // Set if the ok button is enabled
            butOk.Enabled = txtName.Text.Length > 0 ? true : false;
        }

        #endregion
    }
}
