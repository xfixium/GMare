namespace GMare.Controls
{
    partial class GMareTileEditor
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
            // Dispose of tiles
            if (_tiles != null)
            {
                // Iterate through tiles
                foreach (System.Drawing.Bitmap tile in _tiles)
                {
                    // Get rid of tile
                    if (tile != null)
                        tile.Dispose();
                }
            }

            // If the tileset is not empty, dispose
            if (_tileSelection != null)
                _tileSelection.Dispose();

            // If the image attributes are not empty, dispose
            if (_atts != null)
                _atts.Dispose();

            // If the marching ants timer is not empty, dispose
            if (_antsTimer != null)
                _antsTimer.Dispose();

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
            this.mnuOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDeselect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuOptions
            // 
            this.mnuOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDeselect,
            this.mnuClear});
            this.mnuOptions.Name = "contextMenuStrip1";
            this.mnuOptions.Size = new System.Drawing.Size(161, 48);
            // 
            // mnuDeselect
            // 
            this.mnuDeselect.Image = global::GMare.Properties.Resources.selection_empty;
            this.mnuDeselect.Name = "mnuDeselect";
            this.mnuDeselect.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuDeselect.Size = new System.Drawing.Size(160, 22);
            this.mnuDeselect.Text = "Deselect";
            // 
            // mnuClear
            // 
            this.mnuClear.Image = global::GMare.Properties.Resources.layer_empty;
            this.mnuClear.Name = "mnuClear";
            this.mnuClear.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.mnuClear.Size = new System.Drawing.Size(160, 22);
            this.mnuClear.Text = "Clear Tile(s)";
            // 
            // GMareTileEditor
            // 
            this.AllowDrop = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.mnuOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip mnuOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuDeselect;
        private System.Windows.Forms.ToolStripMenuItem mnuClear;
    }
}
