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
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using GMare.Common;
using GameMaker.Resource;

namespace GMare.Forms
{
    /// <summary>
    /// Export GMare room to a binary file form.
    /// </summary>
    public partial class ExportBinaryForm : Form
    {
        #region Constructor

        /// <summary>
        /// Constructs a new export to binary form.
        /// </summary>
        /// <param name="room">The initial room.</param>
        public ExportBinaryForm(GMareRoom room)
        {
            InitializeComponent();

            // Add the initial room.
            clb_Rooms.Items.Add(room);

            // Set information.
            SetTotalSize();
        }

        #endregion

        #region Events

        #region ToolStrip

        /// <summary>
        /// Save binary file click.
        /// </summary>
        private void tsb_Export_Click(object sender, EventArgs e)
        {
            // If no rooms have been selected, warn the user, then return.
            if (clb_Rooms.CheckedItems.Count <= 0)
            {
                MessageBox.Show("No rooms were selected for export.", "GMare", MessageBoxButtons.OK);
                return;
            }

            // Create a new save file dialog.
            using (SaveFileDialog form = new SaveFileDialog())
            {
                // GMare binary files.
                form.Filter = "Binary File (*.bin)|*.bin";

                // If ok was clicked.
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Write rooms to file.
                    WriteBinaryFile(form.FileName);
                }
            }
        }

        /// <summary>
        /// Cancel button click.
        /// </summary>
        private void tsb_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Add binary file click.
        /// </summary>
        private void tsb_AddRoom_Click(object sender, EventArgs e)
        {
            // Create a new open file dialog.
            using (OpenFileDialog form = new OpenFileDialog())
            {
                // Allow only binary files.
                // Set file format filter.
                form.Filter = "Supported Files (.gmpf, .oref)|*.gmpf;*.oref;";
                form.Multiselect = true;

                // If ok was clicked.
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Iterate through file names.
                    foreach (string path in form.FileNames)
                    {
                        // Get the room.
                        GMareRoom room = ProjectManager.OpenProject(path);

                        // Add the room to the room list.
                        clb_Rooms.Items.Add(room);
                    }
                }
            }

            // Set information.
            SetTotalSize();
        }

        /// <summary>
        /// Remove binary file click.
        /// </summary>
        private void tsb_RemoveFile_Click(object sender, EventArgs e)
        {
            // If there has been an item selected.
            if (clb_Rooms.SelectedItem == null)
                return;

            // Remove room.
            clb_Rooms.Items.Remove(clb_Rooms.SelectedItem);

            // Set information.
            SetTotalSize();
        }

        /// <summary>
        /// Button check all check changed.
        /// </summary>
        private void tsb_CheckAll_CheckChanged(object sender, EventArgs e)
        {
            // Iterate through items.
            for (int i = 0; i < clb_Rooms.Items.Count; i++)
            {
                // Set checked state.
                clb_Rooms.SetItemChecked(i, tsb_CheckAll.Checked);
            }

            // Set information.
            SetTotalSize();
        }

        #endregion

        #region CheckBoxes

        /// <summary>
        /// Checkbox checked change.
        /// </summary>
        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            // Set total size.
            SetTotalSize();
        }

        #endregion

        #region CheckListBox

        /// <summary>
        /// Rooms checklistbox key down.
        /// </summary>
        private void clb_Rooms_KeyDown(object sender, KeyEventArgs e)
        {
            // If shift and up key pressed, shift up the list.
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.A)
                tsmi_ShiftUp_Click(this, new ToolStripItemClickedEventArgs(tsmi_ShiftUp));

            // If shift and down key pressed, shift down the list.
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.S)
                tsmi_ShiftDown_Click(this, new ToolStripItemClickedEventArgs(tsmi_ShiftDown));
        }

        /// <summary>
        /// Rooms check list box selected index changed.
        /// </summary>
        private void clb_Rooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            // No room selected, return.
            if (clb_Rooms.SelectedItem == null)
            {
                // Set information.
                SetTotalSize();
                return;
            }

            // Get the selected room.
            GMareRoom room = clb_Rooms.SelectedItem as GMareRoom;

            // Set information.
            SetTotalSize();
        }

        /// <summary>
        /// Rooms check listbox mouse down.
        /// </summary>
        private void clb_Rooms_MouseDown(object sender, MouseEventArgs e)
        {
            // Selected index change.
            clb_Rooms_SelectedIndexChanged(this, EventArgs.Empty);

            // The selected item index
            int index = clb_Rooms.IndexFromPoint(e.Location);

            // Right mouse button clicked.
            if (e.Button == MouseButtons.Right)
            {
                // If there was an item under the cursor, and there are items to select.
                if (index != -1 && clb_Rooms.Items.Count > 0)
                {
                    // Select the item.
                    clb_Rooms.SelectedIndex = index;
                    
                    // Show the context menu.
                    cms_Options.Show(clb_Rooms, e.Location);
                }
            }
        }

        /// <summary>
        /// Shift up tool strip menu item click.
        /// </summary>
        private void tsmi_ShiftUp_Click(object sender, EventArgs e)
        {
            // If there is an item selected, and the item is not at the top of the list already.
            if (clb_Rooms.SelectedItem != null && clb_Rooms.SelectedIndex > 0)
            {
                // Get the selected shape.
                GMareRoom room = clb_Rooms.SelectedItem as GMareRoom;

                // Data to recall.
                int index = clb_Rooms.SelectedIndex;
                bool check = clb_Rooms.CheckedIndices.Contains(index);

                // Insert the copied shape one up.
                clb_Rooms.Items.Insert(index - 1, room);

                // Remove the old item.
                clb_Rooms.Items.RemoveAt(index + 1);

                // Set recall data.
                clb_Rooms.SelectedIndex = index - 1;
                clb_Rooms.SetItemChecked(clb_Rooms.SelectedIndex, check);
            }
        }

        /// <summary>
        /// Shift down tool strip menu item click.
        /// </summary>
        private void tsmi_ShiftDown_Click(object sender, EventArgs e)
        {
            // If there is an item selected, and the item is not at the bottom of the list already.
            if (clb_Rooms.SelectedItem != null && clb_Rooms.SelectedIndex < clb_Rooms.Items.Count - 1)
            {
                // Get the selected room.
                GMareRoom room = clb_Rooms.SelectedItem as GMareRoom;

                // Data to recall.
                int index = clb_Rooms.SelectedIndex;
                bool check = clb_Rooms.CheckedIndices.Contains(index);

                // Insert room two down.
                clb_Rooms.Items.Insert(index + 2, room);

                // Remove the old room.
                clb_Rooms.Items.RemoveAt(index);

                // Set recall data.
                clb_Rooms.SelectedIndex = index + 1;
                clb_Rooms.SetItemChecked(clb_Rooms.SelectedIndex, check);
            }
        }

        #endregion

        #endregion

        #region Methods

        #region Write Binary

        /// <summary>
        /// Writes a GMare binary file.
        /// </summary>
        public void WriteBinaryFile(string filePath)
        {
            // Create a new file stream.
            using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                // Create a binary reader.
                BinaryWriter writer = new BinaryWriter(stream);

                // Write file id.
                writer.Write(new char[4] { 'G', 'B', 'I', 'N' });

                // Write the amount of rooms.
                writer.Write((short)clb_Rooms.CheckedItems.Count);

                // The total header size.
                int headerSize = 6;

                foreach (GMareRoom room in clb_Rooms.CheckedItems)
                {
                    // Add the number of letters, the actual letters, and offset bytes.
                    headerSize += room.Name.Length + 5;
                }

                // The total room offset.
                int roomOffset = headerSize;

                // Write header.
                foreach (GMareRoom room in clb_Rooms.CheckedItems)
                {
                    // Write room string length.
                    writer.Write((byte)room.Name.Length);

                    // Write room name string.
                    writer.Write((char[])room.Name.ToCharArray());

                    // Write the offset to the room data.
                    writer.Write((int)roomOffset);

                    // Add room offset.
                    roomOffset += room.GetBinaryRoomSize(cb_Tiles.Checked, cb_Instances.Checked, cb_Collisions.Checked);
                }

                // Write rooms.
                foreach (GMareRoom room in clb_Rooms.CheckedItems)
                {
                    // If writing tiles to file.
                    if (cb_Tiles.Checked == true)
                    {
                        // Calculate tile columns.
                        int tileCols = (room.Background.Width - (((room.Background.Width - room.OffsetX) / room.TileWidth) * room.SeparationX)) / room.TileWidth;

                        // Write room data.
                        writer.Write((short)room.Columns);
                        writer.Write((short)room.Rows);
                        writer.Write((byte)room.OffsetX);
                        writer.Write((byte)room.OffsetY);
                        writer.Write((byte)room.SeparationX);
                        writer.Write((byte)room.SeparationY);
                        writer.Write((byte)room.TileWidth);
                        writer.Write((byte)room.TileHeight);
                        writer.Write((short)tileCols);
                        writer.Write((int)room.Layers.Count);
                        writer.Write((int)room.Instances.Count);
                        writer.Write((int)room.Shapes.Count);

                        // Write layers.
                        foreach (GMareLayer layer in room.Layers)
                        {
                            // Write layer data.
                            BinaryMethod method = GMareRoom.GetBinaryMethod(layer);
                            writer.Write((int)layer.Depth);
                            writer.Write((byte)method);

                            // Write tiles based on tile data method.
                            switch (method)
                            {
                                // Sector data method.
                                case BinaryMethod.Sector:

                                    // Write tile.
                                    for (int row = 0; row < layer.Tiles.GetLength(1); row++)
                                        for (int col = 0; col < layer.Tiles.GetLength(0); col++)
                                            writer.Write((short)layer.Tiles[col, row]);

                                    break;

                                // Tile data method.
                                case BinaryMethod.Tile:

                                    // Write the amount of tiles.
                                    writer.Write((int)GMareRoom.GetTileCount(layer));

                                    // Iterate through rows.
                                    for (int row = 0; row < layer.Tiles.GetLength(1); row++)
                                    {
                                        // Iterate through columns.
                                        for (int col = 0; col < layer.Tiles.GetLength(0); col++)
                                        {
                                            // If the tile is not empty, write tile.
                                            if (layer.Tiles[col, row] != -1)
                                            {
                                                writer.Write((short)layer.Tiles[col, row]);
                                                writer.Write((int)col * room.TileWidth);
                                                writer.Write((int)row * room.TileHeight);
                                            }
                                        }
                                    }

                                    break;
                            }
                        }
                    }

                    // If instances should be written to the file
                    if (cb_Instances.Checked == true)
                    {
                        // Iterate through instances.
                        foreach (GMInstance instance in room.Instances)
                        {
                            // Write instance data.
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

        #endregion

        #region SetTotalSize

        /// <summary>
        /// Sets the total size of the binary file.
        /// </summary>
        private void SetTotalSize()
        {
            // The total size of all rooms in binary form.
            int size = 6;

            // Iterate through rooms.
            foreach (GMareRoom room in clb_Rooms.CheckedItems)
            {
                // Increment the size.
                size += room.Name.Length + 5;
                size += room.GetBinaryRoomSize(cb_Tiles.Checked, cb_Instances.Checked, cb_Collisions.Checked);
            }

            // Return the total size of all rooms in binary form
            tssl_TotalSize.Text = "Total Size: " + (size / 1024) + "kb";
        }

        #endregion

        #endregion
    }
}