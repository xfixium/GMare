// Decompiled with JetBrains decompiler
// Type: GMare.Controls.GMareTilesetRefactorEditor
// Assembly: GMare, Version=1.0.0.18, Culture=neutral, PublicKeyToken=null
// MVID: 2D0D4CCF-F6FC-4E10-8440-03A4A8ADC62E
// Assembly location: C:\Users\r2d2r\Desktop\gmare_beta_118\gmare_beta_118\GMare.exe

using GMare.Objects;
using GMare.Properties;
using Pyxosoft.Windows.Tools.PyxTools.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace GMare.Controls
{
  public class GMareTilesetRefactorEditor : PyxCanvas
  {
    private Timer _antsTimer = new Timer();
    private Point _pos = Point.Empty;
    private Size _max = Size.Empty;
    private int _cols = 16;
    private int _rows = 16;
    private bool _showGrid = true;
    private IContainer components;
    private ContextMenuStrip mnuOptions;
    private ToolStripMenuItem mnuDeselect;
    private ToolStripMenuItem mnuClear;
    private List<Bitmap> _tiles;
    private Bitmap _tileSelection;
    private GMareBrush _targets;
    private GMareBrush _swaps;
    private ColorMatrix _matrix;
    private ImageAttributes _atts;
    private float[][] _elements;
    private int _antOffset;
    private bool _dragging;
    private bool _moving;
    private int _originalCols;

    public List<Bitmap> Tiles
    {
      get
      {
        List<Bitmap> bitmapList = new List<Bitmap>();
        for (int index1 = 0; index1 < this._rows; ++index1)
        {
          for (int index2 = 0; index2 < this._cols; ++index2)
            bitmapList.Add(this._tiles[index2 + index1 * this._cols]);
        }
        return bitmapList;
      }
      set
      {
        this._tiles = value;
        if (this._targets != null)
          this._targets = (GMareBrush) null;
        this._rows = this._tiles == null || this._tiles.Count == 0 ? 0 : (int) Math.Ceiling((double) this._tiles.Count / (double) this._cols);
        this.CanvasSize = this._tiles == null || this._tiles.Count == 0 ? Size.Empty : new Size(this.TilesetWidth, this.TilesetHeight);
        this._max.Width = this._cols;
        this._max.Height = this._rows;
        this._originalCols = this._cols;
      }
    }

    public List<int> Replacements
    {
      get
      {
        List<int> intList = new List<int>();
        if (this._cols < this._max.Width)
        {
          List<Bitmap> shortList = this.GetShortList();
          int width = this._max.Width;
          int num = this.TilesetWidth / this.SnapSize.Width;
          for (int index = 0; index < shortList.Count; ++index)
          {
            int tag = (int) shortList[index].Tag;
            intList.Add(index);
          }
        }
        else
        {
          for (int index = 0; index < this._tiles.Count; ++index)
          {
            if (this._tiles[index] != null)
              intList.Add(index);
          }
        }
        return intList;
      }
    }

    public List<int> Targets
    {
      get
      {
        List<int> intList = new List<int>();
        if (this._cols < this._max.Width)
        {
          int num1 = this._cols;
          int num2 = this._cols + (this._max.Width - this._cols);
          int num3 = this._cols;
          int num4 = this._max.Width - this._cols;
          int num5 = this._max.Width <= this._originalCols || this._cols >= this._originalCols ? 0 : this._max.Width - this._originalCols;
          int num6 = 0;
          for (int index = 0; index < this._tiles.Count; ++index)
          {
            if (index != 0 && index % num3 == 0)
            {
              num1 = index;
              num2 = index + this._max.Width - this._cols - 1;
              num3 = index + this._cols + num4;
              num6 += num5;
            }
            if (index > num2 || index < num1)
            {
              intList.Add(num5 != 0 ? num6 : index);
              ++num6;
            }
          }
        }
        else
        {
          for (int index = 0; index < this._tiles.Count; ++index)
          {
            if (this._tiles[index] != null && this._tiles[index].Tag != null)
              intList.Add((int) this._tiles[index].Tag);
          }
        }
        return intList;
      }
    }

    public int Columns
    {
      get
      {
        return this._cols;
      }
      set
      {
        this._cols = value;
        if (this._targets != null)
          this._targets = (GMareBrush) null;
        if (this._tiles != null && this._cols > this._max.Width)
        {
          this.ResetSelection();
          for (int index = 0; index < this._tiles.Count; ++index)
          {
            if (index != 0 && index % this._cols == 0)
              this._tiles.Insert(index - 1, this.GetEmptyTile(this._tiles.Count));
          }
          this._tiles.Add(this.GetEmptyTile(this._tiles.Count));
          this._max.Width = this._cols;
        }
        this.CanvasSize = this._tiles == null || this._tiles.Count == 0 ? Size.Empty : new Size(this.TilesetWidth, this.TilesetHeight);
      }
    }

    public int Rows
    {
      get
      {
        return this._rows;
      }
      set
      {
        this._rows = value;
        if (this._targets != null)
          this._targets = (GMareBrush) null;
        if (this._tiles != null && this._rows > this._max.Height)
        {
          for (int index = 0; index < this._cols + 1; ++index)
          {
            Bitmap bitmap = new Bitmap(this.SnapSize.Width, this.SnapSize.Height);
            bitmap.Tag = (object) this._tiles.Count;
            this._tiles.Add(bitmap);
          }
          this._max.Height = this._rows;
        }
        this.CanvasSize = this._tiles == null || this._tiles.Count == 0 ? Size.Empty : new Size(this.TilesetWidth, this.TilesetHeight);
      }
    }

    public int TilesetWidth
    {
      get
      {
        return this._cols * this.SnapSize.Width;
      }
    }

    public int TilesetHeight
    {
      get
      {
        return this._rows * this.SnapSize.Height;
      }
    }

    public bool ShowGrid
    {
      get
      {
        return this._showGrid;
      }
      set
      {
        this._showGrid = value;
        this.UpdateBackBuffer();
      }
    }

    public int MaxCols
    {
      get
      {
        return this._max.Width;
      }
    }

    public event GMareTilesetRefactorEditor.PanelChangedHandler PanelChanged;

    public GMareTilesetRefactorEditor()
    {
      this.InitializeComponent();
      this._elements = new float[5][]
      {
        new float[5]{ -1f, 0.0f, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, -1f, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, -1f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, 1f, 0.0f },
        new float[5]{ 1f, 1f, 1f, 0.0f, 1f }
      };
      this._matrix = new ColorMatrix(this._elements);
      this._atts = new ImageAttributes();
      this._atts.SetColorMatrix(this._matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
      this.UpdateBackBuffer();
      this._antsTimer.Interval = 100;
      this._antsTimer.Tick += new EventHandler(this.Timer_Tick);
      this._antsTimer.Start();
      this.mnuClear.Click += new EventHandler(this.mnuClear_Click);
      this.mnuDeselect.Click += new EventHandler(this.mnuDeselect_Click);
    }

    protected override void Dispose(bool disposing)
    {
      if (this._tiles != null)
      {
        foreach (Bitmap tile in this._tiles)
        {
          if (tile != null)
            tile.Dispose();
        }
      }
      if (this._tileSelection != null)
        this._tileSelection.Dispose();
      if (this._atts != null)
        this._atts.Dispose();
      if (this._antsTimer != null)
        this._antsTimer.Dispose();
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.mnuOptions = new ContextMenuStrip(this.components);
      this.mnuDeselect = new ToolStripMenuItem();
      this.mnuClear = new ToolStripMenuItem();
      this.mnuOptions.SuspendLayout();
      this.SuspendLayout();
      this.mnuOptions.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.mnuDeselect,
        (ToolStripItem) this.mnuClear
      });
      this.mnuOptions.Name = "contextMenuStrip1";
      this.mnuOptions.Size = new Size(161, 48);
      this.mnuDeselect.Image = (Image) Resources.selection_empty;
      this.mnuDeselect.Name = "mnuDeselect";
      this.mnuDeselect.ShortcutKeys = Keys.R | Keys.Control;
      this.mnuDeselect.Size = new Size(160, 22);
      this.mnuDeselect.Text = "Deselect";
      this.mnuClear.Image = (Image) Resources.layer_empty;
      this.mnuClear.Name = "mnuClear";
      this.mnuClear.ShortcutKeys = Keys.Delete;
      this.mnuClear.Size = new Size(160, 22);
      this.mnuClear.Text = "Clear Tile(s)";
      this.mnuOptions.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private List<Bitmap> GetShortList()
    {
      List<Bitmap> bitmapList = new List<Bitmap>();
      int num1 = this._cols;
      int num2 = this._cols + (this._max.Width - this._cols);
      int num3 = this._cols;
      int num4 = this._max.Width - this._cols;
      for (int index = 0; index < this._tiles.Count; ++index)
      {
        if (index != 0 && index % num3 == 0)
        {
          num1 = index;
          num2 = index + this._max.Width - this._cols - 1;
          num3 = index + this._cols + num4;
        }
        if (index > num2 || index < num1)
          bitmapList.Add(this._tiles[index]);
      }
      return bitmapList;
    }

    private void mnuDeselect_Click(object sender, EventArgs e)
    {
      this.ResetSelection();
    }

    private void mnuClear_Click(object sender, EventArgs e)
    {
      if (this._targets == null)
        return;
      this.PanelChanged();
      foreach (int index in this._targets.ToArray())
      {
        if (this._tiles[index] != null)
        {
          Bitmap bitmap = new Bitmap(this._tiles[index].Width, this._tiles[index].Height);
          bitmap.Tag = (object) (int) this._tiles[index].Tag;
          this._tiles[index].Dispose();
          this._tiles[index] = bitmap;
        }
      }
      this.ResetSelection();
      this.UpdateBackBuffer();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      ++this._antOffset;
      if (this._antOffset % 8 == 0)
        this._antOffset = 0;
      if (this._targets == null)
        return;
      this.Invalidate();
    }

    protected override void OnDrawAfterOnPaint(ref PaintEventArgs e)
    {
      if (this._targets == null)
        return;
      Point point = new Point(-this.AutoScrollPosition.X, -this.AutoScrollPosition.Y);
      Rectangle targetRectangle = this._targets.ToTargetRectangle();
      targetRectangle.X -= (int) ((double) point.X / (double) this.Zoom);
      targetRectangle.Y -= (int) ((double) point.Y / (double) this.Zoom);
      this.DrawSelection(e.Graphics, targetRectangle);
    }

    protected override void OnDrawOnBackbuffer(ref System.Drawing.Graphics gfx)
    {
      if (this._tiles == null)
        return;
      this.DrawTiles(gfx);
      if (!this._showGrid)
        return;
      this.DrawGrid(gfx);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      if (this.BackBuffer == null || this._tiles == null || this._tiles.Count == 0)
        return;
      this.Focus();
      Point snappedPoint = this.GetSnappedPoint(e.Location);
      if (!new Rectangle(0, 0, this.TilesetWidth, this.TilesetHeight).Contains(snappedPoint))
        return;
      if (e.Button == MouseButtons.Left && this._tiles != null)
      {
        if (this._targets != null && this._targets.ToTargetRectangle().Contains(snappedPoint))
        {
          this._moving = true;
          this._pos.X = snappedPoint.X;
          this._pos.Y = snappedPoint.Y;
        }
        if (!this._moving)
        {
          if (this._tileSelection != null)
          {
            this._tileSelection.Dispose();
            this._tileSelection = (Bitmap) null;
          }
          this._targets = new GMareBrush();
          this._dragging = true;
          this._targets.StartX = snappedPoint.X;
          this._targets.StartY = snappedPoint.Y;
          this._targets.EndX = this._targets.StartX + this.SnapSize.Width;
          this._targets.EndY = this._targets.StartY + this.SnapSize.Height;
        }
      }
      if (e.Button == MouseButtons.Right)
      {
        if (this._targets == null || !this._targets.ToTargetRectangle().Contains(snappedPoint))
          return;
        this.mnuOptions.Show(this.PointToScreen(e.Location));
      }
      this.Invalidate();
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      Point snappedPoint = this.GetSnappedPoint(e.Location);
      if (this._targets != null && (this._targets.ToTargetRectangle().Contains(snappedPoint) && !this._dragging))
        this.Cursor = this.Cursor == Cursors.SizeAll ? this.Cursor : Cursors.SizeAll;
      else
        this.Cursor = this.Cursor == Cursors.Arrow ? this.Cursor : Cursors.Arrow;
      if (this.BackBuffer == null || this._tiles == null || this._tiles.Count == 0)
        return;
      if (this._moving && (snappedPoint.X != this._pos.X || snappedPoint.Y != this._pos.Y))
      {
        Point point = new Point(snappedPoint.X - this._pos.X, snappedPoint.Y - this._pos.Y);
        this._pos.X = snappedPoint.X;
        this._pos.Y = snappedPoint.Y;
        this._targets.StartX += point.X;
        this._targets.StartY += point.Y;
        this._targets.EndX += point.X;
        this._targets.EndY += point.Y;
        this.Invalidate();
      }
      if (!this._dragging || !new Rectangle(0, 0, this.TilesetWidth, this.TilesetHeight).Contains(snappedPoint))
        return;
      if (snappedPoint.X >= this._targets.StartX)
        snappedPoint.X += this.SnapSize.Width;
      if (snappedPoint.Y >= this._targets.StartY)
        snappedPoint.Y += this.SnapSize.Height;
      if (snappedPoint.X == this._targets.EndX && snappedPoint.Y == this._targets.EndY)
        return;
      if (snappedPoint.X != this._targets.StartX)
        this._targets.EndX = snappedPoint.X;
      if (snappedPoint.Y != this._targets.StartY)
        this._targets.EndY = snappedPoint.Y;
      this.Invalidate();
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);
      if (this.BackBuffer == null || this._tiles == null || this._tiles.Count == 0)
        return;
      int width = this._cols < this._originalCols ? this._max.Width * this.SnapSize.Width : this.TilesetWidth;
      if (this._dragging && this._targets != null)
      {
        this._dragging = false;
        this._targets.Tiles = GMareBrush.RectangleToTiles(this._targets.ToTargetRectangle(), width, this.SnapSize);
        foreach (int num in this._targets.ToArray())
        {
          if (num < 0 || num >= this._tiles.Count)
          {
            this.ResetSelection();
            return;
          }
        }
        this._tileSelection = this.GetImage().Clone(this._targets.ToTargetRectangle(), PixelFormat.Format32bppArgb);
        this._swaps = this._targets.Clone();
      }
      if (!this._moving || this._targets == null)
        return;
      this._moving = false;
      if (!new Rectangle(0, 0, this.TilesetWidth, this.TilesetHeight).Contains(this._targets.ToTargetRectangle()))
      {
        this._targets = this._swaps;
        this._swaps = (GMareBrush) null;
        this.Invalidate();
      }
      else
      {
        this._targets.Tiles = GMareBrush.RectangleToTiles(this._targets.ToTargetRectangle(), width, this.SnapSize);
        foreach (int num in this._targets.ToArray())
        {
          if (num < 0 || num >= this._tiles.Count)
          {
            this._targets = this._swaps;
            this._swaps = (GMareBrush) null;
            this.Invalidate();
            return;
          }
        }
        this.SwapTiles(false);
      }
    }

    public void ExecuteContextAction(GMareTilesetRefactorEditor.ContextActionType type)
    {
      if (this._targets == null || !this._targets.ToTargetRectangle().Contains(this.GetSnappedPoint(this.PointToClient(Cursor.Position))))
        return;
      switch (type)
      {
        case GMareTilesetRefactorEditor.ContextActionType.Deselect:
          this.mnuDeselect_Click((object) this.mnuDeselect, EventArgs.Empty);
          break;
        case GMareTilesetRefactorEditor.ContextActionType.Clear:
          this.mnuClear_Click((object) this.mnuClear, EventArgs.Empty);
          break;
      }
    }

    private void DrawTiles(System.Drawing.Graphics gfx)
    {
      int index1 = 0;
      int width = this._max.Width;
      int num = this._rows <= this._max.Height ? this._rows : this._max.Height;
      Point empty = Point.Empty;
      for (int index2 = 0; index2 < num; ++index2)
      {
        for (int index3 = 0; index3 < width; ++index3)
        {
          if (index1 < this._tiles.Count && this._tiles[index1] != null)
            gfx.DrawImageUnscaled((Image) this._tiles[index1], index3 * this.SnapSize.Width, index2 * this.SnapSize.Height);
          empty.X = index3 * this.SnapSize.Width;
          empty.Y = index2 * this.SnapSize.Height;
          gfx.DrawString(this._tiles[index1].Tag.ToString(), this.Font, Brushes.Black, (float) (empty.X - 1), (float) empty.Y);
          gfx.DrawString(this._tiles[index1].Tag.ToString(), this.Font, Brushes.Black, (float) empty.X, (float) (empty.Y - 1));
          gfx.DrawString(this._tiles[index1].Tag.ToString(), this.Font, Brushes.Black, (float) (empty.X + 1), (float) empty.Y);
          gfx.DrawString(this._tiles[index1].Tag.ToString(), this.Font, Brushes.Black, (float) empty.X, (float) (empty.Y + 1));
          gfx.DrawString(this._tiles[index1].Tag.ToString(), this.Font, Brushes.Yellow, (PointF) empty);
          ++index1;
        }
      }
    }

    private void DrawGrid(System.Drawing.Graphics gfx)
    {
      GraphicsState gstate = gfx.Save();
      Pen pen = new Pen(Color.Red);
      Rectangle destRect = new Rectangle(0, 0, this.BackBuffer.Width, this.BackBuffer.Height);
      GraphicsPath path = new GraphicsPath(FillMode.Alternate);
      for (int index1 = 0; index1 < this._rows; ++index1)
      {
        for (int index2 = 0; index2 < this._cols; ++index2)
        {
          int x = index2 * this.SnapSize.Width;
          int y = index1 * this.SnapSize.Height;
          path.AddRectangle(new Rectangle(x, y, this.SnapSize.Width, this.SnapSize.Height));
        }
      }
      path.Widen(pen);
      Region region = new Region(path);
      gfx.Clip = region;
      gfx.DrawImage((Image) this.BackBuffer, destRect, 0, 0, destRect.Width, destRect.Height, GraphicsUnit.Pixel, this._atts);
      gfx.Restore(gstate);
      region.Dispose();
      pen.Dispose();
    }

    private void DrawSelection(System.Drawing.Graphics gfx, Rectangle rect)
    {
      Pen pen = new Pen(Color.White, 1f);
      pen.DashStyle = DashStyle.Dash;
      pen.DashPattern = new float[2]{ 4f, 4f };
      pen.DashOffset = (float) this._antOffset;
      ++rect.X;
      ++rect.Y;
      if (this._tileSelection != null)
        gfx.DrawImage((Image) this._tileSelection, rect.Location);
      gfx.DrawRectangle(Pens.Black, rect);
      gfx.DrawRectangle(pen, rect);
      pen.Dispose();
    }

    private void SwapTiles(bool ignoreUpdate)
    {
      if (this._targets == null || this._swaps == null)
        return;
      int[] array1 = this._targets.ToArray();
      int[] array2 = this._swaps.ToArray();
      if (array2[0] == array1[0])
        return;
      int num1 = 0;
      int num2 = 1;
      int num3 = array1.Length;
      if (array2[0] < array1[0])
      {
        num2 = -1;
        num3 = -1;
        num1 = array1.Length - 1;
      }
      if (!ignoreUpdate && this.PanelChanged != null)
        this.PanelChanged();
      int index = num1;
      while (index != num3)
      {
        Bitmap bitmap1 = (Bitmap) null;
        Bitmap bitmap2 = (Bitmap) null;
        int num4 = array1[index];
        int num5 = array2[index];
        if (this._tiles[array2[index]] != null)
        {
          bitmap2 = (Bitmap) this._tiles[array2[index]].Clone();
          bitmap2.Tag = (object) (int) this._tiles[array2[index]].Tag;
          this._tiles[array2[index]].Dispose();
        }
        if (this._tiles[array1[index]] != null)
        {
          bitmap1 = (Bitmap) this._tiles[array1[index]].Clone();
          bitmap1.Tag = (object) (int) this._tiles[array1[index]].Tag;
          this._tiles[array1[index]].Dispose();
        }
        this._tiles[array1[index]] = bitmap2;
        this._tiles[array2[index]] = bitmap1;
        index += num2;
      }
      this.ResetSelection();
      if (ignoreUpdate)
        return;
      this.UpdateBackBuffer();
    }

    public Bitmap GetImage()
    {
      if (this._tiles == null)
        return (Bitmap) null;
      Bitmap bitmap = new Bitmap(this.TilesetWidth, this.TilesetHeight, PixelFormat.Format32bppArgb);
      this.DrawTiles(System.Drawing.Graphics.FromImage((Image) bitmap));
      return bitmap;
    }

    public Bitmap GetImage(Point offset, Size separation)
    {
      if (this._tiles == null)
        return (Bitmap) null;
      Bitmap bitmap = new Bitmap(this.TilesetWidth + separation.Width * this._cols + offset.X, this.TilesetHeight + separation.Height * this._rows + offset.Y, PixelFormat.Format32bppArgb);
            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage((Image) bitmap);
      int index1 = 0;
      int width = this._max.Width;
      int num1 = this._rows <= this._max.Height ? this._rows : this._max.Height;
      Rectangle empty = Rectangle.Empty;
      Point point = Point.Empty;
      for (int index2 = 0; index2 < num1; ++index2)
      {
        for (int index3 = 0; index3 < width; ++index3)
        {
          point = new Point(index3 * this.SnapSize.Width, index2 * this.SnapSize.Height);
          int num2 = index3 * separation.Width + offset.X;
          int num3 = index2 * separation.Height + offset.Y;
          Rectangle rectangle = new Rectangle(point.X + index3 * separation.Width, point.Y + index2 * separation.Height, this.SnapSize.Width + separation.Width, this.SnapSize.Height + separation.Height);
          if (index1 < this._tiles.Count && this._tiles[index1] != null)
            graphics.DrawImageUnscaled((Image) this._tiles[index1], point.X + num2, point.Y + num3);
          ++index1;
        }
      }
      return bitmap;
    }

    private void ResetSelection()
    {
      this._targets = (GMareBrush) null;
      this._swaps = (GMareBrush) null;
      if (this._tileSelection != null)
      {
        this._tileSelection.Dispose();
        this._tileSelection = (Bitmap) null;
      }
      this.Invalidate();
    }

    private Bitmap GetEmptyTile(int id)
    {
      Bitmap bitmap = new Bitmap(this.SnapSize.Width, this.SnapSize.Height);
      bitmap.Tag = (object) id;
      return bitmap;
    }

    public enum ContextActionType
    {
      Deselect,
      Clear,
    }

    public delegate void PanelChangedHandler();
  }
}
