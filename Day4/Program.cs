using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Day4
{
	class Program
	{
		static readonly string[] neededTags = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid", "cid" };
		static readonly string[] patterns =
		{
			@"byr:([0-9]+)",
			@"iyr:([0-9]+)",
			@"eyr:([0-9]+)",
			@"hgt:([0-9]+)(cm|in)",
			@"hcl:#[0-9a-f]{6}",
			@"ecl:(amb|blu|brn|gry|grn|hzl|oth)",
			@"pid:([0-9]){9}\b"
		};

		static readonly (int, int)[] years = new[]
		{
			(1920, 2002),
			(2010, 2020),
			(2020, 2030),
		};

		static void Main(string[] args)
		{
			int total1 = 0;
			int total2 = 0;

			foreach (var passport in File.ReadAllText("Day4.txt").Split("\n\n"))
			{
				if (Part1(passport))
				{
					total1++;
					Part2(passport, ref total2);
				}
			}

			Console.WriteLine($"Total for part 1: {total1}");
			Console.WriteLine($"Total for part 2: {total2}");
		}

		static bool Part1(string passport)
		{
			var tags = passport.Split(neededTags, StringSplitOptions.RemoveEmptyEntries);
			return tags.Length == 8 || tags.Length == 7 && !passport.Contains("cid");
		}

		static void Part2(string passport, ref int total)
		{
			for (int i = 0; i < patterns.Length; i++)
			{
				Regex regex = new(patterns[i]);
				Match match = regex.Match(passport);

				if (!match.Success)
				{
					return;
				}

				if (i < 3 && !CheckYear(int.Parse(match.Groups[1].Value), years[i]))
				{
					return;
				}
				
				if (i == 3 && !CheckHeight(int.Parse(match.Groups[1].Value), match.Groups[2].Value))
				{
					return;
				}
			}

			total++;
		}

		static bool CheckYear(int year, (int lower, int upper) range)
		{
			return year >= range.lower && year <= range.upper;
		}

		static bool CheckHeight(int height, string unitsStr)
		{
			return unitsStr switch
			{
				"cm" => height is >= 150 and <= 193,
				_ => height is >= 59 and <= 76
			};
		}
	}
}
