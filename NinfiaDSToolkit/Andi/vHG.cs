using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NinfiaDSToolkit.Andi.Controls.HexBox;
using NinfiaDSToolkit.Andi.Controls.ImageBox;
using NinfiaDSToolkit.Andi.Utils;
using NinfiaDSToolkit.Andi.Utils.DB;
using NinfiaDSToolkit.Andi.Utils.Narc;
using WeifenLuo.WinFormsUI.Docking;

namespace NinfiaDSToolkit.Andi
{
    public partial class vHG : DockContent
    {
        AndiNarcReader narc = new AndiNarcReader();
        Stream a = new MemoryStream();
        int indexpokemon = 0;
        bool checkstate = false;

        public vHG()
        {
            InitializeComponent();

            FirstLoads();
            ImageBoxEventLoads();
        }

        #region Proses 1 : load ComboBox , Load ImageBox Items dan Pokemons
        void FirstLoads()
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
            bt_SaveCurrent.Click += bt_SaveCurrent_Click;
            bt_cpyhex.Click += bt_copyhex_Click;
            st_hexview.Click += st_hexview_Click;

            bt_Open.Click += btn_open_Click;
            bt_Save.Click += (this.bt_Save_Click);

            nm_female_rate.ValueChanged += (this.NumericValueChanged);
            nm_lv_min.ValueChanged += (this.NumericValueChanged);
            nm_lv_max.ValueChanged += (this.NumericValueChanged);
        }

        void ImageBoxLoadPokemon(params AndiImageBox[] pkm)
        {
            for (int i = 0; i < pkm.Length; i++)
            {
                pkm[i].IndexParent = (i + 1);
                pkm[i].Click -= IB_Pokemon_Click;
                pkm[i].Click += IB_Pokemon_Click;
            }
        }

        void ImageBoxLoadItems(params AndiImageBox[] itm)
        {
            for (int i = 0; i < itm.Length; i++)
            {
                itm[i].IndexParent = (i + 1);
                itm[i].Click -= IB_Items_Click; // make sure event listener click is not duplicate on same control
                itm[i].Click += IB_Items_Click;
            }
        }

        void ImageBoxEventLoads()
        {
            ImageBoxLoadPokemon(pkm_1,pkm_2,pkm_3,pkm_4,pkm_5,pkm_6,pkm_7,
                pkm_8,pkm_9,pkm_10,pkm_11,pkm_12);

            ImageBoxLoadItems(item_1,item_2,item_3,item_4,item_5,item_6,item_7,item_8,
                item_9,item_10,item_11,item_12,item_13,item_14,item_15,item_16,item_17,item_18,
                item_19,item_20,item_21,item_22,item_23,item_24,item_25,item_26,item_27,item_28,
                item_29,item_30,item_31,item_32);
        }

        void ImageBoxColorItems(params AndiImageBox[] itm)
        {
            for (int i = 0; i < itm.Length; i++)
            {
                if (itm[i].GridColor != Color.Gainsboro)
                {
                    itm[i].GridColor = Color.Gainsboro;
                }
            }
        }

        void IB_Items_Click(object sender, EventArgs e)
        {
            txt_itemid.Text = ((AndiImageBox)sender).IndexParent + "";

            ImageBoxColorItems(item_1, item_2, item_3, item_4, item_5, item_6, item_7, item_8,
                item_9, item_10, item_11, item_12, item_13, item_14, item_15, item_16, item_17, item_18,
                item_19, item_20, item_21, item_22, item_23, item_24, item_25, item_26, item_27, item_28,
                item_29, item_30, item_31, item_32);

            ((AndiImageBox)sender).GridColor = Color.CadetBlue;

            LoadDataItems();
        }

        void LoadDataItems()
        {
            byte[] temp = new byte[2];

            a.Position = ((int.Parse(txt_itemid.Text) - 1) * 2) + 156;
            a.Read(temp, 0, 2);

            cb_items.SelectedIndex = BitConverter.ToInt16(temp, 0);
        }

        void ImageBoxColorPokemon(params AndiImageBox[] pkm)
        {
            for (int i = 0; i < pkm.Length; i++)
            {
                if (pkm[i].GridColor != Color.Gainsboro)
                {
                    pkm[i].GridColor = Color.Gainsboro;
                }
            }
        }

        void IB_Pokemon_Click(object sender, EventArgs e)
        {
            checkstate = false;

            ImageBoxColorPokemon(pkm_1, pkm_2, pkm_3, pkm_4, pkm_5, pkm_6, pkm_7,
                pkm_8, pkm_9, pkm_10, pkm_11, pkm_12);

            ((AndiImageBox)sender).GridColor = Color.CadetBlue;

            ReadHGPokemonData(sender);
        }

        int GetIndexB(object sender)
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

        void PositionHGPokemon(byte[] temp,int indexa, int indexb, int countbyte, int prebyte)
        {
            a.Position = (indexa * countbyte) + cb_vergm.SelectedIndex * (26 * 3) + (26 * indexb + prebyte);
            a.Read(temp, 0, countbyte);
        }

        void ReadHGPokemonData(object sender)
        {
            byte[] temp = new byte[2];
            int indexa = (((AndiImageBox)sender).IndexParent - 1) % 4;
            int indexb = GetIndexB(sender);

            PositionHGPokemon(temp, indexa, indexb, 2, 0);
            int bb = BitConverter.ToInt16(temp, 0);

            txt_pkmid.Text = ((AndiImageBox)sender).IndexParent + "";
            cb_pokemon.SelectedIndex = bb - 1;

            temp = new byte[1];
            PositionHGPokemon(temp, indexa, indexb, 1, 8);
            nm_lv_max.Value = (UInt16)temp[0];

            temp = new byte[1];
            PositionHGPokemon(temp, indexa, indexb, 1, 12);
            nm_lv_min.Value = (UInt16)temp[0];

            temp = new byte[1];
            PositionHGPokemon(temp, indexa, indexb, 1, 16);
            nm_female_rate.Value = (UInt16)temp[0];

            temp = new byte[1];
            PositionHGPokemon(temp, indexa, indexb, 1, 20);
            cb_forme.SelectedIndex = (UInt16)temp[0];

            checkstate = true;
        }
        #endregion

        #region Proses 2 : Buka File dan Simpan File
        void btn_open_Click(object sender, EventArgs e)
        {
            string path = "";

            OpenFileDialog BukaNarcFileDialog = new OpenFileDialog();
            BukaNarcFileDialog.Title = "Hidden Grotto - File Open";
            BukaNarcFileDialog.Filter = "Any Files|*.*|Narc Files|*.*";

            if (BukaNarcFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                path = BukaNarcFileDialog.FileName;

            if (path != "")
            {
                FileStream a = new FileStream(path,FileMode.Open);
                byte[] bytee = new byte[4];

                a.Position = 0;

                a.Read(bytee, 0, 4);

                string check = System.Text.Encoding.ASCII.GetString(bytee);
                a.Close();

                if (check != "NARC")
                {
                    MessageBox.Show("This Not NARC File, File Extension Signature is " + check+", and is not NARC File!","Error!");
                    return;
                }

                narc.OpenData(path);

                if (narc.FileCount != 20)
                {
                    MessageBox.Show("Invalid File.", "Error!");
                    return;
                }

                LoadLocationVersions();
            }
        }

        void LoadLocationVersions()
        {
            cb_locname.SelectedIndex = 0;
            cb_vergm.SelectedIndex = 0;
            cb_locname.Enabled = true;
            mTab1.Enabled = true;
            bt_Save.Enabled = true;
        }

        void bt_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveNarcDialog = new SaveFileDialog();
            SaveNarcDialog.Title = "Save File";
            SaveNarcDialog.Filter = "narc file|*.narc";
            //dialog.FileName = "file_" + comboBox1.SelectedValue;
            //dialog.InitialDirectory = igtfpath;
            if (SaveNarcDialog.ShowDialog() == DialogResult.OK)
            {
                //igtfpath = dialog.FileName.Replace(dialog.file, "");
                File.WriteAllBytes(SaveNarcDialog.FileName, this.narc.CachedData);
            }
        }
        #endregion

        #region ComboBoxEventHandler
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
            loadhexview();
        }

        void ChangeImageChangeItemList(int id, params AndiImageBox[] itm)
        {
            ChangeImageChange(itm[id-1], cb_items.SelectedIndex);
        }

        void ChangeImageChange(AndiImageBox a, int index)
        {
            a.Image = ImageIconHandler.setImageItemPictureBox(index);
        }

        void cb_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            andiImageBox2.Image = ImageIconHandler.setImageItemPictureBox(cb_items.SelectedIndex);

            byte[] temp = ByteConverter.ToByte(cb_items.SelectedIndex,2);

            a.Position = ((int.Parse(txt_itemid.Text)-1)* 2) + 156;
            a.Write(temp, 0, 2);

            writetoback();

            ChangeImageChangeItemList(int.Parse(txt_itemid.Text),item_1, item_2, item_3, item_4, item_5, item_6, item_7, item_8,
                item_9, item_10, item_11, item_12, item_13, item_14, item_15, item_16, item_17, item_18,
                item_19, item_20, item_21, item_22, item_23, item_24, item_25, item_26, item_27, item_28,
                item_29, item_30, item_31, item_32);
        }

        void ChangeImageChangepkm(AndiImageBox a, int index)
        {
            a.Image = ImageIconHandler.setImagePictureBox(index);
        }

        void ChangeImageChangePokemonList(int id, params AndiImageBox[] pkm)
        {
            ChangeImageChangepkm(pkm[id - 1], cb_pokemon.SelectedIndex+1);
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

            ChangeImageChangePokemonList(int.Parse(txt_pkmid.Text), pkm_1, pkm_2, pkm_3, pkm_4, pkm_5, pkm_6, pkm_7,
                pkm_8, pkm_9, pkm_10, pkm_11, pkm_12);

            if (checkstate)
            {
                writePokemonId();
            }
        }

        private void cb_forme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkstate)
            {
                writePokemonId();
            }
        }
        #endregion

        #region Other
        void ChangeImageChangePicItemList(byte[] temp, params AndiImageBox[] itm)
        {
            int bb=0;
            for (int i = 0; i < itm.Length; i++)
            {
                a.Position = (i * 2) + 156;
                a.Read(temp, 0, 2);

                bb = BitConverter.ToInt16(temp, 0);

                ChangeImageChange(itm[i], bb);
            }
            
        }

        private void ImageBoxLoadPicItems()
        {
            byte[] temp = new byte[2];

            ChangeImageChangePicItemList(temp, item_1, item_2, item_3, item_4, item_5, item_6, item_7, item_8,
                item_9, item_10, item_11, item_12, item_13, item_14, item_15, item_16, item_17, item_18,
                item_19, item_20, item_21, item_22, item_23, item_24, item_25, item_26, item_27, item_28,
                item_29, item_30, item_31, item_32);
        }

        private void ImageBoxLoadPicPokemons()
        {
            byte[] temp = new byte[2];

            for (int i = 0; i < 3; i++)
            {
                a.Position = 0 + cb_vergm.SelectedIndex*(26*3) + (26*i);
                a.Read(temp, 0, 2);
                int aa = (i*4) + 1;
                int bb = BitConverter.ToInt16(temp, 0);

                switch (aa)
                {
                    case 1:
                        ChangeImageChangepkm(pkm_1, bb);
                        break;
                    case 5:
                        ChangeImageChangepkm(pkm_5, bb);
                        break;
                    case 9:
                        ChangeImageChangepkm(pkm_9, bb);
                        break;
                }

                a.Position = 2 + cb_vergm.SelectedIndex * (26 * 3) + (26 * i);
                a.Read(temp, 0, 2);
                aa = (i * 4) + 2;
                bb = BitConverter.ToInt16(temp, 0);

                switch (aa)
                {
                    case 2:
                        ChangeImageChangepkm(pkm_2, bb);
                        break;
                    case 6:
                        ChangeImageChangepkm(pkm_6, bb);
                        break;
                    case 10:
                        ChangeImageChangepkm(pkm_10, bb);
                        break;
                }

                a.Position = 4 + cb_vergm.SelectedIndex * (26 * 3) + (26 * i);
                a.Read(temp, 0, 2);
                aa = (i * 4) + 3;
                bb = BitConverter.ToInt16(temp, 0);

                switch (aa)
                {
                    case 3:
                        ChangeImageChangepkm(pkm_3, bb);
                        break;
                    case 7:
                        ChangeImageChangepkm(pkm_7, bb);
                        break;
                    case 11:
                        ChangeImageChangepkm(pkm_11, bb);
                        break;
                }

                a.Position = 6 + cb_vergm.SelectedIndex * (26 * 3) + (26 * i);
                a.Read(temp, 0, 2);
                aa = (i * 4) + 4;
                bb = BitConverter.ToInt16(temp, 0);

                switch (aa)
                {
                    case 4:
                        ChangeImageChangepkm(pkm_4, bb);
                        break;
                    case 8:
                        ChangeImageChangepkm(pkm_8, bb);
                        break;
                    case 12:
                        ChangeImageChangepkm(pkm_12, bb);
                        break;
                }
            }
        }

        void loadhexview()
        {
            if (st_hexview.Checked)
            {
                DynamicFileByteProvider dynamicFileByteProvider = null;

                try
                {
                    dynamicFileByteProvider = new DynamicFileByteProvider(a);
                }
                catch { }

                hx_hiddengrotto.ByteProvider = dynamicFileByteProvider;
            }
            else
            {
                hx_hiddengrotto.ByteProvider = null;
            }
        }

        void writePokemonId()
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

                writeA();
                writetoback();
            }
        }

        void writeA()
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

        void writetoback()
        {
            byte[] temp = new byte[a.Length];

            a.Position = 0;
            a.Read(temp, 0, (int) a.Length);

            narc.ReplaceEntry(cb_locname.SelectedIndex, (int)a.Length, temp);
        }

        private void NumericValueChanged(object sender, EventArgs e)
        {
            if (checkstate)
            {
                writePokemonId();
            }
        }
        #endregion

        private void bt_copyhex_Click(object sender, EventArgs e)
        {
            hx_hiddengrotto.CopyHex();
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

        private void bt_SaveCurrent_Click(object sender, EventArgs e)
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

            writeA();
            writetoback();
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
    }
}
