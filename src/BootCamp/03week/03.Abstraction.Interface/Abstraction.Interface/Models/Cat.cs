using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Interface.Models
{
    public class Cat : Animal, IMeow
    {
        public void Meow()
        {
            Console.WriteLine("Meow ! ");
        }
    }
}
