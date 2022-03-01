using CodingProblems.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class MaximalEvents : IExecution
	{
		public MethodEnums Name => MethodEnums.MaximalEvents;

		public void Execute()
		{
			Console.WriteLine("Given 2 array of integers, one consist of positions which the company approaches the college and second one consist of duration that company spend on the college." +
				"There should be only one company can be at a time period.We need to find maximize the number of companies bring to college");
			Console.WriteLine("Enter the Position Array");
			var positions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None).Select(x => Int32.Parse(x)).ToArray();
			Console.WriteLine("Enter the Duration Array");
			var durations = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None).Select(x => Int32.Parse(x)).ToArray();
			var model = ModelBuild(positions, durations);
			Console.WriteLine("Maximum Number Of Events: " + MaxDisjointIntervals(model));
		}
		
		public List<Pair> ModelBuild(int[] pos, int[] duration)
		{
			var count = pos.Length;
			var list = new List<Pair>();
			for (int i = 0; i < count; i++)
			{
				list.Add(new Pair(pos[i], duration[i]));
			}
			list.Sort((x, y) =>
			{
				if (x.end > y.end)
					return 1;
				else if (x.end == y.end)
					return 0;
				return -1;
			});
			return list;
		}

		public int MaxDisjointIntervals(IList<Pair> list)
		{
			// End point of first interval
			int r1 = list[0].end;
			int count = 1;

			for (int i = 1; i < list.Count; i++)
			{
				int l1 = list[i].begin;
				int r2 = list[i].end;

				if (l1 >= r1)
				{
					r1 = r2;
					count++;
				}
			}
			return count;
		}
	}
	public class Pair
	{
		public int begin, end = 0;
		public Pair(int f, int s)
		{
			begin = f;
			end = f + s;
		}
	}
}
