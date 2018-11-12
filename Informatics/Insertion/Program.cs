using System;
using System.Linq;

namespace Insertion
{
    class Program
    {
        static void Main(string[] args)
        {
            // size of arr
            int n = int.Parse(Console.ReadLine());

            // make new array with size to fit the inserted number
            int[] arr = new int[n+1];

            // fill the array
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            // number to be inserted
            int toAdd = int.Parse(Console.ReadLine());

            // add as last element
            arr[n] = toAdd;

            // insert
            for (int i = n; i >= 1; i--)
            {
                // compare the current num and the previous num
                int num = arr[i];
                int prevNum = arr[i-1];
                
                // and swap them if the prev num is greater
                if(num < prevNum) 
                {
                    arr[i] = prevNum;
                    arr[i-1] = num;
                }
            }

            // print entire arr
            Console.WriteLine(String.Join(' ', arr));
        }
    }
}
