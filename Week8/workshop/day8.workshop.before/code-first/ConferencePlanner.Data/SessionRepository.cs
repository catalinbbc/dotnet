using ConferencePlanner.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferencePlanner.Data
{

    public class SessionRepository : ISessionRepository
    {
        private ApplicationDbContext context;

        public SessionRepository(ApplicationDbContext context)
        {
            this.context = context;

        }
        public Task<Session> Get(int id)
        {
            return Task.FromResult((Session)context.Sessions.Find(id));
        }
               

        public void Save(Session session)
        {
            Task.FromResult(context.Sessions.Add((Data.Entities.Session)session));
        }

        public void Remove(int id)
        {
            Session session = context.Sessions.Find(id);
            context.Sessions.Remove((Data.Entities.Session)session);
        }

        public List<Data.Entities.Session> GetByTitle(string searchTitle)
        {
            return context.Sessions.Where(s => s.Title == searchTitle).ToList();
        }
    }
}
