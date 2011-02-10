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
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Collections.Generic;
using GMare.Forms;
using GMare.Common;
using GMare.Controls;
using GameMaker.Resource;
using GenericUndoRedo;

namespace GMare.Forms
{
    /// <summary>
    /// Main application form. (Giggity)
    /// </summary>
    public partial class MainForm : Form, IRoomOwner
    {
        #region Fields

        private UndoRedoHistory<IRoomOwner> _history;   // The program undo/redo history.

        #endregion

        #region IRoomOwner Members

        /// <summary>
        /// Gets or sets the project Undo/Redo room.
        /// </summary>
        public RoomData Data
        {
            get { return new RoomData(ProjectManager.Room); }
            set
            {
                // Get current edit index.
                int index = tscb_EditSelect.SelectedIndex;

                // If the backgrounds are different, update backgrounds.
                if (GMare.Graphics.PixelMap.Same(ProjectManager.Room.Background, value.Room.Background) == false)
                {
                    pnl_Tileset.Image = ProjectManager.Room.GetTileset();
                    pnl_RoomEditor.Image = ProjectManager.Room.GetTileset();
                }

                // Set room from undo redo.
                ProjectManager.Room = value.Room;
                this.Text = "GMare" + " [" + ProjectManager.Room.Name + "]";
                UpdateEditSelect(index);

                // If editing layers, delete the selection.
                if (pnl_RoomEditor.EditMode == EditType.Layers)
                    pnl_RoomEditor.Delete();

                pnl_RoomEditor_SelectedInstanceChanged();
                pnl_RoomEditor.Invalidate();

                // Set clipboard GUI.
                SetClipboard();
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new main application form.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Apply custom visual style over XP default blue.
            VisualStyle.ApplyVisualStyle();

            // Create new undo/redo history.
            _history = new UndoRedoHistory<IRoomOwner>(this, 5);

            // Set zoom tag.
            tsb_Zoom.Tag = 5;

            // Set the GUI.
            SetGUI();
        }

        #endregion

        #region Events

        #region MainForm

        /// <summary>
        /// Main form closing.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If a project was loaded, check for user action.
            if (ProjectManager.Room == null)
                return;

            // If the project has changed, ask the user to save.
            if (ProjectManager.Changed == true)
            {
                // Get user input.
                DialogResult result = MessageBox.Show("The project has changed, would you like to save before exiting?", "GMare", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

                // Take action based on dialog result.
                switch (result)
                {
                    // Save the project.
                    case DialogResult.Yes:

                        // Create a save file dialog.
                        using (SaveFileDialog form = new SaveFileDialog())
                        {
                            // Set filter.
                            form.Filter = "GMare Project File (.gmpf)|*.gmpf";

                            // If the dialog result was Ok, save the project.
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                // Save the project.
                                ProjectManager.SaveProject(form.FileName);

                                // Dispose of the project.
                                ProjectManager.Room = null;
                            }
                            else  // Did not save project, treat like "Cancel".
                                e.Cancel = true;
                        }

                        break;

                    // Cancel close.
                    case DialogResult.Cancel:

                        // Cancel closing the application.
                        e.Cancel = true;
                        break;
                }
            }
        }

        #endregion

        #region MenuStrip

        #region File

        /// <summary>
        /// New Project clicked.
        /// </summary>
        private void tsmi_New_Click(object sender, EventArgs e)
        {
            // Create a new room form.
            using (RoomForm form = new RoomForm())
            {
                // If the dialog result is ok.
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Set project room.
                    ProjectManager.Room = form.Room;

                    // The new project has not been saved yet, so it has changed.
                    ProjectManager.Changed = true;

                    // Set the GUI.
                    SetGUI();
                }
            }
        }

        /// <summary>
        /// Open Project clicked.
        /// </summary>
        private void tsmi_Open_Click(object sender, EventArgs e)
        {
            // Create a new open file dialog.
            using (OpenFileDialog form = new OpenFileDialog())
            {
                // Set file format filter.
                form.Filter = "Supported Files (.gmpf, .oref, .png, .bmp, .gif)|*.gmpf;*.oref;*.png;*.bmp;*.gif;|GMare Project File (.gmpf)|*.gmpf|Ocarina Room File (.oref)|*.oref|Image File (.png, .bmp, .gif)|*png;*bmp;*gif;";

                // If the dialog result is Ok.
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Set project room.
                    ProjectManager.Room = ProjectManager.OpenProject(form.FileName);

                    // Set the GUI.
                    SetGUI();
                }
            }
        }

        /// <summary>
        /// Close room clicked.
        /// </summary>
        private void tsmi_Close_Click(object sender, EventArgs e)
        {
            // If a project was loaded, check for user action.
            if (ProjectManager.Room == null)
                return;

            // If the project has changed, ask the user to save.
            if (ProjectManager.Changed == true)
            {
                // Get the user input.
                DialogResult result = MessageBox.Show("The project has changed, would you like to save before closing?", "GMare", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

                // Take action based on dialog result.
                switch (result)
                {
                    // Save the project.
                    case DialogResult.Yes:

                        // Create a save file dialog.
                        using (SaveFileDialog form = new SaveFileDialog())
                        {
                            // Set filter.
                            form.Filter = "GMare Project File (.gmpf)|*.gmpf";

                            // If the dialog result was Ok, save the project.
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                // Save the project.
                                ProjectManager.SaveProject(form.FileName);

                                // Dispose of the project.
                                ProjectManager.Room = null;
                            }
                            else  // Did not save project treat like "Cancel".
                                return;
                        }

                        break;

                    // Dispose of the project.
                    case DialogResult.No:

                        // Dispose of the project.
                        ProjectManager.Room = null;
                        break;

                    // Do nothing.
                    case DialogResult.Cancel:
                        return;
                }
            }
            else  // Dispose of the project.
                ProjectManager.Room = null;

            // Set the GUI.
            SetGUI();
        }

        /// <summary>
        /// Export to image clicked.
        /// </summary>
        private void tsmi_ExportImage_Click(object sender, EventArgs e)
        {
            // If a room was not loaded, or there is no tileset, return.
            if (ProjectManager.Room == null || ProjectManager.Room.Background == null)
                return;

            Size roomSize = new Size(ProjectManager.Room.Width, ProjectManager.Room.Height);
            Size tileSize = new Size(ProjectManager.Room.TileWidth, ProjectManager.Room.TileHeight);

            // Create a new save file dialog.
            using (ExportImageForm form = new ExportImageForm(ProjectManager.Room.Layers, ProjectManager.Room.GetTileset(), roomSize, tileSize, ProjectManager.Room.Background.Width))
            {
                // Show the form;
                form.ShowDialog();
            }
        }

        /// <summary>
        /// Export to single binary clicked.
        /// </summary>
        private void tsmi_ExportBinary_Click(object sender, EventArgs e)
        {
            // If no room is loaded, return.
            if (ProjectManager.Room == null)
                return;

            // Create a new save file dialog.
            using (ExportBinaryForm form = new ExportBinaryForm(ProjectManager.Room))
            {
                // Show the form.
                form.ShowDialog();
            }
        }

        /// <summary>
        /// Export room clicked.
        /// </summary>
        private void tsmi_ExportGMProject_Click(object sender, EventArgs e)
        {
            // Create a new open file dialog.
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Set file format filter.
                ofd.Filter = "Game Maker Project Files (.gmk, .gm6, .gmd)|*.gmk;*.gm6;*gmd;";

                // If the dialog result is Ok.
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Create a new export form dialog.
                    using (ExportGMProjectForm form = new ExportGMProjectForm(ofd.FileName))
                    {
                        // Show the form.
                        form.ShowDialog();
                    }
                }
            }
        }

        /// <summary>
        /// Save tileset.
        /// </summary>
        private void tsmi_SaveTileset_Click(object sender, EventArgs e)
        {
            // If a room has not been loaded.
            if (ProjectManager.Room == null)
                return;

            // Create a save file dialog.
            using (SaveFileDialog form = new SaveFileDialog())
            {
                // Set filter.
                form.Filter = "Portable Network Graphics (.png)|*.png";

                // If the dialog result was Ok, save the background.
                if (form.ShowDialog() == DialogResult.OK)
                    ProjectManager.Room.Background.ToBitmap().Save(form.FileName, ImageFormat.Png);
            }
        }

        /// <summary>
        /// Save Project clicked.
        /// </summary>
        private void tsmi_Save_Click(object sender, EventArgs e)
        {
            // If a project was not loaded, return.
            if (ProjectManager.Room == null)
                return;

            // Create a save file dialog.
            using (SaveFileDialog form = new SaveFileDialog())
            {
                // Set filter.
                form.Filter = "GMare Project File (.gmpf)|*.gmpf";

                // If the dialog result was Ok, save the project.
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Save the project.
                    ProjectManager.SaveProject(form.FileName);

                    // The project has not made any new changes.
                    ProjectManager.Changed = false;
                }
            }
        }

        /// <summary>
        /// Exit application clicked.
        /// </summary>
        private void tsmi_Exit_Click(object sender, EventArgs e)
        {
            // Close the main form.
            this.Close();
        }

        #endregion

        #region Edit

        /// <summary>
        /// Undo button click.
        /// </summary>
        private void tsmi_Undo_Click(object sender, EventArgs e)
        {
            // If able to undo.
            if (_history.CanUndo == true)
            {
                // Undo room.
                _history.Undo();
            }

            // Set undo/redo buttons.
            SetUndoRedo();
        }

        /// <summary>
        /// Redo button click.
        /// </summary>
        private void tsmi_Redo_Click(object sender, EventArgs e)
        {
            // If able to undo.
            if (_history.CanRedo == true)
            {
                // Undo room.
                _history.Redo();
            }

            // Set undo/redo buttons.
            SetUndoRedo();
        }

        /// <summary>
        /// Cut button click.
        /// </summary>
        private void tsmi_Cut_Click(object sender, EventArgs e)
        {
            pnl_RoomEditor.Cut();
            
            // Set clipboard GUI.
            SetClipboard();
        }

        /// <summary>
        /// Copy button click.
        /// </summary>
        private void tsmi_Copy_Click(object sender, EventArgs e)
        {
            pnl_RoomEditor.Copy();

            // Set clipboard GUI.
            SetClipboard();
        }

        /// <summary>
        /// Paste button click.
        /// </summary>
        private void tsmi_Paste_Click(object sender, EventArgs e)
        {
            pnl_RoomEditor.Paste();

            // Set clipboard GUI.
            SetClipboard();
        }

        /// <summary>
        /// Delete button click.
        /// </summary>
        private void tsmi_Delete_Click(object sender, EventArgs e)
        {
            pnl_RoomEditor.Delete();

            // Set clipboard GUI.
            SetClipboard();
        }

        #endregion

        #region Tools

        /// <summary>
        /// Shift room clicked.
        /// </summary>
        private void tsmi_Shift_Click(object sender, EventArgs e)
        {
            // If a project has not been loaded, return.
            if (ProjectManager.Room == null)
                return;

            // Create a new shift form.
            using (ShiftForm form = new ShiftForm())
            {
                // If the dialog result was Ok, force refresh.
                if (form.ShowDialog() == DialogResult.OK)
                    pnl_RoomEditor.Invalidate();
            }
        }

        /// <summary>
        /// Change back color clicked.
        /// </summary>
        private void tsmi_BackColor_Click(object sender, EventArgs e)
        {
            // If a project has not been loaded, return.
            if (ProjectManager.Room == null)
                return;

            // Create a new color dialog box.
            using (ColorDialog form = new ColorDialog())
            {
                // If the dialog result is Ok.
                if (form.ShowDialog() == DialogResult.OK)
                    ProjectManager.Room.BackColor = form.Color;

                // Refresh the room editor.
                pnl_RoomEditor.Invalidate();
            }
        }

        /// <summary>
        /// Layer view click.
        /// </summary>
        private void tsmi_LayerView_Click(object sender, EventArgs e)
        {
            // If no room was loaded, return.
            if (ProjectManager.Room == null)
                return;

            // Create a new text form.
            using (TextForm form = new TextForm(ProjectManager.Room.Layers))
            {
                // Show the form.
                form.ShowDialog();
            }
        }

        /// <summary>
        /// Edit properties clicked.
        /// </summary>
        private void tsmi_Edit_Click(object sender, EventArgs e)
        {
            // If a project has not been loaded, return.
            if (ProjectManager.Room == null)
                return;

            // Create a new room form.
            using (RoomForm form = new RoomForm(ProjectManager.Room))
            {
                // If the dialog result is ok.
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // If the room got changed, push history.
                    if (form.Changed == true)
                        PushHistory();

                    // Set project room.
                    ProjectManager.Room = form.Room;

                    // Update GUI.
                    UpdateEditSelect(tscb_EditSelect.SelectedIndex);
                    int index = lb_Instances.SelectedIndex;
                    SetInstancesListBox();
                    lb_Instances.SelectedIndex = index;
                    pnl_Tileset.Image = ProjectManager.Room.GetTileset();
                    pnl_RoomEditor.Image = ProjectManager.Room.GetTileset();
                    this.Text = "GMare" + " [" + ProjectManager.Room.Name + "]";

                    // Force redraw.
                    pnl_RoomEditor.Invalidate();
                }
            }
        }

        #endregion

        #region Help

        /// <summary>
        /// Show GML Scripts clicked.
        /// </summary>
        private void tsmi_Scripts_Click(object sender, EventArgs e)
        {
            // TODO: Save scripts to hard drive.
        }

        /// <summary>
        /// About clicked.
        /// </summary>
        private void tsmi_About_Click(object sender, EventArgs e)
        {
            // Create a new about form.
            using (AboutForm form = new AboutForm())
            {
                // Show the form.
                form.ShowDialog();
            }
        }

        #endregion

        #endregion

        #region ToolStrip

        /// <summary>
        /// Grid show button clicked.
        /// </summary>
        private void tsb_Grid_Click(object sender, EventArgs e)
        {
            // Toggle room editor grid on or off.
            pnl_RoomEditor.ShowGrid = tsb_Grid.Checked;
        }

        /// <summary>
        /// Show Isometric grid button clicked.
        /// </summary>
        private void tsb_GridIso_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle grid drawing mode.
            pnl_RoomEditor.GridMode = tsb_GridIso.Checked ? GridType.Isometric : GridType.Normal;
        }

        /// <summary>
        /// Snap to grid button click.
        /// </summary>
        private void tsmi_Snap_Click(object sender, EventArgs e)
        {
            // Toggle snap to grid.
            pnl_RoomEditor.Snap = tsb_Snap.Checked ? true : false;
        }

        /// <summary>
        /// Horizontal grid offset numeric up and down value changed.
        /// </summary>
        private void tsb_GridX_ValueChanged(object sender, EventArgs e)
        {
            // Set the room editor horizontal grid spacing.
            pnl_RoomEditor.GridX = (int)tsb_GridX.Value;
        }

        /// <summary>
        /// Vertical grid offset numeric up and down value changed.
        /// </summary>
        private void tsb_GridY_ValueChanged(object sender, EventArgs e)
        {
            // Set the room editor vertical grid spacing.
            pnl_RoomEditor.GridY = (int)tsb_GridY.Value;
        }

        /// <summary>
        /// Tool strip menu item click.
        /// </summary>
        private void tsmi_Zoom_Click(object sender, EventArgs e)
        {
            // If no room was loaded, return.
            if (ProjectManager.Room == null)
                return;

            // Iterate through tool strip menu items.
            for (int i = 0; i < tsb_Zoom.DropDownItems.Count; i++)
            {
                // If the item is a tool strip menu item.
                if (tsb_Zoom.DropDownItems[i] is ToolStripMenuItem)
                {
                    // If the item clicked matches the sender set button, else uncheck it.
                    if (tsb_Zoom.DropDownItems[i] == sender as ToolStripMenuItem)
                    {
                        // Zoom index.
                        int index = 0;

                        // Set split button text.
                        tsb_Zoom.Text = tsb_Zoom.DropDownItems[i].Text;

                        // Set checked.
                        (tsb_Zoom.DropDownItems[i] as ToolStripMenuItem).Checked = true;

                        // Set room editor scale.
                        switch (tsb_Zoom.Text)
                        {
                            case "25%": pnl_RoomEditor.Zoom = .25f; break;
                            case "50%": pnl_RoomEditor.Zoom = .50f; break;
                            case "100%": pnl_RoomEditor.Zoom = 1f; break;
                            case "200%": pnl_RoomEditor.Zoom = 2f; break;
                            case "400%": pnl_RoomEditor.Zoom = 4f; break;

                            case "Zoom In":
                                // Get next index.
                                index = (int)tsb_Zoom.Tag + 1 > tsb_Zoom.DropDownItems.Count - 1 ? tsb_Zoom.DropDownItems.Count - 1 : (int)tsb_Zoom.Tag + 1;

                                // Set the new index.
                                tsb_Zoom.Tag = (int)index;

                                // Call that item's click event.
                                tsmi_Zoom_Click(tsb_Zoom.DropDownItems[index], EventArgs.Empty);
                                return;

                            case "Zoom Out":
                                // Get next index.
                                index = (int)tsb_Zoom.Tag - 1 < 3 ? 3 : (int)tsb_Zoom.Tag - 1;

                                // Set the new index.
                                tsb_Zoom.Tag = (int)index;

                                // Call that item's click event.
                                tsmi_Zoom_Click(tsb_Zoom.DropDownItems[index], EventArgs.Empty);
                                return;
                        }
                    }
                    else
                        (tsb_Zoom.DropDownItems[i] as ToolStripMenuItem).Checked = false;
                }
            }
        }

        /// <summary>
        /// Add layer button clicked.
        /// </summary>
        private void tsmi_LayerAdd_Click(object sender, EventArgs e)
        {
            // Create a new layer form.
            using (LayerForm form = new LayerForm())
            {
                // If the dialog result is Ok, change selected layer.
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Push history.
                    PushHistory();

                    // Add the new layer.
                    ProjectManager.Room.Layers.Add(form.Layer);

                    // Sort layers.
                    ProjectManager.Room.Layers.Sort(delegate(GMareLayer layer1, GMareLayer layer2) { return layer1.Depth.CompareTo(layer2.Depth); });

                    // Update the edit select.
                    UpdateEditSelect(form.Layer);
                }
            }
        }

        /// <summary>
        /// Change layer properties button clicked.
        /// </summary>
        private void tsmi_LayerEdit_Click(object sender, EventArgs e)
        {
            // If the selected item is a layer object.
            if (tscb_EditSelect.SelectedItem is GMareLayer)
            {
                // Get the layer from the layer list.
                GMareLayer layer = (tscb_EditSelect.SelectedItem as GMareLayer);

                // Create a new layer form.
                using (LayerForm form = new LayerForm(layer))
                {
                    // If the dialog result is Ok, change selected layer.
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // If a valid change was made push history.
                        if (form.Changed == true)
                            PushHistory();

                        // Set layer.
                        layer = form.Layer;

                        // Sort layers.
                        ProjectManager.Room.Layers.Sort(delegate(GMareLayer layer1, GMareLayer layer2) { return layer1.Depth.CompareTo(layer2.Depth); });

                        // Update the edit select.
                        UpdateEditSelect(layer);
                    }
                }
            }
        }

        /// <summary>
        /// Delete layer button clicked.
        /// </summary>
        private void tsmi_LayerDelete_Click(object sender, EventArgs e)
        {
            // Warn the user.
            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected layer?", "GMare", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            // If yes was clicked.
            if (result == DialogResult.Yes)
            {
                // Push history.
                PushHistory();

                // Remove the layer.
                ProjectManager.Room.Layers.Remove(tscb_EditSelect.SelectedItem as GMareLayer);

                // Update the edit select control.
                UpdateEditSelect(null);
            }
        }

        /// <summary>
        /// Clear layer clicked.
        /// </summary>
        private void tsb_LayerClear_Click(object sender, EventArgs e)
        {
            // Warn the user.
            DialogResult result = MessageBox.Show("Are you sure you want to empty all tiles from the selected layer?", "GMare", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            // If yes was clicked, remove the layer.
            if (result == DialogResult.Yes)
            {
                // Push history.
                PushHistory();

                // Get the layer index.
                int index = ProjectManager.Room.Layers.IndexOf(tscb_EditSelect.SelectedItem as GMareLayer);

                // Clear tiles from layer.
                ProjectManager.Room.Layers[index].Clear();
            }
        }

        /// <summary>
        /// Edit select combobox drop down closed.
        /// </summary>
        private void tscb_EditSelect_DropDownClosed(object sender, EventArgs e)
        {
            // Reset the active control.
            this.ActiveControl = null;
        }

        /// <summary>
        /// Edit select combobox selected index changed.
        /// </summary>
        private void tscb_EditSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Turn off layer options.
            tsmi_LayerEdit.Enabled = false;
            tsmi_LayerDelete.Enabled = false;
            tsmi_LayerClear.Enabled = false;

            // Set edit mode.
            switch (tscb_EditSelect.SelectedIndex)
            {
                case 0: pnl_RoomEditor.EditMode = EditType.ViewAll; break;
                case 1: pnl_RoomEditor.EditMode = EditType.Collisions; break;
                case 2: pnl_RoomEditor.EditMode = EditType.Instances; break;
                default:
                    // Turn on layer options.
                    tsmi_LayerEdit.Enabled = true;
                    tsmi_LayerDelete.Enabled = true;
                    tsmi_LayerClear.Enabled = true;

                    // Set edit mode.
                    pnl_RoomEditor.EditMode = EditType.Layers;

                    // Set depth index.
                    pnl_RoomEditor.DepthIndex = (tscb_EditSelect.SelectedItem as GMareLayer).Depth;

                    // Set layer index.
                    pnl_RoomEditor.LayerIndex = ProjectManager.Room.Layers.IndexOf((tscb_EditSelect.SelectedItem as GMareLayer));
                    break;
            }

            // Set focus on room editor.
            pnl_RoomEditor.Focus();

            // Set status strip.
            SetStatusStrip();

            // Set clipboard GUI.
            SetClipboard();
        }

        /// <summary>
        /// Updates the edit select control.
        /// </summary>
        private void UpdateEditSelect(object item)
        {
            // Clear items.
            tscb_EditSelect.Items.Clear();

            // Add standard items
            tscb_EditSelect.Items.AddRange(new object[] { "View Room", "Collisions", "Instances" });

            // If a room is loaded, add layers.
            if (ProjectManager.Room != null)
            {
                // Iterate through room layers.
                foreach (GMareLayer layer in ProjectManager.Room.Layers)
                {
                    // Add layer to edit select.
                    tscb_EditSelect.Items.Add(layer);
                }
            }

            // Set selected index, or item.
            if (item == null)
                tscb_EditSelect.SelectedIndex = 0;
            else
                tscb_EditSelect.SelectedItem = item;
        }

        /// <summary>
        /// Updates the edit select control.
        /// </summary>
        private void UpdateEditSelect(int index)
        {
            // Clear items.
            tscb_EditSelect.Items.Clear();

            // Add standard items
            tscb_EditSelect.Items.AddRange(new object[] { "View Room", "Collisions", "Instances" });

            // If a room is loaded, add layers.
            if (ProjectManager.Room != null)
            {
                // Iterate through room layers.
                foreach (GMareLayer layer in ProjectManager.Room.Layers)
                {
                    // Add layer to edit select.
                    tscb_EditSelect.Items.Add(layer);
                }
            }

            // Set selected index.
            if (index > 0 && index < tscb_EditSelect.Items.Count)
                tscb_EditSelect.SelectedIndex = index;
            else
                tscb_EditSelect.SelectedIndex = 0;
        }

        #endregion

        #region Tiles

        /// <summary>
        /// Tile tool button check changed.
        /// </summary>
        private void tsb_TileTool_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle tools.
            if (tsb_TileTool.Checked == true)
            {
                // Set the tool mode to pencil.
                pnl_RoomEditor.ToolMode = ToolType.Pencil;

                // Toggle off other tools.
                tsb_FillTool.Checked = false;
                tsb_SelectionTool.Checked = false;
            }

            // Set clipboard GUI.
            SetClipboard();
        }

        /// <summary>
        /// Bucket fill button check changed.
        /// </summary>
        private void tsb_FillTool_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle tools.
            if (tsb_FillTool.Checked == true)
            {
                // Set the tool mode to bucket fill.
                pnl_RoomEditor.ToolMode = ToolType.Bucket;

                // Toggle off other tools.
                tsb_TileTool.Checked = false;
                tsb_SelectionTool.Checked = false;
            }

            // Set clipboard GUI.
            SetClipboard();
        }

        /// <summary>
        /// Tile selection tool check changed.
        /// </summary>
        private void tsb_SelectionTool_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle tools.
            if (tsb_SelectionTool.Checked == true)
            {
                // Set the tool mode to bucket fill.
                pnl_RoomEditor.ToolMode = ToolType.Selection;

                // Toggle off other tools.
                tsb_TileTool.Checked = false;
                tsb_FillTool.Checked = false;
            }

            // Set clipboard GUI.
            SetClipboard();
        }

        /// <summary>
        /// Swap tiles clicked.
        /// </summary>
        private void tsb_Swap_Click(object sender, EventArgs e)
        {
            // Create a new tile swap form.
            using (ReplaceForm form = new ReplaceForm(ProjectManager.Room.GetTileset()))
            {
                // If the dialog result was Ok.
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // If the tile swap happens on all layers.
                    if (form.Layer == null)
                    {
                        // Iterate through each layer.
                        foreach (GMareLayer temp in ProjectManager.Room.Layers)
                        {
                            // Swap tiles.
                            temp.Replace(form.Target.ToArray(), form.Swap.ToArray());
                        }
                    }
                    else
                    {
                        // Get the index of the desired layer.
                        int index = ProjectManager.Room.Layers.IndexOf(form.Layer);

                        // Swap tiles on the desired layer.
                        ProjectManager.Room.Layers[index].Replace(form.Target.ToArray(), form.Swap.ToArray());
                    }
                }

                // Force redraw.
                pnl_RoomEditor.Invalidate();
            }
        }

        /// <summary>
        /// Tileset zoom changed.
        /// </summary>
        private void tsb_TilesetZoom_ZoomChanged()
        {
            // Set the tileset panel zoom.
            pnl_Tileset.Zoom = tsb_TilesetZoom.Zoom;
        }

        /// <summary>
        /// Tileset panel mouse up.
        /// </summary>
        private void pnl_Tileset_MouseUp(object sender, MouseEventArgs e)
        {
            // Set room editor selection.
            pnl_RoomEditor.Tiles = pnl_Tileset.Selection;
        }

        #endregion

        #region Objects

        /// <summary>
        /// Import objects click.
        /// </summary>
        private void tsb_ImportObjects_Click(object sender, EventArgs e)
        {
            // If no project was loaded, return.
            if (ProjectManager.Room == null)
                return;

            // Create a new room form.
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Set file format filter.
                ofd.Filter = "Game Maker Project Files (.gmk, .gm6, .gmd)|*.gmk;*.gm6;*gmd;";

                // If the dialog result is ok.
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Load project objects.
                    ProjectManager.LoadObjects(ofd.FileName);

                    // If no nodes were loaded, return.
                    if (ProjectManager.Room.Nodes == null)
                        return;

                    // Creates a context menu for the object tree.
                    SetObjectDropDownMenu();

                    // Reset selected object.
                    tsb_Objects.Image = GMare.Properties.Resources.slash;
                    tsb_Objects.Text = "<undefined>";
                    pnl_RoomEditor.SelectedObject = null;

                    // Invalidate.
                    lb_Instances.Invalidate();
                    pnl_RoomEditor.Invalidate();
                }
            }
        }

        /// <summary>
        /// Object item click.
        /// </summary>
        private void tsb_Object_item_Click(object sender, EventArgs e)
        {
            // If the calling object is a toolstrip dropdown item.
            if (sender is ToolStripDropDownItem)
            {
                // Set selected item.
                tsb_Objects.Text = (sender as ToolStripDropDownItem).Text;
                tsb_Objects.Image = (sender as ToolStripDropDownItem).Image;

                // Get node from tag.
                GMNode node = (GMNode)(sender as ToolStripDropDownItem).Tag;

                // Set object for room editor.
                pnl_RoomEditor.SelectedObject = ProjectManager.Room.Objects.Find(delegate(GMareObject o) { return o.Resource.Id == node.Id; });
            }
        }

        /// <summary>
        /// Sets up the object drop down menu.
        /// </summary>
        private void SetObjectDropDownMenu()
        {
            // Clear any drop down items.
            tsb_Objects.DropDownItems.Clear();

            // Get menu items.
            ToolStripDropDownItem[] items = ProjectManager.Room.GetMenu();

            // Itrate through drop down items.
            foreach (ToolStripDropDownItem item in items)
            {
                // If the node is a child, set click event.
                if ((item.Tag as GMNode).NodeType == GameMaker.Common.GMNodeType.Child)
                    item.Click += new EventHandler(tsb_Object_item_Click);
                else  // Set up click event, recursive.
                    SetObjectDropDownItemEvents(item);

                // Ad items to dropdown.
                tsb_Objects.DropDownItems.Add(item);
            }
        }

        /// <summary>
        /// Sets the click events for a drop down menu, and it's drop down items.
        /// </summary>
        private ToolStripDropDownItem SetObjectDropDownItemEvents(ToolStripDropDownItem menu)
        {
            // If no child items, return the top item.
            if (menu.DropDownItems.Count == 0)
                return menu;

            // Iterate through items.
            foreach (ToolStripDropDownItem item in menu.DropDownItems)
            {
                // Get node data.
                GMNode node = (GMNode)item.Tag;

                // If a child, hook click event.
                if (node.NodeType == GameMaker.Common.GMNodeType.Child)
                    item.Click += new EventHandler(tsb_Object_item_Click);

                // Get any other child items.
                SetObjectDropDownItemEvents(item);
            }

            // Return a menu item.
            return menu;
        }

        /// <summary>
        /// Instances context menu opening.
        /// </summary>
        private void cms_Instances_Opening(object sender, CancelEventArgs e)
        {
            // If no item was selected, cancel context open.
            if (lb_Instances.SelectedItem == null)
                e.Cancel = true;
        }

        /// <summary>
        /// Standard sort click.
        /// </summary>
        private void tsmi_SortStandard_Click(object sender, EventArgs e)
        {
            // Set sorting.
            SetSortingChecked(0);
            SetInstancesListBox();
        }

        /// <summary>
        /// Alphabetical ascending sort click.
        /// </summary>
        private void tsmi_SortAscending_Click(object sender, EventArgs e)
        {
            // Set sorting.
            SetSortingChecked(1);
            SetInstancesListBox();
        }

        /// <summary>
        /// Alphabetical descending sort click.
        /// </summary>
        private void tsmi_SortDescending_Click(object sender, EventArgs e)
        {
            // Set sorting.
            SetSortingChecked(2);
            SetInstancesListBox();
        }

        /// <summary>
        /// Set sorting checked.
        /// </summary>
        /// <param name="index">The one sorting option to check.</param>
        private void SetSortingChecked(int index)
        {
            // Uncheck all sorting options.
            foreach (ToolStripMenuItem item in tsmi_Sorting.DropDownItems)
                item.Checked = false;

            // Set the checked sort.
            (tsmi_Sorting.DropDownItems[index] as ToolStripMenuItem).Checked = true;
        }

        /// <summary>
        /// Creation code button click.
        /// </summary>
        private void tsmi_CreationCode_Click(object sender, EventArgs e)
        {
            // If no item was selected from the instance list, return.
            if (lb_Instances.SelectedItem == null)
                return;

            // Get the instance object.
            GMareInstance inst = lb_Instances.SelectedItem as GMareInstance;

            // Create a new script form.
            using (ScriptForm form = new ScriptForm(inst.CreationCode, "Creation Code"))
            {
                // If ok was clicked.
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // If no change in creation code, return.
                    if (inst.CreationCode == form.Code)
                        return;

                    // Instance creation code changed, push history.
                    PushHistory();

                    // Set creation code.
                    inst.CreationCode = form.Code;

                    // Force redraw.
                    lb_Instances.Invalidate();
                }
            }
        }

        /// <summary>
        /// Delete instance button click.
        /// </summary>
        private void tsmi_DeleteInstance_Click(object sender, EventArgs e)
        {
            // Index options for delete and sort commands.
            int index = lb_Instances.SelectedIndex;
            object item = lb_Instances.SelectedItem;

            // If an item was selected, remove it from project instances.
            if (lb_Instances.SelectedItem != null)
                ProjectManager.Room.Instances.Remove((GMareInstance)lb_Instances.SelectedItem);

            // Force redraw since there is no more items to trigger a redraw.
            if (ProjectManager.Room.Instances.Count == 0)
                pnl_RoomEditor.Invalidate();

            // Set up the listbox with new values.
            SetInstancesListBox();

            // If the list still contains last selected item, select it.
            if (item != null && lb_Instances.Items.Contains(item))
                lb_Instances.SelectedItem = item;
            else
            {
                // If the index is greater than the first item, Deincrement the indexer.
                if (index > 0)
                    index--;

                // If the index is within bounds and there are items left, use the index.
                if (index > -1 && lb_Instances.Items.Count > 0)
                    lb_Instances.SelectedIndex = index;
            }
        }

        /// <summary>
        /// Shapes listbox selected index changed.
        /// </summary>
        private void lb_Instances_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If a shape has been selected, tell the room editor.
            if (lb_Instances.SelectedItem != null)
            {
                // Set clipboard GUI.
                SetClipboard();
                pnl_RoomEditor.SelectedInstance = lb_Instances.SelectedItem as GMareInstance;
            }

            // Set clipboard GUI.
            SetClipboard();
        }

        /// <summary>
        /// Sets the shapes list box.
        /// </summary>
        private void SetInstancesListBox()
        {
            // If no shapes, return.
            if (ProjectManager.Room.Instances == null)
                return;

            // Sort the listbox items.
            if (tsmi_SortStandard.Checked == true)
                lb_Instances.SortMode = ListboxEx.SortType.Standard;
            else if (tsmi_SortAscending.Checked == true)
                lb_Instances.SortMode = ListboxEx.SortType.Ascending;
            else if (tsmi_SortDescending.Checked == true)
                lb_Instances.SortMode = ListboxEx.SortType.Descending;

            // Set the selected instance.
            if (pnl_RoomEditor.SelectedInstance != null)
                lb_Instances.SelectedItem = pnl_RoomEditor.SelectedInstance;
        }

        #endregion

        #region Collisions

        /// <summary>
        /// Shapes listbox selected index changed.
        /// </summary>
        private void lb_Shapes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If a shape has been selected, tell the room editor.
            if (lb_Shapes.SelectedItem != null)
                pnl_RoomEditor.SelectedShape = lb_Shapes.SelectedItem as GMareCollision;
        }

        /// <summary>
        /// Sets the shapes list box.
        /// </summary>
        private void SetShapesListBox()
        {
            // Clear all the shapes.
            lb_Shapes.Items.Clear();

            // If no shapes, return.
            if (ProjectManager.Room.Shapes == null)
                return;

            // Add all the current shapes.
            lb_Shapes.Items.AddRange(ProjectManager.Room.Shapes.ToArray());

            // Set the selected shape.
            if (pnl_RoomEditor.SelectedShape != null)
                lb_Shapes.SelectedItem = pnl_RoomEditor.SelectedShape;
        }

        /// <summary>
        /// Shape menu item clicked.
        /// </summary>
        private void cms_ShapeTools_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // If no room has been loaded, and there are no shapes, return.
            if (ProjectManager.Room == null || ProjectManager.Room.Shapes == null)
                return;

            /* Shift shape up.
            if (e.ClickedItem == tsmi_ShiftUp)
            {
                // If there is an item selected, and the item is not at the top of the list already.
                if (lb_Shapes.SelectedItem != null && lb_Shapes.SelectedIndex > 0)
                {
                    // Get the selected shape.
                    GMareShape shape = ProjectManager.Room.Shapes[lb_Shapes.SelectedIndex];

                    // Index to recall.
                    int index = lb_Shapes.SelectedIndex;

                    // Insert the copied shape one up.
                    ProjectManager.Room.Shapes.Insert(lb_Shapes.SelectedIndex - 1, shape);

                    // Remove the old item.
                    ProjectManager.Room.Shapes.RemoveAt(lb_Shapes.SelectedIndex + 1);

                    // Clear shapes.
                    lb_Shapes.Items.Clear();

                    // Add all room shapes.
                    lb_Shapes.Items.AddRange(ProjectManager.Room.Shapes.ToArray());

                    // Set the index.
                    lb_Shapes.SelectedIndex = index;
                }
            }
            else if (e.ClickedItem == tsmi_ShiftDown)  // Shift shape down.
            {
                // If there is an item selected, and the item is not at the top of the list already.
                if (lb_Shapes.SelectedItem != null && lb_Shapes.SelectedIndex < lb_Shapes.Items.Count - 1)
                {
                    // Get the selected shape.
                    GMareShape shape = ProjectManager.Room.Shapes[lb_Shapes.SelectedIndex];

                    // Index to recall.
                    int index = lb_Shapes.SelectedIndex;

                    // Insert the copied shape one up.
                    ProjectManager.Room.Shapes.Insert(lb_Shapes.SelectedIndex + 2, shape);

                    // Remove the old item.
                    ProjectManager.Room.Shapes.RemoveAt(lb_Shapes.SelectedIndex);

                    // Clear shapes.
                    lb_Shapes.Items.Clear();

                    // Add all room shapes.
                    lb_Shapes.Items.AddRange(ProjectManager.Room.Shapes.ToArray());

                    // Set the index.
                    lb_Shapes.SelectedIndex = index;
                }
            }
            else if (e.ClickedItem == tsmi_Delete)  // Delete shape.
            {
                // Index variable.
                int index = 0;

                // Get the currently selected item index.
                if (lb_Shapes.SelectedIndex > 0)
                    index = lb_Shapes.SelectedIndex - 1;

                // Remove the shape from the room.
                ProjectManager.Room.Shapes.Remove(lb_Shapes.SelectedItem as GMareShape);

                // Clear shapes.
                lb_Shapes.Items.Clear();

                // Add all room shapes.
                lb_Shapes.Items.AddRange(ProjectManager.Room.Shapes.ToArray());

                // If there are still items left, use the saved index.
                if (index > -1 && lb_Shapes.Items.Count > 0)
                    lb_Shapes.SelectedIndex = index;
            }*/
        }

        /// <summary>
        /// Level drop down item clicked.
        /// </summary>
        private void tsb_Level_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Set level for collision.
            if (e.ClickedItem == tsmi_Level1)
                pnl_RoomEditor.Level = 0;
            else if (e.ClickedItem == tsmi_Level2)
                pnl_RoomEditor.Level = 1;
            else if (e.ClickedItem == tsmi_Level3)
                pnl_RoomEditor.Level = 2;
            else if (e.ClickedItem == tsmi_Level4)
                pnl_RoomEditor.Level = 3;
            else if (e.ClickedItem == tsmi_Level5)
                pnl_RoomEditor.Level = 4;
        }

        #endregion

        #region RoomEditor

        /// <summary>
        /// Room panel room changed.
        /// </summary>
        private void pnl_RoomEditor_RoomChanged()
        {
            // Push new history.
            PushHistory();
        }

        /// <summary>
        /// Room panel mouse up.
        /// </summary>
        private void pnl_RoomEditor_MouseUp(object sender, MouseEventArgs e)
        {
            // If a room has been loaded.
            if (ProjectManager.Room == null)
                return;

            // Do action based on edit mode of room editor.
            switch (pnl_RoomEditor.EditMode)
            {
                case EditType.Collisions: SetShapesListBox(); break;
                case EditType.Instances: SetInstancesListBox(); break;
            }

            // Set clipboard GUI.
            SetClipboard();

            // Invalidate room editor.
            pnl_RoomEditor.Invalidate();
        }

        /// <summary>
        /// Room panel position changed.
        /// </summary>
        private void pnl_RoomEditor_PositionChanged()
        {
            // Set position information.
            tssl_Actual.Text =  pnl_RoomEditor.MouseActual;
            tssl_Snapped.Text = pnl_RoomEditor.MouseSnapped;

            // Set status strip information.
            SetStatusStrip();
        }

        /// <summary>
        /// Selected instance changed.
        /// </summary>
        private void pnl_RoomEditor_SelectedInstanceChanged()
        {
            // Set the instance listbox.
            SetInstancesListBox();

            // Set the selected instance.
            if (pnl_RoomEditor.SelectedInstance != null)
                lb_Instances.SelectedItem = pnl_RoomEditor.SelectedInstance;

            // Force redraw.
            pnl_RoomEditor.Invalidate();

            // Set clipboard GUI.
            SetClipboard();
        }

        /// <summary>
        /// Clipboard changed.
        /// </summary>
        private void pnl_RoomEditor_ClipboardChanged()
        {
            // Set clipboard GUI.
            SetClipboard();
        }

        #endregion

        #region StatusStrip

        /// <summary>
        /// Sets the status strip with extra information depending on the edit mode.
        /// </summary>
        private void SetStatusStrip()
        {
            // If no room was loaded, return.
            if (ProjectManager.Room == null)
            {
                tssl_Info.Text = "Open or create a new project.";
                return;
            }

            // If the edit mode is layers, set extra information.
            switch (pnl_RoomEditor.EditMode)
            {
                case EditType.Layers: tssl_Info.Text = pnl_RoomEditor.MouseSector; break;
                case EditType.Instances: tssl_Info.Text = "Instances: " + ProjectManager.Room.Instances.Count; break;
                case EditType.Collisions: tssl_Info.Text = "Collisions: " + ProjectManager.Room.Shapes.Count; break;
                case EditType.ViewAll: tssl_Info.Text = "Ready"; break;
            }
        }

        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// Pushes history on undo/redo stacks.
        /// </summary>
        private void PushHistory()
        {
            // If a room has not been loaded, return.
            if (ProjectManager.Room == null)
                return;

            // Add to history.
            if (_history.InUndoRedo == false)
            {
                // Push a copy of the room.
                _history.Do(new RoomMemento(new RoomData(ProjectManager.Room.Clone())));
            }

            // If the project has not been changed.
            if (ProjectManager.Changed == false)
            {
                // TODO: Maybe keep track of this memento if the user undos to the original project state.

                // Project has changed.
                ProjectManager.Changed = true;
            }

            // Set undo/redo buttons.
            SetUndoRedo();
        }

        /// <summary>
        /// Sets undo redo controls.
        /// </summary>
        private void SetUndoRedo()
        {
            // Set any undo redo related controls.
            tsb_Undo.Enabled = _history.CanUndo;
            tsb_Redo.Enabled = _history.CanRedo;
            tsmi_Undo.Enabled = _history.CanUndo;
            tsmi_Redo.Enabled = _history.CanRedo;
        }

        /// <summary>
        /// Sets the clipboard controls.
        /// </summary>
        /// <param name="selection">Whether an object was selected.</param>
        /// <param name="clipboard">Whether a clipboard object exits for the selection.</param>
        private void SetClipboard()
        {
            // The clipboard object.
            object clipboard = null;

            // Whether the object of interest has been selected.
            bool selection = false;

            // Set clipboard GUI.
            switch (pnl_RoomEditor.EditMode)
            {
                // Instance edit.
                case EditType.Instances:

                    // If an instance was selected.
                    if (lb_Instances.SelectedItem != null)
                        selection = true;

                    // Set the clipboard.
                    clipboard = pnl_RoomEditor.InstanceClipboard;
                    break;

                // Layer edit.
                case EditType.Layers:

                    // Selection tool.
                    switch (pnl_RoomEditor.ToolMode)
                    {
                        // Selection tool.
                        case ToolType.Selection:

                            // If a selection has been made.
                            if (pnl_RoomEditor.Selection != null)
                                selection = true;

                            // Set the clipboard.
                            clipboard = pnl_RoomEditor.SelectionClipboard;
                            break;
                    }
                    
                    break;
            }

            // If an object was selected.
            if (selection == true)
            {
                tsmi_Cut.Enabled = true;
                tsb_Cut.Enabled = true;
                tsmi_Copy.Enabled = true;
                tsb_Copy.Enabled = true;
                tsmi_Delete.Enabled = true;
                tsb_Delete.Enabled = true;
            }
            else
            {
                tsmi_Cut.Enabled = false;
                tsb_Cut.Enabled = false;
                tsmi_Copy.Enabled = false;
                tsb_Copy.Enabled = false;
                tsmi_Delete.Enabled = false;
                tsb_Delete.Enabled = false;
            }

            // If something resides in the clipboard for pasting.
            if (clipboard != null)
            {
                tsmi_Paste.Enabled = true;
                tsb_Paste.Enabled = true;
            }
            else
            {
                tsmi_Paste.Enabled = false;
                tsb_Paste.Enabled = false;
            }
        }

        /// <summary>
        /// On project state changed.
        /// </summary>
        private void SetGUI()
        {
            // Enable and disable stuff based on project room.
            if (ProjectManager.Room == null)
            {
                // Menu strip.
                tsmi_NewProject.Enabled = true;
                tsmi_OpenProject.Enabled = true;
                tsmi_CloseProject.Enabled = false;
                tsmi_Export.Enabled = false;
                tsmi_SaveTileset.Enabled = false;
                tsmi_SaveProject.Enabled = false;
                tsmi_Exit.Enabled = true;
                tsmi_Shift.Enabled = false;
                tsmi_BackColor.Enabled = false;
                tsmi_Properties.Enabled = false;
                tsmi_LayerView.Enabled = false;
                tsmi_About.Enabled = true;

                // Main menu strip.
                foreach (ToolStripItem item in ts_Main.Items)
                    item.Enabled = false;

                tsb_NewProject.Enabled = true;
                tsb_OpenProject.Enabled = true;
                tsb_Contents.Enabled = true;
                tsb_About.Enabled = true;

                // Editor tool strip.
                foreach (ToolStripItem item in ts_Tools.Items)
                    item.Enabled = false;

                // Reset the room editor.
                pnl_RoomEditor.Reset();

                // Get rid of tileset image.
                pnl_Tileset.Image = null;

                // Reset the GUI tab control.
                tc_GUI.TabIndex = 0;
                tc_GUI.Enabled = false;

                // Reset selected object.
                tsb_Objects.Image = GMare.Properties.Resources.slash;
                tsb_Objects.Text = "<undefined>";

                // Get rid of room data.
                lb_Instances.Items.Clear();
                tsb_Objects.DropDownItems.Clear();
                lb_Shapes.Items.Clear();

                // Update the edit select control.
                UpdateEditSelect(null);

                // Set text.
                Text = "GMare";

                // The project has not made any new changes.
                ProjectManager.Changed = false;
            }
            else
            {
                // Menu strip.
                tsmi_NewProject.Enabled = false;
                tsmi_OpenProject.Enabled = false;
                tsmi_CloseProject.Enabled = true;
                tsmi_Export.Enabled = true;
                tsmi_SaveTileset.Enabled = true;
                tsmi_SaveProject.Enabled = true;
                tsmi_Exit.Enabled = true;
                tsmi_Shift.Enabled = true;
                tsmi_BackColor.Enabled = true;
                tsmi_Properties.Enabled = true;
                tsmi_LayerView.Enabled = true;
                tsmi_About.Enabled = true;

                // Main menu strip.
                foreach (ToolStripItem item in ts_Main.Items)
                    item.Enabled = true;

                tsb_NewProject.Enabled = false;
                tsb_OpenProject.Enabled = false;

                // Editor tool strip.
                foreach (ToolStripItem item in ts_Tools.Items)
                    item.Enabled = true;

                // Load all the objects textures.
                foreach (GMareObject obj in ProjectManager.Room.Objects)
                {
                    // Add texture to texture cache.
                    Graphics.GraphicsManager.LoadTexture(obj.Image, obj.Resource.Id);
                }

                // Create tilesets for controls.
                if (ProjectManager.Room.Background != null)
                {
                    pnl_Tileset.Image = ProjectManager.Room.GetTileset();
                    pnl_RoomEditor.Image = ProjectManager.Room.GetTileset();
                }

                // Reset the GUI tab control.
                tc_GUI.Enabled = true;

                // Set room data.
                SetInstancesListBox();
                SetShapesListBox();

                // Set object drop down menu.
                if (ProjectManager.Room.Nodes != null)
                    SetObjectDropDownMenu();

                // Update the edit select control.
                UpdateEditSelect(null);

                // Set grid values.
                tsb_GridX.Value = ProjectManager.Room.TileWidth;
                tsb_GridY.Value = ProjectManager.Room.TileHeight;

                // Set text.
                Text = "GMare" + " [" + ProjectManager.Room.Name + "]";
            }

            // Disable all clipboard functions.
            SetClipboard();

            // Clear history.
            _history.Clear();

            // Set undo/redo buttons.
            SetUndoRedo();

            // Reset project changed.
            ProjectManager.Changed = false;

            // Set the status strip information.
            SetStatusStrip();

            // Refresh drawing.
            pnl_RoomEditor.Invalidate();
        }

        #endregion
    }
}