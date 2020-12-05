using System;
using System.IO;
using System.Linq;

namespace Day5
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = File.ReadAllLines("Day5.txt");

			int lowest = int.MaxValue;
			int highest = 0;
			int sum = 0;
			for (int i = 0; i < input.Length; i++)
			{
				string seat = input[i];
				int id = 0;
				for (int j = 0; j < seat.Length; j++)
				{
					if (seat[j] == 'B' || seat[j] == 'R')
					{
						id |= 1 << (9 - j);
					}
				}

				sum += id;

				if (id > highest)
				{
					highest = id;
				}
				else if (id < lowest)
				{
					lowest = id;
				}
			}

			// Part 1
			Console.WriteLine($"Highest seat ID: {highest}");

			// Part 2
			int n = input.Length;
			int mySeat = ((n + 1) * (n + (2 * lowest)) / 2) - sum;
			Console.WriteLine($"My seat: {mySeat}");
		}
	}
}
