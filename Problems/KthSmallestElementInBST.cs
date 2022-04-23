using CodingProblems.Interfaces;
using System;
using System.Linq;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class KthSmallestElementInBST : IExecution
	{
		private static int number = 0;
		private static int count = 0;
		public MethodEnums Name => MethodEnums.KthSmallestElementInBST;

		public void Execute() // Leet Code 230
		{
			Console.WriteLine("Given the root of a binary search tree, and an integer k, return the kth smallest value (1-indexed) of all the values of the nodes in the tree.");

			Console.WriteLine("Enter the KthValue");
			var k = int.Parse(Console.ReadLine());
			var head = new TreeNode(5);
			head.left = new TreeNode(3);
			head.right = new TreeNode(6);
			head.left.left = new TreeNode(2);
			head.left.right = new TreeNode(4);
			head.right.left = null;
			head.right.right = null;
			head.left.left.left = new TreeNode(1);

			int result = KthSmallest(head, k);
			Console.WriteLine("Kth Smallest Element in a BST " + result);
		}

		public int KthSmallest(TreeNode root, int k)
		{
			count = k;
			helperFnToFindKthElement(root);
			return number;
		}

		public void helperFnToFindKthElement(TreeNode n)
		{
			if (n.left != null) helperFnToFindKthElement(n.left);
			count--;
			if (count == 0)
			{
				number = n.val;
				return;
			}
			if (n.right != null) helperFnToFindKthElement(n.right);
		}
	}
}
