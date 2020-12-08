using System;
using System.Diagnostics;
using System.IO;

namespace Day6
{
	class Program
	{
		static void Main()
		{
			var input = File.ReadAllText("Day6.txt").Split("\n\n");

			Stopwatch sw = Stopwatch.StartNew();

			int totalAnswers = 0;
			int totalQuestions = 0;

			for (int i = 0; i < input.Length; i++)
			{
				var answerFull = input[i].Replace("\n", "");
				var answerDistinct = RemoveDuplicates(answerFull);

				// Part 1
				totalAnswers += answerDistinct.Length;

				// Part 2
				var numPeople = Count(input[i], '\n') + 1;
				
				// Handle last line not having \n\n
				if (i == input.Length - 1)
				{
					numPeople--;
				}

				for (int k = 0; k < answerDistinct.Length; k++)
				{
					if (Count(answerFull, answerDistinct[k]) == numPeople)
					{
						totalQuestions++;
					}
				}
			}

			sw.Stop();
			Console.WriteLine(sw.Elapsed.TotalMilliseconds);

			Console.WriteLine($"Total number of answers: {totalAnswers}");
			Console.WriteLine($"Number of questions groups all answered yes to: {totalQuestions}");
		}

		static ReadOnlySpan<char> RemoveDuplicates(ReadOnlySpan<char> str)
		{
			Span<char> result = new char[str.Length];

			int j = 0;
			for (int i = 0; i < str.Length; i++)
			{
				if (!Contains(result, str[i]))
				{
					result[j++] = str[i];
				}
			}

			return result.Slice(0, j);
		}

		private static bool Contains(ReadOnlySpan<char> str, char letter)
		{
			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] == letter)
				{
					return true;
				}
			}

			return false;
		}

		static int Count(ReadOnlySpan<char> str, char letter)
		{
			int count = 0;

			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] == letter)
				{
					count++;
				}
			}

			return count;
		}
	}
}
