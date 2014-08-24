using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace NinfiaDSToolkit.Andi.Controls
{
    public static class EnumExtensions
    {
        private static readonly object object_0 = new object();
        private static readonly IDictionary<Enum, string> idictionary_1 = new Dictionary<Enum, string>();
        private static readonly IDictionary<Enum, bool> idictionary_0 = new Dictionary<Enum, bool>();

        static EnumExtensions()
        {
        }

        public static string GetDescription([In] this Enum obj0)
        {
            string str;
            if (!idictionary_1.TryGetValue(obj0, out str))
            {
                FieldInfo field = obj0.GetType().GetField(obj0.ToString());
                DescriptionAttribute descriptionAttribute = field != null
                    ? Attribute.GetCustomAttribute(field, typeof (DescriptionAttribute)) as DescriptionAttribute
                    : null;
                str = descriptionAttribute == null
                    ? obj0.ToString().ParseByCapitalLetters()
                    : descriptionAttribute.Description;
                lock (object_0)
                {
                    if (!idictionary_1.ContainsKey(obj0))
                        idictionary_1.Add(obj0, str);
                }
            }
            return str;
        }

        public static bool HasFlag<T>([In] this T value, [In] T flags) where T : struct
        {
            Type enumType = typeof (T);
            if (!enumType.IsEnum)
                throw new ArgumentException("The type parameter T must be an enum type.");
            Type underlyingType = Enum.GetUnderlyingType(enumType);
            if (underlyingType == typeof (int))
                return smethod_0(value, flags, (Func<int, int, bool>) ((obj0, obj1) => (obj0 & obj1) == obj1));
            if (underlyingType == typeof (sbyte))
                return smethod_0(value, flags,
                    (Func<sbyte, sbyte, bool>) ((obj0, obj1) => ((int) obj0 & (int) obj1) == (int) obj1));
            if (underlyingType == typeof (byte))
                return smethod_0(value, flags,
                    (Func<byte, byte, bool>) ((obj0, obj1) => ((int) obj0 & (int) obj1) == (int) obj1));
            if (underlyingType == typeof (short))
                return smethod_0(value, flags,
                    (Func<short, short, bool>) ((obj0, obj1) => ((int) obj0 & (int) obj1) == (int) obj1));
            if (underlyingType == typeof (ushort))
                return smethod_0(value, flags,
                    (Func<ushort, ushort, bool>) ((obj0, obj1) => ((int) obj0 & (int) obj1) == (int) obj1));
            if (underlyingType == typeof (uint))
                return smethod_0(value, flags,
                    (Func<uint, uint, bool>) ((obj0, obj1) => ((int) obj0 & (int) obj1) == (int) obj1));
            if (underlyingType == typeof (long))
                return smethod_0(value, flags, (Func<long, long, bool>) ((obj0, obj1) => (obj0 & obj1) == obj1));
            if (underlyingType == typeof (ulong))
                return smethod_0(value, flags,
                    (Func<ulong, ulong, bool>) ((obj0, obj1) => ((long) obj0 & (long) obj1) == (long) obj1));
            if (underlyingType == typeof (char))
                return smethod_0(value, flags,
                    (Func<char, char, bool>) ((obj0, obj1) => ((int) obj0 & (int) obj1) == (int) obj1));
            throw new ArgumentException("Unknown enum underlying type " + underlyingType.Name + ".");
        }

        private static bool smethod_0<T>([In] object obj0, [In] object obj1, [In] Func<T, T, bool> obj2)
        {
            return obj2((T) obj0, (T) obj1);
        }
    }
}