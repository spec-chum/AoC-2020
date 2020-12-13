using System;
using System.IO;

namespace Day12
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = File.ReadAllLines("Day12.txt");

			// Part 1
			(int x, int y) location = (0, 0);
			(int x, int y) waypoint = (1, 0);

			ExecuteCommands(1, input, ref location, waypoint);
			int EW = Math.Abs(location.x);
			int NS = Math.Abs(location.y);
			Console.WriteLine($"Part 1: {EW} + {NS} = {EW + NS}");

			// Part 2
			location = (0, 0);
			waypoint = (10, 1);

			ExecuteCommands(2, input, ref location, waypoint);
			EW = Math.Abs(location.x);
			NS = Math.Abs(location.y);
			Console.WriteLine($"Part 2: {EW} + {NS} = {EW + NS}");
		}

		private static void ExecuteCommands(int part, string[] input, ref (int x, int y) location, (int x, int y) waypoint)
		{
			ref (int x, int y) target = ref part == 1 ? ref location : ref waypoint;

			foreach (var command in input)
			{
				char action = command[0];
				int value = int.Parse(command[1..]);

				int temp;

				switch (action)
				{
					case 'N':
						target.y += value;
						break;
					case 'S':
						target.y -= value;
						break;
					case 'E':
						target.x += value;
						break;
					case 'W':
						target.x -= value;
						break;

					case 'L':
						// Flip and "Fallthrough"
						if (value == 90)
						{
							value = 270;
						}
						else if (value == 270)
						{
							value = 90;
						}
						goto case 'R';						
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
		}
	}
}
