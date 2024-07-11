using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeGeneration
{
    class TreeNode
    {
        public string Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(string value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    class BinaryTree
    {
        public TreeNode Root { get; set; }

        public void Insert(TreeNode parentNode, string value, bool isLeft)
        {
            if (isLeft)
            {
                parentNode.Left = new TreeNode(value);
            }
            else
            {
                parentNode.Right = new TreeNode(value);
            }
        }

        public TreeNode GetNode(TreeNode node, string path)
        {
            if (node == null) return null;

            if (string.IsNullOrEmpty(path)) return node;

            if (path.Equals("Root", StringComparison.OrdinalIgnoreCase))
                return Root;

            if (path[0] == 'L' || path[0] == 'l')
                return GetNode(node.Left, path.Substring(1));
            else if (path[0] == 'R' || path[0] == 'r')
                return GetNode(node.Right, path.Substring(1));
            else
                return null;
        }
    }
}
