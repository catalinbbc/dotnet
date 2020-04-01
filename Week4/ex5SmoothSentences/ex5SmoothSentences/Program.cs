using System;
using System.Collections.Generic;
/*
A smooth sentence is one where the last letter of each word is identical to the first letter the following word.
To illustrate, the following would be a smooth sentence: "Carlos swam masterfully."
Since "Carlos" ends with an "s" and swam begins with an "s" and swam ends with an "m" and masterfully begins with an "m".

Examples
IsSmooth("Marta appreciated deep perpendicular right trapezoids") ➞ true
IsSmooth("Someone is outside the doorway") ➞ false
IsSmooth("She eats super righteously") ➞ true

*/



namespace ex5SmoothSentences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            Console.Write("Enter your sentence:");

            string sentence = Console.ReadLine();
            // Splits string into array
            string[] words = sentence.Split();

            // Writes array to list
            for (int i = 0; i < words.Length; i++)
            {
                list.Add(words[i]);
            }

            //check the sentence
            if(list.Count <2 )
            {
                Console.WriteLine("sentence must have at least 2 words");
            }
            else
            {
                Console.WriteLine("Sentence is Smooth ? =>" + isSoomth(list));
            }

        }

        public static bool isSoomth(List<String> myList)
        {
            //loop through list
            int first = 1;
            bool isSmooth = true;
            string prevWord = myList[0];
            char lastC;
            char firstC;

            foreach(string word in myList)
            {
                if(first == 1)
                {
                    first = 0;
                   
                    prevWord = word;
                    //Console.WriteLine("First Word:"+word);
                    continue;
                }
                else
                {
                    //get prev word last char
                    lastC   = prevWord[prevWord.Length-1];
                    firstC = word[0];

                    //Console.WriteLine( "Compare: {0} - {1} => {2} == {3} ====++ === ",prevWord, word, lastC, firstC, firstC.CompareTo(lastC).ToString());
                    if(lastC == firstC)
                    {
                        //move to next
                        prevWord = word;
                        
                    }   
                    else
                    {
                        isSmooth = false;
                        break;
                    }
                    
                }
            }
            return isSmooth;
        }

        


    }
}
