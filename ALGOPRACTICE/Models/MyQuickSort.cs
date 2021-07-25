using System;
using System.Collections.Generic;
using System.Text;

namespace ALGOPRACTICE.Models
{
    public class MyQuickSort
    {
        public MyQuickSort()
        {
        }

        public int[] QuickSort(int[] items)
        {
            try
            {
                int leftIndex = 0;
                int rightIndex = items.Length - 1;
                //override items with sorted items
                items = QuickSortHelper(items, leftIndex, rightIndex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return items;
        }
        public int[] QuickSortHelper(int[] items, int leftIndex, int rightIndex)
        {
            try
            {
                if (leftIndex >= rightIndex)
                {
                    //leftindex should not be greater tahn or equal to right index. there's nothing to sort we just return the items as is
                    return items;
                }
                //get pivot is defined as a helper method so that we access the items array and make changes to it in each iteration of getting anew pivot
                int GetPivot(int leftIndex, int rightIndex)
                {
                    //we choose the index at the end of the array as our pivot. This may change in our while loop below
                    int currentPivotIdex = rightIndex;
                    try
                    {


                        while (leftIndex != currentPivotIdex)
                        {
                            //this are the 3 important values that will be involved in a swap if the left element is greater than the pivot
                            //if teh left element is greater thanthe pivot we bring it to the back or a position just after teh current pivot position
                            //i.e if pivot was in index 5 then pivot will move to index 4 and the bigger element will take over pivot 5 and the element in index 4
                            //will move to the position of the left element

                            int leftElement = items[leftIndex];
                            int pivotElement = items[currentPivotIdex];
                            int elementInFrontOfPivot = items[currentPivotIdex - 1];

                            if (leftElement > pivotElement)
                            {
                                //take former element in fron of pivot to the former position of left element
                                items[leftIndex] = elementInFrontOfPivot;

                                //move pivot element one step to closer to the left
                                items[currentPivotIdex - 1] = pivotElement;

                                //bring bigger element to the back of the pivot i.e former pivot position since we just move the pivot above
                                items[currentPivotIdex] = leftElement;

                                //since the pivot has been moved one step closer to the left we update it index position
                                //the whole idea is to move the pivot from the right to it final resting place in the left so that the pivot itself is sorted
                                //and elements bigger than it are to it right and those smaller are to it left. these elements may not be sorted but they either smaller than
                                //or greater than pivot e.g 1,0 2, 5,7 . 2 is in it right position and 1,0 and are smaller than 2 even though they are not fully sorted. They
                                //will be sorted in future iteration
                                currentPivotIdex--;
                            }
                            else
                            {
                                //left element is smaller or equal to pivot so we move one step to the right and prepare to comapre the next element with the pivot
                                leftIndex++;
                                continue;
                            }
                        }
                        //at the end of the loop the left and pivot index have converged and the pivot element is in it right position so we return this index

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
                    }
                    return currentPivotIdex;
                }

                int pivotIndex = GetPivot(leftIndex, rightIndex);
                //now that will have a pivot will use it to split our array into two and sort both parts of the array

                //sort left side
                QuickSortHelper(items, leftIndex, pivotIndex);

                //sort right side
                QuickSortHelper(items, pivotIndex + 1, rightIndex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return items;
        }
    }

}
