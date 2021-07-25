using System;
using System.Collections.Generic;
using System.Text;

namespace ALGOPRACTICE.Models
{
    public class MyMinHeap
    {
        //Size of storage array
        public int Size { get; set; }

        //Array to store the value of the heap
        public int[] Store { get; set; }
        //Next Index for insertion
        public int NextIndex { get; set; }
        public MyMinHeap()
        {
            Size = 100;
            Store = new int[Size];
            NextIndex = 0;
        }
        public void Insert(int data)
        {
            try
            {
                //insert at next index
                Store[NextIndex] = data;

                // heapify i.e sort heap in terms of priority. the smallest element to the root of the heap vice versa for max heap
                HeapifyUpwards();
                NextIndex++;

                //check if ther's room for next index otherwise expand sttorage size
                if (NextIndex >= Store.Length)
                {
                    var tempStore = (int[])Store.Clone();
                    Store = new int[Size * 2];

                    for (int i = 0; i < tempStore.Length; i++)
                    {
                        Store[i] = tempStore[i];
                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        public void HeapifyUpwards()
        {
            try
            {
                //we start checking from the end. next index i currently at the end of the array since we just inserted in the insert method and have not
                //increased nextindex pointer
                int currentChildIndex = NextIndex;
                /*
                 the parent index from a child index is equal to (childIndex - 1) / 2 we round down. Therefore childIndex in the while loop cannnot be
                less than two, else will run into negative index i.e 1- 1/2 or 0 -1 /2
                 */
                while (currentChildIndex >= 1)
                {
                    //calculate parent index of the current child based on teh child's index
                    int parentIndex = (currentChildIndex - 1) / 2;
                    
                    //store the value of the parent and child based on the caluclated indexor location
                    int parentElement = Store[parentIndex];
                    int currentChildElement = Store[currentChildIndex];

                    //if the parent is greater than child we swap. we are currently building a min heap. parent should be less than child
                    if (parentElement > currentChildElement)
                    {
                        Store[parentIndex] = currentChildElement;
                        Store[currentChildIndex] = parentElement;
                        currentChildIndex = parentIndex;
                    }
                    else
                    {
                        //no need to swap do nothinga nd come out of loop
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        public int Remove()
        {
            int? result = null;
            try
            {
                //reduce next index by 1 so that it now points to the previuosly added value since it always points to the next available space
                NextIndex--;
                //this the index of the root or the parent. it always starts at 0
                int parentIndex = 0;
                int lastIndex = NextIndex;
                result = Store[parentIndex];

                int currentRootElement = Store[parentIndex];
                int currentLastElement = Store[lastIndex];

                //while removing in a heap we are actually removing the root element. In a min heap this is the smallest element and in a max heap this is biggest element

                //first we swap the root and the last element and after that we adjust or heapify the heap downwards

                Store[parentIndex] = currentLastElement;
                Store[lastIndex] = currentRootElement;
                HeapifyDownwards();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return result.Value;
        }

        public int Remove(int data)
        {
            int? result = null;
            try
            {
                int indexOfDataToDelete = 0;

                for (int i =0; i < Store.Length; i++)
                {
                    if (Store[i] == data)
                    {
                        indexOfDataToDelete = i;
                    }
                }
                if (indexOfDataToDelete == 0)
                {
                    //same as removing smallest element
                    result = Remove();
                    return result.Value;
                }
                //reduce next index by 1 so that it now points to the previuosly added value since it always points to the next available space
                NextIndex--;
                //this the index of the root or the parent. it always starts at 0
                int parentIndex = 0;
                int lastIndex = NextIndex;
                //store value to be delted it is the same data
                result = Store[indexOfDataToDelete];

                int currentRootElement = Store[parentIndex];
                int currentLastElement = Store[lastIndex];
                if (data < currentRootElement)
                
                //simly swap the data to be deleted with the last element. it will be overwritten by the next insert since we decreeased the next index count
                Store[lastIndex] = data;
                Store[indexOfDataToDelete] = currentLastElement;
                HeapifyDownwards();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return result.Value;
        }
        public void HeapifyDownwards()
        {
            try
            {
                //we starte from the root downwards
                int currentParentIndex = 0;
                int lastIndex = NextIndex;

                while (currentParentIndex < lastIndex)
                {
                    //the left and right index of the current parent node is (2 * currentParentIndex) + 1 and (2 * currentParentIndex) + 2
                    int indexOfLeftChild = (2 * currentParentIndex) + 1;
                    int indexOfRightChild = (2 * currentParentIndex) + 2;

                    int currentParentElement = Store[currentParentIndex];
                    //we cann't assign tehm now beacuse it is possible that we are dealing with a leaf node i,e the node at the bottom of the and it has
                    //no left or right child so we have to check before assigning value
                    int? currentLeftElement = null;
                    int? currentRightElement = null;

                    //we start by assuming teh parent is the smallest element or value
                    int minElement = currentParentElement;

                    //check if left child index is valid and within the tree

                    if (indexOfLeftChild < lastIndex)
                    {
                        currentLeftElement = Store[indexOfLeftChild];
                    }

                    //check if right child is valid and within the tree
                    if (indexOfRightChild < lastIndex)
                    {
                        currentRightElement = Store[indexOfRightChild];
                    }

                    //get the minimum value between the parent and it children. we start with the left

                    if (currentLeftElement != null)
                    {
                        minElement = Math.Min(currentParentElement, currentLeftElement.Value);
                    }
                    if (currentRightElement != null)
                    {
                        minElement = Math.Min(currentRightElement.Value, minElement);
                    }

                    //check if the parent is equal to min element. if it is then we do nothing and return.
                    if (currentParentElement == minElement)
                    {
                        return;
                    }
                    //now we check if the left or the right child equals min element and we swap. we will start with the left
                    if (currentLeftElement.Value == minElement)
                    {
                        Store[indexOfLeftChild] = currentParentElement;
                        Store[currentParentIndex] = currentLeftElement.Value;
                        currentParentIndex = indexOfLeftChild;
                    }

                    if (currentRightElement.Value == minElement)
                    {
                        Store[indexOfRightChild] = currentParentElement;
                        Store[currentParentIndex] = currentRightElement.Value;
                        currentParentIndex = indexOfRightChild;
                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        public int? GetMinimumValue()
        {
            try
            {
                if (Store.Length == 0)
                {
                    return null;
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            //return the root or first element
            return Store[0];
        }
    }
}
