using ALGOPRACTICE.Models;
using System;
using System.Linq;

namespace ALGOPRACTICE
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            var solution = new Solution();
            //string brackets = "()))((";
            //var result = solution.MinAddToMakeValid(brackets);
            //var digits = new int[] { 9, 9 };
            //var result = solution.PlusOne(digits);
            // set up a tree with tree 2 beacuse it accepts string
            /*
             (D)
            /   \
           (B) (E)
            /\   \
           (A)(C) (F)
             */
            //TreeNode2 root = new TreeNode2(val: "D");
            //Tree2 tree = new Tree2(root);

            //tree.Root.left = new TreeNode2("B");
            //tree.Root.right = new TreeNode2("E");
            //tree.Root.left.left = new TreeNode2("A");
            //tree.Root.left.right = new TreeNode2("C");
            //tree.Root.right.right = new TreeNode2("F");

            //var solution2 = new Solution2();
            //var preResult = solution2.PreorderTraversal(tree.Root);
            //var inResult = solution2.InorderTraversal(tree.Root);
            //var postResult = solution2.PostorderTraversal(tree.Root);
            //Console.WriteLine("Pre Order result");
            //Console.WriteLine(string.Join(",", preResult.ToList()));
            //Console.WriteLine("In Order result");
            //Console.WriteLine(string.Join(",", inResult.ToList()));
            //Console.WriteLine("Post Order result");
            //Console.WriteLine(string.Join(",", postResult.ToList()));

            //MyHashMap myHashMap = new MyHashMap();
            //myHashMap.Put(1, 1); // The map is now [[1,1]]
            //myHashMap.Put(2, 2); // The map is now [[1,1], [2,2]]
            //myHashMap.Get(1);    // return 1, The map is now [[1,1], [2,2]]
            //myHashMap.Get(3);    // return -1 (i.e., not found), The map is now [[1,1], [2,2]]
            //myHashMap.Put(2, 1); // The map is now [[1,1], [2,1]] (i.e., update the existing value)
            //myHashMap.Get(2);    // return 1, The map is now [[1,1], [2,1]]
            //myHashMap.Remove(2); // remove the mapping for 2, The map is now [[1,1]]
            //myHashMap.Get(2);    // return -1 (i.e., not found), The map is now [[1,1]]

            //int noOfQueries =  Convert.ToInt32(Console.ReadLine());

            //if (noOfQueries > 0)
            //{
            //    var heap = new MyMinHeap();
            //    for(int i = 0; i < noOfQueries; i++)
            //    {
            //        string commandString = Console.ReadLine();
            //        if (!string.IsNullOrWhiteSpace(commandString))
            //        {
            //            var commandArray = commandString.Split(' ');
            //            int command = Convert.ToInt32(commandArray[0]);
            //            int data = 0;

            //            if (commandArray.Length > 1)
            //            {
            //                data = Convert.ToInt32(commandArray[1]);
            //            }

            //            switch (command)
            //            {
            //                case 1:
            //                    heap.Insert(data);
            //                    break;
            //                case 2:
            //                    heap.Remove(data);
            //                    break;
            //                case 3:
            //                    var result = heap.GetMinimumValue();
            //                    if (result != null)
            //                    {
            //                        Console.WriteLine(result.ToString());
            //                    }
            //                    break;
            //                default:
            //                    break;
            //            }
            //        }
            //    }
            //}

            //var nums = new int[] { 2, 5, 1, 3, 4 };
            //int inversionCount = 0;
            //var countingInversion = new CountingInversion();
            //var result = countingInversion.SortArrayAndCountingInversion(nums);
            //var soretdArray = result.Item1;
            //var countOfInversion = result.Item2;
            //var nums = new int[] { 5, 2, 3, 1 };
            //var quick = new MyQuickSort();
            //var result = quick.QuickSort(nums);

            var nums = new int[] { 2, 7, 11, 15 };
            var sol = new Solution();
            int target = 9;
            sol.TwoSum(nums, target);
        }
    }
}
