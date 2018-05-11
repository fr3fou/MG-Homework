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
            int a = int.Parse(Console.ReadLine());
            int counter = 0;
            while (a != 0)
            {
                a = int.Parse(Console.ReadLine());
                if (a < 0)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
