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
using System.Collections.Generic;
using System.Windows.Forms;
using GMare.Common;

namespace GMare.Forms
{
    public partial class BrushEditForm : Form
    {
        #region Properties

        /// <summary>
        /// Gets an array of brushes.
        /// </summary>
        public GMareBrush[] Brushes
        {
            get { return GetBrushes(); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new brush edit form.
        /// </summary>
        /// <param name="brushes">The brushes to edit.</param>
        public BrushEditForm(GMareBrush[] brushes)
        {
            InitializeComponent();

            // Add brushes to the edit list.
            lb_Brushes.Items.AddRange(brushes);

            // If there are brushes, select the first one.
            if (lb_Brushes.Items.Count > 0)
                lb_Brushes.SelectedIndex = 0;
        }

        #endregion

        #region Events

        /// <summary>
        /// Ok click.
        /// </summary>
        private void tsb_Ok_Click(object sender, EventArgs e)
        {
            // Cloase this form.
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Cancel click.
        /// </summary>
        private void tsb_Cancel_Click(object sender, EventArgs e)
        {
            // Close this form.
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Delete click.
        /// </summary>
        private void tsb_Delete_Click(object sender, EventArgs e)
        {
            // If a brush was selected, get name.
            if (lb_Brushes.SelectedItem != null)
            {
                int index = lb_Brushes.SelectedIndex;
                lb_Brushes.Items.Remove(lb_Brushes.SelectedItem);

                // If there is at least one brsh left, keep previous index.
                if (lb_Brushes.Items.Count > 0)
                {
                    if (index >= lb_Brushes.Items.Count)
                        lb_Brushes.SelectedIndex = index - 1;
                    else
                        lb_Brushes.SelectedIndex = index;
                }
            }
        }

        /// <summary>
        /// Move selected brush up.
        /// </summary>
        private void tsb_MoveUp_Click(object sender, EventArgs e)
        {
            // Current index.
            int index = lb_Brushes.SelectedIndex;

            // Swap item.
            object swap = lb_Brushes.SelectedItem;

            // If selecting something, and the index would not be out of bounds.
            if (index != -1 && index - 1 > -1)
            {
                // Remove the swap item.
                lb_Brushes.Items.RemoveAt(index);

                // Insert swap item.
                lb_Brushes.Items.Insert(index - 1, swap);

                // Select moved item.
                lb_Brushes.SelectedItem = swap;
            }
        }

        /// <summary>
        /// Move selected brush down.
        /// </summary>
        private void tsb_MoveDown_Click(object sender, EventArgs e)
        {
            // Current index.
            int index = lb_Brushes.SelectedIndex;

            // Swap item.
            object swap = lb_Brushes.SelectedItem;

            // If selecting something, and the index would not be out of bounds.
            if (index != -1 && index + 1 < lb_Brushes.Items.Count)
            {
                // Remove the swap item.
                lb_Brushes.Items.RemoveAt(index);

                // Insert swap item.
                lb_Brushes.Items.Insert(index + 1, swap);

                // Select moved item.
                lb_Brushes.SelectedItem = swap;
            }
        }

        /// <summary>
        /// Brush name changed.
        /// </summary>
        private void tb_Name_TextChanged(object sender, EventArgs e)
        {
            // If a brush was selected, set name.
            if (lb_Brushes.SelectedItem != null)
                (lb_Brushes.SelectedItem as GMareBrush).Name = tb_Name.Text;
        }

        /// <summary>
        /// Brush list selected index changed.
        /// </summary>
        private void lb_Brushes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If a brush was selected, get name.
            if (lb_Brushes.SelectedItem != null)
            {
                tb_Name.Enabled = true;
                tb_Name.Text = (lb_Brushes.SelectedItem as GMareBrush).Name;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets an array of brushes.
        /// </summary>
        /// <returns>An array of brushes.</returns>
        private GMareBrush[] GetBrushes()
        {
            // Create a new array of brushes.
            GMareBrush[] brushes = new GMareBrush[lb_Brushes.Items.Count];

            // Get all the brushes from the listbox.
            for (int i = 0; i < lb_Brushes.Items.Count; i++)
                brushes[i] = (lb_Brushes.Items[i] as GMareBrush);

            // Return the array of brushes.
            return brushes;
        }

        #endregion
    }
}