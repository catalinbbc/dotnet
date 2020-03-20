using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

namespace week3Run
{
    public class Ex1MyList<T> : IEnumerable<T>
    {
        static int initialCapacity = 2;
        public  T[] myArray = new T[initialCapacity];
        public int index = 0;

        public Ex1MyList()
        {
        }
        public Ex1MyList(T t)
        {
            myArray[index] = t;
            List<T> newList = new List<T>();            
        }

        public int myCount()
        {
            int indexCount = 0;
            foreach( T element in myArray)
            {
                //Console.WriteLine(element);
                    indexCount++;
            }
            return indexCount;
        }

        public void myAdd(T elem)
        {
            if (index < initialCapacity / 2)
            {
                myArray[index] = elem;
                index++;
            }
            else
            {
               
                //increase the capacity
               int newCapacity = 2 *  initialCapacity;
                Console.WriteLine("increase capacity from  " + initialCapacity +" to "+newCapacity);
                initialCapacity = newCapacity;
                
                T[] myArrayNew = new T[initialCapacity];
                
               //copy elements from old array to the

                myArrayNew[index] = elem;
                myArrayNew = myArray;
                index++;
                myArray = myArrayNew;
            }
        }

        public void myRemove(T elem)
        {
            int indexToRemove = -1;
            for ( int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i].Equals(elem))
                {
                     indexToRemove = i;
                }
            }

            if(indexToRemove > 0)
            {
                myArray = myArray.Where((source, index) => index != indexToRemove).ToArray();

            }

        }

        public void listItems()
        {
            Console.WriteLine("Elements in the myList:");
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine(myArray[i]);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return myArray.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (T item in myArray)
            {
                yield return item;

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
