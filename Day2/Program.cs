using System;
using System.IO;

namespace Day2
{
	class Program
	{
		static void Main(string[] args)
		{
			int part1Answer = 0;
			int part2Answer = 0;

			var lines = File.ReadAllLines("day2.txt");

			for (int i = 0; i < lines.Length; i++)
			{
				string line = lines[i];
				int space = line.IndexOf(' ');
				int minus = line.IndexOf('-');
				int colon = line.IndexOf(':');

				char letter = line[colon - 1];
				int low = int.Parse(line[0..minus]);
				int high = int.Parse(line[(minus + 1)..space]);
				string password = line[(colon + 2)..];

				int letterCount = 0;
				for (int j = 0; j < password.Length; j++)
				{
					if (password[j] == letter)
					{
						letterCount++;
					}
				}
				
				if (letterCount >= low && letterCount <= high)
				{
					part1Answer++;
				}

				if (password.Length >= high && password[low - 1] == letter ^ password[high - 1] == letter)
				{
					part2Answer++;
				}
			}

			Console.WriteLine($"Part 1: {part1Answer}");
			Console.WriteLine($"Part 2: {part2Answer}");
		}
	}
}
