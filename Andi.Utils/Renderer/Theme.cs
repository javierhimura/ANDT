using System.Windows.Forms;

namespace Andi.Utils.Renderer
{
    public class Theme
    {
        public static void setTheme(int id)
        {
            switch (id)
            {
                case 0:
                    ToolStripManager.Renderer = new VS2012LightRenderer();
                    break;
                case 1:
                    ToolStripManager.Renderer = new Win8MenuStripRenderer();
                    break;
            }
        }
    }
}
