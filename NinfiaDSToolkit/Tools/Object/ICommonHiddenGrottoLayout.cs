using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NinfiaDSToolkit.Andi.Controls.ImageBox;

namespace NinfiaDSToolkit.Tools.Object
{
    internal interface ICommonHiddenGrottoLayout
    {
        void WritePokemonId();

        void WriteHiddenGrottoData();

        void ImageBoxChange(AndiImageBox imgbox, int index, vEnum.HiddenGrottoProperty property);

        void ReadPokemonData(object sender);

        void ReadItemsData();

        void ImageBoxEventLoads();

        void ChangeImagBoxItemList(int id, vEnum.HiddenGrottoProperty property, params AndiImageBox[] ibbox);
    }
}
