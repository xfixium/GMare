namespace GMare.Controls
{
    partial class GMareRoomPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GMareRoomPanel));
            this.mnuSelectionOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSelectionCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectionCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectionPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeperator01 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSelectionFlipHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectionFlipVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectionColor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeperator02 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSelectionBrush = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectionAddBrush = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectionDeselect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectionDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInstanceOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuInstanceReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInstanceReplaceAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeperator03 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInstanceCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInstanceCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInstancePaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeperator04 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInstancePosition = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInstanceBringFront = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInstanceSendBack = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInstanceSnap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInstanceCode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeperator05 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInstanceDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInstanceDeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInstanceClear = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBrushOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuBrushFlipHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBrushFlipVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBrushColor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeperator06 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBrushEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBrushNone = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectionOptions.SuspendLayout();
            this.mnuInstanceOptions.SuspendLayout();
            this.mnuBrushOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuSelectionOptions
            // 
            this.mnuSelectionOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSelectionCut,
            this.mnuSelectionCopy,
            this.mnuSelectionPaste,
            this.mnuSeperator01,
            this.mnuSelectionFlipHorizontal,
            this.mnuSelectionFlipVertical,
            this.mnuSelectionColor,
            this.mnuSeperator02,
            this.mnuSelectionBrush,
            this.mnuSelectionAddBrush,
            this.mnuSelectionDeselect,
            this.mnuSelectionDelete});
            this.mnuSelectionOptions.Name = "cms_SelectionOptions";
            this.mnuSelectionOptions.Size = new System.Drawing.Size(282, 236);
            // 
            // mnuSelectionCut
            // 
            this.mnuSelectionCut.Image = global::GMare.Properties.Resources.clipboard_cut;
            this.mnuSelectionCut.Name = "mnuSelectionCut";
            this.mnuSelectionCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuSelectionCut.Size = new System.Drawing.Size(281, 22);
            this.mnuSelectionCut.Text = "Cut";
            // 
            // mnuSelectionCopy
            // 
            this.mnuSelectionCopy.Image = global::GMare.Properties.Resources.clipboard_copy;
            this.mnuSelectionCopy.Name = "mnuSelectionCopy";
            this.mnuSelectionCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuSelectionCopy.Size = new System.Drawing.Size(281, 22);
            this.mnuSelectionCopy.Text = "Copy";
            // 
            // mnuSelectionPaste
            // 
            this.mnuSelectionPaste.Image = global::GMare.Properties.Resources.clipboard_paste;
            this.mnuSelectionPaste.Name = "mnuSelectionPaste";
            this.mnuSelectionPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuSelectionPaste.Size = new System.Drawing.Size(281, 22);
            this.mnuSelectionPaste.Text = "Paste";
            // 
            // mnuSeperator01
            // 
            this.mnuSeperator01.Name = "mnuSeperator01";
            this.mnuSeperator01.Size = new System.Drawing.Size(278, 6);
            // 
            // mnuSelectionFlipHorizontal
            // 
            this.mnuSelectionFlipHorizontal.Image = global::GMare.Properties.Resources.flip_horizontal;
            this.mnuSelectionFlipHorizontal.Name = "mnuSelectionFlipHorizontal";
            this.mnuSelectionFlipHorizontal.ShortcutKeyDisplayString = "Right Arrow";
            this.mnuSelectionFlipHorizontal.Size = new System.Drawing.Size(281, 22);
            this.mnuSelectionFlipHorizontal.Text = "Flip Selection Horizontally";
            // 
            // mnuSelectionFlipVertical
            // 
            this.mnuSelectionFlipVertical.Image = global::GMare.Properties.Resources.flip_vertical;
            this.mnuSelectionFlipVertical.Name = "mnuSelectionFlipVertical";
            this.mnuSelectionFlipVertical.ShortcutKeyDisplayString = "Down Arrow";
            this.mnuSelectionFlipVertical.Size = new System.Drawing.Size(281, 22);
            this.mnuSelectionFlipVertical.Text = "Flip Selection Vertically";
            // 
            // mnuSelectionColor
            // 
            this.mnuSelectionColor.Image = global::GMare.Properties.Resources.color_swatch;
            this.mnuSelectionColor.Name = "mnuSelectionColor";
            this.mnuSelectionColor.Size = new System.Drawing.Size(281, 22);
            this.mnuSelectionColor.Text = "Change Blend Color";
            // 
            // mnuSeperator02
            // 
            this.mnuSeperator02.Name = "mnuSeperator02";
            this.mnuSeperator02.Size = new System.Drawing.Size(278, 6);
            // 
            // mnuSelectionBrush
            // 
            this.mnuSelectionBrush.Image = global::GMare.Properties.Resources.brush_fill;
            this.mnuSelectionBrush.Name = "mnuSelectionBrush";
            this.mnuSelectionBrush.Size = new System.Drawing.Size(281, 22);
            this.mnuSelectionBrush.Text = "Brush From Selection";
            // 
            // mnuSelectionAddBrush
            // 
            this.mnuSelectionAddBrush.Image = global::GMare.Properties.Resources.brush_add;
            this.mnuSelectionAddBrush.Name = "mnuSelectionAddBrush";
            this.mnuSelectionAddBrush.Size = new System.Drawing.Size(281, 22);
            this.mnuSelectionAddBrush.Text = "Save Brush From Selection";
            // 
            // mnuSelectionDeselect
            // 
            this.mnuSelectionDeselect.Image = global::GMare.Properties.Resources.selection_empty;
            this.mnuSelectionDeselect.Name = "mnuSelectionDeselect";
            this.mnuSelectionDeselect.Size = new System.Drawing.Size(281, 22);
            this.mnuSelectionDeselect.Text = "Deselect";
            // 
            // mnuSelectionDelete
            // 
            this.mnuSelectionDelete.Image = global::GMare.Properties.Resources.bin;
            this.mnuSelectionDelete.Name = "mnuSelectionDelete";
            this.mnuSelectionDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.mnuSelectionDelete.Size = new System.Drawing.Size(281, 22);
            this.mnuSelectionDelete.Text = "Delete";
            // 
            // mnuInstanceOptions
            // 
            this.mnuInstanceOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInstanceReplace,
            this.mnuInstanceReplaceAll,
            this.mnuSeperator03,
            this.mnuInstanceCut,
            this.mnuInstanceCopy,
            this.mnuInstancePaste,
            this.mnuSeperator04,
            this.mnuInstancePosition,
            this.mnuInstanceBringFront,
            this.mnuInstanceSendBack,
            this.mnuInstanceSnap,
            this.mnuInstanceCode,
            this.mnuSeperator05,
            this.mnuInstanceDelete,
            this.mnuInstanceDeleteAll,
            this.mnuInstanceClear});
            this.mnuInstanceOptions.Name = "cms_InstanceOptions";
            this.mnuInstanceOptions.Size = new System.Drawing.Size(171, 308);
            this.mnuInstanceOptions.Opening += new System.ComponentModel.CancelEventHandler(this.mnuInstanceOptions_Opening);
            // 
            // mnuInstanceReplace
            // 
            this.mnuInstanceReplace.Image = global::GMare.Properties.Resources.arrow_switch;
            this.mnuInstanceReplace.Name = "mnuInstanceReplace";
            this.mnuInstanceReplace.Size = new System.Drawing.Size(170, 22);
            this.mnuInstanceReplace.Text = "Instance Replace";
            // 
            // mnuInstanceReplaceAll
            // 
            this.mnuInstanceReplaceAll.Image = global::GMare.Properties.Resources.instance_replace;
            this.mnuInstanceReplaceAll.Name = "mnuInstanceReplaceAll";
            this.mnuInstanceReplaceAll.Size = new System.Drawing.Size(170, 22);
            this.mnuInstanceReplaceAll.Text = "Replace All";
            // 
            // mnuSeperator03
            // 
            this.mnuSeperator03.Name = "mnuSeperator03";
            this.mnuSeperator03.Size = new System.Drawing.Size(167, 6);
            // 
            // mnuInstanceCut
            // 
            this.mnuInstanceCut.Image = global::GMare.Properties.Resources.clipboard_cut;
            this.mnuInstanceCut.Name = "mnuInstanceCut";
            this.mnuInstanceCut.ShortcutKeyDisplayString = "Ctrl + X";
            this.mnuInstanceCut.Size = new System.Drawing.Size(170, 22);
            this.mnuInstanceCut.Text = "Cut";
            // 
            // mnuInstanceCopy
            // 
            this.mnuInstanceCopy.Image = global::GMare.Properties.Resources.clipboard_copy;
            this.mnuInstanceCopy.Name = "mnuInstanceCopy";
            this.mnuInstanceCopy.ShortcutKeyDisplayString = "Ctrl + C";
            this.mnuInstanceCopy.Size = new System.Drawing.Size(170, 22);
            this.mnuInstanceCopy.Text = "Copy";
            // 
            // mnuInstancePaste
            // 
            this.mnuInstancePaste.Image = global::GMare.Properties.Resources.clipboard_paste;
            this.mnuInstancePaste.Name = "mnuInstancePaste";
            this.mnuInstancePaste.ShortcutKeyDisplayString = "Ctrl + V";
            this.mnuInstancePaste.Size = new System.Drawing.Size(170, 22);
            this.mnuInstancePaste.Text = "Paste";
            // 
            // mnuSeperator04
            // 
            this.mnuSeperator04.Name = "mnuSeperator04";
            this.mnuSeperator04.Size = new System.Drawing.Size(167, 6);
            // 
            // mnuInstancePosition
            // 
            this.mnuInstancePosition.Image = global::GMare.Properties.Resources.instance_position;
            this.mnuInstancePosition.Name = "mnuInstancePosition";
            this.mnuInstancePosition.Size = new System.Drawing.Size(170, 22);
            this.mnuInstancePosition.Text = "Change Position...";
            // 
            // mnuInstanceBringFront
            // 
            this.mnuInstanceBringFront.Image = global::GMare.Properties.Resources.bring_to_front;
            this.mnuInstanceBringFront.Name = "mnuInstanceBringFront";
            this.mnuInstanceBringFront.Size = new System.Drawing.Size(170, 22);
            this.mnuInstanceBringFront.Text = "Bring To Front";
            // 
            // mnuInstanceSendBack
            // 
            this.mnuInstanceSendBack.Image = global::GMare.Properties.Resources.send_to_back;
            this.mnuInstanceSendBack.Name = "mnuInstanceSendBack";
            this.mnuInstanceSendBack.Size = new System.Drawing.Size(170, 22);
            this.mnuInstanceSendBack.Text = "Send To Back";
            // 
            // mnuInstanceSnap
            // 
            this.mnuInstanceSnap.Image = ((System.Drawing.Image)(resources.GetObject("mnuInstanceSnap.Image")));
            this.mnuInstanceSnap.Name = "mnuInstanceSnap";
            this.mnuInstanceSnap.Size = new System.Drawing.Size(170, 22);
            this.mnuInstanceSnap.Text = "Snap To Grid";
            // 
            // mnuInstanceCode
            // 
            this.mnuInstanceCode.Image = global::GMare.Properties.Resources.script;
            this.mnuInstanceCode.Name = "mnuInstanceCode";
            this.mnuInstanceCode.Size = new System.Drawing.Size(170, 22);
            this.mnuInstanceCode.Text = "Creation Code...";
            // 
            // mnuSeperator05
            // 
            this.mnuSeperator05.Name = "mnuSeperator05";
            this.mnuSeperator05.Size = new System.Drawing.Size(167, 6);
            // 
            // mnuInstanceDelete
            // 
            this.mnuInstanceDelete.Image = global::GMare.Properties.Resources.delete;
            this.mnuInstanceDelete.Name = "mnuInstanceDelete";
            this.mnuInstanceDelete.ShortcutKeyDisplayString = "Del";
            this.mnuInstanceDelete.Size = new System.Drawing.Size(170, 22);
            this.mnuInstanceDelete.Text = "Delete";
            // 
            // mnuInstanceDeleteAll
            // 
            this.mnuInstanceDeleteAll.Image = global::GMare.Properties.Resources.button_decline;
            this.mnuInstanceDeleteAll.Name = "mnuInstanceDeleteAll";
            this.mnuInstanceDeleteAll.Size = new System.Drawing.Size(170, 22);
            this.mnuInstanceDeleteAll.Text = "Delete All";
            // 
            // mnuInstanceClear
            // 
            this.mnuInstanceClear.Image = global::GMare.Properties.Resources.bin;
            this.mnuInstanceClear.Name = "mnuInstanceClear";
            this.mnuInstanceClear.Size = new System.Drawing.Size(170, 22);
            this.mnuInstanceClear.Text = "Clear All Instances";
            // 
            // mnuBrushOptions
            // 
            this.mnuBrushOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBrushFlipHorizontal,
            this.mnuBrushFlipVertical,
            this.mnuBrushColor,
            this.mnuSeperator06,
            this.mnuBrushEdit,
            this.mnuBrushNone});
            this.mnuBrushOptions.Name = "cns_BrushOptions";
            this.mnuBrushOptions.Size = new System.Drawing.Size(264, 120);
            this.mnuBrushOptions.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuBrushOptions_ItemClicked);
            // 
            // mnuBrushFlipHorizontal
            // 
            this.mnuBrushFlipHorizontal.Image = global::GMare.Properties.Resources.flip_horizontal;
            this.mnuBrushFlipHorizontal.Name = "mnuBrushFlipHorizontal";
            this.mnuBrushFlipHorizontal.ShortcutKeyDisplayString = "Right Arrow";
            this.mnuBrushFlipHorizontal.Size = new System.Drawing.Size(263, 22);
            this.mnuBrushFlipHorizontal.Text = "Flip Brush Horizontally";
            // 
            // mnuBrushFlipVertical
            // 
            this.mnuBrushFlipVertical.Image = global::GMare.Properties.Resources.flip_vertical;
            this.mnuBrushFlipVertical.Name = "mnuBrushFlipVertical";
            this.mnuBrushFlipVertical.ShortcutKeyDisplayString = "Down Arrow";
            this.mnuBrushFlipVertical.Size = new System.Drawing.Size(263, 22);
            this.mnuBrushFlipVertical.Text = "Flip Brush Vertically";
            // 
            // mnuBrushColor
            // 
            this.mnuBrushColor.Image = global::GMare.Properties.Resources.color_swatch;
            this.mnuBrushColor.Name = "mnuBrushColor";
            this.mnuBrushColor.Size = new System.Drawing.Size(263, 22);
            this.mnuBrushColor.Text = "Change Blend Color";
            // 
            // mnuSeperator06
            // 
            this.mnuSeperator06.Name = "mnuSeperator06";
            this.mnuSeperator06.Size = new System.Drawing.Size(260, 6);
            // 
            // mnuBrushEdit
            // 
            this.mnuBrushEdit.Image = global::GMare.Properties.Resources.brush_edit;
            this.mnuBrushEdit.Name = "mnuBrushEdit";
            this.mnuBrushEdit.Size = new System.Drawing.Size(263, 22);
            this.mnuBrushEdit.Text = "Edit Brushes";
            // 
            // mnuBrushNone
            // 
            this.mnuBrushNone.Enabled = false;
            this.mnuBrushNone.Image = global::GMare.Properties.Resources.slash;
            this.mnuBrushNone.Name = "mnuBrushNone";
            this.mnuBrushNone.Size = new System.Drawing.Size(263, 22);
            this.mnuBrushNone.Text = "<No Saved Brushes>";
            this.mnuSelectionOptions.ResumeLayout(false);
            this.mnuInstanceOptions.ResumeLayout(false);
            this.mnuBrushOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip mnuSelectionOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectionCut;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectionCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectionPaste;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectionDelete;
        private System.Windows.Forms.ToolStripSeparator mnuSeperator02;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectionDeselect;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectionBrush;
        private System.Windows.Forms.ContextMenuStrip mnuInstanceOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuInstanceCut;
        private System.Windows.Forms.ToolStripMenuItem mnuInstanceCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuInstancePaste;
        private System.Windows.Forms.ToolStripSeparator mnuSeperator04;
        private System.Windows.Forms.ToolStripMenuItem mnuInstanceBringFront;
        private System.Windows.Forms.ToolStripMenuItem mnuInstanceSendBack;
        private System.Windows.Forms.ToolStripMenuItem mnuInstanceSnap;
        private System.Windows.Forms.ToolStripMenuItem mnuInstanceCode;
        private System.Windows.Forms.ToolStripSeparator mnuSeperator05;
        private System.Windows.Forms.ToolStripMenuItem mnuInstanceDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuInstanceDeleteAll;
        private System.Windows.Forms.ToolStripMenuItem mnuInstanceClear;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectionAddBrush;
        private System.Windows.Forms.ContextMenuStrip mnuBrushOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuBrushEdit;
        private System.Windows.Forms.ToolStripSeparator mnuSeperator06;
        private System.Windows.Forms.ToolStripMenuItem mnuBrushNone;
        private System.Windows.Forms.ToolStripMenuItem mnuBrushFlipHorizontal;
        private System.Windows.Forms.ToolStripMenuItem mnuBrushFlipVertical;
        private System.Windows.Forms.ToolStripSeparator mnuSeperator01;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectionFlipHorizontal;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectionFlipVertical;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectionColor;
        private System.Windows.Forms.ToolStripMenuItem mnuBrushColor;
        private System.Windows.Forms.ToolStripMenuItem mnuInstanceReplace;
        private System.Windows.Forms.ToolStripMenuItem mnuInstanceReplaceAll;
        private System.Windows.Forms.ToolStripSeparator mnuSeperator03;
        private System.Windows.Forms.ToolStripMenuItem mnuInstancePosition;
    }
}
