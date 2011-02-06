namespace GMare.Controls
{
    partial class ZoomToolStripButton
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
            this.tsmi_ZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_100 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_200 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_300 = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // tsmi_ZoomIn
            // 
            this.tsmi_ZoomIn.Image = global::GMare.Properties.Resources.magnifier_zoom_in;
            this.tsmi_ZoomIn.Name = "tsmi_ZoomIn";
            this.tsmi_ZoomIn.ShortcutKeyDisplayString = "Ctrl +";
            this.tsmi_ZoomIn.Size = new System.Drawing.Size(163, 22);
            this.tsmi_ZoomIn.Text = "Zoom In";
            // 
            // tsmi_ZoomOut
            // 
            this.tsmi_ZoomOut.Image = global::GMare.Properties.Resources.magifier_zoom_out;
            this.tsmi_ZoomOut.Name = "tsmi_ZoomOut";
            this.tsmi_ZoomOut.ShortcutKeyDisplayString = "Ctrl -";
            this.tsmi_ZoomOut.Size = new System.Drawing.Size(163, 22);
            this.tsmi_ZoomOut.Text = "Zoom Out";
            // 
            // tsmi_Separator1
            // 
            this.tsmi_Separator1.Name = "tsmi_Separator1";
            this.tsmi_Separator1.Size = new System.Drawing.Size(160, 6);
            // 
            // tsmi_100
            // 
            this.tsmi_100.Checked = true;
            this.tsmi_100.CheckOnClick = true;
            this.tsmi_100.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmi_100.Name = "tsmi_100";
            this.tsmi_100.Size = new System.Drawing.Size(163, 22);
            this.tsmi_100.Text = "100%";
            // 
            // tsmi_200
            // 
            this.tsmi_200.CheckOnClick = true;
            this.tsmi_200.Name = "tsmi_200";
            this.tsmi_200.Size = new System.Drawing.Size(163, 22);
            this.tsmi_200.Text = "200%";
            // 
            // tsmi_300
            // 
            this.tsmi_300.CheckOnClick = true;
            this.tsmi_300.Name = "tsmi_300";
            this.tsmi_300.Size = new System.Drawing.Size(163, 22);
            this.tsmi_300.Text = "300%";
            // 
            // ZoomToolStripButton
            // 
            this.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_ZoomIn,
            this.tsmi_ZoomOut,
            this.tsmi_Separator1,
            this.tsmi_100,
            this.tsmi_200,
            this.tsmi_300});
            this.Image = global::GMare.Properties.Resources.magnifier;
            this.Text = "100%";

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmi_ZoomIn;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ZoomOut;
        private System.Windows.Forms.ToolStripSeparator tsmi_Separator1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_100;
        private System.Windows.Forms.ToolStripMenuItem tsmi_200;
        private System.Windows.Forms.ToolStripMenuItem tsmi_300;
    }
}
