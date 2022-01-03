using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._04.ISP.Wrong
{
    internal class Tank2 : ITank
    {
        public bool AtesEt()
        {
            //Tank2'nin ateş etme özelliği yoktur!
            return false;
        }
        public double DusmanIleMesafeOlc()
        {
            //Mesafa ölçme işlemleri
            return 230;
        }
        public bool HareketEt() => true;
    }
}
