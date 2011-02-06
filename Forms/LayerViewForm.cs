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
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using GMare.Common;

namespace GMare.Forms
{
    /// <summary>
    /// A form that shows tile data in various forms, all in text.
    /// </summary>
    public partial class TextForm : Form
    {
        #region Fields

        /// <summary>
        /// Describes the type of Game Maker array.
        /// </summary>
        public enum ArrayType
        {
            Raw = 0,
            Standard = 1,
            List = 2,
            Grid = 3
        };

        /// <summary>
        /// Describes the type of display data type.
        /// </summary>
        public enum DataType
        {
            Sectors = 0,
            Points = 1,
            Rectangles = 2,
        };

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new text form.
        /// </summary>
        public TextForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructs a new text form with layer data.
        /// </summary>
        /// <param name="layers"></param>
        public TextForm(List<GMareLayer> layers)
        {
            InitializeComponent();

            // Iterate through layers.
            foreach (GMareLayer layer in layers)
            {
                // Add layer to list box.
                cb_Layers.Items.Add(layer);
            }

            // If there is at least one item to select, set to first item.
            if (cb_Layers.Items.Count > 0)
                cb_Layers.SelectedIndex = 0;

            // Set the data type.
            cb_DataType.SelectedIndex = 0;

            // Set the array type.
            cb_ArrayType.SelectedIndex = 0;
        }

        #endregion

        #region Events

        /// <summary>
        /// Layer combo box selected index changed.
        /// </summary>
        private void cb_Layers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the rich text box text.
            SetText((GMareLayer)cb_Layers.SelectedItem, (DataType)cb_DataType.SelectedIndex, (ArrayType)cb_ArrayType.SelectedIndex);
        }

        /// <summary>
        /// Data type combo box selected index changed.
        /// </summary>
        private void tsb_DataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the rich text box text.
            SetText((GMareLayer)cb_Layers.SelectedItem, (DataType)cb_DataType.SelectedIndex, (ArrayType)cb_ArrayType.SelectedIndex);
        }

        /// <summary>
        /// Array type combo box selected index changed.
        /// </summary>
        private void cb_ArrayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the rich text box text.
            SetText((GMareLayer)cb_Layers.SelectedItem, (DataType)cb_DataType.SelectedIndex, (ArrayType)cb_ArrayType.SelectedIndex);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a string representation of a layer.
        /// </summary>
        /// <param name="layer">The layer to get tile data from.</param>
        /// <param name="dataType">The type of data to present.</param>
        /// <param name="arrayType">The type of array style to use when writing the string.</param>
        private void SetText(GMareLayer layer, DataType dataType, ArrayType arrayType)
        {
            // Clear any existing text.
            rtb_Text.Clear();

            // Local variables.
            int index = 0;
            int roomWidth = ProjectManager.Room.Background.Width;
            Size roomTileSize = ProjectManager.Room.TileSize;
            bool tileData = TilesExist(layer.Tiles);

            // Create new text.
            StringBuilder text = new StringBuilder();
            string layerId = "layer" + layer.Depth.ToString();
            layerId = layerId.Replace("-", "_");

            // Do action based on array type.
            switch (arrayType)
            {
                // If the array present type is a list.
                case ArrayType.List:
                    // Do action based on data type.
                    switch (dataType)
                    {
                        // Sector data type.
                        case DataType.Sectors:
                            // Create array variable string.
                            text.AppendLine(layerId + " = ds_list_create();");
                            text.AppendLine();
                            break;

                        // All other data types.
                        default:
                            // If there is tile data, create array variable string.
                            if (tileData)
                            {
                                text.AppendLine(layerId + " = ds_list_create();");
                                text.AppendLine();
                            }

                            break;
                    }

                    break;

                // If the array present type is a grid.
                case ArrayType.Grid:
                    // If the data type is sectors, create a grid variable.
                    if (dataType == DataType.Sectors)
                    {
                        text.AppendLine(layerId + " = ds_grid_create();");
                        text.AppendLine();
                    }

                    break;
            }

            // Calculate columns and rows.
            int rows = layer.Tiles.GetLength(1);
            int cols = layer.Tiles.GetLength(0);

            // Iterate through rows.
            for (int row = 0; row < rows; row++)
            {
                // Create a new line.
                StringBuilder line = new StringBuilder();

                // Iterate through columns.
                for (int col = 0; col < cols; col++)
                {
                    // Do action based on data type.
                    switch (dataType)
                    {
                        // If sector data must be displayed.
                        case DataType.Sectors:
                            // Set sector data text based on desired array type.
                            switch (arrayType)
                            {
                                case ArrayType.Raw: line.Append(layer.Tiles[col, row].ToString() + ", "); break;
                                case ArrayType.Standard: line.Append(layerId + "[" + col + "," + row + "] = " + layer.Tiles[col, row].ToString() + "; "); break;
                                case ArrayType.List: line.Append("ds_list_add(" + layerId + "," + layer.Tiles[col, row].ToString() + "); "); break;
                                case ArrayType.Grid: line.Append("ds_grid_add(" + layerId + "," + col + "," + row + "," + layer.Tiles[col, row].ToString() + "); "); break;
                            }

                            break;

                        // If point data must be displayed.
                        case DataType.Points:
                            // If the tile id is -1, don't bother with rectangle data.
                            if (layer.Tiles[col, row] == -1)
                                continue;

                            // Create a new rectangle that represents the source rectangle.
                            Point point = TileGrid.TileIdToPosition(layer.Tiles[col, row], roomWidth, roomTileSize);

                            // Set tile data text based on desired array type.
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

                        // If rectangle data must be displayed.
                        case DataType.Rectangles:
                            // If the tile id is -1, don't bother with rectangle data.
                            if (layer.Tiles[col, row] == -1)
                                continue;

                            // Create a new rectangle that represents the source rectangle.
                            Rectangle rect = new Rectangle();
                            rect.Location = TileGrid.TileIdToPosition(layer.Tiles[col, row], roomWidth, roomTileSize);
                            rect.Size = roomTileSize;

                            // Set tile data text based on desired array type.
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

                // Append line to text.
                if (dataType == DataType.Sectors)
                    text.AppendLine(line.ToString());
            }

            // Set rich text box text.
            rtb_Text.Text = text.ToString();
        }

        /// <summary>
        /// Checks tile sectors for actual tile data types.
        /// </summary>
        /// <param name="tiles">The tiles to inspect.</param>
        /// <returns>Whether there is tile data, or just empty tiles.</returns>
        private bool TilesExist(int[,] tiles)
        {
            // Calculate columns and rows.
            int rows = tiles.GetLength(1);
            int cols = tiles.GetLength(0);

            // Iterate through rows.
            for (int row = 0; row < rows; row++)
                // Iterate through columns.
                for (int col = 0; col < cols; col++)
                    // There is tile data.
                    if (tiles[col, row] != -1)
                        return true;

            // No tiles in the tile array.
            return false;
        }

        #endregion
    }
}