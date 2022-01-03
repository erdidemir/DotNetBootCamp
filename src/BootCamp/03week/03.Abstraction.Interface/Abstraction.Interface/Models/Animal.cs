using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Interface.Models
{
    public abstract class Animal
    {
        public bool isAPet = true;
        public String owner = "xxx";

        public void Sleep()
        {
           Console.WriteLine("Sleeping");
        }

        public void Eat()
        {
            Console.WriteLine("Eating");
        }
    }


}
