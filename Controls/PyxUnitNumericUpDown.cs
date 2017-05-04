// Decompiled with JetBrains decompiler
// Type: GMare.Controls.PyxUnitNumericUpDown
// Assembly: GMare, Version=1.0.0.18, Culture=neutral, PublicKeyToken=null
// MVID: 2D0D4CCF-F6FC-4E10-8440-03A4A8ADC62E
// Assembly location: C:\Users\r2d2r\Desktop\gmare_beta_118\gmare_beta_118\GMare.exe

using Pyxosoft.Windows.Tools.PyxTools.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace GMare.Controls
{
  public class PyxUnitNumericUpDown : UserControl
  {
    private PyxToolTip _toolTip = new PyxToolTip();
    private string _toolTipText = string.Empty;
    private string _toolTipTitle = string.Empty;
    private string _unitOfMeasure = "Unit";
    private bool _useUnitOfMeasure = true;
    private IContainer components;
    private MaskedTextBox txtMain;
    private PyxNumericUpDown nudMain;
    private Label lblUnit;
    private bool _useNumericPostfix;
    private bool _alreadyFocused;

    [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof (UITypeEditor))]
    public string ToolTipText
    {
      get
      {
        return this._toolTipText;
      }
      set
      {
        this._toolTipText = value;
        this._toolTip.SetToolTip((Control) this, value);
        this._toolTip.SetToolTip((Control) this.nudMain, value);
        this._toolTip.SetToolTip((Control) this.lblUnit, value);
      }
    }

    public string ToolTipTitle
    {
      get
      {
        return this._toolTipTitle;
      }
      set
      {
        this._toolTipTitle = value;
        this._toolTip.ToolTipTitle = value;
      }
    }

    public bool UseNumericPostfix
    {
      get
      {
        return this._useNumericPostfix;
      }
      set
      {
        this._useNumericPostfix = value;
        this.SetPostfix();
      }
    }

    public bool UseUnitOfMeasure
    {
      get
      {
        return this._useUnitOfMeasure;
      }
      set
      {
        this._useUnitOfMeasure = value;
        this.lblUnit.Visible = this._useUnitOfMeasure;
      }
    }

    public string UnitOfMeasure
    {
      get
      {
        return this._unitOfMeasure;
      }
      set
      {
        this._unitOfMeasure = value;
        this.lblUnit.Text = this._unitOfMeasure;
      }
    }

    public string Mask
    {
      get
      {
        return this.txtMain.Mask;
      }
    }

    public Decimal Minimum
    {
      get
      {
        return this.nudMain.Minimum;
      }
      set
      {
        this.nudMain.Minimum = value;
      }
    }

    public Decimal Maximum
    {
      get
      {
        return this.nudMain.Maximum;
      }
      set
      {
        this.nudMain.Maximum = value;
        this.txtMain.MaxLength = this.GetMaxLength();
        this.SetMask();
      }
    }

    public Decimal Increment
    {
      get
      {
        return this.nudMain.Increment;
      }
      set
      {
        this.nudMain.Increment = value;
      }
    }

    public int DecimalPlaces
    {
      get
      {
        return this.nudMain.DecimalPlaces;
      }
      set
      {
        this.nudMain.DecimalPlaces = value;
        this.txtMain.MaxLength = this.GetMaxLength();
        this.SetMask();
      }
    }

    public Decimal Value
    {
      get
      {
        return this.nudMain.Value;
      }
      set
      {
        this.nudMain.Value = value;
        this.UpdateLabel();
      }
    }

    public event PyxUnitNumericUpDown.ValueChangedHandler ValueChanged;

    public PyxUnitNumericUpDown()
    {
      this.InitializeComponent();
      this.txtMain.Text = this.nudMain.Value.ToString();
      this.txtMain.MaxLength = this.txtMain.MaxLength = this.GetMaxLength();
      this.SetMask();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.lblUnit = new Label();
      this.nudMain = new PyxNumericUpDown();
      this.txtMain = new MaskedTextBox();
      this.nudMain.BeginInit();
      this.SuspendLayout();
      this.lblUnit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.lblUnit.BackColor = SystemColors.Window;
      this.lblUnit.Location = new Point(11, 3);
      this.lblUnit.Margin = new Padding(0);
      this.lblUnit.Name = "lblUnit";
      this.lblUnit.Size = new Size(79, 13);
      this.lblUnit.TabIndex = 2;
      this.lblUnit.Text = "Unit";
      this.lblUnit.Click += new EventHandler(this.lblUnit_Click);
      this.nudMain.Anchor = AnchorStyles.Right;
      this.nudMain.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.nudMain.IgnoreHeight = false;
      this.nudMain.Location = new Point(90, 0);
      this.nudMain.Name = "nudMain";
      this.nudMain.Size = new Size(17, 20);
      this.nudMain.TabIndex = 1;
      this.nudMain.TabStop = false;
      this.nudMain.ToolTipText = "";
      this.nudMain.ToolTipTitle = "";
      this.nudMain.ValueChanged += new EventHandler(this.nudMain_ValueChanged);
      this.txtMain.BackColor = SystemColors.Window;
      this.txtMain.Location = new Point(0, 0);
      this.txtMain.Name = "txtMain";
      this.txtMain.Size = new Size(100, 20);
      this.txtMain.TabIndex = 0;
      this.txtMain.TextChanged += new EventHandler(this.txtMain_TextChanged);
      this.txtMain.KeyDown += new KeyEventHandler(this.txtMain_KeyDown);
      this.txtMain.Leave += new EventHandler(this.txtMain_Leave);
      this.txtMain.MouseUp += new MouseEventHandler(this.txtMain_MouseUp);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.Window;
      this.Controls.Add((Control) this.nudMain);
      this.Controls.Add((Control) this.lblUnit);
      this.Controls.Add((Control) this.txtMain);
      this.Name = "PyxUnitNumericUpDown";
      this.Size = new Size(107, 20);
      this.SizeChanged += new EventHandler(this.PyxUnitUpDown_SizeChanged);
      this.Enter += new EventHandler(this.PyxUnitNumericUpDown_Enter);
      this.nudMain.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void PyxUnitUpDown_SizeChanged(object sender, EventArgs e)
    {
      this.UpdateLabel();
    }

    private void PyxUnitNumericUpDown_Enter(object sender, EventArgs e)
    {
      this.txtMain.Focus();
    }

    private void lblUnit_Click(object sender, EventArgs e)
    {
      this.txtMain.Focus();
    }

    private void nudMain_ValueChanged(object sender, EventArgs e)
    {
      this.txtMain.Text = this.nudMain.Value.ToString();
      this.SetPostfix();
      this.OnValueChanged();
    }

    private void txtMain_TextChanged(object sender, EventArgs e)
    {
      this.UpdateLabel();
    }

    private void txtMain_Leave(object sender, EventArgs e)
    {
      this.SetValue();
      this._alreadyFocused = false;
    }

    private void txtMain_MouseUp(object sender, MouseEventArgs e)
    {
      if (this._alreadyFocused || this.txtMain.SelectionLength != 0)
        return;
      this._alreadyFocused = true;
      this.txtMain.SelectAll();
    }

    private void txtMain_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return && e.KeyCode != Keys.Tab)
        return;
      this.SetValue();
    }

    private void UpdateLabel()
    {
      System.Drawing.Graphics graphics = this.CreateGraphics();
      SizeF sizeF = graphics.MeasureString(this.txtMain.Text.ToString(), this.Font);
      graphics.Dispose();
      this.lblUnit.Width = this.ClientSize.Width - (int) sizeF.Width - this.nudMain.Width;
      this.lblUnit.Location = new Point((int) sizeF.Width - 1, this.lblUnit.Location.Y);
    }

    private void SetValue()
    {
      try
      {
        Decimal num = Decimal.Parse(this.txtMain.Text);
        if (num < this.nudMain.Minimum || num > this.nudMain.Maximum)
          this.nudMain_ValueChanged((object) this, EventArgs.Empty);
        else
          this.nudMain.Value = num;
      }
      catch (Exception ex)
      {
        this.nudMain_ValueChanged((object) this, EventArgs.Empty);
      }
    }

    private void SetPostfix()
    {
      if (!this._useNumericPostfix)
        return;
      try
      {
        int index = this.txtMain.Text.Contains(".") ? this.txtMain.Text.IndexOf(".") : this.txtMain.Text.Length - 1;
        int num1 = int.Parse(this.txtMain.Text);
        int num2 = int.Parse(this.txtMain.Text[index].ToString());
        if (num1 >= 11 && num1 <= 13 || num2 == 0 || num2 >= 4 && num2 <= 9)
          this.lblUnit.Text = "th";
        else if (num2 == 1)
          this.lblUnit.Text = "st";
        else if (num2 == 2)
        {
          this.lblUnit.Text = "nd";
        }
        else
        {
          if (num2 != 3)
            return;
          this.lblUnit.Text = "rd";
        }
      }
      catch (Exception ex)
      {
      }
    }

    private int GetMaxLength()
    {
      this.SetMask();
      MaskedTextBox txtMain = this.txtMain;
      int num1 = this.nudMain.Maximum.ToString().Length + this.nudMain.DecimalPlaces;
      int num2 = this.nudMain.DecimalPlaces > 0 ? 1 : 0;
      int num3;
      int num4 = num3 = num1 + num2;
      txtMain.MaxLength = num3;
      return num4;
    }

    private void SetMask()
    {
      string str1 = "";
      for (int index = 0; index < this.nudMain.Maximum.ToString().Length; ++index)
        str1 += "0";
      this.txtMain.Mask = str1;
      if (this.nudMain.DecimalPlaces == 0)
        return;
      string str2 = str1 + ".";
      for (int index = 0; index < this.nudMain.DecimalPlaces; ++index)
        str2 += "9";
      this.txtMain.Mask = str2;
      this.txtMain.Invalidate();
    }

    public void OnValueChanged()
    {
      if (this.ValueChanged == null)
        return;
      this.ValueChanged((object) this, EventArgs.Empty);
    }

    public delegate void ValueChangedHandler(object sender, EventArgs e);
  }
}
