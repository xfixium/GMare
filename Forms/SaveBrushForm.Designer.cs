namespace GMare.Forms
{
    partial class SaveBrushForm
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
            this.txtName = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox();
            this.pnlBrush = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxPictureBox();
            this.grpMain = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabbedGroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.butCancel = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butOk = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.grpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(68, 16);
            this.txtName.MaxLength = 40;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(164, 20);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "New Brush";
            this.txtName.ToolTipText = "";
            this.txtName.ToolTipTitle = "";
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // pnlBrush
            // 
            this.pnlBrush.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBrush.AutoScroll = true;
            this.pnlBrush.AutoScrollMinSize = new System.Drawing.Size(216, 200);
            this.pnlBrush.BackColor = System.Drawing.Color.White;
            this.pnlBrush.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBrush.CheckerColor = System.Drawing.Color.Silver;
            this.pnlBrush.CheckerSize = new System.Drawing.Size(8, 8);
            this.pnlBrush.Image = null;
            this.pnlBrush.ImageScale = 1;
            this.pnlBrush.Location = new System.Drawing.Point(12, 44);
            this.pnlBrush.Name = "pnlBrush";
            this.pnlBrush.Size = new System.Drawing.Size(220, 204);
            this.pnlBrush.SnapSize = new System.Drawing.Size(8, 8);
            this.pnlBrush.TabIndex = 2;
            this.pnlBrush.Title = "Brush";
            this.pnlBrush.ToolTipText = "";
            this.pnlBrush.ToolTipTitle = "";
            this.pnlBrush.UseCheckerBoard = true;
            this.pnlBrush.Zoom = 1F;
            // 
            // grpMain
            // 
            this.grpMain.BackColor = System.Drawing.Color.Transparent;
            this.grpMain.CenterStatus = false;
            this.grpMain.Controls.Add(this.lblName);
            this.grpMain.Controls.Add(this.txtName);
            this.grpMain.Controls.Add(this.pnlBrush);
            this.grpMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpMain.Location = new System.Drawing.Point(4, 4);
            this.grpMain.MinimumSize = new System.Drawing.Size(24, 0);
            this.grpMain.Name = "grpMain";
            this.grpMain.Padding = new System.Windows.Forms.Padding(10, 12, 10, 30);
            this.grpMain.ShowStatusBar = false;
            this.grpMain.Size = new System.Drawing.Size(244, 260);
            this.grpMain.StatusBarHeight = 16;
            this.grpMain.StatusBarText = "";
            this.grpMain.TabIndex = 0;
            this.grpMain.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // butCancel
            // 
            this.butCancel.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butCancel.Checked = false;
            this.butCancel.FlatStyled = false;
            this.butCancel.ImageXOffset = 0;
            this.butCancel.ImageYOffset = 0;
            this.butCancel.Location = new System.Drawing.Point(168, 268);
            this.butCancel.Name = "butCancel";
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
            this.butOk.ImageXOffset = 0;
            this.butOk.ImageYOffset = 0;
            this.butOk.Location = new System.Drawing.Point(88, 268);
            this.butOk.Name = "butOk";
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
            // SaveBrushForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 299);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.grpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveBrushForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Save Brush";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BrushForm_FormClosing);
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox txtName;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxPictureBox pnlBrush;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabbedGroupBox grpMain;
        private System.Windows.Forms.Label lblName;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butCancel;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butOk;
    }
}