namespace GMare.Forms
{
    partial class PreferencesForm
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
            this.grpMain = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabbedGroupBox();
            this.nudUpperLayerTransparency = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.lblUpperLayerTransparency = new System.Windows.Forms.Label();
            this.nudLowerLayerBrightness = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.lblLowerLayerBrightness = new System.Windows.Forms.Label();
            this.nudMaximumUndoRedo = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.lblMaximumUndoRedo = new System.Windows.Forms.Label();
            this.butCancel = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butOk = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.chkShowTips = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpperLayerTransparency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLowerLayerBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumUndoRedo)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMain
            // 
            this.grpMain.BackColor = System.Drawing.Color.Transparent;
            this.grpMain.CenterStatus = false;
            this.grpMain.Controls.Add(this.chkShowTips);
            this.grpMain.Controls.Add(this.nudUpperLayerTransparency);
            this.grpMain.Controls.Add(this.lblUpperLayerTransparency);
            this.grpMain.Controls.Add(this.nudLowerLayerBrightness);
            this.grpMain.Controls.Add(this.lblLowerLayerBrightness);
            this.grpMain.Controls.Add(this.nudMaximumUndoRedo);
            this.grpMain.Controls.Add(this.lblMaximumUndoRedo);
            this.grpMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpMain.Location = new System.Drawing.Point(4, 4);
            this.grpMain.MinimumSize = new System.Drawing.Size(24, 0);
            this.grpMain.Name = "grpMain";
            this.grpMain.Padding = new System.Windows.Forms.Padding(10, 12, 10, 30);
            this.grpMain.ShowStatusBar = false;
            this.grpMain.Size = new System.Drawing.Size(232, 116);
            this.grpMain.StatusBarHeight = 24;
            this.grpMain.StatusBarText = "Status:";
            this.grpMain.TabIndex = 0;
            this.grpMain.TabStop = false;
            // 
            // nudUpperLayerTransparency
            // 
            this.nudUpperLayerTransparency.DecimalPlaces = 1;
            this.nudUpperLayerTransparency.IgnoreHeight = true;
            this.nudUpperLayerTransparency.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudUpperLayerTransparency.Location = new System.Drawing.Point(180, 60);
            this.nudUpperLayerTransparency.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudUpperLayerTransparency.Name = "nudUpperLayerTransparency";
            this.nudUpperLayerTransparency.Size = new System.Drawing.Size(40, 20);
            this.nudUpperLayerTransparency.TabIndex = 5;
            this.nudUpperLayerTransparency.ToolTipText = "The opacity of a layer higher than the currently\r\nselected layer will appear.";
            this.nudUpperLayerTransparency.ToolTipTitle = "Upper Layer Transparency";
            this.nudUpperLayerTransparency.Value = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            // 
            // lblUpperLayerTransparency
            // 
            this.lblUpperLayerTransparency.AutoSize = true;
            this.lblUpperLayerTransparency.Location = new System.Drawing.Point(8, 64);
            this.lblUpperLayerTransparency.Name = "lblUpperLayerTransparency";
            this.lblUpperLayerTransparency.Size = new System.Drawing.Size(165, 13);
            this.lblUpperLayerTransparency.TabIndex = 4;
            this.lblUpperLayerTransparency.Text = "Upper Layer Transparency Level:";
            // 
            // nudLowerLayerBrightness
            // 
            this.nudLowerLayerBrightness.DecimalPlaces = 1;
            this.nudLowerLayerBrightness.IgnoreHeight = true;
            this.nudLowerLayerBrightness.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudLowerLayerBrightness.Location = new System.Drawing.Point(180, 36);
            this.nudLowerLayerBrightness.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLowerLayerBrightness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudLowerLayerBrightness.Name = "nudLowerLayerBrightness";
            this.nudLowerLayerBrightness.Size = new System.Drawing.Size(40, 20);
            this.nudLowerLayerBrightness.TabIndex = 3;
            this.nudLowerLayerBrightness.ToolTipText = "How light or dark a layer lower than the currently\r\nselected layer will appear.";
            this.nudLowerLayerBrightness.ToolTipTitle = "Lower Layer Brightness";
            this.nudLowerLayerBrightness.Value = new decimal(new int[] {
            4,
            0,
            0,
            -2147418112});
            // 
            // lblLowerLayerBrightness
            // 
            this.lblLowerLayerBrightness.AutoSize = true;
            this.lblLowerLayerBrightness.Location = new System.Drawing.Point(8, 40);
            this.lblLowerLayerBrightness.Name = "lblLowerLayerBrightness";
            this.lblLowerLayerBrightness.Size = new System.Drawing.Size(149, 13);
            this.lblLowerLayerBrightness.TabIndex = 2;
            this.lblLowerLayerBrightness.Text = "Lower Layer Brightness Level:";
            // 
            // nudMaximumUndoRedo
            // 
            this.nudMaximumUndoRedo.IgnoreHeight = true;
            this.nudMaximumUndoRedo.Location = new System.Drawing.Point(180, 12);
            this.nudMaximumUndoRedo.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudMaximumUndoRedo.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudMaximumUndoRedo.Name = "nudMaximumUndoRedo";
            this.nudMaximumUndoRedo.Size = new System.Drawing.Size(40, 20);
            this.nudMaximumUndoRedo.TabIndex = 1;
            this.nudMaximumUndoRedo.ToolTipText = "The amount you can undo or redo room changes\r\nThe higher the number, the more mem" +
                "ory it requires\r\nUse caution when adjusting this number";
            this.nudMaximumUndoRedo.ToolTipTitle = "Maximum Undo/Redo Amount";
            this.nudMaximumUndoRedo.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblMaximumUndoRedo
            // 
            this.lblMaximumUndoRedo.AutoSize = true;
            this.lblMaximumUndoRedo.Location = new System.Drawing.Point(8, 16);
            this.lblMaximumUndoRedo.Name = "lblMaximumUndoRedo";
            this.lblMaximumUndoRedo.Size = new System.Drawing.Size(153, 13);
            this.lblMaximumUndoRedo.TabIndex = 0;
            this.lblMaximumUndoRedo.Text = "Maximum Undo/Redo Amount:";
            // 
            // butCancel
            // 
            this.butCancel.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butCancel.Checked = false;
            this.butCancel.FlatStyled = false;
            this.butCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCancel.ImageXOffset = 0;
            this.butCancel.ImageYOffset = 0;
            this.butCancel.Location = new System.Drawing.Point(160, 124);
            this.butCancel.Name = "butCancel";
            this.butCancel.PushButtonImage = null;
            this.butCancel.Size = new System.Drawing.Size(76, 24);
            this.butCancel.TabIndex = 2;
            this.butCancel.Text = "Cancel";
            this.butCancel.TextXOffset = 0;
            this.butCancel.TextYOffset = 0;
            this.butCancel.ToolTipText = "";
            this.butCancel.ToolTipTitle = "";
            this.butCancel.UseDropShadow = true;
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOk
            // 
            this.butOk.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butOk.Checked = false;
            this.butOk.FlatStyled = false;
            this.butOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butOk.ImageXOffset = 0;
            this.butOk.ImageYOffset = 0;
            this.butOk.Location = new System.Drawing.Point(80, 124);
            this.butOk.Name = "butOk";
            this.butOk.PushButtonImage = null;
            this.butOk.Size = new System.Drawing.Size(76, 24);
            this.butOk.TabIndex = 1;
            this.butOk.Text = "OK";
            this.butOk.TextXOffset = 0;
            this.butOk.TextYOffset = 0;
            this.butOk.ToolTipText = "";
            this.butOk.ToolTipTitle = "";
            this.butOk.UseDropShadow = true;
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // chkShowTips
            // 
            this.chkShowTips.AutoSize = true;
            this.chkShowTips.Checked = true;
            this.chkShowTips.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowTips.Location = new System.Drawing.Point(12, 88);
            this.chkShowTips.Name = "chkShowTips";
            this.chkShowTips.Size = new System.Drawing.Size(111, 17);
            this.chkShowTips.TabIndex = 6;
            this.chkShowTips.Text = "Show GMare Tips";
            this.chkShowTips.ToolTipCaption = "";
            this.chkShowTips.ToolTipText = "";
            this.chkShowTips.UseVisualStyleBackColor = true;
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 155);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.grpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreferencesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpperLayerTransparency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLowerLayerBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumUndoRedo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabbedGroupBox grpMain;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudUpperLayerTransparency;
        private System.Windows.Forms.Label lblUpperLayerTransparency;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudLowerLayerBrightness;
        private System.Windows.Forms.Label lblLowerLayerBrightness;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudMaximumUndoRedo;
        private System.Windows.Forms.Label lblMaximumUndoRedo;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butCancel;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butOk;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox chkShowTips;
    }
}