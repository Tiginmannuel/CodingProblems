using CodingProblems.Interfaces;
using System;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class ReverseInteger : IExecution
	{
		public MethodEnums Name => MethodEnums.ReverseInteger;

		public void Execute() // Leet Code 7
		{
			Console.WriteLine("Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the" +
				"signed 32-bit integer range [-231, 231 - 1], then return 0. Assume the environment does not allow you to" +
				"store 64 - bit integers(signed or unsigned).");

			Console.WriteLine("Enter Number");
			var target = int.Parse(Console.ReadLine());
			Console.WriteLine(Reverse(target));
		}

		public int Reverse(int x)
		{
			int result = 0;

			while (x != 0)
			{
				int tail = x % 10;
				int newResult = result * 10 + tail;
				if ((newResult - tail) / 10 != result)
				{ return 0; }
				result = newResult;
				x = x / 10;
			}

			return result;
		}
	}
}
