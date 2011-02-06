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

namespace GMare.Controls
{
    public partial class ToolStripTextBoxEx : ToolStripTextBox
    {
        #region Fields

        private bool _firstSelect = false;

        #endregion

        #region Constructor

        public ToolStripTextBoxEx()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// OnEnter
        /// </summary>
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            // Select all text
            SelectAll();

            // First time select
            _firstSelect = true;
        }
        /// <summary>
        /// OnKeyDown
        /// </summary>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectAll();
            }
        }
        /// <summary>
        /// OnMouseDown
        /// </summary>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            // Select all text, if it's the first time the control has been clicked
            if (this._firstSelect)
            {
                SelectAll();
                _firstSelect = false;
            }
        }

        #endregion
    }
}
