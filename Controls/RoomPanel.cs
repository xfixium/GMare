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
using GMare.Common;
using GMare.Forms;
using GMare.Graphics;

namespace GMare.Controls
{
    /// <summary>
    /// A control that edits various room elements.
    /// </summary>
    public partial class RoomPanel : Panel
    {
        #region Fields

        public event PositionHandler PositionChanged;                 // Mouse position changed event.
        public delegate void PositionHandler();                       // Mouse poisition changed event handler.
        public event InstanceChangedHandler SelectedInstanceChanged;  // Selected instance changed event.
        public delegate void InstanceChangedHandler();                // Selected instance changed event handler.
        public event RoomChangedHandler RoomChanged;                  // Room changed event.
        public delegate void RoomChangedHandler();                    // Room changed event handler.
        public event ClipboardChangedHandler ClipboardChanged;        // Clipboard contents changed.
        public delegate void ClipboardChangedHandler();               // Clipboard contents changed handler.

        private Timer _stippleTimer = new Timer();                    // Marching ants timer.
        private GMareObject _selectedObject = null;                   // The currently selected object.
        private GMareCollision _selectedShape = null;                     // The currently selected shape.
        private GMareInstance _selectedInstance = null;               // The currently selected instance.
        private GMareInstance _instanceClip = null;                   // The instance clipboard.
        private EditType _editMode = EditType.ViewAll;                // The edit mode of the control.
        private ToolType _toolMode = ToolType.Pencil;                 // The type of tool selected.
        private ShapeType _shapeMode = ShapeType.Rectangle;           // The type of collision shape selected.
        private GridType _gridMode = GridType.Normal;                 // The type of grid to draw.
        private TileGrid _tiles = new TileGrid();                     // The tile grid used for setting tile ids, the brush.
        private TileGrid _selection = null;                           // The selection of tiles when in selection mode.
        private TileGrid _selectionClip = null;                       // The selection clipboard.
        private Cursor _cursorPencil = null;                          // The pencil cursor.
        private Cursor _cursorBucket = null;                          // The bucket cursor.
        private Cursor _cursorCross = null;                           // The selection cursor.
        private string _mouseActual = "-NA-";                         // The actual position of the mouse.
        private string _mouseSnapped = "-NA-";                        // The snapped position of the mouse.
        private string _mouseSector = "-NA-";                         // The tile id, based on mouse position.
        private int _stippleOffset = 0;                               // Selection rectangle stipple offset.
        private int _depthIndex = 0;                                  // The selected layer depth.
        private int _layerIndex = -1;                                 // The selected layer index.
        private int _gridX = 16;                                      // Offset for grid width.
        private int _gridY = 16;                                      // Offset for grid height.
        private int _posX = 0;                                        // Last mouse x position.
        private int _posY = 0;                                        // Last mouse y position.
        private int _selectedPoint = -1;                              // The currently selected shape node.
        private int _level = 0;                                       // The level of the collision.
        private bool _showGrid = true;                                // Whether to show the grid.
        private bool _showCursor = false;                             // Whether to show the cursor.
        private bool _dragging = false;                               // Whether in a dragging operation.
        private bool _moving = false;                                 // Whether in a moving operation.
        private bool _moved = false;                                  // Whether a selection has moved since it first was selected.
        private bool _snap = true;                                    // Whether the instances created are snapped to a grid.

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the currently selected shape.
        /// </summary>
        public GMareCollision SelectedShape
        {
            get { return _selectedShape; }
            set { _selectedShape = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the currently selected object.
        /// </summary>
        public GMareObject SelectedObject
        {
            get { return _selectedObject; }
            set { _selectedObject = value; }
        }

        /// <summary>
        /// Gets or sets the currently selected instance.
        /// </summary>
        public GMareInstance SelectedInstance
        {
            get { return _selectedInstance; }
            set { _selectedInstance = value; }
        }

        /// <summary>
        /// Gets the instance clipboard.
        /// </summary>
        public GMareInstance InstanceClipboard
        {
            get { return _instanceClip; }
        }

        /// <summary>
        /// Gets the selection clipboard.
        /// </summary>
        public TileGrid SelectionClipboard
        {
            get { return _selectionClip; }
        }

        /// <summary>
        /// Gets or sets the selected layer.
        /// </summary>
        public EditType EditMode
        {
            get { return _editMode; }
            set
            {
                _editMode = value;

                // If not editing layers, deselect.
                if (_editMode != EditType.Layers)
                    tsmi_SelectionDeselect_Click(this, EventArgs.Empty);

                // Set the tool cursor.
                SetCursor();

                // Force redraw.
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the current drawing tool type.
        /// </summary>
        public ToolType ToolMode
        {
            get { return _toolMode; }
            set
            {
                _toolMode = value;

                // If not using the selection tool, deselect.
                if (_toolMode != ToolType.Selection)
                    tsmi_SelectionDeselect_Click(this, EventArgs.Empty);

                // Set the tool cursor.
                SetCursor();
            }
        }

        /// <summary>
        /// Gets or sets the type of shape tool currently used.
        /// </summary>
        public ShapeType ShapeMode
        {
            get { return _shapeMode; }
            set { _shapeMode = value; }
        }

        /// <summary>
        /// Gets or sets the drawing grid mode.
        /// </summary>
        public GridType GridMode
        {
            get { return _gridMode; }
            set { _gridMode = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the grid of selected tiles.
        /// </summary>
        public TileGrid Tiles
        {
            get { return _tiles; }
            set { _tiles = value; }
        }

        /// <summary>
        /// The image to use as a texture.
        /// </summary>
        public Bitmap Image
        {
            set { LoadTexture(value); }
        }

        /// <summary>
        /// Gets the actual mouse position.
        /// </summary>
        public string MouseActual
        {
            get { return _mouseActual; }
        }

        /// <summary>
        /// Gets the sector the mouse is over.
        /// </summary>
        public string MouseSector
        {
            get { return _mouseSector; }
        }

        /// <summary>
        /// Gets the current mouse snapped position.
        /// </summary>
        public string MouseSnapped
        {
            get { return _mouseSnapped; }
        }

        /// <summary>
        /// Sets the mouse's actual position.
        /// </summary>
        private string SetMouseActual
        {
            set
            {
                _mouseActual = value;

                // Fire position changed event().
                if (PositionChanged != null)
                    PositionChanged();
            }
        }

        /// <summary>
        /// Sets the mouse's snapped position.
        /// </summary>
        private string SetMouseSnapped
        {
            set
            {
                _mouseSnapped = value;

                // Fire position changed event().
                if (PositionChanged != null)
                    PositionChanged();
            }
        }

        /// <summary>
        /// Sets the sector the mouse is over.
        /// </summary>
        private string SetMouseSector
        {
            set
            {
                _mouseSector = value;

                // Fire position changed event().
                if (PositionChanged != null)
                    PositionChanged();
            }
        }

        /// <summary>
        /// Gets or sets the scale factor of the room panel.
        /// </summary>
        public float Zoom
        {
            get { return GraphicsManager.ScreenScale; }
            set { GraphicsManager.ScreenScale = value; Invalidate(); }
        }

        public Point Offset
        {
            get { return new Point(GraphicsManager.OffsetX, GraphicsManager.OffsetY); }
            set { GraphicsManager.OffsetX = value.X; GraphicsManager.OffsetY = value.Y; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the layer depth currently selected.
        /// </summary>
        public int DepthIndex
        {
            get { return _depthIndex; }
            set { _depthIndex = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the layer index currently selected.
        /// </summary>
        public int LayerIndex
        {
            get { return _layerIndex; }
            set { _layerIndex = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the horizontal grid spacing.
        /// </summary>
        public int GridX
        {
            get { return _gridX; }
            set { _gridX = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the vertical grid spacing.
        /// </summary>
        public int GridY
        {
            get { return _gridY; }
            set { _gridY = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the level of the collsion.
        /// </summary>
        public int Level
        {
            get { return _level; }
            set { _level = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the show grid property.
        /// </summary>
        public bool ShowGrid
        {
            get { return _showGrid; }
            set { _showGrid = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets whether to snap instances to the grid.
        /// </summary>
        public bool Snap
        {
            get { return _snap; }
            set { _snap = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new room editor.
        /// </summary>
        public RoomPanel()
        {
            InitializeComponent();

            // For mouse wheel scrolling support.
            this.SetStyle(ControlStyles.Selectable, true);

            // For resizing flicker issues.
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.Opaque, true);

            // Set cursors.
            _cursorPencil = new Cursor(GetType().Assembly.GetManifestResourceStream("GMare.Resources.cur_pencil.cur"));
            _cursorBucket = new Cursor(GetType().Assembly.GetManifestResourceStream("GMare.Resources.cur_bucket.cur"));
            _cursorCross = new Cursor(GetType().Assembly.GetManifestResourceStream("GMare.Resources.cur_cross.cur"));

            // Set stipple timer.
            _stippleTimer.Interval = 100;
            _stippleTimer.Tick += new EventHandler(Timer_Tick);
            _stippleTimer.Start();

            // Set selection options click events.
            tsmi_SelectionCut.Click += new EventHandler(tsmi_SelectionCut_Click);
            tsmi_SelectionCopy.Click += new EventHandler(tsmi_SelectionCopy_Click);
            tsmi_SelectionPaste.Click += new EventHandler(tsmi_SelectionPaste_Click);
            tsmi_SelectionDeselect.Click += new EventHandler(tsmi_SelectionDeselect_Click);
            tsmi_SelectionDelete.Click += new EventHandler(tsmi_SelectionDelete_Click);
            tsmi_SelectionFill.Click += new EventHandler(tsmi_SelectionFill_Click);

            // Set instance options click events.
            tsmi_InstanceCut.Click += new EventHandler(tsmi_InstanceCut_Click);
            tsmi_InstanceCopy.Click += new EventHandler(tsmi_InstanceCopy_Click);
            tsmi_InstancePaste.Click += new EventHandler(tsmi_InstancePaste_Click);
            tsmi_InstanceSendBack.Click += new EventHandler(tsmi_InstanceSendBack_Click);
            tsmi_InstanceSendFront.Click += new EventHandler(tsmi_InstanceSendFront_Click);
            tsmi_InstanceSnap.Click += new EventHandler(tsmi_InstanceSnap_Click);
            tsmi_InstanceCode.Click += new EventHandler(tsmi_InstanceCode_Click);
            tsmi_InstanceDelete.Click += new EventHandler(tsmi_InstanceDelete_Click);
            tsmi_InstanceDeleteAll.Click += new EventHandler(tsmi_InstanceDeleteAll_Click);
            tsmi_InstanceClear.Click += new EventHandler(tsmi_InstanceClear_Click);
        }

        #endregion

        #region Events

        #region Selection Options

        /// <summary>
        /// Cut click.
        /// </summary>
        public void tsmi_SelectionCut_Click(object sender, EventArgs e)
        {
            // If there is a selection.
            if (_selection != null)
            {
                // Set clipboard.
                _selectionClip = _selection.Clone();

                // Clipboard changed.
                ClipboardChanged();
            }

            // If the selection has not moved, set tiles empty under selection.
            if (_moved == false)
            {
                // Room changed, selected tiles set.
                RoomChanged();

                // Empty out selection tiles.
                SetTiles(_selection.StartX, _selection.StartY, true, _selection, true);
            }

            // Empty the selection.
            _selection = null;

            // Force redraw.
            Invalidate();
        }

        /// <summary>
        /// Copy click.
        /// </summary>
        public void tsmi_SelectionCopy_Click(object sender, EventArgs e)
        {
            // If there is a selection.
            if (_selection != null)
            {
                // Set clipboard.
                _selectionClip = _selection.Clone();

                // Clipboard changed.
                ClipboardChanged();

                // Room changed, selected tiles set.
                if (_moved == true)
                    RoomChanged();

                // Set selection tiles to layer.
                SetTiles(_selection.StartX, _selection.StartY, false, _selection, true);
            }

            // Reset moved flag.
            _moved = false;

            // Empty the selection.
            _selection = null;

            // Force redraw.
            Invalidate();
        }

        /// <summary>
        /// Paste click.
        /// </summary>
        public void tsmi_SelectionPaste_Click(object sender, EventArgs e)
        {
            // If there was a previous selection.
            if (_selection != null)
            {
                // Room changed, selected tiles set.
                RoomChanged();

                // Set previous selection to the layer.
                SetTiles(_selection.StartX, _selection.StartY, false, _selection, true);
            }

            // Set the selection.
            _selection = _selectionClip.Clone();

            // Get the smallest size.
            Size size = GetSmallestCanvas();

            // Get tile size.
            Size tileSize = ProjectManager.Room.TileSize;

            // Get centered position.
            int x = (size.Width / 2) - (_selection.Width / 2);
            int y = (size.Height / 2) - (_selection.Height / 2);

            // Remember original size before transform.
            int width = _selection.Width;
            int height = _selection.Height;

            // Get the center point snapped.
            Point snap = GetSnappedPoint(new Point(x, y), tileSize);

            // Set the new selection position.
            _selection.StartX = snap.X;
            _selection.StartY = snap.Y;
            _selection.EndX = snap.X + width;
            _selection.EndY = snap.Y + height;

            // Set moved flag.
            _moved = true;

            // Force redraw.
            Invalidate();
        }

        /// <summary>
        /// Fill click.
        /// </summary>
        private void tsmi_SelectionFill_Click(object sender, EventArgs e)
        {
            // Get point.
            Point point = (sender as ToolStripMenuItem).GetCurrentParent().Location;

            // If not in selection mode, return.
            if (_editMode != EditType.Layers || _toolMode != ToolType.Selection)
                return;

            // If the clipboard is empty, return.
            if (_selectionClip == null)
                return;

            // Room changed, tile fill.
            RoomChanged();

            // Calculate starting point in tiles.
            Size tileSize = ProjectManager.Room.TileSize;
            Point snap = GetSnappedPoint(this.PointToClient(point), tileSize);
            Point tile = new Point(snap.X / tileSize.Width, snap.Y / tileSize.Height);

            // Fill tile(s).
            ProjectManager.Room.Layers[_layerIndex].Fill(tile, _selectionClip.TileIds);

            // Force redraw.
            Invalidate();
        }

        /// <summary>
        /// Deselect click.
        /// </summary>
        private void tsmi_SelectionDeselect_Click(object sender, EventArgs e)
        {
            // If not in selection mode, return.
            if (_editMode != EditType.Layers || _toolMode != ToolType.Selection)
                return;

            // Room changed, selected tiles set.
            if (_moved == true)
                RoomChanged();

            // If there was a previous selection, set it to the layer.
            if (_selection != null)
                SetTiles(_selection.StartX, _selection.StartY, false, _selection, true);

            // Reset moved flag.
            _moved = false;

            // Empty the selection.
            _selection = null;

            // Force redraw.
            Invalidate();
        }

        /// <summary>
        /// Delete click.
        /// </summary>
        public void tsmi_SelectionDelete_Click(object sender, EventArgs e)
        {
            // If the selection has not moved, set tiles empty under selection.
            if (_selection != null && _moved == false)
            {
                // Room changed, selected tiles set.
                RoomChanged();

                // Empty out selection tiles.
                SetTiles(_selection.StartX, _selection.StartY, true, _selection, true);
            }

            // Reset moved flag.
            _moved = false;

            // Empty tile selection.
            _selection = null;

            // Force redraw.
            Invalidate();
        }

        #endregion

        #region Instance Options

        /// <summary>
        /// Instance cut.
        /// </summary>
        public void tsmi_InstanceCut_Click(object sender, EventArgs e)
        {
            // If no instance has been selected, return.
            if (_selectedInstance == null)
                return;

            // Room changed, instance deleted.
            RoomChanged();

            // Set instance clipboard.
            _instanceClip = _selectedInstance.Clone();

            // Clipboard changed.
            ClipboardChanged();

            // Remove selected instance.
            ProjectManager.Room.Instances.Remove(_selectedInstance);
            _selectedInstance = null;

            // Selected instance changed.
            SelectedInstanceChanged();
        }

        /// <summary>
        /// Instance copy.
        /// </summary>
        public void tsmi_InstanceCopy_Click(object sender, EventArgs e)
        {
            // If no instance has been selected, return.
            if (_selectedInstance == null)
                return;

            // Set instance clipboard.
            _instanceClip = _selectedInstance.Clone();

            // Clipboard changed.
            ClipboardChanged();
        }

        /// <summary>
        /// Instance paste.
        /// </summary>
        public void tsmi_InstancePaste_Click(object sender, EventArgs e)
        {
            // If the instance clip is empty, return.
            if (_instanceClip == null)
                return;

            // Get object.
            GMareObject obj = ProjectManager.Room.Objects.Find(delegate(GMareObject o) { return o.Resource.Id == _instanceClip.ObjectId; });

            // If no parent object was found, return.
            if (obj == null)
                return;

            // Get the smallest canvas size.
            Size size = GetSmallestCanvas();

            // Add new instance.
            GMareInstance inst = _instanceClip.Clone();
            inst.X = ((int)(size.Width / Zoom) / 2) + (obj.Image.Width / 2) + Offset.X;
            inst.Y = ((int)(size.Height / Zoom) / 2) + (obj.Image.Height / 2) + Offset.Y;

            // Add the new instance.
            ProjectManager.Room.Instances.Add(inst);

            // Set selected instance.
            _selectedInstance = inst;

            // Fire selected instance changed event.
            SelectedInstanceChanged();
        }

        /// <summary>
        /// Instance send front.
        /// </summary>
        private void tsmi_InstanceSendFront_Click(object sender, EventArgs e)
        {
            // If the selected instance is empty, return.
            if (_selectedInstance == null)
                return;

            // Room changed, instance index changed.
            RoomChanged();

            // Send the selected instance to the end of the list.
            ProjectManager.Room.Instances.Add(_selectedInstance.Clone());
            ProjectManager.Room.Instances.Remove(_selectedInstance);

            // Select newly placed instance.
            _selectedInstance = ProjectManager.Room.Instances[ProjectManager.Room.Instances.Count - 1];

            // The selected instance changed.
            SelectedInstanceChanged();
        }

        /// <summary>
        /// Instance send back.
        /// </summary>
        private void tsmi_InstanceSendBack_Click(object sender, EventArgs e)
        {
            // If the selected instance is empty, return.
            if (_selectedInstance == null)
                return;

            // Room changed, instance index changed.
            RoomChanged();

            // Send the selected instance to the end of the list.
            ProjectManager.Room.Instances.Insert(0, _selectedInstance.Clone());
            ProjectManager.Room.Instances.Remove(_selectedInstance);

            // Select newly placed instance.
            _selectedInstance = ProjectManager.Room.Instances[0];

            // The selected instance changed.
            SelectedInstanceChanged();
        }

        /// <summary>
        /// Instance snap.
        /// </summary>
        private void tsmi_InstanceSnap_Click(object sender, EventArgs e)
        {
            // If the selected instance is empty, return.
            if (_selectedInstance == null)
                return;

            // The new snapped point to move the instance to.
            Point snap = Point.Empty;

            // Get the width and height of the snapped point.
            int width = (int)(_gridX * Zoom);
            int height = (int)(_gridY * Zoom);

            // Calculate snapped point.
            snap.X = (int)((((_selectedInstance.X) / width) * width) / Zoom);
            snap.Y = (int)((((_selectedInstance.Y) / height) * height) / Zoom);

            // If no change was made, return.
            if (_selectedInstance.X == snap.X && _selectedInstance.Y == snap.Y)
                return;

            // Room changed, instance position changed.
            RoomChanged();

            // Set instance new position.
            _selectedInstance.X = snap.X;
            _selectedInstance.Y = snap.Y;

            // The selected instance changed.
            SelectedInstanceChanged();
        }

        /// <summary>
        /// Instance creation code.
        /// </summary>
        private void tsmi_InstanceCode_Click(object sender, EventArgs e)
        {
            // If the selected instance is empty, return.
            if (_selectedInstance == null)
                return;

            // Create a new script form.
            using (ScriptForm form = new ScriptForm((string)_selectedInstance.CreationCode.Clone(), "Creation Code"))
            {
                // If ok was clicked.
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // If no change in creation code, return.
                    if (_selectedInstance.CreationCode == form.Code)
                        return;

                    // Room changed, instance creation code changed.
                    RoomChanged();

                    // Set creation code.
                    _selectedInstance.CreationCode = form.Code;

                    // The selected instance changed.
                    SelectedInstanceChanged();
                }
            }
        }

        /// <summary>
        /// Instance delete.
        /// </summary>
        public void tsmi_InstanceDelete_Click(object sender, EventArgs e)
        {
            // If no instance has been selected, return.
            if (_selectedInstance == null)
                return;

            // Room changed, instance deleted.
            RoomChanged();

            // Remove selected instance.
            ProjectManager.Room.Instances.Remove(_selectedInstance);

            // Selected instance changed.
            SelectedInstanceChanged();
        }

        /// <summary>
        /// Instance delete all.
        /// </summary>
        private void tsmi_InstanceDeleteAll_Click(object sender, EventArgs e)
        {
            // If the selected instance is empty, return.
            if (_selectedInstance == null)
                return;

            // Ask if the user really wants to delete all instances of a certain type.
            DialogResult result = MessageBox.Show("Are you sure you want to delete all " + tsmi_InstanceDeleteAll.Tag.ToString() + " ?", "GMare", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            // If the user wants to delete all instances of a certain type.
            if (result == DialogResult.Yes)
            {
                // Room changed, all instances of set type deleted.
                RoomChanged();

                // Delete all of the selected object type.
                ProjectManager.Room.Instances.RemoveAll(delegate(GMareInstance i) { return i.ObjectId == _selectedInstance.ObjectId; });

                // The selected instance changed.
                SelectedInstanceChanged();
            }
        }

        /// <summary>
        /// Instance clear.
        /// </summary>
        private void tsmi_InstanceClear_Click(object sender, EventArgs e)
        {
            // If there is nothing to clear, return.
            if (ProjectManager.Room.Instances.Count == 0)
                return;

            // Ask if the user really wants to clear all the instances.
            DialogResult result = MessageBox.Show("Are you sure you want to clear all instances from the room?", "GMare", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            // If the user wants to clear all instances.
            if (result == DialogResult.Yes)
            {
                // Room changed, all instances deleted.
                RoomChanged();

                // Clear all instances.
                ProjectManager.Room.Instances.Clear();

                // The selected instance changed.
                SelectedInstanceChanged();
            }
        }

        #endregion

        #endregion

        #region Overrides

        #region Create

        /// <summary>
        /// Override CreateControl event.
        /// </summary>
        protected override void OnCreateControl()
        {
            // Allow hooking of this event.
            base.OnCreateControl();

            // If not in design mode, initialize OpenGL.
            if (DesignMode == false)
                GraphicsManager.Initialize(this);

            // Set blend mode for alpha data.
            GraphicsManager.BlendMode = GraphicsManager.BlendType.Alpha;
        }

        #endregion

        #region Paint

        /// <summary>
        /// OnPaint.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            // If not in design mode, and a room is loaded.
            if (RoomExists() == true)
            {
                // Clear the screen.
                GraphicsManager.DrawClear(this.BackColor);

                // Begin drawing the scene.
                GraphicsManager.BeginScene();

                int width = ProjectManager.Room.Width;
                int height = ProjectManager.Room.Height;

                // Draw a blank background for room.
                GraphicsManager.DrawRectangle(new Rectangle(0, 0, width + 1, height + 1), ProjectManager.Room.BackColor, false);

                // Set scissor rectangle, to clip needless rendering.
                Size size = GetSmallestCanvas();
                GraphicsManager.Scissor = new Rectangle(0, this.ClientSize.Height - size.Height, size.Width, size.Height);

                // Draw tiles.
                DrawTiles();

                // If in instance mode, or view all mode, draw instances.
                if (_editMode == EditType.Instances || _editMode == EditType.ViewAll)
                    DrawInstances();

                // Draw grid.
                DrawGrid();
                
                // If in shapes mode, draw shapes.
                if (_editMode == EditType.Collisions)
                    DrawShapes();

                // Draw selection.
                if (_editMode == EditType.Layers)
                {
                    // If selection tool, draw selection, else draw the standard cursor.
                    if (_toolMode == ToolType.Selection)
                        DrawSelection();
                    else
                        DrawCursor();
                }

                // Disable scissor testing.
                OpenGL.glDisable(GLOption.ScissorTest);

                // End drawing the scene.
                GraphicsManager.EndScene();
            }
            else
                e.Graphics.Clear(this.BackColor);
        }

        /// <summary>
        /// Pain background.
        /// </summary>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Do nothing.
        }

        #endregion

        #region Mouse

        /// <summary>
        /// Mouse down in graphics panel.
        /// </summary>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Allow hooking of this event.
            base.OnMouseDown(e);

            // If a room has not been loaded, return.
            if (RoomExists() == false)
                return;

            switch (_editMode)
            {
                case EditType.Layers: LayersMouseDown(e); break;
                case EditType.Collisions: CollisionsMouseDown(e); break;
                case EditType.Instances: InstancesMouseDown(e); break;
            }
        }

        /// <summary>
        /// /// <summary>
        /// Mouse move in graphics panel.
        /// </summary>
        protected override void  OnMouseMove(MouseEventArgs e)
        {
            // Allow hooking of this event.
            base.OnMouseMove(e);

            // If a room has not been loaded, return.
            if (RoomExists() == false)
                return;

            // Calculate tile position.
            Size tileSize = ProjectManager.Room.TileSize;
            Point snap = GetSnappedPoint(e.Location, tileSize);

            // Set mouse position information.
            this.SetMouseActual = "Actual: " + GetActualPoint(e.X, e.Y).ToString();
            this.SetMouseSnapped = "Snapped: " + snap.ToString();

            // Do action based on edit mode.
            switch (_editMode)
            {
                case EditType.Layers: LayersMouseMove(e); break;
                case EditType.Collisions: CollisionsMouseMove(e); break;
                case EditType.Instances: InstancesMouseMove(e); break;
            }
        }

        /// <summary>
        /// Mouse up in graphics panel.
        /// </summary>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            // If a room has not been loaded, return.
            if (RoomExists() == false)
                return;
                
            // Do action based on edit mode.
            switch (_editMode)
            {
                case EditType.Layers: LayersMouseUp(); break;
                case EditType.Collisions: ShapesMouseUp(); break;
                case EditType.Instances: InstancesMouseUp(); break;
            }

            // Finish any dragging operation.
            _dragging = false;

            // Allow hooking of this event.
            base.OnMouseUp(e);
        }

        /// <summary>
        /// Mouse enter in graphics panel.
        /// </summary>
        protected override void  OnMouseEnter(EventArgs e)
        {
            // Focus for scroll support.
            Focus();

            // Allow hooking of this event.
            base.OnMouseEnter(e);

            // Set cursor.
            SetCursor();

            // Allow showing the cursor.
            _showCursor = true;

            // Update drawing.
            Invalidate();
        }

        /// <summary>
        /// Mouse leave in graphics panel.
        /// </summary>
        protected override void  OnMouseLeave(EventArgs e)
        {
            // Set mouse information.
            SetMouseActual = "Actual: -NA-";
            SetMouseSnapped = "Snapped: -NA-";
            SetMouseSector = "Tile Id: -NA-";

            // Set cursor.
            this.Cursor = Cursors.Arrow;

            // Do not allow showing the cursor.
            _showCursor = false;

            // Update drawing.
            Invalidate();
        }

        #endregion

        #endregion

        #region Methods

        #region Mouse

        #region Layers

        /// <summary>
        /// Layer mode mouse down.
        /// </summary>
        /// <param name="mouse">Mouse event arguments.</param>
        private void LayersMouseDown(MouseEventArgs mouse)
        {
            // Get snapped position.
            Size tileSize = ProjectManager.Room.TileSize;
            Point snap = GetSnappedPoint(mouse.Location, tileSize);

            // Check that the mouse is within room bounds.
            if (CheckBounds(mouse.X, mouse.Y) == false)
                return;

            // Do action based on tool.
            switch (_toolMode)
            {
                // Pencil tool.
                case ToolType.Pencil:

                    // Room changed, tiles have been set.
                    RoomChanged();

                    // Start dragging operation.
                    _dragging = true;

                    // If left click set tile, right click set tile empty.
                    if (mouse.Button == MouseButtons.Left)
                        SetTiles(mouse.X, mouse.Y, false, _tiles, false);
                    else if (mouse.Button == MouseButtons.Right)
                        SetTiles(mouse.X, mouse.Y, true, _tiles, false);

                    // Force redraw.
                    Invalidate();
                    break;

                // Bucket fill tool.
                case ToolType.Bucket:

                    // Room changed, tiles have been set.
                    RoomChanged();

                    // Calculate starting point in tiles.
                    Point tile = new Point(snap.X / tileSize.Width, snap.Y / tileSize.Height);

                    // If left click fill tile(s), right click set tile(s) empty.
                    if (mouse.Button == MouseButtons.Left)
                        ProjectManager.Room.Layers[_layerIndex].Fill(tile, _tiles.TileIds);
                    else if (mouse.Button == MouseButtons.Right)
                        SetTiles(mouse.X, mouse.Y, true, _tiles, false);

                    // Force redraw.
                    Invalidate();
                    break;

                // Selection tool.
                case ToolType.Selection:

                    // If left mouse button click.
                    if (mouse.Button == MouseButtons.Left)
                    {
                        // If a selection exists, and the mouse is within the selection.
                        if (_selection != null && _selection.ToRectangle().Contains(snap))
                        {
                            // Selection clicked.
                            _moving = true;

                            // If the selection has never been clicked to be moved.
                            if (_moved == false)
                            {
                                // Room changed, selected tiles set.
                                RoomChanged();

                                // Set tiles empty under selection.
                                SetTiles(_selection.StartX, _selection.StartY, true, _selection, true);

                                // Set one time moving flag.
                                _moved = true;
                            }

                            // Set zero position.
                            _posX = snap.X;
                            _posY = snap.Y;
                        }

                        // If not moving an existing selection.
                        if (_moving == false)
                        {
                            // If there is a previous selection, set it.
                            if (_selection != null)
                                SetTiles(_selection.StartX, _selection.StartY, false, _selection, true);

                            // Create a new selection.
                            _selection = new TileGrid();

                            // Start collecting other tiles.
                            _dragging = true;

                            // Set selection dimensions.
                            _selection.StartX = snap.X;
                            _selection.StartY = snap.Y;
                            _selection.EndX = _selection.StartX + tileSize.Width;
                            _selection.EndY = _selection.StartY + tileSize.Height;

                            // Force redraw.
                            Invalidate();
                        }
                    }
                    else if (mouse.Button == MouseButtons.Right)  // Show selection options.
                    {
                        // Disable all options by default.
                        for (int i = 0; i < cms_SelectionOptions.Items.Count; i++)
                            cms_SelectionOptions.Items[i].Enabled = false;

                        // If the selection is not empty.
                        if (_selection != null)
                        {
                            // Allow options.
                            tsmi_SelectionCopy.Enabled = true;
                            tsmi_SelectionCut.Enabled = true;
                            tsmi_SelectionDelete.Enabled = true;
                            tsmi_SelectionDeselect.Enabled = true;
                        }

                        // If the clipboard is empty, do not enable the paste function, else allow it.
                        tsmi_SelectionPaste.Enabled = _selectionClip == null ? false : true;

                        // If the mouse is not within the selection, and the clipboard is not empty, allow flood fill.
                        if (_selectionClip != null)
                        {
                            // If there is no selection, or if there is a fill, but the cursor is not within it, allow fill.
                            if (_selection == null)
                                tsmi_SelectionFill.Enabled = true;
                            else if (_selection != null && _selection.ToRectangle().Contains(snap) == false)
                                tsmi_SelectionFill.Enabled = true;
                        }

                        // Show menu.
                        cms_SelectionOptions.Show(PointToScreen(mouse.Location));
                    }

                    break;
            }
        }

        /// <summary>
        /// Layers mode mouse move.
        /// </summary>
        private void LayersMouseMove(MouseEventArgs mouse)
        {
            // Get snapped position.
            Size tileSize = ProjectManager.Room.TileSize;
            Point snap = GetSnappedPoint(mouse.Location, tileSize);

            // Set tile id string.
            SetMouseSector = "Tile Id: " + GetTile(mouse.X, mouse.Y);

            // Check that the mouse is within room bounds.
            if (CheckBounds(mouse.X, mouse.Y) == false)
            {
                // Reset cursor.
                this.Cursor = Cursors.Arrow;

                // Force redraw.
                Invalidate();
                return;
            }
            else
                SetCursor();

            // Do action based on tool mode.
            switch (_toolMode)
            {
                // Pencil tool.
                case ToolType.Pencil:

                    // If the new snapped position differs from the old position.
                    if (snap.X != _posX || snap.Y != _posY)
                    {
                        // Set new position check.
                        _posX = snap.X;
                        _posY = snap.Y;

                        // If left click set tile, right click set tile empty.
                        if (mouse.Button == MouseButtons.Left)
                            SetTiles(mouse.X, mouse.Y, false, _tiles, false);
                        else if (mouse.Button == MouseButtons.Right)
                            SetTiles(mouse.X, mouse.Y, true, _tiles, false);

                        // Force redraw.
                        Invalidate();
                    }

                    break;

                // Selection tool.
                case ToolType.Selection:

                    // If a selection exists, cursor is within selection rectangle, and not dragging selection rectangle.
                    if (_selection != null && _selection.ToRectangle().Contains(snap) == true && _dragging == false)
                        this.Cursor = Cursors.SizeAll;
                    else
                        this.Cursor = _cursorCross;

                    // If moving a selection.
                    if (_moving == true)
                    {
                        // If there is a change in snapped position since last movement.
                        if (snap.X != _posX || snap.Y != _posY)
                        {
                            // Calculate move amount.
                            Point pos = new Point(snap.X - _posX, snap.Y - _posY);

                            // Set check to new value.
                            _posX = snap.X;
                            _posY = snap.Y;

                            // Set selection position.
                            _selection.StartX += pos.X;
                            _selection.StartY += pos.Y;
                            _selection.EndX += pos.X;
                            _selection.EndY += pos.Y;

                            // Force redraw.
                            Invalidate();
                        }
                    }

                    // If dragging a rubberband rectangle.
                    if (_dragging == true)
                    {
                        // If the snapped x is greater than the start x, add an extra tile width to contain the mouse cursor.
                        if (snap.X >= _selection.StartX)
                            snap.X += ProjectManager.Room.TileWidth;

                        // If the snapped y is greater than the start y, add an extra tile height to contain the mouse cursor.
                        if (snap.Y >= _selection.StartY)
                            snap.Y += ProjectManager.Room.TileHeight;

                        // If there is a change in snapped position since last movement.
                        if (snap.X != _selection.EndX || snap.Y != _selection.EndY)
                        {
                            // If the end x coordinate is not equal to the start x coordinate, set it.
                            if (snap.X != _selection.StartX)
                                _selection.EndX = snap.X;

                            // If the end y coordinate is not equal to the start y coordinate, set it.
                            if (snap.Y != _selection.StartY)
                                _selection.EndY = snap.Y;
                        }

                        // Force redraw.
                        Invalidate();
                    }

                    break;

                default:

                    // If the mouse snap position is different, update.
                    if (snap.X != _posX || snap.Y != _posY)
                    {
                        // Set new check position.
                        _posX = snap.X;
                        _posY = snap.Y;

                        // Force redraw.
                        Invalidate();
                    }

                    break;
            }
        }

        /// <summary>
        /// Layers mode mouse up.
        /// </summary>
        private void LayersMouseUp()
        {
            // Do action based on tool type
            switch (_toolMode)
            {
                // Selection tool.
                case ToolType.Selection:

                    // If dragging, get selected tile ids.
                    if (_dragging == true)
                        // Set selection.
                        _selection.TileIds = GetTiles(_selection);

                    // Stop moving and dragging operations.
                    _moving = false;
                    _dragging = false;

                    // Force redraw.
                    Invalidate();
                    break;
            }
        }

        #endregion

        #region Instances

        /// <summary>
        /// Instances mouse down.
        /// </summary>
        /// <param name="mouse">Mouse event arguments.</param>
        private void InstancesMouseDown(MouseEventArgs mouse)
        {
            // Get snapped position based on grid.
            Point snap = GetSnappedPoint(mouse.Location, new Size(_gridX, _gridY)); 

            // If mouse left button clicked.
            if (mouse.Button == MouseButtons.Left)
            {
                // Check instance.
                CheckInstance(mouse.Location, true);

                // If the instance does not need to be snapped to the grid, set to actual coordinates.
                if (_snap == false)
                    snap = new Point((int)((mouse.Location.X + Offset.X) * Zoom), (int)((mouse.Location.Y + Offset.Y) * Zoom));

                // Start dragging operation.
                _dragging = true;

                // Set position.
                _posX = snap.X;
                _posY = snap.Y;

                // Force redraw.
                Invalidate();
            }
            else if (mouse.Button == MouseButtons.Right)  // If mouse right button clicked.
            {
                // Check for instance.
                bool item = CheckInstance(mouse.Location, true);

                // Disable all options by default.
                for (int i = 0; i < cms_InstanceOptions.Items.Count; i++)
                    cms_InstanceOptions.Items[i].Enabled = false;

                // If the selection is not empty.
                if (_selectedInstance != null && item == true)
                {
                    // Allow options.
                    tsmi_InstanceCopy.Enabled = true;
                    tsmi_InstanceCut.Enabled = true;
                    tsmi_InstanceDelete.Enabled = true;

                    tsmi_InstanceDeleteAll.Text = "Delete All: " + _selectedInstance.Name;
                    tsmi_InstanceDeleteAll.Tag = _selectedInstance.Name;
                    tsmi_InstanceDeleteAll.Enabled = true;

                    tsmi_InstanceSendBack.Enabled = true;
                    tsmi_InstanceSendFront.Enabled = true;
                    tsmi_InstanceSnap.Enabled = true;
                    tsmi_InstanceCode.Enabled = true;
                }
                else
                    tsmi_InstanceDeleteAll.Text = "Delete All";

                // Always allow clear.
                tsmi_InstanceClear.Enabled = true;

                // If the clipboard is empty, do not enable the paste function, else allow it.
                tsmi_InstancePaste.Enabled = _instanceClip == null ? false : true;

                // Show menu.
                cms_InstanceOptions.Show(PointToScreen(mouse.Location));
            }
        }

        /// <summary>
        /// Instances mouse move.
        /// </summary>
        /// <param name="mouse">Mouse event arguments.</param>
        private void InstancesMouseMove(MouseEventArgs mouse)
        {
            // If not doing a dragging operation, check for instances and return.
            if (_dragging == false)
            {
                // Check for instance collision.
                CheckInstance(mouse.Location, false);
                return;
            }

            // Get snapped position, based on grid.
            Point pos = GetSnappedPoint(mouse.Location, new Size(_gridX, _gridY));

            // If the instance does not need to be snapped to the grid, set to actual coordinates.
            if (_snap == false)
                pos = new Point((int)(mouse.Location.X / Zoom + Offset.X), (int)(mouse.Location.Y / Zoom + Offset.Y));

            // If there is a change in position since last movement.
            if (_posX != pos.X || _posY != pos.Y)
            {
                // If an instance has been selected.
                if (_selectedInstance != null)
                {
                    // Get object associated with selected instance. We need the origin.
                    GMareObject obj = ProjectManager.Room.Objects.Find(delegate(GMareObject o) { return o.Resource.Id == _selectedInstance.ObjectId; });

                    // If no object was found, end dragging and return.
                    if (obj == null)
                    {
                        _dragging = false;
                        return;
                    }

                    // Change the selected instance's position.
                    _selectedInstance.X = pos.X - obj.OriginX;
                    _selectedInstance.Y = pos.Y - obj.OriginY;
                }

                // Set new drag display position.
                _posX = pos.X;
                _posY = pos.Y;

                // Force redraw.
                Invalidate();
            }
        }

        /// <summary>
        /// Instances mouse up.
        /// </summary>
        private void InstancesMouseUp()
        {
            // If no object was selected, or not in a dragging operation return.
            if (_selectedObject == null || _dragging == false || _selectedInstance != null)
                return;

            // Room changed, instance added.
            RoomChanged();

            // Create a new instance, based off of selected object.
            GMareInstance inst = new GMareInstance();
            inst.ObjectId = _selectedObject.Resource.Id;
            inst.Name = _selectedObject.Resource.Name;
            inst.Depth = _selectedObject.Depth;
            inst.X = _posX - _selectedObject.OriginX;
            inst.Y = _posY - _selectedObject.OriginY;

            // Add the new instance.
            ProjectManager.Room.Instances.Add(inst);

            // Set selected instance.
            _selectedInstance = inst;

            // Fire selected instance changed event.
            SelectedInstanceChanged();

            // Force redraw.
            Invalidate();
        }

        /// <summary>
        /// Check's if a point is within an instance. Optionally sets it as selected if it is.
        /// </summary>
        /// <param name="point">The point to check.</param>
        /// <param name="set">If the item should be selected if within bounds.</param>
        private bool CheckInstance(Point point, bool set)
        {
            // Set cursor
            this.Cursor = Cursors.Arrow;

            // Offset scroll position.
            point.X += (int)(Offset.X * Zoom);
            point.Y += (int)(Offset.Y * Zoom);

            // Iterate through instances backwards (Top items have more priority).
            for (int i = ProjectManager.Room.Instances.Count - 1; i > -1; i--)
            {
                // Get instance.
                GMareInstance instance = ProjectManager.Room.Instances[i];

                // Get the instance rectangle.
                Size size = GraphicsManager.Sprites[instance.ObjectId].Size;
                Rectangle rect = new Rectangle((int)(instance.X * Zoom), (int)(instance.Y * Zoom), (int)(size.Width * Zoom), (int)(size.Height * Zoom));

                // If the rectangle contains the mouse.
                if (rect.Contains(point))
                {
                    // Get location on the sprite.
                    int x = point.X - (int)(instance.X * Zoom);
                    int y = point.Y - (int)(instance.Y * Zoom);

                    // Get the pixel from the sprite.
                    Color color = Color.FromArgb(GraphicsManager.Sprites[instance.ObjectId].Pixels[(int)(x / Zoom), (int)(y / Zoom)]);

                    // If not on a transparent pixel. (Pixels arranged in GDI format) :P
                    if (color.B != 0)
                    {
                        // If the instance should be selected.
                        if (set == true)
                        {
                            // Set dragging instance.
                            _selectedInstance = instance;

                            // Fire selected instance changed event.
                            SelectedInstanceChanged();
                        }

                        // Set cursor.
                        this.Cursor = Cursors.SizeAll;
                        return true;
                    }
                }
            }

            // If an instance needs to be set, clear selected instance for a new one.
            if (set == true)
                _selectedInstance = null;

            return false;
        }

        #endregion

        #region Collisions

        /// <summary>
        /// Collisions mode mouse down.
        /// </summary>
        private void CollisionsMouseDown(MouseEventArgs mouse)
        {
            // Get snapped position.
            Size tileSize = ProjectManager.Room.TileSize;
            Point snap = GetSnappedPoint(mouse.Location, new Size(_gridX, _gridY));

            // If a shape was selected, return;
            if (CollisionContains(mouse.Location, true) == true)
                return;

            // Create a new rectangle.
            GMareCollision shape = new GMareCollision();
            shape.Level = _level;

            // Add a new shape to the shapes list.
            ProjectManager.Room.Shapes.Add(shape);

            // Set selected shape.
            _selectedShape = shape;
        }

        /// <summary>
        /// Collisions mode mouse move.
        /// </summary>
        private void CollisionsMouseMove(MouseEventArgs mouse)
        {
            // If drawing, and the selected node is valid.
            if (_dragging == true)
            {
                // If no node was selected, break.
                if (_selectedPoint == -1)
                    return;

                // Get snapped position.
                Size tileSize = ProjectManager.Room.TileSize;
                Point snap = GetSnappedPoint(mouse.Location, new Size(_gridX, _gridY));

                // Set selectied nodes.
                _selectedShape[_selectedPoint] = snap;

                // Update drawing.
                Invalidate();
            }
            else  // Set cursor.
                CollisionContains(mouse.Location, false);
        }

        /// <summary>
        /// Collisions mode mouse up.
        /// </summary>
        private void ShapesMouseUp()
        {
            // Reset node for shape mode.
            _selectedPoint = -1;
        }

        /// <summary>
        /// Sets the shape under the mouse, if there is one.
        /// </summary>
        /// <param name="point">The point to check.</param>
        /// <param name="set">If the item should be selected if within bounds.</param>
        /// <returns>Whether a shape was selected or not.</returns>
        private bool CollisionContains(Point point, bool set)
        {
            // Set cursor
            this.Cursor = Cursors.Arrow;

            // Offset scroll position.
            point.X += Offset.X;
            point.Y += Offset.Y;

            // Iterate through room shapes, search for a selection.
            foreach (GMareCollision shape in ProjectManager.Room.Shapes)
            {
                // Iterate through nodes.
                for (int i = 0; i < shape.Nodes.Length; i++)
                {
                    // If the mouse lies within the shape node.
                    if (shape.Nodes[i].Contains(point))
                    {
                        // If the shape and node should be set.
                        if (set == true)
                        {
                            // Set the slected shape, and node.
                            _selectedShape = shape;
                            _selectedPoint = i;

                            // Allow dragging.
                            _dragging = true;
                        }

                        // Set cursor.
                        this.Cursor = Cursors.SizeAll;

                        // Selected a shape.
                        return true;
                    }

                    // If the mouse lies within the shape.
                    if (shape.Contains(point))
                    {
                        // Set the selected shape.
                        if (set == true)
                            _selectedShape = shape;

                        // Selected a shape.
                        return true;
                    }
                }
            }

            // The point is not contained by any shape or node.
            return false;
        }

        #endregion

        #endregion

        #region Draw

        #region DrawTiles

        /// <summary>
        /// Draws all the tiles in the tile array.
        /// </summary>
        private void DrawTiles()
        {
            // Get various variables.
            Size tileSize = ProjectManager.Room.TileSize;
            int layers = ProjectManager.Room.Layers.Count - 1;
            int cols = ProjectManager.Room.Columns;
            int rows = ProjectManager.Room.Rows;
            int depth = 0;

            // Destination rectangle.
            Rectangle position = new Rectangle(0, 0, tileSize.Width, tileSize.Height);

            // Source Rectangle.
            Point source = Point.Empty;

            // Calculate tileset width.
            int width = (int)Math.Floor((double)(ProjectManager.Room.Background.Width - ProjectManager.Room.OffsetX) / (double)(ProjectManager.Room.TileWidth + ProjectManager.Room.SeparationX)) * ProjectManager.Room.TileWidth;

            // Iterate through layers.
            for (int layer = layers; layer > -1; layer--)
            {
                // Get layer depth.
                depth = ProjectManager.Room.Layers[layer].Depth;

                // Set the blend mode based on drawing depth.
                int index = GetIndex(depth);

                // Iterate through columns.
                for (int col = 0; col < cols; col++)
                {
                    // Iterate through rows.
                    for (int row = 0; row < rows; row++)
                    {
                        // Get tile id.
                        int tileId = ProjectManager.Room.Layers[layer].Tiles[col, row];

                        // If the tile is empty, continue looping.
                        if (tileId == -1)
                            continue;

                        // Calculate destination rectangle.
                        position.X = col * tileSize.Width;
                        position.Y = row * tileSize.Height;

                        Rectangle viewport = ClientRectangle;
                        viewport.X = Offset.X;
                        viewport.Y = Offset.Y;
                        viewport.Width = (int)(viewport.Width / Zoom);
                        viewport.Height = (int)(viewport.Height / Zoom);

                        // If the tile is visible within the viewport, draw tile.
                        if (viewport.IntersectsWith(position) == false)
                            continue;

                        // Calculate source point.
                        source = TileGrid.TileIdToSector(tileId, width, tileSize);

                        // Draw tile to cache.
                        if (source.X < GraphicsManager.TileMaps[0].GetLength(0) && source.Y < GraphicsManager.TileMaps[0].GetLength(1))
                            GraphicsManager.DrawTile(GraphicsManager.TileMaps[index][source.X, source.Y], position.X, position.Y, Color.White);
                    }
                }

                // Draw cache.
                GraphicsManager.DrawSpriteBatch(true);
            }
        }

        #endregion

        #region DrawGrid

        /// <summary>
        /// Draws the grid.
        /// </summary>
        private void DrawGrid()
        {
            // If the grid is not being shown, return.
            if (_showGrid == false)
                return;

            // Position variables.
            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;
            Size canvas = GetSmallestCanvas();

            // Calculate line amounts.
            int cols = (int)(canvas.Width / _gridX / Zoom) + 2;
            int rows = (int)(canvas.Height / _gridY / Zoom) + 2;

            // Calculate offsets.
            int offsetX = Offset.X % ProjectManager.Room.Width;
            int offsetY = Offset.Y % ProjectManager.Room.Height;

            // Calculate snap.
            Point snap = GetSnappedPoint(new Point(Offset.X - offsetX, Offset.Y - offsetY), new Size(_gridX, _gridY));

            // Grid color.
            Color color = Color.FromArgb(128, Color.Black);

            // Draw grid based on grid mode.
            switch (_gridMode)
            {
                // Draw a normal grid.
                case GridType.Normal:

                    // Draw vertical lines.
                    for (int col = 0; col < cols; col++)
                    {
                        // Calculate coordinates.
                        x1 = col * _gridX + snap.X;
                        y1 = snap.Y;
                        x2 = col * _gridX + snap.X;
                        y2 = (int)(canvas.Height / Zoom) + snap.Y + _gridY;

                        // Draw line.
                        GraphicsManager.DrawLineCache(x1, y1, x2, y2, color);
                    }

                    // Draw horizontal lines.
                    for (int row = 0; row < rows; row++)
                    {
                        // Calculate coordinates.
                        x1 = snap.X;
                        y1 = row * _gridY + snap.Y;
                        x2 = (int)(canvas.Width / Zoom) + snap.X + _gridX;
                        y2 = row * _gridY + snap.Y;

                        // Draw line.
                        GraphicsManager.DrawLineCache(x1, y1, x2, y2, color);
                    }

                    break;

                // Draw an isometric grid.
                case GridType.Isometric:

                    // Iterate through visible rows.
                    for (int y = MathMethods.DivideTowardsNegative(0, _gridY) * _gridY; y < rows * _gridY; y += _gridY)
                    {
                        // Iterate through visible columns.
                        for (int x = MathMethods.DivideTowardsNegative(0, _gridX) * _gridX; x < cols * _gridX; x += _gridX)
                        {
                            // Calculate positions.
                            x1 = (x + (_gridX >> 1)) + snap.X;
                            y1 = (y + (_gridY >> 1)) + snap.Y;
                            x2 = (x + (_gridX + 1 >> 1)) + snap.X;
                            y2 = (y + (_gridY + 1 >> 1)) + snap.Y;

                            // Draw lines.
                            GraphicsManager.DrawLineCache(x + snap.X, y2, x1, y + _gridY + snap.Y, color);
                            GraphicsManager.DrawLineCache(x2, y + _gridY + snap.Y, x + _gridX + snap.X, y2, color);
                            GraphicsManager.DrawLineCache(x + _gridX + snap.X, y1, x2, y + snap.Y, color);
                            GraphicsManager.DrawLineCache(x1, y + snap.Y, x + snap.X, y1, color);
                        }
                    }

                    break;
            }

            // Draw line batch.
            GraphicsManager.DrawLineBatch();
        }

        #endregion

        #region DrawCursor

        /// <summary>
        /// Draws the selected tiles with a rectangle border.
        /// </summary>
        private void DrawCursor()
        {
            // If the cursor should not be drawn, return.
            if (_showCursor == false)
                return;

            // Get room tilesize.
            Size tileSize = ProjectManager.Room.TileSize;

            // Create a new selection rectangle
            Rectangle selection = new Rectangle();

            // Get selection rectangle.
            selection = _tiles.ToRectangle();
            selection.X = _posX;
            selection.Y = _posY;

            // Calculate tileset width.
            int width = ProjectManager.Room.Background.Width;
            width = (width - ((width / tileSize.Width) * ProjectManager.Room.SeparationX));

            // Source Rectangle.
            Point source = Point.Empty;

            // Destination point.
            Point position = Point.Empty;

            // Iterate through tiles horizontally.
            for (int col = 0; col < _tiles.Columns; col++)
            {
                // Iterate through tiles vertically.
                for (int row = 0; row < _tiles.Rows; row++)
                {
                    // Calculate source point.
                    source = TileGrid.TileIdToSector(_tiles.TileIds[col, row], width, tileSize);
                    position.X = _posX + col * tileSize.Width;
                    position.Y = _posY + row * tileSize.Height;

                    // Draw tile.
                    GraphicsManager.DrawTile(GraphicsManager.TileMaps[2][source.X, source.Y], position.X, position.Y, Color.White);
                }
            }

            // Draw cache.
            GraphicsManager.DrawSpriteBatch(true);

            // Draw cursor border.
            selection.Width += 1;
            selection.Height += 1;
            GraphicsManager.DrawRectangle(selection, Color.Black, true);
            selection.X += 1;
            selection.Y += 1;
            selection.Width -= 2;
            selection.Height -= 2;
            GraphicsManager.DrawRectangle(selection, Color.White, true);
            selection.X += 1;
            selection.Y += 1;
            selection.Width -= 2;
            selection.Height -= 2;
            GraphicsManager.DrawRectangle(selection, Color.Black, true);
        }

        #endregion

        #region DrawShapes

        /// <summary>
        /// Draws all the room shapes.
        /// </summary>
        private void DrawShapes()
        {
            // Shape color.
            Color color = Color.Red;

            // Iterate through shapes.
            foreach (GMareCollision shape in ProjectManager.Room.Shapes)
            {
                // If the shape is the currently selected shape, change color.
                if (shape == _selectedShape)
                    color = Color.White;
                else
                {
                    switch (shape.Level)
                    {
                        case 0: color = Color.Lime; break;
                        case 1: color = Color.Blue; break;
                        case 2: color = Color.Purple; break;
                        case 3: color = Color.Orange; break;
                        case 4: color = Color.Red; break;
                    }
                }

                // Draw nodes.
                GraphicsManager.DrawRectangles(shape.Nodes, color, false);
                GraphicsManager.DrawRectangles(shape.Nodes, Color.White, true);
            }
        }

        #endregion

        #region DrawInstances

        /// <summary>
        /// Draws all the instances within the room.
        /// </summary>
        private void DrawInstances()
        {
            // Blending color.
            Color blend = Color.White;

            // If in view all mode, draw instances semi-transparent.
            if (_editMode == EditType.ViewAll)
                blend = Color.FromArgb(128, Color.White);

            // Iterate through room instances.
            foreach (GMareInstance instance in ProjectManager.Room.Instances)
            {
                // If in instance mode, and the selected instance is being drawn, use different blend.
                if (_editMode == EditType.Instances && instance == _selectedInstance)
                    GraphicsManager.DrawSprite(instance.ObjectId, instance.X, instance.Y, Color.Orange);
                else
                    GraphicsManager.DrawSprite(instance.ObjectId, instance.X, instance.Y, blend);
            }

            // If dragging an instance, there's no instance selected and there is an object selected, draw dragging instance.
            if (_dragging == true && _selectedInstance == null && _selectedObject != null)
                GraphicsManager.DrawSprite(_selectedObject.Resource.Id, _posX - _selectedObject.OriginX, _posY - _selectedObject.OriginY, Color.FromArgb(128, Color.White));

            // Draw sprite batch.
            GraphicsManager.DrawSpriteBatch(false);
        }

        #endregion

        #region DrawSelection

        /// <summary>
        /// Draws selection from selection tool.
        /// </summary>
        private void DrawSelection()
        {
            // If the selection is empty, return
            if (_selection == null)
                return;

            // Get room tilesize.
            Size tileSize = ProjectManager.Room.TileSize;

            // Calculate tileset width.
            int width = ProjectManager.Room.Background.Width;
            width = (width - ((width / tileSize.Width) * ProjectManager.Room.SeparationX));

            // Source Rectangle.
            Point source = Point.Empty;

            // Destination point.
            Point position = Point.Empty;

            // Iterate through tiles horizontally.
            for (int col = 0; col < _selection.Columns; col++)
            {
                // Iterate through tiles vertically.
                for (int row = 0; row < _selection.Rows; row++)
                {
                    // Calculate source point.
                    if (_selection.TileIds[col, row] == -1)
                        continue;

                    // Calculate source point.
                    source = TileGrid.TileIdToSector(_selection.TileIds[col, row], width, tileSize);
                    position.X = _selection.StartX + col * tileSize.Width;
                    position.Y = _selection.StartY + row * tileSize.Height;

                    // Draw tile.
                    GraphicsManager.DrawTile(GraphicsManager.TileMaps[0][source.X, source.Y], position.X, position.Y, Color.White);
                }
            }

            // Draw sprite cache.
            GraphicsManager.DrawSpriteBatch(true);

            // Create a selection rectangle.
            Rectangle rect = _selection.ToRectangle();
            rect.Width += 1;
            rect.Height += 1;

            GraphicsManager.DrawRectangle(rect, Color.Black, true);
            GraphicsManager.DrawStippledRectangle(rect, Color.White, _stippleOffset);
        }

        #endregion

        #endregion

        #region Cursor

        /// <summary>
        /// Sets the room's cursor.
        /// </summary>
        private void SetCursor()
        {
            // Default cursor.
            this.Cursor = Cursors.Arrow;

            // If in layer edit mode.
            if (_editMode == EditType.Layers)
            {
                // Switch cursor based on tool mode.
                switch (_toolMode)
                {
                    case ToolType.Pencil: this.Cursor = _cursorPencil; break;
                    case ToolType.Bucket: this.Cursor = _cursorBucket; break;
                    case ToolType.Selection: this.Cursor = _cursorCross; break;
                }
            }
        }

        #endregion

        #region Tile

        /// <summary>
        /// Gets the tile id at the desired position.
        /// </summary>
        /// <param name="x">Mouse X position.</param>
        /// <param name="y">Mouse Y position.</param>
        private string GetTile(int x, int y)
        {
            // If not within bounds of the layers array or room, return empty tile id.
            if ( _layerIndex < 0 || _layerIndex >= ProjectManager.Room.Layers.Count || CheckBounds(x, y) == false)
                return "- NA -";

            // Calculate tilesize.
            Size tileSize = ProjectManager.Room.TileSize;

            // Get snapped position.
            Point snap = GetSnappedPoint(new Point(x, y), tileSize);

            // Get column and row.
            int col = snap.X / ProjectManager.Room.TileWidth;
            int row = snap.Y / ProjectManager.Room.TileHeight;

            // Return tile id.
            return ProjectManager.Room.Layers[_layerIndex].Tiles[col, row].ToString();
        }

        /// <summary> 
        /// Get a selection of tiles from the selected layer.
        /// </summary>
        /// <param name="grid">The grid to use for selection data.</param>
        /// <returns>An array of tiles.</returns>
        private int[,] GetTiles(TileGrid grid)
        {
            // A new array of tile ids.
            Rectangle rect = grid.ToRectangle();
            Size tileSize = ProjectManager.Room.TileSize;
            int[,] tiles = new int[rect.Width / tileSize.Width, rect.Height / tileSize.Height];

            // Iterate through columns.
            for (int col = 0; col < tiles.GetLength(0); col++)
            {
                // Iterate through rows.
                for (int row = 0; row < tiles.GetLength(1); row++)
                {
                    // Calculate source position.
                    int x = ((col * tileSize.Width) + rect.X) / tileSize.Width;
                    int y = ((row * tileSize.Height) + rect.Y) / tileSize.Height;

                    // Set tile id.
                    tiles[col, row] = ProjectManager.Room.Layers[_layerIndex].Tiles[x, y];
                }
            }

            // Return selected tiles.
            return tiles;
        }

        /// <summary>
        /// Sets a tile index based on mouse coordinates.
        /// </summary>
        /// <param name="x">Mouse X position.</param>
        /// <param name="y">Mouse Y position.</param>
        private void SetTiles(int x, int y, bool setEmpty, TileGrid tiles, bool absolute)
        {
            // Calculate tilesize.
            Size tileSize = ProjectManager.Room.TileSize;

            // Set snap point.
            Point snap = new Point(x, y);

            // If snap has not been pre-calculated, calculate snapped position.
            if (absolute == false)
                snap = GetSnappedPoint(new Point(x, y), tileSize);

            // Iterate through columns.
            for (int col = 0; col < tiles.TileIds.GetLength(0); col++)
            {
                // Iterate through rows.
                for (int row = 0; row < tiles.TileIds.GetLength(1); row++)
                {
                    // Calculate destination tile position.
                    int destCol = (snap.X / tileSize.Width) + col;
                    int destRow = (snap.Y / tileSize.Height) + row;

                    // If index not within bounds, continue.
                    if (destRow < 0 || destCol > ProjectManager.Room.Columns - 1 ||
                        destCol < 0 || destRow > ProjectManager.Room.Rows - 1)
                        continue;

                    // If set empty is true, set tile id to -1, else set a the targter tile id.
                    if (setEmpty == true)
                        ProjectManager.Room.Layers[_layerIndex].Tiles[destCol, destRow] = -1;
                    else
                        ProjectManager.Room.Layers[_layerIndex].Tiles[destCol, destRow] = tiles.TileIds[col, row];
                }
            }
        }

        /// <summary>
        /// Sets the blend mode for tile drawing.
        /// </summary>
        /// <param name="depth">The depth of the tile.</param>
        /// <returns>Tileset index to use for rendering.</returns>
        private int GetIndex(int depth)
        {
            // If the layer is the currently selected layer, or not in layer mode, draw opaque.
            if (depth == _depthIndex || _editMode != EditType.Layers)
                return 0;

            // If the depth is more than the currently selected layer, draw dark.
            if (depth > _depthIndex)
                return 1;
            else
                return 2;
        }

        #endregion

        #region Math

        /// <summary>
        /// Check if coordinates are within the room rectangle.
        /// </summary>
        /// <param name="x">The horizontal coordinate.</param>
        /// <param name="y">The vertical coordinate.</param>
        /// <returns>False if out of bounds, else true.</returns>
        private bool CheckBounds(int x, int y)
        {
            // Calculate position with scroll offset.
            int offsetX = (int)(Offset.X * Zoom);
            int offsetY = (int)(Offset.Y * Zoom);
            x = (int)((x + offsetX) / Zoom);
            y = (int)((y + offsetY) / Zoom);

            // If the coordinate is out of bounds.
            if (x < 0 || x > ProjectManager.Room.Width - 1 || y < 0 || y > ProjectManager.Room.Height - 1)
            {
                _showCursor = false;
                return false;
            }

            // Show the cursor it is withing bounds.
            _showCursor = true;

            // Within bounds.
            return true;
        }

        /// <summary>
        /// Gets the actual point within the room.
        /// </summary>
        /// <param name="x">The relative horizontal coordinate.</param>
        /// <param name="y">The relative vertical coordinate.</param>
        /// <returns>A point within the room.</returns>
        private Point GetActualPoint(int x, int y)
        {
            // Create a new point.
            Point point = new Point();

            // Calculate position with scroll offset.
            int offsetX = (int)(Offset.X * Zoom);
            int offsetY = (int)(Offset.Y * Zoom);
            point.X = (int)((x + offsetX) / Zoom);
            point.Y = (int)((y + offsetY) / Zoom);

            // Return area corrected point.
            return point;
        }

        /// <summary>
        /// Calculates a snapped version of a point.
        /// </summary>
        /// <param name="position">Point to use as snapping origin.</param>
        /// <param name="snap">Snapping value.</param>
        /// <returns>A snapped point.</returns>
        private Point GetSnappedPoint(Point position, Size snap)
        {
            // Calculate snapped position.
            int width = (int)(snap.Width * Zoom);
            int height = (int)(snap.Height * Zoom);
            int offsetX = (int)(Offset.X * Zoom);
            int offsetY = (int)(Offset.Y * Zoom);
            int x = (int)((((position.X + offsetX) / width) * width) / Zoom);
            int y = (int)((((position.Y + offsetY) / height) * height) / Zoom);

            return new Point(x, y);
        }

        /// <summary>
        /// Gets the smallest drawing area. Room size versus client size.
        /// </summary>
        /// <returns>The smallest drawing size.</returns>
        private Size GetSmallestCanvas()
        {
            // Set size to client size.
            Size size = ClientSize;

            // if no project to compare to, return the client size.
            if (ProjectManager.Room == null)
                return size;

            // Check for the smallest width.
            if (ClientSize.Width > (int)(ProjectManager.Room.Width * Zoom))
                size.Width = (int)(ProjectManager.Room.Width * Zoom);

            // Check for the smallest height.
            if (ClientSize.Height > (int)(ProjectManager.Room.Height * Zoom))
                size.Height = (int)(ProjectManager.Room.Height * Zoom);

            // Return the smallest possible drawing area.
            return size;
        }

        #endregion

        #region Texture

        /// <summary>
        /// Loads a texture from a bitmap.
        /// </summary>
        private void LoadTexture(Bitmap image)
        {
            // If no image exists, return.
            if (image == null || ProjectManager.Room == null)
                return;

            // Delete any previous tilemaps.
            GraphicsManager.DeleteTilemaps();

            // This is so that the bitmap is pre-rendered with "blending effects", instead of using OpenGL.
            GraphicsManager.LoadTileMap(image, ProjectManager.Room.TileWidth, ProjectManager.Room.TileHeight);
            GraphicsManager.LoadTileMap(PixelMap.BitmapBrightness(image, -0.3f), ProjectManager.Room.TileWidth, ProjectManager.Room.TileHeight);
            GraphicsManager.LoadTileMap(PixelMap.BitmapTransparency(image, 0.5f), ProjectManager.Room.TileWidth, ProjectManager.Room.TileHeight);

            image.Dispose();
        }

        #endregion

        #region Validation

        /// <summary>
        /// Checks if a room was loaded, and if it has a background.
        /// </summary>
        /// <returns>Whether the room and tileset exists.</returns>
        private bool RoomExists()
        {
            // If the project and background do not exist, return false.
            if (ProjectManager.Room == null || ProjectManager.Room.Background == null)
                return false;

            // Room and background exists, return true.
            return true;
        }

        /// <summary>
        /// Reset the control to empty state.
        /// </summary>
        public void Reset()
        {
            _selection = null;
            _selectedInstance = null;
            _selectedObject = null;
            _selectedShape = null;
            _selectionClip = null;
            _instanceClip = null;

            // Delete textures.
            GraphicsManager.DeleteTextures();
            GraphicsManager.DeleteTilemaps();
        }

        #endregion

        #region Timer

        /// <summary>
        /// Marching ants timer tick.
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Increase offset.
            _stippleOffset++;

            // If at maximum offset, reset offset.
            if (_stippleOffset % 8 == 0)
                _stippleOffset = 0;

            // As long as there is a selection, force redraw.
            if (_selection != null)
                Invalidate();
        }

        #endregion

        #endregion
    }
}