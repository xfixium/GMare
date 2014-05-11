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
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using GMare.Objects;

namespace GMare.Forms
{
    /// <summary>
    /// A form that shows tile data in various forms, all in text
    /// </summary>
    public partial class ViewLayerForm : Form
    {
        #region Enumerations

        /// <summary>
        /// Describes the type of Game Maker array
        /// </summary>
        public enum ArrayType
        {
            Raw = 0,
            Standard = 1,
            List = 2,
            Grid = 3
        };

        /// <summary>
        /// Describes the type of display data type
        /// </summary>
        public enum DataType
        {
            Sectors = 0,
            Points = 1,
            Rectangles = 2
        };

        #endregion

        #region Fields

        private bool _viewOptimizations = false;  // If viewing optimization controls

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new view form
        /// </summary>
        public ViewLayerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructs a new text form with layer data
        /// </summary>
        /// <param name="layers">Layers to have available</param>
        public ViewLayerForm(List<GMareLayer> layers, bool viewOptimizations)
        {
            InitializeComponent();

            // Set view optimization flag
            _viewOptimizations = viewOptimizations;

            // Iterate through layers
            foreach (GMareLayer layer in layers)
            {
                // Add layer to list box
                cboLayers.Items.Add(layer);
            }
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Set up controls that need to be hidden/shown
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            // Call base method
            base.OnLoad(e);

            // Show or hide optimization panel view and text data controls
            pnlOptimized.Visible = _viewOptimizations;
            grpArrayType.Visible = _viewOptimizations ? false : true;
            grpDataType.Visible = _viewOptimizations ? false : true;

            // If there is at least one item to select, set to first item
            if (cboLayers.Items.Count > 0)
                cboLayers.SelectedIndex = 0;

            // Set the data type
            cboDataType.SelectedIndex = 0;

            // Set the array type
            cboArrayType.SelectedIndex = 0;
        }

        #endregion

        #region Events

        /// <summary>
        /// Layer combo box selected index changed
        /// </summary>
        private void cboLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If the optimization panel is visible, populate panel with data, else populate text data
            if (pnlOptimized.Visible)
            {
                pnlOptimized.Layer = (GMareLayer)cboLayers.SelectedItem;
                grpTextView.Text = "Layer View (" + pnlOptimized.TileCount + " Tiles)";
            }
            else
                SetText((GMareLayer)cboLayers.SelectedItem, (DataType)cboDataType.SelectedIndex, (ArrayType)cboArrayType.SelectedIndex);
        }

        /// <summary>
        /// Data type combo box selected index changed
        /// </summary>
        private void cboDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the rich text box text
            SetText((GMareLayer)cboLayers.SelectedItem, (DataType)cboDataType.SelectedIndex, (ArrayType)cboArrayType.SelectedIndex);
        }

        /// <summary>
        /// Array type combo box selected index changed
        /// </summary>
        private void cboArrayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the rich text box text
            SetText((GMareLayer)cboLayers.SelectedItem, (DataType)cboDataType.SelectedIndex, (ArrayType)cboArrayType.SelectedIndex);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a string representation of a layer
        /// </summary>
        /// <param name="layer">The layer to get tile data from</param>
        /// <param name="dataType">The type of data to present</param>
        /// <param name="arrayType">The type of array style to use when writing the string</param>
        private void SetText(GMareLayer layer, DataType dataType, ArrayType arrayType)
        {
            // If no layers, display nothing
            if (layer == null)
                return;

            // Clear any existing text
            txtText.Clear();

            // Local variables
            int index = 0;
            int roomWidth = 0;

            if (ProjectManager.Room.Backgrounds[0].Image != null)
                roomWidth = ProjectManager.Room.Backgrounds[0].Image.Width;

            Size roomTileSize = ProjectManager.Room.Backgrounds[0].TileSize;
            bool tileData = TilesExist(layer.Tiles);

            // Create new text
            StringBuilder text = new StringBuilder();
            string layerId = "layer" + layer.Depth.ToString();
            layerId = layerId.Replace("-", "_");

            // Do action based on array type
            switch (arrayType)
            {
                // If the array present type is a list
                case ArrayType.List:
                    // Do action based on data type
                    switch (dataType)
                    {
                        // Sector data type
                        case DataType.Sectors:
                            // Create array variable string
                            text.AppendLine(layerId + " = ds_list_create();");
                            text.AppendLine();
                            break;

                        // All other data types
                        default:
                            // If there is tile data, create array variable string
                            if (tileData)
                            {
                                text.AppendLine(layerId + " = ds_list_create();");
                                text.AppendLine();
                            }

                            break;
                    }

                    break;

                // If the array present type is a grid
                case ArrayType.Grid:
                    // If the data type is sectors, create a grid variable
                    if (dataType == DataType.Sectors)
                    {
                        text.AppendLine(layerId + " = ds_grid_create();");
                        text.AppendLine();
                    }

                    break;
            }

            // Calculate columns and rows
            int rows = layer.Tiles.GetLength(1);
            int cols = layer.Tiles.GetLength(0);

            // Iterate through rows
            for (int row = 0; row < rows; row++)
            {
                // Create a new line
                StringBuilder line = new StringBuilder();

                // Iterate through columns
                for (int col = 0; col < cols; col++)
                {
                    // Do action based on data type
                    switch (dataType)
                    {
                        // If sector data must be displayed
                        case DataType.Sectors:
                            // Set sector data text based on desired array type
                            switch (arrayType)
                            {
                                case ArrayType.Raw: line.Append((layer.Tiles[col, row].TileId).ToString() + ", "); break;
                                case ArrayType.Standard: line.Append(layerId + "[" + col + "," + row + "] = " + layer.Tiles[col, row].TileId.ToString() + "; "); break;
                                case ArrayType.List: line.Append("ds_list_add(" + layerId + "," + layer.Tiles[col, row].TileId.ToString() + "); "); break;
                                case ArrayType.Grid: line.Append("ds_grid_add(" + layerId + "," + col + "," + row + "," + layer.Tiles[col, row].TileId.ToString() + "); "); break;
                            }

                            break;

                        // If point data must be displayed
                        case DataType.Points:
                            // If the tile id is -1, don't bother with rectangle data
                            if (layer.Tiles[col, row].TileId == -1)
                                continue;

                            // Create a new rectangle that represents the source rectangle
                            Point point = GMareBrush.TileIdToPosition(layer.Tiles[col, row].TileId, roomWidth, roomTileSize);

                            // Set tile data text based on desired array type
                            switch (arrayType)
                            {
                                case ArrayType.Raw:
                                    text.AppendLine(new Point(col * roomTileSize.Width, row * roomTileSize.Height).ToString() + " // Destination point.");
                                    text.AppendLine(point.ToString() + " // Source Point");
                                    break;

                                case ArrayType.Standard:
                                    text.AppendLine(layerId + "[" + index + "] = " + col * roomTileSize.Width + "; " + " // Destination X."); index++;
                                    text.AppendLine(layerId + "[" + index + "] = " + row * roomTileSize.Height + "; " + " // Destination Y."); index++;
                                    text.AppendLine(layerId + "[" + index + "] = " + point.X + "; " + " // Source X."); index++;
                                    text.AppendLine(layerId + "[" + index + "] = " + point.Y + "; " + " // Source Y."); index++;
                                    break;

                                case ArrayType.List:
                                    text.AppendLine("ds_list_add(" + layerId + ", " + col * roomTileSize.Width + "); " + " // Destination X.");
                                    text.AppendLine("ds_list_add(" + layerId + ", " + row * roomTileSize.Height + "); " + " // Destination Y.");
                                    text.AppendLine("ds_list_add(" + layerId + ", " + point.X + "); " + " // Source X.");
                                    text.AppendLine("ds_list_add(" + layerId + ", " + point.Y + "); " + " // Source Y.");
                                    break;
                            }

                            break;

                        // If rectangle data must be displayed
                        case DataType.Rectangles:
                            // If the tile id is -1, don't bother with rectangle data
                            if (layer.Tiles[col, row].TileId == -1)
                                continue;

                            // Create a new rectangle that represents the source rectangle
                            Rectangle rect = new Rectangle();
                            rect.Location = GMareBrush.TileIdToPosition(layer.Tiles[col, row].TileId, roomWidth, roomTileSize);
                            rect.Size = roomTileSize;

                            // Set tile data text based on desired array type
                            switch (arrayType)
                            {
                                case ArrayType.Raw:
                                    text.AppendLine(new Point(col * roomTileSize.Width, row * roomTileSize.Height).ToString() + " // Destination point.");
                                    text.AppendLine(rect.ToString() + " // Source rectangle.");
                                    break;

                                case ArrayType.Standard:
                                    text.AppendLine(layerId + "[" + index + "] = " + col * roomTileSize.Width + "; " + " // Destination X."); index++;
                                    text.AppendLine(layerId + "[" + index + "] = " + row * roomTileSize.Height + "; " + " // Destination Y."); index++;
                                    text.AppendLine(layerId + "[" + index + "] = " + rect.X + "; " + " // Source X."); index++;
                                    text.AppendLine(layerId + "[" + index + "] = " + rect.Y + "; " + " // Source Y."); index++;
                                    text.AppendLine(layerId + "[" + index + "] = " + rect.Width + "; " + " // Tile Width."); index++;
                                    text.AppendLine(layerId + "[" + index + "] = " + rect.Height + "; " + " // Tile Height."); index++;
                                    break;

                                case ArrayType.List:
                                    text.AppendLine("ds_list_add(" + layerId + "," + col * roomTileSize.Width + "); " + " // Destination X.");
                                    text.AppendLine("ds_list_add(" + layerId + "," + row * roomTileSize.Height + "); " + " // Destination Y.");
                                    text.AppendLine("ds_list_add(" + layerId + "," + rect.X + "); " + " // Source X.");
                                    text.AppendLine("ds_list_add(" + layerId + "," + rect.Y + "); " + " // Source Y.");
                                    text.AppendLine("ds_list_add(" + layerId + "," + rect.Width + "); " + " // Tile Width.");
                                    text.AppendLine("ds_list_add(" + layerId + "," + rect.Height + "); " + " // Tile Height.");
                                    break;
                            }

                            break;
                    }
                }

                // Append line to text
                if (dataType == DataType.Sectors)
                    text.AppendLine(line.ToString());
            }

            // Set rich text box text
            txtText.Text = text.ToString();
        }

        /// <summary>
        /// Checks tile sectors for actual tile data types
        /// </summary>
        /// <param name="tiles">The tiles to inspect</param>
        /// <returns>Whether there is tile data, or just empty tiles</returns>
        private bool TilesExist(GMareTile[,] tiles)
        {
            // Calculate columns and rows
            int rows = tiles.GetLength(1);
            int cols = tiles.GetLength(0);

            // Iterate through tiles, searching for non-empty tiles
            for (int row = 0; row < rows; row++)
                for (int col = 0; col < cols; col++)
                    if (tiles[col, row].TileId != -1)
                        return true;

            // No tiles in the tile array
            return false;
        }

        #endregion
    }
}