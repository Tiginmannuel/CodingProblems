using CodingProblems.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class SubArraySumEqualsK : IExecution
	{
		public MethodEnums Name => MethodEnums.SubArraySumEqualsK;

		public void Execute()
		{
			Console.WriteLine("Given an array of integers nums and an integer k, return the total number of subarrays whose sum equals to k.");
			Console.WriteLine("Enter Array of Coin");
			var array = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None).Select(x => Int32.Parse(x)).ToArray();

			Console.WriteLine("Enter the K");
			var k = int.Parse(Console.ReadLine());
			Console.WriteLine(SubarraySum(array, k));
		}

		public int SubarraySum(int[] nums, int k)
		{
			var dict = new Dictionary<int, int>();
			dict[0] = 1;
			var curSum = 0;
			var result = 0;
			foreach (var i in nums)
			{
				curSum += i;
				var diff = curSum - k;

				result += getValueFromDic(dict, diff);
				dict[curSum] = 1 + getValueFromDic(dict, curSum);
			}
			return result;
		}

		private int getValueFromDic(Dictionary<int, int> dict, int key)
		{
			return dict.ContainsKey(key) ? dict[key] : 0;
		}
	}
}
