using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._04.ISP.Right
{
    internal class Tank3 : ITankAtesEt, ITankHareketEt
    {
        public bool AtesEt() => true;
        public bool HareketEt() => true;
    }
}
