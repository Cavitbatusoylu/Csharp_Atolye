using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");
Console.Write("Welcome to C# 14.0 features demonstration");
Console.WriteLine("Lest 's explore new features!");

//Deişken tanımlama ve atama
int number = 40;
string message = "C# 14.0 is awesome!";
double pi = 3.14159;
bool isLearning = true;

var val = 100;
var text = "Learning C# 14.0";

Console.WriteLine($"Number: {number},\nMessage: {message},\nPi: {pi},\nIs Learning: {isLearning}, \n " +
    $"Var Number: {val}, \nText :{text}");
Console.WriteLine(number.GetType());
Console.WriteLine(message.GetType());


// Tip Dönüşümü
int intNumber = 100;
double doubleNumber = intNumber; // Implicit conversion from int to double
Console.WriteLine($"Converted int to double: {doubleNumber}");
Console.WriteLine(doubleNumber.GetType());

double value = 92.555;
int valInt = Convert.ToInt32(value); // Explicit conversion from double to int
Console.WriteLine($"Converted double to int: {valInt}");

//Operatörler
/*
 + => Toplama
 - => Çıkarma
 * => Çarpma
 /  => Bölme
 % => Mod Alma
*/

int a = 17;
int b = 5;
Console.WriteLine($"Toplama: {a} + {b} = {a + b}");
Console.WriteLine($"Çıkarma: {a} - {b} = {a - b}");
Console.WriteLine($"Çarpma: {a} * {b} = {a * b}");
Console.WriteLine($"Bölme: {a} / {b} = {a / b}");
Console.WriteLine($"Mod Alma: {a} % {b} = {a % b}");

// Atama Operatörleri
int x = 10;
x += 5; // x = x + 5
Console.WriteLine(x);
x -= 3; // x = x - 3
Console.WriteLine(x);
x *= 2; // x = x * 2
Console.WriteLine(x);
x /= 4; // x = x / 4
Console.WriteLine(x);
x %= 3; // x = x % 3
Console.WriteLine(x);

// Karşılaştırma Operatörleri
/*
 == => Eşit mi
 != => Eşit değil mi
 >  => Büyük mü
 <  => Küçük mü
 >= => Büyük eşit mi
 <= => Küçük eşit mi
*/

int val1 = 25;
int val2 = 30;
Console.WriteLine("======Karşılaştırma Operatörler======");
Console.WriteLine($"Eşit mi: {val1} == {val2} :{val1 == val2}");
Console.WriteLine($"Eşit değil mi: {val1} != {val2} :{val1 != val2}");
Console.WriteLine($"Büyük mü: {val1} > {val2} :{val1 > val2}");
Console.WriteLine($"Küçük mü: {val1} < {val2} :{val1 < val2}");
Console.WriteLine($"Büyük eşit mi: {val1} >= {val2} :{val1 >= val2}");
Console.WriteLine($"Küçük eşit mi: {val1} <= {val2} :{val1 <= val2}");

// Mantıksal Operatörler
/*
 and operatörü: && => Ve
 or operatörü: || => Veya
*/

bool condition1 = true;
bool condition2 = false;
Console.WriteLine("======Mantıksal Operatörler======");
Console.WriteLine($"Ve (AND) Operatörü: {condition1} && {condition2} : {condition1 && condition2}");
Console.WriteLine($"Veya (OR) Operatörü: {condition1} || {condition2} : {condition1 || condition2}");

// Kulllanıcıdan veri alma
Console.WriteLine("Lütfen bir sayı giriniz:");
var str = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"Girdiğiniz metnin tipi: {str.GetType()}");