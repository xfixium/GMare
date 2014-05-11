namespace GMare.Forms
{
    partial class TileReplacementForm
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
            this.chkEmpty = new System.Windows.Forms.CheckBox();
            this.butCancel = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butOk = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.grpTarget = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabbedGroupBox();
            this.pnlTarget = new GMare.Controls.GMareBackgroundPanel();
            this.cboLayers = new System.Windows.Forms.ComboBox();
            this.lblLayers = new System.Windows.Forms.Label();
            this.pyxTabbedGroupBox1 = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabbedGroupBox();
            this.pnlReplacement = new GMare.Controls.GMareBackgroundPanel();
            this.lblMagnify = new System.Windows.Forms.Label();
            this.pnlMagnify = new System.Windows.Forms.Panel();
            this.trkMagnify = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTrackBar();
            this.grpTarget.SuspendLayout();
            this.pyxTabbedGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkEmpty
            // 
            this.chkEmpty.AutoSize = true;
            this.chkEmpty.Location = new System.Drawing.Point(8, 363);
            this.chkEmpty.Name = "chkEmpty";
            this.chkEmpty.Size = new System.Drawing.Size(213, 17);
            this.chkEmpty.TabIndex = 8;
            this.chkEmpty.Text = "Replace Target Tile(s) With Empty Tiles";
            this.chkEmpty.UseVisualStyleBackColor = true;
            this.chkEmpty.CheckedChanged += new System.EventHandler(this.chkEmpty_CheckedChanged);
            // 
            // butCancel
            // 
            this.butCancel.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butCancel.Checked = false;
            this.butCancel.FlatStyled = false;
            this.butCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCancel.ImageXOffset = 0;
            this.butCancel.ImageYOffset = 0;
            this.butCancel.Location = new System.Drawing.Point(480, 360);
            this.butCancel.Name = "butCancel";
            this.butCancel.PushButtonImage = null;
            this.butCancel.Size = new System.Drawing.Size(92, 23);
            this.butCancel.TabIndex = 10;
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
            this.butOk.Location = new System.Drawing.Point(384, 360);
            this.butOk.Name = "butOk";
            this.butOk.PushButtonImage = null;
            this.butOk.Size = new System.Drawing.Size(92, 23);
            this.butOk.TabIndex = 9;
            this.butOk.Text = "OK";
            this.butOk.TextXOffset = 0;
            this.butOk.TextYOffset = 0;
            this.butOk.ToolTipText = "";
            this.butOk.ToolTipTitle = "";
            this.butOk.UseDropShadow = true;
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // grpTarget
            // 
            this.grpTarget.BackColor = System.Drawing.Color.Transparent;
            this.grpTarget.CenterStatus = false;
            this.grpTarget.Controls.Add(this.pnlTarget);
            this.grpTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpTarget.Location = new System.Drawing.Point(4, 16);
            this.grpTarget.MinimumSize = new System.Drawing.Size(60, 0);
            this.grpTarget.Name = "grpTarget";
            this.grpTarget.Padding = new System.Windows.Forms.Padding(10, 12, 10, 30);
            this.grpTarget.ShowStatusBar = false;
            this.grpTarget.Size = new System.Drawing.Size(284, 340);
            this.grpTarget.StatusBarHeight = 16;
            this.grpTarget.StatusBarText = "";
            this.grpTarget.TabIndex = 3;
            this.grpTarget.TabStop = false;
            this.grpTarget.Text = "Target";
            // 
            // pnlTarget
            // 
            this.pnlTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTarget.AutoScroll = true;
            this.pnlTarget.AutoScrollMinSize = new System.Drawing.Size(256, 296);
            this.pnlTarget.BackColor = System.Drawing.Color.White;
            this.pnlTarget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTarget.CheckerColor = System.Drawing.Color.Silver;
            this.pnlTarget.CheckerSize = new System.Drawing.Size(16, 16);
            this.pnlTarget.Image = null;
            this.pnlTarget.ImageScale = 1;
            this.pnlTarget.Location = new System.Drawing.Point(12, 28);
            this.pnlTarget.Name = "pnlTarget";
            this.pnlTarget.SelectMode = GMare.Controls.GMareBackgroundPanel.SelectType.Normal;
            this.pnlTarget.Size = new System.Drawing.Size(260, 300);
            this.pnlTarget.SnapSize = new System.Drawing.Size(8, 8);
            this.pnlTarget.TabIndex = 0;
            this.pnlTarget.TileBrush = null;
            this.pnlTarget.Title = "Target Tile(s)";
            this.pnlTarget.ToolTipText = "";
            this.pnlTarget.ToolTipTitle = "";
            this.pnlTarget.UseCheckerBoard = true;
            this.pnlTarget.Zoom = 1F;
            this.pnlTarget.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTarget_MouseUp);
            // 
            // cboLayers
            // 
            this.cboLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLayers.FormattingEnabled = true;
            this.cboLayers.Location = new System.Drawing.Point(136, 8);
            this.cboLayers.Name = "cboLayers";
            this.cboLayers.Size = new System.Drawing.Size(149, 21);
            this.cboLayers.TabIndex = 1;
            // 
            // lblLayers
            // 
            this.lblLayers.AutoSize = true;
            this.lblLayers.Location = new System.Drawing.Point(84, 12);
            this.lblLayers.Name = "lblLayers";
            this.lblLayers.Size = new System.Drawing.Size(51, 13);
            this.lblLayers.TabIndex = 0;
            this.lblLayers.Text = "Layer(s):";
            // 
            // pyxTabbedGroupBox1
            // 
            this.pyxTabbedGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.pyxTabbedGroupBox1.CenterStatus = false;
            this.pyxTabbedGroupBox1.Controls.Add(this.pnlReplacement);
            this.pyxTabbedGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pyxTabbedGroupBox1.Location = new System.Drawing.Point(292, 16);
            this.pyxTabbedGroupBox1.MinimumSize = new System.Drawing.Size(94, 0);
            this.pyxTabbedGroupBox1.Name = "pyxTabbedGroupBox1";
            this.pyxTabbedGroupBox1.Padding = new System.Windows.Forms.Padding(10, 12, 10, 30);
            this.pyxTabbedGroupBox1.ShowStatusBar = false;
            this.pyxTabbedGroupBox1.Size = new System.Drawing.Size(284, 340);
            this.pyxTabbedGroupBox1.StatusBarHeight = 16;
            this.pyxTabbedGroupBox1.StatusBarText = "Status:";
            this.pyxTabbedGroupBox1.TabIndex = 4;
            this.pyxTabbedGroupBox1.TabStop = false;
            this.pyxTabbedGroupBox1.Text = "Replacement";
            // 
            // pnlReplacement
            // 
            this.pnlReplacement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReplacement.AutoScroll = true;
            this.pnlReplacement.AutoScrollMinSize = new System.Drawing.Size(256, 296);
            this.pnlReplacement.BackColor = System.Drawing.Color.White;
            this.pnlReplacement.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlReplacement.CheckerColor = System.Drawing.Color.Silver;
            this.pnlReplacement.CheckerSize = new System.Drawing.Size(16, 16);
            this.pnlReplacement.Image = null;
            this.pnlReplacement.ImageScale = 1;
            this.pnlReplacement.Location = new System.Drawing.Point(12, 28);
            this.pnlReplacement.Name = "pnlReplacement";
            this.pnlReplacement.SelectMode = GMare.Controls.GMareBackgroundPanel.SelectType.Fixed;
            this.pnlReplacement.Size = new System.Drawing.Size(260, 300);
            this.pnlReplacement.SnapSize = new System.Drawing.Size(8, 8);
            this.pnlReplacement.TabIndex = 0;
            this.pnlReplacement.TileBrush = null;
            this.pnlReplacement.Title = "Replacement Tile(s)";
            this.pnlReplacement.ToolTipText = "";
            this.pnlReplacement.ToolTipTitle = "";
            this.pnlReplacement.UseCheckerBoard = true;
            this.pnlReplacement.Zoom = 1F;
            // 
            // lblMagnify
            // 
            this.lblMagnify.AutoSize = true;
            this.lblMagnify.Location = new System.Drawing.Point(540, 12);
            this.lblMagnify.Name = "lblMagnify";
            this.lblMagnify.Size = new System.Drawing.Size(36, 13);
            this.lblMagnify.TabIndex = 7;
            this.lblMagnify.Text = "100%";
            // 
            // pnlMagnify
            // 
            this.pnlMagnify.BackgroundImage = global::GMare.Properties.Resources.magnifier;
            this.pnlMagnify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlMagnify.Location = new System.Drawing.Point(408, 6);
            this.pnlMagnify.Name = "pnlMagnify";
            this.pnlMagnify.Size = new System.Drawing.Size(24, 24);
            this.pnlMagnify.TabIndex = 5;
            // 
            // trkMagnify
            // 
            this.trkMagnify.BackColor = System.Drawing.Color.Transparent;
            this.trkMagnify.LargeChange = 1;
            this.trkMagnify.Location = new System.Drawing.Point(428, 8);
            this.trkMagnify.Maximum = 5;
            this.trkMagnify.Minimum = 1;
            this.trkMagnify.Name = "trkMagnify";
            this.trkMagnify.Size = new System.Drawing.Size(120, 20);
            this.trkMagnify.TabIndex = 6;
            this.trkMagnify.TabStop = true;
            this.trkMagnify.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkMagnify.ToolTipText = "Slide to set the magnification level";
            this.trkMagnify.ToolTipTitle = "Background Magnification";
            this.trkMagnify.Value = 1;
            this.trkMagnify.ValueChanged += new System.EventHandler(this.trkMagnify_ValueChanged);
            // 
            // TileReplacementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 390);
            this.Controls.Add(this.lblMagnify);
            this.Controls.Add(this.pnlMagnify);
            this.Controls.Add(this.trkMagnify);
            this.Controls.Add(this.pyxTabbedGroupBox1);
            this.Controls.Add(this.lblLayers);
            this.Controls.Add(this.cboLayers);
            this.Controls.Add(this.grpTarget);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.chkEmpty);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TileReplacementForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tile Replacement";
            this.grpTarget.ResumeLayout(false);
            this.pyxTabbedGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMare.Controls.GMareBackgroundPanel pnlTarget;
        private GMare.Controls.GMareBackgroundPanel pnlReplacement;
        private System.Windows.Forms.CheckBox chkEmpty;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butCancel;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butOk;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabbedGroupBox grpTarget;
        private System.Windows.Forms.ComboBox cboLayers;
        private System.Windows.Forms.Label lblLayers;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabbedGroupBox pyxTabbedGroupBox1;
        private System.Windows.Forms.Label lblMagnify;
        private System.Windows.Forms.Panel pnlMagnify;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTrackBar trkMagnify;
    }
}