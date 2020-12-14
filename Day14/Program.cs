using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Day14
{
	class Program
	{
		static void Main(string[] args)
		{
			//var input = "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X\nmem[8] = 11\nmem[7] = 101\nmem[8] = 0".Split('\n');

			var input = File.ReadAllLines("Day14.txt");

			ulong[] mem = new ulong[65536];

			string mask = "";
			ulong value;
			int address;

			foreach (var line in input)
			{
				if (line.StartsWith("ma"))
				{
					mask = line.Substring(7, 36);
				}
				else
				{
					var matches = Regex.Matches(line, @"\[(?<addr>[0-9]+)\] = (?<value>[0-9]+)");
					for (int i = 0; i < matches.Count; i++)
					{
						var groups = matches[i].Groups;
						address = int.Parse(groups["addr"].Value);
						value = ulong.Parse(groups["value"].Value);

						for (int j = 0; j < mask.Length; j++)
						{
							char bit = mask[j];
							if (bit == 'X')
							{
								continue;
							}

							if (bit == '1')
							{
								value |= (ulong)1 << (35 - j);
							}
							else
							{
								value &= ~((ulong)1 << (35 - j));
							}
						}

						mem[address] = value;
					}				
				}
			}

			ulong total = 0;
			foreach (var data in mem)
			{
				total += data;
			}
			Console.WriteLine(total);
		}
	}
}
