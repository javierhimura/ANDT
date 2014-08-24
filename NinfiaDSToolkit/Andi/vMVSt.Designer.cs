using NinfiaDSToolkit.Andi.Controls;
using NinfiaDSToolkit.Andi.Controls.HexBox;
using NinfiaDSToolkit.Andi.Controls.TabControl;

namespace NinfiaDSToolkit.Andi
{
    partial class vMVSt
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
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bt_Open = new System.Windows.Forms.ToolStripButton();
            this.bt_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cb_ver = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.label5 = new System.Windows.Forms.ToolStripLabel();
            this.label4 = new System.Windows.Forms.ToolStripLabel();
            this.label3 = new System.Windows.Forms.ToolStripLabel();
            this.label2 = new System.Windows.Forms.ToolStripLabel();
            this.label1 = new System.Windows.Forms.ToolStripLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LB_List = new NinfiaDSToolkit.Andi.Controls.AndiListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.mTab1 = new NinfiaDSToolkit.Andi.Controls.TabControl.AndiCustomTabControl();
            this.tab_list = new System.Windows.Forms.TabPage();
            this.IB_pokemon = new NinfiaDSToolkit.Andi.Controls.ImageBox.AndiImageBox();
            this.bt_remove = new System.Windows.Forms.Button();
            this.bt_add = new System.Windows.Forms.Button();
            this.nm_lv = new System.Windows.Forms.NumericUpDown();
            this.cb_pokemon = new NinfiaDSToolkit.Andi.Controls.AndiImageComboBox();
            this.grid1 = new SourceGrid.Grid();
            this.tab_hex = new System.Windows.Forms.TabPage();
            this.hexBox1 = new NinfiaDSToolkit.Andi.Controls.HexBox.HexBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.mTab1.SuspendLayout();
            this.tab_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_lv)).BeginInit();
            this.tab_hex.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bt_Open,
            this.bt_Save,
            this.toolStripSeparator3,
            this.cb_ver,
            this.toolStripSeparator1,
            this.label5,
            this.label4,
            this.label3,
            this.label2,
            this.label1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(647, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bt_Open
            // 
            this.bt_Open.Image = global::NinfiaDSToolkit.Properties.Resources.folder_open;
            this.bt_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bt_Open.Name = "bt_Open";
            this.bt_Open.Size = new System.Drawing.Size(68, 22);
            this.bt_Open.Text = "Open ...";
            // 
            // bt_Save
            // 
            this.bt_Save.Image = global::NinfiaDSToolkit.Properties.Resources.disk;
            this.bt_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(79, 22);
            this.bt_Save.Text = "Save As ...";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // cb_ver
            // 
            this.cb_ver.Items.AddRange(new object[] {
            "Auto Detection",
            "DP",
            "PtHGSS",
            "BW",
            "BW 2"});
            this.cb_ver.Name = "cb_ver";
            this.cb_ver.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // label5
            // 
            this.label5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 22);
            this.label5.Text = "0";
            // 
            // label4
            // 
            this.label4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 22);
            this.label4.Text = "0";
            // 
            // label3
            // 
            this.label3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 22);
            this.label3.Text = "0";
            // 
            // label2
            // 
            this.label2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 22);
            this.label2.Text = "index : ";
            // 
            // label1
            // 
            this.label1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 22);
            this.label1.Text = "0";
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
            this.splitContainer1.Panel1.Controls.Add(this.LB_List);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mTab1);
            this.splitContainer1.Size = new System.Drawing.Size(647, 447);
            this.splitContainer1.SplitterDistance = 162;
            this.splitContainer1.TabIndex = 2;
            // 
            // LB_List
            // 
            this.LB_List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_List.FormattingEnabled = true;
            this.LB_List.ItemHeight = 17;
            this.LB_List.Location = new System.Drawing.Point(4, 0);
            this.LB_List.Name = "LB_List";
            this.LB_List.Size = new System.Drawing.Size(157, 426);
            this.LB_List.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(4, 426);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(157, 20);
            this.textBox1.TabIndex = 3;
            // 
            // mTab1
            // 
            this.mTab1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mTab1.Controls.Add(this.tab_list);
            this.mTab1.Controls.Add(this.tab_hex);
            this.mTab1.DisplayStyle = NinfiaDSToolkit.Andi.Controls.TabControl.TabStyle.VisualStudio;
            // 
            // 
            // 
            this.mTab1.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.mTab1.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            this.mTab1.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.mTab1.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.mTab1.DisplayStyleProvider.FocusTrack = false;
            this.mTab1.DisplayStyleProvider.HotTrack = true;
            this.mTab1.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mTab1.DisplayStyleProvider.Opacity = 1F;
            this.mTab1.DisplayStyleProvider.Overlap = 7;
            this.mTab1.DisplayStyleProvider.Padding = new System.Drawing.Point(14, 1);
            this.mTab1.DisplayStyleProvider.ShowTabCloser = false;
            this.mTab1.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.mTab1.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.mTab1.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.mTab1.HotTrack = true;
            this.mTab1.Location = new System.Drawing.Point(1, 1);
            this.mTab1.Name = "mTab1";
            this.mTab1.SelectedIndex = 0;
            this.mTab1.Size = new System.Drawing.Size(480, 446);
            this.mTab1.TabIndex = 0;
            // 
            // tab_list
            // 
            this.tab_list.AutoScroll = true;
            this.tab_list.AutoScrollMinSize = new System.Drawing.Size(0, 421);
            this.tab_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.tab_list.Controls.Add(this.IB_pokemon);
            this.tab_list.Controls.Add(this.bt_remove);
            this.tab_list.Controls.Add(this.bt_add);
            this.tab_list.Controls.Add(this.nm_lv);
            this.tab_list.Controls.Add(this.cb_pokemon);
            this.tab_list.Controls.Add(this.grid1);
            this.tab_list.Location = new System.Drawing.Point(4, 21);
            this.tab_list.Name = "tab_list";
            this.tab_list.Padding = new System.Windows.Forms.Padding(3);
            this.tab_list.Size = new System.Drawing.Size(472, 421);
            this.tab_list.TabIndex = 0;
            this.tab_list.Text = "List";
            // 
            // IB_pokemon
            // 
            this.IB_pokemon.AutoScroll = false;
            this.IB_pokemon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IB_pokemon.IndexParent = 0;
            this.IB_pokemon.Location = new System.Drawing.Point(6, 0);
            this.IB_pokemon.Name = "IB_pokemon";
            this.IB_pokemon.Size = new System.Drawing.Size(32, 32);
            this.IB_pokemon.TabIndex = 17;
            // 
            // bt_remove
            // 
            this.bt_remove.Location = new System.Drawing.Point(330, 5);
            this.bt_remove.Name = "bt_remove";
            this.bt_remove.Size = new System.Drawing.Size(64, 23);
            this.bt_remove.TabIndex = 4;
            this.bt_remove.Text = "Remove";
            this.bt_remove.UseVisualStyleBackColor = true;
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(271, 5);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(53, 23);
            this.bt_add.TabIndex = 3;
            this.bt_add.Text = "Add";
            this.bt_add.UseVisualStyleBackColor = true;
            // 
            // nm_lv
            // 
            this.nm_lv.Location = new System.Drawing.Point(192, 6);
            this.nm_lv.Name = "nm_lv";
            this.nm_lv.Size = new System.Drawing.Size(73, 20);
            this.nm_lv.TabIndex = 2;
            // 
            // cb_pokemon
            // 
            this.cb_pokemon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_pokemon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_pokemon.FormattingEnabled = true;
            this.cb_pokemon.ItemHeight = 17;
            this.cb_pokemon.Location = new System.Drawing.Point(44, 5);
            this.cb_pokemon.Name = "cb_pokemon";
            this.cb_pokemon.Size = new System.Drawing.Size(142, 23);
            this.cb_pokemon.TabIndex = 1;
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
            this.grid1.Size = new System.Drawing.Size(462, 382);
            this.grid1.TabIndex = 0;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // tab_hex
            // 
            this.tab_hex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.tab_hex.Controls.Add(this.hexBox1);
            this.tab_hex.Location = new System.Drawing.Point(4, 21);
            this.tab_hex.Name = "tab_hex";
            this.tab_hex.Padding = new System.Windows.Forms.Padding(3);
            this.tab_hex.Size = new System.Drawing.Size(472, 421);
            this.tab_hex.TabIndex = 1;
            this.tab_hex.Text = "HEX";
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
            this.hexBox1.Size = new System.Drawing.Size(466, 415);
            this.hexBox1.StringViewVisible = true;
            this.hexBox1.TabIndex = 1;
            this.hexBox1.UseFixedBytesPerLine = true;
            this.hexBox1.VScrollBarVisible = true;
            // 
            // vMVSt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(647, 472);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "vMVSt";
            this.Text = "vMVSt";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.mTab1.ResumeLayout(false);
            this.tab_list.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nm_lv)).EndInit();
            this.tab_hex.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bt_Open;
        private System.Windows.Forms.ToolStripButton bt_Save;
        private AndiListBox LB_List;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBox1;
        private AndiCustomTabControl mTab1;
        private System.Windows.Forms.TabPage tab_list;
        private System.Windows.Forms.TabPage tab_hex;
        private SourceGrid.Grid grid1;
        private HexBox hexBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox cb_ver;
        private System.Windows.Forms.ToolStripLabel label4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private AndiImageComboBox cb_pokemon;
        private System.Windows.Forms.NumericUpDown nm_lv;
        private System.Windows.Forms.ToolStripLabel label3;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.Button bt_remove;
        private System.Windows.Forms.ToolStripLabel label2;
        private System.Windows.Forms.ToolStripLabel label1;
        private Controls.ImageBox.AndiImageBox IB_pokemon;
        private System.Windows.Forms.ToolStripLabel label5;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}