using System;
using System.IO;
using System.Windows.Forms;
using NinfiaDSToolkit.Andi.Controls.HexBox;
using NinfiaDSToolkit.Andi.Utils.Narc;
using WeifenLuo.WinFormsUI.Docking;

namespace NinfiaDSToolkit.Tools.Extra
{
    public partial class BLZCoderUI : DockContent
    {
        Stream a = new MemoryStream();
        Stream b = new MemoryStream();
        public BLZCoderUI()
        {
            InitializeComponent();
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
                a = new FileStream(path, FileMode.Open);

                DynamicFileByteProvider dynamicFileByteProvider = null;

                try
                {
                    dynamicFileByteProvider = new DynamicFileByteProvider(a);
                }
                catch
                {

                }

                toolStripLabel1.Text = a.Length + "";

                hexBox1.ByteProvider = dynamicFileByteProvider;

                byte[] bytetemp = new byte[a.Length];

                a.Read(bytetemp, 0, (int) a.Length);

                DynamicFileByteProvider dynamicFileByteProvider2 = null;

                try
                {
                    BLZCoder aa = new BLZCoder();
                    b = new MemoryStream(aa.BLZ_DecodePub(bytetemp, "-d"));
                    
                    dynamicFileByteProvider2 = new DynamicFileByteProvider(b);
                }
                catch
                {
                    b = a;

                    dynamicFileByteProvider2 = new DynamicFileByteProvider(b);
                }

                toolStripLabel2.Text = b.Length + "";

                hexBox2.ByteProvider = dynamicFileByteProvider2;
            }
        }
    }
}
