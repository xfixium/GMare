namespace GMare.Controls
{
    partial class RoomEditor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tlp_Layout = new System.Windows.Forms.TableLayoutPanel();
            this.pnl_Room = new GMare.Controls.RoomPanel();
            this.sb_Vertical = new System.Windows.Forms.VScrollBar();
            this.sb_Horizontal = new System.Windows.Forms.HScrollBar();
            this.panel1.SuspendLayout();
            this.tlp_Layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.tlp_Layout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(148, 148);
            this.panel1.TabIndex = 0;
            // 
            // tlp_Layout
            // 
            this.tlp_Layout.BackColor = System.Drawing.SystemColors.Control;
            this.tlp_Layout.ColumnCount = 2;
            this.tlp_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tlp_Layout.Controls.Add(this.pnl_Room, 0, 0);
            this.tlp_Layout.Controls.Add(this.sb_Vertical, 1, 0);
            this.tlp_Layout.Controls.Add(this.sb_Horizontal, 0, 1);
            this.tlp_Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Layout.Location = new System.Drawing.Point(1, 1);
            this.tlp_Layout.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Layout.Name = "tlp_Layout";
            this.tlp_Layout.RowCount = 2;
            this.tlp_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tlp_Layout.Size = new System.Drawing.Size(146, 146);
            this.tlp_Layout.TabIndex = 3;
            // 
            // pnl_Room
            // 
            this.pnl_Room.BackColor = System.Drawing.Color.White;
            this.pnl_Room.Brush = null;
            this.pnl_Room.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pnl_Room.DepthIndex = 0;
            this.pnl_Room.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Room.EditMode = GMare.Common.EditType.ViewAll;
            this.pnl_Room.GridMode = GMare.Common.GridType.Normal;
            this.pnl_Room.GridX = 16;
            this.pnl_Room.GridY = 16;
            this.pnl_Room.LayerIndex = -1;
            this.pnl_Room.Level = 0;
            this.pnl_Room.Location = new System.Drawing.Point(0, 0);
            this.pnl_Room.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_Room.Name = "pnl_Room";
            this.pnl_Room.Offset = new System.Drawing.Point(0, 0);
            this.pnl_Room.SelectedInstance = null;
            this.pnl_Room.SelectedObject = null;
            this.pnl_Room.SelectedShape = null;
            this.pnl_Room.ShapeMode = GMare.Common.ShapeType.Rectangle;
            this.pnl_Room.ShowGrid = true;
            this.pnl_Room.Size = new System.Drawing.Size(129, 129);
            this.pnl_Room.Snap = true;
            this.pnl_Room.TabIndex = 6;
            this.pnl_Room.ToolMode = GMare.Common.ToolType.Brush;
            this.pnl_Room.Zoom = 1F;
            this.pnl_Room.PositionChanged += new GMare.Controls.RoomPanel.PositionHandler(this.pnl_Room_PositionChanged);
            this.pnl_Room.SelectedInstanceChanged += new GMare.Controls.RoomPanel.InstanceChangedHandler(this.pnl_Room_InstanceChanged);
            this.pnl_Room.RoomChanging += new GMare.Controls.RoomPanel.RoomChangingHandler(this.pnl_Room_RoomChanged);
            this.pnl_Room.ClipboardChanged += new GMare.Controls.RoomPanel.ClipboardChangedHandler(this.pnl_Room_ClipboardChanged);
            this.pnl_Room.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_Room_MouseDown);
            this.pnl_Room.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_Room_MouseMove);
            this.pnl_Room.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_Room_MouseUp);
            // 
            // sb_Vertical
            // 
            this.sb_Vertical.Dock = System.Windows.Forms.DockStyle.Right;
            this.sb_Vertical.Location = new System.Drawing.Point(129, 0);
            this.sb_Vertical.Name = "sb_Vertical";
            this.sb_Vertical.Size = new System.Drawing.Size(17, 129);
            this.sb_Vertical.TabIndex = 7;
            this.sb_Vertical.ValueChanged += new System.EventHandler(this.sb_Vertical_ValueChanged);
            // 
            // sb_Horizontal
            // 
            this.sb_Horizontal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sb_Horizontal.Location = new System.Drawing.Point(0, 129);
            this.sb_Horizontal.Name = "sb_Horizontal";
            this.sb_Horizontal.Size = new System.Drawing.Size(129, 17);
            this.sb_Horizontal.TabIndex = 8;
            this.sb_Horizontal.ValueChanged += new System.EventHandler(this.sb_Horizontal_ValueChanged);
            // 
            // RoomEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel1);
            this.Name = "RoomEditor";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.ResumeLayout(false);
            this.tlp_Layout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tlp_Layout;
        private RoomPanel pnl_Room;
        private System.Windows.Forms.VScrollBar sb_Vertical;
        private System.Windows.Forms.HScrollBar sb_Horizontal;




    }
}
