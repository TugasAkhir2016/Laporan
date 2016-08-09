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
    public partial class Histogram : Form
    {

        public Histogram(Bitmap gambar1,Bitmap gambar2, Bitmap gambar3)
        {
            citraawal = gambar1; citraAFCEDP = gambar2; citraACEDP = gambar3;
            InitializeComponent();
        }

        private Bitmap citraawal, citraAFCEDP, citraACEDP;
        AForge.Math.Histogram hist1, hist2, hist3;
        AForge.Imaging.ImageStatistics stat1, stat2, stat3;
        private void Histogram_Load(object sender, EventArgs e)
        {
            stat1 = new AForge.Imaging.ImageStatistics(citraawal);
            stat2 = new AForge.Imaging.ImageStatistics(citraAFCEDP);
            stat3 = new AForge.Imaging.ImageStatistics(citraACEDP);
            histogram1.Color = Color.Black; histogram2.Color = Color.Black; histogram3.Color = Color.Black;
            hist1 = stat1.Red; hist2 = stat2.Red; hist3 = stat3.Red;
            histogram1.Values = hist1.Values; histogram2.Values = hist2.Values; histogram3.Values = hist3.Values;
            float aspect1 = Convert.ToSingle((float)citraawal.Width / (float)citraawal.Height);
            float aspect2 = Convert.ToSingle((float)citraAFCEDP.Width / (float)citraAFCEDP.Height);
            float aspect3 = Convert.ToSingle((float)citraACEDP.Width / (float)citraACEDP.Height);
            lbl_awal_aspect.Text = aspect1.ToString("F3"); lbl_AFCEDP_aspec.Text = aspect2.ToString("F3"); lbl_ACEDP_aspect.Text = aspect3.ToString("F3");
            lbl_awal_mean.Text = stat1.Red.Mean.ToString("F3"); lbl_AFCEDP_mean.Text = stat2.Red.Mean.ToString("F3"); lbl_ACEDP_mean.Text = stat3.Red.Mean.ToString("F3");
            lbl_awal_median.Text = stat1.Red.Median.ToString(); lbl_AFCEDP_median.Text = stat2.Red.Median.ToString(); lbl_ACEDP_median.Text = stat3.Red.Median.ToString();
            lbl_awal_Min.Text = stat1.Red.Min.ToString(); lbl_AFCEDP_Min.Text = stat2.Red.Min.ToString(); lbl_ACEDP_min.Text = stat3.Red.Min.ToString();
            lbl_awal_max.Text = stat1.Red.Max.ToString(); lbl_AFCEDP_Max.Text = stat2.Red.Max.ToString(); lbl_ACEDP_max.Text = stat3.Red.Max.ToString();
            lbl_awal_pixels.Text = stat1.Red.TotalCount.ToString(); lbl_AFCEDP_pixels.Text = stat1.Red.TotalCount.ToString(); lbl_ACEDP_pixels.Text = stat1.Red.TotalCount.ToString();
            double stddev1 = AForge.Math.Statistics.StdDev(hist1.Values); double stddev2 = AForge.Math.Statistics.StdDev(hist2.Values); double stddev3 = AForge.Math.Statistics.StdDev(hist3.Values);
            lbl_awal_std.Text = stddev1.ToString("F3"); lbl_AFCEDP_std.Text = stddev2.ToString("F3"); lbl_ACEDP_std.Text = stddev3.ToString("F3");
        }



    }
}
