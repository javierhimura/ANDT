using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Andi.Utils.Dialogs;
using SourceGrid;
using WeifenLuo.WinFormsUI.Docking;

namespace Andi.Toolkit.utils
{
    public partial class ovl9tableview : DockContent
    {
        private string _LastPath = "";
        private Stream a;

        public ovl9tableview()
        {
            InitializeComponent();
            _LastPath = Application.StartupPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "";

            path = AndiFileDialog.OpenDialog(path, _LastPath, "OVA9 Table - File Open", "Any Files|*.*|Bin Files|*.bin");

            if (path != "")
            {
                a = new FileStream(path, FileMode.Open);
                int b = (int)(a.Length/32);
                object[,] datatemp = new object[b,9];

                for (int i = 0; i < b; i++)
                {
                    byte[] buffernew = new byte[4];
                    a.Position = 0 + i*32;
                    a.Read(buffernew, 0, 4);
                    datatemp[i, 0] = BitConverter.ToUInt32(buffernew, 0);
                    a.Position = 4 + i * 32;
                    a.Read(buffernew, 0, 4);
                    datatemp[i, 1] = BitConverter.ToUInt32(buffernew, 0).ToString("x8");
                    a.Position = 8 + i * 32;
                    a.Read(buffernew, 0, 4);
                    datatemp[i, 2] = BitConverter.ToUInt32(buffernew, 0);
                    a.Position = 12 + i * 32;
                    a.Read(buffernew, 0, 4);
                    datatemp[i, 3] = BitConverter.ToUInt32(buffernew, 0);
                    a.Position = 16 + i * 32;
                    a.Read(buffernew, 0, 4);
                    datatemp[i, 4] = BitConverter.ToUInt32(buffernew, 0).ToString("x8");
                    a.Position = 20 + i * 32;
                    a.Read(buffernew, 0, 4);
                    datatemp[i, 5] = BitConverter.ToUInt32(buffernew, 0).ToString("x8");
                    a.Position = 24 + i * 32;
                    a.Read(buffernew, 0, 4);
                    datatemp[i, 6] = BitConverter.ToUInt32(buffernew, 0);
                    a.Position = 28 + i * 32;
                    buffernew = new byte[3];
                    a.Read(buffernew, 0, 3);
                    datatemp[i, 7] = BitConverter.ToUInt16(buffernew, 0).ToString("x8");

                    a.Position = 31 + i * 32;
                    buffernew = new byte[1];
                    a.Read(buffernew, 0, 1);
                    datatemp[i, 8] = (int) buffernew[0];
                }

                FillGrid.Build(grid1, b, 9, "OVA#", "RAM Addr", "RAM Size", "BSS Size", "Static InitStart", "Static InitEnd", "File ID#", "RESERVED", "Compressed Flag");
                Fill(grid1,datatemp);
            }
        }

        #region Filling Grid
        private static void Fill(Grid a, object[,] data, bool multiline = true)
        {
            SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();
            SourceGrid.Cells.Editors.TextBox editor = new SourceGrid.Cells.Editors.TextBox(typeof(string));
            view.BackColor = Color.White;
            editor.Control.Multiline = multiline;

            for (int r = a.FixedRows; r < a.RowsCount; r++)
            {
                a[r, 1] = new SourceGrid.Cells.Cell(data[r - 1, 0]);
                a[r, 2] = new SourceGrid.Cells.Cell(data[r - 1, 1]);
                a[r, 3] = new SourceGrid.Cells.Cell(data[r - 1, 2]);
                a[r, 4] = new SourceGrid.Cells.Cell(data[r - 1, 3]);
                a[r, 5] = new SourceGrid.Cells.Cell(data[r - 1, 4]);
                a[r, 6] = new SourceGrid.Cells.Cell(data[r - 1, 5]);
                a[r, 7] = new SourceGrid.Cells.Cell(data[r - 1, 6]);
                a[r, 8] = new SourceGrid.Cells.Cell(data[r - 1, 7]);
                a[r, 9] = new SourceGrid.Cells.Cell(data[r - 1, 8]);
                a[r, 1].View = view;
                a[r, 2].View = view;
                a[r, 3].View = view;
                a[r, 4].View = view;
                a[r, 5].View = view;
                a[r, 6].View = view;
                a[r, 7].View = view;
                a[r, 8].View = view;
                a[r, 9].View = view;
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

        private void button2_Click(object sender, EventArgs e)
        {
            grid1.PerformCopy(new RangeRegion(new Range(1, 1, grid1.RowsCount, grid1.ColumnsCount)));
        }
    }
}
