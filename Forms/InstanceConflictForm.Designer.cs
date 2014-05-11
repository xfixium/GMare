namespace GMare.Forms
{
    partial class InstanceConflictForm
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
            this.tvObjects = new System.Windows.Forms.TreeView();
            this.imgMain = new System.Windows.Forms.ImageList(this.components);
            this.butReplace = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butDelete = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblObject = new System.Windows.Forms.Label();
            this.pnlObject = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxPanel();
            this.grpObjects = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.grpObjects.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvObjects
            // 
            this.tvObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvObjects.HideSelection = false;
            this.tvObjects.ImageIndex = 0;
            this.tvObjects.ImageList = this.imgMain;
            this.tvObjects.Indent = 20;
            this.tvObjects.ItemHeight = 18;
            this.tvObjects.Location = new System.Drawing.Point(12, 32);
            this.tvObjects.Name = "tvObjects";
            this.tvObjects.SelectedImageIndex = 0;
            this.tvObjects.Size = new System.Drawing.Size(240, 228);
            this.tvObjects.TabIndex = 0;
            this.tvObjects.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvObjects_AfterSelect);
            this.tvObjects.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvObjects_MouseDown);
            // 
            // imgMain
            // 
            this.imgMain.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgMain.ImageSize = new System.Drawing.Size(16, 16);
            this.imgMain.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // butReplace
            // 
            this.butReplace.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butReplace.Checked = false;
            this.butReplace.FlatStyled = false;
            this.butReplace.ImageXOffset = 0;
            this.butReplace.ImageYOffset = 0;
            this.butReplace.Location = new System.Drawing.Point(8, 368);
            this.butReplace.Name = "butReplace";
            this.butReplace.Size = new System.Drawing.Size(256, 23);
            this.butReplace.TabIndex = 5;
            this.butReplace.Text = "Replace With Selected Object";
            this.butReplace.TextXOffset = 0;
            this.butReplace.TextYOffset = 0;
            this.butReplace.ToolTipText = "";
            this.butReplace.ToolTipTitle = "";
            this.butReplace.UseDropShadow = true;
            this.butReplace.UseVisualStyleBackColor = true;
            this.butReplace.Click += new System.EventHandler(this.butReplace_Click);
            // 
            // butDelete
            // 
            this.butDelete.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butDelete.Checked = false;
            this.butDelete.FlatStyled = false;
            this.butDelete.ImageXOffset = 0;
            this.butDelete.ImageYOffset = 0;
            this.butDelete.Location = new System.Drawing.Point(8, 392);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(256, 23);
            this.butDelete.TabIndex = 6;
            this.butDelete.Text = "Delete All Instances";
            this.butDelete.TextXOffset = 0;
            this.butDelete.TextYOffset = 0;
            this.butDelete.ToolTipText = "";
            this.butDelete.ToolTipTitle = "";
            this.butDelete.UseDropShadow = true;
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(4, 32);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(272, 56);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "The above object: [TAG], no longer is exists in the new set of objects imported. " +
                "The room has instances of the above object. Please choose a replacement option.";
            // 
            // lblObject
            // 
            this.lblObject.AutoSize = true;
            this.lblObject.Location = new System.Drawing.Point(30, 12);
            this.lblObject.Name = "lblObject";
            this.lblObject.Size = new System.Drawing.Size(36, 13);
            this.lblObject.TabIndex = 1;
            this.lblObject.Text = "object";
            // 
            // pnlObject
            // 
            this.pnlObject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlObject.CheckerColor = System.Drawing.Color.Silver;
            this.pnlObject.CheckerSize = new System.Drawing.Size(16, 16);
            this.pnlObject.Location = new System.Drawing.Point(8, 8);
            this.pnlObject.Name = "pnlObject";
            this.pnlObject.Size = new System.Drawing.Size(20, 20);
            this.pnlObject.TabIndex = 0;
            this.pnlObject.Title = "";
            this.pnlObject.ToolTipText = "";
            this.pnlObject.ToolTipTitle = "";
            this.pnlObject.UseCheckerBoard = true;
            // 
            // grpObjects
            // 
            this.grpObjects.BackColor = System.Drawing.Color.Transparent;
            this.grpObjects.Controls.Add(this.tvObjects);
            this.grpObjects.Location = new System.Drawing.Point(4, 92);
            this.grpObjects.Name = "grpObjects";
            this.grpObjects.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpObjects.Size = new System.Drawing.Size(264, 272);
            this.grpObjects.TabIndex = 4;
            this.grpObjects.TabStop = false;
            this.grpObjects.Text = "Imported Objects";
            this.grpObjects.TextBarHeight = 24;
            // 
            // InstanceConflictForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 422);
            this.ControlBox = false;
            this.Controls.Add(this.grpObjects);
            this.Controls.Add(this.pnlObject);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butReplace);
            this.Controls.Add(this.lblObject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InstanceConflictForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Instance Conflict";
            this.grpObjects.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvObjects;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butReplace;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butDelete;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ImageList imgMain;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxPanel pnlObject;
        private System.Windows.Forms.Label lblObject;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpObjects;
    }
}