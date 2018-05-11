using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zadacha_4
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 1;
            List<double> numbers = new List<double>();
            while (a != 0)
            {
                a = double.Parse(Console.ReadLine());
                numbers.Add(a);
            }
            Console.WriteLine(numbers.Where(x => x % 2 == 0).ToArray().Aggregate((num, x) => num + x));
            Console.WriteLine(numbers.Where(x => x % 2 != 0).ToArray().Aggregate((num, x) => num * x));
        }
    }
}
