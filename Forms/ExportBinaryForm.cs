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
using System.Xml;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using GameMaker.Resource;
using GMare.Objects;

namespace GMare.Forms
{
    /// <summary>
    /// Export GMare room to a binary file form
    /// </summary>
    public partial class ExportBinaryForm : Form
    {
        #region Fields

        private bool _changed = false;      // If project export data has changed
        private bool _allowChange;  // Change flag on start up

        #endregion

        #region Properties

        /// <summary>
        /// Gets if the project export data has changed
        /// </summary>
        public bool Changed { get { return _changed; } }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new export binary form
        /// </summary>
        public ExportBinaryForm()
        {
            InitializeComponent();

            // If no native project was found, create one
            if (ProjectManager.Room.Projects.Find(p => p.Native == true) == null)
            {
                ExportProject project = new ExportProject();
                project.Native = true;
                ProjectManager.Room.Projects.Add(project);

                // Project changed
                _changed = true;
            }

            // Update the native project
            ExportProject native = ProjectManager.Room.Projects.Find(p => p.Native == true);

            // If project changed
            if (native.Name != ProjectManager.Room.Name || native.RoomPath != ProjectManager.SavePath)
                _changed = true;

            native.Name = ProjectManager.Room.Name;
            native.RoomPath = ProjectManager.SavePath;

            // Select first script option
            cboScripts.SelectedIndex = 0;

            _allowChange = false;

            // Update the project list
            UpdateProjectList(0);

            _allowChange = true;
        }

        #endregion

        #region Events

        /// <summary>
        /// Export to binary file button click
        /// </summary>
        private void butExport_Click(object sender, EventArgs e)
        {
            // If no rooms have been selected, warn the user, then return
            if (lstRooms.CheckedItems.Count <= 0)
            {
                MessageBox.Show("No rooms were selected for export.", "GMare", MessageBoxButtons.OK);
                return;
            }

            // Room names list
            List<string> names = new List<string>();

            // Check for duplicate room names
            foreach (ExportProject project in lstRooms.CheckedItems)
            {
                // Add room name
                names.Add(project.Name);

                // If there is a duplicate, show error and abort
                if (names.FindAll(n => n == project.Name).Count > 1)
                {
                    MessageBox.Show("Room: " + project.Name + ", exists more than once. Room names must be unique. Change the duplicate room(s) and try again.", "GMare", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }

                // If the background has no background id
                if (project.Background.Id == -1)
                {
                    MessageBox.Show("Room: " + project.Name + ", does not have a Game Maker background assigned to it. Assign a Game Maker background to it and try again.", "GMare",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
            }

            // Create a new save file dialog
            using (SaveFileDialog form = new SaveFileDialog())
            {
                // GMare binary files
                form.Filter = "Binary File (*.bin)|*.bin";

                // If ok was clicked, write room(s) to file
                if (form.ShowDialog() == DialogResult.OK)
                    WriteBinaryFile(form.FileName);
            }
        }

        /// <summary>
        /// Cancel button click
        /// </summary>
        private void butCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Add rooms button click
        /// </summary>
        private void butRoomAdd_Click(object sender, EventArgs e)
        {
            // Create a new open file dialog
            using (OpenFileDialog form = new OpenFileDialog())
            {
                // Set file format filter
                form.Title = "Add Project(s)";
                form.Filter = "GMare Project Files (.gmpx)|*.gmpx;";
                form.Multiselect = true;

                // If ok was not clicked, return
                if (form.ShowDialog() != DialogResult.OK)
                    return;

                // Iterate through file names, try adding a project for each path
                foreach (string path in form.FileNames)
                {
                    // If the path is the same as this project's path, continue
                    if (path == ProjectManager.SavePath)
                        continue;

                    // Get the room data
                    GMareRoom room = ProjectManager.GetGMareProject(path);

                    // If the room is empty, continue
                    if (room == null)
                        continue;

                    // Export project to add
                    ExportProject project = null;

                    // If the native export room is not present, create a new project else clone the existing one
                    if (room.Projects.Find(p => p.Native) == null)
                    {
                        project = new ExportProject();
                        project.Name = room.Name;
                        project.RoomPath = path;
                    }
                    else
                        project = room.Projects.Find(p => p.Native).Clone();

                    // The project is not native to this project
                    project.Native = false;

                    // Add the room to the project list
                    ProjectManager.Room.Projects.Add(project);
                }

                // Update project list
                UpdateProjectList((lstRooms.Items.Count - 1) + form.FileNames.Length);

                // Export projects have changed
                _changed = _allowChange;
            }
        }

        /// <summary>
        /// Delete rooms button click
        /// </summary>
        private void butRoomDelete_Click(object sender, EventArgs e)
        {
            // If a project was not selected, return
            if (lstRooms.SelectedItem == null)
                return;

            // Get the selected project
            ExportProject project = (ExportProject)lstRooms.SelectedItem;

            // If the project is the native one, notify the user an return
            if (project.Native == true)
            {
                MessageBox.Show("You can't remove the native project from the export list. Uncheck the project if you do not want to export it.",
                    "GMare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Remove project and update project list
            ProjectManager.Room.Projects.Remove(project);
            UpdateProjectList(lstRooms.Items.Count == 1 ? -1 : lstRooms.SelectedIndex >= lstRooms.Items.Count - 1 ? lstRooms.Items.Count - 2 : lstRooms.SelectedIndex);

            // Export projects have changed
            _changed = _allowChange;
        }

        /// <summary>
        /// Move room up button click
        /// </summary>
        private void butMoveUp_Click(object sender, EventArgs e)
        {
            // If an item has not been selected, return
            if (lstRooms.SelectedItem == null)
                return;
            
            // Get the index of the selected project, then copy it
            int index = lstRooms.SelectedIndex;
            ExportProject swap = (ExportProject)lstRooms.SelectedItem;

            // If the index is not out of bounds
            if (index - 1 > -1)
            {
                // Remove, insert, and select the swap item
                ProjectManager.Room.Projects.RemoveAt(index);
                ProjectManager.Room.Projects.Insert(index - 1, swap);
                UpdateProjectList(index - 1);

                // Export projects have changed
                _changed = _allowChange;
            }
        }

        /// <summary>
        /// Move room down button click
        /// </summary>
        private void butMoveDown_Click(object sender, EventArgs e)
        {
            // If an item has not been selected, return
            if (lstRooms.SelectedItem == null)
                return;

            // Get the index of the selected project, then copy it
            int index = lstRooms.SelectedIndex;
            ExportProject swap = (ExportProject)lstRooms.SelectedItem;

            // If the index is not out of bounds
            if (index + 1 < lstRooms.Items.Count)
            {
                // Remove, insert, and select the swap item
                ProjectManager.Room.Projects.RemoveAt(index);
                ProjectManager.Room.Projects.Insert(index + 1, swap);
                UpdateProjectList(index + 1);

                // Export projects have changed
                _changed = _allowChange;
            }
        }

        /// <summary>
        /// Button check all rooms check changed
        /// </summary>
        private void butCheckAll_CheckChanged(object sender)
        {
            // Iterate through projects, set exporting flag
            foreach (ExportProject project in ProjectManager.Room.Projects)
                project.Exporting = butCheckAll.Checked;

            // Update project list
            UpdateProjectList(lstRooms.SelectedIndex);

            // Export projects have changed
            _changed = _allowChange;
        }

        /// <summary>
        /// Copies the selected script to the clipboard
        /// </summary>
        private void butCopyScript_Click(object sender, EventArgs e)
        {
            // If not a valid selected item, return
            if (cboScripts.SelectedItem == null || cboScripts.SelectedIndex == 0)
                return;

            var assembly = Assembly.GetExecutingAssembly();
            var script = "GMare.Resources." + (string)cboScripts.SelectedItem + ".txt";

            // Copy embedded script to the clipboard
            using (Stream stream = assembly.GetManifestResourceStream(script))
            {
                StreamReader reader = new StreamReader(stream);
                string result = reader.ReadToEnd();
                Clipboard.SetText(result);
            }
        }

        /// <summary>
        /// Room selection change
        /// </summary>
        private void lstRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If the selected item is empty, return
            if (lstRooms.SelectedItem == null)
            {
                txtRoomName.Text = string.Empty;
                txtProjectPath.Text = string.Empty;
                txtProjectPath.ToolTipText = "";
                txtBackgroundName.Text = "None";
                txtBackgroundId.Text = "None";
                txtTileWidth.Text = "0";
                txtTileHeight.Text = "0";
                txtTileOffsetX.Text = "0";
                txtTileOffsetY.Text = "0";
                txtTileSeparationX.Text = "0";
                txtTileSeparationY.Text = "0";
                grpRoomProperties.Enabled = false;
                grpBackgrounds.Enabled = false;
                return;
            }

            // Set properties UI
            ExportProject project = (ExportProject)lstRooms.SelectedItem;
            txtRoomName.Text = project.Name;
            txtProjectPath.Text = project.Native ? ProjectManager.SavePath : project.RoomPath;
            txtProjectPath.Enabled = project.Native ? false : true;
            txtProjectPath.ToolTipText = project.RoomPath;
            txtBackgroundName.Text = (project.Background.Name == "" ? "None" : project.Background.Name);
            txtBackgroundId.Text = (project.Background.GameMakerId == -1 ? "None" : project.Background.GameMakerId.ToString());
            txtTileWidth.Text = project.Background.TileWidth.ToString();
            txtTileHeight.Text = project.Background.TileHeight.ToString();
            txtTileOffsetX.Text = project.Background.OffsetX.ToString();
            txtTileOffsetY.Text = project.Background.OffsetY.ToString();
            txtTileSeparationX.Text = project.Background.SeparationX.ToString();
            txtTileSeparationY.Text = project.Background.SeparationY.ToString();
            chkWriteTiles.Checked = project.WriteTiles;
            chkUseFlipped.Checked = project.UseFlipValues;
            chkUseColor.Checked = project.UseBlendColor;
            chkWriteInstances.Checked = project.WriteInstances;
            grpRoomProperties.Enabled = true;
            grpBackgrounds.Enabled = true;
        } 

        /// <summary>
        /// Item check
        /// </summary>
        private void lstRooms_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Set project as exporting
            ProjectManager.Room.Projects[e.Index].Exporting = e.NewValue == CheckState.Checked ? true : false;

            // Export projects have changed
            _changed = _allowChange;
        }

        /// <summary>
        /// Room name text changed
        /// </summary>
        private void txtRoomName_TextChanged(object sender, EventArgs e)
        {
            // If a project was not selected or the name text box has no focus, return
            if (lstRooms.SelectedItem == null || !txtRoomName.Focused)
                return;

            // Change the name of the room
            (lstRooms.SelectedItem as ExportProject).Name = txtRoomName.Text;
            
            // If the native room, change the name of the room name
            if ((lstRooms.SelectedItem as ExportProject).Native)
                ProjectManager.Room.Name = (string)txtRoomName.Text.Clone();
            
            // Refresh the project list
            UpdateProjectList(lstRooms.SelectedIndex);

            // Export projects have changed
            _changed = _allowChange;
        }

        /// <summary>
        /// Project path button click
        /// </summary>
        private void txtProjectPath_ButtonClick(object sender, EventArgs e)
        {
            // If no project has been selected
            if (lstRooms.SelectedItem == null)
                return;

            // Create a new open file dialog
            using (OpenFileDialog form = new OpenFileDialog())
            {
                // Set file format filter
                form.Title = "Add Project(s)";
                form.Filter = "GMare Project Files (.gmpx)|*.gmpx;";

                // If ok was not clicked, return
                if (form.ShowDialog() != DialogResult.OK)
                    return;

                // Update the project file path
                (lstRooms.SelectedItem as ExportProject).RoomPath = form.FileName;

                // Update the project list
                UpdateProjectList(lstRooms.SelectedIndex);

                // Export projects have changed
                _changed = _allowChange;
            }
        }

        /// <summary>
        /// Write tiles checkbox check changed
        /// </summary>
        private void chkOptions_CheckedChanged(object sender, EventArgs e)
        {
            // If the calling object is not a checkbox or the selection is empty, return
            if (!(sender is CheckBox) || lstRooms.SelectedItem == null)
                return;

            // Get the calling checkbox name
            string name = (sender as CheckBox).Name;

            // Get the export project, and the index
            ExportProject project = (ExportProject)lstRooms.SelectedItem;

            // Do action based on checkbox
            if (chkWriteTiles.Name == name)
            {
                // Set UI flags
                chkUseFlipped.Checked = chkWriteTiles.Checked ? chkUseFlipped.Checked : false;
                chkUseColor.Checked = chkWriteTiles.Checked ? chkUseFlipped.Checked : false;
                //chkUseFlipped.Enabled = chkWriteTiles.Checked;
                //chkUseColor.Enabled = chkWriteTiles.Checked;

                // Set project flags
                project.WriteTiles = chkWriteTiles.Checked;
            }
            else if (chkUseFlipped.Name == name)
                project.UseFlipValues = chkUseFlipped.Checked;
            else if (chkUseColor.Name == name)
                project.UseBlendColor = chkUseColor.Checked;
            else if (chkWriteInstances.Name == name)
                project.WriteInstances = chkWriteInstances.Checked;

            // Export projects have changed
            _changed = _allowChange;
        }

        /// <summary>
        /// Set background button click
        /// </summary>
        private void butSetBackground_Click(object sender, EventArgs e)
        {
            // If a room has not been selected, return
            if (lstRooms.SelectedItem == null)
                return;

            // Create an open file dialog box
            using (OpenFileDialog form = new OpenFileDialog())
            {
                // Set file filter
                form.Filter = "Supported Files (.gmk, .gm6, .gmd .gm81)|*.gmk;*.gm6;*.gmd;*.gm81;*.gmx;";

                // If the dialog result was not Ok, return
                if (form.ShowDialog() != DialogResult.OK)
                    return;

                // Create a Game Maker project form
                using (GMProjectLoadForm iof = new GMProjectLoadForm(form.FileName))
                {
                    // Show the form
                    iof.ShowDialog();

                    // Create a new import background form
                    using (ImportBackgroundForm backgroundForm = new ImportBackgroundForm(iof.Project.Backgrounds.FindAll(b => b.UseAsTileSet == true).ToArray()))
                    {
                        // If dialog result is Ok
                        if (backgroundForm.ShowDialog() == DialogResult.OK)
                        {
                            // Set background and update list
                            if (backgroundForm.Background != null)
                            {
                                (lstRooms.SelectedItem as ExportProject).Background = backgroundForm.Background;
                                UpdateProjectList(lstRooms.SelectedIndex);

                                // Export projects have changed
                                _changed = _allowChange;
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Update the list of projects
        /// </summary>
        /// <param name="index">The index to select</param>
        private void UpdateProjectList(int index)
        {
            // Clear existing items
            lstRooms.Items.Clear();

            // Add projects to export to the project list
            for (int i = 0; i < ProjectManager.Room.Projects.Count; i++)
            {
                lstRooms.Items.Add(ProjectManager.Room.Projects[i]);
                lstRooms.SetItemChecked(i, ProjectManager.Room.Projects[i].Exporting);
            }

            // Set selected index
            lstRooms.SelectedIndex = index;
        }

        /// <summary>
        /// Writes a GMare binary file
        /// </summary>
        public void WriteBinaryFile(string path)
        {
            // Create a new file stream
            using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                // Create a binary reader
                BinaryWriter writer = new BinaryWriter(stream);
                
                // Write file id
                writer.Write(new char[4] { 'G', 'B', 'I', 'N' });
                writer.Write((short)GetRoomCount());

                // Write rooms
                foreach (ExportProject project in lstRooms.CheckedItems)
                {
                    // If not exporting the project, continue
                    if (!project.Exporting)
                        continue;

                    // Get the room
                    GMareRoom room = project.Native ? ProjectManager.Room : ProjectManager.OpenProject(project.RoomPath);

                    // Write room name and size of room data
                    writer.Write((byte)project.Name.Length);
                    writer.Write((char[])project.Name.ToCharArray());

                    // Get the complete byte size of the room
                    int size = room.GetByteCount(project.Background, project.WriteTiles, project.UseFlipValues, 
                        project.UseBlendColor, project.WriteInstances, true);

                    writer.Write((int)size);

                    // Write room data
                    writer.Write((bool)project.WriteTiles);
                    writer.Write((bool)project.UseFlipValues);
                    writer.Write((bool)project.UseBlendColor);
                    writer.Write((bool)project.WriteInstances);
                    
                    // If writing tiles to file and there's a background
                    if (project.WriteTiles)
                    {
                        // Calculate tile columns
                        int width = project.Background.Image.Width;
                        int offsetX = project.Background.OffsetX;
                        int tileWidth = project.Background.TileWidth;
                        int separationX = project.Background.SeparationX;
                        int backgroundCols = (width - (((width - offsetX) / tileWidth) * separationX)) / tileWidth;

                        // Write room data
                        writer.Write((int)room.Layers.Count);
                        writer.Write((short)room.Columns);
                        writer.Write((short)room.Rows);
                        writer.Write((byte)project.Background.OffsetX);
                        writer.Write((byte)project.Background.OffsetY);
                        writer.Write((byte)project.Background.SeparationX);
                        writer.Write((byte)project.Background.SeparationY);
                        writer.Write((byte)project.Background.TileWidth);
                        writer.Write((byte)project.Background.TileHeight);
                        writer.Write((int)backgroundCols);
                        writer.Write((int)project.Background.GameMakerId);
                        writer.Write((int)project.Background.Name.Length);
                        writer.Write((char[])project.Background.Name.ToCharArray());
                        
                        // Write layers
                        foreach (GMareLayer layer in room.Layers.OrderByDescending(l => l.Depth))
                        {
                            // Get binary tiles, then determine the best method
                            int tiledSize = 0;
                            int standardSize = 0;
                            ExportTile[] tiles = layer.GetExportTiles(project.Background, true, -1);
                            BinaryMethodType method = room.GetTileMethodType(layer, tiles, project.Background, 
                                project.UseFlipValues, project.UseBlendColor, out tiledSize, out standardSize);

                            // Write depth of the layer and binary method used
                            writer.Write((int)layer.Depth);
                            writer.Write((byte)method);

                            // Write data based on tile method
                            switch (method)
                            {
                                // Tiled data method
                                case BinaryMethodType.Tiled:

                                    // Write tile data
                                    for (int row = 0; row < layer.Tiles.GetLength(1); row++)
                                    {
                                        for (int col = 0; col < layer.Tiles.GetLength(0); col++)
                                        {
                                            // Write tile id
                                            writer.Write((int)layer.Tiles[col, row].TileId);

                                            // If the tile is empty, no need to put other data in
                                            if (layer.Tiles[col, row].TileId == -1)
                                                continue;

                                            // If flipping data is used
                                            if (project.UseFlipValues)
                                                writer.Write((byte)layer.Tiles[col, row].FlipMode);

                                            // If blend color data is used
                                            if (project.UseBlendColor)
                                                writer.Write((int)GameMaker.Common.GMUtilities.ColorToGMColor(layer.Tiles[col, row].Blend));
                                        }
                                    }

                                    break;

                                // GM Tile method
                                case BinaryMethodType.Standard:

                                    // Write the number of tiles
                                    writer.Write((int)tiles.Length);

                                    // Iterate through tiles
                                    foreach (ExportTile tile in tiles)
                                    {
                                        writer.Write((int)tile.Rect.X);
                                        writer.Write((int)tile.Rect.Y);
                                        writer.Write((int)tile.Location.X);
                                        writer.Write((int)tile.Location.Y);
                                        writer.Write((int)tile.Rect.Width);
                                        writer.Write((int)tile.Rect.Height);

                                        // If using flip data
                                        if (project.UseFlipValues)
                                            writer.Write((byte)tile.FlipMode);

                                        // If using color data
                                        if (project.UseBlendColor)
                                            writer.Write((int)GameMaker.Common.GMUtilities.ColorToGMColor(tile.BlendColor));
                                    }

                                    break;
                            }
                        }
                    }

                    // If instances should be written to the file
                    if (project.WriteInstances)
                    {
                        // Write the number of instances
                        writer.Write((int)room.Instances.Count);

                        // Iterate through instances
                        foreach (GMInstance instance in room.Instances)
                        {
                            // Write instance data
                            writer.Write((int)instance.ObjectName.Length);
                            writer.Write((char[])instance.ObjectName.ToCharArray());
                            writer.Write((int)instance.ObjectId);
                            writer.Write((int)instance.X);
                            writer.Write((int)instance.Y);
                            writer.Write((int)instance.CreationCode.Length);
                            writer.Write((char[])instance.CreationCode.ToCharArray());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get the count of valid export projects
        /// </summary>
        /// <returns>The number of valid export projects</returns>
        private int GetRoomCount()
        {
            // Valid project export count
            int count = 0;

            // Iterate through export projects
            foreach (ExportProject project in lstRooms.CheckedItems)
            {
                // If the room path is empty or does not exist, notify the user and continue
                if (project.RoomPath == "" || !File.Exists(project.RoomPath))
                {
                    MessageBox.Show("The Room: " + project.Name + ", does not have a valid file path and will not be exported.",
                        "GMare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    project.Exporting = false;
                    continue;
                }

                // Increment the project count
                count++;
            }

            // Return valid count
            return count;
        }

        #endregion
    }
}