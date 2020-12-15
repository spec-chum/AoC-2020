﻿using System;
using System.Collections.Generic;

namespace Day15
{
	class Program
	{
		static void Main()
		{
			List<int> input = new() { 16, 1, 0, 18, 12, 14, 19 };

			int total = RunPart(input, 2020);
			Console.WriteLine(total);

			total = RunPart(input, 30_000_000);
			Console.WriteLine(total);
		}

		private static int RunPart(List<int> input, int totalLoops)
		{
			Dictionary<int, int> indexes = new();

			for (int i = 0; i < input.Count; i++)
			{
				indexes[input[i]] = i;
			}

			int index = input.Count - 1;
			int currentNum = input[index];

			while (index < totalLoops - 1)
			{
				if (!indexes.ContainsKey(currentNum))
				{
					indexes[currentNum] = index;
					currentNum = 0;
				}
				else
				{
					int temp = indexes[currentNum];
					indexes[currentNum] = index;
					currentNum = index - temp;
				}

				index++;
			}

			return currentNum;
		}
	}
}
