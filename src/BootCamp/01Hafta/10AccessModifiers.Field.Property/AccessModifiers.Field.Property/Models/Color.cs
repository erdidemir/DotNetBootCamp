using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers.Field.Property.Models
{
    public class Color
    {
        public static readonly Color Siyah = new Color(0, 0, 0);
        public static readonly Color Beyaz = new Color(255, 255, 255);
        public static readonly Color Kırmızı = new Color(255, 0, 0);
        public static readonly Color Yeşil = new Color(0, 255, 0);
        public static readonly Color Mavi = new Color(0, 0, 255);

        private byte r, g, b;
        public Color(byte r, byte g, byte b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public byte getR()
        { return r; }

        public byte getG()
        { return g; }

        public byte getB()
        { return b; }
    }
}
