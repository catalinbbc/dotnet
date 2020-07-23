using Microsoft.Extensions.Logging;
using System;

namespace MusicLibrary.api.Middleware
{
    public interface IRequestLogger
    {
        void LogInfo(string message);
    }

    public class RequestLogger : IRequestLogger
    {
        private readonly Guid id;
        private readonly ILogger<RequestLogger> logger;

        public RequestLogger(ILogger<RequestLogger> logger)
        {
            this.id = Guid.NewGuid();

            this.logger = logger;
        }

        public void LogInfo(string message)
        {
            this.logger.LogInformation($"{this.id} : {message}");
        }
    }
}