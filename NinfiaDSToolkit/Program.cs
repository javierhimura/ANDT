using System;
using System.Windows.Forms;
using NinfiaDSToolkit.Andi.Controls;
using NinfiaDSToolkit.Andi.Utils;

namespace NinfiaDSToolkit
{
    static class Program
    {
        public static MainForm mForm;
        public static string GlobalPath;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);

            MemoryManager.AttachApp();

            GlobalPath = Application.StartupPath;

            if (Tools.Object.AccessChecker.WriteAccess(Application.StartupPath))
            {
                mForm = new MainForm();
                Database.Connect();
                ToolStripManager.Renderer = new VS2012LightRenderer();
                Application.Run(mForm);
            }
            else
            {
                MessageBox.Show("Directory : "+Application.StartupPath+ " ini Tidak mempunyai hak akses Menulis/Membaca\n\nmaka Aplikasi ini akan keluar!");
                Application.ExitThread();
            }
        }
    }
}
