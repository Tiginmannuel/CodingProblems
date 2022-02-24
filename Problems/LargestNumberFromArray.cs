using CodingProblems.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	class LargestNumberFromArray : IExecution
	{
		public MethodEnums Name => MethodEnums.LargestNumberFromArray;

		public void Execute()
		{
			Console.WriteLine("Given a list of non-negative integers nums, arrange them such that they form the largest number and return it. " +
				"Since the result may be very large, so you need to return a string instead of an integer.");
			var array = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None).Select(x => Int32.Parse(x)).ToArray();
			Console.WriteLine("Largest Number From Given Array: " + LargestNumber(array));
		}

		public string LargestNumber(int[] nums)
		{
			var newArray = new List<string>();
			newArray.AddRange(nums.Select(x => x.ToString()));
			newArray.Sort(Compare);
			var val = String.Join("", newArray.ToArray());
			if (ZeroAllCheck(val))
			{
				val = "0";
			}
			return val;
		}

		public int Compare(string n1, string n2)
		{
			return string.Compare((n2 + n1), (n1 + n2));
		}

		public bool ZeroAllCheck(string str)
		{
			return str.All(c => c == '0');
		}
	}
}
