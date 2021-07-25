using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALGOPRACTICE
{
    public class Tree2
    {
        public TreeNode2 Root { get; set; }
        public Tree2(TreeNode2 root)
        {
            Root = root;
        }
    }
    public class TreeNode2
    {
        public string val;
        public TreeNode2 left;
        public TreeNode2 right;
        public TreeNode2(string val = "", TreeNode2 left = null, TreeNode2 right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    class Solution2
    {

        public IList<string> PreorderTraversal(TreeNode2 root)
        {
            var result = new List<string>();
            try
            {
                //Create a helper function for traversing the tree. Creating it withing this method allows it access to the result list
                void Traverse(TreeNode2 node)
                {
                    if (node == null)
                    {
                        return;
                    }
                    //Visit node and print or obtain result
                    result.Add(node.val);

                    //traverse left sub tree
                    Traverse(node.left);

                    //traverse right sub tree
                    Traverse(node.right);
                }
                //call the travesre helper function
                Traverse(root);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return result;
        }

        public IList<string> InorderTraversal(TreeNode2 root)
        {
            var result = new List<string>();
            try
            {
                //Create a helper function for traversing the tree. Creating it withing this method allows it access to the result list
                void Traverse(TreeNode2 node)
                {
                    if (node == null)
                    {
                        return;
                    }

                    //traverse left sub tree
                    Traverse(node.left);

                    //Visit node and print or obtain result
                    result.Add(node.val);

                    //traverse right sub tree
                    Traverse(node.right);
                }
                //call the travesre helper function
                Traverse(root);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return result;
        }

        public IList<string> PostorderTraversal(TreeNode2 root)
        {
            var result = new List<string>();
            try
            {
                //Create a helper function for traversing the tree. Creating it withing this method allows it access to the result list
                void Traverse(TreeNode2 node)
                {
                    if (node == null)
                    {
                        return;
                    }

                    //traverse left sub tree
                    Traverse(node.left);

                    //traverse right sub tree
                    Traverse(node.right);


                    //Visit node and print or obtain result
                    result.Add(node.val);
                }
                //call the travesre helper function
                Traverse(root);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return result;
        }

    }
}
