using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers.Field.Property.Models
{
    public class Personel
    {
        public static int PersonelSayısı;
        private static int say;
        private string isim;

        // Okuma ve Yazma Özelliği
        public string Isım
        {
            get { return isim; }
            set { isim = value; }
        }

        // Sadece Okunabilir Özelliği
        public static int Say
        {
            get { return say; }
        }

        // Yapıcı metodumuz.
        public Personel()
        {
            // Personel Sayısını Hesapla
            say = ++PersonelSayısı;
        }
    }
}
