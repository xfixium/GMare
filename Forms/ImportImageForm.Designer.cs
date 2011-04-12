namespace GMare.Forms
{
    partial class ImportImageForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnl_Image = new GMare.Controls.PanelEx();
            this.nud_TileY = new GMare.Controls.NumericUpDownEx();
            this.nud_TileX = new GMare.Controls.NumericUpDownEx();
            this.nud_OffsetY = new GMare.Controls.NumericUpDownEx();
            this.nud_OffsetX = new GMare.Controls.NumericUpDownEx();
            this.nud_SeperationY = new GMare.Controls.NumericUpDownEx();
            this.nud_SeperationX = new GMare.Controls.NumericUpDownEx();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pnl_Tileset = new GMare.Controls.TilesPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_Ok = new System.Windows.Forms.ToolStripButton();
            this.tsb_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Compile = new System.Windows.Forms.ToolStripButton();
            this.tsb_CancelCompile = new System.Windows.Forms.ToolStripButton();
            this.tsb_Undo = new System.Windows.Forms.ToolStripButton();
            this.tsb_Redo = new System.Windows.Forms.ToolStripButton();
            this.tsb_Grid = new System.Windows.Forms.ToolStripButton();
            this.tsb_Zoom = new GMare.Controls.ZoomToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.nud_Columns = new GMare.Controls.ToolStripNumericUpDown();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tb_Name = new GMare.Controls.ToolStripTextBoxEx();
            this.gb_Options = new System.Windows.Forms.GroupBox();
            this.gb_TileSize = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gb_Offset = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gb_Seperation = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_TileCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.bgw_Compile = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TileY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TileX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_OffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_OffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SeperationY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SeperationX)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.gb_Options.SuspendLayout();
            this.gb_TileSize.SuspendLayout();
            this.gb_Offset.SuspendLayout();
            this.gb_Seperation.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Image
            // 
            this.pnl_Image.BackColor = System.Drawing.SystemColors.Window;
            this.pnl_Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnl_Image.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Image.Location = new System.Drawing.Point(8, 256);
            this.pnl_Image.Name = "pnl_Image";
            this.pnl_Image.Size = new System.Drawing.Size(144, 144);
            this.pnl_Image.TabIndex = 3;
            this.toolTip1.SetToolTip(this.pnl_Image, "Original image");
            // 
            // nud_TileY
            // 
            this.nud_TileY.Location = new System.Drawing.Point(96, 42);
            this.nud_TileY.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nud_TileY.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nud_TileY.Name = "nud_TileY";
            this.nud_TileY.Size = new System.Drawing.Size(40, 20);
            this.nud_TileY.TabIndex = 1;
            this.toolTip1.SetToolTip(this.nud_TileY, "The height of a single tile");
            this.nud_TileY.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // nud_TileX
            // 
            this.nud_TileX.Location = new System.Drawing.Point(96, 18);
            this.nud_TileX.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nud_TileX.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nud_TileX.Name = "nud_TileX";
            this.nud_TileX.Size = new System.Drawing.Size(40, 20);
            this.nud_TileX.TabIndex = 0;
            this.toolTip1.SetToolTip(this.nud_TileX, "The width of a single tile");
            this.nud_TileX.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // nud_OffsetY
            // 
            this.nud_OffsetY.Location = new System.Drawing.Point(96, 42);
            this.nud_OffsetY.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_OffsetY.Name = "nud_OffsetY";
            this.nud_OffsetY.Size = new System.Drawing.Size(40, 20);
            this.nud_OffsetY.TabIndex = 1;
            this.toolTip1.SetToolTip(this.nud_OffsetY, "The vertical tile offset");
            // 
            // nud_OffsetX
            // 
            this.nud_OffsetX.Location = new System.Drawing.Point(96, 18);
            this.nud_OffsetX.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_OffsetX.Name = "nud_OffsetX";
            this.nud_OffsetX.Size = new System.Drawing.Size(40, 20);
            this.nud_OffsetX.TabIndex = 0;
            this.toolTip1.SetToolTip(this.nud_OffsetX, "The horizontal tile offset");
            // 
            // nud_SeperationY
            // 
            this.nud_SeperationY.Location = new System.Drawing.Point(96, 42);
            this.nud_SeperationY.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_SeperationY.Name = "nud_SeperationY";
            this.nud_SeperationY.Size = new System.Drawing.Size(40, 20);
            this.nud_SeperationY.TabIndex = 1;
            this.toolTip1.SetToolTip(this.nud_SeperationY, "Seperation between tiles vertically");
            // 
            // nud_SeperationX
            // 
            this.nud_SeperationX.Location = new System.Drawing.Point(96, 18);
            this.nud_SeperationX.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_SeperationX.Name = "nud_SeperationX";
            this.nud_SeperationX.Size = new System.Drawing.Size(40, 20);
            this.nud_SeperationX.TabIndex = 0;
            this.toolTip1.SetToolTip(this.nud_SeperationX, "Seperation between tiles horizontally");
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pnl_Tileset);
            this.groupBox4.Location = new System.Drawing.Point(176, 32);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(432, 408);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tiles";
            // 
            // pnl_Tileset
            // 
            this.pnl_Tileset.AllowDrop = true;
            this.pnl_Tileset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Tileset.AutoScroll = true;
            this.pnl_Tileset.AutoScrollMinSize = new System.Drawing.Size(256, 256);
            this.pnl_Tileset.BackColor = System.Drawing.Color.White;
            this.pnl_Tileset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Tileset.Columns = 16;
            this.pnl_Tileset.Location = new System.Drawing.Point(10, 18);
            this.pnl_Tileset.Name = "pnl_Tileset";
            this.pnl_Tileset.ShowGrid = true;
            this.pnl_Tileset.Size = new System.Drawing.Size(412, 380);
            this.pnl_Tileset.TabIndex = 0;
            this.pnl_Tileset.Tiles = null;
            this.pnl_Tileset.TileSize = new System.Drawing.Size(16, 16);
            this.pnl_Tileset.Zoom = 1F;
            this.pnl_Tileset.PanelChanged += new GMare.Controls.TilesPanel.PanelChangedHandler(this.pnl_Tileset_PanelChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_Ok,
            this.tsb_Cancel,
            this.toolStripSeparator1,
            this.tsb_Compile,
            this.tsb_CancelCompile,
            this.tsb_Undo,
            this.tsb_Redo,
            this.tsb_Grid,
            this.tsb_Zoom,
            this.toolStripLabel1,
            this.nud_Columns,
            this.toolStripLabel2,
            this.tb_Name});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(618, 26);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_Ok
            // 
            this.tsb_Ok.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Ok.Image = global::GMare.Properties.Resources.accept;
            this.tsb_Ok.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Ok.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_Ok.Name = "tsb_Ok";
            this.tsb_Ok.Size = new System.Drawing.Size(23, 23);
            this.tsb_Ok.Text = "toolStripButton1";
            this.tsb_Ok.ToolTipText = "Ok";
            this.tsb_Ok.Click += new System.EventHandler(this.tsb_Ok_Click);
            // 
            // tsb_Cancel
            // 
            this.tsb_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Cancel.Image = global::GMare.Properties.Resources.decline;
            this.tsb_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Cancel.Name = "tsb_Cancel";
            this.tsb_Cancel.Size = new System.Drawing.Size(23, 23);
            this.tsb_Cancel.Text = "toolStripButton2";
            this.tsb_Cancel.ToolTipText = "Cancel";
            this.tsb_Cancel.Click += new System.EventHandler(this.tsb_Cancel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // tsb_Compile
            // 
            this.tsb_Compile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Compile.Image = global::GMare.Properties.Resources.room;
            this.tsb_Compile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Compile.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_Compile.Name = "tsb_Compile";
            this.tsb_Compile.Size = new System.Drawing.Size(23, 23);
            this.tsb_Compile.Text = "toolStripButton1";
            this.tsb_Compile.ToolTipText = "Compile tiles from source image";
            this.tsb_Compile.Click += new System.EventHandler(this.tsb_Compile_Click);
            // 
            // tsb_CancelCompile
            // 
            this.tsb_CancelCompile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_CancelCompile.Image = global::GMare.Properties.Resources.button_decline;
            this.tsb_CancelCompile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_CancelCompile.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_CancelCompile.Name = "tsb_CancelCompile";
            this.tsb_CancelCompile.Size = new System.Drawing.Size(23, 23);
            this.tsb_CancelCompile.Text = "toolStripButton1";
            this.tsb_CancelCompile.ToolTipText = "Cancel tile compile";
            this.tsb_CancelCompile.Click += new System.EventHandler(this.tsb_CancelCompile_Click);
            // 
            // tsb_Undo
            // 
            this.tsb_Undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Undo.Image = global::GMare.Properties.Resources.arrow_undo;
            this.tsb_Undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Undo.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_Undo.Name = "tsb_Undo";
            this.tsb_Undo.Size = new System.Drawing.Size(23, 23);
            this.tsb_Undo.Text = "toolStripButton1";
            this.tsb_Undo.ToolTipText = "Undo";
            this.tsb_Undo.Click += new System.EventHandler(this.tsb_Undo_Click);
            // 
            // tsb_Redo
            // 
            this.tsb_Redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Redo.Image = global::GMare.Properties.Resources.arrow_redo;
            this.tsb_Redo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Redo.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_Redo.Name = "tsb_Redo";
            this.tsb_Redo.Size = new System.Drawing.Size(23, 23);
            this.tsb_Redo.Text = "toolStripButton2";
            this.tsb_Redo.ToolTipText = "Redo";
            this.tsb_Redo.Click += new System.EventHandler(this.tsb_Redo_Click);
            // 
            // tsb_Grid
            // 
            this.tsb_Grid.Checked = true;
            this.tsb_Grid.CheckOnClick = true;
            this.tsb_Grid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsb_Grid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Grid.Image = global::GMare.Properties.Resources.grid;
            this.tsb_Grid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Grid.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_Grid.Name = "tsb_Grid";
            this.tsb_Grid.Size = new System.Drawing.Size(23, 23);
            this.tsb_Grid.Text = "toolStripButton4";
            this.tsb_Grid.ToolTipText = "Show grid";
            this.tsb_Grid.Click += new System.EventHandler(this.tsb_Grid_Click);
            // 
            // tsb_Zoom
            // 
            this.tsb_Zoom.Image = global::GMare.Properties.Resources.magnifier;
            this.tsb_Zoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Zoom.Name = "tsb_Zoom";
            this.tsb_Zoom.Size = new System.Drawing.Size(64, 23);
            this.tsb_Zoom.Text = "100%";
            this.tsb_Zoom.UseIncrements = true;
            this.tsb_Zoom.ZoomChanged += new GMare.Controls.ZoomToolStripButton.ZoomChangedHandler(this.tsb_Zoom_ZoomChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(95, 23);
            this.toolStripLabel1.Text = "Tileset Columns:";
            // 
            // nud_Columns
            // 
            this.nud_Columns.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_Columns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Columns.Name = "nud_Columns";
            this.nud_Columns.Size = new System.Drawing.Size(53, 23);
            this.nud_Columns.Text = "16";
            this.nud_Columns.ToolTipText = "The amount of tile columns the tileset has";
            this.nud_Columns.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nud_Columns.ValueChanged += new System.EventHandler(this.nud_Columns_ValueChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(77, 23);
            this.toolStripLabel2.Text = "Room Name:";
            // 
            // tb_Name
            // 
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(100, 26);
            this.tb_Name.Text = "New Room";
            this.tb_Name.ToolTipText = "A personalized name for the room";
            // 
            // gb_Options
            // 
            this.gb_Options.Controls.Add(this.pnl_Image);
            this.gb_Options.Controls.Add(this.gb_TileSize);
            this.gb_Options.Controls.Add(this.gb_Offset);
            this.gb_Options.Controls.Add(this.gb_Seperation);
            this.gb_Options.Location = new System.Drawing.Point(8, 32);
            this.gb_Options.Name = "gb_Options";
            this.gb_Options.Size = new System.Drawing.Size(160, 408);
            this.gb_Options.TabIndex = 7;
            this.gb_Options.TabStop = false;
            this.gb_Options.Text = "Image To Tileset Options";
            // 
            // gb_TileSize
            // 
            this.gb_TileSize.Controls.Add(this.nud_TileY);
            this.gb_TileSize.Controls.Add(this.nud_TileX);
            this.gb_TileSize.Controls.Add(this.label1);
            this.gb_TileSize.Controls.Add(this.label2);
            this.gb_TileSize.Location = new System.Drawing.Point(8, 16);
            this.gb_TileSize.Name = "gb_TileSize";
            this.gb_TileSize.Size = new System.Drawing.Size(144, 72);
            this.gb_TileSize.TabIndex = 0;
            this.gb_TileSize.TabStop = false;
            this.gb_TileSize.Text = "Tile Size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Height:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Width:";
            // 
            // gb_Offset
            // 
            this.gb_Offset.Controls.Add(this.nud_OffsetY);
            this.gb_Offset.Controls.Add(this.nud_OffsetX);
            this.gb_Offset.Controls.Add(this.label5);
            this.gb_Offset.Controls.Add(this.label6);
            this.gb_Offset.Location = new System.Drawing.Point(8, 96);
            this.gb_Offset.Name = "gb_Offset";
            this.gb_Offset.Size = new System.Drawing.Size(144, 72);
            this.gb_Offset.TabIndex = 2;
            this.gb_Offset.TabStop = false;
            this.gb_Offset.Text = "Tile Offset";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Vertical:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Horizontal:";
            // 
            // gb_Seperation
            // 
            this.gb_Seperation.Controls.Add(this.nud_SeperationY);
            this.gb_Seperation.Controls.Add(this.nud_SeperationX);
            this.gb_Seperation.Controls.Add(this.label3);
            this.gb_Seperation.Controls.Add(this.label4);
            this.gb_Seperation.Location = new System.Drawing.Point(8, 176);
            this.gb_Seperation.Name = "gb_Seperation";
            this.gb_Seperation.Size = new System.Drawing.Size(144, 72);
            this.gb_Seperation.TabIndex = 1;
            this.gb_Seperation.TabStop = false;
            this.gb_Seperation.Text = "Tile Separation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Vertical:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Horizontal:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_Status,
            this.tssl_TileCount,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel3,
            this.tssl_Progress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 451);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(618, 24);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl_Status
            // 
            this.tssl_Status.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tssl_Status.Name = "tssl_Status";
            this.tssl_Status.Size = new System.Drawing.Size(81, 19);
            this.tssl_Status.Text = "Status: Ready";
            this.tssl_Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssl_TileCount
            // 
            this.tssl_TileCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tssl_TileCount.Name = "tssl_TileCount";
            this.tssl_TileCount.Size = new System.Drawing.Size(78, 19);
            this.tssl_TileCount.Text = "Tile Count: 0";
            this.tssl_TileCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(199, 19);
            this.toolStripStatusLabel1.Text = "Right click tile selection for options.";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(143, 19);
            this.toolStripStatusLabel3.Spring = true;
            this.toolStripStatusLabel3.Text = "Progress:";
            this.toolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tssl_Progress
            // 
            this.tssl_Progress.Name = "tssl_Progress";
            this.tssl_Progress.Size = new System.Drawing.Size(100, 18);
            // 
            // bgw_Compile
            // 
            this.bgw_Compile.WorkerReportsProgress = true;
            this.bgw_Compile.WorkerSupportsCancellation = true;
            this.bgw_Compile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_Compile_DoWork);
            this.bgw_Compile.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_Compile_ProgressChanged);
            this.bgw_Compile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_Compile_RunWorkerCompleted);
            // 
            // ImportImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 475);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gb_Options);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportImageForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image To Room";
            ((System.ComponentModel.ISupportInitialize)(this.nud_TileY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TileX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_OffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_OffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SeperationY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SeperationX)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gb_Options.ResumeLayout(false);
            this.gb_TileSize.ResumeLayout(false);
            this.gb_TileSize.PerformLayout();
            this.gb_Offset.ResumeLayout(false);
            this.gb_Offset.PerformLayout();
            this.gb_Seperation.ResumeLayout(false);
            this.gb_Seperation.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_Ok;
        private System.Windows.Forms.ToolStripButton tsb_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsb_Grid;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private GMare.Controls.ToolStripNumericUpDown nud_Columns;
        private System.Windows.Forms.GroupBox gb_Options;
        private System.Windows.Forms.GroupBox gb_TileSize;
        private GMare.Controls.NumericUpDownEx nud_TileY;
        private GMare.Controls.NumericUpDownEx nud_TileX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gb_Offset;
        private GMare.Controls.NumericUpDownEx nud_OffsetY;
        private GMare.Controls.NumericUpDownEx nud_OffsetX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gb_Seperation;
        private GMare.Controls.NumericUpDownEx nud_SeperationY;
        private GMare.Controls.NumericUpDownEx nud_SeperationX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private GMare.Controls.PanelEx pnl_Image;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox4;
        private GMare.Controls.TilesPanel pnl_Tileset;
        private System.Windows.Forms.ToolStripStatusLabel tssl_TileCount;
        private System.Windows.Forms.ToolStripProgressBar tssl_Progress;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private GMare.Controls.ToolStripTextBoxEx tb_Name;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Status;
        private System.Windows.Forms.ToolStripButton tsb_Compile;
        private System.Windows.Forms.ToolStripButton tsb_CancelCompile;
        private System.ComponentModel.BackgroundWorker bgw_Compile;
        private GMare.Controls.ZoomToolStripButton tsb_Zoom;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripButton tsb_Undo;
        private System.Windows.Forms.ToolStripButton tsb_Redo;
    }
}