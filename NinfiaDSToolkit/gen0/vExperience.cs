using System;
using System.IO;
using System.Windows.Forms;
using Andi.Libs.HexBox;
using Andi.Toolkit.utils;
using Andi.Toolkit.utils.Internal;
using Andi.Utils.Database;
using Andi.Utils.Dialogs;
using Andi.Utils.Io;
using Andi.Utils.Nitro.Archive;
using SourceGrid;
using WeifenLuo.WinFormsUI.Docking;

namespace Andi.Toolkit.gen0
{
    public partial class vExperience : DockContent, ICommonFormLayout, IGridFormLayout
    {
        AndiNarcReader narc = new AndiNarcReader();
        Stream a = new MemoryStream();
        public bool checkgridfocus = true;
        public string _LastPath = "";
        private FileInfo flepath;

        public vExperience()
        {
            InitializeComponent();
            EventsFormLoad();
        }

        #region CommonFunction
        public void EventsFormLoad()
        {
            andiCustomTabControl1.Enabled = false;
            grid1.SelectionMode = GridSelectionMode.Row;
            grid1.Selection.EnableMultiSelection = false;
            grid1.MouseClick += BaseGridSelection_SelectionChanged;
            grid1.KeyDown += BaseGridSelection_SelectionChanged;
            grid1.KeyUp += BaseGridSelection_SelectionChanged;

            _LastPath = Program.GlobalPath;
            flepath = new FileInfo(_LastPath);

            grid1.Selection.FocusRowEntered += BaseGridSelection_FocusRowEntered;
            this.GotFocus += GotFocusF;
        }

        public void OpenFile_Click(object sender, EventArgs e)
        {
            string path = "";

            path = AndiFileDialog.OpenDialog(path, _LastPath, "Experience Narc - File Open", "Any Files|*.*|Narc Files|*.*");

            if (path != "")
            {
                Program.GlobalPath = Path.GetDirectoryName(path);
                _LastPath = Path.GetDirectoryName(path);

                flepath = new FileInfo(path);
                Program.mForm.fname.Text = flepath.Name;
                Program.mForm.fsize.Text = flepath.Length + "";

                if (CheckMagicHeaderID.get(path) != "NARC")
                {
                    MessageBox.Show("This Not NARC File, File Extension Signature is " + CheckMagicHeaderID.get(path) + ", and is not NARC File!", "Error!");
                    return;
                }

                a.Close();

                narc.OpenData(path);
                EventsAfterOpenFile();
            }
        }

        public void SaveFile_Click(object sender, EventArgs e)
        {
            AndiFileDialog.NarcSaveDialog(narc, Path.GetDirectoryName(_LastPath), "Save Experience Data", "narc file|*.narc");
        }

        public void EventsAfterOpenFile()
        {
            andiListBox1.Items.Clear();
            string[] xxx = Database.GetCommonText(1);

            for (int i = 0; i < narc.FileCount; i++)
            {
                if (i > 0 && i < 7)
                {
                    andiListBox1.Items.Add(xxx[i - 1]);
                }
                else
                {
                    andiListBox1.Items.Add("Data " + i);
                }
            }

            andiListBox1.SelectedIndex = 0;
            andiCustomTabControl1.Enabled = true;
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

        public void LoadCurrentData()
        {
            int lenghtdata = (int)a.Length / 4;
            long[] data = new long[lenghtdata];

            for (int i = 0; i < lenghtdata; i++)
            {
                byte[] temp = new byte[4];
                a.Position = i * 4;
                a.Read(temp, 0, 4);
                data[i] = BitConverter.ToUInt32(temp, 0);
            }

            FillGrid.Build(grid1, lenghtdata, 1, "Exp");
            FillGrid.Fill(grid1, data);
        }

        public void WriteNarcBack()
        {
            byte[] temp = new byte[a.Length];

            a.Position = 0;
            a.Read(temp, 0, (int)a.Length);

            narc.ReplaceEntry(andiListBox1.SelectedIndex, temp.Length, temp);
        }
        #endregion

        #region Grid EventHandler Function
        public void BaseGridSelectionChanged()
        {
            try
            {
                label1.Text = grid1.Selection.ActivePosition.Row + "";
                nm_value.Value = (long)grid1[grid1.Selection.ActivePosition.Row, 1].Value;
            }
            catch { }
        }

        public void BaseGridSelection_FocusRowEntered(object sender, RowEventArgs e)
        {
            BaseGridSelectionChanged();

            if (!checkgridfocus)
            {
                andiListBox1.Focus();
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

        #region Other EventHandler
        private void andiListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            a = new MemoryStream(narc.getdataselected(andiListBox1.SelectedIndex));
            checkgridfocus = false;
            HexView();
            LoadCurrentData();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int angka = int.Parse(label1.Text) - 1;
            long angka2 = (long) nm_value.Value;

            a.Position = angka*4;
            a.Write(ByteConverter.ToByte(angka2,4),0,4);

            int r = angka + 1;

            SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();

            grid1[r, 1] = new SourceGrid.Cells.Cell(angka2);
            grid1[r, 1].View = view;
            grid1.Refresh();

            WriteNarcBack();
        }
        #endregion
    }
}
