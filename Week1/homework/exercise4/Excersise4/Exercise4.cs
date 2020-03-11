using System;
using System.Collections.Generic;
using System.Text;

namespace homework1
{
    public class Excercise4
    {
        public static void goex()
        {
            Console.WriteLine("#Ex4 reverse a linked list, if you able to do it using loops, try to solve with recursion.");
            Console.WriteLine("Please enter a phrase:");
            string line = Console.ReadLine();
            string[] words = line.Split();

            //make a LinkedList with the words
            LinkedList<string> sentence = new LinkedList<string>(words);

            Console.WriteLine("Original linked list:");
            printLinkedList(sentence.First, " ");

            
            Console.WriteLine("\nReversed Linked list:");
            LinkedListNode<String> newList = reverseRecursive(sentence.First);
            printLinkedList(newList, " ");

            //foreach (string word in words)
            //{
            //    Console.WriteLine(word);
            //}
        }

        //recursive reverse the list
        static LinkedListNode<String> reverseRecursive(LinkedListNode<String> current)
        {
            if (current == null || current.Next == null)
            {
                return current;
            }

            LinkedListNode<String> newNode = reverseRecursive(current.Next);

            newNode.List.AddLast(current.Value);
            newNode.List.Remove(current);

            return newNode;
        }
        //Display the linked list
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


