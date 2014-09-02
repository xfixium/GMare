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
using System.Drawing.Imaging;
using System.Collections.Generic;
using GMare.Objects;

namespace GMare.Forms
{
    /// <summary>
    /// Exports selected layers to an image file
    /// </summary>
    public partial class ExportImageForm : Form
    {
        #region Constructors

        /// <summary>
        /// Constructs a new export image form
        /// </summary>
        public ExportImageForm()
        {
            InitializeComponent();

            // Add layers to the list box and select the first one if available
            lstLayers.Items.AddRange(App.Room.Layers.ToArray());
            lstLayers.SelectedIndex = lstLayers.Items.Count > 0 ? 0 : -1;
        }

        #endregion

        #region Events

        /// <summary>
        /// Ok button click
        /// </summary>
        private void butExport_Click(object sender, EventArgs e)
        {
            // Create a save file dialog box
            using (SaveFileDialog form = new SaveFileDialog())
            {
                // Set file format filter
                form.Filter = "Portable Network Graphics (.png)|*.png|Windows Bitmap (.bmp)|*.bmp;";

                // If the dialog result was not Ok, return
                if (form.ShowDialog() != DialogResult.OK)
                    return;

                // Create a new list of layers
                List<GMareLayer> layers = new List<GMareLayer>();

                // Add the selected layers to the list
                foreach (object obj in lstLayers.CheckedItems)
                    layers.Add((GMareLayer)obj);

                // Get the room image
                Bitmap image = App.Room.ToBitmap(layers, butDrawInstances.Checked);

                // Save the room to file
                switch (form.FilterIndex)
                {
                    case 1: image.Save(form.FileName, ImageFormat.Png); break;
                    case 2: image.Save(form.FileName, ImageFormat.Bmp); break;
                }
            }

            // Set dialog result
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Cancel button click
        /// </summary>
        private void butCancel_Click(object sender, EventArgs e)
        {
            // Set dialog result
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Check/Uncheck all layers
        /// </summary>
        private void butCheckAll_CheckChanged(object sender)
        {
            // Iterate through items
            for (int i = 0; i < lstLayers.Items.Count; i++)
            {
                // Set checked state
                lstLayers.SetItemChecked(i, butCheckAll.Checked);
            }

            // Update rendering
            lstLayers.Invalidate();
        }

        #endregion
    }
}