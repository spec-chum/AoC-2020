using System;
using System.IO;

namespace Day3
{
	class Program
	{
		private static string[] map;

		static void Main(string[] args)
		{
			map = File.ReadAllLines("day3.txt");

			long total;
			total = CountTrees((1, 1));
			total *= CountTrees((3, 1));
			total *= CountTrees((5, 1));
			total *= CountTrees((7, 1));
			total *= CountTrees((1, 2));

			Console.WriteLine(total);
		}

		private static int CountTrees((int x, int y) pattern)
		{
			const char tree = '#';

			int hitCount = 0;

			int x = 0;
			for (int y = pattern.y; y < map.Length; y += pattern.y)
			{
				string line = map[y];

				x += pattern.x;
				if (x >= line.Length)
				{
					x -= line.Length;
				}

				if (line[x] == tree)
				{
					hitCount++;
				}
			}

			Console.WriteLine(hitCount);

			return hitCount;
		}
	}
}
