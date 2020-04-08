using System;

namespace det
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new Matrix(3,3, new double[,] 
                    {
                    {1,2,3},
                    {4,5,6},
                    {7,8,9}
                    });
            Console.WriteLine(m.Det());
        }
    }

    class Matrix 
    {
        int Rows;
        int Cols;

        public double[,] Data;

        public Matrix(int rows, int cols, double [,] data)
        {
            Rows = rows;
            Cols = cols;
            Data = data; 
        }

        public Matrix Chop(double n) // премахва 1-ви ред и n-та колона
        {

            if (n >= this.Cols || n < 0) 
                throw new Exception("chop n outside of bounds");

            var v = new Matrix(this.Rows-1, this.Cols-1, new double[this.Rows, this.Cols]);

            for (int i = 1; i < this.Rows; i++)
            {
                int innerIndex = 0;
                for (int j = 0; j < this.Cols; j++)
                {
                    v.Data[i-1,innerIndex] = this.Data[i,j];
                    if (j != n) 
                        innerIndex++;
                }
            }
            return v;
        }

        public double Det() 
        {
            if (this.Rows == 1 && this.Cols == 1) 
            {
                return this.Data[0,0];
            }

            double det = 0;
            for (int i = 0; i < this.Cols; i++)
            {
                det += Math.Pow(-1, i) * this.Data[0,i] * this.Chop(i).Det();
            }

            return det;
        }

        public void Print() 
        {
            for (int i = 0; i < this.Rows; i++) 
            {
                for (int j = 0; j < this.Cols; j++) 
                {
                    Console.Write(this.Data[i, j] + "\t");
                }
                Console.WriteLine();
            } 
        }
    }
}
