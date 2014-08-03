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
    /// Adds or edits a selected layer's properties
    /// </summary>
    public partial class AddEditLayerForm : Form
    {
        #region Fields

        private GMareLayer _layer = null;  // The layer to edit
        private int _existingDepth = 0;    // The existing depth before edit
        private bool _new = false;         // If the layer is a new layer
        private bool _changed = false;     // If there was a change in the edit layer

        #endregion

        #region Properties

        /// <summary>
        /// Gets the edited layer object
        /// </summary>
        public GMareLayer Layer
        {
            get { return _layer; }
        }

        /// <summary>
        /// Gets if the given layer has changed
        /// </summary>
        public bool Changed
        {
            get { return _changed; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new add/edit layer form
        /// </summary>
        public AddEditLayerForm()
        {
            InitializeComponent();

            // Set form text based on action
            Text = "Add Layer";

            // It's a new layer, so we ignore the existing depth
            _new = true;

            // Create layer properties
            int cols = App.Room.Columns;
            int rows = App.Room.Rows;
            int depth = App.Room.GetUniqueDepth();
            GMareTile[,] tiles = GMareLayer.GetEmptyLayer(cols, rows);

            // Create a new layer
            _layer = new GMareLayer("Layer", depth, tiles);

            // Update the UI
            UpdateUI();
        }

        /// <summary>
        /// Constructs a new add/edit layer form with the desired layer to be edited
        /// </summary>
        /// <param name="layer">The layer to edit</param>
        public AddEditLayerForm(GMareLayer layer)
        {
            InitializeComponent();

            // Set form text based on action
            Text = "Edit Layer";

            // Set edit layer
            _layer = layer;

            // Set the existing depth as a valid depth to use
            _existingDepth = _layer.Depth;

            // Update the UI
            UpdateUI();
        }

        #endregion

        #region Events

        /// <summary>
        /// Form closing
        /// </summary>
        private void LayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If the dialog result is not Ok, return
            if (this.DialogResult != DialogResult.OK)
                return;

            // If the layer is an existing one, and the nud is just it's current depth
            if (_new == false && _layer.Depth == (int)nudDepth.Value)
            {
                // If the name changed, the layer has been changed
                if (_layer.Name == txtName.Text)
                    _changed = true;

                // Set edit layer properties
                _layer.Name = txtName.Text;
                _layer.Depth = (int)nudDepth.Value;
                return;
            }

            // Check depth redundancy
            bool match = App.Room.CheckDepth((int)nudDepth.Value);

            // The depth has been used already
            if (match == true)
            {
                // Show warning
                MessageBox.Show("The depth is already used by another layer. Please choose another depth.", "GMare", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                // Cancel close
                e.Cancel = true;
            }
            else
            {
                // Set edit layer properties
                _layer.Name = txtName.Text;
                _layer.Depth = (int)nudDepth.Value;

                // A change was made on the edit layer
                _changed = true;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the UI with layer data
        /// </summary>
        private void UpdateUI()
        {
            // Set controls
            txtName.Text = _layer.Name;
            nudDepth.Value = _layer.Depth;
        }

        #endregion
    }
}