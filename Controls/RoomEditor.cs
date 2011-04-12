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

        private Point _previous = Point.Empty;                  // Previous dragging point.
        private bool _handTool = false;                         // If the hand tool is being pressed.
        private bool _dragging = false;                         // If Dragging.

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
                    Rectangle view = new Rectangle(pnl_Room.Offset.X, pnl_Room.Offset.Y, (int)(pnl_Room.ClientSize.Width / pnl_Room.Zoom), (int)(pnl_Room.ClientSize.Height / pnl_Room.Zoom));
                    
                    // If the selected instance is not within the viewport.
                    if (view.IntersectsWith(rect) == false)
                    {
                        // Calculate scroll position on selected instance centered.
                        int x = rect.X - ((int)(pnl_Room.ClientSize.Width / pnl_Room.Zoom) / 2) + (rect.Width / 2);
                        int y = rect.Y - ((int)(pnl_Room.ClientSize.Height / pnl_Room.Zoom) / 2) + (rect.Height / 2);

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
        public GMareBrush SelectionClipboard
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
        public GMareBrush Tiles
        {
            get { return pnl_Room.Brush; }
            set { pnl_Room.Brush = value; }
        }

        /// <summary>
        /// Gets the current selection.
        /// </summary>
        public GMareBrush Selection
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
        /// Gets or sets the show instances always.
        /// </summary>
        public bool ShowInstances
        {
            get { return pnl_Room.ShowInstances; }
            set { pnl_Room.ShowInstances = value; }
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
        /// On paint override.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Set up the scrollbars.
            SetScrollbars();

            // Invalidate the room panel.
            pnl_Room.Invalidate();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            // If holding down the H key for the hand tool.
            if (e.KeyChar == 'h')
                pnl_Room.Invalidate();
        }

        /// <summary>
        /// On key down override.
        /// </summary>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            // If holding down the H key for the hand tool.
            if (e.KeyCode == Keys.H)
            {
                // The hand tool is ready.
                _handTool = true;

                // Tell the panel to change cursor graphics.
                pnl_Room.HandKey = true;

                // Don't allow other keys to override.
                return;
            }

            // If holding down the shift key
            if (e.KeyCode == Keys.ShiftKey)
                pnl_Room.ShiftKey = true;
        }

        /// <summary>
        /// On key up override.
        /// </summary>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            // Reset.
            _handTool = false;
            pnl_Room.ShiftKey = false;
            pnl_Room.HandKey = false;
            pnl_Room.ReAquirePosition();
        }

        /// <summary>
        /// On mouse enter override.
        /// </summary>
        protected override void OnMouseEnter(EventArgs e)
        {
            // Focus for scroll support.
            Focus();
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
        /// Mouse down.
        /// </summary>
        private void pnl_Room_MouseDown(object sender, MouseEventArgs e)
        {
            // If the hand tool is ready to be used.
            if (_handTool == true)
            {
                // Allow dragging.
                _dragging = true;

                // Record start position.
                _previous = e.Location;

                // Ignore other calls.
                return;
            }

            // If not in view all mode, trigger mouse down event.
            if (EditMode != EditType.ViewAll)
                OnMouseDown(e);
        }

        /// <summary>
        /// Mouse move.
        /// </summary>
        private void pnl_Room_MouseMove(object sender, MouseEventArgs e)
        {
            // If dragging, set scroll.
            if (_dragging == true)
            {
                // Get new position.
                int x = sb_Horizontal.Value - (e.X - _previous.X);
                int y = sb_Vertical.Value - (e.Y - _previous.Y);

                // Check boundries.
                if (x >= sb_Horizontal.Minimum && x <= ProjectManager.Room.Width - (int)(pnl_Room.ClientSize.Width / pnl_Room.Zoom) - 1)
                    sb_Horizontal.Value = x;

                if (y >= sb_Vertical.Minimum && y <= ProjectManager.Room.Height - (int)(pnl_Room.ClientSize.Height / pnl_Room.Zoom) - 1)
                    sb_Vertical.Value = y;

                // Set new previous location.
                _previous = e.Location;
            }
        }

        /// <summary>
        /// Room panel mouse up.
        /// </summary>
        private void pnl_Room_MouseUp(object sender, MouseEventArgs e)
        {
            // If previously dragging.
            if (_dragging == true)
            {
                // No more dragging.
                _dragging = false;
                return;
            }

            // If not in view all mode, trigger mouse up event.
            if (EditMode != EditType.ViewAll)
                OnMouseUp(e);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the scrollbars based on project room.
        /// </summary>
        private void SetScrollbars()
        {
            // Zero out minimums, and scrollbar visibility.
            sb_Vertical.Minimum = 0;
            sb_Horizontal.Minimum = 0;
            tlp_Layout.RowStyles[1].Height = 0;
            tlp_Layout.ColumnStyles[1].Width = 0;

            // If no room was loaded, return.
            if (ProjectManager.Room == null)
                return;

            // Thumb size.
            int thumb = 2;

            // If the room is wider than the room panel, show the horizontal scrollbar.
            if ((int)(pnl_Room.ClientSize.Width / pnl_Room.Zoom) < ProjectManager.Room.Width)
                tlp_Layout.RowStyles[1].Height = 17;

            // If the room is taller than the room panel, show the vertical scrollbar.
            if ((int)(pnl_Room.ClientSize.Height / pnl_Room.Zoom) < ProjectManager.Room.Height)
                tlp_Layout.ColumnStyles[1].Width = 17;

            // If the offset does not make the maximum less than zero, set its value. 
            if ((ProjectManager.Room.Width - (int)(pnl_Room.ClientSize.Width / pnl_Room.Zoom)) > 0)
            {
                sb_Horizontal.Maximum = ProjectManager.Room.Width - (int)(pnl_Room.ClientSize.Width / pnl_Room.Zoom) - 1;

                // If the horizontal maximum is a negative number.
                if (this.sb_Horizontal.Maximum / thumb < 0)
                {
                    // Disable the horizontal scrollbar.
                    sb_Horizontal.Maximum = 0;
                    sb_Horizontal.Value = 0;
                    tlp_Layout.RowStyles[1].Height = 0;
                }
                else
                {
                    // Set horizontal large and small changes.
                    sb_Horizontal.LargeChange = sb_Horizontal.Maximum / thumb;
                    sb_Horizontal.SmallChange = sb_Horizontal.Maximum / 20;
                }

                // Adjust the maximum value to make the raw maximum value attainable by user interaction.
                sb_Horizontal.Maximum += sb_Horizontal.LargeChange;
            }
            else
                sb_Horizontal.Value = 0;

            // If the offset does not make the maximum less than zero, set its value.    
            if ((ProjectManager.Room.Height - (int)(pnl_Room.ClientSize.Height / pnl_Room.Zoom)) > 0)
            {
                sb_Vertical.Maximum = ProjectManager.Room.Height - (int)(pnl_Room.ClientSize.Height / pnl_Room.Zoom) - 1;

                // If the vertical maximum is a negative number.
                if (sb_Vertical.Maximum / thumb < 0)
                {
                    // Disable the vertical scrollbar.
                    sb_Vertical.Maximum = 0;
                    sb_Vertical.Value = 0;
                    tlp_Layout.ColumnStyles[1].Width = 0;
                }
                else
                {
                    // Set vertical large and small changes.
                    sb_Vertical.LargeChange = sb_Vertical.Maximum / thumb;
                    sb_Vertical.SmallChange = sb_Vertical.Maximum / 20;
                }

                // Adjust the maximum value to make the raw maximum value attainable by user interaction.
                sb_Vertical.Maximum += sb_Vertical.LargeChange;
            }
            else
                sb_Vertical.Value = 0;
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

        /// <summary>
        /// Flips brushes or selections.
        /// </summary>
        public void Flip(FlipDirection direction)
        {
            // If the room is empty, return.
            if (ProjectManager.Room == null)
                return;

            // If not editing the layers, return.
            if (EditMode == EditType.Layers)
            {
                // Do action based on key.
                switch (ToolMode)
                {
                    case ToolType.Brush:
                        // Do action based on key data.
                        switch (direction)
                        {
                            case FlipDirection.Horizontal: pnl_Room.tsmi_BrushFlipHorizontally_Click(this, EventArgs.Empty); Invalidate(); break;
                            case FlipDirection.Vertical: pnl_Room.tsmi_BrushFlipVertically_Click(this, EventArgs.Empty); Invalidate(); break;
                        }
                        break;

                    case ToolType.Bucket:
                        // Do action based on key data.
                        switch (direction)
                        {
                            case FlipDirection.Horizontal: pnl_Room.tsmi_BrushFlipHorizontally_Click(this, EventArgs.Empty); Invalidate(); break;
                            case FlipDirection.Vertical: pnl_Room.tsmi_BrushFlipVertically_Click(this, EventArgs.Empty); Invalidate(); break;
                        }
                        break;

                    case ToolType.Selection:
                        // Do action based on key data.
                        switch (direction)
                        {
                            case FlipDirection.Horizontal: pnl_Room.tsmi_SelectionFlipX_Click(this, EventArgs.Empty); Invalidate(); break;
                            case FlipDirection.Vertical: pnl_Room.tsmi_SelectionFlipY_Click(this, EventArgs.Empty); Invalidate(); break;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Zooms the control.
        /// </summary>
        /// <param name="amount">The amount to zoom.</param>
        public void Zoom(float amount)
        {
            // Set zoom.
            pnl_Room.Zoom = amount;

            // Set scrollbars.
            SetScrollbars();

            // If the control contains the mouse, zoom and center to mouse point.
            if (pnl_Room.ClientRectangle.Contains(pnl_Room.PointToClient(Cursor.Position)))
            {
                // Calculate scroll position on mouse point centered.
                int x = pnl_Room.MousePosition.X - ((int)(pnl_Room.ClientSize.Width / pnl_Room.Zoom) / 2);
                int y = pnl_Room.MousePosition.Y - ((int)(pnl_Room.ClientSize.Height / pnl_Room.Zoom) / 2);

                // Stay within minimum and maximum values.
                x = x < 0 ? 0 : x;
                y = y < 0 ? 0 : y;
                x = x > sb_Horizontal.Maximum ? sb_Horizontal.Maximum : x;
                y = y > sb_Vertical.Maximum ? sb_Vertical.Maximum : y;

                // Scroll to position.
                sb_Horizontal.Value = x;
                sb_Vertical.Value = y;

                // Set scrollbars.
                SetScrollbars();
            }
        }

        #endregion
    }
}
