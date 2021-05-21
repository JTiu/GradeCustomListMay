using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeCustomListMay
{
    public class CustomList <T> // <T> allows for any data type, generic.
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
                    if(item != null)
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


        public void Add(T item) //does not return, so 'void'
        {
            int findIndex = FindNullIndexToAdd(); //method to find next open position

        }

        private int FindNullIndexToAdd()//will use a for loop to find index position (not a foreach loop, as above
        {
            for (int i = 0; i < items.Length; i++)
            {
                if(items[i] == null)//check with ==
                {
                    return i;//returns the next open slot.  if initial add, goeos to [0], subsequent additions go to next available slot, up to length-1; when full , will have a different result
                }
            }
            return -1;//-1 will indicate that there are no null postions to fill, array is full (ten)
        }
    }

    //As a developer, I want the ability to add an object to an instance of my custom-built list class by imitating the C# Add() method.



}
