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
using GameMaker.Resource;
using GameMaker.Common;

namespace GMare.Forms
{
    /// <summary>
    /// UI that displays Game Maker background resources for selection
    /// </summary>
    public partial class ImportBackgroundForm : Form
    {
        #region Properties

        /// <summary>
        /// Gets the selected background
        /// </summary>
        public GMareBackground Background
        {
            get { return GetBackground(); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new import background form
        /// </summary>
        /// <param name="backgrounds">Array of Game Maker backgrounds</param>
        public ImportBackgroundForm(GMBackground[] backgrounds)
        {
            InitializeComponent();

            // Disable Ok button by default
            butOk.Enabled = false;

            // Iterate through backgrounds
            foreach (GMBackground background in backgrounds)
            {
                // If the image data is not empty, add the background to the backgrounds listbox
                if (background.Image != null && background.Image.Data != null)
                    lstBackgrounds.Items.Add(background);
            }

            // If there is background(s), select the first one
            if (lstBackgrounds.Items.Count > 0)
                lstBackgrounds.SelectedIndex = 0;
        }

        #endregion

        #region Events

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
        /// Backgrounds listbox selection changed
        /// </summary>
        private void lstBackgrounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            butOk.Enabled = lstBackgrounds.SelectedIndex != -1 ? true : false;
        }

        /// <summary>
        /// Backgrounds listbox double click
        /// </summary>
        private void lstBackgrounds_DoubleClick(object sender, EventArgs e)
        {
            if (lstBackgrounds.SelectedItem != null)
                butOk_Click(this, EventArgs.Empty);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a GMare background from imported backgrounds
        /// </summary>
        /// <returns>A GMare background</returns>
        private GMareBackground GetBackground()
        {
            // Create new background
            GMareBackground background = null;

            // If an item was selected
            if (lstBackgrounds.SelectedItem != null)
            {
                // Get GMare vackground from Game Maker background
                GMBackground back = lstBackgrounds.SelectedItem as GMBackground;

                // Set properties
                background = new GMareBackground();
                background.GameMakerId = back.Id;
                background.Name = back.Name;
                background.OffsetX = back.HorizontalOffset;
                background.OffsetY = back.VerticalOffset;
                background.SeparationX = back.HorizontalSeperation;
                background.SeparationY = back.VerticalSeperation;
                background.TileWidth = back.TileWidth;
                background.TileHeight = back.TileHeight;
                background.Image = new Graphics.PixelMap(GMUtilities.GetBitmap(back.Image));

                // If the background is transparent
                if (back.Transparent == true)
                {
                    background.Image.UseKey = true;
                    background.Image.ColorKey = Color.FromArgb(background.Image[0, background.Image.Height - 1]);
                }
            }

            // Return converted background
            return background;
        }

        #endregion
    }
}
