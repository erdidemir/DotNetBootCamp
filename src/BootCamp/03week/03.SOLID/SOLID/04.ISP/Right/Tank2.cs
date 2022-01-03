using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._04.ISP.Right
{
    internal class Tank2 : ITankHareketEt, ITankMesafeOlc
    {
        public double DusmanIleMesafeOlc()
        {
            //Mesafa ölçme işlemleri
            return 230;
        }
        public bool HareketEt() => true;
    }
}
