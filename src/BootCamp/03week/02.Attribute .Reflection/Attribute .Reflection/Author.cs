using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attribute_.Reflection
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                        System.AttributeTargets.Struct,
                        AllowMultiple = true)  // Multiuse attribute.  
 ]
    public class Author : System.Attribute
    {
        string name;
        public double version;

        public Author(string name)
        {
            this.name = name;

            // Default value.  
            version = 1.0;
        }

        public string GetName()
        {
            return name;
        }
    }
}
