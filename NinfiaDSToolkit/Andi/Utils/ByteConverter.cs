using System;
using System.Collections.Generic;

namespace NinfiaDSToolkit.Andi.Utils
{
    public class ByteConverter
    {
        public enum reverse
        {
            yes, no
        }

        public static byte[] ToByte(long input, int lenghtbyte)
        {
            byte[] data = new byte[lenghtbyte];
            byte[] data2 = BitConverter.GetBytes(input);

            for (int i = 0; i < lenghtbyte; i++)
            {
                data[i] = data2[i];
            }

            return data;
        }

        public static byte[] ToByte(long input, int lenghtbyte, reverse c)
        {

            byte[] data = new byte[lenghtbyte];
            byte[] data2 = BitConverter.GetBytes(input);

            for (int i = 0; i < lenghtbyte; i++)
            {
                data[i] = data2[i];
            }

            if (c == reverse.no)
            {
                Array.Reverse(data);
            }

            return data;
        }

        public static byte[] CombineByte(List<byte[]> data)
        {
            byte[] rv;

            int lenghtbyte = 0, intp = 0;

            for (int i = 0; i < data.Count; i++)
            {
                lenghtbyte += data[i].Length;
            }

            rv = new byte[lenghtbyte];

            for (int i = 0; i < data.Count; i++)
            {
                System.Buffer.BlockCopy(data[i], 0, rv, intp, data[i].Length);
                intp += data[i].Length;
            }

            return rv;
        }

        public static string ByteToHexBit(byte[] bytes)
        {
            char[] c = new char[bytes.Length * 2];
            int b;
            for (int i = 0; i < bytes.Length; i++)
            {
                b = bytes[i] >> 4;
                c[i * 2] = (char)(55 + b + (((b - 10) >> 31) & -7));
                b = bytes[i] & 0xF;
                c[i * 2 + 1] = (char)(55 + b + (((b - 10) >> 31) & -7));
            }
            return new string(c);
        }

        public static string bitConvert(int x)
        {
            char[] bits = new char[32];
            int i = 0;

            while (x != 0)
            {
                bits[i++] = (x & 1) == 1 ? '1' : '0';
                x >>= 1;
            }

            Array.Reverse(bits, 0, i);
            return new string(bits);
        }
    }
}
