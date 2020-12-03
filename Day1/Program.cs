using System;
using System.IO;
using System.Threading.Tasks;

namespace Day1
{
	class Program
	{
		static void Main()
		{
			var numbers = Array.ConvertAll(File.ReadAllLines("day1.txt"), int.Parse);

			Parallel.For(0, numbers.Length, i =>
			{
				int number1 = numbers[i];
				for (int j = i + 1; j < numbers.Length; j++)
				{
					int number2 = numbers[j];
					if (number1 + number2 == 2020)
					{
						Console.WriteLine(number1 * number2);
					}

					for (int k = j + 1; k < numbers.Length; k++)
					{
						int number3 = numbers[k];
						if (number1 + number2 + number3 == 2020)
						{
							Console.WriteLine(number1 * number2 * number3);
							return;
						}
					}
				}
			});
		}
	}
}
