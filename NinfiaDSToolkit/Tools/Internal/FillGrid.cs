using System.Collections.Generic;
using System.Drawing;
using NinfiaDSToolkit.Andi.Utils;
using SourceGrid;
using ContentAlignment = DevAge.Drawing.ContentAlignment;

namespace NinfiaDSToolkit.Tools.Internal
{
    public class FillGrid
    {
        static SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();
        static  SourceGrid.Cells.Editors.TextBox editor = new SourceGrid.Cells.Editors.TextBox(typeof(string));

        internal static void Reset(Grid a, int m, int n)
        {
            a.Redim(0, 0);
            a.Redim(m + 1, n + 1);
            a.FixedRows = 1;
            a.FixedColumns = 1;
        }

        internal static void Build(Grid a, int m, int n = 3, params string[] headername)
        {
            try
            {
                Reset(a, m, n);
                view.BackColor = Color.White;

                for (int r = a.FixedRows; r < a.RowsCount; r++)
                {
                    a[r, 0] = new SourceGrid.Cells.RowHeader(r);
                }

                for (int c = a.FixedColumns; c < a.ColumnsCount; c++)
                {
                    SourceGrid.Cells.ColumnHeader header = new SourceGrid.Cells.ColumnHeader(headername[c - 1]);
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
                        a[r, c].View = view;
                    }
                }

                a.Update();
                a.AutoSizeCells();
            }
            catch { }
        }

        internal static void Fill(Grid a, object[] data, int focusrow = 1, int focuscolumn = 1, bool multiline = true)
        {
            view.BackColor = Color.White;
            editor.Control.Multiline = multiline;

            for (int r = a.FixedRows; r < a.RowsCount; r++)
            {
                a[r, 1] = new SourceGrid.Cells.Cell(data[r - 1]);
                a[r, 1].View = view;
            }

            a.Update();
            a.Selection.Focus(new SourceGrid.Position(focusrow, focuscolumn), true);
            a.AutoSizeCells();
        }

        internal static void Fill(Grid a, long[] data, int focusrow = 1, int focuscolumn = 1, bool multiline = true)
        {
            view.BackColor = Color.White;
            editor.Control.Multiline = multiline;

            for (int r = a.FixedRows; r < a.RowsCount; r++)
            {
                a[r, 1] = new SourceGrid.Cells.Cell(data[r - 1]);
                a[r, 1].View = view;
            }

            a.Update();
            a.Selection.Focus(new SourceGrid.Position(focusrow, focuscolumn), true);
            a.AutoSizeCells();
        }

        internal static void FillMoveset(Grid a, List<MoveList> data, int focusrow = 1, int focuscolumn = 1, bool multiline = true)
        {
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
            }

            a.Update();

            try
            {
                a.Selection.Focus(new SourceGrid.Position(focusrow, focuscolumn), true);
            }
            catch
            {

            }
            a.AutoSizeCells();
        }
    }
}
