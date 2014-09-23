using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Andi.Controls
{
    [ToolboxItem(true)]
    [DefaultProperty("Text")]
    [Designer(
        "System.Windows.Forms.Design.DocumentDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
        typeof (IRootDesigner))]
    [DefaultEvent("Click")]
    [Designer(
        "System.Windows.Forms.Design.GroupBoxDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
        )]
    public class AndiGroupBox : System.Windows.Forms.GroupBox
    {
        private bool bool_0;
        private bool bool_1;
        private bool bool_2;
        private bool bool_3;
        private Border3DSide border3DSide_0 = Border3DSide.Top;
        private Color color_0;
        private Color color_1;
        private Color color_2;
        private Image image_0;
        private Pen pen_0;
        private Pen pen_1;
        private Size size_0;

        public AndiGroupBox()
        {
            bool_2 = true;
            size_0 = new Size(0, 6);
            color_1 = SystemColors.ButtonHighlight;
            color_2 = SystemColors.ButtonShadow;
            color_0 = SystemColors.HotTrack;
            DisableControlsWithCheckBox = true;
            SetStyle(
                ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor |
                ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            method_2();
        }

        public override Rectangle DisplayRectangle
        {
            get
            {
                Size clientSize = ClientSize;
                int num = CheckBox == null ? Font.Height : CheckBox.Height;
                int x = (image_0 == null ? 0 : size_0.Width + image_0.Width + 3) + 3;
                int y = num + 3;
                return new Rectangle(x, y, Math.Max(clientSize.Width - (x + 3), 0),
                    Math.Max(clientSize.Height - (y + 3), 0));
            }
        }

        [DefaultValue("")]
        [Browsable(true)]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof (Border3DSide), "Top")]
        public Border3DSide Borders
        {
            get { return border3DSide_0; }
            set
            {
                border3DSide_0 = value;
                Invalidate();
            }
        }

        [DefaultValue(false)]
        [Category("Appearance")]
        public virtual bool Checked
        {
            get { return bool_0; }
            set
            {
                if (Checked == value)
                    return;
                bool_0 = value;
                OnCheckedChanged(EventArgs.Empty);
            }
        }

        [DefaultValue(true)]
        [Category("Behavior")]
        public virtual bool DisableControlsWithCheckBox
        {
            get { return bool_1; }
            set
            {
                if (DisableControlsWithCheckBox == value)
                    return;
                bool_1 = value;
                OnDisableControlsWithCheckBoxChanged(EventArgs.Empty);
            }
        }

        [DefaultValue(typeof (Color), "HotTrack")]
        [Category("Appearance")]
        public virtual Color HeaderForeColor
        {
            get { return color_0; }
            set
            {
                if (!(HeaderForeColor != value))
                    return;
                color_0 = value;
                OnHeaderForeColorChanged(EventArgs.Empty);
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof (Size), "0, 6")]
        public Size IconMargin
        {
            get { return size_0; }
            set
            {
                size_0 = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Browsable(true)]
        [DefaultValue(typeof (Image), "")]
        public Image Image
        {
            get { return image_0; }
            set
            {
                image_0 = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof (Color), "ButtonHighlight")]
        [Browsable(true)]
        public Color LineColorBottom
        {
            get { return color_1; }
            set
            {
                color_1 = value;
                method_2();
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Browsable(true)]
        [DefaultValue(typeof (Color), "ButtonShadow")]
        public Color LineColorTop
        {
            get { return color_2; }
            set
            {
                color_2 = value;
                method_2();
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool ShowBorders
        {
            get { return bool_2; }
            set
            {
                bool_2 = value;
                Invalidate();
            }
        }

        [DefaultValue(false)]
        [Category("Behavior")]
        public virtual bool ShowCheckBox
        {
            get { return bool_3; }
            set
            {
                if (ShowCheckBox == value)
                    return;
                bool_3 = value;
                OnShowCheckBoxChanged(EventArgs.Empty);
            }
        }

        protected CheckBox CheckBox { get; set; }

        protected virtual TextFormatFlags Flags
        {
            get { return TextFormatFlags.NoPrefix | TextFormatFlags.SingleLine | TextFormatFlags.WordEllipsis; }
        }

        [Category("Property Changed")]
        public event EventHandler CheckedChanged;

        [Category("Property Changed")]
        public event EventHandler DisableControlsWithCheckBoxChanged;

        [Category("Property Changed")]
        public event EventHandler HeaderForeColorChanged;

        [Category("Property Changed")]
        public event EventHandler ShowCheckBoxChanged;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                method_0();
            base.Dispose(disposing);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            if (CheckBox != null)
            {
                CheckBox.Font = Font;
                method_3();
            }
            base.OnFontChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            TextFormatFlags flags = Flags;
            SizeF sizeF = CheckBox == null
                ? TextRenderer.MeasureText(e.Graphics, Text, Font, ClientSize, flags)
                : CheckBox.Size;
            int num = (int) (sizeF.Height + 3.0)/2;
            if (ShowBorders)
            {
                if ((border3DSide_0 & Border3DSide.All) == Border3DSide.All)
                {
                    e.Graphics.DrawRectangle(pen_0, 1, num + 1, Width - 2, Height - (num + 2));
                    e.Graphics.DrawRectangle(pen_1, 0, num, Width - 2, Height - (num + 2));
                }
                else
                {
                    if ((border3DSide_0 & Border3DSide.Top) == Border3DSide.Top)
                    {
                        e.Graphics.DrawLine(pen_1, sizeF.Width + 3f, num, Width - 5, num);
                        e.Graphics.DrawLine(pen_0, sizeF.Width + 3f, num + 1, Width - 5, num + 1);
                    }
                    if ((border3DSide_0 & Border3DSide.Left) == Border3DSide.Left)
                    {
                        e.Graphics.DrawLine(pen_1, 0, num, 0, Height - 1);
                        e.Graphics.DrawLine(pen_0, 1, num, 1, Height - 1);
                    }
                    if ((border3DSide_0 & Border3DSide.Right) == Border3DSide.Right)
                    {
                        e.Graphics.DrawLine(pen_0, Width - 1, num, Width - 1, Height - 1);
                        e.Graphics.DrawLine(pen_1, Width - 2, num, Width - 2, Height - 1);
                    }
                    if ((border3DSide_0 & Border3DSide.Bottom) == Border3DSide.Bottom)
                    {
                        e.Graphics.DrawLine(pen_1, 0, Height - 2, Width, Height - 2);
                        e.Graphics.DrawLine(pen_0, 0, Height - 1, Width, Height - 1);
                    }
                }
            }
            if (CheckBox == null)
            {
                var bounds = new Rectangle(1, 1, (int) sizeF.Width, (int) sizeF.Height);
                TextRenderer.DrawText(e.Graphics, Text, Font, bounds, HeaderForeColor, flags);
            }
            if (image_0 != null)
                e.Graphics.DrawImage(image_0, Padding.Left + size_0.Width,
                    Padding.Top + (int) sizeF.Height + size_0.Height, image_0.Width, image_0.Height);
            if (!this.IsDesignTime() || (border3DSide_0 & Border3DSide.All) == Border3DSide.All)
                return;
            using (var pen = new Pen(SystemColors.ButtonShadow)
            {
                DashStyle = DashStyle.Dot
            })
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
        }

        protected override void OnSystemColorsChanged(EventArgs e)
        {
            base.OnSystemColorsChanged(e);
            method_2();
            Invalidate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (CheckBox != null)
            {
                CheckBox.Text = Text;
                method_3();
            }
            base.OnTextChanged(e);
        }

        protected virtual void OnCheckedChanged(EventArgs e)
        {
            if (CheckBox != null)
                CheckBox.Checked = Checked;
            method_4();
            EventHandler eventHandler = CheckedChanged;
            if (eventHandler == null)
                return;
            eventHandler(this, e);
        }

        protected virtual void OnDisableControlsWithCheckBoxChanged(EventArgs e)
        {
            EventHandler eventHandler = DisableControlsWithCheckBoxChanged;
            if (eventHandler == null)
                return;
            eventHandler(this, e);
        }

        protected virtual void OnHeaderForeColorChanged(EventArgs e)
        {
            if (CheckBox != null)
                CheckBox.ForeColor = HeaderForeColor;
            method_2();
            Invalidate();
            EventHandler eventHandler = HeaderForeColorChanged;
            if (eventHandler == null)
                return;
            eventHandler(this, e);
        }

        protected virtual void OnShowCheckBoxChanged(EventArgs e)
        {
            method_1();
            Invalidate();
            EventHandler eventHandler = ShowCheckBoxChanged;
            if (eventHandler == null)
                return;
            eventHandler(this, e);
        }

        private void method_0()
        {
            if (pen_1 != null)
                pen_1.Dispose();
            if (pen_0 == null)
                return;
            pen_0.Dispose();
        }

        private void method_1()
        {
            if (ShowCheckBox && CheckBox == null)
            {
                AndiGroupBox groupBox = this;
                var checkBox1 = new CheckBox();
                checkBox1.Text = Text;
                checkBox1.Font = Font;
                checkBox1.ForeColor = HeaderForeColor;
                checkBox1.Checked = Checked;
                checkBox1.TabIndex = 0;
                CheckBox checkBox2 = checkBox1;
                groupBox.CheckBox = checkBox2;
                CheckBox.CheckedChanged += method_5;
                method_3();
                method_4();
                Controls.Add(CheckBox);
                Controls.SetChildIndex(CheckBox, 0);
            }
            else
            {
                if (ShowCheckBox || CheckBox == null)
                    return;
                Controls.Remove(CheckBox);
                CheckBox = null;
            }
        }

        private void method_2()
        {
            method_0();
            pen_1 = new Pen(color_2);
            pen_0 = new Pen(color_1);
        }

        private void method_3()
        {
            SizeF sizeF;
            using (Graphics graphics = Graphics.FromHwnd(Handle))
                sizeF = TextRenderer.MeasureText(graphics, Text, Font, ClientSize, Flags);
            CheckBox.Width = (int) sizeF.Width + SystemInformation.MenuCheckSize.Width;
        }

        private void method_4()
        {
            if (this.IsDesignTime() || !DisableControlsWithCheckBox)
                return;
            foreach (Control control in Controls.Cast<Control>().Where(control_0 => control_0 != CheckBox))
                control.Enabled = Checked;
        }

        private void method_5(object sender, EventArgs e)
        {
            Checked = CheckBox.Checked;
        }
    }
}