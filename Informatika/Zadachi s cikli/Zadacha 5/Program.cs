using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zadacha_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int negCounter = 0;
            List<double> numbers = new List<double>();
            while (negCounter < 2)
            {
                double a = double.Parse(Console.ReadLine());
                numbers.Add(a);
                if (a < 0)
                {
                    negCounter++;
                }
            }
            Console.WriteLine(numbers.Where(x => x % 5==0).ToArray().Count()-1);
        }
    }
}
