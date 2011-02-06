namespace GMare.Forms
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtb_Information = new GMare.Controls.RichTextBoxEx();
            this.lnklbl_Pyxosoft = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_Ok = new System.Windows.Forms.Button();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtb_Information);
            this.groupBox1.Location = new System.Drawing.Point(8, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 168);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Details And Credits";
            // 
            // rtb_Information
            // 
            this.rtb_Information.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_Information.BackColor = System.Drawing.SystemColors.Window;
            this.rtb_Information.Location = new System.Drawing.Point(8, 16);
            this.rtb_Information.Name = "rtb_Information";
            this.rtb_Information.ReadOnly = true;
            this.rtb_Information.Size = new System.Drawing.Size(288, 144);
            this.rtb_Information.TabIndex = 0;
            this.rtb_Information.Text = resources.GetString("rtb_Information.Text");
            this.rtb_Information.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtb_Information_LinkClicked);
            // 
            // lnklbl_Pyxosoft
            // 
            this.lnklbl_Pyxosoft.AutoSize = true;
            this.lnklbl_Pyxosoft.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnklbl_Pyxosoft.LinkColor = System.Drawing.Color.Crimson;
            this.lnklbl_Pyxosoft.Location = new System.Drawing.Point(8, 288);
            this.lnklbl_Pyxosoft.Name = "lnklbl_Pyxosoft";
            this.lnklbl_Pyxosoft.Size = new System.Drawing.Size(114, 13);
            this.lnklbl_Pyxosoft.TabIndex = 3;
            this.lnklbl_Pyxosoft.TabStop = true;
            this.lnklbl_Pyxosoft.Text = "www.pyxosoft.com";
            this.lnklbl_Pyxosoft.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklbl_Pyxosoft_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Visit us on the web:";
            // 
            // btn_Ok
            // 
            this.btn_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Ok.Image = global::GMare.Properties.Resources.accept;
            this.btn_Ok.Location = new System.Drawing.Point(280, 272);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(32, 32);
            this.btn_Ok.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btn_Ok, "Ok");
            this.btn_Ok.UseVisualStyleBackColor = true;
            // 
            // lbl_Version
            // 
            this.lbl_Version.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_Version.AutoSize = true;
            this.lbl_Version.Location = new System.Drawing.Point(128, 288);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(42, 13);
            this.lbl_Version.TabIndex = 5;
            this.lbl_Version.Text = "Version";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::GMare.Properties.Resources.gmare;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 88);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(320, 312);
            this.Controls.Add(this.lbl_Version);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lnklbl_Pyxosoft);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About GMare";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.LinkLabel lnklbl_Pyxosoft;
        private System.Windows.Forms.Label label1;
        private GMare.Controls.RichTextBoxEx rtb_Information;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbl_Version;
    }
}