using System;
using System.Threading;


namespace week3Run
{
    delegate void TimePassed(int seconds);

    class Program
    {
        
        static void Main(string[] args)
        {

            // Timer theTimer = new Timer();
            //theTimer.

            MyTimerClass t = new MyTimerClass(10000, true);
            t.Start();
            t.Dispose();

            
            Ex1MyList<int> myGenericList = new Ex1MyList<int>();
            myGenericList.myAdd(1);
            myGenericList.myAdd(10);
            myGenericList.myAdd(100);

            myGenericList.listItems();
            myGenericList.myRemove(10);
            myGenericList.listItems();


            Console.WriteLine("Elements  in my List of type "+myGenericList+ " is  "+ myGenericList.myCount());


            Ex1MyList<double> myDoubleList = new Ex1MyList<double>();

            Console.WriteLine("Elements  in my List of type " + myDoubleList + " is  " + myDoubleList.myCount());
            
            
        }
    }
}
