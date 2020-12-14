using System;
using System.IO;

namespace Day14
{
	class Program
	{
		static void Main()
		{
			//var input = "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X\nmem[8] = 11\nmem[7] = 101\nmem[8] = 0".Split('\n');

			var input = File.ReadAllLines("Day14.txt");

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
