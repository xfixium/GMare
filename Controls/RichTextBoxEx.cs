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
using System.Runtime.InteropServices;

namespace GMare.Controls
{
    public partial class RichTextBoxEx : RichTextBox
    {
        #region Fields

        private NativeMethods.RECT _borderRect;  // Visual styles border rectangle.

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new rich textbox ex.
        /// </summary>
        public RichTextBoxEx()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        /// <summary>
        /// Copy tool strip menu item click.
        /// </summary>
        private void tsmi_Copy_Click(object sender, EventArgs e)
        {
            // Copy all the selected text.
            this.Copy();
        }

        /// <summary>
        /// Select all tool strip menu item click.
        /// </summary>
        private void tsmi_SelectAll_Click(object sender, EventArgs e)
        {
            // Select all the text.
            this.SelectAll();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Filter windows messages to render border visual style.
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeMethods.WM_NCPAINT: { WmNcpaint(ref m); break; }
                case NativeMethods.WM_NCCALCSIZE: { WmNccalcsize(ref m); break; }
                case NativeMethods.WM_THEMECHANGED: { UpdateStyles(); break; }
                default: { base.WndProc(ref m); break; }
            }
        }

        #endregion

        #region Visual Style

        /// <summary>
        /// Calculates the size of the window frame and client area of the control
        /// </summary>
        void WmNccalcsize(ref Message m)
        {
            // let the control draw the scrollbar if necessary.
            base.WndProc(ref m);

            // If the visual styles are not enabled and BorderStyle is not Fixed3D then we have nothing more to do.
            if (!this.RenderWithVisualStyles())
                return;

            // Contains detailed information about WM_NCCALCSIZE message
            NativeMethods.NCCALCSIZE_PARAMS par = (NativeMethods.NCCALCSIZE_PARAMS)
                Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.NCCALCSIZE_PARAMS));

            // Contains the client area of the control
            NativeMethods.RECT contentRect;

            // Get the DC
            IntPtr hDC = NativeMethods.GetWindowDC(this.Handle);

            // Open theme data
            IntPtr hTheme = NativeMethods.OpenThemeData(this.Handle, "EDIT");

            // Find out how much space the borders needs
            if (NativeMethods.GetThemeBackgroundContentRect(hTheme, hDC, NativeMethods.EP_EDITTEXT, NativeMethods.ETS_NORMAL,
                ref par.rgrc0, out contentRect) == NativeMethods.S_OK)
            {
                // Shrink the client area the make more space for contents.
                contentRect.Inflate(-1, -1);

                // remember the space of the borders
                this._borderRect = new NativeMethods.RECT(contentRect.Left - par.rgrc0.Left,
                    contentRect.Top - par.rgrc0.Top,
                    par.rgrc0.Right - contentRect.Right,
                    par.rgrc0.Bottom - contentRect.Bottom);

                // update LParam of the message with the new client area
                par.rgrc0 = contentRect;
                Marshal.StructureToPtr(par, m.LParam, false);

                // force the control to redraw it´s client area
                m.Result = new IntPtr(NativeMethods.WVR_REDRAW);
            }

            // release theme data handle
            NativeMethods.CloseThemeData(hTheme);

            // release DC
            NativeMethods.ReleaseDC(this.Handle, hDC);
        }

        /// <summary>
        /// The border painting is done here.
        /// </summary>
        void WmNcpaint(ref Message m)
        {
            base.WndProc(ref m);

            if (!this.RenderWithVisualStyles())
            {
                return;
            }

            ///
            // Get the DC of the window frame and paint the border using uxTheme API´s
            ///

            // set the part id to TextBox
            int partId = NativeMethods.EP_EDITTEXT;

            // set the state id of the current TextBox
            int stateId;

            if (this.Enabled)
                stateId = NativeMethods.ETS_NORMAL;
            else
                stateId = NativeMethods.ETS_DISABLED;

            // define the windows frame rectangle of the control
            NativeMethods.RECT windowRect;
            NativeMethods.GetWindowRect(this.Handle, out windowRect);
            windowRect.Right -= windowRect.Left; windowRect.Bottom -= windowRect.Top;
            windowRect.Top = windowRect.Left = 0;

            // get the device context of the window frame
            IntPtr hDC = NativeMethods.GetWindowDC(this.Handle);

            // define a rectangle inside the borders and exclude it from the DC
            NativeMethods.RECT clientRect = windowRect;
            clientRect.Left += this._borderRect.Left;
            clientRect.Top += this._borderRect.Top;
            clientRect.Right -= this._borderRect.Right;
            clientRect.Bottom -= this._borderRect.Bottom;
            NativeMethods.ExcludeClipRect(hDC, clientRect.Left, clientRect.Top, clientRect.Right, clientRect.Bottom);

            // open theme data
            IntPtr hTheme = NativeMethods.OpenThemeData(this.Handle, "EDIT");

            // make sure the background is updated when transparent background is used.
            if (NativeMethods.IsThemeBackgroundPartiallyTransparent(hTheme,
                NativeMethods.EP_EDITTEXT, NativeMethods.ETS_NORMAL) != 0)
            {
                NativeMethods.DrawThemeParentBackground(this.Handle, hDC, ref windowRect);
            }

            // draw background
            NativeMethods.DrawThemeBackground(hTheme, hDC, partId, stateId, ref windowRect, IntPtr.Zero);

            // close theme data
            NativeMethods.CloseThemeData(hTheme);

            // release dc
            NativeMethods.ReleaseDC(this.Handle, hDC);

            // we have processed the message so set the result to zero
            m.Result = IntPtr.Zero;
        }

        /// <summary>
        /// Returns true, when visual styles are enabled in this application.
        /// </summary>
        bool VisualStylesEnabled()
        {
            // Check if RenderWithVisualStyles property is available in the Application class (New feature in NET 2.0)
            Type t = typeof(Application);
            System.Reflection.PropertyInfo pi = t.GetProperty("RenderWithVisualStyles");

            if (pi == null)
            {
                // NET 1.1
                OperatingSystem os = System.Environment.OSVersion;
                if (os.Platform == PlatformID.Win32NT && (((os.Version.Major == 5) && (os.Version.Minor >= 1)) || (os.Version.Major > 5)))
                {
                    NativeMethods.DLLVersionInfo version = new NativeMethods.DLLVersionInfo();
                    version.cbSize = Marshal.SizeOf(typeof(NativeMethods.DLLVersionInfo));
                    if (NativeMethods.DllGetVersion(ref version) == 0)
                    {
                        return (version.dwMajorVersion > 5) && NativeMethods.IsThemeActive() && NativeMethods.IsAppThemed();
                    }
                }

                return false;
            }
            else
            {
                // NET 2.0
                bool result = (bool)pi.GetValue(null, null);
                return result;
            }
        }

        /// <summary>
        /// Return true, when this control should render with visual styles.
        /// </summary>
        /// <returns></returns>
        bool RenderWithVisualStyles()
        {
            return (this.BorderStyle == BorderStyle.Fixed3D && this.VisualStylesEnabled());
        }

        /// <summary>
        /// Update the control parameters.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams p = base.CreateParams;

                // remove the Fixed3D border style
                if (this.RenderWithVisualStyles() && (p.ExStyle & NativeMethods.WS_EX_CLIENTEDGE) == NativeMethods.WS_EX_CLIENTEDGE)
                    p.ExStyle ^= NativeMethods.WS_EX_CLIENTEDGE;

                return p;
            }
        }

        #endregion
    }
}