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
    public partial class PanelEx : Panel
    {
        #region Fields

        private NativeMethods.RECT _borderRect;

        #endregion

        #region Constructor

        public PanelEx()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Filter windows messages.
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

        #region Methods

        /// <summary>
        /// Calculates the size of the window frame and client area of the control.
        /// </summary>
        void WmNccalcsize(ref Message m)
        {
            // let the control draw the scrollbar if necessary.
            base.WndProc(ref m);
            
            // If the visual styles are not enabled and BorderStyle is not Fixed3D return.
            if (this.RenderWithVisualStyles() == false)
                return;

            // Contains detailed information about WM_NCCALCSIZE message.
            NativeMethods.NCCALCSIZE_PARAMS par = (NativeMethods.NCCALCSIZE_PARAMS)
               System.Runtime.InteropServices.Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.NCCALCSIZE_PARAMS));

            // Contains the client area of the control.
            NativeMethods.RECT clientRect;

            // Get the device context.
            IntPtr hDC = NativeMethods.GetWindowDC(this.Handle);

            // Get theme data.
            IntPtr theme = NativeMethods.OpenThemeData(this.Handle, "EDIT");

            // Find out how much space the borders needs
            if (NativeMethods.GetThemeBackgroundContentRect(theme, hDC, NativeMethods.EP_EDITTEXT, NativeMethods.ETS_NORMAL, ref par.rgrc0, out clientRect) == NativeMethods.S_OK)
            {
                // Shrink the client area the make more space for contents.
                clientRect.Inflate(-1, -1);

                // Remember the space of the borders
                _borderRect = new NativeMethods.RECT(clientRect.Left - par.rgrc0.Left, clientRect.Top - par.rgrc0.Top, par.rgrc0.Right - clientRect.Right, par.rgrc0.Bottom - clientRect.Bottom);

                // Update LParam of the message with the new client area
                par.rgrc0 = clientRect;
                System.Runtime.InteropServices.Marshal.StructureToPtr(par, m.LParam, false);

                // Force the control to redraw it´s client area.
                m.Result = new IntPtr(NativeMethods.WVR_REDRAW);
            }

            // Release theme data.
            NativeMethods.CloseThemeData(theme);

            // Release the device context.
            NativeMethods.ReleaseDC(this.Handle, hDC);
        }

        /// <summary>
        /// The border painting is done here.
        /// </summary>
        void WmNcpaint(ref Message m)
        {
            // Process base paint message.
            base.WndProc(ref m);

            // If not rendering with visual styles, return.
            if (this.RenderWithVisualStyles() == false)
                return;

            ///
            // Get the DC of the window frame and paint the border using uxTheme API´s
            ///

            // Set the part id to TextBox
            int partId = NativeMethods.EP_EDITTEXT;

            // Set the state id.
            int stateId;

            // If this control is enabled.
            if (this.Enabled)
                stateId = NativeMethods.ETS_NORMAL;
            else
                stateId = NativeMethods.ETS_DISABLED;

            // Define the windows frame rectangle of the control.
            NativeMethods.RECT windowRect;
            NativeMethods.GetWindowRect(this.Handle, out windowRect);
            windowRect.Right -= windowRect.Left;
            windowRect.Bottom -= windowRect.Top;
            windowRect.Top = windowRect.Left = 0;

            // Get the device context of the control.
            IntPtr hDC = NativeMethods.GetWindowDC(this.Handle);

            // Define a rectangle inside the borders and exclude it from the DC.
            NativeMethods.RECT clientRect = windowRect;
            clientRect.Left += this._borderRect.Left;
            clientRect.Top += this._borderRect.Top;
            clientRect.Right -= this._borderRect.Right;
            clientRect.Bottom -= this._borderRect.Bottom;
            
            // Set exclude clip rectangle.
            NativeMethods.ExcludeClipRect(hDC, clientRect.Left, clientRect.Top, clientRect.Right, clientRect.Bottom);

            // open theme data
            IntPtr hTheme = NativeMethods.OpenThemeData(this.Handle, "EDIT");

            // make sure the background is updated when transparent background is used.
            if (NativeMethods.IsThemeBackgroundPartiallyTransparent(hTheme,
                NativeMethods.EP_EDITTEXT, NativeMethods.ETS_NORMAL) != 0)
            {
                NativeMethods.DrawThemeParentBackground(this.Handle, hDC, ref windowRect);
            }

            // Draw background.
            NativeMethods.DrawThemeBackground(hTheme, hDC, partId, stateId, ref windowRect, IntPtr.Zero);

            // Close theme data.
            NativeMethods.CloseThemeData(hTheme);

            // Release the device context.
            NativeMethods.ReleaseDC(this.Handle, hDC);

            // We have processed the message so set the result to zero.
            m.Result = IntPtr.Zero;
        }

        /// <summary>
        /// Returns true, when visual styles are enabled in this application.
        /// </summary>
        bool VisualStylesEnabled()
        {
            // Check if RenderWithVisualStyles property is available in the Application class.
            Type t = typeof(Application);
            System.Reflection.PropertyInfo pi = t.GetProperty("RenderWithVisualStyles");

            // If no property information was gotten, return false.
            if (pi == null)
                return false;

            // Get result.
            bool result = (bool)pi.GetValue(null, null);
            return result;

        }

        /// <summary>
        /// Return true, when this control should render with visual styles.
        /// </summary>
        bool RenderWithVisualStyles()
        {
            return (this.BorderStyle == BorderStyle.Fixed3D && this.VisualStylesEnabled());
        }

        /// <summary>
        /// Gets the control parameters.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                // Create parameters.
                CreateParams p = base.CreateParams;

                // Remove the Fixed3D border style.
                if (this.RenderWithVisualStyles() == true && (p.ExStyle & NativeMethods.WS_EX_CLIENTEDGE) == NativeMethods.WS_EX_CLIENTEDGE)
                    p.ExStyle ^= NativeMethods.WS_EX_CLIENTEDGE;

                return p;
            }
        }

        #endregion
    }
}
