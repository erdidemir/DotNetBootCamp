using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extentions
{
    public class Person
    {
        public Person(int id, string firsName, string lastName)
        {
            Id = id;
            FirsName = firsName;    
            LastName = lastName;
        }
        public int Id { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }


    }
}
