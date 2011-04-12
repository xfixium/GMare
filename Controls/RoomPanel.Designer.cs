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
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_SelectionFlipHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SelectionFlipVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SelectionColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_SelectionBrush = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SelectionAddBrush = new System.Windows.Forms.ToolStripMenuItem();
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
            this.cms_BrushOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_BrushFlipHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_BrushFlipVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_BrushColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_BrushEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_BrushNone = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_SelectionOptions.SuspendLayout();
            this.cms_InstanceOptions.SuspendLayout();
            this.cms_BrushOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // cms_SelectionOptions
            // 
            this.cms_SelectionOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_SelectionCut,
            this.tsmi_SelectionCopy,
            this.tsmi_SelectionPaste,
            this.toolStripSeparator6,
            this.tsmi_SelectionFlipHorizontal,
            this.tsmi_SelectionFlipVertical,
            this.tsmi_SelectionColor,
            this.toolStripSeparator1,
            this.tsmi_SelectionBrush,
            this.tsmi_SelectionAddBrush,
            this.tsmi_SelectionDeselect,
            this.tsmi_SelectionDelete});
            this.cms_SelectionOptions.Name = "cms_SelectionOptions";
            this.cms_SelectionOptions.Size = new System.Drawing.Size(282, 236);
            // 
            // tsmi_SelectionCut
            // 
            this.tsmi_SelectionCut.Image = global::GMare.Properties.Resources.clipboard_cut;
            this.tsmi_SelectionCut.Name = "tsmi_SelectionCut";
            this.tsmi_SelectionCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.tsmi_SelectionCut.Size = new System.Drawing.Size(281, 22);
            this.tsmi_SelectionCut.Text = "Cut";
            // 
            // tsmi_SelectionCopy
            // 
            this.tsmi_SelectionCopy.Image = global::GMare.Properties.Resources.clipboard_copy;
            this.tsmi_SelectionCopy.Name = "tsmi_SelectionCopy";
            this.tsmi_SelectionCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsmi_SelectionCopy.Size = new System.Drawing.Size(281, 22);
            this.tsmi_SelectionCopy.Text = "Copy";
            // 
            // tsmi_SelectionPaste
            // 
            this.tsmi_SelectionPaste.Image = global::GMare.Properties.Resources.clipboard_paste;
            this.tsmi_SelectionPaste.Name = "tsmi_SelectionPaste";
            this.tsmi_SelectionPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.tsmi_SelectionPaste.Size = new System.Drawing.Size(281, 22);
            this.tsmi_SelectionPaste.Text = "Paste";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(278, 6);
            // 
            // tsmi_SelectionFlipHorizontal
            // 
            this.tsmi_SelectionFlipHorizontal.Image = global::GMare.Properties.Resources.flip_horizontal;
            this.tsmi_SelectionFlipHorizontal.Name = "tsmi_SelectionFlipHorizontal";
            this.tsmi_SelectionFlipHorizontal.ShortcutKeyDisplayString = "Right Arrow";
            this.tsmi_SelectionFlipHorizontal.Size = new System.Drawing.Size(281, 22);
            this.tsmi_SelectionFlipHorizontal.Text = "Flip Selection Horizontally";
            // 
            // tsmi_SelectionFlipVertical
            // 
            this.tsmi_SelectionFlipVertical.Image = global::GMare.Properties.Resources.flip_vertical;
            this.tsmi_SelectionFlipVertical.Name = "tsmi_SelectionFlipVertical";
            this.tsmi_SelectionFlipVertical.ShortcutKeyDisplayString = "Down Arrow";
            this.tsmi_SelectionFlipVertical.Size = new System.Drawing.Size(281, 22);
            this.tsmi_SelectionFlipVertical.Text = "Flip Selection Vertically";
            // 
            // tsmi_SelectionColor
            // 
            this.tsmi_SelectionColor.Image = global::GMare.Properties.Resources.color_swatch;
            this.tsmi_SelectionColor.Name = "tsmi_SelectionColor";
            this.tsmi_SelectionColor.Size = new System.Drawing.Size(281, 22);
            this.tsmi_SelectionColor.Text = "Change Blend Color";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(278, 6);
            // 
            // tsmi_SelectionBrush
            // 
            this.tsmi_SelectionBrush.Image = global::GMare.Properties.Resources.brush_fill;
            this.tsmi_SelectionBrush.Name = "tsmi_SelectionBrush";
            this.tsmi_SelectionBrush.Size = new System.Drawing.Size(281, 22);
            this.tsmi_SelectionBrush.Text = "Brush From Selection";
            // 
            // tsmi_SelectionAddBrush
            // 
            this.tsmi_SelectionAddBrush.Image = global::GMare.Properties.Resources.brush_add;
            this.tsmi_SelectionAddBrush.Name = "tsmi_SelectionAddBrush";
            this.tsmi_SelectionAddBrush.Size = new System.Drawing.Size(281, 22);
            this.tsmi_SelectionAddBrush.Text = "Save Brush From Selection";
            // 
            // tsmi_SelectionDeselect
            // 
            this.tsmi_SelectionDeselect.Image = global::GMare.Properties.Resources.selection_empty;
            this.tsmi_SelectionDeselect.Name = "tsmi_SelectionDeselect";
            this.tsmi_SelectionDeselect.Size = new System.Drawing.Size(281, 22);
            this.tsmi_SelectionDeselect.Text = "Deselect";
            // 
            // tsmi_SelectionDelete
            // 
            this.tsmi_SelectionDelete.Image = global::GMare.Properties.Resources.bin;
            this.tsmi_SelectionDelete.Name = "tsmi_SelectionDelete";
            this.tsmi_SelectionDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.tsmi_SelectionDelete.Size = new System.Drawing.Size(281, 22);
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
            this.tsmi_InstanceCut.ShortcutKeyDisplayString = "Ctrl + X";
            this.tsmi_InstanceCut.Size = new System.Drawing.Size(170, 22);
            this.tsmi_InstanceCut.Text = "Cut";
            // 
            // tsmi_InstanceCopy
            // 
            this.tsmi_InstanceCopy.Image = global::GMare.Properties.Resources.clipboard_copy;
            this.tsmi_InstanceCopy.Name = "tsmi_InstanceCopy";
            this.tsmi_InstanceCopy.ShortcutKeyDisplayString = "Ctrl + C";
            this.tsmi_InstanceCopy.Size = new System.Drawing.Size(170, 22);
            this.tsmi_InstanceCopy.Text = "Copy";
            // 
            // tsmi_InstancePaste
            // 
            this.tsmi_InstancePaste.Image = global::GMare.Properties.Resources.clipboard_paste;
            this.tsmi_InstancePaste.Name = "tsmi_InstancePaste";
            this.tsmi_InstancePaste.ShortcutKeyDisplayString = "Ctrl + V";
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
            this.tsmi_InstanceDelete.ShortcutKeyDisplayString = "Del";
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
            this.tsmi_InstanceClear.Image = global::GMare.Properties.Resources.layer_empty;
            this.tsmi_InstanceClear.Name = "tsmi_InstanceClear";
            this.tsmi_InstanceClear.Size = new System.Drawing.Size(170, 22);
            this.tsmi_InstanceClear.Text = "Clear All Instances";
            // 
            // cms_BrushOptions
            // 
            this.cms_BrushOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_BrushFlipHorizontal,
            this.tsmi_BrushFlipVertical,
            this.tsmi_BrushColor,
            this.toolStripSeparator4,
            this.tsmi_BrushEdit,
            this.tsmi_BrushNone});
            this.cms_BrushOptions.Name = "cns_BrushOptions";
            this.cms_BrushOptions.Size = new System.Drawing.Size(264, 120);
            this.cms_BrushOptions.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cms_BrushOptions_ItemClicked);
            // 
            // tsmi_BrushFlipHorizontal
            // 
            this.tsmi_BrushFlipHorizontal.Image = global::GMare.Properties.Resources.flip_horizontal;
            this.tsmi_BrushFlipHorizontal.Name = "tsmi_BrushFlipHorizontal";
            this.tsmi_BrushFlipHorizontal.ShortcutKeyDisplayString = "Right Arrow";
            this.tsmi_BrushFlipHorizontal.Size = new System.Drawing.Size(263, 22);
            this.tsmi_BrushFlipHorizontal.Text = "Flip Brush Horizontally";
            // 
            // tsmi_BrushFlipVertical
            // 
            this.tsmi_BrushFlipVertical.Image = global::GMare.Properties.Resources.flip_vertical;
            this.tsmi_BrushFlipVertical.Name = "tsmi_BrushFlipVertical";
            this.tsmi_BrushFlipVertical.ShortcutKeyDisplayString = "Down Arrow";
            this.tsmi_BrushFlipVertical.Size = new System.Drawing.Size(263, 22);
            this.tsmi_BrushFlipVertical.Text = "Flip Brush Vertically";
            // 
            // tsmi_BrushColor
            // 
            this.tsmi_BrushColor.Image = global::GMare.Properties.Resources.color_swatch;
            this.tsmi_BrushColor.Name = "tsmi_BrushColor";
            this.tsmi_BrushColor.Size = new System.Drawing.Size(263, 22);
            this.tsmi_BrushColor.Text = "Change Blend Color";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(260, 6);
            // 
            // tsmi_BrushEdit
            // 
            this.tsmi_BrushEdit.Image = global::GMare.Properties.Resources.brush_edit;
            this.tsmi_BrushEdit.Name = "tsmi_BrushEdit";
            this.tsmi_BrushEdit.Size = new System.Drawing.Size(263, 22);
            this.tsmi_BrushEdit.Text = "Edit Brushes";
            // 
            // tsmi_BrushNone
            // 
            this.tsmi_BrushNone.Enabled = false;
            this.tsmi_BrushNone.Image = global::GMare.Properties.Resources.slash;
            this.tsmi_BrushNone.Name = "tsmi_BrushNone";
            this.tsmi_BrushNone.Size = new System.Drawing.Size(263, 22);
            this.tsmi_BrushNone.Text = "<No Saved Brushes>";
            this.cms_SelectionOptions.ResumeLayout(false);
            this.cms_InstanceOptions.ResumeLayout(false);
            this.cms_BrushOptions.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem tsmi_SelectionBrush;
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
        private System.Windows.Forms.ToolStripMenuItem tsmi_SelectionAddBrush;
        private System.Windows.Forms.ContextMenuStrip cms_BrushOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmi_BrushEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmi_BrushNone;
        private System.Windows.Forms.ToolStripMenuItem tsmi_BrushFlipHorizontal;
        private System.Windows.Forms.ToolStripMenuItem tsmi_BrushFlipVertical;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SelectionFlipHorizontal;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SelectionFlipVertical;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SelectionColor;
        private System.Windows.Forms.ToolStripMenuItem tsmi_BrushColor;
    }
}
