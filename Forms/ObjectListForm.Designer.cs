namespace GMare.Forms
{
    partial class ObjectListForm
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
            this.txtSearch = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox();
            this.lstObjects = new GMare.Controls.GMareListbox();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(36, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(211, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Text = "Search";
            this.txtSearch.ToolTipText = "";
            this.txtSearch.ToolTipTitle = "";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // lstObjects
            // 
            this.lstObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstObjects.CellSize = new System.Drawing.Size(16, 16);
            this.lstObjects.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstObjects.EmptyListText = "";
            this.lstObjects.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstObjects.FormattingEnabled = true;
            this.lstObjects.Glyph = null;
            this.lstObjects.GlyphOffsetX = 2;
            this.lstObjects.GlyphOffsetY = 0;
            this.lstObjects.HorizontalExtent = 235;
            this.lstObjects.ItemHeight = 22;
            this.lstObjects.ListboxMode = GMare.Controls.GMareListbox.ListboxType.Objects;
            this.lstObjects.Location = new System.Drawing.Point(8, 36);
            this.lstObjects.Name = "lstObjects";
            this.lstObjects.ShowBlocks = true;
            this.lstObjects.Size = new System.Drawing.Size(239, 312);
            this.lstObjects.TabIndex = 2;
            this.lstObjects.TextOffsetX = 0;
            this.lstObjects.TextOffsetY = 0;
            this.lstObjects.ToolTipText = "A list of objects imported for this room";
            this.lstObjects.ToolTipTitle = "Object List";
            this.lstObjects.Click += new System.EventHandler(this.lstObjects_Click);
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackgroundImage = global::GMare.Properties.Resources.magnifier;
            this.pnlSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlSearch.Location = new System.Drawing.Point(8, 6);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(24, 24);
            this.pnlSearch.TabIndex = 0;
            // 
            // ObjectListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 358);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.lstObjects);
            this.Controls.Add(this.txtSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ObjectListForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Object List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox txtSearch;
        private Controls.GMareListbox lstObjects;
        private System.Windows.Forms.Panel pnlSearch;
    }
}