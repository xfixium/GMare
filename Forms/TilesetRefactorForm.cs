// Decompiled with JetBrains decompiler
// Type: GMare.Forms.TilesetRefactorForm
// Assembly: GMare, Version=1.0.0.18, Culture=neutral, PublicKeyToken=null
// MVID: 2D0D4CCF-F6FC-4E10-8440-03A4A8ADC62E
// Assembly location: C:\Users\r2d2r\Desktop\gmare_beta_118\gmare_beta_118\GMare.exe

using GenericUndoRedo;
using GMare.Controls;
using GMare.Graphics;
using GMare.Objects;
using GMare.Properties;
using Pyxosoft.Windows.Tools.PyxTools.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMare.Forms
{
  public class TilesetRefactorForm : Form, ITilesOwner
  {
    private Size _originalSize = Size.Empty;
    private IContainer components;
    private Label lblMagnify;
    private Panel pnlMagnify;
    private PyxTrackBar trkMagnify;
    private GMareTilesetRefactorEditor pnlTileset;
    private PyxButton butCancel;
    private PyxButton butOk;
    private PyxNumericUpDown nudRows;
    private PyxNumericUpDown nudColumns;
    private Label lblTileX;
    private Label lblTileY;
    private PyxButton butGrid;
    private PyxButton butRedo;
    private PyxButton butUndo;
    private StatusStrip ssMain;
    private ToolStripStatusLabel lblTileCount;
    private ToolStripStatusLabel lblTilesetSize;
    private UndoRedoHistory<ITilesOwner> _history;
    private GMareBackground _background;
    private int[] _targets;
    private int[] _replacements;
    private bool _changed;

    public TileData Data
    {
      get
      {
        return new TileData(this.pnlTileset.Tiles, this.pnlTileset.Columns);
      }
      set
      {
        this.nudColumns.Value = (Decimal) value.Columns;
        this.pnlTileset.Columns = value.Columns;
        this.pnlTileset.Tiles = value.Tiles;
      }
    }

    public GMareBackground Background
    {
      get
      {
        return this._background;
      }
    }

    public int[] Targets
    {
      get
      {
        return this._targets;
      }
    }

    public int[] Replacements
    {
      get
      {
        return this._replacements;
      }
    }

    public bool Changed
    {
      get
      {
        return this._changed;
      }
    }

    public TilesetRefactorForm()
    {
      this.InitializeComponent();
      this._background = App.Room.Backgrounds[0].Clone();
      this._originalSize = new Size(this._background.Image.Width, this._background.Image.Height);
      this.butUndo.Enabled = false;
      this.butRedo.Enabled = false;
      this._history = new UndoRedoHistory<ITilesOwner>((ITilesOwner) this, 20);
      this.PopulateTiles(this._background.GetCondensedTileset());
      this.SetUI();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TilesetRefactorForm));
      this.lblMagnify = new Label();
      this.pnlMagnify = new Panel();
      this.trkMagnify = new PyxTrackBar();
      this.butCancel = new PyxButton();
      this.butOk = new PyxButton();
      this.nudRows = new PyxNumericUpDown();
      this.nudColumns = new PyxNumericUpDown();
      this.lblTileX = new Label();
      this.lblTileY = new Label();
      this.butGrid = new PyxButton();
      this.butRedo = new PyxButton();
      this.butUndo = new PyxButton();
      this.ssMain = new StatusStrip();
      this.lblTileCount = new ToolStripStatusLabel();
      this.lblTilesetSize = new ToolStripStatusLabel();
      this.pnlTileset = new GMareTilesetRefactorEditor();
      this.nudRows.BeginInit();
      this.nudColumns.BeginInit();
      this.ssMain.SuspendLayout();
      this.SuspendLayout();
      this.lblMagnify.AutoSize = true;
      this.lblMagnify.Location = new Point(400, 10);
      this.lblMagnify.Name = "lblMagnify";
      this.lblMagnify.Size = new Size(33, 13);
      this.lblMagnify.TabIndex = 9;
      this.lblMagnify.Text = "100%";
      this.pnlMagnify.BackgroundImage = (Image) Resources.magnifier;
      this.pnlMagnify.BackgroundImageLayout = ImageLayout.Center;
      this.pnlMagnify.Location = new Point(280, 4);
      this.pnlMagnify.Name = "pnlMagnify";
      this.pnlMagnify.Size = new Size(24, 24);
      this.pnlMagnify.TabIndex = 7;
      this.trkMagnify.BackColor = Color.Transparent;
      this.trkMagnify.LargeChange = 1;
      this.trkMagnify.Location = new Point(304, 6);
      this.trkMagnify.Maximum = 5;
      this.trkMagnify.Minimum = 1;
      this.trkMagnify.Name = "trkMagnify";
      this.trkMagnify.Size = new Size(104, 20);
      this.trkMagnify.TabIndex = 8;
      this.trkMagnify.TabStop = true;
      this.trkMagnify.TickStyle = TickStyle.None;
      this.trkMagnify.ToolTipText = "Slide to set the magnification level of the graphic";
      this.trkMagnify.ToolTipTitle = "Image Magnification";
      this.trkMagnify.Value = 1;
      this.trkMagnify.ValueChanged += new EventHandler(this.trkMagnify_ValueChanged);
      this.butCancel.ButtonType = PyxButton.ButtonModeType.Button;
      this.butCancel.Checked = false;
      this.butCancel.FlatStyled = false;
      this.butCancel.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.butCancel.ImageXOffset = 0;
      this.butCancel.ImageYOffset = 0;
      this.butCancel.Location = new Point(572, 552);
      this.butCancel.Name = "butCancel";
      this.butCancel.PushButtonImage = (Bitmap) null;
      this.butCancel.Size = new Size(76, 24);
      this.butCancel.TabIndex = 12;
      this.butCancel.Text = "Cancel";
      this.butCancel.TextXOffset = 0;
      this.butCancel.TextYOffset = 0;
      this.butCancel.ToolTipText = "";
      this.butCancel.ToolTipTitle = "";
      this.butCancel.UseDropShadow = true;
      this.butCancel.UseVisualStyleBackColor = true;
      this.butCancel.Click += new EventHandler(this.butCancel_Click);
      this.butOk.ButtonType = PyxButton.ButtonModeType.Button;
      this.butOk.Checked = false;
      this.butOk.FlatStyled = false;
      this.butOk.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.butOk.ImageXOffset = 0;
      this.butOk.ImageYOffset = 0;
      this.butOk.Location = new Point(492, 552);
      this.butOk.Name = "butOk";
      this.butOk.PushButtonImage = (Bitmap) null;
      this.butOk.Size = new Size(76, 24);
      this.butOk.TabIndex = 11;
      this.butOk.Text = "OK";
      this.butOk.TextXOffset = 0;
      this.butOk.TextYOffset = 0;
      this.butOk.ToolTipText = "";
      this.butOk.ToolTipTitle = "";
      this.butOk.UseDropShadow = true;
      this.butOk.UseVisualStyleBackColor = true;
      this.butOk.Click += new EventHandler(this.butOk_Click);
      this.nudRows.IgnoreHeight = true;
      this.nudRows.Location = new Point(228, 7);
      this.nudRows.Maximum = new Decimal(new int[4]
      {
        9999,
        0,
        0,
        0
      });
      this.nudRows.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.nudRows.Name = "nudRows";
      this.nudRows.Size = new Size(48, 20);
      this.nudRows.TabIndex = 6;
      this.nudRows.ToolTipText = "The height of the tileset in tiles";
      this.nudRows.ToolTipTitle = "Rows";
      this.nudRows.Value = new Decimal(new int[4]
      {
        16,
        0,
        0,
        0
      });
      this.nudRows.ValueChanged += new EventHandler(this.nudSize_ValueChanged);
      this.nudColumns.IgnoreHeight = true;
      this.nudColumns.Location = new Point(136, 7);
      this.nudColumns.Maximum = new Decimal(new int[4]
      {
        9999,
        0,
        0,
        0
      });
      this.nudColumns.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.nudColumns.Name = "nudColumns";
      this.nudColumns.Size = new Size(48, 20);
      this.nudColumns.TabIndex = 4;
      this.nudColumns.ToolTipText = "The width of the tileset in tiles";
      this.nudColumns.ToolTipTitle = "Columns";
      this.nudColumns.Value = new Decimal(new int[4]
      {
        16,
        0,
        0,
        0
      });
      this.nudColumns.ValueChanged += new EventHandler(this.nudSize_ValueChanged);
      this.lblTileX.AutoSize = true;
      this.lblTileX.Location = new Point(84, 10);
      this.lblTileX.Name = "lblTileX";
      this.lblTileX.Size = new Size(50, 13);
      this.lblTileX.TabIndex = 3;
      this.lblTileX.Text = "Columns:";
      this.lblTileY.AutoSize = true;
      this.lblTileY.Location = new Point(188, 10);
      this.lblTileY.Name = "lblTileY";
      this.lblTileY.Size = new Size(37, 13);
      this.lblTileY.TabIndex = 5;
      this.lblTileY.Text = "Rows:";
      this.butGrid.ButtonType = PyxButton.ButtonModeType.PushButton;
      this.butGrid.Checked = true;
      this.butGrid.FlatStyled = false;
      this.butGrid.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.butGrid.Image = (Image) componentResourceManager.GetObject("butGrid.Image");
      this.butGrid.ImageXOffset = 1;
      this.butGrid.ImageYOffset = 0;
      this.butGrid.Location = new Point(56, 4);
      this.butGrid.Name = "butGrid";
      this.butGrid.PushButtonImage = (Bitmap) null;
      this.butGrid.Size = new Size(25, 24);
      this.butGrid.TabIndex = 2;
      this.butGrid.TextXOffset = 0;
      this.butGrid.TextYOffset = 0;
      this.butGrid.ToolTipText = "Show or hide the cell grid";
      this.butGrid.ToolTipTitle = "Show/Hide Grid";
      this.butGrid.UseDropShadow = true;
      this.butGrid.UseVisualStyleBackColor = true;
      this.butGrid.CheckChanged += new PyxButton.CheckChangedEventHandler(this.butShowGrid_CheckChanged);
      this.butRedo.ButtonType = PyxButton.ButtonModeType.Button;
      this.butRedo.Checked = false;
      this.butRedo.FlatStyled = false;
      this.butRedo.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.butRedo.Image = (Image) Resources.arrow_redo;
      this.butRedo.ImageXOffset = 0;
      this.butRedo.ImageYOffset = 0;
      this.butRedo.Location = new Point(32, 4);
      this.butRedo.Name = "butRedo";
      this.butRedo.PushButtonImage = (Bitmap) null;
      this.butRedo.Size = new Size(24, 24);
      this.butRedo.TabIndex = 1;
      this.butRedo.TextXOffset = 0;
      this.butRedo.TextYOffset = 0;
      this.butRedo.ToolTipText = "Redo tile edit";
      this.butRedo.ToolTipTitle = "Redo (Ctrl+Y)";
      this.butRedo.UseDropShadow = true;
      this.butRedo.UseVisualStyleBackColor = true;
      this.butRedo.Click += new EventHandler(this.butRedo_Click);
      this.butUndo.ButtonType = PyxButton.ButtonModeType.Button;
      this.butUndo.Checked = false;
      this.butUndo.FlatStyled = false;
      this.butUndo.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.butUndo.Image = (Image) Resources.arrow_undo;
      this.butUndo.ImageXOffset = 0;
      this.butUndo.ImageYOffset = 0;
      this.butUndo.Location = new Point(8, 4);
      this.butUndo.Name = "butUndo";
      this.butUndo.PushButtonImage = (Bitmap) null;
      this.butUndo.Size = new Size(24, 24);
      this.butUndo.TabIndex = 0;
      this.butUndo.TextXOffset = 0;
      this.butUndo.TextYOffset = 0;
      this.butUndo.ToolTipText = "Undo tile edit";
      this.butUndo.ToolTipTitle = "Undo (Ctrl+Z)";
      this.butUndo.UseDropShadow = true;
      this.butUndo.UseVisualStyleBackColor = true;
      this.butUndo.Click += new EventHandler(this.butUndo_Click);
      this.ssMain.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.lblTileCount,
        (ToolStripItem) this.lblTilesetSize
      });
      this.ssMain.Location = new Point(0, 580);
      this.ssMain.Name = "ssMain";
      this.ssMain.Size = new Size(660, 24);
      this.ssMain.TabIndex = 13;
      this.ssMain.Text = "statusStrip1";
      this.lblTileCount.BorderSides = ToolStripStatusLabelBorderSides.Right;
      this.lblTileCount.Name = "lblTileCount";
      this.lblTileCount.Size = new Size(78, 19);
      this.lblTileCount.Text = "Tile Count: 0";
      this.lblTileCount.TextAlign = ContentAlignment.MiddleLeft;
      this.lblTilesetSize.BorderSides = ToolStripStatusLabelBorderSides.Right;
      this.lblTilesetSize.Name = "lblTilesetSize";
      this.lblTilesetSize.Size = new Size(59, 19);
      this.lblTilesetSize.Text = "Size: N/A";
      this.lblTilesetSize.TextAlign = ContentAlignment.MiddleLeft;
      this.pnlTileset.AllowDrop = true;
      this.pnlTileset.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.pnlTileset.AutoScroll = true;
      this.pnlTileset.AutoScrollMinSize = new Size(640, 512);
      this.pnlTileset.BackColor = Color.White;
      this.pnlTileset.BorderStyle = BorderStyle.Fixed3D;
      this.pnlTileset.CanvasSize = new Size(0, 0);
      this.pnlTileset.CheckerColor = Color.Silver;
      this.pnlTileset.CheckerSize = new Size(16, 16);
      this.pnlTileset.Columns = 16;
      this.pnlTileset.ImageScale = 1;
      this.pnlTileset.Location = new Point(8, 32);
      this.pnlTileset.Name = "pnlTileset";
      this.pnlTileset.Rows = 0;
      this.pnlTileset.ShowGrid = true;
      this.pnlTileset.Size = new Size(644, 516);
      this.pnlTileset.SnapSize = new Size(8, 8);
      this.pnlTileset.TabIndex = 10;
      this.pnlTileset.Tiles = (List<Bitmap>) componentResourceManager.GetObject("pnlTileset.Tiles");
      this.pnlTileset.Title = "Tile Editor";
      this.pnlTileset.ToolTipText = "";
      this.pnlTileset.ToolTipTitle = "";
      this.pnlTileset.UseCheckerBoard = true;
      this.pnlTileset.Zoom = 1f;
      this.pnlTileset.PanelChanged += new GMareTilesetRefactorEditor.PanelChangedHandler(this.pnlTileset_PanelChanged);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(660, 604);
      this.Controls.Add((Control) this.ssMain);
      this.Controls.Add((Control) this.butRedo);
      this.Controls.Add((Control) this.butUndo);
      this.Controls.Add((Control) this.nudRows);
      this.Controls.Add((Control) this.lblTileY);
      this.Controls.Add((Control) this.butGrid);
      this.Controls.Add((Control) this.nudColumns);
      this.Controls.Add((Control) this.lblTileX);
      this.Controls.Add((Control) this.lblMagnify);
      this.Controls.Add((Control) this.pnlMagnify);
      this.Controls.Add((Control) this.trkMagnify);
      this.Controls.Add((Control) this.pnlTileset);
      this.Controls.Add((Control) this.butCancel);
      this.Controls.Add((Control) this.butOk);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "TilesetRefactorForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Tileset Editor";
      this.nudRows.EndInit();
      this.nudColumns.EndInit();
      this.ssMain.ResumeLayout(false);
      this.ssMain.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    protected override bool ProcessDialogKey(Keys keyData)
    {
      if (keyData == (Keys.Z | Keys.Control))
        this.butUndo_Click((object) this.butUndo, EventArgs.Empty);
      else if (keyData == (Keys.Y | Keys.Control))
        this.butRedo_Click((object) this.butRedo, EventArgs.Empty);
      else if (keyData == (Keys.R | Keys.Control))
        this.pnlTileset.ExecuteContextAction(GMareTilesetRefactorEditor.ContextActionType.Deselect);
      switch (keyData)
      {
        case Keys.Delete:
          this.pnlTileset.ExecuteContextAction(GMareTilesetRefactorEditor.ContextActionType.Clear);
          break;
        case Keys.G:
          this.butGrid.Checked = !this.butGrid.Checked;
          break;
      }
      return base.ProcessDialogKey(keyData);
    }

    private void butUndo_Click(object sender, EventArgs e)
    {
      if (this._history.CanUndo)
        this._history.Undo();
      this.butUndo.Enabled = this._history.CanUndo;
      this.butRedo.Enabled = this._history.CanRedo;
    }

    private void butRedo_Click(object sender, EventArgs e)
    {
      if (this._history.CanRedo)
        this._history.Redo();
      this.butUndo.Enabled = this._history.CanUndo;
      this.butRedo.Enabled = this._history.CanRedo;
    }

    private void butShowGrid_CheckChanged(object sender)
    {
      this.pnlTileset.ShowGrid = this.butGrid.Checked;
    }

    private void nudSize_ValueChanged(object sender, EventArgs e)
    {
      if (this.pnlTileset.Tiles != null || this.pnlTileset.Tiles.Count != 0)
        this.PushHistory();
      string name = (sender as PyxNumericUpDown).Name;
      if (this.nudColumns.Name == name)
        this.pnlTileset.Columns = (int) this.nudColumns.Value;
      else if (this.nudRows.Name == name)
        this.pnlTileset.Rows = (int) this.nudRows.Value;
      this.SetStatus();
    }

    private void trkMagnify_ValueChanged(object sender, EventArgs e)
    {
      this.pnlTileset.Zoom = (float) this.trkMagnify.Value;
      this.lblMagnify.Text = (this.trkMagnify.Value * 100).ToString() + "%";
    }

    private void pnlTileset_PanelChanged()
    {
      this.PushHistory();
      this._changed = true;
    }

    private void butOk_Click(object sender, EventArgs e)
    {
      if (this._originalSize.Width != this.pnlTileset.TilesetWidth || this._originalSize.Height != this.pnlTileset.TilesetHeight)
        this._changed = true;
      this._targets = this.pnlTileset.Targets.ToArray();
      this._replacements = this.pnlTileset.Replacements.ToArray();
      this._background.Image = new PixelMap(this.pnlTileset.GetImage(this._background.Offset, this._background.Separation));
      this.DialogResult = DialogResult.OK;
    }

    private void butCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void PopulateTiles(Bitmap tileset)
    {
      List<Bitmap> bitmapList = new List<Bitmap>();
      Size gridSize = App.Room.Backgrounds[0].GetGridSize();
      Size tileSize = App.Room.Backgrounds[0].TileSize;
      Size size = new Size(App.Room.Backgrounds[0].SeparationX, App.Room.Backgrounds[0].SeparationY);
      Point point = new Point(App.Room.Backgrounds[0].OffsetX, App.Room.Backgrounds[0].OffsetY);
      Rectangle rect = new Rectangle(Point.Empty, tileSize);
      this.pnlTileset.Columns = gridSize.Width;
      for (int index1 = 0; index1 < gridSize.Height; ++index1)
      {
        for (int index2 = 0; index2 < gridSize.Width; ++index2)
        {
          rect.X = index2 * tileSize.Width;
          rect.Y = index1 * tileSize.Height;
          Bitmap bitmap = tileset.Clone(rect, tileset.PixelFormat);
          bitmap.Tag = (object) GMareBrush.PositionToSourceTileId(rect.Location.X, rect.Location.Y, tileset.Width, tileSize);
          bitmapList.Add(bitmap);
        }
      }
      this.pnlTileset.SnapSize = tileSize;
      this.pnlTileset.Tiles = bitmapList;
      tileset.Dispose();
    }

    private void PushHistory()
    {
      List<Bitmap> tiles = new List<Bitmap>();
      foreach (Bitmap tile in this.pnlTileset.Tiles)
      {
        if (tile != null)
        {
          Bitmap bitmap = (Bitmap) tile.Clone();
          bitmap.Tag = (object) (int) tile.Tag;
          tiles.Add(bitmap);
        }
        else
          tiles.Add((Bitmap) null);
      }
      TileData data = new TileData(tiles, this.pnlTileset.Columns);
      if (!this._history.InUndoRedo)
        this._history.Do((IMemento<ITilesOwner>) new TilesMemento(data));
      this.butUndo.Enabled = this._history.CanUndo;
      this.butRedo.Enabled = this._history.CanRedo;
    }

    private void SetStatus()
    {
      if (this.pnlTileset.Tiles != null)
      {
        this.lblTileCount.Text = "Tile Count: " + (object) this.pnlTileset.Tiles.Count;
        this.pnlTileset.Zoom = (float) this.trkMagnify.Value;
      }
      ToolStripStatusLabel lblTilesetSize = this.lblTilesetSize;
      string str;
      if (this.pnlTileset.Tiles != null && this.pnlTileset.Tiles.Count != 0)
        str = "Size: " + (object) this.pnlTileset.TilesetWidth + ", " + (object) this.pnlTileset.TilesetHeight;
      else
        str = "Size: N/A";
      lblTilesetSize.Text = str;
    }

    private void SetUI()
    {
      Size gridSize = this._background.GetGridSize();
      this.nudColumns.Value = (Decimal) gridSize.Width;
      this.nudRows.Value = (Decimal) gridSize.Height;
      this.butUndo.Enabled = this._history.CanUndo;
      this.butRedo.Enabled = this._history.CanRedo;
    }
  }
}
