namespace ConferencePlanner.App
{
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
 using ConferencePlanner.Data;
 using ConferencePlanner.Entities;
using ConferencePlanner.Services;
using Microsoft.EntityFrameworkCore;

    class SessionRepository<TEntity> : ISessionRepository<TEntity>
    {
        internal ApplicationDbContext context;
        internal DbSet<TEntity> dbSet;


        public SessionRepository(ApplicationDbContext context)

        {

            this.context = context;

            this.dbSet = context.Sessions<TEntity>

        }
        Task<Session> ISessionRepository.Get(int id)
        {
            throw new NotImplementedException();
        }

        Task<Session> ISessionRepository<TEntity>.Get(int id)
        {
            throw new NotImplementedException();
        }

        Task<Session> ISessionRepository.Remove(int id)
        {
            throw new NotImplementedException();
        }

        Task<Session> ISessionRepository<TEntity>.Remove(int id)
        {
            throw new NotImplementedException();
        }

        Task<Session> ISessionRepository.Save(Session session)
        {
            throw new NotImplementedException();
        }

        Task<Session> ISessionRepository<TEntity>.Save(Session session)
        {
            throw new NotImplementedException();
        }
    }
}
