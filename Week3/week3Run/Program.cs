using System;
using System.Threading;


namespace week3Run
{
    delegate void TimePassed(int seconds);

    public class MyTimerClass
    {
        public event EventHandler Elapsed;

        public void OnOneSecond(int seconds)
        {
            Thread.Sleep(seconds);
            Console.WriteLine("Wait ..." + seconds + "...seconds");
        }



        public MyTimerClass()
        {
            //Thread.Sleep(10000);
        }
    }
    class Program
    {
        

    

        static void Main(string[] args)
        {

            MyTimerClass mc = new MyTimerClass();

            TimePassed d = mc.OnOneSecond;
            d();
            /*
            while(true)
            {
                mc.Elapsed += ;
            }
            */
          

            /*
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
            
            */
        }
    }
}
