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
            int k = int.Parse(Console.ReadLine());
            int a;
            int max = int.MinValue;
            int n = 1;
            while (n <= k)
            {
                a = int.Parse(Console.ReadLine());
                if (a >= max && a % 5 == 0)
                {
                    max = a;   
                }
                n++;
            }
            Console.WriteLine(max);
        }
    }
}
