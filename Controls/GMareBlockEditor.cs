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
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using GMare.Objects;
using Pyxosoft.Windows.Tools.PyxTools.Controls;

namespace GMare.Controls
{
    public partial class GMareBlockEditor : PyxPictureBox
    {
        #region Fields

        private GMareBackground _background = null;  // Background instance.
        private int _objectId = -1;                  // The selected object id
        private ColorMatrix _cm = null;              // Alpha color matrix

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the selected background
        /// </summary>
        public GMareBackground SelectedBackground
        {
            get { return _background; }
            set { _background = value; }
        }

        /// <summary>
        /// Gets or sets the object id
        /// </summary>
        public int ObjectId
        {
            get { return _objectId; }
            set { _objectId = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new block editor
        /// </summary>
        public GMareBlockEditor()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// On draw backbuffer
        /// </summary>
        protected override void OnDrawOnBackbuffer(ref System.Drawing.Graphics gfx)
        {
            // If the color matrix is empty, create it
            if (_cm == null)
                _cm = new ColorMatrix(new float[][] {
                    new float[]{ 1.0f, 0.0f, 0.0f, 0.0f, 0.0f},
                    new float[]{ 0.0f, 1.0f, 0.0f, 0.0f, 0.0f},
                    new float[]{ 0.0f, 0.0f, 1.0f, 0.0f, 0.0f},
                    new float[]{ 0.0f, 0.0f, 0.0f, 0.5f, 0.0f},
                    new float[]{ 0.0f, 0.0f, 0.0f, 0.0f, 1.0f} });

            // Create new image attributes
            ImageAttributes ia = new ImageAttributes();
            ia.SetColorMatrix(_cm);

            // Get tile size
            Size tileSize = _background.TileSize;
            tileSize.Width += 1;
            tileSize.Height += 1;

            // Iterate through instances
            foreach (GMareInstance inst in App.Room.Blocks)
            {
                // Get the object associated with this instance
                GMareObject obj = App.Room.Objects.Find(delegate(GMareObject o) { return o.Resource.Id == inst.ObjectId; });

                // If no object was found, continue
                if (obj == null)
                    continue;

                // Get drawing point
                Point point = GMareBrush.TileIdToPosition(inst.TileId, Image.Width, tileSize);
                point.X += 1;
                point.Y += 1;

                Bitmap image = obj.Image.ToBitmap();

                // Draw glyph
                gfx.DrawImage(image, new Rectangle(point.X, point.Y, obj.Image.Width, obj.Image.Height), 0, 0, obj.Image.Width, obj.Image.Height, GraphicsUnit.Pixel, ia);
                image.Dispose();
            }

            // Dispose.
            ia.Dispose();
        }

        /// <summary>
        /// On mouse down
        /// </summary>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            // If the project or tileset do not exist or the object id is empty, return
            if (App.Room == null || Image == null)
                return;

            // Focus for scroll support
            Focus();

            // Get start snapped position
            Point snap = GetOffsetSnappedPoint(e.Location);

            // If the mouse is within the image dimensions
            if (!new Rectangle(0, 0, Image.Width, Image.Height).Contains(snap))
                return;

            // Set id
            Size tileSize = _background.TileSize;
            tileSize.Width += 1;
            tileSize.Height += 1;

            int tileId = GMareBrush.PositionToTileId(snap.X, snap.Y, Image.Width, tileSize);

            // If left click and not an empty tile id, set object, if right click, erase
            if (e.Button == MouseButtons.Left && _objectId != -1)
                App.Room.AddBlock(_objectId, tileId);
            else if (e.Button == MouseButtons.Right)
                App.Room.DeleteBlock(_objectId, tileId);

            // Update backbuffer
            UpdateBackBuffer();

            // Allow hooking of this event
            base.OnMouseDown(e);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Calculates a offset snapped version of a point
        /// </summary>
        /// <param name="position">The point to calculate</param>
        /// <returns>A snapped point</returns>
        private Point GetOffsetSnappedPoint(Point position)
        {
            // Calculate snapped position
            Size tileSize = _background.TileSize;
            tileSize.Width += 1;
            tileSize.Height += 1;

            int width = (int)(tileSize.Width * Zoom);
            int height = (int)(tileSize.Height * Zoom);
            int x = (int)((((position.X - AutoScrollPosition.X) / width) * width) / Zoom);
            int y = (int)((((position.Y - AutoScrollPosition.Y) / height) * height) / Zoom);
            x = (x / tileSize.Width) * tileSize.Width;
            y = (y / tileSize.Height) * tileSize.Height;

            return new Point(x, y);
        }

        #endregion
    }
}
