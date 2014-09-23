using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Andi.Utils.Citro.Audio;
using WeifenLuo.WinFormsUI.Docking;

namespace Andi.Toolkit.utils2
{
    public partial class BCSARUnpacker : DockContent
    {
        private BCSAR BCSARReader;
        private Stream a;
        private string apath = "";
        Thread intern;

        public BCSARUnpacker()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "";
            string spath = "";

            OpenFileDialog openFile = new OpenFileDialog();

            if (openFile.ShowDialog() == DialogResult.OK) // Test result.
            {
                path = openFile.FileName;
            }

            if (path == "")
            {
                return;
            }

            apath = path;

            FolderBrowserDialog saveFile = new FolderBrowserDialog();

            if (saveFile.ShowDialog() == DialogResult.OK) // Test result.
            {
                spath = saveFile.SelectedPath;
            }

            BCSARReader = new BCSAR(openFile.FileName);

            textBox1.Text = BCSARReader.CSARHeader.Info.FileSize + "";
            textBox2.Text = BCSARReader.FILEe.Length + "";
            button1.Enabled = false;
            if (spath == "")
            {
                return;
            }

            button1.Enabled = false;
            intern = new Thread(
                    new ThreadStart(() =>
                    {
                        Directory.CreateDirectory(spath + @"\[CSAR]\");
                        Directory.CreateDirectory(spath + @"\[FILE]\");
                        Directory.CreateDirectory(spath + @"\[STRG]\");
                        Directory.CreateDirectory(spath + @"\[INFO]\");
                        string aa = "";

                        progressBar1.BeginInvoke(new Action(() =>
                        {
                            progressBar1.Value = 0;
                            progressBar1.Maximum = BCSARReader.STRGHeader.SubFile.Count;
                        }));

                        for (int i = 0; i < BCSARReader.STRGHeader.SubFile.Count; i++)
                        {
                            BCSAR.Header.STRG.MaskEntry tt = new BCSAR.Header.STRG.MaskEntry();

                            tt = BCSARReader.GetMaskEntry(i);

                            aa += tt.FileID + ",";
                            aa += BCSARReader.GetNameString(i) + ",";
                            aa += BCSARReader.STRGHeader.SubFile.FileEntry[i].RootID + ",";
                            aa += BCSAR.Header.GetTypeName(tt.TypeID) + ",";
                            aa += tt.TypeIndex + ",";
                            aa += tt.Const + ",";
                            aa += tt.u1 + ",";
                            aa += tt.u2 + ",";
                            aa += tt.u3 + ",";
                            aa += tt.u4 + ",";
                            aa += tt.u5;
                            aa += Environment.NewLine;

                            progressBar1.BeginInvoke(new Action(() =>
                            {
                                progressBar1.Value = i;
                            }));

                            label1.BeginInvoke(new Action(() =>
                            {
                                label1.Text = "[STRG Partition] " + i + "/" + BCSARReader.STRGHeader.SubFile.Count;
                            }));
                        }

                        File.WriteAllText(spath + @"\STRG_Text.txt", aa);

                        progressBar1.BeginInvoke(new Action(() =>
                        {
                            progressBar1.Value = 0;
                            progressBar1.Maximum = BCSARReader.FILEe.Length;
                        }));

                        for (int i = 0; i < BCSARReader.FILEe.Length; i++)
                        {
                            try
                            {
                                string text = i + " [" + BCSARReader.FILEe[i].Offset + "]." +
                                          BCSARReader.FILEe[i].MagicHeader;
                                using (var output = File.Create(spath + @"\[FILE]\" + text))
                                using (var input = new FileStream(openFile.FileName, FileMode.Open))
                                {
                                    Andi.Utils.Io.Utils.AppendChunk(output, input, BCSARReader.FILEe[i].Offset, BCSARReader.FILEe[i].Offset + BCSARReader.FILEe[i].Lenght);
                                    //AppendChunk(output, input, 1257553244L, 4126897791L);

                                    input.Close();
                                    output.Close();
                                }

                                label1.BeginInvoke(new Action(() =>
                                {
                                    label1.Text = "[FILE Partition] " + i + "/" + BCSARReader.FILEe.Length + " -" + text + " (" + BCSARReader.FILEe[i - 1].Lenght + " byte)";
                                }));
                            }
                            catch
                            {
                                string text = i + " [" + BCSARReader.FILEe[i].Offset + "].bin";
                                using (var output = File.Create(spath + @"\" + text))
                                using (var input = new FileStream(openFile.FileName, FileMode.Open))
                                {
                                    Andi.Utils.Io.Utils.AppendChunk(output, input, BCSARReader.FILEe[i].Offset, BCSARReader.FILEe[i].Offset + BCSARReader.FILEe[i].Lenght);

                                    input.Close();
                                    output.Close();
                                }

                                label1.BeginInvoke(new Action(() =>
                                {
                                    label1.Text = "[FILE Partition] " + i + "/" + BCSARReader.FILEe.Length + " -" + text + " - FAIL (" + BCSARReader.FILEe[i - 1].Lenght + " byte)";
                                }));
                            }

                            progressBar1.BeginInvoke(new Action(() =>
                            {
                                progressBar1.Value = i;
                            }));
                        }

                        label1.BeginInvoke(new Action(() =>
                        {
                            label1.Text = "Done !";
                        }));

                        button1.BeginInvoke(new Action(() =>
                        {
                            button1.Enabled = true;
                        }));
                    }));

            intern.Start();
        }
    }
}
