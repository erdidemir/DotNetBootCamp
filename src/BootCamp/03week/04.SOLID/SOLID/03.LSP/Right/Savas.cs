using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._03.LSP.Right
{
    internal class Savas
    {
        List<IHedefiVur> HedefVurucular;
        List<IUcakKesif> KesifYapicilar;
        public Savas(List<IUcakKesif> KesifYapicilar, List<IHedefiVur> HedefVurucular)
        {
            this.KesifYapicilar = KesifYapicilar;
            this.HedefVurucular = HedefVurucular;
        }

        public void KesifYap()
        {
            KesifYapicilar.ForEach(u =>
            {
                u.KesifYap();
            });
        }

        public void HedefiVur()
        {
            HedefVurucular.ForEach(u =>
            {
                u.HedefiVur();
            });
        }
    }
}
