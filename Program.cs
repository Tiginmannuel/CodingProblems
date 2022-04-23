using CodingProblems.Interfaces;
using CodingProblems.Problems;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace CodingProblems
{
	class Program
	{
		public static void Main()
		{
			var serviceProvider = new ServiceCollection()
				.AddSingleton<IExecution, QuickSort>()
				.AddSingleton<IExecution, Base_ChildClass>()
				.AddSingleton<IExecution, MergeSort>()
				.AddSingleton<IExecution, MinimumStepToOne_Memoization>()
				.AddSingleton<IExecution, MinimumStepToOne_BottomUp>()
				.AddSingleton<IExecution, MinCoinChange>()
				.AddSingleton<IExecution, MaxCoinChange>()
				.AddSingleton<IExecution, DeleteAndEarn>()
				.AddSingleton<IExecution, CircularQueue>()
				.AddSingleton<IExecution, MinimumDaysToEatNOrange>()
				.AddSingleton<IExecution, HouseRobber>()
				.AddSingleton<IExecution, MaximumProductSubArray>()
				.AddSingleton<IExecution, LargestNumberFromArray>()
				.AddSingleton<IExecution, SubArraySumEqualsK>()
				.AddSingleton<IExecution, TwoSums>()
				.AddSingleton<IExecution, LongestSubstringWithoutRepeatingChar>()
				.AddSingleton<IExecution, BestTimeToBuyAndSell>()
				.AddSingleton<IExecution, SurroundedRegions>()
				.AddSingleton<IExecution, TargetSum>()
				.AddSingleton<IExecution, MaximalEvents>()
				.AddSingleton<IExecution, MinimumDominoRotations>()
				.AddSingleton<IExecution, RemoveDuplicatesFromSortedLinkedList>()
				.AddSingleton<IExecution, ShortestSubStringWithAllAlphabetsInOrder>()
				.AddSingleton<IExecution, ChampagneTower>()
				.AddSingleton<IExecution, LongestPalindromicSubstring>()
				.AddSingleton<IExecution, CountingBits>()
				.AddSingleton<IExecution, KthSmallestElementInBST>()
				.AddSingleton<IExecution, ZigzagConversion>()
				.AddSingleton<IExecution, ReverseInteger>()
				.AddSingleton<IExecution, ConvertBSTtoGreaterTree>()
				.AddSingleton<IExecution, ContainerWithMostWater>()
				.BuildServiceProvider();
			var result = serviceProvider.GetService<IEnumerable<IExecution>>();
			new Executer(result).Run();
		}
	}
}
