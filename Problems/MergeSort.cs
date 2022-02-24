using CodingProblems.Interfaces;
using System;
using System.Linq;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class MergeSort : IExecution
	{
		public MethodEnums Name => MethodEnums.QuickSort;

		public void Execute()
		{
			Console.WriteLine("Enter Array to Merge Sort!");
			var array = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None).Select(x => Int32.Parse(x)).ToArray();
			Sort(array, 0, array.Length - 1);
			for (int j = 0; j < array.Length; j++)
			{
				Console.WriteLine(array[j]);
			}
		}

		public void Sort(int[] arr, int l, int r)
		{
			if (l < r)
			{
				int m = (l + (r - 1)) / 2;

				Sort(arr, l, m);
				Sort(arr, m + 1, r);

				Merge(arr, l, m, r);
			}
		}

		public void Merge(int[] arr, int l, int m, int r)
		{
			int n1 = m - l + 1;
			int n2 = r - m;

			// Create temp arrays
			int[] L = new int[n1];
			int[] R = new int[n2];
			int i, j;

			// Copy data to temp arrays
			for (i = 0; i < n1; ++i)
				L[i] = arr[l + i];
			for (j = 0; j < n2; ++j)
				R[j] = arr[m + 1 + j];

			// Merge the temp arrays

			// Initial indexes of first
			// and second subarrays
			i = 0;
			j = 0;

			int k = l;
			while (i < n1 && j < n2)
			{
				if (L[i] <= R[j])
				{
					arr[k] = L[i];
					i++;
				}
				else
				{
					arr[k] = R[j];
					j++;
				}
				k++;
			}

			// Copy remaining elements
			// of L[] if any
			while (i < n1)
			{
				arr[k] = L[i];
				i++;
				k++;
			}

			// Copy remaining elements
			// of R[] if any
			while (j < n2)
			{
				arr[k] = R[j];
				j++;
				k++;
			}
		}
	}
}
