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
    public class GMSprite : GMResource
    {
        #region Fields

        private GMImage[] _subImages = null;
        private int[] _textureGroups = null;
        private int _boundingBoxMode = 0;
        private int _shapeMode = 1;
        private int _width = 32;
        private int _height = 32;
        private int _originX = 0;
        private int _originY = 0;
        private int _boundingBoxLeft = 0;
        private int _boundingBoxRight = 0;
        private int _boundingBoxTop = 0;
        private int _boundingBoxBottom = 0;
        private int _alphaTolerance = 0;
        private bool _tileHorizontally = false;
        private bool _tileVertically = false;
        private bool _transparent = true;
        private bool _precise = true;
        private bool _smoothEdges = false;
        private bool _preload = true;
        private bool _useVideoMemory = true;
        private bool _loadOnlyOnUse = false;
        private bool _useSeperateCollisionMasks = false;
        private bool _usedFor3D = false;

        #endregion

        #region Properties

        public GMImage[] SubImages
        {
            get { return _subImages; }
            set { _subImages = value; }
        }

        public int[] TextureGroups
        {
            get { return _textureGroups; }
            set { _textureGroups = value; }
        }

        public int BoundingBoxMode
        {
            get { return _boundingBoxMode; }
            set { _boundingBoxMode = value; }
        }

        public int ShapeMode
        {
            get { return _shapeMode; }
            set { _shapeMode = value; }
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

        public int OriginX
        {
            get { return _originX; }
            set { _originX = value; }
        }

        public int OriginY
        {
            get { return _originY; }
            set { _originY = value; }
        }

        public int BoundingBoxLeft
        {
            get { return _boundingBoxLeft; }
            set { _boundingBoxLeft = value; }
        }

        public int BoundingBoxRight
        {
            get { return _boundingBoxRight; }
            set { _boundingBoxRight = value; }
        }

        public int BoundingBoxTop
        {
            get { return _boundingBoxTop; }
            set { _boundingBoxTop = value; }
        }

        public int BoundingBoxBottom
        {
            get { return _boundingBoxBottom; }
            set { _boundingBoxBottom = value; }
        }

        public int AlphaTolerance
        {
            get { return _alphaTolerance; }
            set { _alphaTolerance = value; }
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

        public bool Precise
        {
            get { return _precise; }
            set { _precise = value; }
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

        public bool UseSeperateCollisionMasks
        {
            get { return _useSeperateCollisionMasks; }
            set { _useSeperateCollisionMasks = value; }
        }

        public bool UsedFor3D
        {
            get { return _usedFor3D; }
            set { _usedFor3D = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Reads sprites from Game Maker project file.
        /// </summary>
        public static GMList<GMSprite> ReadSpritesGMX(string directory, ref List<string> assets)
        {
            // A list of sprites
            GMList<GMSprite> sprites = new GMList<GMSprite>();
            sprites.AutoIncrementIds = false;

            // Iterate through .gmx files in the directory
            foreach (string file in Directory.GetFiles(directory, "*.gmx"))
            {
                // Set name of the sprite
                string name = GetResourceName(file);

                // If the file is not in the asset list, it has been orphaned, continue
                if (!assets.Contains(name))
                    continue;

                // Create a dictionary of sprite properties 
                Dictionary<string, string> properties = new Dictionary<string, string>();
                foreach (GMXSpriteProperty property in Enum.GetValues(typeof(GMXSpriteProperty)))
                    properties.Add(GMXEnumString(property), "");

                // Local variables and texture group strings
                List<GMImage> subImages = new List<GMImage>();
                string textureGroup = GMXEnumString(GMXSpriteProperty.TextureGroup);
                string textureGroup0 = GMXEnumString(GMXSpriteProperty.TextureGroup0);

                // Create an xml reader
                using (XmlReader reader = XmlReader.Create(file))
                {
                    // Seek to content
                    reader.MoveToContent();

                    // Read the GMX file
                    while (reader.Read())
                    {
                        // If the node is not an element, continue
                        if (reader.NodeType != XmlNodeType.Element)
                            continue;

                        // Get the element name
                        string nodeName = reader.Name;

                        // Read element
                        reader.Read();

                        // If the element value is null or empty, continue
                        if (String.IsNullOrEmpty(reader.Value))
                            continue;

                        // If the element is a frame element create subimage, else normal property
                        if (nodeName.ToLower() == GMXEnumString(GMXSpriteProperty.Frame).ToLower())
                        {
                            // Create a sub image and set the image path
                            GMImage subImage = new GMImage();
                            subImage.Compressed = false;
                            subImage.FilePath = reader.Value;
                            subImage.Data = GMUtilities.LoadBytesFromBitmap(directory + "\\" + subImage.FilePath);
                            subImages.Add(subImage);
                        }
                        else
                        {
                            // Set the property value
                            properties[nodeName] = reader.Value;
                        }
                    }
                }

                // Create a new sprite, set properties
                GMSprite sprite = new GMSprite();
                sprite.Id = GetIdFromName(name);
                sprite.Name = name;
                sprite.OriginX = GMXInt(properties[GMXEnumString(GMXSpriteProperty.XOrigin)], sprite.OriginX);
                sprite.OriginY = GMXInt(properties[GMXEnumString(GMXSpriteProperty.YOrigin)], sprite.OriginY);
                sprite.ShapeMode = GMXInt(properties[GMXEnumString(GMXSpriteProperty.ColKind)], sprite.ShapeMode);
                sprite.AlphaTolerance = GMXInt(properties[GMXEnumString(GMXSpriteProperty.ColTolerance)], sprite.AlphaTolerance);
                sprite.UseSeperateCollisionMasks = GMXBool(properties[GMXEnumString(GMXSpriteProperty.SepMasks)], sprite.UseSeperateCollisionMasks);
                sprite.BoundingBoxMode = GMXInt(properties[GMXEnumString(GMXSpriteProperty.BBoxMode)], sprite.BoundingBoxMode);
                sprite.BoundingBoxLeft = GMXInt(properties[GMXEnumString(GMXSpriteProperty.BBoxLeft)], sprite.BoundingBoxLeft);
                sprite.BoundingBoxRight = GMXInt(properties[GMXEnumString(GMXSpriteProperty.BBoxRight)], sprite.BoundingBoxRight);
                sprite.BoundingBoxTop = GMXInt(properties[GMXEnumString(GMXSpriteProperty.BBoxTop)], sprite.BoundingBoxTop);
                sprite.BoundingBoxBottom = GMXInt(properties[GMXEnumString(GMXSpriteProperty.BBoxBottom)], sprite.BoundingBoxBottom);
                sprite.TileHorizontally = GMXBool(properties[GMXEnumString(GMXSpriteProperty.HTile)], sprite.TileHorizontally);
                sprite.TileVertically = GMXBool(properties[GMXEnumString(GMXSpriteProperty.VTile)], sprite.TileVertically);
                sprite.UsedFor3D = GMXBool(properties[GMXEnumString(GMXSpriteProperty.For3D)], sprite.UsedFor3D);
                sprite.Width = GMXInt(properties[GMXEnumString(GMXSpriteProperty.Width)], sprite.Width);
                sprite.Height = GMXInt(properties[GMXEnumString(GMXSpriteProperty.Height)], sprite.Height);
                properties[textureGroup] = properties[textureGroup] == "" ? "0" : properties[textureGroup];
                properties[textureGroup0] = properties[textureGroup0] == "" ? "0" : properties[textureGroup0];
                
                // The texture group does not equal zero set texture group 0 to the texture group value
                if (properties[textureGroup] != "0")
                    properties[textureGroup0] = properties[textureGroup];
                // The texture group zero does not equal zero set texture group to the texture group 0 value
                else if (properties[textureGroup0] != "0")
                    properties[textureGroup] = properties[textureGroup0];

                // Create a list of texture groups
                List<int> textureGroups = new List<int>();
                for (int i = 0; properties.ContainsKey(textureGroup + i); i++)
                    textureGroups.Add(Convert.ToInt32(properties[textureGroup + i]));

                // Set the subimage size for all subimages
                foreach (GMImage image in subImages)
                {
                    image.Width = sprite.Width;
                    image.Height = sprite.Height;
                }

                sprite.TextureGroups = textureGroups.ToArray();
                sprite.SubImages = subImages.ToArray();

                // Add the sprite
                sprites.Add(sprite);
            }

            // Return the list of sprites
            return sprites;
        }

        /// <summary>
        /// Reads sprites from Game Maker project file.
        /// </summary>
        public static GMList<GMSprite> ReadSprites(GMFileReader reader)
        {
            // Get version
            int version = reader.ReadGMInt();

            // Check version
            if (version != 400 && version != 800)
                throw new Exception("Unsupported Pre-Sprite object version.");

            // Create a new list of sprites
            GMList<GMSprite> sprites = new GMList<GMSprite>();

            // Amount of sprite ids
            int num = reader.ReadGMInt();

            // Iterate through sprites
            for (int i = 0; i < num; i++)
            {
                // If version is 8.0, start inflate
                if (version == 800)
                    reader.Decompress();

                // If the sprite at index does not exists, continue
                if (reader.ReadGMBool() == false)
                {
                    sprites.LastId++;
                    reader.EndDecompress();
                    continue;
                }

                // Create a new sprite object
                GMSprite sprite = new GMSprite();

                // Set sprite id
                sprite.Id = i;

                // Read sprite data
                sprite.Name = reader.ReadGMString();

                // If version is 8.0, get last changed
                if (version == 800)
                    sprite.LastChanged = reader.ReadGMDouble();

                // Get version
                version = reader.ReadGMInt();

                // Check version
                if (version != 400 && version != 542 && version != 800)
                    throw new Exception("Unsupported Sprite object version.");

                // If less than version 8.0
                if (version < 800)
                {
                    // Read sprite data
                    sprite.Width = reader.ReadGMInt();
                    sprite.Height = reader.ReadGMInt();
                    sprite.BoundingBoxLeft = reader.ReadGMInt();
                    sprite.BoundingBoxRight = reader.ReadGMInt();
                    sprite.BoundingBoxBottom = reader.ReadGMInt();
                    sprite.BoundingBoxTop = reader.ReadGMInt();
                    sprite.Transparent = reader.ReadGMBool();

                    // Check version
                    if (version > 400)
                    {
                        // Read sprite data
                        sprite.SmoothEdges = reader.ReadGMBool();
                        sprite.Preload = reader.ReadGMBool();
                    }

                    // Read sprite data
                    sprite.BoundingBoxMode = reader.ReadGMInt();
                    sprite.Precise = reader.ReadGMBool();

                    // Check version
                    if (version == 400)
                    {
                        // Read sprtie data
                        sprite.UseVideoMemory = reader.ReadGMBool();
                        sprite.LoadOnlyOnUse = reader.ReadGMBool();
                    }

                    // Read sprite data
                    sprite.OriginX = reader.ReadGMInt();
                    sprite.OriginY = reader.ReadGMInt();

                    // Sprite number of sub images
                    sprite.SubImages = new GMImage[reader.ReadGMInt()];

                    // Iterate through sub-images
                    for (int j = 0; j < sprite.SubImages.Length; j++)
                    {
                        // If the sub-image at index does not exists, continue
                        if (reader.ReadGMInt() == -1)
                            continue;

                        // Create a new image object
                        GMImage image = new GMImage();

                        // Get size of image data
                        int size = reader.ReadGMInt();

                        // Get image data
                        image.Data = reader.ReadGMBytes(size);

                        // Insert compressed image data
                        sprite.SubImages[j] = image;
                    }
                }
                else
                {
                    // Read sprite data
                    sprite.OriginX = reader.ReadGMInt();
                    sprite.OriginY = reader.ReadGMInt();

                    // Sprite number of sub images
                    sprite.SubImages = new GMImage[reader.ReadGMInt()];

                    // Iterate through sub-images
                    for (int j = 0; j < sprite.SubImages.Length; j++)
                    {
                        // Get version.
                        version = reader.ReadGMInt();

                        // Check version
                        if (version != 800)
                            throw new Exception("Unsupported Sprite object version.");

                        // Get width and height of image
                        int width = reader.ReadGMInt();
                        int height = reader.ReadGMInt();

                        // If the sprite size is not zero
                        if (width != 0 && height != 0)
                        {
                            // Create a new image object
                            GMImage image = new GMImage();
                            image.Compressed = false;

                            // Set image data
                            image.Width = width;
                            image.Height = height;

                            // Get size of image data
                            int size = reader.ReadGMInt();

                            // Get image data
                            image.Data = reader.ReadGMBytes(size);

                            // Insert compressed image data
                            sprite.SubImages[j] = image;
                        }
                    }

                    // Read sprite data
                    sprite.ShapeMode = reader.ReadGMInt();
                    sprite.AlphaTolerance = reader.ReadGMInt();
                    sprite.UseSeperateCollisionMasks = reader.ReadGMBool();
                    sprite.BoundingBoxMode = reader.ReadGMInt();
                    sprite.BoundingBoxLeft = reader.ReadGMInt();
                    sprite.BoundingBoxRight = reader.ReadGMInt();
                    sprite.BoundingBoxBottom = reader.ReadGMInt();
                    sprite.BoundingBoxTop = reader.ReadGMInt();
                }

                // End object inflate
                reader.EndDecompress();

                // Add sprite
                sprites.Add(sprite);
            }

            // Return sprites
            return sprites;
        }

        #endregion
    }
}