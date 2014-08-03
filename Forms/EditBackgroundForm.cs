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
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using GMare.Objects;

namespace GMare.Forms
{
    /// <summary>
    /// Creates or edits a background used as a tileset
    /// </summary>
    public partial class EditBackgroundForm : Form
    {
        #region Fields

        private GMareBackground _background = null;  // Background to edit

        #endregion

        #region Properties

        /// <summary>
        /// Gets the edited room
        /// </summary>
        public GMareBackground Background
        {
            get { return _background; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new room form with a room to edit
        /// </summary>
        public EditBackgroundForm(GMareBackground background)
        {
            InitializeComponent();

            // Set background to edit
            _background = background;

            // Update the UI with background data
            SetUI();
        }

        #endregion

        #region Events

        /// <summary>
        /// Numeric up and down tile size value changed
        /// </summary>
        private void nudTileSize_ValueChanged(object sender, EventArgs e)
        {
            // Set tile size
            pnlImage.CellWidth = (int)nudTileX.Value;
            pnlImage.CellHeight = (int)nudTileY.Value;
        }

        /// <summary>
        /// Numeric up and down seperation value changed
        /// </summary>
        private void nudSeperation_ValueChanged(object sender, EventArgs e)
        {
            // Set seperation
            pnlImage.CellSeperationX = (int)nudSeperationX.Value;
            pnlImage.CellSeperationY = (int)nudSeperationY.Value;
        }

        /// <summary>
        /// Numeric up and down offset value changed
        /// </summary>
        private void nudOffset_ValueChanged(object sender, EventArgs e)
        {
            // Set offset
            pnlImage.CellOffsetX = (int)nudOffsetX.Value;
            pnlImage.CellOffsetY = (int)nudOffsetY.Value;
        }

        /// <summary>
        /// Image button clicked
        /// </summary>
        private void butImage_Click(object sender, EventArgs e)
        {
            // Create an open file dialog box
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Set file filter
                ofd.Filter = "Supported Files (.bmp, .png, .gif, .gmk, .gm6, .gmd .gm81 .gmx)|*.bmp;*.png;*.gif;*.gmk;*.gm6;*.gmd;*.gm81;*.gmx;";

                // If the dialog result was not Ok, return
                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                // If getting a background object from a Game Maker project file
                if (ofd.FileName.Substring(ofd.FileName.LastIndexOf(".")).ToLower().Contains("gm") == true)
                {
                    // Create a Game Maker project form
                    using (ProjectIOForm iof = new ProjectIOForm(ofd.FileName, true))
                    {
                        // Show the form
                        iof.ShowDialog();

                        // Create a new import background form
                        using (ImportBackgroundForm backgroundForm = new ImportBackgroundForm(iof.GMProject.Backgrounds.ToArray()))
                        {
                            // If dialog result is Ok
                            if (backgroundForm.ShowDialog() == DialogResult.OK)
                            {
                                // Set background and update views
                                if (backgroundForm.Background != null)
                                {
                                    _background = backgroundForm.Background;
                                    SetUI();
                                }
                            }
                        }
                    }
                }
                else  // Normal image file
                {
                    // Create a new file stream
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        // Get a bitmap from disk
                        Bitmap image = (Bitmap)Image.FromStream(fs);

                        // If the image is a valid size
                        if (CheckSize(image.Size, pnlImage.CellSize))
                        {
                            // Set GUI and set background name to the file name
                            pnlImage.Image = image;
                            _background.GameMakerId = -1;
                            _background.Name = Path.GetFileNameWithoutExtension(ofd.FileName);
                            txtName.Text = _background.Name;

                            // Set transparency color
                            butSetColorKey_CheckedChanged(this);
                        }
                        else  // Not a valid size
                            image.Dispose();

                        // Update the status strip
                        UpdateStatusStrip();
                    }
                }
            }
        }

        /// <summary>
        /// Set color key checked changed
        /// </summary>
        private void butSetColorKey_CheckedChanged(object sender)
        {
            // Set default transparency color
            pnlImage.Blink = butSetColorKey.Checked;

            // Set color key information
            tsslTransparentColor.BackColor = pnlImage.ColorKey;
            tsslTransparentColor.ToolTipText = tsslTransparentColor.BackColor.ToString();
        }

        /// <summary>
        /// Show cell grid checked changed
        /// </summary>
        private void butShowGrid_CheckedChanged(object sender)
        {
            // Set whether to show the cell grid
            pnlImage.ShowCells = butShowGrid.Checked ? true : false;
        }

        /// <summary>
        /// Magnification level changed
        /// </summary>
        private void trkMagnify_ValueChanged(object sender, EventArgs e)
        {
            // Set image zoom level
            pnlImage.Zoom = trkMagnify.Value;
            lblMagnify.Text = (trkMagnify.Value * 100).ToString() + "%";
        }

        /// <summary>
        /// Ok button click
        /// </summary>
        private void butOk_Click(object sender, EventArgs e)
        {
            // If the name of the background is empty, inform the user and return
            if (pnlImage.Image != null && txtName.Text == "")
            {
                MessageBox.Show("Please fill out the name of the background.", "GMare", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            // Set dialog result and close
            DialogResult = DialogResult.OK;

            // Set room data
            _background.Name = txtName.Text;
            _background.TileWidth = (int)nudTileX.Value;
            _background.TileHeight = (int)nudTileY.Value;
            _background.OffsetX = (int)nudOffsetX.Value;
            _background.OffsetY = (int)nudOffsetY.Value;
            _background.SeparationX = (int)nudSeperationX.Value;
            _background.SeparationY = (int)nudSeperationY.Value;

            // If there is a background image selected, set it's data
            if (pnlImage.Image != null)
            {
                // Set the background's image data
                _background.Image = new Graphics.PixelMap(pnlImage.Image);
                _background.Image.UseKey = butSetColorKey.Checked;
                _background.Image.ColorKey = pnlImage.ColorKey;
            }
            else
                _background.Image = null;
        }

        /// <summary>
        /// Cancel button click
        /// </summary>
        private void butCancel_Click(object sender, EventArgs e)
        {
            // Set dialog result and close
            DialogResult = DialogResult.Cancel;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initial UI setup
        /// </summary>
        private void SetUI()
        {
            // Set the nud values
            txtName.Text = _background.Name;
            nudTileX.Value = _background.TileWidth;
            nudTileY.Value = _background.TileHeight;
            nudOffsetX.Value = _background.OffsetX;
            nudOffsetY.Value = _background.OffsetY;
            nudSeperationX.Value = _background.SeparationX;
            nudSeperationY.Value = _background.SeparationY;

            // Set image panel
            pnlImage.CellSize = _background.TileSize;
            pnlImage.CellSeperationX = _background.SeparationX;
            pnlImage.CellSeperationY = _background.SeparationY;
            pnlImage.CellOffsetX = _background.OffsetX;
            pnlImage.CellOffsetY = _background.OffsetY;

            // If a background exists
            if (_background.Image != null)
            {
                // Get the background's bitmap
                pnlImage.Image = Graphics.PixelMap.PixelDataToBitmap(_background.Image.Pixels);

                // Set if using color key
                butSetColorKey.Checked = _background.Image.UseKey;
            }

            // Set status strip
            UpdateStatusStrip();
        }

        /// <summary>
        /// Checks if the image contains too many tiles to support
        /// </summary>
        /// <param name="imageSize">The size of the tileset</param>
        /// <param name="tileSize">The desired tile size</param>
        /// <returns>If the tile count is acceptable</returns>
        private bool CheckSize(Size imageSize, Size tileSize)
        {
            // Calculate the amount of tiles
            int width = imageSize.Width / tileSize.Width;
            int height = imageSize.Width / tileSize.Height;
            long count = width * height;

            // If the tile count exceeds maximum value
            if (count > 2147483647)
            {
                MessageBox.Show("The desired image and tile size exceed maximum allowed tile amount (2,147,483,647).", "GMare", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                
                return false;
            }

            return true;
        }

        /// <summary>
        /// Updates the size of the room information
        /// </summary>
        private void UpdateStatusStrip()
        {
            tsslWidth.Text = pnlImage.Image == null ? "Image Width: 0" : "Image Width: " + pnlImage.Image.Width;
            tsslHeight.Text = pnlImage.Image == null ? "Image Height: 0" : "Image Height: " + pnlImage.Image.Height;
            tsslTransparentColor.ToolTipText = tsslTransparentColor.BackColor.ToString();
        }

        #endregion
    }
}