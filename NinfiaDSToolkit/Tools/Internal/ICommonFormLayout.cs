using System;

namespace NinfiaDSToolkit.Tools.Internal
{
    internal interface ICommonFormLayout
    {

        void EventsFormLoad();

        void OpenFile_Click(object sender, EventArgs e);

        void SaveFile_Click(object sender, EventArgs e);

        void EventsAfterOpenFile();

        void GotFocusF(object sender, EventArgs e);

        void WriteNarcBack();

        void LoadCurrentData();

        void WriteCurrentBack_Click(object sender, EventArgs e);

        void HexView();
    }
}
