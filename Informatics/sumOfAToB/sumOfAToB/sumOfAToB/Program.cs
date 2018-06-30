using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sumOfAToB
{
    class Program
    {
        static void Main(string[] args)
        {            
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());           
            Console.WriteLine(sumOfAToB(a,b));
        }
        static int sumOfAToB(int a, int b)
        {
            int sum = 0;
            if (a > b)
            {
                int temp = a;
                a = b;
                b = temp;
            }
            int i = a;
            while (i <= b)
            {
                sum += i;
                i++;
            }
            return sum;
        }
    }
}
