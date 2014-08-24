using System;
using System.Drawing;
using System.Windows.Forms;

namespace NinfiaDSToolkit.Andi.Controls
{
    public class ListControlRenderer : IListControlRenderer
    {
        private static IListControlRenderer ilistControlRenderer_0;

        public static IListControlRenderer DefaultRenderer
        {
            get { return ilistControlRenderer_0 ?? (ilistControlRenderer_0 = new ListControlRenderer()); }
            set { ilistControlRenderer_0 = value; }
        }

        public virtual bool AllowHotTrack
        {
            get { return false; }
        }

        public virtual void Bind(IListControl parent)
        {
        }

        public virtual void DrawItemBackground(IListControl parent, ListControlDrawItemEventArgs e)
        {
            using (
                Brush brush =
                    new SolidBrush(!EnumExtensions.HasFlag(e.State, DrawItemState.HotLight) ||
                                   EnumExtensions.HasFlag(e.State, DrawItemState.Selected) || !AllowHotTrack
                        ? (!parent.Enabled || EnumExtensions.HasFlag(e.State, DrawItemState.Selected)
                            ? (!parent.Enabled ||
                               !parent.IsDroppedDown && parent.HideSelection &&
                               (!EnumExtensions.HasFlag(e.State, DrawItemState.Focus) && parent.FullRowSelect)
                                ? SystemColors.Control
                                : parent.HighlightBackColor)
                            : parent.BackColor)
                        : parent.HotTrackColor))
                e.Graphics.FillRectangle(brush, e.Bounds);
        }

        public virtual void DrawItemImage(IListControl parent, ListControlDrawItemEventArgs e)
        {
            if (e.Image == null)
                return;
            Size size = e.Image.Size;
            e.Graphics.DrawImage(e.Image, e.Bounds.Left + e.Offset, e.Bounds.Top + (e.Bounds.Height - size.Height)/2,
                size.Width, size.Height);
            e.Offset += size.Width + parent.Padding.Left;
        }

        public virtual void DrawItemText(IListControl parent, ListControlDrawItemEventArgs e)
        {
            int num = Math.Max(2, parent.Padding.Right);
            int width = e.Bounds.Width - (e.Offset + num);
            TextFormatFlags flags = GetFlags(parent, e.Item.Text);
            var rectangle = new Rectangle(e.Bounds.X + e.Offset, e.Bounds.Y,
                TextRenderer.MeasureText(e.Graphics, e.Item.Text, e.Font, new Size(width, e.Bounds.Height)).Width + num,
                e.Bounds.Height);
            if (rectangle.Width > width)
                rectangle.Width = width;
            Color foreColor;
            if (EnumExtensions.HasFlag(e.State, DrawItemState.Selected))
            {
                Color color;
                if (!parent.IsDroppedDown && parent.HideSelection &&
                    !EnumExtensions.HasFlag(e.State, DrawItemState.Focus))
                {
                    color = SystemColors.Control;
                    foreColor = parent.ForeColor;
                }
                else
                {
                    color = parent.HighlightBackColor;
                    foreColor = parent.HighlightForeColor;
                }
                if (!parent.FullRowSelect)
                {
                    using (Brush brush = new SolidBrush(color))
                        e.Graphics.FillRectangle(brush, rectangle);
                }
            }
            else
                foreColor = parent.Enabled ? parent.ForeColor : SystemColors.GrayText;
            TextRenderer.DrawText(e.Graphics, e.Item.Text, e.Font, rectangle, foreColor, flags);
            if (!EnumExtensions.HasFlag(e.State, DrawItemState.Focus) ||
                EnumExtensions.HasFlag(e.State, DrawItemState.NoFocusRect))
                return;
            ControlPaint.DrawFocusRectangle(e.Graphics, parent.FullRowSelect ? e.Bounds : rectangle);
        }

        public virtual SizeF MeasureItem(IListControl parent, Graphics g, ImageComboItem item)
        {
            TextFormatFlags flags = GetFlags(parent, item.Text);
            SizeF sizeF1 = TextRenderer.MeasureText(g, item.Text, parent.Font, parent.ClientSize, flags);
            SizeF sizeF2 = item.Image != null ? item.Image.Size : SizeF.Empty;
            if (sizeF1.Height < (double) parent.DefaultItemHeight)
                sizeF1.Height = parent.DefaultItemHeight;
            return new SizeF(Math.Max(sizeF1.Width, sizeF2.Width),
                Math.Max(Math.Max(sizeF1.Height, sizeF2.Height), parent.DefaultItemHeight));
        }

        protected virtual TextFormatFlags GetFlags(IListControl parent, string text)
        {
            TextFormatFlags textFormatFlags1 = TextFormatFlags.NoPrefix | TextFormatFlags.VerticalCenter |
                                               TextFormatFlags.WordEllipsis;
            TextFormatFlags textFormatFlags2;
            if (!parent.WordWrap)
            {
                if (text.IndexOfAny(new char[2]
                {
                    '\n',
                    '\r'
                }) == -1)
                {
                    textFormatFlags2 = textFormatFlags1 | TextFormatFlags.SingleLine;
                    goto label_4;
                }
            }
            textFormatFlags2 = textFormatFlags1 | TextFormatFlags.WordBreak;
            label_4:
            return textFormatFlags2;
        }
    }
}