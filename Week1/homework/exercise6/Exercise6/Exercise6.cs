using System;

namespace homework1
{
    public class Exercise6
    {

        public static void goex()
        {

            Console.WriteLine("EX 6: Given a string s consists of upper/lower-case alphabets and empty space characters ' ', return the length of last word in the string.");
            Console.WriteLine("Please enter a phrase:");

            string buffer = Console.ReadLine();

            //find the position of last space
            int lastSpace = buffer.LastIndexOf(' ');
            
            
            if (lastSpace == -1)
            {
                Console.WriteLine("No space found");
            }

            //get the last word
            string lastword = buffer.Substring(lastSpace + 1);
            int countChar = lastword.Length;
            Console.Write("The last word is "+ lastword + " with the length of:"+countChar);

        }

    }
}
