using CodingProblems.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems
{
	public class Executer
	{
		private readonly IEnumerable<IExecution> _providers;
		public Executer(IEnumerable<IExecution> providers)
		{
			_providers = providers;
		}

		public void Run()
		{
			var request = 1;
			while (request == 1)
			{
				Console.WriteLine("Select Program that need to run");
				Console.WriteLine("1. Quick Sort");
				Console.WriteLine("2. Base Child Class");
				Console.WriteLine("3. Merge Sort");
				Console.WriteLine("4. Minimum Step To One - Memorization");
				Console.WriteLine("5. Minimum Step To One - BottumUp");
				Console.WriteLine("6. Coin Change Minimum Problem");
				Console.WriteLine("7. Coin Change Maximum Problem");
				Console.WriteLine("8. Delete And Earn");
				Console.WriteLine("9. Circular Queue");
				Console.WriteLine("10. Minimum Days To eat N Oranges");
				Console.WriteLine("11. House Robber");
				Console.WriteLine("12. Maximum Product Subarray");
				Console.WriteLine("13. Largest Number From Given Array");
				Console.WriteLine("14. SubArray Sum Equal K");
				Console.WriteLine("15. Two Sum");
				Console.WriteLine("16. Longest Substring Without Repeating Characters");
				Console.WriteLine("17. Best Time to Buy and Sell Stock");
				Console.WriteLine("18. Surrounded Regions");
				Console.WriteLine("19. Target Sum");
				Console.WriteLine("20. Maximal Events");
				Console.WriteLine("21. Minimum Domino Rotations For Equal Row");
				Console.WriteLine("22. Remove Duplicates from Sorted List");
				Console.WriteLine("Choose Anyone Of these");
				var item = Console.ReadLine();
				MethodEnums functionNumber;
				if (Enum.TryParse(item, out functionNumber))
				{
					var provider = _providers.FirstOrDefault(x => x.Name == functionNumber);
					if (provider != null)
					{
						provider.Execute();
						Console.WriteLine("Do you want to continue? If Yes Press 1 else 0");
					}
					else
					{
						Console.WriteLine("You choose wrong option, Do you want to continue? If Yes Press 1 else 0");
					}
					request = int.Parse(Console.ReadLine());

				}
				else
				{
					request = 0;
				}
			}
		}
	}
}
