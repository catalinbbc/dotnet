using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WordProcessor
{
    class Program
    {
       
        static int totalWordsCount;
        static string[] allFileNames;


        static async Task Main(string[] args)
        {
            Console.WriteLine("W6 - Ex4 - Word Count");

            List<Task> tasks = new List<Task>();
            WordProcessor wordProcessor = new WordProcessor();

            allFileNames = Directory.GetFiles(@"D:\\dotnet\\dotnet\\\\Resources");

            //open a file stream for al files in a separate task
            for (int i = 0; i < 10; i++)
            {
                string fileName = allFileNames[i];
                Console.WriteLine("read file: {0}", fileName);               
                FileStream fileStream = new FileStream(fileName, FileMode.Open);
                
                
                //tasks.Add(Task.Factory.StartNew(() => wordProcessor.ReadFileAsync(fileStream, fileName)));
                tasks.Add(Task.Factory.StartNew(() => wordProcessor.ReadFileAsync(fileStream)));
            }

            Task.WaitAll(tasks.ToArray());

            //Process the words
            wordProcessor.CountAllWords();

            wordProcessor.CountDistinctWords();

            //find a word in file5.dat first
            wordProcessor.FindWord("egixinetovatixoconi");



            Console.WriteLine(" specific word manual added once");
            //manual entered in file6.dat
            wordProcessor.FindWord("catalintestword");



            wordProcessor.GroupWords();
            Console.ReadLine();
        }

      
        
    }
}
