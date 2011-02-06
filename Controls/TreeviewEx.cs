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

namespace GMare.Controls
{
    /// <summary>
    /// Custom treeview.
    /// </summary>
    public partial class TreeviewEx : TreeView
    {
        #region Constructor

        /// <summary>
        /// Cnstructs a new treeview ex.
        /// </summary>
        public TreeviewEx()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// On Mouse Down.
        /// </summary>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            // This is a temp node for checking the clicked item
            TreeNode node = GetNodeAt(e.X, e.Y);

            // If the left mouse button was clicked
            if (e.Button == MouseButtons.Left)
            {
                // If there was a node where the user clicked
                if (node != null)
                    SelectedNode = node;
            }
        }

        #endregion
    }
}
