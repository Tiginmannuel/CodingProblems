using CodingProblems.Interfaces;
using System;
using System.Linq;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class QuickSort : IExecution
	{
		public MethodEnums Name => MethodEnums.QuickSort;

		public void Execute()
		{
			Console.WriteLine("Enter Array to Quick Sort!");
			var array = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None).Select(x => Int32.Parse(x)).ToArray();
			QuickSortFn(array, 0, array.Length - 1);
			for (int j = 0; j < array.Length; j++)
			{
				Console.WriteLine(array[j]);
			}
		}

		public void QuickSortFn(int[] arr, int low, int high)
		{
			if (low < high)
			{
				var pi = MakePartition(arr, low, high);

				QuickSortFn(arr, low, pi - 1);
				QuickSortFn(arr, pi + 1, high);
			}
		}

		private int MakePartition(int[] arr, int low, int high)
		{
			int pivot = arr[high];
			int i = low - 1;

			for (int j = low; j <= high - 1; j++)
			{
				if (arr[j] < pivot)
				{
					i++;
					if (i >= 0)
					{
						var temp = arr[i];
						arr[i] = arr[j];
						arr[j] = temp;
					}
				}
			}
			var cons = arr[i + 1];
			arr[i + 1] = arr[high];
			arr[high] = cons;
			return (i + 1);
		}
	}
}
