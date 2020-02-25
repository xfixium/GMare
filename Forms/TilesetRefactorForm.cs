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
using Pyxosoft.Windows.Tools.PyxTools.Controls;
using GMare.Objects;
using GMare.Controls;
using GenericUndoRedo;

namespace GMare.Forms
{
    /// <summary>
    /// A form to rearrange a tileset without affecting the room design
    /// </summary>
    public partial class TilesetRefactorForm : Form, ITilesOwner
    {
        #region Fields

        private UndoRedoHistory<ITilesOwner> _history;  // The form undo/redo history
        private GMareBackground _background = null;     // The changed background
        private Size _originalSize = Size.Empty;        // The original size of the background before it has been edited
        private int[] _targets;                         // The array of tile targets
        private int[] _replacements;                    // The array of tile replacements
        private bool _changed = false;                  // If the background has changed

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
        /// Gets the new background
        /// </summary>
        public GMareBackground Background
        {
            get { return _background; }
        }

        /// <summary>
        /// Gets the tiles that are being targetted for replacement
        /// </summary>
        public int[] Targets
        {
            get { return _targets; }
        }

        /// <summary>
        /// Gets the tiles that are replacements for targetted tiles
        /// </summary>
        public int[] Replacements
        {
            get { return _replacements; }
        }

        /// <summary>
        /// Gets if the background has changed
        /// </summary>
        public bool Changed
        {
            get { return _changed; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a new tileset refactor form
        /// </summary>
        public TilesetRefactorForm()
        {
            InitializeComponent();

            // Create a new room
            _background = App.Room.Backgrounds[0].Clone();
            _originalSize = new Size(_background.Image.Width, _background.Image.Height);

            // Create new undo/redo history
            butUndo.Enabled = false;
            butRedo.Enabled = false;
            _history = new UndoRedoHistory<ITilesOwner>(this, 20);

            // Get the tiles from the background
            PopulateTiles(_background.GetCondensedTileset());

            // Set up the UI based on the data given
            SetUI();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Process dialog key
        /// </summary>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            // Do action based on key and any modifiers
            if (keyData == (Keys.Control | Keys.Z))
                butUndo_Click(butUndo, EventArgs.Empty);
            else if (keyData == (Keys.Control | Keys.Y))
                butRedo_Click(butRedo, EventArgs.Empty);
            else if (keyData == (Keys.Control | Keys.R))
                pnlTileset.ExecuteContextAction(GMareTilesetRefactorEditor.ContextActionType.Deselect);

            // Do action based on key
            switch (keyData)
            {
                case Keys.G: butGrid.Checked = butGrid.Checked ? false : true; break;
                case Keys.Delete: pnlTileset.ExecuteContextAction(GMareTilesetRefactorEditor.ContextActionType.Clear); break;
            }

            // Process
            return base.ProcessDialogKey(keyData);
        }

        #endregion

        #region Events

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
        /// Size numerics value changed
        /// </summary>
        private void nudSize_ValueChanged(object sender, EventArgs e)
        {
            // If the tiles are not empty, push history
            if (pnlTileset.Tiles != null || pnlTileset.Tiles.Count != 0)
                PushHistory();

            // Get the name of the control
            string name = (sender as PyxNumericUpDown).Name;

            // Do action based on control
            if (nudColumns.Name == name)
                pnlTileset.Columns = (int)nudColumns.Value;
            else if (nudRows.Name == name)
                pnlTileset.Rows = (int)nudRows.Value;

            // Update status
            SetStatus();
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
        /// Tileset panel changed
        /// </summary>
        private void pnlTileset_PanelChanged()
        {
            // Push history
            PushHistory();

            // The background has changed
            _changed = true;
        }

        /// <summary>
        /// Ok button click
        /// </summary>
        private void butOk_Click(object sender, EventArgs e)
        {
            // If the sizes are different, then changed (Simple check)
            if (_originalSize.Width != pnlTileset.TilesetWidth || _originalSize.Height != pnlTileset.TilesetHeight)
                _changed = true;

            // Set targets and replacements
            _targets = pnlTileset.Targets.ToArray();
            _replacements = pnlTileset.Replacements.ToArray();

            // Set the background
            _background.Image = new Graphics.PixelMap(pnlTileset.GetImage(_background.Offset, _background.Separation));

            // Set dialog result
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Cancel button click
        /// </summary>
        private void butCancel_Click(object sender, EventArgs e)
        {
            // Set dialog result
            DialogResult = DialogResult.Cancel;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates individual tiles from the existing background
        /// </summary>
        /// <param name="tileset">The tileset to grid to individual tiles</param>
        private void PopulateTiles(Bitmap tileset)
        {
            // Get background data
            List<Bitmap> tiles = new List<Bitmap>();
            Size size = App.Room.Backgrounds[0].GetGridSize();
            Size tileSize = App.Room.Backgrounds[0].TileSize;
            Size seperation = new Size(App.Room.Backgrounds[0].SeparationX, App.Room.Backgrounds[0].SeparationY);
            Point offset = new Point(App.Room.Backgrounds[0].OffsetX, App.Room.Backgrounds[0].OffsetY);
            Rectangle rect = new Rectangle(Point.Empty, tileSize);

            pnlTileset.Columns = size.Width;

            // Iterate through image columns and rows
            for (int row = 0; row < size.Height; row++)
            {
                for (int col = 0; col < size.Width; col++)
                {
                    // Set position
                    rect.X = col * tileSize.Width;
                    rect.Y = row * tileSize.Height;

                    // Create a tile bitmap, and remember it's original id
                    Bitmap tile = tileset.Clone(rect, tileset.PixelFormat);
                    tile.Tag = GMareBrush.PositionToSourceTileId(rect.Location.X, rect.Location.Y, tileset.Width, tileSize);

                    // Add bitmap to tiles
                    tiles.Add(tile);
                }
            }

            // Populate tile editor
            pnlTileset.SnapSize = tileSize;
            pnlTileset.Tiles = tiles;
            tileset.Dispose();
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
        }

        /// <summary>
        /// Sets the status bar information
        /// </summary>
        private void SetStatus()
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
                "Size: N/A" : "Size: " + pnlTileset.TilesetWidth + ", " + pnlTileset.TilesetHeight);
        }

        /// <summary>
        /// Sets the UI, based on if tiles are being compiled
        /// </summary>
        /// <param name="compiling">If compiling tiles</param>
        private void SetUI()
        {
            Size size = _background.GetGridSize();

            // Set UI
            nudColumns.Value = size.Width;
            nudRows.Value = size.Height;
            butUndo.Enabled = _history.CanUndo;
            butRedo.Enabled = _history.CanRedo;
        }

        #endregion
    }
}