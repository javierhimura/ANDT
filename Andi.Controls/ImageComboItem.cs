using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Andi.Controls
{
    public class ImageComboItem
    {
        public ImageComboItem()
        {
            ImageIndex = -1;
            ImageKey = string.Empty;
            Tag = null;
        }

        public ImageComboItem(string text)
            : this()
        {
            Text = text;
        }

        public ImageComboItem(string text, int imageIndex)
            : this(text)
        {
            ImageIndex = imageIndex;
        }

        public ImageComboItem(string text, string imageKey)
            : this(text)
        {
            ImageKey = imageKey;
        }

        public ImageComboItem(string text, int imageIndex, object tag)
            : this(text, imageIndex)
        {
            Tag = tag;
        }

        public ImageComboItem(string text, string imageKey, object tag)
            : this(text, imageKey)
        {
            Tag = tag;
        }

        [DefaultValue(null)]
        [Category("Appearance")]
        public virtual Image Image { get; set; }

        [DefaultValue(0)]
        [Category("Appearance")]
        public virtual int ImageIndex { get; set; }

        [Category("Appearance")]
        [DefaultValue("")]
        public virtual string ImageKey { get; set; }

        [Category("Appearance")]
        [DefaultValue(0)]
        public virtual int Indent { get; set; }

        [DefaultValue("")]
        [Category("Behavior")]
        public string Key { get; set; }

        [TypeConverter(typeof (StringConverter))]
        [DefaultValue(null)]
        public virtual object Tag { get; set; }

        [DefaultValue("")]
        [Category("Appearance")]
        public virtual string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }

        public Image GetImage(ImageList imageList)
        {
            Image image = Image;
            if (image == null && imageList != null)
            {
                int index = string.IsNullOrEmpty(ImageKey) ? ImageIndex : imageList.Images.IndexOfKey(ImageKey);
                if (index != -1)
                    image = imageList.Images[index];
            }
            return image;
        }
    }
}