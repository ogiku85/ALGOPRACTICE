using System;
using System.Collections.Generic;
using System.Text;

namespace ALGOPRACTICE.Models
{
    public class MapLinkedListNode
    {
        public int Value { get; set; }
        public int Key { get; set; }
        public MapLinkedListNode Next { get; set; }
    }
    public class MyHashMap
    {
        //used for genrating unique keys
        public int PrimeCoefficient { get; set; }
        public MapLinkedListNode[] Store { get; set; }
        public int Count { get; set; }
        public double OptimalLoadFactor { get; set; }
        /** Initialize your data structure here. */
        public MyHashMap()
        {
            PrimeCoefficient = 31;
            //initialise array to lenght of 1000
            Store = new MapLinkedListNode[10];
            OptimalLoadFactor = 0.7;
        }
        public int GenerateHashCode(int key)
        {
            int hashCode = 0;
            string keyString = key.ToString();
            //we start at 1 beacuse primecoefficent raised to zero is 1
            int currentCoefficient = 1;
            int lenOfStore = Store.Length;
            try
            {
                foreach (var n in keyString)
                {
                    hashCode += Convert.ToInt32(n) * currentCoefficient;
                    currentCoefficient = currentCoefficient * PrimeCoefficient;
                    //now we use compression to reduce the hashcode generated so that we don't use up alot of memory i.e we don't declare
                    //a store array with a lot of space since will be using the generated hashcode as index of the array store
                    hashCode = hashCode % lenOfStore;
                    currentCoefficient = currentCoefficient % lenOfStore;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return hashCode % lenOfStore;
        }

        /** value will always be non-negative. */
        public void Put(int key, int value)
        {
            MapLinkedListNode currentNode;
            try
            {
                //this should always be less than 0.7
                double currentLoadFactor;
                int indexOfInsertion = GenerateHashCode(key);
                //at each location key value paifr are store ij a linkedlist using seperate chaining. This is to handle collison
                //where the same hashcode is generated for different key so both data will be store in the same location in a linked list
                //this shouldn't happen often if the hashing function is solid. ideally a hsahmap should have a load factor of 0.7
                //i.e number items in the hashmap can be 7 in a store of lenght 10

                var headOfStoredDataInCurrentIndex = Store[indexOfInsertion];
                currentNode = headOfStoredDataInCurrentIndex;

                // We first of all check if the key exists and update it
                while (currentNode != null)
                {
                    if (currentNode.Key == key)
                    {
                        currentNode.Value = value;
                        return;
                    }
                    currentNode = currentNode.Next;
                }
                //If we didn't return in the above while loop, it measn the key is new and we need to create an entry for it
                var newNode = new MapLinkedListNode() { Key = key, Value = value };

                //the new node will be inserted at the begining of the list and become the new head. so will point the new node next value to the existung head if any
                //and then return the new node is the new head by setting it as the value to retrieved from the insertion location
                //once you get a nide you can traverse to get the remaining node in the list beacuse we have set the new node next node to the previous head
                //the old data is not lost and teh chain/list continues
                newNode.Next = headOfStoredDataInCurrentIndex;
                Store[indexOfInsertion] = newNode;
                Count++;
                currentLoadFactor = Count / Store.Length;
                if (currentLoadFactor > OptimalLoadFactor)
                {
                    Rehash();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        public void Rehash()
        {
            //When the loadfactore is higher than expected we create a new array double the size of the existing one rehash or regeenarte the hascode of
            //existing data and move them to their new location so that the load factor is optimal otherwise we could have a very high number of items being stored
            //in a few few index position instaed of being spread across the array
            try
            {
                MapLinkedListNode[] newStore = new MapLinkedListNode[2 * Store.Length];
                var oldStore = (MapLinkedListNode[])Store.Clone();
                Store = newStore;
                //we go into every array location pick out the linkedlist there and regenerate the hashcode for each stor4ed item. They will likely get new array location
                foreach (var headOfExistingData in oldStore)
                {
                    var currentNode = headOfExistingData;
                    while (currentNode != null)
                    {
                        Put(currentNode.Key, currentNode.Value);
                        currentNode = currentNode.Next;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public int Get(int key)
        {
            int result = -1;
            try
            {
                var indexToRetrieveFrom = GenerateHashCode(key);
                var headOfDataInCurrentIndex = Store[indexToRetrieveFrom];
                var currentNode = headOfDataInCurrentIndex;

                while (currentNode != null)
                {
                    if (currentNode.Key == key)
                    {
                        result = currentNode.Value;
                        return result;
                    }
                    currentNode = currentNode.Next;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return result;
        }

        /** Removes the mapping of the specified value key if this map contains a mapping for the key */
        public void Remove(int key)
        {
            try
            {
                var indexToDeleteFrom = GenerateHashCode(key);

                var headOfDataInCurrentIndex = Store[indexToDeleteFrom];

                var currentNode = headOfDataInCurrentIndex;
                MapLinkedListNode previousNode;
                //if the key to remove is the first key or located in the next we simply make the next node the new jhead and not bother looping
                //through the entire list
                if (headOfDataInCurrentIndex.Key == key)
                {
                    headOfDataInCurrentIndex = headOfDataInCurrentIndex.Next;
                    Store[indexToDeleteFrom] = headOfDataInCurrentIndex;
                    return;
                }
                while (currentNode.Next != null)
                {
                    if (currentNode.Next.Key == key) 
                    {
                        previousNode = currentNode;
                        //we skip over the current's node next node and move to the next next
                        previousNode.Next = currentNode.Next.Next;
                        return;
                    }
                    currentNode = currentNode.Next;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
