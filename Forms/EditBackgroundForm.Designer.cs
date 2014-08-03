namespace GMare.Forms
{
    partial class EditBackgroundForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditBackgroundForm));
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.tsslWidth = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslHeight = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslColor = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslTransparentColor = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTileHeight = new System.Windows.Forms.Label();
            this.lblTileWidth = new System.Windows.Forms.Label();
            this.lblOffsetY = new System.Windows.Forms.Label();
            this.lblOffsetX = new System.Windows.Forms.Label();
            this.lblSeparationY = new System.Windows.Forms.Label();
            this.lblSeparationX = new System.Windows.Forms.Label();
            this.pnlImage = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCellBox();
            this.grpTileSize = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.nudTileY = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.nudTileX = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.grpTileOffset = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.nudOffsetY = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.nudOffsetX = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.grpTileSeparation = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.nudSeperationY = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.nudSeperationX = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.butOk = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butCancel = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butImage = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butSetColorKey = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butShowGrid = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.lblMagnify = new System.Windows.Forms.Label();
            this.pnlMagnify = new System.Windows.Forms.Panel();
            this.trkMagnify = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTrackBar();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox();
            this.ssMain.SuspendLayout();
            this.grpTileSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTileY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTileX)).BeginInit();
            this.grpTileOffset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetX)).BeginInit();
            this.grpTileSeparation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeperationY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeperationX)).BeginInit();
            this.SuspendLayout();
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslWidth,
            this.tsslHeight,
            this.tsslColor,
            this.tsslTransparentColor});
            this.ssMain.Location = new System.Drawing.Point(0, 441);
            this.ssMain.Name = "ssMain";
            this.ssMain.ShowItemToolTips = true;
            this.ssMain.Size = new System.Drawing.Size(448, 24);
            this.ssMain.TabIndex = 14;
            this.ssMain.Text = "statusStrip1";
            // 
            // tsslWidth
            // 
            this.tsslWidth.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsslWidth.Name = "tsslWidth";
            this.tsslWidth.Size = new System.Drawing.Size(91, 19);
            this.tsslWidth.Text = "Image Width: 0";
            // 
            // tsslHeight
            // 
            this.tsslHeight.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsslHeight.Name = "tsslHeight";
            this.tsslHeight.Size = new System.Drawing.Size(95, 19);
            this.tsslHeight.Text = "Image Height: 0";
            // 
            // tsslColor
            // 
            this.tsslColor.Name = "tsslColor";
            this.tsslColor.Size = new System.Drawing.Size(105, 19);
            this.tsslColor.Text = "Transparent Color:";
            // 
            // tsslTransparentColor
            // 
            this.tsslTransparentColor.AutoSize = false;
            this.tsslTransparentColor.BackColor = System.Drawing.Color.Transparent;
            this.tsslTransparentColor.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslTransparentColor.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tsslTransparentColor.Name = "tsslTransparentColor";
            this.tsslTransparentColor.Size = new System.Drawing.Size(17, 18);
            // 
            // lblTileHeight
            // 
            this.lblTileHeight.AutoSize = true;
            this.lblTileHeight.Location = new System.Drawing.Point(12, 60);
            this.lblTileHeight.Name = "lblTileHeight";
            this.lblTileHeight.Size = new System.Drawing.Size(41, 13);
            this.lblTileHeight.TabIndex = 2;
            this.lblTileHeight.Text = "Height:";
            // 
            // lblTileWidth
            // 
            this.lblTileWidth.AutoSize = true;
            this.lblTileWidth.Location = new System.Drawing.Point(12, 36);
            this.lblTileWidth.Name = "lblTileWidth";
            this.lblTileWidth.Size = new System.Drawing.Size(38, 13);
            this.lblTileWidth.TabIndex = 0;
            this.lblTileWidth.Text = "Width:";
            // 
            // lblOffsetY
            // 
            this.lblOffsetY.AutoSize = true;
            this.lblOffsetY.Location = new System.Drawing.Point(12, 60);
            this.lblOffsetY.Name = "lblOffsetY";
            this.lblOffsetY.Size = new System.Drawing.Size(45, 13);
            this.lblOffsetY.TabIndex = 2;
            this.lblOffsetY.Text = "Vertical:";
            // 
            // lblOffsetX
            // 
            this.lblOffsetX.AutoSize = true;
            this.lblOffsetX.Location = new System.Drawing.Point(12, 36);
            this.lblOffsetX.Name = "lblOffsetX";
            this.lblOffsetX.Size = new System.Drawing.Size(57, 13);
            this.lblOffsetX.TabIndex = 0;
            this.lblOffsetX.Text = "Horizontal:";
            // 
            // lblSeparationY
            // 
            this.lblSeparationY.AutoSize = true;
            this.lblSeparationY.Location = new System.Drawing.Point(12, 60);
            this.lblSeparationY.Name = "lblSeparationY";
            this.lblSeparationY.Size = new System.Drawing.Size(45, 13);
            this.lblSeparationY.TabIndex = 2;
            this.lblSeparationY.Text = "Vertical:";
            // 
            // lblSeparationX
            // 
            this.lblSeparationX.AutoSize = true;
            this.lblSeparationX.Location = new System.Drawing.Point(12, 36);
            this.lblSeparationX.Name = "lblSeparationX";
            this.lblSeparationX.Size = new System.Drawing.Size(57, 13);
            this.lblSeparationX.TabIndex = 0;
            this.lblSeparationX.Text = "Horizontal:";
            // 
            // pnlImage
            // 
            this.pnlImage.AutoScroll = true;
            this.pnlImage.AutoScrollMinSize = new System.Drawing.Size(432, 280);
            this.pnlImage.BackColor = System.Drawing.Color.White;
            this.pnlImage.Blink = false;
            this.pnlImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlImage.CellCount = 1;
            this.pnlImage.CellEditMode = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCellBox.EditModeType.Auto;
            this.pnlImage.CellHeight = 16;
            this.pnlImage.CellOffsetX = 0;
            this.pnlImage.CellOffsetY = 0;
            this.pnlImage.CellPoint = new System.Drawing.Point(0, 0);
            this.pnlImage.CellSeperationX = 0;
            this.pnlImage.CellSeperationY = 0;
            this.pnlImage.CellSize = new System.Drawing.Size(16, 16);
            this.pnlImage.CellsPerRow = 1;
            this.pnlImage.CellWidth = 16;
            this.pnlImage.CheckerColor = System.Drawing.Color.Silver;
            this.pnlImage.CheckerSize = new System.Drawing.Size(8, 8);
            this.pnlImage.ColorKey = System.Drawing.Color.Black;
            this.pnlImage.Image = null;
            this.pnlImage.ImageScale = 1;
            this.pnlImage.Location = new System.Drawing.Point(6, 124);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.SetKey = false;
            this.pnlImage.ShowCells = true;
            this.pnlImage.Size = new System.Drawing.Size(436, 284);
            this.pnlImage.SnapSize = new System.Drawing.Size(16, 16);
            this.pnlImage.TabIndex = 11;
            this.pnlImage.Title = "Background Image";
            this.pnlImage.ToolTipText = "";
            this.pnlImage.ToolTipTitle = "";
            this.pnlImage.UseCheckerBoard = true;
            this.pnlImage.Zoom = 1F;
            // 
            // grpTileSize
            // 
            this.grpTileSize.BackColor = System.Drawing.Color.Transparent;
            this.grpTileSize.Controls.Add(this.nudTileY);
            this.grpTileSize.Controls.Add(this.nudTileX);
            this.grpTileSize.Controls.Add(this.lblTileWidth);
            this.grpTileSize.Controls.Add(this.lblTileHeight);
            this.grpTileSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTileSize.Location = new System.Drawing.Point(4, 32);
            this.grpTileSize.Name = "grpTileSize";
            this.grpTileSize.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpTileSize.Size = new System.Drawing.Size(144, 88);
            this.grpTileSize.TabIndex = 8;
            this.grpTileSize.TabStop = false;
            this.grpTileSize.Text = "Tile Size";
            this.grpTileSize.TextBarHeight = 24;
            // 
            // nudTileY
            // 
            this.nudTileY.IgnoreHeight = true;
            this.nudTileY.Location = new System.Drawing.Point(84, 56);
            this.nudTileY.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nudTileY.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudTileY.Name = "nudTileY";
            this.nudTileY.Size = new System.Drawing.Size(48, 20);
            this.nudTileY.TabIndex = 3;
            this.nudTileY.ToolTipText = "The height of a single tile";
            this.nudTileY.ToolTipTitle = "Tile Height";
            this.nudTileY.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudTileY.ValueChanged += new System.EventHandler(this.nudTileSize_ValueChanged);
            // 
            // nudTileX
            // 
            this.nudTileX.IgnoreHeight = true;
            this.nudTileX.Location = new System.Drawing.Point(84, 32);
            this.nudTileX.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nudTileX.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudTileX.Name = "nudTileX";
            this.nudTileX.Size = new System.Drawing.Size(48, 20);
            this.nudTileX.TabIndex = 1;
            this.nudTileX.ToolTipText = "The width of a single tile";
            this.nudTileX.ToolTipTitle = "Tile Width";
            this.nudTileX.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudTileX.ValueChanged += new System.EventHandler(this.nudTileSize_ValueChanged);
            // 
            // grpTileOffset
            // 
            this.grpTileOffset.BackColor = System.Drawing.Color.Transparent;
            this.grpTileOffset.Controls.Add(this.nudOffsetY);
            this.grpTileOffset.Controls.Add(this.nudOffsetX);
            this.grpTileOffset.Controls.Add(this.lblOffsetY);
            this.grpTileOffset.Controls.Add(this.lblOffsetX);
            this.grpTileOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTileOffset.Location = new System.Drawing.Point(152, 32);
            this.grpTileOffset.Name = "grpTileOffset";
            this.grpTileOffset.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpTileOffset.Size = new System.Drawing.Size(144, 88);
            this.grpTileOffset.TabIndex = 9;
            this.grpTileOffset.TabStop = false;
            this.grpTileOffset.Text = "Tile Offset";
            this.grpTileOffset.TextBarHeight = 24;
            // 
            // nudOffsetY
            // 
            this.nudOffsetY.IgnoreHeight = true;
            this.nudOffsetY.Location = new System.Drawing.Point(84, 56);
            this.nudOffsetY.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudOffsetY.Name = "nudOffsetY";
            this.nudOffsetY.Size = new System.Drawing.Size(48, 20);
            this.nudOffsetY.TabIndex = 3;
            this.nudOffsetY.ToolTipText = "The vertical tile offset";
            this.nudOffsetY.ToolTipTitle = "Vertical Tile Offset";
            this.nudOffsetY.ValueChanged += new System.EventHandler(this.nudOffset_ValueChanged);
            // 
            // nudOffsetX
            // 
            this.nudOffsetX.IgnoreHeight = true;
            this.nudOffsetX.Location = new System.Drawing.Point(84, 32);
            this.nudOffsetX.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudOffsetX.Name = "nudOffsetX";
            this.nudOffsetX.Size = new System.Drawing.Size(48, 20);
            this.nudOffsetX.TabIndex = 1;
            this.nudOffsetX.ToolTipText = "The horizontal tile offset";
            this.nudOffsetX.ToolTipTitle = "Horizontal Tile Offset";
            this.nudOffsetX.ValueChanged += new System.EventHandler(this.nudOffset_ValueChanged);
            // 
            // grpTileSeparation
            // 
            this.grpTileSeparation.BackColor = System.Drawing.Color.Transparent;
            this.grpTileSeparation.Controls.Add(this.nudSeperationY);
            this.grpTileSeparation.Controls.Add(this.nudSeperationX);
            this.grpTileSeparation.Controls.Add(this.lblSeparationY);
            this.grpTileSeparation.Controls.Add(this.lblSeparationX);
            this.grpTileSeparation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTileSeparation.Location = new System.Drawing.Point(300, 32);
            this.grpTileSeparation.Name = "grpTileSeparation";
            this.grpTileSeparation.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpTileSeparation.Size = new System.Drawing.Size(144, 88);
            this.grpTileSeparation.TabIndex = 10;
            this.grpTileSeparation.TabStop = false;
            this.grpTileSeparation.Text = "Tile Separation";
            this.grpTileSeparation.TextBarHeight = 24;
            // 
            // nudSeperationY
            // 
            this.nudSeperationY.IgnoreHeight = true;
            this.nudSeperationY.Location = new System.Drawing.Point(84, 56);
            this.nudSeperationY.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudSeperationY.Name = "nudSeperationY";
            this.nudSeperationY.Size = new System.Drawing.Size(48, 20);
            this.nudSeperationY.TabIndex = 3;
            this.nudSeperationY.ToolTipText = "Separation between tiles vertically";
            this.nudSeperationY.ToolTipTitle = "Vertical Tile Separation";
            this.nudSeperationY.ValueChanged += new System.EventHandler(this.nudSeperation_ValueChanged);
            // 
            // nudSeperationX
            // 
            this.nudSeperationX.IgnoreHeight = true;
            this.nudSeperationX.Location = new System.Drawing.Point(84, 32);
            this.nudSeperationX.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudSeperationX.Name = "nudSeperationX";
            this.nudSeperationX.Size = new System.Drawing.Size(48, 20);
            this.nudSeperationX.TabIndex = 1;
            this.nudSeperationX.ToolTipText = "Separation between tiles horizontally";
            this.nudSeperationX.ToolTipTitle = "Horizontal Tile Separation";
            this.nudSeperationX.ValueChanged += new System.EventHandler(this.nudSeperation_ValueChanged);
            // 
            // butOk
            // 
            this.butOk.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butOk.Checked = false;
            this.butOk.FlatStyled = false;
            this.butOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butOk.ImageXOffset = 0;
            this.butOk.ImageYOffset = 0;
            this.butOk.Location = new System.Drawing.Point(284, 412);
            this.butOk.Name = "butOk";
            this.butOk.PushButtonImage = null;
            this.butOk.Size = new System.Drawing.Size(76, 24);
            this.butOk.TabIndex = 12;
            this.butOk.Text = "OK";
            this.butOk.TextXOffset = 0;
            this.butOk.TextYOffset = 0;
            this.butOk.ToolTipText = "";
            this.butOk.ToolTipTitle = "";
            this.butOk.UseDropShadow = true;
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butCancel.Checked = false;
            this.butCancel.FlatStyled = false;
            this.butCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCancel.ImageXOffset = 0;
            this.butCancel.ImageYOffset = 0;
            this.butCancel.Location = new System.Drawing.Point(364, 412);
            this.butCancel.Name = "butCancel";
            this.butCancel.PushButtonImage = null;
            this.butCancel.Size = new System.Drawing.Size(76, 24);
            this.butCancel.TabIndex = 13;
            this.butCancel.Text = "Cancel";
            this.butCancel.TextXOffset = 0;
            this.butCancel.TextYOffset = 0;
            this.butCancel.ToolTipText = "";
            this.butCancel.ToolTipTitle = "";
            this.butCancel.UseDropShadow = true;
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butImage
            // 
            this.butImage.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butImage.Checked = false;
            this.butImage.FlatStyled = false;
            this.butImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butImage.Image = global::GMare.Properties.Resources.folder_image;
            this.butImage.ImageXOffset = -1;
            this.butImage.ImageYOffset = 0;
            this.butImage.Location = new System.Drawing.Point(8, 6);
            this.butImage.Name = "butImage";
            this.butImage.PushButtonImage = null;
            this.butImage.Size = new System.Drawing.Size(24, 24);
            this.butImage.TabIndex = 0;
            this.butImage.TextXOffset = 0;
            this.butImage.TextYOffset = 0;
            this.butImage.ToolTipText = "Get an image from disk, or import a \r\nbackground from a Game Maker project";
            this.butImage.ToolTipTitle = "Get Background";
            this.butImage.UseDropShadow = true;
            this.butImage.UseVisualStyleBackColor = true;
            this.butImage.Click += new System.EventHandler(this.butImage_Click);
            // 
            // butSetColorKey
            // 
            this.butSetColorKey.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.PushButton;
            this.butSetColorKey.Checked = false;
            this.butSetColorKey.FlatStyled = false;
            this.butSetColorKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSetColorKey.Image = global::GMare.Properties.Resources.point;
            this.butSetColorKey.ImageXOffset = 0;
            this.butSetColorKey.ImageYOffset = 0;
            this.butSetColorKey.Location = new System.Drawing.Point(32, 6);
            this.butSetColorKey.Name = "butSetColorKey";
            this.butSetColorKey.PushButtonImage = null;
            this.butSetColorKey.Size = new System.Drawing.Size(24, 24);
            this.butSetColorKey.TabIndex = 1;
            this.butSetColorKey.TextXOffset = 0;
            this.butSetColorKey.TextYOffset = 0;
            this.butSetColorKey.ToolTipText = "Use the bottom left pixel of the image as the transparent color";
            this.butSetColorKey.ToolTipTitle = "Use Transparent Color";
            this.butSetColorKey.UseDropShadow = true;
            this.butSetColorKey.UseVisualStyleBackColor = true;
            this.butSetColorKey.CheckChanged += new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.CheckChangedEventHandler(this.butSetColorKey_CheckedChanged);
            // 
            // butShowGrid
            // 
            this.butShowGrid.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.PushButton;
            this.butShowGrid.Checked = true;
            this.butShowGrid.FlatStyled = false;
            this.butShowGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butShowGrid.Image = ((System.Drawing.Image)(resources.GetObject("butShowGrid.Image")));
            this.butShowGrid.ImageXOffset = 1;
            this.butShowGrid.ImageYOffset = 0;
            this.butShowGrid.Location = new System.Drawing.Point(56, 6);
            this.butShowGrid.Name = "butShowGrid";
            this.butShowGrid.PushButtonImage = null;
            this.butShowGrid.Size = new System.Drawing.Size(25, 24);
            this.butShowGrid.TabIndex = 2;
            this.butShowGrid.TextXOffset = 0;
            this.butShowGrid.TextYOffset = 0;
            this.butShowGrid.ToolTipText = "Show or hide the cell grid";
            this.butShowGrid.ToolTipTitle = "Show/Hide Grid";
            this.butShowGrid.UseDropShadow = true;
            this.butShowGrid.UseVisualStyleBackColor = true;
            this.butShowGrid.CheckChanged += new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.CheckChangedEventHandler(this.butShowGrid_CheckedChanged);
            // 
            // lblMagnify
            // 
            this.lblMagnify.AutoSize = true;
            this.lblMagnify.Location = new System.Drawing.Point(412, 12);
            this.lblMagnify.Name = "lblMagnify";
            this.lblMagnify.Size = new System.Drawing.Size(33, 13);
            this.lblMagnify.TabIndex = 7;
            this.lblMagnify.Text = "100%";
            // 
            // pnlMagnify
            // 
            this.pnlMagnify.BackgroundImage = global::GMare.Properties.Resources.magnifier;
            this.pnlMagnify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlMagnify.Location = new System.Drawing.Point(296, 6);
            this.pnlMagnify.Name = "pnlMagnify";
            this.pnlMagnify.Size = new System.Drawing.Size(24, 24);
            this.pnlMagnify.TabIndex = 5;
            // 
            // trkMagnify
            // 
            this.trkMagnify.BackColor = System.Drawing.Color.Transparent;
            this.trkMagnify.LargeChange = 1;
            this.trkMagnify.Location = new System.Drawing.Point(316, 8);
            this.trkMagnify.Maximum = 5;
            this.trkMagnify.Minimum = 1;
            this.trkMagnify.Name = "trkMagnify";
            this.trkMagnify.Size = new System.Drawing.Size(104, 20);
            this.trkMagnify.TabIndex = 6;
            this.trkMagnify.TabStop = true;
            this.trkMagnify.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkMagnify.ToolTipText = "Slide to set the magnification level of the graphic";
            this.trkMagnify.ToolTipTitle = "Image Magnification";
            this.trkMagnify.Value = 1;
            this.trkMagnify.ValueChanged += new System.EventHandler(this.trkMagnify_ValueChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(84, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(124, 8);
            this.txtName.MaxLength = 255;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(168, 20);
            this.txtName.TabIndex = 4;
            this.txtName.ToolTipText = "The name of the background";
            this.txtName.ToolTipTitle = "Background Name";
            // 
            // EditBackgroundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 465);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblMagnify);
            this.Controls.Add(this.pnlMagnify);
            this.Controls.Add(this.trkMagnify);
            this.Controls.Add(this.butShowGrid);
            this.Controls.Add(this.butSetColorKey);
            this.Controls.Add(this.butImage);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.grpTileSeparation);
            this.Controls.Add(this.grpTileOffset);
            this.Controls.Add(this.grpTileSize);
            this.Controls.Add(this.pnlImage);
            this.Controls.Add(this.ssMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditBackgroundForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Background";
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.grpTileSize.ResumeLayout(false);
            this.grpTileSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTileY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTileX)).EndInit();
            this.grpTileOffset.ResumeLayout(false);
            this.grpTileOffset.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetX)).EndInit();
            this.grpTileSeparation.ResumeLayout(false);
            this.grpTileSeparation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeperationY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeperationX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel tsslWidth;
        private System.Windows.Forms.ToolStripStatusLabel tsslHeight;
        private System.Windows.Forms.ToolStripStatusLabel tsslColor;
        private System.Windows.Forms.ToolStripStatusLabel tsslTransparentColor;
        private System.Windows.Forms.Label lblTileHeight;
        private System.Windows.Forms.Label lblTileWidth;
        private System.Windows.Forms.Label lblOffsetY;
        private System.Windows.Forms.Label lblOffsetX;
        private System.Windows.Forms.Label lblSeparationY;
        private System.Windows.Forms.Label lblSeparationX;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCellBox pnlImage;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpTileSize;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudTileY;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudTileX;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpTileOffset;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpTileSeparation;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudOffsetY;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudOffsetX;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudSeperationY;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudSeperationX;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butOk;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butCancel;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butImage;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butSetColorKey;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butShowGrid;
        private System.Windows.Forms.Label lblMagnify;
        private System.Windows.Forms.Panel pnlMagnify;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTrackBar trkMagnify;
        private System.Windows.Forms.Label lblName;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox txtName;
    }
}