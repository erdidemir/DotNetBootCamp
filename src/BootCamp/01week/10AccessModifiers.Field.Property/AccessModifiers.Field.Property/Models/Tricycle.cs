using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers.Field.Property.Models
{
    // public class:
    public class Tricycle
    {
        // protected method:
        protected void Pedal() { }

        // private field:
        private int wheels = 3;

        // protected internal property:
        protected internal int Wheels
        {
            get { return wheels; }
        }
    }
}
