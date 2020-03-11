using System;
using System.Collections.Generic;
using System.Text;

namespace homework1
{
    public class Excercise3
    {
        public static void goex()
        {
            
            Console.WriteLine("Input a string to count the frequency of chars:");

            string buffer = Console.ReadLine();

            
            Dictionary<char, int> myDictionary = new Dictionary<char, int>();


            var countIndex = 0;

            //loop char by char and count the occurencies in the dictionary if not presents add it
            for (int i = 0; i < buffer.Length; i++)
            {
                //if it is present increase the counts 
                if (myDictionary.TryGetValue(buffer[i], out countIndex))
                {
                    countIndex++;
                    myDictionary[buffer[i]] = countIndex;
                }
                else //not present add to dictionarys
                {
                    myDictionary.Add(buffer[i], 1);
                }

            }

            Console.WriteLine("Char Occurencies in the given strings:");
            foreach (KeyValuePair<char, int> kvp in myDictionary)
            {
                Console.WriteLine("{0} : {1} times.", kvp.Key, kvp.Value);
            }
        }

       

    
    }

}
