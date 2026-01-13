using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp_bitirme_projesi
{
    static class AracManager
    {
        public static List<Arac> Araclar = new List<Arac>();

        public static void AraclariBaslat()
        {
            Araclar.Add(new Arac { Plaka = "45CBS10", Marka = "Porsche", Model = "Taycan", Tip = "Sedan", GunlukFiyat = 1500 });
            Araclar.Add(new Arac { Plaka = "65MKK09", Marka = "BMW", Model = "X5", Tip = "SUV", GunlukFiyat = 1800 });
            Araclar.Add(new Arac { Plaka = "04MMC04", Marka = "Audi", Model = "A6", Tip = "Sedan", GunlukFiyat = 1600 });
            Araclar.Add(new Arac { Plaka = "34MEY01", Marka = "Mercedes", Model = "C180", Tip = "Sedan", GunlukFiyat = 1400 });
            Araclar.Add(new Arac { Plaka = "06EEA99", Marka = "Toyota", Model = "RAV4", Tip = "SUV", GunlukFiyat = 1200 });
        }

        public static void AraclariListele()
        {
            Console.WriteLine("\n=== MEVCUT ARACLAR ===");
            Console.WriteLine(new string('-', 70));
            foreach (var arac in Araclar)
            {
                Console.WriteLine($"Plaka: {arac.Plaka,-10} | {arac.MarkaModel,-20} | Tip: {arac.Tip,-10} | Fiyat: {arac.GunlukFiyat} TL/gun");
            }
            Console.WriteLine(new string('-', 70));
        }

        public static List<string> MusaitAraclariGetir(DateTime baslangic, DateTime bitis)
        {
            return Araclar
                .Where(a => AracMusaitMi(a.Plaka, baslangic, bitis))
                .Select(a => $"{a.Plaka} - {a.MarkaModel} ({a.Tip}) - {a.GunlukFiyat} TL/gun")
                .ToList();
        }

        public static void MusaitAraclariGoster(DateTime baslangic, DateTime bitis)
        {
            var musaitler = MusaitAraclariGetir(baslangic, bitis);

            Console.WriteLine($"\n=== {baslangic:dd/MM/yyyy} - {bitis:dd/MM/yyyy} TARIHLERI ARASI MUSAIT ARACLAR ===");
            Console.WriteLine(new string('-', 70));

            if (musaitler.Count == 0)
            {
                Console.WriteLine("Bu tarihler arasinda musait arac bulunmamaktadir.");
            }
            else
            {
                foreach (var arac in musaitler)
                {
                    Console.WriteLine(arac);
                }
            }
            Console.WriteLine(new string('-', 70));
        }

        public static bool AracMusaitMi(string plaka, DateTime baslangic, DateTime bitis)
        {
            if (!Araclar.Any(a => a.Plaka == plaka))
            {
                return false;
            }

            return !RezervasyonManager.Rezervasyonlar.Any(r =>
                r.Plaka == plaka &&
                baslangic < r.Bitis &&
                bitis > r.Baslangic);
        }

        public static double AracGunlukFiyatiniGetir(string plaka)
        {
            var arac = Araclar.FirstOrDefault(a => a.Plaka == plaka);
            return arac?.GunlukFiyat ?? 0;
        }

        public static Arac AracGetir(string plaka)
        {
            return Araclar.FirstOrDefault(a => a.Plaka == plaka);
        }

        public static bool AracVarMi(string plaka)
        {
            return Araclar.Any(a => a.Plaka == plaka);
        }
    }
}
