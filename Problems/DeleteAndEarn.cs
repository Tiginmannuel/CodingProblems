using CodingProblems.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class DeleteAndEarn : IExecution
	{
		public MethodEnums Name => MethodEnums.DeleteAndEarn;

		public void Execute()
		{
			Console.WriteLine("You are given an integer array nums. You want to maximize the number of points you get by performing the following operation any number of times." +
				"Pick any nums[i] and delete it tot earn nums[i] points. Afterwards, you must delete every element equals to nums[i] - 1 and every element equal to nums[i] + 1 " +
				"Return the maximum number of points you can earn by applying the above operation some number of times");
			Console.WriteLine("Enter Array of Coins");
			var nums = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None).Select(x => Int32.Parse(x)).ToArray();
			Console.WriteLine("Maximum Earned is :" + Run(nums));
		}

		private int Run(int[] nums)
		{
			var counts = nums.GroupBy(item => item).ToDictionary(x => x.Key, x => x.Count());
			var numList = new HashSet<int>(nums).ToArray();

			int earn1 = 0;
			int earn2 = 0;
			for (int i = 0; i < numList.Length; i++)
			{
				var curEarn = numList[i] * counts[numList[i]];
				if (i > 0 && numList[i] == numList[i - 1] + 1)
				{
					var temp = earn2;
					earn2 = Math.Max(curEarn + earn1, earn2);
					earn1 = temp;
				}
				else
				{
					var temp = earn2;
					earn2 = curEarn + earn2;
					earn1 = temp;
				}
			}
			return earn2;
		}
	}
}
