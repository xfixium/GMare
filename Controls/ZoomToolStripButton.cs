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
    /// <summary>
    /// A basic control that handles common magnification options.
    /// </summary>
    public partial class ZoomToolStripButton : ToolStripDropDownButton
    {
        #region Fields

        public event ZoomChangedHandler ZoomChanged;  // Zoom changed event.
        public delegate void ZoomChangedHandler();    // Zoom changed event handler.
        private float _scale = 1.0f;                  // Scale factor.
        private bool _useIncrements = true;           // Whether to use the zoom in and zoom out options.

        #endregion

        #region Properties

        /// <summary>
        /// Gets the zoom level.
        /// </summary>
        public float Zoom
        {
            get { return _scale; }
        }

        /// <summary>
        /// Sets the scale factor.
        /// </summary>
        private float Scale
        {
            get { return _scale; }
            set { _scale = value; ZoomChanged(); }
        }

        /// <summary>
        /// Gets or sets whether to use increment options.
        /// </summary>
        public bool UseIncrements
        {
            get { return _useIncrements; }
            set
            {
                _useIncrements = value;

                // If not using increment options.
                if (_useIncrements == false)
                {
                    // Hide incremetor options.
                    tsmi_ZoomIn.Visible = false;
                    tsmi_ZoomOut.Visible = false;
                    tsmi_Separator1.Visible = false;

                    // Unhook click events.
                    tsmi_ZoomIn.Click -= new EventHandler(tsmi_Zoom_Click);
                    tsmi_ZoomOut.Click -= new EventHandler(tsmi_Zoom_Click);

                    // Set shortcuts.
                    tsmi_ZoomIn.ShortcutKeys = Keys.None;
                    tsmi_ZoomOut.ShortcutKeys = Keys.None;
                }
                else
                {
                    // Show incremetor options.
                    tsmi_ZoomIn.Visible = true;
                    tsmi_ZoomOut.Visible = true;
                    tsmi_Separator1.Visible = true;

                    // Hook click events.
                    tsmi_ZoomIn.Click += new EventHandler(tsmi_Zoom_Click);
                    tsmi_ZoomOut.Click += new EventHandler(tsmi_Zoom_Click);

                    // Set shortcuts.
                    tsmi_ZoomIn.ShortcutKeyDisplayString = "Ctrl +";
                    tsmi_ZoomIn.ShortcutKeys = ((Keys)((Keys.Control | Keys.Oemplus)));
                    tsmi_ZoomOut.ShortcutKeyDisplayString = "Ctrl -";
                    tsmi_ZoomOut.ShortcutKeys = ((Keys)((Keys.Control | Keys.OemMinus)));
                }
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new zoom toolstrip dropdown button.
        /// </summary>
        public ZoomToolStripButton()
        {
            InitializeComponent();
            
            // Hook click events.
            tsmi_100.Click += new EventHandler(tsmi_Zoom_Click);
            tsmi_200.Click += new EventHandler(tsmi_Zoom_Click);
            tsmi_300.Click += new EventHandler(tsmi_Zoom_Click);
        }

        #endregion

        #region Events

        /// <summary>
        /// Menu item click.
        /// </summary>
        private void tsmi_Zoom_Click(object sender, EventArgs e)
        {
            // Iterate through tool strip menu items.
            foreach (ToolStripItem item in this.DropDownItems)
            {
                // If the item is a tool strip menu item.
                if (item is ToolStripMenuItem)
                {
                    // If the item clicked matches the sender, uncheck it.
                    if (item == sender as ToolStripMenuItem)
                    {
                        // Set room editor scale.
                        switch ((sender as ToolStripMenuItem).Text)
                        {
                            case "100%": Scale = 1; break;
                            case "200%": Scale = 2; break;
                            case "300%": Scale = 3; break;
                            case "Zoom In": if (_scale != 3) { Scale++; } break;
                            case "Zoom Out": if (_scale != 1) { Scale--; } break;
                        }
                    }
                }
            }

            // Set checked item.
            SetChecked();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the checked item based on scale factor.
        /// </summary>
        private void SetChecked()
        {
            // Set tool strip status button text.
            this.Text = _scale.ToString() + "00%";

            // Iterate through menu items.
            foreach (ToolStripItem item in this.DropDownItems)
            {
                // If the item is a tool strip menu item, uncheck.
                if (item is ToolStripMenuItem)
                    (item as ToolStripMenuItem).Checked = false;
            }

            // Set checked item.
            if (_scale == 1)
                tsmi_100.Checked = true;
            else if (_scale == 2)
                tsmi_200.Checked = true;
            else if (_scale == 3)
                tsmi_300.Checked = true;
        }

        #endregion
    }
}