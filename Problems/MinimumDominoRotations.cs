using CodingProblems.Interfaces;
using System;
using System.Linq;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class MinimumDominoRotations : IExecution
	{
		public MethodEnums Name => MethodEnums.MinimumDominoRotations;

		public void Execute() // Leet Code 1007
        {
            Console.WriteLine("In a row of dominoes, tops[i] and bottoms[i] represent the top and bottom halves of the ith domino." +
                "(A domino is a tile with two numbers from 1 to 6 - one on each half of the tile.)" +
                "We may rotate the ith domino, so that tops[i] and bottoms[i] swap values." +
                "Return the minimum number of rotations so that all the values in tops are the same, or all the values in bottoms are the same." +
                "If it cannot be done, return -1.");
            Console.WriteLine("Enter the Top Array");
            var tops = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None).Select(x => Int32.Parse(x)).ToArray();
            Console.WriteLine("Enter the Bottom Array");
            var bottoms = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None).Select(x => Int32.Parse(x)).ToArray();
            Console.WriteLine("Maximum Number Of Events: " + MinDominoRotations(tops, bottoms));
        }

        private int MinDominoRotations(int[] tops, int[] bottoms)
        {
            int up = tops[0];
            int down = bottoms[0];
            var dummy = new int[2] { up, down };
            foreach (var val in dummy)
            {
                int missingT = 0;
                int missingB = 0;
                for (int i = 0; i < tops.Length; i++)
                {
                    if (tops[i] != val && bottoms[i] != val)
                    {
                        break;
                    }
                    if (tops[i] != val)
                    {
                        missingT += 1;
                    }
                    if (bottoms[i] != val)
                    {
                        missingB += 1;
                    }
                    if (i == (tops.Length - 1))
                    {
                        return Math.Min(missingT, missingB);
                    }
                }
            }
            return -1;
        }
    }
}
