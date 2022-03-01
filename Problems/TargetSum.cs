using CodingProblems.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class TargetSum : IExecution
	{
		Dictionary<Tuple<int, int>, int> dict = null;
		public MethodEnums Name => MethodEnums.TargetSum;

		public void Execute()
		{
			dict = new Dictionary<Tuple<int, int>, int>();
			Console.WriteLine("You are given an integer array nums and an integer target. " +
				"You want to build an expression out of nums by adding one of the symbols '+' and '-' before each integer in nums and then concatenate all the integers. " +
				"For example, if nums = [2, 1], you can add a '+' before 2 and a '-' before 1 and concatenate them to build the expression +2-1. " +
				"Return the number of different expressions that you can build, which evaluates to target.");
			Console.WriteLine("Enter Array");
			var nums = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None).Select(x => Int32.Parse(x)).ToArray();
			Console.WriteLine("Enter Target");
			var target = int.Parse(Console.ReadLine());
			Console.WriteLine("Target Sum: " + FindTargetSum(nums, target, 0, 0));
		}

		private int FindTargetSum(int[] nums, int target, int i, int total)
		{
			if (i == nums.Length)
			{
				return target == total ? 1 : 0;
			}
			if (dict.TryGetValue(new Tuple<int, int>(i, total), out var val))
			{
				return val;
			}
			dict[Tuple.Create(i, total)] = (FindTargetSum(nums, target, i + 1, total + nums[i]) + FindTargetSum(nums, target, i + 1, total - nums[i]));
			return dict[Tuple.Create(i, total)];
		}
	}
}
