using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NinfiaDSToolkit.Andi.Controls.HexBox;
using NinfiaDSToolkit.Andi.Utils;
using NinfiaDSToolkit.Andi.Utils.DB;
using NinfiaDSToolkit.Andi.Utils.Narc;
using SourceGrid;
using WeifenLuo.WinFormsUI.Docking;
using ContentAlignment = DevAge.Drawing.ContentAlignment;

namespace NinfiaDSToolkit.Andi
{
    public partial class vExperience : DockContent
    {
        AndiNarcReader narc = new AndiNarcReader();
        Stream a = new MemoryStream();
        private bool checkgridfocus = true;

        public vExperience()
        {
            InitializeComponent();
            andiCustomTabControl1.Enabled = false;
            grid1.SelectionMode = GridSelectionMode.Row;
            grid1.Selection.EnableMultiSelection = false;
            grid1.MouseClick += Selection_SelectionChanged;
            grid1.KeyDown += Selection_SelectionChanged;
            grid1.KeyUp += Selection_SelectionChanged;

            grid1.Selection.FocusRowEntered += Selection_FocusRowEntered;
        }

        void grideventchanged()
        {
            try
            {
                label1.Text = grid1.Selection.ActivePosition.Row + "";
                numericUpDown1.Value = (long)grid1[grid1.Selection.ActivePosition.Row, 1].Value;
            }
            catch { }
        }

        private void Selection_FocusRowEntered(object sender, RowEventArgs e)
        {
            grideventchanged();

            if (!checkgridfocus)
            {
                andiListBox1.Focus();
                checkgridfocus = true;
            }
        }

        private void Selection_SelectionChanged(object sender, KeyEventArgs e)
        {
            grideventchanged();
            checkgridfocus = true;
        }

        private void Selection_SelectionChanged(object sender, MouseEventArgs e)
        {
            grideventchanged();
            checkgridfocus = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string path = "";

            OpenFileDialog openROMDialog = new OpenFileDialog();
            openROMDialog.Filter = "Any Files|*.*|Narc Files|*.*";

            if (openROMDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                path = openROMDialog.FileName;

            if (path != "")
            {
                FileStream a = new FileStream(path, FileMode.Open);

                a.Position = 0;
                byte[] bytee = new byte[4];

                a.Read(bytee, 0, 4);
                string check = System.Text.Encoding.ASCII.GetString(bytee);

                if (check != "NARC")
                {
                    MessageBox.Show("This Not NARC File, File Extension Signature is " + check + ", and is not NARC File!", "Error!");
                    return;
                }

                a.Close();

                narc.OpenData(path);

                andiListBox1.Items.Clear();
                string[] xxx = Database.GetCommonText(1);
                
                for (int i = 0; i < narc.FileCount; i++)
                {
                    if (i > 0 && i < 7)
                    {
                        andiListBox1.Items.Add(xxx[i-1]);
                    }
                    else
                    {
                        andiListBox1.Items.Add("Data " + i);
                    }
                }

                andiListBox1.SelectedIndex = 0;
                andiCustomTabControl1.Enabled = true;
            }
        }

        private void andiListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            a = new MemoryStream(narc.getdataselected(andiListBox1.SelectedIndex));
            checkgridfocus = false;
            loadhexview();
            loaddata();
        }

        private void loaddata()
        {
            int lenghtdata = (int) a.Length/4;
            long[] data = new long[lenghtdata];

            for (int i = 0; i < lenghtdata; i++)
            {
                byte[] temp = new byte[4];
                a.Position = i*4;
                a.Read(temp, 0, 4);
                data[i] = BitConverter.ToUInt32(temp, 0);
            }

            Build(grid1, lenghtdata);
            Fill(grid1,data);
        }

        void loadhexview()
        {
            DynamicFileByteProvider dynamicFileByteProvider = null;

            try
            {
                // try to open in write mode
                dynamicFileByteProvider = new DynamicFileByteProvider(a);
            }
            catch { }

            hexBox1.ByteProvider = dynamicFileByteProvider;

        }

        private static void Reset(Grid a, int m, int n)
        {
            a.Redim(0, 0);
            a.Redim(m + 1, n + 1);
            a.FixedRows = 1;
            a.FixedColumns = 1;
        }

        private static void Build(Grid a, int m, int n = 3)
        {
            try
            {
                Reset(a, m, n);

                SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();
                SourceGrid.Cells.Editors.TextBox editor = new SourceGrid.Cells.Editors.TextBox(typeof(string));
                view.BackColor = Color.White;


                for (int r = a.FixedRows; r < a.RowsCount; r++)
                {
                    a[r, 0] = new SourceGrid.Cells.RowHeader(r);
                }

                string[] headername = new[] { "Experience"};

                for (int c = a.FixedColumns; c < a.ColumnsCount; c++)
                {
                    SourceGrid.Cells.ColumnHeader header = new
                        SourceGrid.Cells.ColumnHeader(headername[c - 1]);
                    header.AutomaticSortEnabled = true;
                    header.View.TextAlignment = ContentAlignment.MiddleCenter;
                    a[0, c] = header;
                }

                SourceGrid.Cells.ColumnHeader header1 = new SourceGrid.Cells.ColumnHeader("Lv");

                header1.SortComparer = new SourceGrid.MultiColumnsComparer(1, 2, 3, 4);

                a[0, 0] = header1;

                for (int r = a.FixedRows; r < a.RowsCount; r++)
                {
                    for (int c = a.FixedColumns; c < a.ColumnsCount; c++)
                    {
                        a[r, c] = new SourceGrid.Cells.Cell("");
                        //a[r, c].Editor = editor;
                        a[r, c].View = view;
                    }
                }

                a.Update();
                a.AutoSizeCells();
            }
            catch { }
        }

        private static void Fill(Grid a, long[] data, bool multiline = true)
        {
            SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();
            SourceGrid.Cells.Editors.TextBox editor = new SourceGrid.Cells.Editors.TextBox(typeof(string));
            view.BackColor = Color.White;
            editor.Control.Multiline = multiline;

            for (int r = a.FixedRows; r < a.RowsCount; r++)
            {
                a[r, 1] = new SourceGrid.Cells.Cell(data[r - 1]);
                a[r, 1].View = view;
            }

            a.Update();
            a.Selection.Focus(new SourceGrid.Position(1, 1), true);
            a.AutoSizeCells();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int angka = int.Parse(label1.Text) - 1;
            long angka2 = (long) numericUpDown1.Value;

            a.Position = angka*4;
            a.Write(ByteConverter.ToByte(angka2,4),0,4);

            int r = angka + 1;
            SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();

            grid1[r, 1] = new SourceGrid.Cells.Cell(angka2);
            grid1[r, 1].View = view;
            grid1.Refresh();

            writebacknarc();
        }

        void writebacknarc()
        {
            byte[] temp = new byte[a.Length];

            a.Position = 0;
            a.Read(temp, 0, (int)a.Length);

            narc.ReplaceEntry(andiListBox1.SelectedIndex, temp.Length, temp);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save File";
            dialog.Filter = "narc file|*.narc";
            //dialog.FileName = "file_" + comboBox1.SelectedValue;
            //dialog.InitialDirectory = igtfpath;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //igtfpath = dialog.FileName.Replace(dialog.file, "");
                File.WriteAllBytes(dialog.FileName, this.narc.CachedData);
            }
        }
    }
}
