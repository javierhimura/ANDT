using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace NinfiaDSToolkit.Andi.Utils
{
    public partial class Information : DockContent
    {
        public Information()
        {
            InitializeComponent();
            fastColoredTextBox1.Text = Properties.Resources.data;
        }
    }
}
