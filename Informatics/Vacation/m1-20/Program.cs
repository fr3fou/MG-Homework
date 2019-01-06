using System;

namespace m1_20
{
    class Program
    {
        static void Main(string[] args)
        {
            // get the arrays' sizes
            int n = int.Parse(Console.ReadLine());
            double mul = 1;
            
            // declare both array
            double[] arr1 = new double[n];
            double[] arr2 = new double[n];

            // fill the 1st array
            for (int i = 0; i < n; i++)
            {
                arr1[i] = double.Parse(Console.ReadLine());
            }

            // fill the 2nd array
            for (int i = 0; i < n; i++)
            {
                arr2[i] = double.Parse(Console.ReadLine());
            }

            // calculate mul of GCD
            for (int i = 0; i < n; i++)
            {
                mul *= GCD(arr1[i], arr2[i]);
            }

            Console.WriteLine(mul);
        }

        // calculate GCD
        private static double GCD(double a, double b) => (b == 0) ? a : GCD(b, a % b);
    }
}
