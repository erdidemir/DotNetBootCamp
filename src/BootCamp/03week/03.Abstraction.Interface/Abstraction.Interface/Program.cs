using Abstraction.Interface.Models;
using System;

namespace Abstraction.Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cat = new Cat();

            cat.Meow();


            var dog = new Dog();
            
            dog.Bark();

            Console.ReadLine();
        }
    }
}
