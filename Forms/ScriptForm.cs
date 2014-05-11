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

namespace GMare.Forms
{
    /// <summary>
    /// A form for script editing
    /// </summary>
    public partial class ScriptForm : Form
    {
        #region Fields

        private string _code = string.Empty;  // Code string

        #endregion

        #region Properties

        /// <summary>
        /// Gets the code
        /// </summary>
        public string Code
        {
            get { return _code; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new script form
        /// </summary>
        /// <param name="code">The code to insert into the editor</param>
        /// <param name="title">Title of the form</param>
        public ScriptForm(string code, string title)
        {
            InitializeComponent();

            // Set code
            txtCodeEditor.Text = code;

            // Set window title
            this.Text = title;
        }

        #endregion

        #region Events

        /// <summary>
        /// Ok button click
        /// </summary>
        private void butOk_Click(object sender, EventArgs e)
        {
            // Set dialog result
            this.DialogResult = DialogResult.OK;

            // Set code
            _code = txtCodeEditor.Text;
        }

        /// <summary>
        /// Cancel button click
        /// </summary>
        private void butCancel_Click(object sender, EventArgs e)
        {
            // Set dialog result
            this.DialogResult = DialogResult.Cancel;
        }

        #endregion
    }
}