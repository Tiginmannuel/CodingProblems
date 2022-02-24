using CodingProblems.Interfaces;
using System;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class MinimumStepToOne_Memoization : IExecution
	{
		private static int[] store;
		public MethodEnums Name => MethodEnums.MinimumStepToOne_Memoization;

		public void Execute()
		{
			Console.WriteLine("On a positive integer, you can perform any one of the following 3 steps. 1.) Subtract 1 from it. ( n = n - 1 ) , 2.)" +
				"If its divisible by 2, divide by 2. ( if n % 2 == 0 , then n = n / 2 ) , 3.) If its divisible by 3, divide by 3. ( if n % 3 == 0 , then n = n / 3 )." +
				"Now the question is, given a positive integer n, find the minimum number of steps that takes n to 1");
			int n = int.Parse(Console.ReadLine());
			store = new int[n + 1];
			for (int i = 0; i < n + 1; i++)
			{
				store[i] = -1;
			}
			int result = GetMinSteps(n);
			Console.WriteLine("The Minimum step to reach the number is " + result);
		}

		private int GetMinSteps(int n)
		{
			if (n == 1) return 0; // base case
			if (store[n] != -1) return store[n]; // we have solved it already :)
			int r = 1 + GetMinSteps(n - 1); // '-1' step . 'r' will contain the optimal answer finally
			if (n % 2 == 0) r = Math.Min(r, 1 + GetMinSteps(n / 2)); // '/2' step
			if (n % 3 == 0) r = Math.Min(r, 1 + GetMinSteps(n / 3)); // '/3' step
			store[n] = r; // save the result. If you forget this step, then its same as plain recursion.
			return r;
		}
	}
}
