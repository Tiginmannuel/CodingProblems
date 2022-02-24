using CodingProblems.Interfaces;
using System;
using System.Linq;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class BestTimeToBuyAndSell : IExecution
	{
		public MethodEnums Name => MethodEnums.BestTimeToBuyAndSell;

		public void Execute() // Leet Code 121
		{
			Console.WriteLine("You are given an array prices where prices[i] is the price of a given stock on the ith day. " +
				"You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock. " +
				"Return the maximum profit you can achieve from this transaction.If you cannot achieve any profit, return 0.");
			Console.WriteLine("Enter Array Of Share Price!");
			var array = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None).Select(x => Int32.Parse(x)).ToArray();
            Console.WriteLine("Max Profit: " + MaxProfit(array));
		}

        public int MaxProfit(int[] prices)
        {
            int min = Int32.MaxValue;
            int overProfit = 0;
			for (int i = 0; i <= prices.Length - 1; i++)
            {
                var price = prices[i];
                if (min > price)
                {
                    min = price;
                }
				int todayProfit = price - min;
				if (overProfit < todayProfit)
                {
                    overProfit = todayProfit;
                }
            }
            return overProfit;
        }
    }
}
