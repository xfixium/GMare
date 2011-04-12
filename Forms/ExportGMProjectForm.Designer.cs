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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstbx_Backgrounds = new GMare.Controls.ListboxEx();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tv_Rooms = new GMare.Controls.TreeviewEx();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cb_OverwriteInstances = new System.Windows.Forms.CheckBox();
            this.cb_RefactorTiles = new System.Windows.Forms.CheckBox();
            this.cb_RefactorInstances = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_Export = new System.Windows.Forms.ToolStripButton();
            this.tsb_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tstb_Name = new GMare.Controls.ToolStripTextBoxEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.bw_IO = new System.ComponentModel.BackgroundWorker();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstbx_Backgrounds);
            this.groupBox3.Location = new System.Drawing.Point(224, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 328);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Project Backgrounds";
            // 
            // lstbx_Backgrounds
            // 
            this.lstbx_Backgrounds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstbx_Backgrounds.CellHeight = 96;
            this.lstbx_Backgrounds.CellWidth = 128;
            this.lstbx_Backgrounds.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstbx_Backgrounds.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstbx_Backgrounds.FormattingEnabled = true;
            this.lstbx_Backgrounds.HorizontalExtent = 260;
            this.lstbx_Backgrounds.IntegralHeight = false;
            this.lstbx_Backgrounds.ItemHeight = 98;
            this.lstbx_Backgrounds.ListboxMode = GMare.Controls.ListboxEx.ListboxType.Backgrounds;
            this.lstbx_Backgrounds.Location = new System.Drawing.Point(8, 16);
            this.lstbx_Backgrounds.Name = "lstbx_Backgrounds";
            this.lstbx_Backgrounds.Size = new System.Drawing.Size(264, 304);
            this.lstbx_Backgrounds.TabIndex = 0;
            this.toolTip1.SetToolTip(this.lstbx_Backgrounds, "Project backgrounds that are used as tilesets, choose one for your export room");
            this.lstbx_Backgrounds.SelectedIndexChanged += new System.EventHandler(this.lstbx_Backgrounds_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tv_Rooms);
            this.groupBox4.Location = new System.Drawing.Point(8, 112);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(208, 248);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Project Rooms";
            // 
            // tv_Rooms
            // 
            this.tv_Rooms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tv_Rooms.HideSelection = false;
            this.tv_Rooms.ImageIndex = 0;
            this.tv_Rooms.ImageList = this.imageList1;
            this.tv_Rooms.Indent = 20;
            this.tv_Rooms.ItemHeight = 18;
            this.tv_Rooms.Location = new System.Drawing.Point(8, 16);
            this.tv_Rooms.Name = "tv_Rooms";
            this.tv_Rooms.SelectedImageIndex = 0;
            this.tv_Rooms.Size = new System.Drawing.Size(192, 224);
            this.tv_Rooms.TabIndex = 0;
            this.tv_Rooms.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_Rooms_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            this.imageList1.Images.SetKeyName(1, "folder_open.png");
            this.imageList1.Images.SetKeyName(2, "room.png");
            // 
            // cb_OverwriteInstances
            // 
            this.cb_OverwriteInstances.AutoSize = true;
            this.cb_OverwriteInstances.Location = new System.Drawing.Point(8, 48);
            this.cb_OverwriteInstances.Name = "cb_OverwriteInstances";
            this.cb_OverwriteInstances.Size = new System.Drawing.Size(152, 17);
            this.cb_OverwriteInstances.TabIndex = 12;
            this.cb_OverwriteInstances.Text = "Write/Overwrite instances.";
            this.toolTip1.SetToolTip(this.cb_OverwriteInstances, "Writes instances, or overwrites existing instances");
            this.cb_OverwriteInstances.UseVisualStyleBackColor = true;
            // 
            // cb_RefactorTiles
            // 
            this.cb_RefactorTiles.AutoSize = true;
            this.cb_RefactorTiles.Location = new System.Drawing.Point(8, 16);
            this.cb_RefactorTiles.Name = "cb_RefactorTiles";
            this.cb_RefactorTiles.Size = new System.Drawing.Size(102, 17);
            this.cb_RefactorTiles.TabIndex = 11;
            this.cb_RefactorTiles.Text = "Refactor tile ids.";
            this.toolTip1.SetToolTip(this.cb_RefactorTiles, "Resets the project\'s tile ids");
            this.cb_RefactorTiles.UseVisualStyleBackColor = true;
            // 
            // cb_RefactorInstances
            // 
            this.cb_RefactorInstances.AutoSize = true;
            this.cb_RefactorInstances.Location = new System.Drawing.Point(8, 32);
            this.cb_RefactorInstances.Name = "cb_RefactorInstances";
            this.cb_RefactorInstances.Size = new System.Drawing.Size(129, 17);
            this.cb_RefactorInstances.TabIndex = 13;
            this.cb_RefactorInstances.Text = "Refactor instance ids.";
            this.toolTip1.SetToolTip(this.cb_RefactorInstances, "Resets the project\'s instance ids");
            this.cb_RefactorInstances.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_Export,
            this.tsb_Cancel,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tstb_Name});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(513, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_Export
            // 
            this.tsb_Export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Export.Image = global::GMare.Properties.Resources.save;
            this.tsb_Export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Export.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_Export.Name = "tsb_Export";
            this.tsb_Export.Size = new System.Drawing.Size(23, 22);
            this.tsb_Export.Text = "toolStripButton1";
            this.tsb_Export.ToolTipText = "Save to Game Maker project";
            this.tsb_Export.Click += new System.EventHandler(this.tsb_Export_Click);
            // 
            // tsb_Cancel
            // 
            this.tsb_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Cancel.Image = global::GMare.Properties.Resources.decline;
            this.tsb_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Cancel.Name = "tsb_Cancel";
            this.tsb_Cancel.Size = new System.Drawing.Size(23, 22);
            this.tsb_Cancel.Text = "toolStripButton2";
            this.tsb_Cancel.ToolTipText = "Cancel";
            this.tsb_Cancel.Click += new System.EventHandler(this.tsb_Cancel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(77, 22);
            this.toolStripLabel1.Text = "Room Name:";
            // 
            // tstb_Name
            // 
            this.tstb_Name.Name = "tstb_Name";
            this.tstb_Name.Size = new System.Drawing.Size(100, 25);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_RefactorInstances);
            this.groupBox1.Controls.Add(this.cb_OverwriteInstances);
            this.groupBox1.Controls.Add(this.cb_RefactorTiles);
            this.groupBox1.Location = new System.Drawing.Point(8, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 72);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_Status,
            this.tssl_Progress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 370);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(513, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl_Status
            // 
            this.tssl_Status.Name = "tssl_Status";
            this.tssl_Status.Size = new System.Drawing.Size(39, 17);
            this.tssl_Status.Text = "Ready";
            // 
            // tssl_Progress
            // 
            this.tssl_Progress.Name = "tssl_Progress";
            this.tssl_Progress.Size = new System.Drawing.Size(100, 16);
            // 
            // bw_IO
            // 
            this.bw_IO.WorkerReportsProgress = true;
            // 
            // ExportGMProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 392);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportGMProjectForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export To Game Maker Project File";
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private GMare.Controls.ListboxEx lstbx_Backgrounds;
        private GMare.Controls.TreeviewEx tv_Rooms;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_Export;
        private System.Windows.Forms.ToolStripButton tsb_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private GMare.Controls.ToolStripTextBoxEx tstb_Name;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_RefactorInstances;
        private System.Windows.Forms.CheckBox cb_OverwriteInstances;
        private System.Windows.Forms.CheckBox cb_RefactorTiles;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Status;
        private System.Windows.Forms.ToolStripProgressBar tssl_Progress;
        private System.ComponentModel.BackgroundWorker bw_IO;
    }
}