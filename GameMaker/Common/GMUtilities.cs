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
using System.Drawing.Imaging;
using ICSharpCode.SharpZipLib.Zip.Compression;
using GameMaker.Project;
using GameMaker.Resource;

namespace GameMaker.Common
{
    /// <summary>
    /// Easy to use static methods usually to convert one data type to a .net data type and vice versa.
    /// </summary>
    public static class GMUtilities
    {
        #region Fields

        // 12_26_2010: All this down below seems ridiculous. :/
        // If it ain't broke then don't try and fix it.
        public static string ImageKeyGroup = "";
        public static string ImageKeyGroupSelected = "";
        public static string ImageKeySprite = "";
        public static string ImageKeySpriteSelected = "";
        public static string ImageKeySound = "";
        public static string ImageKeySoundSelected = "";
        public static string ImageKeyBackground = "";
        public static string ImageKeyBackgroundSelected = "";
        public static string ImageKeyPath = "";
        public static string ImageKeyPathSelected = "";
        public static string ImageKeyScript = "";
        public static string ImageKeyScriptSelected = "";
        public static string ImageKeyFont = "";
        public static string ImageKeyFontSelected = "";
        public static string ImageKeyDataFile = "";
        public static string ImageKeyDataFileSelected = "";
        public static string ImageKeyTimeline = "";
        public static string ImageKeyTimelineSelected = "";
        public static string ImageKeyObject = "";
        public static string ImageKeyObjectSelected = "";
        public static string ImageKeyRoom = "";
        public static string ImageKeyRoomSelected = "";
        public static string ImageKeyGameInfo = "";
        public static string ImageKeyGameInfoSelected = "";
        public static string ImageKeySettings = "";
        public static string ImageKeySettingsSelected = "";
        public static string ImageKeyExtensions = "";
        public static string ImageKeyExtensionsSelected = "";

        #endregion

        #region Methods

        #region Project

        /// <summary>
        /// Reads a Game Maker project file. Supports versions 5 through 8.
        /// </summary>
        /// <param name="path">The path where the project should be read from.</param>
        /// <returns>The read Game Maker project.</returns>
        public static GMProject ReadGMProject(string path)
        {
            GMProjectReader reader = new GMProjectReader();
            return reader.ReadProject(path);
        }

        /// <summary>
        /// Writes a Game Maker project to disk.
        /// </summary>
        /// <param name="path">The path where the project should be written to.</param>
        /// <param name="project">The project that is to be written.</param>
        /// <param name="version">The target version for the write.</param>
        public static void WriteGMProject(string path, GMProject project, GMVersionType version)
        {
            GMProjectWriter writer = new GMProjectWriter();
            writer.WriteGMProject(path, project, version);
        }

        #endregion

        #region Color

        /// <summary>
        /// Converts a Game Maker color, to a .net color.
        /// </summary>
        /// <param name="color">The Game Maker color to convert.</param>
        /// <returns>A .net color.</returns>
        public static Color GMColorToColor(int color)
        {
            // Return converted color.
            return Color.FromArgb(color & 0xFF, (color & 0xFF00) >> 8, (color & 0xFF0000) >> 16);
        }

        /// <summary>
        /// Converts a .net color to a Game Maker color.
        /// </summary>
        /// <param name="color">The .net color to convert.</param>
        /// <returns>A game Maker color.</returns>
        public static int ColorToGMColor(Color color)
        {
            // Return a converted Game Maker color.
            return color.R | color.G << 8 | color.B << 16;
        }

        #endregion

        #region Node

        /// <summary>
        /// Gets a .net tree node from a GM node. Stores original GM node data in tag property.
        /// </summary>
        /// <param name="node">The GM node to convert to treenode.</param>
        /// <returns>A tree node version of the GM node.</returns>
        public static TreeNode GetTreeNodeFromGMNode(GMNode node)
        {
            // Set-up tree node.
            TreeNode treeNode = new TreeNode();
            treeNode.Text = node.Name;
            treeNode.Tag = node;

            switch (node.NodeType)
            {
                // If a child node, get appropriate resource key.
                case GMNodeType.Child:
                    switch (node.ResourceType)
                    {
                        case GMResourceType.Rooms: treeNode.ImageKey = ImageKeyRoom; treeNode.SelectedImageKey = ImageKeyRoomSelected; break;
                    }

                    break;

                default: treeNode.ImageKey = ImageKeyGroup; treeNode.SelectedImageKey = ImageKeyGroupSelected; break;
            }

            // If no child nodes, return the top node.
            if (node.Nodes == null)
                return treeNode;

            // Iterate through nodes.
            for (int i = 0; i < node.Children; i++)
            {
                // Set the node.
                treeNode.Nodes.Add(GetTreeNodeFromGMNode(node.Nodes[i]));
            }

            // Return a .net tree node.
            return treeNode;
        }

        /// <summary>
        /// Gets a GMNode from a .net tree node.
        /// </summary>
        /// <param name="treeNode">The tree node to convert.</param>
        /// <returns>A Game Maker node.</returns>
        public static GMNode GetGMNodeFromTreeNode(TreeNode treeNode)
        {
            GMNode tag = new GMNode();

            if (treeNode.Nodes != null)
            {
                tag = treeNode.Tag as GMNode;
                tag.Nodes = new GMNode[treeNode.Nodes.Count];

                for (int i = 0; i < treeNode.Nodes.Count; i++)
                {
                    tag.Nodes[i] = GetGMNodeFromTreeNode(treeNode.Nodes[i]);
                }
            }

            return tag;
        }

        /// <summary>
        /// Gets a .net tree node from a GM node recursively.
        /// </summary>
        /// <param name="treenode">The tree node to convert.</param>
        /// <returns>A Game Maker node.</returns>
        private static GMNode GetGMNodeFromTreeNodeRecursive(TreeNode treeNode)
        {
            return new GMNode();
        }

        #endregion

        #region Graphics

        /// <summary>
        /// Makes a GDI+ bitmap from compressed Game Maker image data.
        /// </summary>
        /// <param name="imageData">The GM image data to convert.</param>
        /// <returns>A GDI+ bitmap.</returns>
        public static Bitmap GetBitmap(GMImage image)
        {
            // If not compressed, get bitmap normally.
            if (image.Compressed == false)
                return PixelDataToBitmap(image.Data, image.Width, image.Height);

            // Create new inflater.
            Inflater inflater = new Inflater();

            // Image buffer.
            byte[] result = new byte[image.Data.Length];

            // Set inflater input byte data.
            inflater.SetInput(image.Data, 0, image.Data.Length);

            // Using memory stream.
            using (MemoryStream ms = new MemoryStream())
            {
                // While the decompressor is not finished.
                while (!inflater.IsFinished)
                {
                    // Get length of data.
                    int length = inflater.Inflate(result);

                    // Write data result to byte array.
                    ms.Write(result, 0, length);
                }

                // Reset position.
                ms.Position = 0;

                // Get bitmap from screen
                Bitmap bitmap = (Bitmap)Bitmap.FromStream(ms);

                // Create a backbuffer image to convert the bitmap for the screen
                System.Drawing.Graphics gfx = System.Drawing.Graphics.FromHwnd(IntPtr.Zero);
                Bitmap buffer = new Bitmap(bitmap.Width, bitmap.Height, gfx);
                gfx.Dispose();

                // Copy original bitmap to new backbuffer
                gfx = System.Drawing.Graphics.FromImage(buffer);
                gfx.DrawImageUnscaled(bitmap, new Point(0, 0));
                gfx.Dispose();

                // Return bitmap
                return buffer;
            }
        }

        /// <summary>
        /// Converts pixel data to a bitmap. Only supports internal standard 32bppPArgb.
        /// </summary>
        /// <returns>A GDI+ bitmap.</returns>
        private static Bitmap PixelDataToBitmap(byte[] pixels, int width, int height)
        {
            int i = 0;

            // Create new GDI+ bitmap with no alpha values. 
            Bitmap image = new Bitmap(width, height, PixelFormat.Format32bppPArgb);

            // Lock the bitmap for writing.
            BitmapData data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);

            // Begin image write.
            unsafe
            {
                // Get stride offset.
                int offset = data.Stride - data.Width * 4;

                // Get pointer to pixel data.
                byte* imgPtr = (byte*)(void*)(data.Scan0);

                // Iterate through vertical pixels.
                for (int y = 0; y < data.Height; ++y)
                {
                    // Iterate through horizontal pixels.
                    for (int x = 0; x < data.Width; ++x)
                    {
                        // Set bitmap pixel.
                        imgPtr[0] = pixels[i];
                        imgPtr[1] = pixels[i + 1];
                        imgPtr[2] = pixels[i + 2];
                        imgPtr[3] = pixels[i + 3];

                        // Increment the image pointer.
                        imgPtr += 4;
                        i += 4;
                    }

                    // Offset image pointer.
                    imgPtr += offset;
                }
            }

            // Unlock the bitmap.
            image.UnlockBits(data);

            // Return the GDI+ version of the image resource.
            return image;
        }

        /// <summary>
        /// Makes a GDI+ icon from compressed Game Maker image data.
        /// </summary>
        /// <param name="iconData">The GM image data to convert.</param>
        /// <returns> GDI+ icon image.</returns>
        public static Icon GetIcon(byte[] iconData)
        {
            // Read icon data.
            byte[] data = iconData;

            // Using memory stream.
            using (MemoryStream ms = new MemoryStream())
            {
                // Send data to buffer.
                ms.Write(data, 0, data.Length);

                // Reset stream position.
                ms.Position = 0;

                // Return icon.
                return new Icon(ms);
            }
        }

        #endregion

        #endregion
    }
}