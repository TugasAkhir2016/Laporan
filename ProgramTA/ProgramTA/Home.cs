using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramTA
{
    public partial class Home : Form
    {
        string filename = "";
        string asfilename = "File";
        double c1;
        double c2;
        int[] f1,f2;
        int HElowbound;
        int HEhibound;
        int[] H;
        int[] newH2;
        int[] newH1;
        double[] low, mid, high;
        double[] pdf;
        int totallow, totalmid, totalhigh;
        public Home()
        {
            InitializeComponent();
            low = new double[256];
            mid = new double[256];
            high = new double[256];
            for(int i = 0; i < low.Length; i++)
            {
                if (i > 95)
                {
                    low[i] = 0;
                }
                else if (i < 75)
                {
                    low[i] = 1;
                }
                else
                {
                    low[i] = (95 - i) / 20.00;
                    mid[i] = (i - 75) / 20.00;
                }
                if (i < 75 || i > 180)
                {
                    mid[i] = 0;
                }
                else if (i >= 95 && i <= 160)
                {
                    mid[i] = 1;
                }
                if (i < 160)
                {
                    high[i] = 0;
                }
                else if (i > 180)
                {
                    high[i] = 1;
                }
                else
                {
                    mid[i] = (180 - i) / 20.00;
                    high[i] = (i - 160) / 20.00;
                }
            }
        }
        public double means(double[] p)
        {
            double rerata = 0;
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] > 0) rerata++;
            }
            return (double)p.Sum() / (double)rerata;
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "File";
            openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.tif; *.tiff; *.bmp; *.png; *.gif)|*.jpg; *.jpeg; *.tif; *.tiff; *.bmp; *.png; *.gif;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK || openFileDialog1.FileName != "File")
            {
                button1.Enabled = true;
                totallow = 0; totalmid = 0; totalhigh = 0;
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                Bitmap test = new Bitmap(openFileDialog1.FileName);
                filename = openFileDialog1.FileName;
                long totalgr1 = 0; long totalgr2 = 0;
                H = new int[256];
                pdf = new double[256];
                double Contrast = 0;
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        Color c = bmp.GetPixel(x, y);
                        int grayscale = (int)((c.R * 0.3f) + (c.G * 0.59f) + (c.B * 0.11f));
                        Color g = Color.FromArgb(grayscale, grayscale, grayscale);
                        bmp.SetPixel(x, y, g);
                        H[grayscale]++;
                        totalgr1 += (grayscale * grayscale);
                        totalgr2 += grayscale;
                        if (grayscale < 85)
                            totallow++;
                        else if (grayscale > 170)
                            totalhigh++;
                        else totalmid++;
                    }
                }
                Contrast = (double)10f * Math.Log10((double)((double)totalgr1 / (double)bmp.Width /(double)bmp.Height) - Math.Pow((double)totalgr2 / (double)bmp.Width / (double)bmp.Height, 2));
                double Entropy = 0;
                for(int i = 0; i < H.Length; i++)
                {
                    pdf[i] = (double)H[i] / (double)H.Sum();
                    if (pdf[i] > 0)
                        Entropy += ((double)(-1) * (double)pdf[i] * (double)Math.Log(pdf[i], 2));
                }
                pictureBox1.Image = bmp;
                textBox3.Text = Entropy.ToString();
                textBox6.Text = Contrast.ToString();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox2.Image);
            bmp.Save(filename);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = asfilename;
            saveFileDialog1.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(saveFileDialog1.FileName);
                asfilename = saveFileDialog1.FileName;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void percobaanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Percobaan percobaan = new Percobaan(low, mid, high);
            percobaan.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            btn_Show.Enabled = true;
            richTextBox1.Text = ""; richTextBox2.Text = "";
            c1 = (double)numericUpDown1.Value; c2 = (double)numericUpDown2.Value;
            HElowbound = Int32.Parse(textBox1.Text); HEhibound = Int32.Parse(textBox2.Text);
            Bitmap bmp1 = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(pictureBox1.Image);
            long totalgr1 = 0; long totalgr2 = 0;
            double tlow = 0, tmid = 0, thigh = 0;
            int intref;
            int deflow = 43; int defmid = 128; int defhigh = 213;
            double newEntropy1 = 0; double newEntropy2 = 0; double newContrast1 = 0; double newContrast2 = 0;
            richTextBox1.Text += "Nilai histogram tiap nilai keabuan :\n";
            for (int i = 0; i < H.Length; i++)
            {
                richTextBox1.Text += "H[" + i + "] = " + H[i].ToString().PadRight(7);
            }
            richTextBox1.Text += "\n\nNilai Fungsi probabilitas densitas (pdf) tiap nilai keabuan :\n";
            for (int i = 0; i < H.Length; i++)
            {
                richTextBox1.Text += "Pdf[" + i + "] = " + pdf[i].ToString("0.000").PadRight(6);
            }
            richTextBox2.Text = richTextBox1.Text;
            richTextBox1.Text += "\n\nDerajat keanggotaan untuk tiap nilai keabuan (μ) :\n";
            for (int i = 0; i < H.Length; i++)
            {
                richTextBox1.Text += "μLow[" + i + "] = " + low[i].ToString().PadRight(10) + "μMid[" + i + "] = " + mid[i].ToString().PadRight(10) + "\t" + "μHigh[" + i + "] = " + high[i].ToString().PadRight(10) + "\n";
                tlow += low[i] * H[i]; tmid += mid[i] * H[i]; thigh += high[i] * H[i];
            }
            richTextBox1.Text += "\nLow_part = " + (tlow / (tlow + tmid + thigh)).ToString("0.000") + "\tMid_part = " + (tmid / (tlow + tmid + thigh)).ToString("0.000") + "\tHigh_Part = " + (thigh / (tlow + tmid + thigh)).ToString("0.000") + "\nNilai intensitas referensi citra \n= low_part * 43 + mid_part * 128 + high_part * 213\n=";
            richTextBox1.Text += (tlow / (tlow + tmid + thigh)).ToString("0.000") + " * 43 + " + (tmid / (tlow + tmid + thigh)).ToString("0.000") + " * 128 + " + (thigh / (tlow + tmid + thigh)).ToString("0.000") + " * 213 = ";
            intref = Convert.ToInt32(Math.Round((tlow / (tlow + tmid + thigh) * deflow) + (tmid / (tlow + tmid + thigh) * defmid) + (thigh / (tlow + tmid + thigh) * defhigh)));
            richTextBox1.Text += intref + "\n\n";
            newH1 = new int[256]; double[] newHpdf1 = new double[256];
            double[] npdf1 = new double[256];
            double[] ncdf1 = new double[256];
            double lvlow, lvmid, lvhigh;
            double cliplimit = 0;
            f1 = new int[256];
            lvlow = 0; lvmid = 0; lvhigh = 0;
            richTextBox1.Text += "Perhitungan nilai clipping limit untuk tiap intensitas :\n";
            for (int i = 0; i < H.Length; i++)
            {
                if (i == 0)
                {
                    lvlow = (c1) + pdf.Max();
                    lvhigh = (c2) + means(pdf);
                    lvmid = means(pdf);
                    cliplimit = (low[intref] * lvlow) + (mid[intref] * lvmid) + (high[intref] * lvhigh);
                    richTextBox1.Text += "Levellow = c1 + Max(Pdf)\n\t=" + c1 + " + " + pdf.Max().ToString("0.000") + " = " + lvlow.ToString("0.00000") + "\n";
                    richTextBox1.Text += "Levelmid = Mean(Pdf)\n\t=" + lvmid.ToString("0.00000") + "\n";
                    richTextBox1.Text += "Levelhigh = c2 + Mean(Pdf)\n\t=" + c1 + " + " + lvmid.ToString("0.000") + " = " + lvhigh.ToString("0.00000") + "\n";
                    richTextBox1.Text += "Clipping Limit (CL) = (μLow[" + intref + "] * Levellow) + (μMid[" + intref + "] * Levelmid) + (μHigh[" + intref + "] * Levelhigh\n";
                    richTextBox1.Text += "CL = (" + low[intref] + " * " + lvlow.ToString("0.00000") + ") + (" + mid[intref] + " * " + lvmid.ToString("0.00000") + ") + (" + high[intref] + " * " + lvhigh.ToString("0.00000") + ") = " + cliplimit.ToString("0.00000") + "\n\n";
                    richTextBox1.Text += "Proses Clipping Histogram :\n";
                }
                richTextBox1.Text += "Pdf[" + i + "] = " + pdf[i].ToString("0.00000") + "\n";
                if (pdf[i] > cliplimit)
                {
                    richTextBox1.Text += "Pdf[" + i + "] > CL dimana " + pdf[i].ToString("0.00000") + " > " + cliplimit.ToString("0.00000") + ", Maka nPdf[" + i + "] = " + cliplimit.ToString("0.00000") + "\n";
                    npdf1[i] = cliplimit;
                }
                else
                {
                    richTextBox1.Text += "Pdf[" + i + "] < CL dimana " + pdf[i].ToString("0.00000") + " < " + cliplimit.ToString("0.00000") + ", Maka nPdf[" + i + "] = " + pdf[i].ToString("0.00000") + "\n";
                    npdf1[i] = pdf[i];
                }
                if (i > 0)
                {
                    ncdf1[i] = ncdf1[i - 1] + npdf1[i];
                    richTextBox1.Text += "nCdf[" + i + "] = nCdf[" + (i - 1) + "] + nPdf[" + i + "] = " + ncdf1[i].ToString("0.00000") + "\n\n";
                }
                else
                {
                    ncdf1[i] = npdf1[i];
                    richTextBox1.Text += "nCdf[" + i + "] = nPdf[0] = " + ncdf1[i].ToString("0.00000") + "\n\n";
                }
            }
            richTextBox1.Text += "\nUntuk mendapatkan nilai kumulatif terakhir nCdf[255] = 1, Maka :\n";
            for (int i = 0; i < H.Length; i++)
            {
                richTextBox1.Text += "nPdf[" + i + "] = " + npdf1[i].ToString("0.00000") + "/" + ncdf1[255].ToString("0.00000") + " = ";
                npdf1[i] /= ncdf1[255];
                richTextBox1.Text += npdf1[i].ToString("0.00000") + "\n";
                if (i > 0)
                {
                    ncdf1[i] = ncdf1[i - 1] + npdf1[i];
                    richTextBox1.Text += "nCdf[" + i + "] = nCdf[" + (i - 1) + "] + nPdf[" + i + "] = " + ncdf1[i].ToString("0.00000") + "\n\n";
                }
                else
                {
                    ncdf1[i] = npdf1[i];
                    richTextBox1.Text += "nCdf[" + i + "] = nPdf[0] = " + ncdf1[i].ToString("0.00000") + "\n\n";
                }
                f1[i] = Convert.ToInt32(Math.Round(HElowbound + ((HEhibound - HElowbound) * (ncdf1[i] - (npdf1[i] / 2)))));
            }
            richTextBox1.Text += "\nPerataan histogram dengan fungsi transformasi dilakukan untuk mendapatkan nilai intensitas baru:\n";
            richTextBox1.Text += "Nilai X(0) = " + HElowbound + " dan Nilai X(L-1) = " + HEhibound + "\n";
            for (int i = 0; i < H.Length; i++)
            {
                richTextBox1.Text += "new_f[" + i + "] = X(0) + (X(L-1) - X(0)) x (nCdf[" + i + "] - 1/2 nPdf[" + i + "]) = " + f1[i] + "\n";
                richTextBox1.Text += "Nilai intensitas " + i + "ditransformasi menjadi intensitas baru " + f1[i] + "\n";
            }
            for (int x = 0; x < bmp1.Width; x++)
            {
                for (int y = 0; y < bmp1.Height; y++)
                {
                    Color c = bmp1.GetPixel(x, y);
                    int gr = f1[(int)c.R];
                    Color g = Color.FromArgb(gr, gr, gr);
                    bmp1.SetPixel(x, y, g);
                    newH1[gr]++;
                    totalgr1 += (gr * gr);
                    totalgr2 += gr;
                }
            }
            richTextBox1.Text += "\nSehingga tiap pixel dari citra awal ditransformasi membentuk citra baru dengan nilai Histogram:\n";
            for (int i = 0; i < H.Length; i++)
            {
                richTextBox1.Text += "newH[" + i + "] = " + newH1[i] + "\n";
            }
            newContrast1 = (double)10f * Math.Log10((double)((double)totalgr1 / (double)(bmp1.Width * bmp1.Height)) - Math.Pow((double)totalgr2 / (double)(bmp1.Width * bmp1.Height), 2));
            pictureBox2.Image = bmp1;
            newH2 = new int[256]; double[] newHpdf2 = new double[256];
            double[] npdf2 = new double[256];
            double[] ncdf2 = new double[256];
            f2 = new int[256];
            cliplimit = 0;
            richTextBox2.Text += "\n\nPerhitungan nilai clipping limit untuk tiap intensitas :\n";
            for (int i = 0; i < H.Length; i++)
            {
                if (i == 0)
                {
                    if (totallow > totalmid && totallow > totalhigh)
                    {
                        cliplimit = (c1) + pdf.Max();
                        richTextBox2.Text += "Clipping Limit (CL) = c1 + Max(Pdf)\n\t=" + c1 + " + " + pdf.Max().ToString("0.00000") + " = " + cliplimit.ToString("0.00000") + "\n";
                    }
                    else if (totalhigh > totallow && totalhigh > totalmid)
                    {
                        cliplimit = (c2) + means(pdf);
                        richTextBox2.Text += "Clipping Limit (CL) = c2 + Mean(Pdf)\n\t=" + c2 + " + " + means(pdf).ToString("0.00000") + " = " + cliplimit.ToString("0.00000") + "\n";
                    }
                    else
                    {
                        cliplimit = means(pdf);
                        richTextBox2.Text += "Clipping Limit (CL) = Mean(Pdf)\n\t=" + cliplimit + "\n";
                    }
                }
                richTextBox1.Text += "Pdf[" + i + "] = " + pdf[i].ToString("0.00000") + "\n";
                if (pdf[i] > cliplimit)
                {
                    richTextBox2.Text += "Pdf[" + i + "] > CL dimana " + pdf[i].ToString("0.00000") + " > " + cliplimit.ToString("0.00000") + ", Maka nPdf[" + i + "] = " + cliplimit.ToString("0.00000") + "\n";
                    npdf2[i] = cliplimit;
                }
                else
                {
                    richTextBox2.Text += "Pdf[" + i + "] < CL dimana " + pdf[i].ToString("0.00000") + " < " + cliplimit.ToString("0.00000") + ", Maka nPdf[" + i + "] = " + pdf[i].ToString("0.00000") + "\n";
                    npdf2[i] = pdf[i];
                }
                if (i > 0)
                {
                    ncdf2[i] = ncdf2[i - 1] + npdf2[i];
                    richTextBox2.Text += "nCdf[" + i + "] = nCdf[" + (i - 1) + "] + nPdf[" + i + "] = " + ncdf2[i].ToString("0.00000") + "\n\n";
                }
                else
                {
                    ncdf2[i] = npdf2[i];
                    richTextBox2.Text += "nCdf[" + i + "] = nPdf[0] = " + ncdf2[i].ToString("0.00000") + "\n\n";
                }
            }
            richTextBox2.Text += "\nUntuk mendapatkan nilai kumulatif terakhir nCdf[255] = 1, Maka :\n";
            for (int i = 0; i < H.Length; i++)
            {
                richTextBox2.Text += "nPdf[" + i + "] = " + npdf2[i].ToString("0.00000") + "/" + ncdf2[255].ToString("0.00000") + " = ";
                npdf2[i] /= ncdf2[255];
                richTextBox2.Text += npdf2[i].ToString("0.00000") + "\n";
                if (i > 0)
                {
                    ncdf2[i] = ncdf2[i - 1] + npdf2[i];
                    richTextBox2.Text += "nCdf[" + i + "] = nCdf[" + (i - 1) + "] + nPdf[" + i + "] = " + ncdf2[i].ToString("0.00000") + "\n\n";
                }
                else
                {
                    ncdf2[i] = npdf2[i];
                    richTextBox2.Text += "nCdf[" + i + "] = nPdf[0] = " + ncdf2[i].ToString("0.00000") + "\n\n";
                }
                f2[i] = Convert.ToInt32(Math.Round(HElowbound + ((HEhibound - HElowbound) * (ncdf2[i] - (npdf2[i] / 2)))));
            }
            richTextBox2.Text += "\nPerataan histogram dengan fungsi transformasi dilakukan untuk mendapatkan nilai intensitas baru:\n";
            richTextBox2.Text += "Nilai X(0) = " + HElowbound + " dan Nilai X(L-1) = " + HEhibound + "\n";
            for (int i = 0; i < H.Length; i++)
            {
                richTextBox2.Text += "new_f[" + i + "] = X(0) + (X(L-1) - X(0)) x (nCdf[" + i + "] - 1/2 nPdf[" + i + "]) = " + f2[i] + "\n";
                richTextBox2.Text += "Nilai intensitas " + i + "ditransformasi menjadi intensitas baru " + f2[i] + "\n";
            }
            totalgr1 = 0; totalgr2 = 0;
            for (int x = 0; x < bmp2.Width; x++)
            {
                for (int y = 0; y < bmp2.Height; y++)
                {
                    Color c = bmp2.GetPixel(x, y);
                    int gr = f2[(int)c.R];
                    Color g = Color.FromArgb(gr, gr, gr);
                    bmp2.SetPixel(x, y, g);
                    newH2[gr]++;
                    totalgr1 += (gr * gr);
                    totalgr2 += gr;
                }
            }
            richTextBox2.Text += "\nSehingga tiap pixel dari citra awal ditransformasi membentuk citra baru dengan nilai Histogram:\n";
            for (int i = 0; i < H.Length; i++)
            {
                richTextBox2.Text += "newH[" + i + "] = " + newH2[i] + "\n";
            }
            newContrast2 = (double)10f * Math.Log10((double)((double)totalgr1 / (double)(bmp2.Width * bmp2.Height)) - Math.Pow((double)totalgr2 / (double)(bmp2.Width * bmp2.Height), 2));
            pictureBox3.Image = bmp2;
            for (int i = 0; i < H.Length; i++)
            {
                newHpdf1[i] = (double)newH1[i] / (double)newH1.Sum();
                newHpdf2[i] = (double)newH2[i] / (double)newH2.Sum();
                if (newHpdf1[i] > 0)
                    newEntropy1 += ((double)(-1) * (double)newHpdf1[i] * (double)Math.Log(newHpdf1[i], 2));
                if (newHpdf2[i] > 0)
                    newEntropy2 += ((double)(-1) * (double)newHpdf2[i] * (double)Math.Log(newHpdf2[i], 2));
            }
            textBox4.Text = newEntropy1.ToString(); 
            textBox5.Text = newEntropy2.ToString();
            textBox7.Text = newContrast1.ToString(); 
            textBox8.Text = newContrast2.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Tampil_CItra tmpl = new Tampil_CItra((Bitmap)pictureBox1.Image, "Citra Asli");
                tmpl.ShowDialog();
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                Tampil_CItra tmpl = new Tampil_CItra((Bitmap)pictureBox2.Image, "Citra AFCEDP");
                tmpl.ShowDialog();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (pictureBox3.Image != null)
            {
                Tampil_CItra tmpl = new Tampil_CItra((Bitmap)pictureBox3.Image, "Citra ACEDP");
                tmpl.ShowDialog();
            }
        }

        private void btn_Show_Click(object sender, EventArgs e)
        {
            Log log = new Log(H,newH1,newH2,f1,f2);
            log.ShowDialog();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About_Us abu = new About_Us();
            abu.ShowDialog();
        }

    }
}
