using System;
using System.Drawing;
using System.IO;
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
    public partial class vExperience : DockContent
    {
        AndiNarcReader narc = new AndiNarcReader();
        Stream a = new MemoryStream();
        private bool checkgridfocus = true;
        private string _LastPath = "";

        public vExperience()
        {
            InitializeComponent();
            andiCustomTabControl1.Enabled = false;
            grid1.SelectionMode = GridSelectionMode.Row;
            grid1.Selection.EnableMultiSelection = false;
            grid1.MouseClick += Selection_SelectionChanged;
            grid1.KeyDown += Selection_SelectionChanged;
            grid1.KeyUp += Selection_SelectionChanged;
            _LastPath = Program.GlobalPath;
            grid1.Selection.FocusRowEntered += Selection_FocusRowEntered;
        }

        void grideventchanged()
        {
            try
            {
                label1.Text = grid1.Selection.ActivePosition.Row + "";
                nm_value.Value = (long)grid1[grid1.Selection.ActivePosition.Row, 1].Value;
            }
            catch { }
        }

        private void Selection_FocusRowEntered(object sender, RowEventArgs e)
        {
            grideventchanged();

            if (!checkgridfocus)
            {
                andiListBox1.Focus();
                checkgridfocus = true;
            }
        }

        private void Selection_SelectionChanged(object sender, KeyEventArgs e)
        {
            grideventchanged();
            checkgridfocus = true;
        }

        private void Selection_SelectionChanged(object sender, MouseEventArgs e)
        {
            grideventchanged();
            checkgridfocus = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string path = "";

            path = AndiFileDialog.OpenDialog(path, _LastPath, "Experience Narc - File Open", "Any Files|*.*|Narc Files|*.*");

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

                andiListBox1.Items.Clear();
                string[] xxx = Database.GetCommonText(1);
                
                for (int i = 0; i < narc.FileCount; i++)
                {
                    if (i > 0 && i < 7)
                    {
                        andiListBox1.Items.Add(xxx[i-1]);
                    }
                    else
                    {
                        andiListBox1.Items.Add("Data " + i);
                    }
                }

                andiListBox1.SelectedIndex = 0;
                andiCustomTabControl1.Enabled = true;
            }
        }

        private void andiListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            a = new MemoryStream(narc.getdataselected(andiListBox1.SelectedIndex));
            checkgridfocus = false;
            loadhexview();
            loaddata();
        }

        private void loaddata()
        {
            int lenghtdata = (int) a.Length/4;
            long[] data = new long[lenghtdata];

            for (int i = 0; i < lenghtdata; i++)
            {
                byte[] temp = new byte[4];
                a.Position = i*4;
                a.Read(temp, 0, 4);
                data[i] = BitConverter.ToUInt32(temp, 0);
            }

            FillGrid.Build(grid1, lenghtdata,1,"Exp");
            FillGrid.Fill(grid1, data);
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
            AndiFileDialog.NarcSaveDialog(narc, Path.GetDirectoryName(_LastPath), "Save Experience Data", "narc file|*.narc");
        }
    }
}
