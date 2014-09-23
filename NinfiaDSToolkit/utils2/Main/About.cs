using System.Drawing;
using System.Windows.Forms;
using Andi.Controls.ImageBox;

namespace Andi.Toolkit.utils2.Main
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            andiImageBox1.Image = Image.FromFile(Application.StartupPath + @"\dir\Icons\about.png");
            andiImageBox1.SizeMode = ImageBoxSizeMode.Fit;
        }
    }
}
