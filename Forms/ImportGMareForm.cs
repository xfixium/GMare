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
using GameMaker.Resource;
using Pyxosoft.Windows.Tools.PyxTools.Controls;
using GMare.Objects;

namespace GMare.Forms
{
    public partial class ImportGMareForm : Form
    {
        #region Fields

        private GMareRoom _import = null;  // Room to import
        private GMareRoom _room = null;    // Imported room

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a new import GMare dialog
        /// </summary>
        /// <param name="room">The room to import</param>
        public ImportGMareForm(GMareRoom room)
        {
            InitializeComponent();

            // If no room has been imported, notify the user and return
            if (room == null)
            {
                MessageBox.Show("The imported room was not loaded correctly. Please verify the project file and try again.", 
                    "GMare", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                DialogResult = DialogResult.Cancel;
                return;
            }

            // Set the room
            _import = room;
        }

        #endregion

        #region Events

        /// <summary>
        /// Checks/Unchecks all import options
        /// </summary>
        private void butCheckAll_CheckChanged(object sender)
        {
            // Iterate through checkbox controls and set their checked property
            foreach (PyxCheckBox checkBox in grpMain.Controls)
                checkBox.Checked = butCheckAll.Checked;
        }

        /// <summary>
        /// Ok button click
        /// </summary>
        private void butOk_Click(object sender, EventArgs e)
        {
            // If the user does not want to import data, return
            if (MessageBox.Show("Are  you sure you want to import the selected settings to the current room. Data will be overwritten.",
                "GMare", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            // If the user didn't check anything, return
            if (NothingChecked())
                return;

            // If all options were checked, set to the imported room and return
            if (AllChecked())
            {
                App.Room.Dispose();
                App.Room = _import;
                DialogResult = DialogResult.OK;
                return;
            }

            // If importing name, set to new one
            if (chkName.Checked)
                App.Room.Name = (string)_import.Name.Clone();

            // If importing caption, set to new one
            if (chkCaption.Checked)
                App.Room.Caption = (string)_import.Caption.Clone();

            // If importing back color, set to new one
            if (chkBackColor.Checked)
                App.Room.BackColor = _import.BackColor;

            // If importing creation code, set to new one
            if (chkCreationCode.Checked)
                App.Room.CreationCode = (string)_import.CreationCode.Clone();

            // If importing speed, set to new one
            if (chkSpeed.Checked)
                App.Room.Speed = _import.Speed;

            // If importing size, set to new one
            if (chkSize.Checked)
            {
                App.Room.Columns = _import.Columns;
                App.Room.Rows = _import.Rows;
            }

            // If importing persistence, set to new one
            if (chkPersistent.Checked)
                App.Room.Persistent = _import.Persistent;

            // If importing export projects, clear current and import new ones
            if (chkExportProject.Checked)
            {
                App.Room.Projects.Clear();
                App.Room.Projects = _import.Projects.ConvertAll(p => p.Clone());
            }

            // If importing custom colors, import new ones
            if (chkCustomColors.Checked && _import.CustomColors != null)
                App.Room.CustomColors = (int[])_import.CustomColors.Clone();

            // If importing background, import new one
            if (chkBackground.Checked && _import.Backgrounds != null && _import.Backgrounds[0] != null)
                App.Room.Backgrounds[0] = _import.Backgrounds[0].Clone();

            // If importing layers, clear current and import new ones
            if (chkLayers.Checked)
            {
                App.Room.Layers.Clear();
                App.Room.Layers = _import.Layers.ConvertAll(l => l.Clone());
            }

            // If importing brushes, clear current and import new ones
            if (chkBrushes.Checked)
            {
                App.Room.Brushes.Clear();
                App.Room.Brushes = _import.Brushes.ConvertAll(b => b.Clone());
            }

            // If importing objects, clear current and import new ones
            if (chkObjects.Checked)
            {
                App.Room.Nodes = _import.CloneNodes();
                App.Room.Objects.Clear();
                App.Room.Objects = _import.Objects.ConvertAll(o => o.Clone());
            }

            // If importing instances, clear current and import new ones
            if (chkInstances.Checked)
            {
                // Clear instances
                App.Room.Instances.FindAll(i => i.TileId == -1).Clear();
                App.Room.Instances = _import.Instances.FindAll(i => i.TileId == -1).ConvertAll(i => i.Clone());
            }

            // If importing block and block instances
            if (chkBlocks.Checked)
            {
                // Clear blocks and import blocks and all instances
                App.Room.Blocks.Clear();
                App.Room.Blocks = _import.Blocks.ConvertAll(b => b.Clone());
            }

            // If importing recent objects, clear current and import new ones
            if (chkRecentObjects.Checked)
            {
                App.Room.RecentObjects.Clear();
                App.Room.RecentObjects = _import.RecentObjects.ConvertAll(ro => ro.Clone());
            }

            // Dispose of imported room
            _import.Dispose();
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Cancel button click
        /// </summary>
        private void butCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks to see if all properties are checked
        /// </summary>
        /// <returns>If all properties are checked for import</returns>
        private bool AllChecked()
        {
            // Iterate through checkboxes, if any of them are unchecked, return false
            foreach (PyxCheckBox checkBox in grpMain.Controls)
                if (!checkBox.Checked)
                    return false;

            // All of the properties are checked
            return true;
        }

        /// <summary>
        /// Checks to see if none of the properties are checked
        /// </summary>
        /// <returns>If none of the properties are checked for import</returns>
        private bool NothingChecked()
        {
            // Iterate through checkboxes, if any of them are checked, return false
            foreach (PyxCheckBox checkBox in grpMain.Controls)
                if (checkBox.Checked)
                    return false;

            // All of the properties are not checked
            return true;
        }

        #endregion
    }
}