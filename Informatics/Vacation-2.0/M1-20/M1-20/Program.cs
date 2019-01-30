using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M1_20
{
    class Program
    {
       static void Main(string[] args)
        {
            // размер на масив5
            Console.Write("Razmer na masivi: ");
            int n = int.Parse(Console.ReadLine()); 

            // начална стойност на произведението
            double mul = 1;
            
            // декларация на двата масива
            double[] arr1 = new double[n];
            double[] arr2 = new double[n];

            // попълване на първия масив 
            Console.WriteLine("Purvi masiv: ");
            for (int i = 0; i < n; i++)
            {
                arr1[i] = double.Parse(Console.ReadLine());
            }

            // попълване на втория масив 
            Console.WriteLine("Vtori masiv: ");
            for (int i = 0; i < n; i++)
            {
                arr2[i] = double.Parse(Console.ReadLine());
            }

            // преминаване на масива и умножаване на всички НОД
            for (int i = 0; i < n; i++)
            {
                // калкулиране на НОД от числата в двата масива
                mul *= GCD(arr1[i], arr2[i]);
            }

            // принтиране на произведението
            Console.Write("Rezultat: ");
            Console.WriteLine(mul);
        }

       // пресмятане на НОД на две числа чрез рекурсия (алгоритъм на Евклид)
       private static double GCD(double a, double b) 
       { 
           return (b == 0) ? a : GCD(b, a % b);
       } 
    }
}
