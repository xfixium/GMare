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
    public partial class ObjectListForm : Form
    {
        #region Fields

        private GMareObject _selectedObject = null;  // Selected object

        #endregion

        #region Properties

        /// <summary>
        /// Gets the selected object
        /// </summary>
        public GMareObject SelectedObject
        {
            get { return _selectedObject; }
        }

        #endregion

        #region Consrtuctors

        /// <summary>
        /// Constructs a new object list dialog
        /// </summary>
        public ObjectListForm()
        {
            InitializeComponent();

            // Add objects to search for
            lstObjects.Items.AddRange(App.Room.Objects.ToArray());
            lstObjects.SortMode = GMare.Controls.GMareListbox.SortType.Ascending;
        }

        #endregion

        #region Events

        /// <summary>
        /// Objects list form key down
        /// </summary>
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            // If the enter key was pressed, call object list click event
            if (e.KeyCode == Keys.Enter)
            {
                lstObjects_Click(this, EventArgs.Empty);
                return;
            }
            
            // If nothing is selected or there are no objects, return
            if (lstObjects.SelectedItem == null || lstObjects.Items.Count == 0)
                return;

            // Check for arrow keys, move index based on them
            if (e.KeyCode == Keys.Down)
                lstObjects.SelectedIndex = lstObjects.SelectedIndex + 1 == lstObjects.Items.Count ? 0 : lstObjects.SelectedIndex + 1;
            else if (e.KeyCode == Keys.Up)
                lstObjects.SelectedIndex = lstObjects.SelectedIndex - 1 == -1 ? lstObjects.Items.Count - 1 : lstObjects.SelectedIndex - 1;

            // Update list
            lstObjects.Invalidate();

            // Supress key from search text control
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                e.SuppressKeyPress = true;
        }

        /// <summary>
        /// Search text changed
        /// </summary>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // If the search text is not null or empty
            if (!String.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                // Iterate through objects
                foreach (GMareObject gmObject in lstObjects.Items)
                {
                    // If the object name starts with the search text, select it
                    if (gmObject.Resource.Name.StartsWith(txtSearch.Text.Trim()))
                    {
                        lstObjects.SelectedItem = gmObject;
                        lstObjects.Invalidate();
                        return;
                    }
                }
            }

            // Nothing found
            lstObjects.SelectedItem = null;
            lstObjects.Invalidate();
        }

        /// <summary>
        /// Object list click
        /// </summary>
        private void lstObjects_Click(object sender, EventArgs e)
        {
            // Set the selected object and close the dialog
            _selectedObject = lstObjects.SelectedItem == null ? null : (GMareObject)lstObjects.SelectedItem;
            DialogResult = DialogResult.OK;
        }

        #endregion
    }
}