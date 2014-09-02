namespace GMare.Forms
{
    partial class ExportImageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportImageForm));
            this.tipMain = new System.Windows.Forms.ToolTip(this.components);
            this.lstLayers = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckedListBox();
            this.grpMain = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.butCancel = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butExport = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butCheckAll = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butDrawInstances = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.grpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstLayers
            // 
            this.lstLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLayers.CheckBoxCheckedImage = null;
            this.lstLayers.CheckBoxImageOffsetX = 0;
            this.lstLayers.CheckBoxImageOffsetY = 0;
            this.lstLayers.CheckBoxUnCheckedImage = null;
            this.lstLayers.DisplayFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lstLayers.EmptyListText = "Layers";
            this.lstLayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lstLayers.FormattingEnabled = true;
            this.lstLayers.Glyph = global::GMare.Properties.Resources.layer;
            this.lstLayers.GlyphOffsetX = 0;
            this.lstLayers.GlyphOffsetY = 0;
            this.lstLayers.HorizontalExtent = 276;
            this.lstLayers.IntegralHeight = false;
            this.lstLayers.Location = new System.Drawing.Point(12, 32);
            this.lstLayers.Name = "lstLayers";
            this.lstLayers.RowHeight = 17;
            this.lstLayers.Size = new System.Drawing.Size(280, 264);
            this.lstLayers.TabIndex = 0;
            this.lstLayers.TextOffsetX = 0;
            this.lstLayers.TextOffsetY = 0;
            this.lstLayers.ToolTipText = "";
            this.lstLayers.ToolTipTitle = "";
            // 
            // grpMain
            // 
            this.grpMain.BackColor = System.Drawing.Color.Transparent;
            this.grpMain.Controls.Add(this.lstLayers);
            this.grpMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMain.Location = new System.Drawing.Point(4, 32);
            this.grpMain.Name = "grpMain";
            this.grpMain.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpMain.Size = new System.Drawing.Size(304, 308);
            this.grpMain.TabIndex = 4;
            this.grpMain.TabStop = false;
            this.grpMain.Text = "Layers To Export";
            this.grpMain.TextBarHeight = 24;
            // 
            // butCancel
            // 
            this.butCancel.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butCancel.Checked = false;
            this.butCancel.FlatStyled = false;
            this.butCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.ImageXOffset = 0;
            this.butCancel.ImageYOffset = 0;
            this.butCancel.Location = new System.Drawing.Point(32, 4);
            this.butCancel.Name = "butCancel";
            this.butCancel.PushButtonImage = null;
            this.butCancel.Size = new System.Drawing.Size(24, 24);
            this.butCancel.TabIndex = 1;
            this.butCancel.TextXOffset = 0;
            this.butCancel.TextYOffset = 0;
            this.butCancel.ToolTipText = "Cancel image export";
            this.butCancel.ToolTipTitle = "Cancel";
            this.butCancel.UseDropShadow = true;
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butExport
            // 
            this.butExport.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butExport.Checked = false;
            this.butExport.FlatStyled = false;
            this.butExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butExport.Image = global::GMare.Properties.Resources.save;
            this.butExport.ImageXOffset = 0;
            this.butExport.ImageYOffset = 0;
            this.butExport.Location = new System.Drawing.Point(8, 4);
            this.butExport.Name = "butExport";
            this.butExport.PushButtonImage = null;
            this.butExport.Size = new System.Drawing.Size(24, 24);
            this.butExport.TabIndex = 0;
            this.butExport.TextXOffset = 0;
            this.butExport.TextYOffset = 0;
            this.butExport.ToolTipText = "Export the selected layers to an image file";
            this.butExport.ToolTipTitle = "Export To Image";
            this.butExport.UseDropShadow = true;
            this.butExport.UseVisualStyleBackColor = true;
            this.butExport.Click += new System.EventHandler(this.butExport_Click);
            // 
            // butCheckAll
            // 
            this.butCheckAll.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.PushButton;
            this.butCheckAll.Checked = false;
            this.butCheckAll.FlatStyled = false;
            this.butCheckAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCheckAll.Image = global::GMare.Properties.Resources.check_list;
            this.butCheckAll.ImageXOffset = 0;
            this.butCheckAll.ImageYOffset = 0;
            this.butCheckAll.Location = new System.Drawing.Point(56, 4);
            this.butCheckAll.Name = "butCheckAll";
            this.butCheckAll.PushButtonImage = null;
            this.butCheckAll.Size = new System.Drawing.Size(24, 24);
            this.butCheckAll.TabIndex = 2;
            this.butCheckAll.TextXOffset = 0;
            this.butCheckAll.TextYOffset = 0;
            this.butCheckAll.ToolTipText = "Check or uncheck all layers for export";
            this.butCheckAll.ToolTipTitle = "Check/Uncheck All Layers";
            this.butCheckAll.UseDropShadow = true;
            this.butCheckAll.UseVisualStyleBackColor = true;
            this.butCheckAll.CheckChanged += new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.CheckChangedEventHandler(this.butCheckAll_CheckChanged);
            // 
            // butDrawInstances
            // 
            this.butDrawInstances.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.PushButton;
            this.butDrawInstances.Checked = false;
            this.butDrawInstances.FlatStyled = false;
            this.butDrawInstances.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butDrawInstances.Image = global::GMare.Properties.Resources.show_instances;
            this.butDrawInstances.ImageXOffset = 0;
            this.butDrawInstances.ImageYOffset = 0;
            this.butDrawInstances.Location = new System.Drawing.Point(80, 4);
            this.butDrawInstances.Name = "butDrawInstances";
            this.butDrawInstances.PushButtonImage = null;
            this.butDrawInstances.Size = new System.Drawing.Size(24, 24);
            this.butDrawInstances.TabIndex = 3;
            this.butDrawInstances.TextXOffset = 0;
            this.butDrawInstances.TextYOffset = 0;
            this.butDrawInstances.ToolTipText = "Check or uncheck if \r\ndrawing room instances";
            this.butDrawInstances.ToolTipTitle = "Check/Uncheck Include Instances";
            this.butDrawInstances.UseDropShadow = true;
            this.butDrawInstances.UseVisualStyleBackColor = true;
            // 
            // ExportImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 348);
            this.Controls.Add(this.butDrawInstances);
            this.Controls.Add(this.butCheckAll);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butExport);
            this.Controls.Add(this.grpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportImageForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export To Image File";
            this.grpMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tipMain;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckedListBox lstLayers;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpMain;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butCancel;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butExport;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butCheckAll;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butDrawInstances;
    }
}