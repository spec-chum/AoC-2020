using System;
using System.Collections.Generic;
using System.IO;

namespace Day10
{
	class Program
	{
		static void Main()
		{
			int[] input = Array.ConvertAll(File.ReadAllLines("Day10.txt"), int.Parse);
			//int[] input = { 16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4 };

			List<int> nums = new() { 0 };
			nums.AddRange(input);
			nums.Sort();
			nums.Add(nums[^1] + 3);

			int oneCount = 0;
			int threeCount = 0;
			for (int i = 0; i < nums.Count - 1; i++)
			{
				int diff = nums[i + 1] - nums[i];
				if (diff == 1)
				{
					oneCount++;
				}
				else if (diff == 3)
				{
					threeCount++;
				}
			}

			Console.WriteLine($"Part 1: {oneCount} * {threeCount} = {oneCount * threeCount}");

			// Part 2
			long[] arrangements = new long[nums.Count];
			arrangements[^1] = nums[1];
			for (int i = arrangements.Length - 1; i >= 0; i--)
			{
				for (int j = i + 1; j < arrangements.Length; j++)
				{
					if (nums[j] - nums[i] < 4)
					{
						arrangements[i] += arrangements[j];
					}
				}
			}

			Console.WriteLine($"Part 2: {arrangements[0]} distinct arrangements");
		}
	}
}
