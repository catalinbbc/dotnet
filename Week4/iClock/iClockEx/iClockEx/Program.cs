using System;

namespace iClockEx
{
    public class Program
    {
        static void Main(string[] args)
        {
            SystemClock sytemClock = new SystemClock();
            Console.WriteLine("IClock Interface and BusinessDate Struct:");
            Console.WriteLine("\nSystem DateTime:");
            Console.WriteLine("Now:" + sytemClock.Now.ToString());
            Console.WriteLine("UtcNow:" + sytemClock.UtcNow.ToString());


            Console.WriteLine("\nCustom Date Struct:");
            Console.WriteLine("Today default no format:" + sytemClock.Today.ToString());

            //Console.WriteLine(sytemClock.Today.Day);

            Console.WriteLine("Today in specific format eg<MMMM dd, yyyy>: " + sytemClock.Today.ToString("MMMM dd, yyyy"));

            BusinessDate date1 = new BusinessDate(31, 3, 2020);
            BusinessDate date2 = new BusinessDate(31, 3, 2020);

            Console.WriteLine("Compare [{0}] == [{1}] :{2}",date1.ToString() ,date2.ToString(), date1 == date2);
            Console.WriteLine("Compare [{0}] != [{1}] :{2}",date1.ToString() ,date2.ToString(), date1 != date2);


        }
    }

   
}
