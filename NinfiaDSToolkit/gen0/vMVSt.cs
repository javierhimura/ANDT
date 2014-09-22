using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Andi.Libs.HexBox;
using Andi.Toolkit.utils;
using Andi.Toolkit.utils.Internal;
using Andi.Utils.Database;
using Andi.Utils.Dialogs;
using Andi.Utils.Events;
using Andi.Utils.Io;
using Andi.Utils.Nitro.Archive;
using SourceGrid;
using WeifenLuo.WinFormsUI.Docking;

namespace Andi.Toolkit.gen0
{
    public partial class vMVSt : DockContent, ICommonFormLayout, IGridFormLayout
    {
        AndiNarcReader narc = new AndiNarcReader();

        List<MoveList> mvlist = new List<MoveList>(); 
        List<MapList> mapfile = new List<MapList>(); 
        Stream a = new MemoryStream();

        vEnum.GameVer b = vEnum.GameVer.none;
        vEnum.GameFormat c = vEnum.GameFormat.none;

        private int gameid = 0;
        private int indexlist = 0;
        private int movelist = 0;

        private bool checkgridfocus = true;
        private bool isGen6 = false;

        private string _LastPath = "";

        private FileInfo flepath;

        public vMVSt()
        {
            InitializeComponent();
            EventsFormLoad();
        }

        #region CommonFunction
        public void EventsFormLoad()
        {
            mTab1.Enabled = false;
            cb_ver.SelectedIndex = 0;

            grid1.SelectionMode = GridSelectionMode.Row;
            grid1.Selection.EnableMultiSelection = false;
            grid1.MouseClick += BaseGridSelection_SelectionChanged;
            grid1.KeyDown += BaseGridSelection_SelectionChanged;
            grid1.KeyUp += BaseGridSelection_SelectionChanged;
            grid1.Selection.FocusRowEntered += BaseGridSelection_FocusRowEntered;

            _LastPath = Program.GlobalPath;
            flepath = new FileInfo(_LastPath);

            GotFocus += GotFocusF;

            bt_Open.Click += (OpenFile_Click);
            bt_Save.Click += (SaveFile_Click); 
            LB_List.SelectedIndexChanged += (LB_List_SelectedIndexChanged);
            bt_remove.Click += (bt_Remove_Click);
            bt_add.Click += (bt_Add_Click);
            nm_lv.ValueChanged += (nm_lv_ValueChanged);
            cb_pokemon.SelectedIndexChanged += (cb_Pokemon_SelectedIndexChanged);
        }

        public void GotFocusF(object sender, EventArgs e)
        {
            try
            {
                Program.mForm.fname.Text = flepath.Name;
                Program.mForm.fsize.Text = flepath.Length + "";
            }
            catch
            {
                Program.mForm.fname.Text = "";
                Program.mForm.fsize.Text = "";
            }
        }

        public void OpenFile_Click(object sender, EventArgs e)
        {
            string path = "";

            path = AndiFileDialog.OpenDialog(path, _LastPath, "Moveset Narc File - File Open", "Any Files|*.*|Narc Files|*.*");

            if (path != "")
            {
                Program.GlobalPath = Path.GetDirectoryName(path);
                _LastPath = Path.GetDirectoryName(path);

                flepath = new FileInfo(path);
                Program.mForm.fname.Text = flepath.Name;
                Program.mForm.fsize.Text = flepath.Length + "";

                if (CheckMagicHeaderID.get(path) == "NARC")
                {
                    isGen6 = false;
                }
                else if (CheckMagicHeaderID.get(path) == "GARC")
                {
                    isGen6 = true;
                }
                else
                {
                    MessageBox.Show("This Not NARC File, File Extension Signature is " + CheckMagicHeaderID.get(path) + ", and is not NARC/GARC File!", "Error!");
                    return;
                }

                if (isGen6)
                {

                }
                else
                {
                    narc.OpenData(path);
                }
                
                EventsAfterOpenFile();
            }
        }

        public void SaveFile_Click(object sender, EventArgs e)
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

        public void EventsAfterOpenFile()
        {
            if (cb_ver.SelectedIndex == 0)
            {
                int cubindex = 0;

                if (isGen6)
                {
                    cubindex = 5;
                }
                else
                {
                    int narccount = narc.FileCount;
                    cubindex = utils.LoadCurrentData.FindGameIdFromCount(narccount);
                }

                b = utils.LoadCurrentData.FindGameVersion(cubindex);
                c = utils.LoadCurrentData.FindGameFormat(cubindex);
                gameid = utils.LoadCurrentData.FindGameId(cubindex);
                label1.Text = utils.LoadCurrentData.FindLabelGame(cubindex);
            }
            else
            {
                b = utils.LoadCurrentData.FindGameVersion(cb_ver.SelectedIndex);
                c = utils.LoadCurrentData.FindGameFormat(cb_ver.SelectedIndex);
                gameid = utils.LoadCurrentData.FindGameId(cb_ver.SelectedIndex);
                label1.Text = utils.LoadCurrentData.FindLabelGame(cb_ver.SelectedIndex);
            }

            MVGList.Load(gameid);
            mapfile.Clear();

            LB_List.Items.Clear();
            LB_List.Items.AddRange(MVGList.GetPokemonNameMVList());

            cb_pokemon.Items.Clear();
            cb_pokemon.Items.AddRange(MVGList.movelist.ToArray());

            mTab1.Enabled = true;
            LB_List.SelectedIndex = 0;
        }

        public void WriteNarcBack()
        {
            try
            {
                if (isGen6)
                {

                }
                else
                {
                    byte[] temp = new byte[a.Length];

                    a.Position = 0;
                    a.Read(temp, 0, (int)a.Length);

                    narc.ReplaceEntry(LB_List.SelectedIndex, temp.Length, temp);
                }
            }
            catch (Exception ex)
            {
                Database.InsertReader.InsertLogs("Error", "Yellow", ex);
            }
        }

        private void WriteMapData()
        {
            try
            {
                int count1 = mvlist.Count;
                byte[] tempbytenya = new byte[1];
                int ukuran = 0;
                switch (c)
                {
                    case vEnum.GameFormat.gen4:
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
                        break;
                    case vEnum.GameFormat.gen5:
                    case vEnum.GameFormat.gen6:
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
        }

        public void LoadCurrentData()
        {
            throw new NotImplementedException();
        }

        public void WriteCurrentBack_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void HexView()
        {
            DynamicFileByteProvider dynamicFileByteProvider = null;

            try
            {
                dynamicFileByteProvider = new DynamicFileByteProvider(a);
            }
            catch { }

            hexBox1.ByteProvider = dynamicFileByteProvider;
        }
        #endregion

        #region Grid EventHandler Function
        public void BaseGridSelectionChanged()
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

        public void BaseGridSelection_FocusRowEntered(object sender, RowEventArgs e)
        {
            BaseGridSelectionChanged();

            if (!checkgridfocus)
            {
                LB_List.Focus();
                checkgridfocus = true;
            }
        }

        public void BaseGridSelection_SelectionChanged(object sender, KeyEventArgs e)
        {
            BaseGridSelectionChanged();
            checkgridfocus = true;
        }

        public void BaseGridSelection_SelectionChanged(object sender, MouseEventArgs e)
        {
            BaseGridSelectionChanged();
            checkgridfocus = true;
        }
        #endregion

        #region Add/Remove/Update Move Entrie Function
        private int GetIdMoveFromStream(int index)
        {
            switch (c)
            {
                case vEnum.GameFormat.gen4:
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
                case vEnum.GameFormat.gen5:
                    a.Position = index * 4;
                    byte[] tempa = new byte[2];
                    a.Read(tempa, 0, 2);

                    return BitConverter.ToUInt16(tempa, 0);
            }
            return 0;
        }

        private int GetLevelMoveFromStream(int index)
        {
            switch (c)
            {
                case vEnum.GameFormat.gen4:
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
                case vEnum.GameFormat.gen5:
                    a.Position = index * 4 + 2;
                    byte[] tempa = new byte[2];
                    a.Read(tempa, 0, 2);

                    return BitConverter.ToUInt16(tempa, 0);
            }
            return 0;
        }

        private int GetMovesCount()
        {
            switch (c)
            {
                case vEnum.GameFormat.gen4:
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
                case vEnum.GameFormat.gen5:
                    return (int)a.Length / 4 - 1;
                default:
                    return 0;
            }
        }

        private void ChangeMovesSelected(int position, int indexmove, int level)
        {
            mvlist[position - 1].id = indexmove;
            mvlist[position - 1].move = indexmove - 1;
            //mvlist[position - 1].level = level;

            grid1[position, 1] = new SourceGrid.Cells.Cell(indexmove);

            try
            {
                grid1[position, 2] = new SourceGrid.Cells.Cell(MVGList.movelist[indexmove - 1]);
            }
            catch (Exception ex)
            {
                Database.InsertReader.InsertLogs("Error", "Yellow", ex);
            }

            //grid1[position, 3] = new SourceGrid.Cells.Cell(level);

            SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();

            grid1[position, 1].View = view;
            grid1[position, 2].View = view;

            grid1.Refresh();
            hexBox1.Refresh();
            WriteMapData();
            WriteNarcBack();
        }

        private void ChangeMovesSelected(int position, int level)
        {
            try
            {
                mvlist[position - 1].level = level;
                grid1[position, 3] = new SourceGrid.Cells.Cell(level);

                SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();

                grid1[position, 3].View = view;
                grid1.Refresh();
                hexBox1.Refresh();
                WriteMapData();
                WriteNarcBack();
            }
            catch (Exception ex)
            {
                Database.InsertReader.InsertLogs("Error", "Yellow", ex);
            }
        }

        private void Moves_AddNew(int indexmove, int level)
        {
            try
            {
                switch (c)
                {
                    case vEnum.GameFormat.gen4:
                        if (movelist >= 20)
                        {
                            throw new Exception();
                        }
                        break;
                    case vEnum.GameFormat.gen5:
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

                WriteMapData();
                WriteNarcBack();
            }
            catch (Exception ex)
            {
                Database.InsertReader.InsertLogs("Error", "Yellow", ex);
            }
        }

        private void Moves_Removes(int position)
        {
            try
            {
                mvlist.RemoveAt(position - 1);

                FillGrid.Build(grid1, mvlist.Count, 3, "id", " Moves", "Lv");
                FillGrid.FillMoveset(grid1, mvlist);
                movelist--;
                label4.Text = movelist + " Move's";
                WriteMapData();
                WriteNarcBack();
            }
            catch (Exception ex)
            {
                Database.InsertReader.InsertLogs("Error", "Yellow", ex);
            }
        }
        #endregion

        #region Other EventHandler Function
        private void LB_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (isGen6)
                {

                }
                else
                {
                    a = new MemoryStream(narc.getdataselected(LB_List.SelectedIndex));
                    checkgridfocus = false;
                    label5.Text = LB_List.SelectedIndex + "/" + narc.FileCount;
                }

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
                    if (b == vEnum.GameVer.BW2)
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

                HexView();
                int cc = GetMovesCount();

                FillGrid.Build(grid1, cc, 3, "id", " Moves", "Lv");
                mvlist.Clear();
                //object[,] datatemp = new object[cc,3];

                for (int i = 0; i < cc; i++)
                {
                    MoveList bbb = new MoveList();

                    bbb.id = GetIdMoveFromStream(i);
                    bbb.move = GetIdMoveFromStream(i) - 1;
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

        private void cb_Pokemon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = indexlist;
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
            Moves_AddNew(cb_pokemon.SelectedIndex + 1, (int) nm_lv.Value);
        }

        private void bt_Remove_Click(object sender, EventArgs e)
        {
            int index = indexlist;
            Moves_Removes(index);
        }
        #endregion
    }
}
