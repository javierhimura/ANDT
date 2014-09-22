using System.Windows.Forms;
using SourceGrid;

namespace Andi.Toolkit.utils.Internal
{
    internal interface IGridFormLayout
    {
        void BaseGridSelectionChanged();

        void BaseGridSelection_FocusRowEntered(object sender, RowEventArgs e);

        void BaseGridSelection_SelectionChanged(object sender, KeyEventArgs e);

        void BaseGridSelection_SelectionChanged(object sender, MouseEventArgs e);
    }
}
