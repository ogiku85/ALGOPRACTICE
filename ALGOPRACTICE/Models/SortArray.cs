using System;
using System.Collections.Generic;
using System.Text;

namespace ALGOPRACTICE.Models
{
    class SortArray
    {
    }
    public class Solution
    {
        public int[] SortArray(int[] nums)
        {
            return MergeSort(nums);
        }
        public int[] MergeSort(int[] nums)
        {
            int[] sortedResultArray = null;
            try
            {
                //since we are starting with initail array, left index is the begining of the array hence leftindex = 0
                //right index is the end of the array since array are zero index based hence right == array.lenght - 1
                int leftIndex = 0;
                int rightindex = nums.Length - 1;

                sortedResultArray = MergeSortHelper(nums, leftIndex, rightindex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return sortedResultArray;
        }

        public int[] MergeSortHelper(int[] nums, int leftIndex, int rightIndex)
        {
            int[] result = null;
            try
            {
                //base case
                if (leftIndex == rightIndex)
                {
                    return new int[] { nums[leftIndex] };
                }
                int middleIndex = (leftIndex + rightIndex) / 2;
                //the whole idea of merge sort is to keeping split the array until you cann't split any more
                //i,e until the array has one element each. At the begining if the array was 1,2,3,4,5 the array starts
                //at index 0 whic contains 1 and ends at index 4 whic contains 5 and the middle is index 2 which conatins 3
                //in order to split the aray further down we now start from index 0 to 3 this will be our new left array which is 
                //actaully the orignal left index as the new starting point, the middle index as the new end or right index and a new
                //middle index of 2. this happens on the left side and on the right side we have a new right array. starting with
                //mid +1 as it new left, initial right as it new right or endand a middle which could be index 3 or 4 i,e 4 or 5 depends
                //on how you round up
                int[] leftArray = MergeSortHelper(nums, leftIndex, middleIndex);
                int[] rightArray = MergeSortHelper(nums, middleIndex + 1, rightIndex);

                result = Merge(leftArray, rightArray);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return result;
        }
        public int[] Merge(int[] leftArray, int[] rightArray)
        {
            int[] mergedResultArray = null;
            try
            {
                //handle edge cases where one array is empty and the other is not
                if (leftArray.Length == 0 && rightArray.Length > 0)
                {
                    return rightArray;
                }
                if (leftArray.Length > 0 && rightArray.Length == 0)
                {
                    return leftArray;
                }
                //at this point both arrays are not empty so we need to comapare and arrange elements in both array
                //and return a new array

                int newResultArraySize = leftArray.Length + rightArray.Length;
                mergedResultArray = new int[newResultArraySize];

                //set pointers tyo begining of both arrays. this will change in the while loop when elements are compared and
                //added to the new result array. the left index may go further or behind the right index. it all depends on the contents of the array
                //the array with the smaller elements index will move quickly towards the end as it elements are being added to gfill the new result array

                int currentLeftArrayIndex = 0;
                int currentRightArrayIndex = 0;
                int currentResultArrayIndex = 0;

                while (currentLeftArrayIndex < leftArray.Length && currentRightArrayIndex < rightArray.Length)
                {
                    if (leftArray[currentLeftArrayIndex] < rightArray[currentRightArrayIndex])
                    {
                        //elemnet in the left array is less than that of the right so we add it to the result array and 
                        //move the left pointer to next element in the left array for the next iteration of the while loop
                        mergedResultArray[currentResultArrayIndex] = leftArray[currentLeftArrayIndex];
                        currentLeftArrayIndex++;
                    }
                    else
                    {
                        //right lelemnt is lesser or equal to the left element so we add it to the result array and move the right index or pointer
                        //to the next right element in preparation for the next while loop iteration
                        mergedResultArray[currentResultArrayIndex] = rightArray[currentRightArrayIndex];
                        currentRightArrayIndex++;
                    }
                    //no matter what happens in the if statement above we move the result point to make room for the next element that will be added
                    //in the next iteration
                    currentResultArrayIndex++;
                }

                //after the while loop it is possible that one of the array is not yet empty so will simply attach its content to the result array
                //note at this point the left over element will have been sorted so no need to sort them before addding to the result array

                if (currentLeftArrayIndex == leftArray.Length && currentRightArrayIndex < rightArray.Length)
                {
                    //loop through the remaining content of the right array and adding to the result array
                    while (currentRightArrayIndex < rightArray.Length)
                    {
                        mergedResultArray[currentResultArrayIndex] = rightArray[currentRightArrayIndex];
                        currentResultArrayIndex++;
                        currentRightArrayIndex++;
                    }
                }

                if (currentLeftArrayIndex < leftArray.Length && currentRightArrayIndex == rightArray.Length)
                {
                    //loop thorugh the remaining content of the left array and add it to the result array
                    while (currentLeftArrayIndex < leftArray.Length)
                    {
                        mergedResultArray[currentResultArrayIndex] = leftArray[currentLeftArrayIndex];
                        currentResultArrayIndex++;
                        currentLeftArrayIndex++;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return mergedResultArray;
        }
    }

}
