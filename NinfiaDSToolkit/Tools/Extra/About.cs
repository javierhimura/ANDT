﻿using System.Drawing;
using System.Windows.Forms;
using NinfiaDSToolkit.Andi.Controls.ImageBox;

namespace NinfiaDSToolkit.Tools.Extra
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
