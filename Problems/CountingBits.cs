using CodingProblems.Interfaces;
using System;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class CountingBits : IExecution // Leetcode - 338
	{
		public MethodEnums Name => MethodEnums.CountingBits;

		public void Execute()
		{
			Console.WriteLine("Given an integer n, return an array ans of length n + 1 such that for each i (0 <= i <= n), ans[i] is the number of 1's in the binary representation of i.");
			int n = int.Parse(Console.ReadLine());
			var result = CountBits(n);
			foreach (var item in result)
			{
				Console.Write(item + " ");
			}
			Console.WriteLine();
		}
		public int[] CountBits(int n)
		{
			int[] newArray = new int[n + 1];
			for (int i = 0; i <= n; i++)
			{
				newArray[i] = newArray[i >> 1] + (i & 1);
			}
			return newArray;
		}
	}
}
