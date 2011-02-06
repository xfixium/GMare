namespace GMare.Forms
{
    partial class RoomForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl_Width = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Height = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_MaskColor = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.nud_TileY = new GMare.Controls.NumericUpDownEx();
            this.nud_TileX = new GMare.Controls.NumericUpDownEx();
            this.tb_Name = new GMare.Controls.TextBoxEx();
            this.nud_OffsetY = new GMare.Controls.NumericUpDownEx();
            this.nud_OffsetX = new GMare.Controls.NumericUpDownEx();
            this.nud_SeperationY = new GMare.Controls.NumericUpDownEx();
            this.nud_SeperationX = new GMare.Controls.NumericUpDownEx();
            this.nud_Rows = new GMare.Controls.NumericUpDownEx();
            this.nud_Columns = new GMare.Controls.NumericUpDownEx();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_Ok = new System.Windows.Forms.ToolStripButton();
            this.tsb_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Image = new System.Windows.Forms.ToolStripButton();
            this.tsb_SetColorKey = new System.Windows.Forms.ToolStripButton();
            this.tsb_ShowGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Zoom = new GMare.Controls.ZoomToolStripButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_Image = new GMare.Controls.ImagePanel();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TileY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TileX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_OffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_OffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SeperationY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SeperationX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Rows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Columns)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_Width,
            this.tssl_Height,
            this.toolStripStatusLabel1,
            this.tssl_MaskColor});
            this.statusStrip1.Location = new System.Drawing.Point(0, 409);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(583, 24);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl_Width
            // 
            this.tssl_Width.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tssl_Width.Name = "tssl_Width";
            this.tssl_Width.Size = new System.Drawing.Size(90, 19);
            this.tssl_Width.Text = "Room Width: 0";
            // 
            // tssl_Height
            // 
            this.tssl_Height.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tssl_Height.Name = "tssl_Height";
            this.tssl_Height.Size = new System.Drawing.Size(94, 19);
            this.tssl_Height.Text = "Room Height: 0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(105, 19);
            this.toolStripStatusLabel1.Text = "Transparent Color:";
            // 
            // tssl_MaskColor
            // 
            this.tssl_MaskColor.AutoSize = false;
            this.tssl_MaskColor.BackColor = System.Drawing.Color.Transparent;
            this.tssl_MaskColor.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tssl_MaskColor.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tssl_MaskColor.Name = "tssl_MaskColor";
            this.tssl_MaskColor.Size = new System.Drawing.Size(17, 18);
            // 
            // nud_TileY
            // 
            this.nud_TileY.Location = new System.Drawing.Point(112, 42);
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
            this.nud_TileY.Size = new System.Drawing.Size(56, 20);
            this.nud_TileY.TabIndex = 1;
            this.toolTip1.SetToolTip(this.nud_TileY, "The height of a single tile");
            this.nud_TileY.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nud_TileY.ValueChanged += new System.EventHandler(this.nud_TileSize_ValueChanged);
            // 
            // nud_TileX
            // 
            this.nud_TileX.Location = new System.Drawing.Point(112, 18);
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
            this.nud_TileX.Size = new System.Drawing.Size(56, 20);
            this.nud_TileX.TabIndex = 0;
            this.toolTip1.SetToolTip(this.nud_TileX, "The width of a single tile");
            this.nud_TileX.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nud_TileX.ValueChanged += new System.EventHandler(this.nud_TileSize_ValueChanged);
            // 
            // tb_Name
            // 
            this.tb_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Name.Location = new System.Drawing.Point(8, 18);
            this.tb_Name.MaxLength = 40;
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(160, 20);
            this.tb_Name.TabIndex = 0;
            this.tb_Name.Text = "New Room";
            this.toolTip1.SetToolTip(this.tb_Name, "A personalized name for the room");
            this.tb_Name.TextChanged += new System.EventHandler(this.tb_Name_TextChanged);
            // 
            // nud_OffsetY
            // 
            this.nud_OffsetY.Location = new System.Drawing.Point(112, 42);
            this.nud_OffsetY.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_OffsetY.Name = "nud_OffsetY";
            this.nud_OffsetY.Size = new System.Drawing.Size(56, 20);
            this.nud_OffsetY.TabIndex = 1;
            this.toolTip1.SetToolTip(this.nud_OffsetY, "The vertical tile offset");
            this.nud_OffsetY.ValueChanged += new System.EventHandler(this.nud_Offset_ValueChanged);
            // 
            // nud_OffsetX
            // 
            this.nud_OffsetX.Location = new System.Drawing.Point(112, 18);
            this.nud_OffsetX.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_OffsetX.Name = "nud_OffsetX";
            this.nud_OffsetX.Size = new System.Drawing.Size(56, 20);
            this.nud_OffsetX.TabIndex = 0;
            this.toolTip1.SetToolTip(this.nud_OffsetX, "The horizontal tile offset");
            this.nud_OffsetX.ValueChanged += new System.EventHandler(this.nud_Offset_ValueChanged);
            // 
            // nud_SeperationY
            // 
            this.nud_SeperationY.Location = new System.Drawing.Point(112, 42);
            this.nud_SeperationY.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_SeperationY.Name = "nud_SeperationY";
            this.nud_SeperationY.Size = new System.Drawing.Size(56, 20);
            this.nud_SeperationY.TabIndex = 1;
            this.toolTip1.SetToolTip(this.nud_SeperationY, "Separation between tiles vertically");
            this.nud_SeperationY.ValueChanged += new System.EventHandler(this.nud_Seperation_ValueChanged);
            // 
            // nud_SeperationX
            // 
            this.nud_SeperationX.Location = new System.Drawing.Point(112, 18);
            this.nud_SeperationX.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_SeperationX.Name = "nud_SeperationX";
            this.nud_SeperationX.Size = new System.Drawing.Size(56, 20);
            this.nud_SeperationX.TabIndex = 0;
            this.toolTip1.SetToolTip(this.nud_SeperationX, "Separation between tiles horizontally");
            this.nud_SeperationX.ValueChanged += new System.EventHandler(this.nud_Seperation_ValueChanged);
            // 
            // nud_Rows
            // 
            this.nud_Rows.Location = new System.Drawing.Point(112, 42);
            this.nud_Rows.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nud_Rows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Rows.Name = "nud_Rows";
            this.nud_Rows.Size = new System.Drawing.Size(56, 20);
            this.nud_Rows.TabIndex = 1;
            this.toolTip1.SetToolTip(this.nud_Rows, "The number of tiles vertically");
            this.nud_Rows.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // nud_Columns
            // 
            this.nud_Columns.Location = new System.Drawing.Point(112, 18);
            this.nud_Columns.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nud_Columns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Columns.Name = "nud_Columns";
            this.nud_Columns.Size = new System.Drawing.Size(56, 20);
            this.nud_Columns.TabIndex = 0;
            this.toolTip1.SetToolTip(this.nud_Columns, "The number of tiles horizontally");
            this.nud_Columns.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_Ok,
            this.tsb_Cancel,
            this.toolStripSeparator1,
            this.tsb_Image,
            this.tsb_SetColorKey,
            this.tsb_ShowGrid,
            this.toolStripSeparator2,
            this.tsb_Zoom});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(583, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_Ok
            // 
            this.tsb_Ok.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Ok.Image = global::GMare.Properties.Resources.accept;
            this.tsb_Ok.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Ok.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_Ok.Name = "tsb_Ok";
            this.tsb_Ok.Size = new System.Drawing.Size(23, 22);
            this.tsb_Ok.ToolTipText = "Ok";
            this.tsb_Ok.Click += new System.EventHandler(this.tsb_Ok_Click);
            // 
            // tsb_Cancel
            // 
            this.tsb_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Cancel.Image = global::GMare.Properties.Resources.decline;
            this.tsb_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Cancel.Name = "tsb_Cancel";
            this.tsb_Cancel.Size = new System.Drawing.Size(23, 22);
            this.tsb_Cancel.ToolTipText = "Cancel";
            this.tsb_Cancel.Click += new System.EventHandler(this.tsb_Cancel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_Image
            // 
            this.tsb_Image.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Image.Image = global::GMare.Properties.Resources.image;
            this.tsb_Image.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Image.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_Image.Name = "tsb_Image";
            this.tsb_Image.Size = new System.Drawing.Size(23, 22);
            this.tsb_Image.Text = "toolStripButton1";
            this.tsb_Image.ToolTipText = "Get image file from disk";
            this.tsb_Image.Click += new System.EventHandler(this.tsb_Image_Click);
            // 
            // tsb_SetColorKey
            // 
            this.tsb_SetColorKey.CheckOnClick = true;
            this.tsb_SetColorKey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_SetColorKey.Image = global::GMare.Properties.Resources.point;
            this.tsb_SetColorKey.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_SetColorKey.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_SetColorKey.Name = "tsb_SetColorKey";
            this.tsb_SetColorKey.Size = new System.Drawing.Size(23, 22);
            this.tsb_SetColorKey.Text = "toolStripButton2";
            this.tsb_SetColorKey.ToolTipText = "Use the bottom left pixel as the transparent color";
            this.tsb_SetColorKey.CheckedChanged += new System.EventHandler(this.tsb_SetColorKey_CheckedChanged);
            // 
            // tsb_ShowGrid
            // 
            this.tsb_ShowGrid.Checked = true;
            this.tsb_ShowGrid.CheckOnClick = true;
            this.tsb_ShowGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsb_ShowGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_ShowGrid.Image = global::GMare.Properties.Resources.grid;
            this.tsb_ShowGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_ShowGrid.Name = "tsb_ShowGrid";
            this.tsb_ShowGrid.Size = new System.Drawing.Size(23, 22);
            this.tsb_ShowGrid.Text = "toolStripButton1";
            this.tsb_ShowGrid.ToolTipText = "Show the cell grid";
            this.tsb_ShowGrid.CheckedChanged += new System.EventHandler(this.tsb_ShowGrid_CheckedChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_Zoom
            // 
            this.tsb_Zoom.Image = global::GMare.Properties.Resources.magnifier;
            this.tsb_Zoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Zoom.Name = "tsb_Zoom";
            this.tsb_Zoom.Size = new System.Drawing.Size(64, 22);
            this.tsb_Zoom.Text = "100%";
            this.tsb_Zoom.UseIncrements = true;
            this.tsb_Zoom.ZoomChanged += new GMare.Controls.ZoomToolStripButton.ZoomChangedHandler(this.tsb_Zoom_ZoomChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.nud_TileY);
            this.groupBox7.Controls.Add(this.nud_TileX);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Location = new System.Drawing.Point(8, 168);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(176, 72);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Tile Size";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Height:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Width:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tb_Name);
            this.groupBox6.Location = new System.Drawing.Point(8, 32);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(176, 48);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Name";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.nud_OffsetY);
            this.groupBox5.Controls.Add(this.nud_OffsetX);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Location = new System.Drawing.Point(8, 248);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(176, 72);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tile Offset";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nud_SeperationY);
            this.groupBox2.Controls.Add(this.nud_SeperationX);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(8, 328);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 72);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tile Separation";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nud_Rows);
            this.groupBox1.Controls.Add(this.nud_Columns);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 72);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Room Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rows:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Columns:";
            // 
            // pnl_Image
            // 
            this.pnl_Image.AutoScroll = true;
            this.pnl_Image.AutoScrollMinSize = new System.Drawing.Size(376, 360);
            this.pnl_Image.BackColor = System.Drawing.Color.White;
            this.pnl_Image.Blink = false;
            this.pnl_Image.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Image.Image = null;
            this.pnl_Image.Location = new System.Drawing.Point(192, 32);
            this.pnl_Image.Name = "pnl_Image";
            this.pnl_Image.OffsetX = 0;
            this.pnl_Image.OffsetY = 0;
            this.pnl_Image.SeperationX = 0;
            this.pnl_Image.SeperationY = 0;
            this.pnl_Image.ShowGrid = true;
            this.pnl_Image.Size = new System.Drawing.Size(380, 364);
            this.pnl_Image.TabIndex = 25;
            this.pnl_Image.TileSize = new System.Drawing.Size(16, 16);
            this.pnl_Image.Zoom = 1F;
            // 
            // RoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 433);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnl_Image);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoomForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Room Properties";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TileY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TileX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_OffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_OffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SeperationY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SeperationX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Rows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Columns)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_Ok;
        private System.Windows.Forms.ToolStripButton tsb_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Width;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Height;
        private System.Windows.Forms.ToolStripButton tsb_ShowGrid;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_MaskColor;
        private System.Windows.Forms.ToolStripButton tsb_SetColorKey;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsb_Image;
        private System.Windows.Forms.GroupBox groupBox7;
        private GMare.Controls.NumericUpDownEx nud_TileY;
        private GMare.Controls.NumericUpDownEx nud_TileX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox6;
        private GMare.Controls.TextBoxEx tb_Name;
        private System.Windows.Forms.GroupBox groupBox5;
        private GMare.Controls.NumericUpDownEx nud_OffsetY;
        private GMare.Controls.NumericUpDownEx nud_OffsetX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private GMare.Controls.NumericUpDownEx nud_SeperationY;
        private GMare.Controls.NumericUpDownEx nud_SeperationX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private GMare.Controls.NumericUpDownEx nud_Rows;
        private GMare.Controls.NumericUpDownEx nud_Columns;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private GMare.Controls.ImagePanel pnl_Image;
        private Controls.ZoomToolStripButton tsb_Zoom;
    }
}