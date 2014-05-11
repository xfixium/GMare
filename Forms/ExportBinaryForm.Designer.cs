namespace GMare.Forms
{
    partial class ExportBinaryForm
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
            this.cboScripts = new System.Windows.Forms.ComboBox();
            this.grpBackgrounds = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.txtBackgroundName = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox();
            this.lblBackgroundName = new System.Windows.Forms.Label();
            this.txtTileHeight = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox();
            this.txtTileOffsetY = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox();
            this.txtTileSeparationY = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox();
            this.txtTileWidth = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox();
            this.txtTileOffsetX = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox();
            this.txtTileSeparationX = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox();
            this.txtBackgroundId = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox();
            this.lblTileSeparationY = new System.Windows.Forms.Label();
            this.lblTileSeparationX = new System.Windows.Forms.Label();
            this.lblTileOffsetY = new System.Windows.Forms.Label();
            this.lblTileOffsetX = new System.Windows.Forms.Label();
            this.lblTileHeight = new System.Windows.Forms.Label();
            this.lblTileWidth = new System.Windows.Forms.Label();
            this.lblBackgroundId = new System.Windows.Forms.Label();
            this.butSetBackground = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.grpRoomProperties = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.grpRoomName = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabbedGroupBox();
            this.lblRoomName = new System.Windows.Forms.Label();
            this.txtProjectPath = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButtonTextbox();
            this.lblProjectPath = new System.Windows.Forms.Label();
            this.txtRoomName = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox();
            this.grpWriteOptions = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabbedGroupBox();
            this.chkWriteTiles = new System.Windows.Forms.CheckBox();
            this.chkUseFlipped = new System.Windows.Forms.CheckBox();
            this.chkUseColor = new System.Windows.Forms.CheckBox();
            this.chkWriteInstances = new System.Windows.Forms.CheckBox();
            this.butMoveDown = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butRoomAdd = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butMoveUp = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.grpRoomsToExport = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.lstRooms = new GMare.Controls.GMareCheckedListBox();
            this.butRoomDelete = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butCancel = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butCheckAll = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butExport = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butCopyScript = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.grpBackgrounds.SuspendLayout();
            this.grpRoomProperties.SuspendLayout();
            this.grpRoomName.SuspendLayout();
            this.grpWriteOptions.SuspendLayout();
            this.grpRoomsToExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboScripts
            // 
            this.cboScripts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboScripts.FormattingEnabled = true;
            this.cboScripts.Items.AddRange(new object[] {
            "Select Script",
            "scrGMareLoadRoom",
            "scrGMareLoadRoomGMS",
            "scrGMareReadBytes",
            "scrGMareReadString",
            "scrGMareReadTileAttributes"});
            this.cboScripts.Location = new System.Drawing.Point(296, 6);
            this.cboScripts.Name = "cboScripts";
            this.cboScripts.Size = new System.Drawing.Size(220, 21);
            this.cboScripts.TabIndex = 8;
            // 
            // grpBackgrounds
            // 
            this.grpBackgrounds.BackColor = System.Drawing.Color.Transparent;
            this.grpBackgrounds.Controls.Add(this.txtBackgroundName);
            this.grpBackgrounds.Controls.Add(this.lblBackgroundName);
            this.grpBackgrounds.Controls.Add(this.txtTileHeight);
            this.grpBackgrounds.Controls.Add(this.txtTileOffsetY);
            this.grpBackgrounds.Controls.Add(this.txtTileSeparationY);
            this.grpBackgrounds.Controls.Add(this.txtTileWidth);
            this.grpBackgrounds.Controls.Add(this.txtTileOffsetX);
            this.grpBackgrounds.Controls.Add(this.txtTileSeparationX);
            this.grpBackgrounds.Controls.Add(this.txtBackgroundId);
            this.grpBackgrounds.Controls.Add(this.lblTileSeparationY);
            this.grpBackgrounds.Controls.Add(this.lblTileSeparationX);
            this.grpBackgrounds.Controls.Add(this.lblTileOffsetY);
            this.grpBackgrounds.Controls.Add(this.lblTileOffsetX);
            this.grpBackgrounds.Controls.Add(this.lblTileHeight);
            this.grpBackgrounds.Controls.Add(this.lblTileWidth);
            this.grpBackgrounds.Controls.Add(this.lblBackgroundId);
            this.grpBackgrounds.Controls.Add(this.butSetBackground);
            this.grpBackgrounds.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBackgrounds.Location = new System.Drawing.Point(264, 228);
            this.grpBackgrounds.Name = "grpBackgrounds";
            this.grpBackgrounds.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpBackgrounds.Size = new System.Drawing.Size(256, 188);
            this.grpBackgrounds.TabIndex = 10;
            this.grpBackgrounds.TabStop = false;
            this.grpBackgrounds.Text = "GM Project Background";
            this.grpBackgrounds.TextBarHeight = 24;
            // 
            // txtBackgroundName
            // 
            this.txtBackgroundName.BackColor = System.Drawing.SystemColors.Control;
            this.txtBackgroundName.Location = new System.Drawing.Point(100, 32);
            this.txtBackgroundName.Name = "txtBackgroundName";
            this.txtBackgroundName.ReadOnly = true;
            this.txtBackgroundName.Size = new System.Drawing.Size(144, 20);
            this.txtBackgroundName.TabIndex = 16;
            this.txtBackgroundName.ToolTipText = "";
            this.txtBackgroundName.ToolTipTitle = "";
            // 
            // lblBackgroundName
            // 
            this.lblBackgroundName.AutoSize = true;
            this.lblBackgroundName.Location = new System.Drawing.Point(8, 36);
            this.lblBackgroundName.Name = "lblBackgroundName";
            this.lblBackgroundName.Size = new System.Drawing.Size(38, 13);
            this.lblBackgroundName.TabIndex = 15;
            this.lblBackgroundName.Text = "Name:";
            // 
            // txtTileHeight
            // 
            this.txtTileHeight.BackColor = System.Drawing.SystemColors.Control;
            this.txtTileHeight.Location = new System.Drawing.Point(220, 80);
            this.txtTileHeight.Name = "txtTileHeight";
            this.txtTileHeight.ReadOnly = true;
            this.txtTileHeight.Size = new System.Drawing.Size(24, 20);
            this.txtTileHeight.TabIndex = 5;
            this.txtTileHeight.ToolTipText = "";
            this.txtTileHeight.ToolTipTitle = "";
            // 
            // txtTileOffsetY
            // 
            this.txtTileOffsetY.BackColor = System.Drawing.SystemColors.Control;
            this.txtTileOffsetY.Location = new System.Drawing.Point(220, 104);
            this.txtTileOffsetY.Name = "txtTileOffsetY";
            this.txtTileOffsetY.ReadOnly = true;
            this.txtTileOffsetY.Size = new System.Drawing.Size(24, 20);
            this.txtTileOffsetY.TabIndex = 9;
            this.txtTileOffsetY.ToolTipText = "";
            this.txtTileOffsetY.ToolTipTitle = "";
            // 
            // txtTileSeparationY
            // 
            this.txtTileSeparationY.BackColor = System.Drawing.SystemColors.Control;
            this.txtTileSeparationY.Location = new System.Drawing.Point(220, 128);
            this.txtTileSeparationY.Name = "txtTileSeparationY";
            this.txtTileSeparationY.ReadOnly = true;
            this.txtTileSeparationY.Size = new System.Drawing.Size(24, 20);
            this.txtTileSeparationY.TabIndex = 13;
            this.txtTileSeparationY.ToolTipText = "";
            this.txtTileSeparationY.ToolTipTitle = "";
            // 
            // txtTileWidth
            // 
            this.txtTileWidth.BackColor = System.Drawing.SystemColors.Control;
            this.txtTileWidth.Location = new System.Drawing.Point(100, 80);
            this.txtTileWidth.Name = "txtTileWidth";
            this.txtTileWidth.ReadOnly = true;
            this.txtTileWidth.Size = new System.Drawing.Size(24, 20);
            this.txtTileWidth.TabIndex = 3;
            this.txtTileWidth.ToolTipText = "";
            this.txtTileWidth.ToolTipTitle = "";
            // 
            // txtTileOffsetX
            // 
            this.txtTileOffsetX.BackColor = System.Drawing.SystemColors.Control;
            this.txtTileOffsetX.Location = new System.Drawing.Point(100, 104);
            this.txtTileOffsetX.Name = "txtTileOffsetX";
            this.txtTileOffsetX.ReadOnly = true;
            this.txtTileOffsetX.Size = new System.Drawing.Size(24, 20);
            this.txtTileOffsetX.TabIndex = 7;
            this.txtTileOffsetX.ToolTipText = "";
            this.txtTileOffsetX.ToolTipTitle = "";
            // 
            // txtTileSeparationX
            // 
            this.txtTileSeparationX.BackColor = System.Drawing.SystemColors.Control;
            this.txtTileSeparationX.Location = new System.Drawing.Point(100, 128);
            this.txtTileSeparationX.Name = "txtTileSeparationX";
            this.txtTileSeparationX.ReadOnly = true;
            this.txtTileSeparationX.Size = new System.Drawing.Size(24, 20);
            this.txtTileSeparationX.TabIndex = 11;
            this.txtTileSeparationX.ToolTipText = "";
            this.txtTileSeparationX.ToolTipTitle = "";
            // 
            // txtBackgroundId
            // 
            this.txtBackgroundId.BackColor = System.Drawing.SystemColors.Control;
            this.txtBackgroundId.Location = new System.Drawing.Point(100, 56);
            this.txtBackgroundId.Name = "txtBackgroundId";
            this.txtBackgroundId.ReadOnly = true;
            this.txtBackgroundId.Size = new System.Drawing.Size(144, 20);
            this.txtBackgroundId.TabIndex = 1;
            this.txtBackgroundId.ToolTipText = "";
            this.txtBackgroundId.ToolTipTitle = "";
            // 
            // lblTileSeparationY
            // 
            this.lblTileSeparationY.AutoSize = true;
            this.lblTileSeparationY.Location = new System.Drawing.Point(128, 132);
            this.lblTileSeparationY.Name = "lblTileSeparationY";
            this.lblTileSeparationY.Size = new System.Drawing.Size(91, 13);
            this.lblTileSeparationY.TabIndex = 12;
            this.lblTileSeparationY.Text = "Tile Separation Y:";
            // 
            // lblTileSeparationX
            // 
            this.lblTileSeparationX.AutoSize = true;
            this.lblTileSeparationX.Location = new System.Drawing.Point(8, 132);
            this.lblTileSeparationX.Name = "lblTileSeparationX";
            this.lblTileSeparationX.Size = new System.Drawing.Size(91, 13);
            this.lblTileSeparationX.TabIndex = 10;
            this.lblTileSeparationX.Text = "Tile Separation X:";
            // 
            // lblTileOffsetY
            // 
            this.lblTileOffsetY.AutoSize = true;
            this.lblTileOffsetY.Location = new System.Drawing.Point(128, 108);
            this.lblTileOffsetY.Name = "lblTileOffsetY";
            this.lblTileOffsetY.Size = new System.Drawing.Size(68, 13);
            this.lblTileOffsetY.TabIndex = 8;
            this.lblTileOffsetY.Text = "Tile Offset Y:";
            // 
            // lblTileOffsetX
            // 
            this.lblTileOffsetX.AutoSize = true;
            this.lblTileOffsetX.Location = new System.Drawing.Point(8, 108);
            this.lblTileOffsetX.Name = "lblTileOffsetX";
            this.lblTileOffsetX.Size = new System.Drawing.Size(68, 13);
            this.lblTileOffsetX.TabIndex = 6;
            this.lblTileOffsetX.Text = "Tile Offset X:";
            // 
            // lblTileHeight
            // 
            this.lblTileHeight.AutoSize = true;
            this.lblTileHeight.Location = new System.Drawing.Point(128, 84);
            this.lblTileHeight.Name = "lblTileHeight";
            this.lblTileHeight.Size = new System.Drawing.Size(61, 13);
            this.lblTileHeight.TabIndex = 4;
            this.lblTileHeight.Text = "Tile Height:";
            // 
            // lblTileWidth
            // 
            this.lblTileWidth.AutoSize = true;
            this.lblTileWidth.Location = new System.Drawing.Point(8, 84);
            this.lblTileWidth.Name = "lblTileWidth";
            this.lblTileWidth.Size = new System.Drawing.Size(58, 13);
            this.lblTileWidth.TabIndex = 2;
            this.lblTileWidth.Text = "Tile Width:";
            // 
            // lblBackgroundId
            // 
            this.lblBackgroundId.AutoSize = true;
            this.lblBackgroundId.Location = new System.Drawing.Point(8, 60);
            this.lblBackgroundId.Name = "lblBackgroundId";
            this.lblBackgroundId.Size = new System.Drawing.Size(21, 13);
            this.lblBackgroundId.TabIndex = 0;
            this.lblBackgroundId.Text = "ID:";
            // 
            // butSetBackground
            // 
            this.butSetBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSetBackground.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butSetBackground.Checked = false;
            this.butSetBackground.FlatStyled = false;
            this.butSetBackground.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSetBackground.ImageXOffset = 0;
            this.butSetBackground.ImageYOffset = 0;
            this.butSetBackground.Location = new System.Drawing.Point(12, 156);
            this.butSetBackground.Name = "butSetBackground";
            this.butSetBackground.PushButtonImage = null;
            this.butSetBackground.Size = new System.Drawing.Size(232, 23);
            this.butSetBackground.TabIndex = 14;
            this.butSetBackground.Text = "Set GM Project Background";
            this.butSetBackground.TextXOffset = 0;
            this.butSetBackground.TextYOffset = 0;
            this.butSetBackground.ToolTipText = "";
            this.butSetBackground.ToolTipTitle = "";
            this.butSetBackground.UseDropShadow = true;
            this.butSetBackground.UseVisualStyleBackColor = true;
            this.butSetBackground.Click += new System.EventHandler(this.butSetBackground_Click);
            // 
            // grpRoomProperties
            // 
            this.grpRoomProperties.BackColor = System.Drawing.Color.Transparent;
            this.grpRoomProperties.Controls.Add(this.grpRoomName);
            this.grpRoomProperties.Controls.Add(this.grpWriteOptions);
            this.grpRoomProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRoomProperties.Location = new System.Drawing.Point(264, 32);
            this.grpRoomProperties.Name = "grpRoomProperties";
            this.grpRoomProperties.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpRoomProperties.Size = new System.Drawing.Size(256, 192);
            this.grpRoomProperties.TabIndex = 10;
            this.grpRoomProperties.TabStop = false;
            this.grpRoomProperties.Text = "Room Properties";
            this.grpRoomProperties.TextBarHeight = 24;
            // 
            // grpRoomName
            // 
            this.grpRoomName.BackColor = System.Drawing.Color.Transparent;
            this.grpRoomName.CenterStatus = false;
            this.grpRoomName.Controls.Add(this.lblRoomName);
            this.grpRoomName.Controls.Add(this.txtProjectPath);
            this.grpRoomName.Controls.Add(this.lblProjectPath);
            this.grpRoomName.Controls.Add(this.txtRoomName);
            this.grpRoomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpRoomName.Location = new System.Drawing.Point(8, 28);
            this.grpRoomName.MinimumSize = new System.Drawing.Size(24, 0);
            this.grpRoomName.Name = "grpRoomName";
            this.grpRoomName.Padding = new System.Windows.Forms.Padding(10, 12, 10, 30);
            this.grpRoomName.ShowStatusBar = false;
            this.grpRoomName.Size = new System.Drawing.Size(240, 68);
            this.grpRoomName.StatusBarHeight = 16;
            this.grpRoomName.StatusBarText = "Status:";
            this.grpRoomName.TabIndex = 0;
            this.grpRoomName.TabStop = false;
            // 
            // lblRoomName
            // 
            this.lblRoomName.AutoSize = true;
            this.lblRoomName.Location = new System.Drawing.Point(12, 16);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(69, 13);
            this.lblRoomName.TabIndex = 0;
            this.lblRoomName.Text = "Room Name:";
            // 
            // txtProjectPath
            // 
            this.txtProjectPath.ButtonImage = null;
            this.txtProjectPath.ButtonImageXOffset = 0;
            this.txtProjectPath.ButtonImageYOffset = 0;
            this.txtProjectPath.ButtonText = "...";
            this.txtProjectPath.ButtonTextXOffset = 1;
            this.txtProjectPath.ButtonTextYOffset = -2;
            this.txtProjectPath.Location = new System.Drawing.Point(84, 36);
            this.txtProjectPath.MaxLength = 32767;
            this.txtProjectPath.Name = "txtProjectPath";
            this.txtProjectPath.ReadOnly = true;
            this.txtProjectPath.Size = new System.Drawing.Size(144, 20);
            this.txtProjectPath.TabIndex = 3;
            this.txtProjectPath.ToolTipText = "";
            this.txtProjectPath.ToolTipTitle = "";
            this.txtProjectPath.Value = null;
            this.txtProjectPath.ButtonClick += new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButtonTextbox.ButtonClickEventHandler(this.txtProjectPath_ButtonClick);
            // 
            // lblProjectPath
            // 
            this.lblProjectPath.AutoSize = true;
            this.lblProjectPath.Location = new System.Drawing.Point(12, 40);
            this.lblProjectPath.Name = "lblProjectPath";
            this.lblProjectPath.Size = new System.Drawing.Size(68, 13);
            this.lblProjectPath.TabIndex = 2;
            this.lblProjectPath.Text = "Project Path:";
            // 
            // txtRoomName
            // 
            this.txtRoomName.BackColor = System.Drawing.SystemColors.Window;
            this.txtRoomName.Location = new System.Drawing.Point(84, 12);
            this.txtRoomName.MaxLength = 50;
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(144, 20);
            this.txtRoomName.TabIndex = 1;
            this.txtRoomName.ToolTipText = "A unique name for the room";
            this.txtRoomName.ToolTipTitle = "Room Name";
            this.txtRoomName.TextChanged += new System.EventHandler(this.txtRoomName_TextChanged);
            // 
            // grpWriteOptions
            // 
            this.grpWriteOptions.BackColor = System.Drawing.Color.Transparent;
            this.grpWriteOptions.CenterStatus = false;
            this.grpWriteOptions.Controls.Add(this.chkWriteTiles);
            this.grpWriteOptions.Controls.Add(this.chkUseFlipped);
            this.grpWriteOptions.Controls.Add(this.chkUseColor);
            this.grpWriteOptions.Controls.Add(this.chkWriteInstances);
            this.grpWriteOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpWriteOptions.Location = new System.Drawing.Point(8, 100);
            this.grpWriteOptions.MinimumSize = new System.Drawing.Size(24, 0);
            this.grpWriteOptions.Name = "grpWriteOptions";
            this.grpWriteOptions.Padding = new System.Windows.Forms.Padding(10, 12, 10, 30);
            this.grpWriteOptions.ShowStatusBar = false;
            this.grpWriteOptions.Size = new System.Drawing.Size(240, 84);
            this.grpWriteOptions.StatusBarHeight = 16;
            this.grpWriteOptions.StatusBarText = "Status:";
            this.grpWriteOptions.TabIndex = 1;
            this.grpWriteOptions.TabStop = false;
            // 
            // chkWriteTiles
            // 
            this.chkWriteTiles.AutoSize = true;
            this.chkWriteTiles.Location = new System.Drawing.Point(12, 12);
            this.chkWriteTiles.Name = "chkWriteTiles";
            this.chkWriteTiles.Size = new System.Drawing.Size(76, 17);
            this.chkWriteTiles.TabIndex = 0;
            this.chkWriteTiles.Text = "Write Tiles";
            this.chkWriteTiles.UseVisualStyleBackColor = true;
            this.chkWriteTiles.CheckedChanged += new System.EventHandler(this.chkOptions_CheckedChanged);
            // 
            // chkUseFlipped
            // 
            this.chkUseFlipped.AutoSize = true;
            this.chkUseFlipped.Location = new System.Drawing.Point(28, 28);
            this.chkUseFlipped.Name = "chkUseFlipped";
            this.chkUseFlipped.Size = new System.Drawing.Size(137, 17);
            this.chkUseFlipped.TabIndex = 1;
            this.chkUseFlipped.Text = "Use Flipped Tile Values";
            this.chkUseFlipped.UseVisualStyleBackColor = true;
            this.chkUseFlipped.CheckedChanged += new System.EventHandler(this.chkOptions_CheckedChanged);
            // 
            // chkUseColor
            // 
            this.chkUseColor.AutoSize = true;
            this.chkUseColor.Location = new System.Drawing.Point(28, 44);
            this.chkUseColor.Name = "chkUseColor";
            this.chkUseColor.Size = new System.Drawing.Size(152, 17);
            this.chkUseColor.TabIndex = 2;
            this.chkUseColor.Text = "Use Tile Color Blend Value";
            this.chkUseColor.UseVisualStyleBackColor = true;
            this.chkUseColor.CheckedChanged += new System.EventHandler(this.chkOptions_CheckedChanged);
            // 
            // chkWriteInstances
            // 
            this.chkWriteInstances.AutoSize = true;
            this.chkWriteInstances.Location = new System.Drawing.Point(12, 60);
            this.chkWriteInstances.Name = "chkWriteInstances";
            this.chkWriteInstances.Size = new System.Drawing.Size(100, 17);
            this.chkWriteInstances.TabIndex = 3;
            this.chkWriteInstances.Text = "Write Instances";
            this.chkWriteInstances.UseVisualStyleBackColor = true;
            this.chkWriteInstances.CheckedChanged += new System.EventHandler(this.chkOptions_CheckedChanged);
            // 
            // butMoveDown
            // 
            this.butMoveDown.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butMoveDown.Checked = false;
            this.butMoveDown.FlatStyled = false;
            this.butMoveDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butMoveDown.Image = global::GMare.Properties.Resources.arrow_down;
            this.butMoveDown.ImageXOffset = 1;
            this.butMoveDown.ImageYOffset = 0;
            this.butMoveDown.Location = new System.Drawing.Point(124, 4);
            this.butMoveDown.Name = "butMoveDown";
            this.butMoveDown.PushButtonImage = null;
            this.butMoveDown.Size = new System.Drawing.Size(24, 24);
            this.butMoveDown.TabIndex = 5;
            this.butMoveDown.TextXOffset = 0;
            this.butMoveDown.TextYOffset = 0;
            this.butMoveDown.ToolTipText = "Moves the selected room down the list";
            this.butMoveDown.ToolTipTitle = "Move Room Down";
            this.butMoveDown.UseDropShadow = true;
            this.butMoveDown.UseVisualStyleBackColor = true;
            this.butMoveDown.Click += new System.EventHandler(this.butMoveDown_Click);
            // 
            // butRoomAdd
            // 
            this.butRoomAdd.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butRoomAdd.Checked = false;
            this.butRoomAdd.FlatStyled = false;
            this.butRoomAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRoomAdd.Image = global::GMare.Properties.Resources.add;
            this.butRoomAdd.ImageXOffset = 0;
            this.butRoomAdd.ImageYOffset = 0;
            this.butRoomAdd.Location = new System.Drawing.Point(52, 4);
            this.butRoomAdd.Name = "butRoomAdd";
            this.butRoomAdd.PushButtonImage = null;
            this.butRoomAdd.Size = new System.Drawing.Size(24, 24);
            this.butRoomAdd.TabIndex = 2;
            this.butRoomAdd.TextXOffset = 0;
            this.butRoomAdd.TextYOffset = 0;
            this.butRoomAdd.ToolTipText = "Add a room for export";
            this.butRoomAdd.ToolTipTitle = "Add Room";
            this.butRoomAdd.UseDropShadow = true;
            this.butRoomAdd.UseVisualStyleBackColor = true;
            this.butRoomAdd.Click += new System.EventHandler(this.butRoomAdd_Click);
            // 
            // butMoveUp
            // 
            this.butMoveUp.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butMoveUp.Checked = false;
            this.butMoveUp.FlatStyled = false;
            this.butMoveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butMoveUp.Image = global::GMare.Properties.Resources.arrow_up;
            this.butMoveUp.ImageXOffset = 1;
            this.butMoveUp.ImageYOffset = 0;
            this.butMoveUp.Location = new System.Drawing.Point(100, 4);
            this.butMoveUp.Name = "butMoveUp";
            this.butMoveUp.PushButtonImage = null;
            this.butMoveUp.Size = new System.Drawing.Size(24, 24);
            this.butMoveUp.TabIndex = 4;
            this.butMoveUp.TextXOffset = 0;
            this.butMoveUp.TextYOffset = 0;
            this.butMoveUp.ToolTipText = "Moves the selected room up the list";
            this.butMoveUp.ToolTipTitle = "Move Room Up";
            this.butMoveUp.UseDropShadow = true;
            this.butMoveUp.UseVisualStyleBackColor = true;
            this.butMoveUp.Click += new System.EventHandler(this.butMoveUp_Click);
            // 
            // grpRoomsToExport
            // 
            this.grpRoomsToExport.BackColor = System.Drawing.Color.Transparent;
            this.grpRoomsToExport.Controls.Add(this.lstRooms);
            this.grpRoomsToExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRoomsToExport.Location = new System.Drawing.Point(4, 32);
            this.grpRoomsToExport.Name = "grpRoomsToExport";
            this.grpRoomsToExport.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpRoomsToExport.Size = new System.Drawing.Size(256, 384);
            this.grpRoomsToExport.TabIndex = 9;
            this.grpRoomsToExport.TabStop = false;
            this.grpRoomsToExport.Text = "Rooms To Export";
            this.grpRoomsToExport.TextBarHeight = 24;
            // 
            // lstRooms
            // 
            this.lstRooms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRooms.CellSize = new System.Drawing.Size(32, 32);
            this.lstRooms.CheckBoxCheckedImage = null;
            this.lstRooms.CheckBoxImageOffsetX = 0;
            this.lstRooms.CheckBoxImageOffsetY = 0;
            this.lstRooms.CheckBoxUnCheckedImage = null;
            this.lstRooms.DisplayFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lstRooms.EmptyListText = "Rooms";
            this.lstRooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lstRooms.FormattingEnabled = true;
            this.lstRooms.Glyph = null;
            this.lstRooms.GlyphOffsetX = 2;
            this.lstRooms.GlyphOffsetY = 1;
            this.lstRooms.HorizontalExtent = 228;
            this.lstRooms.HorizontalScrollbar = true;
            this.lstRooms.IntegralHeight = false;
            this.lstRooms.ListboxMode = GMare.Controls.GMareCheckedListBox.ListboxType.Projects;
            this.lstRooms.Location = new System.Drawing.Point(12, 32);
            this.lstRooms.Name = "lstRooms";
            this.lstRooms.RowHeight = 32;
            this.lstRooms.Size = new System.Drawing.Size(232, 340);
            this.lstRooms.TabIndex = 0;
            this.lstRooms.TextOffsetX = 8;
            this.lstRooms.TextOffsetY = 0;
            this.lstRooms.ToolTipText = "";
            this.lstRooms.ToolTipTitle = "";
            this.lstRooms.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstRooms_ItemCheck);
            this.lstRooms.SelectedIndexChanged += new System.EventHandler(this.lstRooms_SelectedIndexChanged);
            // 
            // butRoomDelete
            // 
            this.butRoomDelete.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butRoomDelete.Checked = false;
            this.butRoomDelete.FlatStyled = false;
            this.butRoomDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRoomDelete.Image = global::GMare.Properties.Resources.delete;
            this.butRoomDelete.ImageXOffset = 0;
            this.butRoomDelete.ImageYOffset = 0;
            this.butRoomDelete.Location = new System.Drawing.Point(76, 4);
            this.butRoomDelete.Name = "butRoomDelete";
            this.butRoomDelete.PushButtonImage = null;
            this.butRoomDelete.Size = new System.Drawing.Size(24, 24);
            this.butRoomDelete.TabIndex = 3;
            this.butRoomDelete.TextXOffset = 0;
            this.butRoomDelete.TextYOffset = 0;
            this.butRoomDelete.ToolTipText = "Delete selected room";
            this.butRoomDelete.ToolTipTitle = "Delete Room";
            this.butRoomDelete.UseDropShadow = true;
            this.butRoomDelete.UseVisualStyleBackColor = true;
            this.butRoomDelete.Click += new System.EventHandler(this.butRoomDelete_Click);
            // 
            // butCancel
            // 
            this.butCancel.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butCancel.Checked = false;
            this.butCancel.FlatStyled = false;
            this.butCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCancel.Image = global::GMare.Properties.Resources.decline;
            this.butCancel.ImageXOffset = 0;
            this.butCancel.ImageYOffset = 0;
            this.butCancel.Location = new System.Drawing.Point(28, 4);
            this.butCancel.Name = "butCancel";
            this.butCancel.PushButtonImage = null;
            this.butCancel.Size = new System.Drawing.Size(24, 24);
            this.butCancel.TabIndex = 1;
            this.butCancel.TextXOffset = 0;
            this.butCancel.TextYOffset = 0;
            this.butCancel.ToolTipText = "Cancel the export";
            this.butCancel.ToolTipTitle = "Cancel";
            this.butCancel.UseDropShadow = true;
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
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
            this.butCheckAll.Location = new System.Drawing.Point(148, 4);
            this.butCheckAll.Name = "butCheckAll";
            this.butCheckAll.PushButtonImage = null;
            this.butCheckAll.Size = new System.Drawing.Size(24, 24);
            this.butCheckAll.TabIndex = 6;
            this.butCheckAll.TextXOffset = 0;
            this.butCheckAll.TextYOffset = 0;
            this.butCheckAll.ToolTipText = "Check or uncheck all rooms";
            this.butCheckAll.ToolTipTitle = "Check/Uncheck All Rooms";
            this.butCheckAll.UseDropShadow = true;
            this.butCheckAll.UseVisualStyleBackColor = true;
            this.butCheckAll.CheckChanged += new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.CheckChangedEventHandler(this.butCheckAll_CheckChanged);
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
            this.butExport.Location = new System.Drawing.Point(4, 4);
            this.butExport.Name = "butExport";
            this.butExport.PushButtonImage = null;
            this.butExport.Size = new System.Drawing.Size(24, 24);
            this.butExport.TabIndex = 0;
            this.butExport.TextXOffset = 0;
            this.butExport.TextYOffset = 0;
            this.butExport.ToolTipText = "Commit the export to disk";
            this.butExport.ToolTipTitle = "Save Export";
            this.butExport.UseDropShadow = true;
            this.butExport.UseVisualStyleBackColor = true;
            this.butExport.Click += new System.EventHandler(this.butExport_Click);
            // 
            // butCopyScript
            // 
            this.butCopyScript.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.PushButton;
            this.butCopyScript.Checked = false;
            this.butCopyScript.FlatStyled = false;
            this.butCopyScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCopyScript.Image = global::GMare.Properties.Resources.clipboard_paste;
            this.butCopyScript.ImageXOffset = 0;
            this.butCopyScript.ImageYOffset = 0;
            this.butCopyScript.Location = new System.Drawing.Point(268, 4);
            this.butCopyScript.Name = "butCopyScript";
            this.butCopyScript.PushButtonImage = null;
            this.butCopyScript.Size = new System.Drawing.Size(24, 24);
            this.butCopyScript.TabIndex = 7;
            this.butCopyScript.TextXOffset = 0;
            this.butCopyScript.TextYOffset = 0;
            this.butCopyScript.ToolTipText = "Copies the selected binary read script to the clipboard. \r\nPaste each script into" +
                " a new script resource in your project. \r\nThese scripts are used to load binary " +
                "room files.";
            this.butCopyScript.ToolTipTitle = "Copy Selected Script";
            this.butCopyScript.UseDropShadow = true;
            this.butCopyScript.UseVisualStyleBackColor = true;
            this.butCopyScript.Click += new System.EventHandler(this.butCopyScript_Click);
            // 
            // ExportBinaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 421);
            this.Controls.Add(this.butCopyScript);
            this.Controls.Add(this.cboScripts);
            this.Controls.Add(this.grpBackgrounds);
            this.Controls.Add(this.grpRoomProperties);
            this.Controls.Add(this.butMoveDown);
            this.Controls.Add(this.butRoomAdd);
            this.Controls.Add(this.butMoveUp);
            this.Controls.Add(this.grpRoomsToExport);
            this.Controls.Add(this.butRoomDelete);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butCheckAll);
            this.Controls.Add(this.butExport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportBinaryForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export To Binary File";
            this.grpBackgrounds.ResumeLayout(false);
            this.grpBackgrounds.PerformLayout();
            this.grpRoomProperties.ResumeLayout(false);
            this.grpRoomName.ResumeLayout(false);
            this.grpRoomName.PerformLayout();
            this.grpWriteOptions.ResumeLayout(false);
            this.grpWriteOptions.PerformLayout();
            this.grpRoomsToExport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butCancel;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butExport;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpRoomsToExport;
        private GMare.Controls.GMareCheckedListBox lstRooms;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butCheckAll;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butRoomDelete;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butRoomAdd;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpRoomProperties;
        private System.Windows.Forms.CheckBox chkWriteInstances;
        private System.Windows.Forms.CheckBox chkUseColor;
        private System.Windows.Forms.CheckBox chkUseFlipped;
        private System.Windows.Forms.CheckBox chkWriteTiles;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butMoveUp;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butMoveDown;
        private System.Windows.Forms.Label lblRoomName;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox txtRoomName;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButtonTextbox txtProjectPath;
        private System.Windows.Forms.Label lblProjectPath;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabbedGroupBox grpWriteOptions;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabbedGroupBox grpRoomName;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butSetBackground;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpBackgrounds;
        private System.Windows.Forms.Label lblTileHeight;
        private System.Windows.Forms.Label lblTileWidth;
        private System.Windows.Forms.Label lblBackgroundId;
        private System.Windows.Forms.Label lblTileSeparationY;
        private System.Windows.Forms.Label lblTileSeparationX;
        private System.Windows.Forms.Label lblTileOffsetY;
        private System.Windows.Forms.Label lblTileOffsetX;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox txtTileHeight;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox txtTileOffsetY;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox txtTileSeparationY;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox txtTileWidth;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox txtTileOffsetX;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox txtTileSeparationX;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox txtBackgroundId;
        private System.Windows.Forms.ComboBox cboScripts;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butCopyScript;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox txtBackgroundName;
        private System.Windows.Forms.Label lblBackgroundName;
    }
}