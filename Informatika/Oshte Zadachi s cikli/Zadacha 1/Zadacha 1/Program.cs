using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zadacha_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int maxNeg = int.MinValue;
            while (a != 0)
            {
                if (a < 0 && a > maxNeg)
                {
                    maxNeg = a;
                }
                a = int.Parse(Console.ReadLine());
            }
            if (maxNeg == int.MinValue)
            {
                Console.WriteLine("0");
            }
            else
            {
            Console.WriteLine(maxNeg);
            }
        }
    }
}
