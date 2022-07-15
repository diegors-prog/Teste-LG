// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int[] array1 = { 2, 5, 8, 10, 2, 23, 2, 4, 5, 8, 8 };

int[] arraySemRepeticao = array1.Distinct().ToArray();

foreach(var item in arraySemRepeticao)
{
    Console.WriteLine(item);
}