#region MIT

// 
// GMLib.
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
using System.Drawing.Imaging;
using System.Collections.Generic;
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
        public static TreeNode GetTreeNodeFromGMNode(GMProject project, GMNode node, List<Image> images)
        {
            // Set-up tree node.
            TreeNode treeNode = new TreeNode();
            treeNode.Text = node.Name;
            treeNode.Tag = node;

            // If the list does not have the folder graphics, add them.
            if (images != null && images.Count < 2)
            {
                images.Add((Image)GMare.Properties.Resources.file_close.Clone());
                images.Add((Image)GMare.Properties.Resources.file_open.Clone());
                images.Add((Image)GMare.Properties.Resources.instance.Clone());
            }

            switch (node.NodeType)
            {
                // If a child node, get appropriate resource key.
                case GMNodeType.Child:

                    // Do action based on object type.
                    switch (node.ResourceType)
                    {
                        // Sprites.
                        case GMResourceType.Sprites:

                            // If no images to load, break.
                            if (images == null)
                                break;

                            // Get sprite.
                            GMSprite sprite = project.Sprites.Find(delegate(GMSprite s) { return s.Id == node.Id; });
                            
                            // If a sprite was found.
                            if (sprite != null)
                            {
                                // Get image.
                                Bitmap image = GMUtilities.GetBitmap(sprite.SubImages[0]);

                                // Set transparency if needed.
                                if (sprite.Transparent && sprite.SubImages[0].Compressed)
                                    image.MakeTransparent(image.GetPixel(0, image.Height - 1));

                                images.Add(image);
                                treeNode.ImageIndex = images.Count - 1;
                                treeNode.SelectedImageIndex = images.Count - 1;
                            }
                            else
                            {
                                treeNode.ImageIndex = 2;
                                treeNode.SelectedImageIndex = 2;
                            }

                            break;

                        // Objects.
                        case GMResourceType.Objects:

                            // If no images to load, break.
                            if (images == null)
                                break;

                            // Get the object id, use it to get the sprite id.
                            GMObject obj = project.Objects.Find(delegate(GMObject o) { return o.Id == node.Id; });
                            GMSprite spt = project.Sprites.Find(delegate(GMSprite s) { return s.Id == obj.SpriteId; });

                            // If a sprite was found.
                            if (spt != null && spt.SubImages != null && spt.SubImages.Length > 0)
                            {
                                // Get image.
                                Bitmap image = GMUtilities.GetBitmap(spt.SubImages[0]);

                                // Set transparency if needed.
                                if (spt.Transparent && spt.SubImages[0].Compressed)
                                    image.MakeTransparent(image.GetPixel(0, image.Height - 1));

                                images.Add(image);
                                treeNode.ImageIndex = images.Count - 1;
                                treeNode.SelectedImageIndex = images.Count - 1;
                            }
                            else
                            {
                                treeNode.ImageIndex = 2;
                                treeNode.SelectedImageIndex = 2;
                            }

                            break;

                        // Rooms.
                        case GMResourceType.Rooms:
                            treeNode.ImageKey = ImageKeyRoom;
                            treeNode.SelectedImageKey = ImageKeyRoomSelected;
                            break;
                    }

                    break;

                // Folders or parents.
                default:
                    treeNode.ImageIndex = 0;
                    treeNode.SelectedImageIndex = 1;
                    treeNode.ImageKey = ImageKeyGroup;
                    treeNode.SelectedImageKey = ImageKeyGroupSelected;
                    break;
            }

            // If no child nodes, return the top node.
            if (node.Nodes == null)
                return treeNode;

            // Iterate through nodes.
            for (int i = 0; i < node.Children; i++)
            {
                // Set the node.
                treeNode.Nodes.Add(GetTreeNodeFromGMNode(project, node.Nodes[i], images));
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

        #endregion

        #region Graphics

        /// <summary>
        /// Loads a bitmap from file and converts it to a byte array
        /// </summary>
        /// <param name="file">The path to the image file</param>
        /// <returns>A byte array</returns>
        public static byte[] LoadBytesFromBitmap(string file)
        {
            // If the file does not exist, return null
            if (!File.Exists(file))
                return null;

            // Create a file stream to read in the bitmap
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                // Get a bitmap from disk
                Bitmap image = (Bitmap)Image.FromStream(fs);
                return GetPixels(image, new Rectangle(0, 0, image.Width, image.Height));
            }
        }

        /// <summary>
        /// Makes a GDI+ bitmap from compressed Game Maker image data.
        /// </summary>
        /// <param name="imageData">The GM image data to convert.</param>
        /// <returns>A GDI+ bitmap.</returns>
        public static Bitmap GetBitmap(GMImage image)
        {
            // If not compressed, get bitmap normally
            if (image.Compressed == false)
                return PixelDataToBitmap(image.Data, image.Width, image.Height);

            // Create new inflater
            Inflater inflater = new Inflater();

            // Image buffer
            byte[] result = new byte[image.Data.Length];

            // Set inflater input byte data
            inflater.SetInput(image.Data, 0, image.Data.Length);

            // Using memory stream
            using (MemoryStream ms = new MemoryStream())
            {
                // While the decompressor is not finished
                while (!inflater.IsFinished)
                {
                    // Get length of data
                    int length = inflater.Inflate(result);

                    // Write data result to byte array
                    ms.Write(result, 0, length);
                }

                // Reset position
                ms.Position = 0;

                // Get bitmap from stream
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

            // Create new GDI+ bitmap
            Bitmap image = new Bitmap(width, height, PixelFormat.Format32bppPArgb);

            // Lock the bitmap for writing
            BitmapData data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);

            // Begin image write
            unsafe
            {
                // Get stride offset
                int offset = data.Stride - data.Width * 4;

                // Get pointer to pixel data
                byte* imgPtr = (byte*)(void*)(data.Scan0);

                // Iterate through vertical pixels
                for (int y = 0; y < data.Height; ++y)
                {
                    // Iterate through horizontal pixels
                    for (int x = 0; x < data.Width; ++x)
                    {
                        // Set bitmap pixel
                        imgPtr[0] = pixels[i];
                        imgPtr[1] = pixels[i + 1];
                        imgPtr[2] = pixels[i + 2];
                        imgPtr[3] = pixels[i + 3];

                        // Increment the image pointer
                        imgPtr += 4;
                        i += 4;
                    }

                    // Offset image pointer
                    imgPtr += offset;
                }
            }

            // Unlock the bitmap
            image.UnlockBits(data);

            // Return the GDI+ version of the image resource
            return image;
        }

        public static byte[] GetPixels(Bitmap image, Rectangle rect)
        {
            // Pallet data
            Color[] pallet = null;

            // The pixel bits
            int bits = 4;

            // Check pixel format
            switch (image.PixelFormat)
            {
                case PixelFormat.Format8bppIndexed: bits = 1; pallet = image.Palette.Entries; break;
                case PixelFormat.Format24bppRgb: bits = 3; break;
                case PixelFormat.Format32bppArgb:
                case PixelFormat.Format32bppPArgb: bits = 4; break;
                default: throw new Exception(image.PixelFormat.ToString());
            }

            int i = 0;

            // Create a new array of pixels
            byte[] pixels = new byte[(rect.Width * rect.Height) * 4];

            // Lock the bitmap for writing
            BitmapData data = image.LockBits(rect, ImageLockMode.ReadOnly, image.PixelFormat);

            // Begin image read
            unsafe
            {
                // Get stride offset
                int offset = data.Stride - data.Width * bits;

                // Get pointer to pixel data
                byte* imgPtr = (byte*)(void*)(data.Scan0);

                // Iterate through vertical pixels
                for (int y = 0; y < data.Height; ++y)
                {
                    // Iterate through horizontal pixels
                    for (int x = 0; x < data.Width; ++x)
                    {
                        byte[] pixel = new byte[4];

                        if (bits == 3) // 24bit, get rgb data, alpha is defaulted to 255
                        {
                            pixel[0] = 255;
                            pixel[1] = imgPtr[0];
                            pixel[2] = imgPtr[1];
                            pixel[3] = imgPtr[2];
                        }
                        else if (bits == 4) // 32bit, get argb data
                        {
                            pixel[0] = imgPtr[0];
                            pixel[1] = imgPtr[1];
                            pixel[2] = imgPtr[2];
                            pixel[3] = imgPtr[3];
                        }
                        else if (bits == 1)  // 8bit, indexed colors
                        {
                            int index = imgPtr[0];
                            Color color = pallet[index];

                            pixel[0] = 255;
                            pixel[1] = color.B;
                            pixel[2] = color.G;
                            pixel[3] = color.R;
                        }

                        // Set bitmap pixel
                        pixels[i] = pixel[0];
                        pixels[i + 1] = pixel[1];
                        pixels[i + 2] = pixel[2];
                        pixels[i + 3] = pixel[3];

                        i += 4;

                        // Increment the image pointer
                        imgPtr += bits;
                    }

                    // Offset image pointer
                    imgPtr += offset;
                }
            }

            // Unlock the bitmap
            image.UnlockBits(data);

            // Return the read pixels
            return pixels;
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