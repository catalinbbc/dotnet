namespace ConferencePlanner.App
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using ConferencePlanner.Data.Entities;
    using Data;
    using Microsoft.EntityFrameworkCore;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using var context = new ApplicationDbContext();

            Ex01.Run(context);
        }
    }

    internal class Ex01
    {
        public static void Run(ApplicationDbContext context)
        {

            /*
            var attendee = context.Attendees.Add(
                new Data.Entities.Attendee
                {
                    EmailAddress = "Alabala@wwww.com",
                    FirstName = "Cata",
                    LastName = "Lin",
                    UserName = "cata1"
                }
                ) ;

            context.Tracks.Add(new Track { Name = "The Track 12" });

            context.SaveChanges();
            */
            var attendee = context.Attendees.Add(
                 new Data.Entities.Attendee
                 {
                     EmailAddress = "newEmail@wwww.com",
                     FirstName = "Catalin",
                     LastName = "LinData",
                     UserName = "cata45",
                     DateOfBirth = new DateTime(2020, 6, 23, 12, 4, 9)
                  }
                 );

            context.SaveChanges();
            

        }
    }

    internal class Ex02
    {
        public static void Run(ApplicationDbContext context)
        {
            // Todo
            // on Tracks table, add PHP, C# tracks with a seed
            // update ApplicationDbContext to run a seed
        }
    }

    internal class Ex03
    {
        public static void Run(ApplicationDbContext context)
        {
            // Todo
            // on Attendee model, add a new property, date of birth
            // add a migration, run the migration
            // insert then read a Attendee


            var atandee = context.Attendees.Add(new Attendee
            {

                FirstName = "Test",
                LastName = " First",
                UserName = "catalin1122",
                EmailAddress = "catalin@yahoo.com",
                DateOfBirth = new DateTime(1980, 07, 27)
            });
            context.SaveChanges();

            var theAttendee = context.Attendees
                    .Where(b => b.EmailAddress == "catalin@yahoo.com")
                    .First();

            Console.WriteLine("New Id = {0}",theAttendee.Id);
            Console.WriteLine("FirstName = {0}",theAttendee.FirstName);

            Console.WriteLine($"Last Name = {0}",theAttendee.LastName);
            Console.WriteLine($"Email = {0}",theAttendee.EmailAddress);
            Console.WriteLine($"Date Of Birth = {0}",theAttendee.DateOfBirth.Date);
        }

    
    }

    internal class Ex04
    {
        public static void Run(ApplicationDbContext context)
        {
            // Todo
            // have a look on ConferencePlanner.Services and ISessionRepository
            // implement the repository inside the Data project
            // use the repository here in order to read 
            
            SessionRepository repo = new SessionRepository(context);
            //add new record
            repo.Save(new Entities.Session
                    { 
                        Title = "New Conference Title", 
                        TrackId = 19 
                    });


           
            //use repo to get the record
            var record = repo.Get(19);
            Console.WriteLine("The db record TrackID{0}", record.Result.TrackId);
            Console.WriteLine("The db record title{0}", record.Result.Title);
                        
        }
    }

    internal class Ex05
    {
        // todo
        // rename the Speaker.Name to Speaker.FullName
        // you should add a migration
    }

    internal class Ex06
    {
        public static void Run(ApplicationDbContext context)
        {
            // todo
            // all Sessions that title contains ".NET"
            Console.WriteLine("all Sessions that title contains \".NET\"");
            SessionRepository repo = new SessionRepository(context);
            var sessions = repo.GetByTitle(".NET");

           
            foreach (Session session in sessions)
            {
                Console.WriteLine("Session {0}, with Tile =  {1}", session.Id,session.Title);
            }


            // number of sessions for each speaker
            Console.WriteLine("number of sessions for each speaker");
            var speakerQuery = context.SessionSpeaker.GroupBy(s => s.SpeakerId)
                              .Select(e => new { e.Key, Count = e.Count() })
                              .ToDictionary(e => e.Key, e => e.Count);
            foreach (var speaker in speakerQuery)
            {
                Console.WriteLine("Speaker {0} has:  {1} sessions", speaker.Key, speaker.Value);
            }

            // number of tracks per session
            Console.WriteLine("number of tracks per session");
            var tracksQuery = context.Sessions.GroupBy(s => s.TrackId)
                   .Select(e => new { e.Key, Count = e.Count() })
                   .ToDictionary(e => e.Key, e => e.Count);
            foreach (var tracks in tracksQuery)
            {
                Console.WriteLine("Session {0} has {1} tracks", tracks.Key, tracks.Value);
            }



            // all tracks for each session
            Console.WriteLine(" all tracks for each session");
            DbSet<Session> newSessionDb = context.Sessions;
            DbSet<Track> newTracksDb = context.Tracks;

            //join the repos 
            var allTracksPerSession =
                newSessionDb.Join(
                    newTracksDb,
                    session => session.TrackId,
                    track => track.Id,
                    (session, track) => new
                    {
                        SessionID = session.Id,
                        TrackName = track.Name,
                    });

            foreach (var sessionTraks in allTracksPerSession)
            {
                Console.WriteLine("SessionID: {0}  contains TrackName: {1} ", sessionTraks.SessionID, sessionTraks.TrackName);
            }
        }
    }   

    internal class Ex07
    {
        public static void Run(ApplicationDbContext context)
        {
            // todo
            // get all sessions for one speaker
            //use lazy to bring sessionData

            int theSpeakerId = 123;
            var speakerSessions = context.SessionSpeaker
                .Where(s => s.SpeakerId == theSpeakerId)
                .Include(s => s.Session);

            Console.WriteLine("All the session for the speaker [{0}]", theSpeakerId);
            foreach (var sessionSpeaker in speakerSessions)
            {
                Console.WriteLine("SessionId[{0}] with title {1}", sessionSpeaker.Session.Id,sessionSpeaker.Session.Title);
            }
        }
    }

    internal class Ex08
    {
        public static void Run()
        {
            // todo
            // create a separate project for dapper
            // implement the ISpeakerRepository using dapper
        }
    }

    internal class Ex09
    {
        public static void Run()
        {
            // todo
            // create view
            /*
               create view AllSessionsAndSpeakersView as
               select ses.Title, sp.Name, ses.StartTime from Sessions ses
               join SessionSpeaker ss on ses.Id = ss.SessionId
               join Speakers sp on sp.Id = ss.SpeakerId
            */

            // use the view from Dapper
            // display all information at console
        }
    }

    internal class Ex10
    {
        public static void Run()
        {
            // todo
            // use Dapper Plus
            // bulk insert 10 attendees
        }
    }
}
