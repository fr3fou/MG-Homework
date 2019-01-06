using System;

namespace Spiral
{
    class Program
    {
        static void Main(string[] args)
        {
            // Size of 2D array
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            // Declaration of 2D array
            int[,] spiral = new int[n, m];

            // fill in the spiral
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    spiral[i,j] = int.Parse(Console.ReadLine());
                }
            }


            PrintSpiral(spiral, n, m);
        }

        public static void PrintSpiral(int[,] spiral, int n, int m) 
        {
            // keep result here
            string result = "";
            int sum = 0;
            int min = int.MaxValue;


            // starting positions
            int left = 0;
            int right = n - 1;
            int top = 0;
            int bottom = m - 1;

            // repeat until total area
            while(result.Length < n * m)
            {
                // add all the values at the current "top"
                for (int i = left; i <= right; i++)
                {
                    int num = spiral[top, i];

                    if(num < min) 
                    {
                        min = num;
                    }

                    result += num + " ";
                    sum += num;
                }
                top++;

                // add all the values at the current "right"
                for (int i = top; i <= bottom; i++)
                {
                    int num = spiral[i, right];

                    if(num < min) 
                    {
                        min = num;
                    }

                    result += num + " ";
                    sum += num;
                }
                right--;

                // add all the values at the current "bottom"
                for (int i = right; i >= left; i--)
                {
                    int num = spiral[bottom, i];

                    if(num < min) 
                    {
                        min = num;
                    }

                    result += num + " ";
                    sum += num;
                }
                bottom--;

                // prevent repeating
                if (right < left) 
                {
                    break;
                }

                // add all the values at the current "left"
                for (int i = bottom; i >= top; i--)
                {
                    int num = spiral[i, left];

                    if(num < min) 
                    {
                        min = num;
                    }

                    result += num + " ";
                    sum += num;
                }
                left++;
            }

        Console.WriteLine($"Spiral: {result}");
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Min: {min}");

        }
    }
}
