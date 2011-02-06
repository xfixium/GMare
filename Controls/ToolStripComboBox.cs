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
using System.Windows.Forms.Design;

namespace GMare.Controls
{
    /// <summary>
    /// A custom toolstrip combobox.
    /// </summary>
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
    public partial class ToolStripComboBox : ToolStripControlHostEx
    {
        #region Fields

        public event EventHandler SelectedIndexChanged;  // Selected index changed event.
        public event EventHandler DropDownClosed;        // Dropdownclosed event.

        #endregion

        #region Properties

        public ComboBoxEx ComboBoxControl
        {
            get { return Control as ComboBoxEx; }
        }

        public ComboBoxStyle DropDownStyle
        {
            get { return ComboBoxControl.DropDownStyle; }
            set { ComboBoxControl.DropDownStyle = value; }
        }

        public int SelectedIndex
        {
            get { return ComboBoxControl.SelectedIndex; }
            set { ComboBoxControl.SelectedIndex = value; }
        }

        public object SelectedItem
        {
            get { return ComboBoxControl.SelectedItem; }
            set { ComboBoxControl.SelectedItem = value; }
        }

        public ComboBox.ObjectCollection Items
        {
            get { return ComboBoxControl.Items; }
        }

        #endregion

        #region Constructor

        // Call the base constructor passing in a Combobox  ex instance.
        public ToolStripComboBox() : base(new ComboBoxEx()) { }

        #endregion

        #region Overrides

        /// <summary>
        /// On subscribed control events.
        /// </summary>
        /// <param name="control">Control to hook events.</param>
        protected override void OnSubscribeControlEvents(System.Windows.Forms.Control control)
        {
            // Call the base so the base events are connected.
            base.OnSubscribeControlEvents(control);
            ComboBoxEx comboBoxControl = (ComboBoxEx)control;

            comboBoxControl.SelectedIndexChanged += new EventHandler(OnSelectedIndexChanged);
            comboBoxControl.DropDownClosed += new EventHandler(OnDropDownClosed);
        }

        /// <summary>
        /// On unsubscribed control events.
        /// </summary>
        /// <param name="control">Control to un-hook events.</param>
        protected override void OnUnsubscribeControlEvents(System.Windows.Forms.Control control)
        {
            // Call the base method so the basic events are unsubscribed.
            base.OnUnsubscribeControlEvents(control);
            ComboBoxEx comboBoxControl = (ComboBoxEx)control;
            comboBoxControl.SelectedIndexChanged -= new EventHandler(OnSelectedIndexChanged);
            comboBoxControl.DropDownClosed -= new EventHandler(OnDropDownClosed);
        }

        #endregion

        #region Events

        // Raise the value changed event.
        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            // If the event is not empty.
            if (SelectedIndexChanged != null)
                SelectedIndexChanged(this, e);
        }

        // Drop down closed.
        private void OnDropDownClosed(object sender, EventArgs e)
        {
            DropDownClosed(this, e);
        }

        #endregion
    }
}
