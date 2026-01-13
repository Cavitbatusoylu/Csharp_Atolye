using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace csharp_bitirme_projesi
{
    static class DosyaManager
    {
        private static readonly string dosyaYolu = "rezervasyonlar.txt";
        private static readonly string jsonDosyaYolu = "rezervasyonlar.json";

        public static void DosyalariBaslat()
        {
            Yukle();
        }

        public static void Kaydet()
        {
            try
            {
                var satirlar = RezervasyonManager.Rezervasyonlar.Select(r =>
                    $"{r.Musteri}|{r.Plaka}|{r.Baslangic:yyyy-MM-dd HH:mm}|{r.Bitis:yyyy-MM-dd HH:mm}|{r.Ucret}|{r.Saatlik}");

                File.WriteAllLines(dosyaYolu, satirlar);

                JsonKaydet();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HATA: Dosya kaydedilemedi! {ex.Message}");
            }
        }

        private static void JsonKaydet()
        {
            try
            {
                var sb = new StringBuilder();
                sb.AppendLine("[");

                var rezervasyonlar = RezervasyonManager.Rezervasyonlar;
                for (int i = 0; i < rezervasyonlar.Count; i++)
                {
                    var r = rezervasyonlar[i];
                    sb.AppendLine("  {");
                    sb.AppendLine($"    \"musteri\": \"{r.Musteri}\",");
                    sb.AppendLine($"    \"plaka\": \"{r.Plaka}\",");
                    sb.AppendLine($"    \"baslangic\": \"{r.Baslangic:yyyy-MM-dd HH:mm}\",");
                    sb.AppendLine($"    \"bitis\": \"{r.Bitis:yyyy-MM-dd HH:mm}\",");
                    sb.AppendLine($"    \"ucret\": {r.Ucret},");
                    sb.AppendLine($"    \"saatlik\": {r.Saatlik.ToString().ToLower()}");
                    sb.Append("  }");
                    if (i < rezervasyonlar.Count - 1)
                        sb.AppendLine(",");
                    else
                        sb.AppendLine();
                }

                sb.AppendLine("]");
                File.WriteAllText(jsonDosyaYolu, sb.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HATA: JSON dosyasi kaydedilemedi! {ex.Message}");
            }
        }

        public static void Yukle()
        {
            try
            {
                if (!File.Exists(dosyaYolu))
                {
                    return;
                }

                foreach (var satir in File.ReadAllLines(dosyaYolu))
                {
                    if (string.IsNullOrWhiteSpace(satir)) continue;

                    var parcalar = satir.Split('|');

                    if (parcalar.Length >= 6)
                    {
                        RezervasyonManager.Rezervasyonlar.Add(new Rezervasyon
                        {
                            Musteri = parcalar[0],
                            Plaka = parcalar[1],
                            Baslangic = DateTime.Parse(parcalar[2]),
                            Bitis = DateTime.Parse(parcalar[3]),
                            Ucret = double.Parse(parcalar[4]),
                            Saatlik = bool.Parse(parcalar[5])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HATA: Dosya yuklenemedi! {ex.Message}");
            }
        }
    }
}
