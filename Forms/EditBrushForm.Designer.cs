namespace GMare.Forms
{
    partial class EditBrushForm
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
            this.butMoveDown = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butMoveUp = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butDelete = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butCancel = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butOk = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.grpBrushes = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.txtName = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lstBrushes = new GMare.Controls.GMareCheckedListBox();
            this.butCheckAll = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.grpBrushes.SuspendLayout();
            this.SuspendLayout();
            // 
            // butMoveDown
            // 
            this.butMoveDown.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butMoveDown.Checked = false;
            this.butMoveDown.FlatStyled = false;
            this.butMoveDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butMoveDown.Image = global::GMare.Properties.Resources.arrow_down;
            this.butMoveDown.ImageXOffset = 1;
            this.butMoveDown.ImageYOffset = 0;
            this.butMoveDown.Location = new System.Drawing.Point(56, 300);
            this.butMoveDown.Name = "butMoveDown";
            this.butMoveDown.PushButtonImage = null;
            this.butMoveDown.Size = new System.Drawing.Size(24, 24);
            this.butMoveDown.TabIndex = 3;
            this.butMoveDown.TextXOffset = 0;
            this.butMoveDown.TextYOffset = 0;
            this.butMoveDown.ToolTipText = "Move the selected brush down the list";
            this.butMoveDown.ToolTipTitle = "Move Brush Down";
            this.butMoveDown.UseDropShadow = true;
            this.butMoveDown.UseVisualStyleBackColor = true;
            this.butMoveDown.Click += new System.EventHandler(this.butMoveDown_Click);
            // 
            // butMoveUp
            // 
            this.butMoveUp.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butMoveUp.Checked = false;
            this.butMoveUp.FlatStyled = false;
            this.butMoveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butMoveUp.Image = global::GMare.Properties.Resources.arrow_up;
            this.butMoveUp.ImageXOffset = 1;
            this.butMoveUp.ImageYOffset = 0;
            this.butMoveUp.Location = new System.Drawing.Point(32, 300);
            this.butMoveUp.Name = "butMoveUp";
            this.butMoveUp.PushButtonImage = null;
            this.butMoveUp.Size = new System.Drawing.Size(24, 24);
            this.butMoveUp.TabIndex = 2;
            this.butMoveUp.TextXOffset = 0;
            this.butMoveUp.TextYOffset = 0;
            this.butMoveUp.ToolTipText = "Move the selected brush up the list";
            this.butMoveUp.ToolTipTitle = "Move Brush Up";
            this.butMoveUp.UseDropShadow = true;
            this.butMoveUp.UseVisualStyleBackColor = true;
            this.butMoveUp.Click += new System.EventHandler(this.butMoveUp_Click);
            // 
            // butDelete
            // 
            this.butDelete.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butDelete.Checked = false;
            this.butDelete.FlatStyled = false;
            this.butDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butDelete.Image = global::GMare.Properties.Resources.brush_delete;
            this.butDelete.ImageXOffset = 0;
            this.butDelete.ImageYOffset = 0;
            this.butDelete.Location = new System.Drawing.Point(8, 300);
            this.butDelete.Name = "butDelete";
            this.butDelete.PushButtonImage = null;
            this.butDelete.Size = new System.Drawing.Size(24, 24);
            this.butDelete.TabIndex = 1;
            this.butDelete.TextXOffset = 0;
            this.butDelete.TextYOffset = 0;
            this.butDelete.ToolTipText = "Delete checked brushes";
            this.butDelete.ToolTipTitle = "Delete Brush(es)";
            this.butDelete.UseDropShadow = true;
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // butCancel
            // 
            this.butCancel.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butCancel.Checked = false;
            this.butCancel.FlatStyled = false;
            this.butCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCancel.ImageXOffset = 0;
            this.butCancel.ImageYOffset = 0;
            this.butCancel.Location = new System.Drawing.Point(204, 300);
            this.butCancel.Name = "butCancel";
            this.butCancel.PushButtonImage = null;
            this.butCancel.Size = new System.Drawing.Size(76, 24);
            this.butCancel.TabIndex = 6;
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
            this.butOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butOk.ImageXOffset = 0;
            this.butOk.ImageYOffset = 0;
            this.butOk.Location = new System.Drawing.Point(124, 300);
            this.butOk.Name = "butOk";
            this.butOk.PushButtonImage = null;
            this.butOk.Size = new System.Drawing.Size(76, 24);
            this.butOk.TabIndex = 5;
            this.butOk.Text = "OK";
            this.butOk.TextXOffset = 0;
            this.butOk.TextYOffset = 0;
            this.butOk.ToolTipText = "";
            this.butOk.ToolTipTitle = "";
            this.butOk.UseDropShadow = true;
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // grpBrushes
            // 
            this.grpBrushes.BackColor = System.Drawing.Color.Transparent;
            this.grpBrushes.Controls.Add(this.txtName);
            this.grpBrushes.Controls.Add(this.lblName);
            this.grpBrushes.Controls.Add(this.lstBrushes);
            this.grpBrushes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBrushes.Location = new System.Drawing.Point(4, 4);
            this.grpBrushes.Name = "grpBrushes";
            this.grpBrushes.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpBrushes.Size = new System.Drawing.Size(276, 292);
            this.grpBrushes.TabIndex = 0;
            this.grpBrushes.TabStop = false;
            this.grpBrushes.Text = "Brushes";
            this.grpBrushes.TextBarHeight = 24;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(52, 32);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(212, 20);
            this.txtName.TabIndex = 1;
            this.txtName.ToolTipText = "";
            this.txtName.ToolTipTitle = "";
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 36);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // lstBrushes
            // 
            this.lstBrushes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBrushes.CellSize = new System.Drawing.Size(16, 16);
            this.lstBrushes.DisplayFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lstBrushes.EmptyListText = "Brush List";
            this.lstBrushes.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lstBrushes.FormattingEnabled = true;
            this.lstBrushes.Glyph = global::GMare.Properties.Resources.brush;
            this.lstBrushes.CheckBoxCheckedImage = null;
            this.lstBrushes.GlyphOffsetX = 2;
            this.lstBrushes.GlyphOffsetY = 0;
            this.lstBrushes.CheckBoxUnCheckedImage = null;
            this.lstBrushes.HorizontalExtent = 248;
            this.lstBrushes.IntegralHeight = false;
            this.lstBrushes.ListboxMode = GMare.Controls.GMareCheckedListBox.ListboxType.Brushes;
            this.lstBrushes.Location = new System.Drawing.Point(12, 60);
            this.lstBrushes.Name = "lstBrushes";
            this.lstBrushes.RowHeight = 17;
            this.lstBrushes.Size = new System.Drawing.Size(252, 220);
            this.lstBrushes.TabIndex = 2;
            this.lstBrushes.TextOffsetX = 2;
            this.lstBrushes.TextOffsetY = 0;
            this.lstBrushes.ToolTipText = "";
            this.lstBrushes.ToolTipTitle = "";
            this.lstBrushes.SelectedIndexChanged += new System.EventHandler(this.lstBrushes_SelectedIndexChanged);
            // 
            // butCheckAll
            // 
            this.butCheckAll.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.PushButton;
            this.butCheckAll.Checked = false;
            this.butCheckAll.FlatStyled = false;
            this.butCheckAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCheckAll.Image = global::GMare.Properties.Resources.check_list;
            this.butCheckAll.ImageXOffset = 0;
            this.butCheckAll.ImageYOffset = 0;
            this.butCheckAll.Location = new System.Drawing.Point(80, 300);
            this.butCheckAll.Name = "butCheckAll";
            this.butCheckAll.PushButtonImage = null;
            this.butCheckAll.Size = new System.Drawing.Size(24, 24);
            this.butCheckAll.TabIndex = 4;
            this.butCheckAll.TextXOffset = 0;
            this.butCheckAll.TextYOffset = 0;
            this.butCheckAll.ToolTipText = "Check or uncheck all brushes";
            this.butCheckAll.ToolTipTitle = "Check/Uncheck All Brushes";
            this.butCheckAll.UseDropShadow = true;
            this.butCheckAll.UseVisualStyleBackColor = true;
            this.butCheckAll.CheckChanged += new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.CheckChangedEventHandler(this.butCheckAll_CheckChanged);
            // 
            // EditBrushForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 330);
            this.Controls.Add(this.butCheckAll);
            this.Controls.Add(this.butMoveDown);
            this.Controls.Add(this.butMoveUp);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.grpBrushes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditBrushForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Brushes";
            this.grpBrushes.ResumeLayout(false);
            this.grpBrushes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GMare.Controls.GMareCheckedListBox lstBrushes;
        private System.Windows.Forms.Label lblName;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpBrushes;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butCancel;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butOk;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butMoveDown;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butMoveUp;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butDelete;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox txtName;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butCheckAll;
    }
}