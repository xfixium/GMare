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
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using GMare.Common;

namespace GMare.Forms
{
    /// <summary>
    /// Creates or edits a room.
    /// </summary>
    public partial class RoomForm : Form
    {
        #region Fields

        private GMareRoom _room = null;  // Room to edit.
        private bool _new = false;       // Whether the room is a newly created room.
        private bool _changed = false;   // Whether the loaded room changed.

        #endregion

        #region Properties

        /// <summary>
        /// Gets the edited room.
        /// </summary>
        public GMareRoom Room
        {
            get { return _room; }
        }

        /// <summary>
        /// Gets whether the loaded room changed.
        /// </summary>
        public bool Changed
        {
            get { return _changed; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new room form.
        /// </summary>
        public RoomForm()
        {
            InitializeComponent();

            // Set new room.
            _room = new GMareRoom();

            // A new room, no need for change checks.
            _new = true;

            // Update the GUI with room data.
            SetupGUI();
        }

        /// <summary>
        /// Constructs a new room form with a room to edit.
        /// </summary>
        public RoomForm(GMareRoom room)
        {
            InitializeComponent();

            // Set new room.
            _room = room.Clone();

            // Update the GUI with room data.
            SetupGUI();
        }

        #endregion

        #region Events

        /// <summary>
        /// Ok button clicked.
        /// </summary>
        private void tsb_Ok_Click(object sender, EventArgs e)
        {
            // Set dialog result and close.
            DialogResult = DialogResult.OK;

            // Create new pixel map.
            Graphics.PixelMap image = new Graphics.PixelMap(pnl_Image.Image);

            if (_room.Columns != (int)nud_Columns.Value ||
                _room.Name != tb_Name.Text ||
                _room.Rows != (int)nud_Rows.Value ||
                _room.TileWidth != (int)nud_TileX.Value ||
                _room.TileHeight != (int)nud_TileY.Value ||
                _room.OffsetX != (int)nud_OffsetX.Value ||
                _room.OffsetY != (int)nud_OffsetY.Value ||
                _room.SeparationX != (int)nud_SeperationX.Value ||
                _room.SeparationY != (int)nud_SeperationY.Value
            )
                _changed = true;

            // Check background data change.
            if (_room.Background != null)
            {
                if (_room.Background.UseKey != tsb_SetColorKey.Checked ||
                    _room.Background.ColorKey.ToArgb() != pnl_Image.ColorKey.ToArgb() ||
                    Graphics.PixelMap.Same(_room.Background, image) == false)
                    _changed = true;
            }

            // Set room data.
            _room.Columns = (int)nud_Columns.Value;
            _room.Name = tb_Name.Text;
            _room.Rows = (int)nud_Rows.Value;
            _room.TileWidth = (int)nud_TileX.Value;
            _room.TileHeight = (int)nud_TileY.Value;
            _room.OffsetX = (int)nud_OffsetX.Value;
            _room.OffsetY = (int)nud_OffsetY.Value;
            _room.SeparationX = (int)nud_SeperationX.Value;
            _room.SeparationY = (int)nud_SeperationY.Value;
            _room.Background = image;
            _room.Background.UseKey = tsb_SetColorKey.Checked;
            _room.Background.ColorKey = pnl_Image.ColorKey;

            // If the room has no layers, add one.
            if (_room.Layers.Count == 0)
                _room.Layers.Add(new GMareLayer("Layer", 0, GMareLayer.GetEmptyLayer(_room.Columns, _room.Rows)));

            // Close form.
            Close();
        }

        /// <summary>
        /// Cancel button clicked.
        /// </summary>
        private void tsb_Cancel_Click(object sender, EventArgs e)
        {
            // Set dialog result and close.
            DialogResult = DialogResult.Cancel;

            // Close form.
            Close();
        }

        /// <summary>
        /// Image button clicked.
        /// </summary>
        private void tsb_Image_Click(object sender, EventArgs e)
        {
            // Create an open file dialog box.
            using (OpenFileDialog form = new OpenFileDialog())
            {
                // Set file filter.
                form.Filter = "Supported Image Files (.bmp, .png, .gif)|*.bmp;*.png;*gif;";

                // If the dialog result was Ok.
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Create a new file stream.
                    using (FileStream fs = new FileStream(form.FileName, FileMode.Open, FileAccess.Read))
                    {
                        // Get a bitmap from disk.
                        Bitmap image = (Bitmap)Image.FromStream(fs);

                        // If the image is a valid size.
                        if (CheckSize(image.Size, pnl_Image.TileSize))
                        {
                            // Set GUI.
                            pnl_Image.Image = image;
                            tssl_Width.Text = "Image Width: " + image.Width;
                            tssl_Height.Text = "Image Height: " + image.Height;

                            // Set transparency color.
                            tsb_SetColorKey_CheckedChanged(this, EventArgs.Empty);

                            // Check if able to accept the background settings.
                            CheckRequirements();
                        }
                        else  // Not a valid size.
                            image.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// Set color key checked changed.
        /// </summary>
        private void tsb_SetColorKey_CheckedChanged(object sender, EventArgs e)
        {
            // Set default transparency color.
            pnl_Image.Blink = tsb_SetColorKey.Checked;

            // Set color key information.
            tssl_MaskColor.BackColor = pnl_Image.ColorKey;
            tssl_MaskColor.ToolTipText = tssl_MaskColor.BackColor.ToString();
        }

        /// <summary>
        /// Show cell grid checked changed.
        /// </summary>
        private void tsb_ShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            // Set whether to show the cell grid.
            pnl_Image.ShowGrid = tsb_ShowGrid.Checked ? true : false;
        }

        /// <summary>
        /// Zoom level changed.
        /// </summary>
        private void tsb_Zoom_ZoomChanged()
        {
            // Set image zoom level.
            pnl_Image.Zoom = tsb_Zoom.Zoom;
        }

        /// <summary>
        /// Name textbox text changed.
        /// </summary>
        private void tb_Name_TextChanged(object sender, EventArgs e)
        {
            // Check requirements.
            CheckRequirements();
        }

        /// <summary>
        /// Numeric up and down tile size value changed.
        /// </summary>
        private void nud_TileSize_ValueChanged(object sender, EventArgs e)
        {
            // Set tile width.
            pnl_Image.TileSize = new Size((int)nud_TileX.Value, (int)nud_TileY.Value);
        }

        /// <summary>
        /// Numeric up and down seperation value changed.
        /// </summary>
        private void nud_Seperation_ValueChanged(object sender, EventArgs e)
        {
            // Set seperation.
            pnl_Image.SeperationX = (int)nud_SeperationX.Value;
            pnl_Image.SeperationY = (int)nud_SeperationY.Value;
        }

        /// <summary>
        /// Numeric up and down offset value changed.
        /// </summary>
        private void nud_Offset_ValueChanged(object sender, EventArgs e)
        {
            // Set offset.
            pnl_Image.OffsetX = (int)nud_OffsetX.Value;
            pnl_Image.OffsetY = (int)nud_OffsetY.Value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initial GUI setup.
        /// </summary>
        private void SetupGUI()
        {
            // Set name textbox.
            tb_Name.Text = _room.Name;

            // Set the nud values.
            nud_Columns.Value = _room.Columns;
            nud_Rows.Value = _room.Rows;
            nud_TileX.Value = _room.TileWidth;
            nud_TileY.Value = _room.TileHeight;
            nud_OffsetX.Value = _room.OffsetX;
            nud_OffsetY.Value = _room.OffsetY;
            nud_SeperationX.Value = _room.SeparationX;
            nud_SeperationY.Value = _room.SeparationY;

            // Set image panel.
            pnl_Image.TileSize = _room.TileSize;
            pnl_Image.SeperationX = _room.SeparationX;
            pnl_Image.SeperationY = _room.SeparationY;
            pnl_Image.OffsetX = _room.OffsetX;
            pnl_Image.OffsetY = _room.OffsetY;

            // If a background exists.
            if (_room.Background != null)
            {
                // Get the background's bitmap.
                pnl_Image.Image = Graphics.PixelMap.PixelDataToBitmap(_room.Background.Pixels);

                // Set color key.
                tsb_SetColorKey.Checked = _room.Background.UseKey;
            }

            // Set status labels.
            tssl_Width.Text = "Room Width: " + _room.Width.ToString();
            tssl_Height.Text = "Room Height: " + _room.Height.ToString();
            tssl_MaskColor.ToolTipText = tssl_MaskColor.BackColor.ToString();

            // Check if the user can accept settings.
            CheckRequirements();
        }

        /// <summary>
        /// Checks if the image contains too many tiles to support shorts.
        /// </summary>
        /// <param name="imageSize">The size of the tileset.</param>
        /// <param name="tileSize">The desired tile size.</param>
        /// <returns></returns>
        private bool CheckSize(Size imageSize, Size tileSize)
        {
            // Calculate the amount of tiles.
            int width = imageSize.Width / tileSize.Width;
            int height = imageSize.Width / tileSize.Height;
            int count = width * height;

            // If the tile count exceeds maximum value.
            if (count > 2147483647)
            {
                MessageBox.Show("The desired image and tile size exceed maximum allowed tile amount (2147483647 tiles).", "GMare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks requirements to accept room.
        /// </summary>
        private void CheckRequirements()
        {
            // If all the requirements have been met, allow confirmation.
            if (pnl_Image.Image != null && tb_Name.Text != string.Empty &&
                nud_TileX.Value <= pnl_Image.Image.Width && nud_TileY.Value <= pnl_Image.Image.Height)
            {
                tsb_Ok.Enabled = true;
            }
            else
                tsb_Ok.Enabled = false;
        }

        #endregion
    }
}