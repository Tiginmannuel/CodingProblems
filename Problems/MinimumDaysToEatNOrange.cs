using CodingProblems.Interfaces;
using System;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class MinimumDaysToEatNOrange : IExecution
	{
		public MethodEnums Name => MethodEnums.MinimumDaysToEatNOrange;
		private int[] dp;

		public void Execute()
		{
			Console.WriteLine("There are n Oranges in the kitchen and you decided to eat some of these orange every day as follows:" +
				"Eat One Orange" +
				"If the Number of remaining oranges (n) is divisible by 2 then you can eat n/2 oranges" +
				"If the number of remaining oranges (n) is divisible by 3 then you can eat 2*(n/3) oranges" +
				"You can only choose one of the actions per day" +
				"Return the minimum number of days to eat n Oranges");
			int n = int.Parse(Console.ReadLine());
			dp = new int[n + 1];
			dp[0] = 0;
			dp[1] = 1;
			for (int i = 2; i <= n; i++)
			{
				dp[i] = -1;
			}
			Console.WriteLine("Minimum Number of Days Need to Eat " + n + " Oranges is " + Run(n));
		}

		public int Run(int n)
		{
			if (dp[n] != -1)
			{
				return dp[n];
			}
			var one = 1 + (n % 2) + Run(n / 2);
			var two = 1 + (n % 3) + Run(n / 3);
			dp[n] = Math.Min(one, two);
			return dp[n];
		}
	}
}
