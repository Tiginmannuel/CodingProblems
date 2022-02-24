using CodingProblems.Interfaces;
using System;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class CircularQueue : IExecution
	{
		public MethodEnums Name => MethodEnums.CircularQueue;

		public void Execute()
		{
			var myQueue = new MyCircularQueue(10);
			var request = 1;
			while (request == 1)
			{
				Console.WriteLine("Select Operation that need to Run over the Circular Queue (FIFO)");
				Console.WriteLine("1. Insert Into Queue");
				Console.WriteLine("2. Remove From the Queue");
				Console.WriteLine("3. First Value");
				Console.WriteLine("4. Last Value");
				Console.WriteLine("5. Check Is Queue Is Full");
				Console.WriteLine("6. Check Is Queue Is Empty");
				var item = Console.ReadLine();
				int functionNumber;
				if (int.TryParse(item, out functionNumber))
				{
					switch (functionNumber)
					{
						case 1:
							Console.WriteLine("Value of the Node");
							var number = int.Parse(Console.ReadLine());
							myQueue.EnQueue(number);
							break;
						case 2:
							ConvertBoolToMessage(myQueue.DeQueue());
							break;
						case 3:
							Console.WriteLine(myQueue.Front());
							break;
						case 4:
							Console.WriteLine(myQueue.Rear());
							break;
						case 5:
							ConvertBoolToBooleanString(myQueue.IsFull());
							break;
						case 6:
							ConvertBoolToBooleanString(myQueue.IsEmpty());
							break;
						default:
							break;
					}
					Console.WriteLine("Do you want to continue the Circular Program? If Yes Press 1 else 0");
					request = int.Parse(Console.ReadLine());
				}
				else
				{
					request = 0;
				}
			}
		}

		private void ConvertBoolToMessage(bool value)
		{
			if (value)
			{
				Console.WriteLine("Success");
			}
			else
			{
				Console.WriteLine("Failed");
			}
		}

		private void ConvertBoolToBooleanString(bool value)
		{
			if (value)
			{
				Console.WriteLine("Yes");
			}
			else
			{
				Console.WriteLine("No");
			}
		}
	}

	public class MyCircularQueue
	{
		public int Space { get; set; }
		public ListNode Left { get; set; }
		public ListNode Right { get; set; }
		public MyCircularQueue(int space)
		{
			Space = space;
			Left = new ListNode(0, null, null);
			Right = new ListNode(0, null, Left);
			Left.Next = Right;
		}

		public bool EnQueue(int value)
		{
			if (IsFull())
			{
				return false;
			}
			var current = new ListNode(value, Right, Right.Prev);
			Right.Prev.Next = current;
			Right.Prev = current;
			Space--;
			return true;
		}

		public bool DeQueue()
		{
			if (IsEmpty())
			{
				return false;
			}
			Left.Next = Left.Next.Next;
			Left.Next.Prev = Left;
			Space++;
			return true;

		}

		public int Front()
		{
			if (IsEmpty())
			{
				return -1;
			}
			return Left.Next.Value;
		}

		public int Rear()
		{
			if (IsEmpty())
			{
				return -1;
			}
			return Right.Prev.Value;
		}

		public bool IsEmpty()
		{
			return Left.Next == Right;
		}

		public bool IsFull()
		{
			return Space == 0;
		}
	}

	public class ListNode
	{
		public ListNode(int val, ListNode next, ListNode prev)
		{
			Value = val;
			Next = next;
			Prev = prev;
		}
		public int Value { get; set; }
		public ListNode Next { get; set; }
		public ListNode Prev { get; set; }
	}
}
