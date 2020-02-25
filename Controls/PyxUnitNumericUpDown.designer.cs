namespace GMare.Controls
{
    partial class PyxUnitNumericUpDown
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUnit = new System.Windows.Forms.Label();
            this.nudMain = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.txtMain = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudMain)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUnit
            // 
            this.lblUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUnit.BackColor = System.Drawing.SystemColors.Window;
            this.lblUnit.Location = new System.Drawing.Point(11, 3);
            this.lblUnit.Margin = new System.Windows.Forms.Padding(0);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(79, 13);
            this.lblUnit.TabIndex = 2;
            this.lblUnit.Text = "Unit";
            this.lblUnit.Click += new System.EventHandler(this.lblUnit_Click);
            // 
            // nudMain
            // 
            this.nudMain.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.nudMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMain.IgnoreHeight = false;
            this.nudMain.Location = new System.Drawing.Point(90, 0);
            this.nudMain.Name = "nudMain";
            this.nudMain.Size = new System.Drawing.Size(17, 20);
            this.nudMain.TabIndex = 1;
            this.nudMain.TabStop = false;
            this.nudMain.ToolTipText = "";
            this.nudMain.ToolTipTitle = "";
            this.nudMain.ValueChanged += new System.EventHandler(this.nudMain_ValueChanged);
            // 
            // txtMain
            // 
            this.txtMain.BackColor = System.Drawing.SystemColors.Window;
            this.txtMain.Location = new System.Drawing.Point(0, 0);
            this.txtMain.Name = "txtMain";
            this.txtMain.Size = new System.Drawing.Size(100, 20);
            this.txtMain.TabIndex = 0;
            this.txtMain.TextChanged += new System.EventHandler(this.txtMain_TextChanged);
            this.txtMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMain_KeyDown);
            this.txtMain.Leave += new System.EventHandler(this.txtMain_Leave);
            this.txtMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtMain_MouseUp);
            // 
            // PyxUnitNumericUpDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.nudMain);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.txtMain);
            this.Name = "PyxUnitNumericUpDown";
            this.Size = new System.Drawing.Size(107, 20);
            this.SizeChanged += new System.EventHandler(this.PyxUnitUpDown_SizeChanged);
            this.Enter += new System.EventHandler(this.PyxUnitNumericUpDown_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.nudMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtMain;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudMain;
        private System.Windows.Forms.Label lblUnit;
    }
}
