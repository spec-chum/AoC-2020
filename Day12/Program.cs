using System;
using System.IO;

namespace Day12
{
	class Program
	{
		enum Direction
		{
			North,
			East,
			South,
			West
		}

		struct Vector
		{
			public int X, Y;

			public Vector(int x, int y)
			{
				X = x;
				Y = y;
			}
		}

		static void Main(string[] args)
		{
			//var input = "F10\nN3\nF7\nR90\nF11".Split('\n');
			var input = File.ReadAllLines("Day12.txt");

			Direction dir = Direction.East;
			Vector location = new(0, 0);

			foreach (var command in input)
			{
				char action = command[0];
				int value = int.Parse(command[1..]);

				switch (action)
				{
					case 'N':
						location.Y += value;
						break;
					case 'S':
						location.Y -= value;
						break;
					case 'E':
						location.X += value;
						break;
					case 'W':
						location.X -= value;
						break;

					case 'L':
						dir = (Direction)((int)dir - (value / 90) & 3);
						break;
					case 'R':
						dir = (Direction)((int)dir + (value / 90) & 3);
						break;

					case 'F':
						if (dir == Direction.North)
						{
							location.Y += value;
							break;
						}
						else if (dir == Direction.South)
						{
							location.Y -= value;
							break;
						}
						else if (dir == Direction.East)
						{
							location.X += value;
							break;
						}
						else
						{
							location.X -= value;
							break;
						}

					default:
						break;
				}
			}

			int NS = (int)MathF.Abs(location.Y);
			int EW = (int)MathF.Abs(location.X);
			Console.WriteLine($"{NS} + {EW} = {NS + EW}");
			Console.WriteLine(2458);
		}
	}
}
