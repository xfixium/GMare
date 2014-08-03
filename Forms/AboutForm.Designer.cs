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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.lblPyxosoft = new System.Windows.Forms.LinkLabel();
            this.lblVisitUs = new System.Windows.Forms.Label();
            this.butOk = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.grpCredits = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.txtInformation = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxRichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpCredits.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPyxosoft
            // 
            this.lblPyxosoft.ActiveLinkColor = System.Drawing.Color.CornflowerBlue;
            this.lblPyxosoft.AutoSize = true;
            this.lblPyxosoft.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPyxosoft.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lblPyxosoft.Location = new System.Drawing.Point(8, 212);
            this.lblPyxosoft.Name = "lblPyxosoft";
            this.lblPyxosoft.Size = new System.Drawing.Size(114, 13);
            this.lblPyxosoft.TabIndex = 2;
            this.lblPyxosoft.TabStop = true;
            this.lblPyxosoft.Text = "www.pyxosoft.com";
            this.lblPyxosoft.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPyxosoft_LinkClicked);
            // 
            // lblVisitUs
            // 
            this.lblVisitUs.AutoSize = true;
            this.lblVisitUs.Location = new System.Drawing.Point(8, 196);
            this.lblVisitUs.Name = "lblVisitUs";
            this.lblVisitUs.Size = new System.Drawing.Size(99, 13);
            this.lblVisitUs.TabIndex = 1;
            this.lblVisitUs.Text = "Visit us on the web:";
            // 
            // butOk
            // 
            this.butOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOk.Image = global::GMare.Properties.Resources.accept;
            this.butOk.Location = new System.Drawing.Point(276, 196);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(32, 32);
            this.butOk.TabIndex = 4;
            this.butOk.UseVisualStyleBackColor = true;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(128, 212);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "Version";
            // 
            // grpCredits
            // 
            this.grpCredits.BackColor = System.Drawing.Color.Transparent;
            this.grpCredits.Controls.Add(this.label1);
            this.grpCredits.Controls.Add(this.txtInformation);
            this.grpCredits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCredits.Location = new System.Drawing.Point(4, 4);
            this.grpCredits.Name = "grpCredits";
            this.grpCredits.Padding = new System.Windows.Forms.Padding(12, 20, 12, 12);
            this.grpCredits.Size = new System.Drawing.Size(308, 188);
            this.grpCredits.TabIndex = 0;
            this.grpCredits.TabStop = false;
            this.grpCredits.Text = "Application Details And Credits";
            this.grpCredits.TextBarHeight = 24;
            // 
            // txtInformation
            // 
            this.txtInformation.BackColor = System.Drawing.SystemColors.Window;
            this.txtInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInformation.Location = new System.Drawing.Point(12, 33);
            this.txtInformation.Name = "txtInformation";
            this.txtInformation.ReadOnly = true;
            this.txtInformation.Size = new System.Drawing.Size(284, 143);
            this.txtInformation.TabIndex = 0;
            this.txtInformation.Text = resources.GetString("txtInformation.Text");
            this.txtInformation.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtxtInformation_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(268, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Beta";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(318, 236);
            this.Controls.Add(this.grpCredits);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblVisitUs);
            this.Controls.Add(this.lblPyxosoft);
            this.Controls.Add(this.butOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About GMare";
            this.grpCredits.ResumeLayout(false);
            this.grpCredits.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.LinkLabel lblPyxosoft;
        private System.Windows.Forms.Label lblVisitUs;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxRichTextBox txtInformation;
        private System.Windows.Forms.Label lblVersion;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpCredits;
        private System.Windows.Forms.Label label1;
    }
}