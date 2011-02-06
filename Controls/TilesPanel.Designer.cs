namespace GMare.Controls
{
    partial class TilesPanel
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
            // Dispose of tiles.
            if (_tiles != null)
            {
                // Iterate through tiles.
                foreach (System.Drawing.Bitmap tile in _tiles)
                {
                    // Get rid of tile.
                    if (tile != null)
                        tile.Dispose();
                }
            }

            // Dispose of the backbuffer.
            if (_backBuffer != null)
                _backBuffer.Dispose();

            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cms_Options = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_Deselect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_Options.SuspendLayout();
            this.SuspendLayout();
            // 
            // cms_Options
            // 
            this.cms_Options.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Deselect,
            this.tsmi_Clear});
            this.cms_Options.Name = "contextMenuStrip1";
            this.cms_Options.Size = new System.Drawing.Size(143, 70);
            // 
            // tsmi_Deselect
            // 
            this.tsmi_Deselect.Image = global::GMare.Properties.Resources.select_empty;
            this.tsmi_Deselect.Name = "tsmi_Deselect";
            this.tsmi_Deselect.Size = new System.Drawing.Size(142, 22);
            this.tsmi_Deselect.Text = "Deselect";
            // 
            // tsmi_Clear
            // 
            this.tsmi_Clear.Image = global::GMare.Properties.Resources.layer_empty;
            this.tsmi_Clear.Name = "tsmi_Clear";
            this.tsmi_Clear.Size = new System.Drawing.Size(142, 22);
            this.tsmi_Clear.Text = "Clear Tile(s)";
            // 
            // TilesPanel
            // 
            this.AllowDrop = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.cms_Options.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cms_Options;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Deselect;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Clear;
    }
}
