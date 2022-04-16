using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers.Field.Property.Models
{
    public class Personel
    {
        [Required]
        public static int PersonelSayısı;

        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "Max 50 characters")]
        [RegularExpression(@"\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b")]
        public string Email { get; set; }


        private static int say;
        private string isim;

        // Okuma ve Yazma Özelliği
        [Display(Name ="İsim")]
        public string Isım
        {
            get { return isim; }
            set { isim = value; }
        }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DogumTarih { get; set; }

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
