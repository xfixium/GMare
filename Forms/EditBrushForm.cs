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
    /// UI to edit brushes saved by the tile selection tool
    /// </summary>
    public partial class EditBrushForm : Form
    {
        #region Properties

        /// <summary>
        /// Gets an array of brushes
        /// </summary>
        public GMareBrush[] Brushes
        {
            get
            {
                // Create a new array of brushes
                GMareBrush[] brushes = new GMareBrush[lstBrushes.Items.Count];

                // Get all the brushes from the listbox
                for (int i = 0; i < lstBrushes.Items.Count; i++)
                    brushes[i] = (lstBrushes.Items[i] as GMareBrush);

                // Return the array of brushes
                return brushes;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new brush edit form
        /// </summary>
        /// <param name="brushes">The brushes to edit</param>
        public EditBrushForm(GMareBrush[] brushes)
        {
            InitializeComponent();

            // Add brushes to the edit list
            lstBrushes.Items.AddRange(brushes);

            // If there are brushes, select the first one
            lstBrushes.SelectedIndex = lstBrushes.Items.Count > 0 ? 0 : -1;
        }

        #endregion

        #region Events

        /// <summary>
        /// Brush name changed
        /// </summary>
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            // If a brush is selected, set name
            if (lstBrushes.SelectedItem != null)
                (lstBrushes.SelectedItem as GMareBrush).Name = txtName.Text;

            // Refresh drawing
            lstBrushes.Invalidate();
        }

        /// <summary>
        /// Brush list selected index changed
        /// </summary>
        private void lstBrushes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If no brush selected, return
            if (lstBrushes.SelectedItem == null)
                return;

            // Enable brush name editing
            txtName.Enabled = true;
            txtName.Text = (lstBrushes.SelectedItem as GMareBrush).Name;
        }

        /// <summary>
        /// Delete click
        /// </summary>
        private void butDelete_Click(object sender, EventArgs e)
        {
            // If no brush selected, return
            if (lstBrushes.SelectedItem == null)
                return;

            // If the user does not want to delete any brushes, return
            if (MessageBox.Show("Are you sure you want to delete the selected brush(es)?", "GMare", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            // Get the index of the selected brush, then delete it
            int index = lstBrushes.SelectedIndex;

            // Remove checked items
            while (lstBrushes.CheckedItems.Count > 0)
            {
                lstBrushes.Items.Remove(lstBrushes.CheckedItems[0]);
            }

            // If there is at least one brush left, use previous index
            if (lstBrushes.Items.Count > 0)
                lstBrushes.SelectedIndex = index >= lstBrushes.Items.Count ? index - 1 : index;
        }

        /// <summary>
        /// Move selected brush up
        /// </summary>
        private void butMoveUp_Click(object sender, EventArgs e)
        {
            // If no brush selected, return
            if (lstBrushes.SelectedItem == null)
                return;

            // Get the index of the selected brush, then copy it
            int index = lstBrushes.SelectedIndex;
            object swap = lstBrushes.SelectedItem;

            // If the index is not out of bounds
            if (index - 1 > -1)
            {
                // Remove, insert, and select the swap item
                bool isChecked = lstBrushes.CheckedItems.Contains(lstBrushes.SelectedItem);
                lstBrushes.Items.RemoveAt(index);
                lstBrushes.Items.Insert(index - 1, swap);
                lstBrushes.SetItemChecked(index - 1, isChecked);
                lstBrushes.SelectedItem = swap;
            }
        }

        /// <summary>
        /// Move selected brush down
        /// </summary>
        private void butMoveDown_Click(object sender, EventArgs e)
        {
            // If no brush selected, return
            if (lstBrushes.SelectedItem == null)
                return;

            // Get the index of the selected brush, then copy it
            int index = lstBrushes.SelectedIndex;
            object swap = lstBrushes.SelectedItem;

            // If the index is not out of bounds
            if (index + 1 < lstBrushes.Items.Count)
            {
                // Remove, insert, and select the swap item
                bool isChecked = lstBrushes.CheckedItems.Contains(lstBrushes.SelectedItem);
                lstBrushes.Items.RemoveAt(index);
                lstBrushes.Items.Insert(index + 1, swap);
                lstBrushes.SetItemChecked(index + 1, isChecked);
                lstBrushes.SelectedItem = swap;
            }
        }

        /// <summary>
        /// Check/Uncheck all brushes button check changed
        /// </summary>
        private void butCheckAll_CheckChanged(object sender)
        {
            // Iterate through items
            for (int i = 0; i < lstBrushes.Items.Count; i++)
            {
                // Set checked state
                lstBrushes.SetItemChecked(i, butCheckAll.Checked);
            }

            // Update rendering
            lstBrushes.Invalidate();
        }

        /// <summary>
        /// Ok button click
        /// </summary>
        private void butOk_Click(object sender, EventArgs e)
        {
            // Close this form
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Cancel button click
        /// </summary>
        private void butCancel_Click(object sender, EventArgs e)
        {
            // Close this form
            this.DialogResult = DialogResult.Cancel;
        }

        #endregion
    }
}