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
using System.Runtime.Serialization.Formatters.Binary;
using GameMaker.Project;
using GameMaker.Resource;
using GMare.Forms;

namespace GMare.Common
{
    public class ProjectManager
    {
        #region Fields

        public static GMareRoom Room = null;  // Global edit room.
        public static bool Changed = false;   // If the project changed.

        #endregion

        #region Methods

        /// <summary>
        /// Saves a project file.
        /// </summary>
        /// <param name="path">Path to save to.</param>
        public static void SaveProject(string path)
        {
            // If a project was loaded.
            if (Room == null)
            {
                MessageBox.Show("There was no loaded project to save.");
                return;
            }

            // Create a new file stream.
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                // Create binary writers.
                BinaryWriter bw = new BinaryWriter(fs);
                BinaryFormatter bf = new BinaryFormatter();

                // Create the magic number.
                char[] id = new char[4] { 'G', 'M', 'A', 'P' };

                // Write the majic number.
                bw.Write((char[])id);

                // Write product version.
                bw.Write(Application.ProductVersion);

                // Serialize room.
                bf.Serialize(fs, Room);
            }
        }

        /// <summary>
        /// Loads a project from a support file type.
        /// </summary>
        /// <param name="path">The path pointing to a supported file.</param>
        public static GMareRoom OpenProject(string path)
        {
            // New room.
            GMareRoom room = null;

            // Create a new file stream.
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                // Binary readers and formatters.
                BinaryReader br = new BinaryReader(fs);
                System.Runtime.Serialization.IFormatter bf = new BinaryFormatter();

                // Get file extension.
                int index = path.LastIndexOf('.');
                string ext = path.Substring(index).ToLower();

                // GMare project file.
                if (ext == ".gmpf")
                {
                    // If the magic number is incorrect, return null.
                    if (new string(br.ReadChars(4)) != "GMAP")
                    {
                        MessageBox.Show("Not a valid GMare project file. Load has failed.", "GMare", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return null;
                    }

                    // Read version information.
                    string fileVersion = br.ReadString();

                    // De-Serialize room.
                    try
                    {
                        room = (GMareRoom)bf.Deserialize(fs);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("The project failed to load. The project may be corrupted, or an unsupported version.", "GMare", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return null;
                    }
                }

                // Ore project file.
                if (ext == ".oref")
                {
                    // Read magic number and file id.
                    if ((br.ReadString() != "OREF") || (br.ReadInt32() != 77373732))
                    {
                        MessageBox.Show("Not a valid ORE project file. Load has failed.", "GMare", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return null;
                    }

                    try
                    {
                        // Set binder for Ore room deserialization.
                        bf.Binder = new OcarinaRoomEditor.RoomBinder();

                        // Deserialize ORE room.
                        OcarinaRoomEditor.Room oreRoom = (OcarinaRoomEditor.Room)bf.Deserialize(fs);

                        // Convert to GMare room.
                        room = GMareRoom.OreRoomToGMareRoom(oreRoom);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("The ORE project failed to load. The project may be corrupted, or an unsupported version.", "GMare", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return null;
                    }
                }

                // Image file.
                if (ext == ".png" || ext == ".bmp" || ext == ".gif")
                {
                    // Create a new image import form.
                    using (ImportImageForm form = new ImportImageForm((Bitmap)Bitmap.FromStream(fs)))
                    {
                        // If Ok was clicked from the dialog, set room.
                        if (form.ShowDialog() == DialogResult.OK)
                            room = form.NewRoom;
                        else
                            return null;
                    }
                }
            }

            // If the room was not loaded successfully, inform the user.
            if (room == null)
            {
                MessageBox.Show("There was a problem loading the project data. The file may be invalid or corrupt.", "GMare", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return null;
            }

            // Return the opened room.
            return room;
        }

        /// <summary>
        /// Gets a list of GMare objects.
        /// </summary>
        /// <param name="path">The file path to Game Maker project.</param>
        /// <returns>A list of GMare objects.</returns>
        public static void LoadObjects(string path)
        {
            // Clear previous objects if any.
            ProjectManager.Room.Objects.Clear();

            // New list of Gmare objects.
            List<GMareObject> objects = new List<GMareObject>();

            // Read desired project.
            GMProjectReader reader = new GMProjectReader();
            GMProject project = reader.ReadProject(path);

            // Check instances for differences.
            CheckInstances(project);

            // Iterate through project objects.
            foreach (GMObject resource in project.Objects)
            {
                // GMare object variables.
                int originX = 0;
                int originY = 0;
                Bitmap image = null;

                // Get the sprite object.
                GMSprite sprite = project.Sprites.Find(delegate(GMSprite i) { return i.Id == resource.SpriteId; });

                // If a sprite was found.
                if (sprite != null)
                {
                    // Get sprite data.
                    originX = sprite.OriginX;
                    originY = sprite.OriginY;
                    image = GameMaker.Common.GMUtilities.GetBitmap(sprite.SubImages[0]);

                    // Set transparency if needed.
                    if (sprite.Transparent && sprite.SubImages[0].Compressed)
                        image.MakeTransparent(image.GetPixel(0, image.Height - 1));
                }

                // Add new gmare object.
                Room.Objects.Add(new GMareObject(resource, image, resource.SpriteId, resource.Depth, originX, originY));
            }

            // Get the object nodes.
            Room.Nodes = project.ProjectTree.Nodes[7].Nodes;

            // Delete all previous textures if any.
            Graphics.GraphicsManager.DeleteTextures();

            // Iterate though new objects, add sprite texture.
            foreach (GMareObject obj in ProjectManager.Room.Objects)
                Graphics.GraphicsManager.LoadTexture(obj.Image, obj.Resource.Id);
        }

        /// <summary>
        /// Checks existing instances against newly imported objects.
        /// </summary>
        /// <param name="project">The Game Maker project to check against.</param>
        private static void CheckInstances(GMProject project)
        {
            // If no instances exist, return.
            if (Room.Instances.Count == 0)
                return;

            // Get object node.
            TreeNode root = GameMaker.Common.GMUtilities.GetTreeNodeFromGMNode(project.ProjectTree.Nodes[7]);

            // A list of checked object resources.
            Dictionary<int, GMResource> ids = new Dictionary<int,GMResource>();

            // A list of object nodes.
            List<TreeNode> nodes = new List<TreeNode>();

            // Get all the child nodes.
            foreach (TreeNode node in root.Nodes)
                nodes.Add(node);

            // Iterate through existing instances.
            foreach (GMareInstance instance in Room.Instances)
            {
                // If the instance's resource id does not match any new objects.
                if (project.Objects.Find(delegate(GMObject o) { return o.Id == instance.ObjectId; }) == null ||
                    project.Objects.Find(delegate(GMObject o) { return o.Name == instance.Name; }) == null)
                {
                    // If the id check has already processed the instance's object id.
                    if (ids.ContainsKey(instance.ObjectId) == true)
                    {
                        // Set new instance data.
                        int key = instance.ObjectId;
                        instance.ObjectId = ids[key].Id;
                        instance.Name = ids[key].Name;
                        continue;
                    }

                    // Give the user a choice of either replacing the instance's parent object id, or just delete them.
                    using (InstanceForm form = new InstanceForm(nodes.ToArray(), instance.Name))
                    {
                        // Show the instance options form.
                        form.ShowDialog();

                        // Set resource as one that has been checked.
                        ids.Add(instance.ObjectId, form.Object);

                        // Set instance with new data.
                        instance.ObjectId = form.Object.Id;
                        instance.Name = form.Object.Name;
                    }
                }
            }

            // Remove all instances that have an empty id.
            Room.Instances.RemoveAll(delegate(GMareInstance i) { return i.ObjectId == -1; });
        }

        #endregion
    }
}
