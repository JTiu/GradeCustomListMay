using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeCustomListMay
{
    public class CustomList<T> // <T> allows for any data type, generic.
    {


        private T[] items; //array indicated by the T[], followed by name, need a constructor

        public CustomList()

        {
            items = new T[10]; //initializes the array with lenght of 10 items. meets user story#1 As a developer, I want to use a custom-built list class that stores its values in an array, so that I can store any data type in my collection.
            //capacity is ten at this moment
        }

        // As a developer,#2 I want a read-only Count property implemented on the custom-built list class, so that I can get a count of the number of elements in my custom list class instance.

        public int Count //Enter array, determine how many positions
        {
            get
            {
                int count = 0; //start at 0 position

                foreach (var item in items) //Loop thru items, each item, if not null, add item to count// for each loop does not care about index postion
                {
                    if (item != null)
                    {
                        count++;
                    }
                    else
                    {
                        return count;
                    }
                }
                return count; //array is full. until anything is added, count is zero

            }

        }

        public int Capacity ////As a developer, I want a #3 Capacity: How many? ten.
        {
            get
            {
                return items.Length;
            }

        }
        public T this[int index]//As a developer, story #4I want to create a C# indexer property so that I can make the objects in my list accessible via index.

        {
            get
            {
                if (index < 0 || index >= items.Length) // I want to properly ensure that a user cannot access an out-of-bounds index. will use an 'if'
                {
                    throw new IndexOutOfRangeException();//will stop the 'run' and throw a written exception
                }
                return items[index];
            }
        }
        //As a developer, I want the ability to add an object to an instance of my custom-built list class by imitating the C# Add() method.

        public void Add(T item) //does not return, so 'void' because will always be able to add a new value by 3 step process to double the capacvity if array is full. Remove method will return a bool to indicate t/f if removal method is successful

        {
            int findIndex = FindNullIndexToAdd(); //method to find next open position
            if (findIndex >= 0)
            {
                items[findIndex] = item;
            }
            else//if the array is full, i.e., -1
            {
                findIndex = items.Length;

                IncreaseCapacity();//activated when array was full, will double the length of the 'capacity'. three part process in the below method 'Increase capacity.  1. create doubled capacity, 2.move using for loop 3. update array to point to new array with double the capicity
                items[findIndex] = item;//finds next open index position (should be ten for the first new incoming item, then 11 to 19, until full). adds new item to the new array
            }
        }

        private void IncreaseCapacity()//3 steps
        {
            T[] newArray = new T[2 * items.Length];//step one

            for (int i = 0; i < items.Length; i++)//step 2
            {
                newArray[i] = items[i]; //copies all items to the new array
            }
            items = newArray;//new  array has double the capacity of the prior array; step 3
        }

        private int FindNullIndexToAdd()//will use a for loop to find index position (not a foreach loop, as above
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)//check with ==
                {
                    return i;//returns the next open slot.  if initial add, goeos to [0], subsequent additions go to next available slot, up to length-1; when full , will have a different result
                }
            }
            return -1;//-1 will indicate that there are no null postions to fill, array is full (ten)
        }
        public bool Remove(T item) //does not return, so 'void' #6: As a developer, I want the ability to remove an object from an instance of my custom-built list class by imitating the C# Remove() method.
        {
            int indexToRemove = FindItemIndex(item);//need to create a new method, as below, to check
            if (indexToRemove >= 0)//it >Equal finds the item, start the removal process using code below
            {
                for (int i = indexToRemove; i < items.Length -1; i++)//
                {
                    items[i] = items[i + 1];//
                }
                items[items.Length - 1] = default(T);//cannot use a null value, need to use default (T)

                return true;//if the item found, return true to indicate removall success
            }
            else
            {
                return false;//if the item does not exist, return false
            }
            
        }

        private int FindItemIndex(T item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                //needed to correct this based on error revealed in unit test
                if(items[i] == null)
                {
                    return -1;//may resolve failure in remove method unit test.
                }
                if (items[i].Equals(item))//check through the .Equals method to determine whether is something is equal, and if equal, proceed to next function, at the index
                {
                    return i;
                }
            }
            return -1;//if we reach this point, then item not found in the array.
        }
        //#7 As a developer, I want to be able to override the ToString method that converts the contents of the custom list to a string.
        public override string ToString()//need to create a string to hold the result
        {
            string result = string.Empty;//created empty string
            foreach (var item in items)//run 'for loop' on item through items, adding everything to the string, adding all non-empty (not null), items to the 'result' of the ToString method
            {
                if(item != null)
                {
                    result += item.ToString();
                    result += "\n";
                }
            }
            return result;
        }

        //#8As a developer, I want to be able to overload the + operator, so that I can add two instances of the custom list class together.
        //- List<int> one = new List<int>() {1,3,5}; and List<int> two = new List<int>() {2,4,6};
        //- List<int> result = one + two;
        //- result has 1,3,5,2,4,6
        public static CustomList<T> operator + (CustomList<T> a, CustomList<T> b)       // overload the + operator,
        {
            for (int i = 0; i < b.Count; i++)
            {
                a.Add(b[i]);//adds all the items from b to a, return the new a as combined collection
            }
            return a;//new list, after combination a & b
        
        }
        //  #8  As a developer, I want to be able to overload the – operator, so that I can subtract one instance of a custom list class from another instance of a custom list class.
        //- List<int> one = new List<int>() { 1, 3, 5 }; and List<int> two = new List<int>() { 2, 1, 6 };
        //- List<int> result = one - two;
        //- result has 3,5
        //using the template of the + operator above, modify to use the '-' operator, using a for loop to complete, and a return for the new a.list
        public static CustomList<T> operator -(CustomList<T> a, CustomList<T> b)       // overload the - operator,
        {
            for (int i = 0; i < b.Count; i++)
            {
                a.Remove(b[i]);//subtracts all the items from b to a, return the new a as new, smaller collection
            }
            return a;//new list, after reduction of b from a

        }
    }


    


}
