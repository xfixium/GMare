namespace GMare.Controls
{
    partial class GMareRoomEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlLayout = new System.Windows.Forms.TableLayoutPanel();
            this.sbVertical = new System.Windows.Forms.VScrollBar();
            this.sbHorizontal = new System.Windows.Forms.HScrollBar();
            this.pnlRoom = new GMare.Controls.GMareRoomPanel();
            this.pnlMain.SuspendLayout();
            this.pnlLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.Window;
            this.pnlMain.Controls.Add(this.pnlLayout);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(1, 1);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(1);
            this.pnlMain.Size = new System.Drawing.Size(148, 148);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlLayout
            // 
            this.pnlLayout.BackColor = System.Drawing.SystemColors.Control;
            this.pnlLayout.ColumnCount = 2;
            this.pnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.pnlLayout.Controls.Add(this.pnlRoom, 0, 0);
            this.pnlLayout.Controls.Add(this.sbVertical, 1, 0);
            this.pnlLayout.Controls.Add(this.sbHorizontal, 0, 1);
            this.pnlLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLayout.Location = new System.Drawing.Point(1, 1);
            this.pnlLayout.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLayout.Name = "pnlLayout";
            this.pnlLayout.RowCount = 2;
            this.pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.pnlLayout.Size = new System.Drawing.Size(146, 146);
            this.pnlLayout.TabIndex = 3;
            // 
            // sbVertical
            // 
            this.sbVertical.Dock = System.Windows.Forms.DockStyle.Right;
            this.sbVertical.Location = new System.Drawing.Point(129, 0);
            this.sbVertical.Name = "sbVertical";
            this.sbVertical.Size = new System.Drawing.Size(17, 129);
            this.sbVertical.TabIndex = 7;
            this.sbVertical.ValueChanged += new System.EventHandler(this.sbVertical_ValueChanged);
            // 
            // sbHorizontal
            // 
            this.sbHorizontal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sbHorizontal.Location = new System.Drawing.Point(0, 129);
            this.sbHorizontal.Name = "sbHorizontal";
            this.sbHorizontal.Size = new System.Drawing.Size(129, 17);
            this.sbHorizontal.TabIndex = 8;
            this.sbHorizontal.ValueChanged += new System.EventHandler(this.sbHorizontal_ValueChanged);
            // 
            // pnlRoom
            // 
            this.pnlRoom.AltKey = false;
            this.pnlRoom.AvoidMouseEvents = false;
            this.pnlRoom.BackColor = System.Drawing.Color.White;
            this.pnlRoom.Brush = null;
            this.pnlRoom.ControlKey = false;
            this.pnlRoom.DepthIndex = 0;
            this.pnlRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoom.EditMode = GMare.Objects.EditType.Layers;
            this.pnlRoom.GridMode = GMare.Objects.GridType.Normal;
            this.pnlRoom.GridX = 16;
            this.pnlRoom.GridY = 16;
            this.pnlRoom.HandKey = false;
            this.pnlRoom.InvertGridColor = false;
            this.pnlRoom.LayerIndex = -1;
            this.pnlRoom.Level = 0;
            this.pnlRoom.Location = new System.Drawing.Point(0, 0);
            this.pnlRoom.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRoom.Name = "pnlRoom";
            this.pnlRoom.Offset = new System.Drawing.Point(0, 0);
            this.pnlRoom.SelectedBackground = null;
            this.pnlRoom.SelectedObject = null;
            this.pnlRoom.ShiftKey = false;
            this.pnlRoom.ShowBlocks = true;
            this.pnlRoom.ShowGrid = true;
            this.pnlRoom.ShowInstances = true;
            this.pnlRoom.Size = new System.Drawing.Size(129, 129);
            this.pnlRoom.Snap = true;
            this.pnlRoom.TabIndex = 6;
            this.pnlRoom.ToolMode = GMare.Objects.ToolType.Brush;
            this.pnlRoom.Zoom = 1F;
            this.pnlRoom.MousePositionChanged += new GMare.Controls.GMareRoomPanel.MousePositionHandler(this.pnlRoom_MousePositionChanged);
            this.pnlRoom.SelectedObjectChanged += new GMare.Controls.GMareRoomPanel.SelectedObjectChangedHandler(this.pnlRoom_SelectedObjectChanged);
            this.pnlRoom.SelectedInstancesPositionChanged += new GMare.Controls.GMareRoomPanel.InstancePositionHandler(this.pnlRoom_InstancesPositionChanged);
            this.pnlRoom.SelectedInstanceChanged += new GMare.Controls.GMareRoomPanel.InstanceChangedHandler(this.pnlRoom_InstancesChanged);
            this.pnlRoom.RoomChanging += new GMare.Controls.GMareRoomPanel.RoomChangingHandler(this.pnlRoom_RoomChanged);
            this.pnlRoom.ClipboardChanged += new GMare.Controls.GMareRoomPanel.ClipboardChangedHandler(this.pnlRoom_ClipboardChanged);
            this.pnlRoom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlRoom_MouseDown);
            this.pnlRoom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_Room_MouseMove);
            this.pnlRoom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_Room_MouseUp);
            // 
            // GMareRoomEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlMain);
            this.Name = "GMareRoomEditor";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.pnlMain.ResumeLayout(false);
            this.pnlLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TableLayoutPanel pnlLayout;
        private GMareRoomPanel pnlRoom;
        private System.Windows.Forms.VScrollBar sbVertical;
        private System.Windows.Forms.HScrollBar sbHorizontal;




    }
}
