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
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using GameMaker.Resource;
using GMare.Common;

namespace GMare.Controls
{
    public partial class RoomEditor : UserControl
    {
        #region Fields

        public event PositionHandler PositionChanged;           // Mouse position changed event.
        public delegate void PositionHandler();                 // Mouse poisition changed event handler.
        public event InstanceChangedHandler InstanceChanged;    // Selected instance changed event.
        public delegate void InstanceChangedHandler();          // Selected instance changed event handler.
        public event RoomChangedHandler RoomChanged;            // Room changed event.
        public delegate void RoomChangedHandler();              // Room changed event handler.
        public event ClipboardChangedHandler ClipboardChanged;  // Clipboard contents changed.
        public delegate void ClipboardChangedHandler();         // Clipboard contents changed handler.

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the currently selected shape.
        /// </summary>
        public GMareCollision SelectedShape
        {
            get { return pnl_Room.SelectedShape; }
            set { pnl_Room.SelectedShape = value; }
        }

        /// <summary>
        /// Gets or sets the currently selected object.
        /// </summary>
        public GMareObject SelectedObject
        {
            get { return pnl_Room.SelectedObject; }
            set { pnl_Room.SelectedObject = value; }
        }

        /// <summary>
        /// Gets or sets the currently selected instance.
        /// </summary>
        public GMareInstance SelectedInstance
        {
            get { return pnl_Room.SelectedInstance; }
            set
            {
                pnl_Room.SelectedInstance = value;

                // If the selected instance is not empty, and in instance edit mode.
                if (SelectedInstance != null && EditMode == EditType.Instances && ProjectManager.Room != null)
                {
                    // Get object.
                    GMareObject obj = ProjectManager.Room.Objects.Find(delegate(GMareObject o) {return o.Resource.Id == SelectedInstance.ObjectId; });

                    // If no object was found return.
                    if (obj == null)
                        return;

                    // Get Instance rectangle.
                    Rectangle rect = new Rectangle(SelectedInstance.X, SelectedInstance.Y, obj.Image.Width, obj.Image.Height);
                    Rectangle view = new Rectangle(pnl_Room.Offset.X, pnl_Room.Offset.Y, (int)(pnl_Room.ClientSize.Width / Zoom), (int)(pnl_Room.ClientSize.Height / Zoom));
                    
                    // If the selected instance is not within the viewport.
                    if (view.IntersectsWith(rect) == false)
                    {
                        // Calculate scroll position on selected instance centered.
                        int x = rect.X - ((int)(pnl_Room.ClientSize.Width / Zoom) / 2) + (rect.Width / 2);
                        int y = rect.Y - ((int)(pnl_Room.ClientSize.Height / Zoom) / 2) + (rect.Height / 2);

                        // Stay within minimum and maximum values.
                        x = x < 0 ? 0 : x;
                        y = y < 0 ? 0 : y;
                        x = x > sb_Horizontal.Maximum ? sb_Horizontal.Maximum : x;
                        y = y > sb_Vertical.Maximum ? sb_Vertical.Maximum : y;

                        // Scroll to position.
                        sb_Horizontal.Value = x;
                        sb_Vertical.Value = y;

                        // Set the scrollbars.
                        SetScrollbars();
                    }
                }

                // Force redraw.
                pnl_Room.Invalidate();
            }
        }

        /// <summary>
        /// Gets the instance clipboard.
        /// </summary>
        public GMareInstance InstanceClipboard
        {
            get { return pnl_Room.InstanceClipboard; }
        }

        /// <summary>
        /// Gets the selection clipboard.
        /// </summary>
        public TileGrid SelectionClipboard
        {
            get { return pnl_Room.SelectionClipboard; }
        }

        /// <summary>
        /// Gets or sets the selected layer.
        /// </summary>
        public EditType EditMode
        {
            get { return pnl_Room.EditMode; }
            set { pnl_Room.EditMode = value; }
        }

        /// <summary>
        /// Gets or sets the current drawing tool type.
        /// </summary>
        public ToolType ToolMode
        {
            get { return pnl_Room.ToolMode; }
            set { pnl_Room.ToolMode = value; }
        }

        /// <summary>
        /// Gets or sets the type of shape tool currently used.
        /// </summary>
        public ShapeType ShapeMode
        {
            get { return pnl_Room.ShapeMode; }
            set { pnl_Room.ShapeMode = value; }
        }

        /// <summary>
        /// Gets or sets the drawing grid mode.
        /// </summary>
        public GridType GridMode
        {
            get { return pnl_Room.GridMode; }
            set { pnl_Room.GridMode = value; }
        }

        /// <summary>
        /// Gets or sets the grid of selected tiles.
        /// </summary>
        public TileGrid Tiles
        {
            get { return pnl_Room.Tiles; }
            set { pnl_Room.Tiles = value; }
        }

        /// <summary>
        /// Gets the current selection.
        /// </summary>
        public TileGrid Selection
        {
            get { return pnl_Room.Selection; }
        }

        /// <summary>
        /// Sets the image to use as a texture.
        /// </summary>
        public Bitmap Image
        {
            set { pnl_Room.Image = value; }
        }

        /// <summary>
        /// Gets the actual mouse position.
        /// </summary>
        public string MouseActual
        {
            get { return pnl_Room.MouseActual; }
        }

        /// <summary>
        /// Gets the sector the mouse is over.
        /// </summary>
        public string MouseSector
        {
            get { return pnl_Room.MouseSector; }
        }

        /// <summary>
        /// Gets the current mouse snapped position.
        /// </summary>
        public string MouseSnapped
        {
            get { return pnl_Room.MouseSnapped; }
        }

        /// <summary>
        /// Gets or sets the scale factor of the room panel.
        /// </summary>
        public float Zoom
        {
            get { return pnl_Room.Zoom; }
            set { pnl_Room.Zoom = value; SetScrollbars(); }
        }

        /// <summary>
        /// Gets or sets the layer depth currently selected.
        /// </summary>
        public int DepthIndex
        {
            get { return pnl_Room.DepthIndex; }
            set { pnl_Room.DepthIndex = value; }
        }

        /// <summary>
        /// Gets or sets the layer index currently selected.
        /// </summary>
        public int LayerIndex
        {
            get { return pnl_Room.LayerIndex; }
            set { pnl_Room.LayerIndex = value; }
        }

        /// <summary>
        /// Gets or sets the horizontal grid spacing.
        /// </summary>
        public int GridX
        {
            get { return pnl_Room.GridX; }
            set { pnl_Room.GridX = value; }
        }

        /// <summary>
        /// Gets or sets the vertical grid spacing.
        /// </summary>
        public int GridY
        {
            get { return pnl_Room.GridY; }
            set { pnl_Room.GridY = value; }
        }

        /// <summary>
        /// Gets or sets the level of the collsion.
        /// </summary>
        public int Level
        {
            get { return pnl_Room.Level; }
            set { pnl_Room.Level = value; }
        }

        /// <summary>
        /// Gets or sets the show grid property.
        /// </summary>
        public bool ShowGrid
        {
            get { return pnl_Room.ShowGrid; }
            set { pnl_Room.ShowGrid = value; }
        }

        /// <summary>
        /// Gets or sets whether to snap instances to the grid.
        /// </summary>
        public bool Snap
        {
            get { return pnl_Room.Snap ; }
            set { pnl_Room.Snap = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new room editor.
        /// </summary>
        public RoomEditor()
        {
            InitializeComponent();

            // Sets the scrollbars.
            SetScrollbars();

            // Set the backcolor for mock visual styled border.
            BackColor = System.Windows.Forms.VisualStyles.VisualStyleInformation.TextControlBorder;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// OnPaint override.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Set up the scrollbars.
            SetScrollbars();

            // Invalidate the room panel.
            pnl_Room.Invalidate();
        }

        #endregion

        #region Events

        /// <summary>
        /// Vertical scrollbar value changed.
        /// </summary>
        private void sb_Vertical_ValueChanged(object sender, EventArgs e)
        {
            // Set room offset.
            pnl_Room.Offset = new Point(pnl_Room.Offset.X, sb_Vertical.Value);
        }

        /// <summary>
        /// Horizontal scrollbar value changed.
        /// </summary>
        private void sb_Horizontal_ValueChanged(object sender, EventArgs e)
        {
            // Set room offset.
            pnl_Room.Offset = new Point(sb_Horizontal.Value, pnl_Room.Offset.Y);
        }

        /// <summary>
        /// Room panel position changed.
        /// </summary>
        private void pnl_Room_PositionChanged()
        {
            if (PositionChanged != null)
                PositionChanged();
        }

        /// <summary>
        /// Room panel instance changed.
        /// </summary>
        private void pnl_Room_InstanceChanged()
        {
            if (InstanceChanged != null)
                InstanceChanged();
        }

        /// <summary>
        /// Room clipboard changed.
        /// </summary>
        private void pnl_Room_ClipboardChanged()
        {
            if (ClipboardChanged != null)
                ClipboardChanged();
        }

        /// <summary>
        /// Room changed.
        /// </summary>
        private void pnl_Room_RoomChanged()
        {
            if (RoomChanged != null)
                RoomChanged();
        }

        /// <summary>
        /// Room panel mouse up.
        /// </summary>
        private void pnl_Room_MouseUp(object sender, MouseEventArgs e)
        {
            // If not in view all mode, trigger mouse up event.
            if (EditMode != EditType.ViewAll)
                OnMouseUp(e);
        }

        /// <summary>
        /// Room  panel mouse down.
        /// </summary>
        private void pnl_Room_MouseDown(object sender, MouseEventArgs e)
        {
            // If not in view all mode, trigger mouse down event.
            if (EditMode != EditType.ViewAll)
                OnMouseDown(e);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the scrollbars based on project room.
        /// </summary>
        private void SetScrollbars()
        {
            // Zero out minimums, and scrollbar visibility.
            this.sb_Vertical.Minimum = 0;
            this.sb_Horizontal.Minimum = 0;
            this.tlp_Layout.RowStyles[1].Height = 0;
            this.tlp_Layout.ColumnStyles[1].Width = 0;

            // If no room was loaded, return.
            if (ProjectManager.Room == null)
                return;

            // Thumb size.
            int thumb = 2;

            // If the room is wider than the room panel, show the horizontal scrollbar.
            if ((int)(pnl_Room.ClientSize.Width / Zoom) < ProjectManager.Room.Width)
                this.tlp_Layout.RowStyles[1].Height = 17;

            // If the room is taller than the room panel, show the vertical scrollbar.
            if ((int)(pnl_Room.ClientSize.Height / Zoom) < ProjectManager.Room.Height)
                this.tlp_Layout.ColumnStyles[1].Width = 17;

            // If the offset does not make the maximum less than zero, set its value. 
            if ((ProjectManager.Room.Width - (int)(pnl_Room.ClientSize.Width / Zoom)) > 0)
            {
                this.sb_Horizontal.Maximum = ProjectManager.Room.Width - (int)(pnl_Room.ClientSize.Width / Zoom) - 1;

                // If the horizontal maximum is a negative number.
                if (this.sb_Horizontal.Maximum / thumb < 0)
                {
                    // Disable the horizontal scrollbar.
                    this.sb_Horizontal.Maximum = 0;
                    this.sb_Horizontal.Value = 0;
                    this.tlp_Layout.RowStyles[1].Height = 0;
                }
                else
                {
                    // Set horizontal large and small changes.
                    this.sb_Horizontal.LargeChange = this.sb_Horizontal.Maximum / thumb;
                    this.sb_Horizontal.SmallChange = this.sb_Horizontal.Maximum / 20;
                }

                // Adjust the maximum value to make the raw maximum value attainable by user interaction.
                this.sb_Horizontal.Maximum += this.sb_Horizontal.LargeChange;
            }
            else
                this.sb_Horizontal.Value = 0;

            // If the offset does not make the maximum less than zero, set its value.    
            if ((ProjectManager.Room.Height - (int)(pnl_Room.ClientSize.Height / Zoom)) > 0)
            {
                this.sb_Vertical.Maximum = ProjectManager.Room.Height - (int)(pnl_Room.ClientSize.Height / Zoom) - 1;

                // If the vertical maximum is a negative number.
                if (this.sb_Vertical.Maximum / thumb < 0)
                {
                    // Disable the vertical scrollbar.
                    this.sb_Vertical.Maximum = 0;
                    this.sb_Vertical.Value = 0;
                    this.tlp_Layout.ColumnStyles[1].Width = 0;
                }
                else
                {
                    // Set vertical large and small changes.
                    this.sb_Vertical.LargeChange = this.sb_Vertical.Maximum / thumb;
                    this.sb_Vertical.SmallChange = this.sb_Vertical.Maximum / 20;
                }

                // Adjust the maximum value to make the raw maximum value attainable by user interaction.
                this.sb_Vertical.Maximum += this.sb_Vertical.LargeChange;
            }
            else
                this.sb_Vertical.Value = 0;
        }

        /// <summary>
        /// Cut to clipboard.
        /// </summary>
        public void Cut()
        {
            // Do action based on edit mode.
            switch (EditMode)
            {
                case EditType.Layers: if (ToolMode == ToolType.Selection) { pnl_Room.tsmi_SelectionCut_Click(this, EventArgs.Empty); } break;
                case EditType.Instances: pnl_Room.tsmi_InstanceCut_Click(this, EventArgs.Empty); break;
                case EditType.Collisions: break;
            }
        }

        /// <summary>
        /// Copy to clipboard.
        /// </summary>
        public void Copy()
        {
            // Do action based on edit mode.
            switch (EditMode)
            {
                case EditType.Layers: if (ToolMode == ToolType.Selection) { pnl_Room.tsmi_SelectionCopy_Click(this, EventArgs.Empty); } break;
                case EditType.Instances: pnl_Room.tsmi_InstanceCopy_Click(this, EventArgs.Empty); break;
                case EditType.Collisions: break;
            }
        }

        /// <summary>
        /// Paste the clipboard.
        /// </summary>
        public void Paste()
        {
            // Do action based on edit mode.
            switch (EditMode)
            {
                case EditType.Layers: if (ToolMode == ToolType.Selection) { pnl_Room.tsmi_SelectionPaste_Click(this, EventArgs.Empty); } break;
                case EditType.Instances: pnl_Room.tsmi_InstancePaste_Click(this, EventArgs.Empty); break;
                case EditType.Collisions: break;
            }
        }

        /// <summary>
        /// Delete selection.
        /// </summary>
        public void Delete()
        {
            // Do action based on edit mode.
            switch (EditMode)
            {
                case EditType.Layers: if (ToolMode == ToolType.Selection) { pnl_Room.tsmi_SelectionDelete_Click(this, EventArgs.Empty); } break;
                case EditType.Instances: pnl_Room.tsmi_InstanceDelete_Click(this, EventArgs.Empty); break;
                case EditType.Collisions: break;
            }
        }

        /// <summary>
        /// Resets the control.
        /// </summary>
        public void Reset()
        {
            // Reset scrollbars.
            SetScrollbars();

            // Reset room panel.
            pnl_Room.Reset();
        }

        #endregion
    }
}
