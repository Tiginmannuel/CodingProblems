using CodingProblems.Interfaces;
using System;
using System.Linq;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
    public class ContainerWithMostWater : IExecution // Leet Code 11
    {
        public MethodEnums Name => MethodEnums.ContainerWithMostWater;

        public void Execute()
        {
            Console.WriteLine("You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i])." +
                "Find two lines that together with the x - axis form a container, such that the container contains the most water." +
                "Return the maximum amount of water a container can store.");
            var array = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None).Select(x => Int32.Parse(x)).ToArray();
            Console.WriteLine(MaxArea(array));
        }

        public int MaxArea(int[] height)
        {
            int l = 0;
            int r = height.Count() - 1;
            int area = 0;

            while (l < r)
            {
                area = Math.Max(area,
                            Math.Min(height[l], height[r]) * (r - l));

                if (height[l] < height[r])
                    l += 1;

                else
                    r -= 1;
            }
            return area;
        }
    }
}
