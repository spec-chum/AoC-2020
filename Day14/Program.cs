using System;
using System.Collections.Generic;
using System.IO;

namespace Day14
{
	class Program
	{
		static void Main()
		{
			var input = File.ReadAllLines("Day14.txt");

			Part1(input);
			Part2(input);
		}

		static void Part2(string[] input)
		{
			Dictionary<long, long> mem = new();
			long maskOnes = 0;
			long maskX = 0;

			for (int i = 0; i < input.Length; i++)
			{
				var line = input[i].AsSpan();
				if (line.StartsWith("ma"))
				{
					maskOnes = 0;
					maskX = 0;

					var mask = line[7..];
					for (int j = 0; j < mask.Length; j++)
					{
						switch(mask[j])
						{
							case '1':
								maskOnes |= 1L << (mask.Length - 1 - j);
								break;
							case 'X':
								maskX |= 1L << (mask.Length - 1 - j);
								break;
							default:
								continue;
						}
					}
				}
				else
				{
					int addrEnd = line.IndexOf(']');
					long address = long.Parse(line[4..addrEnd]);

					address = (address | maskOnes) & ~maskX;

					long value = long.Parse(line[(addrEnd + 3)..]);
					long mask = 0;

					do
					{
						mem[address | mask] = value;
						mask = (mask - 1) & maskX;
					} while (mask > 0);
				}
			}

			long total = 0;
			foreach (var num in mem)
			{
				total += num.Value;
			}

			Console.WriteLine(total);
		}

		static void Part1(string[] input)
		{
			long[] mem = new long[65536];
			long maskZeros = 0;
			long maskOnes = 0;

			for (int i = 0; i < input.Length; i++)
			{
				var line = input[i].AsSpan();
				if (line.StartsWith("ma"))
				{
					maskZeros = 0;
					maskOnes = 0;

					var mask = line[7..];
					for (int j = 0; j < mask.Length; j++)
					{
						switch (mask[j])
						{
							case '0':
								maskZeros |= 1L << (mask.Length - 1 - j);
								break;
							case '1':
								maskOnes |= 1L << (mask.Length - 1 - j);
								break;
							default:
								continue;
						}
					}
				}
				else
				{
					int addrEnd = line.IndexOf(']');
					int address = int.Parse(line[4..addrEnd]);
					long value = long.Parse(line[(addrEnd + 3)..]);

					mem[address] = (value | maskOnes) & ~maskZeros;
				}
			}

			long total = 0;
			for (int i = 0; i < mem.Length; i++)
			{
				total += mem[i];
			}

			Console.WriteLine(total);
		}
	}
}
