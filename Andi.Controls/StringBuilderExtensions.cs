using System.Runtime.InteropServices;
using System.Text;

namespace Andi.Controls
{
    public static class StringBuilderExtensions
    {
        public static void Clear([In] this StringBuilder obj0)
        {
            obj0.Length = 0;
            obj0.Capacity = 16;
        }
    }
}