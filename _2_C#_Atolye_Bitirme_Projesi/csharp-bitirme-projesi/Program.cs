using System;

namespace csharp_bitirme_projesi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            AracManager.AraclariBaslat();
            DosyaManager.DosyalariBaslat();

            while (true)
            {
                Console.Clear();
                AnaMenuGoster();

                Console.Write("Seciminiz: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        AracManager.AraclariListele();
                        break;

                    case "2":
                        MusaitAracGoster();
                        break;

                    case "3":
                        RezervasyonYap();
                        break;

                    case "4":
                        RezervasyonDuzenle();
                        break;

                    case "5":
                        RezervasyonIptalEt();
                        break;

                    case "6":
                        MusteriRezervasyonGoster();
                        break;

                    case "7":
                        RezervasyonAra();
                        break;

                    case "8":
                        ToplamGelirGoster();
                        break;

                    case "9":
                        EnCokKiralananAracGoster();
                        break;

                    case "10":
                        RaporOlustur();
                        break;

                    case "0":
                        CikisYap();
                        return;

                    default:
                        Console.WriteLine("\nHATA: Gecersiz secim! Lutfen 0-10 arasinda bir deger girin.");
                        break;
                }

                Console.WriteLine("\nDevam etmek icin Enter'a basin...");
                Console.ReadLine();
            }
        }

        private static void AnaMenuGoster()
        {
            Console.WriteLine("============================================================");
            Console.WriteLine("       AKILLI ARAC KIRALAMA REZERVASYON SISTEMI            ");
            Console.WriteLine("============================================================");
            Console.WriteLine("  [1] Tum Araclari Listele                                 ");
            Console.WriteLine("  [2] Musait Araclari Goster                               ");
            Console.WriteLine("  [3] Yeni Rezervasyon Yap                                 ");
            Console.WriteLine("  [4] Rezervasyon Duzenle                                  ");
            Console.WriteLine("  [5] Rezervasyon Iptal Et                                 ");
            Console.WriteLine("  [6] Musteri Rezervasyonlarini Goruntule                  ");
            Console.WriteLine("  [7] Rezervasyon Ara                                      ");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("  [8] Toplam Geliri Goster                                 ");
            Console.WriteLine("  [9] En Cok Kiralanan Arac                                ");
            Console.WriteLine(" [10] Raporu Dosyaya Yazdir                                ");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("  [0] Cikis                                                ");
            Console.WriteLine("============================================================");
        }

        private static void MusaitAracGoster()
        {
            Console.WriteLine("\n=== MUSAIT ARAC SORGULAMA ===");

            DateTime? baslangic = TarihAl("Baslangic Tarihi (gg/aa/yyyy): ");
            if (!baslangic.HasValue) return;

            DateTime? bitis = TarihAl("Bitis Tarihi (gg/aa/yyyy): ");
            if (!bitis.HasValue) return;

            if (bitis <= baslangic)
            {
                Console.WriteLine("HATA: Bitis tarihi baslangic tarihinden sonra olmalidir!");
                return;
            }

            AracManager.MusaitAraclariGoster(baslangic.Value, bitis.Value);
        }

        private static void RezervasyonYap()
        {
            Console.WriteLine("\n=== YENI REZERVASYON ===");

            Console.Write("Musteri Adi Soyadi: ");
            string musteri = Console.ReadLine();

            Console.WriteLine("\n--- MEVCUT ARACLAR ---");
            var araclar = AracManager.Araclar;
            for (int i = 0; i < araclar.Count; i++)
            {
                var a = araclar[i];
                Console.WriteLine($"  [{i + 1}] {a.MarkaModel} ({a.Plaka}) - {a.GunlukFiyat} TL/gun");
            }
            Console.WriteLine("----------------------");

            Console.Write("Arac Secimi (1-" + araclar.Count + "): ");
            string secim = Console.ReadLine();

            if (!int.TryParse(secim, out int aracIndex) || aracIndex < 1 || aracIndex > araclar.Count)
            {
                Console.WriteLine("HATA: Gecersiz arac secimi!");
                return;
            }

            string plaka = araclar[aracIndex - 1].Plaka;

            bool saatlik = SaatlikMi();

            DateTime? baslangic;
            DateTime? bitis;

            if (saatlik)
            {
                baslangic = TarihSaatAl("Baslangic Tarih ve Saat (gg/aa/yyyy SS:dd): ");
                if (!baslangic.HasValue) return;

                bitis = TarihSaatAl("Bitis Tarih ve Saat (gg/aa/yyyy SS:dd): ");
                if (!bitis.HasValue) return;
            }
            else
            {
                baslangic = TarihAl("Baslangic Tarihi (gg/aa/yyyy): ");
                if (!baslangic.HasValue) return;

                bitis = TarihAl("Bitis Tarihi (gg/aa/yyyy): ");
                if (!bitis.HasValue) return;
            }

            RezervasyonManager.RezervasyonYap(musteri, plaka, baslangic.Value, bitis.Value, saatlik);
        }

        private static void RezervasyonIptalEt()
        {
            Console.WriteLine("\n=== REZERVASYON IPTAL ===");

            var rezervasyonlar = RezervasyonManager.Rezervasyonlar;
            if (rezervasyonlar.Count == 0)
            {
                Console.WriteLine("Iptal edilecek rezervasyon bulunmuyor.");
                return;
            }

            Console.WriteLine("\n--- MEVCUT REZERVASYONLAR ---");
            for (int i = 0; i < rezervasyonlar.Count; i++)
            {
                var r = rezervasyonlar[i];
                Console.WriteLine($"  [{i + 1}] {r.Musteri} - {r.Plaka} ({r.Baslangic:dd/MM/yyyy} - {r.Bitis:dd/MM/yyyy})");
            }
            Console.WriteLine("-----------------------------");

            Console.Write("Iptal edilecek rezervasyon (1-" + rezervasyonlar.Count + "): ");
            string secim = Console.ReadLine();

            if (!int.TryParse(secim, out int index) || index < 1 || index > rezervasyonlar.Count)
            {
                Console.WriteLine("HATA: Gecersiz secim!");
                return;
            }

            var silinecek = rezervasyonlar[index - 1];
            rezervasyonlar.RemoveAt(index - 1);
            DosyaManager.Kaydet();
            Console.WriteLine($"BASARILI: {silinecek.Musteri} - {silinecek.Plaka} rezervasyonu iptal edildi.");
        }

        private static void MusteriRezervasyonGoster()
        {
            Console.WriteLine("\n=== MUSTERI REZERVASYONLARI ===");
            Console.Write("Musteri Adi Soyadi: ");
            string musteri = Console.ReadLine();

            RezervasyonManager.MusteriRezervasyonlari(musteri);
        }

        private static void RezervasyonAra()
        {
            Console.WriteLine("\n=== REZERVASYON ARA ===");
            Console.Write("Arama terimi (musteri adi veya plaka): ");
            string arama = Console.ReadLine();

            RezervasyonManager.RezervasyonAraVeGoster(arama);
        }

        private static void ToplamGelirGoster()
        {
            double gelir = RezervasyonManager.ToplamGelir();
            Console.WriteLine("\n============================================");
            Console.WriteLine("           TOPLAM GELIR RAPORU              ");
            Console.WriteLine("============================================");
            Console.WriteLine($"  Toplam Gelir: {gelir} TL");
            Console.WriteLine($"  Rezervasyon Sayisi: {RezervasyonManager.Rezervasyonlar.Count}");
            Console.WriteLine("============================================");
        }

        private static void EnCokKiralananAracGoster()
        {
            Console.WriteLine("\n============================================");
            Console.WriteLine("         EN COK KIRALANAN ARAC              ");
            Console.WriteLine("============================================");
            Console.WriteLine($"  {RezervasyonManager.EnCokKiralananArac()}");
            Console.WriteLine("============================================");
        }

        private static void RaporOlustur()
        {
            RezervasyonManager.RaporYazdir();
            Console.WriteLine("\nBasarili: Rapor 'rapor.txt' dosyasina kaydedildi.");
        }

        private static void CikisYap()
        {
            DosyaManager.Kaydet();
            Console.WriteLine("\nVeriler kaydedildi. Sistemden cikiliyor...");
            Console.WriteLine("Arac Kiralama Sistemini kullandiginiz icin tesekkurler!");
        }

        private static DateTime? TarihAl(string mesaj)
        {
            while (true)
            {
                Console.Write(mesaj + "(Iptal icin 0): ");
                string girdi = Console.ReadLine();

                if (girdi == "0")
                {
                    return null;
                }

                if (DateTime.TryParse(girdi, out DateTime tarih))
                {
                    return tarih;
                }
                else
                {
                    Console.WriteLine("HATA: Gecersiz tarih formati! Lutfen tekrar deneyin. (Ornek: 25/12/2024)");
                }
            }
        }

        private static DateTime? TarihSaatAl(string mesaj)
        {
            string[] formatlar = new string[] {
                "dd/MM/yyyy HH:mm",
                "dd/MM/yyyy H:mm",
                "d/M/yyyy HH:mm",
                "d/M/yyyy H:mm"
            };

            while (true)
            {
                Console.Write(mesaj + "(Iptal icin 0): ");
                string girdi = Console.ReadLine();

                if (girdi == "0")
                {
                    return null;
                }

                if (DateTime.TryParseExact(girdi, formatlar, null, System.Globalization.DateTimeStyles.None, out DateTime tarih))
                {
                    return tarih;
                }
                else
                {
                    Console.WriteLine("HATA: Gecersiz tarih-saat formati! Lutfen tekrar deneyin. (Ornek: 25/12/2024 14:30)");
                }
            }
        }

        private static bool SaatlikMi()
        {
            while (true)
            {
                Console.Write("Saatlik kiralama mi? (E/H): ");
                string girdi = Console.ReadLine()?.ToUpper();

                if (girdi == "E")
                {
                    return true;
                }
                else if (girdi == "H")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("HATA: Lutfen sadece E veya H girin!");
                }
            }
        }

        private static void RezervasyonDuzenle()
        {
            Console.WriteLine("\n=== REZERVASYON DUZENLE ===");

            var rezervasyonlar = RezervasyonManager.Rezervasyonlar;
            if (rezervasyonlar.Count == 0)
            {
                Console.WriteLine("Duzenlenecek rezervasyon bulunmuyor.");
                return;
            }

            Console.WriteLine("\n--- MEVCUT REZERVASYONLAR ---");
            for (int i = 0; i < rezervasyonlar.Count; i++)
            {
                var r = rezervasyonlar[i];
                string tip = r.Saatlik ? "Saatlik" : "Gunluk";
                Console.WriteLine($"  [{i + 1}] {r.Musteri} - {r.Plaka} ({r.Baslangic:dd/MM/yyyy HH:mm} - {r.Bitis:dd/MM/yyyy HH:mm}) - {tip} - {r.Ucret} TL");
            }
            Console.WriteLine("-----------------------------");

            int index;
            while (true)
            {
                Console.Write("Duzenlenecek rezervasyon (1-" + rezervasyonlar.Count + ", Iptal icin 0): ");
                string secim = Console.ReadLine();

                if (secim == "0")
                {
                    return;
                }

                if (int.TryParse(secim, out index) && index >= 1 && index <= rezervasyonlar.Count)
                {
                    break;
                }
                Console.WriteLine("HATA: Gecersiz secim! Lutfen tekrar deneyin.");
            }

            var duzenlenecek = rezervasyonlar[index - 1];

            Console.WriteLine($"\nSecilen: {duzenlenecek.Musteri} - {duzenlenecek.Plaka}");
            Console.WriteLine("Neleri duzenlemek istiyorsunuz?");
            Console.WriteLine("  [1] Musteri Adi");
            Console.WriteLine("  [2] Tarihler");
            Console.WriteLine("  [0] Iptal");

            while (true)
            {
                Console.Write("Seciminiz: ");
                string duzenlemeSecim = Console.ReadLine();

                switch (duzenlemeSecim)
                {
                    case "1":
                        Console.Write("Yeni Musteri Adi: ");
                        string yeniMusteri = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(yeniMusteri))
                        {
                            duzenlenecek.Musteri = yeniMusteri;
                            DosyaManager.Kaydet();
                            Console.WriteLine("BASARILI: Musteri adi guncellendi.");
                        }
                        else
                        {
                            Console.WriteLine("HATA: Musteri adi bos olamaz!");
                        }
                        return;

                    case "2":
                        bool saatlik = SaatlikMi();
                        DateTime? yeniBaslangic;
                        DateTime? yeniBitis;

                        if (saatlik)
                        {
                            yeniBaslangic = TarihSaatAl("Yeni Baslangic Tarih ve Saat (gg/aa/yyyy SS:dd): ");
                            if (!yeniBaslangic.HasValue) return;

                            yeniBitis = TarihSaatAl("Yeni Bitis Tarih ve Saat (gg/aa/yyyy SS:dd): ");
                            if (!yeniBitis.HasValue) return;
                        }
                        else
                        {
                            yeniBaslangic = TarihAl("Yeni Baslangic Tarihi (gg/aa/yyyy): ");
                            if (!yeniBaslangic.HasValue) return;

                            yeniBitis = TarihAl("Yeni Bitis Tarihi (gg/aa/yyyy): ");
                            if (!yeniBitis.HasValue) return;
                        }

                        if (yeniBitis <= yeniBaslangic)
                        {
                            Console.WriteLine("HATA: Bitis tarihi baslangic tarihinden sonra olmalidir!");
                            return;
                        }

                        duzenlenecek.Baslangic = yeniBaslangic.Value;
                        duzenlenecek.Bitis = yeniBitis.Value;
                        duzenlenecek.Saatlik = saatlik;
                        duzenlenecek.Ucret = RezervasyonManager.RezervasyonUcretiHesapla(duzenlenecek.Plaka, yeniBaslangic.Value, yeniBitis.Value, saatlik);
                        DosyaManager.Kaydet();
                        Console.WriteLine($"BASARILI: Tarihler guncellendi. Yeni ucret: {duzenlenecek.Ucret} TL");
                        return;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("HATA: Gecersiz secim! Lutfen 0, 1 veya 2 girin.");
                        break;
                }
            }
        }
    }
}