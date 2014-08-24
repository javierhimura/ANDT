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
            this.aContextMenu1 = new NinfiaDSToolkit.Andi.Controls.AContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.btn_open_hgrotto = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem24 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.btn_exit = new System.Windows.Forms.MenuItem();
            this.aStatusBar1 = new NinfiaDSToolkit.Andi.Controls.AStatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.sbp_1 = new System.Windows.Forms.StatusBarPanel();
            this.panel_dock1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.vS2012LightTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2012LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbp_1)).BeginInit();
            this.SuspendLayout();
            // 
            // aContextMenu1
            // 
            this.aContextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.btn_open_hgrotto,
            this.menuItem19,
            this.menuItem18,
            this.menuItem11,
            this.menuItem15,
            this.menuItem17,
            this.menuItem2,
            this.menuItem24,
            this.menuItem13,
            this.menuItem12,
            this.menuItem3,
            this.menuItem16,
            this.btn_exit});
            this.menuItem1.Text = "&File";
            // 
            // btn_open_hgrotto
            // 
            this.btn_open_hgrotto.Index = 0;
            this.btn_open_hgrotto.Text = "Hidden Grotto (BW2)";
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 1;
            this.menuItem19.Text = "WildPokemonEx DPPt (DPPt)";
            this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 2;
            this.menuItem18.Text = "-";
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 3;
            this.menuItem11.Text = "Moveset Editor (All)";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 4;
            this.menuItem15.Text = "ExperienceTable Editor (All)";
            this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 5;
            this.menuItem17.Text = "Evolution and BaseEvolution Editor (All)";
            this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 6;
            this.menuItem2.Text = "-";
            // 
            // menuItem24
            // 
            this.menuItem24.Index = 7;
            this.menuItem24.Text = "Information";
            this.menuItem24.Click += new System.EventHandler(this.menuItem24_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 8;
            this.menuItem13.Text = "-";
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 9;
            this.menuItem12.Text = "Wiki";
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 10;
            this.menuItem3.Text = "-";
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 11;
            this.menuItem16.Text = "Restart";
            this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Index = 12;
            this.btn_exit.Text = "Keluar";
            // 
            // aStatusBar1
            // 
            this.aStatusBar1.Location = new System.Drawing.Point(0, 436);
            this.aStatusBar1.Name = "aStatusBar1";
            this.aStatusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.sbp_1});
            this.aStatusBar1.ShowPanels = true;
            this.aStatusBar1.Size = new System.Drawing.Size(523, 22);
            this.aStatusBar1.TabIndex = 0;
            this.aStatusBar1.Text = "Ready";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel1.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "-";
            this.statusBarPanel1.Width = 466;
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
            this.panel_dock1.ActiveContentChanged += new System.EventHandler(this.ActiveContentChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 458);
            this.Controls.Add(this.panel_dock1);
            this.Controls.Add(this.aStatusBar1);
            this.IsMdiContainer = true;
            this.Menu = this.aContextMenu1;
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbp_1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AContextMenu aContextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem btn_exit;
        private AStatusBar aStatusBar1;
        private System.Windows.Forms.StatusBarPanel sbp_1;
        private WeifenLuo.WinFormsUI.Docking.VS2012LightTheme vS2012LightTheme1;
        internal WeifenLuo.WinFormsUI.Docking.DockPanel panel_dock1;
        private MenuItem menuItem2;
        private MenuItem btn_open_hgrotto;
        internal StatusBarPanel statusBarPanel1;
        private MenuItem menuItem11;
        private MenuItem menuItem12;
        private MenuItem menuItem13;
        private MenuItem menuItem15;
        private MenuItem menuItem18;
        private MenuItem menuItem17;
        private MenuItem menuItem19;
        private MenuItem menuItem24;
        private MenuItem menuItem16;

    }
}

