using ConferencePlanner.Entities;
using ConferencePlanner.Services;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DapperQueriesTest
{
    class SpeakerDapper : ISpeakerRepository
    {
        private SqlConnection dbConnection;
        public SpeakerDapper(SqlConnection connection)
        {
            this.dbConnection = connection;
        }

        public List<DbDataSet> CountSessionPerSpeaker()
        {
            return dbConnection.Query<DbDataSet>("" +
                "SELECT " +
                "COUNT(SpeakerId) AS NumberOfSessions , sessionSp.SpeakerId, Speaker.FullName as SpeakerName " +
                "FROM SessionSpeaker AS sessionSp  " +
                "LEFT JOIN Speaker on sessionSp.SpeakerId = Speaker.Id"+
                "GROUP BY sessionSp.SpeakerId;").
                ToList();
        }

        public Speaker Get(int id)
        {
            return dbConnection.Query<Speaker>("" +
                "SELECT * " +
                "FROM Speakers" +
                "WHERE Id = @SpeakerID;", 
                new { SpeakerID = id })
                .First();
        }

        public IEnumerable<Session> GetAllSessions(int id)
        {
            return dbConnection.Query<Session>("" +
                "SELECT * " +
                "FROM SessionSpeaker AS sessionSp " +
                "INNER JOIN Sessions AS s ON s.Id=sessionSp.SessionId " +
                "WHERE ss.SpeakerId = @SpeakerID;", 
                new { SpeakerID = id }).
                ToList();
        }

        public IEnumerable<Speaker> GetSpeakers()
        {
            return dbConnection.Query<Speaker>("" +
                "SELECT * " +
                "FROM Speakers")
                .ToList();
        }
        public long Save(Speaker speaker)
        {
            return dbConnection.Insert(speaker);
        }

        int ISpeakerRepository.CountSessionPerSpeaker()
        {
            throw new NotImplementedException();
        }
    }
}
