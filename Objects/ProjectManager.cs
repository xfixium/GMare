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
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections.Generic;
using GameMaker.Common;
using GameMaker.Project;
using GameMaker.Resource;
using GMare.Forms;

namespace GMare.Objects
{
    public class ProjectManager
    {
        #region Fields

        public static int TILE_EMPTY = -1;             // The number for an empty tile id
        public static GMareRoom Room = null;           // Global edit room
        public static bool Changed = false;            // If the project changed
        public static string SavePath = string.Empty;  // A valid save path for the current project

        #endregion

        #region Methods

        /// <summary>
        /// Saves a project file
        /// </summary>
        /// <param name="file">Path to save to</param>
        public static bool SaveProject(string file)
        {
            // If a project was loaded
            if (Room == null)
            {
                MessageBox.Show("There was no loaded project to save.");
                return false;
            }

            // If the file does not exist
            if (file == string.Empty)
            {
                // Create a save file dialog
                using (SaveFileDialog form = new SaveFileDialog())
                {
                    // Set filter
                    form.Filter = "GMare Project File (.gmpx)|*.gmpx";
                    form.Title = "Save Project As...";

                    // If the dialog result was Ok, save the project
                    if (form.ShowDialog() != DialogResult.OK)
                        return false;

                    // Save the project path
                    ProjectManager.SavePath = form.FileName;
                    file = form.FileName;
                }
            }

            // Create a new stream writer, write project xml
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(file))
            {
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(GMareRoom));
                writer.Serialize(sw, Room);
            }

            return true;
        }

        /// <summary>
        /// Loads a project from a support file type
        /// </summary>
        /// <param name="file">The path pointing to a supported file</param>
        public static void SetProject(string file)
        {
            // Get file extension
            string ext = file.Substring(file.LastIndexOf('.')).ToLower();

            // Image file
            if (ext == ".png" || ext == ".bmp" || ext == ".gif")
            {
                // Create a new file stream
                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    // Create a new image import form
                    using (ImportImageForm form = new ImportImageForm((Bitmap)Bitmap.FromStream(fs)))
                    {
                        // If Ok was clicked from the dialog, set room
                        if (form.ShowDialog() == DialogResult.OK)
                            Room = form.NewRoom;
                        else
                            return;
                    }
                }
            }

            // Create a new stream reader, read in standard xml project file
            using (StreamReader sr = new StreamReader(file))
            {
                XmlSerializer writer = new XmlSerializer(typeof(GMareRoom));
                Room = (GMareRoom)writer.Deserialize(sr);
            }

            // Set textures for loaded objects
            SetTextures();

            // If the room was not loaded successfully, inform the user
            if (Room == null)
            {
                MessageBox.Show("There was a problem loading the project data. The file may be invalid or corrupt.", "GMare", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            // Remove default background, update block instances
            Room.Backgrounds.RemoveAt(0);
            Room.UpdateBlockInstances();

            // Set edit room and save path, update the UI
            ProjectManager.SavePath = file;
        }

        /// <summary>
        /// Loads a project from a support file type
        /// </summary>
        /// <param name="file">The path pointing to a supported file</param>
        public static GMareRoom OpenProject(string file)
        {
            // Get file extension
            string ext = file.Substring(file.LastIndexOf('.')).ToLower();

            // If not a gmpx file
            if (ext != ".gmpx")
                return null;

            // Create a new room
            GMareRoom room = null;

            // Create a new stream reader, read in standard xml project file
            using (StreamReader sr = new StreamReader(file))
            {
                XmlSerializer writer = new XmlSerializer(typeof(GMareRoom));
                room = (GMareRoom)writer.Deserialize(sr);
            }

            // If the room was not loaded successfully, inform the user
            if (room == null)
            {
                MessageBox.Show("There was a problem loading the project data. The file may be invalid or corrupt.", "GMare", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return null;
            }

            // Return the opened room
            return room;
        }

        /// <summary>
        /// Gets a GMare room from a project file
        /// </summary>
        /// <param name="file">The path to the Game Maker project file</param>
        /// <returns>A GM project</returns>
        public static GMareRoom GetGMareProject(string file)
        {
            StreamReader sr = null;

            // Create a new stream reader, read in standard xml project file
            try
            {
                sr = new StreamReader(file);
                XmlSerializer writer = new XmlSerializer(typeof(GMareRoom));
                return (GMareRoom)writer.Deserialize(sr);
            }
            catch
            {
                MessageBox.Show("There was a problem loading the project data. The file may be invalid or corrupt.", "GMare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                // Dispose
                sr.Close();
                sr.Dispose();
            }

            return null;
        }

        /// <summary>
        /// Gets data from a Game Maker project file
        /// </summary>
        /// <param name="file">The path to the Game Maker project file</param>
        /// <returns>A GM project</returns>
        public static GMProject GetGMProject(string file)
        {
            // Read in the selected GM project file and show progress of read
            using (GMProjectLoadForm form = new GMProjectLoadForm(file))
            {
                form.ShowDialog();
                return form.Project;
            }
        }

        /// <summary>
        /// Gets objects
        /// </summary>
        /// <param name="file">The path to the Game Maker project file</param>
        public static void GetObjects(string file)
        {
            // Create a new Game Maker project form
            using (GMProjectLoadForm form = new GMProjectLoadForm(file))
            {
                // Show the form
                form.ShowDialog();

                // If the project is empty, return
                if (form.Project == null || form.Project.ProjectTree == null || form.Project.ProjectTree.Nodes == null)
                    return;

                // The object node index
                int objectIndex = -1;

                // Get the object node
                for (int i = 0; i < form.Project.ProjectTree.Nodes.Length; i++)
                    if (form.Project.ProjectTree.Nodes[i].ResourceType == GMResourceType.Objects)
                        objectIndex = i;

                // If no object node was found, return
                if (objectIndex == -1)
                    return;

                // Check instances for differences
                CheckInstances(form.Project);

                // Clear previous objects if any
                ProjectManager.Room.Objects.Clear();

                // Iterate through project objects
                foreach (GMObject resource in form.Project.Objects)
                {
                    // GMare object variables
                    int originX = 0;
                    int originY = 0;
                    Bitmap image = null;

                    // Get the sprite object
                    GMSprite sprite = form.Project.Sprites.Find(i => i.Id == resource.SpriteId);

                    // If a sprite was found
                    if (sprite != null)
                    {
                        // Get sprite data
                        originX = sprite.OriginX;
                        originY = sprite.OriginY;

                        // If there are no sub-images, skip image data
                        if (sprite.SubImages.Length <= 0)
                        {
                            // Add new gmare object
                            ProjectManager.Room.Objects.Add(new GMareObject(resource, image, resource.SpriteId, resource.Depth, originX, originY));
                            continue;
                        }

                        image = GameMaker.Common.GMUtilities.GetBitmap(sprite.SubImages[0]);

                        // Set transparency if needed
                        if (sprite.Transparent && sprite.SubImages[0].Compressed)
                            image.MakeTransparent(image.GetPixel(0, image.Height - 1));
                    }

                    // Add new gmare object
                    ProjectManager.Room.Objects.Add(new GMareObject(resource, image, resource.SpriteId, resource.Depth, originX, originY));
                }

                // Get the object nodes
                ProjectManager.Room.Nodes = form.Project.ProjectTree.Nodes[objectIndex].Nodes;

                // Set textures for loaded objects
                SetTextures();
            }
        }

        /// <summary>
        /// Set textures for loaded objects
        /// </summary>
        private static void SetTextures()
        {
            // Delete all previous textures if any
            Graphics.GraphicsManager.DeleteTextures();

            // If a room was not loaded, return
            if (ProjectManager.Room == null)
                return;

            // Iterate though new objects, add sprite texture
            foreach (GMareObject obj in ProjectManager.Room.Objects)
                Graphics.GraphicsManager.LoadTexture(obj.Image, obj.Resource.Id);
        }

        /// <summary>
        /// Checks existing instances against newly imported objects
        /// </summary>
        /// <param name="project">The Game Maker project to check against</param>
        private static void CheckInstances(GMProject project)
        {
            // If no instances exist, return
            if (ProjectManager.Room.Instances.Count == 0)
                return;

            // Get object node
            List<Image> images = new List<Image>();
            TreeNode root = GMUtilities.GetTreeNodeFromGMNode(project, project.ProjectTree.Nodes[7], images);

            // A list of checked object resources
            Dictionary<int, GMResource> ids = new Dictionary<int, GMResource>();

            // A list of object nodes
            List<TreeNode> nodes = new List<TreeNode>();

            // Get all the child nodes
            foreach (TreeNode node in root.Nodes)
                nodes.Add(node);

            // Iterate through existing instances
            foreach (GMareInstance instance in ProjectManager.Room.Instances)
            {
                // If the instance's resource id does not match any new objects
                if (project.Objects.Find(o => o.Id == instance.ObjectId ||  o.Name == instance.ObjectName) == null)
                {
                    // If the id check has already processed the instance's object id
                    if (ids.ContainsKey(instance.ObjectId) == true)
                    {
                        // Set new instance data.
                        int key = instance.ObjectId;
                        instance.ObjectId = ids[key].Id;
                        instance.ObjectName = ids[key].Name;
                        continue;
                    }

                    // Get original glyph graphic
                    Bitmap glyph = ProjectManager.Room.Objects.Find(o => o.Resource.Id == instance.ObjectId).Image;

                    // Give the user a choice of either replacing the instance's parent object id, or just delete them
                    using (InstanceConflictForm form = new InstanceConflictForm(nodes.ToArray(), instance.ObjectName, images.ToArray(), glyph))
                    {
                        // Show the instance options form
                        form.ShowDialog();

                        // Set resource as one that has been checked
                        ids.Add(instance.ObjectId, form.Object);

                        // Iterate through blocks
                        foreach (GMareInstance block in ProjectManager.Room.Blocks)
                        {
                            if (block.ObjectId == instance.ObjectId)
                            {
                                block.ObjectId = form.Object.Id;
                                block.ObjectName = form.Object.Name;
                            }
                        }

                        // Set instance with new data
                        instance.ObjectId = form.Object.Id;
                        instance.ObjectName = form.Object.Name;
                    }
                }
            }

            // Dispose
            foreach (Image img in images)
                img.Dispose();

            // Remove all instances that have an empty id
            ProjectManager.Room.Instances.RemoveAll(i => i.ObjectId == -1);
            ProjectManager.Room.Blocks.RemoveAll(b => b.ObjectId == -1);
        }

        #endregion
    }
}
