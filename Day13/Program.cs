using System;
using System.Collections.Generic;
using System.IO;

namespace Day13
{
	class Program
	{
		static void Main()
		{
			string[] input = File.ReadAllLines("Day13.txt");

			string[] buses = input[1].Split(',');
			string idStr;
			int busID;

			int earliestDepartTime = int.Parse(input[0]);
			int minBusTime = int.MaxValue;
			int idIndex = 0;
			for (int i = 0; i < buses.Length; i++)
			{
				idStr = buses[i];
				if (idStr != "x")
				{
					busID = int.Parse(idStr);
					int currentBusTime = (int)(busID * MathF.Ceiling(earliestDepartTime / (float)busID));

					if (currentBusTime < minBusTime)
					{
						minBusTime = currentBusTime;
						idIndex = i;
					}
				}
			}

			Console.WriteLine($"Part 1: {(minBusTime - earliestDepartTime) * int.Parse(buses[idIndex])}");

			// Part 2
			long departTime = 0;
			long lcm = long.Parse(buses[0]);

			for (int i = 1; i < buses.Length; i++)
			{
				idStr = buses[i];
				if (idStr != "x")
				{
					busID = int.Parse(idStr);
					while ((departTime + i) % busID != 0)
					{
						departTime += lcm;
					}

					lcm = CalcLcm(lcm, busID);
				}
			}

			Console.WriteLine($"Part 2: {departTime}");
		}

		static long CalcLcm(long a, long n)
		{
			long gcd = a;
			long mod = n;
			long temp;

			// GCD
			while (mod != 0)
			{
				temp = mod;
				mod = gcd % mod;
				gcd = temp;
			}

			return (a / gcd) * n;
		}
	}
}
