namespace GMare.Forms
{
    partial class LayerForm
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.nud_Depth = new GMare.Controls.NumericUpDownEx();
            this.txtbx_Name = new GMare.Controls.TextBoxEx();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Depth)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Image = global::GMare.Properties.Resources.decline;
            this.btn_Cancel.Location = new System.Drawing.Point(152, 76);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(32, 32);
            this.btn_Cancel.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btn_Cancel, "Cancel");
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // btn_Ok
            // 
            this.btn_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Ok.Image = global::GMare.Properties.Resources.accept;
            this.btn_Ok.Location = new System.Drawing.Point(120, 76);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(32, 32);
            this.btn_Ok.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btn_Ok, "Ok");
            this.btn_Ok.UseVisualStyleBackColor = true;
            // 
            // nud_Depth
            // 
            this.nud_Depth.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_Depth.Location = new System.Drawing.Point(8, 18);
            this.nud_Depth.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nud_Depth.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.nud_Depth.Name = "nud_Depth";
            this.nud_Depth.Size = new System.Drawing.Size(88, 20);
            this.nud_Depth.TabIndex = 0;
            this.toolTip1.SetToolTip(this.nud_Depth, "The drawing depth of the layer, the lower");
            // 
            // txtbx_Name
            // 
            this.txtbx_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbx_Name.Location = new System.Drawing.Point(8, 18);
            this.txtbx_Name.Name = "txtbx_Name";
            this.txtbx_Name.Size = new System.Drawing.Size(160, 20);
            this.txtbx_Name.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtbx_Name, "The name of the layer");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nud_Depth);
            this.groupBox2.Location = new System.Drawing.Point(8, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(104, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Layer Depth";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbx_Name);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Layer Name";
            // 
            // LayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 123);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LayerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Layer Properties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LayerForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nud_Depth)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private GMare.Controls.NumericUpDownEx nud_Depth;
        private GMare.Controls.TextBoxEx txtbx_Name;
    }
}