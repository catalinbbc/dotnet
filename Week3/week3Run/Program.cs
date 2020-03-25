using System;
using System.Collections.Generic;
using System.Threading;


namespace week3Run
{
    delegate void TimePassed(int seconds);

    class Program
    {
        
        static void Main(string[] args)
        {
            /*
            //ex1
            Ex1MyList<int> myGenericList = new Ex1MyList<int>();
            myGenericList.myAdd(1);
            myGenericList.myAdd(10);
            myGenericList.myAdd(100);

            myGenericList.listItems();
            myGenericList.myRemove(10);
            myGenericList.listItems();


            Console.WriteLine("Elements  in my List of type " + myGenericList + " is  " + myGenericList.myCount());


            Ex1MyList<double> myDoubleList = new Ex1MyList<double>();

            Console.WriteLine("Elements  in my List of type " + myDoubleList + " is  " + myDoubleList.myCount());

            */


            //ex2
            /*
            MyTimerClass t = new MyTimerClass(10000, true);
            t.Start();
            t.Dispose();
            */


            //ex3 - extend myEnumerable 
            /*

            List<int> myList = new List<int>() { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 };
            
            //myList.Add(1);
            //myList.Add(2);
            //myList.Add(3);
            //myList.Add(4);
          

            Console.WriteLine("Designated list:");
            foreach(int item in myList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n=======================================");

            Console.WriteLine("Sum of List = "+myList.Sum());
            Console.WriteLine("AVG of List = "+myList.Avg());
            Console.WriteLine("Min of List = "+myList.Min());
            Console.WriteLine("Max of List = "+myList.Max());
            Console.WriteLine("Prod of List = "+myList.Prod());
            */

            /*

            try
            {
                Ex4.Execute();
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Ex4.ExecuteDate();
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Ex4.ExecureSeq();
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine(ex.Message);
            }

    */
            //Ex 6

            //long sampleNumber = 1234567;

            long sampleNumber = 11;
            BitArray64 myNumber = new BitArray64(sampleNumber);


            Console.WriteLine("Bit 7 is "+myNumber[7]);

            Console.WriteLine(myNumber[2] == myNumber[3]);

            Console.WriteLine("My Number {0} as a Bit Array:", sampleNumber);
            foreach (var value in myNumber)
            {
                Console.Write(value);
            }
            //change the bit 3,4,5 to 1
            myNumber[3] = 1;
            myNumber[4] = 1;
            myNumber[5] = 1;

            Console.WriteLine("\nchange the bit 3,4,5 to 1 and the bit Array becomes: ");
            foreach (var value in myNumber)
            {
                Console.Write(value);
            }

            try
            {
                Console.WriteLine(myNumber[77]);
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine("\nnumber[77 ]triggers "+ex.Message);
            }
        }
    }
}
