using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace linearEquation
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine(linearEquation(a,b));
        }
        public static string linearEquation(double a, double b)
        {
            if (a == 0)
            {
                if (b == 0)
                {
                    return "Every Number is an answer";
                }
                else
                {
                    return "There is no answer";
                }
            }
            else
            {
                try
                {
                    return (-b / a).ToString();
                }
                catch
                {
                    return "ERROR";
                }
            }
        }
        
    }
}
