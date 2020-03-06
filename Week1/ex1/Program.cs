using System;
using System.Collections;
using System.Collections.Generic;

namespace ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter 3 chars:");

             Stack<char> myStack = new Stack<char>();

            int stackLength = 3;

            for(int i = 0; i < stackLength; i++)
            {
                Console.WriteLine("");
                var item = Console.ReadKey();

                myStack.Push(item.KeyChar);
               
            }

            Console.WriteLine("\nThe entered arguments in reverse order are:");

            for (int i = 0; i < stackLength; i++)
            {
                //Console.Write(myStack.;
                Console.WriteLine(myStack.Pop());
                
            }

        }
    }

    
}
