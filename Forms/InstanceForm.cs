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
using System.Windows.Forms;
using GameMaker.Resource;

namespace GMare.Forms
{
    public partial class InstanceForm : Form
    {
        #region Fields

        private string _instance = "";                  // Instance name.
        private GMResource _object = new GMResource();  // Selected object resource data.

        #endregion

        #region Properties

        /// <summary>
        /// Gets the node data from selection.
        /// </summary>
        public GMResource Object
        {
            get { return _object; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Create an instance form.
        /// </summary>
        /// <param name="nodes">The object nodes to display.</param>
        /// <param name="instance">The name of the instance.</param>
        public InstanceForm(TreeNode[] nodes, string instance)
        {
            InitializeComponent();

            // Get instance name.
            _instance = instance;

            // Add object nodes.
            tv_Objects.Nodes.AddRange(nodes);

            // Set text.
            btn_Replace.Text = "Select An Object To Replace With";
            btn_Delete.Text = "Delete All " + _instance + " Instances";
            label1.Text = "The instance: " + _instance + ", refers to an object that does not exist within the new imported objects. Choose an option below.";

            // Check for replace option.
            CheckRequisite();
        }

        #endregion

        #region Events

        /// <summary>
        /// Replace instances click.
        /// </summary>
        private void btn_Replace_Click(object sender, EventArgs e)
        {
            _object.Id = (tv_Objects.SelectedNode.Tag as GMNode).Id;
            _object.Name = (tv_Objects.SelectedNode.Tag as GMNode).Name;
            tv_Objects.Nodes.Clear();
            this.Close();
        }

        /// <summary>
        /// Delete instances click.
        /// </summary>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            _object.Id = -1;
            tv_Objects.Nodes.Clear();
            this.Close();
        }

        /// <summary>
        /// After node select.
        /// </summary>
        private void tv_Objects_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Check for replace option.
            CheckRequisite();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks if the replace option is valid.
        /// </summary>
        private void CheckRequisite()
        {
            // If no node has been selected, disable replace option.
            if (tv_Objects.SelectedNode == null)
            {
                btn_Replace.Text = "Select An Object To Replace With";
                btn_Replace.Enabled = false;
                return;
            }

            // If the selected node is an object, allow replace, else do not.
            if ((tv_Objects.SelectedNode.Tag as GMNode).NodeType == GameMaker.Common.GMNodeType.Child)
            {
                btn_Replace.Enabled = true;
                btn_Replace.Text = "Replace All " + _instance + " With " + tv_Objects.SelectedNode.Text;
            }
            else
            {
                btn_Replace.Enabled = false;
                btn_Replace.Text = "Select An Object To Replace With";
            }
        }

        #endregion
    }
}
