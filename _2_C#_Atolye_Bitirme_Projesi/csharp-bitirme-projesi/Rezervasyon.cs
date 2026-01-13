using System;

namespace csharp_bitirme_projesi
{
    class Rezervasyon
    {
        public string Musteri { get; set; }
        public string Plaka { get; set; }
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }
        public double Ucret { get; set; }
        public bool Saatlik { get; set; }

        public override string ToString()
        {
            string sureTipi = Saatlik ? "Saatlik" : "Gunluk";
            return $"Musteri: {Musteri} | Plaka: {Plaka} | {Baslangic:dd/MM/yyyy} - {Bitis:dd/MM/yyyy} | Ucret: {Ucret} TL ({sureTipi})";
        }
    }
}
