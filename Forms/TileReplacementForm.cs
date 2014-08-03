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

namespace GMare.Forms
{
    /// <summary>
    /// A form that collects data on tile swapping
    /// </summary>
    public partial class TileReplacementForm : Form
    {
        #region Fields

        private GMareLayer _layer = null;   // The layer to swap tile ids in. Null value means to swap all layers
        private GMareBrush _target = null;  // The tile ids to swap out
        private GMareBrush _swap = null;    // The new tile ids to swap with

        #endregion

        #region Properties

        /// <summary>
        /// Target layer to swap ids in. Null value means to swap all layers
        /// </summary>
        public GMareLayer Layer
        {
            get { return _layer; }
        }

        /// <summary>
        /// Gets the tile ids to swap out
        /// </summary>
        public GMareBrush Target
        {
            get { return _target; }
        }

        /// <summary>
        /// Gets the tile ids to swap with
        /// </summary>
        public GMareBrush Swap
        {
            get { return _swap; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new replace form
        /// </summary>
        /// <param name="image">Image used as a tileset</param>
        /// <param name="tileSize">Size of a single tile within the tileset</param>
        public TileReplacementForm(Bitmap image, Size tileSize)
        {
            InitializeComponent();

            // If the image is empty, return
            if (image == null)
                return;

            // Add default layer selection
            cboLayers.Items.Add("All Layers");

            // Add all the rooms layers
            foreach (GMareLayer layer in App.Room.Layers)
                cboLayers.Items.Add(layer);

            // Select the first element
            cboLayers.SelectedIndex = 0;

            // Set up image panels
            pnlTarget.Image = image;
            pnlReplacement.Image = image;
            pnlTarget.SnapSize = tileSize;
            pnlReplacement.SnapSize = tileSize;
            pnlTarget.CreateDefaultBrush();
            pnlTarget_MouseUp(this, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
        }

        #endregion

        #region Events

        /// <summary>
        /// Magnificy value changed
        /// </summary>
        private void trkMagnify_ValueChanged(object sender, EventArgs e)
        {
            // Set magnification level
            pnlReplacement.Zoom = trkMagnify.Value;
            pnlTarget.Zoom = trkMagnify.Value;
            lblMagnify.Text = (trkMagnify.Value * 100).ToString() + "%";
        }

        /// <summary>
        /// Mouse up event
        /// </summary>
        private void pnlTarget_MouseUp(object sender, MouseEventArgs e)
        {
            // If tiles are empty
            if (pnlTarget.TileBrush == null)
                return;

            // Set swap selection
            pnlReplacement.TileBrush = pnlTarget.TileBrush.Clone();
            pnlReplacement.AutoScrollPosition = new Point(-pnlTarget.AutoScrollPosition.X, -pnlTarget.AutoScrollPosition.Y);
        }

        /// <summary>
        /// Empty replacement tiles check changed
        /// </summary>
        private void chkEmpty_CheckedChanged(object sender, EventArgs e)
        {
            pnlReplacement.Enabled = chkEmpty.Checked ? false : true;
        }

        /// <summary>
        /// Ok button click
        /// </summary>
        private void butOk_Click(object sender, EventArgs e)
        {
            // If all the layers are going to be swapped, set to null, else set to desired layer
            _layer = cboLayers.SelectedIndex == 0 ? null : (GMareLayer)cboLayers.SelectedItem;

            // Set tile ids
            _target = pnlTarget.TileBrush;
            _swap = pnlReplacement.TileBrush;

            // If the set target empty button is checked
            if (chkEmpty.Checked)
            {
                // Set tile grid to empty tiles
                for (int x = 0; x < _swap.Tiles.GetLength(0); x++)
                    for (int y = 0; y < _swap.Tiles.GetLength(0); y++)
                        _swap.Tiles[x, y].TileId = -1;
            }

            // Set dialog result
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Cancel button click
        /// </summary>
        private void butCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion
    }
}