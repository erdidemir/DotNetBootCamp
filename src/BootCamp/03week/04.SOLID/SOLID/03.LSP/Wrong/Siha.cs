using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._03.LSP.Wrong
{
    internal class Siha : IUcak
    {
        public bool HedefiVur()
        {
            Console.WriteLine(this.GetType().Name + " hedefi vurdu.");
            return true;
        }

        public bool KesifYap()
        {
            Console.WriteLine(this.GetType().Name + " keşfi tamamladı.");
            return true;
        }
    }
}
