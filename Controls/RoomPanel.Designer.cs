namespace GMare.Controls
{
    partial class RoomPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomPanel));
            this.cms_SelectionOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_SelectionCut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SelectionCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SelectionPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_SelectionFill = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SelectionDeselect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SelectionDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_InstanceOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_InstanceCut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_InstanceCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_InstancePaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_InstanceSendFront = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_InstanceSendBack = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_InstanceSnap = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_InstanceCode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_InstanceDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_InstanceDeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_InstanceClear = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_SelectionOptions.SuspendLayout();
            this.cms_InstanceOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // cms_SelectionOptions
            // 
            this.cms_SelectionOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_SelectionCut,
            this.tsmi_SelectionCopy,
            this.tsmi_SelectionPaste,
            this.toolStripSeparator1,
            this.tsmi_SelectionFill,
            this.tsmi_SelectionDeselect,
            this.tsmi_SelectionDelete});
            this.cms_SelectionOptions.Name = "cms_SelectionOptions";
            this.cms_SelectionOptions.Size = new System.Drawing.Size(145, 120);
            // 
            // tsmi_SelectionCut
            // 
            this.tsmi_SelectionCut.Image = global::GMare.Properties.Resources.clipboard_cut;
            this.tsmi_SelectionCut.Name = "tsmi_SelectionCut";
            this.tsmi_SelectionCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.tsmi_SelectionCut.Size = new System.Drawing.Size(144, 22);
            this.tsmi_SelectionCut.Text = "Cut";
            // 
            // tsmi_SelectionCopy
            // 
            this.tsmi_SelectionCopy.Image = global::GMare.Properties.Resources.clipboard_copy;
            this.tsmi_SelectionCopy.Name = "tsmi_SelectionCopy";
            this.tsmi_SelectionCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsmi_SelectionCopy.Size = new System.Drawing.Size(144, 22);
            this.tsmi_SelectionCopy.Text = "Copy";
            // 
            // tsmi_SelectionPaste
            // 
            this.tsmi_SelectionPaste.Image = global::GMare.Properties.Resources.clipboard_paste;
            this.tsmi_SelectionPaste.Name = "tsmi_SelectionPaste";
            this.tsmi_SelectionPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.tsmi_SelectionPaste.Size = new System.Drawing.Size(144, 22);
            this.tsmi_SelectionPaste.Text = "Paste";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // tsmi_SelectionFill
            // 
            this.tsmi_SelectionFill.Image = global::GMare.Properties.Resources.tool_fill;
            this.tsmi_SelectionFill.Name = "tsmi_SelectionFill";
            this.tsmi_SelectionFill.Size = new System.Drawing.Size(144, 22);
            this.tsmi_SelectionFill.Text = "Flood Fill";
            // 
            // tsmi_SelectionDeselect
            // 
            this.tsmi_SelectionDeselect.Image = global::GMare.Properties.Resources.selection;
            this.tsmi_SelectionDeselect.Name = "tsmi_SelectionDeselect";
            this.tsmi_SelectionDeselect.Size = new System.Drawing.Size(144, 22);
            this.tsmi_SelectionDeselect.Text = "Deselect";
            // 
            // tsmi_SelectionDelete
            // 
            this.tsmi_SelectionDelete.Image = global::GMare.Properties.Resources.bin;
            this.tsmi_SelectionDelete.Name = "tsmi_SelectionDelete";
            this.tsmi_SelectionDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.tsmi_SelectionDelete.Size = new System.Drawing.Size(144, 22);
            this.tsmi_SelectionDelete.Text = "Delete";
            // 
            // cms_InstanceOptions
            // 
            this.cms_InstanceOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_InstanceCut,
            this.tsmi_InstanceCopy,
            this.tsmi_InstancePaste,
            this.toolStripSeparator2,
            this.tsmi_InstanceSendFront,
            this.tsmi_InstanceSendBack,
            this.tsmi_InstanceSnap,
            this.tsmi_InstanceCode,
            this.toolStripSeparator3,
            this.tsmi_InstanceDelete,
            this.tsmi_InstanceDeleteAll,
            this.tsmi_InstanceClear});
            this.cms_InstanceOptions.Name = "cms_InstanceOptions";
            this.cms_InstanceOptions.Size = new System.Drawing.Size(171, 236);
            // 
            // tsmi_InstanceCut
            // 
            this.tsmi_InstanceCut.Image = global::GMare.Properties.Resources.clipboard_cut;
            this.tsmi_InstanceCut.Name = "tsmi_InstanceCut";
            this.tsmi_InstanceCut.Size = new System.Drawing.Size(170, 22);
            this.tsmi_InstanceCut.Text = "Cut";
            // 
            // tsmi_InstanceCopy
            // 
            this.tsmi_InstanceCopy.Image = global::GMare.Properties.Resources.clipboard_copy;
            this.tsmi_InstanceCopy.Name = "tsmi_InstanceCopy";
            this.tsmi_InstanceCopy.Size = new System.Drawing.Size(170, 22);
            this.tsmi_InstanceCopy.Text = "Copy";
            // 
            // tsmi_InstancePaste
            // 
            this.tsmi_InstancePaste.Image = global::GMare.Properties.Resources.clipboard_paste;
            this.tsmi_InstancePaste.Name = "tsmi_InstancePaste";
            this.tsmi_InstancePaste.Size = new System.Drawing.Size(170, 22);
            this.tsmi_InstancePaste.Text = "Paste";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(167, 6);
            // 
            // tsmi_InstanceSendFront
            // 
            this.tsmi_InstanceSendFront.Image = global::GMare.Properties.Resources.sort_up;
            this.tsmi_InstanceSendFront.Name = "tsmi_InstanceSendFront";
            this.tsmi_InstanceSendFront.Size = new System.Drawing.Size(170, 22);
            this.tsmi_InstanceSendFront.Text = "Bring To Front";
            // 
            // tsmi_InstanceSendBack
            // 
            this.tsmi_InstanceSendBack.Image = global::GMare.Properties.Resources.sort_down;
            this.tsmi_InstanceSendBack.Name = "tsmi_InstanceSendBack";
            this.tsmi_InstanceSendBack.Size = new System.Drawing.Size(170, 22);
            this.tsmi_InstanceSendBack.Text = "Send To Back";
            // 
            // tsmi_InstanceSnap
            // 
            this.tsmi_InstanceSnap.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_InstanceSnap.Image")));
            this.tsmi_InstanceSnap.Name = "tsmi_InstanceSnap";
            this.tsmi_InstanceSnap.Size = new System.Drawing.Size(170, 22);
            this.tsmi_InstanceSnap.Text = "Snap To Grid";
            // 
            // tsmi_InstanceCode
            // 
            this.tsmi_InstanceCode.Image = global::GMare.Properties.Resources.script;
            this.tsmi_InstanceCode.Name = "tsmi_InstanceCode";
            this.tsmi_InstanceCode.Size = new System.Drawing.Size(170, 22);
            this.tsmi_InstanceCode.Text = "Creation Code...";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(167, 6);
            // 
            // tsmi_InstanceDelete
            // 
            this.tsmi_InstanceDelete.Image = global::GMare.Properties.Resources.delete;
            this.tsmi_InstanceDelete.Name = "tsmi_InstanceDelete";
            this.tsmi_InstanceDelete.Size = new System.Drawing.Size(170, 22);
            this.tsmi_InstanceDelete.Text = "Delete";
            // 
            // tsmi_InstanceDeleteAll
            // 
            this.tsmi_InstanceDeleteAll.Image = global::GMare.Properties.Resources.button_decline;
            this.tsmi_InstanceDeleteAll.Name = "tsmi_InstanceDeleteAll";
            this.tsmi_InstanceDeleteAll.Size = new System.Drawing.Size(170, 22);
            this.tsmi_InstanceDeleteAll.Text = "Delete All";
            // 
            // tsmi_InstanceClear
            // 
            this.tsmi_InstanceClear.Name = "tsmi_InstanceClear";
            this.tsmi_InstanceClear.Size = new System.Drawing.Size(170, 22);
            this.tsmi_InstanceClear.Text = "Clear All Instances";
            this.cms_SelectionOptions.ResumeLayout(false);
            this.cms_InstanceOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cms_SelectionOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SelectionCut;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SelectionCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SelectionPaste;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SelectionDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SelectionDeselect;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SelectionFill;
        private System.Windows.Forms.ContextMenuStrip cms_InstanceOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmi_InstanceCut;
        private System.Windows.Forms.ToolStripMenuItem tsmi_InstanceCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmi_InstancePaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_InstanceSendFront;
        private System.Windows.Forms.ToolStripMenuItem tsmi_InstanceSendBack;
        private System.Windows.Forms.ToolStripMenuItem tsmi_InstanceSnap;
        private System.Windows.Forms.ToolStripMenuItem tsmi_InstanceCode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmi_InstanceDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmi_InstanceDeleteAll;
        private System.Windows.Forms.ToolStripMenuItem tsmi_InstanceClear;
    }
}
