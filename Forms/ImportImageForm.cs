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
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GMare.Common;
using GenericUndoRedo;

namespace GMare.Forms
{
    /// <summary>
    /// Imports a room from an image file.
    /// </summary>
    public partial class ImportImageForm : Form, ITilesOwner
    {
        #region Fields

        private UndoRedoHistory<ITilesOwner> _history;  // The form undo/redo history.
        private GMareRoom _newRoom = null;              // The newly created room.

        #endregion

        #region ITilesOwner Members

        /// <summary>
        /// Gets or sets the tile data.
        /// </summary>
        public TileData Data
        {
            get { return new TileData(pnl_Tileset.Tiles, pnl_Tileset.Columns); }
            set
            {
                // Set the tiles panel.
                nud_Columns.Value = value.Columns;
                pnl_Tileset.Columns = value.Columns;
                pnl_Tileset.Tiles = value.Tiles;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the newly created room.
        /// </summary>
        public GMareRoom NewRoom
        {
            get { return _newRoom; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new import room from image form.
        /// </summary>
        /// <param name="image">The image used as a room.</param>
        public ImportImageForm(Bitmap image)
        {
            InitializeComponent();

            // Create a new room.
            _newRoom = new GMareRoom();

            // Set target room image.
            pnl_Image.BackgroundImage = image;

            // Disable cancel tile compile button.
            tsb_CancelCompile.Enabled = false;
            tsb_Undo.Enabled = false;
            tsb_Redo.Enabled = false;

            // Create new undo/redo history.
            _history = new UndoRedoHistory<ITilesOwner>(this, 10);

            // Check for ok button enable.
            CheckAccept();
        }

        #endregion

        #region Events

        /// <summary>
        /// Ok button click.
        /// </summary>
        private void tsb_Ok_Click(object sender, EventArgs e)
        {
            // If no tiles, return.
            if (pnl_Tileset.Tiles.Count == 0)
            {
                // Show message.
                MessageBox.Show("The tileset has no tiles.", "GMare", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            // Set dialog result and close.
            DialogResult = DialogResult.OK;

            // The end resulting tile replacements.
            int[] replacements = new int[pnl_Tileset.Tiles.Count];
            int[] targets = new int[replacements.Length];

            // Get target and replacement tile ids.
            for (int i = 0; i < replacements.Length; i++)
            {
                // If the tile is empty, give empty id, else target id.
                if (pnl_Tileset.Tiles[i] != null)
                {
                    // Set the replacement and target ids.
                    replacements[i] = i;
                    targets[i] = (int)pnl_Tileset.Tiles[i].Tag;
                }
            }

            // Set room.
            _newRoom.Name = tb_Name.Text;
            _newRoom.Background = new Graphics.PixelMap(pnl_Tileset.Image);
            _newRoom.Layers[0].Replace(targets, replacements);

            Close();
        }

        /// <summary>
        /// Cancel button click.
        /// </summary>
        private void tsb_Cancel_Click(object sender, EventArgs e)
        {
            // Set dialog result and close.
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Undo button click.
        /// </summary>
        private void tsb_Undo_Click(object sender, EventArgs e)
        {
            // If able to undo.
            if (_history.CanUndo == true)
            {
                // Undo room.
                _history.Undo();
            }

            // Set undo/redo buttons.
            tsb_Undo.Enabled = _history.CanUndo;
            tsb_Redo.Enabled = _history.CanRedo;
        }

        /// <summary>
        /// Redo button click.
        /// </summary>
        private void tsb_Redo_Click(object sender, EventArgs e)
        {
            // If able to undo.
            if (_history.CanRedo == true)
            {
                // Undo room.
                _history.Redo();
            }

            // Set undo/redo buttons.
            tsb_Undo.Enabled = _history.CanUndo;
            tsb_Redo.Enabled = _history.CanRedo;
        }

        /// <summary>
        /// Grid button click.
        /// </summary>
        private void tsb_Grid_Click(object sender, EventArgs e)
        {
            // Toggle grid.
            pnl_Tileset.ShowGrid = tsb_Grid.Checked ? true : false;
        }

        /// <summary>
        /// Compile button click.
        /// </summary>
        private void tsb_Compile_Click(object sender, EventArgs e)
        {
            // If a tiles list already exists and there are tiles, warn the user.
            if (pnl_Tileset.Tiles != null && pnl_Tileset.Tiles.Count > 0 )
            {
                // Ask the user a question.
                DialogResult result = MessageBox.Show("Compiling tiles will delete existing compiled tile data. Are you sure you want to continue?", "GMare", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                // If the user chose yes, empty tiles, else return.
                if (result == DialogResult.Yes)
                {
                    // Clear tiles.
                    pnl_Tileset.Tiles.Clear();

                    // Clear history.
                    _history.Clear();
                }
                else
                    return;
            }

            // Set GUI.
            SetGUI(true);

            // Set status.
            tssl_Status.Text = "Status: Compiling tiles";
            Refresh();

            // Compile tiles.
            bgw_Compile.RunWorkerAsync();
        }

        /// <summary>
        /// Cancel tile compile click.
        /// </summary>
        private void tsb_CancelCompile_Click(object sender, EventArgs e)
        {
            // If compiling tiles, cancel tile compilation.
            if (bgw_Compile.IsBusy == true)
                bgw_Compile.CancelAsync();
        }

        /// <summary>
        /// Zoom changed.
        /// </summary>
        private void tsb_Zoom_ZoomChanged()
        {
            // If tiles have been compiled, set tileset zoom level.
            if (pnl_Tileset.Tiles.Count > 0)
                pnl_Tileset.Zoom = tsb_Zoom.Zoom;
        }

        /// <summary>
        /// Compile tiles.
        /// </summary>
        private void bgw_Compile_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // Hook into background worker for any cancellations.
            BackgroundWorker bw = sender as BackgroundWorker;

            // Get neccessary data.
            Size tileSize = new Size((int)nud_TileX.Value, (int)nud_TileY.Value);
            Size seperation = new Size((int)nud_SeperationX.Value, (int)nud_SeperationY.Value);
            Point offset = new Point((int)nud_OffsetX.Value, (int)nud_OffsetY.Value);
            Bitmap image = (Bitmap)pnl_Image.BackgroundImage;

            // Calculate the number of columns and rows.
            int cols = (int)Math.Ceiling((double)(image.Width - offset.X) / (double)(tileSize.Width + seperation.Width));
            int rows = (int)Math.Ceiling((double)(image.Height - offset.Y) / (double)(tileSize.Height + seperation.Height));

            // Set looping variables.
            bool match = false;
            int i = 0;
            int total = cols * rows;

            // Byte array collection for unique tiles.
            List<byte[]> imageData = new List<byte[]>();

            // A list of accepted unique tile bitmaps.
            List<Bitmap> tiles = new List<Bitmap>();

            // Create an empty layer.
            GMareLayer layer = new GMareLayer(cols, rows);

            // Copy rectangle.
            Rectangle rect = new Rectangle(0, 0, tileSize.Width, tileSize.Height);

            // Iterate through image tile rows.
            for (int row = 0; row < rows; row++)
            {
                // Iterate through image tile columns.
                for (int col = 0; col < cols; col++)
                {
                    // Set copy rectangle position.
                    rect.X = (col * tileSize.Width + (col * seperation.Width)) + offset.X;
                    rect.Y = (row * tileSize.Height + (row * seperation.Height)) + offset.Y;

                    // Copy a section of the image pixel data fast.
                    byte[] compare = GetTileBytes(image, rect);

                    // If the compare is empty, skip over validation process.
                    if (compare == null)
                        continue;

                    // Set match variable.
                    match = false;

                    // Iterate through existing unique tiles for a match.
                    for (int j = 0; j < imageData.Count; j++)
                    {
                        // If the compare is equal to the tile.
                        if (CompareTiles(compare, imageData[j]) == true)
                        {
                            // Match is true.
                            match = true;

                            // Set tile id, which is the same as the tile's index at this point.
                            layer.Tiles[col, row] = j;
                            break;
                        }
                    }

                    // No match was found.
                    if (match == false)
                    {
                        // New tile id.
                        layer.Tiles[col, row] = imageData.Count;

                        // Add tile to unique tile list.
                        imageData.Add(compare);

                        try
                        {
                            // Create a tile bitmap, and remember it's original id.
                            Bitmap tile = GMare.Graphics.PixelMap.PixelDataToBitmap(GMare.Graphics.PixelMap.GetPixels(image, rect));
                            tile.Tag = imageData.Count - 1;

                            // Add bitmap to tiles.
                            tiles.Add(tile);
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("When compiling the tiles, the image's color depth of: " + error.Message + ", is not supported.", "GMare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    // Increment progress.
                    i++;

                    // Report progress.
                    bw.ReportProgress(i * 100 / total);
                }

                // If cancelling, return.
                if (bw.CancellationPending == true)
                {
                    // Clear tile data.
                    tiles.Clear();
                    tiles = null;

                    // Cancel processing.
                    e.Cancel = true;
                    return;
                }
            }

            // Tilesize.
            pnl_Tileset.TileSize = tileSize;

            // Set tiles.
            pnl_Tileset.Tiles = tiles;

            // Set room properties.
            _newRoom.TileWidth = tileSize.Width;
            _newRoom.TileHeight = tileSize.Height;
            _newRoom.Columns = cols;
            _newRoom.Rows = rows;
            _newRoom.Layers.Clear();
            _newRoom.Layers.Add(layer);
        }

        /// <summary>
        /// Compiler progress changed event.
        /// </summary>
        private void bgw_Compile_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            // Set progress bar progress amount.
            tssl_Progress.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Compiler done event.
        /// </summary>
        private void bgw_Compile_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            // Setup GUI.
            SetGUI(false);

            // Reset progress bar.
            tssl_Progress.Value = 0;

            // Set status.
            tssl_Status.Text = "Status: Ready";

            // If there are tiles.
            if (pnl_Tileset.Tiles != null)
            {
                // Show the amount of tiles.
                tssl_TileCount.Text = "Tile Count: " + pnl_Tileset.Tiles.Count;

                // Set the zoom level of the tile editor.
                pnl_Tileset.Zoom = tsb_Zoom.Zoom;
            }

            // Check for ok button enable.
            CheckAccept();
        }

        /// <summary>
        /// Numeric up and down columns value changed.
        /// </summary>
        private void nud_Columns_ValueChanged(object sender, EventArgs e)
        {
            // If the tiles are not empty, push history.
            if (pnl_Tileset.Tiles != null)
                PushHistory();

            // Set the width of the tileset.
            pnl_Tileset.Columns = (int)nud_Columns.Value;
        }

        /// <summary>
        /// Tiles Panel changed.
        /// </summary>
        private void pnl_Tileset_PanelChanged()
        {
            // Push history.
            PushHistory();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Compares to tiles bytes, returns whether they match or not.
        /// </summary>
        /// <param name="tile1">The first tile to compare.</param>
        /// <param name="tile2">The second tile to compare.</param>
        /// <returns>If the tiles match.</returns>
        private bool CompareTiles(byte[] tile1, byte[] tile2)
        {
            // Iterate through bytes, if there is a mismatch in bytes, then tiles don't match.
            for (int i = 0; i < tile1.Length; i++)
                if (tile1[i] != tile2[i])
                    return false;

            // The tiles match
            return true;
        }

        /// <summary>
        /// Gets a byte array of image data.
        /// </summary>
        /// <param name="image">The bitmap to get the image data from.</param>
        /// <param name="selection">The size of the tile.</param>
        /// <returns>A byte array.</returns>
        public byte[] GetTileBytes(Bitmap image, Rectangle selection)
        {
            // If the selection end point is out of image bounds, return null.
            if (selection.X + selection.Width > image.Width || selection.Y + selection.Height > image.Height)
                return null;

            // Get image bytes.
            BitmapData data = image.LockBits(selection, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
            
            int size = data.Stride * selection.Height;
            byte[] bytes = new byte[size];
            Marshal.Copy(data.Scan0, bytes, 0, size);
            image.UnlockBits(data);

            return bytes;
        }

        /// <summary>
        /// Sets the history.
        /// </summary>
        private void PushHistory()
        {
            // Create a new list of bitmaps.
            List<Bitmap> tiles = new List<Bitmap>();

            // Clone all tiles.
            foreach (Bitmap tile in pnl_Tileset.Tiles)
            {
                // If the tile has not been cleared, add it, else add empty.
                if (tile != null)
                {
                    Bitmap image = (Bitmap)tile.Clone();
                    image.Tag = (int)tile.Tag;
                    tiles.Add(image);
                }
                else
                    tiles.Add(null);
            }

            // Get needed data.
            TileData data = new TileData(tiles, pnl_Tileset.Columns);

            // Set history.
            if (_history.InUndoRedo == false)
                _history.Do(new TilesMemento(data));

            // Set undo/redo buttons.
            tsb_Undo.Enabled = _history.CanUndo;
            tsb_Redo.Enabled = _history.CanRedo;

            // Check for ok button enable.
            CheckAccept();
        }

        /// <summary>
        /// Checks if the form is in a valid state to allow the ok button.
        /// </summary>
        private void CheckAccept()
        {
            // If the tiles are not empty, and the tile count is greater than zero, allow accept.
            if (pnl_Tileset.Tiles != null && pnl_Tileset.Tiles.Count > 0)
                tsb_Ok.Enabled = true;
            else
                tsb_Ok.Enabled = false;
        }

        /// <summary>
        /// Sets the GUI, based on if tiles are being compiled.
        /// </summary>
        /// <param name="compiling"></param>
        private void SetGUI(bool compiling)
        {
            // If compiling, disable certain GUI options.
            if (compiling == true)
            {
                // Set toolstrip.
                tsb_Ok.Enabled = false;
                tsb_Cancel.Enabled = false;
                tsb_Compile.Enabled = false;
                tsb_CancelCompile.Enabled = true;
                tsb_Grid.Enabled = false;

                nud_Columns.Enabled = false;
                tb_Name.Enabled = false;

                // Set tile options.
                gb_TileSize.Enabled = false;
                gb_Seperation.Enabled = false;
                gb_Offset.Enabled = false;

                // Clear history.
                _history.Clear();
            }
            else
            {
                // Set toolstrip.
                tsb_Ok.Enabled = true;
                tsb_Cancel.Enabled = true;
                tsb_Compile.Enabled = true;
                tsb_CancelCompile.Enabled = false;
                tsb_Grid.Enabled = true;

                nud_Columns.Enabled = true;
                tb_Name.Enabled = true;

                // Set tile options.
                gb_TileSize.Enabled = true;
                gb_Seperation.Enabled = true;
                gb_Offset.Enabled = true;
            }

            // Set undo/redo buttons.
            tsb_Undo.Enabled = _history.CanUndo;
            tsb_Redo.Enabled = _history.CanRedo;
        }

        #endregion
    }
}