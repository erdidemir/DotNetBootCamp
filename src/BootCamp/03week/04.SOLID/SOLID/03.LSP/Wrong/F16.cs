using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._03.LSP.Wrong
{
    internal class F16 : IUcak
    {
        public bool HedefiVur()
        {
            Console.WriteLine("F16 hedefi vurdu.");
            return true;
        }

        public bool KesifYap()
        {
            Console.WriteLine("F16 keşfi tamamladı.");
            return true;
        }
    }
}
