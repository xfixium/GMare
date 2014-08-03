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
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GMare.Objects;
using GMare.Controls;
using GenericUndoRedo;

namespace GMare.Forms
{
    /// <summary>
    /// Creates a room from an imported image
    /// </summary>
    public partial class ImportImageForm : Form, ITilesOwner
    {
        #region Fields

        private UndoRedoHistory<ITilesOwner> _history;  // The form undo/redo history
        private GMareRoom _newRoom = null;              // The newly created room

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the tile data
        /// </summary>
        public TileData Data
        {
            get { return new TileData(pnlTileset.Tiles, pnlTileset.Columns); }
            set
            {
                // Set the tiles panel
                nudColumns.Value = value.Columns;
                pnlTileset.Columns = value.Columns;
                pnlTileset.Tiles = value.Tiles;
            }
        }

        /// <summary>
        /// Gets the newly created room
        /// </summary>
        public GMareRoom NewRoom
        {
            get { return _newRoom; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new import image form
        /// </summary>
        /// <param name="image">The image used as a room</param>
        public ImportImageForm(Bitmap image)
        {
            InitializeComponent();

            // Create a new room
            _newRoom = new GMareRoom();
            _newRoom.Name = "New Room";

            // Set target room image
            pnlImage.BackgroundImage = image;
            pnlImage.AutoScrollMinSize = image.Size;

            // Disable cancel tile compile button
            butCompileCancel.Enabled = false;
            butUndo.Enabled = false;
            butRedo.Enabled = false;
            txtName.Text = _newRoom.Name;

            // Create new undo/redo history
            _history = new UndoRedoHistory<ITilesOwner>(this, 20);

            // Check for ok button enable
            CheckAccept();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Process dialog key
        /// </summary>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            // If any textboxes have focus, ignore processing
            if (txtName.Focused)
                return base.ProcessDialogKey(keyData);

            // Do action based on key and any modifiers
            if (keyData == (Keys.Control | Keys.Z))
                butUndo_Click(butUndo, EventArgs.Empty);
            else if (keyData == (Keys.Control | Keys.Y))
                butRedo_Click(butRedo, EventArgs.Empty);
            else if (keyData == (Keys.Control | Keys.R))
                pnlTileset.ExecuteContextAction(GMareTileEditor.ContextActionType.Deselect);

            // Do action based on key
            switch (keyData)
            {
                case Keys.C: butCompile_Click(butCompile, EventArgs.Empty); break;
                case Keys.G: butGrid.Checked = butGrid.Checked ? false : true; break;
                case Keys.Delete: pnlTileset.ExecuteContextAction(GMareTileEditor.ContextActionType.Clear); break;
            }

            // Process
            return base.ProcessDialogKey(keyData);
        }
        
        #endregion

        #region Events

        /// <summary>
        /// Compile button click
        /// </summary>
        private void butCompile_Click(object sender, EventArgs e)
        {
            // If a tiles list already exists and there are tiles, warn the user
            if (pnlTileset.Tiles != null && pnlTileset.Tiles.Count > 0)
            {
                // Ask the user a question
                DialogResult result = MessageBox.Show("Compiling tiles will delete existing compiled tile data. Are you sure you want to continue?", "GMare", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                // If the user chose yes, empty tiles, else return
                if (result == DialogResult.Yes)
                {
                    // Clear tiles
                    pnlTileset.Tiles.Clear();

                    // Clear history
                    _history.Clear();
                }
                else
                    return;
            }

            // Set GUI
            SetUI(true);

            // Set status
            SetStatus("Compiling tiles");
            Refresh();

            // Compile tiles
            bgwCompile.RunWorkerAsync();
        }

        /// <summary>
        /// Cancel tile compile click
        /// </summary>
        private void butCancelCompile_Click(object sender, EventArgs e)
        {
            // If compiling tiles, cancel tile compilation
            if (bgwCompile.IsBusy == true)
                bgwCompile.CancelAsync();
        }

        /// <summary>
        /// Undo button click
        /// </summary>
        private void butUndo_Click(object sender, EventArgs e)
        {
            // If able to undo, undo
            if (_history.CanUndo == true)
                _history.Undo();

            // Set undo/redo buttons
            butUndo.Enabled = _history.CanUndo;
            butRedo.Enabled = _history.CanRedo;
        }

        /// <summary>
        /// Redo button click
        /// </summary>
        private void butRedo_Click(object sender, EventArgs e)
        {
            // If able to redo, redo
            if (_history.CanRedo == true)
                _history.Redo();

            // Set undo/redo buttons
            butUndo.Enabled = _history.CanUndo;
            butRedo.Enabled = _history.CanRedo;
        }

        /// <summary>
        /// Show grid button checked changed
        /// </summary>
        private void butShowGrid_CheckChanged(object sender)
        {
            // Toggle grid
            pnlTileset.ShowGrid = butGrid.Checked;
        }

        /// <summary>
        /// Numeric up and down columns value changed
        /// </summary>
        private void nudColumns_ValueChanged(object sender, EventArgs e)
        {
            // If the tiles are not empty, push history
            if (pnlTileset.Tiles != null || pnlTileset.Tiles.Count != 0)
                PushHistory();

            // Set the width of the tileset
            pnlTileset.Columns = (int)nudColumns.Value;

            // Update status
            SetStatus("");
        }

        /// <summary>
        /// Tileset panel changed
        /// </summary>
        private void pnlTileset_PanelChanged()
        {
            // Push history
            PushHistory();
        }

        /// <summary>
        /// Magnification changed
        /// </summary>
        private void trkMagnify_ValueChanged(object sender, EventArgs e)
        {
            // Set magnification
            pnlTileset.Zoom = trkMagnify.Value;
            lblMagnify.Text = (trkMagnify.Value * 100).ToString() + "%";
        }

        /// <summary>
        /// Ok button click
        /// </summary>
        private void butOk_Click(object sender, EventArgs e)
        {
            // If no tiles, return
            if (pnlTileset.Tiles.Count == 0)
            {
                // Show message
                MessageBox.Show("The tileset has no tiles. Room creation aborted.", "GMare", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            // The end resulting tile replacements
            int[] replacements = new int[pnlTileset.Tiles.Count];
            int[] targets = new int[replacements.Length];

            // Get target and replacement tile ids
            for (int i = 0; i < replacements.Length; i++)
            {
                // If the tile is empty, give empty id, else target id
                if (pnlTileset.Tiles[i] != null)
                {
                    // Set the replacement and target ids
                    replacements[i] = i;
                    targets[i] = (int)pnlTileset.Tiles[i].Tag;
                }
            }

            // Set room
            _newRoom.Name = txtName.Text;
            _newRoom.Backgrounds[0].Image = new Graphics.PixelMap(pnlTileset.GetImage());
            _newRoom.Layers[0].Replace(targets, replacements);

            // Set dialog result
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Cancel button click
        /// </summary>
        private void butCancel_Click(object sender, EventArgs e)
        {
            // Dispose of new room
            _newRoom.Dispose();

            // Set dialog result
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Compile tiles
        /// </summary>
        private void bgwCompile_DoWork(object sender, DoWorkEventArgs e)
        {
            // Hook into background worker for any cancellations
            BackgroundWorker bw = sender as BackgroundWorker;

            // Get neccessary data
            Size tileSize = new Size((int)nudTileX.Value, (int)nudTileY.Value);
            Size seperation = new Size((int)nudSeperationX.Value, (int)nudSeperationY.Value);
            Point offset = new Point((int)nudOffsetX.Value, (int)nudOffsetY.Value);
            Bitmap image = (Bitmap)pnlImage.BackgroundImage;

            // Calculate the number of columns and rows
            int cols = (int)Math.Ceiling((double)(image.Width - offset.X) / (double)(tileSize.Width + seperation.Width));
            int rows = (int)Math.Ceiling((double)(image.Height - offset.Y) / (double)(tileSize.Height + seperation.Height));

            // Set looping variables
            bool match = false;
            int i = 0;
            int total = cols * rows;

            // Byte array collection for unique tiles
            List<byte[]> imageData = new List<byte[]>();

            // A list of accepted unique tile bitmaps
            List<Bitmap> tiles = new List<Bitmap>();

            // Create an empty layer
            GMareLayer layer = new GMareLayer(cols, rows);

            // Copy rectangle
            Rectangle rect = new Rectangle(0, 0, tileSize.Width, tileSize.Height);

            // Iterate through image tile rows
            for (int row = 0; row < rows; row++)
            {
                // Iterate through image tile columns
                for (int col = 0; col < cols; col++)
                {
                    // Set copy rectangle position
                    rect.X = (col * tileSize.Width + (col * seperation.Width)) + offset.X;
                    rect.Y = (row * tileSize.Height + (row * seperation.Height)) + offset.Y;

                    // Copy a section of the image pixel data fast
                    byte[] compare = GetTileBytes(image, rect);

                    // If the compare is empty, skip over validation process
                    if (compare == null)
                        continue;

                    // Set match variable
                    match = false;

                    // Iterate through existing unique tiles for a match
                    for (int j = 0; j < imageData.Count; j++)
                    {
                        // If the compare is equal to the tile
                        if (CompareTiles(compare, imageData[j]) == true)
                        {
                            // Match is true
                            match = true;

                            // Set tile id, which is the same as the tile's index at this point
                            layer.Tiles[col, row].TileId = j;
                            break;
                        }
                    }

                    // No match was found
                    if (match == false)
                    {
                        // New tile id
                        layer.Tiles[col, row].TileId = imageData.Count;

                        // Add tile to unique tile list
                        imageData.Add(compare);

                        try
                        {
                            // Create a tile bitmap, and remember it's original id
                            Bitmap tile = GMare.Graphics.PixelMap.PixelDataToBitmap(GMare.Graphics.PixelMap.GetPixels(image, rect));
                            tile.Tag = imageData.Count - 1;

                            // Add bitmap to tiles
                            tiles.Add(tile);
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("When compiling the tiles, the image's color depth of: " + error.Message + ", is not supported.", "GMare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    // Increment progress
                    i++;

                    // Report progress
                    bw.ReportProgress(i * 100 / total);
                }

                // If cancelling, return
                if (bw.CancellationPending == true)
                {
                    // Clear tile data
                    tiles.Clear();
                    tiles = null;

                    // Cancel processing
                    e.Cancel = true;
                    return;
                }
            }

            // Populate tile editor
            pnlTileset.SnapSize = tileSize;
            pnlTileset.Tiles = tiles;

            // Set room properties
            _newRoom.Backgrounds[0].TileWidth = tileSize.Width;
            _newRoom.Backgrounds[0].TileHeight = tileSize.Height;
            _newRoom.Columns = cols;
            _newRoom.Rows = rows;
            _newRoom.Layers.Clear();
            _newRoom.Layers.Add(layer);
        }

        /// <summary>
        /// Compiler progress changed event
        /// </summary>
        private void bgwCompile_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Set progress bar progress amount
            barProgress.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Compiler done event
        /// </summary>
        private void bgwCompile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Setup GUI
            SetUI(false);

            // Reset progress bar
            barProgress.Value = 0;

            // Update status information
            SetStatus("Ready");

            // Check for ok button enable
            CheckAccept();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Compares to tiles bytes, returns whether they match or not
        /// </summary>
        /// <param name="tile1">The first tile to compare</param>
        /// <param name="tile2">The second tile to compare</param>
        /// <returns>If the tiles match</returns>
        private bool CompareTiles(byte[] tile1, byte[] tile2)
        {
            // Iterate through bytes, if there is a mismatch in bytes, then tiles don't match
            for (int i = 0; i < tile1.Length; i++)
                if (tile1[i] != tile2[i])
                    return false;

            // The tiles match
            return true;
        }

        /// <summary>
        /// Gets a byte array of image data
        /// </summary>
        /// <param name="image">The bitmap to get the image data from</param>
        /// <param name="selection">The size of the tile</param>
        /// <returns>A byte array</returns>
        public byte[] GetTileBytes(Bitmap image, Rectangle selection)
        {
            // If the selection end point is out of image bounds, return null
            if (selection.X + selection.Width > image.Width || selection.Y + selection.Height > image.Height)
                return null;

            // Get image bytes
            BitmapData data = image.LockBits(selection, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
            
            int size = data.Stride * selection.Height;
            byte[] bytes = new byte[size];
            Marshal.Copy(data.Scan0, bytes, 0, size);
            image.UnlockBits(data);

            return bytes;
        }

        /// <summary>
        /// Sets the history
        /// </summary>
        private void PushHistory()
        {
            // Create a new list of bitmaps
            List<Bitmap> tiles = new List<Bitmap>();

            // Clone all tiles
            foreach (Bitmap tile in pnlTileset.Tiles)
            {
                // If the tile has not been cleared, add it, else add empty
                if (tile != null)
                {
                    Bitmap image = (Bitmap)tile.Clone();
                    image.Tag = (int)tile.Tag;
                    tiles.Add(image);
                }
                else
                    tiles.Add(null);
            }

            // Get needed data
            TileData data = new TileData(tiles, pnlTileset.Columns);

            // Set history
            if (_history.InUndoRedo == false)
                _history.Do(new TilesMemento(data));

            // Set undo/redo buttons
            butUndo.Enabled = _history.CanUndo;
            butRedo.Enabled = _history.CanRedo;

            // Check for Ok button enable
            CheckAccept();
        }

        /// <summary>
        /// Checks if the form is in a valid state to allow the ok button
        /// </summary>
        private void CheckAccept()
        {
            // If the tiles are not empty, and the tile count is greater than zero, enable Ok button
            butOk.Enabled = pnlTileset.Tiles != null && pnlTileset.Tiles.Count > 0 ? true : false;
        }

        /// <summary>
        /// Sets the status bar information
        /// </summary>
        private void SetStatus(string status)
        {
            // If there are tiles
            if (pnlTileset.Tiles != null)
            {
                // Show the amount of tiles
                lblTileCount.Text = "Tile Count: " + pnlTileset.Tiles.Count;

                // Set the magnification level of the tile editor
                pnlTileset.Zoom = trkMagnify.Value;
            }

            lblTilesetSize.Text = (pnlTileset.Tiles == null || pnlTileset.Tiles.Count == 0 ? 
                "Size: N/A" : "Size: " + pnlTileset.TilesetSize.Width + ", " + pnlTileset.TilesetSize.Height);
            lblStatus.Text = (status == "" ? lblStatus.Text : "Status: " + status);
        }

        /// <summary>
        /// Sets the UI, based on if tiles are being compiled
        /// </summary>
        /// <param name="compiling">If compiling tiles</param>
        private void SetUI(bool compiling)
        {
            // Set UI
            butOk.Enabled = compiling ? false : true;
            butCancel.Enabled = compiling ? false : true;
            butCompile.Enabled = compiling ? false : true;
            butCompileCancel.Enabled = compiling ? true : false;
            butGrid.Enabled = compiling ? false : true;
            nudColumns.Enabled = compiling ? false : true;
            txtName.Enabled = compiling ? false : true;
            grpTileSize.Enabled = compiling ? false : true;
            grpSeperation.Enabled = compiling ? false : true;
            grpTileOffset.Enabled = compiling ? false : true;

            // Clear history
            if (compiling)
                _history.Clear();

            // Set undo/redo buttons
            butUndo.Enabled = _history.CanUndo;
            butRedo.Enabled = _history.CanRedo;
        }

        #endregion
    }
}