namespace NinfiaDSToolkit.Tools
{
    partial class vWildEx4
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_Open = new System.Windows.Forms.ToolStripButton();
            this.btn_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.WeExList = new NinfiaDSToolkit.Andi.Controls.AndiListBox();
            this.TabC1 = new NinfiaDSToolkit.Andi.Controls.TabControl.AndiCustomTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pkm_1 = new NinfiaDSToolkit.Andi.Controls.ImageBox.AndiImageBox();
            this.cb_pkm = new NinfiaDSToolkit.Andi.Controls.AndiImageComboBox();
            this.grid1 = new SourceGrid.Grid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.hexBox1 = new NinfiaDSToolkit.Andi.Controls.HexBox.HexBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.TabC1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Open,
            this.btn_Save,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(579, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_Open
            // 
            this.btn_Open.Image = global::NinfiaDSToolkit.Properties.Resources.folder_open;
            this.btn_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(56, 22);
            this.btn_Open.Text = "Open";
            this.btn_Open.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Image = global::NinfiaDSToolkit.Properties.Resources.disk;
            this.btn_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(51, 22);
            this.btn_Save.Text = "Save";
            this.btn_Save.Click += new System.EventHandler(this.SaveFile_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(13, 22);
            this.toolStripLabel1.Text = "0";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.WeExList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TabC1);
            this.splitContainer1.Size = new System.Drawing.Size(579, 441);
            this.splitContainer1.SplitterDistance = 124;
            this.splitContainer1.TabIndex = 2;
            // 
            // WeExList
            // 
            this.WeExList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WeExList.FormattingEnabled = true;
            this.WeExList.ItemHeight = 17;
            this.WeExList.Location = new System.Drawing.Point(0, 0);
            this.WeExList.Name = "WeExList";
            this.WeExList.Size = new System.Drawing.Size(124, 441);
            this.WeExList.TabIndex = 0;
            this.WeExList.SelectedIndexChanged += new System.EventHandler(this.andiListBox1_SelectedIndexChanged);
            // 
            // TabC1
            // 
            this.TabC1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabC1.Controls.Add(this.tabPage1);
            this.TabC1.Controls.Add(this.tabPage2);
            this.TabC1.DisplayStyle = NinfiaDSToolkit.Andi.Controls.TabControl.TabStyle.VisualStudio;
            // 
            // 
            // 
            this.TabC1.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.TabC1.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            this.TabC1.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.TabC1.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.TabC1.DisplayStyleProvider.FocusTrack = false;
            this.TabC1.DisplayStyleProvider.HotTrack = true;
            this.TabC1.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TabC1.DisplayStyleProvider.Opacity = 1F;
            this.TabC1.DisplayStyleProvider.Overlap = 7;
            this.TabC1.DisplayStyleProvider.Padding = new System.Drawing.Point(14, 1);
            this.TabC1.DisplayStyleProvider.ShowTabCloser = false;
            this.TabC1.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.TabC1.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.TabC1.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.TabC1.HotTrack = true;
            this.TabC1.Location = new System.Drawing.Point(3, 3);
            this.TabC1.Name = "TabC1";
            this.TabC1.SelectedIndex = 0;
            this.TabC1.Size = new System.Drawing.Size(445, 435);
            this.TabC1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.tabPage1.Controls.Add(this.pkm_1);
            this.tabPage1.Controls.Add(this.cb_pkm);
            this.tabPage1.Controls.Add(this.grid1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(437, 410);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "List";
            // 
            // pkm_1
            // 
            this.pkm_1.AutoScroll = false;
            this.pkm_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pkm_1.IndexParent = 0;
            this.pkm_1.Location = new System.Drawing.Point(6, 0);
            this.pkm_1.Name = "pkm_1";
            this.pkm_1.Size = new System.Drawing.Size(32, 32);
            this.pkm_1.TabIndex = 17;
            // 
            // cb_pkm
            // 
            this.cb_pkm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_pkm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_pkm.FormattingEnabled = true;
            this.cb_pkm.ItemHeight = 17;
            this.cb_pkm.Location = new System.Drawing.Point(44, 5);
            this.cb_pkm.Name = "cb_pkm";
            this.cb_pkm.Size = new System.Drawing.Size(142, 23);
            this.cb_pkm.TabIndex = 1;
            this.cb_pkm.SelectedIndexChanged += new System.EventHandler(this.andiImageComboBox1_SelectedIndexChanged);
            // 
            // grid1
            // 
            this.grid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(4, 33);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(430, 374);
            this.grid1.TabIndex = 0;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.tabPage2.Controls.Add(this.hexBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(437, 410);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "HEX";
            // 
            // hexBox1
            // 
            this.hexBox1.ColumnInfoVisible = true;
            this.hexBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hexBox1.HexCasing = NinfiaDSToolkit.Andi.Controls.HexBox.HexCasing.Lower;
            this.hexBox1.LineInfoVisible = true;
            this.hexBox1.Location = new System.Drawing.Point(3, 3);
            this.hexBox1.Name = "hexBox1";
            this.hexBox1.ReadOnly = true;
            this.hexBox1.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox1.Size = new System.Drawing.Size(431, 404);
            this.hexBox1.StringViewVisible = true;
            this.hexBox1.TabIndex = 1;
            this.hexBox1.UseFixedBytesPerLine = true;
            this.hexBox1.VScrollBarVisible = true;
            // 
            // vWildEx4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 466);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "vWildEx4";
            this.Text = "WildEncounter Ex Gen 4";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.TabC1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_Open;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Andi.Controls.AndiListBox WeExList;
        private System.Windows.Forms.ToolStripButton btn_Save;
        private Andi.Controls.TabControl.AndiCustomTabControl TabC1;
        private System.Windows.Forms.TabPage tabPage1;
        private Andi.Controls.ImageBox.AndiImageBox pkm_1;
        private Andi.Controls.AndiImageComboBox cb_pkm;
        private SourceGrid.Grid grid1;
        private System.Windows.Forms.TabPage tabPage2;
        private Andi.Controls.HexBox.HexBox hexBox1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}