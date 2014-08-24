using NinfiaDSToolkit.Andi.Controls;
using NinfiaDSToolkit.Andi.Controls.HexBox;
using NinfiaDSToolkit.Andi.Controls.TabControl;

namespace NinfiaDSToolkit.Tools
{
    partial class vExperience
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
            this.bt_Open = new System.Windows.Forms.ToolStripButton();
            this.bt_Save = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.andiListBox1 = new NinfiaDSToolkit.Andi.Controls.AndiListBox();
            this.andiCustomTabControl1 = new NinfiaDSToolkit.Andi.Controls.TabControl.AndiCustomTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.nm_value = new System.Windows.Forms.NumericUpDown();
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
            ((System.ComponentModel.ISupportInitialize)(this.nm_value)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bt_Open,
            this.bt_Save});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(529, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bt_Open
            // 
            this.bt_Open.Image = global::NinfiaDSToolkit.Properties.Resources.folder_open;
            this.bt_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bt_Open.Name = "bt_Open";
            this.bt_Open.Size = new System.Drawing.Size(56, 22);
            this.bt_Open.Text = "Open";
            this.bt_Open.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // bt_Save
            // 
            this.bt_Save.Image = global::NinfiaDSToolkit.Properties.Resources.disk;
            this.bt_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(63, 22);
            this.bt_Save.Text = "Save ...";
            this.bt_Save.Click += new System.EventHandler(this.toolStripButton2_Click);
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
            this.splitContainer1.Size = new System.Drawing.Size(529, 400);
            this.splitContainer1.SplitterDistance = 154;
            this.splitContainer1.TabIndex = 1;
            // 
            // andiListBox1
            // 
            this.andiListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.andiListBox1.FormattingEnabled = true;
            this.andiListBox1.ItemHeight = 17;
            this.andiListBox1.Location = new System.Drawing.Point(-1, 0);
            this.andiListBox1.Name = "andiListBox1";
            this.andiListBox1.Size = new System.Drawing.Size(153, 400);
            this.andiListBox1.TabIndex = 2;
            this.andiListBox1.SelectedIndexChanged += new System.EventHandler(this.andiListBox1_SelectedIndexChanged);
            // 
            // andiCustomTabControl1
            // 
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
            this.andiCustomTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.andiCustomTabControl1.HotTrack = true;
            this.andiCustomTabControl1.Location = new System.Drawing.Point(0, 0);
            this.andiCustomTabControl1.Name = "andiCustomTabControl1";
            this.andiCustomTabControl1.SelectedIndex = 0;
            this.andiCustomTabControl1.Size = new System.Drawing.Size(371, 400);
            this.andiCustomTabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.nm_value);
            this.tabPage1.Controls.Add(this.grid1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(363, 375);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "List";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(324, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "0";
            // 
            // nm_value
            // 
            this.nm_value.Location = new System.Drawing.Point(6, 4);
            this.nm_value.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nm_value.Name = "nm_value";
            this.nm_value.Size = new System.Drawing.Size(131, 20);
            this.nm_value.TabIndex = 2;
            this.nm_value.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // grid1
            // 
            this.grid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(0, 29);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(363, 346);
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
            this.tabPage2.Size = new System.Drawing.Size(363, 375);
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
            this.hexBox1.Size = new System.Drawing.Size(357, 369);
            this.hexBox1.StringViewVisible = true;
            this.hexBox1.TabIndex = 1;
            this.hexBox1.UseFixedBytesPerLine = true;
            this.hexBox1.VScrollBarVisible = true;
            // 
            // vExperience
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 425);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "vExperience";
            this.Text = "vExperience";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.andiCustomTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_value)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private AndiListBox andiListBox1;
        private System.Windows.Forms.ToolStripButton bt_Open;
        private AndiCustomTabControl andiCustomTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.NumericUpDown nm_value;
        private SourceGrid.Grid grid1;
        private System.Windows.Forms.TabPage tabPage2;
        private HexBox hexBox1;
        private System.Windows.Forms.ToolStripButton bt_Save;
        private System.Windows.Forms.Label label1;
    }
}