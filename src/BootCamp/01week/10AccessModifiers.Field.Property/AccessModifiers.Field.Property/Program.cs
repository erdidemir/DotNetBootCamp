using AccessModifiers.Field.Property.Models;
using System;
using System.Drawing;

namespace AccessModifiers.Field.Property
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var testSiyah = new Models.Color(0,0,0);
            Console.WriteLine("{0}, {1}, {2}", testSiyah.getR(), testSiyah.getG(), testSiyah.getB());


            CalendarEntry birthday = new CalendarEntry();
            birthday.Day = "Saturday";


            TimePeriod t = new TimePeriod();
            // The property assignment causes the 'set' accessor to be called.
            t.Hours = 24;

            // Retrieving the property causes the 'get' accessor to be called.
            Console.WriteLine($"Time in hours: {t.Hours}");

            var person = new Person("Erdi", "Demir", new DateTime(1989,11,17));
            Console.WriteLine(person.Name + " Age:" + person.Age);

            //var item = new SaleItem("Shoes", 19.95m);
            //Console.WriteLine($"{item.Name}: sells for {item.Price:C2}");


            //Personel.PersonelSayısı = 100;

            //Personel prsnl = new Personel();
            //prsnl.Isım = "Erdi Demir";

            //Console.WriteLine("Personel Sayısı: {0}", Personel.PersonelSayısı);
            ////Çıktı: 101
            //Console.WriteLine("Personel Ismi: {0}", prsnl.Isım);

            Console.ReadLine();
        }
    }
}
