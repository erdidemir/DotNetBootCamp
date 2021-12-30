using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attribute_.Reflection
{

    public class Ogrenci
    {
        public string OgrenciNo { get; set; }
        public string Adi { get; set; }
        public string SoyAdi { get; set; }
        public double MaasHesapla(int Saat, double Ucret) => Saat * Ucret;
    }
}
