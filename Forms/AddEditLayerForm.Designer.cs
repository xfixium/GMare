namespace GMare.Forms
{
    partial class AddEditLayerForm
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
            this.nudDepth = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.txtName = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox();
            this.grpName = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.grpDepth = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.butCancel = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butOk = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepth)).BeginInit();
            this.grpName.SuspendLayout();
            this.grpDepth.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudDepth
            // 
            this.nudDepth.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudDepth.IgnoreHeight = true;
            this.nudDepth.Location = new System.Drawing.Point(12, 32);
            this.nudDepth.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudDepth.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.nudDepth.Name = "nudDepth";
            this.nudDepth.Size = new System.Drawing.Size(85, 20);
            this.nudDepth.TabIndex = 0;
            this.nudDepth.ToolTipText = "";
            this.nudDepth.ToolTipTitle = "";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(12, 32);
            this.txtName.MaxLength = 40;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(157, 20);
            this.txtName.TabIndex = 0;
            this.txtName.ToolTipText = "";
            this.txtName.ToolTipTitle = "";
            // 
            // grpName
            // 
            this.grpName.BackColor = System.Drawing.Color.Transparent;
            this.grpName.Controls.Add(this.txtName);
            this.grpName.Location = new System.Drawing.Point(4, 4);
            this.grpName.Name = "grpName";
            this.grpName.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpName.Size = new System.Drawing.Size(180, 64);
            this.grpName.TabIndex = 0;
            this.grpName.TabStop = false;
            this.grpName.Text = "Layer Name";
            this.grpName.TextBarHeight = 24;
            // 
            // grpDepth
            // 
            this.grpDepth.BackColor = System.Drawing.Color.Transparent;
            this.grpDepth.Controls.Add(this.nudDepth);
            this.grpDepth.Location = new System.Drawing.Point(4, 72);
            this.grpDepth.Name = "grpDepth";
            this.grpDepth.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpDepth.Size = new System.Drawing.Size(108, 64);
            this.grpDepth.TabIndex = 1;
            this.grpDepth.TabStop = false;
            this.grpDepth.Text = "Layer Depth";
            this.grpDepth.TextBarHeight = 24;
            // 
            // butCancel
            // 
            this.butCancel.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butCancel.Checked = false;
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.FlatStyled = false;
            this.butCancel.ImageXOffset = 0;
            this.butCancel.ImageYOffset = 0;
            this.butCancel.Location = new System.Drawing.Point(116, 108);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(68, 24);
            this.butCancel.TabIndex = 3;
            this.butCancel.Text = "Cancel";
            this.butCancel.TextXOffset = 0;
            this.butCancel.TextYOffset = 0;
            this.butCancel.ToolTipText = "";
            this.butCancel.ToolTipTitle = "";
            this.butCancel.UseDropShadow = true;
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // butOk
            // 
            this.butOk.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butOk.Checked = false;
            this.butOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOk.FlatStyled = false;
            this.butOk.ImageXOffset = 0;
            this.butOk.ImageYOffset = 0;
            this.butOk.Location = new System.Drawing.Point(116, 80);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(68, 24);
            this.butOk.TabIndex = 2;
            this.butOk.Text = "OK";
            this.butOk.TextXOffset = 0;
            this.butOk.TextYOffset = 0;
            this.butOk.ToolTipText = "";
            this.butOk.ToolTipTitle = "";
            this.butOk.UseDropShadow = true;
            this.butOk.UseVisualStyleBackColor = true;
            // 
            // AddEditLayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(190, 141);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.grpDepth);
            this.Controls.Add(this.grpName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditLayerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Layer Properties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LayerForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudDepth)).EndInit();
            this.grpName.ResumeLayout(false);
            this.grpName.PerformLayout();
            this.grpDepth.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudDepth;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox txtName;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpName;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpDepth;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butCancel;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butOk;
    }
}