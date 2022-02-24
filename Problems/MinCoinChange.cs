using CodingProblems.Interfaces;
using System;
using System.Linq;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class MinCoinChange : IExecution
	{
		public MethodEnums Name => MethodEnums.MinCoinChange;

		public void Execute()
		{
			Console.WriteLine("Enter Array of Coins");
			var coins = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None).Select(x => Int32.Parse(x)).ToArray();

			Console.WriteLine("Enter the Amount that need to make with change of least coins");
			var amount = int.Parse(Console.ReadLine());
			Console.WriteLine("The Minimum number of Coin Changes are " + Run(coins, amount));
		}

		public int Run(int[] coins, int amount)
		{
			var results = new int[amount + 1];
			for (int i = 0; i <= amount; i++)
			{
				results[i] = amount + 1;
			}
			results[0] = 0;
			for (int i = 1; i <= amount; i++)
			{
				foreach (var coin in coins)
				{
					if (i - coin >= 0)
					{
						results[i] = Math.Min(results[i], 1 + results[i - coin]);
					}
				}
			}
			return results[amount];
		}
	}
}
