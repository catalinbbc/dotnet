using System;
using System.Collections.Generic;
using System.IO;

namespace Ex4ReadDir
{
    class Program
    {
        static void Main(string[] args)
        {


            Int32 exNumber = 0;
            string path;

            string[] files = new string[50];
            int fileId = 0;
            string fileName;


            try
            { 
             
               do
                {
                //Console.Clear();
                Console.WriteLine("\n\n\n##############################\nPlease enter an option:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Read dir from path");
                Console.WriteLine("2. open file content from #number above");
                Console.WriteLine("------------------------------------");

              


                    exNumber = Int32.Parse(Console.ReadLine());
                    //Console.WriteLine("Selected exercise: " + exNumber);

                    switch (exNumber)
                    {
                        case 0:
                            Console.WriteLine("Exiting..........");
                            break;
                        case 1:
                            Console.WriteLine("Enter a path from disk to read:");
                            path = Console.ReadLine();
                            int i = 0;
                            foreach (string file in GetFiles(path))
                            {

                                Console.WriteLine("#{0} ->{1}", i, file);
                                files[i] = file;
                                i++;
                            }
                            break;

                        case 2:
                            Console.WriteLine("Enter a  file # to load:");
                            fileId = Int32.Parse(Console.ReadLine());
                            fileName = files[fileId];

                            Console.WriteLine("File chosed#{0} :{1}", fileId, fileName);
                            Console.WriteLine("#######\nFile Content:\n");


                            string AllText = System.IO.File.ReadAllText(fileName);
                            Console.WriteLine(AllText);

                            break;


                        default:
                            Console.WriteLine("Invalid Selection :" + exNumber);
                            break;
                    }
                    // code block to be executed
                } while (exNumber > 0 && exNumber <= 3) ;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }





           

            
        }

        public static IEnumerable<string> GetFiles(string path)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(path);
            while (queue.Count > 0)
            {
                path = queue.Dequeue();
                try
                {
                    //get a list of dirs in current dir
                    foreach (string subDir in Directory.GetDirectories(path))
                    {
                        queue.Enqueue(subDir);
                    }
                }
                catch (DirectoryNotFoundException ex)
                {
                    //Console.Error.WriteLine(ex);
                    Console.WriteLine("Directory not found: "+path);
                }
                string[] files = null;
                try
                {
                    //call back the new path
                    files = Directory.GetFiles(path);
                }
               
                catch (DirectoryNotFoundException eDir)
                {
                    //Console.Error.WriteLine(eDir);
                    //Console.WriteLine("Directory not found 2: "+path);
                }
                catch (UnauthorizedAccessException exd)
                {
                    //Console.Error.WriteLine(exd);
                    Console.WriteLine("No   Access to:"+path);

                }
                catch (Exception exg)
                {
                    Console.Error.WriteLine(exg);

                }
                if (files != null)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        yield return files[i];
                    }
                }
            }
        }

   
    }

}
