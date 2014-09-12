using System;
using System.IO;
using System.Windows.Forms;
using NinfiaDSToolkit.Andi.Controls.HexBox;
using NinfiaDSToolkit.Andi.Utils;
using NinfiaDSToolkit.Andi.Utils.Narc;
using NinfiaDSToolkit.Tools.Internal;
using WeifenLuo.WinFormsUI.Docking;

namespace NinfiaDSToolkit.Tools.Unfinished
{
    public partial class vInGameTrade : DockContent, ICommonFormLayout
    {
        AndiNarcReader narc = new AndiNarcReader();
        Stream a = new MemoryStream();
        public bool isReady = false;
        public string _LastPath = "", _LastPath2="";

        public vInGameTrade()
        {
            InitializeComponent();
        }

        #region CommonFunction
        public void EventsFormLoad()
        {
            throw new NotImplementedException();
        }

        public void OpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "";

                path = AndiFileDialog.OpenDialog(path, _LastPath, "InGameTrade - File Open", "Any Files|*.*|Narc Files|*.*");

                if (path != "")
                {
                    Program.GlobalPath = Path.GetDirectoryName(path);
                    _LastPath = Path.GetDirectoryName(path);
                    _LastPath2 = path;
                    FileStream a = new FileStream(path, FileMode.Open);
                    Program.mForm.toolStripLabel1.Text = a.Name + " (" + a.Length + ")";
                    byte[] bytee = new byte[4];

                    a.Position = 0;

                    a.Read(bytee, 0, 4);

                    string check = System.Text.Encoding.ASCII.GetString(bytee);
                    a.Close();

                    if (check != "NARC")
                    {
                        MessageBox.Show("This Not NARC File, File Extension Signature is " + check + ", and is not NARC File!", "Error!");
                        return;
                    }

                    narc.OpenData(path);

                    if (narc.FileCount != 20)
                    {
                        MessageBox.Show("Invalid File.", "Error!");
                        return;
                    }

                    EventsAfterOpenFile();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Database.InsertReader.InsertLogs("error", "Yello", ex);
#endif
            }
        }

        public void SaveFile_Click(object sender, EventArgs e)
        {
            try
            {
                AndiFileDialog.NarcSaveDialog(narc, Path.GetDirectoryName(_LastPath), "Save In-Game Trade Data", "narc file|*.narc");
            }
            catch (Exception ex)
            {
#if DEBUG
                Database.InsertReader.InsertLogs("error", "Yello", ex);
#endif
            }
        }

        public void EventsAfterOpenFile()
        {
            throw new NotImplementedException();
        }

        public void GotFocusF(object sender, EventArgs e)
        {
            FileInfo a = new FileInfo(_LastPath2);
            try
            {
                Program.mForm.toolStripLabel1.Text = a.Name + " (" + a.Length + ")";
            }
            catch
            {
                Program.mForm.toolStripLabel1.Text = "";
            }
        }

        public void WriteNarcBack()
        {
            throw new NotImplementedException();
        }

        public void LoadCurrentData()
        {
            throw new NotImplementedException();
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
                dynamicFileByteProvider = new DynamicFileByteProvider(a);
            }
            catch (Exception ex)
            {
#if DEBUG
                Database.InsertReader.InsertLogs("error", "Yello", ex);
#endif
            }
            hexBox1.ByteProvider = dynamicFileByteProvider;
        }
        #endregion
    }
}
