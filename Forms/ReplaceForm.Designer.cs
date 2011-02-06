namespace GMare.Forms
{
    partial class ReplaceForm
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
            GMare.Common.TileGrid tileGrid1 = new GMare.Common.TileGrid();
            GMare.Common.TileGrid tileGrid2 = new GMare.Common.TileGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnl_Target = new GMare.Controls.BackgroundPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnl_Swap = new GMare.Controls.BackgroundPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_Ok = new System.Windows.Forms.ToolStripButton();
            this.tsb_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Empty = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tscb_Layers = new System.Windows.Forms.ToolStripComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnl_Target);
            this.groupBox1.Location = new System.Drawing.Point(8, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 328);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tile(s) to Replace";
            // 
            // pnl_Target
            // 
            this.pnl_Target.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Target.AutoScroll = true;
            this.pnl_Target.AutoScrollMinSize = new System.Drawing.Size(220, 300);
            this.pnl_Target.BackColor = System.Drawing.Color.White;
            this.pnl_Target.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Target.Image = null;
            this.pnl_Target.Location = new System.Drawing.Point(8, 16);
            this.pnl_Target.Name = "pnl_Target";
            tileGrid1.EndX = 16;
            tileGrid1.EndY = 16;
            tileGrid1.StartX = 0;
            tileGrid1.StartY = 0;
            tileGrid1.TileIds = null;
            this.pnl_Target.Selection = tileGrid1;
            this.pnl_Target.SelectMode = GMare.Controls.BackgroundPanel.SelectType.Normal;
            this.pnl_Target.Size = new System.Drawing.Size(224, 304);
            this.pnl_Target.TabIndex = 0;
            this.pnl_Target.Zoom = 1F;
            this.pnl_Target.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_Target_MouseUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnl_Swap);
            this.groupBox2.Location = new System.Drawing.Point(256, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 328);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Replacement Tile(s)";
            // 
            // pnl_Swap
            // 
            this.pnl_Swap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Swap.AutoScroll = true;
            this.pnl_Swap.AutoScrollMinSize = new System.Drawing.Size(220, 300);
            this.pnl_Swap.BackColor = System.Drawing.Color.White;
            this.pnl_Swap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Swap.Image = null;
            this.pnl_Swap.Location = new System.Drawing.Point(8, 16);
            this.pnl_Swap.Name = "pnl_Swap";
            tileGrid2.EndX = 16;
            tileGrid2.EndY = 16;
            tileGrid2.StartX = 0;
            tileGrid2.StartY = 0;
            tileGrid2.TileIds = null;
            this.pnl_Swap.Selection = tileGrid2;
            this.pnl_Swap.SelectMode = GMare.Controls.BackgroundPanel.SelectType.Fixed;
            this.pnl_Swap.Size = new System.Drawing.Size(224, 304);
            this.pnl_Swap.TabIndex = 0;
            this.pnl_Swap.Zoom = 1F;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_Ok,
            this.tsb_Cancel,
            this.toolStripSeparator1,
            this.tsb_Empty,
            this.toolStripLabel1,
            this.tscb_Layers});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(505, 25);
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
            // tsb_Empty
            // 
            this.tsb_Empty.CheckOnClick = true;
            this.tsb_Empty.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Empty.Image = global::GMare.Properties.Resources.layer_empty;
            this.tsb_Empty.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Empty.Name = "tsb_Empty";
            this.tsb_Empty.Size = new System.Drawing.Size(23, 22);
            this.tsb_Empty.Text = "toolStripButton3";
            this.tsb_Empty.ToolTipText = "Set replacement tile(s) to empty";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(99, 22);
            this.toolStripLabel1.Text = "Affected Layer(s):";
            // 
            // tscb_Layers
            // 
            this.tscb_Layers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscb_Layers.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tscb_Layers.Name = "tscb_Layers";
            this.tscb_Layers.Size = new System.Drawing.Size(121, 25);
            // 
            // ReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 370);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReplaceForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tile Replacement";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolTip toolTip1;
        private GMare.Controls.BackgroundPanel pnl_Target;
        private GMare.Controls.BackgroundPanel pnl_Swap;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_Ok;
        private System.Windows.Forms.ToolStripButton tsb_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox tscb_Layers;
        private System.Windows.Forms.ToolStripButton tsb_Empty;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}