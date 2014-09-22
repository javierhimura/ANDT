using System.IO;

namespace Andi.Toolkit.utils
{
    public class CheckMagicHeaderID
    {
        public static string get(string path)
        {
            Stream a = new FileStream(path, FileMode.Open);
            a.Position = 0;
            byte[] bytee = new byte[4];

            a.Read(bytee, 0, 4);
            a.Close();

            return System.Text.Encoding.ASCII.GetString(bytee);
        }
    }
}
