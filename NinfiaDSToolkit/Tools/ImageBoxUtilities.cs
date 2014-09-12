using System;
using System.Drawing;
using NinfiaDSToolkit.Andi.Controls.ImageBox;
using NinfiaDSToolkit.Andi.Utils;

namespace NinfiaDSToolkit.Tools
{
    internal class ImageBoxUtilities
    {
        internal static void ImageBoxGridColor(Color color, params AndiImageBox[] box)
        {
            for (int i = 0; i < box.Length; i++)
            {
                if (box[i].GridColor != color)
                {
                    box[i].GridColor = color;
                }
            }
        }

        internal static void ImageBoxLoadEvent(EventHandler handler, params AndiImageBox[] itm)
        {
            for (int i = 0; i < itm.Length; i++)
            {
                try
                {
                    itm[i].IndexParent = (i + 1);
                    itm[i].Click -= handler; // make sure event listener click is not duplicate on same control
                    itm[i].Click += handler;
                }
                catch (Exception ex)
                {
#if DEBUG
                    Database.InsertReader.InsertLogs("error", "Yello", ex);
#endif
                }
            }
        }
    }
}
