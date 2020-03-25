using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace week3Run
{
   

        [Serializable()]
        public class InvalidRangeException<T> : Exception
        {
            private static readonly string DefaultMessage = "Custom Invalid Range exception default Message.";

            public static T minVal;
            public static T maxVal;
            public static T MinVal { get => minVal; set => minVal = value; }
            public static T MaxVal { get => maxVal; set => maxVal = value; }

           

            public  InvalidRangeException() : base() { }
            public  InvalidRangeException(string message) : base(message) { }
            public  InvalidRangeException(string message, System.Exception inner) : base(message, inner) { }

            // A constructor is needed for serialization when an
            // exception propagates from a remoting server to the client. 
            protected InvalidRangeException(System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

            public InvalidRangeException(T minVal, T maxVal, string v) : base(DefaultMessage)
            {
                MinVal = minVal;
                MaxVal = maxVal;
                
            }
        }

}
