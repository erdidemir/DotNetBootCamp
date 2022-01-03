using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._03.LSP.Right
{
    internal class Iha : IUcakKesif
    {
        public bool KesifYap()
        {
            Console.WriteLine(this.GetType().Name + " keşfi tamamladı.");
            return true;
        }
    }
}
