using System;
using System.Collections.Generic;

namespace homework1

{
    public class Exercise5
    {
        public static void goex()
        {

            Console.WriteLine("EX 5: remove duplicates from an unsorted linked list.");

            Console.WriteLine("Please enter a phrase:");
            string line = Console.ReadLine();
            string[] words = line.Split();

            
            //make a LinkedList with the words
            //LinkedList<string> sentence = new LinkedList<string>(words);
            
            LinkedList<String> sentence = new LinkedList<String>();

            foreach (string word in words)
            {
                if(!sentence.Contains(word))
                {
                    sentence.AddLast(word);
                }
            }
            
            Console.WriteLine("Unique list:");
            printLinkedList(sentence.First, " ");

        }

        public static void printLinkedList(LinkedListNode<String> node, String separator)
        {
            while (node != null)
            {
                Console.Write(node.Value + separator);
                node = node.Next;
            }
        }

    }
}
