using System;
using System.Diagnostics;
using System.Windows.Forms;
//using NinfiaDSToolkit.Andi.Utils.NitroROM.DSFileSystem;
using NinfiaDSToolkit.Tools;
using NinfiaDSToolkit.Tools.Extra;
//using NinfiaDSToolkit.Tools.Unfinished;
using WeifenLuo.WinFormsUI.Docking;

namespace NinfiaDSToolkit
{
    public partial class MainForm : Form
    {
        //public static NitroROMFilesystem fsrom;
        public bool check = false;

        public MainForm()
        {
            InitializeComponent();

            btn_exit.Click += btn_exit_Click;
            btn_showhome.Click += btn_showhome_Click;
            btn_open_hgrotto.Click += btn_open_hgrotto_Click;
            this.Text = ProductName +" " + ProductVersion;

            loadCPUVer();
            //loadHomePage();
        }

        private void ActiveContentChanged(object sender, EventArgs e)
        {
            try
            {
                this.Text = panel_dock1.ActiveContent.DockHandler.TabText + " - " + ProductName + " " + ProductVersion;
            }
            catch { }

            if (MdiChildren.Length == 0)
            {
                this.Text = ProductName + " " + ProductVersion;
            }
        }

        private IDockContent FindDocument(string text)
        {
            if (panel_dock1.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    if (form.Text == text)
                        return form as IDockContent;

                return null;
            }
            else
            {
                foreach (IDockContent content in panel_dock1.Documents)
                    if (content.DockHandler.TabText == text)
                        return content;

                return null;
            }
        }

        private void loadDockForms(DockContent form, string textheader)
        {
            int count = 1;
            string text = "[" + count + "] " + textheader;

            while (FindDocument(text) != null)
            {
                count++;
                text = "[" + count + "] " + textheader;
            }

            form.Text = text;

            if (this.panel_dock1.DocumentStyle == DocumentStyle.SystemMdi)
            {
                form.MdiParent = this;
                form.Show();
            }
            else
                form.Show(this.panel_dock1);
        }

        void loadCPUVer()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                sbp_1.Text = "x64";
            }
            else
            {
                sbp_1.Text = "x32";
            }
        }

        void btn_exit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void menuItem16_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void menuItem12_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/andibadra/ninfia.document/wiki");
        }

        void btn_showhome_Click(object sender, EventArgs e)
        {

        }

        void btn_open_hgrotto_Click(object sender, EventArgs e)
        {
            loadDockForms(new vHG(), "HiddenGrotto Editor");
        }

        private void menuItem11_Click(object sender, EventArgs e)
        {
            loadDockForms(new vMVSt(), "Moveset Editor");
        }

        private void menuItem15_Click(object sender, EventArgs e)
        {
            loadDockForms(new vExperience(), "Experience Editor");
        }

        private void menuItem24_Click(object sender, EventArgs e)
        {
            loadDockForms(new Information(), "Information");
        }

        private void menuItem19_Click(object sender, EventArgs e)
        {
            loadDockForms(new vWildEx4(), "WildEncounterEx gen4 Editor");
        }

        private void menuItem17_Click(object sender, EventArgs e)
        {
            loadDockForms(new vEvolutions(), "Evolution Editor");
        }

        private void btn_showhome_Click_1(object sender, EventArgs e)
        {
            About a = new About();

            a.ShowDialog(this);
        }

        private void menuItem21_Click(object sender, EventArgs e)
        {
            loadDockForms(new BLZCoderUI(), "BLZCoder Test");
        }

        private void menuItem9_Click(object sender, EventArgs e)
        {
            loadDockForms(new NarcExplorer(), "NARC Viewer");
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            loadDockForms(new ovl9tableview(), "Overlay9 Table Viewer");
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            //loadDockForms(new vInGameTrade(), "In-Game Trade Editor");
        }

        private void menuItem8_Click(object sender, EventArgs e)
        {
            Process.Start("http://projectpokemon.org/forums/showthread.php?26663-Andi-Pok%E9mon-Black-amp-White-Tools");
        }

        private void menuItem14_Click(object sender, EventArgs e)
        {
            Process.Start("https://bitbucket.org/andibadra/");
        }

        private void menuItem10_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/andibadra");
        }
    }
}
