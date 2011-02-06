namespace GMare.Forms
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
            GMare.Common.TileGrid tileGrid1 = new GMare.Common.TileGrid();
            GMare.Common.TileGrid tileGrid2 = new GMare.Common.TileGrid();
            this.ms_Main = new System.Windows.Forms.MenuStrip();
            this.tsmi_File = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_NewProject = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_OpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_CloseProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_SaveTileset = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SaveProject = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ExportImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ExportMultipleBinary = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ExportGMProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Undo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Redo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Cut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Tools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Shift = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_BackColor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_LayerView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Properties = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Contents = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_About = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_Main = new System.Windows.Forms.ToolStrip();
            this.tsb_NewProject = new System.Windows.Forms.ToolStripButton();
            this.tsb_OpenProject = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_SaveTileset = new System.Windows.Forms.ToolStripButton();
            this.tsb_SaveProject = new System.Windows.Forms.ToolStripButton();
            this.tsb_SaveBinary = new System.Windows.Forms.ToolStripSplitButton();
            this.tbmi_ExportImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tbmi_ExportMultipleBinary = new System.Windows.Forms.ToolStripMenuItem();
            this.tbmi_ExportGMProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Undo = new System.Windows.Forms.ToolStripButton();
            this.tsb_Redo = new System.Windows.Forms.ToolStripButton();
            this.tsb_Cut = new System.Windows.Forms.ToolStripButton();
            this.tsb_Copy = new System.Windows.Forms.ToolStripButton();
            this.tsb_Paste = new System.Windows.Forms.ToolStripButton();
            this.tsb_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Shift = new System.Windows.Forms.ToolStripButton();
            this.tsb_BackColor = new System.Windows.Forms.ToolStripButton();
            this.tsb_LayerView = new System.Windows.Forms.ToolStripButton();
            this.tsb_Properties = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Contents = new System.Windows.Forms.ToolStripButton();
            this.tsb_About = new System.Windows.Forms.ToolStripButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ss_Main = new System.Windows.Forms.StatusStrip();
            this.tssl_Info = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Actual = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Snapped = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tc_GUI = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnl_Tileset = new GMare.Controls.BackgroundPanel();
            this.ts_Tiles = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_TileTool = new System.Windows.Forms.ToolStripButton();
            this.tsb_FillTool = new System.Windows.Forms.ToolStripButton();
            this.tsb_SelectionTool = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Swap = new System.Windows.Forms.ToolStripButton();
            this.tsb_TilesetZoom = new GMare.Controls.ZoomToolStripButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lb_Instances = new GMare.Controls.ListboxEx();
            this.cms_Instances = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_Sorting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SortStandard = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SortAscending = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SortDescending = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_CreationCode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_DeleteInstance = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsb_ImportObjects = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tsb_Objects = new System.Windows.Forms.ToolStripSplitButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lb_Shapes = new GMare.Controls.ListboxEx();
            this.ts_Collisions = new System.Windows.Forms.ToolStrip();
            this.tsb_MoveUp = new System.Windows.Forms.ToolStripButton();
            this.tsb_MoveDown = new System.Windows.Forms.ToolStripButton();
            this.tsb_ShapeDelete = new System.Windows.Forms.ToolStripButton();
            this.tsb_Level = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmi_Level1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Level2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Level3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Level4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Level5 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gb_Editor = new System.Windows.Forms.GroupBox();
            this.pnl_RoomEditor = new GMare.Controls.RoomEditor();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ts_Tools = new System.Windows.Forms.ToolStrip();
            this.tsb_Grid = new System.Windows.Forms.ToolStripButton();
            this.tsb_GridIso = new System.Windows.Forms.ToolStripButton();
            this.tsb_Snap = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsb_GridX = new GMare.Controls.ToolStripNumericUpDown();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsb_GridY = new GMare.Controls.ToolStripNumericUpDown();
            this.tsb_Zoom = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmi_ZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Zoom25 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Zoom50 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Zoom100 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Zoom200 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Zoom400 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_LayerOptions = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmi_LayerAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_LayerEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_LayerDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_LayerClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsl_Layer = new System.Windows.Forms.ToolStripLabel();
            this.tscb_EditSelect = new GMare.Controls.ToolStripComboBox();
            this.ms_Main.SuspendLayout();
            this.ts_Main.SuspendLayout();
            this.ss_Main.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tc_GUI.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.ts_Tiles.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.cms_Instances.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.ts_Collisions.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gb_Editor.SuspendLayout();
            this.ts_Tools.SuspendLayout();
            this.SuspendLayout();
            // 
            // ms_Main
            // 
            this.ms_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_File,
            this.editToolStripMenuItem,
            this.tsmi_Tools,
            this.tsmi_Help});
            this.ms_Main.Location = new System.Drawing.Point(0, 0);
            this.ms_Main.Name = "ms_Main";
            this.ms_Main.Size = new System.Drawing.Size(704, 24);
            this.ms_Main.TabIndex = 0;
            this.ms_Main.Text = "menuStrip1";
            // 
            // tsmi_File
            // 
            this.tsmi_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_NewProject,
            this.tsmi_OpenProject,
            this.tsmi_CloseProject,
            this.toolStripMenuItem1,
            this.tsmi_SaveTileset,
            this.tsmi_SaveProject,
            this.tsmi_Export,
            this.toolStripMenuItem2,
            this.tsmi_Exit});
            this.tsmi_File.Name = "tsmi_File";
            this.tsmi_File.Size = new System.Drawing.Size(37, 20);
            this.tsmi_File.Text = "&File";
            // 
            // tsmi_NewProject
            // 
            this.tsmi_NewProject.Image = global::GMare.Properties.Resources.file_new;
            this.tsmi_NewProject.Name = "tsmi_NewProject";
            this.tsmi_NewProject.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.N)));
            this.tsmi_NewProject.Size = new System.Drawing.Size(218, 22);
            this.tsmi_NewProject.Text = "New Project";
            this.tsmi_NewProject.Click += new System.EventHandler(this.tsmi_New_Click);
            // 
            // tsmi_OpenProject
            // 
            this.tsmi_OpenProject.Image = global::GMare.Properties.Resources.file_open;
            this.tsmi_OpenProject.Name = "tsmi_OpenProject";
            this.tsmi_OpenProject.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.O)));
            this.tsmi_OpenProject.Size = new System.Drawing.Size(218, 22);
            this.tsmi_OpenProject.Text = "Open Project";
            this.tsmi_OpenProject.Click += new System.EventHandler(this.tsmi_Open_Click);
            // 
            // tsmi_CloseProject
            // 
            this.tsmi_CloseProject.Image = global::GMare.Properties.Resources.file_close;
            this.tsmi_CloseProject.Name = "tsmi_CloseProject";
            this.tsmi_CloseProject.Size = new System.Drawing.Size(218, 22);
            this.tsmi_CloseProject.Text = "Close Project";
            this.tsmi_CloseProject.Click += new System.EventHandler(this.tsmi_Close_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(215, 6);
            // 
            // tsmi_SaveTileset
            // 
            this.tsmi_SaveTileset.Image = global::GMare.Properties.Resources.tileset_save;
            this.tsmi_SaveTileset.Name = "tsmi_SaveTileset";
            this.tsmi_SaveTileset.Size = new System.Drawing.Size(218, 22);
            this.tsmi_SaveTileset.Text = "Save Tileset";
            this.tsmi_SaveTileset.Click += new System.EventHandler(this.tsmi_SaveTileset_Click);
            // 
            // tsmi_SaveProject
            // 
            this.tsmi_SaveProject.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_SaveProject.Image")));
            this.tsmi_SaveProject.Name = "tsmi_SaveProject";
            this.tsmi_SaveProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmi_SaveProject.Size = new System.Drawing.Size(218, 22);
            this.tsmi_SaveProject.Text = "Save Project";
            this.tsmi_SaveProject.Click += new System.EventHandler(this.tsmi_Save_Click);
            // 
            // tsmi_Export
            // 
            this.tsmi_Export.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_ExportImage,
            this.tsmi_ExportMultipleBinary,
            this.tsmi_ExportGMProject});
            this.tsmi_Export.Image = global::GMare.Properties.Resources.export;
            this.tsmi_Export.Name = "tsmi_Export";
            this.tsmi_Export.Size = new System.Drawing.Size(218, 22);
            this.tsmi_Export.Text = "Export To...";
            // 
            // tsmi_ExportImage
            // 
            this.tsmi_ExportImage.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_ExportImage.Image")));
            this.tsmi_ExportImage.Name = "tsmi_ExportImage";
            this.tsmi_ExportImage.Size = new System.Drawing.Size(154, 22);
            this.tsmi_ExportImage.Text = "Image File";
            this.tsmi_ExportImage.Click += new System.EventHandler(this.tsmi_ExportImage_Click);
            // 
            // tsmi_ExportMultipleBinary
            // 
            this.tsmi_ExportMultipleBinary.Image = global::GMare.Properties.Resources.export_binary;
            this.tsmi_ExportMultipleBinary.Name = "tsmi_ExportMultipleBinary";
            this.tsmi_ExportMultipleBinary.Size = new System.Drawing.Size(154, 22);
            this.tsmi_ExportMultipleBinary.Text = "Binary File";
            this.tsmi_ExportMultipleBinary.Click += new System.EventHandler(this.tsmi_ExportBinary_Click);
            // 
            // tsmi_ExportGMProject
            // 
            this.tsmi_ExportGMProject.Image = global::GMare.Properties.Resources.export_gmproject;
            this.tsmi_ExportGMProject.Name = "tsmi_ExportGMProject";
            this.tsmi_ExportGMProject.Size = new System.Drawing.Size(154, 22);
            this.tsmi_ExportGMProject.Text = "GM Project File";
            this.tsmi_ExportGMProject.Click += new System.EventHandler(this.tsmi_ExportGMProject_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(215, 6);
            // 
            // tsmi_Exit
            // 
            this.tsmi_Exit.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Exit.Image")));
            this.tsmi_Exit.Name = "tsmi_Exit";
            this.tsmi_Exit.Size = new System.Drawing.Size(218, 22);
            this.tsmi_Exit.Text = "Exit";
            this.tsmi_Exit.Click += new System.EventHandler(this.tsmi_Exit_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Undo,
            this.tsmi_Redo,
            this.toolStripMenuItem4,
            this.tsmi_Cut,
            this.tsmi_Copy,
            this.tsmi_Paste,
            this.toolStripMenuItem7,
            this.tsmi_Delete});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // tsmi_Undo
            // 
            this.tsmi_Undo.Image = global::GMare.Properties.Resources.arrow_undo;
            this.tsmi_Undo.Name = "tsmi_Undo";
            this.tsmi_Undo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.tsmi_Undo.Size = new System.Drawing.Size(144, 22);
            this.tsmi_Undo.Text = "Undo";
            // 
            // tsmi_Redo
            // 
            this.tsmi_Redo.Image = global::GMare.Properties.Resources.arrow_redo;
            this.tsmi_Redo.Name = "tsmi_Redo";
            this.tsmi_Redo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.tsmi_Redo.Size = new System.Drawing.Size(144, 22);
            this.tsmi_Redo.Text = "Redo";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(141, 6);
            // 
            // tsmi_Cut
            // 
            this.tsmi_Cut.Image = global::GMare.Properties.Resources.clipboard_cut;
            this.tsmi_Cut.Name = "tsmi_Cut";
            this.tsmi_Cut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.tsmi_Cut.Size = new System.Drawing.Size(144, 22);
            this.tsmi_Cut.Text = "Cut";
            this.tsmi_Cut.Click += new System.EventHandler(this.tsmi_Cut_Click);
            // 
            // tsmi_Copy
            // 
            this.tsmi_Copy.Image = global::GMare.Properties.Resources.clipboard_copy;
            this.tsmi_Copy.Name = "tsmi_Copy";
            this.tsmi_Copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsmi_Copy.Size = new System.Drawing.Size(144, 22);
            this.tsmi_Copy.Text = "Copy";
            this.tsmi_Copy.Click += new System.EventHandler(this.tsmi_Copy_Click);
            // 
            // tsmi_Paste
            // 
            this.tsmi_Paste.Image = global::GMare.Properties.Resources.clipboard_paste;
            this.tsmi_Paste.Name = "tsmi_Paste";
            this.tsmi_Paste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.tsmi_Paste.Size = new System.Drawing.Size(144, 22);
            this.tsmi_Paste.Text = "Paste";
            this.tsmi_Paste.Click += new System.EventHandler(this.tsmi_Paste_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(141, 6);
            // 
            // tsmi_Delete
            // 
            this.tsmi_Delete.Image = global::GMare.Properties.Resources.button_decline;
            this.tsmi_Delete.Name = "tsmi_Delete";
            this.tsmi_Delete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.tsmi_Delete.Size = new System.Drawing.Size(144, 22);
            this.tsmi_Delete.Text = "Delete";
            this.tsmi_Delete.Click += new System.EventHandler(this.tsmi_Delete_Click);
            // 
            // tsmi_Tools
            // 
            this.tsmi_Tools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Shift,
            this.tsmi_BackColor,
            this.tsmi_LayerView,
            this.tsmi_Properties});
            this.tsmi_Tools.Name = "tsmi_Tools";
            this.tsmi_Tools.Size = new System.Drawing.Size(48, 20);
            this.tsmi_Tools.Text = "&Tools";
            // 
            // tsmi_Shift
            // 
            this.tsmi_Shift.Image = global::GMare.Properties.Resources.arrow_move;
            this.tsmi_Shift.Name = "tsmi_Shift";
            this.tsmi_Shift.Size = new System.Drawing.Size(170, 22);
            this.tsmi_Shift.Text = "Shift Room";
            this.tsmi_Shift.Click += new System.EventHandler(this.tsmi_Shift_Click);
            // 
            // tsmi_BackColor
            // 
            this.tsmi_BackColor.Image = global::GMare.Properties.Resources.color_swatch;
            this.tsmi_BackColor.Name = "tsmi_BackColor";
            this.tsmi_BackColor.Size = new System.Drawing.Size(170, 22);
            this.tsmi_BackColor.Text = "Background Color";
            this.tsmi_BackColor.Click += new System.EventHandler(this.tsmi_BackColor_Click);
            // 
            // tsmi_LayerView
            // 
            this.tsmi_LayerView.Image = global::GMare.Properties.Resources.page_find;
            this.tsmi_LayerView.Name = "tsmi_LayerView";
            this.tsmi_LayerView.Size = new System.Drawing.Size(170, 22);
            this.tsmi_LayerView.Text = "Layer View";
            this.tsmi_LayerView.Click += new System.EventHandler(this.tsmi_LayerView_Click);
            // 
            // tsmi_Properties
            // 
            this.tsmi_Properties.Image = global::GMare.Properties.Resources.room_edit;
            this.tsmi_Properties.Name = "tsmi_Properties";
            this.tsmi_Properties.Size = new System.Drawing.Size(170, 22);
            this.tsmi_Properties.Text = "Edit Properties";
            this.tsmi_Properties.Click += new System.EventHandler(this.tsmi_Edit_Click);
            // 
            // tsmi_Help
            // 
            this.tsmi_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Contents,
            this.tsmi_About});
            this.tsmi_Help.Name = "tsmi_Help";
            this.tsmi_Help.Size = new System.Drawing.Size(44, 20);
            this.tsmi_Help.Text = "&Help";
            // 
            // tsmi_Contents
            // 
            this.tsmi_Contents.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Contents.Image")));
            this.tsmi_Contents.Name = "tsmi_Contents";
            this.tsmi_Contents.Size = new System.Drawing.Size(145, 22);
            this.tsmi_Contents.Text = "Contents";
            // 
            // tsmi_About
            // 
            this.tsmi_About.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_About.Image")));
            this.tsmi_About.Name = "tsmi_About";
            this.tsmi_About.Size = new System.Drawing.Size(145, 22);
            this.tsmi_About.Text = "About GMare";
            this.tsmi_About.Click += new System.EventHandler(this.tsmi_About_Click);
            // 
            // ts_Main
            // 
            this.ts_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_NewProject,
            this.tsb_OpenProject,
            this.toolStripSeparator1,
            this.tsb_SaveTileset,
            this.tsb_SaveProject,
            this.tsb_SaveBinary,
            this.toolStripSeparator8,
            this.tsb_Undo,
            this.tsb_Redo,
            this.tsb_Cut,
            this.tsb_Copy,
            this.tsb_Paste,
            this.tsb_Delete,
            this.toolStripSeparator2,
            this.tsb_Shift,
            this.tsb_BackColor,
            this.tsb_LayerView,
            this.tsb_Properties,
            this.toolStripSeparator7,
            this.tsb_Contents,
            this.tsb_About});
            this.ts_Main.Location = new System.Drawing.Point(0, 24);
            this.ts_Main.Name = "ts_Main";
            this.ts_Main.Size = new System.Drawing.Size(704, 25);
            this.ts_Main.TabIndex = 1;
            this.ts_Main.Text = "toolStrip1";
            // 
            // tsb_NewProject
            // 
            this.tsb_NewProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_NewProject.Image = global::GMare.Properties.Resources.file_new;
            this.tsb_NewProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_NewProject.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_NewProject.Name = "tsb_NewProject";
            this.tsb_NewProject.Size = new System.Drawing.Size(23, 22);
            this.tsb_NewProject.Text = "Create a new room";
            this.tsb_NewProject.Click += new System.EventHandler(this.tsmi_New_Click);
            // 
            // tsb_OpenProject
            // 
            this.tsb_OpenProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_OpenProject.Image = global::GMare.Properties.Resources.file_open;
            this.tsb_OpenProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_OpenProject.Name = "tsb_OpenProject";
            this.tsb_OpenProject.Size = new System.Drawing.Size(23, 22);
            this.tsb_OpenProject.Text = "Open an existing room";
            this.tsb_OpenProject.Click += new System.EventHandler(this.tsmi_Open_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_SaveTileset
            // 
            this.tsb_SaveTileset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_SaveTileset.Image = global::GMare.Properties.Resources.tileset_save;
            this.tsb_SaveTileset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_SaveTileset.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_SaveTileset.Name = "tsb_SaveTileset";
            this.tsb_SaveTileset.Size = new System.Drawing.Size(23, 22);
            this.tsb_SaveTileset.Text = "toolStripButton3";
            this.tsb_SaveTileset.ToolTipText = "Save tileset";
            this.tsb_SaveTileset.Click += new System.EventHandler(this.tsmi_SaveTileset_Click);
            // 
            // tsb_SaveProject
            // 
            this.tsb_SaveProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_SaveProject.Image = ((System.Drawing.Image)(resources.GetObject("tsb_SaveProject.Image")));
            this.tsb_SaveProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_SaveProject.Name = "tsb_SaveProject";
            this.tsb_SaveProject.Size = new System.Drawing.Size(23, 22);
            this.tsb_SaveProject.Text = "toolStripButton5";
            this.tsb_SaveProject.ToolTipText = "Save project";
            this.tsb_SaveProject.Click += new System.EventHandler(this.tsmi_Save_Click);
            // 
            // tsb_SaveBinary
            // 
            this.tsb_SaveBinary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_SaveBinary.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbmi_ExportImage,
            this.tbmi_ExportMultipleBinary,
            this.tbmi_ExportGMProject});
            this.tsb_SaveBinary.Image = global::GMare.Properties.Resources.export;
            this.tsb_SaveBinary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_SaveBinary.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_SaveBinary.Name = "tsb_SaveBinary";
            this.tsb_SaveBinary.Size = new System.Drawing.Size(32, 22);
            this.tsb_SaveBinary.Text = "toolStripSplitButton1";
            this.tsb_SaveBinary.ToolTipText = "Export options";
            // 
            // tbmi_ExportImage
            // 
            this.tbmi_ExportImage.Image = ((System.Drawing.Image)(resources.GetObject("tbmi_ExportImage.Image")));
            this.tbmi_ExportImage.Name = "tbmi_ExportImage";
            this.tbmi_ExportImage.Size = new System.Drawing.Size(154, 22);
            this.tbmi_ExportImage.Text = "Image File";
            this.tbmi_ExportImage.Click += new System.EventHandler(this.tsmi_ExportImage_Click);
            // 
            // tbmi_ExportMultipleBinary
            // 
            this.tbmi_ExportMultipleBinary.Image = global::GMare.Properties.Resources.export_binary;
            this.tbmi_ExportMultipleBinary.Name = "tbmi_ExportMultipleBinary";
            this.tbmi_ExportMultipleBinary.Size = new System.Drawing.Size(154, 22);
            this.tbmi_ExportMultipleBinary.Text = "Binary File";
            this.tbmi_ExportMultipleBinary.Click += new System.EventHandler(this.tsmi_ExportBinary_Click);
            // 
            // tbmi_ExportGMProject
            // 
            this.tbmi_ExportGMProject.Image = global::GMare.Properties.Resources.export_gmproject;
            this.tbmi_ExportGMProject.Name = "tbmi_ExportGMProject";
            this.tbmi_ExportGMProject.Size = new System.Drawing.Size(154, 22);
            this.tbmi_ExportGMProject.Text = "GM Project File";
            this.tbmi_ExportGMProject.Click += new System.EventHandler(this.tsmi_ExportGMProject_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_Undo
            // 
            this.tsb_Undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Undo.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Undo.Image")));
            this.tsb_Undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Undo.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_Undo.Name = "tsb_Undo";
            this.tsb_Undo.Size = new System.Drawing.Size(23, 22);
            this.tsb_Undo.Text = "toolStripButton1";
            this.tsb_Undo.ToolTipText = "Undo";
            this.tsb_Undo.Click += new System.EventHandler(this.tsmi_Undo_Click);
            // 
            // tsb_Redo
            // 
            this.tsb_Redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Redo.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Redo.Image")));
            this.tsb_Redo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Redo.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_Redo.Name = "tsb_Redo";
            this.tsb_Redo.Size = new System.Drawing.Size(23, 22);
            this.tsb_Redo.Text = "toolStripButton2";
            this.tsb_Redo.ToolTipText = "Redo";
            this.tsb_Redo.Click += new System.EventHandler(this.tsmi_Redo_Click);
            // 
            // tsb_Cut
            // 
            this.tsb_Cut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Cut.Image = global::GMare.Properties.Resources.clipboard_cut;
            this.tsb_Cut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Cut.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_Cut.Name = "tsb_Cut";
            this.tsb_Cut.Size = new System.Drawing.Size(23, 22);
            this.tsb_Cut.Text = "toolStripButton9";
            this.tsb_Cut.ToolTipText = "Cut";
            this.tsb_Cut.Click += new System.EventHandler(this.tsmi_Cut_Click);
            // 
            // tsb_Copy
            // 
            this.tsb_Copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Copy.Image = global::GMare.Properties.Resources.clipboard_copy;
            this.tsb_Copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Copy.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_Copy.Name = "tsb_Copy";
            this.tsb_Copy.Size = new System.Drawing.Size(23, 22);
            this.tsb_Copy.Text = "toolStripButton9";
            this.tsb_Copy.ToolTipText = "Copy";
            this.tsb_Copy.Click += new System.EventHandler(this.tsmi_Copy_Click);
            // 
            // tsb_Paste
            // 
            this.tsb_Paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Paste.Image = global::GMare.Properties.Resources.clipboard_paste;
            this.tsb_Paste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Paste.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_Paste.Name = "tsb_Paste";
            this.tsb_Paste.Size = new System.Drawing.Size(23, 22);
            this.tsb_Paste.Text = "toolStripButton9";
            this.tsb_Paste.ToolTipText = "Paste";
            this.tsb_Paste.Click += new System.EventHandler(this.tsmi_Paste_Click);
            // 
            // tsb_Delete
            // 
            this.tsb_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Delete.Image = global::GMare.Properties.Resources.button_decline;
            this.tsb_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Delete.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_Delete.Name = "tsb_Delete";
            this.tsb_Delete.Size = new System.Drawing.Size(23, 22);
            this.tsb_Delete.Text = "toolStripButton9";
            this.tsb_Delete.ToolTipText = "Delete";
            this.tsb_Delete.Click += new System.EventHandler(this.tsmi_Delete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_Shift
            // 
            this.tsb_Shift.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Shift.Image = global::GMare.Properties.Resources.arrow_move;
            this.tsb_Shift.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Shift.Name = "tsb_Shift";
            this.tsb_Shift.Size = new System.Drawing.Size(23, 22);
            this.tsb_Shift.Text = "toolStripButton11";
            this.tsb_Shift.ToolTipText = "Shift room";
            this.tsb_Shift.Click += new System.EventHandler(this.tsmi_Shift_Click);
            // 
            // tsb_BackColor
            // 
            this.tsb_BackColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_BackColor.Image = global::GMare.Properties.Resources.color_swatch;
            this.tsb_BackColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_BackColor.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_BackColor.Name = "tsb_BackColor";
            this.tsb_BackColor.Size = new System.Drawing.Size(23, 22);
            this.tsb_BackColor.Text = "toolStripButton9";
            this.tsb_BackColor.ToolTipText = "Set background color";
            this.tsb_BackColor.Click += new System.EventHandler(this.tsmi_BackColor_Click);
            // 
            // tsb_LayerView
            // 
            this.tsb_LayerView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_LayerView.Image = global::GMare.Properties.Resources.page_find;
            this.tsb_LayerView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_LayerView.Name = "tsb_LayerView";
            this.tsb_LayerView.Size = new System.Drawing.Size(23, 22);
            this.tsb_LayerView.Text = "toolStripButton1";
            this.tsb_LayerView.ToolTipText = "View layer data in textual form";
            this.tsb_LayerView.Click += new System.EventHandler(this.tsmi_LayerView_Click);
            // 
            // tsb_Properties
            // 
            this.tsb_Properties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Properties.Image = global::GMare.Properties.Resources.room_edit;
            this.tsb_Properties.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Properties.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_Properties.Name = "tsb_Properties";
            this.tsb_Properties.Size = new System.Drawing.Size(23, 22);
            this.tsb_Properties.Text = "toolStripButton10";
            this.tsb_Properties.ToolTipText = "Edit room properties";
            this.tsb_Properties.Click += new System.EventHandler(this.tsmi_Edit_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_Contents
            // 
            this.tsb_Contents.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Contents.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Contents.Image")));
            this.tsb_Contents.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Contents.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_Contents.Name = "tsb_Contents";
            this.tsb_Contents.Size = new System.Drawing.Size(23, 22);
            this.tsb_Contents.Text = "toolStripButton1";
            this.tsb_Contents.ToolTipText = "Contents";
            // 
            // tsb_About
            // 
            this.tsb_About.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_About.Image = ((System.Drawing.Image)(resources.GetObject("tsb_About.Image")));
            this.tsb_About.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_About.Name = "tsb_About";
            this.tsb_About.Size = new System.Drawing.Size(23, 22);
            this.tsb_About.Text = "toolStripButton12";
            this.tsb_About.ToolTipText = "About GMare";
            this.tsb_About.Click += new System.EventHandler(this.tsmi_About_Click);
            // 
            // ss_Main
            // 
            this.ss_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_Info,
            this.tssl_Actual,
            this.tssl_Snapped,
            this.toolStripStatusLabel1});
            this.ss_Main.Location = new System.Drawing.Point(0, 488);
            this.ss_Main.Name = "ss_Main";
            this.ss_Main.Size = new System.Drawing.Size(704, 24);
            this.ss_Main.TabIndex = 2;
            this.ss_Main.Text = "statusStrip1";
            // 
            // tssl_Info
            // 
            this.tssl_Info.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tssl_Info.Name = "tssl_Info";
            this.tssl_Info.Size = new System.Drawing.Size(4, 19);
            this.tssl_Info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssl_Actual
            // 
            this.tssl_Actual.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tssl_Actual.Name = "tssl_Actual";
            this.tssl_Actual.Size = new System.Drawing.Size(78, 19);
            this.tssl_Actual.Text = "Actual: -NA-";
            this.tssl_Actual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssl_Snapped
            // 
            this.tssl_Snapped.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tssl_Snapped.Name = "tssl_Snapped";
            this.tssl_Snapped.Size = new System.Drawing.Size(90, 19);
            this.tssl_Snapped.Text = "Snapped: -NA-";
            this.tssl_Snapped.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::GMare.Properties.Resources.eraser;
            this.toolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(517, 19);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = " Right click to erase";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tc_GUI);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 76);
            this.panel1.MinimumSize = new System.Drawing.Size(312, 412);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 412);
            this.panel1.TabIndex = 5;
            // 
            // tc_GUI
            // 
            this.tc_GUI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tc_GUI.Controls.Add(this.tabPage1);
            this.tc_GUI.Controls.Add(this.tabPage3);
            this.tc_GUI.Controls.Add(this.tabPage2);
            this.tc_GUI.Location = new System.Drawing.Point(8, 8);
            this.tc_GUI.Name = "tc_GUI";
            this.tc_GUI.SelectedIndex = 0;
            this.tc_GUI.Size = new System.Drawing.Size(300, 396);
            this.tc_GUI.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnl_Tileset);
            this.tabPage1.Controls.Add(this.ts_Tiles);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 5, 5, 5);
            this.tabPage1.Size = new System.Drawing.Size(292, 370);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tiles";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnl_Tileset
            // 
            this.pnl_Tileset.AutoScroll = true;
            this.pnl_Tileset.AutoScrollMinSize = new System.Drawing.Size(280, 331);
            this.pnl_Tileset.BackColor = System.Drawing.Color.White;
            this.pnl_Tileset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Tileset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Tileset.Image = null;
            this.pnl_Tileset.Location = new System.Drawing.Point(3, 30);
            this.pnl_Tileset.Name = "pnl_Tileset";
            tileGrid1.EndX = 16;
            tileGrid1.EndY = 16;
            tileGrid1.StartX = 0;
            tileGrid1.StartY = 0;
            tileGrid1.TileIds = null;
            this.pnl_Tileset.Selection = tileGrid1;
            this.pnl_Tileset.SelectMode = GMare.Controls.BackgroundPanel.SelectType.Normal;
            this.pnl_Tileset.Size = new System.Drawing.Size(284, 335);
            this.pnl_Tileset.TabIndex = 0;
            this.pnl_Tileset.Zoom = 1F;
            this.pnl_Tileset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_Tileset_MouseUp);
            // 
            // ts_Tiles
            // 
            this.ts_Tiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator9,
            this.tsb_TileTool,
            this.tsb_FillTool,
            this.tsb_SelectionTool,
            this.toolStripSeparator5,
            this.tsb_Swap,
            this.tsb_TilesetZoom});
            this.ts_Tiles.Location = new System.Drawing.Point(3, 5);
            this.ts_Tiles.Name = "ts_Tiles";
            this.ts_Tiles.Size = new System.Drawing.Size(284, 25);
            this.ts_Tiles.TabIndex = 1;
            this.ts_Tiles.Text = "toolStrip1";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_TileTool
            // 
            this.tsb_TileTool.Checked = true;
            this.tsb_TileTool.CheckOnClick = true;
            this.tsb_TileTool.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsb_TileTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_TileTool.Image = global::GMare.Properties.Resources.tool_paint;
            this.tsb_TileTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_TileTool.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_TileTool.Name = "tsb_TileTool";
            this.tsb_TileTool.Size = new System.Drawing.Size(23, 22);
            this.tsb_TileTool.Text = "toolStripButton6";
            this.tsb_TileTool.ToolTipText = "Tile tool";
            this.tsb_TileTool.CheckedChanged += new System.EventHandler(this.tsb_TileTool_CheckedChanged);
            // 
            // tsb_FillTool
            // 
            this.tsb_FillTool.CheckOnClick = true;
            this.tsb_FillTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_FillTool.Image = global::GMare.Properties.Resources.tool_fill;
            this.tsb_FillTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_FillTool.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_FillTool.Name = "tsb_FillTool";
            this.tsb_FillTool.Size = new System.Drawing.Size(23, 22);
            this.tsb_FillTool.Text = "toolStripButton7";
            this.tsb_FillTool.ToolTipText = "Flood fill tool";
            this.tsb_FillTool.CheckedChanged += new System.EventHandler(this.tsb_FillTool_CheckedChanged);
            // 
            // tsb_SelectionTool
            // 
            this.tsb_SelectionTool.CheckOnClick = true;
            this.tsb_SelectionTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_SelectionTool.Image = ((System.Drawing.Image)(resources.GetObject("tsb_SelectionTool.Image")));
            this.tsb_SelectionTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_SelectionTool.Name = "tsb_SelectionTool";
            this.tsb_SelectionTool.Size = new System.Drawing.Size(23, 22);
            this.tsb_SelectionTool.Text = "toolStripButton7";
            this.tsb_SelectionTool.ToolTipText = "Selection tool";
            this.tsb_SelectionTool.CheckedChanged += new System.EventHandler(this.tsb_SelectionTool_CheckedChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_Swap
            // 
            this.tsb_Swap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Swap.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Swap.Image")));
            this.tsb_Swap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Swap.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_Swap.Name = "tsb_Swap";
            this.tsb_Swap.Size = new System.Drawing.Size(23, 22);
            this.tsb_Swap.Text = "toolStripButton8";
            this.tsb_Swap.ToolTipText = "Replace tiles";
            this.tsb_Swap.Click += new System.EventHandler(this.tsb_Swap_Click);
            // 
            // tsb_TilesetZoom
            // 
            this.tsb_TilesetZoom.Image = global::GMare.Properties.Resources.magnifier;
            this.tsb_TilesetZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_TilesetZoom.Name = "tsb_TilesetZoom";
            this.tsb_TilesetZoom.Size = new System.Drawing.Size(64, 22);
            this.tsb_TilesetZoom.Text = "100%";
            this.tsb_TilesetZoom.UseIncrements = false;
            this.tsb_TilesetZoom.ZoomChanged += new GMare.Controls.ZoomToolStripButton.ZoomChangedHandler(this.tsb_TilesetZoom_ZoomChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lb_Instances);
            this.tabPage3.Controls.Add(this.toolStrip2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 5, 5, 5);
            this.tabPage3.Size = new System.Drawing.Size(292, 370);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Objects";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lb_Instances
            // 
            this.lb_Instances.CellHeight = 16;
            this.lb_Instances.CellWidth = 16;
            this.lb_Instances.ContextMenuStrip = this.cms_Instances;
            this.lb_Instances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Instances.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lb_Instances.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Instances.FormattingEnabled = true;
            this.lb_Instances.HorizontalExtent = 280;
            this.lb_Instances.IntegralHeight = false;
            this.lb_Instances.ItemHeight = 18;
            this.lb_Instances.ListboxMode = GMare.Controls.ListboxEx.ListboxType.Instances;
            this.lb_Instances.Location = new System.Drawing.Point(3, 30);
            this.lb_Instances.Name = "lb_Instances";
            this.lb_Instances.Size = new System.Drawing.Size(284, 335);
            this.lb_Instances.TabIndex = 0;
            this.lb_Instances.SelectedIndexChanged += new System.EventHandler(this.lb_Instances_SelectedIndexChanged);
            // 
            // cms_Instances
            // 
            this.cms_Instances.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Sorting,
            this.toolStripMenuItem3,
            this.tsmi_CreationCode,
            this.tsmi_DeleteInstance});
            this.cms_Instances.Name = "cms_Instances";
            this.cms_Instances.Size = new System.Drawing.Size(174, 76);
            this.cms_Instances.Opening += new System.ComponentModel.CancelEventHandler(this.cms_Instances_Opening);
            // 
            // tsmi_Sorting
            // 
            this.tsmi_Sorting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_SortStandard,
            this.tsmi_SortAscending,
            this.tsmi_SortDescending});
            this.tsmi_Sorting.Image = global::GMare.Properties.Resources.list_box;
            this.tsmi_Sorting.Name = "tsmi_Sorting";
            this.tsmi_Sorting.Size = new System.Drawing.Size(173, 22);
            this.tsmi_Sorting.Text = "Sorting";
            // 
            // tsmi_SortStandard
            // 
            this.tsmi_SortStandard.Checked = true;
            this.tsmi_SortStandard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmi_SortStandard.Image = global::GMare.Properties.Resources.sort_type;
            this.tsmi_SortStandard.Name = "tsmi_SortStandard";
            this.tsmi_SortStandard.Size = new System.Drawing.Size(136, 22);
            this.tsmi_SortStandard.Text = "Standard";
            this.tsmi_SortStandard.Click += new System.EventHandler(this.tsmi_SortStandard_Click);
            // 
            // tsmi_SortAscending
            // 
            this.tsmi_SortAscending.Image = global::GMare.Properties.Resources.sort_alphabetical_ascending;
            this.tsmi_SortAscending.Name = "tsmi_SortAscending";
            this.tsmi_SortAscending.Size = new System.Drawing.Size(136, 22);
            this.tsmi_SortAscending.Text = "Ascending";
            this.tsmi_SortAscending.Click += new System.EventHandler(this.tsmi_SortAscending_Click);
            // 
            // tsmi_SortDescending
            // 
            this.tsmi_SortDescending.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_SortDescending.Image")));
            this.tsmi_SortDescending.Name = "tsmi_SortDescending";
            this.tsmi_SortDescending.Size = new System.Drawing.Size(136, 22);
            this.tsmi_SortDescending.Text = "Descending";
            this.tsmi_SortDescending.Click += new System.EventHandler(this.tsmi_SortDescending_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(170, 6);
            // 
            // tsmi_CreationCode
            // 
            this.tsmi_CreationCode.Image = global::GMare.Properties.Resources.script;
            this.tsmi_CreationCode.Name = "tsmi_CreationCode";
            this.tsmi_CreationCode.Size = new System.Drawing.Size(173, 22);
            this.tsmi_CreationCode.Text = "Edit Creation Code";
            this.tsmi_CreationCode.Click += new System.EventHandler(this.tsmi_CreationCode_Click);
            // 
            // tsmi_DeleteInstance
            // 
            this.tsmi_DeleteInstance.Image = global::GMare.Properties.Resources.bin;
            this.tsmi_DeleteInstance.Name = "tsmi_DeleteInstance";
            this.tsmi_DeleteInstance.Size = new System.Drawing.Size(173, 22);
            this.tsmi_DeleteInstance.Text = "Delete Instance";
            this.tsmi_DeleteInstance.Click += new System.EventHandler(this.tsmi_DeleteInstance_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_ImportObjects,
            this.toolStripSeparator3,
            this.toolStripLabel4,
            this.tsb_Objects});
            this.toolStrip2.Location = new System.Drawing.Point(3, 5);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(284, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip1";
            // 
            // tsb_ImportObjects
            // 
            this.tsb_ImportObjects.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_ImportObjects.Image = global::GMare.Properties.Resources.import_objects;
            this.tsb_ImportObjects.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_ImportObjects.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_ImportObjects.Name = "tsb_ImportObjects";
            this.tsb_ImportObjects.Size = new System.Drawing.Size(23, 22);
            this.tsb_ImportObjects.Text = "toolStripButton3";
            this.tsb_ImportObjects.ToolTipText = "Import objects from Game Maker project";
            this.tsb_ImportObjects.Click += new System.EventHandler(this.tsb_ImportObjects_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripLabel4.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(45, 19);
            this.toolStripLabel4.Text = "Object:";
            // 
            // tsb_Objects
            // 
            this.tsb_Objects.Image = global::GMare.Properties.Resources.slash;
            this.tsb_Objects.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Objects.Name = "tsb_Objects";
            this.tsb_Objects.Size = new System.Drawing.Size(76, 22);
            this.tsb_Objects.Text = "(None)";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lb_Shapes);
            this.tabPage2.Controls.Add(this.ts_Collisions);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 5, 5, 5);
            this.tabPage2.Size = new System.Drawing.Size(292, 370);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Collisions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lb_Shapes
            // 
            this.lb_Shapes.CellHeight = 16;
            this.lb_Shapes.CellWidth = 16;
            this.lb_Shapes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Shapes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lb_Shapes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Shapes.HorizontalExtent = 280;
            this.lb_Shapes.HorizontalScrollbar = true;
            this.lb_Shapes.IntegralHeight = false;
            this.lb_Shapes.ItemHeight = 16;
            this.lb_Shapes.ListboxMode = GMare.Controls.ListboxEx.ListboxType.Shapes;
            this.lb_Shapes.Location = new System.Drawing.Point(3, 30);
            this.lb_Shapes.Name = "lb_Shapes";
            this.lb_Shapes.Size = new System.Drawing.Size(284, 335);
            this.lb_Shapes.Sorted = true;
            this.lb_Shapes.TabIndex = 0;
            this.lb_Shapes.SelectedIndexChanged += new System.EventHandler(this.lb_Shapes_SelectedIndexChanged);
            // 
            // ts_Collisions
            // 
            this.ts_Collisions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_MoveUp,
            this.tsb_MoveDown,
            this.tsb_ShapeDelete,
            this.tsb_Level});
            this.ts_Collisions.Location = new System.Drawing.Point(3, 5);
            this.ts_Collisions.Name = "ts_Collisions";
            this.ts_Collisions.Size = new System.Drawing.Size(284, 25);
            this.ts_Collisions.TabIndex = 2;
            this.ts_Collisions.Text = "toolStrip2";
            // 
            // tsb_MoveUp
            // 
            this.tsb_MoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_MoveUp.Image = global::GMare.Properties.Resources.sort_up;
            this.tsb_MoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_MoveUp.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_MoveUp.Name = "tsb_MoveUp";
            this.tsb_MoveUp.Size = new System.Drawing.Size(23, 22);
            this.tsb_MoveUp.Text = "toolStripButton3";
            this.tsb_MoveUp.ToolTipText = "Move shape up the list";
            // 
            // tsb_MoveDown
            // 
            this.tsb_MoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_MoveDown.Image = global::GMare.Properties.Resources.sort_down;
            this.tsb_MoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_MoveDown.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_MoveDown.Name = "tsb_MoveDown";
            this.tsb_MoveDown.Size = new System.Drawing.Size(23, 22);
            this.tsb_MoveDown.Text = "toolStripButton7";
            this.tsb_MoveDown.ToolTipText = "Move shape down list";
            // 
            // tsb_ShapeDelete
            // 
            this.tsb_ShapeDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_ShapeDelete.Image = global::GMare.Properties.Resources.bin;
            this.tsb_ShapeDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_ShapeDelete.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_ShapeDelete.Name = "tsb_ShapeDelete";
            this.tsb_ShapeDelete.Size = new System.Drawing.Size(23, 22);
            this.tsb_ShapeDelete.Text = "toolStripButton12";
            this.tsb_ShapeDelete.ToolTipText = "Delete shape";
            // 
            // tsb_Level
            // 
            this.tsb_Level.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Level1,
            this.tsmi_Level2,
            this.tsmi_Level3,
            this.tsmi_Level4,
            this.tsmi_Level5});
            this.tsb_Level.Image = global::GMare.Properties.Resources.level01;
            this.tsb_Level.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Level.Name = "tsb_Level";
            this.tsb_Level.Size = new System.Drawing.Size(75, 22);
            this.tsb_Level.Text = "Level 1";
            this.tsb_Level.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsb_Level_DropDownItemClicked);
            // 
            // tsmi_Level1
            // 
            this.tsmi_Level1.Image = global::GMare.Properties.Resources.level01;
            this.tsmi_Level1.Name = "tsmi_Level1";
            this.tsmi_Level1.Size = new System.Drawing.Size(110, 22);
            this.tsmi_Level1.Tag = "0";
            this.tsmi_Level1.Text = "Level 1";
            // 
            // tsmi_Level2
            // 
            this.tsmi_Level2.Image = global::GMare.Properties.Resources.level02;
            this.tsmi_Level2.Name = "tsmi_Level2";
            this.tsmi_Level2.Size = new System.Drawing.Size(110, 22);
            this.tsmi_Level2.Tag = "1";
            this.tsmi_Level2.Text = "Level 2";
            // 
            // tsmi_Level3
            // 
            this.tsmi_Level3.Image = global::GMare.Properties.Resources.level03;
            this.tsmi_Level3.Name = "tsmi_Level3";
            this.tsmi_Level3.Size = new System.Drawing.Size(110, 22);
            this.tsmi_Level3.Tag = "2";
            this.tsmi_Level3.Text = "Level 3";
            // 
            // tsmi_Level4
            // 
            this.tsmi_Level4.Image = global::GMare.Properties.Resources.level04;
            this.tsmi_Level4.Name = "tsmi_Level4";
            this.tsmi_Level4.Size = new System.Drawing.Size(110, 22);
            this.tsmi_Level4.Tag = "3";
            this.tsmi_Level4.Text = "Level 4";
            // 
            // tsmi_Level5
            // 
            this.tsmi_Level5.Image = global::GMare.Properties.Resources.level05;
            this.tsmi_Level5.Name = "tsmi_Level5";
            this.tsmi_Level5.Size = new System.Drawing.Size(110, 22);
            this.tsmi_Level5.Tag = "4";
            this.tsmi_Level5.Text = "Level 5";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gb_Editor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(312, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(392, 412);
            this.panel2.TabIndex = 6;
            // 
            // gb_Editor
            // 
            this.gb_Editor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Editor.Controls.Add(this.pnl_RoomEditor);
            this.gb_Editor.Location = new System.Drawing.Point(8, 8);
            this.gb_Editor.Name = "gb_Editor";
            this.gb_Editor.Size = new System.Drawing.Size(376, 398);
            this.gb_Editor.TabIndex = 0;
            this.gb_Editor.TabStop = false;
            this.gb_Editor.Text = "Room Editor";
            // 
            // pnl_RoomEditor
            // 
            this.pnl_RoomEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_RoomEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.pnl_RoomEditor.DepthIndex = 0;
            this.pnl_RoomEditor.EditMode = GMare.Common.EditType.ViewAll;
            this.pnl_RoomEditor.GridMode = GMare.Common.GridType.Normal;
            this.pnl_RoomEditor.GridX = 16;
            this.pnl_RoomEditor.GridY = 16;
            this.pnl_RoomEditor.LayerIndex = -1;
            this.pnl_RoomEditor.Level = 0;
            this.pnl_RoomEditor.Location = new System.Drawing.Point(8, 16);
            this.pnl_RoomEditor.Name = "pnl_RoomEditor";
            this.pnl_RoomEditor.Padding = new System.Windows.Forms.Padding(1);
            this.pnl_RoomEditor.SelectedInstance = null;
            this.pnl_RoomEditor.SelectedObject = null;
            this.pnl_RoomEditor.SelectedShape = null;
            this.pnl_RoomEditor.ShapeMode = GMare.Common.ShapeType.Rectangle;
            this.pnl_RoomEditor.ShowGrid = true;
            this.pnl_RoomEditor.Size = new System.Drawing.Size(360, 372);
            this.pnl_RoomEditor.Snap = true;
            this.pnl_RoomEditor.TabIndex = 0;
            tileGrid2.EndX = 16;
            tileGrid2.EndY = 16;
            tileGrid2.StartX = 0;
            tileGrid2.StartY = 0;
            tileGrid2.TileIds = null;
            this.pnl_RoomEditor.Tiles = tileGrid2;
            this.pnl_RoomEditor.ToolMode = GMare.Common.ToolType.Pencil;
            this.pnl_RoomEditor.Zoom = 1F;
            this.pnl_RoomEditor.PositionChanged += new GMare.Controls.RoomEditor.PositionHandler(this.pnl_RoomEditor_PositionChanged);
            this.pnl_RoomEditor.InstanceChanged += new GMare.Controls.RoomEditor.InstanceChangedHandler(this.pnl_RoomEditor_SelectedInstanceChanged);
            this.pnl_RoomEditor.RoomChanged += new GMare.Controls.RoomEditor.RoomChangedHandler(this.pnl_RoomEditor_RoomChanged);
            this.pnl_RoomEditor.ClipboardChanged += new GMare.Controls.RoomEditor.ClipboardChangedHandler(this.pnl_RoomEditor_ClipboardChanged);
            this.pnl_RoomEditor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_RoomEditor_MouseUp);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(312, 76);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 412);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // ts_Tools
            // 
            this.ts_Tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_Grid,
            this.tsb_GridIso,
            this.tsb_Snap,
            this.toolStripSeparator4,
            this.toolStripLabel1,
            this.tsb_GridX,
            this.toolStripLabel2,
            this.tsb_GridY,
            this.tsb_Zoom,
            this.toolStripSeparator6,
            this.tsb_LayerOptions,
            this.tsl_Layer,
            this.tscb_EditSelect});
            this.ts_Tools.Location = new System.Drawing.Point(0, 49);
            this.ts_Tools.Name = "ts_Tools";
            this.ts_Tools.Padding = new System.Windows.Forms.Padding(0, 1, 1, 0);
            this.ts_Tools.Size = new System.Drawing.Size(704, 27);
            this.ts_Tools.TabIndex = 8;
            this.ts_Tools.Text = "toolStrip2";
            // 
            // tsb_Grid
            // 
            this.tsb_Grid.Checked = true;
            this.tsb_Grid.CheckOnClick = true;
            this.tsb_Grid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsb_Grid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Grid.Image = global::GMare.Properties.Resources.grid;
            this.tsb_Grid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Grid.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_Grid.Name = "tsb_Grid";
            this.tsb_Grid.Size = new System.Drawing.Size(23, 23);
            this.tsb_Grid.Text = "toolStripButton13";
            this.tsb_Grid.ToolTipText = "Show grid";
            this.tsb_Grid.CheckedChanged += new System.EventHandler(this.tsb_Grid_Click);
            // 
            // tsb_GridIso
            // 
            this.tsb_GridIso.CheckOnClick = true;
            this.tsb_GridIso.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_GridIso.Image = global::GMare.Properties.Resources.grid_isometric;
            this.tsb_GridIso.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_GridIso.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.tsb_GridIso.Name = "tsb_GridIso";
            this.tsb_GridIso.Size = new System.Drawing.Size(23, 23);
            this.tsb_GridIso.Text = "toolStripButton1";
            this.tsb_GridIso.ToolTipText = "The grid is drawn in an isometric perspective";
            this.tsb_GridIso.CheckedChanged += new System.EventHandler(this.tsb_GridIso_CheckedChanged);
            // 
            // tsb_Snap
            // 
            this.tsb_Snap.Checked = true;
            this.tsb_Snap.CheckOnClick = true;
            this.tsb_Snap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsb_Snap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Snap.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Snap.Image")));
            this.tsb_Snap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Snap.Name = "tsb_Snap";
            this.tsb_Snap.Size = new System.Drawing.Size(23, 23);
            this.tsb_Snap.Text = "toolStripButton2";
            this.tsb_Snap.ToolTipText = "Snap instances to grid";
            this.tsb_Snap.Click += new System.EventHandler(this.tsmi_Snap_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(42, 23);
            this.toolStripLabel1.Text = "Grid X:";
            // 
            // tsb_GridX
            // 
            this.tsb_GridX.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.tsb_GridX.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.tsb_GridX.Name = "tsb_GridX";
            this.tsb_GridX.Size = new System.Drawing.Size(41, 23);
            this.tsb_GridX.Text = "16";
            this.tsb_GridX.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.tsb_GridX.ValueChanged += new System.EventHandler(this.tsb_GridX_ValueChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(42, 23);
            this.toolStripLabel2.Text = "Grid Y:";
            // 
            // tsb_GridY
            // 
            this.tsb_GridY.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tsb_GridY.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.tsb_GridY.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.tsb_GridY.Name = "tsb_GridY";
            this.tsb_GridY.Size = new System.Drawing.Size(41, 23);
            this.tsb_GridY.Text = "16";
            this.tsb_GridY.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.tsb_GridY.ValueChanged += new System.EventHandler(this.tsb_GridY_ValueChanged);
            // 
            // tsb_Zoom
            // 
            this.tsb_Zoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_ZoomIn,
            this.tsmi_ZoomOut,
            this.toolStripMenuItem6,
            this.tsmi_Zoom25,
            this.tsmi_Zoom50,
            this.tsmi_Zoom100,
            this.tsmi_Zoom200,
            this.tsmi_Zoom400});
            this.tsb_Zoom.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Zoom.Image")));
            this.tsb_Zoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Zoom.Name = "tsb_Zoom";
            this.tsb_Zoom.Size = new System.Drawing.Size(67, 23);
            this.tsb_Zoom.Tag = "";
            this.tsb_Zoom.Text = "100%";
            this.tsb_Zoom.ToolTipText = "Zoom options";
            // 
            // tsmi_ZoomIn
            // 
            this.tsmi_ZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_ZoomIn.Image")));
            this.tsmi_ZoomIn.Name = "tsmi_ZoomIn";
            this.tsmi_ZoomIn.ShortcutKeyDisplayString = "Ctrl +";
            this.tsmi_ZoomIn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.tsmi_ZoomIn.Size = new System.Drawing.Size(163, 22);
            this.tsmi_ZoomIn.Text = "Zoom In";
            this.tsmi_ZoomIn.Click += new System.EventHandler(this.tsmi_Zoom_Click);
            // 
            // tsmi_ZoomOut
            // 
            this.tsmi_ZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_ZoomOut.Image")));
            this.tsmi_ZoomOut.Name = "tsmi_ZoomOut";
            this.tsmi_ZoomOut.ShortcutKeyDisplayString = "Ctrl -";
            this.tsmi_ZoomOut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.tsmi_ZoomOut.Size = new System.Drawing.Size(163, 22);
            this.tsmi_ZoomOut.Text = "Zoom Out";
            this.tsmi_ZoomOut.Click += new System.EventHandler(this.tsmi_Zoom_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(160, 6);
            // 
            // tsmi_Zoom25
            // 
            this.tsmi_Zoom25.CheckOnClick = true;
            this.tsmi_Zoom25.Name = "tsmi_Zoom25";
            this.tsmi_Zoom25.Size = new System.Drawing.Size(163, 22);
            this.tsmi_Zoom25.Text = "25%";
            this.tsmi_Zoom25.Click += new System.EventHandler(this.tsmi_Zoom_Click);
            // 
            // tsmi_Zoom50
            // 
            this.tsmi_Zoom50.CheckOnClick = true;
            this.tsmi_Zoom50.Name = "tsmi_Zoom50";
            this.tsmi_Zoom50.Size = new System.Drawing.Size(163, 22);
            this.tsmi_Zoom50.Text = "50%";
            this.tsmi_Zoom50.Click += new System.EventHandler(this.tsmi_Zoom_Click);
            // 
            // tsmi_Zoom100
            // 
            this.tsmi_Zoom100.Checked = true;
            this.tsmi_Zoom100.CheckOnClick = true;
            this.tsmi_Zoom100.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmi_Zoom100.Name = "tsmi_Zoom100";
            this.tsmi_Zoom100.Size = new System.Drawing.Size(163, 22);
            this.tsmi_Zoom100.Text = "100%";
            this.tsmi_Zoom100.Click += new System.EventHandler(this.tsmi_Zoom_Click);
            // 
            // tsmi_Zoom200
            // 
            this.tsmi_Zoom200.CheckOnClick = true;
            this.tsmi_Zoom200.Name = "tsmi_Zoom200";
            this.tsmi_Zoom200.Size = new System.Drawing.Size(163, 22);
            this.tsmi_Zoom200.Text = "200%";
            this.tsmi_Zoom200.Click += new System.EventHandler(this.tsmi_Zoom_Click);
            // 
            // tsmi_Zoom400
            // 
            this.tsmi_Zoom400.CheckOnClick = true;
            this.tsmi_Zoom400.Name = "tsmi_Zoom400";
            this.tsmi_Zoom400.Size = new System.Drawing.Size(163, 22);
            this.tsmi_Zoom400.Text = "400%";
            this.tsmi_Zoom400.Click += new System.EventHandler(this.tsmi_Zoom_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 26);
            // 
            // tsb_LayerOptions
            // 
            this.tsb_LayerOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_LayerOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_LayerAdd,
            this.toolStripMenuItem5,
            this.tsmi_LayerEdit,
            this.tsmi_LayerDelete,
            this.tsmi_LayerClear});
            this.tsb_LayerOptions.Image = global::GMare.Properties.Resources.layer;
            this.tsb_LayerOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_LayerOptions.Name = "tsb_LayerOptions";
            this.tsb_LayerOptions.Size = new System.Drawing.Size(32, 23);
            this.tsb_LayerOptions.Text = "toolStripSplitButton1";
            this.tsb_LayerOptions.ToolTipText = "Layer options";
            // 
            // tsmi_LayerAdd
            // 
            this.tsmi_LayerAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_LayerAdd.Image")));
            this.tsmi_LayerAdd.Name = "tsmi_LayerAdd";
            this.tsmi_LayerAdd.Size = new System.Drawing.Size(138, 22);
            this.tsmi_LayerAdd.Text = "Add Layer";
            this.tsmi_LayerAdd.Click += new System.EventHandler(this.tsmi_LayerAdd_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(135, 6);
            // 
            // tsmi_LayerEdit
            // 
            this.tsmi_LayerEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_LayerEdit.Image")));
            this.tsmi_LayerEdit.Name = "tsmi_LayerEdit";
            this.tsmi_LayerEdit.Size = new System.Drawing.Size(138, 22);
            this.tsmi_LayerEdit.Text = "Edit Layer";
            this.tsmi_LayerEdit.Click += new System.EventHandler(this.tsmi_LayerEdit_Click);
            // 
            // tsmi_LayerDelete
            // 
            this.tsmi_LayerDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_LayerDelete.Image")));
            this.tsmi_LayerDelete.Name = "tsmi_LayerDelete";
            this.tsmi_LayerDelete.Size = new System.Drawing.Size(138, 22);
            this.tsmi_LayerDelete.Text = "Delete Layer";
            this.tsmi_LayerDelete.Click += new System.EventHandler(this.tsmi_LayerDelete_Click);
            // 
            // tsmi_LayerClear
            // 
            this.tsmi_LayerClear.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_LayerClear.Image")));
            this.tsmi_LayerClear.Name = "tsmi_LayerClear";
            this.tsmi_LayerClear.Size = new System.Drawing.Size(138, 22);
            this.tsmi_LayerClear.Text = "Clear Layer";
            this.tsmi_LayerClear.Click += new System.EventHandler(this.tsb_LayerClear_Click);
            // 
            // tsl_Layer
            // 
            this.tsl_Layer.Name = "tsl_Layer";
            this.tsl_Layer.Size = new System.Drawing.Size(64, 23);
            this.tsl_Layer.Text = "Edit Mode:";
            // 
            // tscb_EditSelect
            // 
            this.tscb_EditSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscb_EditSelect.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tscb_EditSelect.Margin = new System.Windows.Forms.Padding(0, 1, 1, 4);
            this.tscb_EditSelect.Name = "tscb_EditSelect";
            this.tscb_EditSelect.SelectedIndex = 0;
            this.tscb_EditSelect.SelectedItem = "View Room";
            this.tscb_EditSelect.Size = new System.Drawing.Size(150, 21);
            this.tscb_EditSelect.Text = "View Room";
            this.tscb_EditSelect.SelectedIndexChanged += new System.EventHandler(this.tscb_EditSelect_SelectedIndexChanged);
            this.tscb_EditSelect.DropDownClosed += new System.EventHandler(this.tscb_EditSelect_DropDownClosed);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 512);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ss_Main);
            this.Controls.Add(this.ts_Tools);
            this.Controls.Add(this.ts_Main);
            this.Controls.Add(this.ms_Main);
            this.MainMenuStrip = this.ms_Main;
            this.MinimumSize = new System.Drawing.Size(720, 550);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GMare";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ms_Main.ResumeLayout(false);
            this.ms_Main.PerformLayout();
            this.ts_Main.ResumeLayout(false);
            this.ts_Main.PerformLayout();
            this.ss_Main.ResumeLayout(false);
            this.ss_Main.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tc_GUI.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ts_Tiles.ResumeLayout(false);
            this.ts_Tiles.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.cms_Instances.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ts_Collisions.ResumeLayout(false);
            this.ts_Collisions.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.gb_Editor.ResumeLayout(false);
            this.ts_Tools.ResumeLayout(false);
            this.ts_Tools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ms_Main;
        private System.Windows.Forms.ToolStripMenuItem tsmi_File;
        private System.Windows.Forms.ToolStrip ts_Main;
        private System.Windows.Forms.ToolStripButton tsb_NewProject;
        private System.Windows.Forms.ToolStripButton tsb_OpenProject;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsb_SaveProject;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Tools;
        private System.Windows.Forms.ToolStripMenuItem tsmi_BackColor;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Properties;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Shift;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Help;
        private System.Windows.Forms.ToolStripMenuItem tsmi_About;
        private System.Windows.Forms.ToolStripMenuItem tsmi_NewProject;
        private System.Windows.Forms.ToolStripMenuItem tsmi_OpenProject;
        private System.Windows.Forms.ToolStripMenuItem tsmi_CloseProject;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SaveProject;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Exit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.StatusStrip ss_Main;
        private System.Windows.Forms.ToolStripButton tsb_About;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Actual;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Snapped;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Export;
        private System.Windows.Forms.ToolStrip ts_Tools;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripLabel tsl_Layer;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private GMare.Controls.ToolStripNumericUpDown tsb_GridX;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private GMare.Controls.ToolStripNumericUpDown tsb_GridY;
        private System.Windows.Forms.ToolStripSplitButton tsb_SaveBinary;
        private System.Windows.Forms.ToolStripMenuItem tbmi_ExportImage;
        private GMare.Controls.ToolStripComboBox tscb_EditSelect;
        private System.Windows.Forms.ToolStripButton tsb_BackColor;
        private System.Windows.Forms.ToolStripButton tsb_Properties;
        private System.Windows.Forms.ToolStripButton tsb_Shift;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ExportMultipleBinary;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ExportImage;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ExportGMProject;
        private System.Windows.Forms.ToolStripMenuItem tbmi_ExportMultipleBinary;
        private System.Windows.Forms.ToolStripMenuItem tbmi_ExportGMProject;
        private System.Windows.Forms.ToolStripButton tsb_LayerView;
        private System.Windows.Forms.ToolStripMenuItem tsmi_LayerView;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Contents;
        private System.Windows.Forms.ToolStripButton tsb_Contents;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsb_Grid;
        private System.Windows.Forms.ToolStripButton tsb_GridIso;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SaveTileset;
        private System.Windows.Forms.ToolStripButton tsb_SaveTileset;
        private System.Windows.Forms.ToolStripSplitButton tsb_LayerOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmi_LayerAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem tsmi_LayerEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmi_LayerDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmi_LayerClear;
        private System.Windows.Forms.ToolStripSplitButton tsb_Zoom;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ZoomIn;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ZoomOut;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Zoom25;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Zoom50;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Zoom100;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Zoom200;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Zoom400;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox gb_Editor;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Info;
        private System.Windows.Forms.ToolStripButton tsb_Snap;
        private System.Windows.Forms.TabControl tc_GUI;
        private System.Windows.Forms.TabPage tabPage1;
        private Controls.BackgroundPanel pnl_Tileset;
        private System.Windows.Forms.TabPage tabPage3;
        private Controls.ListboxEx lb_Instances;
        private System.Windows.Forms.TabPage tabPage2;
        private Controls.ListboxEx lb_Shapes;
        private System.Windows.Forms.ToolStrip ts_Collisions;
        private System.Windows.Forms.ToolStripButton tsb_MoveUp;
        private System.Windows.Forms.ToolStripButton tsb_MoveDown;
        private System.Windows.Forms.ToolStripButton tsb_ShapeDelete;
        private System.Windows.Forms.ToolStripSplitButton tsb_Level;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Level1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Level2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Level3;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Level4;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Level5;
        private System.Windows.Forms.ToolStrip ts_Tiles;
        private System.Windows.Forms.ToolStripButton tsb_TileTool;
        private System.Windows.Forms.ToolStripButton tsb_FillTool;
        private System.Windows.Forms.ToolStripButton tsb_SelectionTool;
        private Controls.ZoomToolStripButton tsb_TilesetZoom;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripSplitButton tsb_Objects;
        private System.Windows.Forms.ToolStripButton tsb_Swap;
        private System.Windows.Forms.ToolStripButton tsb_ImportObjects;
        private System.Windows.Forms.ContextMenuStrip cms_Instances;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Sorting;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SortStandard;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SortAscending;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SortDescending;
        private System.Windows.Forms.ToolStripMenuItem tsmi_CreationCode;
        private System.Windows.Forms.ToolStripMenuItem tsmi_DeleteInstance;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private Controls.RoomEditor pnl_RoomEditor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Undo;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Redo;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Cut;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Copy;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Paste;
        private System.Windows.Forms.ToolStripButton tsb_Undo;
        private System.Windows.Forms.ToolStripButton tsb_Redo;
        private System.Windows.Forms.ToolStripButton tsb_Cut;
        private System.Windows.Forms.ToolStripButton tsb_Copy;
        private System.Windows.Forms.ToolStripButton tsb_Paste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Delete;
        private System.Windows.Forms.ToolStripButton tsb_Delete;
    }
}

