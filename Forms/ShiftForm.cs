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
using GMare.Common;

namespace GMare.Forms
{
    public partial class ShiftForm : Form
    {
        #region Fields

        private ShiftDirection _direction = ShiftDirection.Up;

        #endregion

        #region Ctor

        public ShiftForm()
        {
            InitializeComponent();

            // Add all layers option.
            cmbobx_Layer.Items.Add("All Layers");

            // Add all the layers to the list box.
            cmbobx_Layer.Items.AddRange(ProjectManager.Room.Layers.ToArray());

            // Set selected layer index.
            cmbobx_Layer.SelectedIndex = 0;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Up radio button checked changed.
        /// </summary>
        private void rb_Up_CheckedChanged(object sender, EventArgs e)
        {
            // If checked, change direction.
            if (rb_Up.Checked)
                _direction = ShiftDirection.Up;
        }

        /// <summary>
        /// Right radio button checked changed.
        /// </summary>
        private void rb_Right_CheckedChanged(object sender, EventArgs e)
        {
            // If checked, change direction.
            if (rb_Right.Checked)
                _direction = ShiftDirection.Right;
        }

        /// <summary>
        /// Down radio button checked changed.
        /// </summary>
        private void rb_Down_CheckedChanged(object sender, EventArgs e)
        {
            // If checked, change direction.
            if (rb_Down.Checked)
                _direction = ShiftDirection.Down;
        }

        /// <summary>
        /// Left radio button checked changed.
        /// </summary>
        private void rb_Left_CheckedChanged(object sender, EventArgs e)
        {
            // If checked, change direction.
            if (rb_Left.Checked)
                _direction = ShiftDirection.Left;
        }

        /// <summary>
        /// Form closing.
        /// </summary>
        private void ShiftForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (cmbobx_Layer.SelectedIndex == 0)
                    ProjectManager.Room.Shift(null, _direction, (int)nud_Amount.Value);
                else
                    ProjectManager.Room.Shift((GMareLayer)cmbobx_Layer.SelectedItem, _direction, (int)nud_Amount.Value);
            }
        }

        #endregion
    }
}