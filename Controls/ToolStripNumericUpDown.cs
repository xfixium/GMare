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
using System.Windows.Forms.Design;

namespace GMare.Controls
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
    public partial class ToolStripNumericUpDown : ToolStripControlHostEx
    {
        #region Fields

        public event EventHandler ValueChanged;

        #endregion

        #region Properties

        public NumericUpDownEx NumericUpDownControl
        {
            get { return Control as NumericUpDownEx; }
        }
        public decimal Value
        {
            get { return NumericUpDownControl.Value; }
            set { NumericUpDownControl.Value = value; }
        }
        public decimal Maximum
        {
            get { return NumericUpDownControl.Maximum; }
            set { NumericUpDownControl.Maximum = value; }
        }
        public decimal Minimum
        {
            get { return NumericUpDownControl.Minimum; }
            set { NumericUpDownControl.Minimum = value; }
        }

        #endregion

        #region Constructor

        // Call the base constructor passing in a GmareComboBox instance
        public ToolStripNumericUpDown()
            : base(new NumericUpDownEx())
        {
        }

        #endregion

        #region Overrides

        protected override void OnSubscribeControlEvents(System.Windows.Forms.Control control)
        {
            // Call the base so the base events are connected.
            base.OnSubscribeControlEvents(control);

            // Cast the control to a NumericUpDownEx control.
            NumericUpDownEx numericUpDownExControl = (NumericUpDownEx)control;

            // Add the event.
            numericUpDownExControl.ValueChanged += new EventHandler(OnValueChanged);
        }

        protected override void OnUnsubscribeControlEvents(System.Windows.Forms.Control control)
        {
            // Call the base method so the basic events are unsubscribed.
            base.OnUnsubscribeControlEvents(control);

            // Cast the control to a NumericUpDownEx control.
            NumericUpDownEx numericUpDownExControl = (NumericUpDownEx)control;

            // Remove the event.
            numericUpDownExControl.ValueChanged -= new EventHandler(OnValueChanged);
        }


        #endregion

        #region Events

        // Raise the value changed event.
        private void OnValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
            {
                ValueChanged(this, e);
            }
        }

        #endregion
    }
}