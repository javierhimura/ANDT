using System.Drawing;
using System.Windows.Forms;

namespace NinfiaDSToolkit.Andi.Controls
{
    public interface IListControl
    {
        Color BackColor { get; set; }

        Rectangle ClientRectangle { get; }

        Size ClientSize { get; }

        int DefaultItemHeight { get; set; }

        bool Enabled { get; }

        Font Font { get; set; }

        Color ForeColor { get; set; }

        bool FullRowSelect { get; set; }

        bool HideSelection { get; }

        Color HighlightBackColor { get; set; }

        Color HighlightForeColor { get; set; }

        Color HotTrackColor { get; set; }

        ImageList ImageList { get; set; }

        bool IsDroppedDown { get; }

        Padding Padding { get; set; }

        bool WordWrap { get; set; }
    }
}