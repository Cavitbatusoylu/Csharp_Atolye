using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace csharp_bitirme_projesi
{
    static class RezervasyonManager
    {
        public static List<Rezervasyon> Rezervasyonlar = new List<Rezervasyon>();

        public static void RezervasyonEkle(string musteri, string plaka, DateTime baslangic, DateTime bitis)
        {
            RezervasyonYap(musteri, plaka, baslangic, bitis, false);
        }

        public static void RezervasyonYap(string musteri, string plaka, DateTime baslangic, DateTime bitis, bool saatlik)
        {
            if (string.IsNullOrWhiteSpace(musteri))
            {
                Console.WriteLine("HATA: Musteri adi bos olamaz!");
                return;
            }

            if (string.IsNullOrWhiteSpace(plaka))
            {
                Console.WriteLine("HATA: Plaka bos olamaz!");
                return;
            }

            if (!AracManager.AracVarMi(plaka))
            {
                Console.WriteLine("HATA: Belirtilen plakaya sahip arac bulunamadi!");
                return;
            }

            if (bitis <= baslangic)
            {
                Console.WriteLine("HATA: Bitis tarihi baslangic tarihinden sonra olmalidir!");
                return;
            }

            if (!AracManager.AracMusaitMi(plaka, baslangic, bitis))
            {
                Console.WriteLine("HATA: Arac belirtilen tarihlerde musait degil!");
                return;
            }

            double ucret = RezervasyonUcretiHesapla(plaka, baslangic, bitis, saatlik);

            Rezervasyonlar.Add(new Rezervasyon
            {
                Musteri = musteri,
                Plaka = plaka,
                Baslangic = baslangic,
                Bitis = bitis,
                Ucret = ucret,
                Saatlik = saatlik
            });

            DosyaManager.Kaydet();

            var arac = AracManager.AracGetir(plaka);
            Console.WriteLine("\n============================================================");
            Console.WriteLine("           REZERVASYON BASARIYLA OLUSTURULDU               ");
            Console.WriteLine("============================================================");
            Console.WriteLine($"  Musteri    : {musteri}");
            Console.WriteLine($"  Arac       : {arac.MarkaModel}");
            Console.WriteLine($"  Plaka      : {plaka}");
            Console.WriteLine($"  Tarih      : {baslangic:dd/MM/yyyy} - {bitis:dd/MM/yyyy}");
            Console.WriteLine($"  Ucret      : {ucret} TL");
            Console.WriteLine("============================================================");
        }

        public static double RezervasyonUcretiHesapla(string plaka, DateTime baslangic, DateTime bitis, bool saatlik = false)
        {
            double gunlukFiyat = AracManager.AracGunlukFiyatiniGetir(plaka);

            if (saatlik)
            {
                double toplamSaat = (bitis - baslangic).TotalHours;
                return Math.Ceiling(toplamSaat * (gunlukFiyat / 24));
            }
            else
            {
                int gunSayisi = (int)Math.Ceiling((bitis - baslangic).TotalDays);
                return gunSayisi * gunlukFiyat;
            }
        }

        public static void RezervasyonIptal(string plaka)
        {
            var silinecekler = Rezervasyonlar.Where(r => r.Plaka == plaka).ToList();

            if (silinecekler.Count == 0)
            {
                Console.WriteLine("HATA: Bu plakaya ait aktif rezervasyon bulunamadi!");
                return;
            }

            Rezervasyonlar.RemoveAll(r => r.Plaka == plaka);
            DosyaManager.Kaydet();

            Console.WriteLine($"BASARILI: {silinecekler.Count} adet rezervasyon iptal edildi.");
        }

        public static double ToplamGelir()
        {
            return Rezervasyonlar.Sum(r => r.Ucret);
        }

        public static List<string> MusteriRezervasyonlariniGetir(string musteri)
        {
            return Rezervasyonlar
                .Where(r => r.Musteri.ToLower().Contains(musteri.ToLower()))
                .Select(r => r.ToString())
                .ToList();
        }

        public static void MusteriRezervasyonlari(string musteri)
        {
            var rezervasyonlar = MusteriRezervasyonlariniGetir(musteri);

            Console.WriteLine($"\n=== '{musteri}' MUSTERISININ REZERVASYONLARI ===");
            Console.WriteLine(new string('-', 70));

            if (rezervasyonlar.Count == 0)
            {
                Console.WriteLine("Bu musteriye ait rezervasyon bulunamadi.");
            }
            else
            {
                foreach (var rez in rezervasyonlar)
                {
                    Console.WriteLine(rez);
                }
                Console.WriteLine(new string('-', 70));
                Console.WriteLine($"Toplam: {rezervasyonlar.Count} rezervasyon");
            }
        }

        public static string EnCokKiralananArac()
        {
            if (Rezervasyonlar.Count == 0)
            {
                return "Henuz rezervasyon bulunmuyor.";
            }

            var enCok = Rezervasyonlar
                .GroupBy(r => r.Plaka)
                .OrderByDescending(g => g.Count())
                .First();

            var arac = AracManager.AracGetir(enCok.Key);
            return arac != null
                ? $"{arac.MarkaModel} ({arac.Plaka}) - {enCok.Count()} kez kiralandi"
                : enCok.Key;
        }

        public static List<string> RezervasyonAra(string anahtar)
        {
            return Rezervasyonlar
                .Where(r => r.Musteri.ToLower().Contains(anahtar.ToLower()) ||
                           r.Plaka.ToLower().Contains(anahtar.ToLower()))
                .Select(r => r.ToString())
                .ToList();
        }

        public static void RezervasyonAraVeGoster(string anahtar)
        {
            var sonuclar = RezervasyonAra(anahtar);

            Console.WriteLine($"\n=== '{anahtar}' ICIN ARAMA SONUCLARI ===");
            Console.WriteLine(new string('-', 70));

            if (sonuclar.Count == 0)
            {
                Console.WriteLine("Arama kriterine uygun rezervasyon bulunamadi.");
            }
            else
            {
                foreach (var sonuc in sonuclar)
                {
                    Console.WriteLine(sonuc);
                }
                Console.WriteLine(new string('-', 70));
                Console.WriteLine($"Toplam: {sonuclar.Count} sonuc bulundu");
            }
        }

        public static void RaporYazdir()
        {
            double saatlikGelir = Rezervasyonlar.Where(r => r.Saatlik).Sum(r => r.Ucret);
            double gunlukGelir = Rezervasyonlar.Where(r => !r.Saatlik).Sum(r => r.Ucret);
            int saatlikSayi = Rezervasyonlar.Count(r => r.Saatlik);
            int gunlukSayi = Rezervasyonlar.Count(r => !r.Saatlik);

            string raporIcerigi = "============================================================\n";
            raporIcerigi += "            ARAC KIRALAMA SISTEMI RAPORU                    \n";
            raporIcerigi += $"            Olusturma Tarihi: {DateTime.Now:dd/MM/yyyy HH:mm}              \n";
            raporIcerigi += "============================================================\n";
            raporIcerigi += $"  Toplam Rezervasyon Sayisi: {Rezervasyonlar.Count}\n";
            raporIcerigi += "------------------------------------------------------------\n";
            raporIcerigi += $"  Gunluk Kiralama  : {gunlukSayi} adet - {gunlukGelir} TL\n";
            raporIcerigi += $"  Saatlik Kiralama : {saatlikSayi} adet - {saatlikGelir} TL\n";
            raporIcerigi += "------------------------------------------------------------\n";
            raporIcerigi += $"  TOPLAM GELIR     : {ToplamGelir()} TL\n";
            raporIcerigi += $"  En Cok Kiralanan Arac: {EnCokKiralananArac()}\n";
            raporIcerigi += "============================================================\n";
            raporIcerigi += "                    TUM REZERVASYONLAR                      \n";
            raporIcerigi += "============================================================\n";

            foreach (var rez in Rezervasyonlar)
            {
                raporIcerigi += $"  {rez}\n";
            }

            raporIcerigi += "============================================================\n";

            File.WriteAllText("rapor.txt", raporIcerigi);

            RaporJsonKaydet(saatlikGelir, gunlukGelir, saatlikSayi, gunlukSayi);
        }

        private static void RaporJsonKaydet(double saatlikGelir, double gunlukGelir, int saatlikSayi, int gunlukSayi)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("{");
            sb.AppendLine($"  \"olusturmaTarihi\": \"{DateTime.Now:yyyy-MM-dd HH:mm}\",");
            sb.AppendLine($"  \"toplamRezervasyonSayisi\": {Rezervasyonlar.Count},");
            sb.AppendLine("  \"gelirOzeti\": {");
            sb.AppendLine($"    \"gunlukKiralamaSayisi\": {gunlukSayi},");
            sb.AppendLine($"    \"gunlukGelir\": {gunlukGelir},");
            sb.AppendLine($"    \"saatlikKiralamaSayisi\": {saatlikSayi},");
            sb.AppendLine($"    \"saatlikGelir\": {saatlikGelir},");
            sb.AppendLine($"    \"toplamGelir\": {ToplamGelir()}");
            sb.AppendLine("  },");
            sb.AppendLine($"  \"enCokKiralananArac\": \"{EnCokKiralananArac()}\",");
            sb.AppendLine("  \"rezervasyonlar\": [");

            for (int i = 0; i < Rezervasyonlar.Count; i++)
            {
                var r = Rezervasyonlar[i];
                sb.AppendLine("    {");
                sb.AppendLine($"      \"musteri\": \"{r.Musteri}\",");
                sb.AppendLine($"      \"plaka\": \"{r.Plaka}\",");
                sb.AppendLine($"      \"baslangic\": \"{r.Baslangic:yyyy-MM-dd HH:mm}\",");
                sb.AppendLine($"      \"bitis\": \"{r.Bitis:yyyy-MM-dd HH:mm}\",");
                sb.AppendLine($"      \"ucret\": {r.Ucret},");
                sb.AppendLine($"      \"kiralamaTipi\": \"{(r.Saatlik ? "Saatlik" : "Gunluk")}\"");
                sb.Append("    }");
                if (i < Rezervasyonlar.Count - 1)
                    sb.AppendLine(",");
                else
                    sb.AppendLine();
            }

            sb.AppendLine("  ]");
            sb.AppendLine("}");

            File.WriteAllText("rapor.json", sb.ToString());
        }
    }
}