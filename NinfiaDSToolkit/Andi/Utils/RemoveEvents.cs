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

        public static string RemoveSpecialCharacter(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
