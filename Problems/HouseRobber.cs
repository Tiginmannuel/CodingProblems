using CodingProblems.Interfaces;
using System;
using System.Linq;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class HouseRobber : IExecution
	{
		public MethodEnums Name => MethodEnums.HouseRobber;

		public void Execute()
		{
			Console.WriteLine("You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you" +
                "from robbing each of them is that adjacent houses have security systems connected and it will automatically contact the police if two adjacent houses were broken into" +
                "on the same night.Given an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting" +
                "the police. --LeetCode 198");
            var array = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None).Select(x => Int32.Parse(x)).ToArray();
            int result = Rob(array);
			Console.WriteLine("The Maximum Amount can be Robbed " + result);
		}

        public int Rob(int[] nums)
        {
            int earn1 = 0;
            int earn2 = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                var temp = Math.Max(earn1 + nums[i], earn2);
                earn1 = earn2;
                earn2 = temp;
            }
            return earn2;
        }
    }
}
