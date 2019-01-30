using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spiral
{
    class Program
    {
        static void Main(string[] args)
        {
            // размер на двуизмерен масив
            Console.WriteLine("Razmer na 2D masiv: ");
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            // декларация на двуизмерен масив
            int[,] spiral = new int[n, m];

            // попълване на двуизмерен масив
            Console.WriteLine("Stoinosti na 2D masiv: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    spiral[i,j] = int.Parse(Console.ReadLine());
                }
            }

            // принтиране на двуизмерен масив
            PrintSpiral(spiral, n, m);
        }

        public static void PrintSpiral(int[,] spiral, int n, int m) 
        {
            // държим резултат тук
            string result = "";

            // сума и най-малка стойност
            int sum = 0;
            int min = int.MaxValue;

            // начални позиции
            // за n = 5, m = 5
            //                            v горната страна е 0
            //                      1, 2, 3, 5, 9,
            //                      6, 9, 7, 1, 3,
            // лявата страна е 0 >> 4, 5, 2, 5, 9, << дясната страна е 4
            //                      7, 8, 9, 3, 7,
            //                      3, 9, 5, 5, 3
            //                            ^ долната страна е 4
            int left = 0;
            int right = n - 1;
            int top = 0;
            int bottom = m - 1;

            // повтаряме докато не стигнем общия размер на масива (умножаваме по 2, заради space-овете, които добаваяме в резултата)
            while(result.Length < (n * m * 2))
            {

            // добавяне на текущите стойности от "горната страна"
            //  тези >> 1, 2, 3, 5, 9, 
            //          6, 9, 7, 1, 3,
            //          4, 5, 2, 5, 9,
            //          7, 8, 9, 3, 7,
            //          3, 9, 5, 5, 3
            //
                for (int i = left; i <= right; i++)
                {
                    int num = spiral[top, i];

                    // търсене на най-малката стойност
                    if(num < min) 
                    {
                        min = num;
                    }

                    result += num + " ";

                    // събиране на сумата
                    sum += num;
                }
                
                // преместване на горната страна с един индекс "надолу"
                //                    1, 2, 3, 5, 9, 
                //  горната страна >> 6, 9, 7, 1, 3,
                //                    4, 5, 2, 5, 9,
                //                    7, 8, 9, 3, 7,
                //                    3, 9, 5, 5, 3
                top++;

                // добавяне на текущите стойности от "дясната страна"
                //                          V тези
                //              1, 2, 3, 5, 9, 
                //              6, 9, 7, 1, 3,
                //              4, 5, 2, 5, 9,
                //              7, 8, 9, 3, 7,
                //              3, 9, 5, 5, 3
                //
                for (int i = top; i <= bottom; i++)
                {
                    int num = spiral[i, right];

                    // търсене на най-малката стойност
                    if(num < min) 
                    {
                        min = num;
                    }

                    result += num + " ";

                    // събиране на сумата
                    sum += num;
                }

                // преместване на дясната страна с един индекс "наляво"
                //                     V дясната страна
                //            1, 2, 3, 5, 9, 
                //            6, 9, 7, 1, 3,
                //            4, 5, 2, 5, 9,
                //            7, 8, 9, 3, 7,
                //            3, 9, 5, 5, 3
                right--;

                // добавяне на текущите стойности от "долната страна"
                //            1, 2, 3, 5, 9, 
                //            6, 9, 7, 1, 3,
                //            4, 5, 2, 5, 9,
                //            7, 8, 9, 3, 7,
                //   тези >>  3, 9, 5, 5, 3
                //
                for (int i = right; i >= left; i--)
                {
                    int num = spiral[bottom, i];

                    // търсене на най-малката стойност
                    if(num < min) 
                    {
                        min = num;
                    }

                    result += num + " ";

                    // събиране на сумата
                    sum += num;
                }

                // преместване на долната страна с един индекс "нагоре"
                //                    1, 2, 3, 5, 9, 
                //                    6, 9, 7, 1, 3,
                //                    4, 5, 2, 5, 9,
                //  долната страна >> 7, 8, 9, 3, 7,
                //                    3, 9, 5, 5, 3
                bottom--;

                // ПРЕДОТВРАТЯВАНЕ НА ПОВТОРЕНИЯ
                if (right < left) 
                {
                    break;
                }

                // добавяне на текущите стойности от "лявата страна"
                //       тези V 
                //            1, 2, 3, 5, 9, 
                //            6, 9, 7, 1, 3,
                //            4, 5, 2, 5, 9,
                //            7, 8, 9, 3, 7,
                //            3, 9, 5, 5, 3
                //
                for (int i = bottom; i >= top; i--)
                {
                    int num = spiral[i, left];

                    // търсене на най-малката стойност
                    if(num < min) 
                    {
                        min = num;
                    }

                    result += num + " ";

                    // събиране на сумата
                    sum += num;
                }
                // преместване на лявата страна с един индекс "наляво"
                // лявата страна V
                //            1, 2, 3, 5, 9, 
                //            6, 9, 7, 1, 3,
                //            4, 5, 2, 5, 9,
                //            7, 8, 9, 3, 7,
                //            3, 9, 5, 5, 3
                left++;
            }

            Console.WriteLine("Spiral: {0}", result);
            Console.WriteLine("Sum: {0}", sum);
            Console.WriteLine("Min: {0}", min);

        }
    }
}
