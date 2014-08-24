using System;
using System.Diagnostics;
using System.Windows.Forms;
using NinfiaDSToolkit.Andi;
using NinfiaDSToolkit.Andi.Utils;
using NinfiaDSToolkit.Andi.Utils.Narc;
//using NinfiaDSToolkit.Andi.Utils.NitroROM.DSFileSystem;
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
            btn_open_hgrotto.Click += btn_open_hgrotto_Click;
            this.Text = ProductName +" " + ProductVersion;

            loadCPUVer();
            //loadHomePage();
        }

        void btn_open_hgrotto_Click(object sender, EventArgs e)
        {
            loadHiddenHollow();
        }


        void btn_exit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
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

        private void menuItem11_Click(object sender, EventArgs e)
        {
            loadMoveset();
        }

        private void menuItem12_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/andibadra/ninfia.document/wiki");
        }

        private void menuItem15_Click(object sender, EventArgs e)
        {
            loadExperience();
        }

        private void menuItem24_Click(object sender, EventArgs e)
        {
            loadInformation();
        }

        void loadExperience()
        {
            vExperience an = new vExperience();

            int count = 1;
            string text = "[" + count + "] Experience Editor";
            while (FindDocument(text) != null)
            {
                count++;
                text = "[" + count + "] Experience Editor";
            }

            an.Text = text;

            if (this.panel_dock1.DocumentStyle == DocumentStyle.SystemMdi)
            {
                an.MdiParent = this;
                an.Show();
            }
            else
                an.Show(this.panel_dock1);
        }

        void loadInformation()
        {
            Information an = new Information();

            int count = 1;
            string text = "[" + count + "] Information";
            while (FindDocument(text) != null)
            {
                count++;
                text = "[" + count + "] Information";
            }

            an.Text = text;

            if (this.panel_dock1.DocumentStyle == DocumentStyle.SystemMdi)
            {
                an.MdiParent = this;
                an.Show();
            }
            else
                an.Show(this.panel_dock1);
        }

        void loadHiddenHollow()
        {
            var an = new vHG();

            int count = 1;
            string text = "[" + count + "] Hidden Grotto/Hollow Editor";
            while (FindDocument(text) != null)
            {
                count++;
                text = "[" + count + "] Hidden Grotto/Hollow Editor";
            }

            an.Text = text;

            if (this.panel_dock1.DocumentStyle == DocumentStyle.SystemMdi)
            {
                an.MdiParent = this;
                an.Show();
            }
            else
                an.Show(this.panel_dock1);
        }

        void loadMoveset()
        {
            vMVSt an = new vMVSt();

            int count = 1;
            string text = "[" + count + "] Moveset Editor";
            while (FindDocument(text) != null)
            {
                count++;
                text = "[" + count + "] Moveset Editor";
            }

            an.Text = text;

            if (this.panel_dock1.DocumentStyle == DocumentStyle.SystemMdi)
            {
                an.MdiParent = this;
                an.Show();
            }
            else
                an.Show(this.panel_dock1);
        }

        void loadWildExg4()
        {
            vWildEx4 an = new vWildEx4();

            int count = 1;
            string text = "[" + count + "] WildEncounterEx gen4 Editor";
            while (FindDocument(text) != null)
            {
                count++;
                text = "[" + count + "] WildEncounterEx gen4 Editor";
            }

            an.Text = text;

            if (this.panel_dock1.DocumentStyle == DocumentStyle.SystemMdi)
            {
                an.MdiParent = this;
                an.Show();
            }
            else
                an.Show(this.panel_dock1);
        }

        private void ActiveContentChanged(object sender, EventArgs e)
        {
            try
            {
                this.Text = panel_dock1.ActiveContent.DockHandler.TabText +" - "+ProductName + " " + ProductVersion ;

            }
            catch
            {
                
            }

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

        private void menuItem19_Click(object sender, EventArgs e)
        {
            loadWildExg4();
        }

        private void menuItem16_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void menuItem17_Click(object sender, EventArgs e)
        {
            vEvolutions an = new vEvolutions();

            int count = 1;
            string text = "[" + count + "] Evolution Editor";
            while (FindDocument(text) != null)
            {
                count++;
                text = "[" + count + "] Evolution Editor";
            }

            an.Text = text;

            if (this.panel_dock1.DocumentStyle == DocumentStyle.SystemMdi)
            {
                an.MdiParent = this;
                an.Show();
            }
            else
                an.Show(this.panel_dock1);
        }

    }
}
