﻿using System;
using System.Collections.Generic;

namespace Day15
{
	class Program
	{
		static void Main()
		{
			List<int> input = new() { 16, 1, 0, 18, 12, 14, 19 };

			int total = RunPart(1, input);
			Console.WriteLine(total);

			total = RunPart(2, input);
			Console.WriteLine(total);
		}

		private static int RunPart(int part, List<int> input)
		{
			Dictionary<int, int> indexes = new();

			for (int i = 0; i < input.Count; i++)
			{
				indexes[input[i]] = i;
			}

			int index = input.Count - 1;
			int currentNum = input[index];

			while (index + 1 < (part == 1 ? 2020 : 30_000_000))
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
