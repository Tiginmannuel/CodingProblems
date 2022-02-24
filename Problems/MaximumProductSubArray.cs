using CodingProblems.Interfaces;
using System;
using System.Linq;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class MaximumProductSubArray : IExecution
	{
		public MethodEnums Name => MethodEnums.MaximumProductSubArray;

		public void Execute()
		{
            Console.WriteLine("Given an integer array nums, find a contiguous non-empty subarray within the array that has the largest product, and return the product. " +
                "The test cases are generated so that the answer will fit in a 32 - bit integer. " +
                "A subarray is a contiguous subsequence of the array.");
            var array = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None).Select(x => Int32.Parse(x)).ToArray();
            int result = MaxProduct(array);
            Console.WriteLine("The Maximum Product from the SubArray " + result);
        }

        public int MaxProduct(int[] nums)
        {
            int res = nums.Max();
            int curMax = 1;
            int curMin = 1;

            foreach (int num in nums)
            {
                var temp = curMax * num;
                curMax = Math.Max(curMax * num, Math.Max(curMin * num, num));
                curMin = Math.Min(temp, Math.Min(curMin * num, num));
                res = Math.Max(res, curMax);
            }
            return res;
        }
    }
}
