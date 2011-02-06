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
using System.Diagnostics;
using System.Windows.Forms;

namespace GMare.Forms
{
    /// <summary>
    /// About form.
    /// </summary>
    public partial class AboutForm : Form
    {
        #region Constructor

        /// <summary>
        /// Constructs a new about form.
        /// </summary>
        public AboutForm()
        {
            InitializeComponent();
            lbl_Version.Text = "Version: " + Application.ProductVersion;
        }

        #endregion

        #region Events

        /// <summary>
        /// Rich textbox link clicked.
        /// </summary>
        private void rtb_Information_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            // Links.
            if (e.LinkText == "http://p.yusukekamiyamane.com/")
                System.Diagnostics.Process.Start("http://p.yusukekamiyamane.com/");

            if (e.LinkText == "www.yoyogames.com/make")
                System.Diagnostics.Process.Start("www.yoyogames.com/make");

            if (e.LinkText == "www.ismavatar.com")
                System.Diagnostics.Process.Start("www.ismavatar.com");

            if (e.LinkText == "www.sharpziplib.com")
                System.Diagnostics.Process.Start("www.icsharpcode.net/OpenSource/SharpZipLib/Download.aspx");

            if (e.LinkText == "www.binaryphoenix.com")
                System.Diagnostics.Process.Start("www.binaryphoenix.com");
        }

        /// <summary>
        /// Pyxosoft link clicked.
        /// </summary>
        private void lnklbl_Pyxosoft_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Start the web browser.
            Process.Start("www.pyxosoft.com");
        }

        #endregion
    }
}