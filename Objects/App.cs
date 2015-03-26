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
using System.Reflection;
using System.Configuration;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GameMaker.Common;
using GameMaker.Project;
using GameMaker.Resource;
using GMare.Forms;

namespace GMare.Objects
{
    public class App
    {
        #region Fields

        public static int TILE_EMPTY = -1;                                             // The number for an empty tile id
        public static GMareRoom Room = null;                                           // Global edit room
        public static bool Changed = false;                                            // If the project changed
        public static string SavePath = string.Empty;                                  // A valid save path for the current project
        public static string UndoRedoMaximumAppKey = "UndoRedoMaximum";                // Undo/Redo maximum app.config settings key
        public static string LowerLayerBrightnessAppKey = "LowerLayerBrightness";      // Lower layer brightness app.config settings key
        public static string UpperLayerTransparencyAppKey = "UpperLayerTransparency";  // Upper layer transparency app.config settings key
        public static string ShowScaleWarningAppKey = "ShowScaleWarning";              // Scale warning app.config settings key
        public static string ShowBlendWarningAppKey = "ShowBlendWarning";              // Blend color warning app.config settings key
        public static string ShowTipsAppKey = "ShowTips";                              // If showing tips app.config settings key
        public static string ShowLayerCursorTipAppKey = "ShowLayerCursorTip";          // If showing the layer mouse tip app.config settings key
        public static int UndoRedoMaximumAppDefault = 15;                              // Undo/Redo maximum default value
        public static float LowerLayerBrightnessAppDefault = -0.4f;                    // Lower layer brightness default value
        public static float UpperLayerTransparencyAppDefault = 0.4f;                   // Upper layer transparency default value
        public static bool ShowScaleWarningAppDefault = false;                         // Scale warning default value
        public static bool ShowBlendWarningAppDefault = false;                         // Blend color warning default value
        public static bool ShowTipsAppDefault = true;                                  // If showing tips default value
        public static bool ShowLayerCursorTipAppDefault = true;                        // If showing the layer mouse tip

        #endregion

        #region Methods

        /// <summary>
        /// Gets the applications global configuration settings
        /// </summary>
        /// <returns>A configuration file</returns>
        public static Configuration GetConfig(bool supressWarning)
        {
            // Local variables acquiring config file
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string configPath = Path.Combine(appPath, "app.config");

            // If the app.config file does not exist
            if (!File.Exists(configPath))
            {
                // If not supressing the warning
                if (!supressWarning)
                    MessageBox.Show("GMare could not find the file: app.config. Please make sure it resides in the same directory as GMare.",
                        "GMare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                return null;
            }

            // Get the config file and return it
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = configPath;
            return ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
        }

        /// <summary>
        /// Gets the applications global configuration settings
        /// </summary>
        /// <returns>A configuration file</returns>
        private static bool ConfigKeyExists(Configuration config, string key)
        {
            // If the given config is empty, return false
            if (config == null)
                return false;

            // Iterate through app setting keys to see if the given key exists
            foreach (var k in config.AppSettings.Settings.AllKeys)
                if (k == key)
                    return true;

            return false;
        }

        /// <summary>
        /// Gets a boolean type from the given app setting key
        /// </summary>
        /// <param name="key">The key to search the value of</param>
        /// <param name="defaultValue">The default value if the key was not found</param>
        /// <returns>A boolean type value from the given app setting key</returns>
        public static bool GetConfigBool(string key, bool defaultValue)
        {
            // Get the config file
            Configuration config = App.GetConfig(true);

            // If the config file does not exist, or the key does not exist, return default value
            if (config == null || !ConfigKeyExists(config, key))
                return defaultValue;

            bool value = defaultValue;
            bool result = bool.TryParse(config.AppSettings.Settings[key].Value, out value);
            return result ? value : defaultValue;
        }

        /// <summary>
        /// Gets a int type from the given app setting key
        /// </summary>
        /// <param name="key">The key to search the value of</param>
        /// <param name="defaultValue">The default value if the key was not found</param>
        /// <returns>A int type value from the given app setting key</returns>
        public static int GetConfigInt(string key, int defaultValue)
        {
            // Get the config file
            Configuration config = App.GetConfig(true);

            // If the config file does not exist, or the key does not exist, return default value
            if (config == null || !ConfigKeyExists(config, key))
                return defaultValue;

            int value = defaultValue;
            bool result = int.TryParse(config.AppSettings.Settings[key].Value, out value);
            return result ? value : defaultValue;
        }

        /// <summary>
        /// Gets a float type from the given app setting key
        /// </summary>
        /// <param name="key">The key to search the value of</param>
        /// <param name="defaultValue">The default value if the key was not found</param>
        /// <returns>A float type value from the given app setting key</returns>
        public static float GetConfigFloat(string key, float defaultValue)
        {
            // Get the config file
            Configuration config = App.GetConfig(true);

            // If the config file does not exist, or the key does not exist, return default value
            if (config == null || !ConfigKeyExists(config, key))
                return defaultValue;

            float value = defaultValue;
            bool result = float.TryParse(config.AppSettings.Settings[key].Value, out value);
            return result ? value : defaultValue;
        }

        /// <summary>
        /// Gets a flag value from the app.config
        /// </summary>
        /// <returns>The app.config flag value</returns>
        public static void SetConfigBool(string key, bool val)
        {
            // Get the config file
            Configuration config = App.GetConfig(true);

            // If the config file was not found, return default
            if (config == null || !ConfigKeyExists(config, key))
                return;

            try
            {
                // Set the config with user values
                config.AppSettings.Settings[key].Value = val.ToString();
                config.Save();
            }
            catch (Exception)
            {
                MessageBox.Show("Error saving the app setting, app.config may be corrupted.", "GMare", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

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
                    App.SavePath = form.FileName;
                    file = form.FileName;
                }
            }

            // Set file version
            Room.Version = Application.ProductVersion;

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

                        return;
                    }
                }
            }

            // If a room already exists, dispose of it
            if (Room != null)
                Room.Dispose();

            // Create a new stream reader, read in standard xml project file
            using (StreamReader sr = new StreamReader(file))
            {
                XmlSerializer reader = new XmlSerializer(typeof(GMareRoom));
                Room = (GMareRoom)reader.Deserialize(sr);
            }

            // If the room was not loaded successfully, inform the user
            if (Room == null)
            {
                MessageBox.Show("There was a problem loading the project data. The file may be invalid or corrupt.", "GMare", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            // Remove default background
            Room.Backgrounds.RemoveAt(0);

            // Correct values for earlier versions
            CorrectValues(Room);

            // Set edit room and save path, update the UI
            App.SavePath = file;
        }

        /// <summary>
        /// Gets a GMare room from a project file
        /// </summary>
        /// <param name="file">The path to the GMare project file</param>
        /// <returns>A GMare room</returns>
        public static GMareRoom GetProject(string file)
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
                MessageBox.Show("There was a problem loading the project data. The file may be invalid or corrupt.", "GMare", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return null;
            }

            // Remove default background
            room.Backgrounds.RemoveAt(0);

            // Correct values for earlier versions
            CorrectValues(room);

            // Return the opened room
            return room;
        }

        /// <summary>
        /// Gets data from a Game Maker project file
        /// </summary>
        /// <param name="file">The path to the Game Maker project file</param>
        /// <returns>A GM project</returns>
        public static GMProject GetGMProject(string file)
        {
            // Read in the selected GM project file and show progress of read
            using (ProjectIOForm form = new ProjectIOForm(file, true))
            {
                form.ShowDialog();
                return form.GMProject;
            }
        }

        /// <summary>
        /// Gets objects
        /// </summary>
        /// <param name="file">The path to the Game Maker project file</param>
        public static bool GetObjects(string file)
        {
            // Create a new Game Maker project form
            using (ProjectIOForm form = new ProjectIOForm(file, true))
            {
                // Show the form
                form.ShowDialog();

                // If the project is empty, return
                if (form.GMProject == null || form.GMProject.ProjectTree == null || form.GMProject.ProjectTree.Nodes == null)
                    return false;

                // The object node index
                int objectIndex = -1;

                // Get the object node
                for (int i = 0; i < form.GMProject.ProjectTree.Nodes.Length; i++)
                    if (form.GMProject.ProjectTree.Nodes[i].ResourceType == GMResourceType.Objects)
                        objectIndex = i;

                // If no object node was found, return
                if (objectIndex == -1)
                    return false;

                // Check instances for differences
                CheckInstances(form.GMProject);

                // Clear previous objects if any
                App.Room.Objects.Clear();

                // Iterate through project objects
                foreach (GMObject resource in form.GMProject.Objects)
                {
                    // GMare object variables
                    int originX = 0;
                    int originY = 0;
                    Bitmap image = null;

                    // Get the sprite object
                    GMSprite sprite = form.GMProject.Sprites.Find(i => i.Id == resource.SpriteId);

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
                            App.Room.Objects.Add(new GMareObject(resource, image, resource.SpriteId, resource.Depth, originX, originY));
                            continue;
                        }

                        image = GameMaker.Common.GMUtilities.GetBitmap(sprite.SubImages[0]);

                        // Set transparency if needed
                        if (sprite.Transparent && sprite.SubImages[0].Compressed)
                            image.MakeTransparent(image.GetPixel(0, image.Height - 1));
                    }

                    // Add new gmare object
                    App.Room.Objects.Add(new GMareObject(resource, image, resource.SpriteId, resource.Depth, originX, originY));
                }

                // Get the object nodes
                App.Room.Nodes = form.GMProject.ProjectTree.Nodes[objectIndex].Nodes;

                // Set textures for loaded objects
                SetTextures();
                return true;
            }
        }

        /// <summary>
        /// Set textures for loaded objects
        /// </summary>
        public static void SetTextures()
        {
            // Delete all previous textures if any
            Graphics.GraphicsManager.DeleteTextures();

            // If a room was not loaded, return
            if (App.Room == null)
                return;

            // Iterate though new objects, add sprite texture
            foreach (GMareObject obj in App.Room.Objects)
                Graphics.GraphicsManager.LoadTexture(obj.Image, obj.Resource.Id);
        }

        /// <summary>
        /// Checks existing instances against newly imported objects
        /// </summary>
        /// <param name="project">The Game Maker project to check against</param>
        private static void CheckInstances(GMProject project)
        {
            // If no instances exist, return
            if (App.Room.Instances.Count == 0)
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
            foreach (GMareInstance instance in App.Room.Instances)
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
                    Bitmap glyph = App.Room.Objects.Find(o => o.Resource.Id == instance.ObjectId).Image.ToBitmap();

                    // Give the user a choice of either replacing the instance's parent object id, or just delete them
                    using (InstanceConflictForm form = new InstanceConflictForm(nodes.ToArray(), instance.ObjectName, images.ToArray(), glyph))
                    {
                        // Show the instance options form
                        form.ShowDialog();

                        // Set resource as one that has been checked
                        ids.Add(instance.ObjectId, form.Object);

                        // Iterate through blocks
                        foreach (GMareInstance block in App.Room.Blocks)
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
            App.Room.Instances.RemoveAll(i => i.ObjectId == -1);
            App.Room.Blocks.RemoveAll(b => b.ObjectId == -1);
        }

        /// <summary>
        /// Checks to see if the given version is older or newer than the current one
        /// </summary>
        /// <param name="target">The version to check</param>
        /// <param name="source">The version that is the source</param>
        /// <returns>The result of the version comparison</returns>
        private static VersionResultType VersionCompare(string target, string source)
        {
            try
            {
                // Compare versions
                Version version1 = new Version(target);
                Version version2 = new Version(source);
                int result = version1.CompareTo(version2);

                // Return the result
                if (result > 0)
                    return VersionResultType.Greater;
                else if (result < 0)
                    return VersionResultType.Less;
                else
                    return VersionResultType.Equal;
            }
            catch
            {
                return VersionResultType.Less;
            }
        }

        /// <summary>
        /// Corrects previous version values if necessary
        /// </summary>
        public static void CorrectValues(GMareRoom room)
        {
            // If the room is empty return
            if (room == null)
                return;

            // Correct values for versions under 1.0.0.14
            if (VersionCompare(room.Version, "1.0.0.14") == VersionResultType.Less)
            {
                // Set instance color blend to white
                foreach (GMareInstance instance in room.Instances)
                    instance.UBlendColor = 4294967295;

                // Set width and height based on old column and row values
                room.Width = room.Backgrounds.Count == 0 ? 16 : room.Columns * room.Backgrounds[0].TileWidth;
                room.Height = room.Backgrounds.Count == 0 ? 16 : room.Rows * room.Backgrounds[0].TileHeight;
            }
        }

        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);

        public struct IconInfo
        {
            public bool fIcon;
            public int xHotspot;
            public int yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }

        public static Cursor CreateCursor(Bitmap bmp, int xHotSpot, int yHotSpot)
        {
            try
            {
                IconInfo tmp = new IconInfo();
                GetIconInfo(bmp.GetHicon(), ref tmp);
                tmp.xHotspot = xHotSpot;
                tmp.yHotspot = yHotSpot;
                tmp.fIcon = false;
                return new Cursor(CreateIconIndirect(ref tmp));
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }
}
