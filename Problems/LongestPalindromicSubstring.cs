using CodingProblems.Interfaces;
using System;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class LongestPalindromicSubstring : IExecution
	{
        int lo = 0;
        int max = 0;
        public MethodEnums Name => MethodEnums.LongestPalindromicSubstring;

		public void Execute()
		{
			Console.WriteLine("Given a string s, return the longest palindromic substring in s.");
			Console.WriteLine("Enter String");
			var str = Console.ReadLine();
            Console.WriteLine(LongestPalindrome(str));
        }
        public string LongestPalindrome(string s)
        {
            var length = s.Length;
            if (length < 2)
            {
                return s;
            }
            for (int i = 0; i < length - 1; i++)
            {
                CheckPalindrome(s, i, i);
                CheckPalindrome(s, i, i + 1);
                if (max == length)
                {
                    break;
                }
            }
            return s.Substring(lo, max);
        }
        private void CheckPalindrome(string s, int i, int j)
        {
            while (i >= 0 && j < s.Length && s[i] == s[j])
            {
                i--;
                j++;
            }
            if (max < j - i - 1)
            {
                lo = i + 1;
                max = j - i - 1;
            }
        }
    }
}
