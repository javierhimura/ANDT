using System;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Windows.Forms;
using NinfiaDSToolkit.Andi.Controls;
using NinfiaDSToolkit.Andi.Utils.DB;

namespace NinfiaDSToolkit
{
    static class Program
    {
        public static MainForm mForm;
        //public static vHome vFHome;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            MemoryManager.AttachApp();

            if (WriteAccess(Application.StartupPath))
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

        public static bool WriteAccess(string fileName)
        {
            if ((File.GetAttributes(fileName) & FileAttributes.ReadOnly) != 0)
                return false;

            var rules = File.GetAccessControl(fileName).GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));

            var groups = WindowsIdentity.GetCurrent().Groups;
            string sidCurrentUser = WindowsIdentity.GetCurrent().User.Value;

            if (rules.OfType<FileSystemAccessRule>().Any(r => (groups.Contains(r.IdentityReference) || r.IdentityReference.Value == sidCurrentUser) && r.AccessControlType == AccessControlType.Deny && (r.FileSystemRights & FileSystemRights.WriteData) == FileSystemRights.WriteData))
                return false;

            return rules.OfType<FileSystemAccessRule>().Any(r => (groups.Contains(r.IdentityReference) || r.IdentityReference.Value == sidCurrentUser) && r.AccessControlType == AccessControlType.Allow && (r.FileSystemRights & FileSystemRights.WriteData) == FileSystemRights.WriteData);
        }
    }
}
