using System;
using System.Collections.Generic;
using System.IO;

namespace Day5
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = File.ReadAllLines("Day5.txt");

			List<int> seats = new();

			// Part 1
			int highest = 0;
			foreach (var seat in input)
			{
				int row = 0;
				int column = 0;
				for (int i = 0; i < 10; i++)
				{
					if (i < 7)
					{
						if (seat[i] == 'B')
						{
							row += 1 << (6 - i);
						}
					}
					else
					{
						if (seat[i] == 'R')
						{
							column += 1 << (9 - i);
						}
					}
				}

				int id = row * 8 + column;
				seats.Add(id);

				if (id > highest)
				{
					highest = id;
				}
			}

			Console.WriteLine($"Highest seat ID: {highest}");

			// Part 2
			seats.Sort();

			int mine = 0;
			for (int i = 1; i < seats.Count - 1; i++)
			{
				if (seats[i] - 1 != seats[i - 1])
				{
					mine = seats[i] - 1;
					break;
				}
			}

			Console.WriteLine($"My seat ID: {mine}");
		}
	}
}
