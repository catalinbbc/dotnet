using System;
using System.Collections.Generic;
using System.Text;

namespace week3Run
{
     class RangeException<T>
    {
        public static T minVal;
        public static T maxVal;
        public static T MinVal { get => minVal; set => minVal = value; }
        public static T MaxVal { get =>maxVal; set => maxVal = value; }

        public  RangeException(T min, T max)
        {
            MinVal = min;
            MaxVal = max;
        }

        public void readData()
        {
            Console.WriteLine("Enter a value between " + MinVal + " and " + MaxVal);

            try
            {
                ReadParamFromConsole();

            }
            catch (InvalidRangeException<T> ex)
            {
                Console.WriteLine(ex.Message);
            }

            //most generic
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine("At the end");

        }



        public void ReadParamFromConsole()
        {
            string value = Console.ReadLine();
            
            if(value is T)
            {
                if (value.CompareTo(MinVal) < 0  || value.CompareTo(MaxVal) > 0)
                {
                    //with a message
                    throw new InvalidRangeException<T>("The value is NOT in the specified interval [" + MinVal + " - " + MaxVal + "]");

                   
                }
                else
                {
                    Console.WriteLine("Value {0} is in the specified interval [{1} - {2}]",value , MinVal, MaxVal);
                }
            }
          

            //return value;

        }


        [Serializable()]
        public class InvalidRangeException<T> : System.Exception
        {
            private static readonly string DefaultMessage = "Custom Invalid Rande exception default Message.";


            public  InvalidRangeException() : base() { }
            public  InvalidRangeException(string message) : base(message) { }
            public  InvalidRangeException(string message, System.Exception inner) : base(message, inner) { }

            // A constructor is needed for serialization when an
            // exception propagates from a remoting server to the client. 
            protected InvalidRangeException(System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}
