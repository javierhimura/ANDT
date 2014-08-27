using System;
using System.IO;
using System.Windows.Forms;
using NinfiaDSToolkit.Andi.Controls.HexBox;
using NinfiaDSToolkit.Andi.Utils;
using NinfiaDSToolkit.Andi.Utils.Narc;
using NinfiaDSToolkit.Tools.Internal;
using NinfiaDSToolkit.Tools.Object;
using SourceGrid;
using WeifenLuo.WinFormsUI.Docking;

namespace NinfiaDSToolkit.Tools
{
    public partial class vWildEx4 : DockContent, ICommonFormLayout, IGridFormLayout
    {
        AndiNarcReader narc = new AndiNarcReader();
        Stream a = new MemoryStream();
        public string[] pkmname = new string[1];
        public bool isGridFocus = true;
        public string _LastPath = "";

        public vWildEx4()
        {
            InitializeComponent();
            TabC1.Enabled = false;
            _LastPath = Program.GlobalPath;
            EventsFormLoad();
        }

        #region CommonFunction
        public void EventsFormLoad()
        {
            grid1.SelectionMode = GridSelectionMode.Row;
            grid1.Selection.EnableMultiSelection = false;
            grid1.MouseClick += BaseGridSelection_SelectionChanged;
            grid1.KeyDown += BaseGridSelection_SelectionChanged;
            grid1.KeyUp += BaseGridSelection_SelectionChanged;
            grid1.Selection.FocusRowEntered += BaseGridSelection_FocusRowEntered;
        }

        public void EventsAfterOpenFile()
        {
            WeExList.Items.Clear();

            string[] extname = Database.GetCommonText(2);

            for (int i = 0; i < narc.FileCount; i++)
            {
                WeExList.Items.Add(extname[i]);
            }

            //andiListBox1.Items.AddRange(MVGList.GetPokemonNameMVList());
            cb_pkm.Items.Clear();
            pkmname = Database.GetPokemonName(4, 1);
            cb_pkm.Items.AddRange(pkmname);

            WeExList.SelectedIndex = 0;
            TabC1.Enabled = true;
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
                // try to open in write mode
                dynamicFileByteProvider = new DynamicFileByteProvider(a);
            }
            catch { }

            hexBox1.ByteProvider = dynamicFileByteProvider;
        }

        public void WriteNarcBack()
        {
            byte[] temp = new byte[a.Length];

            a.Position = 0;
            a.Read(temp, 0, (int)a.Length);

            narc.ReplaceEntry(WeExList.SelectedIndex, temp.Length, temp);
        }

        public void OpenFile_Click(object sender, EventArgs e)
        {
            string path = "";

            path = AndiFileDialog.OpenDialog(path, _LastPath, "WildEncounter EX Gen IV - File Open", "Any Files|*.*|Narc Files|*.*");

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
                EventsAfterOpenFile();
            }
        }

        public void SaveFile_Click(object sender, EventArgs e)
        {
            AndiFileDialog.NarcSaveDialog(narc, Path.GetDirectoryName(_LastPath), "WildEncounter Ex G4 Data", "narc file|*.narc");
        }

        public void LoadCurrentData()
        {
            int lenghtdata = (int)a.Length / 4;
            string[] data = new string[lenghtdata];

            for (int i = 0; i < lenghtdata; i++)
            {
                byte[] temp = new byte[4];
                a.Position = i * 4;
                a.Read(temp, 0, 4);
                data[i] = pkmname[BitConverter.ToUInt32(temp, 0) - 1];
            }

            FillGrid.Build(grid1, lenghtdata);
            FillGrid.Fill(grid1, data);
        }
        #endregion

        #region Grid Selection EventHandler Changed
        public void BaseGridSelectionChanged()
        {
            try
            {
                toolStripLabel1.Text = grid1.Selection.ActivePosition.Row + "";
                cb_pkm.Text = grid1[grid1.Selection.ActivePosition.Row, 1].Value.ToString();
            }
            catch { }
        }

        public void BaseGridSelection_FocusRowEntered(object sender, RowEventArgs e)
        {
            BaseGridSelectionChanged();

            if (!isGridFocus)
            {
                WeExList.Focus();
                isGridFocus = true;
            }
        }

        public void BaseGridSelection_SelectionChanged(object sender, KeyEventArgs e)
        {
            BaseGridSelectionChanged();
            isGridFocus = true;
        }

        public void BaseGridSelection_SelectionChanged(object sender, MouseEventArgs e)
        {
            BaseGridSelectionChanged();
            isGridFocus = true;
        }
        #endregion

        #region WildEx 4 Function
        private void andiListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int angka = WeExList.SelectedIndex;
            isGridFocus = false;
            a = new MemoryStream(narc.getdataselected(angka));

            HexView();

            if (angka == 1 || angka == 11)
            {
                FillGrid.Build(grid1, 0, 2, "Pokemon");
            }
            else
            {
                LoadCurrentData();
            }
        }

        private void andiImageComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pkm_1.Image = ImageIconHandler.setImagePictureBox(cb_pkm.SelectedIndex+1);

            int angka = int.Parse(toolStripLabel1.Text) - 1;
            long angka2 = (long)cb_pkm.SelectedIndex +1;

            a.Position = angka * 4;
            a.Write(NinfiaDSToolkit.Andi.Utils.ByteConverter.ToByte(angka2, 4), 0, 4);

            int r = angka + 1;
            SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();

            grid1[r, 1] = new SourceGrid.Cells.Cell(pkmname[angka2-1]);
            grid1[r, 1].View = view;
            grid1.Refresh();

            WriteNarcBack();
        }
        #endregion
    }
}
