using System;
using System.Collections.Generic;

namespace Day15
{
	class Program
	{
		static void Main()
		{
			List<int> input = new() { 16, 1, 0, 18, 12, 14, 19 };

			int index = input.Count - 1;
			int currentNum = 0;

			while (index < 2020)
			{
				currentNum = input[index];
				int diff = input.LastIndexOf(currentNum, index - 1);

				if (diff == -1)
				{
					input.Add(0);
				}
				else
				{
					input.Add(index - diff);
				}

				index++;
			}

			Console.WriteLine(currentNum);
		}
	}
}
