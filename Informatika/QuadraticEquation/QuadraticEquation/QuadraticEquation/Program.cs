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
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = b * b - 4 * a * c;
            if (d>0)
            {
                Console.WriteLine("x1 = {0} \n x2 = {1}", (-b+Math.Sqrt(d))/2*a, (-b-Math.Sqrt(d))/2*a);
            }
            else if (d==0)
            {
                Console.WriteLine("x1,2 = {0}", -(b/(2*a)));
            }
            else
            {
                Console.WriteLine("Nqma realni koreni");
            }
        }
    }
}
