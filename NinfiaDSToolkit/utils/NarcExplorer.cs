using System;
using System.IO;
using System.Windows.Forms;
using Andi.Libs.HexBox;
using Andi.Utils.Citro.Archive;
using Andi.Utils.Database;
using Andi.Utils.Nitro.Archive;
using WeifenLuo.WinFormsUI.Docking;

namespace Andi.Toolkit.utils
{
    public partial class NarcExplorer : DockContent
    {
        AndiNarcReader narc = new AndiNarcReader();
        AndiGarcReader garc = new AndiGarcReader();
        Stream a = new MemoryStream();

        public NarcExplorer()
        {
            InitializeComponent();
            hexBox1.CurrentLineChanged += hexBox1_CurrentPositionInLineChanged;
            hexBox1.CurrentPositionInLineChanged += hexBox1_CurrentPositionInLineChanged;
        }

        void hexBox1_CurrentPositionInLineChanged(object sender, EventArgs e)
        {
            long index = ((hexBox1.CurrentPositionInLine + (16*(hexBox1.CurrentLine - 1))) - 1);

            try
            {
                a.Position = index;
                byte[] ntbyte = new[]
                {(byte) a.ReadByte(), (byte) a.ReadByte()};
                label1.Text = "Position : " + index + " ID : " + BitConverter.ToInt16(ntbyte, 0) +" Name : "+ MVGList.GetMoveName(BitConverter.ToInt16(ntbyte, 0));
            }
            catch
            {
                label1.Text = index + " " + index.ToString("X");  
            }
            
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

                garc = new AndiGarcReader(path);

                //narc.OpenData(path);
                andiListBox1.Items.Clear();
                for (int i = 0; i < garc.getFileCount(); i++)
                {
                    andiListBox1.Items.Add("Data" + i + " " + garc.GetGarc().BTAF.Entries[i].StartOffset);
                }

                andiListBox1.SelectedIndex = 0;
            }
        }

        private void andiListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            a = new MemoryStream(garc.Extract(andiListBox1.SelectedIndex));
            //a = new MemoryStream(narc.getdataselected(andiListBox1.SelectedIndex));
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

            int ccount = (int)(a.Length/4)-1;

            textBox1.Text = "";
            for (int i = 0; i < ccount; i++)
            {
                a.Position = i*4;
                byte[] ntbyte = new[] { (byte)a.ReadByte(), (byte)a.ReadByte() };
                textBox1.Text += MVGList.GetMoveName(BitConverter.ToInt16(ntbyte, 0)) +", ";
                ntbyte = new[] { (byte)a.ReadByte(), (byte)a.ReadByte() };
                textBox1.Text += BitConverter.ToInt16(ntbyte, 0) + Environment.NewLine;
            }
        }
    }
}
