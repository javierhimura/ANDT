using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NinfiaDSToolkit.Andi.Controls
{
    public class AndiListBox : System.Windows.Forms.ListBox, IListControl
    {
        private bool bool_0;
        private bool bool_1;
        private bool bool_2;
        private Color color_0;
        private Color color_1;
        private Color color_2;
        private IListControlRenderer ilistControlRenderer_0;
        private ImageList imageList_0;
        private int int_0;

        public AndiListBox()
        {
            HoverIndex = -1;
            HideSelection = true;
            DrawMode = DrawMode.OwnerDrawVariable;
            IntegralHeight = false;
            FullRowSelect = true;
            WordWrap = true;
            Padding = new Padding(2);
            DoubleBuffered = true;
            HotTrackColor = SystemColors.Highlight;
            HighlightBackColor = SystemColors.Highlight;
            HighlightForeColor = SystemColors.HighlightText;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new DrawMode DrawMode
        {
            get { return base.DrawMode; }
            set { base.DrawMode = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual int HoverIndex
        {
            get { return int_0; }
            set
            {
                if (HoverIndex == value)
                    return;
                if (HoverIndex != -1)
                    InvalidateItem(HoverIndex);
                int_0 = value;
                if (value != -1)
                    InvalidateItem(HoverIndex);
                OnHoverIndexChanged(EventArgs.Empty);
            }
        }

        [DefaultValue(false)]
        public new bool IntegralHeight
        {
            get { return base.IntegralHeight; }
            set { base.IntegralHeight = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [Category("Behavior")]
        public virtual IListControlRenderer Renderer
        {
            get { return ilistControlRenderer_0; }
            set
            {
                if (Renderer == value)
                    return;
                ilistControlRenderer_0 = value;
                OnRendererChanged(EventArgs.Empty);
            }
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        public virtual bool FullRowSelect
        {
            get { return bool_0; }
            set
            {
                if (FullRowSelect == value)
                    return;
                bool_0 = value;
                OnFullRowSelectChanged(EventArgs.Empty);
            }
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        public virtual bool HideSelection
        {
            get { return bool_1; }
            set
            {
                if (HideSelection == value)
                    return;
                bool_1 = value;
                OnHideSelectionChanged(EventArgs.Empty);
            }
        }

        [DefaultValue(typeof (Color), "Highlight")]
        [Category("Appearance")]
        public virtual Color HighlightBackColor
        {
            get { return color_0; }
            set
            {
                if (!(HighlightBackColor != value))
                    return;
                color_0 = value;
                OnHighlightBackColorChanged(EventArgs.Empty);
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof (Color), "HighlightText")]
        public virtual Color HighlightForeColor
        {
            get { return color_1; }
            set
            {
                if (!(HighlightForeColor != value))
                    return;
                color_1 = value;
                OnHighlightForeColorChanged(EventArgs.Empty);
            }
        }

        [DefaultValue(typeof (Color), "Highlight")]
        [Category("Appearance")]
        public virtual Color HotTrackColor
        {
            get { return color_2; }
            set
            {
                if (!(HotTrackColor != value))
                    return;
                color_2 = value;
                OnHotTrackColorChanged(EventArgs.Empty);
            }
        }

        [Category("Appearance")]
        [DefaultValue(null)]
        public virtual ImageList ImageList
        {
            get { return imageList_0; }
            set
            {
                if (ImageList == value)
                    return;
                imageList_0 = value;
                OnImageListChanged(EventArgs.Empty);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(typeof (Padding), "2, 2, 2, 2")]
        [Browsable(true)]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = value; }
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        public virtual bool WordWrap
        {
            get { return bool_2; }
            set
            {
                if (WordWrap == value)
                    return;
                bool_2 = value;
                OnWordWrapChanged(EventArgs.Empty);
            }
        }

        int IListControl.DefaultItemHeight
        {
            get { return ItemHeight; }
            set { ItemHeight = value; }
        }

        bool IListControl.IsDroppedDown
        {
            get { return false; }
        }

        Rectangle IListControl.ClientRectangle
        {
            get { return ClientRectangle; }
        }

        Size IListControl.ClientSize
        {
            get { return ClientSize; }
        }

        bool IListControl.Enabled
        {
            get { return Enabled; }
        }

        [Category("Property Changed")]
        public event EventHandler FullRowSelectChanged;

        [Category("Property Changed")]
        public event EventHandler HideSelectionChanged;

        [Category("Property Changed")]
        public event EventHandler HighlightBackColorChanged;

        [Category("Property Changed")]
        public event EventHandler HighlightForeColorChanged;

        [Category("Property Changed")]
        public event EventHandler HotTrackColorChanged;

        [Category("Property Changed")]
        public event EventHandler HoverIndexChanged;

        [Category("Property Changed")]
        public event EventHandler ImageListChanged;

        [Category("Property Changed")]
        public event EventHandler RendererChanged;

        [Category("Property Changed")]
        public event EventHandler WordWrapChanged;

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            IListControlRenderer renderer = GetRenderer();
            ImageComboItem imageComboItem = GetItem(e.Index);
            var e1 = new ListControlDrawItemEventArgs(e, imageComboItem)
            {
                Image = GetItemImage(imageComboItem),
                Offset = Padding.Left
            };
            if (HoverIndex == e.Index)
                e1.State |= DrawItemState.HotLight;
            renderer.DrawItemBackground(this, e1);
            renderer.DrawItemImage(this, e1);
            renderer.DrawItemText(this, e1);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            SetAutomaticSize();
            base.OnFontChanged(e);
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            if (e.Index >= 0 && e.Index < Items.Count)
            {
                IListControlRenderer renderer = GetRenderer();
                ImageComboItem imageComboItem = GetItem(e.Index);
                if (imageComboItem != null)
                {
                    SizeF sizeF = renderer.MeasureItem(this, e.Graphics, imageComboItem);
                    e.ItemHeight = ImageList == null
                        ? (int) sizeF.Height + Padding.Vertical
                        : (int) Math.Max(sizeF.Height, ImageList.ImageSize.Height) + Padding.Vertical;
                }
            }
            base.OnMeasureItem(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            HoverIndex = -1;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (GetRenderer().AllowHotTrack)
            {
                int index = IndexFromPoint(e.Location);
                if (index == Items.Count - 1 && DrawMode == DrawMode.OwnerDrawVariable &&
                    !GetItemRectangle(index).Contains(e.Location))
                    index = -1;
                HoverIndex = index;
            }
            base.OnMouseMove(e);
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            SetAutomaticSize();
            base.OnPaddingChanged(e);
        }

        public ImageComboItem FindItemByKey(string key)
        {
            return FindItemByKey(key, 0);
        }

        public ImageComboItem FindItemByKey(string key, int startIndex)
        {
            ImageComboItem imageComboItem = null;
            for (int index = startIndex; index < Items.Count; ++index)
            {
                if (Items[index] is ImageComboItem && ((ImageComboItem) Items[index]).Key == key)
                {
                    imageComboItem = Items[index] as ImageComboItem;
                    break;
                }
            }
            return imageComboItem;
        }

        public ImageComboItem FindItemByTag(object tag)
        {
            return FindItemByTag(tag, 0);
        }

        public ImageComboItem FindItemByTag(object tag, int startIndex)
        {
            ImageComboItem imageComboItem = null;
            for (int index = startIndex; index < Items.Count; ++index)
            {
                if (Items[index] is ImageComboItem && ((ImageComboItem) Items[index]).Tag == tag)
                {
                    imageComboItem = Items[index] as ImageComboItem;
                    break;
                }
            }
            return imageComboItem;
        }

        public void InvalidateItem(int index)
        {
            if (index < 0 || index >= Items.Count)
                return;
            Invalidate(GetItemRectangle(index), false);
        }

        protected virtual int GetDefaultItemHeight()
        {
            int val2;
            using (Graphics graphics = CreateGraphics())
                val2 = (int) graphics.MeasureString("Xy", Font).Height;
            return Math.Max(imageList_0 != null ? imageList_0.ImageSize.Height : 0, val2) + Padding.Vertical;
        }

        protected virtual ImageComboItem GetItem(int index)
        {
            return index < 0 || index > Items.Count - 1
                ? new ImageComboItem(Text)
                : (Items[index] is ImageComboItem
                    ? (ImageComboItem) Items[index]
                    : new ImageComboItem(Items[index].ToString()));
        }

        protected virtual Image GetItemImage(ImageComboItem item)
        {
            return item.GetImage(ImageList);
        }

        protected virtual IListControlRenderer GetRenderer()
        {
            return Renderer ?? (Renderer = ListControlRenderer.DefaultRenderer);
        }

        protected virtual void OnFullRowSelectChanged(EventArgs e)
        {
            EventHandler eventHandler = FullRowSelectChanged;
            if (eventHandler == null)
                return;
            eventHandler(this, e);
        }

        protected virtual void OnHideSelectionChanged(EventArgs e)
        {
            EventHandler eventHandler = HideSelectionChanged;
            if (eventHandler == null)
                return;
            eventHandler(this, e);
        }

        protected virtual void OnHighlightBackColorChanged(EventArgs e)
        {
            EventHandler eventHandler = HighlightBackColorChanged;
            Invalidate();
            if (eventHandler == null)
                return;
            eventHandler(this, e);
        }

        protected virtual void OnHighlightForeColorChanged(EventArgs e)
        {
            Invalidate();
            EventHandler eventHandler = HighlightForeColorChanged;
            if (eventHandler == null)
                return;
            eventHandler(this, e);
        }

        protected virtual void OnHotTrackColorChanged(EventArgs e)
        {
            Invalidate();
            EventHandler eventHandler = HotTrackColorChanged;
            if (eventHandler == null)
                return;
            eventHandler(this, e);
        }

        protected virtual void OnHoverIndexChanged(EventArgs e)
        {
            EventHandler eventHandler = HoverIndexChanged;
            if (eventHandler == null)
                return;
            eventHandler(this, e);
        }

        protected virtual void OnImageListChanged(EventArgs e)
        {
            SetAutomaticSize();
            EventHandler eventHandler = ImageListChanged;
            if (eventHandler == null)
                return;
            eventHandler(this, e);
        }

        protected virtual void OnRendererChanged(EventArgs e)
        {
            if (Renderer != null)
                Renderer.Bind(this);
            Invalidate();
            EventHandler eventHandler = RendererChanged;
            if (eventHandler == null)
                return;
            eventHandler(this, e);
        }

        protected virtual void OnWordWrapChanged(EventArgs e)
        {
            Invalidate();
            EventHandler eventHandler = WordWrapChanged;
            if (eventHandler == null)
                return;
            eventHandler(this, e);
        }

        protected virtual void SetAutomaticSize()
        {
            ItemHeight = GetDefaultItemHeight();
        }
    }
}