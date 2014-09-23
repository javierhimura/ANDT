using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Andi.Controls
{
    public class AndiImageComboBox : System.Windows.Forms.ComboBox, IListControl
    {
        private bool bool_1;
        private bool bool_2;
        private Color color_0;
        private Color color_1;
        private Color color_2;
        private IListControlRenderer ilistControlRenderer_0;
        private ImageList imageList_0;

        public AndiImageComboBox()
        {
            HideSelection = true;
            DrawMode = DrawMode.OwnerDrawVariable;
            FullRowSelect = true;
            Padding = new Padding(2);
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
            get { return bool_1; }
            set
            {
                if (FullRowSelect == value)
                    return;
                bool_1 = value;
                OnFullRowSelectChanged(EventArgs.Empty);
            }
        }

        [DefaultValue(true)]
        [Category("Appearance")]
        public virtual bool HideSelection
        {
            get { return bool_2; }
            set
            {
                if (HideSelection == value)
                    return;
                bool_2 = value;
                OnHideSelectionChanged(EventArgs.Empty);
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof (Color), "Highlight")]
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

        [DefaultValue(typeof (Color), "HighlightText")]
        [Category("Appearance")]
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

        [DefaultValue(null)]
        [Category("Behavior")]
        public ImageList ImageList
        {
            get { return imageList_0; }
            set
            {
                imageList_0 = value;
                OnImageListChanged(EventArgs.Empty);
            }
        }

        [DefaultValue(typeof (Padding), "2, 2, 2, 2")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = value; }
        }

        bool IListControl.WordWrap
        {
            get { return false; }
            set { }
        }

        int IListControl.DefaultItemHeight
        {
            get { return ItemHeight; }
            set { ItemHeight = value; }
        }

        bool IListControl.IsDroppedDown
        {
            get { return DroppedDown; }
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
        public event EventHandler ImageListChanged;

        [Category("Property Changed")]
        public event EventHandler RendererChanged;

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            IListControlRenderer renderer = GetRenderer();
            ImageComboItem imageComboItem = e.Index >= 0
                ? (Items[e.Index] is ImageComboItem
                    ? (ImageComboItem) Items[e.Index]
                    : new ImageComboItem(Items[e.Index].ToString()))
                : new ImageComboItem(Text);
            var e1 = new ListControlDrawItemEventArgs(e, imageComboItem)
            {
                Image = GetItemImage(imageComboItem),
                Offset = Padding.Left
            };
            renderer.DrawItemBackground(this, e1);
            renderer.DrawItemImage(this, e1);
            renderer.DrawItemText(this, e1);
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            if (ImageList != null && e.Index >= 0 && (e.Index < Items.Count && Items[e.Index] is ImageComboItem))
                e.ItemHeight = ImageList.ImageSize.Height + Padding.Vertical;
            base.OnMeasureItem(e);
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            ItemHeight = GetBaseItemHeight();
            base.OnPaddingChanged(e);
        }


        public ImageComboItem FindItemByKey(string key)
        {
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: reference to a compiler-generated method
            return Items.Cast<object>().Where(new Class82
            {
                string_0 = key
            }.method_0).Cast<ImageComboItem>().FirstOrDefault();
        }

        public ImageComboItem FindItemByTag(object value)
        {
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: reference to a compiler-generated method
            return Items.Cast<object>().Where(new Class83
            {
                object_0 = value
            }.method_0).Cast<ImageComboItem>().FirstOrDefault();
        }

        public ImageComboItem FindItemByText(string text)
        {
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: reference to a compiler-generated method
            return Items.Cast<object>().Where(new Class84
            {
                string_0 = text
            }.method_0).Cast<ImageComboItem>().FirstOrDefault();
        }

        public void PopulateFromEnum(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            if (!typeof (Enum).IsAssignableFrom(type))
                throw new ArgumentException("Type is not an enum.", "type");
            BeginUpdate();
            Items.Clear();
            foreach (object tag in Enum.GetValues(type))
                Items.Add(new ImageComboItem(Enum.GetName(type, tag), null, tag));
            EndUpdate();
        }

        public void SetAutomaticSize()
        {
            ItemHeight = GetBaseItemHeight();
        }

        protected virtual int GetBaseItemHeight()
        {
            int val2;
            using (Graphics graphics = CreateGraphics())
                val2 = (int) graphics.MeasureString("Xy", Font).Height;
            return Math.Max(imageList_0 == null ? 0 : imageList_0.ImageSize.Height, val2) + Padding.Vertical;
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
            Invalidate();

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

        private sealed class Class82
        {
            // Fields
            public string string_0;

            // Methods
            public bool method_0(object object_0)
            {
                return ((object_0 is ImageComboItem) && Equals(((ImageComboItem) object_0).Key, string_0));
            }
        }

        private sealed class Class83
        {
            // Fields
            public object object_0;

            // Methods
            public bool method_0(object object_1)
            {
                return ((object_1 is ImageComboItem) && Equals(((ImageComboItem) object_1).Tag, object_0));
            }
        }

        private sealed class Class84
        {
            // Fields
            public string string_0;

            // Methods
            public bool method_0(object object_0)
            {
                return ((object_0 is ImageComboItem) && Equals(((ImageComboItem) object_0).Text, string_0));
            }
        }
    }
}