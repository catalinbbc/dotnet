using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace week3Run
{
    class Ex4
    {
      public static int min = 1;
      public static int max = 100;


        public static void Execute()
        {
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            Console.WriteLine("Enter a number value between 1 and 100");

            int value = int.Parse(Console.ReadLine());
            if (value < min || value > max)
            {
                throw new InvalidRangeException<int>("The value is NOT in the specified interval [" + min + " - " + max + "]");
            }

            Console.WriteLine("Value {0} is in the specified interval [{1} - {2}]", value, min, max);

            Console.ReadLine();
        }
        public static void ExecuteDate()
        {
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            DateTime minDate = DateTime.Parse("1.1.2020");
            DateTime maxDate = DateTime.Parse("31.1.2020");
            Console.WriteLine("Enter a date between {0} and {1}", minDate, maxDate);
            try
            {
                DateTime d = DateTime.Parse(Console.ReadLine());

                if (d < minDate || d > maxDate)
                {
                    throw new InvalidRangeException<DateTime>(minDate, maxDate, "Invalid Date out of range");
                }
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        public static void ExecureSeq()
        {


            List<int> myList = new List<int>();
            int value = new int();

            Console.WriteLine("Enter a seqence of 10 numbers from {0} - {1}", min, max);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(" # "+i);


                value = int.Parse(Console.ReadLine());

                //is in range
                if (value < min || value > max)
                {
                    //with a message
                    throw new InvalidRangeException<int>("The value is NOT in the specified interval [" + min + " - " + max + "]");

                }

                if (myList.Count > 0)
                {
                    int lastElement = myList.Last();
                    if (lastElement > value)
                    {
                        //with a message
                        throw new InvalidRangeException<int>("The value not from the sequence requested");

                    }
                }

                myList.Add(value);

            }
        }
        
    }
}
