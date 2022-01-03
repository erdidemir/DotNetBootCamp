using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Interface.Models
{
    internal class Dog:Animal,IBark
    {
        public void Bark()
        {
            Console.WriteLine("Bark ! ");
        }
    }
}
