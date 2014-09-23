//using NinfiaDSToolkit.Andi.Utils.NitroROM.DSFileSystem;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using Andi.Controls.TabControl;
using Andi.Toolkit.gen0;
using Andi.Toolkit.gen4;
using Andi.Toolkit.gen5;
using Andi.Toolkit.utils;
using Andi.Toolkit.utils2;
using Andi.Toolkit.utils2.Arc;
using Andi.Toolkit.utils2.Main;
using Andi.Toolkit._un;
using Andi.Utils.Renderer;
using WeifenLuo.WinFormsUI.Docking;

namespace Andi.Toolkit
{
    public partial class MainForm : Form
    {
        // public static NitroROMFilesystem fsrom;
        // public bool check = false;
        // public string foolpath = "";

        public MainForm()
        {
            InitializeComponent();
            Event();
            loadCPUVer();
            
            this.Text= ProductName +" " + ProductVersion;
        }

        #region Main Events
        public void Event()
        {
            panel_dock1.ActiveContentChanged += (ActiveContentChanged);

            mExit.Click += MExitClick;
            mHomeDS.Click += ShowMHomeClick;
            mHGH.Click += ShowMHidenGrotto;
            mAbout.Click += ShowMAboutClick;

            mInformation.Click += ShowMInformationClick;
            // mLinkGithub.Click += LinkMLinkGithubClick;
            // mLinkBitbucket.Click += LinkMLinkBitbucketClick;
            // mLinkPP.Click += LinkPokemonProject_Click;
            mRestart.Click += FunctMRestartClick;

            mWildEn4.Click += ShowMWildEx4Click;
            mMoveset.Click += ShowMoveEditor_Click;
            mExperience.Click += ShowMExperienceClick;
            mEvolution.Click += ShowMEvolutionEditorClick;
            // mInGameTrade.Click += ShowIngameTrade_Click;

            mTestNarc.Click += ToolTestMTestNarcClick;
            // mTestBLZ.Click += ToolTestBLZ_Click;
            // mTestOva9.Click += ToolTestOvaTable_Click;
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
                // sbp_1.Text = "x64";
            }
            else
            {
                // sbp_1.Text = "x32";
            }
        }
        #endregion

        #region MenuClick
        void MExitClick(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void FunctMRestartClick(object sender, EventArgs e)
        {
            Application.Restart();
        }

        void ShowMHomeClick(object sender, EventArgs e)
        {

        }

        void ShowMHidenGrotto(object sender, EventArgs e)
        {
            loadDockForms(new vHG(), "HiddenGrotto Editor");
        }

        private void ShowMoveEditor_Click(object sender, EventArgs e)
        {
            loadDockForms(new vMVSt(), "Moveset Editor");
        }

        private void ShowMExperienceClick(object sender, EventArgs e)
        {
            loadDockForms(new vExperience(), "Experience Editor");
        }

        private void ShowMInformationClick(object sender, EventArgs e)
        {
            loadDockForms(new Information(), "Information");
        }

        private void ShowMWildEx4Click(object sender, EventArgs e)
        {
            loadDockForms(new vWildEx4(), "WildEncounterEx gen4 Editor");
        }

        private void ShowMEvolutionEditorClick(object sender, EventArgs e)
        {
            loadDockForms(new vEvolutions(), "Evolution Editor");
        }

        private void ShowMAboutClick(object sender, EventArgs e)
        {
            About a = new About();

            a.ShowDialog(this);
        }

        private void ToolTestBLZ_Click(object sender, EventArgs e)
        {
            loadDockForms(new BLZCoderUI(), "BLZCoder Test");
        }

        private void ToolTestMTestNarcClick(object sender, EventArgs e)
        {
            loadDockForms(new NarcExplorer(), "NARC Viewer Test");
        }

        private void ToolTestOvaTable_Click(object sender, EventArgs e)
        {
            loadDockForms(new ovl9tableview(), "Overlay9 Table Viewer");
        }

        private void ShowIngameTrade_Click(object sender, EventArgs e)
        {
            loadDockForms(new vInGameTrade(), "In-Game Trade Editor");
        }

        private void LinkPokemonProject_Click(object sender, EventArgs e)
        {
            Process.Start("http://projectpokemon.org/forums/showthread.php?26663-Andi-Pok%E9mon-Black-amp-White-Tools");
        }

        private void LinkMLinkBitbucketClick(object sender, EventArgs e)
        {
            Process.Start("https://bitbucket.org/andibadra/");
        }

        private void LinkMLinkGithubClick(object sender, EventArgs e)
        {
            Process.Start("https://github.com/andibadra");
        }
        #endregion

        private void win8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Theme.setTheme(1);
        }

        private void vS2012WhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Theme.setTheme(0);
        }

        private void bCSARUnpackerTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadDockForms(new Andi.Toolkit.utils2.BCSARUnpacker(), "BCSAR Unpacker");
        }
    }
}
