using SOLID._01.SRP.Right;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._02.OCP.Wrong
{
    public class RaporOlusturma
    {
        /// <summary>
        /// Rapor oluşturmak için kullanılan metod
        /// </summary>
        /// <param name="em"></param>
        public void RaporOlustur(Employee em)
        {
            string RaporTipi = "";

            if (RaporTipi == "CRS")
            {
                // Crystal Report ile rapor oluştur
            }
            if (RaporTipi == "PDF")
            {
                // PDF formatında rapor oluştur
            }
        }
    }
}
