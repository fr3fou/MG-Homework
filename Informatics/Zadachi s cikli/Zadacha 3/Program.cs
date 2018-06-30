using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zadacha_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> results = new List<string>();
            while (input != "0 0 0")
            {
                double[] numbers = input
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => double.Parse(x))
                    .ToArray();
                if (numbers.Sum() % 3 == 0)
                {
                    results.Add("YES");
                }
                else
                {
                    results.Add("NO");
                }   
                input = Console.ReadLine();
            }
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
