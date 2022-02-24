using CodingProblems.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class TwoSums : IExecution
	{
		public MethodEnums Name => MethodEnums.TwoSums; // LeetCode 1

		public void Execute()
		{
			Console.WriteLine("Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target." +
				"You may assume that each input would have exactly one solution, and you may not use the same element twice." +
				"You can return the answer in any order.");
			Console.WriteLine("Enter Array");
			var array = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None).Select(x => Int32.Parse(x)).ToArray();

			Console.WriteLine("Enter the Target");
			var target = int.Parse(Console.ReadLine());
			Console.WriteLine(string.Join(", ", TwoSum(array, target)));
		}

		public int[] TwoSum(int[] nums, int target)
		{
			var dict = new Dictionary<int, int>();
			var result = new int[2];
			for (int i = 0; i < nums.Length; i++)
			{
				if (dict.ContainsKey(nums[i]))
				{
					result[0] = dict[nums[i]];
					result[1] = i;
					return result;
				}
				else
				{
					var temp = target - nums[i];
					dict[temp] = i;
				}
			}
			return result;
		}
	}
}
