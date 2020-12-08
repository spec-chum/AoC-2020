using System;
using System.Collections.Generic;
using System.IO;

namespace Day8
{
	class Program
	{
		static readonly string[] input = File.ReadAllLines("Day8.txt");
		static readonly bool[] visited = new bool[input.Length + 1];

		static int A;
		static int PC;

		static void Main(string[] args)
		{
			visited[input.Length] = true;

			Execute();
			Console.WriteLine($"Part 1: A = {A}");

			Part2();
			Console.WriteLine($"Part 2: A = {A}");
		}

		private static void Execute()
		{
			Array.Clear(visited, 0, visited.Length - 1);

			A = 0;
			PC = 0;

			while (!visited[PC])
			{
				visited[PC] = true;

				string opcode = input[PC];
				int offset = int.Parse(opcode[4..]);

				if (opcode.StartsWith('a'))
				{
					A += offset;
					PC++;
				}
				else if (opcode.StartsWith('j'))
				{
					PC += offset;
				}
				else
				{
					PC++;
				}
			}
		}

		private static void Part2()
		{
			List<int> nops = new();
			PopulateList(nops, 'n');
			for (int i = 0; i < nops.Count; i++)
			{
				int nop = nops[i];
				string temp = input[nop];
				input[nop] = input[nop].Replace("no", "jm");

				Execute();
				if (PC == input.Length)
				{
					Console.WriteLine($"Execution successful by changing NOP at index {i} to JMP");
					return;
				}
				else
				{
					input[nop] = temp;
				}
			}

			List<int> jmps = new();
			PopulateList(jmps, 'j');
			for (int i = 0; i < jmps.Count; i++)
			{
				int jmp = jmps[i];
				string temp = input[jmp];
				input[jmp] = input[jmp].Replace("jm", "no");

				Execute();
				if (PC == input.Length)
				{
					Console.WriteLine($"Execution successful by changing JMP at index {i} to NOP");
					return;
				}
				else
				{
					input[jmp] = temp;
				}
			}
		}

		static void PopulateList(List<int> list, char mnenomic)
		{
			for (int i = 0; i < input.Length; i++)
			{
				if (input[i][0] == mnenomic)
				{
					list.Add(i);
				}
			}
		}
	}
}
