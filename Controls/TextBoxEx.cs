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
using System.ComponentModel;

namespace GMare.Controls
{
    /// <summary>
    /// A standard textbox, but with a select all feature upon mouse down.
    /// </summary>
    public partial class TextBoxEx : TextBox
    {
        #region Fields

        private bool Selected = false;  // Whether first time selected.

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new textbox ex.
        /// </summary>
        public TextBoxEx()
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
            this.SelectAll();

            // First time select
            this.Selected = true;
        }

        /// <summary>
        /// OnKeyDown
        /// </summary>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            // If the enter key has been pressed.
            if (e.KeyCode == Keys.Enter)
            {
                // This prevents window's key sound.
                e.SuppressKeyPress = true;
                this.SelectAll();
            }
        }
        /// <summary>
        /// OnMouseDown
        /// </summary>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            // Select all text, if it's the first time the control has been clicked
            if (this.Selected)
            {
                this.SelectAll();
                this.Selected = false;
            }
        }

        #endregion
    }
}