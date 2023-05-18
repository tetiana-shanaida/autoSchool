// See https://aka.ms/new-console-template for more information
using System.Formats.Asn1;
namespace Homework_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double s = a * b;
            double p = 2 * (a + b);

            Console.WriteLine($"Area = {s}");
            Console.WriteLine($"Perimeter = {p}");
        }
    }
    
}

