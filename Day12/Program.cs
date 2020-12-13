using System;
using System.IO;
using System.Numerics;

namespace Day12
{
	class Program
	{
		static void Main()
		{
			var input = File.ReadAllLines("Day12.txt");

			// Part 1
			Vector2 location = Vector2.Zero;
			Vector2 waypoint = Vector2.UnitX;

			ExecuteCommands(1, input, ref location, waypoint);

			location = Vector2.Abs(location);
			Console.WriteLine($"Part 1: {location.X} + {location.Y} = {location.X + location.Y}");

			// Part 2
			location = Vector2.Zero;
			waypoint = new(10, 1);

			ExecuteCommands(2, input, ref location, waypoint);

			location = Vector2.Abs(location);
			Console.WriteLine($"Part 2: {location.X} + {location.Y} = {location.X + location.Y}");
		}

		private static void ExecuteCommands(int part, string[] input, ref Vector2 location, Vector2 waypoint)
		{
			ref Vector2 target = ref part == 1 ? ref location : ref waypoint;

			foreach (var command in input)
			{
				char action = command[0];
				float value = float.Parse(command[1..]);

				float temp;

				switch (action)
				{
					case 'N':
						target.Y += value;
						break;
					case 'S':
						target.Y -= value;
						break;
					case 'E':
						target.X += value;
						break;
					case 'W':
						target.X -= value;
						break;

					case 'L':
						// Every angle is a multiple of 90 so don't bother with a transform matrix
						switch (value)
						{
							case 90:
								temp = waypoint.X;
								waypoint.X = -waypoint.Y;
								waypoint.Y = temp;
								break;
							case 180:
								waypoint.X = -waypoint.X;
								waypoint.Y = -waypoint.Y;
								break;
							case 270:
								temp = waypoint.X;
								waypoint.X = waypoint.Y;
								waypoint.Y = -temp;
								break;
							default:
								break;
						}

						break;
					case 'R':
						switch (value)
						{
							case 90:
								temp = waypoint.X;
								waypoint.X = waypoint.Y;
								waypoint.Y = -temp;
								break;
							case 180:
								waypoint.X = -waypoint.X;
								waypoint.Y = -waypoint.Y;
								break;
							case 270:
								temp = waypoint.X;
								waypoint.X = -waypoint.Y;
								waypoint.Y = temp;
								break;
							default:
								break;
						}

						break;

					case 'F':
						location += waypoint * value;
						break;

					default:
						break;
				}
			}
		}
	}
}
