namespace GMare.Forms
{
    partial class TilesetRefactorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TilesetRefactorForm));
            this.lblMagnify = new System.Windows.Forms.Label();
            this.pnlMagnify = new System.Windows.Forms.Panel();
            this.trkMagnify = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTrackBar();
            this.butCancel = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butOk = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.nudRows = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.nudColumns = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.lblTileX = new System.Windows.Forms.Label();
            this.lblTileY = new System.Windows.Forms.Label();
            this.butGrid = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butRedo = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butUndo = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.lblTileCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTilesetSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlTileset = new GMare.Controls.GMareTilesetRefactorEditor();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColumns)).BeginInit();
            this.ssMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMagnify
            // 
            this.lblMagnify.AutoSize = true;
            this.lblMagnify.Location = new System.Drawing.Point(400, 10);
            this.lblMagnify.Name = "lblMagnify";
            this.lblMagnify.Size = new System.Drawing.Size(33, 13);
            this.lblMagnify.TabIndex = 9;
            this.lblMagnify.Text = "100%";
            // 
            // pnlMagnify
            // 
            this.pnlMagnify.BackgroundImage = global::GMare.Properties.Resources.magnifier;
            this.pnlMagnify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlMagnify.Location = new System.Drawing.Point(280, 4);
            this.pnlMagnify.Name = "pnlMagnify";
            this.pnlMagnify.Size = new System.Drawing.Size(24, 24);
            this.pnlMagnify.TabIndex = 7;
            // 
            // trkMagnify
            // 
            this.trkMagnify.BackColor = System.Drawing.Color.Transparent;
            this.trkMagnify.LargeChange = 1;
            this.trkMagnify.Location = new System.Drawing.Point(304, 6);
            this.trkMagnify.Maximum = 5;
            this.trkMagnify.Minimum = 1;
            this.trkMagnify.Name = "trkMagnify";
            this.trkMagnify.Size = new System.Drawing.Size(104, 20);
            this.trkMagnify.TabIndex = 8;
            this.trkMagnify.TabStop = true;
            this.trkMagnify.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkMagnify.ToolTipText = "Slide to set the magnification level of the graphic";
            this.trkMagnify.ToolTipTitle = "Image Magnification";
            this.trkMagnify.Value = 1;
            this.trkMagnify.ValueChanged += new System.EventHandler(this.trkMagnify_ValueChanged);
            // 
            // butCancel
            // 
            this.butCancel.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butCancel.Checked = false;
            this.butCancel.FlatStyled = false;
            this.butCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCancel.ImageXOffset = 0;
            this.butCancel.ImageYOffset = 0;
            this.butCancel.Location = new System.Drawing.Point(572, 552);
            this.butCancel.Name = "butCancel";
            this.butCancel.PushButtonImage = null;
            this.butCancel.Size = new System.Drawing.Size(76, 24);
            this.butCancel.TabIndex = 12;
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
            this.butOk.Location = new System.Drawing.Point(492, 552);
            this.butOk.Name = "butOk";
            this.butOk.PushButtonImage = null;
            this.butOk.Size = new System.Drawing.Size(76, 24);
            this.butOk.TabIndex = 11;
            this.butOk.Text = "OK";
            this.butOk.TextXOffset = 0;
            this.butOk.TextYOffset = 0;
            this.butOk.ToolTipText = "";
            this.butOk.ToolTipTitle = "";
            this.butOk.UseDropShadow = true;
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // nudRows
            // 
            this.nudRows.IgnoreHeight = true;
            this.nudRows.Location = new System.Drawing.Point(228, 7);
            this.nudRows.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRows.Name = "nudRows";
            this.nudRows.Size = new System.Drawing.Size(48, 20);
            this.nudRows.TabIndex = 6;
            this.nudRows.ToolTipText = "The height of the tileset in tiles";
            this.nudRows.ToolTipTitle = "Rows";
            this.nudRows.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudRows.ValueChanged += new System.EventHandler(this.nudSize_ValueChanged);
            // 
            // nudColumns
            // 
            this.nudColumns.IgnoreHeight = true;
            this.nudColumns.Location = new System.Drawing.Point(136, 7);
            this.nudColumns.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudColumns.Name = "nudColumns";
            this.nudColumns.Size = new System.Drawing.Size(48, 20);
            this.nudColumns.TabIndex = 4;
            this.nudColumns.ToolTipText = "The width of the tileset in tiles";
            this.nudColumns.ToolTipTitle = "Columns";
            this.nudColumns.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudColumns.ValueChanged += new System.EventHandler(this.nudSize_ValueChanged);
            // 
            // lblTileX
            // 
            this.lblTileX.AutoSize = true;
            this.lblTileX.Location = new System.Drawing.Point(84, 10);
            this.lblTileX.Name = "lblTileX";
            this.lblTileX.Size = new System.Drawing.Size(50, 13);
            this.lblTileX.TabIndex = 3;
            this.lblTileX.Text = "Columns:";
            // 
            // lblTileY
            // 
            this.lblTileY.AutoSize = true;
            this.lblTileY.Location = new System.Drawing.Point(188, 10);
            this.lblTileY.Name = "lblTileY";
            this.lblTileY.Size = new System.Drawing.Size(37, 13);
            this.lblTileY.TabIndex = 5;
            this.lblTileY.Text = "Rows:";
            // 
            // butGrid
            // 
            this.butGrid.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.PushButton;
            this.butGrid.Checked = true;
            this.butGrid.FlatStyled = false;
            this.butGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butGrid.Image = ((System.Drawing.Image)(resources.GetObject("butGrid.Image")));
            this.butGrid.ImageXOffset = 1;
            this.butGrid.ImageYOffset = 0;
            this.butGrid.Location = new System.Drawing.Point(56, 4);
            this.butGrid.Name = "butGrid";
            this.butGrid.PushButtonImage = null;
            this.butGrid.Size = new System.Drawing.Size(25, 24);
            this.butGrid.TabIndex = 2;
            this.butGrid.TextXOffset = 0;
            this.butGrid.TextYOffset = 0;
            this.butGrid.ToolTipText = "Show or hide the cell grid";
            this.butGrid.ToolTipTitle = "Show/Hide Grid";
            this.butGrid.UseDropShadow = true;
            this.butGrid.UseVisualStyleBackColor = true;
            this.butGrid.CheckChanged += new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.CheckChangedEventHandler(this.butShowGrid_CheckChanged);
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
            this.butRedo.Location = new System.Drawing.Point(32, 4);
            this.butRedo.Name = "butRedo";
            this.butRedo.PushButtonImage = null;
            this.butRedo.Size = new System.Drawing.Size(24, 24);
            this.butRedo.TabIndex = 1;
            this.butRedo.TextXOffset = 0;
            this.butRedo.TextYOffset = 0;
            this.butRedo.ToolTipText = "Redo tile edit";
            this.butRedo.ToolTipTitle = "Redo (Ctrl+Y)";
            this.butRedo.UseDropShadow = true;
            this.butRedo.UseVisualStyleBackColor = true;
            this.butRedo.Click += new System.EventHandler(this.butRedo_Click);
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
            this.butUndo.Location = new System.Drawing.Point(8, 4);
            this.butUndo.Name = "butUndo";
            this.butUndo.PushButtonImage = null;
            this.butUndo.Size = new System.Drawing.Size(24, 24);
            this.butUndo.TabIndex = 0;
            this.butUndo.TextXOffset = 0;
            this.butUndo.TextYOffset = 0;
            this.butUndo.ToolTipText = "Undo tile edit";
            this.butUndo.ToolTipTitle = "Undo (Ctrl+Z)";
            this.butUndo.UseDropShadow = true;
            this.butUndo.UseVisualStyleBackColor = true;
            this.butUndo.Click += new System.EventHandler(this.butUndo_Click);
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTileCount,
            this.lblTilesetSize});
            this.ssMain.Location = new System.Drawing.Point(0, 580);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(660, 24);
            this.ssMain.TabIndex = 13;
            this.ssMain.Text = "statusStrip1";
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
            // pnlTileset
            // 
            this.pnlTileset.AllowDrop = true;
            this.pnlTileset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTileset.AutoScroll = true;
            this.pnlTileset.AutoScrollMinSize = new System.Drawing.Size(640, 512);
            this.pnlTileset.BackColor = System.Drawing.Color.White;
            this.pnlTileset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTileset.CanvasSize = new System.Drawing.Size(0, 0);
            this.pnlTileset.CheckerColor = System.Drawing.Color.Silver;
            this.pnlTileset.CheckerSize = new System.Drawing.Size(16, 16);
            this.pnlTileset.Columns = 16;
            this.pnlTileset.ImageScale = 1;
            this.pnlTileset.Location = new System.Drawing.Point(8, 32);
            this.pnlTileset.Name = "pnlTileset";
            this.pnlTileset.Rows = 0;
            this.pnlTileset.ShowGrid = true;
            this.pnlTileset.Size = new System.Drawing.Size(644, 516);
            this.pnlTileset.SnapSize = new System.Drawing.Size(8, 8);
            this.pnlTileset.TabIndex = 10;
            this.pnlTileset.Tiles = ((System.Collections.Generic.List<System.Drawing.Bitmap>)(resources.GetObject("pnlTileset.Tiles")));
            this.pnlTileset.Title = "Tile Editor";
            this.pnlTileset.ToolTipText = "";
            this.pnlTileset.ToolTipTitle = "";
            this.pnlTileset.UseCheckerBoard = true;
            this.pnlTileset.Zoom = 1F;
            this.pnlTileset.PanelChanged += new GMare.Controls.GMareTilesetRefactorEditor.PanelChangedHandler(this.pnlTileset_PanelChanged);
            // 
            // TilesetRefactorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 604);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.butRedo);
            this.Controls.Add(this.butUndo);
            this.Controls.Add(this.nudRows);
            this.Controls.Add(this.lblTileY);
            this.Controls.Add(this.butGrid);
            this.Controls.Add(this.nudColumns);
            this.Controls.Add(this.lblTileX);
            this.Controls.Add(this.lblMagnify);
            this.Controls.Add(this.pnlMagnify);
            this.Controls.Add(this.trkMagnify);
            this.Controls.Add(this.pnlTileset);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TilesetRefactorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tileset Editor";
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColumns)).EndInit();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMagnify;
        private System.Windows.Forms.Panel pnlMagnify;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTrackBar trkMagnify;
        private Controls.GMareTilesetRefactorEditor pnlTileset;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butCancel;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butOk;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudRows;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudColumns;
        private System.Windows.Forms.Label lblTileX;
        private System.Windows.Forms.Label lblTileY;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butGrid;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butRedo;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butUndo;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel lblTileCount;
        private System.Windows.Forms.ToolStripStatusLabel lblTilesetSize;
    }
}