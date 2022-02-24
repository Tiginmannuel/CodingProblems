using CodingProblems.Enums;
using CodingProblems.Interfaces;
using System;
using System.Linq;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class MaxCoinChange : IExecution
	{
		public MethodEnums Name => MethodEnums.MaxCoinChange;

		public void Execute()
		{
			Console.WriteLine("Enter Array of Coins");
			var coins = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None).Select(x => Int32.Parse(x)).ToArray();

			Console.WriteLine("Enter the Amount that need to make with change of maximum coins");
			var amount = int.Parse(Console.ReadLine());
			Console.WriteLine("The Maximum number of Coin Changes are " + Run(coins, amount));
		}

		public int Run(int[] coins, int amount)
		{
			var results = new int[amount + 1];
			for (int i = 0; i <= amount; i++)
			{
				results[i] = 0;
			}
			results[0] = 0;
			for (int i = 1; i <= amount; i++)
			{
				foreach (var coin in coins)
				{
					if (i - coin >= 0)
					{
						results[i] = Math.Max(results[i], 1 + results[i - coin]);
					}
				}
			}
			return results[amount];
		}
	}
}
