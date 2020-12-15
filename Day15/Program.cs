using System;
using System.Collections.Generic;

namespace Day15
{
	class Program
	{
		static void Main()
		{
			List<int> input = new() { 16, 1, 0, 18, 12, 14, 19 };

			Dictionary<int, int> indexes = new();

			for (int i = 0; i < input.Count; i++)
			{
				indexes[input[i]] = i;
			}

			int total = RunPart(1, input, indexes);
			Console.WriteLine(total);

			total = RunPart(2, input, indexes);
			Console.WriteLine(total);
		}

		private static int RunPart(int part, List<int> input, Dictionary<int, int> diffs)
		{
			int index = input.Count - 1;
			int currentNum = 0;

			while (index < (part == 1 ? 2020 : 30_000_000))
			{
				currentNum = input[index];

				if (!diffs.ContainsKey(currentNum))
				{
					diffs[currentNum] = index;
					input.Add(0);
				}
				else
				{
					input.Add(index - diffs[currentNum]);
					diffs[currentNum] = index;
				}

				index++;
			}

			return currentNum;
		}
	}
}
