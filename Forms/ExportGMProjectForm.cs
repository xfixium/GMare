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
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using GameMaker.Project;
using GameMaker.Common;
using GameMaker.Resource;
using GMare.Common;

namespace GMare.Forms
{
    /// <summary>
    /// Export GMare room to a Game Maker project form.
    /// </summary>
    public partial class ExportGMProjectForm : Form
    {
        #region Fields

        private string _projectPath = string.Empty;  // The path to write the new project.
        private GMProject _project = null;           // The read in project.
        private GMProjectWriter _writer = new GMProjectWriter();  // Project writer.

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs an export form.
        /// </summary>
        /// <param name="projectPath">Path to a Game Maker project.</param>
        public ExportGMProjectForm(string projectPath)
        {
            InitializeComponent();

            // Set image keys.
            GMUtilities.ImageKeyGroup = imageList1.Images.Keys[0];
            GMUtilities.ImageKeyGroupSelected = imageList1.Images.Keys[1];
            GMUtilities.ImageKeyRoom = imageList1.Images.Keys[2];
            GMUtilities.ImageKeyRoomSelected = imageList1.Images.Keys[2];

            // Set project target Game Maker path.
            _projectPath = projectPath;

            // Read in a Game Maker project.
            _project = GMUtilities.ReadGMProject(projectPath);

            // Populate the backgrounds listbox.
            foreach (GMBackground background in _project.Backgrounds)
            {
                // Add all backgrounds to the background list.
                lstbx_Backgrounds.Items.Add(background);
            }

            // If there is at least one item to select, do so.
            if (lstbx_Backgrounds.Items.Count > 0)
                lstbx_Backgrounds.SelectedIndex = 0;

            // Get root node.
            TreeNode root = GMUtilities.GetTreeNodeFromGMNode(_project.ProjectTree.Nodes[8]);

            // Add room nodes to treeview.
            foreach (TreeNode node in root.Nodes)
            {
                tv_Rooms.Nodes.Add(node);
            }

            // Set name of room in text box.
            tstb_Name.Text = ProjectManager.Room.Name;

            // Verify requistes.
            Verify();
        }

        #endregion

        #region Events

        /// <summary>
        /// Ok button clicked.
        /// </summary>
        private void tsb_Export_Click(object sender, EventArgs e)
        {
            // Get the currently selected node.
            GMNode node = tv_Rooms.SelectedNode.Tag as GMNode;

            // If the node is a child node.
            if (node.NodeType == GMNodeType.Child)
            {
                // Give warning about an overwrite.
                DialogResult result = MessageBox.Show("Are you sure you want to overwrite room: " + node.Name + "?", "GMare", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                // If not ok, return.
                if (result != DialogResult.Yes)
                    return;
            }

            // Offsets and spacing.
            int tileCols = ProjectManager.Room.GetTileset().Width / ProjectManager.Room.TileWidth;
            Point offset = new Point(ProjectManager.Room.OffsetX, ProjectManager.Room.OffsetY);
            Point spacing = new Point(ProjectManager.Room.SeparationX, ProjectManager.Room.SeparationY);

            // If the node is being overwritten, overwrite, else add the node.
            if (node.NodeType == GMNodeType.Child)
            {
                // Find the room to write over.
                GMRoom room = _project.Rooms.Find(delegate(GMRoom r) { return r.Id == node.Id; });

                // Write data.
                room.BackgroundColor = GMUtilities.ColorToGMColor(ProjectManager.Room.BackColor);
                room.Width = ProjectManager.Room.Width;
                room.Height = ProjectManager.Room.Height;
                room.Tiles = ProjectManager.Room.GMareTilesToGMTiles(_project.LastTileId, (lstbx_Backgrounds.SelectedItem as GMBackground).Id, ProjectManager.Room.TileSize, tileCols, offset, spacing);
                room.TileWidth = ProjectManager.Room.TileWidth;
                room.TileHeight = ProjectManager.Room.TileHeight;

                // If the room's instances should be overwritten, overwrite the instances.
                if (cb_OverwriteInstances.Checked == true)
                {
                    // Set room instances.
                    room.Instances = ProjectManager.Room.Instances.ToArray();

                    // Iterate through instances.
                    foreach (GMInstance inst in room.Instances)
                    {
                        // Increment last instance id indexer.
                        _project.LastInstanceId++;

                        // Set instance id.
                        inst.Id = _project.LastInstanceId;
                    }
                }

                // Change the node's name to the project room.
                node.Name = room.Name;

                // Overwrite the selected node.
                tv_Rooms.SelectedNode.Tag = node;
            }
            else
            {
                // Increase the amount of children for parent node.
                (tv_Rooms.SelectedNode.Tag as GMNode).Children++;

                // Create a Game Maker new room.
                GMRoom room = new GMRoom();

                // Write data.
                room.Id = node.Id;
                room.Name = tstb_Name.Text;
                room.BackgroundColor = GMUtilities.ColorToGMColor(ProjectManager.Room.BackColor);
                room.Width = ProjectManager.Room.Width;
                room.Height = ProjectManager.Room.Height;
                room.Tiles = ProjectManager.Room.GMareTilesToGMTiles(_project.LastTileId, (lstbx_Backgrounds.SelectedItem as GMBackground).Id, ProjectManager.Room.TileSize, tileCols, offset, spacing);
                room.TileWidth = ProjectManager.Room.TileWidth;
                room.TileHeight = ProjectManager.Room.TileHeight;

                // Add the room to the project.
                _project.Rooms.Add(room);

                // Create a new tree node.
                TreeNode treeNode = new TreeNode(room.Name);

                // Create a new Game Maker node.
                GMNode newNode = new GMNode();
                newNode.Name = room.Name;
                newNode.NodeType = GMNodeType.Child;
                newNode.ResourceType = GMResourceType.Rooms;
                newNode.Id = room.Id;

                // Set the tree node tag to Game Maker node.
                treeNode.Tag = newNode;

                // Add the new node to the tree.
                tv_Rooms.SelectedNode.Nodes.Add(treeNode);
            }

            // Set the project's tree.
            List<GMNode> nodes = new List<GMNode>();

            // Iterate through room nodes.
            foreach (TreeNode n in tv_Rooms.Nodes)
                nodes.Add(GMUtilities.GetGMNodeFromTreeNode(n));

            // Set room nodes.
            _project.ProjectTree.Nodes[8].Nodes = nodes.ToArray();

            // If the project's tiles need to be refactored, refactor project tile ids.
            if (cb_RefactorTiles.Checked == true)
                _project.RefactorTileIds();

            // If the project's instances need to be refactored, refactor project instance ids.
            if (cb_RefactorInstances.Checked == true)
                _project.RefactorInstanceIds();

            // Give warning about project overwrite.
            MessageBox.Show("Since GMare is still in the beta phases of development, it is suggested that you back up your project now, before overwriting it.", "GMare", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Write the project.
            _writer.WriteGMProject(_projectPath, _project, _project.GameMakerVersion);

            // Close the form.
            Close();
        }

        /// <summary>
        /// Cancel button clicked.
        /// </summary>
        private void tsb_Cancel_Click(object sender, EventArgs e)
        {
            // Set dialog result and close.
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Rooms treeview after select.
        /// </summary>
        private void tv_Rooms_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Verify();
        }

        /// <summary>
        /// Backgrounds listbox selected index changed.
        /// </summary>
        private void lstbx_Backgrounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            Verify();
        }

        /// <summary>
        /// Check if requirements have been met before export.
        /// </summary>
        private void Verify()
        {
            // If both a room node and background have been selected, enable the ok button.
            if (tv_Rooms.SelectedNode != null && lstbx_Backgrounds.SelectedItem != null)
                tsb_Export.Enabled = true;
            else
                tsb_Export.Enabled = false;
        }

        #endregion
    }
}