using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramTA
{
    public partial class About_Us : Form
    {
        public About_Us()
        {
            InitializeComponent();
        }

        private void About_Us_Load(object sender, EventArgs e)
        {
            advRichTextBox1.SelectionAlignment = TextAlign.Justify;
            advRichTextBox1.SelectAll();
        }
    }
}
