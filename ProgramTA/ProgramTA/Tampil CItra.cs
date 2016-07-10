using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math;

namespace ProgramTA
{
    public partial class Tampil_CItra : Form
    {

        public Tampil_CItra(System.Drawing.Image btmap, string name)
        {
            Citra = (Bitmap)btmap;
            this.name = name;
            InitializeComponent();
        }
        private Bitmap Citra { set; get; }
        private string name { set; get; }
        private float aspectratio { set; get; }
        
        private void Tampil_CItra_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Citra;
            this.Text = "Tampil Citra - " + name;
            ImageStatistics stat = new ImageStatistics(Citra);
            Histogram hist = stat.Red;
            histogram1.Color = Color.Black;
            histogram1.Values = hist.Values;
            ComboboxZoom.SelectedIndex = 2;
            aspectratio = Convert.ToSingle((float)Citra.Width / (float)Citra.Height);
            nilaiaspect.Text = aspectratio.ToString("F3");
            nilaimean.Text = stat.Red.Mean.ToString("F3");
            nilaimedian.Text = stat.Red.Median.ToString();
            nilaimin.Text = stat.Red.Min.ToString();
            nilaimax.Text = stat.Red.Max.ToString();
            bnykpixel.Text = stat.Red.TotalCount.ToString();
            double stddev = Statistics.StdDev(hist.Values);
            nilaistd.Text = stddev.ToString("F3");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(ComboboxZoom.SelectedIndex == 1)
            {
                ComboboxZoom.SelectedIndex = 0;
                toolStripButton1.Enabled = false;
                int n_height = Citra.Height * 2;
                int n_width = Convert.ToInt32(aspectratio * n_height);
                pictureBox1.Image = new Bitmap(Citra, n_width, n_height);
            }
            else if(ComboboxZoom.SelectedIndex == 2)
            {

                ComboboxZoom.SelectedIndex = 1;
                int n_height = Convert.ToInt32(Citra.Height * 1.5f);
                int n_width = Convert.ToInt32(aspectratio * n_height);
                pictureBox1.Image = new Bitmap(Citra, n_width, n_height);
            }
            else if (ComboboxZoom.SelectedIndex == 3)
            {

                ComboboxZoom.SelectedIndex = 2;
                pictureBox1.Image = Citra;
            }
            else if (ComboboxZoom.SelectedIndex == 4)
            {

                ComboboxZoom.SelectedIndex = 3;
                int n_height = Convert.ToInt32(Citra.Height * 0.75f);
                int n_width = Convert.ToInt32(aspectratio * n_height);
                pictureBox1.Image = new Bitmap(Citra, n_width, n_height);
            }
            else if (ComboboxZoom.SelectedIndex == 5)
            {

                ComboboxZoom.SelectedIndex = 4;
                toolStripButton2.Enabled = true;
                int n_height = Convert.ToInt32(Citra.Height * 0.5f);
                int n_width = Convert.ToInt32(aspectratio * n_height);
                pictureBox1.Image = new Bitmap(Citra, n_width, n_height);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (ComboboxZoom.SelectedIndex == 0)
            {
                toolStripButton1.Enabled = true;
                ComboboxZoom.SelectedIndex = 1;
                int n_height = Convert.ToInt32(Citra.Height * 1.5f);
                int n_width = Convert.ToInt32(aspectratio * n_height);
                pictureBox1.Image = new Bitmap(Citra, n_width, n_height);
            }
            else if (ComboboxZoom.SelectedIndex == 1)
            {
                ComboboxZoom.SelectedIndex = 2;
                pictureBox1.Image = Citra;
            }
            else if (ComboboxZoom.SelectedIndex == 2)
            {
                ComboboxZoom.SelectedIndex = 3;
                int n_height = Convert.ToInt32(Citra.Height * 0.75f);
                int n_width = Convert.ToInt32(aspectratio * n_height);
                pictureBox1.Image = new Bitmap(Citra, n_width, n_height);
            }
            else if (ComboboxZoom.SelectedIndex == 3)
            {
                ComboboxZoom.SelectedIndex = 4;
                int n_height = Convert.ToInt32(Citra.Height * 0.5f);
                int n_width = Convert.ToInt32(aspectratio * n_height);
                pictureBox1.Image = new Bitmap(Citra, n_width, n_height);
            }
            else if (ComboboxZoom.SelectedIndex == 4)
            {
                ComboboxZoom.SelectedIndex = 5;
                toolStripButton2.Enabled = false;
                int n_height = Convert.ToInt32(Citra.Height * 0.25f);
                int n_width = Convert.ToInt32(aspectratio * n_height);
                pictureBox1.Image = new Bitmap(Citra, n_width, n_height);
            }
        }

        private void ComboboxZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ComboboxZoom.SelectedIndex == 0)
            {
                toolStripButton1.Enabled = false;
                toolStripButton2.Enabled = true;
                int n_height = Citra.Height * 2;
                int n_width = Convert.ToInt32(aspectratio * n_height);
                pictureBox1.Image = new Bitmap(Citra, n_width, n_height);

            }
            else if(ComboboxZoom.SelectedIndex == 1)
            {
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = true;
                int n_height = Convert.ToInt32(Citra.Height * 1.5f);
                int n_width = Convert.ToInt32(aspectratio * n_height);
                pictureBox1.Image = new Bitmap(Citra, n_width, n_height);
            }
            else if(ComboboxZoom.SelectedIndex == 2)
            {
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = true;
                pictureBox1.Image = Citra;
            }
            else if(ComboboxZoom.SelectedIndex == 3)
            {
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = true;
                int n_height = Convert.ToInt32(Citra.Height * 0.75f);
                int n_width = Convert.ToInt32(aspectratio * n_height);
                pictureBox1.Image = new Bitmap(Citra, n_width, n_height);
            }
            else if(ComboboxZoom.SelectedIndex == 4)
            {
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = true;
                int n_height = Convert.ToInt32(Citra.Height * 0.5f);
                int n_width = Convert.ToInt32(aspectratio * n_height);
                pictureBox1.Image = new Bitmap(Citra, n_width, n_height);
            }
            else if(ComboboxZoom.SelectedIndex == 5)
            {
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = false;
                int n_height = Convert.ToInt32(Citra.Height * 0.25f);
                int n_width = Convert.ToInt32(aspectratio * n_height);
                pictureBox1.Image = new Bitmap(Citra, n_width, n_height);

            }
        }
        private void mouse_enter(object sender,EventArgs e)
        {
            if(ComboboxZoom.SelectedIndex < 2)
            {
                pictureBox1.Cursor = Cursors.Hand;
            }
            else
            {
                pictureBox1.Cursor = Cursors.Default;
            }
        }
    }
}
