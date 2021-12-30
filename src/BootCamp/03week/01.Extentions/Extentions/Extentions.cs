using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Extentions
{
    public static class Extentions
    {
        public static string FullName(this Person person)
        {
            return person.FirsName + " " + person.LastName;
        }
        public static int Faktoryel(this Int32 sayi)
        {
            if (sayi == 0
                || sayi == 1)
                return 1;
            else
                return sayi * Faktoryel(sayi - 1);
        }

        public static string ToTelefonFormat(this string telefon)
        {
            Match match;
            string desen = "", DogruTelefon = "";
            telefon = telefon.Replace("-", "").Replace("_", "").Replace("(", "").Replace(")", "").Replace(" ", "").Replace("+", "");
            if (telefon.Substring(0, 2) == "95")
            {
                telefon = telefon.Remove(0, 1);
            }
            switch (telefon.Length)
            {
                case 10:
                    desen = @"^(5(\d{9}))$";
                    break;
                case 11:
                    desen = @"^(05(\d{9}))$";
                    break;
                case 12:
                    desen = @"^(905(\d{9}))$";
                    break;
                default:

                    break;
            }
            match = Regex.Match(telefon, desen, RegexOptions.IgnoreCase);
            if (match.Success)
                switch (telefon.Length)
                {
                    case 10:
                        DogruTelefon = "0" + telefon;
                        break;
                    case 11:
                        DogruTelefon = telefon;
                        break;
                    case 12:
                        DogruTelefon = telefon.Remove(0, 1);
                        break;
                    default:
                        DogruTelefon = "0";
                        break;
                }

            return DogruTelefon;
        }
    }
}
