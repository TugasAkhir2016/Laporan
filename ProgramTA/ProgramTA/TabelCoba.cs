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
        public double Entropy {get;set;} public double newEntropy1 {get;set;} public double newEntropy2{get;set;} public double Contrast {get;set;} public double newContrast1{get;set;} public double newContrast2{get;set;}
        public TabelCoba(string filename, double c1, double c2, double Entropy, double newEntropy1, double newEntropy2, double Contrast, double newContrast1, double newContrast2)
        {
            this.filename = filename;
            this.c1 = c1; this.c2 = c2;
            this.Entropy = Entropy;
            this.Contrast = Contrast;
            this.newContrast1 = newContrast1;
            this.newContrast2 = newContrast2;
            this.newEntropy1 = newEntropy1;
            this.newEntropy2 = newEntropy2;
        }
    }
}
