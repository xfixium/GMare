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
using System.Collections.Generic;
using GMare.Objects;
using Pyxosoft.Windows.Tools.PyxTools.Controls;

namespace GMare.Controls
{
    /// <summary>
    /// A control that shows a visual representation of tile ids optimized for Game Maker
    /// </summary>
    public partial class GMareTileConversionPanel : PyxCanvas
    {
        #region Fields

        private GMareLayer _layer = null;  // Layer to draw
        private int _tileCount = 0;        // Number of tiles on the layer

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the layer to draw
        /// </summary>
        public GMareLayer Layer
        {
            get { return _layer; }
            set
            {
                _layer = value;

                // Update canvas size for scrollbars
                if (App.Room != null)
                    CanvasSize = new Size(App.Room.Width + 1, App.Room.Height + 1);

                UpdateBackBuffer();
            }
        }

        /// <summary>
        /// Get the number of tiles on the layer after optimization
        /// </summary>
        public int TileCount
        {
            get { return _tileCount; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new tile conversion panel
        /// </summary>
        public GMareTileConversionPanel()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// On draw on backbuffer
        /// </summary>
        protected override void OnDrawOnBackbuffer(ref System.Drawing.Graphics gfx)
        {
            // If layer is empty or background is empty, return
            if (_layer == null || App.Room.Backgrounds[0] == null || App.Room.Backgrounds[0].Image == null)
                return;

            // Draw layer
            gfx.DrawImageUnscaled(_layer.GetLayerImage(App.Room.Backgrounds[0], App.Room.Backgrounds[0].GetCondensedTileset(), .5f), Point.Empty);
        
            // Convert tile ids to optimized binary tiles and reset the tile count
            ExportTile[] tiles = _layer.GetExportTiles(App.Room.Backgrounds[0], false, -1);
            _tileCount = 0;

            // If there are rectangles to draw, draw them
            if (tiles != null || tiles.Length > 0)
            {
                // Create a list of rectangles
                List<Rectangle> rects = new List<Rectangle>();

                // Iterate through tiles
                foreach (ExportTile tile in tiles)
                    rects.Add(tile.Rect);

                // Draw rectangles and set tile count
                gfx.DrawRectangles(Pens.Red, rects.ToArray());
                _tileCount = rects.Count;
            }
        }

        #endregion
    }
}
