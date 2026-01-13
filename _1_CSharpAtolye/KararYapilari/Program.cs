/*
 Karar Yapıları (Conditional Statements) programlamada belirli koşullara bağlı olarak farklı kod bloklarının çalıştırılmasını sağlar. 
*/

int sayi = 10;

{
    int scopeVal = 20;
}
// Console.WriteLine(scopeVal) => hata verir çünkü scopeVal değişkeni sadece yukarıdaki blok içinde geçerlidir.
Console.WriteLine(sayi);

Console.WriteLine("======If-Else Yapısı======");
int age = 18;
if (age >= 18)
{
    Console.WriteLine("You are an adult.");
}
else
{
    Console.WriteLine("You are a minor.");
}

Console.WriteLine("Program bitti...");

Console.WriteLine("======Not Değerlendirme======");

int not = 85;
if (not >= 90)
{
    Console.WriteLine("A");
}
else if (not >= 80)
{
    Console.WriteLine("B");
}
else if (not >= 70)
{
    Console.WriteLine("C");
}
else if (not >= 60)
{
    Console.WriteLine("D");
}
else
{
    Console.WriteLine("F");
}

/*
if (not >= 90)
{
    Console.WriteLine("A");
}
if (not >= 80)
{
    Console.WriteLine("B");
    return;
}
if (not >= 70)
{
    Console.WriteLine("C");
    return;
}
if (not >= 60)
{
    Console.WriteLine("D");
    return;
}
if
{
    Console.WriteLine("F");
    return;    
}
 */

Console.WriteLine("Program bitti...");

// Switch-Case Yapısı
int gun = 3;

switch(gun)
{
    case 1:
        Console.WriteLine("Pazartesi");
        break;
    case 2:
        Console.WriteLine("Salı");
        break;
    case 3:
        Console.WriteLine("Çarşamba");
        break;
    case 4:
        Console.WriteLine("Perşembe");
        break;
    case 5:
        Console.WriteLine("Cuma");
        break;
    case 6:
        Console.WriteLine("Cumartesi");
        break;
    case 7:
        Console.WriteLine("Pazar");
        break;
    default:
        Console.WriteLine("Geçersiz gün numarası.");
        break;
}