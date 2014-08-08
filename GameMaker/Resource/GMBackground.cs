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
using System.Xml;
using System.Collections.Generic;
using GameMaker.Common;

namespace GameMaker.Resource
{
    [Serializable]
    public class GMBackground : GMResource
    {
        #region Fields

        private GMImage _image = null;
        private int[] _textureGroups = null;
        private int _width = 0;
        private int _height = 0;
        private int _tileWidth = 16;
        private int _tileHeight = 16;
        private int _horizontalOffset = 0;
        private int _verticalOffset = 0;
        private int _horizontalSeperation = 0;
        private int _verticalSeperation = 0;
        private bool _tileHorizontally = false;
        private bool _tileVertically = false;
        private bool _transparent = false;
        private bool _smoothEdges = false;
        private bool _preload = false;
        private bool _useAsTileSet = false;
        private bool _useVideoMemory = true;
        private bool _loadOnlyOnUse = true;
        private bool _usedFor3D = false;

        #endregion

        #region Properties

        public GMImage Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public int[] TextureGroups
        {
            get { return _textureGroups; }
            set { _textureGroups = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public int TileWidth
        {
            get { return _tileWidth; }
            set { _tileWidth = value; }
        }

        public int TileHeight
        {
            get { return _tileHeight; }
            set { _tileHeight = value; }
        }

        public int HorizontalOffset
        {
            get { return _horizontalOffset; }
            set { _horizontalOffset = value; }
        }

        public int VerticalOffset
        {
            get { return _verticalOffset; }
            set { _verticalOffset = value; }
        }

        public int HorizontalSeperation
        {
            get { return _horizontalSeperation; }
            set { _horizontalSeperation = value; }
        }

        public int VerticalSeperation
        {
            get { return _verticalSeperation; }
            set { _verticalSeperation = value; }
        }

        public bool TileHorizontally
        {
            get { return _tileHorizontally; }
            set { _tileHorizontally = value; }
        }

        public bool TileVertically
        {
            get { return _tileVertically; }
            set { _tileVertically = value; }
        }

        public bool Transparent
        {
            get { return _transparent; }
            set { _transparent = value; }
        }

        public bool SmoothEdges
        {
            get { return _smoothEdges; }
            set { _smoothEdges = value; }
        }

        public bool Preload
        {
            get { return _preload; }
            set { _preload = value; }
        }

        public bool UseAsTileSet
        {
            get { return _useAsTileSet; }
            set { _useAsTileSet = value; }
        }

        public bool UseVideoMemory
        {
            get { return _useVideoMemory; }
            set { _useVideoMemory = value; }
        }

        public bool LoadOnlyOnUse
        {
            get { return _loadOnlyOnUse; }
            set { _loadOnlyOnUse = value; }
        }

        public bool UsedFor3D
        {
            get { return _usedFor3D; }
            set { _usedFor3D = value; }
        }

        #endregion

        #region Methods

        #region Read

        #region Game Maker Studio

        /// <summary>
        /// Reads all backgrounds from a background XML file
        /// </summary>
        /// <param name="directory">The XML (.GMX) file path</param>
        /// <param name="assets">A list of assets listed in the project GMX</param>
        /// <returns>A GM background</returns>
        public static GMList<GMBackground> ReadBackgroundsGMX(string directory, ref List<string> assets)
        {
            // A list of backgrounds
            GMList<GMBackground> backgrounds = new GMList<GMBackground>();
            backgrounds.AutoIncrementIds = false;

            // Iterate through .gmx files in the directory
            foreach (string file in Directory.GetFiles(directory, "*.gmx"))
            {
                // Set name of the background
                string name = GetResourceName(file);

                // If the file is not in the asset list, it has been orphaned, continue
                if (!assets.Contains(name))
                    continue;

                // Create a dictionary of room properties
                Dictionary<string, string> properties = new Dictionary<string, string>();
                foreach (GMXBackgroundProperty property in Enum.GetValues(typeof(GMXBackgroundProperty)))
                    properties.Add(GMXEnumString(property), "");

                // Background image and texture group strings
                GMImage image = null;
                string textureGroup = GMXEnumString(GMXBackgroundProperty.TextureGroup);
                string textureGroup0 = GMXEnumString(GMXBackgroundProperty.TextureGroup0);

                // Create an XMLReader to read in the resource elements
                using (XmlReader reader = XmlReader.Create(file))
                {
                    // Move to a content node
                    reader.MoveToContent();

                    // Read XML file
                    while (reader.Read())
                    {
                        // If the node is not an element, continue
                        if (reader.NodeType != XmlNodeType.Element)
                            continue;

                        // Get the element name
                        string nodeName = reader.Name;

                        // Read 
                        reader.Read();

                        // If the element value is null or empty, continue
                        if (string.IsNullOrEmpty(reader.Value))
                            continue;

                        // If the element is a frame element create subimage, else normal property
                        if (nodeName.ToLower() == GMXEnumString(GMXBackgroundProperty.Data))
                        {
                            // Create an image and set the image path
                            image = new GMImage();
                            image.Compressed = false;
                            image.FilePath = reader.Value;
                            image.Data = GMUtilities.LoadBytesFromBitmap(directory + "\\" + image.FilePath);
                        }
                        else
                        {
                            // Set the property value
                            properties[nodeName] = reader.Value;
                        }
                    }
                }

                // Create a new background and set its properties
                GMBackground background = new GMBackground();
                background.Id = GetIdFromName(name);
                background.Name = name;
                background.UseAsTileSet = GMXBool(properties[GMXEnumString(GMXBackgroundProperty.IsTileset)], background.UseAsTileSet);
                background.TileWidth = GMXInt(properties[GMXEnumString(GMXBackgroundProperty.TileWidth)], background.TileWidth);
                background.TileHeight = GMXInt(properties[GMXEnumString(GMXBackgroundProperty.TileHeight)], background.TileHeight);
                background.HorizontalOffset = GMXInt(properties[GMXEnumString(GMXBackgroundProperty.TileXOff)], background.HorizontalOffset);
                background.VerticalOffset = GMXInt(properties[GMXEnumString(GMXBackgroundProperty.TileYOff)], background.VerticalOffset);
                background.HorizontalSeperation = GMXInt(properties[GMXEnumString(GMXBackgroundProperty.TileHSep)], background.HorizontalSeperation);
                background.VerticalSeperation = GMXInt(properties[GMXEnumString(GMXBackgroundProperty.TileVSep)], background.VerticalSeperation);
                background.TileHorizontally = GMXBool(properties[GMXEnumString(GMXBackgroundProperty.HTile)], background.TileHorizontally);
                background.TileVertically = GMXBool(properties[GMXEnumString(GMXBackgroundProperty.VTile)], background.TileVertically);
                background.UsedFor3D = GMXBool(properties[GMXEnumString(GMXBackgroundProperty.For3D)], background.UsedFor3D);
                background.Width = GMXInt(properties[GMXEnumString(GMXBackgroundProperty.Width)], background.Width);
                background.Height = GMXInt(properties[GMXEnumString(GMXBackgroundProperty.Height)], background.Height);
                properties[textureGroup] = properties[textureGroup] == "" ? "0" : properties[textureGroup];
                properties[textureGroup0] = properties[textureGroup0] == "" ? "0" : properties[textureGroup0];
                image.Width = background.Width;
                image.Height = background.Height;
                background.Image = image;

                // The texture group does not equal zero set texture group 0 to the texture group value
                if (properties[textureGroup] != "0")
                    properties[textureGroup0] = properties[textureGroup];
                // The texture group zero does not equal zero set texture group to the texture group 0 value
                else if (properties[textureGroup0] != "0")
                    properties[textureGroup] = properties[textureGroup0];

                // Create a list of texture groups
                List<int> textureGroups = new List<int>();
                for (int i = 0; properties.ContainsKey(string.Concat(textureGroup, i)); i++)
                    textureGroups.Add(Convert.ToInt32(properties[string.Concat(textureGroup, i)]));

                background.TextureGroups = textureGroups.ToArray();

                // Add the background
                backgrounds.Add(background);
            }

            // Return the list of backgrounds
            return backgrounds;
        }

        #endregion

        #region Game Maker 5 - 8.1

        /// <summary>
        /// Reads all backgrounds from a GM file reader
        /// </summary>
        public static GMList<GMBackground> ReadBackgrounds(GMFileReader reader)
        {
            // Get version
            int version = reader.ReadGMInt();

            // Check version
            if (version != 400 && version != 800)
                throw new Exception("Unsupported Pre-Background object version.");

            // Create a new list of backgrounds
            GMList<GMBackground> backgrounds = new GMList<GMBackground>();

            // Amount of background ids
            int num = reader.ReadGMInt();

            // Iterate through backgrounds
            for (int i = 0; i < num; i++)
            {
                // If version is 8.0, start inflate
                if (version == 800)
                    reader.Decompress();

                // If the background at index does not exists, continue
                if (reader.ReadGMBool() == false)
                {
                    backgrounds.LastId++;
                    reader.EndDecompress();
                    continue;
                }

                // Create a new background object
                GMBackground background = new GMBackground();

                // Set background id
                background.Id = i;

                // Get background data
                background.Name = reader.ReadGMString();

                // If version is 8.0, get last changed
                if (version == 800)
                    background.LastChanged = reader.ReadGMDouble();

                // Get version
                version = reader.ReadGMInt();

                // Check version
                if (version != 400 && version != 543 && version != 710)
                    throw new Exception("Unsupported Background object version.");

                // If version is less than 7.1
                if (version < 710)
                {
                    // Background data
                    background.Width = reader.ReadGMInt();
                    background.Height = reader.ReadGMInt();
                    background.Transparent = reader.ReadGMBool();

                    // Check version
                    if (version > 400)
                    {
                        // Read background data
                        background.SmoothEdges = reader.ReadGMBool();
                        background.Preload = reader.ReadGMBool();
                        background.UseAsTileSet = reader.ReadGMBool();
                        background.TileWidth = reader.ReadGMInt();
                        background.TileHeight = reader.ReadGMInt();
                        background.HorizontalOffset = reader.ReadGMInt();
                        background.VerticalOffset = reader.ReadGMInt();
                        background.HorizontalSeperation = reader.ReadGMInt();
                        background.VerticalSeperation = reader.ReadGMInt();
                    }
                    else
                    {
                        // Read background data
                        background.UseVideoMemory = reader.ReadGMBool();
                        background.LoadOnlyOnUse = reader.ReadGMBool();
                    }

                    // If image data exists
                    if (reader.ReadGMBool())
                    {
                        // If pixel data does not exist
                        if (reader.ReadGMInt() == -1)
                            continue;

                        // Create a new image
                        GMImage image = new GMImage();

                        // Set image data
                        image.Width = background.Width;
                        image.Height = background.Height;

                        // Get size of image data
                        int size = reader.ReadGMInt();

                        // Get compressed image data
                        image.Data = reader.ReadGMBytes(size);

                        // Set background image
                        background.Image = image;
                    }
                }
                else
                {
                    // Get background data
                    background.UseAsTileSet = reader.ReadGMBool();
                    background.TileWidth = reader.ReadGMInt();
                    background.TileHeight = reader.ReadGMInt();
                    background.HorizontalOffset = reader.ReadGMInt();
                    background.VerticalOffset = reader.ReadGMInt();
                    background.HorizontalSeperation = reader.ReadGMInt();
                    background.VerticalSeperation = reader.ReadGMInt();

                    // Get version
                    version = reader.ReadGMInt();

                    // Check version
                    if (version != 800)
                        throw new Exception("Unsupported Background object version.");

                    // Get image data
                    background.Width = reader.ReadGMInt();
                    background.Height = reader.ReadGMInt();

                    // If the sprite size is not zero
                    if (background.Width != 0 && background.Height != 0)
                    {
                        // Create a new image object
                        GMImage image = new GMImage();
                        image.Compressed = false;

                        // Set image data
                        image.Width = background.Width;
                        image.Height = background.Height;

                        // Get size of image data
                        int size = reader.ReadGMInt();

                        // Get image data
                        image.Data = reader.ReadGMBytes(size);

                        // Insert compressed image data
                        background.Image = image;
                    }
                }

                // End object inflate
                reader.EndDecompress();

                // Add background
                backgrounds.Add(background);
            }

            // Return backgrounds
            return backgrounds;
        }

        #endregion

        #endregion

        #region Write

        /// <summary>
        /// Write a Game Maker GMX formatted background
        /// </summary>
        /// <param name="background">The given background to write</param>
        /// <param name="directory">The room directory</param>
        public static void WriteBackgroundGMX(GMBackground background, string directory)
        {
            // Write a single room
            WriteBackgroundsGMX(new List<GMBackground>() { background }, directory);
        }

        /// <summary>
        /// Writes a list of Game Maker GMX formatted backgrounds
        /// </summary>
        /// <param name="backgrounds">The given backgrounds to write</param>
        /// <param name="directory">The backgrounds directory</param>
        public static void WriteBackgroundsGMX(List<GMBackground> backgrounds, string directory)
        {
            // If the directory does not exist
            if (Directory.Exists(directory))
                throw new Exception("The directory for " + directory + " does not exist. Write failed.");

            // Iterate through rooms
            foreach (GMBackground background in backgrounds)
            {
                // Create a file stream to write the file to
                using (FileStream fs = new FileStream(directory + background.Name + ".gmx", FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        // Create an XML writer for the project nodes
                        using (XmlTextWriter writer = new XmlTextWriter(sw))
                        {
                            // GMX standard header comment
                            writer.WriteComment(GMUtilities.GMXHeaderComment);

                            // Start writing properties
                            writer.WriteStartElement(GMXEnumString(GMXBackgroundProperty.Background));
                            writer.WriteElementString(GMXEnumString(GMXBackgroundProperty.IsTileset), GetGMXBool(background.UseAsTileSet));
                            writer.WriteElementString(GMXEnumString(GMXBackgroundProperty.TileWidth), background.TileWidth.ToString());
                            writer.WriteElementString(GMXEnumString(GMXBackgroundProperty.TileHeight), background.TileHeight.ToString());
                            writer.WriteElementString(GMXEnumString(GMXBackgroundProperty.TileXOff), background.HorizontalOffset.ToString());
                            writer.WriteElementString(GMXEnumString(GMXBackgroundProperty.TileYOff), background.VerticalOffset.ToString());
                            writer.WriteElementString(GMXEnumString(GMXBackgroundProperty.TileHSep), background.HorizontalSeperation.ToString());
                            writer.WriteElementString(GMXEnumString(GMXBackgroundProperty.TileVSep), background.VerticalSeperation.ToString());
                            writer.WriteElementString(GMXEnumString(GMXBackgroundProperty.HTile), background.TileHorizontally.ToString());
                            writer.WriteElementString(GMXEnumString(GMXBackgroundProperty.VTile), background.TileVertically.ToString());

                            // Iterate through texture groups
                            writer.WriteStartElement(GMXEnumString(GMXParallaxProperty.Backgrounds));
                            foreach (int group in background.TextureGroups)
                            {
                                writer.WriteStartElement(GMXEnumString(GMXBackgroundProperty.TextureGroup + group));
                                writer.WriteElementString(GMXEnumString(GMXBackgroundProperty.VTile), group.ToString());
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();

                            // Continue writing properties
                            writer.WriteElementString(GMXEnumString(GMXBackgroundProperty.For3D), background.UsedFor3D.ToString());
                            writer.WriteElementString(GMXEnumString(GMXBackgroundProperty.Width), background.Width.ToString());
                            writer.WriteElementString(GMXEnumString(GMXBackgroundProperty.Height), background.Height.ToString());
                            writer.WriteElementString(GMXEnumString(GMXBackgroundProperty.Data), background.Image.FilePath);
                            writer.WriteEndElement();
                        }
                    }
                }
            }
        }

        #endregion

        #endregion
    }
}