using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NinfiaDSToolkit.Andi.Controls.HexBox;
using NinfiaDSToolkit.Andi.Utils;
using NinfiaDSToolkit.Andi.Utils.DB;
using NinfiaDSToolkit.Andi.Utils.Narc;
using SourceGrid;
using WeifenLuo.WinFormsUI.Docking;
using ByteConverter = NinfiaDSToolkit.Andi.Utils.ByteConverter;
using ContentAlignment = DevAge.Drawing.ContentAlignment;

namespace NinfiaDSToolkit.Andi
{
    public partial class vEvolutions : DockContent
    {
        AndiNarcReader[] Narc = new AndiNarcReader[2];

        private bool narcopen2 = false;
        private bool checkgridfocus = true;

        Stream a = new MemoryStream();
        Stream b = new MemoryStream();
        string[] pkmname = new string[1];
        string[] itemname = new string[1];
        string[] movename = new string[1];
        string[] methodname = new string[1];
        string[] pkmnamecom = new string[1];
        private bool checkstate = true;

        GameFormat gameformat = new GameFormat();
        GameVer gamever = new GameVer();

        public enum GameVer
        {
            DP, PtHGSS, BW, BW2, none
        }

        public enum GameFormat
        {
            gen4, gen5, none
        }

        public vEvolutions()
        {
            InitializeComponent();
            toolStripComboBox1.SelectedIndex = 0;
            andiCustomTabControl1.Enabled = false;
            grid1.SelectionMode = GridSelectionMode.Row;
            grid1.Selection.EnableMultiSelection = false;
            grid1.MouseClick += Selection_SelectionChanged;
            grid1.KeyDown += Selection_SelectionChanged;
            grid1.KeyUp += Selection_SelectionChanged;
            grid1.Selection.FocusRowEntered += Selection_FocusRowEntered;
        }

        private void Selection_FocusRowEntered(object sender, RowEventArgs e)
        {
            gridevent();

            if (!checkgridfocus)
            {
                andiListBox1.Focus();
                checkgridfocus = true;
            }
        }

        private void Selection_SelectionChanged(object sender, KeyEventArgs e)
        {
            gridevent();
            checkgridfocus = true;
        }

        private void Selection_SelectionChanged(object sender, MouseEventArgs e)
        {
            gridevent();
            checkgridfocus = true;
        }

        void gridevent()
        {
            try
            {
                checkstate = false;
                toolStripLabel3.Text = grid1.Selection.ActivePosition.Row + "";

                andiImageComboBox3.Text = grid1[grid1.Selection.ActivePosition.Row, 2] + "";
                andiImageComboBox2.Text = grid1[grid1.Selection.ActivePosition.Row, 1] + "";

                switch (gameformat)
                {
                    case GameFormat.gen4:
                        switch (andiImageComboBox3.SelectedIndex)
                        {
                            case 4:
                            case 22:
                            case 23:
                            case 15:
                                andiImageComboBox1.Enabled = false;
                                numericUpDown1.Value = int.Parse(grid1[grid1.Selection.ActivePosition.Row, 3].Value.ToString());
                                break;
                            case 6:
                            case 7:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                            case 21:
                            default:
                                andiImageComboBox1.Enabled = true;
                                andiImageComboBox1.Text = grid1[grid1.Selection.ActivePosition.Row, 3] + "";
                                numericUpDown1.Value = 0;
                                break;
                        }
                        break;
                    case GameFormat.gen5:
                        switch (andiImageComboBox3.SelectedIndex)
                        {
                            case 4:
                            case 23:
                            case 24:
                            case 16:
                                numericUpDown1.Value = int.Parse(grid1[grid1.Selection.ActivePosition.Row, 3].Value.ToString());
                                break;
                            case 6:
                            case 8:
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                            case 21:
                            case 22:
                            default:
                                andiImageComboBox1.Text = grid1[grid1.Selection.ActivePosition.Row, 3] + "";
                                //numericUpDown1.Value = andiImageComboBox1.SelectedIndex;
                                break;
                        }
                        break;
                }

                checkstate = true;
                //numericUpDown1.Value = (int)grid1[grid1.Selection.ActivePosition.Row, 3].Value;
                //andiImageComboBox1.Text = grid1[grid1.Selection.ActivePosition.Row, 2] + "";
            }
            catch { }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string path = "", path2 ="";

            OpenFileDialog openROMDialog = new OpenFileDialog();

            openROMDialog.Title = "Open Evolution Narc Files";
            openROMDialog.Filter = "Any Files|*.*|Narc Files|*.*";

            OpenFileDialog openROMDialog2 = new OpenFileDialog();

            openROMDialog2.Title = "Open Baby Pokemon / BaseEvolution Narc Files";
            openROMDialog2.Filter = "Any Files|*.*|Narc Files|*.*";

            if (openROMDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                path = openROMDialog.FileName;

            if (openROMDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                path2 = openROMDialog2.FileName;

            if (path2 != "")
            {
                FileStream a = new FileStream(path2, FileMode.Open);

                a.Position = 0;
                byte[] bytee = new byte[4];

                a.Read(bytee, 0, 4);
                string check = System.Text.Encoding.ASCII.GetString(bytee);

                if (check != "NARC")
                {
                    MessageBox.Show(
                        "This Not NARC File, File Extension Signature is " + check + ", and is not NARC File!", "Error!");
                    narcopen2 = false;
                    a.Close();
                    andiImageComboBox4.Enabled = false;
                }
                else
                {
                    a.Close();
                    andiImageComboBox4.Enabled = true;
                    Narc[1] = new AndiNarcReader();
                    Narc[1].OpenData(path2);
                    narcopen2 = true;
                }
            }
            else
            {
                narcopen2 = false;
                andiImageComboBox4.Enabled = false;
            }


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
                andiCustomTabControl1.Enabled = true;
                Narc[0] = new AndiNarcReader();
                Narc[0].OpenData(path);
                toolStripLabel1.Text = Narc[0].FileCount + "";
                andiListBox1.Items.Clear();
                andiImageComboBox3.Items.Clear();

                switch (toolStripComboBox1.SelectedIndex)
                {
                    case 0:
                        MVGList.Load(12);
                        pkmname = MVGList.GetPokemonNameMVList();
                        methodname = Database.GetCommonText(4);
                        gameformat = GameFormat.gen4;
                        itemname = Database.GetItemName(21);
                        break;
                    case 1:
                        MVGList.Load(14);
                        pkmname = MVGList.GetPokemonNameMVList();
                        methodname = Database.GetCommonText(4);
                        gameformat = GameFormat.gen4;
                        itemname = Database.GetItemName(21);
                        break;
                    case 2:
                        MVGList.Load(17);
                        pkmname = MVGList.GetPokemonNameMVList();
                        methodname = Database.GetCommonText(3);
                        gameformat = GameFormat.gen5;
                        itemname = Database.GetItemName(21);
                        break;
                    case 3:
                        MVGList.Load(21);
                        pkmname = MVGList.GetPokemonNameMVList();
                        methodname = Database.GetCommonText(3);
                        gameformat = GameFormat.gen5;
                        itemname = Database.GetItemName(21);
                        break;
                }
                
                andiImageComboBox2.Items.Clear();
                andiImageComboBox4.Items.Clear();
                andiImageComboBox3.Items.AddRange(methodname);
                andiListBox1.Items.AddRange(pkmname);

                List<string> n = new List<string>();
                List<string> m = new List<string>();

                n.Add("");
                m.Add("");
                switch (gameformat)
                {
                    case GameFormat.gen4:
                        n.AddRange(Database.GetPokemonName(4));
                        m.AddRange(MVGList.GetMoveList(4));
                        break;
                    case GameFormat.gen5:
                        n.AddRange(Database.GetPokemonName(5));
                        m.AddRange(MVGList.GetMoveList(5));
                        break;
                }

                movename = m.ToArray();
                pkmnamecom = n.ToArray();
                andiImageComboBox2.Items.AddRange(pkmnamecom);
                andiImageComboBox4.Items.AddRange(pkmnamecom);
                andiListBox1.SelectedIndex = 0;
            }
        }

        private void andiListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkgridfocus = false;
            int angka = andiListBox1.SelectedIndex;

            a = new MemoryStream(Narc[0].getdataselected(angka));

            if (narcopen2)
            {
                bool checkstate = false;

                if (gameformat == GameFormat.gen4)
                {
                    if (angka < 494)
                    {
                        andiImageComboBox4.Enabled = true;
                        b = new MemoryStream(Narc[1].getdataselected(angka));
                        checkstate = true;
                    }
                    else
                    {
                        andiImageComboBox4.Text = "None";
                        andiImageComboBox4.Enabled = false;
                    }
                }
                else
                {
                    if (angka < 650)
                    {
                        andiImageComboBox4.Enabled = true;
                        b = new MemoryStream(Narc[1].getdataselected(angka));
                        checkstate = true;
                    }
                    else
                    {
                        andiImageComboBox4.Text = "None";
                        andiImageComboBox4.Enabled = false;
                    }
                }

                if (checkstate)
                {
                    byte[] data2 = new byte[2];
                    b.Position = 0;
                    b.Read(data2, 0, 2);

                    andiImageComboBox4.SelectedIndex = BitConverter.ToUInt16(data2, 0);
                }
            }

            toolStripLabel1.Text = Narc[0].FileCount + "/" + (andiListBox1.SelectedIndex + 1);
            loadhexview();
            loaddatalist();
        }

        private void loaddatalist()
        {
            int count1 = (int) a.Length/6;
            int count2 = 0;

            object[,] datatemp1 = new object[count1,3];

            for (int i = 0; i < count1; i++)
            {
                byte[] data = new byte[2];
                a.Position = i*6+4;
                a.Read(data, 0, 2);
                datatemp1[i, 0] = BitConverter.ToUInt16(data, 0);

                a.Position = i * 6 + 0;
                a.Read(data, 0, 2);
                datatemp1[i, 1] = BitConverter.ToUInt16(data, 0);

                if (BitConverter.ToUInt16(data, 0) == 0)
                {
                    count2 ++;
                }

                toolStripLabel2.Text = (count1-count2) + "/" + count1;

                a.Position = i * 6 + 2;
                a.Read(data, 0, 2);
                datatemp1[i, 2] = BitConverter.ToUInt16(data, 0);
            }

            Build(grid1,count1);
            Fill(grid1,datatemp1);
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

        private void andiImageComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = int.Parse(toolStripLabel3.Text)-1;

            reloadalldata();

            if (checkstate)
            {
                WriteMethod(index, andiImageComboBox3.SelectedIndex);

                try
                {
                    grid1[index + 1, 2] = new SourceGrid.Cells.Cell(andiImageComboBox3.Text);
                    SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();
                    grid1.AutoSizeCells();
                    grid1[index + 1, 2].View = view;
                    grid1.Refresh();
                }
                catch { }

                andiImageComboBox1.SelectedIndex = 0;

                if (andiImageComboBox3.SelectedIndex == 0)
                {
                    andiImageComboBox1.SelectedIndex = 0;
                    WriteRequestment(index, 0);
                    andiImageComboBox2.SelectedIndex = 0;
                    WritePokemonEv(index, 0);
                }
                
                writebacknarc();
            }
        }

        void WriteMethod(int index, int off)
        {
            byte[] data = ByteConverter.ToByte(off, 2);
            a.Position = (index * 6) + 0 * 2;
            a.Write(data,0,2);
        }

        void WriteRequestment(int index, int off)
        {
            byte[] data = ByteConverter.ToByte(off, 2);
            a.Position = (index * 6) + 0 * 2 + 2;
            a.Write(data, 0, 2);
        }
        void WritePokemonEv(int index, int off)
        {
            byte[] data = ByteConverter.ToByte(off, 2);
            a.Position = (index * 6) + 0 * 2 + 4;
            a.Write(data, 0, 2);
        }

        void reloadalldata()
        {
            andiImageComboBox1.Enabled = true;
            numericUpDown1.Enabled = true;

            switch (gameformat)
            {
                case GameFormat.gen4:
                    switch (andiImageComboBox3.SelectedIndex)
                    {
                        case 4:
                        case 22:
                        case 23:
                            numericUpDown1.Maximum = 100;
                            andiImageComboBox1.Items.Clear();
                            andiImageComboBox1.Text = "none, level value";
                            andiImageComboBox1.Items.Add("none, level value");
                            andiImageComboBox1.Enabled = false;
                            break;
                        case 15:
                            numericUpDown1.Maximum = 255;
                            andiImageComboBox1.Items.Clear();
                            andiImageComboBox1.Text = "none, Hapinness value";
                            andiImageComboBox1.Items.Add("none, Hapinness value");
                            andiImageComboBox1.Enabled = false;
                            break;
                        case 6:
                        case 7:
                        case 16:
                        case 17:
                        case 18:
                        case 19:
                            andiImageComboBox1.Items.Clear();
                            andiImageComboBox1.Items.AddRange(itemname);
                            numericUpDown1.Enabled = false;
                            break;
                        case 20:
                            andiImageComboBox1.Items.Clear();
                            andiImageComboBox1.Items.AddRange(movename);
                            numericUpDown1.Enabled = false;
                            break;
                        case 21:
                            andiImageComboBox1.Items.Clear();
                            andiImageComboBox1.Items.AddRange(pkmname);
                            numericUpDown1.Enabled = false;
                            break;
                        default:
                            andiImageComboBox1.Items.Clear();
                            andiImageComboBox1.Text = "None";
                            andiImageComboBox1.Items.Add("none");
                            andiImageComboBox1.Enabled = false;
                            numericUpDown1.Value = 0;
                            numericUpDown1.Enabled = false;
                            break;
                    }
                    break;
                case GameFormat.gen5:
                    switch (andiImageComboBox3.SelectedIndex)
                    {
                        case 4:
                        case 23:
                        case 24:
                            numericUpDown1.Maximum = 100;
                            andiImageComboBox1.Items.Clear();
                            andiImageComboBox1.Text = "none, level value";
                            andiImageComboBox1.Items.Add("none, level value");
                            andiImageComboBox1.Enabled = false;
                            break;
                        case 16:
                            numericUpDown1.Maximum = 255;
                            andiImageComboBox1.Items.Clear();
                            andiImageComboBox1.Text = "none, Hapinness value";
                            andiImageComboBox1.Items.Add("none, Hapinness value");
                            andiImageComboBox1.Enabled = false;
                            break;
                        case 6:
                        case 8:
                        case 17:
                        case 18:
                        case 19:
                        case 20:
                            andiImageComboBox1.Items.Clear();
                            andiImageComboBox1.Items.AddRange(itemname);
                            numericUpDown1.Enabled = false;
                            break;
                        case 21:
                            andiImageComboBox1.Items.Clear();
                            andiImageComboBox1.Items.AddRange(movename);
                            numericUpDown1.Enabled = false;
                            break;
                        case 22:
                            andiImageComboBox1.Items.Clear();
                            andiImageComboBox1.Items.AddRange(pkmname);
                            numericUpDown1.Enabled = false;
                            break;
                        default:
                            andiImageComboBox1.Items.Clear();
                            andiImageComboBox1.Text = "None";
                            andiImageComboBox1.Items.Add("none");
                            andiImageComboBox1.Enabled = false;
                            numericUpDown1.Value = 0;
                            numericUpDown1.Enabled = false;
                            break;
                    }
                    break;
            }
            if (checkstate)
            {
                andiImageComboBox1.SelectedIndex = 0;
            }
            //
        }

        #region Filling Grid
        private void Reset(Grid a, int m, int n)
        {
            a.Redim(0, 0);
            a.Redim(m + 1, n + 1);
            a.FixedRows = 1;
            a.FixedColumns = 1;
        }

        private void Build(Grid a, int m, int n = 3)
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

                string[] headername = new[] { "Evolve Into", "Method", "Requestment" };

                for (int c = a.FixedColumns; c < a.ColumnsCount; c++)
                {
                    SourceGrid.Cells.ColumnHeader header = new
                        SourceGrid.Cells.ColumnHeader(headername[c - 1]);
                    header.AutomaticSortEnabled = true;
                    header.View.TextAlignment = ContentAlignment.MiddleCenter;
                    a[0, c] = header;
                }

                SourceGrid.Cells.ColumnHeader header1 = new SourceGrid.Cells.ColumnHeader("#");

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

        private void Fill(Grid a, object[,] data, bool multiline = true)
        {
            SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();
            SourceGrid.Cells.Editors.TextBox editor = new SourceGrid.Cells.Editors.TextBox(typeof(string));
            view.BackColor = Color.White;
            editor.Control.Multiline = multiline;

            for (int r = a.FixedRows; r < a.RowsCount; r++)
            {
                a[r, 1] = new SourceGrid.Cells.Cell(pkmnamecom[int.Parse(data[r - 1,0].ToString())]);
                a[r, 2] = new SourceGrid.Cells.Cell(methodname[int.Parse(data[r - 1, 1].ToString())]);
                switch (gameformat)
                {
                    case GameFormat.gen4:
                        switch (int.Parse(data[r - 1, 1].ToString()))
                        {
                            case 4:
                            case 22:
                            case 23:
                            case 15:
                                a[r, 3] = new SourceGrid.Cells.Cell(data[r - 1,2]);
                                break;
                            case 6:
                            case 7:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                                a[r, 3] = new SourceGrid.Cells.Cell(itemname[int.Parse(data[r - 1, 2].ToString())]);
                                break;
                            case 20:
                                a[r, 3] = new SourceGrid.Cells.Cell(movename[int.Parse(data[r - 1, 2].ToString())]);
                                break;
                            case 21:
                                a[r, 3] = new SourceGrid.Cells.Cell(pkmname[int.Parse(data[r - 1, 2].ToString())]);
                                break;
                            default:
                                a[r, 3] = new SourceGrid.Cells.Cell("None");
                                break;
                        }
                        break;
                    case GameFormat.gen5:
                        switch (int.Parse(data[r - 1, 1].ToString()))
                        {
                            case 4:
                            case 23:
                            case 24:
                            case 16:
                                a[r, 3] = new SourceGrid.Cells.Cell(data[r - 1, 2]);
                                break;
                            case 6:
                            case 8:
                            case 17:
                            case 18:
                            case 19:
                            case 20:
                                a[r, 3] = new SourceGrid.Cells.Cell(itemname[int.Parse(data[r - 1, 2].ToString())]);
                                break;
                            case 21:
                                a[r, 3] = new SourceGrid.Cells.Cell(movename[int.Parse(data[r - 1, 2].ToString())]);
                                break;
                            case 22:
                                a[r, 3] = new SourceGrid.Cells.Cell(pkmname[int.Parse(data[r - 1, 2].ToString())]);
                                break;
                            default:
                                a[r, 3] = new SourceGrid.Cells.Cell("None");
                                break;
                        }
                        break;
                }
                
                a[r, 1].View = view;
                a[r, 2].View = view;
                a[r, 3].View = view;

                //for (int c = a.FixedRows; c < a.ColumnsCount; c++)
                //{
                //   a[r, c] = new SourceGrid.Cells.Cell(data[r - 1, c - 1]);
                //a[r, c].Editor = editor;
                //   a[r, c].View = view;
                //}
            }

            a.Update();
            a.Selection.Focus(new SourceGrid.Position(1, 1), true);
            a.AutoSizeCells();

        }
        #endregion

        private void andiImageComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = int.Parse(toolStripLabel3.Text) - 1;

            if (checkstate)
            {
                switch (andiImageComboBox3.SelectedIndex)
                {
                    case 4:
                    case 23:
                    case 24:
                    case 16:
                        break;
                    case 6:
                    case 8:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                    case 21:
                    case 22:
                        WriteRequestment(index, andiImageComboBox1.SelectedIndex);
                        numericUpDown1.Value = andiImageComboBox1.SelectedIndex;
                        break;
                    default:
                        WriteRequestment(index, 0);
                        break;
                }

                try
                {
                    switch (andiImageComboBox3.SelectedIndex)
                    {
                        case 4:
                        case 23:
                        case 24:
                        case 16:
                            break;
                        default:
                            grid1[index + 1, 3] = new SourceGrid.Cells.Cell(andiImageComboBox1.Text);
                            SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();
                            grid1.AutoSizeCells();
                            grid1[index + 1, 3].View = view;
                            grid1.Refresh();
                            break;
                    }
                }
                catch { }
                writebacknarc();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int index = int.Parse(toolStripLabel3.Text) - 1;
            if (checkstate)
            {
                switch (andiImageComboBox3.SelectedIndex)
                {
                    case 4:
                    case 23:
                    case 24:
                    case 16:
                        WriteRequestment(index, (int) numericUpDown1.Value);
                        break;
                    case 6:
                    case 8:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                    case 21:
                    case 22:
                        break;
                    default:
                        WriteRequestment(index, 0);
                        break;
                }
                try
                {
                    grid1[index + 1, 3] = new SourceGrid.Cells.Cell(numericUpDown1.Value);
                    SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();
                    grid1.AutoSizeCells();
                    grid1[index + 1, 3].View = view;
                    grid1.Refresh();
                }
                catch { }

                writebacknarc();
            }
        }

        private void andiImageComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = int.Parse(toolStripLabel3.Text) - 1;

            andiImageBox1.Image = ImageIconHandler.setImagePictureBox(andiImageComboBox2.SelectedIndex);

            if (checkstate)
            {
                WritePokemonEv(index, andiImageComboBox2.SelectedIndex);
                try
                {
                    grid1[index + 1, 1] = new SourceGrid.Cells.Cell(andiImageComboBox2.Text);
                    SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();
                    grid1.AutoSizeCells();
                    grid1[index + 1, 1].View = view;
                    grid1.Refresh();
                }
                catch { }

                writebacknarc();
            }
        }

        void writebacknarc()
        {
            byte[] temp = new byte[a.Length];

            a.Position = 0;
            a.Read(temp, 0, (int)a.Length);

            Narc[0].ReplaceEntry(andiListBox1.SelectedIndex, temp.Length, temp);
        }

        private void textupdate1(object sender, EventArgs e)
        {
            reloadalldata();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save Evolution File";
            dialog.Filter = "narc file|*.narc";
            //dialog.FileName = "file_" + comboBox1.SelectedValue;
            //dialog.InitialDirectory = igtfpath;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //igtfpath = dialog.FileName.Replace(dialog.file, "");
                File.WriteAllBytes(dialog.FileName, this.Narc[0].CachedData);
            }

            try
            {
                if (narcopen2)
                {
                    dialog = new SaveFileDialog();
                    dialog.Title = "Save BaseEvolution File";
                    dialog.Filter = "narc file|*.narc";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        //igtfpath = dialog.FileName.Replace(dialog.file, "");
                        File.WriteAllBytes(dialog.FileName, this.Narc[1].CachedData);
                    }
                }
            }
            catch
            {

            }
            
        }

        private void andiImageComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (narcopen2)
            {
                bool checktrue = false;

                if (gameformat == GameFormat.gen4)
                {
                    if (andiListBox1.SelectedIndex < 493)
                    {
                        checktrue = true;
                    }
                }
                else
                {
                    if (andiListBox1.SelectedIndex < 649)
                    {
                        checktrue = true;
                    }
                }

                if (checktrue)
                {
                    byte[] bya = ByteConverter.ToByte(andiImageComboBox4.SelectedIndex, 2); ;
                    b.Position = 0;
                    b.Write(bya, 0, 2);

                    byte[] temp = new byte[b.Length];

                    b.Position = 0;
                    b.Read(temp, 0, (int)b.Length);

                    Narc[1].ReplaceEntry(andiListBox1.SelectedIndex, temp.Length, temp);

                    pkm_1.Image = ImageIconHandler.setImagePictureBox(andiImageComboBox4.SelectedIndex);
                }
            }
        }
    }
}
