using System.Drawing;
using System.Windows.Forms;
using NinfiaDSToolkit.Andi.Controls;

namespace NinfiaDSToolkit
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin1 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient1 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient2 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient3 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient4 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient5 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient6 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient7 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel_dock1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.vS2012LightTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2012LightTheme();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.mInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mTestNarc = new System.Windows.Forms.ToolStripMenuItem();
            this.mTestBLZ = new System.Windows.Forms.ToolStripMenuItem();
            this.mTestOva9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.linksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mLinkGithub = new System.Windows.Forms.ToolStripMenuItem();
            this.mLinkBitbucket = new System.Windows.Forms.ToolStripMenuItem();
            this.mLinkPP = new System.Windows.Forms.ToolStripMenuItem();
            this.mAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.mExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton4 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.mHomeDS = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mHGH = new System.Windows.Forms.ToolStripMenuItem();
            this.mWildEn4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mMoveset = new System.Windows.Forms.ToolStripMenuItem();
            this.mExperience = new System.Windows.Forms.ToolStripMenuItem();
            this.mEvolution = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mInGameTrade = new System.Windows.Forms.ToolStripMenuItem();
            this.bTSWPWTEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.aStatusBar1 = new NinfiaDSToolkit.Andi.Controls.AStatusBar();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.sbp_1 = new System.Windows.Forms.StatusBarPanel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbp_1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_dock1
            // 
            this.panel_dock1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.panel_dock1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_dock1.Location = new System.Drawing.Point(0, 0);
            this.panel_dock1.Name = "panel_dock1";
            this.panel_dock1.Size = new System.Drawing.Size(523, 436);
            dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient1.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
            tabGradient1.EndColor = System.Drawing.SystemColors.Control;
            tabGradient1.StartColor = System.Drawing.SystemColors.Control;
            tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin1.TabGradient = tabGradient1;
            autoHideStripSkin1.TextFont = new System.Drawing.Font("Segoe UI", 9F);
            dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
            tabGradient2.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(206)))), ((int)(((byte)(219)))));
            tabGradient2.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            tabGradient2.TextColor = System.Drawing.Color.White;
            dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
            dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
            tabGradient3.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(151)))), ((int)(((byte)(234)))));
            tabGradient3.StartColor = System.Drawing.SystemColors.Control;
            tabGradient3.TextColor = System.Drawing.Color.Black;
            dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
            dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
            dockPaneStripSkin1.TextFont = new System.Drawing.Font("Segoe UI", 9F);
            tabGradient4.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient4.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            tabGradient4.TextColor = System.Drawing.Color.White;
            dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
            tabGradient5.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient5.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient5.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
            dockPanelGradient3.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient3.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
            tabGradient6.EndColor = System.Drawing.SystemColors.ControlDark;
            tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient6.StartColor = System.Drawing.SystemColors.Control;
            tabGradient6.TextColor = System.Drawing.SystemColors.GrayText;
            dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
            tabGradient7.EndColor = System.Drawing.SystemColors.Control;
            tabGradient7.StartColor = System.Drawing.SystemColors.Control;
            tabGradient7.TextColor = System.Drawing.SystemColors.GrayText;
            dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
            dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
            dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
            this.panel_dock1.Skin = dockPanelSkin1;
            this.panel_dock1.TabIndex = 1;
            this.panel_dock1.Theme = this.vS2012LightTheme1;
            
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton4,
            this.toolStripSeparator7,
            this.toolStripDropDownButton2,
            this.toolStripSeparator5,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(523, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mInformation,
            this.testToolStripMenuItem,
            this.toolStripSeparator1,
            this.linksToolStripMenuItem,
            this.mAbout,
            this.toolStripSeparator2,
            this.mRestart,
            this.mExit});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // mInformation
            // 
            this.mInformation.Name = "mInformation";
            this.mInformation.Size = new System.Drawing.Size(137, 22);
            this.mInformation.Text = "Information";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mTestNarc,
            this.mTestBLZ,
            this.mTestOva9});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // mTestNarc
            // 
            this.mTestNarc.Name = "mTestNarc";
            this.mTestNarc.Size = new System.Drawing.Size(186, 22);
            this.mTestNarc.Text = "Narc Test";
            // 
            // mTestBLZ
            // 
            this.mTestBLZ.Name = "mTestBLZ";
            this.mTestBLZ.Size = new System.Drawing.Size(186, 22);
            this.mTestBLZ.Text = "BLZ Test";
            // 
            // mTestOva9
            // 
            this.mTestOva9.Name = "mTestOva9";
            this.mTestOva9.Size = new System.Drawing.Size(186, 22);
            this.mTestOva9.Text = "Ova9 Table View Test";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(134, 6);
            // 
            // linksToolStripMenuItem
            // 
            this.linksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mLinkGithub,
            this.mLinkBitbucket,
            this.mLinkPP});
            this.linksToolStripMenuItem.Name = "linksToolStripMenuItem";
            this.linksToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.linksToolStripMenuItem.Text = "Links";
            // 
            // mLinkGithub
            // 
            this.mLinkGithub.Name = "mLinkGithub";
            this.mLinkGithub.Size = new System.Drawing.Size(126, 22);
            this.mLinkGithub.Text = "Github";
            // 
            // mLinkBitbucket
            // 
            this.mLinkBitbucket.Name = "mLinkBitbucket";
            this.mLinkBitbucket.Size = new System.Drawing.Size(126, 22);
            this.mLinkBitbucket.Text = "Bitbucket";
            // 
            // mLinkPP
            // 
            this.mLinkPP.Name = "mLinkPP";
            this.mLinkPP.Size = new System.Drawing.Size(126, 22);
            this.mLinkPP.Text = "PP Forum";
            // 
            // mAbout
            // 
            this.mAbout.Name = "mAbout";
            this.mAbout.Size = new System.Drawing.Size(137, 22);
            this.mAbout.Text = "About";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(134, 6);
            // 
            // mRestart
            // 
            this.mRestart.Name = "mRestart";
            this.mRestart.Size = new System.Drawing.Size(137, 22);
            this.mRestart.Text = "Restart";
            // 
            // mExit
            // 
            this.mExit.Name = "mExit";
            this.mExit.Size = new System.Drawing.Size(137, 22);
            this.mExit.Text = "Exit";
            // 
            // toolStripDropDownButton4
            // 
            this.toolStripDropDownButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton4.Image")));
            this.toolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton4.Name = "toolStripDropDownButton4";
            this.toolStripDropDownButton4.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButton4.Text = "Misc";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mHomeDS,
            this.toolStripSeparator6,
            this.mHGH,
            this.mWildEn4,
            this.toolStripSeparator3,
            this.mMoveset,
            this.mExperience,
            this.mEvolution,
            this.toolStripSeparator4,
            this.mInGameTrade,
            this.bTSWPWTEditorToolStripMenuItem,
            this.itemEditorToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(44, 22);
            this.toolStripDropDownButton2.Text = "Tool";
            // 
            // mHomeDS
            // 
            this.mHomeDS.Name = "mHomeDS";
            this.mHomeDS.Size = new System.Drawing.Size(205, 22);
            this.mHomeDS.Text = "Home (NDS ROM Mode)";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(202, 6);
            // 
            // mHGH
            // 
            this.mHGH.Name = "mHGH";
            this.mHGH.Size = new System.Drawing.Size(205, 22);
            this.mHGH.Text = "Hidden Grotto";
            // 
            // mWildEn4
            // 
            this.mWildEn4.Name = "mWildEn4";
            this.mWildEn4.Size = new System.Drawing.Size(205, 22);
            this.mWildEn4.Text = "Wild Encounter Ex";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(202, 6);
            // 
            // mMoveset
            // 
            this.mMoveset.Name = "mMoveset";
            this.mMoveset.Size = new System.Drawing.Size(205, 22);
            this.mMoveset.Text = "Moveset Editor";
            // 
            // mExperience
            // 
            this.mExperience.Name = "mExperience";
            this.mExperience.Size = new System.Drawing.Size(205, 22);
            this.mExperience.Text = "Experience Editor";
            // 
            // mEvolution
            // 
            this.mEvolution.Name = "mEvolution";
            this.mEvolution.Size = new System.Drawing.Size(205, 22);
            this.mEvolution.Text = "Evolution Editor";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(202, 6);
            // 
            // mInGameTrade
            // 
            this.mInGameTrade.Name = "mInGameTrade";
            this.mInGameTrade.Size = new System.Drawing.Size(205, 22);
            this.mInGameTrade.Text = "In-Game Trade Editor";
            // 
            // bTSWPWTEditorToolStripMenuItem
            // 
            this.bTSWPWTEditorToolStripMenuItem.Name = "bTSWPWTEditorToolStripMenuItem";
            this.bTSWPWTEditorToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.bTSWPWTEditorToolStripMenuItem.Text = "BT/SW/PWT Editor";
            // 
            // itemEditorToolStripMenuItem
            // 
            this.itemEditorToolStripMenuItem.Name = "itemEditorToolStripMenuItem";
            this.itemEditorToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.itemEditorToolStripMenuItem.Text = "Item Editor";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(31, 22);
            this.toolStripLabel1.Text = "path";
            // 
            // aStatusBar1
            // 
            this.aStatusBar1.Location = new System.Drawing.Point(0, 436);
            this.aStatusBar1.Name = "aStatusBar1";
            this.aStatusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel2,
            this.statusBarPanel1,
            this.sbp_1});
            this.aStatusBar1.ShowPanels = true;
            this.aStatusBar1.Size = new System.Drawing.Size(523, 22);
            this.aStatusBar1.TabIndex = 0;
            this.aStatusBar1.Text = "Ready";
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Text = "Ready";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel1.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "-";
            this.statusBarPanel1.Width = 366;
            // 
            // sbp_1
            // 
            this.sbp_1.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.sbp_1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.sbp_1.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.sbp_1.Name = "sbp_1";
            this.sbp_1.Text = "NUM";
            this.sbp_1.Width = 40;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 458);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel_dock1);
            this.Controls.Add(this.aStatusBar1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbp_1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AStatusBar aStatusBar1;
        private System.Windows.Forms.StatusBarPanel sbp_1;
        private WeifenLuo.WinFormsUI.Docking.VS2012LightTheme vS2012LightTheme1;
        internal WeifenLuo.WinFormsUI.Docking.DockPanel panel_dock1;
        internal StatusBarPanel statusBarPanel1;
        internal StatusBarPanel statusBarPanel2;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem mInformation;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem linksToolStripMenuItem;
        private ToolStripMenuItem mLinkGithub;
        private ToolStripMenuItem mLinkBitbucket;
        private ToolStripMenuItem mLinkPP;
        private ToolStripMenuItem mAbout;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem mRestart;
        private ToolStripMenuItem mExit;
        private ToolStripDropDownButton toolStripDropDownButton2;
        private ToolStripMenuItem mHGH;
        private ToolStripMenuItem mWildEn4;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem mMoveset;
        private ToolStripMenuItem mExperience;
        private ToolStripMenuItem mEvolution;
        private ToolStripMenuItem mInGameTrade;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        internal ToolStripLabel toolStripLabel1;
        private ToolStripMenuItem testToolStripMenuItem;
        private ToolStripMenuItem mTestNarc;
        private ToolStripMenuItem mTestBLZ;
        private ToolStripMenuItem mTestOva9;
        private ToolStripMenuItem mHomeDS;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem bTSWPWTEditorToolStripMenuItem;
        private ToolStripMenuItem itemEditorToolStripMenuItem;
        private ToolStripDropDownButton toolStripDropDownButton4;
        private ToolStripSeparator toolStripSeparator7;

    }
}

