using System;
using System.Linq;

namespace Attribute_.Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintAuthorInfo(typeof(FirstClass));
            PrintAuthorInfo(typeof(SecondClass));
            PrintAuthorInfo(typeof(ThirdClass));

            /* Output:  
    Author information for FirstClass  
       P. Ackerman, version 1.00  
    Author information for SecondClass  
    Author information for ThirdClass  
       R. Koch, version 2.00  
       P. Ackerman, version 1.00  
*/

            Ogrenci o = new Ogrenci();
            o.GetType().GetProperties().ToList().ForEach(p =>
            {
                Console.WriteLine(p.Name);
            });


            Ogrenci o1 = new Ogrenci();
            o1.GetType().GetMethods().ToList().ForEach(m =>
            {
                if (m.Name == "MaasHesapla")
                {
                    var Sonuc = m.Invoke(o1, new object[] { 3, 5 });
                    Console.WriteLine(Sonuc);
                }
            });



            Console.ReadLine();
        }

        private static void PrintAuthorInfo(System.Type t)
        {
            System.Console.WriteLine("Author information for {0}", t);

            // Using reflection.  
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t);  // Reflection.  

            // Displaying output.  
            foreach (System.Attribute attr in attrs)
            {
                if (attr is Author)
                {
                    Author a = (Author)attr;
                    System.Console.WriteLine("   {0}, version {1:f}", a.GetName(), a.version);
                }
            }
        }
    }
}
