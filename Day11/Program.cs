using System;
using System.IO;
using System.Text;

namespace Day11
{
	class Program
	{
		static readonly (int, int)[] vectors = { (-1, -1), (0, -1), (1, -1), (-1, 0), (1, 0), (-1, 1), (0, 1), (1, 1) };

		static void Main()
		{
			//string[] data = {	"L.LL.LL.LL",
			//					"LLLLLLL.LL",
			//					"L.L.L..L..",
			//					"LLLL.LL.LL",
			//					"L.LL.LL.LL",
			//					"L.LLLLL.LL",
			//					"..L.L.....",
			//					"LLLLLLLLLL",
			//					"L.LLLLLL.L",
			//					"L.LLLLL.LL", };

			string[] data = File.ReadAllLines("Day11.txt");
			string[] input = new string[data.Length + 2];

			input[0] = "".PadLeft(data[0].Length + 2, '.');
			for (int i = 0; i < data.Length; i++)
			{
				input[i + 1] = '.' + data[i] + '.';
			}
			input[data.Length + 1] = "".PadLeft(data[0].Length + 2, '.');

			int width = input[0].Length - 1;
			int height = input.Length - 1;

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
						bool? seat = CheckSeat(input, i, j);

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

			Console.WriteLine(occupied);
		}

		static bool? CheckSeat(string[] seats, int y, int x)
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
				if (seats[y + vector.Item1][x + vector.Item2] == '#')
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
	}
}
