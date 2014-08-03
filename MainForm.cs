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
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Collections.Generic;
using GMare.Forms;
using GMare.Objects;
using GMare.Controls;
using GenericUndoRedo;
using GameMaker.Resource;
using Pyxosoft.Windows.Tools.PyxTools.Controls;
using Pyxosoft.Windows.Tools.PyxTools.Controls.Design;

namespace GMare
{
    /// <summary>
    /// Main application form (Giggity)
    /// </summary>
    public partial class MainForm : Form, IRoomOwner
    {
        #region Fields

        private UndoRedoHistory<IRoomOwner> _history;   // Room undo/redo history
        private GMareBackground _background = null;     // Selected background
        private GMareLayer _layer = null;               // Selected layer
        private bool _loading = false;                  // If loading a project

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the project Undo/Redo room (Implemented IRoomOwner property)
        /// </summary>
        public RoomData Data
        {
            get { return new RoomData(App.Room); }
            set
            {
                // Make a copy of the current room persistent values
                GMareRoom room = App.Room.ClonePersistents();

                // Set room from undo redo, use previous values for persistent data
                App.Room = value.Room;
                App.Room.Objects = room.Objects;
                App.Room.Brushes = room.Brushes;
                App.Room.ScaleWarning = room.ScaleWarning;
                App.Room.BlendWarning = room.BlendWarning;

                // Update UI
                UpdateLayerList(lstLayers.SelectedIndex);

                // If editing layers, delete the selection
                //if (pnlRoomEditor.EditMode == EditType.Layers)
                //    pnlRoomEditor.Delete();

                // Clear selected instances, update room panel
                pnlRoomEditor.SelectedInstances.Clear();
                pnlRoomEditor_InstanceChanged();

                // Update UI
                txtRoomName.Text = value.Room.Name;
                txtRoomCaption.Text = value.Room.Caption;
                nudRoomColumns.Value = value.Room.Columns;
                nudRoomRows.Value = value.Room.Rows;
                nudRoomSpeed.Value = value.Room.Speed;
                butRoomPersistent.Checked = value.Room.Persistent;

                UpdateImages(value);
                UpdateTitle();
                SetClipboard();
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a new main form
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Initialize UI with data
            SetUI();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// On mouse wheel
        /// </summary>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            // If the room editor does not have focus, return
            if (!pnlRoomEditor.ContainsFocus)
                return;

            // Set magnification of the room editor
            if (e.Delta >= 0)
                trkRoomMagnify.Value = trkRoomMagnify.Value + 1 > trkRoomMagnify.Maximum ? trkRoomMagnify.Maximum : trkRoomMagnify.Value + 1;
            else
                trkRoomMagnify.Value = trkRoomMagnify.Value - 1 < trkRoomMagnify.Minimum ? trkRoomMagnify.Minimum : trkRoomMagnify.Value - 1;

            // Call magnification value changed event
            trkMagnify_ValueChanged(trkBlockMagnify, EventArgs.Empty);
        }

        /// <summary>
        /// On closing
        /// </summary>
        protected override void OnClosing(CancelEventArgs e)
        {
            // Check if the project needs to be saved before closing. If the user cancels, cancel form close
            e.Cancel = CheckSave() == DialogResult.Cancel ? true : false;
        }

        /// <summary>
        /// Process dialog key
        /// </summary>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            // If any textboxes have focus, ignore processing
            if (txtRoomName.Focused || txtRoomCaption.Focused || txtObject.Focused)
                return base.ProcessDialogKey(keyData);

            // Do action based on key
            switch (keyData)
            {
                case Keys.C: butRoomBackColor_Click(this, EventArgs.Empty); pnlRoomEditor.Invalidate(); break;
                case Keys.W: butRoomPersistent.Checked = butRoomPersistent.Checked == true ? false : true; break;
                case Keys.T: butRoomScript_Click(this, EventArgs.Empty); break;
                case Keys.L: butLayerAdd_Click(butLayerAdd, EventArgs.Empty); pnlRoomEditor.Invalidate(); break;
                case Keys.E: butLayerOption_Click(butLayerEdit, EventArgs.Empty); pnlRoomEditor.Invalidate(); break;
                case Keys.M: butLayerOption_Click(butLayerMove, EventArgs.Empty); pnlRoomEditor.Invalidate(); break;
                case Keys.V: butLayerOption_Click(butLayerView, EventArgs.Empty); pnlRoomEditor.Invalidate(); break;
                case Keys.B: butBackgroundEdit_Click(butBackgroundEdit, EventArgs.Empty); pnlRoomEditor.Invalidate(); break;
                case Keys.P: SetTileTools(butBrushTool); pnlRoomEditor.Invalidate(); break;
                case Keys.F: SetTileTools(butBucketFillTool); pnlRoomEditor.Invalidate(); break;
                case Keys.S: SetTileTools(butSelectionTool); pnlRoomEditor.Invalidate(); break;
                case Keys.R: butBackgroundEdit_Click(butReplace, EventArgs.Empty); pnlRoomEditor.Invalidate(); break;
                case Keys.A: butShowInstances.Checked = butShowInstances.Checked == true ? false : true; break;
                case Keys.Q: butShowBlocks.Checked = butShowBlocks.Checked == true ? false : true; break;
                case Keys.G: butGrid.Checked = butGrid.Checked ? false : true; pnlRoomEditor.Invalidate(); break;
                case Keys.I: butGridIso.Checked = butGridIso.Checked ? false : true; pnlRoomEditor.Invalidate(); break;
                case Keys.N: butGridSnap.Checked = butGridSnap.Checked ? false : true; break;
                case Keys.O: butObjectsImport_Click(butObjectsImport, EventArgs.Empty); pnlRoomEditor.Invalidate(); break;
                case Keys.Right: pnlRoomEditor.Focus(); pnlRoomEditor.Flip(FlipDirectionType.Horizontal); return true;
                case Keys.Down: pnlRoomEditor.Focus(); pnlRoomEditor.Flip(FlipDirectionType.Vertical); return true;
            }

            // Process
            return base.ProcessDialogKey(keyData);
        }

        #endregion

        #region Events

        #region Main Menu

        /// <summary>
        /// Main menu clicked
        /// </summary>
        private void mnuMain_Click(object sender, EventArgs e)
        {
            // Update UI that displays the room caption and room name
            txtRoomText_Leave(txtRoomCaption, EventArgs.Empty);
            txtRoomText_Leave(txtRoomName, EventArgs.Empty);
        }

        /// <summary>
        /// Menu item click
        /// </summary>
        private void mnuMenuItem_Click(object sender, EventArgs e)
        {
            // If the calling object is not a tool strip menu item, return
            if (!(sender is ToolStripMenuItem))
                return;

            // Get the calling menu item name
            string name = (sender as ToolStripMenuItem).Name;

            // If saving and the room is empty, return
            if ((mnuSave.Name == name || mnuSaveAs.Name == name || mnuExportImage.Name == name || mnuExportBinary.Name == name) && App.Room == null)
                return;

            // If creating a room, check the current room for save, if cancelled return
            if (mnuNewProject.Name == name || mnuOpenProject.Name == name || mnuImportImage.Name == name)
                if (CheckSave() == DialogResult.Cancel)
                    return;

            // Do action based on menu item click
            if (mnuNewProject.Name == name)
            {
                // Reset automatic save to path, room editor states, and UI
                App.SavePath = "";
                pnlRoomEditor.Reset();
                SetUI();
            }
            else if (mnuOpenProject.Name == name)
            {
                // Create a new open file dialog
                using (OpenFileDialog form = new OpenFileDialog())
                {
                    // Set file format filter
                    form.Filter = "GMare Project File (.gmpx)|*.gmpx";
                    form.Title = "Open A GMare Project File";

                    // Stop the room editor from processing mouse events from double click file selection
                    pnlRoomEditor.AvoidMouseEvents = true;
                    pnlBackground.AvoidMouseEvents = true;

                    // If the dialog result is Ok
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // Set project room
                        pnlRoomEditor.Reset();
                        App.SetProject(form.FileName);

                        // Set textures for loaded objects, update blocks and object names
                        App.SetTextures();
                        App.Room.UpdateBlockInstances();
                        App.Room.UpdateInstanceObjectNames();
                        UpdateUI();
                        nudRoomGridX.Value = App.Room.Backgrounds[0].TileWidth;
                        nudRoomGridY.Value = App.Room.Backgrounds[0].TileHeight;
                    }
                }
            }
            else if (mnuSaveBackground.Name == name)
            {
                // If the background is empty or the background's image data is empty
                if (_background == null || _background.Image == null)
                    return;

                // Create a save file dialog
                using (SaveFileDialog form = new SaveFileDialog())
                {
                    // Set filter
                    form.Filter = "Portable Network Graphics (.png)|*.png|Windows Bitmap (.bmp)|*.bmp;";
                    form.Title = "Save Background Image";

                    // If the dialog result was Ok, save the background
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // Save the image based on format selected
                        switch (form.FilterIndex)
                        {
                            case 1: _background.Image.ToBitmap().Save(form.FileName, ImageFormat.Png); break;
                            case 2: _background.Image.ToBitmap().Save(form.FileName, ImageFormat.Bmp); break;
                        }
                    }
                }
            }
            else if (mnuSave.Name == name)
            {
                App.SaveProject(App.SavePath);
                App.Changed = false;
            }
            else if (mnuSaveAs.Name == name)
            {
                // Create a save file dialog
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    // Set filter
                    sfd.Filter = "GMare Project File (.gmpx)|*.gmpx";
                    sfd.Title = "Save Project As...";

                    // If the dialog result was Ok, save the project
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        // Save the project
                        if (App.SaveProject(sfd.FileName))
                            App.SavePath = sfd.FileName;

                        // The project has not made any new changes
                        App.Changed = false;
                    }
                }
            }
            else if (mnuImportImage.Name == name)
            {
                // Create an open file dialog to get the image path
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    // Set file format filter
                    ofd.Filter = "Supported Files (.png, .bmp, .gif)|*.png;*.bmp;*gif;";
                    ofd.Title = "Import Project From Image";

                    // If the dialog result is ok, set the project room
                    if (ofd.ShowDialog() == DialogResult.OK)
                        App.SetProject(ofd.FileName);

                    // If the room is still empty, create a default room
                    if (App.Room == null)
                    {
                        // Create a new room with a new layer
                        App.Room = new GMareRoom();
                        App.Room.Layers.Add(new GMareLayer(App.Room.Columns, App.Room.Rows));
                    }

                    // Project changed
                    App.Changed = true;

                    // Update UI
                    UpdateUI();
                    nudRoomGridX.Value = App.Room.Backgrounds[0].TileWidth;
                    nudRoomGridY.Value = App.Room.Backgrounds[0].TileHeight;
                }
            }
            else if (mnuImportGMare.Name == name)
            {
                // Create an open file dialog to get the image path
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    // Set filter
                    ofd.Filter = "GMare Project File (.gmpx)|*.gmpx";
                    ofd.Title = "Import GMare Project";

                    // If the dialog result is not ok, return
                    if (ofd.ShowDialog() != DialogResult.OK)
                        return;

                    // Create a new import GMare project dialog
                    using (ImportGMareForm form = new ImportGMareForm(App.GetProject(ofd.FileName)))
                    {
                        // If the dialog result is not ok, return
                        if (form.ShowDialog() != DialogResult.OK)
                            return;

                        // Update UI
                        App.SetTextures();
                        App.Room.UpdateBlockInstances();
                        UpdateUI();
                        nudRoomGridX.Value = App.Room.Backgrounds[0].TileWidth;
                        nudRoomGridY.Value = App.Room.Backgrounds[0].TileHeight;
                    }
                }
            }
            else if (mnuExportImage.Name == name)
            {
                // If the background is empty or the background's image data is empty
                if (_background == null || _background.Image == null)
                    return;

                // Create a new export image dialog
                using (ExportImageForm form = new ExportImageForm(App.Room.Layers, _background.GetCondensedTileset(), App.Room.RoomSize, _background.TileSize))
                {
                    form.ShowDialog();
                }
            }
            else if (mnuExportBinary.Name == name)
            {
                // Create a new export binary dialog
                using (ExportBinaryForm form = new ExportBinaryForm())
                {
                    form.ShowDialog();

                    // Set room name based on native project name change
                    txtRoomName.Text = App.Room.Name;

                    // Push history
                    if (form.Changed)
                        PushHistory();
                }
            }
            else if (mnuExportGMProject.Name == name)
            {
                // Create a new open file dialog to choose a GM project to export to
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    // Set file format filter
                    ofd.Filter = "Game Maker Project Files (.gmk, .gm6, .gmd .gm81 .gmx)|*.gmk;*.gm6;*.gmd;*.gm81;*.gmx;";
                    ofd.Title = "Open A Game Maker Project For Export";

                    // If the dialog result is Ok
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        // Create a new GM export dialog
                        using (ExportGMProjectForm gmform = new ExportGMProjectForm(App.GetGMProject(ofd.FileName), ofd.FileName))
                        {
                            gmform.ShowDialog();
                        }
                    }
                }
            }
            else if (mnuPreferences.Name == name)
            {
                // Create a new preferences dialog
                using (PreferencesForm form = new PreferencesForm())
                {
                    // If the dialog result is not Ok, return
                    if (form.ShowDialog() != DialogResult.OK)
                        return;

                    // If unod/redo update is required, notify the user
                    if (form.UpdateUnodRedo)
                    {
                        MessageBox.Show("Changes to the Undo/Redo maximum will take affect on restart.", "GMare", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }

                    // If texture updates are required, reset textures
                    if (_background != null && _background.Image != null && form.UpdateTextures)
                    {
                        App.SetTextures();
                        pnlRoomEditor.Image = _background.GetCondensedTileset();
                    }
                }
            }
            else if (mnuExit.Name == name)
                this.Close();
            else if (mnuUndo.Name == name)
                butEdit_Click(butUndo, EventArgs.Empty);
            else if (mnuRedo.Name == name)
                butEdit_Click(butRedo, EventArgs.Empty);
            else if (mnuCut.Name == name)
                butEdit_Click(butCut, EventArgs.Empty);
            else if (mnuCopy.Name == name)
                butEdit_Click(butCopy, EventArgs.Empty);
            else if (mnuPaste.Name == name)
                butEdit_Click(butPaste, EventArgs.Empty);
            else if (mnuDelete.Name == name)
                butEdit_Click(butDelete, EventArgs.Empty);
            else if (mnuContents.Name == name)
                Help.ShowHelp(this, Application.StartupPath + @"\GMare Help.chm");
            else if (mnuAbout.Name == name)
            {
                // Create a new about form, and display it
                using (AboutForm form = new AboutForm())
                {
                    form.ShowDialog();
                }
            }
        }

        #endregion

        #region Edit Bar

        /// <summary>
        /// Edit button click
        /// </summary>
        private void butEdit_Click(object sender, EventArgs e)
        {
            // If the calling object is not a button or the room is empty, return
            if (!(sender is PyxButton) || App.Room == null)
                return;

            // Get the calling button name
            string name = (sender as PyxButton).Name;

            // Do action based on button click
            if (butUndo.Name == name)
            {
                // If able to undo, undo
                if (_history.CanUndo == true)
                    _history.Undo();

                // Set undo/redo UI
                SetUndoRedo();
            }
            else if (butRedo.Name == name)
            {
                // If able to redo, redo
                if (_history.CanRedo == true)
                    _history.Redo();

                // Set undo/redo UI
                SetUndoRedo();
            }
            else if (butCut.Name == name)
                pnlRoomEditor.Cut();
            else if (butCopy.Name == name)
                pnlRoomEditor.Copy();
            else if (butPaste.Name == name)
                pnlRoomEditor.Paste();
            else if (butDelete.Name == name)
                pnlRoomEditor.Delete();

            // Set clipboard UI
            SetClipboard();
        }

        #endregion

        #region Room Bar

        /// <summary>
        /// Change room back color button click
        /// </summary>
        private void butRoomBackColor_Click(object sender, EventArgs e)
        {
            // If the room is empty, return
            if (App.Room == null)
                return;

            // Create a new color dialog box
            using (ColorDialog form = new ColorDialog())
            {
                // Set user custom colors
                form.CustomColors = App.Room.CustomColors;

                // If the dialog result is Ok
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Room changing
                    PushHistory();

                    // Change back color, and remember custom colors
                    App.Room.BackColor = form.Color;
                    App.Room.CustomColors = form.CustomColors;

                    // Update UI
                    pnlRoomEditor.Invalidate();
                }
            }
        }

        /// <summary>
        /// Persistent button checked changed
        /// </summary>
        private void butRoomPersistent_CheckChanged(object sender)
        {
            // If the room is empty, return
            if (App.Room == null)
                return;

            // Room changing
            PushHistory();

            // Set room persistence
            App.Room.Persistent = butRoomPersistent.Checked;
        }

        /// <summary>
        /// Room creation code button click
        /// </summary>
        private void butRoomScript_Click(object sender, EventArgs e)
        {
            // If the room is empty, return
            if (App.Room == null)
                return;

            // Create a new shift form
            using (ScriptForm form = new ScriptForm((string)App.Room.CreationCode.Clone(), "Room Creation Code"))
            {
                // If the dialog result is Ok
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Room changing
                    PushHistory();

                    // Set room creation code
                    App.Room.CreationCode = form.Code;
                }
            }
        }

        /// <summary>
        /// Room text property leave
        /// </summary>
        private void txtRoomText_Leave(object sender, EventArgs e)
        {
            // Set room text property
            txtRoomText_KeyDown(sender, new KeyEventArgs(Keys.Enter));
        }

        /// <summary>
        /// Room text property key down
        /// </summary>
        private void txtRoomText_KeyDown(object sender, KeyEventArgs e)
        {
            // If not the enter key or the room is empty, return
            if (!(sender is PyxTextBox) || e.KeyCode != Keys.Enter || App.Room == null)
                return;

            // Get the calling textbox name
            string name = (sender as PyxTextBox).Name;

            // Do action based on textbox
            if (txtRoomName.Name == name)
            {
                // If no text or no change in text, reset textbox to previous room name
                if (txtRoomName.Text == "" || txtRoomName.Text == App.Room.Name)
                {
                    txtRoomName.Text = App.Room.Name;
                    return;
                }

                // Room changing
                PushHistory();

                // Set room name
                App.Room.Name = txtRoomName.Text;
            }
            else if (txtRoomCaption.Name == name)
            {
                // If no change in text
                if (txtRoomCaption.Text == App.Room.Caption)
                {
                    txtRoomCaption.Text = App.Room.Caption;
                    return;
                }

                // Room changing
                PushHistory();

                // Set room caption
                App.Room.Caption = txtRoomCaption.Text;
            }

            // Update UI
            UpdateTitle();
        }

        /// <summary>
        /// Room numeric property changed
        /// </summary>
        private void nudRoom_ValueChanged(object sender, EventArgs e)
        {
            // If the calling object is not a numeric up down or the room is empty, return
            if (!(sender is PyxNumericUpDown) || App.Room == null)
                return;

            // Get the calling numeric up down name
            string name = (sender as PyxNumericUpDown).Name;

            // Room changing
            PushHistory();

            // Do action based on numeric change
            if (nudRoomColumns.Name == name)
                App.Room.Columns = (int)nudRoomColumns.Value;
            else if (nudRoomRows.Name == name)
                App.Room.Rows = (int)nudRoomRows.Value;
            else if (nudRoomSpeed.Name == name)
                App.Room.Speed = (int)nudRoomSpeed.Value;

            // Update UI
            pnlRoomEditor.Invalidate();
            UpdateTitle();
        }


        #endregion

        #region Tab Control

        /// <summary>
        /// Tab index changed
        /// </summary>
        private void tabMain_TabChanged(object sender, EventArgs e)
        {
            // Update the block instances, set edit mode, and update status
            App.Room.UpdateBlockInstances();
            pnlRoomEditor.EditMode = tabMain.SelectedTab == tabTiles ? EditType.Layers : EditType.Objects;
            UpdateStatusStrip();
        }

        #endregion

        #region Layers

        /// <summary>
        /// Layer add button click
        /// </summary>
        private void butLayerAdd_Click(object sender, EventArgs e)
        {
            // If the room is empty, return
            if (App.Room == null)
                return;

            // Create a new layer form
            using (AddEditLayerForm form = new AddEditLayerForm())
            {
                // If dialog result is Ok
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Room changing
                    PushHistory();

                    // Add the new layer and sort it from top to bottom
                    App.Room.Layers.Add(form.Layer);
                    App.Room.Layers.Sort(delegate(GMareLayer layer1, GMareLayer layer2) { return layer1.Depth.CompareTo(layer2.Depth); });

                    // Update the layer list and select the new layer
                    UpdateLayerList(form.Layer);
                }
            }
        }

        /// <summary>
        /// Selected layer option button click
        /// </summary>
        private void butLayerOption_Click(object sender, EventArgs e)
        {
            // If the calling object is not a button or no layer was selected or the room is empty, return
            if (!(sender is PyxButton) || lstLayers.SelectedItem == null || App.Room == null)
                return;

            // Get the calling button name
            string name = (sender as PyxButton).Name;

            // Do action based on button click
            if (butLayerEdit.Name == name)
            {
                // Create a new layer form, send selected layer for edit
                using (AddEditLayerForm form = new AddEditLayerForm((GMareLayer)lstLayers.SelectedItem))
                {
                    // If the dialog result is Ok, and the selected layer data was changed
                    if (form.ShowDialog() == DialogResult.OK && form.Changed == true)
                    {
                        // Room changing
                        PushHistory();

                        // Sort layers
                        App.Room.Layers.Sort(delegate(GMareLayer layer1, GMareLayer layer2) { return layer1.Depth.CompareTo(layer2.Depth); });

                        // Update layer list
                        UpdateLayerList((GMareLayer)lstLayers.SelectedItem);
                    }
                }
            }
            else if (butLayerDelete.Name == name)
            {
                // Warn the user
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected layer?", "GMare",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                // If yes was clicked, remove the layer
                if (result == DialogResult.Yes)
                {
                    // Room changing
                    PushHistory();

                    // Get currently selected index
                    int index = lstLayers.SelectedIndex;

                    // Remove the layer from the room, update block instances
                    App.Room.Layers.Remove((GMareLayer)lstLayers.SelectedItem);

                    // Update layer list, set index
                    UpdateLayerList(index);
                }
            }
            else if (butLayerClear.Name == name)
            {
                // Warn the user
                DialogResult result = MessageBox.Show("Are you sure you want to empty all tiles from the selected layer?", "GMare",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                // If yes was clicked, clear the layer
                if (result != DialogResult.Yes)
                    return;

                // Room changing
                PushHistory();

                // Clear tiles from the selected layer
                (lstLayers.SelectedItem as GMareLayer).Clear();
            }
            else if (butLayerMove.Name == name)
            {
                // Create a new shift form
                using (MoveLayerForm form = new MoveLayerForm())
                {
                    // If the dialog result is Ok
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // Room changing
                        PushHistory();

                        // Shift layer(s)
                        App.Room.Shift(form.Layer, form.Direction, form.Amount);
                    }
                }
            }
            else if (butLayerMerge.Name == name)
            {
                // Warn the user
                DialogResult result = MessageBox.Show("Are you sure you want to merge the selected layer to the layer below it?", "GMare",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                // If yes was clicked, clear the layer
                if (result != DialogResult.Yes)
                    return;

                // Get selected layer and the layer to merge to 
                GMareLayer topLayer = (GMareLayer)lstLayers.SelectedItem;
                GMareLayer belowLayer = App.Room.GetLayerBelow(topLayer);

                // If no layer was found below the selected layer, return
                if (belowLayer == null)
                {
                    MessageBox.Show("No layer exists below the selected layer. Merge unsuccessful.", "GMare",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }

                // Room changing
                PushHistory();

                // Merge selected layer to the one right below it
                App.Room.MergeLayers(topLayer, belowLayer);

                // Update layer list, select merged layer
                UpdateLayerList(belowLayer);
            }
            else if (butLayerView.Name == name)
            {
                // Create a new view form
                using (ViewLayerForm form = new ViewLayerForm(App.Room.Layers, false))
                {
                    // Show the form
                    form.ShowDialog();
                }
            }

            // Update UI
            App.Room.UpdateBlockInstances();
            pnlRoomEditor.Invalidate();
            lstLayers.Invalidate();
        }

        /// <summary>
        /// Layer selection changed
        /// </summary>
        private void lstLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If no layer was selected turn off layer options else, turn them on
            butLayerEdit.Enabled = lstLayers.SelectedItem == null ? false : true;
            butLayerDelete.Enabled = lstLayers.SelectedItem == null ? false : true;
            butLayerClear.Enabled = lstLayers.SelectedItem == null ? false : true;
            butLayerEdit.Enabled = lstLayers.SelectedItem == null ? false : true;
            butLayerDelete.Enabled = lstLayers.SelectedItem == null ? false : true;
            butLayerMerge.Enabled = lstLayers.SelectedItem == null ? false : true;
            butLayerClear.Enabled = lstLayers.SelectedItem == null ? false : true;

            // Set depth index
            pnlRoomEditor.DepthIndex = (lstLayers.SelectedItem as GMareLayer).Depth;

            // Set layer index
            pnlRoomEditor.LayerIndex = App.Room.Layers.IndexOf((lstLayers.SelectedItem as GMareLayer));

            // Update status strip
            UpdateStatusStrip();

            // Set clipboard UI
            SetClipboard();
        }

        /// <summary>
        /// Selected layer check changed
        /// </summary>
        private void lstLayers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // If the selected item is empty, return
            if (lstLayers.SelectedItem == null)
                return;

            // If the click is not near the checkbox hit area, keep the previous value
            if (lstLayers.PointToClient(Cursor.Position).X > 18)
                e.NewValue = e.CurrentValue;

            // Set layer visibility, invalidate the room editor
            (lstLayers.SelectedItem as GMareLayer).Visible = e.NewValue == CheckState.Checked ? true : false;
            pnlRoomEditor.Invalidate();
        }

        /// <summary>
        /// Layer list double click
        /// </summary>
        private void lstLayers_DoubleClick(object sender, EventArgs e)
        {
            // If clicking the checkbox area, return
            if (lstLayers.PointToClient(Cursor.Position).X <= 18)
                return;

            // Raise edit button event
            butLayerOption_Click(butLayerEdit, EventArgs.Empty);
        }

        #endregion

        #region Background

        /// <summary>
        /// Background edit button click
        /// </summary>
        private void butBackgroundEdit_Click(object sender, EventArgs e)
        {
            // If the calling object is not a button or the room is empty, return
            if (!(sender is PyxButton) || App.Room == null)
                return;

            // Get the calling button name
            string name = (sender as PyxButton).Name;

            // Do action based on button click
            if (butBackgroundEdit.Name == name)
            {
                // Create a new background form
                using (EditBackgroundForm form = new EditBackgroundForm(_background == null ? new GMareBackground() : _background.Clone()))
                {
                    // If dialog result was Ok
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // If the background has changed, trigger room changing
                        if (!App.Room.Backgrounds[0].Same(form.Background))
                            PushHistory();

                        // Set background
                        App.Room.Backgrounds[0] = form.Background;

                        // Update
                        UpdateBackgrounds();
                        UpdateImages(null);
                        pnlBackground_MouseUp(this, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));

                        // Set grid values
                        nudRoomGridX.Value = _background.TileSize.Width;
                        nudRoomGridY.Value = _background.TileSize.Height;

                        // Update block instances, redraw room editor
                        App.Room.UpdateBlockInstances();
                        pnlRoomEditor.Invalidate();
                    }
                }
            }
            else if (butBrushTool.Name == name)
            {
                // Set the tool mode to brush
                pnlRoomEditor.ToolMode = ToolType.Brush;
                SetTileTools(butBrushTool);
            }
            else if (butBucketFillTool.Name == name)
            {
                // Set the tool mode to bucket fill
                pnlRoomEditor.ToolMode = ToolType.Bucket;
                SetTileTools(butBucketFillTool);
            }
            else if (butSelectionTool.Name == name)
            {
                // Set the tool mode to selection
                pnlRoomEditor.ToolMode = ToolType.Selection;
                SetTileTools(butSelectionTool);
            }
            else if (butReplace.Name == name)
            {
                // Create a new tile replace form
                using (TileReplacementForm form = new TileReplacementForm(_background.GetCondensedTileset(), App.Room.Backgrounds[0].TileSize))
                {
                    // If dialog result was not Ok, return
                    if (form.ShowDialog() != DialogResult.OK)
                        return;

                    // If nothing selected, return
                    if (form.Target == null || form.Swap == null)
                        return;

                    // Room changing
                    PushHistory();

                    // If swaping tiles on all layers, else the selected layer
                    if (form.Layer == null)
                        foreach (GMareLayer temp in App.Room.Layers)
                            temp.Replace(form.Target.ToArray(), form.Swap.ToArray());
                    else
                        App.Room.Layers[App.Room.Layers.IndexOf(form.Layer)].Replace(form.Target.ToArray(), form.Swap.ToArray());
                }
            }

            // Update
            SetClipboard();
            pnlRoomEditor.Invalidate();
        }

        /// <summary>
        /// Background panel mouse up
        /// </summary>
        private void pnlBackground_MouseUp(object sender, MouseEventArgs e)
        {
            // Set room editor tile selection
            pnlRoomEditor.Tiles = pnlBackground.TileBrush;
        }

        #endregion

        #region Objects

        /// <summary>
        /// Import objects button click
        /// </summary>
        private void butObjectsImport_Click(object sender, EventArgs e)
        {
            // If the room is empty, return
            if (App.Room == null)
                return;

            // Create an open file dialog
            using (OpenFileDialog form = new OpenFileDialog())
            {
                // Set file format filter
                form.Filter = "Game Maker Project Files (.gmk, .gm6, .gmd .gm81 .gmx)|*.gmk;*.gm6;*gmd;*gm81;*.gmx;";
                form.Title = "Import Objects From Game Maker Project";

                // If the dialog result is not Ok, return
                if (form.ShowDialog() != DialogResult.OK)
                    return;

                // If retrieving objects was unsuccessful, notify the user
                if (!App.GetObjects(form.FileName))
                    MessageBox.Show("The selected project does not contain any objects. Nothing was loaded.", 
                        "GMare", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                // If no nodes were loaded, return
                if (App.Room.Nodes == null)
                {
                    // Clear any drop down items
                    mnuObjects.Items.Clear();
                    UpdateObjectUI(false);
                    return;
                }

                // Creates a context menu for the object tree
                SetObjectContextMenu(mnuObjects);

                // Reset selected object
                UpdateObjectUI(true);

                // Invalidate
                lstInstances.Invalidate();
                pnlRoomEditor.Invalidate();
                pnlBlockEditor.UpdateBackBuffer();
            }
        }

        /// <summary>
        /// Textbox object button click
        /// </summary>
        private void txtObject_ButtonClick(object sender, EventArgs e)
        {
            // Display the object context menu
            mnuObjects.Show(txtObject, new Point(txtObject.Width - 18, txtObject.Height));
        }

        /// <summary>
        /// Object menu item click
        /// </summary>
        private void mnuObjectMenuItem_Click(object sender, EventArgs e)
        {
            // If the calling object is not a menu item, return
            if (!(sender is ToolStripMenuItem))
                return;

            // Set selected item
            txtObject.Text = (sender as ToolStripMenuItem).Text;
            pnlObject.BackgroundImage = (sender as ToolStripMenuItem).Image;

            // Get GMnode from tag
            GMNode node = (GMNode)(sender as ToolStripMenuItem).Tag;
            pnlRoomEditor.SelectedObject = App.Room.Objects.Find(o => o.Resource.Id == node.Id);
            pnlBlockEditor.ObjectId = App.Room.Objects.Find(o => o.Resource.Id == node.Id).Resource.Id;
        }

        /// <summary>
        /// Selected instance changed
        /// </summary>
        private void lstInstances_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If selected instance is empty, return
            if (lstInstances.SelectedItems == null)
                return;

            // Set clipboard UI
            SetClipboard();

            // Empty selected instances in the room editor
            pnlRoomEditor.SelectedInstances.Clear();

            // New list of instances
            List<GMareInstance> instances = new List<GMareInstance>();

            // Set selected instances
            foreach (GMareInstance instance in lstInstances.SelectedItems)
                instances.Add(instance);

            // Set instances
            pnlRoomEditor.SelectedInstances = instances;

            // Update view
            pnlRoomEditor.Invalidate();

            // Set clipboard UI
            SetClipboard();
        }

        #endregion

        #region Blocks

        /// <summary>
        /// Block editor mouse down
        /// </summary>
        private void pnlBlockEditor_MouseDown(object sender, MouseEventArgs e)
        {
            // Update
            pnlRoomEditor.Invalidate();
            UpdateStatusStrip();

            // If the selected object is empty or no background has been loaded, return
            if (pnlRoomEditor.SelectedObject == null || pnlBlockEditor.Image == null)
            {
                // Update instance listbox
                UpdateInstanceList();
                return;
            }

            // Remove the object if it already exists in recent object history and recreate it to the top of the list
            App.Room.RecentObjects.RemoveAll(o => o.Resource.Id == pnlRoomEditor.SelectedObject.Resource.Id);
            App.Room.RecentObjects.Insert(0, pnlRoomEditor.SelectedObject);

            // Recreate recent object history menu items
            SetRecentObjectsMenu(mnuObjects);

            // Update instance listbox
            UpdateInstanceList();
        }

        /// <summary>
        /// Clear blocks button click
        /// </summary>
        private void butBlocksClear_Click(object sender, EventArgs e)
        {
            // Ask the user a question
            DialogResult result = MessageBox.Show("Are you sure you want to clear all block objects?", "GMare",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            // If the dialog result is Yes
            if (result == DialogResult.Yes)
            {
                // Room changing
                PushHistory();

                // Clear all block instances and update
                App.Room.ClearBlockInstances();
                pnlBlockEditor.UpdateBackBuffer();
                pnlRoomEditor.Invalidate();

                // Update instance listbox
                UpdateInstanceList();
            }
        }

        #endregion

        #region Instance Menu

        /// <summary>
        /// Instance menu opening
        /// </summary>
        private void mnuInstances_Opening(object sender, CancelEventArgs e)
        {
            // Show and allow all options by default
            for (int i = 0; i < mnuInstances.Items.Count; i++)
                mnuInstances.Items[i].Enabled = true;

            for (int i = 0; i < mnuInstances.Items.Count; i++)
                mnuInstances.Items[i].Visible = true;

            // If instances were selected
            if (pnlRoomEditor.SelectedInstances.Count > 0)
            {
                // Make the delete all option not visible
                mnuInstanceDeleteAll.Visible = false;

                // If a single instance has been selected, enable replacement options
                if (pnlRoomEditor.SelectedInstances.Count == 1)
                {
                    // If an object has been selected
                    if (pnlRoomEditor.SelectedObject != null)
                    {
                        mnuInstanceReplace.Enabled = true;
                        mnuInstanceReplaceAll.Enabled = true;
                        mnuInstanceReplace.Text = "Replace With: " + pnlRoomEditor.SelectedObject.Resource.Name;
                        mnuInstanceReplaceAll.Text = "Replace All With: " + pnlRoomEditor.SelectedObject.Resource.Name;
                    }
                    else  // No object selected. Hint to the user to select an object
                    {
                        mnuInstanceReplace.Enabled = false;
                        mnuInstanceReplaceAll.Enabled = false;
                        mnuInstanceReplace.Text = "Replace <undefined>";
                        mnuInstanceReplaceAll.Text = "Replace All <undefined>";
                    }
                }
                else  // Multi-selected instances, turn off replacement options
                {
                    mnuInstanceReplace.Visible = false;
                    mnuInstanceReplaceAll.Visible = false;
                    mnuSeparator07.Visible = false;
                }

                // Set delete all text
                if (pnlRoomEditor.SelectedInstances.Count == 1)
                {
                    mnuInstanceDeleteAll.Visible = true;
                    mnuInstanceDeleteAll.Text = "Delete All: " + pnlRoomEditor.SelectedInstances[0].ToString();
                }

                // Get all non-block instances
                List<GMareInstance> instances = pnlRoomEditor.SelectedInstances.FindAll(i => i.TileId == -1);

                // If the selected instances are all blocks
                if (instances.Count == 0)
                {
                    // Options not available for blocks
                    mnuInstanceReplace.Visible = false;
                    mnuInstanceReplaceAll.Visible = false;
                    mnuInstanceCut.Visible = false;
                    mnuInstanceCopy.Visible = false;
                    mnuInstanceSendBack.Visible = false;
                    mnuInstanceBringFront.Visible = false;
                    mnuInstancePosition.Visible = false;
                    mnuInstanceSnap.Visible = false;
                    mnuInstanceDelete.Visible = false;
                    mnuInstanceDeleteAll.Visible = false;
                    mnuSeparator07.Visible = false;
                }
            }
            else  // Disable everything
            {
                for (int i = 0; i < mnuInstances.Items.Count; i++)
                    mnuInstances.Items[i].Visible = false;
            }

            // If there is something on the clipboard, enable pasting
            mnuInstancePaste.Enabled = pnlRoomEditor.InstanceClipboard.Count > 0 ? true : false;

            // Always allow sorting
            mnuSortStandard.Visible = true;
            mnuSortStandard.Enabled = true;
            mnuSortAscending.Visible = true;
            mnuSortAscending.Enabled = true;
            mnuSortDescending.Visible = true;
            mnuSortDescending.Enabled = true;

            // Always allow instance clearing
            mnuInstancePaste.Visible = true;
            mnuInstanceClear.Visible = true;
            mnuInstanceClear.Enabled = true;
        }

        /// <summary>
        /// Instances menu item clicked
        /// </summary>
        private void mnuInstances_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // If the room is empty, return
            if (App.Room == null)
                return;

            // Close menu, as impending dialogs may be covered by it
            mnuInstances.Close();

            // Get the calling menu item name
            string name = e.ClickedItem.Name;

            // Do action based on menu item
            if (mnuSortStandard.Name == name)
                SetSortingChecked(0);
            else if (mnuSortAscending.Name == name)
                SetSortingChecked(1);
            else if (mnuSortDescending.Name == name)
                SetSortingChecked(2);
            else if (mnuInstanceReplace.Name == name)
                pnlRoomEditor.InstanceReplace();
            else if (mnuInstanceReplaceAll.Name == name)
                pnlRoomEditor.InstanceReplaceAll();
            else if (mnuInstanceCut.Name == name)
                pnlRoomEditor.Cut();
            else if (mnuInstanceCopy.Name == name)
                pnlRoomEditor.Copy();
            else if (mnuInstancePaste.Name == name)
                pnlRoomEditor.Paste();
            else if (mnuInstancePosition.Name == name)
                pnlRoomEditor.InstancePosition();
            else if (mnuInstanceBringFront.Name == name)
                pnlRoomEditor.InstanceBringFront();
            else if (mnuInstanceSendBack.Name == name)
                pnlRoomEditor.InstanceSendBack();
            else if (mnuInstanceSnap.Name == name)
                pnlRoomEditor.InstanceSnap();
            else if (mnuInstanceCode.Name == name)
                pnlRoomEditor.InstanceCode();
            else if (mnuInstanceDelete.Name == name)
                pnlRoomEditor.Delete();
            else if (mnuInstanceDeleteAll.Name == name)
                pnlRoomEditor.InstanceDeleteAll();
            else if (mnuInstanceClear.Name == name)
                pnlRoomEditor.InstanceClear();

            // Refresh and invalidate the instances, uodate the status strip
            SetSelectedInstances(true);
            lstInstances.Invalidate();
            UpdateStatusStrip();
        }

        #endregion

        #region Room Editor

        /// <summary>
        /// Room grid button click
        /// </summary>
        private void butRoomOptions_CheckChanged(object sender)
        {
            // If the calling object is not a button or the room is empty, return
            if (!(sender is PyxButton) || App.Room == null)
                return;

            // Get the calling button name
            string name = (sender as PyxButton).Name;

            // Do action based on button click
            if (butGrid.Name == name)
                pnlRoomEditor.ShowGrid = butGrid.Checked;
            else if (butGridIso.Name == name)
                pnlRoomEditor.GridMode = butGridIso.Checked ? GridType.Isometric : GridType.Normal;
            else if (butInvertGridColor.Name == name)
                pnlRoomEditor.InvertGridColor = butInvertGridColor.Checked;
            else if (butGridSnap.Name == name)
                pnlRoomEditor.Snap = butGridSnap.Checked;
            else if (butShowInstances.Name == name)
            {
                butShowInstances.Image = butShowInstances.Checked ? GMare.Properties.Resources.show_instances : GMare.Properties.Resources.hide_instances;
                pnlRoomEditor.ShowInstances = butShowInstances.Checked;
            }
            else if (butShowBlocks.Name == name)
            {
                butShowBlocks.Image = butShowBlocks.Checked ? GMare.Properties.Resources.show_blocks : GMare.Properties.Resources.hide_blocks;
                pnlRoomEditor.ShowBlocks = butShowBlocks.Checked;
                lstInstances.ShowBlocks = butShowBlocks.Checked;
                UpdateInstanceList();
            }
        }

        /// <summary>
        /// Room grid numeric value changed
        /// </summary>
        private void nudRoomGrid_ValueChanged(object sender, EventArgs e)
        {
            // If the calling object is not a numeric up down or the room is empty, return
            if (!(sender is PyxNumericUpDown) || App.Room == null)
                return;

            // Get the calling numeric up down name
            string name = (sender as PyxNumericUpDown).Name;

            // Do action based on numeric change
            if (nudRoomGridX.Name == name)
                pnlRoomEditor.GridX = (int)nudRoomGridX.Value;
            else if (nudRoomGridY.Name == name)
                pnlRoomEditor.GridY = (int)nudRoomGridY.Value;
        }

        /// <summary>
        /// Room editor room changed
        /// </summary>
        private void pnlRoomEditor_RoomChanged()
        {
            // Push new history
            PushHistory();
        }

        /// <summary>
        /// Room editor edit mode changed
        /// </summary>
        private void pnlRoomEditor_EditModeChanged()
        {
            // Update instances listbox
            UpdateStatusStrip();
        }

        /// <summary>
        /// Room editor mouse up
        /// </summary>
        private void pnlRoomEditor_MouseUp(object sender, MouseEventArgs e)
        {
            // If a room has been loaded
            if (App.Room == null)
                return;

            // Do action based on edit mode of room editor
            switch (pnlRoomEditor.EditMode)
            {
                case EditType.Layers: break;
                case EditType.Objects:

                    // Update instances listbox
                    lstInstances.Invalidate();

                    // If the selected object is empty, break
                    if (pnlRoomEditor.SelectedObject == null)
                        break;

                    // Remove the object if it already exists in recent object history and recreate it to the top of the list
                    App.Room.RecentObjects.RemoveAll(o => o.Resource.Id == pnlRoomEditor.SelectedObject.Resource.Id);
                    App.Room.RecentObjects.Insert(0, pnlRoomEditor.SelectedObject);

                    // Recreate recent object history menu items
                    SetRecentObjectsMenu(mnuObjects);
                    break;
            }

            // Set clipboard GUI
            SetClipboard();

            // Invalidate room editor
            pnlRoomEditor.Invalidate();
        }

        /// <summary>
        /// Rooom editor mouse position changed
        /// </summary>
        private void pnlRoomEditor_MousePositionChanged()
        {
            // Update status strip
            UpdateStatusStrip();
        }

        /// <summary>
        /// Instance position changeg event
        /// </summary>
        private void pnlRoomEditor_InstancesPositionChanged()
        {
            // Refresh changes
            lstInstances.Invalidate();
        }

        /// <summary>
        /// Room editor selected instance changed
        /// </summary>
        private void pnlRoomEditor_InstanceChanged()
        {
            // Set the instance listbox
            SetSelectedInstances(true);

            // Set the selected instances
            foreach (GMareInstance instance in pnlRoomEditor.SelectedInstances)
            {
                // If not showing blocks, and the instance is a block, continue
                if (!pnlRoomEditor.ShowBlocks && instance.TileId != -1)
                    continue;

                lstInstances.SelectedItems.Add(instance);
            }

            // Force redraw
            pnlRoomEditor.Invalidate();

            // Set clipboard GUI
            SetClipboard();
        }

        /// <summary>
        /// Room editor clipboard changed
        /// </summary>
        private void pnlRoomEditor_ClipboardChanged()
        {
            // Set clipboard GUI
            SetClipboard();
        }

        #endregion

        #region Magnification Trackbars

        /// <summary>
        /// Magnification trackbar value changed
        /// </summary>
        private void trkMagnify_ValueChanged(object sender, EventArgs e)
        {
            // If the calling object is not a trackbar or the room is empty, return
            if (!(sender is PyxTrackBar) || App.Room == null)
                return;

            // Get the calling trackbar name
            string name = (sender as PyxTrackBar).Name;

            // Do action based on trackbar value changed
            if (trkBackgroundMagnify.Name == name)
            {
                pnlBackground.Zoom = trkBackgroundMagnify.Value;
                lblBackgroundMagnify.Text = (trkBackgroundMagnify.Value * 100).ToString() + "%";
            }
            else if (trkBlockMagnify.Name == name)
            {
                pnlBlockEditor.Zoom = trkBlockMagnify.Value;
                lblBlockMagnify.Text = (trkBlockMagnify.Value * 100).ToString() + "%";
            }
            else if (trkRoomMagnify.Name == name)
            {
                // Offset values for scaling
                switch (trkRoomMagnify.Value)
                {
                    case 1: pnlRoomEditor.Zoom(.25f); lblRoomMagnify.Text = "25%"; break;
                    case 2: pnlRoomEditor.Zoom(.50f); lblRoomMagnify.Text = "50%"; break;
                    case 3: pnlRoomEditor.Zoom(1.0f); lblRoomMagnify.Text = "100%"; break;
                    case 4: pnlRoomEditor.Zoom(2.0f); lblRoomMagnify.Text = "200%"; break;
                    case 5: pnlRoomEditor.Zoom(3.0f); lblRoomMagnify.Text = "300%"; break;
                    case 6: pnlRoomEditor.Zoom(4.0f); lblRoomMagnify.Text = "400%"; break;
                    case 7: pnlRoomEditor.Zoom(5.0f); lblRoomMagnify.Text = "500%"; break;
                }

                // Refresh mouse position after zoom
                pnlRoomEditor.RefreshPosition();
            }
        }

        #endregion

        #endregion

        #region Methods

        #region Data

        /// <summary>
        /// Checks appropreiate steps in saving the project
        /// </summary>
        /// <returns></returns>
        private DialogResult CheckSave()
        {
            // If the room is empty, return
            if (App.Room == null)
                return DialogResult.Abort;

            // If the project has not changed, return
            if (App.Changed == false)
                return DialogResult.Abort;

            // If the room has changed, ask if they want to save before closing
            DialogResult result = MessageBox.Show("The project has changed, would you like to save?", "GMare", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

            // Take action based on dialog result
            switch (result)
            {
                // Save the project
                case DialogResult.Yes:

                    // Create a save file dialog
                    using (SaveFileDialog form = new SaveFileDialog())
                    {
                        // Set filter
                        form.Filter = "GMare Project File (.gmpf)|*.gmpf";

                        // If the dialog result was Ok
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            // Save the project, and dispose as the current project
                            App.SaveProject(form.FileName);
                            App.Room = null;
                        }
                        else  // Did not save project, treat like "Cancel"
                            return DialogResult.Cancel;
                    }

                    break;

                case DialogResult.No: App.Room = null; break;
                case DialogResult.Cancel: return DialogResult.Cancel;
            }

            // Result
            return result;
        }

        /// <summary>
        /// Push undo/redo history
        /// </summary>
        private void PushHistory()
        {
            // If the room is empty, return
            if (App.Room == null || _loading)
                return;

            // Push room data
            if (_history.InUndoRedo == false)
                _history.Do(new RoomMemento(new RoomData(App.Room.Clone())));

            // Set state as changed
            if (App.Changed == false)
                App.Changed = true;

            // Set undo/redo buttons
            SetUndoRedo();
        }

        #endregion

        #region Set

        /// <summary>
        /// Sets paint tool buttons as radio buttons
        /// </summary>
        /// <param name="button">The button to check</param>
        private void SetTileTools(PyxButton button)
        {
            // If the room is empty, return
            if (App.Room == null)
                return;

            // Set tool mode for room editor
            if (button.Name == butBrushTool.Name)
                pnlRoomEditor.ToolMode = ToolType.Brush;
            else if (button.Name == butBucketFillTool.Name)
                pnlRoomEditor.ToolMode = ToolType.Bucket;
            else if (button.Name == butSelectionTool.Name)
                pnlRoomEditor.ToolMode = ToolType.Selection;

            // Create radio button behavior for tools
            butBrushTool.Checked = false;
            butBucketFillTool.Checked = false;
            butSelectionTool.Checked = false;
            button.Checked = true;

            // Update any block changes
            App.Room.UpdateBlockInstances();
            pnlRoomEditor.Invalidate();
        }

        /// <summary>
        /// Sets undo redo controls enabled/disabled
        /// </summary>
        private void SetUndoRedo()
        {
            butUndo.Enabled = _history.CanUndo;
            butRedo.Enabled = _history.CanRedo;
            mnuUndo.Enabled = _history.CanUndo;
            mnuRedo.Enabled = _history.CanRedo;
        }

        /// <summary>
        /// Sets clipboard controls enabled/disabled
        /// </summary>
        private void SetClipboard()
        {
            // Clipboard flags
            bool cutCopyDelete = false;
            bool paste = false;

            // If editing layers and using the selection tool
            if (pnlRoomEditor.EditMode == EditType.Layers && pnlRoomEditor.ToolMode == ToolType.Selection)
            {
                cutCopyDelete = pnlRoomEditor.Selection == null ? false : true;
                paste = pnlRoomEditor.Selection == null && pnlRoomEditor.SelectionClipboard == null ? false : true;
            }
            else if (pnlRoomEditor.EditMode == EditType.Objects)  // If editing objects
            {
                cutCopyDelete = lstInstances.SelectedItems.Count > 0 ? true : false;
                paste = pnlRoomEditor.InstanceClipboard.Count > 0 ? true : false;
            }

            // Set cut, copy, delete, tools enabled/disabled
            mnuCut.Enabled = cutCopyDelete;
            butCut.Enabled = cutCopyDelete;
            mnuCopy.Enabled = cutCopyDelete;
            butCopy.Enabled = cutCopyDelete;
            mnuDelete.Enabled = cutCopyDelete;
            butDelete.Enabled = cutCopyDelete;

            // Set paste tools enabled/disabled
            mnuPaste.Enabled = paste;
            butPaste.Enabled = paste;
        }

        /// <summary>
        /// Sets up the object context menu
        /// </summary>
        private void SetObjectContextMenu(ContextMenuStrip menu)
        {
            // Reset selected object and clear previous menu items
            pnlRoomEditor.SelectedObject = null;
            menu.Items.Clear();

            // Get menu items
            ToolStripMenuItem[] items = App.Room.GetMenu();

            // If items loaded, set undefined
            if (items.Length > 0)
                txtObject.Text = "<undefined>";

            // Iterate through menu items
            foreach (ToolStripDropDownItem item in items)
            {
                // If the node is a child, set click event
                if ((item.Tag as GMNode).NodeType == GameMaker.Common.GMNodeType.Child)
                    item.Click += new EventHandler(mnuObjectMenuItem_Click);
                else  // Parent node, check for children to set up click event
                    SetObjectMenuItemEvents(item);

                // Add items to dropdown
                menu.Items.Add(item);
            }

            // Set the recent objects history menu item
            SetRecentObjectsMenu(menu);
        }

        /// <summary>
        /// Set recent object history menu items
        /// </summary>
        /// <param name="menu">Context menu to insert recent objects into</param>
        private void SetRecentObjectsMenu(ContextMenuStrip menu)
        {
            // If no objects have been loaded, return
            if (App.Room.Objects.Count == 0)
                return;

            // A list of new recent objects
            List<GMareObject> recentObjects = new List<GMareObject>();

            // Remove Recent Objects menu items
            menu.Items.RemoveByKey("mnuRecentObjects");
            menu.Items.RemoveByKey("sepRecentObjects");

            // Create a menu item for recent objects
            ToolStripMenuItem recent = new ToolStripMenuItem();
            recent.Name = "mnuRecentObjects";
            recent.Text = "Recent Objects";
            recent.Image = GMare.Properties.Resources.clock_history;

            // Iterate through existing items and see if they are still valid
            foreach (GMareObject gObject in App.Room.RecentObjects)
            {
                // See if the object still exists
                GMareObject gObject2 = App.Room.Objects.Find(o => o.Resource.Id == gObject.Resource.Id);

                // If the object is empty or at recent list count maximum, continue
                if (gObject2 == null || recent.DropDownItems.Count >= 20)
                    continue;

                // Create a node for click event data
                GMNode node = new GMNode();
                node.Id = gObject2.Resource.Id;
                node.Name = gObject2.Resource.Name;
                node.NodeType = GameMaker.Common.GMNodeType.Child;

                // Get minumum size for image
                Size size = new Size(Math.Min(gObject2.Image.Width, 22), Math.Min(gObject2.Image.Height, 22));

                // Create a menu item for the object
                Bitmap image = gObject2.Image.ToBitmap();
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = gObject2.Resource.Name;
                item.Image = GMare.Graphics.PixelMap.BitmapResize(image, size);
                item.Tag = node;
                item.Click += new EventHandler(mnuObjectMenuItem_Click);
                image.Dispose();

                // Add item to recent drop down
                recent.DropDownItems.Add(item);
                recentObjects.Add(gObject2);
            }

            // Create a unique separator
            ToolStripSeparator sep = new ToolStripSeparator();
            sep.Name = "sepRecentObjects";

            // Insert the recent object menu item and a separator
            menu.Items.Insert(0, recent);
            menu.Items.Insert(1, sep);

            // Set recent objects
            App.Room.RecentObjects = recentObjects;
        }

        /// <summary>
        /// Sets the click event for the object context menu children
        /// </summary>
        private ToolStripDropDownItem SetObjectMenuItemEvents(ToolStripDropDownItem menu)
        {
            // If no child items, return the top item
            if (menu.DropDownItems.Count == 0)
                return menu;

            // Iterate through items
            foreach (ToolStripDropDownItem item in menu.DropDownItems)
            {
                // Get node data
                GMNode node = (GMNode)item.Tag;

                // If a child, hook click event
                if (node.NodeType == GameMaker.Common.GMNodeType.Child)
                    item.Click += new EventHandler(mnuObjectMenuItem_Click);

                // Get any other child items
                SetObjectMenuItemEvents(item);
            }

            // Return a menu item
            return menu;
        }

        /// <summary>
        /// Set sorting checked
        /// </summary>
        /// <param name="index">The one sorting option to check</param>
        private void SetSortingChecked(int index)
        {
            // Uncheck all sorting options
            mnuSortStandard.Checked = false;
            mnuSortAscending.Checked = false;
            mnuSortDescending.Checked = false;

            // Set the checked sort
            (mnuInstances.Items[index] as ToolStripMenuItem).Checked = true;
        }

        /// <summary>
        /// Sets the instances list box
        /// </summary>
        private void SetSelectedInstances(bool update)
        {
            // Sort the listbox items
            if (mnuSortStandard.Checked == true)
                lstInstances.SortMode = GMareListbox.SortType.Standard;
            else if (mnuSortAscending.Checked == true)
                lstInstances.SortMode = GMareListbox.SortType.Ascending;
            else if (mnuSortDescending.Checked == true)
                lstInstances.SortMode = GMareListbox.SortType.Descending;

            // If updating the selected instances, or if no selected instance to select
            if (update == false || pnlRoomEditor.SelectedInstances.Count == 0)
                return;

            // Set selected items
            foreach (GMareInstance instance in pnlRoomEditor.SelectedInstances.ToArray())
            {
                // If not showing blocks, and the instance is a block, continue
                if (!pnlRoomEditor.ShowBlocks && instance.TileId != -1)
                    continue;

                lstInstances.SelectedItems.Add(instance);
            }
        }

        /// <summary>
        /// Sets the initial GUI on project loads
        /// </summary>
        private void SetUI()
        {
            // Apply custom visual style
            PyxVisualStyle.ApplyVisualStyle();

            // Create a new room with a new layer
            _loading = true;
            App.Room = new GMareRoom();
            App.Room.Layers.Add(new GMareLayer(App.Room.Columns, App.Room.Rows));

            // Set form level variables
            _history = new UndoRedoHistory<IRoomOwner>(this, App.GetUndoRedoMax());
            _layer = App.Room.Layers[0];

            // Set UI based on room properties
            butRoomPersistent.Checked = App.Room.Persistent;
            txtRoomName.Text = App.Room.Name;
            txtRoomCaption.Text = App.Room.Caption;
            nudRoomColumns.Value = App.Room.Columns;
            nudRoomRows.Value = App.Room.Rows;
            nudRoomSpeed.Value = App.Room.Speed;
            pnlBlockEditor.SelectedBackground = _background;
            pnlRoomEditor.EditMode = tabMain.SelectedTab == tabTiles ? EditType.Layers : EditType.Objects;
            txtObject.Text = "<undefined>";
            txtObject.Enabled = false;

            // Update UI
            UpdateLayerList(0);
            UpdateBackgrounds();
            UpdateStatusStrip();
            UpdateImages(null);
            UpdateTitle();
            UpdateInstanceList();

            // Loading the room has triggered history changes, reset the history
            _loading = false;
            App.Changed = false;
            _history.Clear();

            // SET UI
            SetUndoRedo();
            SetClipboard();
        }

        #endregion

        #region Update

        /// <summary>
        /// Sets the caption text of the window
        /// </summary>
        private void UpdateTitle()
        {
            // Set window title
            this.Text = "GMare" + " [" + App.Room.Name + "] " + "Size: " + App.Room.Width + " X " + App.Room.Height;
        }

        /// <summary>
        /// Updates the layer list
        /// </summary>
        /// <param name="index">Index to select after population</param>
        private void UpdateLayerList(int index)
        {
            // Clear items
            lstLayers.Items.Clear();

            // If the room is empty, return
            if (App.Room == null)
            {
                lstLayers.SelectedIndex = -1;
                return;
            }

            // Iterate through room layers, add layer, and set visible check mark
            foreach (GMareLayer layer in App.Room.Layers)
            {
                int i = lstLayers.Items.Add(layer);
                lstLayers.SetItemChecked(i, layer.Visible);
            }

            // Set selected layer
            if (index >= 0 && index < lstLayers.Items.Count)
                lstLayers.SelectedIndex = index;
            else
                lstLayers.SelectedIndex = lstLayers.Items.Count == 0 ? -1 : 0;
        }

        /// <summary>
        /// Updates the layer list
        /// </summary>
        /// <param name="index">Layer to select after population</param>
        private void UpdateLayerList(GMareLayer selectedlayer)
        {
            // Clear items
            lstLayers.Items.Clear();

            // If the room is empty, return
            if (App.Room == null)
            {
                lstLayers.SelectedIndex = -1;
                return;
            }

            // Iterate through room layers, add layer, and set visible check mark
            foreach (GMareLayer layer in App.Room.Layers)
            {
                int i = lstLayers.Items.Add(layer);
                lstLayers.SetItemChecked(i, layer.Visible);
            }

            // Set selected layer
            lstLayers.SelectedItem = selectedlayer;
        }

        /// <summary>
        /// Updates the instance listbox
        /// </summary>
        private void UpdateInstanceList()
        {
            // Clear previous items
            lstInstances.Items.Clear();

            // Add instance items, don't add blocks if not showing blocks
            lstInstances.Items.AddRange(butShowBlocks.Checked ? App.Room.Instances.ToArray() :
                App.Room.Instances.FindAll(i => i.TileId == -1).ToArray());

            // Get a cloned copy of the selected instance in the room editor
            GMareInstance[] selected = (GMareInstance[])pnlRoomEditor.SelectedInstances.ToArray().Clone();

            // Add selected instances
            foreach (GMareInstance instance in selected)
            {
                // If the selected instance exists in the instance list, add it to selected on instance list, else remove it from the room editor
                if (App.Room.Instances.Contains(instance))
                    lstInstances.SelectedItems.Add(instance);
                else
                    pnlRoomEditor.SelectedInstances.Remove(instance);
            }

            // Redraw
            lstInstances.Invalidate();
        }

        /// <summary>
        /// Updates UI that use the room's background image
        /// </summary>
        /// <param name="roomData">Undo/Redo room data, if null, use the current room</param>
        private void UpdateImages(RoomData roomData)
        {
            // If there is no change in background, then there's no need to update the UI
            if (App.Room != null && roomData != null &&
                App.Room.Backgrounds.Count > 0 && roomData.Room.Backgrounds.Count > 0 &&
                App.Room.Backgrounds[0] != null && roomData.Room.Backgrounds[0] != null &&
                App.Room.Backgrounds[0].Same(roomData.Room.Backgrounds[0]))
                return;

            // Update all background UI
            pnlBackground.SnapSize = roomData == null ? App.Room.Backgrounds[0].TileSize : roomData.Room.Backgrounds[0].TileSize;
            pnlBackground.Image = roomData == null ? App.Room.Backgrounds[0].GetCondensedTileset() : roomData.Room.Backgrounds[0].GetCondensedTileset();
            pnlRoomEditor.SelectedBackground = roomData == null ? App.Room.Backgrounds[0] : roomData.Room.Backgrounds[0];
            pnlRoomEditor.Image = roomData == null ? App.Room.Backgrounds[0].GetCondensedTileset() : roomData.Room.Backgrounds[0].GetCondensedTileset();
            pnlBlockEditor.SelectedBackground = roomData == null ? App.Room.Backgrounds[0] : roomData.Room.Backgrounds[0];
            pnlBlockEditor.Image = roomData == null ? App.Room.Backgrounds[0].GetSegmentedTileset(1) : roomData.Room.Backgrounds[0].GetSegmentedTileset(1);

            // Set room editor tile selection
            pnlRoomEditor.Tiles = pnlBackground.TileBrush;
        }

        /// <summary>
        /// Updates the background for each control that uses it
        /// </summary>
        private void UpdateBackgrounds()
        {
            _background = App.Room.Backgrounds[0];
            pnlRoomEditor.SelectedBackground = _background;
            pnlBlockEditor.SelectedBackground = _background;
            pnlBackground.SnapSize = _background.TileSize;

            // Set UI
            mnuExportImage.Enabled = _background.Image == null ? false : true;
            mnuSaveBackground.Enabled = _background.Image == null ? false : true;
        }

        /// <summary>
        /// Updates the object menu
        /// </summary>
        private void UpdateObjectsMenu()
        {
            // Clear any drop down items
            mnuObjects.Items.Clear();

            // If no nodes were loaded, return
            if (App.Room.Nodes == null)
            {
                UpdateObjectUI(false);
                return;
            }

            // Creates a context menu for the object tree
            SetObjectContextMenu(mnuObjects);

            // Reset selected object
            UpdateObjectUI(true);
        }

        /// <summary>
        /// Updates the object UI
        /// </summary>
        /// <param name="allowObjectSelection">If allowed to select an object</param>
        private void UpdateObjectUI(bool allowObjectSelection)
        {
            // Reset selected object
            pnlObject.BackgroundImage = GMare.Properties.Resources.slash;
            txtObject.Text = "<undefined>";
            txtObject.Enabled = allowObjectSelection;
            pnlRoomEditor.SelectedObject = null;
            pnlBlockEditor.ObjectId = -1;
        }

        /// <summary>
        /// Update status strip data
        /// </summary>
        private void UpdateStatusStrip()
        {
            // Set position information
            sslActual.Text = pnlRoomEditor.MouseActual;
            sslSnapped.Text = pnlRoomEditor.MouseSnapped;

            // Set status strip information based on edit mode
            switch (pnlRoomEditor.EditMode)
            {
                case EditType.Layers:
                    sslInfo.Text = pnlRoomEditor.MouseSector;
                    sslTool.Text = "Shift + Left Mouse Button to erase.";
                    sslTool.Image = GMare.Properties.Resources.eraser;
                    break;

                case EditType.Objects:
                    sslInfo.Text = "Instances: " + App.Room.Instances.Count + " | " + pnlRoomEditor.MouseInstance;
                    sslTool.Text = "Shift + Left Button to multi-select. Alt + Left Button to paint.";
                    sslTool.Image = GMare.Properties.Resources.tool_selection;
                    break;
            }
        }

        /// <summary>
        /// Updates the UI on project loads
        /// </summary>
        private void UpdateUI()
        {
            // If the room is empty, return
            if (App.Room == null)
                return;

            // Set UI based on room properties
            _loading = true;
            butRoomPersistent.Checked = App.Room.Persistent;
            txtRoomName.Text = App.Room.Name;
            txtRoomCaption.Text = App.Room.Caption;
            nudRoomColumns.Value = App.Room.Columns;
            nudRoomRows.Value = App.Room.Rows;
            nudRoomSpeed.Value = App.Room.Speed;
            txtObject.Enabled = App.Room.Nodes == null ? false : true;

            // Update UI
            UpdateLayerList(0);
            UpdateObjectsMenu();
            UpdateInstanceList();
            UpdateImages(null);
            UpdateBackgrounds();
            UpdateStatusStrip();
            UpdateTitle();

            // Invalidate the room editor
            pnlRoomEditor.Invalidate();

            // Reset the history
            _loading = false;
            App.Changed = false;
            _history.Clear();

            SetUndoRedo();
            SetClipboard();
        }

        #endregion

        #endregion
    }
}