namespace GMare
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewProject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSep01 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSaveBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSep02 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuImportFrom = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportImage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportGMare = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExportTo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExportImage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExportBinary = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExportGMProject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSep03 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPreferences = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSep04 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSep05 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContents = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.grpEdit = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabbedGroupBox();
            this.butDelete = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butPaste = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butCopy = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butCut = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butRedo = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butUndo = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.grpRoom = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabbedGroupBox();
            this.butRoomScript = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butRoomPersistent = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butRoomBackColor = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.lblRoomName = new System.Windows.Forms.Label();
            this.txtRoomName = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox();
            this.nudRoomSpeed = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.lblRoomCaption = new System.Windows.Forms.Label();
            this.lblRoomSpeed = new System.Windows.Forms.Label();
            this.txtRoomCaption = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox();
            this.nudRoomRows = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.lblRoomColumns = new System.Windows.Forms.Label();
            this.lblRoomRows = new System.Windows.Forms.Label();
            this.nudRoomColumns = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlRoom = new System.Windows.Forms.Panel();
            this.butGrid = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butInvertGridColor = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butGridIso = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.lblRoomGridX = new System.Windows.Forms.Label();
            this.butGridSnap = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.lblRoomGridY = new System.Windows.Forms.Label();
            this.butShowBlocks = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.nudRoomGridX = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.nudRoomGridY = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown();
            this.lblRoomMagnify = new System.Windows.Forms.Label();
            this.trkRoomMagnify = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTrackBar();
            this.butShowInstances = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.pnlRoomMagnify = new System.Windows.Forms.Panel();
            this.grpRoomEditor = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabbedGroupBox();
            this.splRoom = new System.Windows.Forms.Splitter();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.tabMain = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabControl();
            this.tabTiles = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabPage();
            this.grpTiles = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.pnlBackgroundTools = new System.Windows.Forms.Panel();
            this.butBackgroundEdit = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butBrushTool = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.lblBackgroundMagnify = new System.Windows.Forms.Label();
            this.butBucketFillTool = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.pnlBackgroundMagnify = new System.Windows.Forms.Panel();
            this.butSelectionTool = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.trkBackgroundMagnify = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTrackBar();
            this.butReplace = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.splBackground = new System.Windows.Forms.Splitter();
            this.grpLayers = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox();
            this.butLayerView = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butLayerMove = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butLayerMerge = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butLayerClear = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butLayerDelete = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butLayerEdit = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.butLayerAdd = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.lstLayers = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckedListBox();
            this.tabObjects = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabPage();
            this.txtObject = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButtonTextbox();
            this.pnlObject = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxPanel();
            this.tabInstancesMain = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabControl();
            this.tabInstances = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabPage();
            this.mnuInstances = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSearchObjects = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetAsObject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeparator01 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSortStandard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSortAscending = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSortDescending = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeparator06 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInstanceReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInstanceReplaceAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeparator07 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInstanceCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInstanceCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInstancePaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeparator08 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInstancePosition = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInstanceBringFront = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInstanceSendBack = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInstanceSnap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInstanceCode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeparator09 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInstanceDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInstanceDeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInstanceClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tabBlocks = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabPage();
            this.butBlocksClear = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.lblBlockMagnify = new System.Windows.Forms.Label();
            this.pnlBlockMagnify = new System.Windows.Forms.Panel();
            this.trkBlockMagnify = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTrackBar();
            this.lblObject = new System.Windows.Forms.Label();
            this.butObjectsImport = new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.sslInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslActual = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslSnapped = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuObjects = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pnlRoomEditor = new GMare.Controls.GMareRoomEditor();
            this.pnlBackground = new GMare.Controls.GMareBackgroundPanel();
            this.lstInstances = new GMare.Controls.GMareListbox();
            this.pnlBlockEditor = new GMare.Controls.GMareBlockEditor();
            this.mnuMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpEdit.SuspendLayout();
            this.grpRoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomColumns)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlRoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomGridX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomGridY)).BeginInit();
            this.grpRoomEditor.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabTiles.SuspendLayout();
            this.grpTiles.SuspendLayout();
            this.pnlBackgroundTools.SuspendLayout();
            this.grpLayers.SuspendLayout();
            this.tabObjects.SuspendLayout();
            this.tabInstancesMain.SuspendLayout();
            this.tabInstances.SuspendLayout();
            this.mnuInstances.SuspendLayout();
            this.tabBlocks.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(786, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            this.mnuMain.Click += new System.EventHandler(this.mnuMain_Click);
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewProject,
            this.mnuOpenProject,
            this.mnuSep01,
            this.mnuSaveBackground,
            this.mnuSave,
            this.mnuSaveAs,
            this.mnuSep02,
            this.mnuImportFrom,
            this.mnuExportTo,
            this.mnuSep03,
            this.mnuPreferences,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuNewProject
            // 
            this.mnuNewProject.Image = global::GMare.Properties.Resources.application;
            this.mnuNewProject.Name = "mnuNewProject";
            this.mnuNewProject.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.mnuNewProject.Size = new System.Drawing.Size(218, 22);
            this.mnuNewProject.Text = "New Project";
            this.mnuNewProject.Click += new System.EventHandler(this.mnuMenuItem_Click);
            // 
            // mnuOpenProject
            // 
            this.mnuOpenProject.Image = global::GMare.Properties.Resources.file_open;
            this.mnuOpenProject.Name = "mnuOpenProject";
            this.mnuOpenProject.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.mnuOpenProject.Size = new System.Drawing.Size(218, 22);
            this.mnuOpenProject.Text = "Open Project";
            this.mnuOpenProject.Click += new System.EventHandler(this.mnuMenuItem_Click);
            // 
            // mnuSep01
            // 
            this.mnuSep01.Name = "mnuSep01";
            this.mnuSep01.Size = new System.Drawing.Size(215, 6);
            // 
            // mnuSaveBackground
            // 
            this.mnuSaveBackground.Image = global::GMare.Properties.Resources.tileset_image;
            this.mnuSaveBackground.Name = "mnuSaveBackground";
            this.mnuSaveBackground.Size = new System.Drawing.Size(218, 22);
            this.mnuSaveBackground.Text = "Save Background";
            this.mnuSaveBackground.Click += new System.EventHandler(this.mnuMenuItem_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Image = global::GMare.Properties.Resources.save;
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSave.Size = new System.Drawing.Size(218, 22);
            this.mnuSave.Text = "Save Project";
            this.mnuSave.Click += new System.EventHandler(this.mnuMenuItem_Click);
            // 
            // mnuSaveAs
            // 
            this.mnuSaveAs.Image = global::GMare.Properties.Resources.save_as;
            this.mnuSaveAs.Name = "mnuSaveAs";
            this.mnuSaveAs.Size = new System.Drawing.Size(218, 22);
            this.mnuSaveAs.Text = "Save As...";
            this.mnuSaveAs.Click += new System.EventHandler(this.mnuMenuItem_Click);
            // 
            // mnuSep02
            // 
            this.mnuSep02.Name = "mnuSep02";
            this.mnuSep02.Size = new System.Drawing.Size(215, 6);
            // 
            // mnuImportFrom
            // 
            this.mnuImportFrom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImportImage,
            this.mnuImportGMare});
            this.mnuImportFrom.Image = global::GMare.Properties.Resources.import;
            this.mnuImportFrom.Name = "mnuImportFrom";
            this.mnuImportFrom.Size = new System.Drawing.Size(218, 22);
            this.mnuImportFrom.Text = "Import From...";
            // 
            // mnuImportImage
            // 
            this.mnuImportImage.Image = ((System.Drawing.Image)(resources.GetObject("mnuImportImage.Image")));
            this.mnuImportImage.Name = "mnuImportImage";
            this.mnuImportImage.Size = new System.Drawing.Size(149, 22);
            this.mnuImportImage.Text = "Image File";
            this.mnuImportImage.Click += new System.EventHandler(this.mnuMenuItem_Click);
            // 
            // mnuImportGMare
            // 
            this.mnuImportGMare.Name = "mnuImportGMare";
            this.mnuImportGMare.Size = new System.Drawing.Size(149, 22);
            this.mnuImportGMare.Text = "GMare Project";
            this.mnuImportGMare.Click += new System.EventHandler(this.mnuMenuItem_Click);
            // 
            // mnuExportTo
            // 
            this.mnuExportTo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExportImage,
            this.mnuExportBinary,
            this.mnuExportGMProject});
            this.mnuExportTo.Image = global::GMare.Properties.Resources.export;
            this.mnuExportTo.Name = "mnuExportTo";
            this.mnuExportTo.Size = new System.Drawing.Size(218, 22);
            this.mnuExportTo.Text = "Export To...";
            // 
            // mnuExportImage
            // 
            this.mnuExportImage.Image = ((System.Drawing.Image)(resources.GetObject("mnuExportImage.Image")));
            this.mnuExportImage.Name = "mnuExportImage";
            this.mnuExportImage.Size = new System.Drawing.Size(154, 22);
            this.mnuExportImage.Text = "Image File";
            this.mnuExportImage.Click += new System.EventHandler(this.mnuMenuItem_Click);
            // 
            // mnuExportBinary
            // 
            this.mnuExportBinary.Image = global::GMare.Properties.Resources.export_bin;
            this.mnuExportBinary.Name = "mnuExportBinary";
            this.mnuExportBinary.Size = new System.Drawing.Size(154, 22);
            this.mnuExportBinary.Text = "Binary File";
            this.mnuExportBinary.Click += new System.EventHandler(this.mnuMenuItem_Click);
            // 
            // mnuExportGMProject
            // 
            this.mnuExportGMProject.Image = global::GMare.Properties.Resources.export_gm;
            this.mnuExportGMProject.Name = "mnuExportGMProject";
            this.mnuExportGMProject.Size = new System.Drawing.Size(154, 22);
            this.mnuExportGMProject.Text = "GM Project File";
            this.mnuExportGMProject.Click += new System.EventHandler(this.mnuMenuItem_Click);
            // 
            // mnuSep03
            // 
            this.mnuSep03.Name = "mnuSep03";
            this.mnuSep03.Size = new System.Drawing.Size(215, 6);
            // 
            // mnuPreferences
            // 
            this.mnuPreferences.Image = global::GMare.Properties.Resources.preferences;
            this.mnuPreferences.Name = "mnuPreferences";
            this.mnuPreferences.Size = new System.Drawing.Size(218, 22);
            this.mnuPreferences.Text = "Preferences";
            this.mnuPreferences.Click += new System.EventHandler(this.mnuMenuItem_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Image = global::GMare.Properties.Resources.exit;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(218, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuMenuItem_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUndo,
            this.mnuRedo,
            this.mnuSep04,
            this.mnuCut,
            this.mnuCopy,
            this.mnuPaste,
            this.mnuSep05,
            this.mnuDelete});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(39, 20);
            this.mnuEdit.Text = "&Edit";
            // 
            // mnuUndo
            // 
            this.mnuUndo.Image = global::GMare.Properties.Resources.arrow_undo;
            this.mnuUndo.Name = "mnuUndo";
            this.mnuUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.mnuUndo.Size = new System.Drawing.Size(144, 22);
            this.mnuUndo.Text = "Undo";
            this.mnuUndo.Click += new System.EventHandler(this.mnuMenuItem_Click);
            // 
            // mnuRedo
            // 
            this.mnuRedo.Image = global::GMare.Properties.Resources.arrow_redo;
            this.mnuRedo.Name = "mnuRedo";
            this.mnuRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.mnuRedo.Size = new System.Drawing.Size(144, 22);
            this.mnuRedo.Text = "Redo";
            this.mnuRedo.Click += new System.EventHandler(this.mnuMenuItem_Click);
            // 
            // mnuSep04
            // 
            this.mnuSep04.Name = "mnuSep04";
            this.mnuSep04.Size = new System.Drawing.Size(141, 6);
            // 
            // mnuCut
            // 
            this.mnuCut.Image = global::GMare.Properties.Resources.clipboard_cut;
            this.mnuCut.Name = "mnuCut";
            this.mnuCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuCut.Size = new System.Drawing.Size(144, 22);
            this.mnuCut.Text = "Cut";
            this.mnuCut.Click += new System.EventHandler(this.mnuMenuItem_Click);
            // 
            // mnuCopy
            // 
            this.mnuCopy.Image = global::GMare.Properties.Resources.clipboard_copy;
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuCopy.Size = new System.Drawing.Size(144, 22);
            this.mnuCopy.Text = "Copy";
            this.mnuCopy.Click += new System.EventHandler(this.mnuMenuItem_Click);
            // 
            // mnuPaste
            // 
            this.mnuPaste.Image = global::GMare.Properties.Resources.clipboard_paste;
            this.mnuPaste.Name = "mnuPaste";
            this.mnuPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuPaste.Size = new System.Drawing.Size(144, 22);
            this.mnuPaste.Text = "Paste";
            this.mnuPaste.Click += new System.EventHandler(this.mnuMenuItem_Click);
            // 
            // mnuSep05
            // 
            this.mnuSep05.Name = "mnuSep05";
            this.mnuSep05.Size = new System.Drawing.Size(141, 6);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = global::GMare.Properties.Resources.button_decline;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.mnuDelete.Size = new System.Drawing.Size(144, 22);
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuMenuItem_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuContents,
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuContents
            // 
            this.mnuContents.Image = global::GMare.Properties.Resources.contents;
            this.mnuContents.Name = "mnuContents";
            this.mnuContents.Size = new System.Drawing.Size(145, 22);
            this.mnuContents.Text = "Contents";
            this.mnuContents.Click += new System.EventHandler(this.mnuMenuItem_Click);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Image = global::GMare.Properties.Resources.about;
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(145, 22);
            this.mnuAbout.Text = "About GMare";
            this.mnuAbout.Click += new System.EventHandler(this.mnuMenuItem_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.grpEdit);
            this.pnlTop.Controls.Add(this.grpRoom);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 24);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(786, 48);
            this.pnlTop.TabIndex = 0;
            // 
            // grpEdit
            // 
            this.grpEdit.BackColor = System.Drawing.Color.Transparent;
            this.grpEdit.CenterStatus = false;
            this.grpEdit.Controls.Add(this.butDelete);
            this.grpEdit.Controls.Add(this.butPaste);
            this.grpEdit.Controls.Add(this.butCopy);
            this.grpEdit.Controls.Add(this.butCut);
            this.grpEdit.Controls.Add(this.butRedo);
            this.grpEdit.Controls.Add(this.butUndo);
            this.grpEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpEdit.Location = new System.Drawing.Point(2, 4);
            this.grpEdit.MinimumSize = new System.Drawing.Size(24, 0);
            this.grpEdit.Name = "grpEdit";
            this.grpEdit.Padding = new System.Windows.Forms.Padding(10, 12, 10, 30);
            this.grpEdit.ShowStatusBar = false;
            this.grpEdit.Size = new System.Drawing.Size(166, 43);
            this.grpEdit.StatusBarHeight = 16;
            this.grpEdit.StatusBarText = "Status:";
            this.grpEdit.TabIndex = 0;
            this.grpEdit.TabStop = false;
            // 
            // butDelete
            // 
            this.butDelete.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butDelete.Checked = false;
            this.butDelete.FlatStyled = false;
            this.butDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butDelete.Image = global::GMare.Properties.Resources.button_decline;
            this.butDelete.ImageXOffset = 0;
            this.butDelete.ImageYOffset = 0;
            this.butDelete.Location = new System.Drawing.Point(132, 10);
            this.butDelete.Name = "butDelete";
            this.butDelete.PushButtonImage = null;
            this.butDelete.Size = new System.Drawing.Size(24, 24);
            this.butDelete.TabIndex = 5;
            this.butDelete.TextXOffset = 0;
            this.butDelete.TextYOffset = 0;
            this.butDelete.ToolTipText = "Delete selected tiles or instances";
            this.butDelete.ToolTipTitle = "Delete (Del)";
            this.butDelete.UseDropShadow = true;
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // butPaste
            // 
            this.butPaste.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butPaste.Checked = false;
            this.butPaste.FlatStyled = false;
            this.butPaste.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butPaste.Image = global::GMare.Properties.Resources.clipboard_paste;
            this.butPaste.ImageXOffset = 0;
            this.butPaste.ImageYOffset = 0;
            this.butPaste.Location = new System.Drawing.Point(107, 10);
            this.butPaste.Name = "butPaste";
            this.butPaste.PushButtonImage = null;
            this.butPaste.Size = new System.Drawing.Size(24, 24);
            this.butPaste.TabIndex = 4;
            this.butPaste.TextXOffset = 0;
            this.butPaste.TextYOffset = 0;
            this.butPaste.ToolTipText = "Past copied tiles or instances";
            this.butPaste.ToolTipTitle = "Paste (Ctrl+V)";
            this.butPaste.UseDropShadow = true;
            this.butPaste.UseVisualStyleBackColor = true;
            this.butPaste.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // butCopy
            // 
            this.butCopy.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butCopy.Checked = false;
            this.butCopy.FlatStyled = false;
            this.butCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCopy.Image = global::GMare.Properties.Resources.clipboard_copy;
            this.butCopy.ImageXOffset = 0;
            this.butCopy.ImageYOffset = 0;
            this.butCopy.Location = new System.Drawing.Point(82, 10);
            this.butCopy.Name = "butCopy";
            this.butCopy.PushButtonImage = null;
            this.butCopy.Size = new System.Drawing.Size(24, 24);
            this.butCopy.TabIndex = 3;
            this.butCopy.TextXOffset = 0;
            this.butCopy.TextYOffset = 0;
            this.butCopy.ToolTipText = " Copy selected tiles or instances";
            this.butCopy.ToolTipTitle = "Copy (Ctrl+C)";
            this.butCopy.UseDropShadow = true;
            this.butCopy.UseVisualStyleBackColor = true;
            this.butCopy.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // butCut
            // 
            this.butCut.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butCut.Checked = false;
            this.butCut.FlatStyled = false;
            this.butCut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCut.Image = global::GMare.Properties.Resources.clipboard_cut;
            this.butCut.ImageXOffset = 1;
            this.butCut.ImageYOffset = 0;
            this.butCut.Location = new System.Drawing.Point(58, 10);
            this.butCut.Name = "butCut";
            this.butCut.PushButtonImage = null;
            this.butCut.Size = new System.Drawing.Size(23, 24);
            this.butCut.TabIndex = 2;
            this.butCut.TextXOffset = 0;
            this.butCut.TextYOffset = 0;
            this.butCut.ToolTipText = "Cut selected tiles or instances";
            this.butCut.ToolTipTitle = "Cut (Ctrl+X)";
            this.butCut.UseDropShadow = true;
            this.butCut.UseVisualStyleBackColor = true;
            this.butCut.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // butRedo
            // 
            this.butRedo.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butRedo.Checked = false;
            this.butRedo.FlatStyled = false;
            this.butRedo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRedo.Image = global::GMare.Properties.Resources.arrow_redo;
            this.butRedo.ImageXOffset = 1;
            this.butRedo.ImageYOffset = 0;
            this.butRedo.Location = new System.Drawing.Point(34, 10);
            this.butRedo.Name = "butRedo";
            this.butRedo.PushButtonImage = null;
            this.butRedo.Size = new System.Drawing.Size(23, 24);
            this.butRedo.TabIndex = 1;
            this.butRedo.TextXOffset = 0;
            this.butRedo.TextYOffset = 0;
            this.butRedo.ToolTipText = "Redo a room change";
            this.butRedo.ToolTipTitle = "Redo (Ctrl+Y)";
            this.butRedo.UseDropShadow = true;
            this.butRedo.UseVisualStyleBackColor = true;
            this.butRedo.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // butUndo
            // 
            this.butUndo.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butUndo.Checked = false;
            this.butUndo.FlatStyled = false;
            this.butUndo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butUndo.Image = global::GMare.Properties.Resources.arrow_undo;
            this.butUndo.ImageXOffset = 1;
            this.butUndo.ImageYOffset = 0;
            this.butUndo.Location = new System.Drawing.Point(10, 10);
            this.butUndo.Name = "butUndo";
            this.butUndo.PushButtonImage = null;
            this.butUndo.Size = new System.Drawing.Size(23, 24);
            this.butUndo.TabIndex = 0;
            this.butUndo.TextXOffset = 0;
            this.butUndo.TextYOffset = 0;
            this.butUndo.ToolTipText = "Undo a room change";
            this.butUndo.ToolTipTitle = "Undo (Ctrl+Z)";
            this.butUndo.UseDropShadow = true;
            this.butUndo.UseVisualStyleBackColor = true;
            this.butUndo.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // grpRoom
            // 
            this.grpRoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRoom.BackColor = System.Drawing.Color.Transparent;
            this.grpRoom.CenterStatus = false;
            this.grpRoom.Controls.Add(this.butRoomScript);
            this.grpRoom.Controls.Add(this.butRoomPersistent);
            this.grpRoom.Controls.Add(this.butRoomBackColor);
            this.grpRoom.Controls.Add(this.lblRoomName);
            this.grpRoom.Controls.Add(this.txtRoomName);
            this.grpRoom.Controls.Add(this.nudRoomSpeed);
            this.grpRoom.Controls.Add(this.lblRoomCaption);
            this.grpRoom.Controls.Add(this.lblRoomSpeed);
            this.grpRoom.Controls.Add(this.txtRoomCaption);
            this.grpRoom.Controls.Add(this.nudRoomRows);
            this.grpRoom.Controls.Add(this.lblRoomColumns);
            this.grpRoom.Controls.Add(this.lblRoomRows);
            this.grpRoom.Controls.Add(this.nudRoomColumns);
            this.grpRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpRoom.Location = new System.Drawing.Point(170, 4);
            this.grpRoom.MinimumSize = new System.Drawing.Size(24, 0);
            this.grpRoom.Name = "grpRoom";
            this.grpRoom.Padding = new System.Windows.Forms.Padding(10, 12, 10, 30);
            this.grpRoom.ShowStatusBar = false;
            this.grpRoom.Size = new System.Drawing.Size(612, 43);
            this.grpRoom.StatusBarHeight = 16;
            this.grpRoom.StatusBarText = "Status:";
            this.grpRoom.TabIndex = 1;
            this.grpRoom.TabStop = false;
            // 
            // butRoomScript
            // 
            this.butRoomScript.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butRoomScript.Checked = false;
            this.butRoomScript.FlatStyled = false;
            this.butRoomScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRoomScript.Image = global::GMare.Properties.Resources.script;
            this.butRoomScript.ImageXOffset = 0;
            this.butRoomScript.ImageYOffset = 0;
            this.butRoomScript.Location = new System.Drawing.Point(58, 10);
            this.butRoomScript.Name = "butRoomScript";
            this.butRoomScript.PushButtonImage = null;
            this.butRoomScript.Size = new System.Drawing.Size(23, 24);
            this.butRoomScript.TabIndex = 2;
            this.butRoomScript.TextXOffset = 0;
            this.butRoomScript.TextYOffset = 0;
            this.butRoomScript.ToolTipText = "Set the GML code during room creation";
            this.butRoomScript.ToolTipTitle = "Room Creation Code (T)";
            this.butRoomScript.UseDropShadow = true;
            this.butRoomScript.UseVisualStyleBackColor = true;
            this.butRoomScript.Click += new System.EventHandler(this.butRoomScript_Click);
            // 
            // butRoomPersistent
            // 
            this.butRoomPersistent.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.PushButton;
            this.butRoomPersistent.Checked = false;
            this.butRoomPersistent.FlatStyled = false;
            this.butRoomPersistent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRoomPersistent.Image = global::GMare.Properties.Resources.persistent;
            this.butRoomPersistent.ImageXOffset = 1;
            this.butRoomPersistent.ImageYOffset = 1;
            this.butRoomPersistent.Location = new System.Drawing.Point(34, 10);
            this.butRoomPersistent.Name = "butRoomPersistent";
            this.butRoomPersistent.PushButtonImage = null;
            this.butRoomPersistent.Size = new System.Drawing.Size(23, 24);
            this.butRoomPersistent.TabIndex = 1;
            this.butRoomPersistent.TextXOffset = 0;
            this.butRoomPersistent.TextYOffset = 0;
            this.butRoomPersistent.ToolTipText = "Check or Uncheck if the room is persistent";
            this.butRoomPersistent.ToolTipTitle = "Check/Uncheck Room Persistent (W)";
            this.butRoomPersistent.UseDropShadow = true;
            this.butRoomPersistent.UseVisualStyleBackColor = true;
            this.butRoomPersistent.CheckChanged += new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.CheckChangedEventHandler(this.butRoomPersistent_CheckChanged);
            // 
            // butRoomBackColor
            // 
            this.butRoomBackColor.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butRoomBackColor.Checked = false;
            this.butRoomBackColor.FlatStyled = false;
            this.butRoomBackColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRoomBackColor.Image = global::GMare.Properties.Resources.color_swatch;
            this.butRoomBackColor.ImageXOffset = 1;
            this.butRoomBackColor.ImageYOffset = 0;
            this.butRoomBackColor.Location = new System.Drawing.Point(10, 10);
            this.butRoomBackColor.Name = "butRoomBackColor";
            this.butRoomBackColor.PushButtonImage = null;
            this.butRoomBackColor.Size = new System.Drawing.Size(23, 24);
            this.butRoomBackColor.TabIndex = 0;
            this.butRoomBackColor.TextXOffset = 0;
            this.butRoomBackColor.TextYOffset = 0;
            this.butRoomBackColor.ToolTipText = "Set room back color";
            this.butRoomBackColor.ToolTipTitle = "Room Back Color (C)";
            this.butRoomBackColor.UseDropShadow = true;
            this.butRoomBackColor.UseVisualStyleBackColor = true;
            this.butRoomBackColor.Click += new System.EventHandler(this.butRoomBackColor_Click);
            // 
            // lblRoomName
            // 
            this.lblRoomName.AutoSize = true;
            this.lblRoomName.Location = new System.Drawing.Point(84, 16);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(38, 13);
            this.lblRoomName.TabIndex = 3;
            this.lblRoomName.Text = "Name:";
            // 
            // txtRoomName
            // 
            this.txtRoomName.Location = new System.Drawing.Point(124, 12);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(76, 20);
            this.txtRoomName.TabIndex = 4;
            this.txtRoomName.ToolTipText = "The name used for this room when exported";
            this.txtRoomName.ToolTipTitle = "Room Name";
            this.txtRoomName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRoomText_KeyDown);
            this.txtRoomName.Leave += new System.EventHandler(this.txtRoomText_Leave);
            // 
            // nudRoomSpeed
            // 
            this.nudRoomSpeed.IgnoreHeight = true;
            this.nudRoomSpeed.Location = new System.Drawing.Point(560, 13);
            this.nudRoomSpeed.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudRoomSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRoomSpeed.Name = "nudRoomSpeed";
            this.nudRoomSpeed.Size = new System.Drawing.Size(40, 20);
            this.nudRoomSpeed.TabIndex = 12;
            this.nudRoomSpeed.ToolTipText = "The frame rate of the room";
            this.nudRoomSpeed.ToolTipTitle = "Room Speed";
            this.nudRoomSpeed.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudRoomSpeed.ValueChanged += new System.EventHandler(this.nudRoom_ValueChanged);
            // 
            // lblRoomCaption
            // 
            this.lblRoomCaption.AutoSize = true;
            this.lblRoomCaption.Location = new System.Drawing.Point(204, 16);
            this.lblRoomCaption.Name = "lblRoomCaption";
            this.lblRoomCaption.Size = new System.Drawing.Size(46, 13);
            this.lblRoomCaption.TabIndex = 5;
            this.lblRoomCaption.Text = "Caption:";
            // 
            // lblRoomSpeed
            // 
            this.lblRoomSpeed.AutoSize = true;
            this.lblRoomSpeed.Location = new System.Drawing.Point(516, 16);
            this.lblRoomSpeed.Name = "lblRoomSpeed";
            this.lblRoomSpeed.Size = new System.Drawing.Size(41, 13);
            this.lblRoomSpeed.TabIndex = 11;
            this.lblRoomSpeed.Text = "Speed:";
            // 
            // txtRoomCaption
            // 
            this.txtRoomCaption.Location = new System.Drawing.Point(252, 12);
            this.txtRoomCaption.Name = "txtRoomCaption";
            this.txtRoomCaption.Size = new System.Drawing.Size(80, 20);
            this.txtRoomCaption.TabIndex = 6;
            this.txtRoomCaption.ToolTipText = "The text used on the game window";
            this.txtRoomCaption.ToolTipTitle = "Room Caption";
            this.txtRoomCaption.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRoomText_KeyDown);
            this.txtRoomCaption.Leave += new System.EventHandler(this.txtRoomText_Leave);
            // 
            // nudRoomRows
            // 
            this.nudRoomRows.IgnoreHeight = true;
            this.nudRoomRows.Location = new System.Drawing.Point(472, 13);
            this.nudRoomRows.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudRoomRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRoomRows.Name = "nudRoomRows";
            this.nudRoomRows.Size = new System.Drawing.Size(40, 20);
            this.nudRoomRows.TabIndex = 10;
            this.nudRoomRows.ToolTipText = "The height of the room in tiles";
            this.nudRoomRows.ToolTipTitle = "Room Rows";
            this.nudRoomRows.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudRoomRows.ValueChanged += new System.EventHandler(this.nudRoom_ValueChanged);
            // 
            // lblRoomColumns
            // 
            this.lblRoomColumns.AutoSize = true;
            this.lblRoomColumns.Location = new System.Drawing.Point(336, 16);
            this.lblRoomColumns.Name = "lblRoomColumns";
            this.lblRoomColumns.Size = new System.Drawing.Size(50, 13);
            this.lblRoomColumns.TabIndex = 7;
            this.lblRoomColumns.Text = "Columns:";
            // 
            // lblRoomRows
            // 
            this.lblRoomRows.AutoSize = true;
            this.lblRoomRows.Location = new System.Drawing.Point(432, 16);
            this.lblRoomRows.Name = "lblRoomRows";
            this.lblRoomRows.Size = new System.Drawing.Size(37, 13);
            this.lblRoomRows.TabIndex = 9;
            this.lblRoomRows.Text = "Rows:";
            // 
            // nudRoomColumns
            // 
            this.nudRoomColumns.IgnoreHeight = true;
            this.nudRoomColumns.Location = new System.Drawing.Point(388, 13);
            this.nudRoomColumns.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudRoomColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRoomColumns.Name = "nudRoomColumns";
            this.nudRoomColumns.Size = new System.Drawing.Size(40, 20);
            this.nudRoomColumns.TabIndex = 8;
            this.nudRoomColumns.ToolTipText = "The width of the room in tiles";
            this.nudRoomColumns.ToolTipTitle = "Room Columns";
            this.nudRoomColumns.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudRoomColumns.ValueChanged += new System.EventHandler(this.nudRoom_ValueChanged);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.pnlRight);
            this.pnlBottom.Controls.Add(this.splRoom);
            this.pnlBottom.Controls.Add(this.pnlLeft);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 72);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(786, 442);
            this.pnlBottom.TabIndex = 5;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.grpRoomEditor);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(308, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.pnlRight.Size = new System.Drawing.Size(478, 442);
            this.pnlRight.TabIndex = 4;
            // 
            // pnlRoom
            // 
            this.pnlRoom.Controls.Add(this.butGrid);
            this.pnlRoom.Controls.Add(this.butInvertGridColor);
            this.pnlRoom.Controls.Add(this.butGridIso);
            this.pnlRoom.Controls.Add(this.lblRoomGridX);
            this.pnlRoom.Controls.Add(this.butGridSnap);
            this.pnlRoom.Controls.Add(this.lblRoomGridY);
            this.pnlRoom.Controls.Add(this.butShowBlocks);
            this.pnlRoom.Controls.Add(this.nudRoomGridX);
            this.pnlRoom.Controls.Add(this.nudRoomGridY);
            this.pnlRoom.Controls.Add(this.lblRoomMagnify);
            this.pnlRoom.Controls.Add(this.trkRoomMagnify);
            this.pnlRoom.Controls.Add(this.butShowInstances);
            this.pnlRoom.Controls.Add(this.pnlRoomMagnify);
            this.pnlRoom.Location = new System.Drawing.Point(12, 24);
            this.pnlRoom.Name = "pnlRoom";
            this.pnlRoom.Size = new System.Drawing.Size(454, 28);
            this.pnlRoom.TabIndex = 14;
            // 
            // butGrid
            // 
            this.butGrid.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.PushButton;
            this.butGrid.Checked = true;
            this.butGrid.FlatStyled = false;
            this.butGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butGrid.Image = ((System.Drawing.Image)(resources.GetObject("butGrid.Image")));
            this.butGrid.ImageXOffset = 1;
            this.butGrid.ImageYOffset = 0;
            this.butGrid.Location = new System.Drawing.Point(0, 2);
            this.butGrid.Name = "butGrid";
            this.butGrid.PushButtonImage = null;
            this.butGrid.Size = new System.Drawing.Size(23, 24);
            this.butGrid.TabIndex = 0;
            this.butGrid.TextXOffset = 0;
            this.butGrid.TextYOffset = 0;
            this.butGrid.ToolTipText = "Show or hide the room grid";
            this.butGrid.ToolTipTitle = "Show/Hide Grid (G)";
            this.butGrid.UseDropShadow = true;
            this.butGrid.UseVisualStyleBackColor = true;
            this.butGrid.CheckChanged += new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.CheckChangedEventHandler(this.butRoomOptions_CheckChanged);
            // 
            // butInvertGridColor
            // 
            this.butInvertGridColor.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.PushButton;
            this.butInvertGridColor.Checked = false;
            this.butInvertGridColor.FlatStyled = false;
            this.butInvertGridColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInvertGridColor.Image = global::GMare.Properties.Resources.grid_color;
            this.butInvertGridColor.ImageXOffset = 0;
            this.butInvertGridColor.ImageYOffset = 0;
            this.butInvertGridColor.Location = new System.Drawing.Point(73, 2);
            this.butInvertGridColor.Name = "butInvertGridColor";
            this.butInvertGridColor.PushButtonImage = null;
            this.butInvertGridColor.Size = new System.Drawing.Size(24, 24);
            this.butInvertGridColor.TabIndex = 13;
            this.butInvertGridColor.TextXOffset = 0;
            this.butInvertGridColor.TextYOffset = 0;
            this.butInvertGridColor.ToolTipText = "Toggle the grid color between black and white";
            this.butInvertGridColor.ToolTipTitle = "Toggle Grid Color";
            this.butInvertGridColor.UseDropShadow = true;
            this.butInvertGridColor.UseVisualStyleBackColor = true;
            this.butInvertGridColor.CheckChanged += new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.CheckChangedEventHandler(this.butRoomOptions_CheckChanged);
            // 
            // butGridIso
            // 
            this.butGridIso.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.PushButton;
            this.butGridIso.Checked = false;
            this.butGridIso.FlatStyled = false;
            this.butGridIso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butGridIso.Image = ((System.Drawing.Image)(resources.GetObject("butGridIso.Image")));
            this.butGridIso.ImageXOffset = 1;
            this.butGridIso.ImageYOffset = 0;
            this.butGridIso.Location = new System.Drawing.Point(24, 2);
            this.butGridIso.Name = "butGridIso";
            this.butGridIso.PushButtonImage = null;
            this.butGridIso.Size = new System.Drawing.Size(23, 24);
            this.butGridIso.TabIndex = 1;
            this.butGridIso.TextXOffset = 0;
            this.butGridIso.TextYOffset = 0;
            this.butGridIso.ToolTipText = "Show or hide drawing the grid in an isometric view";
            this.butGridIso.ToolTipTitle = "Show/Hide Isometric Grid (I)";
            this.butGridIso.UseDropShadow = true;
            this.butGridIso.UseVisualStyleBackColor = true;
            this.butGridIso.CheckChanged += new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.CheckChangedEventHandler(this.butRoomOptions_CheckChanged);
            // 
            // lblRoomGridX
            // 
            this.lblRoomGridX.AutoSize = true;
            this.lblRoomGridX.Location = new System.Drawing.Point(148, 8);
            this.lblRoomGridX.Name = "lblRoomGridX";
            this.lblRoomGridX.Size = new System.Drawing.Size(39, 13);
            this.lblRoomGridX.TabIndex = 5;
            this.lblRoomGridX.Text = "Grid X:";
            // 
            // butGridSnap
            // 
            this.butGridSnap.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.PushButton;
            this.butGridSnap.Checked = true;
            this.butGridSnap.FlatStyled = false;
            this.butGridSnap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butGridSnap.Image = global::GMare.Properties.Resources.grid_snap;
            this.butGridSnap.ImageXOffset = 0;
            this.butGridSnap.ImageYOffset = 0;
            this.butGridSnap.Location = new System.Drawing.Point(48, 2);
            this.butGridSnap.Name = "butGridSnap";
            this.butGridSnap.PushButtonImage = null;
            this.butGridSnap.Size = new System.Drawing.Size(24, 24);
            this.butGridSnap.TabIndex = 2;
            this.butGridSnap.TextXOffset = 0;
            this.butGridSnap.TextYOffset = 0;
            this.butGridSnap.ToolTipText = "Snap or un-snap instances to the grid";
            this.butGridSnap.ToolTipTitle = "Snap/UnSnap To Grid (N)";
            this.butGridSnap.UseDropShadow = true;
            this.butGridSnap.UseVisualStyleBackColor = true;
            this.butGridSnap.CheckChanged += new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.CheckChangedEventHandler(this.butRoomOptions_CheckChanged);
            // 
            // lblRoomGridY
            // 
            this.lblRoomGridY.AutoSize = true;
            this.lblRoomGridY.Location = new System.Drawing.Point(232, 8);
            this.lblRoomGridY.Name = "lblRoomGridY";
            this.lblRoomGridY.Size = new System.Drawing.Size(39, 13);
            this.lblRoomGridY.TabIndex = 7;
            this.lblRoomGridY.Text = "Grid Y:";
            // 
            // butShowBlocks
            // 
            this.butShowBlocks.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.PushButton;
            this.butShowBlocks.Checked = true;
            this.butShowBlocks.FlatStyled = false;
            this.butShowBlocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butShowBlocks.Image = ((System.Drawing.Image)(resources.GetObject("butShowBlocks.Image")));
            this.butShowBlocks.ImageXOffset = 0;
            this.butShowBlocks.ImageYOffset = 0;
            this.butShowBlocks.Location = new System.Drawing.Point(123, 2);
            this.butShowBlocks.Name = "butShowBlocks";
            this.butShowBlocks.PushButtonImage = null;
            this.butShowBlocks.Size = new System.Drawing.Size(24, 24);
            this.butShowBlocks.TabIndex = 4;
            this.butShowBlocks.TextXOffset = 0;
            this.butShowBlocks.TextYOffset = 0;
            this.butShowBlocks.ToolTipText = "Show or hide instances that are used as blocks";
            this.butShowBlocks.ToolTipTitle = "Show/Hide Block Instances (Q)";
            this.butShowBlocks.UseDropShadow = true;
            this.butShowBlocks.UseVisualStyleBackColor = true;
            this.butShowBlocks.CheckChanged += new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.CheckChangedEventHandler(this.butRoomOptions_CheckChanged);
            // 
            // nudRoomGridX
            // 
            this.nudRoomGridX.IgnoreHeight = true;
            this.nudRoomGridX.Location = new System.Drawing.Point(188, 4);
            this.nudRoomGridX.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudRoomGridX.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudRoomGridX.Name = "nudRoomGridX";
            this.nudRoomGridX.Size = new System.Drawing.Size(40, 20);
            this.nudRoomGridX.TabIndex = 6;
            this.nudRoomGridX.ToolTipText = "The horizontal line spacing of the grid";
            this.nudRoomGridX.ToolTipTitle = "Grid X";
            this.nudRoomGridX.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudRoomGridX.ValueChanged += new System.EventHandler(this.nudRoomGrid_ValueChanged);
            // 
            // nudRoomGridY
            // 
            this.nudRoomGridY.IgnoreHeight = true;
            this.nudRoomGridY.Location = new System.Drawing.Point(272, 4);
            this.nudRoomGridY.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudRoomGridY.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudRoomGridY.Name = "nudRoomGridY";
            this.nudRoomGridY.Size = new System.Drawing.Size(40, 20);
            this.nudRoomGridY.TabIndex = 8;
            this.nudRoomGridY.ToolTipText = "The vertical line spacing of the grid";
            this.nudRoomGridY.ToolTipTitle = "Grid Y";
            this.nudRoomGridY.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudRoomGridY.ValueChanged += new System.EventHandler(this.nudRoomGrid_ValueChanged);
            // 
            // lblRoomMagnify
            // 
            this.lblRoomMagnify.AutoSize = true;
            this.lblRoomMagnify.Location = new System.Drawing.Point(420, 8);
            this.lblRoomMagnify.Name = "lblRoomMagnify";
            this.lblRoomMagnify.Size = new System.Drawing.Size(33, 13);
            this.lblRoomMagnify.TabIndex = 11;
            this.lblRoomMagnify.Text = "100%";
            // 
            // trkRoomMagnify
            // 
            this.trkRoomMagnify.BackColor = System.Drawing.Color.Transparent;
            this.trkRoomMagnify.LargeChange = 1;
            this.trkRoomMagnify.Location = new System.Drawing.Point(336, 4);
            this.trkRoomMagnify.Maximum = 7;
            this.trkRoomMagnify.Minimum = 1;
            this.trkRoomMagnify.Name = "trkRoomMagnify";
            this.trkRoomMagnify.Size = new System.Drawing.Size(92, 20);
            this.trkRoomMagnify.TabIndex = 10;
            this.trkRoomMagnify.TabStop = true;
            this.trkRoomMagnify.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkRoomMagnify.ToolTipText = "Slide to set the magnification level";
            this.trkRoomMagnify.ToolTipTitle = "Room Magnification";
            this.trkRoomMagnify.Value = 3;
            this.trkRoomMagnify.ValueChanged += new System.EventHandler(this.trkMagnify_ValueChanged);
            // 
            // butShowInstances
            // 
            this.butShowInstances.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.PushButton;
            this.butShowInstances.Checked = true;
            this.butShowInstances.FlatStyled = false;
            this.butShowInstances.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butShowInstances.Image = ((System.Drawing.Image)(resources.GetObject("butShowInstances.Image")));
            this.butShowInstances.ImageXOffset = 0;
            this.butShowInstances.ImageYOffset = 0;
            this.butShowInstances.Location = new System.Drawing.Point(98, 2);
            this.butShowInstances.Name = "butShowInstances";
            this.butShowInstances.PushButtonImage = null;
            this.butShowInstances.Size = new System.Drawing.Size(24, 24);
            this.butShowInstances.TabIndex = 3;
            this.butShowInstances.TextXOffset = 0;
            this.butShowInstances.TextYOffset = 0;
            this.butShowInstances.ToolTipText = "Show or hide instances when in tile mode";
            this.butShowInstances.ToolTipTitle = "Show/Hide Instances (A)";
            this.butShowInstances.UseDropShadow = true;
            this.butShowInstances.UseVisualStyleBackColor = true;
            this.butShowInstances.CheckChanged += new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.CheckChangedEventHandler(this.butRoomOptions_CheckChanged);
            // 
            // pnlRoomMagnify
            // 
            this.pnlRoomMagnify.BackgroundImage = global::GMare.Properties.Resources.magnifier;
            this.pnlRoomMagnify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlRoomMagnify.Location = new System.Drawing.Point(316, 2);
            this.pnlRoomMagnify.Name = "pnlRoomMagnify";
            this.pnlRoomMagnify.Size = new System.Drawing.Size(24, 24);
            this.pnlRoomMagnify.TabIndex = 9;
            // 
            // grpRoomEditor
            // 
            this.grpRoomEditor.BackColor = System.Drawing.Color.Transparent;
            this.grpRoomEditor.CenterStatus = false;
            this.grpRoomEditor.Controls.Add(this.pnlRoom);
            this.grpRoomEditor.Controls.Add(this.pnlRoomEditor);
            this.grpRoomEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRoomEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRoomEditor.Location = new System.Drawing.Point(0, 4);
            this.grpRoomEditor.MinimumSize = new System.Drawing.Size(90, 0);
            this.grpRoomEditor.Name = "grpRoomEditor";
            this.grpRoomEditor.Padding = new System.Windows.Forms.Padding(10, 12, 10, 0);
            this.grpRoomEditor.ShowStatusBar = true;
            this.grpRoomEditor.Size = new System.Drawing.Size(474, 434);
            this.grpRoomEditor.StatusBarHeight = 24;
            this.grpRoomEditor.StatusBarText = "";
            this.grpRoomEditor.TabIndex = 4;
            this.grpRoomEditor.TabStop = false;
            this.grpRoomEditor.Text = "Room Editor";
            // 
            // splRoom
            // 
            this.splRoom.Location = new System.Drawing.Point(304, 0);
            this.splRoom.Name = "splRoom";
            this.splRoom.Size = new System.Drawing.Size(4, 442);
            this.splRoom.TabIndex = 3;
            this.splRoom.TabStop = false;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.tabMain);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.MinimumSize = new System.Drawing.Size(304, 416);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.pnlLeft.Size = new System.Drawing.Size(304, 442);
            this.pnlLeft.TabIndex = 2;
            // 
            // tabMain
            // 
            this.tabMain.BackColor = System.Drawing.Color.Transparent;
            this.tabMain.Controls.Add(this.tabTiles);
            this.tabMain.Controls.Add(this.tabObjects);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tabMain.Location = new System.Drawing.Point(4, 4);
            this.tabMain.Name = "tabMain";
            this.tabMain.Scroll = false;
            this.tabMain.SelectedIndex = 0;
            this.tabMain.SelectedTab = this.tabTiles;
            this.tabMain.SelectTabMargin = 2;
            this.tabMain.Size = new System.Drawing.Size(300, 434);
            this.tabMain.TabDock = System.Windows.Forms.DockStyle.Top;
            this.tabMain.TabIndent = 8;
            this.tabMain.TabIndex = 2;
            this.tabMain.Text = "pyxTabControl1";
            this.tabMain.TabChanged += new System.EventHandler(this.tabMain_TabChanged);
            // 
            // tabTiles
            // 
            this.tabTiles.Controls.Add(this.grpTiles);
            this.tabTiles.Controls.Add(this.splBackground);
            this.tabTiles.Controls.Add(this.grpLayers);
            this.tabTiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTiles.Location = new System.Drawing.Point(3, 28);
            this.tabTiles.Name = "tabTiles";
            this.tabTiles.Padding = new System.Windows.Forms.Padding(4, 4, 8, 6);
            this.tabTiles.Size = new System.Drawing.Size(294, 403);
            this.tabTiles.TabIndex = 0;
            this.tabTiles.Text = "Tiles";
            // 
            // grpTiles
            // 
            this.grpTiles.BackColor = System.Drawing.Color.Transparent;
            this.grpTiles.Controls.Add(this.pnlBackgroundTools);
            this.grpTiles.Controls.Add(this.pnlBackground);
            this.grpTiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpTiles.Location = new System.Drawing.Point(4, 152);
            this.grpTiles.MinimumSize = new System.Drawing.Size(24, 0);
            this.grpTiles.Name = "grpTiles";
            this.grpTiles.Padding = new System.Windows.Forms.Padding(10, 12, 10, 30);
            this.grpTiles.Size = new System.Drawing.Size(282, 245);
            this.grpTiles.TabIndex = 2;
            this.grpTiles.TabStop = false;
            this.grpTiles.Text = "Background";
            this.grpTiles.TextBarHeight = 24;
            // 
            // pnlBackgroundTools
            // 
            this.pnlBackgroundTools.Controls.Add(this.butBackgroundEdit);
            this.pnlBackgroundTools.Controls.Add(this.butBrushTool);
            this.pnlBackgroundTools.Controls.Add(this.lblBackgroundMagnify);
            this.pnlBackgroundTools.Controls.Add(this.butBucketFillTool);
            this.pnlBackgroundTools.Controls.Add(this.pnlBackgroundMagnify);
            this.pnlBackgroundTools.Controls.Add(this.butSelectionTool);
            this.pnlBackgroundTools.Controls.Add(this.trkBackgroundMagnify);
            this.pnlBackgroundTools.Controls.Add(this.butReplace);
            this.pnlBackgroundTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBackgroundTools.Location = new System.Drawing.Point(10, 25);
            this.pnlBackgroundTools.Name = "pnlBackgroundTools";
            this.pnlBackgroundTools.Size = new System.Drawing.Size(262, 31);
            this.pnlBackgroundTools.TabIndex = 0;
            // 
            // butBackgroundEdit
            // 
            this.butBackgroundEdit.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butBackgroundEdit.Checked = false;
            this.butBackgroundEdit.FlatStyled = false;
            this.butBackgroundEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBackgroundEdit.Image = global::GMare.Properties.Resources.background;
            this.butBackgroundEdit.ImageXOffset = 0;
            this.butBackgroundEdit.ImageYOffset = 0;
            this.butBackgroundEdit.Location = new System.Drawing.Point(2, 4);
            this.butBackgroundEdit.Name = "butBackgroundEdit";
            this.butBackgroundEdit.PushButtonImage = null;
            this.butBackgroundEdit.Size = new System.Drawing.Size(24, 24);
            this.butBackgroundEdit.TabIndex = 0;
            this.butBackgroundEdit.TextXOffset = 0;
            this.butBackgroundEdit.TextYOffset = 0;
            this.butBackgroundEdit.ToolTipText = "Edit the background tiles";
            this.butBackgroundEdit.ToolTipTitle = "Edit Background (B)";
            this.butBackgroundEdit.UseDropShadow = true;
            this.butBackgroundEdit.UseVisualStyleBackColor = true;
            this.butBackgroundEdit.Click += new System.EventHandler(this.butBackgroundEdit_Click);
            // 
            // butBrushTool
            // 
            this.butBrushTool.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.PushButton;
            this.butBrushTool.Checked = true;
            this.butBrushTool.FlatStyled = false;
            this.butBrushTool.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBrushTool.Image = global::GMare.Properties.Resources.brush;
            this.butBrushTool.ImageXOffset = 0;
            this.butBrushTool.ImageYOffset = 0;
            this.butBrushTool.Location = new System.Drawing.Point(26, 4);
            this.butBrushTool.Name = "butBrushTool";
            this.butBrushTool.PushButtonImage = null;
            this.butBrushTool.Size = new System.Drawing.Size(24, 24);
            this.butBrushTool.TabIndex = 1;
            this.butBrushTool.TextXOffset = 0;
            this.butBrushTool.TextYOffset = 0;
            this.butBrushTool.ToolTipText = "Paint a selection of tiles to a  layer";
            this.butBrushTool.ToolTipTitle = "Tile Paint Tool (P)";
            this.butBrushTool.UseDropShadow = true;
            this.butBrushTool.UseVisualStyleBackColor = true;
            this.butBrushTool.Click += new System.EventHandler(this.butBackgroundEdit_Click);
            // 
            // lblBackgroundMagnify
            // 
            this.lblBackgroundMagnify.AutoSize = true;
            this.lblBackgroundMagnify.Location = new System.Drawing.Point(226, 10);
            this.lblBackgroundMagnify.Name = "lblBackgroundMagnify";
            this.lblBackgroundMagnify.Size = new System.Drawing.Size(33, 13);
            this.lblBackgroundMagnify.TabIndex = 7;
            this.lblBackgroundMagnify.Text = "100%";
            // 
            // butBucketFillTool
            // 
            this.butBucketFillTool.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.PushButton;
            this.butBucketFillTool.Checked = false;
            this.butBucketFillTool.FlatStyled = false;
            this.butBucketFillTool.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBucketFillTool.Image = global::GMare.Properties.Resources.tool_fill;
            this.butBucketFillTool.ImageXOffset = 0;
            this.butBucketFillTool.ImageYOffset = 0;
            this.butBucketFillTool.Location = new System.Drawing.Point(50, 4);
            this.butBucketFillTool.Name = "butBucketFillTool";
            this.butBucketFillTool.PushButtonImage = null;
            this.butBucketFillTool.Size = new System.Drawing.Size(24, 24);
            this.butBucketFillTool.TabIndex = 2;
            this.butBucketFillTool.TextXOffset = 0;
            this.butBucketFillTool.TextYOffset = 0;
            this.butBucketFillTool.ToolTipText = "Fill the layer with a selection of tiles";
            this.butBucketFillTool.ToolTipTitle = "Bucket Fill Tool (F)";
            this.butBucketFillTool.UseDropShadow = true;
            this.butBucketFillTool.UseVisualStyleBackColor = true;
            this.butBucketFillTool.Click += new System.EventHandler(this.butBackgroundEdit_Click);
            // 
            // pnlBackgroundMagnify
            // 
            this.pnlBackgroundMagnify.BackgroundImage = global::GMare.Properties.Resources.magnifier;
            this.pnlBackgroundMagnify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlBackgroundMagnify.Location = new System.Drawing.Point(122, 4);
            this.pnlBackgroundMagnify.Name = "pnlBackgroundMagnify";
            this.pnlBackgroundMagnify.Size = new System.Drawing.Size(24, 24);
            this.pnlBackgroundMagnify.TabIndex = 5;
            // 
            // butSelectionTool
            // 
            this.butSelectionTool.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.PushButton;
            this.butSelectionTool.Checked = false;
            this.butSelectionTool.FlatStyled = false;
            this.butSelectionTool.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSelectionTool.Image = global::GMare.Properties.Resources.tool_selection;
            this.butSelectionTool.ImageXOffset = 0;
            this.butSelectionTool.ImageYOffset = 0;
            this.butSelectionTool.Location = new System.Drawing.Point(74, 4);
            this.butSelectionTool.Name = "butSelectionTool";
            this.butSelectionTool.PushButtonImage = null;
            this.butSelectionTool.Size = new System.Drawing.Size(24, 24);
            this.butSelectionTool.TabIndex = 3;
            this.butSelectionTool.TextXOffset = 0;
            this.butSelectionTool.TextYOffset = 0;
            this.butSelectionTool.ToolTipText = "Select tiles of a layer and edit them";
            this.butSelectionTool.ToolTipTitle = "Selection Tool (S)";
            this.butSelectionTool.UseDropShadow = true;
            this.butSelectionTool.UseVisualStyleBackColor = true;
            this.butSelectionTool.Click += new System.EventHandler(this.butBackgroundEdit_Click);
            // 
            // trkBackgroundMagnify
            // 
            this.trkBackgroundMagnify.BackColor = System.Drawing.Color.Transparent;
            this.trkBackgroundMagnify.LargeChange = 1;
            this.trkBackgroundMagnify.Location = new System.Drawing.Point(142, 6);
            this.trkBackgroundMagnify.Maximum = 5;
            this.trkBackgroundMagnify.Minimum = 1;
            this.trkBackgroundMagnify.Name = "trkBackgroundMagnify";
            this.trkBackgroundMagnify.Size = new System.Drawing.Size(92, 20);
            this.trkBackgroundMagnify.TabIndex = 6;
            this.trkBackgroundMagnify.TabStop = true;
            this.trkBackgroundMagnify.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkBackgroundMagnify.ToolTipText = "Slide to set the magnification level";
            this.trkBackgroundMagnify.ToolTipTitle = "Background Magnification";
            this.trkBackgroundMagnify.ValueChanged += new System.EventHandler(this.trkMagnify_ValueChanged);
            // 
            // butReplace
            // 
            this.butReplace.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butReplace.Checked = false;
            this.butReplace.FlatStyled = false;
            this.butReplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butReplace.Image = global::GMare.Properties.Resources.arrow_switch;
            this.butReplace.ImageXOffset = 1;
            this.butReplace.ImageYOffset = 1;
            this.butReplace.Location = new System.Drawing.Point(98, 4);
            this.butReplace.Name = "butReplace";
            this.butReplace.PushButtonImage = null;
            this.butReplace.Size = new System.Drawing.Size(24, 24);
            this.butReplace.TabIndex = 4;
            this.butReplace.TextXOffset = 0;
            this.butReplace.TextYOffset = 0;
            this.butReplace.ToolTipText = "Replace a tile with another";
            this.butReplace.ToolTipTitle = "Tile Replacement (R)";
            this.butReplace.UseDropShadow = true;
            this.butReplace.UseVisualStyleBackColor = true;
            this.butReplace.Click += new System.EventHandler(this.butBackgroundEdit_Click);
            // 
            // splBackground
            // 
            this.splBackground.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splBackground.Dock = System.Windows.Forms.DockStyle.Top;
            this.splBackground.Location = new System.Drawing.Point(4, 148);
            this.splBackground.Name = "splBackground";
            this.splBackground.Size = new System.Drawing.Size(282, 4);
            this.splBackground.TabIndex = 1;
            this.splBackground.TabStop = false;
            // 
            // grpLayers
            // 
            this.grpLayers.BackColor = System.Drawing.Color.Transparent;
            this.grpLayers.Controls.Add(this.butLayerView);
            this.grpLayers.Controls.Add(this.butLayerMove);
            this.grpLayers.Controls.Add(this.butLayerMerge);
            this.grpLayers.Controls.Add(this.butLayerClear);
            this.grpLayers.Controls.Add(this.butLayerDelete);
            this.grpLayers.Controls.Add(this.butLayerEdit);
            this.grpLayers.Controls.Add(this.butLayerAdd);
            this.grpLayers.Controls.Add(this.lstLayers);
            this.grpLayers.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpLayers.Location = new System.Drawing.Point(4, 4);
            this.grpLayers.MinimumSize = new System.Drawing.Size(24, 0);
            this.grpLayers.Name = "grpLayers";
            this.grpLayers.Padding = new System.Windows.Forms.Padding(10, 12, 10, 30);
            this.grpLayers.Size = new System.Drawing.Size(282, 144);
            this.grpLayers.TabIndex = 0;
            this.grpLayers.TabStop = false;
            this.grpLayers.Text = "Layers";
            this.grpLayers.TextBarHeight = 24;
            // 
            // butLayerView
            // 
            this.butLayerView.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butLayerView.Checked = false;
            this.butLayerView.FlatStyled = false;
            this.butLayerView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLayerView.Image = global::GMare.Properties.Resources.binocular;
            this.butLayerView.ImageXOffset = 0;
            this.butLayerView.ImageYOffset = 0;
            this.butLayerView.Location = new System.Drawing.Point(156, 28);
            this.butLayerView.Name = "butLayerView";
            this.butLayerView.PushButtonImage = null;
            this.butLayerView.Size = new System.Drawing.Size(24, 24);
            this.butLayerView.TabIndex = 6;
            this.butLayerView.TextXOffset = 0;
            this.butLayerView.TextYOffset = 0;
            this.butLayerView.ToolTipText = "View layers as text";
            this.butLayerView.ToolTipTitle = "View Layer(s) (V)";
            this.butLayerView.UseDropShadow = true;
            this.butLayerView.UseVisualStyleBackColor = true;
            this.butLayerView.Click += new System.EventHandler(this.butLayerOption_Click);
            // 
            // butLayerMove
            // 
            this.butLayerMove.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butLayerMove.Checked = false;
            this.butLayerMove.FlatStyled = false;
            this.butLayerMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLayerMove.Image = global::GMare.Properties.Resources.shift;
            this.butLayerMove.ImageXOffset = 1;
            this.butLayerMove.ImageYOffset = 1;
            this.butLayerMove.Location = new System.Drawing.Point(132, 28);
            this.butLayerMove.Name = "butLayerMove";
            this.butLayerMove.PushButtonImage = null;
            this.butLayerMove.Size = new System.Drawing.Size(24, 24);
            this.butLayerMove.TabIndex = 5;
            this.butLayerMove.TextXOffset = 0;
            this.butLayerMove.TextYOffset = 0;
            this.butLayerMove.ToolTipText = "Shifts a layer or layers in a desired direction";
            this.butLayerMove.ToolTipTitle = "Move Layer(s) (M)";
            this.butLayerMove.UseDropShadow = true;
            this.butLayerMove.UseVisualStyleBackColor = true;
            this.butLayerMove.Click += new System.EventHandler(this.butLayerOption_Click);
            // 
            // butLayerMerge
            // 
            this.butLayerMerge.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butLayerMerge.Checked = false;
            this.butLayerMerge.FlatStyled = false;
            this.butLayerMerge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLayerMerge.Image = global::GMare.Properties.Resources.layer_merge;
            this.butLayerMerge.ImageXOffset = 0;
            this.butLayerMerge.ImageYOffset = 0;
            this.butLayerMerge.Location = new System.Drawing.Point(108, 28);
            this.butLayerMerge.Name = "butLayerMerge";
            this.butLayerMerge.PushButtonImage = null;
            this.butLayerMerge.Size = new System.Drawing.Size(24, 24);
            this.butLayerMerge.TabIndex = 4;
            this.butLayerMerge.TextXOffset = 0;
            this.butLayerMerge.TextYOffset = 0;
            this.butLayerMerge.ToolTipText = "Merges the selected layer to the one below it";
            this.butLayerMerge.ToolTipTitle = "Merge Layer";
            this.butLayerMerge.UseDropShadow = true;
            this.butLayerMerge.UseVisualStyleBackColor = true;
            this.butLayerMerge.Click += new System.EventHandler(this.butLayerOption_Click);
            // 
            // butLayerClear
            // 
            this.butLayerClear.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butLayerClear.Checked = false;
            this.butLayerClear.FlatStyled = false;
            this.butLayerClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLayerClear.Image = global::GMare.Properties.Resources.layer_empty;
            this.butLayerClear.ImageXOffset = 0;
            this.butLayerClear.ImageYOffset = 0;
            this.butLayerClear.Location = new System.Drawing.Point(84, 28);
            this.butLayerClear.Name = "butLayerClear";
            this.butLayerClear.PushButtonImage = null;
            this.butLayerClear.Size = new System.Drawing.Size(24, 24);
            this.butLayerClear.TabIndex = 3;
            this.butLayerClear.TextXOffset = 0;
            this.butLayerClear.TextYOffset = 0;
            this.butLayerClear.ToolTipText = "Clear all the tiles from the selected layer";
            this.butLayerClear.ToolTipTitle = "Clear Layer";
            this.butLayerClear.UseDropShadow = true;
            this.butLayerClear.UseVisualStyleBackColor = true;
            this.butLayerClear.Click += new System.EventHandler(this.butLayerOption_Click);
            // 
            // butLayerDelete
            // 
            this.butLayerDelete.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butLayerDelete.Checked = false;
            this.butLayerDelete.FlatStyled = false;
            this.butLayerDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLayerDelete.Image = global::GMare.Properties.Resources.layer_delete;
            this.butLayerDelete.ImageXOffset = 0;
            this.butLayerDelete.ImageYOffset = 0;
            this.butLayerDelete.Location = new System.Drawing.Point(60, 28);
            this.butLayerDelete.Name = "butLayerDelete";
            this.butLayerDelete.PushButtonImage = null;
            this.butLayerDelete.Size = new System.Drawing.Size(24, 24);
            this.butLayerDelete.TabIndex = 2;
            this.butLayerDelete.TextXOffset = 0;
            this.butLayerDelete.TextYOffset = 0;
            this.butLayerDelete.ToolTipText = "Delete the selected layer";
            this.butLayerDelete.ToolTipTitle = "Delete Layer";
            this.butLayerDelete.UseDropShadow = true;
            this.butLayerDelete.UseVisualStyleBackColor = true;
            this.butLayerDelete.Click += new System.EventHandler(this.butLayerOption_Click);
            // 
            // butLayerEdit
            // 
            this.butLayerEdit.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butLayerEdit.Checked = false;
            this.butLayerEdit.FlatStyled = false;
            this.butLayerEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLayerEdit.Image = global::GMare.Properties.Resources.layer_edit;
            this.butLayerEdit.ImageXOffset = 0;
            this.butLayerEdit.ImageYOffset = 0;
            this.butLayerEdit.Location = new System.Drawing.Point(36, 28);
            this.butLayerEdit.Name = "butLayerEdit";
            this.butLayerEdit.PushButtonImage = null;
            this.butLayerEdit.Size = new System.Drawing.Size(24, 24);
            this.butLayerEdit.TabIndex = 1;
            this.butLayerEdit.TextXOffset = 0;
            this.butLayerEdit.TextYOffset = 0;
            this.butLayerEdit.ToolTipText = "Edit the selected layer";
            this.butLayerEdit.ToolTipTitle = "Edit Layer (E)";
            this.butLayerEdit.UseDropShadow = true;
            this.butLayerEdit.UseVisualStyleBackColor = true;
            this.butLayerEdit.Click += new System.EventHandler(this.butLayerOption_Click);
            // 
            // butLayerAdd
            // 
            this.butLayerAdd.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butLayerAdd.Checked = false;
            this.butLayerAdd.FlatStyled = false;
            this.butLayerAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLayerAdd.Image = global::GMare.Properties.Resources.layer_add;
            this.butLayerAdd.ImageXOffset = 0;
            this.butLayerAdd.ImageYOffset = 0;
            this.butLayerAdd.Location = new System.Drawing.Point(12, 28);
            this.butLayerAdd.Name = "butLayerAdd";
            this.butLayerAdd.PushButtonImage = null;
            this.butLayerAdd.Size = new System.Drawing.Size(24, 24);
            this.butLayerAdd.TabIndex = 0;
            this.butLayerAdd.TextXOffset = 0;
            this.butLayerAdd.TextYOffset = 0;
            this.butLayerAdd.ToolTipText = "Add a tile layer to the room";
            this.butLayerAdd.ToolTipTitle = "Add Layer (L)";
            this.butLayerAdd.UseDropShadow = true;
            this.butLayerAdd.UseVisualStyleBackColor = true;
            this.butLayerAdd.Click += new System.EventHandler(this.butLayerAdd_Click);
            // 
            // lstLayers
            // 
            this.lstLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLayers.CheckBoxCheckedImage = global::GMare.Properties.Resources.eye;
            this.lstLayers.CheckBoxImageOffsetX = 0;
            this.lstLayers.CheckBoxImageOffsetY = -1;
            this.lstLayers.CheckBoxUnCheckedImage = ((System.Drawing.Bitmap)(resources.GetObject("lstLayers.CheckBoxUnCheckedImage")));
            this.lstLayers.DisplayFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lstLayers.EmptyListText = "No Layers";
            this.lstLayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lstLayers.FormattingEnabled = true;
            this.lstLayers.Glyph = null;
            this.lstLayers.GlyphOffsetX = 2;
            this.lstLayers.GlyphOffsetY = 0;
            this.lstLayers.HorizontalExtent = 255;
            this.lstLayers.HorizontalScrollbar = true;
            this.lstLayers.IntegralHeight = false;
            this.lstLayers.Location = new System.Drawing.Point(12, 56);
            this.lstLayers.Name = "lstLayers";
            this.lstLayers.RowHeight = 17;
            this.lstLayers.Size = new System.Drawing.Size(259, 76);
            this.lstLayers.TabIndex = 7;
            this.lstLayers.TextOffsetX = 4;
            this.lstLayers.TextOffsetY = 0;
            this.lstLayers.ToolTipText = "";
            this.lstLayers.ToolTipTitle = "";
            this.lstLayers.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstLayers_ItemCheck);
            this.lstLayers.SelectedIndexChanged += new System.EventHandler(this.lstLayers_SelectedIndexChanged);
            this.lstLayers.DoubleClick += new System.EventHandler(this.lstLayers_DoubleClick);
            // 
            // tabObjects
            // 
            this.tabObjects.Controls.Add(this.txtObject);
            this.tabObjects.Controls.Add(this.pnlObject);
            this.tabObjects.Controls.Add(this.tabInstancesMain);
            this.tabObjects.Controls.Add(this.lblObject);
            this.tabObjects.Controls.Add(this.butObjectsImport);
            this.tabObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabObjects.Location = new System.Drawing.Point(3, 28);
            this.tabObjects.Name = "tabObjects";
            this.tabObjects.Size = new System.Drawing.Size(294, 402);
            this.tabObjects.TabIndex = 1;
            this.tabObjects.Text = "Objects";
            // 
            // txtObject
            // 
            this.txtObject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObject.ButtonImage = null;
            this.txtObject.ButtonImageXOffset = 0;
            this.txtObject.ButtonImageYOffset = 0;
            this.txtObject.ButtonText = "...";
            this.txtObject.ButtonTextXOffset = 1;
            this.txtObject.ButtonTextYOffset = -2;
            this.txtObject.Location = new System.Drawing.Point(80, 10);
            this.txtObject.MaxLength = 32767;
            this.txtObject.Name = "txtObject";
            this.txtObject.ReadOnly = true;
            this.txtObject.Size = new System.Drawing.Size(172, 22);
            this.txtObject.TabIndex = 2;
            this.txtObject.ToolTipText = "A menu of imported objects to select from";
            this.txtObject.ToolTipTitle = "Objects";
            this.txtObject.Value = null;
            this.txtObject.ButtonClick += new Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButtonTextbox.ButtonClickEventHandler(this.txtObject_ButtonClick);
            // 
            // pnlObject
            // 
            this.pnlObject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlObject.BackgroundImage = global::GMare.Properties.Resources.slash;
            this.pnlObject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlObject.CheckerColor = System.Drawing.Color.Silver;
            this.pnlObject.CheckerSize = new System.Drawing.Size(16, 16);
            this.pnlObject.Location = new System.Drawing.Point(256, 6);
            this.pnlObject.Name = "pnlObject";
            this.pnlObject.Size = new System.Drawing.Size(28, 28);
            this.pnlObject.TabIndex = 3;
            this.pnlObject.Title = "";
            this.pnlObject.ToolTipText = "The selected object from the object menu";
            this.pnlObject.ToolTipTitle = "Selected Object";
            this.pnlObject.UseCheckerBoard = true;
            // 
            // tabInstancesMain
            // 
            this.tabInstancesMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabInstancesMain.BackColor = System.Drawing.Color.Transparent;
            this.tabInstancesMain.Controls.Add(this.tabInstances);
            this.tabInstancesMain.Controls.Add(this.tabBlocks);
            this.tabInstancesMain.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tabInstancesMain.Location = new System.Drawing.Point(4, 36);
            this.tabInstancesMain.Name = "tabInstancesMain";
            this.tabInstancesMain.Scroll = false;
            this.tabInstancesMain.SelectedIndex = 0;
            this.tabInstancesMain.SelectedTab = this.tabInstances;
            this.tabInstancesMain.SelectTabMargin = 2;
            this.tabInstancesMain.Size = new System.Drawing.Size(286, 360);
            this.tabInstancesMain.TabDock = System.Windows.Forms.DockStyle.Top;
            this.tabInstancesMain.TabIndent = 8;
            this.tabInstancesMain.TabIndex = 4;
            this.tabInstancesMain.Text = "pyxTabControl1";
            // 
            // tabInstances
            // 
            this.tabInstances.Controls.Add(this.lstInstances);
            this.tabInstances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabInstances.Location = new System.Drawing.Point(3, 28);
            this.tabInstances.Name = "tabInstances";
            this.tabInstances.Size = new System.Drawing.Size(280, 329);
            this.tabInstances.TabIndex = 0;
            this.tabInstances.Text = "Instances";
            // 
            // mnuInstances
            // 
            this.mnuInstances.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSearchObjects,
            this.mnuSetAsObject,
            this.mnuSeparator01,
            this.mnuSortStandard,
            this.mnuSortAscending,
            this.mnuSortDescending,
            this.mnuSeparator06,
            this.mnuInstanceReplace,
            this.mnuInstanceReplaceAll,
            this.mnuSeparator07,
            this.mnuInstanceCut,
            this.mnuInstanceCopy,
            this.mnuInstancePaste,
            this.mnuSeparator08,
            this.mnuInstancePosition,
            this.mnuInstanceBringFront,
            this.mnuInstanceSendBack,
            this.mnuInstanceSnap,
            this.mnuInstanceCode,
            this.mnuSeparator09,
            this.mnuInstanceDelete,
            this.mnuInstanceDeleteAll,
            this.mnuInstanceClear});
            this.mnuInstances.Name = "mnuInstances";
            this.mnuInstances.Size = new System.Drawing.Size(208, 430);
            this.mnuInstances.Opening += new System.ComponentModel.CancelEventHandler(this.mnuInstances_Opening);
            this.mnuInstances.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuInstances_ItemClicked);
            // 
            // mnuSearchObjects
            // 
            this.mnuSearchObjects.Image = global::GMare.Properties.Resources.magnifier;
            this.mnuSearchObjects.Name = "mnuSearchObjects";
            this.mnuSearchObjects.Size = new System.Drawing.Size(207, 22);
            this.mnuSearchObjects.Text = "Search Objects";
            // 
            // mnuSetAsObject
            // 
            this.mnuSetAsObject.Image = global::GMare.Properties.Resources.instance;
            this.mnuSetAsObject.Name = "mnuSetAsObject";
            this.mnuSetAsObject.Size = new System.Drawing.Size(207, 22);
            this.mnuSetAsObject.Text = "Set As Selected Object";
            // 
            // mnuSeparator01
            // 
            this.mnuSeparator01.Name = "mnuSeparator01";
            this.mnuSeparator01.Size = new System.Drawing.Size(204, 6);
            // 
            // mnuSortStandard
            // 
            this.mnuSortStandard.Checked = true;
            this.mnuSortStandard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuSortStandard.Image = global::GMare.Properties.Resources.sort;
            this.mnuSortStandard.Name = "mnuSortStandard";
            this.mnuSortStandard.Size = new System.Drawing.Size(207, 22);
            this.mnuSortStandard.Text = "Sort Original Order";
            // 
            // mnuSortAscending
            // 
            this.mnuSortAscending.Image = global::GMare.Properties.Resources.sort_ascending;
            this.mnuSortAscending.Name = "mnuSortAscending";
            this.mnuSortAscending.Size = new System.Drawing.Size(207, 22);
            this.mnuSortAscending.Text = "Sort Ascending";
            // 
            // mnuSortDescending
            // 
            this.mnuSortDescending.Image = global::GMare.Properties.Resources.sort_descending;
            this.mnuSortDescending.Name = "mnuSortDescending";
            this.mnuSortDescending.Size = new System.Drawing.Size(207, 22);
            this.mnuSortDescending.Text = "Sort Descending";
            // 
            // mnuSeparator06
            // 
            this.mnuSeparator06.Name = "mnuSeparator06";
            this.mnuSeparator06.Size = new System.Drawing.Size(204, 6);
            // 
            // mnuInstanceReplace
            // 
            this.mnuInstanceReplace.Image = global::GMare.Properties.Resources.arrow_switch;
            this.mnuInstanceReplace.Name = "mnuInstanceReplace";
            this.mnuInstanceReplace.Size = new System.Drawing.Size(207, 22);
            this.mnuInstanceReplace.Text = "Replace With Selected";
            // 
            // mnuInstanceReplaceAll
            // 
            this.mnuInstanceReplaceAll.Image = global::GMare.Properties.Resources.instance_replace;
            this.mnuInstanceReplaceAll.Name = "mnuInstanceReplaceAll";
            this.mnuInstanceReplaceAll.Size = new System.Drawing.Size(207, 22);
            this.mnuInstanceReplaceAll.Text = "Replace All With Selected";
            // 
            // mnuSeparator07
            // 
            this.mnuSeparator07.Name = "mnuSeparator07";
            this.mnuSeparator07.Size = new System.Drawing.Size(204, 6);
            // 
            // mnuInstanceCut
            // 
            this.mnuInstanceCut.Image = global::GMare.Properties.Resources.clipboard_cut;
            this.mnuInstanceCut.Name = "mnuInstanceCut";
            this.mnuInstanceCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuInstanceCut.Size = new System.Drawing.Size(207, 22);
            this.mnuInstanceCut.Text = "Cut";
            // 
            // mnuInstanceCopy
            // 
            this.mnuInstanceCopy.Image = global::GMare.Properties.Resources.clipboard_copy;
            this.mnuInstanceCopy.Name = "mnuInstanceCopy";
            this.mnuInstanceCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuInstanceCopy.Size = new System.Drawing.Size(207, 22);
            this.mnuInstanceCopy.Text = "Copy";
            // 
            // mnuInstancePaste
            // 
            this.mnuInstancePaste.Image = ((System.Drawing.Image)(resources.GetObject("mnuInstancePaste.Image")));
            this.mnuInstancePaste.Name = "mnuInstancePaste";
            this.mnuInstancePaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuInstancePaste.Size = new System.Drawing.Size(207, 22);
            this.mnuInstancePaste.Text = "Paste";
            // 
            // mnuSeparator08
            // 
            this.mnuSeparator08.Name = "mnuSeparator08";
            this.mnuSeparator08.Size = new System.Drawing.Size(204, 6);
            // 
            // mnuInstancePosition
            // 
            this.mnuInstancePosition.Image = global::GMare.Properties.Resources.instance_position;
            this.mnuInstancePosition.Name = "mnuInstancePosition";
            this.mnuInstancePosition.Size = new System.Drawing.Size(207, 22);
            this.mnuInstancePosition.Text = "Change Position...";
            // 
            // mnuInstanceBringFront
            // 
            this.mnuInstanceBringFront.Image = global::GMare.Properties.Resources.bring_to_front;
            this.mnuInstanceBringFront.Name = "mnuInstanceBringFront";
            this.mnuInstanceBringFront.Size = new System.Drawing.Size(207, 22);
            this.mnuInstanceBringFront.Text = "Bring To Front";
            // 
            // mnuInstanceSendBack
            // 
            this.mnuInstanceSendBack.Image = global::GMare.Properties.Resources.send_to_back;
            this.mnuInstanceSendBack.Name = "mnuInstanceSendBack";
            this.mnuInstanceSendBack.Size = new System.Drawing.Size(207, 22);
            this.mnuInstanceSendBack.Text = "Send To Back";
            // 
            // mnuInstanceSnap
            // 
            this.mnuInstanceSnap.Image = global::GMare.Properties.Resources.grid_snap;
            this.mnuInstanceSnap.Name = "mnuInstanceSnap";
            this.mnuInstanceSnap.Size = new System.Drawing.Size(207, 22);
            this.mnuInstanceSnap.Text = "Snap To Grid";
            // 
            // mnuInstanceCode
            // 
            this.mnuInstanceCode.Image = global::GMare.Properties.Resources.script;
            this.mnuInstanceCode.Name = "mnuInstanceCode";
            this.mnuInstanceCode.Size = new System.Drawing.Size(207, 22);
            this.mnuInstanceCode.Text = "Creation Code...";
            // 
            // mnuSeparator09
            // 
            this.mnuSeparator09.Name = "mnuSeparator09";
            this.mnuSeparator09.Size = new System.Drawing.Size(204, 6);
            // 
            // mnuInstanceDelete
            // 
            this.mnuInstanceDelete.Image = global::GMare.Properties.Resources.delete;
            this.mnuInstanceDelete.Name = "mnuInstanceDelete";
            this.mnuInstanceDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.mnuInstanceDelete.Size = new System.Drawing.Size(207, 22);
            this.mnuInstanceDelete.Text = "Delete";
            // 
            // mnuInstanceDeleteAll
            // 
            this.mnuInstanceDeleteAll.Image = global::GMare.Properties.Resources.button_decline;
            this.mnuInstanceDeleteAll.Name = "mnuInstanceDeleteAll";
            this.mnuInstanceDeleteAll.Size = new System.Drawing.Size(207, 22);
            this.mnuInstanceDeleteAll.Text = "Delete All";
            // 
            // mnuInstanceClear
            // 
            this.mnuInstanceClear.Image = global::GMare.Properties.Resources.bin;
            this.mnuInstanceClear.Name = "mnuInstanceClear";
            this.mnuInstanceClear.Size = new System.Drawing.Size(207, 22);
            this.mnuInstanceClear.Text = "Clear All Instances";
            // 
            // tabBlocks
            // 
            this.tabBlocks.Controls.Add(this.butBlocksClear);
            this.tabBlocks.Controls.Add(this.lblBlockMagnify);
            this.tabBlocks.Controls.Add(this.pnlBlockMagnify);
            this.tabBlocks.Controls.Add(this.trkBlockMagnify);
            this.tabBlocks.Controls.Add(this.pnlBlockEditor);
            this.tabBlocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabBlocks.Location = new System.Drawing.Point(3, 28);
            this.tabBlocks.Name = "tabBlocks";
            this.tabBlocks.Size = new System.Drawing.Size(280, 308);
            this.tabBlocks.TabIndex = 1;
            this.tabBlocks.Text = "Blocks";
            // 
            // butBlocksClear
            // 
            this.butBlocksClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBlocksClear.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butBlocksClear.Checked = false;
            this.butBlocksClear.FlatStyled = false;
            this.butBlocksClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBlocksClear.Image = global::GMare.Properties.Resources.bin;
            this.butBlocksClear.ImageXOffset = 0;
            this.butBlocksClear.ImageYOffset = 0;
            this.butBlocksClear.Location = new System.Drawing.Point(8, 279);
            this.butBlocksClear.Name = "butBlocksClear";
            this.butBlocksClear.PushButtonImage = null;
            this.butBlocksClear.Size = new System.Drawing.Size(24, 24);
            this.butBlocksClear.TabIndex = 1;
            this.butBlocksClear.TextXOffset = 0;
            this.butBlocksClear.TextYOffset = 0;
            this.butBlocksClear.ToolTipText = "Clears the block object settings";
            this.butBlocksClear.ToolTipTitle = "Clear Block Objects";
            this.butBlocksClear.UseDropShadow = true;
            this.butBlocksClear.UseVisualStyleBackColor = true;
            this.butBlocksClear.Click += new System.EventHandler(this.butBlocksClear_Click);
            // 
            // lblBlockMagnify
            // 
            this.lblBlockMagnify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBlockMagnify.AutoSize = true;
            this.lblBlockMagnify.Location = new System.Drawing.Point(148, 285);
            this.lblBlockMagnify.Name = "lblBlockMagnify";
            this.lblBlockMagnify.Size = new System.Drawing.Size(34, 13);
            this.lblBlockMagnify.TabIndex = 4;
            this.lblBlockMagnify.Text = "100%";
            // 
            // pnlBlockMagnify
            // 
            this.pnlBlockMagnify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlBlockMagnify.BackgroundImage = global::GMare.Properties.Resources.magnifier;
            this.pnlBlockMagnify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlBlockMagnify.Location = new System.Drawing.Point(32, 279);
            this.pnlBlockMagnify.Name = "pnlBlockMagnify";
            this.pnlBlockMagnify.Size = new System.Drawing.Size(24, 24);
            this.pnlBlockMagnify.TabIndex = 2;
            // 
            // trkBlockMagnify
            // 
            this.trkBlockMagnify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trkBlockMagnify.BackColor = System.Drawing.Color.Transparent;
            this.trkBlockMagnify.LargeChange = 1;
            this.trkBlockMagnify.Location = new System.Drawing.Point(52, 281);
            this.trkBlockMagnify.Maximum = 5;
            this.trkBlockMagnify.Minimum = 1;
            this.trkBlockMagnify.Name = "trkBlockMagnify";
            this.trkBlockMagnify.Size = new System.Drawing.Size(100, 20);
            this.trkBlockMagnify.TabIndex = 3;
            this.trkBlockMagnify.TabStop = true;
            this.trkBlockMagnify.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkBlockMagnify.ToolTipText = "Slide to set the magnification level";
            this.trkBlockMagnify.ToolTipTitle = "Block Magnification";
            this.trkBlockMagnify.ValueChanged += new System.EventHandler(this.trkMagnify_ValueChanged);
            // 
            // lblObject
            // 
            this.lblObject.AutoSize = true;
            this.lblObject.Location = new System.Drawing.Point(36, 14);
            this.lblObject.Name = "lblObject";
            this.lblObject.Size = new System.Drawing.Size(44, 13);
            this.lblObject.TabIndex = 1;
            this.lblObject.Text = "Object:";
            // 
            // butObjectsImport
            // 
            this.butObjectsImport.ButtonType = Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton.ButtonModeType.Button;
            this.butObjectsImport.Checked = false;
            this.butObjectsImport.FlatStyled = false;
            this.butObjectsImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butObjectsImport.Image = ((System.Drawing.Image)(resources.GetObject("butObjectsImport.Image")));
            this.butObjectsImport.ImageXOffset = 0;
            this.butObjectsImport.ImageYOffset = 0;
            this.butObjectsImport.Location = new System.Drawing.Point(8, 8);
            this.butObjectsImport.Name = "butObjectsImport";
            this.butObjectsImport.PushButtonImage = null;
            this.butObjectsImport.Size = new System.Drawing.Size(24, 24);
            this.butObjectsImport.TabIndex = 0;
            this.butObjectsImport.TextXOffset = 0;
            this.butObjectsImport.TextYOffset = 0;
            this.butObjectsImport.ToolTipText = "Import objects from a Game Maker project";
            this.butObjectsImport.ToolTipTitle = "Import Objects (O)";
            this.butObjectsImport.UseDropShadow = true;
            this.butObjectsImport.UseVisualStyleBackColor = true;
            this.butObjectsImport.Click += new System.EventHandler(this.butObjectsImport_Click);
            // 
            // ssMain
            // 
            this.ssMain.BackColor = System.Drawing.SystemColors.Control;
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslInfo,
            this.sslActual,
            this.sslSnapped});
            this.ssMain.Location = new System.Drawing.Point(0, 514);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(786, 24);
            this.ssMain.TabIndex = 5;
            this.ssMain.Text = "statusStrip1";
            // 
            // sslInfo
            // 
            this.sslInfo.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.sslInfo.Name = "sslInfo";
            this.sslInfo.Size = new System.Drawing.Size(4, 19);
            this.sslInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sslActual
            // 
            this.sslActual.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.sslActual.Name = "sslActual";
            this.sslActual.Size = new System.Drawing.Size(78, 19);
            this.sslActual.Text = "Actual: -NA-";
            this.sslActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sslSnapped
            // 
            this.sslSnapped.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.sslSnapped.Name = "sslSnapped";
            this.sslSnapped.Size = new System.Drawing.Size(90, 19);
            this.sslSnapped.Text = "Snapped: -NA-";
            this.sslSnapped.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mnuObjects
            // 
            this.mnuObjects.Name = "mnuInstances";
            this.mnuObjects.Size = new System.Drawing.Size(61, 4);
            // 
            // pnlRoomEditor
            // 
            this.pnlRoomEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRoomEditor.AvoidMouseEvents = false;
            this.pnlRoomEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.pnlRoomEditor.DepthIndex = 0;
            this.pnlRoomEditor.EditMode = GMare.Objects.EditType.Layers;
            this.pnlRoomEditor.GridMode = GMare.Objects.GridType.Normal;
            this.pnlRoomEditor.GridX = 16;
            this.pnlRoomEditor.GridY = 16;
            this.pnlRoomEditor.InvertGridColor = false;
            this.pnlRoomEditor.LayerIndex = -1;
            this.pnlRoomEditor.Level = 0;
            this.pnlRoomEditor.Location = new System.Drawing.Point(12, 56);
            this.pnlRoomEditor.Name = "pnlRoomEditor";
            this.pnlRoomEditor.Padding = new System.Windows.Forms.Padding(1);
            this.pnlRoomEditor.SelectedBackground = null;
            this.pnlRoomEditor.SelectedObject = null;
            this.pnlRoomEditor.ShowBlocks = true;
            this.pnlRoomEditor.ShowGrid = true;
            this.pnlRoomEditor.ShowInstances = true;
            this.pnlRoomEditor.Size = new System.Drawing.Size(450, 349);
            this.pnlRoomEditor.Snap = true;
            this.pnlRoomEditor.TabIndex = 12;
            this.pnlRoomEditor.Tiles = null;
            this.pnlRoomEditor.ToolMode = GMare.Objects.ToolType.Brush;
            this.pnlRoomEditor.MousePositionChanged += new GMare.Controls.GMareRoomEditor.MousePositionHandler(this.pnlRoomEditor_MousePositionChanged);
            this.pnlRoomEditor.SelectedObjectChanged += new GMare.Controls.GMareRoomEditor.SelectedObjectChangedHandler(this.pnlRoomEditor_SelectedObjectChanged);
            this.pnlRoomEditor.InstancesPositionChanged += new GMare.Controls.GMareRoomEditor.InstancePositionHandler(this.pnlRoomEditor_InstancesPositionChanged);
            this.pnlRoomEditor.InstancesChanged += new GMare.Controls.GMareRoomEditor.InstanceChangedHandler(this.pnlRoomEditor_InstanceChanged);
            this.pnlRoomEditor.RoomChanged += new GMare.Controls.GMareRoomEditor.RoomChangedHandler(this.pnlRoomEditor_RoomChanged);
            this.pnlRoomEditor.ClipboardChanged += new GMare.Controls.GMareRoomEditor.ClipboardChangedHandler(this.pnlRoomEditor_ClipboardChanged);
            this.pnlRoomEditor.EditModeChanged += new GMare.Controls.GMareRoomEditor.EditModeChangedHandler(this.pnlRoomEditor_EditModeChanged);
            this.pnlRoomEditor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlRoomEditor_MouseUp);
            // 
            // pnlBackground
            // 
            this.pnlBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBackground.AutoScroll = true;
            this.pnlBackground.AutoScrollMinSize = new System.Drawing.Size(256, 169);
            this.pnlBackground.AvoidMouseEvents = false;
            this.pnlBackground.BackColor = System.Drawing.Color.White;
            this.pnlBackground.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBackground.CheckerColor = System.Drawing.Color.Silver;
            this.pnlBackground.CheckerSize = new System.Drawing.Size(16, 16);
            this.pnlBackground.Image = null;
            this.pnlBackground.ImageScale = 1;
            this.pnlBackground.Location = new System.Drawing.Point(11, 60);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.SelectMode = GMare.Controls.GMareBackgroundPanel.SelectType.Normal;
            this.pnlBackground.Size = new System.Drawing.Size(260, 173);
            this.pnlBackground.SnapSize = new System.Drawing.Size(8, 8);
            this.pnlBackground.TabIndex = 1;
            this.pnlBackground.TileBrush = null;
            this.pnlBackground.Title = "Background Tiles";
            this.pnlBackground.ToolTipText = "";
            this.pnlBackground.ToolTipTitle = "";
            this.pnlBackground.UseCheckerBoard = true;
            this.pnlBackground.Zoom = 1F;
            this.pnlBackground.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlBackground_MouseUp);
            // 
            // lstInstances
            // 
            this.lstInstances.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstInstances.CellSize = new System.Drawing.Size(16, 16);
            this.lstInstances.ContextMenuStrip = this.mnuInstances;
            this.lstInstances.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstInstances.EmptyListText = "No Instances";
            this.lstInstances.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstInstances.FormattingEnabled = true;
            this.lstInstances.Glyph = null;
            this.lstInstances.GlyphOffsetX = 2;
            this.lstInstances.GlyphOffsetY = 0;
            this.lstInstances.HorizontalExtent = 256;
            this.lstInstances.HorizontalScrollbar = true;
            this.lstInstances.IntegralHeight = false;
            this.lstInstances.ItemHeight = 22;
            this.lstInstances.ListboxMode = GMare.Controls.GMareListbox.ListboxType.Instances;
            this.lstInstances.Location = new System.Drawing.Point(9, 8);
            this.lstInstances.Name = "lstInstances";
            this.lstInstances.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstInstances.ShowBlocks = true;
            this.lstInstances.Size = new System.Drawing.Size(260, 312);
            this.lstInstances.TabIndex = 0;
            this.lstInstances.TextOffsetX = 2;
            this.lstInstances.TextOffsetY = 0;
            this.lstInstances.ToolTipText = "";
            this.lstInstances.ToolTipTitle = "";
            this.lstInstances.SelectedIndexChanged += new System.EventHandler(this.lstInstances_SelectedIndexChanged);
            // 
            // pnlBlockEditor
            // 
            this.pnlBlockEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBlockEditor.AutoScroll = true;
            this.pnlBlockEditor.AutoScrollMinSize = new System.Drawing.Size(256, 263);
            this.pnlBlockEditor.BackColor = System.Drawing.Color.White;
            this.pnlBlockEditor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBlockEditor.CheckerColor = System.Drawing.Color.Silver;
            this.pnlBlockEditor.CheckerSize = new System.Drawing.Size(16, 16);
            this.pnlBlockEditor.Image = null;
            this.pnlBlockEditor.ImageScale = 1;
            this.pnlBlockEditor.Location = new System.Drawing.Point(9, 8);
            this.pnlBlockEditor.Name = "pnlBlockEditor";
            this.pnlBlockEditor.ObjectId = -1;
            this.pnlBlockEditor.SelectedBackground = null;
            this.pnlBlockEditor.Size = new System.Drawing.Size(260, 267);
            this.pnlBlockEditor.SnapSize = new System.Drawing.Size(8, 8);
            this.pnlBlockEditor.TabIndex = 0;
            this.pnlBlockEditor.Title = "Block Object Editor";
            this.pnlBlockEditor.ToolTipText = "";
            this.pnlBlockEditor.ToolTipTitle = "";
            this.pnlBlockEditor.UseCheckerBoard = true;
            this.pnlBlockEditor.Zoom = 1F;
            this.pnlBlockEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlBlockEditor_MouseDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(786, 538);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.mnuMain);
            this.Controls.Add(this.ssMain);
            this.MinimumSize = new System.Drawing.Size(802, 576);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GMare";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.grpEdit.ResumeLayout(false);
            this.grpRoom.ResumeLayout(false);
            this.grpRoom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomColumns)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlRoom.ResumeLayout(false);
            this.pnlRoom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomGridX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomGridY)).EndInit();
            this.grpRoomEditor.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabTiles.ResumeLayout(false);
            this.grpTiles.ResumeLayout(false);
            this.pnlBackgroundTools.ResumeLayout(false);
            this.pnlBackgroundTools.PerformLayout();
            this.grpLayers.ResumeLayout(false);
            this.tabObjects.ResumeLayout(false);
            this.tabObjects.PerformLayout();
            this.tabInstancesMain.ResumeLayout(false);
            this.tabInstances.ResumeLayout(false);
            this.mnuInstances.ResumeLayout(false);
            this.tabBlocks.ResumeLayout(false);
            this.tabBlocks.PerformLayout();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuNewProject;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenProject;
        private System.Windows.Forms.ToolStripSeparator mnuSep01;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveBackground;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAs;
        private System.Windows.Forms.ToolStripSeparator mnuSep02;
        private System.Windows.Forms.ToolStripMenuItem mnuImportFrom;
        private System.Windows.Forms.ToolStripMenuItem mnuImportImage;
        private System.Windows.Forms.ToolStripMenuItem mnuExportTo;
        private System.Windows.Forms.ToolStripMenuItem mnuExportImage;
        private System.Windows.Forms.ToolStripMenuItem mnuExportBinary;
        private System.Windows.Forms.ToolStripMenuItem mnuExportGMProject;
        private System.Windows.Forms.ToolStripSeparator mnuSep03;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuUndo;
        private System.Windows.Forms.ToolStripMenuItem mnuRedo;
        private System.Windows.Forms.ToolStripSeparator mnuSep04;
        private System.Windows.Forms.ToolStripMenuItem mnuCut;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuPaste;
        private System.Windows.Forms.ToolStripSeparator mnuSep05;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuContents;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabbedGroupBox grpEdit;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butDelete;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butPaste;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butCopy;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butCut;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butRedo;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butUndo;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabbedGroupBox grpRoom;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Splitter splRoom;
        private System.Windows.Forms.Panel pnlLeft;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabbedGroupBox grpRoomEditor;
        private System.Windows.Forms.Label lblRoomMagnify;
        private System.Windows.Forms.Panel pnlRoomMagnify;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTrackBar trkRoomMagnify;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudRoomGridY;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudRoomGridX;
        private System.Windows.Forms.Label lblRoomGridY;
        private System.Windows.Forms.Label lblRoomGridX;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabControl tabMain;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabPage tabTiles;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpTiles;
        private System.Windows.Forms.Splitter splBackground;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxGroupBox grpLayers;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabPage tabObjects;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butLayerView;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butLayerMove;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butLayerMerge;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butLayerClear;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butLayerDelete;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butLayerEdit;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butLayerAdd;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxCheckedListBox lstLayers;
        private System.Windows.Forms.Label lblBackgroundMagnify;
        private System.Windows.Forms.Panel pnlBackgroundMagnify;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTrackBar trkBackgroundMagnify;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butReplace;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butSelectionTool;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butBucketFillTool;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butBrushTool;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butBackgroundEdit;
        private System.Windows.Forms.Label lblObject;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butShowInstances;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butObjectsImport;
        private System.Windows.Forms.Label lblRoomName;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox txtRoomName;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudRoomSpeed;
        private System.Windows.Forms.Label lblRoomCaption;
        private System.Windows.Forms.Label lblRoomSpeed;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTextBox txtRoomCaption;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudRoomRows;
        private System.Windows.Forms.Label lblRoomColumns;
        private System.Windows.Forms.Label lblRoomRows;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxNumericUpDown nudRoomColumns;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butGridSnap;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butGridIso;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butGrid;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butRoomScript;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butRoomPersistent;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butRoomBackColor;
        private Controls.GMareRoomEditor pnlRoomEditor;
        private System.Windows.Forms.StatusStrip ssMain;
        private Controls.GMareBackgroundPanel pnlBackground;
        private System.Windows.Forms.ToolStripStatusLabel sslActual;
        private System.Windows.Forms.ToolStripStatusLabel sslSnapped;
        private System.Windows.Forms.Panel pnlBackgroundTools;
        private Controls.GMareListbox lstInstances;
        private System.Windows.Forms.ToolStripStatusLabel sslInfo;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butShowBlocks;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabControl tabInstancesMain;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabPage tabInstances;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTabPage tabBlocks;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butBlocksClear;
        private Controls.GMareBlockEditor pnlBlockEditor;
        private System.Windows.Forms.Label lblBlockMagnify;
        private System.Windows.Forms.Panel pnlBlockMagnify;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxTrackBar trkBlockMagnify;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxPanel pnlObject;
        private System.Windows.Forms.ContextMenuStrip mnuObjects;
        private System.Windows.Forms.ContextMenuStrip mnuInstances;
        private System.Windows.Forms.ToolStripSeparator mnuSeparator06;
        private System.Windows.Forms.ToolStripMenuItem mnuInstanceReplace;
        private System.Windows.Forms.ToolStripMenuItem mnuInstanceReplaceAll;
        private System.Windows.Forms.ToolStripSeparator mnuSeparator07;
        private System.Windows.Forms.ToolStripMenuItem mnuInstanceCut;
        private System.Windows.Forms.ToolStripMenuItem mnuInstancePaste;
        private System.Windows.Forms.ToolStripMenuItem mnuInstanceCopy;
        private System.Windows.Forms.ToolStripSeparator mnuSeparator08;
        private System.Windows.Forms.ToolStripMenuItem mnuInstancePosition;
        private System.Windows.Forms.ToolStripMenuItem mnuInstanceBringFront;
        private System.Windows.Forms.ToolStripMenuItem mnuInstanceSendBack;
        private System.Windows.Forms.ToolStripMenuItem mnuInstanceSnap;
        private System.Windows.Forms.ToolStripMenuItem mnuInstanceCode;
        private System.Windows.Forms.ToolStripSeparator mnuSeparator09;
        private System.Windows.Forms.ToolStripMenuItem mnuInstanceDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuInstanceDeleteAll;
        private System.Windows.Forms.ToolStripMenuItem mnuInstanceClear;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButtonTextbox txtObject;
        private System.Windows.Forms.ToolStripMenuItem mnuSortStandard;
        private System.Windows.Forms.ToolStripMenuItem mnuSortAscending;
        private System.Windows.Forms.ToolStripMenuItem mnuSortDescending;
        private Pyxosoft.Windows.Tools.PyxTools.Controls.PyxButton butInvertGridColor;
        private System.Windows.Forms.ToolStripMenuItem mnuImportGMare;
        private System.Windows.Forms.ToolStripMenuItem mnuPreferences;
        private System.Windows.Forms.ToolStripMenuItem mnuSearchObjects;
        private System.Windows.Forms.ToolStripMenuItem mnuSetAsObject;
        private System.Windows.Forms.ToolStripSeparator mnuSeparator01;
        private System.Windows.Forms.Panel pnlRoom;
    }
}

