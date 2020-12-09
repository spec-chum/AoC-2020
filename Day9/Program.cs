using System;
using System.Collections.Generic;
using System.IO;

namespace Day9
{
	class Program
	{
		static void Main(string[] args)
		{
			var nums = Array.ConvertAll(File.ReadAllLines("Day9.txt"), long.Parse);
			const int preamble = 25;

			long result = 0;
			for (int i = preamble; i < nums.Length; i++)
			{
				List<long> sums = new();
				for (int j = i - preamble; j < i; j++)
				{
					for (int k = j + 1; k < i; k++)
					{
						sums.Add(nums[j] + nums[k]);
					}
				}

				if (!sums.Contains(nums[i]))
				{
					Console.WriteLine($"Found: {nums[i]}");
					result = nums[i];
					break;
				}
			}

			Console.WriteLine();

			// Part 2
			for (int i = 0; i < nums.Length - 1; i++)
			{
				long sum = nums[i];
				for (int j = i + 1; j < nums.Length; j++)
				{
					sum += nums[j];
					if (sum == result)
					{						
						long min = long.MaxValue;
						long max = 0;
						for (int k = i - 1; k <= j; k++)
						{
							if (nums[k] > max)
							{
								max = nums[k];
							}
							else if (nums[k] < min)
							{
								min = nums[k];
							}
						}

						Console.WriteLine($"Sum found: {min} + {max} = {min + max}");
						return;
					}
				}
			}
		}
	}
}
