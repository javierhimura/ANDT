using System.Drawing;
using System.Windows.Forms;

namespace NinfiaDSToolkit.Andi.Controls
{
    public class ListControlDrawItemEventArgs : DrawItemEventArgs
    {
        public ListControlDrawItemEventArgs(DrawItemEventArgs e, ImageComboItem item)
            : base(e.Graphics, e.Font, e.Bounds, e.Index, e.State, e.ForeColor, e.BackColor)
        {
            Item = item;
            State = e.State;
        }

        public Image Image { get; set; }

        public ImageComboItem Item { get; set; }

        public int Offset { get; set; }

        public new DrawItemState State { get; set; }
    }
}