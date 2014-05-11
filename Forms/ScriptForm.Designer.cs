namespace GMare.Forms
{
    partial class ScriptForm
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
            this.txtCodeEditor = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxRichTextBox();
            this.butCancel = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butOk = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.grpScriptEditor = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.grpScriptEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCodeEditor
            // 
            this.txtCodeEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodeEditor.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodeEditor.Location = new System.Drawing.Point(12, 32);
            this.txtCodeEditor.Name = "txtCodeEditor";
            this.txtCodeEditor.Size = new System.Drawing.Size(448, 360);
            this.txtCodeEditor.TabIndex = 0;
            this.txtCodeEditor.Text = "";
            this.txtCodeEditor.WordWrap = false;
            // 
            // butCancel
            // 
            this.butCancel.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butCancel.Checked = false;
            this.butCancel.FlatStyled = false;
            this.butCancel.ImageXOffset = 0;
            this.butCancel.ImageYOffset = 0;
            this.butCancel.Location = new System.Drawing.Point(400, 412);
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
            this.butOk.Location = new System.Drawing.Point(320, 412);
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
            // grpScriptEditor
            // 
            this.grpScriptEditor.BackColor = System.Drawing.Color.Transparent;
            this.grpScriptEditor.Controls.Add(this.txtCodeEditor);
            this.grpScriptEditor.Location = new System.Drawing.Point(4, 4);
            this.grpScriptEditor.Name = "grpScriptEditor";
            this.grpScriptEditor.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpScriptEditor.Size = new System.Drawing.Size(472, 404);
            this.grpScriptEditor.TabIndex = 0;
            this.grpScriptEditor.TabStop = false;
            this.grpScriptEditor.Text = "Script Editor";
            this.grpScriptEditor.TextBarHeight = 24;
            // 
            // ScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 442);
            this.Controls.Add(this.grpScriptEditor);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScriptForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Creation Code";
            this.grpScriptEditor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxRichTextBox txtCodeEditor;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butCancel;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butOk;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpScriptEditor;
    }
}