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
    public partial class Log : Form
    {
        public struct datas
        {
            public int no;
            public int H;
            public int H2;
            public int H3;
            public datas(int n,int h1,int h2,int h3)
            {
                no = n; H = h1; H2 = h2; H3 = h3;
            }
        }
        List<datas> data;

        int[] h1 = new int[256];
        int[] h2 = new int[256];
        int[] h3 = new int[256];
        public Log(int[] H, int[] H2, int[] H3)
        {
            this.h1 = H;
            this.h2 = H2;
            this.h3 = H3;
            data = new List<datas>();
            InitializeComponent();
        }


        private void Log_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < h1.Length; i++)
            {
                data.Add(new datas(i + 1, h1[i], h2[i], h3[i]));
            }

            dataGridView1.DataSource = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
        }

    }
}
