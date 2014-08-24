using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
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
    public partial class vMVSt : DockContent
    {
        AndiNarcReader narc = new AndiNarcReader();
        Stream a = new MemoryStream();
        GameVer b = GameVer.none;
        GameFormat c = GameFormat.none;
        List<MoveList> mvlist = new List<MoveList>(); 
        int gameid = 0;
        private bool checkgridfocus = true;

        public enum GameVer
        {
            DP,PtHGSS,BW,BW2,none
        }

        public enum GameFormat
        {
            gen4,gen5,none
        }

        public vMVSt()
        {
            InitializeComponent();
            mTab1.Enabled = false;
            cb_ver.SelectedIndex = 0;
            grid1.SelectionMode = GridSelectionMode.Row;
            grid1.Selection.EnableMultiSelection = false;
            grid1.MouseClick += Selection_SelectionChanged;
            grid1.KeyDown += Selection_SelectionChanged;
            grid1.KeyUp += Selection_SelectionChanged;
            grid1.Selection.FocusRowEntered += Selection_FocusRowEntered;

            LoadEventListener();
            //grid1.Selection.SelectionChanged += Selection_SelectionChanged;
        }

        void LoadEventListener()
        {
            this.bt_Open.Click += new System.EventHandler(this.bt_Open_Click);
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click); 
            this.LB_List.SelectedIndexChanged += new System.EventHandler(this.LB_List_SelectedIndexChanged);
            this.bt_remove.Click += new System.EventHandler(this.bt_Remove_Click);
            this.bt_add.Click += new System.EventHandler(this.bt_Add_Click);
            this.nm_lv.ValueChanged += new System.EventHandler(this.nm_lv_ValueChanged);
            this.cb_pokemon.SelectedIndexChanged += new System.EventHandler(this.cb_Pokemon_SelectedIndexChanged);
        }

        void GridEventSelectionChanged()
        {
            try
            {
                label3.Text = grid1.Selection.ActivePosition.Row + "";
                nm_lv.Value = (int)grid1[grid1.Selection.ActivePosition.Row, 3].Value;
                cb_pokemon.Text = grid1[grid1.Selection.ActivePosition.Row, 2] + "";
            }
            catch { }
        }

        private void Selection_FocusRowEntered(object sender, RowEventArgs e)
        {
            GridEventSelectionChanged();

            if (!checkgridfocus)
            {
                LB_List.Focus();
                checkgridfocus = true;
            }
        }

        private void Selection_SelectionChanged(object sender, KeyEventArgs e)
        {
            GridEventSelectionChanged();
            checkgridfocus = true;
        }

        private void Selection_SelectionChanged(object sender, MouseEventArgs e)
        {
            GridEventSelectionChanged();
            checkgridfocus = true;
        }

        private void bt_Open_Click(object sender, EventArgs e)
        {
            string path = "";

            OpenFileDialog OpenNarcFileDialog = new OpenFileDialog();
            OpenNarcFileDialog.Filter = "Any Files|*.*|Narc Files|*.*";

            if (OpenNarcFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                path = OpenNarcFileDialog.FileName;

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

                if (cb_ver.SelectedIndex == 0)
                {
                    if (narc.FileCount == 668)
                    {
                        b = GameVer.BW;
                        c = GameFormat.gen5;
                        gameid = 17;
                        label1.Text = "BW";
                    }
                    else if (narc.FileCount == 709)
                    {
                        b = GameVer.BW2;
                        c = GameFormat.gen5;
                        gameid = 21;
                        label1.Text = "BW2";
                    }
                    else if (narc.FileCount == 501)
                    {
                        b = GameVer.DP;
                        c = GameFormat.gen4;
                        gameid = 12;
                        label1.Text = "DP";
                    }
                    else if (narc.FileCount == 508)
                    {
                        b = GameVer.PtHGSS;
                        c = GameFormat.gen4;
                        gameid = 14;
                        label1.Text = "Pt/HGSS";
                    }
                    else
                    {
                        return;
                    }
                }
                else if (cb_ver.SelectedIndex == 1)
                {
                    b = GameVer.DP;
                    c = GameFormat.gen4;
                    gameid = 12;
                    label1.Text = "DP";
                }
                else if (cb_ver.SelectedIndex == 2)
                {
                    b = GameVer.PtHGSS;
                    c = GameFormat.gen4;
                    gameid = 14;
                    label1.Text = "Pt/HGSS";
                }
                else if (cb_ver.SelectedIndex == 3)
                {
                    b = GameVer.BW;
                    c = GameFormat.gen5;
                    label1.Text = "BW";
                    gameid = 17;
                }
                else if (cb_ver.SelectedIndex == 4)
                {
                    b = GameVer.BW2;
                    c = GameFormat.gen5;
                    gameid = 21;
                    label1.Text = "BW2";
                    
                }
                else
                {
                    return;
                }

                MVGList.Load(gameid);
                LB_List.Items.Clear();
                LB_List.Items.AddRange(MVGList.GetPokemonNameMVList());
                cb_pokemon.Items.Clear();
                cb_pokemon.Items.AddRange(MVGList.movelist.ToArray());
                mTab1.Enabled = true;
                LB_List.SelectedIndex = 0;
            }
        }

        private void LB_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            a = new MemoryStream(narc.getdataselected(LB_List.SelectedIndex));
            checkgridfocus = false;
            label5.Text = LB_List.SelectedIndex + "/" + narc.FileCount;

            if (LB_List.SelectedIndex <= 649)
            {
                IB_pokemon.Image = ImageIconHandler.setImagePictureBox(LB_List.SelectedIndex);
            }
            else if ((LB_List.SelectedIndex <= 684 && LB_List.SelectedIndex > 649))
            {
                IB_pokemon.Image = ImageIconHandler.setImagePictureBox(0);
            }
            else
            {
                if (b == GameVer.BW2)
                {
                    switch (LB_List.SelectedIndex)
                    {
                        case 685:
                            IB_pokemon.Image = ImageIconHandler.setImagePictureBox(386, 1);
                            break;
                        case 686:
                            IB_pokemon.Image = ImageIconHandler.setImagePictureBox(386, 2);
                            break;
                        case 687:
                            IB_pokemon.Image = ImageIconHandler.setImagePictureBox(386, 3);
                            break;
                        case 688:
                            IB_pokemon.Image = ImageIconHandler.setImagePictureBox(413, 1);
                            break;
                        case 689:
                            IB_pokemon.Image = ImageIconHandler.setImagePictureBox(413, 2);
                            break;
                        case 690:
                            IB_pokemon.Image = ImageIconHandler.setImagePictureBox(492, 1);
                            break;
                        case 691:
                            IB_pokemon.Image = ImageIconHandler.setImagePictureBox(487, 1);
                            break;
                        case 692:
                            IB_pokemon.Image = ImageIconHandler.setImagePictureBox(479, 1);
                            break;
                        case 693:
                            IB_pokemon.Image = ImageIconHandler.setImagePictureBox(479, 2);
                            break;
                        case 694:
                            IB_pokemon.Image = ImageIconHandler.setImagePictureBox(479, 3);
                            break;
                        case 695:
                            IB_pokemon.Image = ImageIconHandler.setImagePictureBox(479, 4);
                            break;
                        case 696:
                            IB_pokemon.Image = ImageIconHandler.setImagePictureBox(479, 5);
                            break;
                        case 697:
                            IB_pokemon.Image = ImageIconHandler.setImagePictureBox(351, 1);
                            break;
                        case 698:
                            IB_pokemon.Image = ImageIconHandler.setImagePictureBox(351, 2);
                            break;
                        case 699:
                            IB_pokemon.Image = ImageIconHandler.setImagePictureBox(351, 3);
                            break;
                        default:
                            IB_pokemon.Image = ImageIconHandler.setImagePictureBox(0);
                            break;
                    }
                }
                else
                {
                    IB_pokemon.Image = ImageIconHandler.setImagePictureBox(0);
                }
                
            }

            ViewHexBox();
            int cc = GetMovesCount();

            Build(grid1, cc);
            mvlist.Clear();
            //object[,] datatemp = new object[cc,3];

            for (int i = 0; i < cc; i++)
            {
                MoveList bbb = new MoveList();

                bbb.id = GetIDMoveFromStream(i);
                bbb.move = GetIDMoveFromStream(i)-1;
                bbb.level = GetLevelMoveFromStream(i);

                mvlist.Add(bbb);
            }

            Fill(grid1, mvlist);
            label4.Text = cc + " Move's";
        }

        int GetIDMoveFromStream(int index)
        {
            switch (c)
            {
                case GameFormat.gen4:
                    a.Position = index*2;
                    byte[] temp = new byte[2];
                    a.Read(temp, 0, 2);
                    string temp2 = SpecialCharacterCleaner(ByteConverter.bitConvert(BitConverter.ToUInt16(temp, 0)));
                    int sisa = (16 - temp2.Length);

                    for (int i = 0; i < sisa; i++)
                    {
                        temp2 = "0" + temp2;
                    }

                    return (int)Convert.ToInt16(temp2.Substring(7,9), 2);
                case GameFormat.gen5:
                    a.Position = index*4;
                    byte[] tempa = new byte[2];
                    a.Read(tempa, 0, 2);

                    return BitConverter.ToUInt16(tempa, 0);
            }
            return 0;
        }
        public static string SpecialCharacterCleaner(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        int GetLevelMoveFromStream(int index)
        {
            switch (c)
            {
                case GameFormat.gen4:
                    a.Position = index * 2;
                    byte[] temp = new byte[2];
                    a.Read(temp, 0, 2);
                    string temp2 = SpecialCharacterCleaner(ByteConverter.bitConvert(BitConverter.ToUInt16(temp, 0)));
                    int sisa = (16 - temp2.Length);

                    for (int i = 0; i < sisa; i++)
                    {
                        temp2 = "0" + temp2;
                    }

                    return (int)Convert.ToInt16(temp2.Substring(0,7), 2);
                case GameFormat.gen5:
                    a.Position = index*4+2;
                    byte[] tempa = new byte[2];
                    a.Read(tempa, 0, 2);

                    return BitConverter.ToUInt16(tempa, 0);
            }
            return 0;
        }

        int GetMovesCount()
        {
            switch (c)
            {
                case GameFormat.gen4:
                    int newtemp;
                    a.Position = a.Length - 1;
                    newtemp = a.ReadByte();
                    a.Position = 0;

                    if (newtemp == 0)
                    {
                        return (int) a.Length/2 - 2;
                    }
                    else
                    {
                        return (int)a.Length / 2 -1 ;
                    }
                    break;
                case GameFormat.gen5:
                    return (int)a.Length / 4 - 1;
                default:
                    return 0;
            }
        }

        void ViewHexBox()
        {
            DynamicFileByteProvider dynamicFileByteProvider = null;

            try
            {
                // try to open in write mode
                dynamicFileByteProvider = new DynamicFileByteProvider(a);
            }
            catch{}

            hexBox1.ByteProvider = dynamicFileByteProvider;

        }

        #region Filling Grid
        private static void Reset(Grid a, int m, int n)
        {
            a.Redim(0, 0);
            a.Redim(m + 1, n + 1);
            a.FixedRows = 1;
            a.FixedColumns = 1;
        }

        private static void Build(Grid a, int m, int n=3)
        {
            try
            {
                Reset(a,m,n);

                SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();
                SourceGrid.Cells.Editors.TextBox editor = new SourceGrid.Cells.Editors.TextBox(typeof(string));
                view.BackColor = Color.White;


                for (int r = a.FixedRows; r < a.RowsCount; r++)
                {
                    a[r, 0] = new SourceGrid.Cells.RowHeader(r);
                }

                string[] headername = new[] {"id", " Moves", "Lv"};

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
            catch{}
        }

        private static void Fill(Grid a, List<MoveList> data, bool multiline = true)
        {
            SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();
            SourceGrid.Cells.Editors.TextBox editor = new SourceGrid.Cells.Editors.TextBox(typeof(string));
            view.BackColor = Color.White;
            editor.Control.Multiline = multiline;

            for (int r = a.FixedRows; r < a.RowsCount; r++)
            {
                a[r, 1] = new SourceGrid.Cells.Cell(data[r - 1].id);
                a[r, 2] = new SourceGrid.Cells.Cell(MVGList.movelist[data[r - 1].move]);
                a[r, 3] = new SourceGrid.Cells.Cell(data[r - 1].level);
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
            try
            {
                a.Selection.Focus(new SourceGrid.Position(1, 1), true);
            }
            catch
            {
                
            }
            a.AutoSizeCells();
            
        }
        #endregion

        #region Change Add Remove Rewrite Write to Narc
        void ChangeMovesSelected(int position,int indexmove, int level)
        {
            mvlist[position - 1].id = indexmove;
            mvlist[position - 1].move = indexmove - 1;
            //mvlist[position - 1].level = level;

            grid1[position, 1] = new SourceGrid.Cells.Cell(indexmove);
            try
            {
                grid1[position, 2] = new SourceGrid.Cells.Cell(MVGList.movelist[indexmove - 1]);
            }
            catch { }
            
            //grid1[position, 3] = new SourceGrid.Cells.Cell(level);
            
            SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();

            grid1[position, 1].View = view;
            grid1[position, 2].View = view;
            //grid1[position, 3].View = view;
            grid1.Refresh();
            hexBox1.Refresh();
            writeMemoryStream();
            writebacknarc();
        }

        void ChangeMovesSelected(int position, int level)
        {
            mvlist[position - 1].level = level;
            grid1[position, 3] = new SourceGrid.Cells.Cell(level);

            SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();

            grid1[position, 3].View = view;
            grid1.Refresh();
            hexBox1.Refresh();
            writeMemoryStream();
            writebacknarc();
        }

        void AddMoves(int indexmove, int level)
        {
            MoveList aa = new MoveList();

            aa.id = indexmove;
            aa.move = indexmove - 1;
            aa.level = level;

            mvlist.Add(aa);

            Build(grid1, mvlist.Count);
            Fill(grid1, mvlist);

            writeMemoryStream();
            writebacknarc();
        }

        void RemoveMoves(int position)
        {
            mvlist.RemoveAt(position-1);

            Build(grid1, mvlist.Count);
            Fill(grid1, mvlist);

            writeMemoryStream();
            writebacknarc();
        }

        void writeMemoryStream()
        {
            int count1 = mvlist.Count;
            byte[] tempbytenya = new byte[1];
            int ukuran = 0;
            switch (c)
            {
                case GameFormat.gen4:
                    ukuran = (count1) * 2;
                    bool checktype = false;

                    if (ukuran % 4 != 0) // Menentukan FF FF dimana
                    {
                        ukuran += 2;
                    }
                    else
                    {
                        ukuran += 4;
                        checktype = true;
                    }

                    tempbytenya = new byte[ukuran];
                    a = new MemoryStream(tempbytenya);

                    for (int i = 0; i < count1; i++)
                    {
                        a.Position = 2 * i;

                        string a11 = SpecialCharacterCleaner(ByteConverter.bitConvert(mvlist[i].id)).PadLeft(9, '0');
                        string a12 = SpecialCharacterCleaner(ByteConverter.bitConvert(mvlist[i].level)).PadLeft(7, '0');

                        byte[] nik = ByteConverter.ToByte(Convert.ToInt16(a12+a11,2), 2);

                        a.Write(nik, 0, 2);
                    }

                    a.Position = 2 * count1;

                        byte[] nik3 = ByteConverter.ToByte(65535, 2);
                        a.Write(nik3, 0, 2);

                    if (checktype)
                    {
                        a.Position = 2 * count1 + 2;

                        nik3 = ByteConverter.ToByte(0, 2);
                        a.Write(nik3, 0, 2);
                    }
                    // ? bConvert(

                    break;
                case GameFormat.gen5:
                    ukuran = (count1 + 1)*4;

                    tempbytenya = new byte[ukuran];
                    a = new MemoryStream(tempbytenya);

                    for (int i = 0; i < count1; i++)
                    {
                        a.Position = 4*i;
                        byte[] nik = ByteConverter.ToByte(mvlist[i].id,2);
                        a.Write(nik, 0, 2);
                        a.Position = 4 * i+2;
                        nik = ByteConverter.ToByte(mvlist[i].level, 2);
                        a.Write(nik, 0, 2);
                    }

                    a.Position = 4 * count1;
                    byte[] nik2 = ByteConverter.ToByte(65535, 2);
                        a.Write(nik2, 0, 2);
                    a.Position = 4 * count1 + 2;
                    nik2 = ByteConverter.ToByte(65535, 2);
                        a.Write(nik2, 0, 2);

                    break;
            }

            //a = new MemoryStream(narc.getdataselected(andiListBox1.SelectedIndex));
        }

        void writebacknarc()
        {
            byte[] temp = new byte[a.Length];

            a.Position = 0;
            a.Read(temp, 0, (int)a.Length);

            narc.ReplaceEntry(LB_List.SelectedIndex, temp.Length, temp);
        }
        #endregion

        private void cb_Pokemon_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = int.Parse(label3.Text);

            this.toolTip1.SetToolTip(this.cb_pokemon, cb_pokemon.Text+"\n"+MVGList.getFlavor(cb_pokemon.SelectedIndex+1,gameid));

            ChangeMovesSelected(index, cb_pokemon.SelectedIndex + 1, (int) nm_lv.Value);
        }

        private void nm_lv_ValueChanged(object sender, EventArgs e)
        {
            int index = int.Parse(label3.Text);

            ChangeMovesSelected(index, (int)nm_lv.Value);
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            AddMoves(cb_pokemon.SelectedIndex + 1, (int) nm_lv.Value);
        }

        private void bt_Remove_Click(object sender, EventArgs e)
        {
            int index = int.Parse(label3.Text);
            RemoveMoves(index);
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog NarcSaveFileDialog = new SaveFileDialog();
            NarcSaveFileDialog.Title = "Save File";
            NarcSaveFileDialog.Filter = "narc file|*.narc";
            //dialog.FileName = "file_" + comboBox1.SelectedValue;
            //dialog.InitialDirectory = igtfpath;
            if (NarcSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //igtfpath = dialog.FileName.Replace(dialog.file, "");
                File.WriteAllBytes(NarcSaveFileDialog.FileName, this.narc.CachedData);
            }
        }
    }
}
