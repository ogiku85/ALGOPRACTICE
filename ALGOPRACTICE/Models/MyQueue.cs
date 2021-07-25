using System;
using System.Collections.Generic;
using System.Text;

namespace ALGOPRACTICE.Models
{
    public class MyQueue
    {

        /** Initialize your data structure here. */
        /*
Staqck is last in first out but if we bring items through one stack and take them out from the other stack i.e out storage by transfering data from the in stack to the out stack we get a fifo behaviout i.e first in first out which is the opposite of lifo teh stac's default behaviour
*/
        Stack<int> inStorage;
        Stack<int> outStorage;
        public MyQueue()
        {
            inStorage = new Stack<int>();
            outStorage = new Stack<int>();
        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            inStorage.Push(x);
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            //Check if out storage is empty and fill it up with items from in storage before popping from outstorage
            if (outStorage.Count == 0)
            {
                while(inStorage.Count > 0)
                {
                    outStorage.Push(inStorage.Pop());
                }
            }
            return outStorage.Pop();
        }

        /** Get the front element. */
        public int Peek()
        {
            //Check if out storage is empty and fill it up with items from in storage before popping from outstorage
            if (outStorage.Count == 0)
            {
                while (inStorage.Count > 0)
                {
                    outStorage.Push(inStorage.Pop());
                }
            }
            return outStorage.Peek();
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            int totalSize = inStorage.Count + outStorage.Count;
            return totalSize == 0;
        }
    }
}
