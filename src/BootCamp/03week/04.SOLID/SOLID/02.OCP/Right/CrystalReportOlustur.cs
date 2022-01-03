using SOLID._01.SRP.Right;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._02.OCP.Right
{
    public class CrystalReportOlustur : Rapor
    {
        public override void RaporOlustur(Employee em)
        {
            // Crystal Report ile rapor oluştur
            Console.WriteLine("Crystal Report oluşturuldu");
        }
    }
}
