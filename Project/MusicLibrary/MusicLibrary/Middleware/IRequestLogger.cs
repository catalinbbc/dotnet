using Microsoft.Extensions.Logging;
using System;

namespace MusicLibrary.api.Middleware
{
    public interface IRequestLogger
    {
        void LogInfo(string message);

        void LogError(Exception exception);

        void LogWarning(Exception exception);
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

        public void LogError(Exception exception)
        {
            this.logger.LogError(exception, "Error");
        }

        public void LogInfo(string message)
        {
            this.logger.LogInformation($"{this.id} : {message}");
        }

        public void LogWarning(Exception exception)
        {
            this.logger.LogWarning(exception, "Warning");
        }
    }
}