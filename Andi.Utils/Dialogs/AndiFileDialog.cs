using System.Windows.Forms;
using Andi.Utils.Nitro.Archive;

namespace Andi.Utils.Dialogs
{
    public class AndiFileDialog
    {
        public static string OpenDialog(string fb, string lstpath, string title, string filter)
        {
            OpenFileDialog BukaNarcFileDialog = new OpenFileDialog();
            BukaNarcFileDialog.Title = title;
            BukaNarcFileDialog.Filter = filter;
            BukaNarcFileDialog.InitialDirectory = lstpath;

            if (BukaNarcFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fb = BukaNarcFileDialog.FileName;
            }

            return fb;
        }

        public static void NarcSaveDialog(AndiNarcReader narc, string lstpath, string title, string filter)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = title;
            dialog.Filter = filter;
            dialog.InitialDirectory = lstpath;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                narc.SaveData(dialog.FileName);
            }
        }
    }
}
