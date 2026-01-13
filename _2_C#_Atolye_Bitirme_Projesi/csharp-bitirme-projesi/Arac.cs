using System;

namespace csharp_bitirme_projesi
{
    class Arac
    {
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Tip { get; set; }
        public double GunlukFiyat { get; set; }

        public string MarkaModel => $"{Marka} {Model}";
    }
}
