using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Andi.Controls
{
    public static class StringExtensions
    {
        public static string ParseByCapitalLetters([In] this string obj0)
        {
            return Regex.Replace(obj0, "((?<=[a-z])[A-Z]|[A-Z](?=[a-z]))", " $1").Trim();
        }

        public static string[] QuotedSplit([In] this string obj0, [In] char obj1)
        {
            return obj0.QuotedSplit(obj1, false);
        }

        public static string[] QuotedSplit([In] this string obj0, [In] char obj1, [In] bool obj2)
        {
            return obj0.QuotedSplit(new char[1]
            {
                obj1
            }, (obj2 ? 1 : 0) != 0);
        }

        public static string[] QuotedSplit([In] this string obj0, [In] char[] obj1, [In] bool obj2)
        {
            var list = new List<string>();
            var stringBuilder = new StringBuilder();
            bool flag1 = false;
            foreach (char ch1 in obj0)
            {
                if (ch1 == 34)
                    flag1 = !flag1;
                bool flag2 = false;
                foreach (char ch2 in obj1)
                {
                    if (ch1 == ch2)
                    {
                        flag2 = true;
                        break;
                    }
                }
                if (!flag1 && flag2)
                {
                    list.Add(stringBuilder.ToString());
                    StringBuilderExtensions.Clear(stringBuilder);
                }
                else if (ch1 != 34 || obj2)
                    stringBuilder.Append(ch1);
            }
            if (stringBuilder.Length > 0)
                list.Add(stringBuilder.ToString());
            return list.ToArray();
        }

        public static string ReplaceEx([In] this string obj0, [In] string obj1, [In] string obj2)
        {
            return obj0.ReplaceEx(obj1, obj2, StringComparison.InvariantCultureIgnoreCase);
        }

        public static string ReplaceEx([In] this string obj0, [In] string obj1, [In] string obj2,
            [In] StringComparison obj3)
        {
            return obj0.ReplaceEx(obj1, obj2, obj3, -1);
        }

        public static string ReplaceEx([In] this string obj0, [In] string obj1, [In] string obj2,
            [In] StringComparison obj3, [In] int obj4)
        {
            if (!string.IsNullOrEmpty(obj0) && !string.IsNullOrEmpty(obj1) && obj0.IndexOf(obj1, obj3) != -1)
            {
                var stringBuilder = new StringBuilder(obj4 < 0 ? Math.Min(4096, obj0.Length) : obj4);
                int startIndex = 0;
                int length = obj1.Length;
                for (int index = obj0.IndexOf(obj1, obj3); index >= 0; index = obj0.IndexOf(obj1, startIndex, obj3))
                {
                    stringBuilder.Append(obj0, startIndex, index - startIndex);
                    stringBuilder.Append(obj2);
                    startIndex = index + length;
                }
                stringBuilder.Append(obj0, startIndex, obj0.Length - startIndex);
                obj0 = stringBuilder.ToString();
            }
            return obj0;
        }

        public static string TruncateByWidth([In] this string obj0, [In] Font obj1)
        {
            return obj0.TruncateByWidth(400, obj1);
        }

        public static string TruncateByWidth([In] this string obj0, [In] int obj1, [In] Font obj2)
        {
            return obj0.TruncateByWidth(obj1, obj2,
                TextFormatFlags.ModifyString | TextFormatFlags.NoPrefix | TextFormatFlags.PathEllipsis);
        }

        public static string TruncateByWidth([In] this string obj0, [In] int obj1, [In] Font obj2,
            [In] TextFormatFlags obj3)
        {
            char ch = char.MinValue;
            string text = string.Copy(obj0 + new string(char.MinValue, 4));
            TextRenderer.MeasureText(text, obj2, new Size(obj1, 0), obj3);
            if (text.IndexOf(char.MinValue) != -1)
                text = text.Substring(0, text.IndexOf(ch));
            return text;
        }
    }
}