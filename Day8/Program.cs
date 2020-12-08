using System;
using System.IO;

namespace Day8
{
	class Program
	{
		static int A;
		static int PC;

		static void Main(string[] args)
		{
			var input = File.ReadAllLines("Day8.txt");
			var visited = new bool[input.Length];

			while(!visited[PC])
			{
				visited[PC] = true;

				var opcode = input[PC];
				int offset = int.Parse(opcode[4..]);

				if (opcode.StartsWith("acc"))
				{
					A += offset;
					PC++;
				}
				else if (opcode.StartsWith("jmp"))
				{
					PC += offset;
				}
				else
				{
					PC++;
				}
			}

			Console.WriteLine(A);
		}
	}
}
