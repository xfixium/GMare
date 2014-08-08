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
using System.Linq;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using System.Collections.Generic;
using GameMaker.Common;
using GameMaker.Resource;
using GMare.Graphics;

namespace GMare.Objects
{
    /// <summary>
    /// Main room class
    /// </summary>
    [Serializable]
    public class GMareRoom
    {
        #region Fields

        public const int MAXDEPTH = 1000000000;                                    // The maximum depth a layer can have
        public const int MINDEPTH = -1000000000;                                   // The minimum depth a layer can have
        private List<ExportProject> _projects = new List<ExportProject>();         // List of projects for binary export
        private List<GMareBrush> _brushes = new List<GMareBrush>();                // List of brushes
        private List<GMareObject> _objects = new List<GMareObject>();              // List of objects
        private List<GMareInstance> _instances = new List<GMareInstance>();        // List of instances
        private List<GMareInstance> _blocks = new List<GMareInstance>();           // List of block instances
        private List<GMareLayer> _layers = new List<GMareLayer>();                 // List of layers
        private List<GMareBackground> _backgrounds = new List<GMareBackground>();  // List of backgrounds
        private List<GMareObject> _recentObjects = new List<GMareObject>();        // List of recent objects
        private GMNode[] _nodes = null;                                            // An array of object nodes
        private int[] _customColors = null;                                        // An array of custom colors
        private Color _backColor = Color.Silver;                                   // Backcolor of the room
        private string _name = "New Room";                                         // A personalized string of the room
        private string _caption = "";                                              // Window caption text
        private string _creationCode = "";                                         // Room creation code
        private int _speed = 30;                                                   // Room speed
        private int _columns = 20;                                                 // The width of the room in tiles
        private int _rows = 15;                                                    // The height of the room in tiles
        private bool _persistent = false;                                          // If the room is global
        private bool _scaleWarning = true;                                         // Message on scaling
        private bool _blendWarning = true;                                         // Message on color blending

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the list of projects to write for binary export
        /// </summary>
        public List<ExportProject> Projects
        {
            get { return _projects; }
            set { _projects = value; }
        }

        /// <summary>
        /// Gets or sets the room's layers
        /// </summary>
        public List<GMareLayer> Layers
        {
            get { return _layers; }
            set { _layers = value; }
        }

        /// <summary>
        /// Gets or sets the objects list
        /// </summary>
        public List<GMareObject> Objects
        {
            get { return _objects; }
            set { _objects = value; }
        }

        /// <summary>
        /// Gets or sets the instances list
        /// </summary>
        public List<GMareInstance> Instances
        {
            get { return _instances; }
            set { _instances = value; }
        }

        /// <summary>
        /// Gets or sets the block instances list
        /// </summary>
        public List<GMareInstance> Blocks
        {
            get { return _blocks; }
            set { _blocks = value; }
        }

        /// <summary>
        /// Gets or sets the list of saved brushes
        /// </summary>
        public List<GMareBrush> Brushes
        {
            get { return _brushes; }
            set { _brushes = value; }
        }

        /// <summary>
        /// Gets or sets the list of recently used objects
        /// </summary>
        public List<GMareObject> RecentObjects
        {
            get { return _recentObjects; }
            set { _recentObjects = value; }
        }

        /// <summary>
        /// Gets or sets the object node array
        /// </summary>
        public GMNode[] Nodes
        {
            get { return _nodes; }
            set { _nodes = value; }
        }

        /// <summary>
        /// Gets or sets the array of custom colors
        /// </summary>
        public int[] CustomColors
        {
            get { return _customColors; }
            set { _customColors = value; }
        }

        /// <summary>
        /// Gets the background pixelmap used for this room
        /// </summary>
        public List<GMareBackground> Backgrounds
        {
            get { return _backgrounds; }
            set { _backgrounds = value; }
        }

        /// <summary>
        /// Gets or sets the back color of the room
        /// </summary>
        [XmlIgnore]
        public Color BackColor
        {
            get { return _backColor; }
            set { _backColor = value; }
        }

        /// <summary>
        /// XML conversion doesn't support color data, use integer instead
        /// </summary>
        [XmlElement("BackColor")]
        public int XMLBackColor
        {
            get { return _backColor.ToArgb(); }
            set { _backColor = Color.FromArgb(value); }
        }

        /// <summary>
        /// Gets or sets the personalized name for the room
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets the window caption for the room
        /// </summary>
        public string Caption
        {
            get { return _caption; }
            set { _caption = value; }
        }

        /// <summary>
        /// Gets or sets the creation code
        /// </summary>
        public string CreationCode
        {
            get { return _creationCode; }
            set { _creationCode = value; }
        }

        /// <summary>
        /// Gets the width of the room
        /// </summary>
        
        public int Width
        {
            get { return _columns * _backgrounds[0].TileWidth; }
        }

        /// <summary>
        /// Gets the height of the room
        /// </summary>
        
        public int Height
        {
            get { return _rows * _backgrounds[0].TileHeight; }
        }

        /// <summary>
        /// Gets or sets the columns of the room
        /// </summary>
        [XmlIgnore]
        
        public int Columns
        {
            get { return _columns; }
            set
            {
                // Resize the tile columns
                ResizeWidth(value);

                // Set new value
                _columns = value;
            }
        }

        /// <summary>
        /// XML will trigger a resize when deserializing, necessary to avoid it
        /// </summary>
        [XmlElement("Columns")]
        public int XMLColumns
        {
            get { return _columns; }
            set { _columns = value; }
        }

        /// <summary>
        /// Gets or sets the rows of the room
        /// </summary>
        [XmlIgnore]
        
        public int Rows
        {
            get { return _rows; }
            set
            {
                // Resize the tile rows
                ResizeHeight(value);

                // Set new value
                _rows = value;
            }
        }

        /// <summary>
        /// XML will trigger a resize when deserializing, necessary to avoid it
        /// </summary>
        [XmlElement("Rows")]
        public int XMLRows
        {
            get { return _rows; }
            set { _rows = value; }
        }

        /// <summary>
        /// Gets or sets the speed of the room
        /// </summary>
        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        /// <summary>
        /// Gets the room size
        /// </summary>
        
        public Size RoomSize
        {
            get { return new Size(Width, Height); }
        }

        /// <summary>
        /// Gets or sets whether the room is global
        /// </summary>
        public bool Persistent
        {
            get { return _persistent; }
            set { _persistent = value; }
        }

        /// <summary>
        /// Gets or sets whether a scale warning should show
        /// </summary>
        public bool ScaleWarning
        {
            get { return _scaleWarning; }
            set { _scaleWarning = value; }
        }

        /// <summary>
        /// Gets or sets whether a color blend warning should show
        /// </summary>
        public bool BlendWarning
        {
            get { return _blendWarning; }
            set { _blendWarning = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new room
        /// </summary>
        public GMareRoom(int columns, int rows, int tileWidth, int tileHeight)
        {
            // Set Properties, to auto set actual width and height
            Columns = columns;
            Rows = rows;

            // Set fields
            _backgrounds.Add(new GMareBackground());
            _backgrounds[0].TileWidth = tileWidth;
            _backgrounds[0].TileHeight = tileHeight;

            // Create a new layer
            _layers.Add(new GMareLayer("Layer", 0, GMareLayer.GetEmptyLayer(columns, rows)));
        }

        /// <summary>
        /// Constructs a new room
        /// </summary>
        public GMareRoom()
        {
            _backgrounds.Add(new GMareBackground());
        }

        /// <summary>
        /// Constructs a new room
        /// </summary>
        private GMareRoom(int columns, int rows, int tileWidth, int tileHeight, bool noLayer)
        {
            // Set Properties, to auto set actual width and height
            Columns = columns;
            Rows = rows;

            // Set fields
            _backgrounds.Add(new GMareBackground());
            _backgrounds[0].TileWidth = tileWidth;
            _backgrounds[0].TileHeight = tileHeight;
        }

        #endregion

        #region Methods

        #region General

        /// <summary>
        /// Makes a new copy of this room
        /// </summary>
        /// <returns>A new room copy</returns>
        public GMareRoom Clone()
        {
            // Get a copy of the room
            GMareRoom room = (GMareRoom)this.MemberwiseClone();
            room.Projects = _projects.ConvertAll(p => p.Clone());
            room.Brushes = _brushes.ConvertAll(b => b.Clone());
            room.Objects = _objects.ConvertAll(o => o.Clone());
            room.RecentObjects = _recentObjects.ConvertAll(ro => ro.Clone());
            room.Instances = _instances.ConvertAll(i => i.Clone());
            room.Blocks = _blocks.ConvertAll(b => b.Clone());
            room.Layers = _layers.ConvertAll(l => l.Clone());
            room.Backgrounds = _backgrounds.ConvertAll(b => b.Clone());
            room.Nodes = CloneNodes();

            if (_customColors != null)
                room.CustomColors = (int[])_customColors.Clone();

            return room;
        }

        /// <summary>
        /// Clones this room's nodes
        /// </summary>
        /// <returns>A deep clone of this room's nodes</returns>
        public GMNode[] CloneNodes()
        {
            // if the room does not have any nodes. return null
            if (_nodes == null || _nodes.Length == 0)
                return null;

            // Node array
            GMNode[] nodes = new GMNode[_nodes.Length];

            // Iterate through nodes to clone them
            for (int i = 0; i < _nodes.Length; i++)
                nodes[i] = CloneNode(_nodes[i]);

            // Return cloned nodes
            return nodes;
        }

        /// <summary>
        /// Clones a single node
        /// </summary>
        /// <param name="source">The given source node</param>
        /// <returns>A cloned source node</returns>
        private GMNode CloneNode(GMNode source)
        {
            // Create a new node
            GMNode clone = new GMNode();
            clone.Children = source.Children;
            clone.Id = source.Id;
            clone.LastChanged = source.LastChanged;
            clone.Name = (string)source.Name.Clone();
            clone.NodeType = source.NodeType;
            clone.ResourceType = source.ResourceType;
            clone.Nodes = clone.Children == 0 ? null : new GMNode[clone.Children];

            // Iterate through node children
            for (int i = 0; i < source.Children; i++)
                clone.Nodes[i] = CloneNode(source.Nodes[i]);

            // Return cloned node
            return clone;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            // Iterate through export projects
            foreach (ExportProject project in _projects)
            {
                if (project.Background != null && project.Background.Image != null)
                    project.Background.Image.Dispose();

                project.Name = null;
                project.RoomPath = null;
            }

            // Clear brush glyphs and tiles
            foreach (GMareBrush brush in _brushes)
            {
                brush.Glyph.Dispose();
                brush.Tiles = null;
            }

            // Clear object images
            foreach (GMareObject obj in _objects)
                obj.Image.Dispose();

            // Clear recent object images
            foreach (GMareObject obj in _recentObjects)
                if (obj.Image != null)
                    obj.Image.Dispose();

            // Clear creation code for instances
            foreach (GMareInstance instance in _instances)
                instance.CreationCode = null;

            // Clear creation code for blocks
            foreach (GMareInstance block in _blocks)
                block.CreationCode = null;

            // Clear tiles
            foreach (GMareLayer layer in _layers)
                layer.Tiles = null;

            // Clear backgrounds
            foreach (GMareBackground background in _backgrounds)
                if (background.Image != null)
                    background.Image.Dispose();

            // Clear nodes
            if (_nodes != null)
                foreach (GMNode node in _nodes)
                    node.Nodes = null;

            // Clear properties
            _projects.Clear();
            _brushes.Clear();
            _objects.Clear();
            _recentObjects.Clear();
            _instances.Clear();
            _blocks.Clear();
            _layers.Clear();
            _nodes = null;
            _customColors = null;
            _name = null;
            _caption = null;
            _creationCode = null;
        }

        /// <summary>
        /// Clone persistent values
        /// </summary>
        /// <returns>A dereferenced copy of the room, but only data that will not change</returns>
        public GMareRoom ClonePersistents()
        {
            // Create a new room
            GMareRoom room = new GMareRoom(_columns, _rows, _backgrounds[0].TileWidth, _backgrounds[0].TileHeight);

            // Iterate through objects
            foreach (GMareObject obj in _objects)
                room.Objects.Add(obj.Clone());

            // Iterate through brushes
            foreach (GMareBrush brush in _brushes)
                room.Brushes.Add(brush.Clone());

            // Scale warning flags
            room.ScaleWarning = _scaleWarning;
            room.BlendWarning = _blendWarning;

            // Return copy
            return room;
        }

        /// <summary>
        /// Resizes all the layers to the new room width
        /// </summary>
        private void ResizeWidth(int columns)
        {
            // If the sizes are the same, return
            if (columns == (_layers.Count < 1 ? _columns : _layers[0].Tiles.GetLength(0)))
                return;

            // Get the amount of columns we can copy
            int amount = columns > _columns ? _columns : columns;

            // Iterate through layers
            for (int layer = 0; layer < _layers.Count; layer++)
            {
                // Create an empty tile array with the new size
                GMareTile[,] array = GMareLayer.GetEmptyLayer(columns, _rows);

                // Iterate through tiles
                for (int col = 0; col < array.GetLength(0); col++)
                    for (int row = 0; row < array.GetLength(1); row++)
                        if (col < amount)
                            array[col, row] = _layers[layer].Tiles[col, row].Clone();

                // Set tiles with new array
                _layers[layer].Tiles = array;
            }

            // Update block instances
            UpdateBlockInstances();
        }

        /// <summary>
        /// Resizes all the layers to the new room height
        /// </summary>
        private void ResizeHeight(int rows)
        {
            // If the sizes are the same, return
            if (rows == (_layers.Count < 1 ? _rows : _layers[0].Tiles.GetLength(1)))
                return;

            // Get the amount of rows we can copy
            int amount = rows > _rows ? _rows : rows;

            // Iterate through layers
            for (int layer = 0; layer < _layers.Count; layer++)
            {
                // Create an empty tile array with the new size
                GMareTile[,] array = GMareLayer.GetEmptyLayer(_columns, rows);

                // Iterate through tiles
                for (int col = 0; col < array.GetLength(0); col++)
                    for (int row = 0; row < array.GetLength(1); row++)
                        if (row < amount)
                            array[col, row] = _layers[layer].Tiles[col, row].Clone();

                // Set tiles with new array
                _layers[layer].Tiles = array;
            }

            // Update block instances
            UpdateBlockInstances();
        }

        /// <summary>
        /// Gets a menu item array, representing a GM object tree
        /// </summary>
        /// <returns>A drop down menu item array</returns>
        public ToolStripMenuItem[] GetMenu()
        {
            // If nodes are empty, return null
            if (_nodes == null)
                return null;

            // A list of menus, representing GM nodes
            List<ToolStripMenuItem> menus = new List<ToolStripMenuItem>();

            // Iterate through object nodes, add a menu item from the node
            foreach (GMNode node in _nodes)
                menus.Add(GetMenuFromGMNode(node));

            // Return the menus
            return menus.ToArray();
        }

        /// <summary>
        /// Converts a GMNode to a menu item. Stores original GM node data in tag property
        /// </summary>
        /// <param name="node">The GMNode to convert</param>
        /// <returns>A menu item of the GMNode</returns>
        private ToolStripMenuItem GetMenuFromGMNode(GMNode node)
        {
            // Setup menu item
            ToolStripMenuItem menu = new ToolStripMenuItem();
            menu.Text = node.Name;
            menu.Tag = node;

            // Set menu item image
            if (node.NodeType == GMNodeType.Group)
                menu.Image = GMare.Properties.Resources.file_close;
            else
            {
                // Get GM object based on id, set menu image
                GMareObject obj = _objects.Find(delegate(GMareObject o) { return o.Resource.Id == node.Id; });

                // If object is not null, set size for image, then assign it to menu image
                if (obj != null)
                {
                    Size size = new Size(Math.Min(obj.Image.Width, 22), Math.Min(obj.Image.Height, 22));
                    Bitmap image = obj.Image.ToBitmap();
                    menu.Image = obj != null ? PixelMap.BitmapResize(image, size) : menu.Image;
                    image.Dispose();
                }
            }

            // If no child nodes, return menu
            if (node.Nodes == null)
                return menu;

            // Iterate through nodes, add menu item
            for (int i = 0; i < node.Children; i++)
                menu.DropDownItems.Add(GetMenuFromGMNode(node.Nodes[i]));

            // Return a menu item
            return menu;
        }

        /// <summary>
        /// Updates instance object names
        /// </summary>
        public void UpdateInstanceObjectNames()
        {
            // Iterate through existing instances
            foreach (GMareInstance instance in App.Room.Instances)
            {
                // Iterate through objects
                GMareObject obj = this.Objects.Find(o => o.Resource.Id == instance.ObjectId || o.Resource.Name == instance.ObjectName);

                // If the instance does not have an object name, update it
                if (obj != null && instance.ObjectName == "")
                    instance.ObjectName = obj.Resource.Name;
            }
        }

        #endregion

        #region Layers

        /// <summary>
        /// Gets a unique depth
        /// </summary>
        /// <returns>A unique depth</returns>
        public int GetUniqueDepth()
        {
            // Set the depth to the minimum depth allowed
            int depth = MINDEPTH;

            // Iterate through layers
            foreach (GMareLayer layer in _layers)
            {
                // If the depth is the same as the layer depth, increment the depth else, a unique depth was found.
                if (layer.Depth == depth)
                    depth++;
                else
                    break;

                // If the depth is at the maximum allowed depth, break
                if (depth == MAXDEPTH)
                    break;
            }

            // Return the unique depth
            return depth;
        }

        /// <summary>
        /// Check for unique depth
        /// </summary>
        /// <param name="depth">The depth to check</param>
        /// <returns>If the depth exists already</returns>
        public bool CheckDepth(int depth)
        {
            // Iterate through layers
            foreach (GMareLayer layer in _layers)
            {
                // If the depth is the same as the layer depth, the depth is used already
                if (layer.Depth == depth)
                    return true;
            }

            // The depth has not been used
            return false;
        }

        /// <summary>
        /// Shifts room tiles in a desired direction, by a desired amount, on the desired layer
        /// </summary>
        /// <param name="layer">The layer to shift, if null, shift all available layers</param>
        /// <param name="direction">The direction to shift the tiles</param>
        /// <param name="amount">The amount of tiles to shift</param>
        public void Shift(GMareLayer layer, ShiftDirectionType direction, int amount)
        {
            // If the tile swap happens on all layers, iterate through each layer and shift it
            if (layer == null)
            {
                foreach (GMareLayer temp in _layers)
                    temp.Shift(direction, amount);

                return;
            }

            // Get the index of the desired layer and shift it
            int index = _layers.IndexOf(layer);
            _layers[index].Shift(direction, amount);
        }

        /// <summary>
        /// Merges a selected layer to the one below it
        /// </summary>
        /// <param name="topLayer">Layer to merge down</param>
        /// <param name="bottomLayer">Layer to merge to</param>
        public bool MergeLayers(GMareLayer topLayer, GMareLayer bottomLayer)
        {
            // Merge top layer tiles to bottom layer tiles
            for (int x = 0; x < topLayer.Tiles.GetLength(0); x++)
                for (int y = 0; y < topLayer.Tiles.GetLength(1); y++)
                    if (topLayer.Tiles[x, y].TileId != -1)
                        bottomLayer.Tiles[x,y] = topLayer.Tiles[x, y].Clone();

            // Delete the top layer
            Layers.Remove(topLayer);

            // Merger was successful
            return true;
        }

        /// <summary>
        /// Gets a layer below the given layer
        /// </summary>
        /// <param name="layer">The selected layer</param>
        /// <returns>A layer below the selected layer, if there is one</returns>
        public GMareLayer GetLayerBelow(GMareLayer layer)
        {
            // Search for a layer below the selected layer
            for (int i = Layers.IndexOf(layer); i < Layers.Count; i++)
                if (Layers[i].Depth > layer.Depth)
                    return Layers[i];

            return null;
        }

        /// <summary>
        /// Creates an array of Game Maker tile objects from GMare tile ids
        /// </summary>
        /// <param name="lastTileId">The last used tile id</param>
        /// <param name="background">The background id used for the tile</param>
        /// <returns>An array of Game Maker tiles</returns>
        public GMTile[] GMareTilesToGMTiles(int lastTileId, GMareBackground background, bool optimized)
        {
            // Create a list of Game Maker tiles
            List<GMTile> tiles = new List<GMTile>();
            
            // Local variables
            int tileCols = background.GetCondensedTileset().Width / background.TileWidth;
            Point offset = new Point(background.OffsetX, background.OffsetY);
            Point spacing = new Point(background.SeparationX, background.SeparationY);
            Size tileSize = new Size(background.TileWidth, background.TileHeight);

            // Iterate through room layers
            foreach (GMareLayer layer in _layers)
            {
                // Get various layer properties
                int depth = layer.Depth;

                // If optimizing and no separation and spacing, use optimized rectangles, else a rectangle for every tile
                if (optimized && offset == Point.Empty && spacing == Point.Empty)
                {
                    tiles.AddRange(layer.GetExportTiles(background, false, lastTileId));
                }
                else
                {
                    // Iterate through layer tile rows
                    for (int row = 0; row < layer.Tiles.GetLength(1); row++)
                    {
                        // Iterate through layer tile columns
                        for (int col = 0; col < layer.Tiles.GetLength(0); col++)
                        {
                            // Get tile id
                            int sector = layer.Tiles[col, row].TileId;

                            // If the tile is empty, continue
                            if (sector == -1)
                                continue;

                            // Create a new GM tile
                            GMTile tile = new GMTile();
                            tile.Id = lastTileId++;
                            tile.Depth = depth;
                            tile.BackgroundId = background.GameMakerId;
                            tile.BackgroundName = background.Name;
                            tile.X = col * _backgrounds[0].TileWidth;
                            tile.Y = row * _backgrounds[0].TileHeight;
                            tile.Width = _backgrounds[0].TileWidth;
                            tile.Height = _backgrounds[0].TileHeight;
                            tile.BackgroundX = (sector - (sector / tileCols) * tileCols) * tileSize.Width;
                            tile.BackgroundY = (sector / tileCols) * tileSize.Height;
                            tile.BackgroundX += ((tile.BackgroundX / tileSize.Width) * spacing.X) + offset.X;
                            tile.BackgroundY += ((tile.BackgroundY / tileSize.Height) * spacing.Y) + offset.Y;

                            // Add the Game Maker tile to the list
                            tiles.Add(tile);
                        }
                    }
                }
            }

            // Return the array of tiles
            return tiles.ToArray();
        }

        #endregion

        #region Blocks

        /// <summary>
        /// Adds a block instances
        /// </summary>
        /// <param name="objectId">The block instance object id that should reside on the tile id</param>
        /// <param name="tileId">The tile id that the block instance resides on</param>
        public void AddBlock(int objectId, int tileId)
        {
            // If no background image return
            if (_backgrounds[0].Image == null)
                return;

            // Find a matching block instance
            GMareInstance block = _blocks.Find(GMareInstance => GMareInstance.TileId == tileId);

            // If a matching block instance was found
            if (block != null)
            {
                // If the object id is different, update the block
                if (block.ObjectId != objectId)
                {
                    // Update instance object ids to the new one
                    _instances.FindAll(GMareInstance => GMareInstance.TileId == tileId && GMareInstance.ObjectId == block.ObjectId)
                        .ForEach(GMareInstance => GMareInstance.ObjectId = objectId);

                    // Set new object id
                    block.ObjectId = objectId;
                }

                // Since there is a block already assigned to the desired tile, return
                return;
            }

            // Get the object associated with the object id
            GMareObject obj = App.Room.Objects.Find(GMareObject => GMareObject.Resource.Id == objectId);

            // If no object was found, return
            if (obj == null)
                return;

            // Add the new block
            _blocks.Add(new GMareInstance(tileId, objectId));

            // Iterate through layers
            foreach (GMareLayer layer in _layers)
            {
                // Iterate through tiles
                for (int y = 0; y < layer.Tiles.GetLength(1); y++)
                {
                    for (int x = 0; x < layer.Tiles.GetLength(0); x++)
                    {
                        // If the desired tile id matches
                        if (layer.Tiles[x, y].TileId == tileId)
                        {
                            // Get the tile position.
                            Point pos = new Point(x * _backgrounds[0].TileSize.Width, y * _backgrounds[0].TileSize.Height);

                            // If the same block instance type already resides in this space, do not occupy it
                            if (_instances.Find(GMareInstance => GMareInstance.ObjectId == objectId && GMareInstance.X == pos.X && GMareInstance.Y == pos.Y) != null)
                                continue;

                            // Create a new block instance
                            GMareInstance inst = new GMareInstance(tileId);
                            inst.Name = "";
                            inst.X = pos.X;
                            inst.Y = pos.Y;
                            inst.ObjectId = objectId;
                            inst.ObjectName = (string)obj.Resource.Name.Clone();

                            // Add new block instance
                            _instances.Add(inst);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Deletes specified block instances
        /// </summary>
        /// <param name="objectId">The instance's object id to match for deletion</param>
        /// <param name="tileId">The instance's tile id to match for deletion</param>
        public void DeleteBlock(int objectId, int tileId)
        {
            // Check for creation code within the block instances to be deleted
            foreach (GMareInstance instance in _instances)
            {
                // If the block instance has creation code
                if (instance.TileId == tileId && instance.CreationCode != "")
                {
                    // Ask if the user really wants to delete these blocks, knowing creation code is within them
                    DialogResult result = MessageBox.Show("One or more instances of this block hold creation code, are you sure you want to delete them?", "GMare", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    // If the user does not want to delete the block instances, return
                    if (result == DialogResult.No)
                        return;
                    else
                        break;
                }
            }

            // Remove block instances
            _blocks.RemoveAll(GMareInstance => GMareInstance.TileId == tileId);
            _instances.RemoveAll(GMareInstance => GMareInstance.TileId == tileId);
        }

        /// <summary>
        /// Updates the block instances in the room
        /// </summary>
        public void UpdateBlockInstances()
        {
            // Remove all block instances
            _instances.RemoveAll(delegate(GMareInstance i) { return i.TileId != -1; });

            // Iterate through blocks
            foreach (GMareInstance block in _blocks)
            {
                // Iterate through layers
                foreach (GMareLayer layer in _layers)
                {
                    // Iterate through tiles
                    for (int x = 0; x < layer.Tiles.GetLength(0); x++)
                    {
                        for (int y = 0; y < layer.Tiles.GetLength(1); y++)
                        {
                            // Get the object associated with this instance
                            GMareObject obj = App.Room.Objects.Find(delegate(GMareObject o) { return o.Resource.Id == block.ObjectId; });

                            // If no object was found, return
                            if (obj == null)
                                return;

                            // If the desired tile id matches
                            if (layer.Tiles[x, y].TileId == block.TileId)
                            {
                                // Get the tile position
                                Point pos = new Point(x * _backgrounds[0].TileSize.Width, y * _backgrounds[0].TileSize.Height);

                                // If the same object already resides in this space, do not occupy it
                                if (_instances.Find(delegate(GMareInstance i) { return i.ObjectId == block.ObjectId && i.X == pos.X && i.Y == pos.Y; }) != null)
                                    continue;

                                // Create a new block instance
                                GMareInstance inst = new GMareInstance(block.TileId);
                                inst.Name = "";
                                inst.X = pos.X;
                                inst.Y = pos.Y;
                                inst.ObjectId = block.ObjectId;
                                inst.ObjectName = (string)obj.Resource.Name.Clone();

                                // Add new block instance
                                _instances.Add(inst);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Clears all block instances from instance list
        /// </summary>
        public void ClearBlockInstances()
        {
            // Clear all blocks
            _blocks.Clear();

            // Update room
            UpdateBlockInstances();
        }

        #endregion

        #region Binary

        /// <summary>
        /// Gets the byte size of a room for binary export
        /// </summary>
        /// <returns>The byte size of a room</returns>
        public int GetByteCount(GMareBackground background, bool writeTiles, bool useFlipValues, bool useBlendColor, 
            bool writeInstances, bool writeBlockInstances)
        {
            // WriteTiles            (1)
            // UseFlipValues         (1)
            // UseBlendColors        (1)
            // WriteInstances        (1)
            int bytes = 4;

            // Layer count           (4)
            // Columns               (2)
            // Rows                  (2)
            // OffsetX               (1)
            // OffsetY               (1)
            // SeparationX           (1)
            // SeparationY           (1)
            // TileWidth             (1)
            // TileHeight            (1)
            // BackgroundCols        (4)
            // BackgroundId          (4)
            // BackgroundName length (4)
            // BackgroundName        (Number of characters)
            if (writeTiles)
            {
                bytes += 26 + background.Name.Length;

                // Depth        (4)
                // Method type  (1)
                foreach (GMareLayer layer in _layers)
                {
                    bytes += 5;

                    // Get optimized method
                    int tiledSize = 0;
                    int standardSize = 0;
                    BinaryMethodType method = GetTileMethodType(layer, null, background, useFlipValues, useBlendColor, out tiledSize, out standardSize);

                    // Do action based on the optimized method
                    switch (method)
                    {
                        // TileId      (4)
                        // FlipMode    (1)
                        // BlendColor  (4)
                        case BinaryMethodType.Tiled: bytes += tiledSize; break;

                        // Tile count (4)
                        // X          (4)
                        // Y          (4)
                        // Source X   (4)
                        // Source Y   (4)
                        // Width      (4)
                        // Height     (4)
                        // FlipMode   (1)
                        // BlendColor (4)
                        case BinaryMethodType.Standard: bytes += standardSize; break;
                    }
                }
            }

            // Number of instances (4)
            if (writeInstances)
            {
                bytes += 4;

                // ObjectName length    (4)
                // ObjectName           (Number of characters)
                // ObjectId             (4)
                // X                    (4)
                // Y                    (4)
                // Creation code length (4)
                // Creation code        (Number of characters)
                foreach (GMInstance instance in _instances)
                    bytes += 20 + instance.ObjectName.Length + instance.CreationCode.Length;
            }

            return bytes;
        }

        /// <summary>
        /// Gets the optimized method for the given layer
        /// </summary>
        /// <param name="layer">The layer to analize</param>
        /// <param name="tiles">List of optimized tiles from the given layer</param>
        /// <param name="background">The background to use to calculate standard tiles</param>
        /// <param name="useFlipValues">If tile scaling is to be exported</param>
        /// <param name="useBlendColor">If blend colors are to be exported</param>
        /// <returns>The most optimized binary tile method</returns>
        public BinaryMethodType GetTileMethodType(GMareLayer layer, ExportTile[] tiles, GMareBackground background,
            bool useFlipValues, bool useBlendColor, out int tiledSize, out int standardSize)
        {
            // Get optimized tiles, then determine the best method
            tiles = tiles == null ? layer.GetExportTiles(background, true, -1) : tiles;
            int filledTiles = Array.FindAll<GMareTile>(layer.Tiles.Cast<GMareTile>().ToArray(), t => t.TileId != -1).Length;
            tiledSize = (layer.Tiles.Length * 4) + (filledTiles * (useFlipValues ? 1 : 0)) + (filledTiles * (useBlendColor ? 4 : 0));
            standardSize = (tiles.Length * (24 + (useFlipValues ? 1 : 0) + (useBlendColor ? 4 : 0))) + 4;
            BinaryMethodType method = (tiledSize > standardSize ? BinaryMethodType.Standard : BinaryMethodType.Tiled);

            // If using any offset or separation, use standard tile method (Kills optimization)
            if (background.OffsetX > 0 || background.OffsetY > 0 ||
                background.SeparationX > 0 || background.SeparationY > 0)
                method = BinaryMethodType.Tiled;

            // Return the method
            return method;
        }

        #endregion

        #endregion

        #region Overrides

        /// <summary>
        /// Override to string
        /// </summary>
        /// <returns>A custom string that represents the room</returns>
        public override string ToString()
        {
            return _name;
        }

        #endregion
    }
    
    /// <summary>
    /// Layer class that holds indexing and tile data
    /// </summary>
    [Serializable]
    public class GMareLayer
    {
        #region Fields

        private string _name = "Layer";      // The name of the layer
        private int _depth = 0;              // The z order of the layer
        private bool _visible = true;        // If the layer is visible in edit mode
        private GMareTile[,] _tiles = null;  // The tile objects of the layer

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the layer name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets the layer depth
        /// </summary>
        public int Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }

        /// <summary>
        /// Gets or sets if the layer is visible in edit mode
        /// </summary>
        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        /// <summary>
        /// Gets or sets the layer's tiles
        /// </summary>
        [XmlIgnore]
        public GMareTile[,] Tiles
        {
            get { return _tiles; }
            set { _tiles = value; }
        }

        /// <summary>
        /// XML conversion doesn't support 2d arrays, use jagged arrays instead
        /// </summary>
        [XmlArrayItemAttribute("Tiles", typeof(GMareTile[]), IsNullable=false)]
        public GMareTile[][] XMLTiles
        {
            get
            {
                // If tiles are empty, return null
                if (_tiles == null)
                    return null;

                // Convert 2d tile array to a jagged array for XML serialization
                GMareTile[][] tiles = new GMareTile[_tiles.GetLength(1)][];

                for (int i = 0; i < _tiles.GetLength(1); i++)
                    tiles[i] = new GMareTile[_tiles.GetLength(0)];

                for (int y = 0; y < _tiles.GetLength(1); y++)
                    for (int x = 0; x < _tiles.GetLength(0); x++)
                        tiles[y][x] = _tiles[x, y];

                return tiles;
            }
            set
            {
                // If tiles are empty, return null
                if (value == null)
                    _tiles = null;
                else
                {
                    // Create an array of tiles
                    _tiles = new GMareTile[value[0].Length, value.Length];

                    // Convert jagged array to 2d tile array for XML deserialization
                    for (int y = 0; y < value.Length; y++)
                        for (int x = 0; x < value[y].Length; x++)
                            _tiles[x, y] = value[y][x];
                }
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new GMare Layer
        /// </summary>
        public GMareLayer()
        {
        }

        /// <summary>
        /// Constructs a new GMare Layer, with size data
        /// </summary>
        /// <param name="cols">Number of columns</param>
        /// <param name="rows">Number of rows</param>
        public GMareLayer(int cols, int rows)
        {
            // Set empty tiles
            _tiles = GetEmptyLayer(cols, rows);
        }

        /// <summary>
        /// Constructs a new GMare Layer, with name, depth and tile data
        /// </summary>
        /// <param name="name">The name of the layer</param>
        /// <param name="depth">The depth of the layer</param>
        /// <param name="tiles">The tiles for the layer</param>
        public GMareLayer(string name, int depth, GMareTile[,] tiles)
        {
            // Set fields
            _name = name;
            _depth = depth;
            _tiles = new GMareTile[tiles.GetLength(0), tiles.GetLength(1)];

            // Iterate through tiles
            for (int y = 0; y < _tiles.GetLength(1); y++)
                for (int x = 0; x < _tiles.GetLength(0); x++)
                    _tiles[x, y] = tiles[x, y].Clone();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Makes a new copy of this layer
        /// </summary>
        /// <returns>A new layer copy</returns>
        public GMareLayer Clone()
        {
            GMareLayer layer = (GMareLayer)this.MemberwiseClone();
            GMareTile[,] tiles = new GMareTile[_tiles.GetLength(0), _tiles.GetLength(1)];

            // Deep clone
            for (int x = 0; x < _tiles.GetLength(0); x++)
                for (int y = 0; y < _tiles.GetLength(1); y++)
                    tiles[x, y] = _tiles[x, y].Clone();

            layer.Tiles = tiles;
            return layer;
        }

        /// <summary>
        /// Creates an empty layer of tiles where all tile ids are empty (-1)
        /// </summary>
        /// <<param name="cols">The number of columns</param>
        /// <param name="rows">The number of rows</param>
        /// <returns>An empty array</returns>
        public static GMareTile[,] GetEmptyLayer(int cols, int rows)
        {
            // Create a new tile array
            GMareTile[,] tiles = new GMareTile[cols, rows];

            // Iterate through and create tiles
            for (int col = 0; col < cols; col++)
                for (int row = 0; row < rows; row++)
                    tiles[col, row] = new GMareTile();

            // Return an empty array of tiles
            return tiles;
        }

        /// <summary>
        /// Clears all the tiles from the layer
        /// </summary>
        public void Clear()
        {
            // If no tiles exist, return
            if (_tiles == null)
                return;

            // Get column and row counts
            int cols = _tiles.GetLength(0);
            int rows = _tiles.GetLength(1);

            // Iterate through and create tiles
            for (int col = 0; col < cols; col++)
                for (int row = 0; row < rows; row++)
                    _tiles[col, row] = new GMareTile();
        }

        /// <summary>
        /// Shifts the tiles up in the desired amount
        /// </summary>
        /// <param name="direction">The direction to shift the tiles</param>
        /// <param name="amount">The amount of tiles to shift</param>
        public void Shift(ShiftDirectionType direction, int amount)
        {
            // Create a new set of tiles
            GMareTile[,] tiles = GetEmptyLayer(_tiles.GetLength(0), _tiles.GetLength(1));

            // Iterate through columns
            for (int col = 0; col < tiles.GetLength(0); col++)
            {
                // Iterate through rows
                for (int row = 0; row < tiles.GetLength(1); row++)
                {
                    int target = 0;

                    // Calculate offset
                    switch (direction)
                    {
                        // Shift up
                        case ShiftDirectionType.Up:
                            // Calculate offset
                            target = row + amount;

                            // If the target is not out of bounds
                            if (target < _tiles.GetLength(1))
                                tiles[col, row] = _tiles[col, target].Clone();
                            break;

                        // Shift right
                        case ShiftDirectionType.Right:
                            // Calculate offset
                            target = col + amount;

                            // If the target is not out of bounds
                            if (target < _tiles.GetLength(0))
                                tiles[target, row] = _tiles[col, row].Clone();
                            break;

                        // Shift down
                        case ShiftDirectionType.Down:
                            // Calculate offset
                            target = row + amount;

                            // If the target is not out of bounds
                            if (target < _tiles.GetLength(1))
                                tiles[col, target] = _tiles[col, row].Clone();
                            break;

                        // Shift left
                        case ShiftDirectionType.Left:
                            // Calculate offset
                            target = col + amount;

                            // If the target is not out of bounds
                            if (target < _tiles.GetLength(0))
                                tiles[col, row] = _tiles[target, row].Clone();
                            break;
                    }
                }
            }

            // Set the tiles to the new shifted tiles
            _tiles = tiles;
        }

        /// <summary>
        /// Replaces the target tile id with the desired tile id
        /// </summary>
        /// <param name="target">The target tile id to swap</param>
        /// <param name="replacement">The replacement tile id to replace the target</param>
        public void Replace(int target, int replacement)
        {
            // Iterate through tiles, if the iterated tile id matches the target, swap
            for (int col = 0; col < _tiles.GetLength(0); col++)
                for (int row = 0; row < _tiles.GetLength(1); row++)
                    if (_tiles[col, row].TileId == target)
                        _tiles[col, row].TileId = replacement;
        }

        /// <summary>
        /// Replace the target tile grid tile ids with the desired tile id
        /// </summary>
        /// <param name="target">The target tile grid to swap</param>
        /// <param name="replacement">The replacement tile id to replace the target</param>
        public void Replace(GMareBrush target, int replacement)
        {
            // Iterate through tiles, if the iterated tile id matches the target, swap
            for (int col = 0; col < target.Tiles.GetLength(0); col++)
                for (int row = 0; row < target.Tiles.GetLength(1); row++)
                    Replace(target.Tiles[col, row].TileId, replacement);
        }

        /// <summary>
        /// Replaces the target tile grid tile ids with the desired tile grid ids
        /// </summary>
        /// <param name="targets">The target tile grid to swap</param>
        /// <param name="replacements">The replacement tile grid to replace the target</param>
        public void Replace(int[] targets, int[] replacements)
        {
            // If the source and target sizes are not the same return
            if (targets.Length != replacements.Length)
                return;

            // NOTE: This method avoids potenial problems with multiple tile id swapping.
            // If, lets say, the first tile id 6 is replaced with 8, that could lead to issues
            // because if an 8 is replaced at a later position, it would replace those former 6s
            // out with an unexpected value

            // Create a new list of point lists
            List<List<Point>> lists = new List<List<Point>>();

            // Iterate through tile ids in target array
            foreach (int id in targets)
            {
                // Create a new point list
                List<Point> points = new List<Point>();

                // Iterate through layer columns, if the iterated tile id matches the target, add point
                for (int x = 0; x < _tiles.GetLength(0); x++)
                    for (int y = 0; y < _tiles.GetLength(1); y++)
                        if (_tiles[x, y].TileId == id && !(_tiles[x, y].TileId == -1 && id == -1))
                            points.Add(new Point(x, y));

                // Add point list
                lists.Add(points);
            }

            // Iterate through point lists, replace tile id
            for (int i = 0; i < lists.Count; i++)
                foreach (Point point in lists[i])
                    _tiles[point.X, point.Y].TileId = replacements[i];
        }

        /// <summary>
        /// Fills in tile sections with the desired tile
        /// </summary>
        /// <param name="origin">The starting point for the fill, in tiles</param>
        /// <param name="tileId">The tile id to fill with</param>
        public void Fill(Point origin, int tileId)
        {
            // Create a new array of tiles
            GMareTile[,] tiles = new GMareTile[1, 1];
            tiles[0, 0] = new GMareTile();
            tiles[0, 0].TileId = tileId;

            // Fill with tile array
            Fill(origin, tiles);
        }

        /// <summary>
        /// Fills in tile sections with the desired brush
        /// </summary>
        /// <param name="origin">The starting point for the fill, in tiles</param>
        /// <param name="tiles">The array of tiles to fill with</param>
        public void Fill(Point origin, GMareTile[,] tiles)
        {
            // If the origin is out of bounds, return
            if (origin.X < 0 || origin.X >= _tiles.GetLength(0) || origin.Y < 0 || origin.Y >= _tiles.GetLength(1))
                return;

            // Get target tile
            int target = _tiles[origin.X, origin.Y].TileId;

            // Get the valid fill array
            bool[,] mask = this.GetFillMask(origin, target);

            // Calculate fill start offsets
            int offsetX = origin.X % tiles.GetLength(0);
            int offsetY = origin.Y % tiles.GetLength(1);

            // If the offsetX is not zero, adjust offsetX origin
            if (offsetX != 0)
                offsetX = tiles.GetLength(0) - offsetX;

            // If the offsetY is not zero, adjust offsetY origin
            if (offsetY != 0)
                offsetY = tiles.GetLength(1) - offsetY;

            // Selection indexers, start them at the offsets
            int x = offsetX;
            int y = offsetY;

            // Iterate through layer columns
            for (int col = 0; col < _tiles.GetLength(0); col++)
            {
                // Iterate through layer rows
                for (int row = 0; row < _tiles.GetLength(1); row++)
                {
                    // If the coordinate values are allowed by the mask and equal the target, replace the tile
                    if (mask[col, row] == true && _tiles[col, row].TileId == target)
                        _tiles[col, row] = tiles[x, y].Clone();

                    // Increment selection's row index
                    y++;

                    // If at the max height of the tile selection, reset row index
                    if (y == tiles.GetLength(1))
                        y = 0;

                    // If at the max height of the layer, reset row index to offsetY
                    if (row == _tiles.GetLength(1) - 1)
                        y = offsetY;
                }

                // Increment selection's column index
                x++;

                // If at the max width of the tile selection, reset column index
                if (x == tiles.GetLength(0))
                    x = 0;

                // If at the max width of the layer, reset column index to offsetX
                if (col == _tiles.GetLength(0) - 1)
                    x = offsetX;
            }
        }

        /// <summary>
        /// Gets an array of booleans that represents a valid fill area
        /// </summary>
        /// <param name="origin">The starting point for the fill, in tiles</param>
        /// <param name="target">The target that will be compared</param>
        /// <returns>The valid fill area of a layer</returns>
        private bool[,] GetFillMask(Point origin, int target)
        {
            // Create an array of booleans
            bool[,] mask = new bool[_tiles.GetLength(0), _tiles.GetLength(1)];

            // Iterate through columns and rows, set them all to false
            for (int col = 0; col < _tiles.GetLength(0); col++)
                for (int row = 0; row < _tiles.GetLength(1); row++)
                    mask[col, row] = false;

            // Create a checks queue
            Queue checks = new Queue();

            // Add the starting check point
            checks.Enqueue(origin);

            // If there are checks left in the queue
            while (checks.Count > 0)
            {
                // Dequeue point to check
                Point check = (Point)checks.Dequeue();

                // If the check point value equals the target value
                if (_tiles[check.X, check.Y].TileId == target)
                {
                    // Create linear check points
                    int west = check.X;
                    int east = check.X;

                    // While we're not out of bounds, and the target matches the point, set west coordinate
                    while (west > -1 && _tiles[west, check.Y].TileId == target && mask[west, check.Y] == false)
                    {
                        // Deincrement west coordinate
                        west--;
                    }

                    // While we're not out of bounds, and the target matches the point, set east coordinate
                    while (east < _tiles.GetLength(0) && _tiles[east, check.Y].TileId == target && mask[east, check.Y] == false)
                    {
                        // Increment east coordinate
                        east++;
                    }

                    // Check the up and down of each filled coordinate
                    for (west++; west < east; west++)
                    {
                        // Set mask coordinate
                        mask[west, check.Y] = true;

                        // The up and down check variables
                        int up = check.Y - 1;
                        int down = check.Y + 1;

                        // If within bounds, if the tile above matches the target, and not already set, add point to queue
                        if (up > -1 && _tiles[west, up].TileId == target && mask[west, up] == false)
                            checks.Enqueue(new Point(west, check.Y - 1));

                        // If within bounds, if the tile below matches the target, and not already set, add point to queue
                        if (down < _tiles.GetLength(1) && _tiles[west, down].TileId == target && mask[west, down] == false)
                            checks.Enqueue(new Point(west, check.Y + 1));
                    }
                }
            }

            // Return the valid fill area
            return mask;
        }

        /// <summary>
        /// Gets an image of the layer
        /// </summary>
        /// <param name="background">Background to draw with</param>
        /// <param name="backgroundImage">The image of the background</param>
        /// <returns></returns>
        public Bitmap GetLayerImage(GMareBackground background, Bitmap backgroundImage, float alpha)
        {
            // If the background or background image is empty, return
            if (background == null || backgroundImage == null)
                return null;

            // Get tile and layer size
            Size tileSize = background.TileSize;
            Size layerSize = new Size(_tiles.GetLength(0) * tileSize.Width, _tiles.GetLength(1) * tileSize.Height);

            // Create a bitmap the size of the room
            Bitmap image = new Bitmap(layerSize.Width, layerSize.Height, PixelFormat.Format32bppArgb);
            System.Drawing.Graphics gfx = System.Drawing.Graphics.FromImage(image);

            // Calculate rows and columns
            int cols = layerSize.Width / tileSize.Width;
            int rows = layerSize.Height / tileSize.Height;

            // Destination rectangle
            Rectangle dest = Rectangle.Empty;
            dest.Width = tileSize.Width;
            dest.Height = tileSize.Height;

            // Source rectangle
            Rectangle source = Rectangle.Empty;
            source.Width = tileSize.Width;
            source.Height = tileSize.Height;

            // Iterate through columns
            for (int col = 0; col < cols; col++)
            {
                // Iterate through rows
                for (int row = 0; row < rows; row++)
                {
                    // Get tile id
                    int tileId = _tiles[col, row].TileId;

                    // If the tile is empty, continue looping
                    if (tileId == -1)
                        continue;

                    // Calculate destination rectangle
                    dest.X = col * tileSize.Width;
                    dest.Y = row * tileSize.Height;

                    // Calculate source point
                    source.Location = GMareBrush.TileIdToPosition(tileId, backgroundImage.Width, tileSize);

                    // Get tile
                    Bitmap temp = Graphics.PixelMap.PixelDataToBitmap(Graphics.PixelMap.GetPixels(backgroundImage, source));

                    // Get converted blend color
                    Color color = _tiles[col, row].Blend;
                    float red = color.R / 255.0f;
                    float green = color.G / 255.0f;
                    float blue = color.B / 255.0f;

                    // Alpha changing color matrix
                    ColorMatrix cm = new ColorMatrix(new float[][] {
                                    new float[]{ red, 0.0f, 0.0f, 0.0f, 0.0f},
                                    new float[]{ 0.0f, green, 0.0f, 0.0f, 0.0f},
                                    new float[]{ 0.0f, 0.0f, blue, 0.0f, 0.0f},
                                    new float[]{ 0.0f, 0.0f, 0.0f, alpha, 0.0f},
                                    new float[]{ 0.0f, 0.0f, 0.0f, 0.0f, 1.0f} });

                    // Create new image attributes
                    ImageAttributes ia = new ImageAttributes();
                    ia.SetColorMatrix(cm);

                    // Flip tile
                    switch (_tiles[col, row].FlipMode)
                    {
                        case FlipType.Horizontal: temp.RotateFlip(RotateFlipType.RotateNoneFlipX); break;
                        case FlipType.Vertical: temp.RotateFlip(RotateFlipType.RotateNoneFlipY); break;
                        case FlipType.Both: temp.RotateFlip(RotateFlipType.RotateNoneFlipX); temp.RotateFlip(RotateFlipType.RotateNoneFlipY); break;
                    }

                    // Draw the image to the bitmap
                    gfx.DrawImage(temp, dest, 0, 0, tileSize.Width, tileSize.Height, GraphicsUnit.Pixel, ia);

                    // Dispose of things
                    temp.Dispose();
                    ia.Dispose();
                }
            }

            // Return layer image
            return image;
        }

        /// <summary>
        /// Combines tile ids into Game Maker type tiles for exporting
        /// </summary>
        /// <param name="background">Background used for calculations</param>
        /// <param name="forBinary">If for binary export, which uses flipping and blend color data</param>
        /// <returns>An array of binary tiles</returns>
        public ExportTile[] GetExportTiles(GMareBackground background, bool forBinary, int lastId)
        {
            // If the background is empty or background image is empty, return
            if (background == null || background.Image == null)
                return null;

            // A boolean 2D array that keeps track of tiles that have been processed
            bool[,] parsed = new bool[_tiles.GetLength(0), _tiles.GetLength(1)];

            // A list of optimized rectangles
            List<ExportTile> tiles = new List<ExportTile>();

            // Get the tile size and background size in columns and rows
            Size tileSize = background.TileSize;
            Size backgroundSize = background.GetGridSize();

            // Iterate through tiles
            for (int y = 0; y < _tiles.GetLength(1); y++)
            {
                for (int x = 0; x < _tiles.GetLength(0); x++)
                {
                    // If this tile has already been parsed or the tile id is empty, continue
                    if (parsed[x, y] == true || _tiles[x, y].TileId == -1)
                    {
                        parsed[x, y] = true;
                        continue;
                    }

                    // Get indexed tile's id, flipmode, and blend color. Set columns count
                    int id = _tiles[x, y].TileId;
                    FlipType flipMode = _tiles[x, y].FlipMode;
                    Color blendColor = _tiles[x, y].Blend;
                    int cols = 0;

                    // Get the tile id's location on the background
                    Point location = background.TileIdToPosition(id);

                    // Check horizontally for sequential tile ids
                    for (int col = x; col < _tiles.GetLength(0); col++)
                    {
                        // If the next tile id across is not a sequential id or not the same flip mode or not the same blend, break
                        if (forBinary && (_tiles[col, y].TileId != id || _tiles[col, y].FlipMode != flipMode || _tiles[col, y].Blend != blendColor))
                            break;
                        else if (!forBinary && (_tiles[col, y].TileId != id))
                            break;

                        // Increment the column index, set increment for id
                        cols++;
                        id++;
                    }

                    // Reset id, set rows count
                    id = _tiles[x, y].TileId;
                    int rows = 0;

                    // Check vertically for sequential tile ids
                    for (int row = y; row < _tiles.GetLength(1); row++)
                    {
                        // If the next tile id across is not a sequential id or not the same flip mode or not the same blend, break
                        if (forBinary && (_tiles[x, row].TileId != id || _tiles[x, row].FlipMode != flipMode || _tiles[x, row].Blend != blendColor))
                            break;
                        else if (!forBinary && (_tiles[x, row].TileId != id))
                            break;

                        // Local variables
                        int col2 = x;
                        int id2 = id;

                        // Check columns on this row for sequential tile ids
                        while (col2 != (x + cols))
                        {
                            // If the next tile id across is not a sequential id or not the same flip mode or not the same blend, break
                            if (forBinary && (_tiles[col2, row].TileId != id2 || _tiles[col2, row].FlipMode != flipMode || _tiles[col2, row].Blend != blendColor))
                                break;
                            else if (!forBinary && (_tiles[col2, row].TileId != id2))
                                break;

                            // Increment column index and id for sequential checking
                            col2++;
                            id2++;
                        }

                        // If the row is not sequential, break
                        if (col2 != (x + cols))
                            break;

                        // Increment the row index, set increment for id
                        rows++;
                        id += backgroundSize.Width;
                    }

                    // Set parsed flags
                    for (int j = y; j < y + rows; j++)
                        for (int i = x; i < x + cols; i++)
                            parsed[i, j] = true;

                    // Create a new rectangle
                    Rectangle rect = new Rectangle(x * tileSize.Width, y * tileSize.Height, cols * tileSize.Width, rows * tileSize.Height);

                    // Add calculated rectangle
                    ExportTile tile = new ExportTile(++lastId, location, rect, background.GameMakerId, background.Name, _depth, flipMode, blendColor);
                    tiles.Add(tile);
                }
            }

            // Return a list of copy rectangles
            return tiles.ToArray();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Create our own string
        /// </summary>
        /// <returns>The name and depth string combined</returns>
        public override string ToString()
        {
            return _name + " (" + Depth.ToString() + ")";
        }

        #endregion
    }

    /// <summary>
    /// Background class that defines tileset data
    /// </summary>
    [Serializable]
    public class GMareBackground
    {
        #region Fields

        private static int _index = -1;  // The unique id for each background
        private PixelMap _image = null;  // The background pixel map of the room
        private string _name = "";       // Background name
        private int _id = -1;            // Background id
        private int _gmId = -1;          // Game Maker background resource
        private int _tileWidth = 16;     // The width of a single tile
        private int _tileHeight = 16;    // The height of a single tile
        private int _separationX = 0;    // The horizontal tile separation
        private int _separationY = 0;    // The vertical tile separation
        private int _offsetX = 0;        // The horizontal tile offset
        private int _offsetY = 0;        // The vertical tile offset

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the background pixel map of the room
        /// </summary>
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        /// <summary>
        /// Gets or sets the background pixel map of the room
        /// </summary>
        [XmlIgnore]
        public PixelMap Image
        {
            get { return _image; }
            set { _image = value; }
        }

        /// <summary>
        /// XML conversion doesn't support image data, use byte array instead
        /// </summary>
        [XmlElement("Image")]
        public byte[] XMLImage
        {
            get
            {
                // If the image is empty, return null
                if (_image == null)
                    return null;
                
                // Copy the bitmap into memory, return byte array
                using (MemoryStream ms = new MemoryStream())
                {
                    _image.ToBitmap().Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }
            }
            set
            {
                // If value is empty, set the image to null
                if (value == null)
                    _image = null;
                else
                {
                    // Copy the bitmap data into memory, create a pixel map from data
                    using (MemoryStream ms = new MemoryStream(value))
                    {
                        Bitmap test = new Bitmap(ms);
                        _image = new PixelMap(test);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the Game Maker background name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets the unique id of this background
        /// </summary>
        public int Id
        {
            get { return _id; }
        }

        /// <summary>
        /// Gets or sets the Game Maker background resource id
        /// </summary>
        public int GameMakerId
        {
            get { return _gmId; }
            set { _gmId = value; }
        }

        /// <summary>
        /// Gets or sets the tile width
        /// </summary>
        public int TileWidth
        {
            get { return _tileWidth; }
            set { _tileWidth = value; }
        }

        /// <summary>
        /// Gets or sets the tile height
        /// </summary>
        public int TileHeight
        {
            get { return _tileHeight; }
            set { _tileHeight = value; }
        }

        /// <summary>
        /// Gets the tile size
        /// </summary>
        public Size TileSize
        {
            get { return new Size(_tileWidth, _tileHeight); }
        }

        /// <summary>
        ///  Gets or sets tile offset horizontally
        /// </summary>
        public int OffsetX
        {
            get { return _offsetX; }
            set { _offsetX = value; }
        }

        /// <summary>
        /// Gets or sets tile offset vertically
        /// </summary>
        public int OffsetY
        {
            get { return _offsetY; }
            set { _offsetY = value; }
        }

        /// <summary>
        /// Gets or sets tile seperation horizontally
        /// </summary>
        public int SeparationX
        {
            get { return _separationX; }
            set { _separationX = value; }
        }

        /// <summary>
        /// Gets or sets tile seperation vertically
        /// </summary>
        public int SeparationY
        {
            get { return _separationY; }
            set { _separationY = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new background resource
        /// </summary>
        public GMareBackground()
        {
            _index++;      // Increment indexer
            _id = _index;  // Set id of new resource
        }

        #endregion

        #region Methods

        /// <summary>
        /// Makes a new copy of this background
        /// </summary>
        /// <returns>A new background copy</returns>
        public GMareBackground Clone()
        {
            GMareBackground background = (GMareBackground)this.MemberwiseClone();
            background.Image = _image == null ? null : _image.Clone();
            return background;
        }

        /// <summary>
        /// Compares a given background against this background
        /// </summary>
        /// <param name="background">The background to compare this background with</param>
        /// <returns>If the backgrounds are the same</returns>
        public bool Same(GMareBackground background)
        {
            // If the backgrounds do not match
            if (background.GameMakerId != _gmId ||
                background.TileWidth != _tileWidth ||
                background.TileHeight != _tileHeight ||
                background.SeparationX != _separationX ||
                background.SeparationY != _separationY ||
                background.OffsetX != _offsetX ||
                background.OffsetY != _offsetY ||
                PixelMap.Same(background.Image, _image) == false
            )
                return false;

            // The backgrounds are identical
            return true;
        }

        /// <summary>
        /// Compares the given background's tile settings and dimensions to this background (Actual pixel data is ignored)
        /// </summary>
        /// <param name="background">The background to compare this background with</param>
        /// <returns>If the backgrounds are the same</returns>
        public bool SameSimple(GMareBackground background)
        {
            // If the background does not exist
            if (background == null || background.Image == null)
                return false;

            // If the backgrounds do not match
            if (background.TileWidth != _tileWidth ||
                background.TileHeight != _tileHeight ||
                background.SeparationX != _separationX ||
                background.SeparationY != _separationY ||
                background.OffsetX != _offsetX ||
                background.OffsetY != _offsetY ||
                background.Image.Width != _image.Width ||
                background.Image.Height != _image.Height
            )
                return false;

            // The backgrounds are identical
            return true;
        }

        /// <summary>
        /// Gets the column and row size of the background image, takes into consideration the tile size, offset and separation values
        /// </summary>
        public Size GetGridSize()
        {
            // If the background image is empty, return null
            if (_image == null)
                return Size.Empty;

            // Get the background image and options
            Size offset = new Size(_offsetX, _offsetY);
            Size tileSize = new Size(_tileWidth, _tileHeight);
            Size separation = new Size(_separationX, _separationY);

            // Calculate row and column amounts
            int cols = (int)Math.Floor((double)(_image.Width) / (double)(tileSize.Width + separation.Width));
            int rows = (int)Math.Floor((double)(_image.Height) / (double)(tileSize.Height + separation.Height));
            int actualCols = 0;
            int actualRows = 0;

            // Iterate through vertical tiles
            for (int row = 0; row < rows; row++)
            {
                // Iterate through horizontal tiles
                for (int col = 0; col < cols; col++)
                {
                    // Get position coordinates
                    int x = (int)(double)(col * tileSize.Width + col * separation.Width) + offset.Width;
                    int y = (int)(double)(row * tileSize.Height + row * separation.Height) + offset.Height;

                    // Get the cell
                    Rectangle cell = new Rectangle(x, y, tileSize.Width - 1, tileSize.Height - 1);

                    // If the cell is not out of bounds
                    if (row == 0 && cell.Right + 1 <= Image.Width)
                        actualCols++;

                    if (col == 0 && cell.Bottom + 1 <= Image.Height)
                        actualRows++;
                }
            }

            return new Size(actualCols, actualRows);
        }

        /// <summary>
        /// Creates a point from a tile id, takes into consideration the tile size, offset and separation values
        /// </summary>
        /// <param name="tileId">The tile id to calculate the position of</param>
        /// <returns>The tile id's position</returns>
        public Point TileIdToPosition(int tileId)
        {
            // If the background image is empty, return null
            if (_image == null)
                return Point.Empty;

            // Calculate position of a tile id
            Size grid = GetGridSize();
            int x = (tileId - (tileId / grid.Width) * grid.Width) * _tileWidth;
            int y = (tileId / grid.Width) * _tileHeight;
            x += ((x / _tileWidth) * _separationX) + _offsetX;
            y += ((y / _tileHeight) * _separationY) + _offsetY;

            // Return the position of the tile id
            return new Point(x, y);
        }

        /// <summary>
        /// Gets a bitmap condensed by background tile options
        /// </summary>
        public Bitmap GetCondensedTileset()
        {
            // If the background image is empty, return null
            if (_image == null)
                return null;

            // Get the background image and options
            Bitmap image = _image.ToBitmap();
            Size offset = new Size(_offsetX, _offsetY);
            Size tileSize = new Size(_tileWidth, _tileHeight);
            Size separation = new Size(_separationX, _separationY);

            // Calculate row and column amounts
            Size grid = GetGridSize();
            int cols = grid.Width;
            int rows = grid.Height;
            int width = cols * tileSize.Width;
            int height = rows * tileSize.Height;

            // Create a new bitmap
            Bitmap temp = new Bitmap(width, height, image.PixelFormat);
            System.Drawing.Graphics gfx = System.Drawing.Graphics.FromImage(temp);

            // Iterate through columns
            for (int col = 0; col < cols; col++)
            {
                // Iterate through rows
                for (int row = 0; row < rows; row++)
                {
                    // Get source rectangle
                    Rectangle source = new Rectangle();
                    source.X = (int)(double)(col * tileSize.Width + col * separation.Width) + offset.Width;
                    source.Y = (int)(double)(row * tileSize.Height + row * separation.Height) + offset.Height;
                    source.Width = tileSize.Width;
                    source.Height = tileSize.Height;

                    // Draw tile to condensed bitmap
                    gfx.DrawImageUnscaled(image.Clone(source, image.PixelFormat), col * tileSize.Width, row * tileSize.Height);
                }
            }

            // Dispose of graphics object
            gfx.Dispose();

            // Get shallow copy of bitmap
            image = (Bitmap)temp.Clone();

            // Dispose of temporary bitmap
            temp.Dispose();

            // If the background uses a color key, set transparency color
            if (_image.UseKey == true)
                image.MakeTransparent(_image.ColorKey);

            // Return the converted tileset
            return image;
        }

        /// <summary>
        /// Gets a segmented tileset from the background
        /// </summary>
        /// <param name="space">The amount of space between tiles</param>
        /// <returns>A segmented tileset.</returns>
        public Bitmap GetSegmentedTileset(int space)
        {
            // If the background is empty, return null
            if (_image == null)
                return null;

            // Get the background image
            Bitmap image = _image.ToBitmap();
            Pen pen = new Pen(new SolidBrush(Color.Black));
            pen.Width = space;

            // Calculate row and column amounts
            int cols = (int)Math.Floor((double)(image.Width - _offsetX) / (double)(_tileWidth + _separationX));
            int rows = (int)Math.Floor((double)(image.Height - _offsetY) / (double)(_tileHeight + _separationY));
            int width = (cols * _tileWidth) + (space * cols) + space;
            int height = (rows * _tileHeight) + (space * rows) + space;

            // Create a new bitmap
            Bitmap temp = new Bitmap(width, height, image.PixelFormat);
            System.Drawing.Graphics gfx = System.Drawing.Graphics.FromImage(temp);

            // Iterate through columns
            for (int col = 0; col < cols; col++)
            {
                // Iterate through rows
                for (int row = 0; row < rows; row++)
                {
                    // Get source rectangle
                    Rectangle source = new Rectangle();
                    source.X = (int)(double)(col * _tileWidth + col * _separationX) + _offsetX;
                    source.Y = (int)(double)(row * _tileHeight + row * _separationY) + _offsetY;
                    source.Width = _tileWidth;
                    source.Height = _tileHeight;

                    Point dest = new Point(col * _tileWidth, row * _tileHeight);
                    int offsetX = (col * space) + space;
                    int offsetY = (row * space) + space;
                    Rectangle rect = new Rectangle(dest.X + (col * space), dest.Y + (row * space), _tileWidth + space, _tileHeight + space);

                    // Draw segmented bitmap
                    gfx.FillRectangle(System.Drawing.Brushes.White, rect);
                    gfx.DrawRectangle(pen, rect);
                    gfx.DrawImageUnscaled(image.Clone(source, image.PixelFormat), dest.X + offsetX, dest.Y + offsetY);
                }
            }

            // Dispose of graphics object
            gfx.Dispose();

            // Get shallow copy of bitmap
            image = (Bitmap)temp.Clone();

            // Dispose of temporary bitmap
            temp.Dispose();

            // If the background uses a color key, set transparency color
            if (_image.UseKey == true)
                image.MakeTransparent(_image.ColorKey);

            // Return the converted tileset
            return image;
        }

        #endregion
    }

    /// <summary>
    /// Tile class that defines tile data
    /// </summary>
    [Serializable]
    public class GMareTile
    {
        #region Fields

        private Color _blend = Color.White;      // The blend color
        private FlipType _flip = FlipType.None;  // Flip mode
        private int _tileId = -1;                // The source tile id
        private int _backgroundId = -1;          // Background id used for this tile

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the blend color of the tile
        /// </summary>
        [XmlIgnore]
        public Color Blend
        {
            get { return _blend; }
            set { _blend = value; }
        }

        /// <summary>
        /// XML conversion doesn't support color data, use integer instead
        /// </summary>
        [XmlElement("Blend")]
        public int XMLBlend
        {
            get { return _blend.ToArgb(); }
            set { _blend = Color.FromArgb(value); }
        }

        /// <summary>
        /// Gets or sets the source tile from a background
        /// </summary>
        public int TileId
        {
            get { return _tileId; }
            set { _tileId = value; }
        }

        /// <summary>
        /// Gets or sets the background id to copy from
        /// </summary>
        public int BackgroundId
        {
            get { return _backgroundId; }
            set { _backgroundId = value; }
        }

        /// <summary>
        /// Gets or sets the horizontal scale factor of the tile
        /// </summary>
        public FlipType FlipMode
        {
            get { return _flip; }
            set { _flip = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Makes a new copy of this tile
        /// </summary>
        /// <returns>A new tile copy</returns>
        public GMareTile Clone()
        {
            return (GMareTile)this.MemberwiseClone();
        }

        /// <summary>
        /// Converts the flipping data to a scale point
        /// </summary>
        /// <returns>A converted flip point</returns>
        public PointF GetScale()
        {
            // Create a new point
            PointF point = new PointF(1.0f, 1.0f);

            // Set flipping data
            switch (_flip)
            {
                case FlipType.None: break;
                case FlipType.Horizontal: point.X = -1.0f; break;
                case FlipType.Vertical: point.Y = -1.0f; break;
                case FlipType.Both: point.X = -1.0f; point.Y = -1.0f; break;
            }

            // Return converted data point
            return point;
        }

        /// <summary>
        /// Sets the tiles flipping mode
        /// </summary>
        /// <param name="direction">The desired direction to flip</param>
        public void Flip(FlipDirectionType direction)
        {
            // Set flipping enumeration
            switch (_flip)
            {
                case FlipType.None:
                    // If flipping horizontally
                    if (direction == FlipDirectionType.Horizontal)
                        _flip = FlipType.Horizontal;
                    else
                        _flip = FlipType.Vertical;
                    
                    break;

                case FlipType.Horizontal:
                    // If flipping horizontally
                    if (direction == FlipDirectionType.Horizontal)
                        _flip = FlipType.None;
                    else
                        _flip = FlipType.Both;

                    break;

                case FlipType.Vertical:
                    // If flipping horizontally
                    if (direction == FlipDirectionType.Horizontal)
                        _flip = FlipType.Both;
                    else
                        _flip = FlipType.None;
                    
                    break;

                case FlipType.Both:
                    // If flipping horizontally
                    if (direction == FlipDirectionType.Horizontal)
                        _flip = FlipType.Vertical;
                    else
                        _flip = FlipType.Horizontal;
                    
                    break;
            }
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Overrides to string
        /// </summary>
        /// <returns>A string representing a tile object</returns>
        public override string ToString()
        {
            return "Tile Id: " + _tileId + " | Flip Mode: " + _flip.ToString();
        }

        #endregion
    }

    /// <summary>
    /// A GM object reference class
    /// </summary>
    [Serializable]
    public class GMareObject
    {
        #region Fields

        private GMResource _resource = new GMResource();              // The resource id of the source object
        private PixelMap _image = null;                               // The image to represent this object
        private int _depth = 0;                                       // The object depth
        private int _sprite = -1;                                     // The sprite id
        private int _originX = 0;                                     // The horizontal offset
        private int _originY = 0;                                     // The vertical offset

        #endregion

        #region Properties

        /// <summary>
        /// Gets the resource id of this object
        /// </summary>
        [XmlIgnore]
        public GMResource Resource
        {
            get { return _resource; }
            set { _resource = value; }
        }

        /// <summary>
        /// XML conversion doesn't support complex object data, use object array instead
        /// </summary>
        [XmlElement("Resource")]
        public object[] XMLResource
        {
            get
            {
                // Create an object array to store the complex object
                object[] res = new object[3];
                res[0] =_resource.Id;
                res[1] = (string)_resource.Name.Clone();
                res[2] = _resource.LastChanged;

                return res;
            }
            set
            {
                // Set resource properties based on object array
                _resource.Id = (int)value[0];
                _resource.Name = (string)value[1];
                _resource.LastChanged = (double)value[2];
            }
        }

        /// <summary>
        /// Gets the sprite associated with this object
        /// </summary>
        [XmlIgnore]
        public PixelMap Image
        {
            get { return _image; }
            set { _image = value; }
        }

        /// <summary>
        /// XML conversion doesn't support image data, use byte array instead
        /// </summary>
        [XmlElement("Image")]
        public byte[] XMLImage
        {
            get
            {
                // If the image is empty, return null
                if (_image == null)
                    return null;

                // Copy the bitmap into memory, return byte array
                using (MemoryStream ms = new MemoryStream())
                {
                    _image.ToBitmap().Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }
            }
            set
            {
                // If value is empty, set the image to null
                if (value == null)
                    _image = null;
                else
                {
                    // Copy the bitmap data into memory, create a pixel map from data
                    using (MemoryStream ms = new MemoryStream(value))
                    {
                        Bitmap test = new Bitmap(ms);
                        _image = new PixelMap(test);
                    }
                }
            }
        }

        /// <summary>
        /// The sprite id that is used to represent this object
        /// </summary>
        public int Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

        /// <summary>
        /// The depth of the object
        /// </summary>
        public int Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }

        /// <summary>
        /// The horizontal origin of the object
        /// </summary>
        public int OriginX
        {
            get { return _originX; }
            set { _originX = value; }
        }

        /// <summary>
        /// The vertical origin of the object
        /// </summary>
        public int OriginY
        {
            get { return _originY; }
            set { _originY = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new GMare object
        /// </summary>
        public GMareObject()
        {
            _image = new PixelMap(GMare.Properties.Resources.instance);
        }

        /// <summary>
        /// Constructs a new GMare object
        /// </summary>
        public GMareObject(GMResource resource, Bitmap image, int sprite, int depth, int originX, int originY)
        {
            // If the image is not empty, use it
            if (image != null)
                _image = new PixelMap(image);
            else
                _image = new PixelMap(GMare.Properties.Resources.instance);

            // Set fields
            _resource = resource;
            _sprite = sprite;
            _depth = depth;
            _originX = originX;
            _originY = originY;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Makes a new copy of this object
        /// </summary>
        /// <returns>A new object copy</returns>
        public GMareObject Clone()
        {
            GMareObject obj = (GMareObject)this.MemberwiseClone();
            obj.Image = _image == null ? null : _image.Clone();
            return obj;
        }

        #endregion

        #region Override

        /// <summary>
        /// To string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _resource.Name;
        }

        #endregion
    }

    /// <summary>
    /// An extended GM instance class
    /// </summary>
    [Serializable]
    public class GMareInstance : GMInstance
    {
        #region Fields

        private int _tileId = -1;         // Tile id for a block instance

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the block tile id asscoiated with this instance
        /// </summary>
        public int TileId
        {
            get { return _tileId; }
            set { _tileId = value; }
        }

        /// <summary>
        /// Gets the location point of the instance within a room
        /// </summary>
        [XmlIgnore]
        
        public Point Location
        {
            get { return new Point(X, Y); }
            set { X = value.X; Y = value.Y; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new object instance
        /// </summary>
        public GMareInstance()
        {
        }

        /// <summary>
        /// Constructs a new object instance, with a tile id
        /// </summary>
        /// <param name="blockTileId">If the instance is a block instance</param>
        public GMareInstance(int tileId)
        {
            // Set properties
            _tileId = tileId;
        }

        /// <summary>
        /// Constructs a new object instance, with a tile id, and object id
        /// </summary>
        /// <param name="tileId">Block instance assigned tile id</param>
        /// <param name="objectId">The object that this is an instance of</param>
        public GMareInstance(int tileId, int objectId)
        {
            // Set properties
            _tileId = tileId;
            this.ObjectId = objectId;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Makes a new copy of this instance
        /// </summary>
        /// <returns>A new instance copy</returns>
        public GMareInstance Clone()
        {
            return (GMareInstance)this.MemberwiseClone();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// To string
        /// </summary>
        public override string ToString()
        {
            return this.ObjectName;
        }

        #endregion
    }

    /// <summary>
    /// Class that holds project data for binary export
    /// </summary>
    [Serializable]
    public class ExportProject
    {
        #region Fields

        private GMareBackground _background = new GMareBackground();
        private BinaryMethodType _methodMode = BinaryMethodType.Standard;
        private string _name = "";
        private string _roomPath = "";
        private bool _writeTiles = true;
        private bool _useFlipValues = false;
        private bool _useBlendColor = false;
        private bool _writeInstances = true;
        private bool _writeBlocks = true;
        private bool _exporting = true;
        private bool _native = false;

        #endregion

        #region Properties

        public GMareBackground Background { get { return _background; } set { _background = value; } }
        public BinaryMethodType MethodMode { get { return _methodMode; } set { _methodMode = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string RoomPath { get { return _roomPath; } set { _roomPath = value; } }
        public bool WriteTiles { get { return _writeTiles; } set { _writeTiles = value; } }
        public bool UseFlipValues { get { return _useFlipValues; } set { _useFlipValues = value; } }
        public bool UseBlendColor { get { return _useBlendColor; } set { _useBlendColor = value; } }
        public bool WriteInstances { get { return _writeInstances; } set { _writeInstances = value; } }
        public bool WriteBlocks { get { return _writeBlocks; } set { _writeBlocks = value; } }
        public bool Exporting { get { return _exporting; } set { _exporting = value; } }
        public bool Native { get { return _native; } set { _native = value; } }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new binary project
        /// </summary>
        public ExportProject()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a new copy of this project
        /// </summary>
        /// <returns>A new export project copy</returns>
        public ExportProject Clone()
        {
            ExportProject project = (ExportProject)this.MemberwiseClone();
            project.Background = _background.Clone();
            return project;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// To string
        /// </summary>
        public override string ToString()
        {
            return this.Name;
        }

        #endregion
    }

    /// <summary>
    /// A basic tile definition used for binary export
    /// </summary>
    public class ExportTile : GMTile
    {
        #region Fields

        private FlipType _flipMode = FlipType.None;  // The flip mode of the tile
        private Color _blendColor = Color.White;     // The blend color of the tile

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the location of the copy rectangle
        /// </summary>
        public Point Location { get { return new Point(BackgroundX, BackgroundY); } set { BackgroundX = value.X; BackgroundY = value.Y; } }

        /// <summary>
        /// Gets or sets the dimensions of the tile
        /// </summary>
        public Rectangle Rect { get { return new Rectangle(X, Y, Width, Height); } set { X = value.X; Y = value.Y; Width = value.Width; Height = value.Height; } }

        /// <summary>
        /// Gets or sets the flip mode of the tile
        /// </summary>
        public FlipType FlipMode { get { return _flipMode; } set { _flipMode = value; } }

        /// <summary>
        /// Gets or sets the blendcolor of the tile
        /// </summary>
        public Color BlendColor { get { return _blendColor; } set { _blendColor = value; } }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new binary tile
        /// </summary>
        public ExportTile()
        {
        }

        /// <summary>
        /// Constructs a new binary tile
        /// </summary>
        /// <param name="rect">The dimensions of the tile</param>
        /// <param name="flipMode">The flip mode of the tile</param>
        /// <param name="blendColor">The blend color of the tile</param>
        public ExportTile(int id, Point location, Rectangle rect, int background, string backgroundName, int depth, FlipType flipMode, Color blendColor)
        {
            Id = id;
            X = rect.X;
            Y = rect.Y;
            Width = rect.Width;
            Height = rect.Height;
            BackgroundX = location.X;
            BackgroundY = location.Y;
            BackgroundId = background;
            Depth = depth;
            BackgroundName = backgroundName;
            _flipMode = flipMode;
            _blendColor = blendColor;
        }

        #endregion
    }
}