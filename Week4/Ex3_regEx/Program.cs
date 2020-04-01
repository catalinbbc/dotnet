using DocumentFormat.OpenXml.ExtendedProperties;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Ex3_regEx
{
    class Program
    {
        
    static void Main(string[] args)

        {
            string[] Urls = new string[50];

            try
            {
                String AllText = System.IO.File.ReadAllText(@"d:\dotnet\dotnet\Week4\Ex3_regEx\InputFile.txt");




                //#############################################################
                Console.WriteLine("1.Extract all the URLs");
                Regex r = new Regex(@"(?<Protocol>\w+)*(:\/\/)*(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*", RegexOptions.IgnoreCase);
                MatchCollection matchCollection = r.Matches(AllText);
                int i = 1;
                foreach (Match match in matchCollection)
                {
                    Console.WriteLine("#{0} - Url:  {1}", i, match.Value);
                    i++;
                }

                //#############################################################
                Console.WriteLine("\n2.Display all the URLs which start with https://");
                //reset collection 
                i = 1;
                foreach (Match match in matchCollection)
                {
                    if (match.Groups["Protocol"].Value == "https")
                    {
                        Console.WriteLine("#{0} - Url:{1}", i, match.Value);
                        i++;

                    }
                }


                //#############################################################
                Console.WriteLine("\n3.URLs ending with .edu");
                i = 1;
                foreach (Match match in matchCollection)
                {

                    Regex reg = new Regex(@".edu");
                    Match m = reg.Match(match.Value);

                    if (m.Success)
                    {
                        Console.WriteLine("#{0} - Url:{1}  is .edu", i, match.Value);
                        i++;
                    }
                }


                //#############################################################
                Console.WriteLine("\n4.Replace all the vowels in url with given character");
                i = 1;
                string replaceChar = "_";

                foreach (Match match in matchCollection)
                {

                    Regex reg = new Regex(@"[aeiou]");
                    string urlNoVouls = reg.Replace(match.Value, replaceChar);
                    Console.WriteLine("#{0} - Url:{1}  ", i, urlNoVouls);
                    i++;
                }



                //#############################################################
                Console.WriteLine("\n5.Replace all the numbers in the URL with 1 and display");
                i = 1;


                foreach (Match match in matchCollection)
                {

                    Regex reg = new Regex(@"\d");
                    string urlNoVouls = reg.Replace(match.Value, "1");
                    Console.WriteLine("#{0} - Url:{1}  ", i, urlNoVouls);
                    i++;
                }

                //#############################################################
                Console.WriteLine("\n6.Display all duplicate URLs");
                //    
                //Regex rd = new Regex(@"/ (\b\S +\b)\s +\b\1\b /", RegexOptions.IgnoreCase);
               // Regex rd = new Regex(@".*(.+).*\1.*\1.*", RegexOptions.IgnoreCase);
                Regex regDup = new Regex(@".*(.+)\1\1.*", RegexOptions.IgnoreCase);
                Match textDuplicates = regDup.Match(AllText);

                MatchCollection duplicates = r.Matches(textDuplicates.Value);
               
                i = 1;
                foreach (Match match in matchCollection)
                {

                    Console.WriteLine("#{0} - Url:{1}  ", i, match.Groups["Domain"].Value);
                    //Console.WriteLine("#{0} - Url:{1}  ", i, match.Value);
                    i++;

                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        

           
        }

       
    }
}
