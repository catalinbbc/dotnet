using System;
using System.Collections.Generic;

namespace homework1
{
    public class Exercise7
    {

        public static void goex()
        {
            Console.WriteLine("Ex7:  Data manipulation ");

            Console.WriteLine("7.1: Arrays ");

            //#######################################
            int[] theArray = new int[7];
            theArray[0] = 101;
            theArray[1] = 201;
            theArray[2] = 301;
            theArray[3] = 401;
            theArray[4] = 501;
            theArray[5] = 601;
            theArray[6] = 701;

            for (int i = 0; i < theArray.Length; i++)
            {
                Console.WriteLine("The Array {0} =>{1}", i, theArray[i]);
            }


            //#######################################
            Console.WriteLine("\n7.2: Lists ");
            List<string>theList = new List<string>();
            theList.Add("Ala");
            theList.Add("Bala");
            theList.Add("Portocala");
            int index = 0;

            foreach (string item in theList)
            {
                index++;
                Console.WriteLine("List {0} =>{1}", index, item);
            }

            Console.WriteLine("Add element");
            theList.Add(" Ana ");

            index = 0;
            foreach (string item in theList)
            {
                index++;
                Console.WriteLine("List {0} =>{1}", index, item);
            }

            string[] newString = new string[] { "Ana ",
                               "Are ",
                               "Mere"};

            Console.WriteLine();
            Console.WriteLine("AddRange(newArray)");
            theList.AddRange(newString);

            index = 0;
            foreach (string item in theList)
            {
                index++;
                Console.WriteLine("List {0} =>{1}", index, item);
            }

            Console.WriteLine();
            Console.WriteLine("Remove(index5)");

            theList.RemoveAt(5);

            index = 0;
            foreach (string item in theList)
            {
                index++;
                Console.WriteLine("List {0} =>{1}", index, item);
            }


            Console.WriteLine();
            Console.WriteLine("RemoveRange(4,5)");
            theList.RemoveRange(4, 2);

            index = 0;
            foreach (string item in theList)
            {
                index++;
                Console.WriteLine("List {0} =>{1}", index, item);
            }



            //#######################################
            Console.WriteLine("\n7.2: Dictionaries ");

            Dictionary<string, int> occurences = new Dictionary<string, int>();
            occurences.Add("a", 1);
            occurences.Add("n", 2);
            occurences.Add("r", 6);
            occurences.Add("m", 1);
            occurences.Add(" ", 0);


            occurences.Remove(" ");


            foreach (KeyValuePair<string, int> pair in occurences)
            {
                Console.WriteLine("Dict {0} =>{1}", pair.Key, pair.Value);
            }


            //#######################################
            Console.WriteLine("\n7.3: Queues ");

            Queue<string> myQueue = new Queue<string>();
            myQueue.Enqueue("Ana");
            myQueue.Enqueue("are");
            myQueue.Enqueue("multe");
            myQueue.Enqueue("mere");
            

            while (myQueue.Count > 0)
            {
                string item = myQueue.Dequeue();
                Console.WriteLine(item);
            }


            //#######################################
            Console.WriteLine("\n7.3: Stacks ");
            Stack<string> myStrings = new Stack<string>();
            myStrings.Push("ana");
            myStrings.Push("are");
            myStrings.Push("mere");
            myStrings.Push("multe");
            

            while (myStrings.Count > 0)
            {
                string month = myStrings.Pop();
                Console.WriteLine(month);
            }          


            //#######################################
            Console.WriteLine("\n7.4: Linked Lists ");
            LinkedList<string> myStringList = new LinkedList<string>();
            myStringList.AddLast("mere");
            myStringList.AddFirst("multe");
            myStringList.AddFirst("Ana");

            var mere = myStringList.Find("mere");

            myStringList.AddBefore(mere, "are");
            myStringList.AddAfter(mere, "destule");

            foreach (string itemList in myStringList)
            {
                Console.WriteLine(itemList);
            }

        }
    }
}
