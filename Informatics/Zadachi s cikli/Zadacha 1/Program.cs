using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int sum = 0;
            while (sum < k)
            {
                sum += int.Parse(Console.ReadLine());
            }
            Console.WriteLine("end");
        }
    }
}
