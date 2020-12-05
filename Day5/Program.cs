using System;
using System.IO;

namespace Day5
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = File.ReadAllLines("Day5.txt");

			int[] seats = new int[input.Length];

			// Part 1
			int highest = 0;
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

				seats[i] = id;

				if (id > highest)
				{
					highest = id;
				}
			}

			Console.WriteLine($"Highest seat ID: {highest}");

			// Part 2
			Array.Sort(seats);

			int k = 1;
			for (; seats[k] - 1 == seats[k - 1]; k++) ;

			Console.WriteLine($"My seat ID: {seats[k] - 1}");
		}
	}
}
