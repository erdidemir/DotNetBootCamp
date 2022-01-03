using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._03.LSP.Wrong
{
    internal class Iha : IUcak
    {
        public bool HedefiVur()
        {
            return false;
        }

        public bool KesifYap()
        {
            Console.WriteLine(this.GetType().Name + " keşfi tamamladı.");
            return true;
        }
    }
}
