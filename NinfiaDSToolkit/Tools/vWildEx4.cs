using System;
using System.IO;
using System.Windows.Forms;
using NinfiaDSToolkit.Andi.Controls.HexBox;
using NinfiaDSToolkit.Andi.Utils;
using NinfiaDSToolkit.Andi.Utils.Narc;
using NinfiaDSToolkit.Tools.Internal;
using SourceGrid;
using SourceGrid.Cells.Views;
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
        private FileInfo flepath;

        public vWildEx4()
        {
            InitializeComponent();
            TabC1.Enabled = false;
            EventsFormLoad();
        }

        #region CommonFunction
        public void EventsFormLoad()
        {
            _LastPath = Program.GlobalPath;
            flepath = new FileInfo(_LastPath);

            grid1.SelectionMode = GridSelectionMode.Row;
            grid1.Selection.EnableMultiSelection = false;
            grid1.MouseClick += BaseGridSelection_SelectionChanged;
            grid1.KeyDown += BaseGridSelection_SelectionChanged;
            grid1.KeyUp += BaseGridSelection_SelectionChanged;
            grid1.Selection.FocusRowEntered += BaseGridSelection_FocusRowEntered;

            this.GotFocus += GotFocusF;
        }

        public void EventsAfterOpenFile()
        {
            WeExList.Items.Clear();

            string[] extname = Database.GetCommonText(2);

            for (int i = 0; i < narc.FileCount; i++)
            {
                WeExList.Items.Add(extname[i]);
            }

            cb_pkm.Items.Clear();
            pkmname = Database.GetPokemonName(4, 1);
            cb_pkm.Items.AddRange(pkmname);

            WeExList.SelectedIndex = 0;
            TabC1.Enabled = true;
        }

        public void GotFocusF(object sender, EventArgs e)
        {
            try
            {
                Program.mForm.toolStripLabel1.Text = flepath.Name + " (" + flepath.Length + ")";
            }
            catch(Exception ex)
            {
                Program.mForm.toolStripLabel1.Text = "";
            }
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

                flepath = new FileInfo(path);
                Program.mForm.toolStripLabel1.Text = flepath.Name + " (" + flepath.Length + ")";

                if (Utils.CheckMagicHeaderID.get(path) != "NARC")
                {
                    MessageBox.Show("This Not NARC File, File Extension Signature is " + Utils.CheckMagicHeaderID.get(path) + ", and is not NARC File!", "Error!");
                    return;
                }

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
            Utils.LoadCurrentData.WildEx4((int) a.Length / 4,grid1,pkmname,a);
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
            a.Write(ByteConverter.ToByte(angka2, 4), 0, 4);

            int r = angka + 1;
            
            Cell view = new Cell();

            grid1[r, 1] = new SourceGrid.Cells.Cell(pkmname[angka2-1]);
            grid1[r, 1].View = view;
            grid1.Refresh();

            WriteNarcBack();
        }
        #endregion
    }
}
