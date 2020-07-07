using ConferencePlanner.Data.Entities;
using Microsoft.Data.SqlClient;
using System;

namespace DapperQueriesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test Using Dapper repo!");

            var dapperRepo = new SpeakerDapper(ConfigDb());

            //////////////////
            Console.WriteLine("List all Speakes");
            var speakers = dapperRepo.GetSpeakers();
            foreach (var speaker in speakers)
            {
                Console.WriteLine(speaker.FullName);
            }

            ////////////////////////////
            Console.WriteLine("Nr of Sessions per speaker");
            var sessions = dapperRepo.CountSessionPerSpeaker();
            foreach (var speaker in sessions)
            {
                Console.WriteLine("SpeakerId [{0}] {1} has  {2} sessions", speaker.SpeakerId, speaker.SpeakerName, speaker.NumberOfSessions);
            }


            ///////////////////////////////
            Console.WriteLine("Get a specific speaker details");
            var specificSpeaker = dapperRepo.Get(123);
            Console.WriteLine("Id = {0}",specificSpeaker.Id);
            Console.WriteLine("Name = {0}",specificSpeaker.FullName);
            Console.WriteLine("Full Bio = {0}",specificSpeaker.Bio);


            ////////////////////////////
            Console.WriteLine("Save a new speaker");
            var newSpeaker = new Speaker();

           // newSpeaker.Id = 55; - auto increment

            newSpeaker.FullName = "The New speaker";
            newSpeaker.Bio = "This is the last Speaker added to our group but is teh best";
            dapperRepo.Save(newSpeaker);

        }

        protected static SqlConnection ConfigDb()
        {
            return new SqlConnection(@"data source=.\SQLExpress; database=ConferencePlanner; integrated security=SSPI");
        }
    }

   
}
