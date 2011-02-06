namespace GMare.Forms
{
    partial class ShiftForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_Left = new System.Windows.Forms.RadioButton();
            this.rb_Down = new System.Windows.Forms.RadioButton();
            this.rb_Right = new System.Windows.Forms.RadioButton();
            this.rb_Up = new System.Windows.Forms.RadioButton();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmbobx_Layer = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nud_Amount = new GMare.Controls.NumericUpDownEx();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Amount)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_Left);
            this.groupBox1.Controls.Add(this.rb_Down);
            this.groupBox1.Controls.Add(this.rb_Right);
            this.groupBox1.Controls.Add(this.rb_Up);
            this.groupBox1.Location = new System.Drawing.Point(8, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(80, 88);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Direction";
            this.toolTip1.SetToolTip(this.groupBox1, "Direction to shift tiles");
            // 
            // rb_Left
            // 
            this.rb_Left.AutoSize = true;
            this.rb_Left.Location = new System.Drawing.Point(8, 64);
            this.rb_Left.Name = "rb_Left";
            this.rb_Left.Size = new System.Drawing.Size(43, 17);
            this.rb_Left.TabIndex = 3;
            this.rb_Left.Text = "Left";
            this.rb_Left.UseVisualStyleBackColor = true;
            this.rb_Left.CheckedChanged += new System.EventHandler(this.rb_Left_CheckedChanged);
            // 
            // rb_Down
            // 
            this.rb_Down.AutoSize = true;
            this.rb_Down.Location = new System.Drawing.Point(8, 48);
            this.rb_Down.Name = "rb_Down";
            this.rb_Down.Size = new System.Drawing.Size(53, 17);
            this.rb_Down.TabIndex = 2;
            this.rb_Down.Text = "Down";
            this.rb_Down.UseVisualStyleBackColor = true;
            this.rb_Down.CheckedChanged += new System.EventHandler(this.rb_Down_CheckedChanged);
            // 
            // rb_Right
            // 
            this.rb_Right.AutoSize = true;
            this.rb_Right.Location = new System.Drawing.Point(8, 32);
            this.rb_Right.Name = "rb_Right";
            this.rb_Right.Size = new System.Drawing.Size(50, 17);
            this.rb_Right.TabIndex = 1;
            this.rb_Right.Text = "Right";
            this.rb_Right.UseVisualStyleBackColor = true;
            this.rb_Right.CheckedChanged += new System.EventHandler(this.rb_Right_CheckedChanged);
            // 
            // rb_Up
            // 
            this.rb_Up.AutoSize = true;
            this.rb_Up.Checked = true;
            this.rb_Up.Location = new System.Drawing.Point(8, 16);
            this.rb_Up.Name = "rb_Up";
            this.rb_Up.Size = new System.Drawing.Size(39, 17);
            this.rb_Up.TabIndex = 0;
            this.rb_Up.TabStop = true;
            this.rb_Up.Text = "Up";
            this.rb_Up.UseVisualStyleBackColor = true;
            this.rb_Up.CheckedChanged += new System.EventHandler(this.rb_Up_CheckedChanged);
            // 
            // btn_Ok
            // 
            this.btn_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Ok.Image = global::GMare.Properties.Resources.accept;
            this.btn_Ok.Location = new System.Drawing.Point(96, 120);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(32, 32);
            this.btn_Ok.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btn_Ok, "Ok");
            this.btn_Ok.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Image = global::GMare.Properties.Resources.decline;
            this.btn_Cancel.Location = new System.Drawing.Point(128, 120);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(32, 32);
            this.btn_Cancel.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btn_Cancel, "Cancel");
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nud_Amount);
            this.groupBox2.Location = new System.Drawing.Point(96, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(64, 48);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Amount";
            // 
            // cmbobx_Layer
            // 
            this.cmbobx_Layer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbobx_Layer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbobx_Layer.FormattingEnabled = true;
            this.cmbobx_Layer.Location = new System.Drawing.Point(8, 18);
            this.cmbobx_Layer.Name = "cmbobx_Layer";
            this.cmbobx_Layer.Size = new System.Drawing.Size(136, 21);
            this.cmbobx_Layer.TabIndex = 0;
            this.toolTip1.SetToolTip(this.cmbobx_Layer, "Layer to shift tiles");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbobx_Layer);
            this.groupBox3.Location = new System.Drawing.Point(8, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(152, 48);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Layer To Shift";
            // 
            // nud_Amount
            // 
            this.nud_Amount.Location = new System.Drawing.Point(8, 18);
            this.nud_Amount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_Amount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Amount.Name = "nud_Amount";
            this.nud_Amount.Size = new System.Drawing.Size(48, 20);
            this.nud_Amount.TabIndex = 0;
            this.toolTip1.SetToolTip(this.nud_Amount, "The amount of tiles to shift");
            this.nud_Amount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ShiftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(167, 161);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShiftForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shift Layer(s)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShiftForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_Amount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_Left;
        private System.Windows.Forms.RadioButton rb_Down;
        private System.Windows.Forms.RadioButton rb_Right;
        private System.Windows.Forms.RadioButton rb_Up;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private GMare.Controls.NumericUpDownEx nud_Amount;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbobx_Layer;
    }
}