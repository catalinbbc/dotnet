using System;
using System.Collections.Generic;
using System.Text;

namespace homework1
{
    public class Excercise1
    {
        public static void goex1()
        {
            
            Console.WriteLine("\nPlease enter a string with multiple chars so it will return the unique chars:");

            String theString = Console.ReadLine();
            var hash = new HashSet<char>(theString);
            var finalString = new StringBuilder();
            foreach (char ch in hash)
            {
                finalString.Append(ch);
            }
            Console.WriteLine(finalString);
        }
    }
     
}
