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
using System.Text;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using GameMaker.Common;
using GameMaker.Resource;
using GMare.Graphics;

namespace GMare.Common
{
    /// <summary>
    /// A class that manipulates room data.
    /// </summary>
    [Serializable]
    public class GMareRoom
    {
        #region Fields

        public const int MAXDEPTH = 1000000000;                              // The maximum depth a layer can have.
        public const int MINDEPTH = -1000000000;                             // The minimum depth a layer can have.
        private List<GMareLayer> _layers = new List<GMareLayer>();           // List of layers.
        private List<GMareCollision> _shapes = new List<GMareCollision>();   // List of shapes.
        private List<GMareInstance> _instances = new List<GMareInstance>();  // List of instances.
        private List<GMareObject> _objects = new List<GMareObject>();        // List of objects.
        private List<GMareBrush> _brushes = new List<GMareBrush>();          // List of brushes.
        private GMNode[] _nodes = null;                                      // An array of object nodes.
        private PixelMap _background = null;                                 // The background pixel map of the room.
        private Color _backColor = Color.Silver;                             // Backcolor of the room.
        private string _name = "New Room";                                   // A personalized string representation.
        private int _columns = 20;                                           // The width of the room in tiles.
        private int _rows = 15;                                              // The height of the room in tiles.
        private int _tileWidth = 16;                                         // The width of a single tile.
        private int _tileHeight = 16;                                        // The height of a single tile.
        private int _seperationX = 0;                                        // The horizontal tile seperation.
        private int _seperationY = 0;                                        // The vertical tile seperation.
        private int _offsetX = 0;                                            // The horizontal tile offset.
        private int _offsetY = 0;                                            // The vertical tile offset.
        private bool _scaleWarning = true;                                   // Message on scaling.
        private bool _blendWarning = true;                                   // Message on color blending.

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the room's layers.
        /// </summary>
        public List<GMareLayer> Layers
        {
            get { return _layers; }
            set { _layers = value; }
        }

        /// <summary>
        /// Gets or sets the shapes list.
        /// </summary>
        public List<GMareCollision> Shapes
        {
            get { return _shapes; }
            set { _shapes = value; }
        }

        /// <summary>
        /// Gets or sets the objects list.
        /// </summary>
        public List<GMareObject> Objects
        {
            get { return _objects; }
            set { _objects = value; }
        }

        /// <summary>
        /// Gets or sets the instances list.
        /// </summary>
        public List<GMareInstance> Instances
        {
            get { return _instances; }
            set { _instances = value; }
        }

        /// <summary>
        /// Gets or sets the object node array.
        /// </summary>
        public GMNode[] Nodes
        {
            get { return _nodes; }
            set { _nodes = value; }
        }

        /// <summary>
        /// Gets or sets the list of saved brushes.
        /// </summary>
        public List<GMareBrush> Brushes
        {
            get { return _brushes; }
            set { _brushes = value; }
        }

        /// <summary>
        /// Gets the background pixelmap used for this room.
        /// </summary>
        public PixelMap Background
        {
            get { return _background; }
            set { _background = value; }
        }

        /// <summary>
        /// Gets or sets the back color of the room.
        /// </summary>
        public Color BackColor
        {
            get { return _backColor; }
            set { _backColor = value; }
        }

        /// <summary>
        /// Gets or sets the personalized name for the room.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets the width of the room.
        /// </summary>
        public int Width
        {
            get { return _columns * _tileWidth; }
        }

        /// <summary>
        /// Gets the height of the room.
        /// </summary>
        public int Height
        {
            get { return _rows * _tileHeight; }
        }

        /// <summary>
        /// Gets or sets the columns of the room.
        /// </summary>
        public int Columns
        {
            get { return _columns; }
            set
            {
                // Resize the tile columns.
                ResizeWidth(value);

                // Set new value.
                _columns = value;
            }
        }

        /// <summary>
        /// Gets or sets the rows of the room.
        /// </summary>
        public int Rows
        {
            get { return _rows; }
            set
            {
                // Resize the tile rows.
                ResizeHeight(value);

                // Set new value.
                _rows = value;
            }
        }

        /// <summary>
        /// Gets or sets the tile width.
        /// </summary>
        public int TileWidth
        {
            get { return _tileWidth; }
            set { _tileWidth = value; }
        }

        /// <summary>
        /// Gets or sets the tile height.
        /// </summary>
        public int TileHeight
        {
            get { return _tileHeight; }
            set { _tileHeight = value; }
        }

        /// <summary>
        /// Gets the tile size.
        /// </summary>
        public Size TileSize
        {
            get { return new Size(_tileWidth, _tileHeight); }
        }

        /// <summary>
        /// Gets the room size.
        /// </summary>
        public Size RoomSize
        {
            get { return new Size(Width, Height); }
        }

        /// <summary>
        ///  Gets or sets tile offset horizontally.
        /// </summary>
        public int OffsetX
        {
            get { return _offsetX; }
            set { _offsetX = value; }
        }

        /// <summary>
        /// Gets or sets tile offset vertically.
        /// </summary>
        public int OffsetY
        {
            get { return _offsetY; }
            set { _offsetY = value; }
        }

        /// <summary>
        /// Gets or sets tile seperation horizontally.
        /// </summary>
        public int SeparationX
        {
            get { return _seperationX; }
            set { _seperationX = value; }
        }

        /// <summary>
        /// Gets or sets tile seperation vertically.
        /// </summary>
        public int SeparationY
        {
            get { return _seperationY; }
            set { _seperationY = value; }
        }

        /// <summary>
        /// Gets or sets whether a scale warning should show.
        /// </summary>
        public bool ScaleWarning
        {
            get { return _scaleWarning; }
            set { _scaleWarning = value; }
        }

        /// <summary>
        /// Gets or sets whether a color blend warning should show.
        /// </summary>
        public bool BlendWarning
        {
            get { return _blendWarning; }
            set { _blendWarning = value; }
        }


        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new room.
        /// </summary>
        public GMareRoom(int columns, int rows, int tileWidth, int tileHeight)
        {
            // Set Properties, to auto set actual width and height.
            Columns = columns;
            Rows = rows;

            // Set tile size
            _tileWidth = tileWidth;
            _tileHeight = tileHeight;

            // Create a new layer.
            _layers.Add(new GMareLayer("Layer", 0, GMareLayer.GetEmptyLayer(columns, rows)));
        }

        /// <summary>
        /// Constructs a new room.
        /// </summary>
        public GMareRoom()
        {
        }

        #endregion

        #region Methods

        #region General

        /// <summary>
        /// Makes a shallow copy of this room.
        /// </summary>
        /// <returns>A shallow copy of this room.</returns>
        public GMareRoom Clone()
        {
            // Create a new room.
            GMareRoom room = new GMareRoom(_columns, _rows, _tileWidth, _tileHeight);

            // Clone this room.
            room.Layers.Clear();

            // Iterate through layers.
            foreach (GMareLayer layer in _layers)
                room._layers.Add(layer.Clone());

            // Iterate through instances.
            foreach (GMareInstance inst in _instances)
                room.Instances.Add(inst.Clone());

            // TODO: Clone this.
            room.Shapes.AddRange(_shapes.ToArray());

            if (_nodes != null)
                room.Nodes = (GMNode[])_nodes.Clone();

            if (_background != null)
                room.Background = _background.Clone();

            room.BackColor = _backColor;
            room.Name = (string)_name.Clone();
            room.Columns = _columns;
            room.Rows = _rows;
            room.TileWidth = _tileWidth;
            room.TileHeight = _tileHeight;
            room.SeparationX = _seperationX;
            room.SeparationY = _seperationY;
            room.OffsetX = _offsetX;
            room.OffsetY = _offsetY;

            // Return copy.
            return room;
        }

        /// <summary>
        /// Resizes all the layers to the new room width.
        /// </summary>
        private void ResizeWidth(int columns)
        {
            // If the sizes are the same, return.
            if (columns == _columns)
                return;

            // Get the amount of columns we can copy.
            int amount = columns > _columns ? _columns : columns;

            // Iterate through layers.
            for (int layer = 0; layer < _layers.Count; layer++)
            {
                // Create an empty tile array with the new size.
                GMareTile[,] array = GMareLayer.GetEmptyLayer(columns, _rows);

                // Iterate through columns.
                for (int col = 0; col < array.GetLength(0); col++)
                {
                    // Iterate through rows.
                    for (int row = 0; row < array.GetLength(1); row++)
                    {
                        // Set tile.
                        if (col < amount)
                            array[col, row].TileId = _layers[layer].Tiles2[col, row].TileId;
                        else
                            array[col, row].TileId = -1;
                    }
                }

                // Set tiles with new array.
                _layers[layer].Tiles2 = array;
            }
        }

        /// <summary>
        /// Resizes all the layers to the new room height.
        /// </summary>
        private void ResizeHeight(int rows)
        {
            // If the sizes are the same, return.
            if (rows == _rows)
                return;

            // Get the amount of rows we can copy.
            int amount = rows > _rows ? _rows : rows;

            // Iterate through layers.
            for (int layer = 0; layer < _layers.Count; layer++)
            {
                // Create an empty tile array with the new size.
                GMareTile[,] array = GMareLayer.GetEmptyLayer(_columns, rows);

                // Iterate through columns.
                for (int col = 0; col < array.GetLength(0); col++)
                {
                    // Iterate through rows.
                    for (int row = 0; row < array.GetLength(1); row++)
                    {
                        // Set tile.
                        if (row < amount)
                            array[col, row].TileId = _layers[layer].Tiles2[col, row].TileId;
                        else
                            array[col, row].TileId = -1;
                    }
                }

                // Set tiles with new array.
                _layers[layer].Tiles2 = array;
            }
        }

        /// <summary>
        /// Gets a background cut up by tile options.
        /// </summary>
        public Bitmap GetTileset()
        {
            // If the background is empty, return null.
            if (_background == null)
                return null;

            // Get the background image.
            Bitmap image = _background.ToBitmap();

            // Calculate row and column amounts.
            int cols = (int)Math.Floor((double)(image.Width - _offsetX) / (double)(_tileWidth + _seperationX));
            int rows = (int)Math.Floor((double)(image.Height - _offsetY) / (double)(_tileHeight + _seperationY));

            // Create a new bitmap.
            Bitmap temp = new Bitmap(cols * _tileWidth, rows * _tileHeight, image.PixelFormat);
            System.Drawing.Graphics gfx = System.Drawing.Graphics.FromImage(temp);

            // Iterate through columns.
            for (int col = 0; col < cols; col++)
            {
                // Iterate through rows.
                for (int row = 0; row < rows; row++)
                {
                    // Get source rectangle.
                    Rectangle source = new Rectangle();
                    source.X = (int)(double)(col * _tileWidth + col * _seperationX) + _offsetX;
                    source.Y = (int)(double)(row * _tileHeight + row * _seperationY) + _offsetY;
                    source.Width = _tileWidth;
                    source.Height = _tileHeight;

                    // Draw tile to condensed bitmap.
                    gfx.DrawImageUnscaled(image.Clone(source, image.PixelFormat), col * _tileWidth, row * _tileHeight);
                }
            }

            // Dispose of graphics object.
            gfx.Dispose();

            // Get shallow copy of bitmap.
            image = (Bitmap)temp.Clone();

            // Dispose of temporary bitmap.
            temp.Dispose();

            // If the background uses a color key, set transparency color.
            if (_background.UseKey == true)
                image.MakeTransparent(_background.ColorKey);

            // Return the converted tileset.
            return image;
        }

        /// <summary>
        /// Gets a drop down menu item array, representing an object tree.
        /// </summary>
        /// <returns>A drop down menu item array.</returns>
        public ToolStripDropDownItem[] GetMenu()
        {
            // If nodes are empty, return null;
            if (_nodes == null)
                return null;

            // A list of menus, representing GM nodes.
            List<ToolStripDropDownItem> menus = new List<ToolStripDropDownItem>();

            // Iterate through object nodes.
            foreach (GMNode node in _nodes)
            {
                // Add a menu from the node.
                menus.Add(GetMenuFromGMNode(node));
            }

            // Return the menus.
            return menus.ToArray();
        }

        /// <summary>
        /// Converts a GMNode to a drop down menu item. Stores original GM node data in tag property.
        /// </summary>
        /// <param name="node">The GMNode to convert.</param>
        /// <returns>A drop down item of the GMNode.</returns>
        private ToolStripDropDownItem GetMenuFromGMNode(GMNode node)
        {
            // Set-up tree node.
            ToolStripMenuItem menu = new ToolStripMenuItem();
            menu.Text = node.Name;
            menu.Tag = node;

            // Set dropdown menu item image.
            if (node.NodeType == GMNodeType.Group)
                menu.Image = GMare.Properties.Resources.file_close;
            else
            {
                // Get GM object based on id.
                GMareObject obj = _objects.Find(delegate(GMareObject o) { return o.Resource.Id == node.Id; });

                // If an object was found, set image.
                if (obj != null)
                    menu.Image = obj.Image;
            }

            // If no child nodes, return the top item.
            if (node.Nodes == null)
                return menu;

            // Iterate through nodes.
            for (int i = 0; i < node.Children; i++)
            {
                // Add a dropdown menu item.
                menu.DropDownItems.Add(GetMenuFromGMNode(node.Nodes[i]));
            }

            // Return a dropdown menu item.
            return menu;
        }

        #endregion

        #region Tiles

        /// <summary>
        /// Shifts room tiles in a desired direction, by a desired amount, on the desired layer.
        /// </summary>
        /// <param name="layer">The layer to shift.</param>
        /// <param name="direction">The direction to shift the tiles.</param>
        /// <param name="amount">The amount of tiles to shift.</param>
        public void Shift(GMareLayer layer, ShiftDirection direction, int amount)
        {
            // If the tile swap happens on all layers.
            if (layer == null)
            {
                // Iterate through each layer.
                foreach (GMareLayer temp in _layers)
                {
                    // Shift layer.
                    temp.Shift(direction, amount);
                }
            }
            else
            {
                // Get the index of the desired layer.
                int index = _layers.IndexOf(layer);

                // Shift layer.
                _layers[index].Shift(direction, amount);
            }
        }

        /// <summary>
        /// Creates an array of Game Maker tile objects from GMare tile ids.
        /// </summary>
        /// <param name="lastTileId">The last used tile id.</param>
        /// <param name="background">The background id used for the tile.</param>
        /// <returns>An array of Game Maker tiles.</returns>
        public GMTile[] GMareTilesToGMTiles(int lastTileId, int background, Size tileSize, int tileCols, Point offset, Point spacing)
        {
            // Create a list of Game Maker tiles.
            List<GMTile> tiles = new List<GMTile>();

            // Iterate through room layers.
            foreach (GMareLayer layer in _layers)
            {
                // Get various layer properties.
                int depth = layer.Depth;
                int cols = layer.Tiles2.GetLength(0);
                int rows = layer.Tiles2.GetLength(1);

                // Iterate through layer tile rows.
                for (int row = 0; row < rows; row++)
                {
                    // Iterate through layer tile columns.
                    for (int col = 0; col < cols; col++)
                    {
                        // Get tile id.
                        int sector = layer.Tiles2[col, row].TileId;

                        // If the tile is not empty.
                        if (sector != -1)
                        {
                            // Create a new GM tile.
                            GMTile tile = new GMTile();

                            tile.Id = lastTileId++;
                            tile.Depth = depth;
                            tile.BackgroundId = background;
                            tile.X = col * _tileWidth;
                            tile.Y = row * _tileHeight;
                            tile.Width = _tileWidth;
                            tile.Height = _tileHeight;
                            tile.BackgroundX = (sector - (int)(sector / tileCols) * tileCols) * tileSize.Width;
                            tile.BackgroundY = (int)(sector / tileCols) * tileSize.Height;
                            tile.BackgroundX += ((tile.BackgroundX / tileSize.Width) * spacing.X) + offset.X;
                            tile.BackgroundY += ((tile.BackgroundY / tileSize.Height) * spacing.Y) + offset.Y;

                            // Add the Game Maker tile to the list.
                            tiles.Add(tile);
                        }
                    }
                }
            }

            // Return the array of tiles.
            return tiles.ToArray();
        }

        /// <summary>
        /// Converts a rectangle to an array of tile ids.
        /// </summary>
        /// <param name="rectangle">The source rectangle to copy tiles from.</param>
        /// <param name="layer">The layer to copy tiles from.</param>
        /// <returns>An array fo tile ids.</returns>
        public GMareTile[] GetTiles(Rectangle rectangle, GMareLayer layer)
        {
            // If the layer does not exist, return.
            if (_layers.Contains(layer) == false)
                return null;

            // Create a new list of tiles.
            List<GMareTile> tiles = new List<GMareTile>();

            // Iterate through layer tiles.
            foreach (GMareTile tile in layer.Tiles2)
            {
                // The check rectangle.
                Rectangle rect = new Rectangle(GMareBrush.TileIdToPosition(tile.TileId, _background.Width, TileSize), TileSize);

                // Add the included tile.
                if (rectangle.Contains(rect) == true)
                    tiles.Add(tile.Clone());
            }

            // Return the array of tile ids.
            return tiles.ToArray();
        }

        #endregion

        #region Layer

        /// <summary>
        /// Gets a unique depth
        /// </summary>
        /// <returns></returns>
        public int GetUniqueDepth()
        {
            // Set the depth to the minimum depth allowed.
            int depth = MINDEPTH;

            // Iterate through layers.
            foreach (GMareLayer layer in _layers)
            {
                // If the depth is the same as the layer depth, increment the depth.
                // Else, an unique depth was found.
                if (layer.Depth == depth)
                    depth++;
                else
                    break;

                // If the depth is at the maximum allowed depth, break.
                // (Very doubtful it would ever happen) >_<
                if (depth == MAXDEPTH)
                    break;
            }

            // Return the unique depth.
            return depth;
        }

        /// <summary>
        /// Check for unique depth.
        /// </summary>
        /// <param name="depth">The depth to check.</param>
        /// <returns>Whether the depth exists already.</returns>
        public bool CheckDepth(int depth)
        {
            // Iterate through layers.
            foreach (GMareLayer layer in _layers)
            {
                // If the depth is the same as the layer depth, the depth is used already.
                if (layer.Depth == depth)
                    return true;
            }

            // The depth has not been used.
            return false;
        }

        #endregion

        #region Binary

        /// <summary>
        /// Gets the total amount of non-empty tiles.
        /// </summary>
        /// <param name="layer">The layer to count.</param>
        /// <returns>The total amount of non-empty tiles.</returns>
        public static int GetTileCount(GMareLayer layer)
        {
            // Total tile count.
            int count = 0;

            // Iterate through columns.
            for (int col = 0; col < layer.Tiles2.GetLength(0); col++)
            {
                // Iterate through rows.
                for (int row = 0; row < layer.Tiles2.GetLength(1); row++)
                {
                    // If the tile is not empty, add it to the count.
                    if (layer.Tiles2[col, row].TileId != -1)
                        count++;
                }
            }

            // Return the amount of actual tiles.
            return count;
        }

        /// <summary>
        /// Gets the total size of the room for a binary file.
        /// </summary>
        /// <param name="layers">The layers to get sizes for.</param>
        /// <returns>The size of the room  in bytes.</returns>
        public int GetBinaryRoomSize(bool useLayers, bool useScaling, bool useBlendColor, bool useInstances, bool useCollisions)
        {
            /* Size of initial room data.
             * 1 bool        Uses tile data
             * 1 bool        Uses tile flipping data
             * 1 bool        Uses blend color data
             * 1 bool        Uses instance data
             * 1 bool        Uses collision data
             * 1 short       The number of columns
             * 1 short       The number of rows
             * 1 byte        The horizontal tile offset
             * 1 byte        The vertical tile offset
             * 1 byte        The horizontal tile separation
             * 1 byte        The vertical tile separation
             * 1 byte        The size of the tile width
             * 1 byte        The size of the tile height
             * 1 short       The number of tileset columns
             * 1 int         The number of layers
             * 1 int         The number of instances
             * 1 int         The number of collisions*/

            /* Size Layer data
             * 1 int         The depth of the layer
             * 1 byte        Tile method (0 tile id, 1 tile data)
             * 1 int         If tile method is 1, write tile count.*/

            /* Size of necessary bytes for both methods.
             * 1 short       Tile id (For method 0)
             * 1 short       Tile id (For method 1)
             * 1 int         Horizontal coordinate (For method 1)
             * 1 int         Vertical coordinate (For method 1)
             * 1 byte        Tile flipping type
             * 1 int         Tile blend color*/

             /* Size of instance data.
             * 1 int         Parent object Id.
             * 1 int         Horizontal position
             * 1 int         Vertical position
             * 1 int         Number of letters in instance creation code
             * 1 char[]      The characters of the instance creation code*/

            int size = 29;
            int tiled = 0;
            int sectored = 0;

            // If calculating layer data size.
            if (useLayers == true)
            {
                // Iterate through layers.
                foreach (GMareLayer layer in _layers)
                {
                    // The number of non-empty  tiles in the layer.
                    int tileCount = GetTileCount(layer);

                    // Calculate complex method size.
                    tiled += tileCount * 10 + 9;

                    // Calculate simple method size.
                    sectored += layer.Tiles2.Length * 2 + 5;

                    // If using flipping flags data.
                    if (useScaling == true)
                    {
                        tiled += tileCount;
                        sectored += tileCount;
                    }

                    // If using blend color data.
                    if (useBlendColor == true)
                    {
                        tiled += tileCount * 4;
                        sectored += tileCount * 4;
                    }

                    // If the simple method size is bigger, add the complex method, else add simple method to total size.
                    size += sectored >= tiled ? tiled : sectored;

                    tiled = 0;
                    sectored = 0;
                }
            }

            // If calculating instance data size.
            if (useInstances == true)
            {
                // Iterate through instances.
                foreach (GMInstance instance in _instances)
                {
                    // Add instance size.
                    size += instance.CreationCode.Length + 16;
                }
            }

            // TODO: Collision data size.

            // Return the size of the layers.
            return size;
        }

        /// <summary>
        /// Tests the binary methods for the smallest size.
        /// </summary>
        /// <param name="layer">The layer to test.</param>
        /// <returns>The method to be used.</returns>
        public static BinaryMethod GetBinaryMethod(GMareLayer layer)
        {
            // Simple size = 2 (1 short (Tile Id))
            // Complex size = 10 (1 short, 2 ints (Tile Id, horizontal position, vertical position))

            // Complex method size.
            int complex = 0;
            int simple = 0;

            // Calculate complex method size.
            complex += GetTileCount(layer) * 10;

            // Calculate simple method size.
            simple += layer.Tiles2.Length * 2;

            // If the simple method size is bigger, return complex method, else return simple method.
            return simple >= complex ? BinaryMethod.Tile : BinaryMethod.Sector;
        }

        #endregion

        #region ORE

        /// <summary>
        /// Converts an Ore room to a GMare room.
        /// </summary>
        /// <param name="oreRoom">The Ore room to convert.</param>
        /// <returns>A converted Ore room.</returns>
        public static GMareRoom OreRoomToGMareRoom(OcarinaRoomEditor.Room oreRoom)
        {
            // Create a new GMare room.
            GMareRoom room = new GMareRoom();

            // Convert parts of Ore room to GMare room.
            room.BackColor = oreRoom.RoomColor;
            room.Background = new PixelMap(oreRoom.Tileset);
            room.Columns = oreRoom.Width / 16;
            room.Rows = oreRoom.Height / 16;
            room.Layers.Add(new GMareLayer("Upper Layer", -1, OreTilesToGMareTiles(oreRoom.TilesUpper, room.Columns, room.Rows)));
            room.Layers.Add(new GMareLayer("Lower Layer", 0, OreTilesToGMareTiles(oreRoom.TilesLower, room.Columns, room.Rows)));

            // TODO: Convert shapes to collisions.

            // Return converted GMare room.
            return room;
        }

        /// <summary>
        /// Converts Ore tile array to GMare tile array.
        /// </summary>
        /// <param name="oreTiles">The Ore tile array to convert.</param>
        /// <param name="cols">The amount of tiles horizontally.</param>
        /// <param name="rows">The amount of tiles vertically.</param>
        /// <returns>A converted tile array.</returns>
        private static GMareTile[,] OreTilesToGMareTiles(int[] oreTiles, int cols, int rows)
        {
            // Ore tile indexer.
            int index = 0;

            // Create a new 2d array of tiles.
            GMareTile[,] tiles = new GMareTile[cols, rows];

            // Iterate through rows.
            for (int row = 0; row < rows; row++)
            {
                // Iterate through columns.
                for (int col = 0; col < cols; col++)
                {
                    // Create new tile.
                    tiles[col, row] = new GMareTile();

                    // Set tile id.
                    tiles[col, row].TileId = oreTiles[index];

                    // Increament indexer.
                    index++;
                }
            }

            // Return converted tiles.
            return tiles;
        }

        #endregion

        #endregion

        #region Overrides

        /// <summary>
        /// Override to string.
        /// </summary>
        /// <returns>A custom string that represents the room.</returns>
        public override string ToString()
        {
            return _name;
        }

        #endregion
    }

    /// <summary>
    /// A class that manipulates tile data.
    /// </summary>
    [Serializable]
    public class GMareLayer
    {
        #region Fields

        private string _name = "Layer";       // The name of the layer.
        private int _depth = 0;               // The z order of the layer.
        private int[,] _tiles = null;         // Old tile objects.
        private GMareTile[,] _tiles2 = null;  // The tile objects of the layer.

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the layer name.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets the layer depth.
        /// </summary>
        public int Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }

        /// <summary>
        /// Gets or sets the layer's old tile ids.
        /// </summary>
        [Obsolete("Use Tiles2, simple integer tile ids are no longer used.")]
        public int[,] Tiles
        {
            get { return _tiles; }
            set { _tiles = value; }
        }

        /// <summary>
        /// Gets or sets the layer's tiles.
        /// </summary>
        public GMareTile[,] Tiles2
        {
            get { return _tiles2; }
            set { _tiles2 = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new GMare Layer, with size data.
        /// </summary>
        /// <param name="cols">Number of columns.</param>
        /// <param name="rows">Number of rows.</param>
        public GMareLayer(int cols, int rows)
        {
            // Set empty tiles.
            _tiles2 = GetEmptyLayer(cols, rows);
        }


        /// <summary>
        /// Constructs a new GMare Layer, with name, depth and tile data.
        /// </summary>
        /// <param name="name">The name of the layer.</param>
        /// <param name="depth">The depth of the layer.</param>
        /// <param name="tiles">The tiles for the layer.</param>
        public GMareLayer(string name, int depth, GMareTile[,] tiles)
        {
            // Set fields.
            _name = name;
            _depth = depth;
            _tiles2 = new GMareTile[tiles.GetLength(0), tiles.GetLength(1)];

            // Iterate through tiles.
            for (int y = 0; y < _tiles2.GetLength(1); y++)
                for (int x = 0; x < _tiles2.GetLength(0); x++)
                    _tiles2[x, y] = tiles[x, y].Clone();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets all tile values to -1, which means empty.
        /// </summary>
        /// <param name="array">The array to empty.</param>
        /// <returns>An empty array.</returns>
        public static GMareTile[,] GetEmptyLayer(int cols, int rows)
        {
            // Create a new tile array.
            GMareTile[,] tiles = new GMareTile[cols, rows];

            // Iterate through columns.
            for (int col = 0; col < cols; col++)
            {
                // Iterate through rows.
                for (int row = 0; row < rows; row++)
                {
                    // Set the tile to empty.
                    tiles[col, row] = new GMareTile();
                }
            }

            // Return an empty array of tiles.
            return tiles;
        }

        /// <summary>
        /// Makes a shallow copy of this layer.
        /// </summary>
        /// <returns>A shallow copy of this layer.</returns>
        public GMareLayer Clone()
        {
            // Create a new layer.
            GMareLayer layer = new GMareLayer(_tiles2.GetLength(0), _tiles2.GetLength(1));

            // Set data.
            layer.Name = (string)_name.Clone();
            layer.Depth = _depth;

            // Iterate through tiles.
            for (int y = 0; y < _tiles2.GetLength(1); y++)
                for (int x = 0; x < _tiles2.GetLength(0); x++)
                    layer.Tiles2[x, y] = _tiles2[x, y].Clone();

            return layer;
        }

        /// <summary>
        /// Clears all the tiles from the layer.
        /// </summary>
        public void Clear()
        {
            // If no tiles exist, return.
            if (_tiles2 == null)
                return;

            // Get column and row amounts.
            int cols = _tiles2.GetLength(0);
            int rows = _tiles2.GetLength(1);

            // Iterate through columns.
            for (int col = 0; col < cols; col++)
            {
                // Iterate through rows.
                for (int row = 0; row < rows; row++)
                {
                    // Set the tile to new empty tile.
                    _tiles2[col, row] = new GMareTile();
                }
            }
        }

        /// <summary>
        /// Shifts the tiles up in the desired amount.
        /// </summary>
        /// <param name="amount">The amount of tiles to shift.</param>
        public void Shift(ShiftDirection direction, int amount)
        {
            // Create a new set of tiles.
            GMareTile[,] tiles = GetEmptyLayer(_tiles2.GetLength(0), _tiles2.GetLength(1));

            // Iterate through columns.
            for (int col = 0; col < tiles.GetLength(0); col++)
            {
                // Iterate through rows.
                for (int row = 0; row < tiles.GetLength(1); row++)
                {
                    int target = 0;

                    // Calculate offset.
                    switch (direction)
                    {
                        // Shift up.
                        case ShiftDirection.Up:
                            // Calculate offset.
                            target = row + amount;

                            // If the target is not out of bounds.
                            if (target < _tiles2.GetLength(1))
                                tiles[col, row] = _tiles2[col, target].Clone();
                            break;

                        // Shift right.
                        case ShiftDirection.Right:
                            // Calculate offset.
                            target = col + amount;

                            // If the target is not out of bounds.
                            if (target < _tiles2.GetLength(0))
                                tiles[target, row] = _tiles2[col, row].Clone();
                            break;

                        // Shift down.
                        case ShiftDirection.Down:
                            // Calculate offset.
                            target = row + amount;

                            // If the target is not out of bounds.
                            if (target < _tiles2.GetLength(1))
                                tiles[col, target] = _tiles2[col, row].Clone();
                            break;

                        // Shift left.
                        case ShiftDirection.Left:
                            // Calculate offset.
                            target = col + amount;

                            // If the target is not out of bounds.
                            if (target < _tiles2.GetLength(0))
                                tiles[col, row] = _tiles2[target, row].Clone();
                            break;
                    }
                }
            }

            // Set the tiles to the new shifted tiles.
            _tiles2 = tiles;
        }

        /// <summary>
        /// Replaces the target tile id with the desired tile id.
        /// </summary>
        /// <param name="target">The target tile id to swap.</param>
        /// <param name="replacement">The replacement tile id to replace the target. </param>
        public void Replace(int target, int replacement)
        {
            // Iterate through tile columns.
            for (int col = 0; col < _tiles2.GetLength(0); col++)
            {
                // Iterate through tile rows.
                for (int row = 0; row < _tiles2.GetLength(1); row++)
                {
                    // If the iterated tile id matches the target, swap.
                    if (_tiles2[col, row].TileId == target)
                        _tiles2[col, row].TileId = replacement;
                }
            }
        }

        /// <summary>
        /// Replace the target tile grid tile ids with the desired tile id.
        /// </summary>
        /// <param name="target">The target tile grid to swap.</param>
        /// <param name="replacement">The replacement tile id to replace the target.</param>
        public void Replace(GMareBrush target, int replacement)
        {
            // Iterate through tile columns.
            for (int col = 0; col < target.Tiles.GetLength(0); col++)
            {
                // Iterate through tile rows.
                for (int row = 0; row < target.Tiles.GetLength(1); row++)
                {
                    // Swap tile.
                    Replace(target.Tiles[col, row].TileId, replacement);
                }
            }
        }

        /// <summary>
        /// Replaces the target tile grid tile ids with the desired tile grid ids.
        /// </summary>
        /// <param name="targets">The target tile grid to swap.</param>
        /// <param name="replacements">The replacement tile grid to replace the target.</param>
        public void Replace(int[] targets, int[] replacements)
        {
            // If the source and target sizes are not the same return.
            if (targets.Length != replacements.Length)
                return;

            // NOTE: This method avoids potenial problems with multiple tile id swapping.
            // If, lets say, the first tile id 6 is replaced with 8, that could lead to issues
            // because if an 8 is replaced at a later position, it would replace those former 6s
            // out with an unexpected value.

            // Create a new list of point lists.
            List<List<Point>> lists = new List<List<Point>>();

            // Iterate through tile ids in target array.
            foreach (int id in targets)
            {
                // Create a new point list.
                List<Point> points = new List<Point>();

                // Iterate through layer columns.
                for (int x = 0; x < _tiles2.GetLength(0); x++)
                {
                    // Iterate through layer rows.
                    for (int y = 0; y < _tiles2.GetLength(1); y++)
                    {
                        // If the iterated tile id matches the target, add point.
                        if (_tiles2[x, y].TileId == id)
                            points.Add(new Point(x, y));
                    }
                }

                // Add point list.
                lists.Add(points);
            }

            // Iterate through point lists.
            for (int i = 0; i < lists.Count; i++)
            {
                // Iterate through points in the point list.
                foreach (Point point in lists[i])
                {
                    // Replace tile id.
                    _tiles2[point.X, point.Y].TileId = replacements[i];
                }
            }
        }

        /// <summary>
        /// Fills in tile sections with the desired tile.
        /// </summary>
        /// <param name="origin">The starting point for the fill, in tiles.</param>
        /// <param name="tileId">The tile id to fill with.</param>
        public void Fill(Point origin, int tileId)
        {
            // Create a new array of tiles.
            GMareTile[,] tiles = new GMareTile[1, 1];
            tiles[0, 0] = new GMareTile();
            tiles[0, 0].TileId = tileId;

            // Fill with tile array.
            Fill(origin, tiles);
        }

        /// <summary>
        /// Fills in tile sections with the desired brush.
        /// </summary>
        /// <param name="origin">The starting point for the fill, in tiles.</param>
        /// <param name="tiles">The array of tiles to fill with.</param>
        public void Fill(Point origin, GMareTile[,] tiles)
        {
            // If the origin is out of bounds, return.
            if (origin.X < 0 || origin.X >= _tiles2.GetLength(0) || origin.Y < 0 || origin.Y >= _tiles2.GetLength(1))
                return;

            // Get target tile.
            int target = _tiles2[origin.X, origin.Y].TileId;

            // Get the valid fill array.
            bool[,] mask = this.GetFillMask(origin, target);

            // Calculate fill start offsets.
            int offsetX = origin.X % tiles.GetLength(0);
            int offsetY = origin.Y % tiles.GetLength(1);

            // If the offsetX is not zero, adjust offsetX origin.
            if (offsetX != 0)
                offsetX = tiles.GetLength(0) - offsetX;

            // If the offsetY is not zero, adjust offsetY origin.
            if (offsetY != 0)
                offsetY = tiles.GetLength(1) - offsetY;

            // Selection indexers, start them at the offsets.
            int x = offsetX;
            int y = offsetY;

            // Iterate through layer columns.
            for (int col = 0; col < _tiles2.GetLength(0); col++)
            {
                // Iterate through layer rows.
                for (int row = 0; row < _tiles2.GetLength(1); row++)
                {
                    // If the coordinate values are allowed by the mask and equal the target, replace the tile.
                    if (mask[col, row] == true && _tiles2[col, row].TileId == target)
                        _tiles2[col, row] = tiles[x, y].Clone();

                    // Increment selection's row index.
                    y++;

                    // If at the max height of the tile selection, reset row index.
                    if (y == tiles.GetLength(1))
                        y = 0;

                    // If at the max height of the layer, reset row index to offsetY.
                    if (row == _tiles2.GetLength(1) - 1)
                        y = offsetY;
                }

                // Increment selection's column index.
                x++;

                // If at the max width of the tile selection, reset column index.
                if (x == tiles.GetLength(0))
                    x = 0;

                // If at the max width of the layer, reset column index to offsetX.
                if (col == _tiles2.GetLength(0) - 1)
                    x = offsetX;
            }
        }

        /// <summary>
        /// Gets an array of booleans that represents the valid fill area.
        /// </summary>
        /// <param name="origin">The starting point for the fill, in tiles.</param>
        /// <param name="target">The target that will be compared.</param>
        /// <returns>The valid fill area of a layer.</returns>
        private bool[,] GetFillMask(Point origin, int target)
        {
            // Create an array of booleans.
            bool[,] mask = new bool[_tiles2.GetLength(0), _tiles2.GetLength(1)];

            // Iterate through columns and rows, set them all to false.
            for (int col = 0; col < _tiles2.GetLength(0); col++)
                for (int row = 0; row < _tiles2.GetLength(1); row++)
                    mask[col, row] = false;

            // Create a checks queue.
            Queue checks = new Queue();

            // Add the starting check point.
            checks.Enqueue(origin);

            // If there are checks left in the queue.
            while (checks.Count > 0)
            {
                // Dequeue point to check.
                Point check = (Point)checks.Dequeue();

                // If the check point value equals the target value.
                if (_tiles2[check.X, check.Y].TileId == target)
                {
                    // Create linear check points.
                    int west = check.X;
                    int east = check.X;

                    // While we're not out of bounds, and the target matches the point, set west coordinate.
                    while (west > -1 && _tiles2[west, check.Y].TileId == target && mask[west, check.Y] == false)
                    {
                        // Deincrement west coordinate.
                        west--;
                    }

                    // While we're not out of bounds, and the target matches the point, set east coordinate.
                    while (east < _tiles2.GetLength(0) && _tiles2[east, check.Y].TileId == target && mask[east, check.Y] == false)
                    {
                        // Increment east coordinate.
                        east++;
                    }

                    // Check the up and down of each filled coordinate.
                    for (west++; west < east; west++)
                    {
                        // Set mask coordinate.
                        mask[west, check.Y] = true;

                        // The up and down check variables.
                        int up = check.Y - 1;
                        int down = check.Y + 1;

                        // If within bounds, if the tile above matches the target, and not already set, add point to queue.
                        if (up > -1 && _tiles2[west, up].TileId == target && mask[west, up] == false)
                            checks.Enqueue(new Point(west, check.Y - 1));

                        // If within bounds, if the tile below matches the target, and not already set, add point to queue.
                        if (down < _tiles2.GetLength(1) && _tiles2[west, down].TileId == target && mask[west, down] == false)
                            checks.Enqueue(new Point(west, check.Y + 1));
                    }
                }
            }

            // Return the valid fill area.
            return mask;
        }

        /// <summary>
        /// Converts old integer tile ids to new tile objects.
        /// </summary>
        public void Convert()
        {
            // Create a new empty layer.
            _tiles2 = GetEmptyLayer(_tiles.GetLength(0), _tiles.GetLength(1));

            // Get the old tile ids for new tile objects.
            for (int col = 0; col < _tiles.GetLength(0); col++)
                for (int row = 0; row < _tiles.GetLength(1); row++)
                    _tiles2[col, row].TileId = _tiles[col, row];

            // Remove old tile data.
            _tiles = null;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Create our own string.
        /// </summary>
        /// <returns>The name and depth string combined.</returns>
        public override string ToString()
        {
            return _name + " (" + Depth.ToString() + ")";
        }

        #endregion
    }

    /// <summary>
    /// A class that represents a tile's data.
    /// </summary>
    [Serializable]
    public class GMareTile
    {
        #region Fields

        private Color _blend = Color.White;      // The blend color.
        private FlipType _flip = FlipType.None;  // Flip mode.
        private int _tileId = -1;                // The source tile id.

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the blend color of the tile.
        /// </summary>
        public Color Blend
        {
            get { return _blend; }
            set { _blend = value; }
        }

        /// <summary>
        /// Gets or sets the source tile from a background.
        /// </summary>
        public int TileId
        {
            get { return _tileId; }
            set { _tileId = value; }
        }

        /// <summary>
        /// Gets or sets the horizontal scale factor of the tile.
        /// </summary>
        public FlipType FlipMode
        {
            get { return _flip; }
            set { _flip = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Makes a shallow copy of this tile.
        /// </summary>
        /// <returns>A shallow copy of this tile.</returns>
        public GMareTile Clone()
        {
            // Create a new tile.
            GMareTile tile = new GMareTile();

            // Set properties.
            tile.TileId = _tileId;
            tile.FlipMode = _flip;
            tile.Blend = _blend;

            // Return cloned tile.
            return tile;
        }

        /// <summary>
        /// Converts the flipping data to a scale point.
        /// </summary>
        /// <returns>A converted flip point.</returns>
        public PointF GetScale()
        {
            // Create a new point.
            PointF point = new PointF(1.0f, 1.0f);

            // Set flipping data.
            switch (_flip)
            {
                case FlipType.None: break;
                case FlipType.Horizontal: point.X = -1.0f; break;
                case FlipType.Vertical: point.Y = -1.0f; break;
                case FlipType.Both: point.X = -1.0f; point.Y = -1.0f; break;
            }

            // Return converted data point.
            return point;
        }

        /// <summary>
        /// Sets the tiles flipping mode.
        /// </summary>
        /// <param name="direction">The desired direction to flip.</param>
        public void Flip(FlipDirection direction)
        {
            // Set flipping enumeration.
            switch (_flip)
            {
                case FlipType.None:
                    // If flipping horizontally.
                    if (direction == FlipDirection.Horizontal)
                        _flip = FlipType.Horizontal;
                    else
                        _flip = FlipType.Vertical;
                    
                    break;

                case FlipType.Horizontal:
                    // If flipping horizontally.
                    if (direction == FlipDirection.Horizontal)
                        _flip = FlipType.None;
                    else
                        _flip = FlipType.Both;

                    break;

                case FlipType.Vertical:
                    // If flipping horizontally.
                    if (direction == FlipDirection.Horizontal)
                        _flip = FlipType.Both;
                    else
                        _flip = FlipType.None;
                    
                    break;

                case FlipType.Both:
                    // If flipping horizontally.
                    if (direction == FlipDirection.Horizontal)
                        _flip = FlipType.Vertical;
                    else
                        _flip = FlipType.Horizontal;
                    
                    break;
            }
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Overrides to string.
        /// </summary>
        /// <returns>A string representing a tile object.</returns>
        public override string ToString()
        {
            return "Tile Id: " + _tileId + " Flip Mode: " + _flip.ToString();
        }

        #endregion
    }

    /// <summary>
    /// A class that represents a watered down version of a GM object.
    /// </summary>
    [Serializable]
    public class GMareObject
    {
        #region Fields

        private GMResource _resource = new GMResource();           // The resource id of the source object.
        private Bitmap _image = GMare.Properties.Resources.instance;  // The image to represent this object.
        private int _depth = 0;                                    // The object depth.
        private int _sprite = -1;                                  // The sprite id.
        private int _originX = 0;                                  // The horizontal offset.
        private int _originY = 0;                                  // The vertical offset.

        #endregion

        #region Properties

        /// <summary>
        /// Gets the resource id of this object.
        /// </summary>
        public GMResource Resource
        {
            get { return _resource; }
        }

        /// <summary>
        /// Gets the sprite associated with this object.
        /// </summary>
        public Bitmap Image
        {
            get { return _image; }
        }

        /// <summary>
        /// The sprite id that is used to represent this object.
        /// </summary>
        public int Sprite
        {
            get { return _sprite; }
        }

        /// <summary>
        /// The depth of the object.
        /// </summary>
        public int Depth
        {
            get { return _depth; }
        }

        /// <summary>
        /// The horizontal origin of the object.
        /// </summary>
        public int OriginX
        {
            get { return _originX; }
        }

        /// <summary>
        /// The vertical origin of the object.
        /// </summary>
        public int OriginY
        {
            get { return _originY; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new GMare object.
        /// </summary>
        public GMareObject(GMResource resource, Bitmap image, int sprite, int depth, int originX, int originY)
        {
            // If the image is not empty, use it.
            if (image != null)
                _image = image;

            // Set fields.
            _resource = resource;
            _sprite = sprite;
            _depth = depth;
            _originX = originX;
            _originY = originY;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Makes a shallow copy of this object.
        /// </summary>
        /// <returns>A shallow copy of this object.</returns>
        public GMareObject Clone()
        {
            // Get resource id.
            GMResource res = new GMResource();
            res.Name = (string)_resource.Name.Clone();
            res.Id = _resource.Id;
            res.LastChanged = _resource.LastChanged;

            // Get bitmap.
            Bitmap image = (Bitmap)_image.Clone();

            // Return shallow copy.
            return new GMareObject(res, image, _sprite, _depth, _originX, _originY);
        }

        #endregion
    }

    /// <summary>
    /// A class that represents a Game Maker instance, with cloning.
    /// </summary>
    [Serializable]
    public class GMareInstance : GMInstance
    {
        #region Methods

        /// <summary>
        /// Creates a shallow copy of this instance.
        /// </summary>
        /// <returns>A shallow copy of this instance.</returns>
        public GMareInstance Clone()
        {
            // Create new instance.
            GMareInstance instance = new GMareInstance();

            // Set properties.
            instance.CreationCode = (string)CreationCode.Clone();
            instance.Depth = Depth;
            instance.Id = Id;
            instance.LastChanged = LastChanged;
            instance.Locked = Locked;
            instance.Name = (string)Name.Clone();
            instance.ObjectId = ObjectId;
            instance.X = X;
            instance.Y = Y;

            // Return instance.
            return instance;
        }

        #endregion
    }

    /// <summary>
    /// A basic collision shape.
    /// </summary>
    [Serializable]
    public class GMareCollision
    {
        #region Fields

        private Point[] _points = null;     // An array of shape points.
        private Rectangle[] _nodes = null;  // An array of nodes rectangles.
        private int _nodeSize = 7;          // Node size.
        private int _level = 0;             // The level the collision exists on.

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the array of points.
        /// </summary>
        public Point[] Points
        {
            get { return _points; }
            set { _points = value; SetNodes(); }
        }

        /// <summary>
        /// Gets or sets a point within the points array.
        /// </summary>
        public Point this[int i]
        {
            get { return _points[i]; }
            set { _points[i] = value; SetNodes(); }
        }

        /// <summary>
        /// Gets the nodes of the shape.
        /// </summary>
        public Rectangle[] Nodes
        {
            get { return _nodes; }
        }

        /// <summary>
        /// Gets or sets the level of the shape.
        /// </summary>
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new shape object.
        /// </summary>
        /// <param name="shapeMode">The desired shape.</param>
        public GMareCollision()
        {
            // Create a new array of points.
            _points = new Point[4];

            // Set node rectangles.
            SetNodes();
        }

        /// <summary>
        /// Constructs a new shape object.
        /// </summary>
        /// <param name="shapeMode">The desired shape.</param>
        public GMareCollision(Point[] points)
        {
            // Set nodes.
            _points = (Point[])points.Clone();

            // Set node rectangles.
            SetNodes();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks whether the given point lies within the shape.
        /// </summary>
        /// <param name="point">Point to test.</param>
        /// <returns>Whether the point is within the shape.</returns>
        public bool Contains(Point point)
        {
            // Create a new path.
            GraphicsPath path = new GraphicsPath();

            // Start path shape.
            path.StartFigure();

            // Add shape lines.
            path.AddLines(_points);

            // Close path shape.
            path.CloseFigure();

            // Get wether the path contains the point.
            bool contains = path.IsVisible(point);

            // Dispose.
            path.Dispose();

            // If the shape contains the point.
            return contains;
        }

        /// <summary>
        /// Creates selection rectangles based on points.
        /// </summary>
        /// <returns>An array of selection rectangles.</returns>
        private void SetNodes()
        {
            // Set nodes array.
            _nodes = new Rectangle[_points.Length];

            // Iterate through shape points.
            for (int i = 0; i < _points.Length; i++)
            {
                // Calculate rectangle based on indexed point.
                int x = _points[i].X - (_nodeSize / 2);
                int y = _points[i].Y - (_nodeSize / 2);

                // Set new rectangle.
                _nodes[i] = new Rectangle(x, y, _nodeSize, _nodeSize);
            }
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Override to string.
        /// </summary>
        public override string ToString()
        {
            // Create a string builder.
            StringBuilder sb = new StringBuilder();
            sb.Append("Count: ");
            sb.Append(_points.Length);
            sb.Append(" ");

            // Iterate through every shape point.
            foreach (Point point in _points)
            {
                sb.Append("(X: ");
                sb.Append(point.X);
                sb.Append(" Y: ");
                sb.Append(point.Y);
                sb.Append(") ");
            }

            // Return shape string.
            return sb.ToString();
        }


        #endregion
    }
}