using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALGOPRACTICE
{
    public class Tee
    {
        public TreeNode Root { get; set; }
        public Tee(TreeNode root)
        {
            Root = root;
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class StackState
    {
        public bool LeftVisited { get; set; }
        public bool RightVisited { get; set; }
        public TreeNode Node { get; set; }
        public StackState(TreeNode node)
        {
            this.Node = node;
        }
    }
    public class QueueState
    {
        public TreeNode Node { get; set; }
        public int Level { get; set; }
    }
    class Solution
    {
        public int EvalRPN(string[] tokens)
        {
            int total = 0;
            int result = 0;
            Stack<int> stack = new Stack<int>();
            int firstNumber = 0;
            int secondNumber = 0;
            try
            {
                foreach (var x in tokens)
                {
                    // the pop of a stack always returns the last value placed into the stack. Therefore a stack will always return the second value
                    //first before the first value so that's why we asign the second value first
                    //We carry out an operation store it result and move on to the next numebr or operator
                    switch (x)
                    {
                        case "*":
                            secondNumber = stack.Pop();
                            firstNumber = stack.Pop();
                            result = firstNumber * secondNumber;
                            stack.Push(result);
                            break;
                        case "+":
                            secondNumber = stack.Pop();
                            firstNumber = stack.Pop();
                            result = firstNumber + secondNumber;
                            stack.Push(result);
                            break;
                        case "-":
                            secondNumber = stack.Pop();
                            firstNumber = stack.Pop();
                            result = firstNumber - secondNumber;
                            stack.Push(result);
                            break;
                        case "/":
                            secondNumber = stack.Pop();
                            firstNumber = stack.Pop();
                            result = Convert.ToInt32(firstNumber / secondNumber);
                            stack.Push(result);
                            break;
                        default:
                            stack.Push(Convert.ToInt32(x));
                            break;

                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            //the final value in the stack is the total of all operations
            total = stack.Pop();
            return total;
        }
        public int MinAddToMakeValid(string s)
        {
            int noOfParenthesesToAdd = 0;
            int countOfOpenParentheses = 0;
            int countOfClosedParentheses = 0;
            Stack<char> stack = new Stack<char>();
            try
            {
                //first we loop through and try and remove all balanced parenthes and later we remove the remaining unbalance parenthes from thes stack
                //and treat them accordingly
                foreach (var c in s)
                {
                    if (stack.Count == 0)
                    {
                        stack.Push(c);
                    }
                    else
                    {
                        var valueOnTopOfStack = stack.Peek();
                        if (c != valueOnTopOfStack)
                        {
                            //if c ==) then valueOnTopOfStack = ( hence we have () a balance expression
                            if (c == ')')
                            {
                                stack.Pop();
                                continue;
                            }
                            else
                            {
                                //at this point we have a situation like this c =( and valueOnTopOfStack = ) since stack is lifo i.e last in first out
                                //the origibal string order is )( i,e an unbalanced string
                                stack.Push(c);
                            }
                        }
                        else
                        {
                            //the value on top of stack and curent chartater or bracket c are the same possibly (( or )) therefor they are not balanced.
                            stack.Push(c);
                        }
                    }
                }
                //After removing all the balanced brackets i.e() above we now loop through the brackets in the stack to get the number of open
                //and closed barcket so that we can get the difference and determine how many brackets to add
                while (stack.Count > 0)
                {
                    var currentBracket = stack.Pop();
                    if (currentBracket == '(')
                    {
                        countOfOpenParentheses++;
                    }
                    else
                    {
                        countOfClosedParentheses++;
                    }
                }
                noOfParenthesesToAdd = countOfOpenParentheses + countOfClosedParentheses;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return noOfParenthesesToAdd;
        }
        public int[] PlusOne(int[] digits)
        {
            if (digits.SequenceEqual(new int[] { 9 }))
            {
                return new int[] { 1, 0 };
            }
            int lastDigit = 0;
            if(digits.Length > 0)
            {
                lastDigit = digits[digits.Length - 1];
            }
            if (lastDigit < 9)
            {
                digits[digits.Length - 1] = digits[digits.Length - 1] + 1;
                return digits;
            }
            else
            {
                var segment = new ArraySegment<int>(digits, 0, digits.Length - 2);
                var subTotal = PlusOne(segment.ToArray());
                var result = subTotal.Concat(new int[] { 0 }).ToArray();
                return result;
            }
        }

        public IList<int> PreorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            try
            {
                //Create a helper function for traversing the tree. Creating it withing this method allows it access to the result list
                void Traverse(TreeNode node)
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

        public IList<int> InorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            try
            {
                //Create a helper function for traversing the tree. Creating it withing this method allows it access to the result list
                void Traverse(TreeNode node)
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

        public IList<int> PostorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            try
            {
                //Create a helper function for traversing the tree. Creating it withing this method allows it access to the result list
                void Traverse(TreeNode node)
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

        public IList<int> PreorderTraversalWithStack(TreeNode root)
        {
            var result = new List<int>();
            var stack = new Stack<StackState>();
            TreeNode currentNode;
            StackState state;
            try
            {
                if (root == null)
                {
                    return result;
                }

                currentNode = root;
                state = new StackState(currentNode);
                stack.Push(state);
                //we outpu node values as we visit them in pre order
                result.Add(currentNode.val);

                while (currentNode != null)
                {
                    //if the current node has a left node and the left node has not been visisted
                    if (currentNode.left != null && !state.LeftVisited)
                    {
                        state.LeftVisited = true;
                        currentNode = currentNode.left;
                        result.Add(currentNode.val);
                        state = new StackState(currentNode);
                        stack.Push(state);
                    }
                    //if the current node has a right node and the right node has not been visisted
                    else if (currentNode.right != null && !state.RightVisited)
                    {
                        state.RightVisited = true;
                        currentNode = currentNode.right;
                        result.Add(currentNode.val);
                        state = new StackState(currentNode);
                        stack.Push(state);
                    }
                    //the current node has no left or right node time to return and start poping previousy visited nodes form the stack
                    else 
                    {
                        //remove the last node which has no left or right nodes
                        stack.Pop();
                        //if teh stack contains other nodes times to go back and explore them
                        if (stack.Count > 0)
                        {
                            state = stack.Peek();
                            currentNode = state.Node;
                        }
                        else
                        {
                            //at this point the stack is empty all previously visisted nodes have been explored
                            currentNode = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return result;
        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            int lastNodeLevel = 0;
            var currentLevelList = new List<int>();
            try
            {
                QueueState currentNodeState;
                var queue = new Queue<QueueState>();
                // start by queueing the roort node
                queue.Enqueue(new QueueState { Node = root, Level = 0 });

                //while queue is not empty
                while (queue.Count > 0)
                {
                    currentNodeState = queue.Dequeue();
                    if (currentNodeState.Level == lastNodeLevel)
                    {
                        currentLevelList.Add(currentNodeState.Node.val);
                    }
                    else
                    {
                        //  result.AddRange(currentLevelList);
                        result.AddRange(new List<IList<int>> { currentLevelList });
                        currentLevelList = new List<int>();
                        currentLevelList.Add(currentNodeState.Node.val);
                        lastNodeLevel = currentNodeState.Level;
                    }
                    //Queue the left side of current node, ensure yiu increase levl by 1 since the currently queue node is the child of the current node
                    //being operated on
                    if (currentNodeState.Node.left != null)
                    {
                        queue.Enqueue(new QueueState { Node = currentNodeState.Node.left, Level = currentNodeState.Level + 1 });
                    }
                    //queue the right side of current node
                    if (currentNodeState.Node.right != null)
                    {
                        queue.Enqueue(new QueueState { Node = currentNodeState.Node.right, Level = currentNodeState.Level + 1 });
                    }
                }
                //at the end of the queue iteration it is possible to have some results that were not added to the main list
                if (currentLevelList.Count > 0)
                {
                    result.AddRange(new List<List<int>> { currentLevelList });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return result;
        }
        public int LongestConsecutiveWithListStore(int[] nums)
        {
            int noOfLongestConsecutive = 0;
            var dict = new Dictionary<int, int>();
            List<int> longestSequence = new List<int>();
            List<int> currentSequence = new List<int>();
            try
            {
                //load the dictionary.this is O(n)
                for (int i=0; i < nums.Length; i++)
                {
                    if (!dict.ContainsKey(nums[i]))
                    {
                        //Add the number as the key and the index as the value
                        dict.TryAdd(nums[i], i);
                    }
                }
                foreach(var num in dict.Keys)
                {
                    currentSequence = new List<int>();
                    var currentNumber = num;

                    //do a O(1) consatnt time check to determine if the current number is part of sequence. the beauty of dictionary we get constant time access via the key
                    //this is only possible via index in an array but an array may not have consercutive value based on it index.. this is why we used a dictionary
                    //and then access it b y it key i.e it values/numbers in this case
                    while (dict.ContainsKey(currentNumber))
                    {
                        //Add current number to current list
                        currentSequence.Add(currentNumber);
                        //increament to next consecutive number e.g current number is 5 increment to 6
                        currentNumber++;
                    }
                    //since we looking for the longest sequence we compare if new sequence is greater than what was previously generated 
                    //and assign appropraitely
                    if (longestSequence.Count < currentSequence.Count)
                    {
                        longestSequence = currentSequence;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            noOfLongestConsecutive = longestSequence.Count;
            return noOfLongestConsecutive;
        }
        public int LongestConsecutive(int[] nums)
        {
            int lenghtOfLongestConsecutiveSequence = 0;
            var dict = new Dictionary<int, int>();

            int currentNumberGoingForward;
            int currentNumberGoingBackward;

            int currentSequenceStartIndex;

            try
            {
                //load the dictionary.this is O(n)
                for (int i = 0; i < nums.Length; i++)
                {
                    if (!dict.ContainsKey(nums[i]))
                    {
                        //Add the number as the key and the index as the value
                        dict.TryAdd(nums[i], i);
                    }
                }
                foreach (var num in nums)
                {
                    var currentNumber = num;
                    int currentSequenceCount = 0;
                    //setting the start index here is ok as it is a good place to start if tehr are no numbers lower
                    //you can use the start index and the lenght of the sequence to generate the numbers in the sequence if needed that's why i am setting it here
                    currentSequenceStartIndex = dict[currentNumber];

                    currentNumberGoingBackward = currentNumber - 1;
                    currentNumberGoingForward = currentNumber + 1;

                    //mark current nmber as seen and increase current sequence count
                    dict[currentNumber] = -1;
                    currentSequenceCount++;

                    //do a O(1) consatnt time check to determine if the current number is part of sequence. the beauty of dictionary we get constant time access via the key
                    //this is only possible via index in an array but an array may not have consercutive value based on it index.. this is why we used a dictionary
                    //and then access it b y it key i.e it values/numbers in this case
                    while (dict.ContainsKey(currentNumberGoingForward) && dict[currentNumberGoingForward] > - 1)
                    {
                        //set the current number as visited so that we don't count it again
                        dict[currentNumberGoingForward] = -1;
                        currentSequenceCount++;

                        //increament to next consecutive number e.g current number is 5 increment to 6
                        currentNumberGoingForward++;
                    }
                    while (dict.ContainsKey(currentNumberGoingBackward) && dict[currentNumberGoingBackward] > -1)
                    {
                        //since we are going backwards teh start index is flexible to change as the lower the number the better
                        currentSequenceStartIndex = dict[currentNumberGoingBackward];
                        //set the current number as visited so that we don't count it again
                        dict[currentNumberGoingBackward] = -1;
                        currentSequenceCount++;

                        //decrement to previous consecutive number e.g current number is 5 decrement to 4
                        currentNumberGoingBackward--;
                    }
                    //since we looking for the longest sequence we compare if new sequence is greater than what was previously generated 
                    //and assign appropraitely
                    if (lenghtOfLongestConsecutiveSequence < currentSequenceCount)
                    {
                        lenghtOfLongestConsecutiveSequence = currentSequenceCount;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return lenghtOfLongestConsecutiveSequence;
        }
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            try
            {
                // nums1 contains m element and n spaces or zeros technically it is of lenght m + n
                //in order to merge the two arrays in place we can start from thei end values and overwrite
                //nums1 from the end which will initially contain zeros. so intead of starting our merge in ascending order
                //i.e smallest numbers first we are actaully starting with the biggest numbers first

                int currentArrayOneEndIndex = m - 1;
                int currentArrayTwoEndIndex = n - 1;

                int currentArrayOnewWriteIndex = m + n - 1;

                for (int i = currentArrayOnewWriteIndex; i >= 0; i--)
                {
                    //it is expected that we may get to the end of the sceond array since it is smaller than the first array
                    //so we check and exist the loop once the second array values have been compared and writtern into the first array
                    if (currentArrayTwoEndIndex < 0)
                    {
                        break;
                    }
                    if (nums1[currentArrayOneEndIndex] > nums2[currentArrayTwoEndIndex])
                    {
                        // if value in array 1 is greater then insert into the current write location and decrement to the next spot before
                        //the next while loop iteration
                        nums1[i] = nums1[currentArrayOneEndIndex];
                        currentArrayOneEndIndex--;
                    }
                    else
                    {
                        //value in array 2 is greater so we insert and deceremnt pointers accordingly
                        nums1[i] = nums2[currentArrayTwoEndIndex];
                        currentArrayTwoEndIndex--;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        public int[] TwoSum(int[] nums, int target)
        {
            int[] result = null;
            try
            {
                if(nums == null || nums.Length <= 0)
                {
                    return null;
                }
                //to do without extra space we sort the array and use two pointers to get the required some
                //but this will fail on leetcode becasue sort changes the original index of some of the answers
                Array.Sort(nums);

                int leftIndex = 0;
                int rightIndex = nums.Length - 1;
                while(leftIndex < rightIndex)
                {
                    int leftElement = nums[leftIndex];
                    int rightElement = nums[rightIndex];
                    if (leftElement + rightElement == target )
                    {
                        result = new int[] { leftIndex, rightIndex };
                        return result;
                    }
                    else if (leftElement + rightElement < target)
                    {
                        // we need to move the left index towards the right to get a bigger result
                        leftIndex++;
                    }
                    else
                    {
                        //we need to move the right index to the left so that we get a smaller number. ALl this is possible
                        //beacuse we sorted the array earlier
                        rightIndex--;
                    }
                }
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
