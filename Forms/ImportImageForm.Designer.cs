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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportImageForm));
            this.tipMain = new System.Windows.Forms.ToolTip(this.components);
            this.pnlImage = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxPanel();
            this.lblSeparationY = new System.Windows.Forms.Label();
            this.lblSeparationX = new System.Windows.Forms.Label();
            this.lblTileY = new System.Windows.Forms.Label();
            this.lblTileX = new System.Windows.Forms.Label();
            this.lblOffsetY = new System.Windows.Forms.Label();
            this.lblOffsetX = new System.Windows.Forms.Label();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTileCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTilesetSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.barProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.bgwCompile = new System.ComponentModel.BackgroundWorker();
            this.grpTileSize = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.nudTileY = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.nudTileX = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.grpTileOffset = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.nudOffsetY = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.nudOffsetX = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.grpSeperation = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.nudSeperationY = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.nudSeperationX = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.butCancel = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butOk = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butCompile = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butCompileCancel = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butUndo = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butRedo = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butGrid = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.txtName = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblColumns = new System.Windows.Forms.Label();
            this.nudColumns = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.lblMagnify = new System.Windows.Forms.Label();
            this.pnlMagnify = new System.Windows.Forms.Panel();
            this.trkMagnify = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTrackBar();
            this.tabMain = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabControl();
            this.tabTiles = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabPage();
            this.pnlTileset = new GMare.Controls.GMareTileEditor();
            this.tabImage = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabPage();
            this.ssMain.SuspendLayout();
            this.grpTileSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTileY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTileX)).BeginInit();
            this.grpTileOffset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetX)).BeginInit();
            this.grpSeperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeperationY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeperationX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColumns)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabTiles.SuspendLayout();
            this.tabImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlImage
            // 
            this.pnlImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlImage.AutoScroll = true;
            this.pnlImage.BackColor = System.Drawing.SystemColors.Window;
            this.pnlImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlImage.CheckerColor = System.Drawing.Color.Silver;
            this.pnlImage.CheckerSize = new System.Drawing.Size(16, 16);
            this.pnlImage.Location = new System.Drawing.Point(8, 8);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(438, 316);
            this.pnlImage.TabIndex = 15;
            this.pnlImage.Title = "";
            this.pnlImage.ToolTipText = "";
            this.pnlImage.ToolTipTitle = "";
            this.pnlImage.UseCheckerBoard = true;
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
            // lblTileY
            // 
            this.lblTileY.AutoSize = true;
            this.lblTileY.Location = new System.Drawing.Point(12, 60);
            this.lblTileY.Name = "lblTileY";
            this.lblTileY.Size = new System.Drawing.Size(41, 13);
            this.lblTileY.TabIndex = 2;
            this.lblTileY.Text = "Height:";
            // 
            // lblTileX
            // 
            this.lblTileX.AutoSize = true;
            this.lblTileX.Location = new System.Drawing.Point(12, 36);
            this.lblTileX.Name = "lblTileX";
            this.lblTileX.Size = new System.Drawing.Size(38, 13);
            this.lblTileX.TabIndex = 0;
            this.lblTileX.Text = "Width:";
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
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblTileCount,
            this.lblTilesetSize,
            this.lblProgress,
            this.barProgress});
            this.ssMain.Location = new System.Drawing.Point(0, 522);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(474, 24);
            this.ssMain.TabIndex = 18;
            this.ssMain.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(81, 19);
            this.lblStatus.Text = "Status: Ready";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTileCount
            // 
            this.lblTileCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblTileCount.Name = "lblTileCount";
            this.lblTileCount.Size = new System.Drawing.Size(78, 19);
            this.lblTileCount.Text = "Tile Count: 0";
            this.lblTileCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTilesetSize
            // 
            this.lblTilesetSize.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblTilesetSize.Name = "lblTilesetSize";
            this.lblTilesetSize.Size = new System.Drawing.Size(59, 19);
            this.lblTilesetSize.Text = "Size: N/A";
            this.lblTilesetSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProgress
            // 
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(139, 19);
            this.lblProgress.Spring = true;
            this.lblProgress.Text = "Progress:";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // barProgress
            // 
            this.barProgress.Name = "barProgress";
            this.barProgress.Size = new System.Drawing.Size(100, 18);
            // 
            // bgwCompile
            // 
            this.bgwCompile.WorkerReportsProgress = true;
            this.bgwCompile.WorkerSupportsCancellation = true;
            this.bgwCompile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCompile_DoWork);
            this.bgwCompile.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwCompile_ProgressChanged);
            this.bgwCompile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCompile_RunWorkerCompleted);
            // 
            // grpTileSize
            // 
            this.grpTileSize.BackColor = System.Drawing.Color.Transparent;
            this.grpTileSize.Controls.Add(this.nudTileY);
            this.grpTileSize.Controls.Add(this.nudTileX);
            this.grpTileSize.Controls.Add(this.lblTileX);
            this.grpTileSize.Controls.Add(this.lblTileY);
            this.grpTileSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTileSize.Location = new System.Drawing.Point(4, 32);
            this.grpTileSize.Name = "grpTileSize";
            this.grpTileSize.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpTileSize.Size = new System.Drawing.Size(152, 88);
            this.grpTileSize.TabIndex = 9;
            this.grpTileSize.TabStop = false;
            this.grpTileSize.Text = "Tile Size";
            this.grpTileSize.TextBarHeight = 24;
            // 
            // nudTileY
            // 
            this.nudTileY.IgnoreHeight = true;
            this.nudTileY.Location = new System.Drawing.Point(88, 56);
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
            // 
            // nudTileX
            // 
            this.nudTileX.IgnoreHeight = true;
            this.nudTileX.Location = new System.Drawing.Point(88, 32);
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
            // 
            // grpTileOffset
            // 
            this.grpTileOffset.BackColor = System.Drawing.Color.Transparent;
            this.grpTileOffset.Controls.Add(this.nudOffsetY);
            this.grpTileOffset.Controls.Add(this.nudOffsetX);
            this.grpTileOffset.Controls.Add(this.lblOffsetX);
            this.grpTileOffset.Controls.Add(this.lblOffsetY);
            this.grpTileOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTileOffset.Location = new System.Drawing.Point(160, 32);
            this.grpTileOffset.Name = "grpTileOffset";
            this.grpTileOffset.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpTileOffset.Size = new System.Drawing.Size(152, 88);
            this.grpTileOffset.TabIndex = 10;
            this.grpTileOffset.TabStop = false;
            this.grpTileOffset.Text = "Tile Offset";
            this.grpTileOffset.TextBarHeight = 24;
            // 
            // nudOffsetY
            // 
            this.nudOffsetY.IgnoreHeight = true;
            this.nudOffsetY.Location = new System.Drawing.Point(88, 56);
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
            // 
            // nudOffsetX
            // 
            this.nudOffsetX.IgnoreHeight = true;
            this.nudOffsetX.Location = new System.Drawing.Point(88, 32);
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
            // 
            // grpSeperation
            // 
            this.grpSeperation.BackColor = System.Drawing.Color.Transparent;
            this.grpSeperation.Controls.Add(this.nudSeperationY);
            this.grpSeperation.Controls.Add(this.nudSeperationX);
            this.grpSeperation.Controls.Add(this.lblSeparationX);
            this.grpSeperation.Controls.Add(this.lblSeparationY);
            this.grpSeperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSeperation.Location = new System.Drawing.Point(316, 32);
            this.grpSeperation.Name = "grpSeperation";
            this.grpSeperation.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpSeperation.Size = new System.Drawing.Size(152, 88);
            this.grpSeperation.TabIndex = 11;
            this.grpSeperation.TabStop = false;
            this.grpSeperation.Text = "Tile Separation";
            this.grpSeperation.TextBarHeight = 24;
            // 
            // nudSeperationY
            // 
            this.nudSeperationY.IgnoreHeight = true;
            this.nudSeperationY.Location = new System.Drawing.Point(88, 56);
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
            // 
            // nudSeperationX
            // 
            this.nudSeperationX.IgnoreHeight = true;
            this.nudSeperationX.Location = new System.Drawing.Point(88, 32);
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
            // 
            // butCancel
            // 
            this.butCancel.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butCancel.Checked = false;
            this.butCancel.FlatStyled = false;
            this.butCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCancel.ImageXOffset = 0;
            this.butCancel.ImageYOffset = 0;
            this.butCancel.Location = new System.Drawing.Point(392, 490);
            this.butCancel.Name = "butCancel";
            this.butCancel.PushButtonImage = null;
            this.butCancel.Size = new System.Drawing.Size(76, 24);
            this.butCancel.TabIndex = 17;
            this.butCancel.Text = "Cancel";
            this.butCancel.TextXOffset = 0;
            this.butCancel.TextYOffset = 0;
            this.butCancel.ToolTipText = "";
            this.butCancel.ToolTipTitle = "";
            this.butCancel.UseDropShadow = true;
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOk
            // 
            this.butOk.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butOk.Checked = false;
            this.butOk.FlatStyled = false;
            this.butOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butOk.ImageXOffset = 0;
            this.butOk.ImageYOffset = 0;
            this.butOk.Location = new System.Drawing.Point(312, 490);
            this.butOk.Name = "butOk";
            this.butOk.PushButtonImage = null;
            this.butOk.Size = new System.Drawing.Size(76, 24);
            this.butOk.TabIndex = 16;
            this.butOk.Text = "OK";
            this.butOk.TextXOffset = 0;
            this.butOk.TextYOffset = 0;
            this.butOk.ToolTipText = "";
            this.butOk.ToolTipTitle = "";
            this.butOk.UseDropShadow = true;
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCompile
            // 
            this.butCompile.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butCompile.Checked = false;
            this.butCompile.FlatStyled = false;
            this.butCompile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCompile.Image = global::GMare.Properties.Resources.room;
            this.butCompile.ImageXOffset = 1;
            this.butCompile.ImageYOffset = 0;
            this.butCompile.Location = new System.Drawing.Point(8, 4);
            this.butCompile.Name = "butCompile";
            this.butCompile.PushButtonImage = null;
            this.butCompile.Size = new System.Drawing.Size(23, 24);
            this.butCompile.TabIndex = 0;
            this.butCompile.TextXOffset = 0;
            this.butCompile.TextYOffset = 0;
            this.butCompile.ToolTipText = "Compile tiles from source image";
            this.butCompile.ToolTipTitle = "Compile Tiles (C)";
            this.butCompile.UseDropShadow = true;
            this.butCompile.UseVisualStyleBackColor = true;
            this.butCompile.Click += new System.EventHandler(this.butCompile_Click);
            // 
            // butCompileCancel
            // 
            this.butCompileCancel.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butCompileCancel.Checked = false;
            this.butCompileCancel.FlatStyled = false;
            this.butCompileCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCompileCancel.Image = global::GMare.Properties.Resources.slash;
            this.butCompileCancel.ImageXOffset = 0;
            this.butCompileCancel.ImageYOffset = 0;
            this.butCompileCancel.Location = new System.Drawing.Point(32, 4);
            this.butCompileCancel.Name = "butCompileCancel";
            this.butCompileCancel.PushButtonImage = null;
            this.butCompileCancel.Size = new System.Drawing.Size(24, 24);
            this.butCompileCancel.TabIndex = 1;
            this.butCompileCancel.TextXOffset = 0;
            this.butCompileCancel.TextYOffset = 0;
            this.butCompileCancel.ToolTipText = "Cancel tile compile";
            this.butCompileCancel.ToolTipTitle = "Cancel Compile";
            this.butCompileCancel.UseDropShadow = true;
            this.butCompileCancel.UseVisualStyleBackColor = true;
            this.butCompileCancel.Click += new System.EventHandler(this.butCancelCompile_Click);
            // 
            // butUndo
            // 
            this.butUndo.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butUndo.Checked = false;
            this.butUndo.FlatStyled = false;
            this.butUndo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butUndo.Image = global::GMare.Properties.Resources.arrow_undo;
            this.butUndo.ImageXOffset = 0;
            this.butUndo.ImageYOffset = 0;
            this.butUndo.Location = new System.Drawing.Point(56, 4);
            this.butUndo.Name = "butUndo";
            this.butUndo.PushButtonImage = null;
            this.butUndo.Size = new System.Drawing.Size(24, 24);
            this.butUndo.TabIndex = 2;
            this.butUndo.TextXOffset = 0;
            this.butUndo.TextYOffset = 0;
            this.butUndo.ToolTipText = "Undo tile edit";
            this.butUndo.ToolTipTitle = "Undo (Ctrl+Z)";
            this.butUndo.UseDropShadow = true;
            this.butUndo.UseVisualStyleBackColor = true;
            this.butUndo.Click += new System.EventHandler(this.butUndo_Click);
            // 
            // butRedo
            // 
            this.butRedo.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butRedo.Checked = false;
            this.butRedo.FlatStyled = false;
            this.butRedo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRedo.Image = global::GMare.Properties.Resources.arrow_redo;
            this.butRedo.ImageXOffset = 0;
            this.butRedo.ImageYOffset = 0;
            this.butRedo.Location = new System.Drawing.Point(80, 4);
            this.butRedo.Name = "butRedo";
            this.butRedo.PushButtonImage = null;
            this.butRedo.Size = new System.Drawing.Size(24, 24);
            this.butRedo.TabIndex = 3;
            this.butRedo.TextXOffset = 0;
            this.butRedo.TextYOffset = 0;
            this.butRedo.ToolTipText = "Redo tile edit";
            this.butRedo.ToolTipTitle = "Redo (Ctrl+Y)";
            this.butRedo.UseDropShadow = true;
            this.butRedo.UseVisualStyleBackColor = true;
            this.butRedo.Click += new System.EventHandler(this.butRedo_Click);
            // 
            // butGrid
            // 
            this.butGrid.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.PushButton;
            this.butGrid.Checked = true;
            this.butGrid.FlatStyled = false;
            this.butGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butGrid.Image = ((System.Drawing.Image)(resources.GetObject("butGrid.Image")));
            this.butGrid.ImageXOffset = 0;
            this.butGrid.ImageYOffset = 0;
            this.butGrid.Location = new System.Drawing.Point(104, 4);
            this.butGrid.Name = "butGrid";
            this.butGrid.PushButtonImage = null;
            this.butGrid.Size = new System.Drawing.Size(24, 24);
            this.butGrid.TabIndex = 4;
            this.butGrid.TextXOffset = 0;
            this.butGrid.TextYOffset = 0;
            this.butGrid.ToolTipText = "Show or hide tile grid";
            this.butGrid.ToolTipTitle = "Show/Hide Grid (G)";
            this.butGrid.UseDropShadow = true;
            this.butGrid.UseVisualStyleBackColor = true;
            this.butGrid.CheckChanged += new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.CheckChangedEventHandler(this.butShowGrid_CheckChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(204, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(104, 20);
            this.txtName.TabIndex = 6;
            this.txtName.ToolTipText = "";
            this.txtName.ToolTipTitle = "";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(132, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(69, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Room Name:";
            // 
            // lblColumns
            // 
            this.lblColumns.AutoSize = true;
            this.lblColumns.Location = new System.Drawing.Point(312, 10);
            this.lblColumns.Name = "lblColumns";
            this.lblColumns.Size = new System.Drawing.Size(50, 13);
            this.lblColumns.TabIndex = 7;
            this.lblColumns.Text = "Columns:";
            // 
            // nudColumns
            // 
            this.nudColumns.IgnoreHeight = true;
            this.nudColumns.Location = new System.Drawing.Point(364, 7);
            this.nudColumns.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudColumns.Name = "nudColumns";
            this.nudColumns.Size = new System.Drawing.Size(56, 20);
            this.nudColumns.TabIndex = 8;
            this.nudColumns.ToolTipText = "Width of the background in tiles";
            this.nudColumns.ToolTipTitle = "Background Column Amount";
            this.nudColumns.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudColumns.ValueChanged += new System.EventHandler(this.nudColumns_ValueChanged);
            // 
            // lblMagnify
            // 
            this.lblMagnify.AutoSize = true;
            this.lblMagnify.Location = new System.Drawing.Point(124, 496);
            this.lblMagnify.Name = "lblMagnify";
            this.lblMagnify.Size = new System.Drawing.Size(33, 13);
            this.lblMagnify.TabIndex = 15;
            this.lblMagnify.Text = "100%";
            // 
            // pnlMagnify
            // 
            this.pnlMagnify.BackgroundImage = global::GMare.Properties.Resources.magnifier;
            this.pnlMagnify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlMagnify.Location = new System.Drawing.Point(8, 490);
            this.pnlMagnify.Name = "pnlMagnify";
            this.pnlMagnify.Size = new System.Drawing.Size(24, 24);
            this.pnlMagnify.TabIndex = 13;
            // 
            // trkMagnify
            // 
            this.trkMagnify.BackColor = System.Drawing.Color.Transparent;
            this.trkMagnify.LargeChange = 1;
            this.trkMagnify.Location = new System.Drawing.Point(28, 492);
            this.trkMagnify.Maximum = 5;
            this.trkMagnify.Minimum = 1;
            this.trkMagnify.Name = "trkMagnify";
            this.trkMagnify.Size = new System.Drawing.Size(104, 20);
            this.trkMagnify.TabIndex = 14;
            this.trkMagnify.TabStop = true;
            this.trkMagnify.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkMagnify.ToolTipText = "Slide to set the magnification level of the graphic";
            this.trkMagnify.ToolTipTitle = "Image Magnification";
            this.trkMagnify.Value = 1;
            this.trkMagnify.ValueChanged += new System.EventHandler(this.trkMagnify_ValueChanged);
            // 
            // tabMain
            // 
            this.tabMain.BackColor = System.Drawing.Color.Transparent;
            this.tabMain.Controls.Add(this.tabTiles);
            this.tabMain.Controls.Add(this.tabImage);
            this.tabMain.Location = new System.Drawing.Point(6, 124);
            this.tabMain.Name = "tabMain";
            this.tabMain.Scroll = false;
            this.tabMain.SelectedIndex = 0;
            this.tabMain.SelectedTab = this.tabTiles;
            this.tabMain.SelectTabMargin = 2;
            this.tabMain.Size = new System.Drawing.Size(462, 360);
            this.tabMain.TabDock = System.Windows.Forms.DockStyle.Top;
            this.tabMain.TabIndent = 8;
            this.tabMain.TabIndex = 12;
            // 
            // tabTiles
            // 
            this.tabTiles.Controls.Add(this.pnlTileset);
            this.tabTiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTiles.Location = new System.Drawing.Point(3, 24);
            this.tabTiles.Name = "tabTiles";
            this.tabTiles.Size = new System.Drawing.Size(456, 333);
            this.tabTiles.TabIndex = 0;
            this.tabTiles.Text = "Tile Editor";
            // 
            // pnlTileset
            // 
            this.pnlTileset.AllowDrop = true;
            this.pnlTileset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTileset.AutoScroll = true;
            this.pnlTileset.AutoScrollMinSize = new System.Drawing.Size(432, 312);
            this.pnlTileset.BackColor = System.Drawing.Color.White;
            this.pnlTileset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTileset.CanvasSize = new System.Drawing.Size(0, 0);
            this.pnlTileset.CheckerColor = System.Drawing.Color.Silver;
            this.pnlTileset.CheckerSize = new System.Drawing.Size(16, 16);
            this.pnlTileset.Columns = 16;
            this.pnlTileset.ImageScale = 1;
            this.pnlTileset.Location = new System.Drawing.Point(9, 8);
            this.pnlTileset.Name = "pnlTileset";
            this.pnlTileset.ShowGrid = true;
            this.pnlTileset.Size = new System.Drawing.Size(436, 316);
            this.pnlTileset.SnapSize = new System.Drawing.Size(8, 8);
            this.pnlTileset.TabIndex = 0;
            this.pnlTileset.Tiles = null;
            this.pnlTileset.Title = "Compiled Tiles Editor";
            this.pnlTileset.ToolTipText = "";
            this.pnlTileset.ToolTipTitle = "";
            this.pnlTileset.UseCheckerBoard = true;
            this.pnlTileset.Zoom = 1F;
            this.pnlTileset.PanelChanged += new GMare.Controls.GMareTileEditor.PanelChangedHandler(this.pnlTileset_PanelChanged);
            // 
            // tabImage
            // 
            this.tabImage.Controls.Add(this.pnlImage);
            this.tabImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabImage.Location = new System.Drawing.Point(3, 24);
            this.tabImage.Name = "tabImage";
            this.tabImage.Size = new System.Drawing.Size(456, 333);
            this.tabImage.TabIndex = 1;
            this.tabImage.Text = "Image";
            // 
            // ImportImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 546);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.lblMagnify);
            this.Controls.Add(this.pnlMagnify);
            this.Controls.Add(this.trkMagnify);
            this.Controls.Add(this.nudColumns);
            this.Controls.Add(this.lblColumns);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.butGrid);
            this.Controls.Add(this.butRedo);
            this.Controls.Add(this.butUndo);
            this.Controls.Add(this.butCompileCancel);
            this.Controls.Add(this.butCompile);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.grpSeperation);
            this.Controls.Add(this.grpTileOffset);
            this.Controls.Add(this.grpTileSize);
            this.Controls.Add(this.ssMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportImageForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import From Image File";
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
            this.grpSeperation.ResumeLayout(false);
            this.grpSeperation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeperationY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeperationX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColumns)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabTiles.ResumeLayout(false);
            this.tabImage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip tipMain;
        private System.Windows.Forms.Label lblTileY;
        private System.Windows.Forms.Label lblTileX;
        private System.Windows.Forms.Label lblOffsetY;
        private System.Windows.Forms.Label lblOffsetX;
        private System.Windows.Forms.Label lblSeparationY;
        private System.Windows.Forms.Label lblSeparationX;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxPanel pnlImage;
        private System.Windows.Forms.StatusStrip ssMain;
        private GMare.Controls.GMareTileEditor pnlTileset;
        private System.Windows.Forms.ToolStripStatusLabel lblTileCount;
        private System.Windows.Forms.ToolStripProgressBar barProgress;
        private System.Windows.Forms.ToolStripStatusLabel lblProgress;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.ComponentModel.BackgroundWorker bgwCompile;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpTileSize;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudTileY;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudTileX;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpTileOffset;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpSeperation;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudOffsetY;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudOffsetX;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudSeperationY;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudSeperationX;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butCancel;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butOk;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butCompile;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butCompileCancel;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butUndo;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butRedo;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butGrid;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblColumns;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudColumns;
        private System.Windows.Forms.Label lblMagnify;
        private System.Windows.Forms.Panel pnlMagnify;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTrackBar trkMagnify;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabControl tabMain;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabPage tabTiles;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabPage tabImage;
        private System.Windows.Forms.ToolStripStatusLabel lblTilesetSize;
    }
}