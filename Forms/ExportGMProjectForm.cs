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
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using GameMaker.Project;
using GameMaker.Common;
using GameMaker.Resource;
using GMare.Objects;
using ICSharpCode.SharpZipLib.Zip;

namespace GMare.Forms
{
    /// <summary>
    /// Exports a GMare room to a Game Maker project
    /// </summary>
    public partial class ExportGMProjectForm : Form
    {
        #region Fields

        private string _projectPath = string.Empty;               // The path to write the new project
        private GMProject _project = new GMProject();             // The read in project
        private GMProjectWriter _writer = new GMProjectWriter();  // Project writer

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new game maker export form
        /// </summary>
        /// <param name="projectPath">Path to a Game Maker project</param>
        public ExportGMProjectForm(GMProject project, string projectPath)
        {
            InitializeComponent();

            // Set image keys
            GMUtilities.ImageKeyGroup = imgProjectTree.Images.Keys[0];
            GMUtilities.ImageKeyGroupSelected = imgProjectTree.Images.Keys[1];
            GMUtilities.ImageKeyRoom = imgProjectTree.Images.Keys[2];
            GMUtilities.ImageKeyRoomSelected = imgProjectTree.Images.Keys[2];

            // Set project target Game Maker path
            _projectPath = projectPath;

            // Set Game Maker project
            _project = project;

            // If the project is empty, close dialog
            if (_project == null)
            {
                Close();
                return;
            }

            // Populate the backgrounds listbox
            foreach (GMBackground background in _project.Backgrounds)
            {
                // If the background has image data, add it to the list
                if (background.Image.Data != null)
                    lstBackgrounds.Items.Add(background);
            }

            // If there is at least one item to select, do so
            if (lstBackgrounds.Items.Count > 0)
                lstBackgrounds.SelectedIndex = 0;

            // The object node index
            int roomIndex = GetResourceIndex(GMResourceType.Rooms);

            // If no object node was found, return
            if (roomIndex == -1)
                return;

            // Add room nodes to treeview
            //tvRooms.Nodes.Add(GMUtilities.GetTreeNodeFromGMNode(_project, _project.ProjectTree, null));
            tvRooms.Nodes.Add(GMUtilities.GetTreeNodeFromGMNode(_project, _project.ProjectTree.Nodes[roomIndex], null));
            tvRooms.SelectedNode = tvRooms.Nodes[0];
            tvRooms.Nodes[0].Expand();

            // Set name of room in text box
            txtName.Text = App.Room.Name;

            // Verify requistes
            Verify();
        }

        #endregion

        #region Events

        /// <summary>
        /// Ok button clicked
        /// </summary>
        private void butExport_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a backup of the original project file
                string filePath = MakeBackup();

                // If the backup failed, return, else write the file
                if (filePath == "")
                    return;

                // Get the currently selected node
                GMNode node = tvRooms.SelectedNode.Tag as GMNode;
                
                // Create a new room
                GMRoom room;

                // If the node is a child node
                if (node.NodeType == GMNodeType.Child)
                {
                    // Give warning about an overwrite
                    DialogResult result = MessageBox.Show("Are you sure you want to overwrite room: " + node.Name + "?", "GMare",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                    // If not ok, return
                    if (result != DialogResult.Yes)
                        return;
                }

                // If the node is being overwritten, overwrite, else add the node
                if (node.NodeType == GMNodeType.Child)
                {
                    // Find the room to overwrite
                    room = _project.Rooms.Find(r => r.Id == node.Id);

                    // Set room properties
                    if (!SetRoomProperties(room, -1))
                    {
                        // Notify the user that the export failed
                        MessageBox.Show("An error occurred while exporting the room, export aborted.", "GMare",
                            MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }
                }
                else
                {
                    // Check for any resource doubles
                    foreach (string asset in _project.Assets)
                    {
                        // If the asset already exists, return
                        if (asset == txtName.Text)
                        {
                            MessageBox.Show("The game resource name already exists. Please use a unique name for this room. Export aborted.", "GMare",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }

                    // Create a new room
                    room = new GMRoom();

                    // Set room properties
                    if (!SetRoomProperties(room, _project.Rooms.LastId++))
                    {
                        // Give warning about an overwrite
                        MessageBox.Show("An error occurred while exporting the room, export aborted.", "GMare",
                            MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    // Add the room to the project
                    _project.Rooms.Add(room);

                    // Increase the amount of children for parent node
                    (tvRooms.SelectedNode.Tag as GMNode).Children++;

                    // Create a new tree node
                    TreeNode treeNode = new TreeNode(room.Name);

                    // Create a new Game Maker node
                    GMNode newNode = new GMNode();
                    newNode.Name = room.Name;
                    newNode.NodeType = GMNodeType.Child;
                    newNode.ResourceType = GMResourceType.Rooms;
                    newNode.ResourceSubType = GMResourceSubType.Room;
                    newNode.Id = room.Id;
                    newNode.FilePath = "rooms\\" + room.Name;

                    // Set the tree node tag to Game Maker node
                    treeNode.Tag = newNode;
                    treeNode.ImageIndex = 2;

                    // Add the new node to the tree
                    tvRooms.SelectedNode.Nodes.Add(treeNode);
                }

                // Set room nodes
                _project.ProjectTree.Nodes[GetResourceIndex(GMResourceType.Rooms)] = GMUtilities.GetGMNodeFromTreeNode(tvRooms.Nodes[0]);

                // If refactor tiles, refactor
                if (chkRefactorTiles.Checked == true)
                    _project.RefactorTileIds();

                // If refactor instances, refactor
                if (chkRefactorInstances.Checked == true)
                    _project.RefactorInstanceIds();

                // If a game maker studio project and there is room data, wirte project
                if (_project.GameMakerVersion == GMVersionType.GameMakerStudio)
                {
                    // If the room was never created, notify user
                    if (room == null)
                        MessageBox.Show("There was an error creating the room to export. Export failed.", "GMare", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    else
                    {
                        // NOTE: Normally I would not do things this way. It should be the data that drives
                        // the project file creation. However, we're only changing the room portion of the 
                        // project and it's just safer, as of now, to write only the project file and the 
                        // room vs. writing the entire project out. Luckily GM:S is modular and allows that
                        // to happen
                        GameMaker.Resource.GMNode.WriteNodesGMX(_projectPath, ref _project);
                        GameMaker.Resource.GMRoom.WriteRoomGMX(room, Path.GetDirectoryName(_projectPath) + "\\" + "rooms");
                    }
                }
                // Legacy Game Maker project write
                else
                    _writer.WriteGMProject(_projectPath, _project, _project.GameMakerVersion);

                // Display success message
                if (MessageBox.Show("Export complete. A backup of the original project was made. Do you want to open the directory it was copied to?", "GMare",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    Process.Start(filePath);

                // Close the form
                Close();
            }
            catch (Exception)
            {
                // Notify the user that the export failed
                MessageBox.Show("An error occurred while exporting the room, export aborted.", "GMare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Cancel button clicked
        /// </summary>
        private void butCancel_Click(object sender, EventArgs e)
        {
            // Set dialog result and close
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Write tiles checkbox check changed
        /// </summary>
        private void chkWriteTiles_CheckedChanged(object sender, EventArgs e)
        {
            lstBackgrounds.Enabled = chkWriteTiles.Checked;
        }

        /// <summary>
        /// View optimization button click
        /// </summary>
        private void butViewOptimization_Click(object sender, EventArgs e)
        {
            // Create a new view form
            using (ViewLayerForm form = new ViewLayerForm(App.Room.Layers, true))
            {
                // Show the form
                form.ShowDialog();
            }
        }

        /// <summary>
        /// Room tree view mouse down
        /// </summary>
        private void tvRooms_MouseDown(object sender, MouseEventArgs e)
        {
            // If the left mouse button was clicked and a node exists at the mouse location
            if (e.Button == MouseButtons.Left && tvRooms.GetNodeAt(e.X, e.Y) != null)
                tvRooms.SelectedNode = tvRooms.GetNodeAt(e.X, e.Y);
        }

        /// <summary>
        /// Rooms treeview after select
        /// </summary>
        private void tvRooms_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Get the currently selected node
            GMNode node = tvRooms.SelectedNode.Tag as GMNode;

            // If the node is a child node, disable room name (it will inherit the overwritten room's name), else enable it
            txtName.Text = node.NodeType == GMNodeType.Child ? node.Name : App.Room.Name;
            txtName.Enabled = node.NodeType == GMNodeType.Child ? false : true;

            Verify();
        }

        /// <summary>
        /// Backgrounds listbox selected index changed
        /// </summary>
        private void lstBackgrounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            Verify();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the index to the Game Maker resource type
        /// </summary>
        /// <returns>An index to the given Game Maker resource type's parent node</returns>
        private int GetResourceIndex(GMResourceType type)
        {
            // Get the room parent node
            for (int i = 0; i < _project.ProjectTree.Nodes.Length; i++)
                if (_project.ProjectTree.Nodes[i].ResourceType == type)
                    return i;

            // Return room node
            return -1;
        }

        /// <summary>
        /// Check if requirements have been met before export
        /// </summary>
        private void Verify()
        {
            // If both a room node and background have been selected, enable the ok button
            butExport.Enabled = tvRooms.SelectedNode != null && lstBackgrounds.SelectedItem != null ? true : false;

            // If no background, disable tile export
            if (App.Room.Backgrounds[0].Image == null)
            {
                chkWriteTiles.Checked = false;
                chkWriteTiles.Enabled = false;
                lstBackgrounds.Enabled = false;
                chkOptimizeTiles.Enabled = false;
                butViewOptimization.Checked = false;
                butViewOptimization.Enabled = false;
            }
        }

        /// <summary>
        /// Sets the instances
        /// </summary>
        private GMInstance[] SetInstances()
        {
            // Get regular and block instances
            List<GMareInstance> gmareInstances = new List<GMareInstance>();
            gmareInstances.AddRange(App.Room.Instances.ToArray());

            // Create a game maker instance array
            GMInstance[] instances = new GMInstance[gmareInstances.Count];

            // Set room instances
            for (int i = 0; i < gmareInstances.Count; i++)
            {
                // If game maker studio, else Game Maker legacy
                if (_project.GameMakerVersion == GMVersionType.GameMakerStudio)
                {
                    // If the object id does not exist in the export project, abort
                    if (_project.Objects.Find(o => o.Name == gmareInstances[i].ObjectName) == null)
                    {
                        MessageBox.Show("Could not find the object: " + gmareInstances[i].ObjectName + " within the target export project.",
                            "GMare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return null;
                    }
                }
                else
                {
                    // If the object id does not exist in the export project, abort
                    if (_project.Objects.Find(o => o.Id == gmareInstances[i].ObjectId) == null)
                    {
                        MessageBox.Show("Could not find the object: " + gmareInstances[i].Name + "(Id: " + gmareInstances[i].ObjectId + ") within the target export project.",
                            "GMare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return null;
                    }
                }

                // Increment project last instance id
                _project.LastInstanceId++;

                // Create a new instance
                instances[i] = new GMInstance();
                instances[i].Name = GetUniqueName(false);
                instances[i].CreationCode = (string)gmareInstances[i].CreationCode.Clone();
                instances[i].Id = _project.LastInstanceId;
                instances[i].ObjectName = gmareInstances[i].ObjectName;
                instances[i].ObjectId = gmareInstances[i].ObjectId;
                instances[i].X = gmareInstances[i].X;
                instances[i].Y = gmareInstances[i].Y;
                instances[i].ScaleX = gmareInstances[i].ScaleX == 0 ? 1 : gmareInstances[i].ScaleX;
                instances[i].ScaleY = gmareInstances[i].ScaleY == 0 ? 1 : gmareInstances[i].ScaleY;
            }

            // Return an array of instances
            return instances;
        }

        /// <summary>
        /// Sets the given Game Maker room properties to GMare project room properties
        /// </summary>
        /// <param name="room">The room to set properties of</param>
        /// <param name="id">Id of the room</param>
        /// <returns>If the room property set was sucessful</returns>
        private bool SetRoomProperties(GMRoom room, int id)
        {
            // Get the game maker background selected
            GMBackground background = (GMBackground)lstBackgrounds.SelectedItem;

            // If the selected background dimensions do not match the GMare project's background
            if (chkWriteTiles.Checked && (App.Room.Backgrounds[0].Image.Width != background.Width || App.Room.Backgrounds[0].Image.Height != background.Height))
            {
                // Give warning, and cancel export
                DialogResult result = MessageBox.Show("The selected background's size does not match the background used for this room. Please select a background that is the same size as the used background.", 
                    "GMare", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                return false;
            }

            // Set room properties
            room.Id = id == -1 ? room.Id : id;
            room.Name = txtName.Text;
            room.BackgroundColor = GMUtilities.ColorToGMColor(App.Room.BackColor);
            room.Width = App.Room.Width;
            room.Height = App.Room.Height;
            room.TileWidth = App.Room.Backgrounds[0].TileWidth;
            room.TileHeight = App.Room.Backgrounds[0].TileHeight;
            room.Caption = App.Room.Caption;
            room.CreationCode = App.Room.CreationCode;
            room.Speed = App.Room.Speed;
            room.Persistent = App.Room.Persistent;

            // If exporting tiles, set tiles
            if (chkWriteTiles.Checked)
            {
                // Copy the room's background, set the game maker background id
                GMareBackground gmareBackground = App.Room.Backgrounds[0].Clone();
                gmareBackground.GameMakerId = background.Id;
                gmareBackground.Name = background.Name;

                // Get tile array
                GMTile[] tiles = App.Room.GMareTilesToGMTiles(_project.LastTileId, gmareBackground, chkOptimizeTiles.Checked);

                // Set unique names
                foreach (GMTile tile in tiles)
                    tile.Name = GetUniqueName(true);

                // Set the room's tiles
                room.Tiles = tiles;
            }

            // If the room's instances should be written, write instances
            if (chkWriteInstances.Checked)
            {
                room.Instances = SetInstances();

                // If no instances, return  unsuccessful
                if (room.Instances == null)
                    return false;
            }

            // Successful
            return true;
        }

        /// <summary>
        /// Gets a unique tile name
        /// </summary>
        /// <param name="tileName">If getting a unique name for a tile or instance</param>
        /// <returns>A unique name</returns>
        private string GetUniqueName(bool tileName)
        {
            // Random hex generator
            Random random = new Random();
            string name = "";
            bool match = false;

            // Iterate indefinitely
            while (true)
            {
                // Reset match flag
                match = false;

                // Create a random name
                name =  (tileName ? "tile_" : "inst_") + String.Format("{0:X8}", GMUtilities.StaticRandom.Instance.Next(0x10000000));

                // Iterate through rooms
                foreach (GMRoom room in _project.Rooms)
                {
                    // If tile name else instance name
                    if (tileName)
                    {
                        // If the name exists already, break and set flag
                        if (Array.IndexOf(room.Tiles, name) > -1)
                        {
                            match = true;
                            break;
                        }
                    }
                    else
                    {
                        // If the name exists already, break and set flag
                        if (Array.IndexOf(room.Instances, name) > -1)
                        {
                            match = true;
                            break;
                        }
                    }
                }

                // If there is no match, the name is unique
                if (!match)
                    return name;
            }
        }

        /// <summary>
        /// Makes a backup file of the selected game maker project file
        /// </summary>
        private string MakeBackup()
        {
            try
            {
                // If the source file no longer exists, abort export
                if (!File.Exists(_projectPath))
                {
                    MessageBox.Show("Could not find the source Game Make project to export to. It may have been moved or deleted. Export aborted.", "GMare",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return "";
                }

                // Get application save path
                string source = Path.GetDirectoryName(_projectPath);
                string target = Path.GetDirectoryName(App.SavePath == "" ? Application.ExecutablePath : App.SavePath);
                string fileName = Path.GetFileNameWithoutExtension(_projectPath);
                string fileNameExt = Path.GetFileName(_projectPath);
                string temp = Path.GetTempPath();

                // If the save directory does not exist, save backup to application directory
                if (!Directory.Exists(target))
                    target = Path.GetDirectoryName(Application.ExecutablePath);

                // Get date string to attach to file
                string date = "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();

                // If a game maker studio project, create a backup .zip
                if (_project.GameMakerVersion == GMVersionType.GameMakerStudio)
                {
                    // Create set target path and temp path to write to
                    target += "\\" + fileName + date + ".zip";
                    temp += "\\" + fileName + date + ".zip";

                    // Zip the source to the target .zip
                    FastZip fz = new FastZip();
                    fz.CreateZip(temp, source, true, "");
                    File.Copy(temp, target);
                    File.Delete(temp);
                    
                    // If the backup was not made successfully
                    if (!File.Exists(target))
                    {
                        ShowFileErrorMessage();
                        return "";
                    }

                    return target.Remove(target.LastIndexOf("\\"));
                }

                // Reset target and source paths with filename included
                target = Path.Combine(target, fileName + date + ".bak");
                source = Path.Combine(source, fileNameExt);

                // Copy project from source to target
                File.Copy(source, target, true);

                // If the backup was not made successfully
                if (!File.Exists(target))
                {
                    ShowFileErrorMessage();
                    return "";
                }

                // Create file info base on target file
                FileInfo info = new FileInfo(target);

                // If the backup data is empty
                if (info.Length == 0)
                {
                    ShowFileErrorMessage();
                    return "";
                }

                // Return successful target path
                return Path.GetDirectoryName(target);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                // If an error occurs, abort export
                ShowFileErrorMessage();
                return "";
            }
        }

        /// <summary>
        /// Shows a common file error message
        /// </summary>
        private void ShowFileErrorMessage()
        {
            // If an error occurs, abort export
            MessageBox.Show("There was a problem backing up the original Game Maker project. It may be a permissions issue. Export aborted.", "GMare",
                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        #endregion
    }
}