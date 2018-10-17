using System;
using System.Globalization;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int evenIndex = 0;
            int evenValue = 0;
            int negIndex = 0;
            int negValue = 0;
            bool hasFoundNeg = false;
            for (int i = 0; i < n; i++)
            {
                int val = int.Parse(Console.ReadLine());
                if (val % 2 == 0)
                {
                    evenIndex = i;
                    evenValue = val;
                }

                if (val < 0 && !hasFoundNeg)
                {
                    negIndex = i;
                    negValue = val;
                    hasFoundNeg = true;
                }
            }

            Console.WriteLine("Index of neg: " + negIndex);
            Console.WriteLine("Value of neg: " + negValue);
            Console.WriteLine("Index of even: " + evenIndex);
            Console.WriteLine("Value of even: " + evenValue);
        }
    }
}