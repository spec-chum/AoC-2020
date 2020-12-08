using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Day7
{
	class Program
	{
		static readonly string[] input = File.ReadAllLines("Day7.txt");
		static readonly HashSet<string> bagColours = new();

		static void Main()
		{
			const string shinyGold = "shiny gold";

			// Part 1
			bagColours.Add(shinyGold);

			int numColours = 0;
			Console.WriteLine(GetNumColours(shinyGold, ref numColours));
			Console.WriteLine();

			// Part 2
			Console.WriteLine(GetNumBags(shinyGold));
		}

		static int GetNumColours(string currentBag, ref int numColours)
		{
			for (int i = 0; i < input.Length; i++)
			{
				var currentRule = input[i];
				if (!currentRule.Contains(currentBag))
				{
					continue;
				}

				var currentColour = currentRule.Split(" bags")[0];
				if (bagColours.Add(currentColour))
				{
					GetNumColours(currentColour, ref numColours);
					numColours++;
				}
			}

			return numColours;
		}

		static int GetNumBags(string currentBag)
		{
			int numBags = 0;
			for (int i = 0; i < input.Length; i++)
			{
				var currentRule = input[i];
				if (!currentRule.StartsWith(currentBag))
				{
					continue;
				}

				var ruleMatches = Regex.Matches(currentRule, @"([0-9]) (.*?) bag");
				for (int j = 0; j < ruleMatches.Count; j++)
				{
					var groups = ruleMatches[j].Groups;
					numBags += int.Parse(groups[1].Value) * (GetNumBags(groups[2].Value) + 1);
				}
			}

			return numBags;
		}
	}
}