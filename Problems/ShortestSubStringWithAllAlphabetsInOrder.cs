using CodingProblems.Interfaces;
using System;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class ShortestSubStringWithAllAlphabetsInOrder : IExecution
	{
		public MethodEnums Name => MethodEnums.ShortestSubStringWithAllAlphabetsInOrder;

		public void Execute()
		{
			Console.WriteLine("Find the shortest substring where all the alphabets (a to z) appear in order. Consider alphabets as case insensitive means 'a' and 'A' are same.");
			Console.WriteLine("Enter the string");
			var str = Console.ReadLine();
			Console.WriteLine(LengthOfShortestSubStringWithAllAlphabets(str));
		}

		private string LengthOfShortestSubStringWithAllAlphabets(string str)
		{
			string target = "abc";
			int[,] dp = new int[target.Length + 1, str.Length + 1];
			var row = dp.GetLength(0);
			var col = dp.GetLength(1);

			for (int i = 1; i < row; i++)
			{
				dp[i, 0] = -1;
			}

			for (int j = 1; j < col; j++)
			{
				dp[0, j] = j;
			}
			dp[0, 0] = 1;
			for (int i = 1; i < row; i++)
			{
				for (int j = 1; j < col; j++)
				{
					if (target[i - 1] == char.ToLower(str[j - 1]))
					{
						dp[i, j] = dp[i - 1, j - 1];
					}
					else
					{
						dp[i, j] = dp[i, j - 1];
					}
				}
			}
			int minLength = str.Length;
			int start = -1;
			for (int j = 1; j < col; j++)
			{
				if (dp[row - 1, j] != -1)
				{
					int endIdx = j;
					int startIdx = dp[row - 1, j] == 1 ? dp[row - 1, j] - 1 : dp[row - 1, j];
					if (endIdx - startIdx <= minLength)
					{
						minLength = endIdx - startIdx;
						start = startIdx;
					}
				}
			}
			
			return start == -1 ? "" : str.Substring(start, minLength);
		}
	}
}
