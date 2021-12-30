using System;

namespace Extentions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Sayi

            int sayi = 3;

            Console.WriteLine(sayi.Faktoryel());

            sayi = 5;

            Console.WriteLine(sayi.Faktoryel());


            #endregion

            #region Telefon

            string telefon = "0 539 888 8888";

            Console.WriteLine(telefon.ToTelefonFormat());


            telefon = " 539 888 8888";

            Console.WriteLine(telefon.ToTelefonFormat());


            telefon = "+90 (539) 888 8888";

            Console.WriteLine(telefon.ToTelefonFormat());

            #endregion

            #region Person

            Person person = new Person(1, "Ahmet", "Mehmet");

            Console.WriteLine(person.FullName());

            #endregion


            Console.ReadLine();
        }
    }
}
