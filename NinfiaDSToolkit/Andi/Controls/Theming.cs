using System.Windows.Forms;

namespace NinfiaDSToolkit.Andi.Controls
{
    internal class Theming
    {
        public static void setTheme(int id)
        {
            switch (id)
            {
                case 0:
                    ToolStripManager.Renderer = new VS2012LightRenderer();
                    break;
            }
        }
    }
}
