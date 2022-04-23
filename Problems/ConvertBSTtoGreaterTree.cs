using CodingProblems.Enums;
using CodingProblems.Interfaces;
using System;
using static CodingProblems.Enums.MethodEnum;

namespace CodingProblems.Problems
{
	public class ConvertBSTtoGreaterTree : IExecution
	{
		public int currentFee = 0;
		public MethodEnums Name => MethodEnums.ConvertBSTtoGreaterTree;

		public void Execute() // Leet Code 538
		{
			Console.WriteLine("Given the root of a Binary Search Tree (BST), convert it to a Greater Tree such that every key of the original BST is" +
				"changed to the original key plus the sum of all keys greater than the original key in BST. As a reminder, a binary search tree is a" +
				"tree that satisfies these constraints: " +
				"The left subtree of a node contains only nodes with keys less than the node's key. " +
				"The right subtree of a node contains only nodes with keys greater than the node's key." +
				"Both the left and right subtrees must also be binary search trees.");

			var head = new TreeNode(4);
			head.left = new TreeNode(1);
			head.right = new TreeNode(6);
			head.left.left = new TreeNode(0);
			head.left.right = new TreeNode(2);
			head.left.right.right = new TreeNode(3);
			head.right.left = new TreeNode(5);
			head.right.right = new TreeNode(7);
			head.right.right.right = new TreeNode(8);
			ConvertBST(head);
		}

		public TreeNode ConvertBST(TreeNode root)
		{
			if (root == null)
			{
				return null;
			}
			if (root.right != null)
			{
				ConvertBST(root.right);
			}
			currentFee += root.val;
			root.val = currentFee;
			if (root.left != null)
			{
				ConvertBST(root.left);
			}
			return root;
		}
	}

}
