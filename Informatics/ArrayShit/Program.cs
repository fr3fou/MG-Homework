using System;

namespace ArrayShit
{
    class Program
    {
        static void Main(string[] args)
        {
           int n = int.Parse(Console.ReadLine());
           double[] uspeh = new double[n]; 

           // input
           for (int i = 0; i < n; i++)
           {
               uspeh[i] = double.Parse(Console.ReadLine());
           }

           // sort
           InsertionSort(uspeh);

           // print
           Console.WriteLine("Top 3");
           Console.WriteLine(uspeh[n-1]);
           Console.WriteLine(uspeh[n-2]);
           Console.WriteLine(uspeh[n-3]);
        }

        public static void InsertionSort(double[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
               double num = arr[i];
               int j = i - 1; 

               while (j >= 0 && num < arr[j])
               {
                    arr[j + 1] = arr[j];
                    arr[j] = num;
                    j--;
               }
            }
        }
    }
}
