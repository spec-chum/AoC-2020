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

		static void Main(string[] args)
		{
			var input = File.ReadAllLines("Day12.txt");

			Direction dir = Direction.East;
			(int x, int y) location = (0, 0);

			// Part 1
			foreach (var command in input)
			{
				char action = command[0];
				int value = int.Parse(command[1..]);

				switch (action)
				{
					case 'N':
						location.y += value;
						break;
					case 'S':
						location.y -= value;
						break;
					case 'E':
						location.x += value;
						break;
					case 'W':
						location.x -= value;
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
							location.y += value;
							break;
						}
						else if (dir == Direction.South)
						{
							location.y -= value;
							break;
						}
						else if (dir == Direction.East)
						{
							location.x += value;
							break;
						}
						else
						{
							location.x -= value;
							break;
						}

					default:
						break;
				}
			}

			int EW = Math.Abs(location.x);
			int NS = Math.Abs(location.y);
			Console.WriteLine($"Part 1: {EW} + {NS} = {EW + NS}");

			// Part 2
			location = new(0, 0);
			(int x, int y) waypoint = (10, 1);

			foreach (var command in input)
			{
				char action = command[0];
				int value = int.Parse(command[1..]);

				int temp;
				switch (action)
				{
					case 'N':
						waypoint.y += value;
						break;
					case 'S':
						waypoint.y -= value;
						break;
					case 'E':
						waypoint.x += value;
						break;
					case 'W':
						waypoint.x -= value;
						break;

					case 'L':
						switch (value)
						{
							case 90:
								temp = waypoint.x;
								waypoint.x = -waypoint.y;
								waypoint.y = temp;
								break;

							case 180:
								waypoint.x = -waypoint.x;
								waypoint.y = -waypoint.y;
								break;
							case 270:
								temp = waypoint.x;
								waypoint.x = waypoint.y;
								waypoint.y = -temp;
								break;
							default:
								break;
						}
						break;
					case 'R':
						switch (value)
						{
							case 90:
								temp = waypoint.x;
								waypoint.x = waypoint.y;
								waypoint.y = -temp;
								break;
							case 180:
								waypoint.x = -waypoint.x;
								waypoint.y = -waypoint.y;
								break;
							case 270:
								temp = waypoint.x;
								waypoint.x = -waypoint.y;
								waypoint.y = temp;
								break;
							default:
								break;
						}
						break;

					case 'F':
						location.x += waypoint.x * value;
						location.y += waypoint.y * value;
						break;

					default:
						break;
				}
			}

			EW = Math.Abs(location.x);
			NS = Math.Abs(location.y);
			Console.WriteLine($"Part 2: {EW} + {NS} = {EW + NS}");
		}
	}
}
