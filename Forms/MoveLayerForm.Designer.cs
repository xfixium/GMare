namespace GMare.Forms
{
    partial class MoveLayerForm
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
            this.rbLeft = new System.Windows.Forms.RadioButton();
            this.rbDown = new System.Windows.Forms.RadioButton();
            this.rbRight = new System.Windows.Forms.RadioButton();
            this.rbUp = new System.Windows.Forms.RadioButton();
            this.nudAmount = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.cboLayer = new System.Windows.Forms.ComboBox();
            this.grpLayers = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.grpDirection = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.grpAmount = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.butCancel = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butOk = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.grpLayers.SuspendLayout();
            this.grpDirection.SuspendLayout();
            this.grpAmount.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbLeft
            // 
            this.rbLeft.AutoSize = true;
            this.rbLeft.Location = new System.Drawing.Point(12, 92);
            this.rbLeft.Name = "rbLeft";
            this.rbLeft.Size = new System.Drawing.Size(43, 17);
            this.rbLeft.TabIndex = 3;
            this.rbLeft.Text = "Left";
            this.rbLeft.UseVisualStyleBackColor = true;
            this.rbLeft.CheckedChanged += new System.EventHandler(this.rbLeft_CheckedChanged);
            // 
            // rbDown
            // 
            this.rbDown.AutoSize = true;
            this.rbDown.Location = new System.Drawing.Point(12, 72);
            this.rbDown.Name = "rbDown";
            this.rbDown.Size = new System.Drawing.Size(53, 17);
            this.rbDown.TabIndex = 2;
            this.rbDown.Text = "Down";
            this.rbDown.UseVisualStyleBackColor = true;
            this.rbDown.CheckedChanged += new System.EventHandler(this.rbDown_CheckedChanged);
            // 
            // rbRight
            // 
            this.rbRight.AutoSize = true;
            this.rbRight.Location = new System.Drawing.Point(12, 52);
            this.rbRight.Name = "rbRight";
            this.rbRight.Size = new System.Drawing.Size(50, 17);
            this.rbRight.TabIndex = 1;
            this.rbRight.Text = "Right";
            this.rbRight.UseVisualStyleBackColor = true;
            this.rbRight.CheckedChanged += new System.EventHandler(this.rbRight_CheckedChanged);
            // 
            // rbUp
            // 
            this.rbUp.AutoSize = true;
            this.rbUp.Checked = true;
            this.rbUp.Location = new System.Drawing.Point(12, 32);
            this.rbUp.Name = "rbUp";
            this.rbUp.Size = new System.Drawing.Size(39, 17);
            this.rbUp.TabIndex = 0;
            this.rbUp.TabStop = true;
            this.rbUp.Text = "Up";
            this.rbUp.UseVisualStyleBackColor = true;
            this.rbUp.CheckedChanged += new System.EventHandler(this.rbUp_CheckedChanged);
            // 
            // nudAmount
            // 
            this.nudAmount.IgnoreHeight = true;
            this.nudAmount.Location = new System.Drawing.Point(12, 32);
            this.nudAmount.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(48, 20);
            this.nudAmount.TabIndex = 0;
            this.nudAmount.ToolTipText = "";
            this.nudAmount.ToolTipTitle = "";
            this.nudAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cboLayer
            // 
            this.cboLayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLayer.FormattingEnabled = true;
            this.cboLayer.Location = new System.Drawing.Point(12, 32);
            this.cboLayer.Name = "cboLayer";
            this.cboLayer.Size = new System.Drawing.Size(132, 21);
            this.cboLayer.TabIndex = 0;
            // 
            // grpLayers
            // 
            this.grpLayers.BackColor = System.Drawing.Color.Transparent;
            this.grpLayers.Controls.Add(this.cboLayer);
            this.grpLayers.Location = new System.Drawing.Point(4, 4);
            this.grpLayers.Name = "grpLayers";
            this.grpLayers.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpLayers.Size = new System.Drawing.Size(156, 64);
            this.grpLayers.TabIndex = 0;
            this.grpLayers.TabStop = false;
            this.grpLayers.Text = "Layer(s) To Move";
            this.grpLayers.TextBarHeight = 24;
            // 
            // grpDirection
            // 
            this.grpDirection.BackColor = System.Drawing.Color.Transparent;
            this.grpDirection.Controls.Add(this.rbLeft);
            this.grpDirection.Controls.Add(this.rbUp);
            this.grpDirection.Controls.Add(this.rbDown);
            this.grpDirection.Controls.Add(this.rbRight);
            this.grpDirection.Location = new System.Drawing.Point(4, 72);
            this.grpDirection.Name = "grpDirection";
            this.grpDirection.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpDirection.Size = new System.Drawing.Size(80, 120);
            this.grpDirection.TabIndex = 1;
            this.grpDirection.TabStop = false;
            this.grpDirection.Text = "Direction";
            this.grpDirection.TextBarHeight = 24;
            // 
            // grpAmount
            // 
            this.grpAmount.BackColor = System.Drawing.Color.Transparent;
            this.grpAmount.Controls.Add(this.nudAmount);
            this.grpAmount.Location = new System.Drawing.Point(88, 72);
            this.grpAmount.Name = "grpAmount";
            this.grpAmount.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpAmount.Size = new System.Drawing.Size(72, 64);
            this.grpAmount.TabIndex = 2;
            this.grpAmount.TabStop = false;
            this.grpAmount.Text = "Amount";
            this.grpAmount.TextBarHeight = 24;
            // 
            // butCancel
            // 
            this.butCancel.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butCancel.Checked = false;
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.FlatStyled = false;
            this.butCancel.ImageXOffset = 0;
            this.butCancel.ImageYOffset = 0;
            this.butCancel.Location = new System.Drawing.Point(92, 168);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(68, 24);
            this.butCancel.TabIndex = 4;
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
            this.butOk.Location = new System.Drawing.Point(92, 140);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(68, 24);
            this.butOk.TabIndex = 3;
            this.butOk.Text = "OK";
            this.butOk.TextXOffset = 0;
            this.butOk.TextYOffset = 0;
            this.butOk.ToolTipText = "";
            this.butOk.ToolTipTitle = "";
            this.butOk.UseDropShadow = true;
            this.butOk.UseVisualStyleBackColor = true;
            // 
            // MoveLayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(166, 198);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.grpAmount);
            this.Controls.Add(this.grpDirection);
            this.Controls.Add(this.grpLayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MoveLayerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Move Layer(s)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShiftForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.grpLayers.ResumeLayout(false);
            this.grpDirection.ResumeLayout(false);
            this.grpDirection.PerformLayout();
            this.grpAmount.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbLeft;
        private System.Windows.Forms.RadioButton rbDown;
        private System.Windows.Forms.RadioButton rbRight;
        private System.Windows.Forms.RadioButton rbUp;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudAmount;
        private System.Windows.Forms.ComboBox cboLayer;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpLayers;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpDirection;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpAmount;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butCancel;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butOk;
    }
}