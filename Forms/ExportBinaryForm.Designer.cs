namespace GMare.Forms
{
    partial class ExportBinaryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportBinaryForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl_TotalSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_Export = new System.Windows.Forms.ToolStripButton();
            this.tsb_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_AddFile = new System.Windows.Forms.ToolStripButton();
            this.tsb_RemoveFile = new System.Windows.Forms.ToolStripButton();
            this.tsb_CheckAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.cms_Options = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_ShiftUp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ShiftDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Rename = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_Collisions = new System.Windows.Forms.CheckBox();
            this.cb_Instances = new System.Windows.Forms.CheckBox();
            this.cb_Tiles = new System.Windows.Forms.CheckBox();
            this.cb_Flipping = new System.Windows.Forms.CheckBox();
            this.cb_BlendColor = new System.Windows.Forms.CheckBox();
            this.clb_Rooms = new GMare.Controls.CheckedListBoxEx();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.cms_Options.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.clb_Rooms);
            this.groupBox2.Location = new System.Drawing.Point(8, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 192);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rooms To Export";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_TotalSize});
            this.statusStrip1.Location = new System.Drawing.Point(0, 346);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(250, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl_TotalSize
            // 
            this.tssl_TotalSize.Name = "tssl_TotalSize";
            this.tssl_TotalSize.Size = new System.Drawing.Size(121, 17);
            this.tssl_TotalSize.Text = "Total File Size: 0 bytes";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_Export,
            this.tsb_Cancel,
            this.toolStripSeparator1,
            this.tsb_AddFile,
            this.tsb_RemoveFile,
            this.tsb_CheckAll});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(250, 25);
            this.toolStrip1.TabIndex = 0;
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
            this.tsb_Export.ToolTipText = "Save binary file";
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
            // tsb_AddFile
            // 
            this.tsb_AddFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_AddFile.Image = global::GMare.Properties.Resources.add;
            this.tsb_AddFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_AddFile.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_AddFile.Name = "tsb_AddFile";
            this.tsb_AddFile.Size = new System.Drawing.Size(23, 22);
            this.tsb_AddFile.Text = "toolStripButton3";
            this.tsb_AddFile.ToolTipText = "Add a room";
            this.tsb_AddFile.Click += new System.EventHandler(this.tsb_AddRoom_Click);
            // 
            // tsb_RemoveFile
            // 
            this.tsb_RemoveFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_RemoveFile.Image = global::GMare.Properties.Resources.delete;
            this.tsb_RemoveFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_RemoveFile.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_RemoveFile.Name = "tsb_RemoveFile";
            this.tsb_RemoveFile.Size = new System.Drawing.Size(23, 22);
            this.tsb_RemoveFile.Text = "toolStripButton4";
            this.tsb_RemoveFile.ToolTipText = "Remove selected room";
            this.tsb_RemoveFile.Click += new System.EventHandler(this.tsb_RemoveFile_Click);
            // 
            // tsb_CheckAll
            // 
            this.tsb_CheckAll.CheckOnClick = true;
            this.tsb_CheckAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_CheckAll.Image = global::GMare.Properties.Resources.check_list;
            this.tsb_CheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_CheckAll.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_CheckAll.Name = "tsb_CheckAll";
            this.tsb_CheckAll.Size = new System.Drawing.Size(23, 22);
            this.tsb_CheckAll.Text = "toolStripButton1";
            this.tsb_CheckAll.ToolTipText = "Toggle check all rooms";
            this.tsb_CheckAll.CheckedChanged += new System.EventHandler(this.tsb_CheckAll_CheckChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 23);
            // 
            // cms_Options
            // 
            this.cms_Options.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_ShiftUp,
            this.tsmi_ShiftDown,
            this.toolStripSeparator2,
            this.tsmi_Rename});
            this.cms_Options.Name = "contextMenuStrip1";
            this.cms_Options.Size = new System.Drawing.Size(173, 76);
            // 
            // tsmi_ShiftUp
            // 
            this.tsmi_ShiftUp.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_ShiftUp.Image")));
            this.tsmi_ShiftUp.Name = "tsmi_ShiftUp";
            this.tsmi_ShiftUp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.tsmi_ShiftUp.Size = new System.Drawing.Size(172, 22);
            this.tsmi_ShiftUp.Text = "Shift Up";
            this.tsmi_ShiftUp.Click += new System.EventHandler(this.tsmi_ShiftUp_Click);
            // 
            // tsmi_ShiftDown
            // 
            this.tsmi_ShiftDown.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_ShiftDown.Image")));
            this.tsmi_ShiftDown.Name = "tsmi_ShiftDown";
            this.tsmi_ShiftDown.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmi_ShiftDown.Size = new System.Drawing.Size(172, 22);
            this.tsmi_ShiftDown.Text = "Shift Down";
            this.tsmi_ShiftDown.Click += new System.EventHandler(this.tsmi_ShiftDown_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // tsmi_Rename
            // 
            this.tsmi_Rename.Image = global::GMare.Properties.Resources.rename;
            this.tsmi_Rename.Name = "tsmi_Rename";
            this.tsmi_Rename.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.tsmi_Rename.Size = new System.Drawing.Size(172, 22);
            this.tsmi_Rename.Text = "Rename";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_BlendColor);
            this.groupBox1.Controls.Add(this.cb_Flipping);
            this.groupBox1.Controls.Add(this.cb_Collisions);
            this.groupBox1.Controls.Add(this.cb_Instances);
            this.groupBox1.Controls.Add(this.cb_Tiles);
            this.groupBox1.Location = new System.Drawing.Point(8, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 104);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Write Options";
            // 
            // cb_Collisions
            // 
            this.cb_Collisions.AutoSize = true;
            this.cb_Collisions.Enabled = false;
            this.cb_Collisions.Location = new System.Drawing.Point(8, 80);
            this.cb_Collisions.Name = "cb_Collisions";
            this.cb_Collisions.Size = new System.Drawing.Size(128, 17);
            this.cb_Collisions.TabIndex = 2;
            this.cb_Collisions.Text = "Include Collision Data";
            this.cb_Collisions.UseVisualStyleBackColor = true;
            this.cb_Collisions.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cb_Instances
            // 
            this.cb_Instances.AutoSize = true;
            this.cb_Instances.Location = new System.Drawing.Point(8, 64);
            this.cb_Instances.Name = "cb_Instances";
            this.cb_Instances.Size = new System.Drawing.Size(131, 17);
            this.cb_Instances.TabIndex = 1;
            this.cb_Instances.Text = "Include Instance Data";
            this.cb_Instances.UseVisualStyleBackColor = true;
            this.cb_Instances.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cb_Tiles
            // 
            this.cb_Tiles.AutoSize = true;
            this.cb_Tiles.Checked = true;
            this.cb_Tiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Tiles.Location = new System.Drawing.Point(8, 16);
            this.cb_Tiles.Name = "cb_Tiles";
            this.cb_Tiles.Size = new System.Drawing.Size(107, 17);
            this.cb_Tiles.TabIndex = 0;
            this.cb_Tiles.Text = "Include Tile Data";
            this.cb_Tiles.UseVisualStyleBackColor = true;
            this.cb_Tiles.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cb_Flipping
            // 
            this.cb_Flipping.AutoSize = true;
            this.cb_Flipping.Location = new System.Drawing.Point(24, 32);
            this.cb_Flipping.Name = "cb_Flipping";
            this.cb_Flipping.Size = new System.Drawing.Size(146, 17);
            this.cb_Flipping.TabIndex = 3;
            this.cb_Flipping.Text = "Include Tile Flipping Data";
            this.cb_Flipping.UseVisualStyleBackColor = true;
            this.cb_Flipping.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cb_BlendColor
            // 
            this.cb_BlendColor.AutoSize = true;
            this.cb_BlendColor.Location = new System.Drawing.Point(24, 48);
            this.cb_BlendColor.Name = "cb_BlendColor";
            this.cb_BlendColor.Size = new System.Drawing.Size(164, 17);
            this.cb_BlendColor.TabIndex = 4;
            this.cb_BlendColor.Text = "Include Tile Blend Color Data";
            this.cb_BlendColor.UseVisualStyleBackColor = true;
            this.cb_BlendColor.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // clb_Rooms
            // 
            this.clb_Rooms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clb_Rooms.FormattingEnabled = true;
            this.clb_Rooms.Glyph = global::GMare.Properties.Resources.room;
            this.clb_Rooms.HorizontalExtent = 212;
            this.clb_Rooms.HorizontalScrollbar = true;
            this.clb_Rooms.IntegralHeight = false;
            this.clb_Rooms.Location = new System.Drawing.Point(8, 16);
            this.clb_Rooms.Name = "clb_Rooms";
            this.clb_Rooms.Size = new System.Drawing.Size(216, 168);
            this.clb_Rooms.TabIndex = 1;
            this.toolTip1.SetToolTip(this.clb_Rooms, "List of rooms to export to binary file");
            this.clb_Rooms.SelectedIndexChanged += new System.EventHandler(this.clb_Rooms_SelectedIndexChanged);
            this.clb_Rooms.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clb_Rooms_KeyDown);
            this.clb_Rooms.MouseDown += new System.Windows.Forms.MouseEventHandler(this.clb_Rooms_MouseDown);
            // 
            // ExportBinaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 368);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportBinaryForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export To Binary File";
            this.groupBox2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cms_Options.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_Export;
        private System.Windows.Forms.ToolStripButton tsb_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsb_AddFile;
        private System.Windows.Forms.ToolStripButton tsb_RemoveFile;
        private System.Windows.Forms.ToolStripStatusLabel tssl_TotalSize;
        private System.Windows.Forms.ToolStripButton tsb_CheckAll;
        private System.Windows.Forms.ContextMenuStrip cms_Options;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ShiftUp;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ShiftDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Rename;
        private GMare.Controls.CheckedListBoxEx clb_Rooms;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_Collisions;
        private System.Windows.Forms.CheckBox cb_Instances;
        private System.Windows.Forms.CheckBox cb_Tiles;
        private System.Windows.Forms.CheckBox cb_BlendColor;
        private System.Windows.Forms.CheckBox cb_Flipping;
    }
}