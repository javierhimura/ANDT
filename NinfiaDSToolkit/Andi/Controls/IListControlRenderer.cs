using System.Drawing;

namespace NinfiaDSToolkit.Andi.Controls
{
    public interface IListControlRenderer
    {
        bool AllowHotTrack { get; }

        void Bind(IListControl parent);

        void DrawItemBackground(IListControl parent, ListControlDrawItemEventArgs e);

        void DrawItemImage(IListControl parent, ListControlDrawItemEventArgs e);

        void DrawItemText(IListControl parent, ListControlDrawItemEventArgs e);

        SizeF MeasureItem(IListControl parent, Graphics g, ImageComboItem item);
    }
}