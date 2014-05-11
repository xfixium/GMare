namespace GMare.Forms
{
    partial class WarningForm
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
            this.chkShowMessage = new System.Windows.Forms.CheckBox();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.butOk = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.rtxtText = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // chkShowMessage
            // 
            this.chkShowMessage.AutoSize = true;
            this.chkShowMessage.Location = new System.Drawing.Point(8, 80);
            this.chkShowMessage.Name = "chkShowMessage";
            this.chkShowMessage.Size = new System.Drawing.Size(226, 17);
            this.chkShowMessage.TabIndex = 1;
            this.chkShowMessage.Text = "Do not show me this message in the future";
            this.chkShowMessage.UseVisualStyleBackColor = true;
            // 
            // picIcon
            // 
            this.picIcon.BackgroundImage = global::GMare.Properties.Resources.information;
            this.picIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picIcon.Location = new System.Drawing.Point(0, 8);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(56, 64);
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            // 
            // butOk
            // 
            this.butOk.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butOk.Checked = false;
            this.butOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOk.FlatStyled = false;
            this.butOk.ImageXOffset = 0;
            this.butOk.ImageYOffset = 0;
            this.butOk.Location = new System.Drawing.Point(240, 76);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(84, 24);
            this.butOk.TabIndex = 2;
            this.butOk.Text = "OK";
            this.butOk.TextXOffset = 0;
            this.butOk.TextYOffset = 0;
            this.butOk.ToolTipText = "";
            this.butOk.ToolTipTitle = "";
            this.butOk.UseDropShadow = true;
            this.butOk.UseVisualStyleBackColor = true;
            // 
            // rtxtText
            // 
            this.rtxtText.BackColor = System.Drawing.SystemColors.Control;
            this.rtxtText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtText.Location = new System.Drawing.Point(60, 8);
            this.rtxtText.Name = "rtxtText";
            this.rtxtText.ReadOnly = true;
            this.rtxtText.Size = new System.Drawing.Size(260, 64);
            this.rtxtText.TabIndex = 0;
            this.rtxtText.TabStop = false;
            this.rtxtText.Text = "";
            // 
            // WarningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 108);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.rtxtText);
            this.Controls.Add(this.chkShowMessage);
            this.Controls.Add(this.picIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WarningForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GMare Warning";
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.CheckBox chkShowMessage;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxRichTextBox rtxtText;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butOk;
    }
}