using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter amount of numbers generated: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter min number");
            int min = int.Parse(Console.ReadLine());
            Console.Write("Enter max number");
            int max = int.Parse(Console.ReadLine());
            if (min>max)
            {
                int temp;
                temp = min;
                min = max;
                max = min;
            }
            Random rndm = new Random(); 
            int i = 0;
            while (i < n)
            {
                Console.WriteLine(rndm.Next(min,max));
                i++;
            }
        }
    }
}
