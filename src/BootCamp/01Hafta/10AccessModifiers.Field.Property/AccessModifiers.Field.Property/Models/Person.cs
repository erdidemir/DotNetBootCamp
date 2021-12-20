using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers.Field.Property.Models
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private DateTime _birthDate;    

        public Person(string first, string last, DateTime birthDate)
        {
            _firstName = first;
            _lastName = last;
            _birthDate = birthDate;
        }

        public string Name => $"{_firstName} {_lastName}";

        public int Age => DateTime.Now.Subtract(_birthDate).Days/365;
    }

}
