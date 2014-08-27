using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinfiaDSToolkit.Tools.Object
{
    internal interface ICommonFormLayout
    {
        void EventsFormLoad();

        void OpenFile_Click(object sender, EventArgs e);

        void SaveFile_Click(object sender, EventArgs e);

        void EventsAfterOpenFile();

        void WriteNarcBack();

        void LoadCurrentData();

        void WriteCurrentBack_Click(object sender, EventArgs e);

        void HexView();
    }
}
