using ConferencePlanner.Entities;
using ConferencePlanner.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DapperQueries
{
    class SpeakerDapper : ISpeakerRepository
    {
        public SpeakerDapper()
        Task<IEnumerable<SpeakerResponseModel>> ISpeakerRepository.CountSessionPerSpeaker()
        {
            throw new NotImplementedException();
        }

        Task<Speaker> ISpeakerRepository.Get(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Session>> ISpeakerRepository.GetAllSessions(int id)
        {
            throw new NotImplementedException();
        }

        Task<int> ISpeakerRepository.Save(Speaker speaker)
        {
            throw new NotImplementedException();
        }
    }
}
