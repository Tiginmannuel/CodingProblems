using CodingProblems.Interfaces;
using System;
using System.Collections.Generic;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class LongestSubstringWithoutRepeatingChar : IExecution
	{
		public MethodEnums Name => MethodEnums.LongestSubstringWithoutRepeatingChar;

		public void Execute()
		{
			// Leet Code 3
			Console.WriteLine("Given a string s, find the length of the longest substring without repeating characters.");
			var str = Console.ReadLine();

			Console.WriteLine("Longest Substring Length: " + LengthOfLongestSubstring(str));
		}

		public int LengthOfLongestSubstring(string s)
		{
			var dict = new Dictionary<char, int>();
			int max = 0;
			for (int i = 0, j = 0; i < s.Length; i++)
			{
				if (dict.ContainsKey(s[i]))
				{
					j = Math.Max(j, dict[s[i]] + 1);
				}
				dict[s[i]] = i;
				max = Math.Max(max, i - j + 1);
			}
			return max;
		}
	}
}
