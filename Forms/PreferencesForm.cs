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
using System.IO;
using System.Configuration;
using System.Windows.Forms;
using GMare.Objects;

namespace GMare.Forms
{
    /// <summary>
    /// Dialog to change app settings for vaious UI properties
    /// </summary>
    public partial class PreferencesForm : Form
    {
        #region Fields

        private int _undoRedoMaximum = 0;      // The maximum amount allowed to undo/redo
        private float _brightness = 0;         // The brightness of lower layers
        private float _transparency = 0;       // The transparency of higher layers
        private bool _updateTextures = false;  // If texture updates are required
        private bool _updateUndoRedo = false;  // If undo/redo maximum update is required
        private bool _showTips = true;         // If showing GMare tips

        #endregion

        #region Properties

        /// <summary>
        /// Gets if undo/redo maximum update is required
        /// </summary>
        public bool UpdateUnodRedo
        {
            get { return _updateUndoRedo; }
        }

        /// <summary>
        /// Gets if texture updates are required
        /// </summary>
        public bool UpdateTextures
        {
            get { return _updateTextures; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a new preferences dialog
        /// </summary>
        public PreferencesForm()
        {
            InitializeComponent();

            // Get the config file
            Configuration config = App.GetConfig(true);

            // If the config file was not found, return
            if (config == null || config.AppSettings.Settings.Count == 0)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                return;
            }

            try
            {
                // Get the undo/redo max, brightness, and transparency settings
                bool result1 = int.TryParse(config.AppSettings.Settings[App.UndoRedoMaximumAppKey].Value, out _undoRedoMaximum);
                bool result2 = float.TryParse(config.AppSettings.Settings[App.LowerLayerBrightnessAppKey].Value, out _brightness);
                bool result3 = float.TryParse(config.AppSettings.Settings[App.UpperLayerTransparencyAppKey].Value, out _transparency);
                bool result4 = bool.TryParse(config.AppSettings.Settings[App.ShowTipsAppKey].Value, out _showTips);

                // Set UI
                nudMaximumUndoRedo.Value = result2 ? _undoRedoMaximum : 10;
                nudLowerLayerBrightness.Value = result2 ? (decimal)_brightness : -0.4m;
                nudUpperLayerTransparency.Value = result3 ? (decimal)_transparency : 0.4m;
                chkShowTips.Checked = result4 ? _showTips : true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error retrieving an app setting, app.config may be corrupted.", "GMare", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Button Ok click
        /// </summary>
        private void butOk_Click(object sender, EventArgs e)
        {
            // Get the config file
            Configuration config = App.GetConfig(false);

            // If the config file was not found, return
            if (config == null || config.AppSettings.Settings.Count == 0)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }

            try
            {
                // Set the config with user values
                config.AppSettings.Settings[App.UndoRedoMaximumAppKey].Value = nudMaximumUndoRedo.Value.ToString();
                config.AppSettings.Settings[App.LowerLayerBrightnessAppKey].Value = nudLowerLayerBrightness.Value.ToString();
                config.AppSettings.Settings[App.UpperLayerTransparencyAppKey].Value = nudUpperLayerTransparency.Value.ToString();
                config.AppSettings.Settings[App.ShowTipsAppKey].Value = chkShowTips.Checked.ToString();
                config.Save();
            }
            catch (Exception)
            {
                MessageBox.Show("Error saving the app setting, app.config may be corrupted.", "GMare", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            // If the undo/redo maximum has changed, update required
            _updateUndoRedo = _undoRedoMaximum != (int)nudMaximumUndoRedo.Value;

            // If the brightness or transparency has changed, texture updates are required
            if (_brightness != (float)nudLowerLayerBrightness.Value || _transparency != (float)nudUpperLayerTransparency.Value)
                _updateTextures = true;

            // Close dialog
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Cancel button click
        /// </summary>
        private void butCancel_Click(object sender, EventArgs e)
        {
            // Close dialog
            DialogResult = DialogResult.Cancel;
        }

        #endregion
    }
}