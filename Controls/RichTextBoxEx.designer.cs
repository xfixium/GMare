namespace GMare.Controls
{
    partial class RichTextBoxEx
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cms_Main = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // cms_Main
            // 
            this.cms_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Copy,
            this.tsmi_SelectAll});
            this.cms_Main.Name = "contextMenuStrip1";
            this.cms_Main.Size = new System.Drawing.Size(157, 48);
            // 
            // tsmi_Copy
            // 
            this.tsmi_Copy.Image = global::GMare.Properties.Resources.clipboard_copy;
            this.tsmi_Copy.Name = "tsmi_Copy";
            this.tsmi_Copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsmi_Copy.Size = new System.Drawing.Size(156, 22);
            this.tsmi_Copy.Text = "Copy";
            this.tsmi_Copy.Click += new System.EventHandler(this.tsmi_Copy_Click);
            // 
            // tsmi_SelectAll
            // 
            this.tsmi_SelectAll.Image = global::GMare.Properties.Resources.select_all;
            this.tsmi_SelectAll.Name = "tsmi_SelectAll";
            this.tsmi_SelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.tsmi_SelectAll.Size = new System.Drawing.Size(156, 22);
            this.tsmi_SelectAll.Text = "Select All";
            this.tsmi_SelectAll.Click += new System.EventHandler(this.tsmi_SelectAll_Click);
            // 
            // RichTextBoxEx
            // 
            this.ContextMenuStrip = this.cms_Main;
            this.cms_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cms_Main;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Copy;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SelectAll;
    }
}
