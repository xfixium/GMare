namespace GMare.Forms
{
    partial class ViewLayerForm
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
            this.grpArrayType = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.cboArrayType = new System.Windows.Forms.ComboBox();
            this.grpDataType = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.cboDataType = new System.Windows.Forms.ComboBox();
            this.grpLayer = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.cboLayers = new System.Windows.Forms.ComboBox();
            this.grpTextView = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.pnlOptimized = new GMare.Controls.GMareTileConversionPanel();
            this.txtText = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxRichTextBox();
            this.grpArrayType.SuspendLayout();
            this.grpDataType.SuspendLayout();
            this.grpLayer.SuspendLayout();
            this.grpTextView.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpArrayType
            // 
            this.grpArrayType.BackColor = System.Drawing.Color.Transparent;
            this.grpArrayType.Controls.Add(this.cboArrayType);
            this.grpArrayType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpArrayType.Location = new System.Drawing.Point(312, 4);
            this.grpArrayType.Name = "grpArrayType";
            this.grpArrayType.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpArrayType.Size = new System.Drawing.Size(152, 64);
            this.grpArrayType.TabIndex = 2;
            this.grpArrayType.TabStop = false;
            this.grpArrayType.Text = "Array Type";
            this.grpArrayType.TextBarHeight = 24;
            // 
            // cboArrayType
            // 
            this.cboArrayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArrayType.FormattingEnabled = true;
            this.cboArrayType.Items.AddRange(new object[] {
            "Raw",
            "Standard Array",
            "DSList",
            "DSGrid (Sectors Only)"});
            this.cboArrayType.Location = new System.Drawing.Point(12, 32);
            this.cboArrayType.Name = "cboArrayType";
            this.cboArrayType.Size = new System.Drawing.Size(129, 21);
            this.cboArrayType.TabIndex = 0;
            this.cboArrayType.SelectedIndexChanged += new System.EventHandler(this.cboArrayType_SelectedIndexChanged);
            // 
            // grpDataType
            // 
            this.grpDataType.BackColor = System.Drawing.Color.Transparent;
            this.grpDataType.Controls.Add(this.cboDataType);
            this.grpDataType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDataType.Location = new System.Drawing.Point(156, 4);
            this.grpDataType.Name = "grpDataType";
            this.grpDataType.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpDataType.Size = new System.Drawing.Size(152, 64);
            this.grpDataType.TabIndex = 1;
            this.grpDataType.TabStop = false;
            this.grpDataType.Text = "Data Type";
            this.grpDataType.TextBarHeight = 24;
            // 
            // cboDataType
            // 
            this.cboDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataType.FormattingEnabled = true;
            this.cboDataType.Items.AddRange(new object[] {
            "Sectors",
            "Points",
            "Rectangles"});
            this.cboDataType.Location = new System.Drawing.Point(12, 32);
            this.cboDataType.Name = "cboDataType";
            this.cboDataType.Size = new System.Drawing.Size(129, 21);
            this.cboDataType.TabIndex = 0;
            this.cboDataType.SelectedIndexChanged += new System.EventHandler(this.cboDataType_SelectedIndexChanged);
            // 
            // grpLayer
            // 
            this.grpLayer.BackColor = System.Drawing.Color.Transparent;
            this.grpLayer.Controls.Add(this.cboLayers);
            this.grpLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLayer.Location = new System.Drawing.Point(4, 4);
            this.grpLayer.Name = "grpLayer";
            this.grpLayer.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpLayer.Size = new System.Drawing.Size(148, 64);
            this.grpLayer.TabIndex = 0;
            this.grpLayer.TabStop = false;
            this.grpLayer.Text = "Layer";
            this.grpLayer.TextBarHeight = 24;
            // 
            // cboLayers
            // 
            this.cboLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLayers.FormattingEnabled = true;
            this.cboLayers.Location = new System.Drawing.Point(12, 32);
            this.cboLayers.Name = "cboLayers";
            this.cboLayers.Size = new System.Drawing.Size(125, 21);
            this.cboLayers.TabIndex = 0;
            this.cboLayers.SelectedIndexChanged += new System.EventHandler(this.cboLayers_SelectedIndexChanged);
            // 
            // grpTextView
            // 
            this.grpTextView.BackColor = System.Drawing.Color.Transparent;
            this.grpTextView.Controls.Add(this.pnlOptimized);
            this.grpTextView.Controls.Add(this.txtText);
            this.grpTextView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTextView.Location = new System.Drawing.Point(4, 72);
            this.grpTextView.Name = "grpTextView";
            this.grpTextView.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpTextView.Size = new System.Drawing.Size(460, 352);
            this.grpTextView.TabIndex = 3;
            this.grpTextView.TabStop = false;
            this.grpTextView.Text = "Layer View";
            this.grpTextView.TextBarHeight = 24;
            // 
            // pnlOptimized
            // 
            this.pnlOptimized.AutoScroll = true;
            this.pnlOptimized.AutoScrollMinSize = new System.Drawing.Size(432, 304);
            this.pnlOptimized.BackColor = System.Drawing.Color.White;
            this.pnlOptimized.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlOptimized.CanvasSize = new System.Drawing.Size(0, 0);
            this.pnlOptimized.CheckerColor = System.Drawing.Color.Silver;
            this.pnlOptimized.CheckerSize = new System.Drawing.Size(16, 16);
            this.pnlOptimized.ImageScale = 1;
            this.pnlOptimized.Layer = null;
            this.pnlOptimized.Location = new System.Drawing.Point(12, 32);
            this.pnlOptimized.Name = "pnlOptimized";
            this.pnlOptimized.Size = new System.Drawing.Size(436, 308);
            this.pnlOptimized.SnapSize = new System.Drawing.Size(8, 8);
            this.pnlOptimized.TabIndex = 0;
            this.pnlOptimized.Title = "";
            this.pnlOptimized.ToolTipText = "";
            this.pnlOptimized.ToolTipTitle = "";
            this.pnlOptimized.UseCheckerBoard = false;
            this.pnlOptimized.Zoom = 1F;
            // 
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtText.HideSelection = false;
            this.txtText.Location = new System.Drawing.Point(12, 32);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(436, 308);
            this.txtText.TabIndex = 0;
            this.txtText.Text = "";
            this.txtText.WordWrap = false;
            // 
            // ViewLayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 430);
            this.Controls.Add(this.grpArrayType);
            this.Controls.Add(this.grpDataType);
            this.Controls.Add(this.grpLayer);
            this.Controls.Add(this.grpTextView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewLayerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View Layer(s)";
            this.grpArrayType.ResumeLayout(false);
            this.grpDataType.ResumeLayout(false);
            this.grpLayer.ResumeLayout(false);
            this.grpTextView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxRichTextBox txtText;
        private System.Windows.Forms.ComboBox cboLayers;
        private System.Windows.Forms.ComboBox cboDataType;
        private System.Windows.Forms.ComboBox cboArrayType;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpTextView;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpLayer;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpDataType;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpArrayType;
        private Controls.GMareTileConversionPanel pnlOptimized;
    }
}