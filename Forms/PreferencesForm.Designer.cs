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
            this.chkShowLayerCursorTip = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox();
            this.chkShowTips = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox();
            this.nudUpperLayerTransparency = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.lblUpperLayerTransparency = new System.Windows.Forms.Label();
            this.nudLowerLayerBrightness = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.lblLowerLayerBrightness = new System.Windows.Forms.Label();
            this.nudMaximumUndoRedo = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.lblMaximumUndoRedo = new System.Windows.Forms.Label();
            this.butCancel = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butOk = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.grpAreaGrid = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckedTabbedGroupBox();
            this.lblGridSize = new System.Windows.Forms.Label();
            this.lblGridHeight = new System.Windows.Forms.Label();
            this.nudGridWidth = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.nudGridHeight = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.lblGridWidth = new System.Windows.Forms.Label();
            this.nudHorizontalMagnificationMultiplier = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.lblHorizontalMagnificationMultiplier = new System.Windows.Forms.Label();
            this.nudVerticalMagnificationMultiplier = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.lblVerticalMagnificationMultiplier = new System.Windows.Forms.Label();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpperLayerTransparency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLowerLayerBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumUndoRedo)).BeginInit();
            this.grpAreaGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGridWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGridHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHorizontalMagnificationMultiplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVerticalMagnificationMultiplier)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMain
            // 
            this.grpMain.BackColor = System.Drawing.Color.Transparent;
            this.grpMain.CenterStatus = false;
            this.grpMain.Controls.Add(this.nudVerticalMagnificationMultiplier);
            this.grpMain.Controls.Add(this.lblVerticalMagnificationMultiplier);
            this.grpMain.Controls.Add(this.nudHorizontalMagnificationMultiplier);
            this.grpMain.Controls.Add(this.lblHorizontalMagnificationMultiplier);
            this.grpMain.Controls.Add(this.chkShowLayerCursorTip);
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
            this.grpMain.Size = new System.Drawing.Size(232, 180);
            this.grpMain.StatusBarHeight = 24;
            this.grpMain.StatusBarText = "Status:";
            this.grpMain.TabIndex = 0;
            this.grpMain.TabStop = false;
            // 
            // chkShowLayerCursorTip
            // 
            this.chkShowLayerCursorTip.AutoSize = true;
            this.chkShowLayerCursorTip.Checked = true;
            this.chkShowLayerCursorTip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowLayerCursorTip.Location = new System.Drawing.Point(12, 152);
            this.chkShowLayerCursorTip.Name = "chkShowLayerCursorTip";
            this.chkShowLayerCursorTip.Size = new System.Drawing.Size(178, 17);
            this.chkShowLayerCursorTip.TabIndex = 7;
            this.chkShowLayerCursorTip.Text = "Show Selected Layer Cursor Tip";
            this.chkShowLayerCursorTip.ToolTipCaption = "";
            this.chkShowLayerCursorTip.ToolTipText = "";
            this.chkShowLayerCursorTip.UseVisualStyleBackColor = true;
            // 
            // chkShowTips
            // 
            this.chkShowTips.AutoSize = true;
            this.chkShowTips.Checked = true;
            this.chkShowTips.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowTips.Location = new System.Drawing.Point(12, 132);
            this.chkShowTips.Name = "chkShowTips";
            this.chkShowTips.Size = new System.Drawing.Size(111, 17);
            this.chkShowTips.TabIndex = 6;
            this.chkShowTips.Text = "Show GMare Tips";
            this.chkShowTips.ToolTipCaption = "";
            this.chkShowTips.ToolTipText = "";
            this.chkShowTips.UseVisualStyleBackColor = true;
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
            this.butCancel.Location = new System.Drawing.Point(160, 272);
            this.butCancel.Name = "butCancel";
            this.butCancel.PushButtonImage = null;
            this.butCancel.Size = new System.Drawing.Size(76, 24);
            this.butCancel.TabIndex = 3;
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
            this.butOk.Location = new System.Drawing.Point(80, 272);
            this.butOk.Name = "butOk";
            this.butOk.PushButtonImage = null;
            this.butOk.Size = new System.Drawing.Size(76, 24);
            this.butOk.TabIndex = 2;
            this.butOk.Text = "OK";
            this.butOk.TextXOffset = 0;
            this.butOk.TextYOffset = 0;
            this.butOk.ToolTipText = "";
            this.butOk.ToolTipTitle = "";
            this.butOk.UseDropShadow = true;
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // grpAreaGrid
            // 
            this.grpAreaGrid.BackColor = System.Drawing.Color.Transparent;
            this.grpAreaGrid.CenterStatus = false;
            this.grpAreaGrid.Checked = false;
            this.grpAreaGrid.Controls.Add(this.lblGridSize);
            this.grpAreaGrid.Controls.Add(this.lblGridHeight);
            this.grpAreaGrid.Controls.Add(this.nudGridWidth);
            this.grpAreaGrid.Controls.Add(this.nudGridHeight);
            this.grpAreaGrid.Controls.Add(this.lblGridWidth);
            this.grpAreaGrid.Location = new System.Drawing.Point(4, 188);
            this.grpAreaGrid.MinimumSize = new System.Drawing.Size(99, 0);
            this.grpAreaGrid.Name = "grpAreaGrid";
            this.grpAreaGrid.Padding = new System.Windows.Forms.Padding(10, 12, 10, 30);
            this.grpAreaGrid.ShowStatusBar = false;
            this.grpAreaGrid.Size = new System.Drawing.Size(232, 80);
            this.grpAreaGrid.StatusBarHeight = 16;
            this.grpAreaGrid.StatusBarText = "Status:";
            this.grpAreaGrid.TabIndex = 1;
            this.grpAreaGrid.TabStop = false;
            this.grpAreaGrid.Text = "Use Area Grid";
            // 
            // lblGridSize
            // 
            this.lblGridSize.AutoSize = true;
            this.lblGridSize.Location = new System.Drawing.Point(8, 56);
            this.lblGridSize.Name = "lblGridSize";
            this.lblGridSize.Size = new System.Drawing.Size(52, 13);
            this.lblGridSize.TabIndex = 4;
            this.lblGridSize.Text = "Grid Size:";
            // 
            // lblGridHeight
            // 
            this.lblGridHeight.AutoSize = true;
            this.lblGridHeight.Location = new System.Drawing.Point(116, 32);
            this.lblGridHeight.Name = "lblGridHeight";
            this.lblGridHeight.Size = new System.Drawing.Size(41, 13);
            this.lblGridHeight.TabIndex = 2;
            this.lblGridHeight.Text = "Height:";
            // 
            // nudGridWidth
            // 
            this.nudGridWidth.IgnoreHeight = true;
            this.nudGridWidth.Location = new System.Drawing.Point(52, 28);
            this.nudGridWidth.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudGridWidth.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudGridWidth.Name = "nudGridWidth";
            this.nudGridWidth.Size = new System.Drawing.Size(60, 20);
            this.nudGridWidth.TabIndex = 1;
            this.nudGridWidth.ToolTipText = "The width of the area cell in pixels";
            this.nudGridWidth.ToolTipTitle = "Grid Width";
            this.nudGridWidth.Value = new decimal(new int[] {
            320,
            0,
            0,
            0});
            this.nudGridWidth.ValueChanged += new System.EventHandler(this.nudAreaGrid_ValueChanged);
            // 
            // nudGridHeight
            // 
            this.nudGridHeight.IgnoreHeight = true;
            this.nudGridHeight.Location = new System.Drawing.Point(160, 28);
            this.nudGridHeight.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudGridHeight.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudGridHeight.Name = "nudGridHeight";
            this.nudGridHeight.Size = new System.Drawing.Size(60, 20);
            this.nudGridHeight.TabIndex = 3;
            this.nudGridHeight.ToolTipText = "The height of the area cell in pixels";
            this.nudGridHeight.ToolTipTitle = "Grid Height";
            this.nudGridHeight.Value = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.nudGridHeight.ValueChanged += new System.EventHandler(this.nudAreaGrid_ValueChanged);
            // 
            // lblGridWidth
            // 
            this.lblGridWidth.AutoSize = true;
            this.lblGridWidth.Location = new System.Drawing.Point(8, 32);
            this.lblGridWidth.Name = "lblGridWidth";
            this.lblGridWidth.Size = new System.Drawing.Size(38, 13);
            this.lblGridWidth.TabIndex = 0;
            this.lblGridWidth.Text = "Width:";
            // 
            // nudHorizontalMagnificationMultiplier
            // 
            this.nudHorizontalMagnificationMultiplier.IgnoreHeight = true;
            this.nudHorizontalMagnificationMultiplier.Location = new System.Drawing.Point(180, 84);
            this.nudHorizontalMagnificationMultiplier.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudHorizontalMagnificationMultiplier.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHorizontalMagnificationMultiplier.Name = "nudHorizontalMagnificationMultiplier";
            this.nudHorizontalMagnificationMultiplier.Size = new System.Drawing.Size(40, 20);
            this.nudHorizontalMagnificationMultiplier.TabIndex = 9;
            this.nudHorizontalMagnificationMultiplier.ToolTipText = "The multiplier applied to room magnification width";
            this.nudHorizontalMagnificationMultiplier.ToolTipTitle = "Horizontal Magnification Multiplier:";
            this.nudHorizontalMagnificationMultiplier.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblHorizontalMagnificationMultiplier
            // 
            this.lblHorizontalMagnificationMultiplier.AutoSize = true;
            this.lblHorizontalMagnificationMultiplier.Location = new System.Drawing.Point(8, 88);
            this.lblHorizontalMagnificationMultiplier.Name = "lblHorizontalMagnificationMultiplier";
            this.lblHorizontalMagnificationMultiplier.Size = new System.Drawing.Size(167, 13);
            this.lblHorizontalMagnificationMultiplier.TabIndex = 8;
            this.lblHorizontalMagnificationMultiplier.Text = "Horizontal Magnification Multiplier:";
            // 
            // nudVerticalMagnificationMultiplier
            // 
            this.nudVerticalMagnificationMultiplier.IgnoreHeight = true;
            this.nudVerticalMagnificationMultiplier.Location = new System.Drawing.Point(180, 108);
            this.nudVerticalMagnificationMultiplier.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudVerticalMagnificationMultiplier.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudVerticalMagnificationMultiplier.Name = "nudVerticalMagnificationMultiplier";
            this.nudVerticalMagnificationMultiplier.Size = new System.Drawing.Size(40, 20);
            this.nudVerticalMagnificationMultiplier.TabIndex = 11;
            this.nudVerticalMagnificationMultiplier.ToolTipText = "The multiplier applied to room magnification height";
            this.nudVerticalMagnificationMultiplier.ToolTipTitle = "Vertical Magnification Multiplier:";
            this.nudVerticalMagnificationMultiplier.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblVerticalMagnificationMultiplier
            // 
            this.lblVerticalMagnificationMultiplier.AutoSize = true;
            this.lblVerticalMagnificationMultiplier.Location = new System.Drawing.Point(8, 112);
            this.lblVerticalMagnificationMultiplier.Name = "lblVerticalMagnificationMultiplier";
            this.lblVerticalMagnificationMultiplier.Size = new System.Drawing.Size(155, 13);
            this.lblVerticalMagnificationMultiplier.TabIndex = 10;
            this.lblVerticalMagnificationMultiplier.Text = "Vertical Magnification Multiplier:";
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 301);
            this.Controls.Add(this.grpAreaGrid);
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
            this.grpAreaGrid.ResumeLayout(false);
            this.grpAreaGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGridWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGridHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHorizontalMagnificationMultiplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVerticalMagnificationMultiplier)).EndInit();
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
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckedTabbedGroupBox grpAreaGrid;
        private System.Windows.Forms.Label lblGridHeight;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudGridWidth;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudGridHeight;
        private System.Windows.Forms.Label lblGridWidth;
        private System.Windows.Forms.Label lblGridSize;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox chkShowLayerCursorTip;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudVerticalMagnificationMultiplier;
        private System.Windows.Forms.Label lblVerticalMagnificationMultiplier;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudHorizontalMagnificationMultiplier;
        private System.Windows.Forms.Label lblHorizontalMagnificationMultiplier;
    }
}