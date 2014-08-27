using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NinfiaDSToolkit.Andi.Controls.HexBox;
using NinfiaDSToolkit.Andi.Controls.ImageBox;
using NinfiaDSToolkit.Andi.Utils;
using NinfiaDSToolkit.Andi.Utils.Narc;
using NinfiaDSToolkit.Tools.Object;
using WeifenLuo.WinFormsUI.Docking;

namespace NinfiaDSToolkit.Tools
{
    public partial class vHG : DockContent, ICommonFormLayout, ICommonHiddenGrottoLayout
    {
        AndiNarcReader narc = new AndiNarcReader();
        Stream a = new MemoryStream();
        public int isLastIndexPokemon = 0;
        public bool isReady = false;
        public string _LastPath = "";

        public vHG()
        {
            InitializeComponent();
            _LastPath = Program.GlobalPath;
            EventsFormLoad();
            ImageBoxEventLoads();
        }

        #region CommonFunction
        public void EventsFormLoad()
        {
            cb_pokemon.Items.Clear();
            cb_items.Items.Clear();

            cb_pokemon.Items.AddRange(Database.GetPokemonName(5));
            cb_locname.Items.AddRange(Database.GetLocationName());
            cb_items.Items.AddRange(Database.GetItemName());

            cb_pokemon.SelectedIndexChanged += cb_pokemon_SelectedIndexChanged;
            cb_locname.SelectedIndexChanged += cb_locname_SelectedIndexChanged;
            cb_vergm.SelectedIndexChanged += cb_vergm_SelectedIndexChanged;
            cb_items.SelectedIndexChanged += cb_items_SelectedIndexChanged;
            cb_forme.SelectedIndexChanged += cb_forme_SelectedIndexChanged;

            st_Auto.Click += st_Auto_Click;
            et_formecb.Click += et_formecb_Click;
            HGExit.Click += HGExit_Click;
            bt_SaveCurrent.Click += WriteCurrentBack_Click;
            st_hexview.Click += st_hexview_Click;

            bt_Open.Click += OpenFile_Click;
            bt_Save.Click += (this.SaveFile_Click);

            nm_female_rate.ValueChanged += (this.NumericValueChanged);
            nm_lv_min.ValueChanged += (this.NumericValueChanged);
            nm_lv_max.ValueChanged += (this.NumericValueChanged);
        }

        public void OpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "";

                path = AndiFileDialog.OpenDialog(path, _LastPath, "Hidden Grotto - File Open", "Any Files|*.*|Narc Files|*.*");

                if (path != "")
                {
                    Program.GlobalPath = Path.GetDirectoryName(path);
                    _LastPath = Path.GetDirectoryName(path);

                    FileStream a = new FileStream(path, FileMode.Open);
                    byte[] bytee = new byte[4];

                    a.Position = 0;

                    a.Read(bytee, 0, 4);

                    string check = System.Text.Encoding.ASCII.GetString(bytee);
                    a.Close();

                    if (check != "NARC")
                    {
                        MessageBox.Show("This Not NARC File, File Extension Signature is " + check + ", and is not NARC File!", "Error!");
                        return;
                    }

                    narc.OpenData(path);

                    if (narc.FileCount != 20)
                    {
                        MessageBox.Show("Invalid File.", "Error!");
                        return;
                    }

                    EventsAfterOpenFile();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Database.InsertReader.InsertLogs("error", "Yello", ex);
#endif
            }
        }

        public void SaveFile_Click(object sender, EventArgs e)
        {
            try
            {
                AndiFileDialog.NarcSaveDialog(narc, Path.GetDirectoryName(_LastPath), "Save Hidden Grotto Data", "narc file|*.narc");
            }
            catch (Exception ex)
            {
#if DEBUG
                Database.InsertReader.InsertLogs("error", "Yello", ex);
#endif
            }
        }

        public void EventsAfterOpenFile()
        {
            cb_locname.SelectedIndex = 0;
            cb_vergm.SelectedIndex = 0;
            cb_locname.Enabled = true;
            mTab1.Enabled = true;
            bt_Save.Enabled = true;
        }

        public void WriteNarcBack()
        {
            try
            {
                byte[] temp = new byte[a.Length];

                a.Position = 0;
                a.Read(temp, 0, (int)a.Length);

                narc.ReplaceEntry(cb_locname.SelectedIndex, (int)a.Length, temp);
            }
            catch (Exception ex)
            {
#if DEBUG
                Database.InsertReader.InsertLogs("error", "Yello", ex);
#endif
            }
        }

        public void LoadCurrentData()
        {
            throw new NotImplementedException();
        }

        public void WriteCurrentBack_Click(object sender, EventArgs e)
        {
            int i = (int.Parse(txt_pkmid.Text) - 1) % 4;
            int indexb = 0;

            if (int.Parse(txt_pkmid.Text) <= 4)
            {
                indexb = 0;
            }
            else if (int.Parse(txt_pkmid.Text) <= 8 && int.Parse(txt_pkmid.Text) >= 5)
            {
                indexb = 1;
            }
            else
            {
                indexb = 2;
            }

            byte[] temp = ByteConverter.ToByte(cb_pokemon.SelectedIndex + 1, 2);

            a.Position = (2 * i) + cb_vergm.SelectedIndex * (26 * 3) + (26 * indexb);
            a.Write(temp, 0, 2);

            WriteHiddenGrottoData();
            WriteNarcBack();
        }

        public void HexView()
        {
            if (st_hexview.Checked)
            {
                DynamicFileByteProvider dynamicFileByteProvider = null;

                try
                {
                    dynamicFileByteProvider = new DynamicFileByteProvider(a);
                }
                catch (Exception ex)
                {
#if DEBUG
                    Database.InsertReader.InsertLogs("error", "Yello", ex);
#endif
                }
                hx_hiddengrotto.ByteProvider = dynamicFileByteProvider;
            }
            else
            {
                hx_hiddengrotto.ByteProvider = null;
            }
        }
        #endregion

        #region HiddenGrottoFunction
        public void ImageBoxEventLoads()
        {
            try
            {
                Internal.ImageBoxUtilities.ImageBoxLoadEvent(IB_Pokemon_Click, pkm_1, pkm_2, pkm_3, pkm_4, pkm_5, pkm_6, pkm_7,
                    pkm_8, pkm_9, pkm_10, pkm_11, pkm_12);

                Internal.ImageBoxUtilities.ImageBoxLoadEvent(IB_Items_Click, item_1, item_2, item_3, item_4, item_5, item_6, item_7, item_8,
                    item_9, item_10, item_11, item_12, item_13, item_14, item_15, item_16, item_17, item_18,
                    item_19, item_20, item_21, item_22, item_23, item_24, item_25, item_26, item_27, item_28,
                    item_29, item_30, item_31, item_32);
            }
            catch (Exception ex)
            {
#if DEBUG
                Database.InsertReader.InsertLogs("error", "Yello", ex);
#endif
            }
        }
        
        private void PositionOffsetPokemon(byte[] temp, int indexa, int indexb, int countbyte, int prebyte)
        {
            try
            {
                a.Position = (indexa * countbyte) + cb_vergm.SelectedIndex * (26 * 3) + (26 * indexb + prebyte);
                a.Read(temp, 0, countbyte);
            }
            catch (Exception ex)
            {
                Database.InsertReader.InsertLogs("Error", "Yellow", ex);
            }
        }

        public void ImageBoxChange(AndiImageBox imgbox, int index, vEnum.HiddenGrottoProperty property)
        {
            if (property == vEnum.HiddenGrottoProperty.item)
            {
                imgbox.Image = ImageIconHandler.setImageItemPictureBox(index);
            }
            else
            {
                imgbox.Image = ImageIconHandler.setImagePictureBox(index);
            }
        }

        public void WritePokemonId()
        {
            if (st_Auto.Checked)
            {
                int i = (int.Parse(txt_pkmid.Text) - 1) % 4;
                int indexb = 0;

                if (int.Parse(txt_pkmid.Text) <= 4)
                {
                    indexb = 0;
                }
                else if (int.Parse(txt_pkmid.Text) <= 8 && int.Parse(txt_pkmid.Text) >= 5)
                {
                    indexb = 1;
                }
                else
                {
                    indexb = 2;
                }

                byte[] temp = ByteConverter.ToByte(cb_pokemon.SelectedIndex + 1, 2);

                a.Position = (2 * i) + cb_vergm.SelectedIndex * (26 * 3) + (26 * indexb);
                a.Write(temp, 0, 2);

                WriteHiddenGrottoData();
                WriteNarcBack();
            }
        }

        public void WriteHiddenGrottoData()
        {
            try
            {
                int i = (int.Parse(txt_pkmid.Text) - 1) % 4;
                int indexb = 0;

                if (int.Parse(txt_pkmid.Text) <= 4)
                {
                    indexb = 0;
                }
                else if (int.Parse(txt_pkmid.Text) <= 8 && int.Parse(txt_pkmid.Text) >= 5)
                {
                    indexb = 1;
                }
                else
                {
                    indexb = 2;
                }

                byte[] temp = ByteConverter.ToByte(cb_pokemon.SelectedIndex + 1, 2);

                temp = ByteConverter.ToByte((long)nm_lv_max.Value, 1);
                a.Position = (i * 1) + cb_vergm.SelectedIndex * (26 * 3) + (26 * indexb) + 8;
                a.WriteByte(temp[0]);
                //a.Write(temp, 0, 1);

                temp = ByteConverter.ToByte((long)nm_lv_min.Value, 1);
                a.Position = (i * 1) + cb_vergm.SelectedIndex * (26 * 3) + (26 * indexb) + 12;
                a.WriteByte(temp[0]);

                temp = ByteConverter.ToByte((long)nm_female_rate.Value, 1);
                a.Position = (i * 1) + cb_vergm.SelectedIndex * (26 * 3) + (26 * indexb) + 16;
                a.WriteByte(temp[0]);

                temp = ByteConverter.ToByte(cb_forme.SelectedIndex, 1);
                a.Position = (i * 1) + cb_vergm.SelectedIndex * (26 * 3) + (26 * indexb) + 20;
                a.WriteByte(temp[0]);
            }
            catch (Exception ex)
            {
#if DEBUG
                Database.InsertReader.InsertLogs("error", "Yello", ex);
#endif
            }
        }
        #endregion

        #region HiddenGrotto ReadData Function
        public void ReadPokemonData(object sender)
        {
            try
            {
                byte[] temp = new byte[2];
                int indexa = (((AndiImageBox)sender).IndexParent - 1) % 4;
                int indexb = GetIndexB(sender);

                PositionOffsetPokemon(temp, indexa, indexb, 2, 0);
                int bb = BitConverter.ToInt16(temp, 0);

                txt_pkmid.Text = ((AndiImageBox)sender).IndexParent + "";
                cb_pokemon.SelectedIndex = bb - 1;

                temp = new byte[1];
                PositionOffsetPokemon(temp, indexa, indexb, 1, 8);
                nm_lv_max.Value = (UInt16)temp[0];

                temp = new byte[1];
                PositionOffsetPokemon(temp, indexa, indexb, 1, 12);
                nm_lv_min.Value = (UInt16)temp[0];

                temp = new byte[1];
                PositionOffsetPokemon(temp, indexa, indexb, 1, 16);
                nm_female_rate.Value = (UInt16)temp[0];

                temp = new byte[1];
                PositionOffsetPokemon(temp, indexa, indexb, 1, 20);
                cb_forme.SelectedIndex = (UInt16)temp[0];

                isReady = true;
            }
            catch (Exception ex)
            {
#if DEBUG
                Database.InsertReader.InsertLogs("error", "Yello", ex);
#endif
            }
        }

        public void ReadItemsData()
        {
            try
            {
                byte[] temp = new byte[2];

                a.Position = ((int.Parse(txt_itemid.Text) - 1) * 2) + 156;
                a.Read(temp, 0, 2);

                cb_items.SelectedIndex = BitConverter.ToInt16(temp, 0);
            }
            catch (Exception ex)
            {
#if DEBUG
                Database.InsertReader.InsertLogs("error", "Yello", ex);
#endif
            }
        }

        private int GetIndexB(object sender)
        {
            if (((AndiImageBox)sender).IndexParent < 5)
            {
                return 0;
            }
            else if (((AndiImageBox)sender).IndexParent < 9)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public void ChangeImagBoxItemList(int id, vEnum.HiddenGrottoProperty property, params AndiImageBox[] ibbox)
        {
            if (property == vEnum.HiddenGrottoProperty.item)
            {
                ImageBoxChange(ibbox[id - 1], cb_items.SelectedIndex, property);
            }
            else
            {
                ImageBoxChange(ibbox[id - 1], cb_pokemon.SelectedIndex + 1, property);
            }
        }

        private void cb_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                andiImageBox2.Image = ImageIconHandler.setImageItemPictureBox(cb_items.SelectedIndex);

                byte[] temp = ByteConverter.ToByte(cb_items.SelectedIndex, 2);

                a.Position = ((int.Parse(txt_itemid.Text) - 1) * 2) + 156;
                a.Write(temp, 0, 2);

                WriteNarcBack();

                ChangeImagBoxItemList(int.Parse(txt_itemid.Text), vEnum.HiddenGrottoProperty.item, item_1, item_2, item_3, item_4, item_5, item_6, item_7, item_8,
                    item_9, item_10, item_11, item_12, item_13, item_14, item_15, item_16, item_17, item_18,
                    item_19, item_20, item_21, item_22, item_23, item_24, item_25, item_26, item_27, item_28,
                    item_29, item_30, item_31, item_32);
            }
            catch (Exception ex)
            {
#if DEBUG
                Database.InsertReader.InsertLogs("error", "Yello", ex);
#endif
            }
        }

        private void cb_pokemon_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_prev_pokemon.Image = ImageIconHandler.setImagePictureBox(cb_pokemon.SelectedIndex + 1);
            string[] datatemp = Database.GetPokemonAlternativeName(cb_pokemon.SelectedIndex + 1);

            if (datatemp.Length < 1)
            {
                cb_forme.Items.Clear();
                cb_forme.Items.Add("Normal");
                cb_forme.SelectedIndex = 0; // pilih alternative formnya
            }
            else
            {
                cb_forme.Items.Clear();
                cb_forme.Items.AddRange(datatemp);
                cb_forme.SelectedIndex = 0; // pilih alternative formnya
            }

            ChangeImagBoxItemList(int.Parse(txt_pkmid.Text), vEnum.HiddenGrottoProperty.pokemon, pkm_1, pkm_2, pkm_3, pkm_4, pkm_5, pkm_6, pkm_7,
                pkm_8, pkm_9, pkm_10, pkm_11, pkm_12);

            if (isReady)
            {
                WritePokemonId();
            }
        }

        private void ImageBoxLoadPicItems()
        {
            byte[] temp = new byte[2];

            ChangeImageBoxPicItemsList(temp, item_1, item_2, item_3, item_4, item_5, item_6, item_7, item_8,
                item_9, item_10, item_11, item_12, item_13, item_14, item_15, item_16, item_17, item_18,
                item_19, item_20, item_21, item_22, item_23, item_24, item_25, item_26, item_27, item_28,
                item_29, item_30, item_31, item_32);
        }

        private void ChangeImageBoxPicItemsList(byte[] temp, params AndiImageBox[] itm)
        {
            int bb = 0;
            for (int i = 0; i < itm.Length; i++)
            {
                a.Position = (i * 2) + 156;
                a.Read(temp, 0, 2);

                bb = BitConverter.ToInt16(temp, 0);

                ImageBoxChange(itm[i], bb, vEnum.HiddenGrottoProperty.item);
            }
        }

        private void ImageBoxLoadPicPokemons()
        {
            byte[] temp = new byte[2];

            for (int i = 0; i < 3; i++)
            {
                a.Position = 0 + cb_vergm.SelectedIndex * (26 * 3) + (26 * i);
                a.Read(temp, 0, 2);
                int aa = (i * 4) + 1;
                int bb = BitConverter.ToInt16(temp, 0);

                switch (aa)
                {
                    case 1:
                        ImageBoxChange(pkm_1, bb, vEnum.HiddenGrottoProperty.pokemon);
                        break;
                    case 5:
                        ImageBoxChange(pkm_5, bb, vEnum.HiddenGrottoProperty.pokemon);
                        break;
                    case 9:
                        ImageBoxChange(pkm_9, bb, vEnum.HiddenGrottoProperty.pokemon);
                        break;
                }

                a.Position = 2 + cb_vergm.SelectedIndex * (26 * 3) + (26 * i);
                a.Read(temp, 0, 2);
                aa = (i * 4) + 2;
                bb = BitConverter.ToInt16(temp, 0);

                switch (aa)
                {
                    case 2:
                        ImageBoxChange(pkm_2, bb, vEnum.HiddenGrottoProperty.pokemon);
                        break;
                    case 6:
                        ImageBoxChange(pkm_6, bb, vEnum.HiddenGrottoProperty.pokemon);
                        break;
                    case 10:
                        ImageBoxChange(pkm_10, bb, vEnum.HiddenGrottoProperty.pokemon);
                        break;
                }

                a.Position = 4 + cb_vergm.SelectedIndex * (26 * 3) + (26 * i);
                a.Read(temp, 0, 2);
                aa = (i * 4) + 3;
                bb = BitConverter.ToInt16(temp, 0);

                switch (aa)
                {
                    case 3:
                        ImageBoxChange(pkm_3, bb, vEnum.HiddenGrottoProperty.pokemon);
                        break;
                    case 7:
                        ImageBoxChange(pkm_7, bb, vEnum.HiddenGrottoProperty.pokemon);
                        break;
                    case 11:
                        ImageBoxChange(pkm_11, bb, vEnum.HiddenGrottoProperty.pokemon);
                        break;
                }

                a.Position = 6 + cb_vergm.SelectedIndex * (26 * 3) + (26 * i);
                a.Read(temp, 0, 2);
                aa = (i * 4) + 4;
                bb = BitConverter.ToInt16(temp, 0);

                switch (aa)
                {
                    case 4:
                        ImageBoxChange(pkm_4, bb, vEnum.HiddenGrottoProperty.pokemon);
                        break;
                    case 8:
                        ImageBoxChange(pkm_8, bb, vEnum.HiddenGrottoProperty.pokemon);
                        break;
                    case 12:
                        ImageBoxChange(pkm_12, bb, vEnum.HiddenGrottoProperty.pokemon);
                        break;
                }
            }
        }
        #endregion

        #region ImageBox EventHandler Click
        private void IB_Items_Click(object sender, EventArgs e)
        {
            try
            {
                txt_itemid.Text = ((AndiImageBox)sender).IndexParent + "";

                Internal.ImageBoxUtilities.ImageBoxGridColor(Color.Gainsboro, item_1, item_2, item_3, item_4, item_5, item_6, item_7, item_8,
                    item_9, item_10, item_11, item_12, item_13, item_14, item_15, item_16, item_17, item_18,
                    item_19, item_20, item_21, item_22, item_23, item_24, item_25, item_26, item_27, item_28,
                    item_29, item_30, item_31, item_32);

                ((AndiImageBox)sender).GridColor = Color.CadetBlue;

                ReadItemsData();
            }
            catch (Exception ex)
            {
#if DEBUG
                Database.InsertReader.InsertLogs("error", "Yello", ex);
#endif
            }
        }

        private void IB_Pokemon_Click(object sender, EventArgs e)
        {
            isReady = false;

            Internal.ImageBoxUtilities.ImageBoxGridColor(Color.Gainsboro, pkm_1, pkm_2, pkm_3, pkm_4, pkm_5, pkm_6, pkm_7,
                pkm_8, pkm_9, pkm_10, pkm_11, pkm_12);

            ((AndiImageBox)sender).GridColor = Color.CadetBlue;

            ReadPokemonData(sender);
        }
        #endregion

        #region ComboBox EventHandler SelectedIndexChanged
        private void cb_vergm_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImageBoxLoadPicPokemons();
        }

        private void cb_locname_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_vergm.SelectedIndex = 0;
            a = new MemoryStream(narc.getdataselected(cb_locname.SelectedIndex));
            label1.Text = "" + cb_locname.SelectedIndex;
            ImageBoxLoadPicPokemons();
            ImageBoxLoadPicItems();
            HexView();
        }

        private void cb_forme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isReady)
            {
                WritePokemonId();
            }
        }
        #endregion

        #region Other EventHandler
        private void NumericValueChanged(object sender, EventArgs e)
        {
            if (isReady)
            {
                WritePokemonId();
            }
        }

        private void st_Auto_Click(object sender, EventArgs e)
        {
            if (st_Auto.Checked)
            {
                st_Auto.Checked = false;
                bt_SaveCurrent.Visible = true;
            }
            else
            {
                bt_SaveCurrent.Visible = false;
                st_Auto.Checked = true;
            }
        }

        private void st_hexview_Click(object sender, EventArgs e)
        {
            if (st_hexview.Checked)
            {
                st_hexview.Checked = false;
                mTab1.TabPages.Remove(tb_hex);
            }
            else
            {
                st_hexview.Checked = true;
                mTab1.TabPages.Add(tb_hex);
            }
        }

        private void et_formecb_Click(object sender, EventArgs e)
        {
            if (et_formecb.Checked)
            {
                et_formecb.Checked = false;
                cb_forme.Enabled = false;
            }
            else
            {
                et_formecb.Checked = true;
                cb_forme.Enabled = true;
            }
        }

        private void HGExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
