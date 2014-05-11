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
using GameMaker.Resource;

namespace GMare.Forms
{
    /// <summary>
    /// UI to select corrective actions for instances with missing objects
    /// </summary>
    public partial class InstanceConflictForm : Form
    {
        #region Fields

        private string _instance = "";                  // Instance name
        private GMResource _object = new GMResource();  // Selected object resource data

        #endregion

        #region Properties

        /// <summary>
        /// Gets the node data from selection
        /// </summary>
        public GMResource Object
        {
            get { return _object; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Create an instance form
        /// </summary>
        /// <param name="nodes">The object nodes to display</param>
        /// <param name="instance">The name of the instance</param>
        public InstanceConflictForm(TreeNode[] nodes, string instance, Image[] array, Bitmap glyph)
        {
            InitializeComponent();

            // Get instance name
            _instance = instance;

            // Add object nodes
            tvObjects.Nodes.AddRange(nodes);

            // Set text
            butReplace.Text = "Replace With Selected Object";
            butDelete.Text = "Delete All " + _instance + " Instances";
            lblMessage.Text = lblMessage.Text.Replace("[TAG]", _instance);
            lblObject.Text = _instance;
            pnlObject.BackgroundImage = glyph;

            // Set images
            imgMain.Images.AddRange(array);

            // Check for replace option
            CheckRequisite();
        }

        #endregion

        #region Events

        /// <summary>
        /// Replace instances click
        /// </summary>
        private void butReplace_Click(object sender, EventArgs e)
        {
            _object.Id = (tvObjects.SelectedNode.Tag as GMNode).Id;
            _object.Name = (tvObjects.SelectedNode.Tag as GMNode).Name;
            tvObjects.Nodes.Clear();
            this.Close();
        }

        /// <summary>
        /// Delete instances click
        /// </summary>
        private void butDelete_Click(object sender, EventArgs e)
        {
            _object.Id = -1;
            tvObjects.Nodes.Clear();
            this.Close();
        }

        /// <summary>
        /// Objects tree view mouse down
        /// </summary>
        private void tvObjects_MouseDown(object sender, MouseEventArgs e)
        {
            // If the left mouse button was clicked and a node exists at the mouse location
            if (e.Button == MouseButtons.Left && tvObjects.GetNodeAt(e.X, e.Y) != null)
                tvObjects.SelectedNode = tvObjects.GetNodeAt(e.X, e.Y);
        }

        /// <summary>
        /// Objects tree view after node select
        /// </summary>
        private void tvObjects_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Check for replace option
            CheckRequisite();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks if the replace option is valid
        /// </summary>
        private void CheckRequisite()
        {
            // If no node has been selected, disable replace option
            if (tvObjects.SelectedNode == null)
            {
                butReplace.Text = "Replace With Selected Object";
                butReplace.Enabled = false;
                return;
            }

            // If the selected node is an object, allow replace, else do not
            if ((tvObjects.SelectedNode.Tag as GMNode).NodeType == GameMaker.Common.GMNodeType.Child)
            {
                butReplace.Enabled = true;
                butReplace.Text = "Replace All " + _instance + " With " + tvObjects.SelectedNode.Text;
            }
            else
            {
                butReplace.Enabled = false;
                butReplace.Text = "Replace With Selected Object";
            }
        }

        #endregion
    }
}
