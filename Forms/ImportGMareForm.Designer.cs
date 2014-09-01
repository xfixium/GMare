namespace GMare.Forms
{
    partial class ImportGMareForm
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
            this.grpMain = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.chkPersistent = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox();
            this.chkSize = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox();
            this.chkSpeed = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox();
            this.chkCreationCode = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox();
            this.chkBackColor = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox();
            this.chkCaption = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox();
            this.chkName = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox();
            this.chkCustomColors = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox();
            this.chkExportProject = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox();
            this.chkRecentObjects = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox();
            this.chkBrushes = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox();
            this.chkBlocks = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox();
            this.chkInstances = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox();
            this.chkObjects = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox();
            this.chkBackground = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox();
            this.chkLayers = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox();
            this.butCancel = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butOk = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butCheckAll = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.grpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMain
            // 
            this.grpMain.BackColor = System.Drawing.Color.Transparent;
            this.grpMain.Controls.Add(this.chkPersistent);
            this.grpMain.Controls.Add(this.chkSize);
            this.grpMain.Controls.Add(this.chkSpeed);
            this.grpMain.Controls.Add(this.chkCreationCode);
            this.grpMain.Controls.Add(this.chkBackColor);
            this.grpMain.Controls.Add(this.chkCaption);
            this.grpMain.Controls.Add(this.chkName);
            this.grpMain.Controls.Add(this.chkCustomColors);
            this.grpMain.Controls.Add(this.chkExportProject);
            this.grpMain.Controls.Add(this.chkRecentObjects);
            this.grpMain.Controls.Add(this.chkBrushes);
            this.grpMain.Controls.Add(this.chkBlocks);
            this.grpMain.Controls.Add(this.chkInstances);
            this.grpMain.Controls.Add(this.chkObjects);
            this.grpMain.Controls.Add(this.chkBackground);
            this.grpMain.Controls.Add(this.chkLayers);
            this.grpMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMain.Location = new System.Drawing.Point(4, 4);
            this.grpMain.Name = "grpMain";
            this.grpMain.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpMain.Size = new System.Drawing.Size(196, 300);
            this.grpMain.TabIndex = 0;
            this.grpMain.TabStop = false;
            this.grpMain.Text = "Import";
            this.grpMain.TextBarHeight = 24;
            // 
            // chkPersistent
            // 
            this.chkPersistent.AutoSize = true;
            this.chkPersistent.Checked = true;
            this.chkPersistent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPersistent.Location = new System.Drawing.Point(12, 128);
            this.chkPersistent.Name = "chkPersistent";
            this.chkPersistent.Size = new System.Drawing.Size(112, 17);
            this.chkPersistent.TabIndex = 6;
            this.chkPersistent.Text = "Room Persistence";
            this.chkPersistent.ToolTipCaption = "Import Room Persistence";
            this.chkPersistent.ToolTipText = "Imports room persistent flag setting";
            this.chkPersistent.UseVisualStyleBackColor = true;
            // 
            // chkSize
            // 
            this.chkSize.AutoSize = true;
            this.chkSize.Checked = true;
            this.chkSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSize.Location = new System.Drawing.Point(12, 112);
            this.chkSize.Name = "chkSize";
            this.chkSize.Size = new System.Drawing.Size(77, 17);
            this.chkSize.TabIndex = 5;
            this.chkSize.Text = "Room Size";
            this.chkSize.ToolTipCaption = "Import Room Size";
            this.chkSize.ToolTipText = "Imports room column and row settings";
            this.chkSize.UseVisualStyleBackColor = true;
            // 
            // chkSpeed
            // 
            this.chkSpeed.AutoSize = true;
            this.chkSpeed.Checked = true;
            this.chkSpeed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSpeed.Location = new System.Drawing.Point(12, 96);
            this.chkSpeed.Name = "chkSpeed";
            this.chkSpeed.Size = new System.Drawing.Size(88, 17);
            this.chkSpeed.TabIndex = 4;
            this.chkSpeed.Text = "Room Speed";
            this.chkSpeed.ToolTipCaption = "Import Room Speed";
            this.chkSpeed.ToolTipText = "Imports room frame rate setting";
            this.chkSpeed.UseVisualStyleBackColor = true;
            // 
            // chkCreationCode
            // 
            this.chkCreationCode.AutoSize = true;
            this.chkCreationCode.Checked = true;
            this.chkCreationCode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCreationCode.Location = new System.Drawing.Point(12, 80);
            this.chkCreationCode.Name = "chkCreationCode";
            this.chkCreationCode.Size = new System.Drawing.Size(124, 17);
            this.chkCreationCode.TabIndex = 3;
            this.chkCreationCode.Text = "Room Creation Code";
            this.chkCreationCode.ToolTipCaption = "Import Room Creation Code";
            this.chkCreationCode.ToolTipText = "Imports the room creation code script";
            this.chkCreationCode.UseVisualStyleBackColor = true;
            // 
            // chkBackColor
            // 
            this.chkBackColor.AutoSize = true;
            this.chkBackColor.Checked = true;
            this.chkBackColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBackColor.Location = new System.Drawing.Point(12, 64);
            this.chkBackColor.Name = "chkBackColor";
            this.chkBackColor.Size = new System.Drawing.Size(109, 17);
            this.chkBackColor.TabIndex = 2;
            this.chkBackColor.Text = "Room Back Color";
            this.chkBackColor.ToolTipCaption = "Import Room Back Color";
            this.chkBackColor.ToolTipText = "Imports the room back color setting";
            this.chkBackColor.UseVisualStyleBackColor = true;
            // 
            // chkCaption
            // 
            this.chkCaption.AutoSize = true;
            this.chkCaption.Checked = true;
            this.chkCaption.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCaption.Location = new System.Drawing.Point(12, 48);
            this.chkCaption.Name = "chkCaption";
            this.chkCaption.Size = new System.Drawing.Size(93, 17);
            this.chkCaption.TabIndex = 1;
            this.chkCaption.Text = "Room Caption";
            this.chkCaption.ToolTipCaption = "Import Room Caption";
            this.chkCaption.ToolTipText = "Imports the room caption setting";
            this.chkCaption.UseVisualStyleBackColor = true;
            // 
            // chkName
            // 
            this.chkName.AutoSize = true;
            this.chkName.Checked = true;
            this.chkName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkName.Location = new System.Drawing.Point(12, 32);
            this.chkName.Name = "chkName";
            this.chkName.Size = new System.Drawing.Size(85, 17);
            this.chkName.TabIndex = 0;
            this.chkName.Text = "Room Name";
            this.chkName.ToolTipCaption = "Import Room Name";
            this.chkName.ToolTipText = "Imports the room name setting";
            this.chkName.UseVisualStyleBackColor = true;
            // 
            // chkCustomColors
            // 
            this.chkCustomColors.AutoSize = true;
            this.chkCustomColors.Checked = true;
            this.chkCustomColors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCustomColors.Location = new System.Drawing.Point(12, 160);
            this.chkCustomColors.Name = "chkCustomColors";
            this.chkCustomColors.Size = new System.Drawing.Size(93, 17);
            this.chkCustomColors.TabIndex = 8;
            this.chkCustomColors.Text = "Custom Colors";
            this.chkCustomColors.ToolTipCaption = "Import Custom Colors";
            this.chkCustomColors.ToolTipText = "Imports custom room back colors";
            this.chkCustomColors.UseVisualStyleBackColor = true;
            // 
            // chkExportProject
            // 
            this.chkExportProject.AutoSize = true;
            this.chkExportProject.Checked = true;
            this.chkExportProject.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExportProject.Location = new System.Drawing.Point(12, 144);
            this.chkExportProject.Name = "chkExportProject";
            this.chkExportProject.Size = new System.Drawing.Size(97, 17);
            this.chkExportProject.TabIndex = 7;
            this.chkExportProject.Text = "Export Projects";
            this.chkExportProject.ToolTipCaption = "Import Export Projects";
            this.chkExportProject.ToolTipText = "Imports binary export rooms";
            this.chkExportProject.UseVisualStyleBackColor = true;
            // 
            // chkRecentObjects
            // 
            this.chkRecentObjects.AutoSize = true;
            this.chkRecentObjects.Checked = true;
            this.chkRecentObjects.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecentObjects.Location = new System.Drawing.Point(28, 256);
            this.chkRecentObjects.Name = "chkRecentObjects";
            this.chkRecentObjects.Size = new System.Drawing.Size(100, 17);
            this.chkRecentObjects.TabIndex = 14;
            this.chkRecentObjects.Text = "Recent Objects";
            this.chkRecentObjects.ToolTipCaption = "Import Recent Objects";
            this.chkRecentObjects.ToolTipText = "Imports recent object history";
            this.chkRecentObjects.UseVisualStyleBackColor = true;
            // 
            // chkBrushes
            // 
            this.chkBrushes.AutoSize = true;
            this.chkBrushes.Checked = true;
            this.chkBrushes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBrushes.Location = new System.Drawing.Point(28, 208);
            this.chkBrushes.Name = "chkBrushes";
            this.chkBrushes.Size = new System.Drawing.Size(64, 17);
            this.chkBrushes.TabIndex = 11;
            this.chkBrushes.Text = "Brushes";
            this.chkBrushes.ToolTipCaption = "Import Brushes";
            this.chkBrushes.ToolTipText = "Imports custom brushes";
            this.chkBrushes.UseVisualStyleBackColor = true;
            // 
            // chkBlocks
            // 
            this.chkBlocks.AutoSize = true;
            this.chkBlocks.Checked = true;
            this.chkBlocks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBlocks.Location = new System.Drawing.Point(28, 272);
            this.chkBlocks.Name = "chkBlocks";
            this.chkBlocks.Size = new System.Drawing.Size(58, 17);
            this.chkBlocks.TabIndex = 15;
            this.chkBlocks.Text = "Blocks";
            this.chkBlocks.ToolTipCaption = "Import Blocks";
            this.chkBlocks.ToolTipText = "Import block assignments";
            this.chkBlocks.UseVisualStyleBackColor = true;
            // 
            // chkInstances
            // 
            this.chkInstances.AutoSize = true;
            this.chkInstances.Checked = true;
            this.chkInstances.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInstances.Location = new System.Drawing.Point(28, 240);
            this.chkInstances.Name = "chkInstances";
            this.chkInstances.Size = new System.Drawing.Size(72, 17);
            this.chkInstances.TabIndex = 13;
            this.chkInstances.Text = "Instances";
            this.chkInstances.ToolTipCaption = "Import Instances";
            this.chkInstances.ToolTipText = "Imports placed room instances";
            this.chkInstances.UseVisualStyleBackColor = true;
            // 
            // chkObjects
            // 
            this.chkObjects.AutoSize = true;
            this.chkObjects.Checked = true;
            this.chkObjects.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkObjects.Location = new System.Drawing.Point(12, 224);
            this.chkObjects.Name = "chkObjects";
            this.chkObjects.Size = new System.Drawing.Size(62, 17);
            this.chkObjects.TabIndex = 12;
            this.chkObjects.Text = "Objects";
            this.chkObjects.ToolTipCaption = "Import Objects";
            this.chkObjects.ToolTipText = "Imports objects to create instances of";
            this.chkObjects.UseVisualStyleBackColor = true;
            // 
            // chkBackground
            // 
            this.chkBackground.AutoSize = true;
            this.chkBackground.Checked = true;
            this.chkBackground.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBackground.Location = new System.Drawing.Point(12, 176);
            this.chkBackground.Name = "chkBackground";
            this.chkBackground.Size = new System.Drawing.Size(84, 17);
            this.chkBackground.TabIndex = 9;
            this.chkBackground.Text = "Background";
            this.chkBackground.ToolTipCaption = "Import Background";
            this.chkBackground.ToolTipText = "Imports the background used by layers";
            this.chkBackground.UseVisualStyleBackColor = true;
            // 
            // chkLayers
            // 
            this.chkLayers.AutoSize = true;
            this.chkLayers.Checked = true;
            this.chkLayers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLayers.Location = new System.Drawing.Point(28, 192);
            this.chkLayers.Name = "chkLayers";
            this.chkLayers.Size = new System.Drawing.Size(57, 17);
            this.chkLayers.TabIndex = 10;
            this.chkLayers.Text = "Layers";
            this.chkLayers.ToolTipCaption = "Import Layers";
            this.chkLayers.ToolTipText = "Imports layer and tile data";
            this.chkLayers.UseVisualStyleBackColor = true;
            // 
            // butCancel
            // 
            this.butCancel.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butCancel.Checked = false;
            this.butCancel.FlatStyled = false;
            this.butCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCancel.ImageXOffset = 0;
            this.butCancel.ImageYOffset = 0;
            this.butCancel.Location = new System.Drawing.Point(124, 308);
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
            this.butOk.Location = new System.Drawing.Point(44, 308);
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
            // butCheckAll
            // 
            this.butCheckAll.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.PushButton;
            this.butCheckAll.Checked = true;
            this.butCheckAll.FlatStyled = false;
            this.butCheckAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCheckAll.Image = global::GMare.Properties.Resources.check_list;
            this.butCheckAll.ImageXOffset = 0;
            this.butCheckAll.ImageYOffset = 0;
            this.butCheckAll.Location = new System.Drawing.Point(4, 308);
            this.butCheckAll.Name = "butCheckAll";
            this.butCheckAll.PushButtonImage = null;
            this.butCheckAll.Size = new System.Drawing.Size(24, 24);
            this.butCheckAll.TabIndex = 1;
            this.butCheckAll.TextXOffset = 0;
            this.butCheckAll.TextYOffset = 0;
            this.butCheckAll.ToolTipText = "Check or uncheck all room properties to import";
            this.butCheckAll.ToolTipTitle = "Check/Uncheck All Room Properties";
            this.butCheckAll.UseDropShadow = true;
            this.butCheckAll.UseVisualStyleBackColor = true;
            this.butCheckAll.CheckChanged += new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.CheckChangedEventHandler(this.butCheckAll_CheckChanged);
            // 
            // ImportGMareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 339);
            this.Controls.Add(this.butCheckAll);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.grpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportGMareForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import GMare Project";
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpMain;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox chkLayers;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox chkRecentObjects;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox chkBrushes;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox chkBlocks;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox chkInstances;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox chkObjects;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox chkBackground;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox chkExportProject;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox chkCustomColors;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox chkCreationCode;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox chkBackColor;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox chkCaption;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox chkName;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox chkSize;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox chkSpeed;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckBox chkPersistent;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butCancel;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butOk;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butCheckAll;
    }
}