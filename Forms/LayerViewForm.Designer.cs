namespace GMare.Forms
{
    partial class TextForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtb_Text = new GMare.Controls.RichTextBoxEx();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_Layers = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cb_DataType = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cb_ArrayType = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtb_Text);
            this.groupBox1.Location = new System.Drawing.Point(8, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 408);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text View";
            // 
            // rtb_Text
            // 
            this.rtb_Text.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_Text.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_Text.HideSelection = false;
            this.rtb_Text.Location = new System.Drawing.Point(8, 16);
            this.rtb_Text.Name = "rtb_Text";
            this.rtb_Text.Size = new System.Drawing.Size(432, 384);
            this.rtb_Text.TabIndex = 0;
            this.rtb_Text.Text = "";
            this.rtb_Text.WordWrap = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_Layers);
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(144, 48);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Layer";
            // 
            // cb_Layers
            // 
            this.cb_Layers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Layers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Layers.FormattingEnabled = true;
            this.cb_Layers.Location = new System.Drawing.Point(8, 18);
            this.cb_Layers.Name = "cb_Layers";
            this.cb_Layers.Size = new System.Drawing.Size(129, 21);
            this.cb_Layers.TabIndex = 0;
            this.cb_Layers.SelectedIndexChanged += new System.EventHandler(this.cb_Layers_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cb_DataType);
            this.groupBox3.Location = new System.Drawing.Point(160, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(144, 48);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data Type";
            // 
            // cb_DataType
            // 
            this.cb_DataType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_DataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_DataType.FormattingEnabled = true;
            this.cb_DataType.Items.AddRange(new object[] {
            "Sectors",
            "Points",
            "Rectangles"});
            this.cb_DataType.Location = new System.Drawing.Point(8, 18);
            this.cb_DataType.Name = "cb_DataType";
            this.cb_DataType.Size = new System.Drawing.Size(129, 21);
            this.cb_DataType.TabIndex = 0;
            this.cb_DataType.SelectedIndexChanged += new System.EventHandler(this.tsb_DataType_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cb_ArrayType);
            this.groupBox4.Location = new System.Drawing.Point(312, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(144, 48);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Array Type";
            // 
            // cb_ArrayType
            // 
            this.cb_ArrayType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_ArrayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ArrayType.FormattingEnabled = true;
            this.cb_ArrayType.Items.AddRange(new object[] {
            "Raw",
            "Standard Array",
            "DSList",
            "DSGrid (Sectors Only)"});
            this.cb_ArrayType.Location = new System.Drawing.Point(8, 18);
            this.cb_ArrayType.Name = "cb_ArrayType";
            this.cb_ArrayType.Size = new System.Drawing.Size(129, 21);
            this.cb_ArrayType.TabIndex = 0;
            this.cb_ArrayType.SelectedIndexChanged += new System.EventHandler(this.cb_ArrayType_SelectedIndexChanged);
            // 
            // TextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 481);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Layer View";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private GMare.Controls.RichTextBoxEx rtb_Text;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cb_Layers;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cb_DataType;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cb_ArrayType;
    }
}