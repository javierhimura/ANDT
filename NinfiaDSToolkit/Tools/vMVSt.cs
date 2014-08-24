using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using NinfiaDSToolkit.Andi.Controls.HexBox;
using NinfiaDSToolkit.Andi.Utils;
using NinfiaDSToolkit.Andi.Utils.Narc;
using NinfiaDSToolkit.Tools.Internal;
using SourceGrid;
using WeifenLuo.WinFormsUI.Docking;
using ContentAlignment = DevAge.Drawing.ContentAlignment;

namespace NinfiaDSToolkit.Tools
{
    public partial class vMVSt : DockContent
    {
        AndiNarcReader narc = new AndiNarcReader();
        List<MapList> mapfile = new List<MapList>(); 
        Stream a = new MemoryStream();
        penum.GameVer b = penum.GameVer.none;
        penum.GameFormat c = penum.GameFormat.none;
        List<MoveList> mvlist = new List<MoveList>(); 
        int gameid = 0;
        private bool checkgridfocus = true;
        private int indexlist = 0;
        private int movelist = 0;
        private string _LastPath = "";

        public vMVSt()
        {
            InitializeComponent();
            LoadEventListener();
        }

        void LoadEventListener()
        {
            mTab1.Enabled = false;
            cb_ver.SelectedIndex = 0;
            grid1.SelectionMode = GridSelectionMode.Row;
            grid1.Selection.EnableMultiSelection = false;
            grid1.MouseClick += Selection_SelectionChanged;
            grid1.KeyDown += Selection_SelectionChanged;
            grid1.KeyUp += Selection_SelectionChanged;
            grid1.Selection.FocusRowEntered += Selection_FocusRowEntered;
            _LastPath = Program.GlobalPath;

            this.bt_Open.Click += new System.EventHandler(this.bt_Open_Click);
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click); 
            this.LB_List.SelectedIndexChanged += new System.EventHandler(this.LB_List_SelectedIndexChanged);
            this.bt_remove.Click += new System.EventHandler(this.bt_Remove_Click);
            this.bt_add.Click += new System.EventHandler(this.bt_Add_Click);
            this.nm_lv.ValueChanged += new System.EventHandler(this.nm_lv_ValueChanged);
            this.cb_pokemon.SelectedIndexChanged += new System.EventHandler(this.cb_Pokemon_SelectedIndexChanged);
        }

        #region Grid Events
        void GridEventSelectionChanged()
        {
            try
            {
                indexlist = grid1.Selection.ActivePosition.Row;
                label3.Text = indexlist + "";
                nm_lv.Value = (int) grid1[grid1.Selection.ActivePosition.Row, 3].Value;
                cb_pokemon.Text = grid1[grid1.Selection.ActivePosition.Row, 2] + "";
            }
            catch (Exception ex)
            {
                Database.InsertReader.InsertLogs("Error", "Yellow", ex);
            }
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
        #endregion

        #region Open Save
        private void bt_Open_Click(object sender, EventArgs e)
        {
            string path = "";

            path = AndiFileDialog.OpenDialog(path, _LastPath, "Moveset Narc File - File Open", "Any Files|*.*|Narc Files|*.*");

            if (path != "")
            {
                Program.GlobalPath = Path.GetDirectoryName(path);
                _LastPath = Path.GetDirectoryName(path);

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
                        b = penum.GameVer.BW;
                        c = penum.GameFormat.gen5;
                        gameid = 17;
                        label1.Text = "BW";
                    }
                    else if (narc.FileCount == 709)
                    {
                        b = penum.GameVer.BW2;
                        c = penum.GameFormat.gen5;
                        gameid = 21;
                        label1.Text = "BW2";
                    }
                    else if (narc.FileCount == 501)
                    {
                        b = penum.GameVer.DP;
                        c = penum.GameFormat.gen4;
                        gameid = 12;
                        label1.Text = "DP";
                    }
                    else if (narc.FileCount == 508)
                    {
                        b = penum.GameVer.PtHGSS;
                        c = penum.GameFormat.gen4;
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
                    b = penum.GameVer.DP;
                    c = penum.GameFormat.gen4;
                    gameid = 12;
                    label1.Text = "DP";
                }
                else if (cb_ver.SelectedIndex == 2)
                {
                    b = penum.GameVer.PtHGSS;
                    c = penum.GameFormat.gen4;
                    gameid = 14;
                    label1.Text = "Pt/HGSS";
                }
                else if (cb_ver.SelectedIndex == 3)
                {
                    b = penum.GameVer.BW;
                    c = penum.GameFormat.gen5;
                    label1.Text = "BW";
                    gameid = 17;
                }
                else if (cb_ver.SelectedIndex == 4)
                {
                    b = penum.GameVer.BW2;
                    c = penum.GameFormat.gen5;
                    gameid = 21;
                    label1.Text = "BW2";
                    
                }
                else
                {
                    return;
                }

                MVGList.Load(gameid);
                LB_List.Items.Clear();
                mapfile.Clear();
                LB_List.Items.AddRange(MVGList.GetPokemonNameMVList());
                cb_pokemon.Items.Clear();
                cb_pokemon.Items.AddRange(MVGList.movelist.ToArray());
                mTab1.Enabled = true;
                LB_List.SelectedIndex = 0;
            }
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            try
            {
                AndiFileDialog.NarcSaveDialog(narc, Path.GetDirectoryName(_LastPath), "Save Moveset Data", "narc file|*.narc");
            }
            catch (Exception ex)
            {
                Database.InsertReader.InsertLogs("Error", "Yellow", ex);
            }
        }
        #endregion

        #region Getting Data
        int GetIDMoveFromStream(int index)
        {
            switch (c)
            {
                case penum.GameFormat.gen4:
                    a.Position = index * 2;
                    byte[] temp = new byte[2];
                    a.Read(temp, 0, 2);
                    string temp2 = RemoveEvents.RemoveSpecialCharacter(ByteConverter.bitConvert(BitConverter.ToUInt16(temp, 0)));
                    int sisa = (16 - temp2.Length);

                    for (int i = 0; i < sisa; i++)
                    {
                        temp2 = "0" + temp2;
                    }

                    return (int)Convert.ToInt16(temp2.Substring(7, 9), 2);
                case penum.GameFormat.gen5:
                    a.Position = index * 4;
                    byte[] tempa = new byte[2];
                    a.Read(tempa, 0, 2);

                    return BitConverter.ToUInt16(tempa, 0);
            }
            return 0;
        }

        int GetLevelMoveFromStream(int index)
        {
            switch (c)
            {
                case penum.GameFormat.gen4:
                    a.Position = index * 2;
                    byte[] temp = new byte[2];
                    a.Read(temp, 0, 2);
                    string temp2 = RemoveEvents.RemoveSpecialCharacter(ByteConverter.bitConvert(BitConverter.ToUInt16(temp, 0)));
                    int sisa = (16 - temp2.Length);

                    for (int i = 0; i < sisa; i++)
                    {
                        temp2 = "0" + temp2;
                    }

                    return (int)Convert.ToInt16(temp2.Substring(0, 7), 2);
                case penum.GameFormat.gen5:
                    a.Position = index * 4 + 2;
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
                case penum.GameFormat.gen4:
                    int newtemp;
                    a.Position = a.Length - 1;
                    newtemp = a.ReadByte();
                    a.Position = 0;

                    if (newtemp == 0)
                    {
                        return (int)a.Length / 2 - 2;
                    }
                    else
                    {
                        return (int)a.Length / 2 - 1;
                    }
                    break;
                case penum.GameFormat.gen5:
                    return (int)a.Length / 4 - 1;
                default:
                    return 0;
            }
        }
        #endregion

        private void LB_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
                    if (b == penum.GameVer.BW2)
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

                FillGrid.Build(grid1, cc, 3, "id", " Moves", "Lv");
                mvlist.Clear();
                //object[,] datatemp = new object[cc,3];

                for (int i = 0; i < cc; i++)
                {
                    MoveList bbb = new MoveList();

                    bbb.id = GetIDMoveFromStream(i);
                    bbb.move = GetIDMoveFromStream(i) - 1;
                    bbb.level = GetLevelMoveFromStream(i);

                    mvlist.Add(bbb);
                }

                FillGrid.FillMoveset(grid1, mvlist);
                movelist = cc;
                label4.Text = movelist + " Move's";
            }
            catch (Exception ex)
            {
                Database.InsertReader.InsertLogs("Error", "Yellow", ex);
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

        #region Writting Data

        void writeMemoryStream()
        {
            try
            {
                int count1 = mvlist.Count;
                byte[] tempbytenya = new byte[1];
                int ukuran = 0;
                switch (c)
                {
                    case penum.GameFormat.gen4:
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

                            string a11 = RemoveEvents.RemoveSpecialCharacter(ByteConverter.bitConvert(mvlist[i].id)).PadLeft(9, '0');
                            string a12 = RemoveEvents.RemoveSpecialCharacter(ByteConverter.bitConvert(mvlist[i].level)).PadLeft(7, '0');

                            byte[] nik = ByteConverter.ToByte(Convert.ToInt16(a12 + a11, 2), 2);

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
                    case penum.GameFormat.gen5:
                        ukuran = (count1 + 1) * 4;

                        tempbytenya = new byte[ukuran];
                        a = new MemoryStream(tempbytenya);

                        for (int i = 0; i < count1; i++)
                        {
                            a.Position = 4 * i;
                            byte[] nik = ByteConverter.ToByte(mvlist[i].id, 2);
                            a.Write(nik, 0, 2);
                            a.Position = 4 * i + 2;
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
            }
            catch (Exception ex)
            {
                Database.InsertReader.InsertLogs("Error", "Yellow", ex);
            }

            //a = new MemoryStream(narc.getdataselected(andiListBox1.SelectedIndex));
        }

        void writebacknarc()
        {
            try
            {
                byte[] temp = new byte[a.Length];

                a.Position = 0;
                a.Read(temp, 0, (int)a.Length);

                narc.ReplaceEntry(LB_List.SelectedIndex, temp.Length, temp);
            }
            catch (Exception ex)
            {
                Database.InsertReader.InsertLogs("Error", "Yellow", ex);
            }
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
            catch(Exception ex)
            {
                Database.InsertReader.InsertLogs("Error", "Yellow", ex);
            }
            
            //grid1[position, 3] = new SourceGrid.Cells.Cell(level);
            
            SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();

            grid1[position, 1].View = view;
            grid1[position, 2].View = view;

            grid1.Refresh();
            hexBox1.Refresh();
            writeMemoryStream();
            writebacknarc();
        }

        void ChangeMovesSelected(int position, int level)
        {
            try
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
            catch (Exception ex)
            {
                Database.InsertReader.InsertLogs("Error", "Yellow", ex);
            }
        }

        void AddMoves(int indexmove, int level)
        {
            try
            {
                switch (c)
                {
                    case penum.GameFormat.gen4:
                        if (movelist >= 20)
                        {
                            throw new Exception();
                        }
                        break;
                    case penum.GameFormat.gen5:
                        if (movelist >= 26)
                        {
                            throw new Exception();
                        }
                        break;
                }

                MoveList aa = new MoveList();

                aa.id = indexmove;
                aa.move = indexmove - 1;
                aa.level = level;
                movelist++;
                label4.Text = movelist + " Move's";
                mvlist.Add(aa);

                FillGrid.Build(grid1, mvlist.Count, 3, "id", " Moves", "Lv");
                FillGrid.FillMoveset(grid1, mvlist);

                writeMemoryStream();
                writebacknarc();
            }
            catch (Exception ex)
            {
                Database.InsertReader.InsertLogs("Error", "Yellow", ex);
            }
        }

        void RemoveMoves(int position)
        {
            try
            {
                mvlist.RemoveAt(position - 1);

                FillGrid.Build(grid1, mvlist.Count, 3, "id", " Moves", "Lv");
                FillGrid.FillMoveset(grid1, mvlist);
                movelist--;
                label4.Text = movelist + " Move's";
                writeMemoryStream();
                writebacknarc();
            }
            catch (Exception ex)
            {
                Database.InsertReader.InsertLogs("Error", "Yellow", ex);
            }
        }
        #endregion

        private void cb_Pokemon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = indexlist;

                //this.toolTip1.SetToolTip(this.cb_pokemon, cb_pokemon.Text + "\n" + MVGList.getFlavor(cb_pokemon.SelectedIndex + 1, gameid));

                ChangeMovesSelected(index, cb_pokemon.SelectedIndex + 1, (int)nm_lv.Value);
            }
            catch (Exception ex)
            {
                Database.InsertReader.InsertLogs("Error", "Yellow", ex);
            }
        }

        private void nm_lv_ValueChanged(object sender, EventArgs e)
        {
            int index = indexlist;

            ChangeMovesSelected(index, (int)nm_lv.Value);
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            AddMoves(cb_pokemon.SelectedIndex + 1, (int) nm_lv.Value);
        }

        private void bt_Remove_Click(object sender, EventArgs e)
        {
            int index = indexlist;
            RemoveMoves(index);
        }

        
    }
}
