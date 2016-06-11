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
    public partial class Percobaan : Form
    {
        string folderpath = "";
        double[] low, mid, high;
        List<CitraCoba> coba;
        double conrerata, conrerata1, conrerata2, enrerata, enrerata1, enrerata2;
        public Percobaan(double[] low, double[]mid,double[]high)
        {
            InitializeComponent();
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
            this.low = low; this.mid = mid; this.high = high;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderpath != "")
                folderBrowserDialog1.SelectedPath = folderpath;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderpath = folderBrowserDialog1.SelectedPath;
                textBox1.Text = folderpath;
                coba = new List<CitraCoba>();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conrerata = 0; conrerata1 = 0; conrerata2 = 0; enrerata = 0; enrerata1 = 0; enrerata2 = 0;
            foreach(string s in System.IO.Directory.GetFiles(folderpath))
            {
                //if (s.Substring(s.Length - 5, 4) == ".jpg" || s.Substring(s.Length - 5, 4) == ".bmp" || s.Substring(s.Length - 5, 4) == ".png")
                //{
                    double c1 = -0.015; double c2 = 0.005;
                    do
                    {
                        do
                        {
                            coba.Add(new CitraCoba(s, low, mid, high, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), c1, c2, false));
                            conrerata += coba[coba.Count - 1].Contrast;
                            conrerata1 += coba[coba.Count - 1].newContrast1;
                            conrerata2 += coba[coba.Count - 1].newContrast2;
                            enrerata += coba[coba.Count - 1].Entropy;
                            enrerata1 += coba[coba.Count - 1].newEntropy1;
                            enrerata2 += coba[coba.Count - 1].newEntropy2;
                            c1 += 0.001f;
                        } while (c1 <= -0.005);
                        c1 = -0.015;
                        c2 += 0.001f;
                    } while (c2 <= 0.007);
                //}
                            
            }
            List<TabelCoba> tabel = new List<TabelCoba>();
            foreach(CitraCoba c in coba)
            {
                tabel.Add(new TabelCoba(c.filename, c.c1, c.c2, c.Entropy, c.newEntropy1, c.newEntropy2, c.Contrast, c.newContrast1, c.newContrast2));
            }
            var bind = new BindingList<TabelCoba>(tabel);
            textBox6.Text = ((double)conrerata / (double)coba.Count).ToString();
            textBox4.Text = ((double)conrerata1 / (double)coba.Count).ToString();
            textBox5.Text = ((double)conrerata2 / (double)coba.Count).ToString();
            textBox7.Text = ((double)enrerata / (double)coba.Count).ToString();
            textBox8.Text = ((double)enrerata1 / (double)coba.Count).ToString();
            textBox9.Text = ((double)enrerata2 / (double)coba.Count).ToString();
            dataGridView2.DataSource = bind;
        }
    }
}
