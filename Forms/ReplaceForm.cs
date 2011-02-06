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
using GMare.Common;

namespace GMare.Forms
{
    /// <summary>
    /// A form that replaces one tile with another.
    /// </summary>
    public partial class ReplaceForm : Form
    {
        #region Fields

        private GMareLayer _layer = null;  // The layer to swap tile ids in. Null value means to swap all layers.
        private TileGrid _target = null;   // The tile ids to swap out.
        private TileGrid _swap = null;     // The new tile ids to swap with.

        #endregion

        #region Properties

        /// <summary>
        /// Target layer to swap ids in. Null value means to swap all layers.
        /// </summary>
        public GMareLayer Layer
        {
            get { return _layer; }
        }

        /// <summary>
        /// Gets the tile ids to swap out.
        /// </summary>
        public TileGrid Target
        {
            get { return _target; }
        }

        /// <summary>
        /// Gets the tile ids to swap with.
        /// </summary>
        public TileGrid Swap
        {
            get { return _swap; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new tile replace form.
        /// </summary>
        /// <param name="background">The image to use as the tileset.</param>
        public ReplaceForm(Bitmap background)
        {
            InitializeComponent();

            // If a room has been loaded.
            if (ProjectManager.Room != null)
            {
                // Add default operation.
                tscb_Layers.Items.Add("All Layers");

                // Add all the rooms layers.
                foreach (GMareLayer layer in ProjectManager.Room.Layers)
                {
                    tscb_Layers.Items.Add(layer);
                }

                // Select the first element.
                tscb_Layers.SelectedIndex = 0;

                // Set tileset images.
                pnl_Swap.Image = background;
                pnl_Target.Image = background;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Ok button click.
        /// </summary>
        private void tsb_Ok_Click(object sender, EventArgs e)
        {
            // If all the layers are going to be swapped, set to null, else set to desired layer.
            if (tscb_Layers.SelectedIndex == 0)
                _layer = null;
            else
                _layer = (GMareLayer)tscb_Layers.SelectedItem;

            // Set tile ids.
            _target = pnl_Target.Selection;
            _swap = pnl_Swap.Selection;

            // If the set target empty button is checked.
            if (tsb_Empty.Checked)
            {
                // Set tile grid to empty tiles.
                for (int x = 0; x < _swap.TileIds.GetLength(0); x++)
                    for (int y = 0; y < _swap.TileIds.GetLength(0); y++)
                        _swap.TileIds[x, y] = -1;
            }

            // Set dialog result.
            DialogResult = DialogResult.OK;

            // Close the form.
            Close();
        }

        /// <summary>
        /// Cancel button click.
        /// </summary>
        private void tsb_Cancel_Click(object sender, EventArgs e)
        {
            // Close form.
            Close();
        }

        /// <summary>
        /// Mouse up event.
        /// </summary>
        private void pnl_Target_MouseUp(object sender, MouseEventArgs e)
        {
            // Set swap selection.
            pnl_Swap.Selection = pnl_Target.Selection.Clone();
            pnl_Swap.AutoScrollPosition = new Point(-pnl_Target.AutoScrollPosition.X, -pnl_Target.AutoScrollPosition.Y);
        }

        #endregion
    }
}