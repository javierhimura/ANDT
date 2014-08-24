namespace NinfiaDSToolkit.Andi
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
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.andiListBox1 = new NinfiaDSToolkit.Andi.Controls.AndiListBox();
            this.andiCustomTabControl1 = new NinfiaDSToolkit.Andi.Controls.TabControl.AndiCustomTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pkm_1 = new NinfiaDSToolkit.Andi.Controls.ImageBox.AndiImageBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.andiImageComboBox1 = new NinfiaDSToolkit.Andi.Controls.AndiImageComboBox();
            this.grid1 = new SourceGrid.Grid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.hexBox1 = new NinfiaDSToolkit.Andi.Controls.HexBox.HexBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.andiCustomTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(579, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::NinfiaDSToolkit.Properties.Resources.folder_open;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(68, 22);
            this.toolStripButton1.Text = "Open ...";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::NinfiaDSToolkit.Properties.Resources.disk;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(79, 22);
            this.toolStripButton2.Text = "Save As ...";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.andiListBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.andiCustomTabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(579, 441);
            this.splitContainer1.SplitterDistance = 124;
            this.splitContainer1.TabIndex = 2;
            // 
            // andiListBox1
            // 
            this.andiListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.andiListBox1.FormattingEnabled = true;
            this.andiListBox1.ItemHeight = 17;
            this.andiListBox1.Location = new System.Drawing.Point(0, 0);
            this.andiListBox1.Name = "andiListBox1";
            this.andiListBox1.Size = new System.Drawing.Size(124, 441);
            this.andiListBox1.TabIndex = 0;
            this.andiListBox1.SelectedIndexChanged += new System.EventHandler(this.andiListBox1_SelectedIndexChanged);
            // 
            // andiCustomTabControl1
            // 
            this.andiCustomTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.andiCustomTabControl1.Controls.Add(this.tabPage1);
            this.andiCustomTabControl1.Controls.Add(this.tabPage2);
            this.andiCustomTabControl1.DisplayStyle = NinfiaDSToolkit.Andi.Controls.TabControl.TabStyle.VisualStudio;
            // 
            // 
            // 
            this.andiCustomTabControl1.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.andiCustomTabControl1.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            this.andiCustomTabControl1.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.andiCustomTabControl1.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.andiCustomTabControl1.DisplayStyleProvider.FocusTrack = false;
            this.andiCustomTabControl1.DisplayStyleProvider.HotTrack = true;
            this.andiCustomTabControl1.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.andiCustomTabControl1.DisplayStyleProvider.Opacity = 1F;
            this.andiCustomTabControl1.DisplayStyleProvider.Overlap = 7;
            this.andiCustomTabControl1.DisplayStyleProvider.Padding = new System.Drawing.Point(14, 1);
            this.andiCustomTabControl1.DisplayStyleProvider.ShowTabCloser = false;
            this.andiCustomTabControl1.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.andiCustomTabControl1.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.andiCustomTabControl1.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.andiCustomTabControl1.HotTrack = true;
            this.andiCustomTabControl1.Location = new System.Drawing.Point(3, 3);
            this.andiCustomTabControl1.Name = "andiCustomTabControl1";
            this.andiCustomTabControl1.SelectedIndex = 0;
            this.andiCustomTabControl1.Size = new System.Drawing.Size(445, 435);
            this.andiCustomTabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.tabPage1.Controls.Add(this.pkm_1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.andiImageComboBox1);
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
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(251, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(192, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // andiImageComboBox1
            // 
            this.andiImageComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.andiImageComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.andiImageComboBox1.FormattingEnabled = true;
            this.andiImageComboBox1.ItemHeight = 17;
            this.andiImageComboBox1.Location = new System.Drawing.Point(44, 5);
            this.andiImageComboBox1.Name = "andiImageComboBox1";
            this.andiImageComboBox1.Size = new System.Drawing.Size(142, 23);
            this.andiImageComboBox1.TabIndex = 1;
            this.andiImageComboBox1.SelectedIndexChanged += new System.EventHandler(this.andiImageComboBox1_SelectedIndexChanged);
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
            this.andiCustomTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controls.AndiListBox andiListBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private Controls.TabControl.AndiCustomTabControl andiCustomTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Controls.ImageBox.AndiImageBox pkm_1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private Controls.AndiImageComboBox andiImageComboBox1;
        private SourceGrid.Grid grid1;
        private System.Windows.Forms.TabPage tabPage2;
        private Controls.HexBox.HexBox hexBox1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}