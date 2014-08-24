using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace NinfiaDSToolkit.Andi.Utils
{
    public class RemoveEvents
    {
        public static void RemoveClickEvent(MenuItem menu)
        {
            FieldInfo fl = typeof (Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
            object obj = fl.GetValue(menu);
            PropertyInfo pi = menu.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
            EventHandlerList list = (EventHandlerList) pi.GetValue(menu, null);
            list.RemoveHandler(obj, list[obj]);
        }
    }
}
