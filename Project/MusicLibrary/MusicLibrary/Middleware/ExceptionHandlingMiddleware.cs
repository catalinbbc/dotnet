using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace MusicLibrary.api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        public async Task Invoke(HttpContext context)
        {

            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
            if (contextFeature != null && contextFeature.Error != null)
            {
                LogError(context, contextFeature.Error);

                context.Response.StatusCode = (int)GetErrorCode(contextFeature.Error);
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(JsonConvert.SerializeObject(new ProblemDetails()
                {
                    Status = context.Response.StatusCode,
                    Title = contextFeature.Error.Message
                }));
            }
        }

        private HttpStatusCode GetErrorCode(Exception error)
        {
            switch (error)
            {
                case ValidationException _:
                    return HttpStatusCode.BadRequest;                
                case AuthenticationException _:
                    return HttpStatusCode.Forbidden;               
                default:
                    return HttpStatusCode.InternalServerError;
            }
        }

        private void LogError(HttpContext context, Exception error)
        {
            var logger = (IRequestLogger)context.RequestServices.GetService(typeof(IRequestLogger));
            string fullname = error.GetType().FullName;
            if (fullname.StartsWith("Microsoft") || fullname.StartsWith("System"))
            {
                logger.LogError(error);
            }
            else
            {
                logger.LogWarning(error);
            }
        }
    }
}
