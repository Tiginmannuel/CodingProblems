using CodingProblems.Interfaces;
using System;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class ChampagneTower : IExecution
	{
		public MethodEnums Name => MethodEnums.ChampagneTower;

		public void Execute() // LeetCode - 799
		{
			Console.WriteLine("We stack glasses in a pyramid, where the first row has 1 glass, the second row has 2 glasses, and so on until the 100th row.  Each glass holds one cup of champagne. " +
				"Then, some champagne is poured into the first glass at the top.When the topmost glass is full, any excess liquid poured will fall equally to the glass immediately to the left and right of it." +
				"When those glasses become full, any excess champagne will fall equally to the left and right of those glasses, and so on.  (A glass at the bottom row has its excess champagne fall on the floor.)" +
				"For example, after one cup of champagne is poured, the top most glass is full.After two cups of champagne are poured," +
				"the two glasses on the second row are half full.After three cups of champagne are poured, those two cups become full - there are 3 full glasses total now.After four cups of champagne are poured," +
				"the third row has the middle glass half full, and the two outside glasses are a quarter full, as pictured below.");
			Console.WriteLine("Enter the Poured glass Number");
			int poured = int.Parse(Console.ReadLine());
			Console.WriteLine("Enter the query row Number");
			int query_row = int.Parse(Console.ReadLine());
			Console.WriteLine("Enter the query glass Number");
			int query_glass = int.Parse(Console.ReadLine());
			Console.WriteLine(ChampagneTowerFn(poured, query_row, query_glass));
		}
		public double ChampagneTowerFn(int poured, int query_row, int query_glass)
		{
			double[,] dp = new double[query_row + 1, query_row + 1];
			dp[0, 0] = poured;
			for (int i = 0; i < query_row; i++)
			{
				for (int j = 0; j <= i; j++)
				{
					if (dp[i, j] > 1)
					{
						dp[i + 1, j] = dp[i + 1, j] + ((dp[i, j] - 1) / 2.0);
						dp[i + 1, j + 1] = dp[i + 1, j + 1] + ((dp[i, j] - 1) / 2.0);
					}
				}
			}
			return Math.Min(1, dp[query_row, query_glass]);
		}
	}
}
