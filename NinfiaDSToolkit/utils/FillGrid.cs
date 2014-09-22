using System.Collections.Generic;
using System.Drawing;
using Andi.Utils.Database;
using SourceGrid;
using SourceGrid.Cells;
using ContentAlignment = DevAge.Drawing.ContentAlignment;

namespace Andi.Toolkit.utils
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

        internal static Cell NewCell(object input)
        {
            return new Cell(input);
        }

        internal static void Build(Grid a, int m, int n = 3, params string[] headername)
        {
            try
            {
                Reset(a, m, n);
                view.BackColor = Color.White;

                for (int r = a.FixedRows; r < a.RowsCount; r++)
                {
                    a[r, 0] = new RowHeader(r);
                }

                for (int c = a.FixedColumns; c < a.ColumnsCount; c++)
                {
                    ColumnHeader header = new ColumnHeader(headername[c - 1]);

                    header.AutomaticSortEnabled = true;
                    header.View.TextAlignment = ContentAlignment.MiddleCenter;
                    a[0, c] = header;
                }

                ColumnHeader header1 = new ColumnHeader("#");

                header1.SortComparer = new MultiColumnsComparer(1, 2, 3, 4);

                a[0, 0] = header1;

                for (int r = a.FixedRows; r < a.RowsCount; r++)
                {
                    for (int c = a.FixedColumns; c < a.ColumnsCount; c++)
                    {
                        a[r, c] = NewCell("");
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
                a[r, 1] = NewCell(data[r - 1]);
                a[r, 1].View = view;
            }

            a.Update();
            a.Selection.Focus(new Position(focusrow, focuscolumn), true);
            a.AutoSizeCells();
        }

        internal static void Fill(Grid a, long[] data, int focusrow = 1, int focuscolumn = 1, bool multiline = true)
        {
            view.BackColor = Color.White;
            editor.Control.Multiline = multiline;

            for (int r = a.FixedRows; r < a.RowsCount; r++)
            {
                a[r, 1] = NewCell(data[r - 1]);
                a[r, 1].View = view;
            }

            a.Update();
            a.Selection.Focus(new Position(focusrow, focuscolumn), true);
            a.AutoSizeCells();
        }

        internal static void FillMoveset(Grid a, List<MoveList> data, int focusrow = 1, int focuscolumn = 1, bool multiline = true)
        {
            view.BackColor = Color.White;
            editor.Control.Multiline = multiline;

            for (int r = a.FixedRows; r < a.RowsCount; r++)
            {
                a[r, 1] = NewCell(data[r - 1].id);
                a[r, 2] = NewCell(MVGList.movelist[data[r - 1].move]);
                a[r, 3] = NewCell(data[r - 1].level);
                a[r, 1].View = view;
                a[r, 2].View = view;
                a[r, 3].View = view;
            }

            a.Update();

            try
            {
                a.Selection.Focus(new Position(focusrow, focuscolumn), true);
            }
            catch
            {

            }
            a.AutoSizeCells();
        }
    }
}
