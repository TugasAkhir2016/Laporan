using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace ProgramTA
{
    class CitraCoba
    {
        public string filename = "";
        public Bitmap CitraInput, CitraOutput1, CitraOutput2;
        private int[] H = new int[256];
        private double[] low, mid, high;
        public double Entropy, Entropy_AFCEDP, Entropy_ACEDP, Contrast, Contrast_AFCEDP, Contrast_ACEDP;
        public double c1, c2;
        public CitraCoba(string filename, double[] low, double[] mid, double[] high, int HElowbound, int HEhibound, double c1, double c2, bool aktifK)
        {
            Image img = new Bitmap(filename);
            CitraInput = new Bitmap(img);
            this.filename = filename;
            this.c1 = c1; this.c2 = c2;
            long totalgr1 = 0; long totalgr2 = 0;
            for (int x = 0; x < CitraInput.Width; x++)
            {
                for (int y = 0; y < CitraInput.Height; y++)
                {
                    Color c = CitraInput.GetPixel(x, y);
                    int grayscale = (int)((c.R * 0.3f) + (c.G * 0.59f) + (c.B * 0.11f));
                    Color g = Color.FromArgb(grayscale, grayscale, grayscale);
                    CitraInput.SetPixel(x, y, g);
                    H[grayscale]++;
                    totalgr1 += grayscale * grayscale;
                    totalgr2 += grayscale;
                }
            }
            CitraOutput1 = new Bitmap(CitraInput); CitraOutput2 = new Bitmap(CitraInput);
            Contrast = (double)10f * Math.Log10((double)((double)totalgr1 / (double)(CitraInput.Width * CitraInput.Height)) - Math.Pow((double)totalgr2 / (double)(CitraInput.Width * CitraInput.Height), 2));
            this.low = low; this.mid = mid; this.high = high;
            int intref;
            int deflow = 43; int defmid = 128; int defhigh = 213;
            double tlow = 0, tmid = 0, thigh = 0;
            for (int i = 0; i < H.Length; i++)
            {
                tlow += low[i] * H[i]; tmid += mid[i] * H[i]; thigh += high[i] * H[i];
            }
            intref = Convert.ToInt32(Math.Round((tlow / (tlow + tmid + thigh) * deflow) + (tmid / (tlow + tmid + thigh) * defmid) + (thigh / (tlow + tmid + thigh) * defhigh)));
            int[] newH1 = new int[256]; double[] newHpdf1 = new double[256];
            double[] pdf = new double[256];
            double[] npdf1 = new double[256];
            double[] ncdf1 = new double[256];
            double lvlow, lvmid, lvhigh;
            double cliplimit;
            int[] f1 = new int[256];
            lvlow = 0; lvmid = 0; lvhigh = 0;
            for (int i = 0; i < H.Length; i++)
            {
                pdf[i] = (double)H[i] / (double)H.Sum();
            }
            for (int i = 0; i < H.Length; i++)
            {
                if (aktifK == false)
                {
                    lvlow = (c1) + pdf.Max();
                    lvhigh = (c2) + means(pdf);
                    lvmid = means(pdf);
                }
                else
                {
                    lvlow = (c1) * i + pdf.Max();
                    lvhigh = (c2) * i + means(pdf);
                    lvmid = means(pdf);
                }
                cliplimit = (low[intref] * lvlow) + (mid[intref] * lvmid) + (high[intref] * lvhigh);
                if (pdf[i] > cliplimit)
                {
                    npdf1[i] = cliplimit;
                }
                else npdf1[i] = pdf[i];
                if (i > 0)
                    ncdf1[i] = ncdf1[i - 1] + npdf1[i];
                else ncdf1[i] = npdf1[i];
            }
            for (int i = 0; i < H.Length; i++)
            {
                npdf1[i] /= ncdf1[255];
                if (i > 0)
                    ncdf1[i] = ncdf1[i - 1] + npdf1[i];
                else ncdf1[i] = npdf1[i];
                f1[i] = Convert.ToInt32(Math.Round(HElowbound + ((HEhibound - HElowbound) * (ncdf1[i] - (npdf1[i] / 2)))));
            }
            totalgr1 = 0; totalgr2 = 0;
            for (int x = 0; x < CitraOutput1.Width; x++)
            {
                for (int y = 0; y < CitraOutput1.Height; y++)
                {
                    Color c = CitraOutput1.GetPixel(x, y);
                    int gr = f1[(int)c.R];
                    Color g = Color.FromArgb(gr, gr, gr);
                    CitraOutput1.SetPixel(x, y, g);
                    newH1[gr]++;
                    totalgr1 += (gr * gr);
                    totalgr2 += gr;
                }
            }
            Contrast_AFCEDP = (double)10f * Math.Log10((double)((double)totalgr1 / (double)(CitraOutput1.Width * CitraOutput1.Height)) - Math.Pow((double)totalgr2 / (double)(CitraOutput1.Width * CitraOutput1.Height), 2));
            int[] newH2 = new int[256]; double[] newHpdf2 = new double[256];
            double[] npdf2 = new double[256];
            double[] ncdf2 = new double[256];
            int[] f2 = new int[256];
            cliplimit = 0;
            for (int i = 0; i < H.Length; i++)
            {
                if (aktifK == false)
                {
                    if (tlow > tmid && tlow > thigh)
                        cliplimit = (c1) + pdf.Max();
                    else if (thigh > tlow && thigh > tmid)
                        cliplimit = (c2) + means(pdf);
                    else
                        cliplimit = means(pdf);
                }
                else
                {
                    if (tlow > tmid && tlow > thigh)
                        cliplimit = (c1) * i + pdf.Max();
                    else if (thigh > tlow && thigh > tmid)
                        cliplimit = (c2) * i + means(pdf);
                    else
                        cliplimit = means(pdf);
                }
                if (pdf[i] > cliplimit)
                {
                    npdf2[i] = cliplimit;
                }
                else npdf2[i] = pdf[i];
                if (i > 0)
                    ncdf2[i] = ncdf2[i - 1] + npdf2[i];
                else ncdf2[i] = npdf2[i];
            }
            for (int i = 0; i < H.Length; i++)
            {
                npdf2[i] /= ncdf2[255];
                if (i > 0)
                    ncdf2[i] = ncdf2[i - 1] + npdf2[i];
                else ncdf2[i] = npdf2[i];
                f2[i] = Convert.ToInt32(Math.Round(HElowbound + ((HEhibound - HElowbound) * (ncdf2[i] - (npdf2[i] / 2)))));
            }
            totalgr1 = 0; totalgr2 = 0;
            for (int x = 0; x < CitraOutput2.Width; x++)
            {
                for (int y = 0; y < CitraOutput2.Height; y++)
                {
                    Color c = CitraOutput2.GetPixel(x, y);
                    int gr = f2[(int)c.R];
                    Color g = Color.FromArgb(gr, gr, gr);
                    CitraOutput2.SetPixel(x, y, g);
                    newH2[gr]++;
                    totalgr1 += (gr * gr);
                    totalgr2 += gr;
                }
            }
            Contrast_ACEDP = (double)10f * Math.Log10((double)((double)totalgr1 / (double)(CitraOutput2.Width * CitraOutput2.Height)) - Math.Pow((double)totalgr2 / (double)(CitraOutput2.Width * CitraOutput2.Height), 2));
            for (int i = 0; i < H.Length; i++)
            {
                newHpdf1[i] = (double)newH1[i] / (double)newH1.Sum();
                newHpdf2[i] = (double)newH2[i] / (double)newH2.Sum();
                if (pdf[i] > 0)
                    Entropy += ((double)(-1) * (double)pdf[i] * (double)Math.Log(pdf[i], 2));
                if (newHpdf1[i] > 0)
                    Entropy_AFCEDP += ((double)(-1) * (double)newHpdf1[i] * (double)Math.Log(newHpdf1[i], 2));
                if (newHpdf2[i] > 0)
                    Entropy_ACEDP += ((double)(-1) * (double)newHpdf2[i] * (double)Math.Log(newHpdf2[i], 2));
            }
        }
        private double means(double[] p)
        {
            double rerata = 0;
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] > 0) rerata++;
            }
            return (double)p.Sum() / (double)rerata;
        }
    }
}
