using SOLID._01.SRP.Right;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._02.OCP.Right
{
    public class PDFRaporOlustur : Rapor
    {
        public override void RaporOlustur(Employee em)
        {
            // PDF ile rapor oluştur
            Console.WriteLine("Pdf oluşturuldu");
        }
    }
}
