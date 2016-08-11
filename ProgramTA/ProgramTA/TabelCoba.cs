using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramTA
{
    class TabelCoba
    {
        public string filename { get; set; }
        public double c1 { get; set; }
        public double c2 { get; set; }
        public double Entropy {get;set;} public double Entropy_AFCEDP {get;set;} public double Entropy_ACEDP{get;set;} public double CIE_awal {get;set;} public double CIE_AFCEDP{get;set;} public double CIE_ACEDP{get;set;}
        public TabelCoba(string filename, double c1, double c2, double Entropy, double newEntropy1, double newEntropy2, double Contrast, double newContrast1, double newContrast2)
        {
            this.filename = filename;
            this.c1 = c1; this.c2 = c2;
            this.Entropy = Entropy;
            this.CIE_awal = Contrast;
            this.CIE_AFCEDP = newContrast1;
            this.CIE_ACEDP = newContrast2;
            this.Entropy_AFCEDP = newEntropy1;
            this.Entropy_ACEDP = newEntropy2;
        }
    }
}
