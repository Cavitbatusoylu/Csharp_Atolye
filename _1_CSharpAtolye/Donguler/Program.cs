Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");

// For Döngüsü
for (int i = 0; i < 10; i++)
{
    Console.WriteLine("Hello, World!");
}

// While Döngüsü
int counter = 0;
while (counter < 5)
{
    Console.WriteLine("C# Atölye");
    counter++;
}

// Do-While Döngüsü
int counter2 = 0;
do
{
    Console.WriteLine("C# Atölye Do-While");
    counter2++;
} while (counter2 < 3);

// Foreach Döngüsü
string str = "Döngüler";
foreach (char character in str)
{
    Console.WriteLine(character);
}

// İç İçe Döngüler
for (int i = 0; i <= 10; i++)
{
    for (int j = 0; j <= 10; j++)
    {
        Console.WriteLine($"{i} x {j} = {i * j}");
    }
    Console.WriteLine();
}

// Break ve Continue Kullanımı
for (int i = 0; i < 10; i++)
{
    if (i == 3)
    {
        break; // Döngüyü sonlandırır
    }
    Console.WriteLine(i);
}

for (int i = 0; i < 10; i++)
{
    if (i == 3)
    {
        continue; // O anki iterasyonu atlar
    }
    Console.WriteLine(i);
}

// Asal Sayı Bulma
Console.WriteLine("Bir asal sayı girin:");
int number = Convert.ToInt32(Console.ReadLine());

while (true)
{
    if (number == 0)
    {
        break;
    }
    bool isPrime = true;

    for (int i = 2; i < number; i++)
    {
        if (number % i == 0)
        {
            isPrime = false;
            Console.WriteLine("Asal sayı değildir.");
            break;
        }
        else
        {
            isPrime = true;
            Console.WriteLine("Asal sayıdır.");
        }
    }
}

// Diziler ve Koleksiyonlar
int[] ints = { 1, 2, 3, 4, 5 };
string[] strings = { "C#", "Java", "Python" };
foreach (var item in ints)
{
    Console.WriteLine(item);
}
foreach (var item in strings)
{
    Console.WriteLine(item);
}