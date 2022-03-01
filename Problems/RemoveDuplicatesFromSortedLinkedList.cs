using CodingProblems.Interfaces;
using System;
using System.Linq;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class RemoveDuplicatesFromSortedLinkedList : IExecution
	{
		public MethodEnums Name => MethodEnums.RemoveDuplicatesFromSortedLinkedList;

		public void Execute()
		{
			Console.WriteLine("Given the head of a sorted linked list, delete all duplicates such that each element appears only once. Return the linked list sorted as well.");
			Console.WriteLine("Enter Array");
			var nums = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None).Select(x => Int32.Parse(x)).ToArray();
			ListNode head = new ListNode(nums[0], null);
			for (int i = 1; i < nums.Length; i++)
			{
				head.next = new ListNode(nums[i], null);
			}
			DeleteDuplicates(head);
		}

		public void DeleteDuplicates(ListNode head)
		{
			while (head != null)
			{
				if (head.next != null)
				{
					if (head.val == head.next.val)
					{
						head.next = head.next.next;
					}
					else
					{
						Console.WriteLine(head.val);
						head = head.next;
					}
				}
				else
				{
					Console.WriteLine(head.val);
					break;
				}
			}
		}

		public class ListNode
		{
			public int val;
			public ListNode next;
			public ListNode(int val = 0, ListNode next = null)
			{
				this.val = val;
				this.next = next;
			}
		}
	}
}
