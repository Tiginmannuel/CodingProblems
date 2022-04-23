using CodingProblems.Interfaces;
using System;
using System.Linq;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class ZigzagConversion : IExecution
	{
		public MethodEnums Name => MethodEnums.ZigzagConversion;

		public void Execute() // LeetCode 6
		{
			Console.WriteLine("The string PAYPALISHIRING is written in a zigzag pattern on a given number of rows like this:" +
				"(you may want to display this pattern in a fixed font for better legibility) And then read line by line: PAHNAPLSIIGYIR " +
				"Write the code that will take a string and make this conversion given a number of rows: ");

			Console.WriteLine("Enter String Array");
			var stringArray = Console.ReadLine();
			Console.WriteLine("Enter Number Of Rows");
			var numOfRows = int.Parse(Console.ReadLine());

			Console.WriteLine("The Processed New String:" + Convert(stringArray, numOfRows));
		}

		public string Convert(string s, int numRows)
		{
			string result = "";
			if (numRows == 1)
			{
				return s;
			}
			int step1, step2;
			int len = s.Count();
			for (int i = 0; i < numRows; ++i)
			{
				step1 = (numRows - i - 1) * 2;
				step2 = i * 2;

				int pos = i;

				if (pos < len)
				{
					result += s[pos];
				}
				while (true)
				{
					pos += step1;
					if (pos >= len)
					{
						break;
					}
					if (step1 != 0)
					{
						result += s[pos];
					}
					pos += step2;

					if (pos >= len)
					{
						break;
					}

					if (step2 != 0)
					{
						result += s[pos];
					}
				}
			}
			return result;
		}
	}
}
