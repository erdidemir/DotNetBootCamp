using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._04.ISP.Wrong
{
    class Tank1 : ITank
    {
        public bool AtesEt() => true;
        public double DusmanIleMesafeOlc()
        {
            //Mesafa ölçme işlemleri
            return 100;
        }
        public bool HareketEt() => true;
    }
}
