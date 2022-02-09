using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._04.ISP.Wrong
{
    internal class Tank3 : IWTank
    {
        public bool AtesEt() => true;
        public double DusmanIleMesafeOlc()
        {
            //Tank3'ün mesafa ölçme özelliği yoktur!
            return -1;
        }
        public bool HareketEt() => true;
    }
}
