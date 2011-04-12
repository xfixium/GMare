namespace GMare.Forms
{
    partial class BrushForm
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
            this.gb_ = new System.Windows.Forms.GroupBox();
            this.tb_Name = new GMare.Controls.TextBoxEx();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnl_Brush = new GMare.Controls.ImagePanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_Ok = new System.Windows.Forms.ToolStripButton();
            this.tsb_Cancel = new System.Windows.Forms.ToolStripButton();
            this.gb_.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_
            // 
            this.gb_.Controls.Add(this.tb_Name);
            this.gb_.Location = new System.Drawing.Point(8, 32);
            this.gb_.Name = "gb_";
            this.gb_.Size = new System.Drawing.Size(264, 48);
            this.gb_.TabIndex = 0;
            this.gb_.TabStop = false;
            this.gb_.Text = "Brush Name";
            // 
            // tb_Name
            // 
            this.tb_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Name.Location = new System.Drawing.Point(8, 18);
            this.tb_Name.MaxLength = 40;
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(248, 20);
            this.tb_Name.TabIndex = 0;
            this.tb_Name.Text = "New Brush";
            this.tb_Name.TextChanged += new System.EventHandler(this.tb_Name_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnl_Brush);
            this.groupBox1.Location = new System.Drawing.Point(8, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 216);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Brush";
            // 
            // pnl_Brush
            // 
            this.pnl_Brush.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Brush.AutoScroll = true;
            this.pnl_Brush.AutoScrollMinSize = new System.Drawing.Size(240, 184);
            this.pnl_Brush.BackColor = System.Drawing.Color.White;
            this.pnl_Brush.Blink = false;
            this.pnl_Brush.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Brush.Image = null;
            this.pnl_Brush.Location = new System.Drawing.Point(10, 18);
            this.pnl_Brush.Name = "pnl_Brush";
            this.pnl_Brush.OffsetX = 0;
            this.pnl_Brush.OffsetY = 0;
            this.pnl_Brush.SeperationX = 0;
            this.pnl_Brush.SeperationY = 0;
            this.pnl_Brush.ShowGrid = false;
            this.pnl_Brush.Size = new System.Drawing.Size(244, 188);
            this.pnl_Brush.TabIndex = 0;
            this.pnl_Brush.TileSize = new System.Drawing.Size(16, 16);
            this.pnl_Brush.Zoom = 1F;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_Ok,
            this.tsb_Cancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(281, 25);
            this.toolStrip1.TabIndex = 6;
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
            // BrushForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 312);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BrushForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Brush";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NameForm_FormClosing);
            this.gb_.ResumeLayout(false);
            this.gb_.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_;
        private Controls.TextBoxEx tb_Name;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.ImagePanel pnl_Brush;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_Ok;
        private System.Windows.Forms.ToolStripButton tsb_Cancel;
    }
}