using SOLID._01.SRP.Right;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._02.OCP.Right
{
    public abstract class Rapor
    {
        public int RaporId { get; set; }
        public string RaporAdi { get; set; }

        /// <summary>
        /// Method to generate report
        /// </summary>
        /// <param name="em"></param>
        public abstract void RaporOlustur(Employee em);
        // Override edilecek olan metodumuzdur. Bu metod farklı tipte raporlamalar için kullanılacaktır.
    }
}
