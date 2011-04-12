namespace GMare.Forms
{
    partial class BrushEditForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_Ok = new System.Windows.Forms.ToolStripButton();
            this.tsb_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Delete = new System.Windows.Forms.ToolStripButton();
            this.tsb_MoveUp = new System.Windows.Forms.ToolStripButton();
            this.tsb_MoveDown = new System.Windows.Forms.ToolStripButton();
            this.gb_ = new System.Windows.Forms.GroupBox();
            this.tb_Name = new GMare.Controls.TextBoxEx();
            this.lb_Brushes = new GMare.Controls.ListboxEx();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.gb_.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_Brushes);
            this.groupBox1.Location = new System.Drawing.Point(8, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 216);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Brushes";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_Ok,
            this.tsb_Cancel,
            this.toolStripSeparator1,
            this.tsb_Delete,
            this.tsb_MoveUp,
            this.tsb_MoveDown});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(281, 25);
            this.toolStrip1.TabIndex = 1;
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
            // tsb_Delete
            // 
            this.tsb_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Delete.Image = global::GMare.Properties.Resources.brush_delete;
            this.tsb_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Delete.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_Delete.Name = "tsb_Delete";
            this.tsb_Delete.Size = new System.Drawing.Size(23, 22);
            this.tsb_Delete.Text = "toolStripButton1";
            this.tsb_Delete.ToolTipText = "Delete selected brush";
            this.tsb_Delete.Click += new System.EventHandler(this.tsb_Delete_Click);
            // 
            // tsb_MoveUp
            // 
            this.tsb_MoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_MoveUp.Image = global::GMare.Properties.Resources.sort_up;
            this.tsb_MoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_MoveUp.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_MoveUp.Name = "tsb_MoveUp";
            this.tsb_MoveUp.Size = new System.Drawing.Size(23, 22);
            this.tsb_MoveUp.Text = "toolStripButton1";
            this.tsb_MoveUp.ToolTipText = "Move selected brush up the list";
            this.tsb_MoveUp.Click += new System.EventHandler(this.tsb_MoveUp_Click);
            // 
            // tsb_MoveDown
            // 
            this.tsb_MoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_MoveDown.Image = global::GMare.Properties.Resources.sort_down;
            this.tsb_MoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_MoveDown.Name = "tsb_MoveDown";
            this.tsb_MoveDown.Size = new System.Drawing.Size(23, 22);
            this.tsb_MoveDown.Text = "toolStripButton2";
            this.tsb_MoveDown.ToolTipText = "Move the selected brush down the list";
            this.tsb_MoveDown.Click += new System.EventHandler(this.tsb_MoveDown_Click);
            // 
            // gb_
            // 
            this.gb_.Controls.Add(this.tb_Name);
            this.gb_.Location = new System.Drawing.Point(8, 32);
            this.gb_.Name = "gb_";
            this.gb_.Size = new System.Drawing.Size(264, 48);
            this.gb_.TabIndex = 2;
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
            this.tb_Name.TextChanged += new System.EventHandler(this.tb_Name_TextChanged);
            // 
            // lb_Brushes
            // 
            this.lb_Brushes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Brushes.CellHeight = 16;
            this.lb_Brushes.CellWidth = 16;
            this.lb_Brushes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lb_Brushes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Brushes.FormattingEnabled = true;
            this.lb_Brushes.HorizontalExtent = 244;
            this.lb_Brushes.IntegralHeight = false;
            this.lb_Brushes.ItemHeight = 18;
            this.lb_Brushes.ListboxMode = GMare.Controls.ListboxEx.ListboxType.Brushes;
            this.lb_Brushes.Location = new System.Drawing.Point(8, 16);
            this.lb_Brushes.Name = "lb_Brushes";
            this.lb_Brushes.Size = new System.Drawing.Size(248, 188);
            this.lb_Brushes.TabIndex = 0;
            this.lb_Brushes.SelectedIndexChanged += new System.EventHandler(this.lb_Brushes_SelectedIndexChanged);
            // 
            // BrushEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 312);
            this.Controls.Add(this.gb_);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BrushEditForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Brushes";
            this.groupBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gb_.ResumeLayout(false);
            this.gb_.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_Ok;
        private System.Windows.Forms.ToolStripButton tsb_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsb_Delete;
        private Controls.ListboxEx lb_Brushes;
        private System.Windows.Forms.ToolStripButton tsb_MoveUp;
        private System.Windows.Forms.ToolStripButton tsb_MoveDown;
        private System.Windows.Forms.GroupBox gb_;
        private Controls.TextBoxEx tb_Name;
    }
}