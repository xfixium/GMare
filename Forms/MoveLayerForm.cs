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
using System.Windows.Forms;
using GMare.Objects;

namespace GMare.Forms
{
    /// <summary>
    /// UI used to move selected layers in a given direction and tile amount
    /// </summary>
    public partial class MoveLayerForm : Form
    {
        #region Fields

        private ShiftDirectionType _direction = ShiftDirectionType.Up;  // The direction to shift
        private GMareLayer _layer = null;                       // The layer to shift
        private int _amount = 0;                                // The amount of tiles to shift

        #endregion

        #region Properties

        /// <summary>
        /// Gets the direction to shift
        /// </summary>
        public ShiftDirectionType Direction
        {
            get { return _direction; }
        }

        /// <summary>
        /// Gets the layer to shift
        /// </summary>
        public GMareLayer Layer
        {
            get { return _layer; }
        }

        /// <summary>
        /// Gets the amount of tiles to shift
        /// </summary>
        public int Amount
        {
            get { return _amount; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new move layer form
        /// </summary>
        public MoveLayerForm()
        {
            InitializeComponent();

            // Add all layers option
            cboLayer.Items.Add("All Layers");

            // Add all the layers to the list box
            cboLayer.Items.AddRange(ProjectManager.Room.Layers.ToArray());

            // Set selected layer index
            cboLayer.SelectedIndex = 0;
        }

        #endregion

        #region Events

        /// <summary>
        /// Up radio button checked changed
        /// </summary>
        private void rbUp_CheckedChanged(object sender, EventArgs e)
        {
            // If checked, change direction
            if (rbUp.Checked)
                _direction = ShiftDirectionType.Up;
        }

        /// <summary>
        /// Right radio button checked changed
        /// </summary>
        private void rbRight_CheckedChanged(object sender, EventArgs e)
        {
            // If checked, change direction
            if (rbRight.Checked)
                _direction = ShiftDirectionType.Right;
        }

        /// <summary>
        /// Down radio button checked changed
        /// </summary>
        private void rbDown_CheckedChanged(object sender, EventArgs e)
        {
            // If checked, change direction
            if (rbDown.Checked)
                _direction = ShiftDirectionType.Down;
        }

        /// <summary>
        /// Left radio button checked changed
        /// </summary>
        private void rbLeft_CheckedChanged(object sender, EventArgs e)
        {
            // If checked, change direction
            if (rbLeft.Checked)
                _direction = ShiftDirectionType.Left;
        }

        /// <summary>
        /// Form closing
        /// </summary>
        private void ShiftForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If the dialog result is not Ok
            if (DialogResult != DialogResult.OK)
                return;

            // If All Layers was not selected
            if (cboLayer.SelectedIndex != 0)
                _layer = (GMareLayer)cboLayer.SelectedItem;

            // Set the amount of tiles to move
            _amount = (int)nudAmount.Value;
        }

        #endregion
    }
}