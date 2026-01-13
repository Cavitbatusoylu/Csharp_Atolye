// Metotlar
/*
 * Metotlar
 * Değer döndüren metotlar
 * Değer döndürmeyen metotlar
 * Parametreli metotlar
 * Parametresiz metotlar
 * ref, out, params parametreler
 */

#region VoidFonksiyonlar

//Selamla();
//ToplaVeYazdir(4, 6);
//static void Selamla()
//{
//    Console.WriteLine("Merhaba!");
//}

//static void ToplaVeYazdir(int a, int b)
//{
//    var sonuc = a + b;
//    Console.WriteLine("Toplam: " + sonuc);
//}
#endregion

#region Değer Döndüren Metotlar
/*
 return ifadesi
  - Metot çalışmasını sonlandırır.
    - Metot çağrıldığı yere değer döndürür.
//*/

//Console.WriteLine("Toplam: " + Topla(3, 5));
//Fonksiyon();

//static void Fonksiyon()
//{
//    var kullaniciGirdisi = Console.ReadLine();
//    if(kullaniciGirdisi is "q")
//    {
//        Console.WriteLine("İf bloğu çalıştı fonksiyon bitti...");
//        return;
//    }
//    Console.WriteLine("İf bloğu çalışmadı...");
//}

//static int Topla(int a, int b)
//{
//    return a + b;
//}
#endregion

//int sayi = 10;
//degerDegistir(sayi);
//Console.WriteLine("Sayi değeri: " + sayi);
//referansDegistir(sayi);
//Console.WriteLine("Sayi değeri: " + sayi);

//static void degerDegistir(int deger)
//{
//    deger = 20;
//}

//// ref parametre örneği
//static void referansDegistir(ref int deger)
//{
//    deger = 30;
//}

//out parametre örneği
//float yariCap = 5;
//float cevre, alan;

//float donenAlan = cemberAlanCevreHesapla(yariCap, out cevre, out alan);

//Console.WriteLine("Çemberin Alanı (out): " + alan);
//Console.WriteLine("Çemberin Çevresi: " + cevre);
//Console.WriteLine("Dönen Alan (return): " + donenAlan);
//Console.WriteLine("Yarıçap: " + yariCap);

//static float cemberAlanCevreHesapla(float yariCap, out float cevre, out float alan)
//{
//    cevre = 2 * 3.14f * yariCap;
//    alan = 3.14f * yariCap * yariCap;
//    return alan; // return ile yine alan döndürülür
//}

//var seritoplam = ToplaSei(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
//Console.WriteLine("Sayıların Toplamı: " + seritoplam);

//static int ToplaSei(params int[] sayilar)
//{
//    int toplam = 0;
//    foreach (var sayi in sayilar)
//    {
//        toplam += sayi;
//    }
//    return toplam;
//}

//static int Fakto(int sayi)
//{
//    if(sayi == 0||sayi == 1)
//    {
//        return 1;
//    }
//    return sayi * Fakto(sayi - 1);
//}

// Palindrom Kelime Kontrolü
//string str = "radar";

//if (isPalindrom(str))
//{
//    Console.WriteLine($"{str} bir palindrom kelimedir.");
//}
//else
//{
//    Console.WriteLine($"{str} bir palindrom kelime değildir.");
//}

//static bool isPalindrom(string str)
//{
//    int head = 0;
//    int tail = str.Length - 1;
//    while (head < tail)
//    {
//        if (str[head] != str[tail])
//        {
//            return false;
//        }
//    } 
//}



//var sonuc = Topla(3, 5);
//Console.WriteLine("Toplam" + sonuc);
//var sonuc1 = Topla(10, 15);
//Console.WriteLine("Toplam" + sonuc1);

//int Topla(int a, int b)
//{
//    return a + b;
//}

//public class Program
//{
//    static void Main(string[] args)
//    {
//       Program program = new();
//        var sonuc = program.Topla(3, 5);
//        Console.WriteLine("Toplam: " + sonuc);
//    }
//}

/*
erişim belirleyici  DönüşTipi MetotAdı (ParametreListesi)
{
    // Metot gövdesi
}
 */

