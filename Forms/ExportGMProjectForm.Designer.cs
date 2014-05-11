namespace GMare. Forms
{
    partial class ExportGMProjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportGMProjectForm));
            this.imgProjectTree = new System.Windows.Forms.ImageList(this.components);
            this.tipMain = new System.Windows.Forms.ToolTip(this.components);
            this.chkWriteTiles = new System.Windows.Forms.CheckBox();
            this.chkOptimizeTiles = new System.Windows.Forms.CheckBox();
            this.chkRefactorInstances = new System.Windows.Forms.CheckBox();
            this.chkRefactorTiles = new System.Windows.Forms.CheckBox();
            this.chkWriteInstances = new System.Windows.Forms.CheckBox();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.tssl_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.bwIO = new System.ComponentModel.BackgroundWorker();
            this.lblRoomName = new System.Windows.Forms.Label();
            this.txtName = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox();
            this.butCancel = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butExport = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.grpBackgrounds = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.lstBackgrounds = new GMare.Controls.GMareListbox();
            this.grpRooms = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.tvRooms = new System.Windows.Forms.TreeView();
            this.grpOptions = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.butViewOptimization = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.ssMain.SuspendLayout();
            this.grpBackgrounds.SuspendLayout();
            this.grpRooms.SuspendLayout();
            this.grpOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgProjectTree
            // 
            this.imgProjectTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgProjectTree.ImageStream")));
            this.imgProjectTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imgProjectTree.Images.SetKeyName(0, "folder.png");
            this.imgProjectTree.Images.SetKeyName(1, "folder_open.png");
            this.imgProjectTree.Images.SetKeyName(2, "room.png");
            // 
            // chkWriteTiles
            // 
            this.chkWriteTiles.AutoSize = true;
            this.chkWriteTiles.Checked = true;
            this.chkWriteTiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWriteTiles.Location = new System.Drawing.Point(12, 32);
            this.chkWriteTiles.Name = "chkWriteTiles";
            this.chkWriteTiles.Size = new System.Drawing.Size(126, 17);
            this.chkWriteTiles.TabIndex = 0;
            this.chkWriteTiles.Text = "Write/Overwrite Tiles";
            this.tipMain.SetToolTip(this.chkWriteTiles, "Writes instances, or overwrites existing instances");
            this.chkWriteTiles.UseVisualStyleBackColor = true;
            this.chkWriteTiles.CheckedChanged += new System.EventHandler(this.chkWriteTiles_CheckedChanged);
            // 
            // chkOptimizeTiles
            // 
            this.chkOptimizeTiles.AutoSize = true;
            this.chkOptimizeTiles.Checked = true;
            this.chkOptimizeTiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOptimizeTiles.Location = new System.Drawing.Point(12, 99);
            this.chkOptimizeTiles.Name = "chkOptimizeTiles";
            this.chkOptimizeTiles.Size = new System.Drawing.Size(91, 17);
            this.chkOptimizeTiles.TabIndex = 4;
            this.chkOptimizeTiles.Text = "Optimize Tiles";
            this.tipMain.SetToolTip(this.chkOptimizeTiles, "Create optimized Game Maker tiles on export");
            this.chkOptimizeTiles.UseVisualStyleBackColor = true;
            // 
            // chkRefactorInstances
            // 
            this.chkRefactorInstances.AutoSize = true;
            this.chkRefactorInstances.Location = new System.Drawing.Point(12, 80);
            this.chkRefactorInstances.Name = "chkRefactorInstances";
            this.chkRefactorInstances.Size = new System.Drawing.Size(128, 17);
            this.chkRefactorInstances.TabIndex = 3;
            this.chkRefactorInstances.Text = "Refactor Instance Ids";
            this.tipMain.SetToolTip(this.chkRefactorInstances, "Resets the project\'s instance ids");
            this.chkRefactorInstances.UseVisualStyleBackColor = true;
            // 
            // chkRefactorTiles
            // 
            this.chkRefactorTiles.AutoSize = true;
            this.chkRefactorTiles.Location = new System.Drawing.Point(12, 64);
            this.chkRefactorTiles.Name = "chkRefactorTiles";
            this.chkRefactorTiles.Size = new System.Drawing.Size(104, 17);
            this.chkRefactorTiles.TabIndex = 2;
            this.chkRefactorTiles.Text = "Refactor Tile Ids";
            this.tipMain.SetToolTip(this.chkRefactorTiles, "Resets the project\'s tile ids");
            this.chkRefactorTiles.UseVisualStyleBackColor = true;
            // 
            // chkWriteInstances
            // 
            this.chkWriteInstances.AutoSize = true;
            this.chkWriteInstances.Location = new System.Drawing.Point(12, 48);
            this.chkWriteInstances.Name = "chkWriteInstances";
            this.chkWriteInstances.Size = new System.Drawing.Size(150, 17);
            this.chkWriteInstances.TabIndex = 1;
            this.chkWriteInstances.Text = "Write/Overwrite Instances";
            this.tipMain.SetToolTip(this.chkWriteInstances, "Writes instances, or overwrites existing instances");
            this.chkWriteInstances.UseVisualStyleBackColor = true;
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_Status,
            this.tsslProgress});
            this.ssMain.Location = new System.Drawing.Point(0, 431);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(538, 22);
            this.ssMain.TabIndex = 7;
            this.ssMain.Text = "statusStrip1";
            // 
            // tssl_Status
            // 
            this.tssl_Status.Name = "tssl_Status";
            this.tssl_Status.Size = new System.Drawing.Size(421, 17);
            this.tssl_Status.Spring = true;
            this.tssl_Status.Text = "Ready";
            this.tssl_Status.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tsslProgress
            // 
            this.tsslProgress.Name = "tsslProgress";
            this.tsslProgress.Size = new System.Drawing.Size(100, 16);
            // 
            // bwIO
            // 
            this.bwIO.WorkerReportsProgress = true;
            // 
            // lblRoomName
            // 
            this.lblRoomName.AutoSize = true;
            this.lblRoomName.Location = new System.Drawing.Point(60, 10);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(69, 13);
            this.lblRoomName.TabIndex = 2;
            this.lblRoomName.Text = "Room Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(132, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(184, 20);
            this.txtName.TabIndex = 3;
            this.txtName.ToolTipText = "";
            this.txtName.ToolTipTitle = "";
            // 
            // butCancel
            // 
            this.butCancel.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butCancel.Checked = false;
            this.butCancel.FlatStyled = false;
            this.butCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCancel.Image = global::GMare.Properties.Resources.decline;
            this.butCancel.ImageXOffset = 0;
            this.butCancel.ImageYOffset = 0;
            this.butCancel.Location = new System.Drawing.Point(32, 4);
            this.butCancel.Name = "butCancel";
            this.butCancel.PushButtonImage = null;
            this.butCancel.Size = new System.Drawing.Size(24, 24);
            this.butCancel.TabIndex = 1;
            this.butCancel.TextXOffset = 0;
            this.butCancel.TextYOffset = 0;
            this.butCancel.ToolTipText = "Cancel the export";
            this.butCancel.ToolTipTitle = "Cancel";
            this.butCancel.UseDropShadow = true;
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butExport
            // 
            this.butExport.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butExport.Checked = false;
            this.butExport.FlatStyled = false;
            this.butExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butExport.Image = global::GMare.Properties.Resources.save;
            this.butExport.ImageXOffset = 0;
            this.butExport.ImageYOffset = 0;
            this.butExport.Location = new System.Drawing.Point(8, 4);
            this.butExport.Name = "butExport";
            this.butExport.PushButtonImage = null;
            this.butExport.Size = new System.Drawing.Size(24, 24);
            this.butExport.TabIndex = 0;
            this.butExport.TextXOffset = 0;
            this.butExport.TextYOffset = 0;
            this.butExport.ToolTipText = "Commit the export to disk";
            this.butExport.ToolTipTitle = "Save Export";
            this.butExport.UseDropShadow = true;
            this.butExport.UseVisualStyleBackColor = true;
            this.butExport.Click += new System.EventHandler(this.butExport_Click);
            // 
            // grpBackgrounds
            // 
            this.grpBackgrounds.BackColor = System.Drawing.Color.Transparent;
            this.grpBackgrounds.Controls.Add(this.lstBackgrounds);
            this.grpBackgrounds.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBackgrounds.Location = new System.Drawing.Point(232, 32);
            this.grpBackgrounds.Name = "grpBackgrounds";
            this.grpBackgrounds.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpBackgrounds.Size = new System.Drawing.Size(300, 392);
            this.grpBackgrounds.TabIndex = 6;
            this.grpBackgrounds.TabStop = false;
            this.grpBackgrounds.Text = "Backgrounds";
            this.grpBackgrounds.TextBarHeight = 24;
            // 
            // lstBackgrounds
            // 
            this.lstBackgrounds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBackgrounds.CellSize = new System.Drawing.Size(64, 64);
            this.lstBackgrounds.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstBackgrounds.EmptyListText = "Background Selection Disabled";
            this.lstBackgrounds.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBackgrounds.FormattingEnabled = true;
            this.lstBackgrounds.Glyph = null;
            this.lstBackgrounds.GlyphOffsetX = 4;
            this.lstBackgrounds.GlyphOffsetY = 0;
            this.lstBackgrounds.HorizontalExtent = 272;
            this.lstBackgrounds.IntegralHeight = false;
            this.lstBackgrounds.ItemHeight = 68;
            this.lstBackgrounds.ListboxMode = GMare.Controls.GMareListbox.ListboxType.Backgrounds;
            this.lstBackgrounds.Location = new System.Drawing.Point(12, 32);
            this.lstBackgrounds.Name = "lstBackgrounds";
            this.lstBackgrounds.ShowBlocks = false;
            this.lstBackgrounds.Size = new System.Drawing.Size(276, 348);
            this.lstBackgrounds.TabIndex = 0;
            this.lstBackgrounds.TextOffsetX = 12;
            this.lstBackgrounds.TextOffsetY = 0;
            this.lstBackgrounds.ToolTipText = "Choose a background for export";
            this.lstBackgrounds.ToolTipTitle = "Select Background";
            this.lstBackgrounds.SelectedIndexChanged += new System.EventHandler(this.lstBackgrounds_SelectedIndexChanged);
            // 
            // grpRooms
            // 
            this.grpRooms.BackColor = System.Drawing.Color.Transparent;
            this.grpRooms.Controls.Add(this.tvRooms);
            this.grpRooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRooms.Location = new System.Drawing.Point(4, 168);
            this.grpRooms.Name = "grpRooms";
            this.grpRooms.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpRooms.Size = new System.Drawing.Size(224, 256);
            this.grpRooms.TabIndex = 5;
            this.grpRooms.TabStop = false;
            this.grpRooms.Text = "Project Rooms";
            this.grpRooms.TextBarHeight = 24;
            // 
            // tvRooms
            // 
            this.tvRooms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvRooms.HideSelection = false;
            this.tvRooms.ImageIndex = 0;
            this.tvRooms.ImageList = this.imgProjectTree;
            this.tvRooms.Indent = 20;
            this.tvRooms.ItemHeight = 18;
            this.tvRooms.Location = new System.Drawing.Point(12, 32);
            this.tvRooms.Name = "tvRooms";
            this.tvRooms.SelectedImageIndex = 0;
            this.tvRooms.Size = new System.Drawing.Size(200, 212);
            this.tvRooms.TabIndex = 0;
            this.tvRooms.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRooms_AfterSelect);
            this.tvRooms.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvRooms_MouseDown);
            // 
            // grpOptions
            // 
            this.grpOptions.BackColor = System.Drawing.Color.Transparent;
            this.grpOptions.Controls.Add(this.chkWriteTiles);
            this.grpOptions.Controls.Add(this.butViewOptimization);
            this.grpOptions.Controls.Add(this.chkOptimizeTiles);
            this.grpOptions.Controls.Add(this.chkRefactorInstances);
            this.grpOptions.Controls.Add(this.chkRefactorTiles);
            this.grpOptions.Controls.Add(this.chkWriteInstances);
            this.grpOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOptions.Location = new System.Drawing.Point(4, 32);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpOptions.Size = new System.Drawing.Size(224, 132);
            this.grpOptions.TabIndex = 4;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            this.grpOptions.TextBarHeight = 24;
            // 
            // butViewOptimization
            // 
            this.butViewOptimization.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butViewOptimization.Checked = false;
            this.butViewOptimization.FlatStyled = false;
            this.butViewOptimization.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butViewOptimization.ImageXOffset = 0;
            this.butViewOptimization.ImageYOffset = 0;
            this.butViewOptimization.Location = new System.Drawing.Point(104, 96);
            this.butViewOptimization.Name = "butViewOptimization";
            this.butViewOptimization.PushButtonImage = null;
            this.butViewOptimization.Size = new System.Drawing.Size(108, 23);
            this.butViewOptimization.TabIndex = 5;
            this.butViewOptimization.Text = "View Optimization";
            this.butViewOptimization.TextXOffset = 0;
            this.butViewOptimization.TextYOffset = 0;
            this.butViewOptimization.ToolTipText = "";
            this.butViewOptimization.ToolTipTitle = "";
            this.butViewOptimization.UseDropShadow = true;
            this.butViewOptimization.UseVisualStyleBackColor = true;
            this.butViewOptimization.Click += new System.EventHandler(this.butViewOptimization_Click);
            // 
            // ExportGMProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 453);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblRoomName);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butExport);
            this.Controls.Add(this.grpBackgrounds);
            this.Controls.Add(this.grpRooms);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.ssMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportGMProjectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export To Game Maker Project File";
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.grpBackgrounds.ResumeLayout(false);
            this.grpRooms.ResumeLayout(false);
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMare.Controls.GMareListbox lstBackgrounds;
        private System.Windows.Forms.TreeView tvRooms;
        private System.Windows.Forms.ToolTip tipMain;
        private System.Windows.Forms.ImageList imgProjectTree;
        private System.Windows.Forms.CheckBox chkRefactorInstances;
        private System.Windows.Forms.CheckBox chkWriteInstances;
        private System.Windows.Forms.CheckBox chkRefactorTiles;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Status;
        private System.Windows.Forms.ToolStripProgressBar tsslProgress;
        private System.ComponentModel.BackgroundWorker bwIO;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpOptions;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpRooms;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpBackgrounds;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butExport;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butCancel;
        private System.Windows.Forms.Label lblRoomName;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox txtName;
        private System.Windows.Forms.CheckBox chkOptimizeTiles;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butViewOptimization;
        private System.Windows.Forms.CheckBox chkWriteTiles;
    }
}