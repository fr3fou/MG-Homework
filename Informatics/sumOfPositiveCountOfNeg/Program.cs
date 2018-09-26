using System;

namespace sumOfPositiveCountOfNeg
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int evenAmount = 0;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num > 0)
                {
                    sum += num;
                }

                if (num % 2 == 0)
                {
                    evenAmount++;
                }
            }

            Console.WriteLine(sum);
            Console.WriteLine(evenAmount);
        }
    }
}
