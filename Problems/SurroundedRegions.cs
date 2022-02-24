using CodingProblems.Interfaces;
using System;
using System.Linq;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class SurroundedRegions : IExecution
	{
		public MethodEnums Name => MethodEnums.SurroundedRegions;

		public void Execute()
		{
			Console.WriteLine("Given an m x n matrix board containing 'X' and 'O', capture all regions that are 4-directionally surrounded by 'X'." +
				"A region is captured by flipping all 'O's into 'X's in that surrounded region.");
			Console.WriteLine("Enter the Row Size");
			var rowsSize = int.Parse(Console.ReadLine());
			var jaggedArray = new char[rowsSize][];
			for (int i = 0; i < rowsSize; i++)
			{
				jaggedArray[i] = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None).Select(x => char.Parse(x)).ToArray();
			}
			Solve(jaggedArray);
			Console.WriteLine("Result");
			for (int i = 0; i < rowsSize; i++)
			{
				for (int j = 0; j < rowsSize; j++)
				{
					Console.Write(jaggedArray[i][j] + " ");
				}
				Console.WriteLine();
			}
		}

		public void Solve(char[][] board)
		{
			var rows = board.Length;
			var cols = board[0].Length;

			int i = 0, j = 0;
			for (i = 0; i < rows; i++)
			{
				for (j = 0; j < cols; j++)
				{
					if (board[i][j] == 'O' && ((i == 0 || i == rows - 1) || (j == 0 || j == cols - 1)))
					{
						capture(i, j, rows, cols, board);
					}
				}
			}

			for (i = 0; i < rows; i++)
			{
				for (j = 0; j < cols; j++)
				{
					if (board[i][j] == 'O')
					{
						board[i][j] = 'X';
					}
				}
			}
			for (i = 0; i < rows; i++)
			{
				for (j = 0; j < cols; j++)
				{
					if (board[i][j] == 'T')
					{
						board[i][j] = 'O';
					}
				}
			}
		}

		private void capture(int r, int c, int rows, int cols, char[][] board)
		{
			if (r < 0 || c < 0 || r == rows || c == cols || board[r][c] != 'O')
			{
				return;
			}
			board[r][c] = 'T';
			capture(r + 1, c, rows, cols, board);
			capture(r - 1, c, rows, cols, board);
			capture(r, c + 1, rows, cols, board);
			capture(r, c - 1, rows, cols, board);
		}
	}
}
