using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;

namespace NinfiaDSToolkit.Andi.Utils
{
    public class ImageIconHandler
    {
        
        public static Image setImagePictureBox(int index)
        {
            GC.Collect();
            
            string zipPath = Application.StartupPath + @"\dir\Icons\pkm_icon_xy.zip";

            using (ZipFile zipfile = new ZipFile(zipPath))
            {
                try
                {
                    return Image.FromStream(zipfile.GetInputStream(zipfile.GetEntry(index + ".png")));
                }
                catch
                {
                    return Properties.Resources._0;
                }
            }
            
            /*
            using (SevenZipArchive archive = new SevenZipArchive(zipPath))
            {
                try
                {
                    Stream astream = new MemoryStream();
                    archive[index + ".png"].Extract(astream);

                    return Image.FromStream(astream);

                    //label1.Text = (index).ToString();
                    //pictureBox1.Image = Image.FromStream(astream);
                    //pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                catch (Exception ex)
                {
                    return Properties.Resources._0;
                }

            }*/
        }

        public static Image setImagePictureBox(int index, int forme)
        {
            GC.Collect();
            string zipPath = Application.StartupPath + @"\dir\Icons\pkm_icon_xy.zip";

            using (ZipFile zipfile = new ZipFile(zipPath))
            {
                try
                {
                    return Image.FromStream(zipfile.GetInputStream(zipfile.GetEntry(index + "-" + forme + ".png")));
                }
                catch
                {
                    return Properties.Resources._0;
                }
            }

            /*
            using (SevenZipArchive archive = new SevenZipArchive(zipPath))
            {
                try
                {
                    Stream astream = new MemoryStream();
                    archive[index + "-"+forme+".png"].Extract(astream);

                    return Image.FromStream(astream);

                    //label1.Text = (index).ToString();
                    //pictureBox1.Image = Image.FromStream(astream);
                    //pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                catch (Exception ex)
                {
                    return Properties.Resources._0;
                }
            }*/
        }

        public static Image setImageItemPictureBox(int index)
        {
            GC.Collect();
            string zipPath = Application.StartupPath + @"\dir\Icons\item_icon_bw2.zip";

            using (ZipFile zipfile = new ZipFile(zipPath))
            {
                try
                {
                    return Image.FromStream(zipfile.GetInputStream(zipfile.GetEntry(index + ".png")));
                }
                catch
                {
                    return Properties.Resources._0;
                }
            }

            /*
            using (SevenZipArchive archive = new SevenZipArchive(zipPath))
            {
                try
                {
                    Stream astream = new MemoryStream();
                    archive[index + ".png"].Extract(astream);

                    return Image.FromStream(astream);

                    //label1.Text = (index).ToString();
                    //pictureBox1.Image = Image.FromStream(astream);
                    //pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                catch (Exception ex)
                {
                    return Properties.Resources._0;
                }
            }*/
        }
    }
}
