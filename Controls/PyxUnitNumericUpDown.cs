#region MIT

// 
// Pyxtools.
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
using GDI = System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace GMare.Controls
{
    /// <summary>
    /// Numeric up down with a unit string
    /// </summary>
    public partial class PyxUnitNumericUpDown : UserControl
    {
        #region Fields

        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxToolTip _toolTip = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxToolTip();
        public event ValueChangedHandler ValueChanged;                         // Value changed event
        public delegate void ValueChangedHandler(object sender, EventArgs e);  // Value changed event handler
        private string _toolTipText = string.Empty;                            // Tooltip text
        private string _toolTipTitle = string.Empty;                           // Tooltip title
        private string _unitOfMeasure = "Unit";                                // Unit of measure string
        private bool _useUnitOfMeasure = true;                                 // If the unit of measure should be shown
        private bool _useNumericPostfix = false;                               // If the unit of measure should be a number postfix
        private bool _alreadyFocused = false;                                  // First time selected flag

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the tool tip text
        /// </summary>
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public string ToolTipText
        {
            get { return _toolTipText; }
            set { _toolTipText = value; _toolTip.SetToolTip(this, value); _toolTip.SetToolTip(nudMain, value); _toolTip.SetToolTip(lblUnit, value); }
        }

        /// <summary>
        /// Gets or sets the tooltip title
        /// </summary>
        public string ToolTipTitle
        {
            get { return _toolTipTitle; }
            set { _toolTipTitle = value; _toolTip.ToolTipTitle = value; }
        }

        /// <summary>
        /// Gets or sets the use of a number postfix
        /// </summary>
        public bool UseNumericPostfix
        {
            get { return _useNumericPostfix; }
            set { _useNumericPostfix = value; SetPostfix(); }
        }

        /// <summary>
        /// Gets or sets the use of the unit of measure
        /// </summary>
        public bool UseUnitOfMeasure
        {
            get { return _useUnitOfMeasure; }
            set { _useUnitOfMeasure = value; lblUnit.Visible = _useUnitOfMeasure; }
        }

        /// <summary>
        /// Gets or sets the unit of measure string
        /// </summary>
        public string UnitOfMeasure
        {
            get { return _unitOfMeasure; }
            set { _unitOfMeasure = value; lblUnit.Text = _unitOfMeasure; }
        }

        /// <summary>
        /// Gets input mask string
        /// </summary>
        public string Mask
        {
            get { return txtMain.Mask; }
        }

        /// <summary>
        /// gets or sets minimum amount
        /// </summary>
        public decimal Minimum
        {
            get { return nudMain.Minimum; }
            set { nudMain.Minimum = value; }
        }

        /// <summary>
        /// Gets or sets maximum amount
        /// </summary>
        public decimal Maximum
        {
            get { return nudMain.Maximum; }
            set 
            { 
                nudMain.Maximum = value;
                txtMain.MaxLength = GetMaxLength();
                SetMask();
            }
        }

        /// <summary>
        /// Gets or sets increment amount
        /// </summary>
        public decimal Increment
        {
            get { return nudMain.Increment; }
            set { nudMain.Increment = value; }
        }

        /// <summary>
        /// Gets or sets the number of decimal places to use
        /// </summary>
        public int DecimalPlaces
        {
            get { return nudMain.DecimalPlaces; }
            set
            {
                nudMain.DecimalPlaces = value;
                txtMain.MaxLength = GetMaxLength();
                SetMask();
            }
        }

        /// <summary>
        /// Gets or sets the numeric value
        /// </summary>
        public decimal Value
        {
            get { return nudMain.Value; }
            set { nudMain.Value = value; UpdateLabel(); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new PyxUnitUpDown
        /// </summary>
        public PyxUnitNumericUpDown()
        {
            InitializeComponent();

            // Set values for designer
            txtMain.Text = nudMain.Value.ToString();
            txtMain.MaxLength = txtMain.MaxLength = GetMaxLength();
            SetMask();
        }

        #endregion

        #region Events

        /// <summary>
        /// On control size changed
        /// </summary>
        private void PyxUnitUpDown_SizeChanged(object sender, EventArgs e)
        {
            UpdateLabel();
        }

        /// <summary>
        /// On control enter
        /// </summary>
        private void PyxUnitNumericUpDown_Enter(object sender, EventArgs e)
        {
            // Give the textbox focus
            txtMain.Focus();
        }

        /// <summary>
        /// Label click
        /// </summary>
        private void lblUnit_Click(object sender, EventArgs e)
        {
            // Transfer focus to textbox.
            txtMain.Focus();
        }

        /// <summary>
        /// On nud value changed
        /// </summary>
        private void nudMain_ValueChanged(object sender, EventArgs e)
        {
            txtMain.Text = nudMain.Value.ToString();
            SetPostfix();
            OnValueChanged();
        }

        /// <summary>
        /// On textbox text changed
        /// </summary>
        private void txtMain_TextChanged(object sender, EventArgs e)
        {
            UpdateLabel();
        }

        /// <summary>
        /// On textbox leave
        /// </summary>
        private void txtMain_Leave(object sender, EventArgs e)
        {
            SetValue();
            _alreadyFocused = false;
        }

        /// <summary>
        /// On textbox mouse up
        /// </summary>
        private void txtMain_MouseUp(object sender, MouseEventArgs e)
        {
            // If the text box has not recieved focus and there is no selection
            if (!_alreadyFocused && txtMain.SelectionLength == 0)
            {
                _alreadyFocused = true;
                txtMain.SelectAll();
            }
        }

        /// <summary>
        /// On textbox key down
        /// </summary>
        private void txtMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                SetValue();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the unit of measure label
        /// </summary>
        private void UpdateLabel()
        {
            // Resizes the unit label
            GDI.Graphics gfx = this.CreateGraphics();
            GDI.SizeF size = gfx.MeasureString(txtMain.Text.ToString(), this.Font);
            gfx.Dispose();
            lblUnit.Width = ClientSize.Width - (int)size.Width - nudMain.Width;
            lblUnit.Location = new GDI.Point((int)size.Width - 1, lblUnit.Location.Y);
        }

        /// <summary>
        /// Sets the value of the internal nud, validates text value before doing so
        /// </summary>
        private void SetValue()
        {
            try
            {
                // Try to convert the text to a decimal
                decimal value = decimal.Parse(txtMain.Text);
                
                // If the value is within bounds
                if (value < nudMain.Minimum || value > nudMain.Maximum)
                    nudMain_ValueChanged(this, EventArgs.Empty);  // Update with previous value
                else
                    nudMain.Value = value;  // Set new value
            }
            catch (Exception)
            {
                // Update text with previous value
                nudMain_ValueChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Sets numeric postfix
        /// </summary>
        private void SetPostfix()
        {
            // If using postfixing
            if (_useNumericPostfix == true)
            {
                try
                {
                    // Get number index
                    int index = txtMain.Text.Contains(".") ? txtMain.Text.IndexOf(".") : txtMain.Text.Length - 1;

                    // Parse value
                    int value = int.Parse(txtMain.Text);
                    int part = int.Parse(txtMain.Text[index].ToString());

                    // Set postfix
                    if ((value >= 11 && value <= 13) || part == 0 || (part >= 4 && part <= 9))
                        lblUnit.Text = "th";
                    else if (part == 1)
                        lblUnit.Text = "st";
                    else if (part == 2)
                        lblUnit.Text = "nd";
                    else if (part == 3)
                        lblUnit.Text = "rd";
                }
                catch (Exception)
                {

                }
            }
        }

        /// <summary>
        /// Get the maximum length of the string
        /// </summary>
        private int GetMaxLength()
        {
            SetMask();

            // Get the maximum amount the characters can be, plus the decimal places, plus the decimal iteself
            return txtMain.MaxLength = nudMain.Maximum.ToString().Length + nudMain.DecimalPlaces + (nudMain.DecimalPlaces > 0 ? 1 : 0);
        }

        /// <summary>
        /// Set string mask
        /// </summary>
        private void SetMask()
        {
            // String mask
            string mask = "";

            // Get places before decimal
            for (int i = 0; i < nudMain.Maximum.ToString().Length; i++)
                mask += "0";

            // Set mask
            txtMain.Mask = mask;

            // If no decimal places, return
            if (nudMain.DecimalPlaces == 0)
                return;

            // Set decimal
            mask += ".";

            // Get places after the decimal
            for (int i = 0; i < nudMain.DecimalPlaces; i++)
                mask += "9";

            // Set mask
            txtMain.Mask = mask;
            txtMain.Invalidate();
        }

        /// <summary>
        /// On value changed
        /// </summary>
        public void OnValueChanged()
        {
            // If the event has listeners, trigger value changed event
            if (ValueChanged != null)
                ValueChanged(this, EventArgs.Empty);
        }

        #endregion
    }
}
