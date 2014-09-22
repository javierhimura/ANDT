using System;
using System.Windows.Forms;
using Andi.Libs;
using Andi.Toolkit.utils.Object;
using Andi.Utils.Database;
using Andi.Utils.Renderer;

namespace Andi.Toolkit
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

            if (AccessChecker.WriteAccess(Application.StartupPath))
            {
                mForm = new MainForm();
                Database.Connect();
                Theme.setTheme(1);
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
