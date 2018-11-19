using System;

namespace _2D
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("N: ");
			int n = int.Parse(Console.ReadLine());
			Console.Write("M: ");
			int m = int.Parse(Console.ReadLine());
			int[, ] _2d = new int[n, m];
			int max = _2d[0, 0];

			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					Console.Write($"arr[{i}][{j}]: ");
					_2d[i, j] = int.Parse(Console.ReadLine());
					if (_2d[i, j] > max)
					{
						max = _2d[i, j];
					}
				}
			}

			Console.WriteLine($"Max: {max}");

			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					Console.Write(_2d[i, j] + " ");
				}

				Console.WriteLine();
			}
		}
	}
}