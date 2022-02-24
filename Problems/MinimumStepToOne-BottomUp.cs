using CodingProblems.Interfaces;
using System;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class MinimumStepToOne_BottomUp : IExecution
	{
		public MethodEnums Name => MethodEnums.MinimumStepToOne_BottomUp;

		public void Execute()
		{
			Console.WriteLine("On a positive integer, you can perform any one of the following 3 steps. 1.) Subtract 1 from it. ( n = n - 1 ) , 2.)" +
				"If its divisible by 2, divide by 2. ( if n % 2 == 0 , then n = n / 2 ) , 3.) If its divisible by 3, divide by 3. ( if n % 3 == 0 , then n = n / 3 )." +
				"Now the question is, given a positive integer n, find the minimum number of steps that takes n to 1");
			int n = int.Parse(Console.ReadLine());
			int result = GetMinSteps(n);
			Console.WriteLine("The Minimum step to reach the number is " + result);
		}

		private int GetMinSteps(int n)
		{
			var store = new int[n + 1];
			store[1] = 0;
			for (int i = 2; i <= n; i++)
			{
				store[i] = store[i - 1] + 1;
				if (i % 2 == 0)
				{
					store[i] = Math.Min(store[i], 1 + store[i / 2]);
				}
				if (i % 3 == 0)
				{
					store[i] = Math.Min(store[i], 1 + store[i / 3]);
				}
			}
			return store[n];
		}
	}
}
