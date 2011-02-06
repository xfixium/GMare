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
    public partial class NumericUpDownEx : NumericUpDown
    {
        #region Fields

        private bool Selected = false;  // Flag used for first time select.

        #endregion

        #region Ctor

        /// <summary>
        /// Constructs a new extended numeric up down.
        /// </summary>
        public NumericUpDownEx()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// OnLeave
        /// </summary>
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            // Reset value to minimum value if text is left empty.
            if (this.Text == "")
            {
                // Set value.
                this.Value = this.Minimum;

                // Set text.
                this.Text = this.Value.ToString();

                // Redraw control.
                this.Invalidate();
            }
        }

        /// <summary>
        /// OnEnter
        /// </summary>
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            // Select all text
            this.Select(0, this.Text.Length);

            // Set first time flag.
            this.Selected = true;
        }

        /// <summary>
        /// OnKeyDown
        /// </summary>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            // If the enter key has been pressed down
            if (e.KeyCode == Keys.Return)
            {
                // Suppress key, works for numeric up and downs.
                e.SuppressKeyPress = true;

                // Select all text.
                this.Select(0, this.Text.Length);
            }
        }

        /// <summary>
        /// OnMouseDown
        /// </summary>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            // Select all text, if it's the first time the control has been clicked.
            if (this.Selected)
            {
                // Select all the text.
                this.Select(0, this.Text.Length);

                // Set first time flag.
                this.Selected = false;
            }
        }

        /// <summary>
        /// UpButton.
        /// </summary>
        public override void UpButton()
        {
            base.UpButton();

            // Select all the text.
            this.Select(0, this.Text.Length);
        }

        /// <summary>
        /// DownButton.
        /// </summary>
        public override void DownButton()
        {
            base.DownButton();

            // Select all the text.
            this.Select(0, this.Text.Length);
        }

        #endregion
    }
}