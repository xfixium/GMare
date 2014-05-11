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
        private int _width = 0;
        private int _height = 0;
        private int _tileWidth = 16;
        private int _tileHeight = 16;
        private int _horizontalOffset = 0;
        private int _verticalOffset = 0;
        private int _horizontalSeperation = 0;
        private int _verticalSeperation = 0;
        private int _textureGroup = 0;
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

        public int TextureGroup
        {
            get { return _textureGroup; }
            set { _textureGroup = value; }
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

        /// <summary>
        /// Reads all backgrounds from a background XML file
        /// </summary>
        /// <param name="file">The XML (.GMX) file path</param>
        /// <returns>A GM background</returns>
        public static GMList<GMBackground> ReadBackgroundGMX(string directory, List<string> assets)
        {
            // A list of backgrounds
            GMList<GMBackground> backgrounds = new GMList<GMBackground>();

            // Iterate through .gmx files in the directory
            foreach (string file in Directory.GetFiles(directory, "*.gmx"))
            {
                // Set name of the background
                string name = GMFileReader.GetResourceName(file);

                // If the file is not in the asset list, it has been orphaned, continue
                if (!assets.Contains(name))
                    continue;

                // Create a dictionary of room properties
                Dictionary<GMXBackgroundProperty, string> properties = new Dictionary<GMXBackgroundProperty, string>();

                foreach (GMXBackgroundProperty property in Enum.GetValues(typeof(GMXBackgroundProperty)))
                    properties.Add(property, "");

                // Background image
                GMImage image = null;

                // Create an XMLReader to read in the resource elements
                using (XmlReader xmlReader = XmlReader.Create(file))
                {
                    // Move to a content node
                    xmlReader.MoveToContent();

                    // Read XML file
                    while (xmlReader.Read())
                    {
                        // If the node is not an element, continue
                        if (xmlReader.NodeType != XmlNodeType.Element)
                            continue;

                        // Get the element name
                        string nodeName = xmlReader.Name;

                        // Read element
                        xmlReader.Read();

                        // If the element value is null or empty, continue
                        if (String.IsNullOrEmpty(xmlReader.Value))
                            continue;

                        // If the element is a frame element create subimage, else normal property
                        if (nodeName.ToLower() == EnumString.GetEnumString(GMXBackgroundProperty.Data).ToLower())
                        {
                            // Create an image and set the image path
                            image = new GMImage();
                            image.Compressed = false;
                            image.ImagePath = directory + "\\" + xmlReader.Value;
                            image.Data = GMUtilities.LoadBytesFromBitmap(image.ImagePath);
                        }
                        else
                        {
                            // Get the enumeration based on the node name
                            GMXBackgroundProperty? property = EnumString.GetEnumFromString<GMXBackgroundProperty>(nodeName);

                            // If no match was found, continue
                            if (property == null)
                                continue;

                            // Set the property value
                            properties[(GMXBackgroundProperty)property] = xmlReader.Value;
                        }
                    }
                }

                // Create a new background and set its properties
                GMBackground background = new GMBackground();
                background.Id = GMResource.GetIdFromName(name);
                background.Name = name;
                background.UseAsTileSet = GMFileReader.ReadGMXBool(properties[GMXBackgroundProperty.IsTileset]);
                background.TileWidth = GMFileReader.ReadGMXInt(properties[GMXBackgroundProperty.TileWidth]);
                background.TileHeight = GMFileReader.ReadGMXInt(properties[GMXBackgroundProperty.TileHeight]);
                background.HorizontalOffset = GMFileReader.ReadGMXInt(properties[GMXBackgroundProperty.TileXOff]);
                background.VerticalOffset = GMFileReader.ReadGMXInt(properties[GMXBackgroundProperty.TileYOff]);
                background.HorizontalSeperation = GMFileReader.ReadGMXInt(properties[GMXBackgroundProperty.TileHSep]);
                background.VerticalSeperation = GMFileReader.ReadGMXInt(properties[GMXBackgroundProperty.TileVSep]);
                background.TileHorizontally = GMFileReader.ReadGMXBool(properties[GMXBackgroundProperty.HTile]);
                background.TileVertically = GMFileReader.ReadGMXBool(properties[GMXBackgroundProperty.VTile]);
                background.TextureGroup = GMFileReader.ReadGMXInt(properties[GMXBackgroundProperty.TextureGroup0]);
                background.UsedFor3D = GMFileReader.ReadGMXBool(properties[GMXBackgroundProperty.For3D]);
                background.Width = GMFileReader.ReadGMXInt(properties[GMXBackgroundProperty.Width]);
                background.Height = GMFileReader.ReadGMXInt(properties[GMXBackgroundProperty.Height]);
                image.Width = background.Width;
                image.Height = background.Height;
                background.Image = image;
                
                // Add the background
                backgrounds.Add(background);
            }

            // Return the list of backgrounds
            return backgrounds;
        }

        #endregion
    }
}
