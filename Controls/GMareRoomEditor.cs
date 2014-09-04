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
using System.ComponentModel;
using GMare.Objects;

namespace GMare.Controls
{
    /// <summary>
    /// A scrollable container control for the room panel control
    /// This seems necessary because of OpenGL flickering when using the autoscroll properties on a panel control
    /// </summary>
    public partial class GMareRoomEditor : UserControl
    {
        #region Fields

        public event MousePositionHandler MousePositionChanged;           // Mouse position changed event
        public delegate void MousePositionHandler();                      // Mouse position changed event handler
        public event SelectedObjectChangedHandler SelectedObjectChanged;  // Selected object changed event
        public delegate void SelectedObjectChangedHandler();              // Selected object changed handler
        public event InstancePositionHandler InstancesPositionChanged;    // Selected instances position changed event
        public delegate void InstancePositionHandler();                   // Selected instances position changed event handler
        public event InstanceChangedHandler InstancesChanged;             // Selected instances changed event
        public delegate void InstanceChangedHandler();                    // Selected instances changed event handler
        public event RoomChangedHandler RoomChanged;                      // Room changed event
        public delegate void RoomChangedHandler();                        // Room changed event handler
        public event ClipboardChangedHandler ClipboardChanged;            // Clipboard contents changed
        public delegate void ClipboardChangedHandler();                   // Clipboard contents changed handler
        public event EditModeChangedHandler EditModeChanged;              // Editmode changed
        public delegate void EditModeChangedHandler();                    // Editmode changed handler

        private Point _previous = Point.Empty;                            // Previous dragging point
        private bool _handTool = false;                                   // If the hand tool is being pressed
        private bool _dragging = false;                                   // If Dragging

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the currently selected shape
        /// </summary>
        public GMareBackground SelectedBackground
        {
            get { return pnlRoom.SelectedBackground; }
            set { pnlRoom.SelectedBackground = value; }
        }

        /// <summary>
        /// Gets or sets the currently selected object
        /// </summary>
        public GMareObject SelectedObject
        {
            get { return pnlRoom.SelectedObject; }
            set { pnlRoom.SelectedObject = value; }
        }

        /// <summary>
        /// Gets or sets the currently selected instances
        /// Must have attributes here, otherwise the VS WinForm designer will try and serialize this
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<GMareInstance> SelectedInstances
        {
            get { return pnlRoom.SelectedInstances; }
            set
            {
                pnlRoom.SelectedInstances = value;

                // If the selected instance is empty or not in object edit mode or the room is empty, return
                if (pnlRoom.SelectedInstances.Count == 0 || EditMode != EditType.Objects || App.Room == null)
                    return;

                // Get selected instance object id
                GMareObject obj = App.Room.Objects.Find(delegate(GMareObject o) { return o.Resource.Id == SelectedInstances[0].ObjectId; });

                // If no object was found or the object's image data does not exist, return
                if (obj == null || obj.Image == null)
                    return;

                // Get instance and viewport rectangles
                Rectangle rect = new Rectangle(SelectedInstances[0].X, SelectedInstances[0].Y, obj.Image.Width, obj.Image.Height);
                Rectangle view = new Rectangle(pnlRoom.Offset.X, pnlRoom.Offset.Y, (int)(pnlRoom.ClientSize.Width / pnlRoom.Zoom), (int)(pnlRoom.ClientSize.Height / pnlRoom.Zoom));

                // If the selected instance is not within the viewport
                if (view.IntersectsWith(rect) == false)
                {
                    // Calculate scroll position on selected instance so that it is centered on the control
                    int x = rect.X - ((int)(pnlRoom.ClientSize.Width / pnlRoom.Zoom) / 2) + (rect.Width / 2);
                    int y = rect.Y - ((int)(pnlRoom.ClientSize.Height / pnlRoom.Zoom) / 2) + (rect.Height / 2);

                    // Stay within minimum and maximum values
                    x = x < 0 ? 0 : x;
                    y = y < 0 ? 0 : y;
                    x = x > sbHorizontal.Maximum ? sbHorizontal.Maximum : x;
                    y = y > sbVertical.Maximum ? sbVertical.Maximum : y;

                    // Scroll to position
                    sbHorizontal.Value = x;
                    sbVertical.Value = y;

                    // Set the scrollbars
                    SetScrollbars();
                }

                // Force redraw
                pnlRoom.Invalidate();
            }
        }

        /// <summary>
        /// Gets the instance clipboard
        /// </summary>
        public List<GMareInstance> InstanceClipboard
        {
            get { return pnlRoom.InstanceClipboard; }
        }

        /// <summary>
        /// Gets the selection clipboard
        /// </summary>
        public GMareBrush SelectionClipboard
        {
            get { return pnlRoom.SelectionClipboard; }
        }

        /// <summary>
        /// Gets or sets the edit mode type
        /// </summary>
        public EditType EditMode
        {
            get { return pnlRoom.EditMode; }
            set { pnlRoom.EditMode = value; if (EditModeChanged != null) EditModeChanged(); }
        }

        /// <summary>
        /// Gets or sets the current drawing tool type
        /// </summary>
        public ToolType ToolMode
        {
            get { return pnlRoom.ToolMode; }
            set { pnlRoom.ToolMode = value; }
        }

        /// <summary>
        /// Gets or sets the drawing grid mode
        /// </summary>
        public GridType GridMode
        {
            get { return pnlRoom.GridMode; }
            set { pnlRoom.GridMode = value; }
        }

        /// <summary>
        /// Gets or sets the grid of selected tiles
        /// </summary>
        public GMareBrush Tiles
        {
            get { return pnlRoom.Brush; }
            set { pnlRoom.Brush = value; }
        }

        /// <summary>
        /// Gets the current selection
        /// </summary>
        public GMareBrush Selection
        {
            get { return pnlRoom.Selection; }
        }

        /// <summary>
        /// Sets the image to use as a texture
        /// </summary>
        public Bitmap Image
        {
            set { pnlRoom.Image = value; pnlRoom.Invalidate(); }
        }

        /// <summary>
        /// Gets the actual mouse position
        /// </summary>
        public string MouseActual
        {
            get { return pnlRoom.MouseActual; }
        }

        /// <summary>
        /// Gets the sector the mouse is over
        /// </summary>
        public string MouseSector
        {
            get { return pnlRoom.MouseSector; }
        }

        /// <summary>
        /// Gets the current mouse snapped position
        /// </summary>
        public string MouseSnapped
        {
            get { return pnlRoom.MouseSnapped; }
        }

        /// <summary>
        /// Gets the current mouse hover instance
        /// </summary>
        public string MouseInstance
        {
            get { return pnlRoom.MouseInstance; }
        }

        /// <summary>
        /// Gets or sets the layer depth currently selected
        /// </summary>
        public int DepthIndex
        {
            get { return pnlRoom.DepthIndex; }
            set { pnlRoom.DepthIndex = value; }
        }

        /// <summary>
        /// Gets or sets the layer index currently selected
        /// </summary>
        public int LayerIndex
        {
            get { return pnlRoom.LayerIndex; }
            set { pnlRoom.LayerIndex = value; }
        }

        /// <summary>
        /// Gets or sets the horizontal grid spacing
        /// </summary>
        public int GridX
        {
            get { return pnlRoom.GridX; }
            set { pnlRoom.GridX = value; }
        }

        /// <summary>
        /// Gets or sets the vertical grid spacing
        /// </summary>
        public int GridY
        {
            get { return pnlRoom.GridY; }
            set { pnlRoom.GridY = value; }
        }

        /// <summary>
        /// Gets or sets the horizontal area spacing
        /// </summary>
        public int AreaX
        {
            get { return pnlRoom.AreaX; }
            set { pnlRoom.AreaX = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the vertical area spacing
        /// </summary>
        public int AreaY
        {
            get { return pnlRoom.AreaY; }
            set { pnlRoom.AreaY = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the level of the collsion
        /// </summary>
        public int Level
        {
            get { return pnlRoom.Level; }
            set { pnlRoom.Level = value; }
        }

        /// <summary>
        /// Gets or sets the show grid property
        /// </summary>
        public bool ShowGrid
        {
            get { return pnlRoom.ShowGrid; }
            set { pnlRoom.ShowGrid = value; }
        }

        /// <summary>
        /// Gets or sets the show area property
        /// </summary>
        public bool ShowArea
        {
            get { return pnlRoom.ShowArea; }
            set { pnlRoom.ShowArea = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the show instances always
        /// </summary>
        public bool ShowInstances
        {
            get { return pnlRoom.ShowInstances; }
            set { pnlRoom.ShowInstances = value; }
        }

        /// <summary>
        /// Gets or sets whether to snap instances to the grid
        /// </summary>
        public bool Snap
        {
            get { return pnlRoom.Snap ; }
            set { pnlRoom.Snap = value; }
        }

        /// <summary>
        /// Gets or sets whether to show block instances
        /// </summary>
        public bool ShowBlocks
        {
            get { return pnlRoom.ShowBlocks; }
            set { pnlRoom.ShowBlocks = value; }
        }

        /// <summary>
        /// Gets or sets if mouse events should be ignored because of a dialog double click
        /// </summary>
        public bool AvoidMouseEvents
        {
            get { return pnlRoom.AvoidMouseEvents; }
            set { pnlRoom.AvoidMouseEvents = value; }
        }

        /// <summary>
        /// Gets or sets toggling between white and black for the grid color
        /// </summary>
        public bool InvertGridColor
        {
            get { return pnlRoom.InvertGridColor; }
            set { pnlRoom.InvertGridColor = value; }
        }

        /// <summary>
        /// Gets or sets if drawing the room opaque with no layer effects
        /// </summary>
        public bool Opaque
        {
            get { return pnlRoom.Opaque; }
            set { pnlRoom.Opaque = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new room editor
        /// </summary>
        public GMareRoomEditor()
        {
            InitializeComponent();

            // Set the scrollbars
            SetScrollbars();

            // Set the backcolor for mock visual styled border
            BackColor = System.Windows.Forms.VisualStyles.VisualStyleInformation.TextControlBorder;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// On paint
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Set the scrollbars
            SetScrollbars();

            // Invalidate the room panel
            pnlRoom.Invalidate();
        }

        /// <summary>
        /// On key press
        /// </summary>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            // If holding down the H key for the hand tool
            if (e.KeyChar == 'h')
                pnlRoom.Invalidate();
        }

        /// <summary>
        /// On key down
        /// </summary>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            // Do action based on key being pressed
            switch (e.KeyCode)
            {
                case Keys.Shift: case Keys.ShiftKey: pnlRoom.ShiftKey = true; break;
                case Keys.Control: case Keys.ControlKey: pnlRoom.ControlKey = true; break;
                case Keys.Menu: pnlRoom.AltKey = true; e.Handled = true; break;
                case Keys.H:
                    // The hand tool is ready
                    _handTool = true;

                    // Tell the panel to change cursor graphics
                    pnlRoom.HandKey = true;

                    // Don't allow other keys to override
                    return;
            }
        }

        /// <summary>
        /// On key up
        /// </summary>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            // Ignore alt key on parent
            if (e.KeyData == Keys.Menu)
                e.Handled = true;

            // Reset any shortcut modifiers
            _handTool = false;
            pnlRoom.ShiftKey = false;
            pnlRoom.ControlKey = false;
            pnlRoom.AltKey = false;
            pnlRoom.HandKey = false;
            pnlRoom.ReAcquirePosition();
        }

        #endregion

        #region Events

        /// <summary>
        /// Vertical scrollbar value changed
        /// </summary>
        private void sbVertical_ValueChanged(object sender, EventArgs e)
        {
            // Set room offset
            pnlRoom.Offset = new Point(pnlRoom.Offset.X, sbVertical.Value);
        }

        /// <summary>
        /// Horizontal scrollbar value changed
        /// </summary>
        private void sbHorizontal_ValueChanged(object sender, EventArgs e)
        {
            // Set room offset
            pnlRoom.Offset = new Point(sbHorizontal.Value, pnlRoom.Offset.Y);
        }

        /// <summary>
        /// Selected object changed
        /// </summary>
        private void pnlRoom_SelectedObjectChanged()
        {
            if (SelectedObjectChanged != null)
                SelectedObjectChanged();
        }

        /// <summary>
        /// Room panel position changed
        /// </summary>
        private void pnlRoom_MousePositionChanged()
        {
            if (MousePositionChanged != null)
                MousePositionChanged();
        }

        /// <summary>
        /// Room panel instance changed
        /// </summary>
        private void pnlRoom_InstancesPositionChanged()
        {
            if (InstancesPositionChanged != null)
                InstancesPositionChanged();
        }

        /// <summary>
        /// Room panel instance changed
        /// </summary>
        private void pnlRoom_InstancesChanged()
        {
            if (InstancesChanged != null)
                InstancesChanged();
        }

        /// <summary>
        /// Room clipboard changed
        /// </summary>
        private void pnlRoom_ClipboardChanged()
        {
            if (ClipboardChanged != null)
                ClipboardChanged();
        }

        /// <summary>
        /// Room changed
        /// </summary>
        private void pnlRoom_RoomChanged()
        {
            if (RoomChanged != null)
                RoomChanged();
        }

        /// <summary>
        /// Mouse down
        /// </summary>
        private void pnlRoom_MouseDown(object sender, MouseEventArgs e)
        {
            // If the hand tool is ready to be used
            if (_handTool == true)
            {
                // Allow dragging
                _dragging = true;

                // Record start position
                _previous = e.Location;

                // Ignore other calls
                return;
            }

            // Trigger mouse down event
            OnMouseDown(e);
        }

        /// <summary>
        /// Mouse move
        /// </summary>
        private void pnl_Room_MouseMove(object sender, MouseEventArgs e)
        {
            // Focus for scroll support
            this.Focus();

            // If not dragging, return
            if (!_dragging)
                return;

            // Get new position
            int x = sbHorizontal.Value - (e.X - _previous.X);
            int y = sbVertical.Value - (e.Y - _previous.Y);

            // Check boundries
            if (x >= sbHorizontal.Minimum && x <= App.Room.Width - (int)(pnlRoom.ClientSize.Width / pnlRoom.Zoom) - 1)
                sbHorizontal.Value = x;

            if (y >= sbVertical.Minimum && y <= App.Room.Height - (int)(pnlRoom.ClientSize.Height / pnlRoom.Zoom) - 1)
                sbVertical.Value = y;

            // Set new previous location
            _previous = e.Location;
        }

        /// <summary>
        /// Room panel mouse up
        /// </summary>
        private void pnl_Room_MouseUp(object sender, MouseEventArgs e)
        {
            // If previously dragging
            if (_dragging == true)
            {
                // No more dragging
                _dragging = false;
                return;
            }

            // Trigger mouse up event
            OnMouseUp(e);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the scrollbars based on room size and scroll position
        /// </summary>
        private void SetScrollbars()
        {
            // Zero out minimums, and scrollbar visibility
            sbVertical.Minimum = 0;
            sbHorizontal.Minimum = 0;
            pnlLayout.RowStyles[1].Height = 0;
            pnlLayout.ColumnStyles[1].Width = 0;

            // If the room is empty, return
            if (App.Room == null)
                return;

            // Thumb size
            int thumb = 2;

            // If the room is wider than the room panel, show the horizontal scrollbar
            if ((int)(pnlRoom.ClientSize.Width / pnlRoom.Zoom) < App.Room.Width)
                pnlLayout.RowStyles[1].Height = 17;

            // If the room is taller than the room panel, show the vertical scrollbar
            if ((int)(pnlRoom.ClientSize.Height / pnlRoom.Zoom) < App.Room.Height)
                pnlLayout.ColumnStyles[1].Width = 17;

            // If the offset does not make the maximum less than zero, set its value
            if ((App.Room.Width - (int)(pnlRoom.ClientSize.Width / pnlRoom.Zoom)) > 0)
            {
                sbHorizontal.Maximum = App.Room.Width - (int)(pnlRoom.ClientSize.Width / pnlRoom.Zoom) - 1;

                // If the horizontal maximum is a negative number
                if (this.sbHorizontal.Maximum / thumb < 0)
                {
                    // Disable the horizontal scrollbar
                    sbHorizontal.Maximum = 0;
                    sbHorizontal.Value = 0;
                    pnlLayout.RowStyles[1].Height = 0;
                }
                else
                {
                    // Set horizontal large and small changes
                    sbHorizontal.LargeChange = sbHorizontal.Maximum / thumb;
                    sbHorizontal.SmallChange = sbHorizontal.Maximum / 20;
                }

                // Adjust the maximum value to make the raw maximum value attainable by user interaction
                sbHorizontal.Maximum += sbHorizontal.LargeChange;
            }
            else
                sbHorizontal.Value = 0;

            // If the offset does not make the maximum less than zero, set its value
            if ((App.Room.Height - (int)(pnlRoom.ClientSize.Height / pnlRoom.Zoom)) > 0)
            {
                sbVertical.Maximum = App.Room.Height - (int)(pnlRoom.ClientSize.Height / pnlRoom.Zoom) - 1;

                // If the vertical maximum is a negative number
                if (sbVertical.Maximum / thumb < 0)
                {
                    // Disable the vertical scrollbar
                    sbVertical.Maximum = 0;
                    sbVertical.Value = 0;
                    pnlLayout.ColumnStyles[1].Width = 0;
                }
                else
                {
                    // Set vertical large and small changes
                    sbVertical.LargeChange = sbVertical.Maximum / thumb;
                    sbVertical.SmallChange = sbVertical.Maximum / 20;
                }

                // Adjust the maximum value to make the raw maximum value attainable by user interaction
                sbVertical.Maximum += sbVertical.LargeChange;
            }
            else
                sbVertical.Value = 0;
        }

        /// <summary>
        /// Set the selected instance as the selected object
        /// </summary>
        public void SetObjectFromInstance()
        {
            // If not in object editing mode, return
            if (EditMode != EditType.Objects)
                return;

            pnlRoom.mnuSetAsObject_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Instance replace
        /// </summary>
        public void InstanceReplace()
        {
            // If not in object editing mode, return
            if (EditMode != EditType.Objects)
                return;

            pnlRoom.mnuInstanceReplace_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Instance replace all
        /// </summary>
        public void InstanceReplaceAll()
        {
            // If not in object editing mode, return
            if (EditMode != EditType.Objects)
                return;

            pnlRoom.mnuInstanceReplaceAll_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Cut to clipboard
        /// </summary>
        public void Cut()
        {
            // Do action based on edit mode
            switch (EditMode)
            {
                case EditType.Layers: if (ToolMode == ToolType.Selection) { pnlRoom.mnuSelectionCut_Click(this, EventArgs.Empty); } break;
                case EditType.Objects: pnlRoom.mnuInstanceCut_Click(this, EventArgs.Empty); break;
            }
        }

        /// <summary>
        /// Copy to clipboard
        /// </summary>
        public void Copy()
        {
            // Do action based on edit mode
            switch (EditMode)
            {
                case EditType.Layers: if (ToolMode == ToolType.Selection) { pnlRoom.mnuSelectionCopy_Click(this, EventArgs.Empty); } break;
                case EditType.Objects: pnlRoom.mnuInstanceCopy_Click(this, EventArgs.Empty); break;
            }
        }

        /// <summary>
        /// Paste the clipboard
        /// </summary>
        public void Paste()
        {
            // Do action based on edit mode
            switch (EditMode)
            {
                case EditType.Layers: if (ToolMode == ToolType.Selection) { pnlRoom.mnuSelectionPaste_Click(this, EventArgs.Empty); } break;
                case EditType.Objects: pnlRoom.mnuInstancePaste_Click(this, EventArgs.Empty); break;
            }
        }

        /// <summary>
        /// Instance change position
        /// </summary>
        public void InstancePosition()
        {
            // If not in object editing mode, return
            if (EditMode != EditType.Objects)
                return;

            pnlRoom.mnuInstancePosition_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Instance bring front
        /// </summary>
        public void InstanceBringFront()
        {
            // If not in object editing mode, return
            if (EditMode != EditType.Objects)
                return;

            pnlRoom.mnuInstanceSendFront_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Instance send back
        /// </summary>
        public void InstanceSendBack()
        {
            // If not in object editing mode, return
            if (EditMode != EditType.Objects)
                return;

            pnlRoom.mnuInstanceSendBack_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Instance snap to grid
        /// </summary>
        public void InstanceSnap()
        {
            // If not in object editing mode, return
            if (EditMode != EditType.Objects)
                return;

            pnlRoom.mnuInstanceSnap_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Instance edit creation code
        /// </summary>
        public void InstanceCode()
        {
            // If not in object editing mode, return
            if (EditMode != EditType.Objects)
                return;

            pnlRoom.mnuInstanceCode_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Delete selection
        /// </summary>
        public void Delete()
        {
            // Do action based on edit mode
            switch (EditMode)
            {
                case EditType.Layers:
                    // If using the selection tool, delete the selection
                    if (ToolMode == ToolType.Selection)
                        pnlRoom.mnuSelectionDelete_Click(this, EventArgs.Empty);
                        
                    break;
                case EditType.Objects: pnlRoom.mnuInstanceDelete_Click(this, EventArgs.Empty); break;
            }
        }

        /// <summary>
        /// Instance delete all
        /// </summary>
        public void InstanceDeleteAll()
        {
            // If not in object editing mode, return
            if (EditMode != EditType.Objects)
                return;

            pnlRoom.mnuInstanceDeleteAll_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Instance clear
        /// </summary>
        public void InstanceClear()
        {
            // If not in object editing mode, return
            if (EditMode != EditType.Objects)
                return;

            pnlRoom.mnuInstanceClear_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Resets the control
        /// </summary>
        public void Reset()
        {
            // Reset scrollbars
            SetScrollbars();

            // Reset room panel
            pnlRoom.Reset();
        }

        /// <summary>
        /// Flips brushes or selections
        /// </summary>
        public void Flip(FlipDirectionType direction)
        {
            // If the room is empty, return
            if (App.Room == null)
                return;

            // If not editing the layers, return
            if (EditMode == EditType.Layers)
            {
                // Do action based on key
                switch (ToolMode)
                {
                    case ToolType.Brush:
                        // Do action based on key data
                        switch (direction)
                        {
                            case FlipDirectionType.Horizontal: pnlRoom.mnuBrushFlipHorizontally_Click(this, EventArgs.Empty); Invalidate(); break;
                            case FlipDirectionType.Vertical: pnlRoom.mnuBrushFlipVertically_Click(this, EventArgs.Empty); Invalidate(); break;
                        }
                        break;

                    case ToolType.Bucket:
                        // Do action based on key data
                        switch (direction)
                        {
                            case FlipDirectionType.Horizontal: pnlRoom.mnuBrushFlipHorizontally_Click(this, EventArgs.Empty); Invalidate(); break;
                            case FlipDirectionType.Vertical: pnlRoom.mnuBrushFlipVertically_Click(this, EventArgs.Empty); Invalidate(); break;
                        }
                        break;

                    case ToolType.Selection:
                        // Do action based on key data
                        switch (direction)
                        {
                            case FlipDirectionType.Horizontal: pnlRoom.mnuSelectionFlipX_Click(this, EventArgs.Empty); Invalidate(); break;
                            case FlipDirectionType.Vertical: pnlRoom.mnuSelectionFlipY_Click(this, EventArgs.Empty); Invalidate(); break;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Magnifies the control and positions on mouse location
        /// </summary>
        /// <param name="amount">The amount to magnify</param>
        public void Zoom(float amount)
        {
            // Set zoom
            pnlRoom.Zoom = amount;

            // Set scrollbars
            SetScrollbars();

            // If the control does not contain the mouse position, return
            if (!pnlRoom.ClientRectangle.Contains(pnlRoom.PointToClient(Cursor.Position)))
                return;

            // Calculate scroll position on mouse point, centered
            int x = pnlRoom.MouseLocation.X - ((int)(pnlRoom.ClientSize.Width / pnlRoom.Zoom) / 2);
            int y = pnlRoom.MouseLocation.Y - ((int)(pnlRoom.ClientSize.Height / pnlRoom.Zoom) / 2);

            // Stay within minimum and maximum values
            x = x < 0 ? 0 : x;
            y = y < 0 ? 0 : y;
            x = x > sbHorizontal.Maximum ? sbHorizontal.Maximum : x;
            y = y > sbVertical.Maximum ? sbVertical.Maximum : y;

            // Scroll to position
            sbHorizontal.Value = x;
            sbVertical.Value = y;

            // Set scrollbars
            SetScrollbars();
        }

        /// <summary>
        /// Refreshes the mouse position
        /// </summary>
        public void RefreshPosition()
        {
            pnlRoom.RefreshPosition();
        }

        #endregion
    }
}
