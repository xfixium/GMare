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
            this.cb_ShowMessage = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rtb_Text = new GMare.Controls.RichTextBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_ShowMessage
            // 
            this.cb_ShowMessage.AutoSize = true;
            this.cb_ShowMessage.Location = new System.Drawing.Point(8, 80);
            this.cb_ShowMessage.Name = "cb_ShowMessage";
            this.cb_ShowMessage.Size = new System.Drawing.Size(226, 17);
            this.cb_ShowMessage.TabIndex = 2;
            this.cb_ShowMessage.Text = "Do not show me this message in the future";
            this.cb_ShowMessage.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::GMare.Properties.Resources.information;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(0, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 64);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // rtb_Text
            // 
            this.rtb_Text.BackColor = System.Drawing.SystemColors.Control;
            this.rtb_Text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_Text.Location = new System.Drawing.Point(56, 8);
            this.rtb_Text.Name = "rtb_Text";
            this.rtb_Text.Size = new System.Drawing.Size(184, 64);
            this.rtb_Text.TabIndex = 3;
            this.rtb_Text.Text = "";
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 102);
            this.Controls.Add(this.rtb_Text);
            this.Controls.Add(this.cb_ShowMessage);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GMare Warning";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox cb_ShowMessage;
        private Controls.RichTextBoxEx rtb_Text;
    }
}