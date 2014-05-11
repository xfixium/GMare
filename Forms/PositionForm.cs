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
using System.Drawing;
using System.Windows.Forms;

namespace GMare.Forms
{
    /// <summary>
    /// UI to get coordinate data from
    /// </summary>
    public partial class PositionForm : Form
    {
        #region Fields

        private Point _position = Point.Empty;  // New position

        #endregion

        #region Properties

        /// <summary>
        /// Gets the instance position
        /// </summary>
        public Point Position
        {
            get { return _position; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new position form
        /// </summary>
        public PositionForm(int x, int y)
        {
            InitializeComponent();

            // Set current position
            nudX.Value = x;
            nudY.Value = y;
        }

        #endregion

        #region Events

        /// <summary>
        /// X value changed
        /// </summary>
        private void nudX_ValueChanged(object sender, EventArgs e)
        {
            _position.X = (int)nudX.Value;
        }

        /// <summary>
        /// Y value changed
        /// </summary>
        private void nudY_ValueChanged(object sender, EventArgs e)
        {
            _position.Y = (int)nudY.Value;
        }

        #endregion
    }
}