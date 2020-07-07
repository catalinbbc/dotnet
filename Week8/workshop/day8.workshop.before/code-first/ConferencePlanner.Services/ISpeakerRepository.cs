namespace ConferencePlanner.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;

    public interface ISpeakerRepository
    {
         int CountSessionPerSpeaker();

        Speaker Get(int id);

        IEnumerable<Session> GetAllSessions(int id);

        long Save(Speaker speaker);
    }

    public class SpeakerResponseModel
    {
        public int Id { get; set; }

        public int SessionsCount { get; set; }
    }
}
