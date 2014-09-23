using System;
using System.IO;
using System.Windows.Forms;
using Andi.Libs.HexBox;
using WeifenLuo.WinFormsUI.Docking;

namespace Andi.Toolkit.utils2.Arc
{
    public partial class NarcExplorer : DockContent
    {
        private Andi.Utils.Nitro.Archive.Narc narc;
        //AndiGarcReader garc = new AndiGarcReader();
        Stream a = new MemoryStream();

        public NarcExplorer()
        {
            InitializeComponent();
            //hexBox1.CurrentLineChanged += hexBox1_CurrentPositionInLineChanged;
            //hexBox1.CurrentPositionInLineChanged += hexBox1_CurrentPositionInLineChanged;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string path = "";

            OpenFileDialog openROMDialog = new OpenFileDialog();
            openROMDialog.Filter = "Any Files|*.*|Narc Files|*.*";

            if (openROMDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                path = openROMDialog.FileName;

            if (path != "")
            {
                FileStream a = new FileStream(path, FileMode.Open);

                a.Position = 0;
                byte[] bytee = new byte[4];

                a.Read(bytee, 0, 4);
                string check = System.Text.Encoding.ASCII.GetString(bytee);

                //if (check != "NARC")
                //{
                //    MessageBox.Show("This Not NARC File, File Extension Signature is " + check + ", and is not NARC File!", "Error!");
                //    return;
                //}

                a.Close();

                //garc = new AndiGarcReader(path);

                narc = new Andi.Utils.Nitro.Archive.Narc(path,true);


                andiListBox1.Items.Clear();
                for (int i = 0; i < (int) narc.NARCS.FATBheader.Count; i++)
                {
                    andiListBox1.Items.Add("Data" + i);
                }

                andiListBox1.SelectedIndex = 0;
            }
        }

        private void andiListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //a = new MemoryStream(garc.Extract(andiListBox1.SelectedIndex));
            a = new MemoryStream(narc.getdataselected(andiListBox1.SelectedIndex));
            loadhexview();
        }

        void loadhexview()
        {
            DynamicFileByteProvider dynamicFileByteProvider = null;

            try
            {
                // try to open in write mode
                dynamicFileByteProvider = new DynamicFileByteProvider(a);
            }
            catch
            {

            }

            hexBox1.ByteProvider = dynamicFileByteProvider;
        }
    }
}
