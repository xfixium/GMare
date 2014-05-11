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
        private BoundingBoxType _boundingBoxMode = BoundingBoxType.Auto;
        private ShapeType _shapeMode = ShapeType.Rectange;
        private int _width = 32;
        private int _height = 32;
        private int _originX = 0;
        private int _originY = 0;
        private int _boundingBoxLeft = 0;
        private int _boundingBoxRight = 0;
        private int _boundingBoxTop = 0;
        private int _boundingBoxBottom = 0;
        private int _alphaTolerance = 0;
        private int _textureGroup = 0;
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

        public BoundingBoxType BoundingBoxMode
        {
            get { return _boundingBoxMode; }
            set { _boundingBoxMode = value; }
        }

        public ShapeType ShapeMode
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

        public int TextureGroup
        {
            get { return _textureGroup; }
            set { _textureGroup = value; }
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
                    sprite.BoundingBoxMode = (BoundingBoxType)reader.ReadGMInt();
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
                    sprite.ShapeMode = (ShapeType)reader.ReadGMInt();
                    sprite.AlphaTolerance = reader.ReadGMInt();
                    sprite.UseSeperateCollisionMasks = reader.ReadGMBool();
                    sprite.BoundingBoxMode = (BoundingBoxType)reader.ReadGMInt();
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

        /// <summary>
        /// Reads sprites from Game Maker project file.
        /// </summary>
        public static GMList<GMSprite> ReadSpritesGMX(string directory, List<string> assets)
        {
            // A list of sprites
            GMList<GMSprite> sprites = new GMList<GMSprite>();

            // Iterate through .gmx files in the directory
            foreach (string file in Directory.GetFiles(directory, "*.gmx"))
            {
                // Set name of the sprite
                string name = GMFileReader.GetResourceName(file);

                // If the file is not in the asset list, it has been orphaned, continue
                if (!assets.Contains(name))
                    continue;

                // Create a dictionary of sprite properties
                Dictionary<GMXSpriteProperty, string> properties = new Dictionary<GMXSpriteProperty, string>();

                foreach (GMXSpriteProperty property in Enum.GetValues(typeof(GMXSpriteProperty)))
                    properties.Add(property, "");

                // Local variables
                List<GMImage> subImages = new List<GMImage>();

                // Create an xml reader
                using (XmlReader xmlReader = XmlReader.Create(file))
                {
                    // Seek to content
                    xmlReader.MoveToContent();

                    // Read the GMX file
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
                        if (nodeName.ToLower() == EnumString.GetEnumString(GMXSpriteProperty.Frame).ToLower())
                        {
                            // Create a sub image and set the image path
                            GMImage subImage = new GMImage();
                            subImage.Compressed = false;
                            subImage.ImagePath = directory + "\\" + xmlReader.Value;
                            subImage.Data = GMUtilities.LoadBytesFromBitmap(subImage.ImagePath);
                            subImages.Add(subImage);
                        }
                        else
                        {
                            // Get the enumeration based on the node name
                            GMXSpriteProperty? property = EnumString.GetEnumFromString<GMXSpriteProperty>(nodeName);

                            // If no match was found, continue
                            if (property == null)
                                continue;

                            // Set the property value
                            properties[(GMXSpriteProperty)property] = xmlReader.Value;
                        }
                    }
                }

                // Create a new sprite, set properties
                GMSprite sprite = new GMSprite();
                sprite.Id = GMResource.GetIdFromName(name);
                sprite.Name = name;
                sprite.OriginX = GMFileReader.ReadGMXInt(properties[GMXSpriteProperty.XOrigin]);
                sprite.OriginY = GMFileReader.ReadGMXInt(properties[GMXSpriteProperty.YOrigin]);
                sprite.ShapeMode = (ShapeType)GMFileReader.ReadGMXInt(properties[GMXSpriteProperty.ColKind]);
                sprite.AlphaTolerance = GMFileReader.ReadGMXInt(properties[GMXSpriteProperty.ColTolerance]);
                sprite.UseSeperateCollisionMasks = GMFileReader.ReadGMXBool(properties[GMXSpriteProperty.SepMasks]);
                sprite.BoundingBoxMode = (BoundingBoxType)GMFileReader.ReadGMXInt(properties[GMXSpriteProperty.BBoxMode]);
                sprite.BoundingBoxLeft = GMFileReader.ReadGMXInt(properties[GMXSpriteProperty.BBoxLeft]);
                sprite.BoundingBoxRight = GMFileReader.ReadGMXInt(properties[GMXSpriteProperty.BBoxRight]);
                sprite.BoundingBoxTop = GMFileReader.ReadGMXInt(properties[GMXSpriteProperty.BBoxTop]);
                sprite.BoundingBoxBottom = GMFileReader.ReadGMXInt(properties[GMXSpriteProperty.BBoxBottom]);
                sprite.TileHorizontally = GMFileReader.ReadGMXBool(properties[GMXSpriteProperty.HTile]);
                sprite.TileVertically = GMFileReader.ReadGMXBool(properties[GMXSpriteProperty.VTile]);
                sprite.TextureGroup = GMFileReader.ReadGMXInt(properties[GMXSpriteProperty.TextureGroup0]);
                sprite.UsedFor3D = GMFileReader.ReadGMXBool(properties[GMXSpriteProperty.For3D]);
                sprite.Width = GMFileReader.ReadGMXInt(properties[GMXSpriteProperty.Width]);
                sprite.Height = GMFileReader.ReadGMXInt(properties[GMXSpriteProperty.Height]);
                sprite.SubImages = subImages.ToArray();

                // Add the sprite
                sprites.Add(sprite);
            }

            // Return the list of sprites
            return sprites;
        }

        #endregion
    }
}