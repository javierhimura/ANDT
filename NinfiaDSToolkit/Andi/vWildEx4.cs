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
    public partial class vWildEx4 : DockContent
    {
        AndiNarcReader narc = new AndiNarcReader();
        Stream a = new MemoryStream();
        string[] pkmname = new string[1];
        private bool checkgridfocus = true;

        public vWildEx4()
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

        void griddatachanged()
        {
            try
            {
                toolStripLabel1.Text = grid1.Selection.ActivePosition.Row + "";
                andiImageComboBox1.Text = grid1[grid1.Selection.ActivePosition.Row, 1].Value.ToString();
            }
            catch { }
        }

        private void Selection_FocusRowEntered(object sender, RowEventArgs e)
        {
            griddatachanged();

            if (!checkgridfocus)
            {
                andiListBox1.Focus();
                checkgridfocus = true;
            }
        }

        private void Selection_SelectionChanged(object sender, KeyEventArgs e)
        {
            griddatachanged();
            checkgridfocus = true;
        }

        private void Selection_SelectionChanged(object sender, MouseEventArgs e)
        {
            griddatachanged();
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

                string[] extname = Database.GetCommonText(2);

                for (int i = 0; i < narc.FileCount; i++)
                {
                    andiListBox1.Items.Add(extname[i]);
                }

                //andiListBox1.Items.AddRange(MVGList.GetPokemonNameMVList());
                andiImageComboBox1.Items.Clear();
                pkmname = Database.GetPokemonName(4, 1);
                andiImageComboBox1.Items.AddRange(pkmname);

                andiListBox1.SelectedIndex = 0;
                andiCustomTabControl1.Enabled = true;
            }
        }

        private void andiListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int angka = andiListBox1.SelectedIndex;
            checkgridfocus = false;
            a = new MemoryStream(narc.getdataselected(angka));

            loadhexview();

            if (angka == 1 || angka == 11)
            {
                Build(grid1, 0, 2);
            }
            else
            {
                loaddata();
            }
        }

        private void loaddata()
        {
            int lenghtdata = (int)a.Length / 4;
            string[] data = new string[lenghtdata];

            for (int i = 0; i < lenghtdata; i++)
            {
                byte[] temp = new byte[4];
                a.Position = i * 4;
                a.Read(temp, 0, 4);
                data[i] = pkmname[BitConverter.ToUInt32(temp, 0)-1];
            }

            Build(grid1, lenghtdata);
            Fill(grid1, data);
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

                string[] headername = new[] { "Pokemon" };

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

        private static void Fill(Grid a, object[] data, bool multiline = true)
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

        private void andiImageComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pkm_1.Image = ImageIconHandler.setImagePictureBox(andiImageComboBox1.SelectedIndex+1);

            int angka = int.Parse(toolStripLabel1.Text) - 1;
            long angka2 = (long)andiImageComboBox1.SelectedIndex +1;

            a.Position = angka * 4;
            a.Write(NinfiaDSToolkit.Andi.Utils.ByteConverter.ToByte(angka2, 4), 0, 4);

            int r = angka + 1;
            SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();

            grid1[r, 1] = new SourceGrid.Cells.Cell(pkmname[angka2-1]);
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
