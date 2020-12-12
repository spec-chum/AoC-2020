using System;
using System.IO;
using System.Text;

namespace Day11
{
	class Program
	{
		static readonly (int x, int y)[] vectors = { (-1, -1), (-1, 0), (-1, 1), (0, -1), (1, -1), (0, 1), (1, 0), (1, 1) };

		static void Main()
		{
			string[] data = File.ReadAllLines("Day11.txt");
			string[] input = new string[data.Length + 2];

			SetupInput(data, input);

			int width = input[0].Length - 1;
			int height = input.Length - 1;

			int occupied;
			occupied = Run(CheckSeatP1, input, width, height);
			Console.WriteLine($"Part 1: {occupied}");

			SetupInput(data, input);
			occupied = Run(CheckSeatP2, input, width, height);
			Console.WriteLine($"Part 2: {occupied}");
		}

		private static void SetupInput(string[] data, string[] input)
		{
			input[0] = "".PadLeft(data[0].Length + 2, '.');

			for (int i = 0; i < data.Length; i++)
			{
				input[i + 1] = '.' + data[i] + '.';
			}

			input[data.Length + 1] = "".PadLeft(data[0].Length + 2, '.');
		}

		private static int Run(Func<string[], int, int, bool?> part, string[] input, int width, int height)
		{
			int occupied;
			bool same;

			do
			{
				var output = (string[])input.Clone();

				occupied = 0;
				same = true;

				for (int i = 1; i < height; i++)
				{
					StringBuilder row = new(input[i]);
					for (int j = 1; j < width; j++)
					{
						bool? seat = part(input, i, j);

						if (seat == null)
						{
							continue;
						}
						else if (seat == true)
						{
							row[j] = '#';
							same = false;
						}
						else
						{
							row[j] = 'L';
							same = false;
						}
					}

					output[i] = row.ToString();
				}

				// Clone and count occupied
				for (int i = 0; i < height; i++)
				{
					input[i] = output[i];

					for (int j = 0; j < width; j++)
					{
						if (output[i][j] == '#')
						{
							occupied++;
						}
					}
				}
			} while (!same);

			return occupied;
		}

		static bool? CheckSeatP1(string[] seats, int y, int x)
		{
			char seat = seats[y][x];

			// Just return null for floor
			if (seat == '.')
			{
				return null;
			}

			int count = 0;
			foreach (var vector in vectors)
			{
				if (seats[y + vector.x][x + vector.y] == '#')
				{
					count++;
				}
			}

			if (seat == 'L' && count == 0)
			{
				return true;
			}

			if (seat == '#' && count > 3)
			{
				return false;
			}

			return null;
		}

		static bool? CheckSeatP2(string[] seats, int y, int x)
		{
			char seat = seats[y][x];
			if (seat == '.')
			{
				return null;
			}

			int count = 0;
			foreach (var vector in vectors)
			{
				int tempx = x;
				int tempy = y;

				while (true)
				{
					tempy += vector.y;
					if (tempy >= seats.Length || tempy == 0)
					{
						break;
					}

					tempx += vector.x;
					if (tempx >= seats[0].Length || tempx == 0)
					{
						break;
					}

					if (seats[tempy][tempx] == 'L')
					{
						break;
					}

					if (seats[tempy][tempx] == '#')
					{
						count++;
						break;
					}
				}
			}

			if (seat == 'L' && count == 0)
			{
				return true;
			}

			if (seat == '#' && count > 4)
			{
				return false;
			}

			return null;
		}
	}
}
