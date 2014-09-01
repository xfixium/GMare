namespace GMare.Forms
{
    partial class ProjectIOForm
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
            this.barProgress = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tmrClose = new System.Windows.Forms.Timer(this.components);
            this.bgwGMProjectReader = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // barProgress
            // 
            this.barProgress.Location = new System.Drawing.Point(8, 24);
            this.barProgress.MarqueeAnimationSpeed = 20;
            this.barProgress.Name = "barProgress";
            this.barProgress.Size = new System.Drawing.Size(264, 23);
            this.barProgress.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(8, 8);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(46, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status...";
            // 
            // tmrClose
            // 
            this.tmrClose.Interval = 1000;
            this.tmrClose.Tick += new System.EventHandler(this.tmrClose_Tick);
            // 
            // bgwGMProjectReader
            // 
            this.bgwGMProjectReader.WorkerReportsProgress = true;
            this.bgwGMProjectReader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGMProjectReader_DoWork);
            this.bgwGMProjectReader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwGMProjectReader_ProgressChanged);
            this.bgwGMProjectReader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwProjectReader_RunWorkerCompleted);
            // 
            // ProjectIOForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 55);
            this.ControlBox = false;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.barProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProjectIOForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Project Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar barProgress;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer tmrClose;
        private System.ComponentModel.BackgroundWorker bgwGMProjectReader;
    }
}