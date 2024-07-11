using System;
using BinaryTreeGeneration;
namespace BinaryTreeApp
{

    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            Console.Write("Enter value for root node: ");
            string rootValue = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(rootValue)) rootValue = "None";
            tree.Root = new TreeNode(rootValue);

            AddChildren(tree.Root, tree);

            TreeNode currentNode = tree.Root;
            while (true)
            {
                Console.Write($"Current node value: {currentNode.Value}. Enter 'left' or 'right' to navigate, or 'exit' to finish: ");
                string direction = Console.ReadLine().ToLower();
                if (direction == "exit") break;

                if (direction == "left")
                {
                    if (currentNode.Left != null)
                    {
                        currentNode = currentNode.Left;
                    }
                    else
                    {
                        Console.WriteLine("Left branch is empty.");
                    }
                }
                else if (direction == "right")
                {
                    if (currentNode.Right != null)
                    {
                        currentNode = currentNode.Right;
                    }
                    else
                    {
                        Console.WriteLine("Right branch is empty.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'left', 'right', or 'exit'.");
                }
            }
        }

        static void AddChildren(TreeNode node, BinaryTree tree)
        {
            if (node == null || node.Value == "None") return;

            Console.Write($"Enter left branch value for node '{node.Value}' (or type 'None' to skip): ");
            string leftValue = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(leftValue)) leftValue = "None";
            if (leftValue != "None")
            {
                tree.Insert(node, leftValue, true);
                AddChildren(node.Left, tree);
            }

            Console.Write($"Enter right branch value for node '{node.Value}' (or type 'None' to skip): ");
            string rightValue = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(rightValue)) rightValue = "None";
            if (rightValue != "None")
            {
                tree.Insert(node, rightValue, false);
                AddChildren(node.Right, tree);
            }
        }
    }
}
