using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using StudentCard.Data.Logs;
using StudentCard.Data.Logs.Enums;
using StudentCard.Infrastructure.DomainValidation.Models;
using StudentCard.Infrastructure.Interfaces.Contexts;
using StudentCard.Infrastructure.Logs.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCard.Infrastructure.Logs
{
    public class DbLoggingService : ILoggingService
    {
        private readonly IAppLogContext context;

        public DbLoggingService(IAppLogContext context)
        {
            this.context = context;
        }

        public async Task LogExceptionAsync(Exception exception, LogType type, HttpRequest request = null)
        {
            string exceptionMessage;
            if (exception is DomainErrorException customException)
            {
                exceptionMessage = "Message:" + " " + string.Join(", ", customException.ErrorMessages.Select(x => x.DomainErrorCode)) + " " + $"\nStackTrace: {exception.StackTrace}";
            }
            else
            {
                exceptionMessage = $"Message: {exception.Message} \nStackTrace: {exception.StackTrace}";
            }

            await this.LogAsync(type, exceptionMessage, request);
        }

        public async Task LogRequestAsync(HttpRequest request)
        {
            await this.LogAsync(LogType.TraceLog, null, request);
        }

        public async Task LogMessageAsync(string message, HttpRequest request = null)
        {
            await this.LogAsync(LogType.InformationMessageLog, message, request);
        }

        private async Task LogAsync(LogType type, string message, HttpRequest request = null)
        {
            var log = new Log
            {
                Type = type,
                LogDate = DateTime.UtcNow,
                IP = request?.HttpContext.Connection.RemoteIpAddress.ToString(),
                Verb = request?.Method,
                Url = request?.GetDisplayUrl(),
                UserAgent = request?.Headers["User-Agent"].ToString(),
                Message = message,
                UserId = request?.GetUserId()
            };

            this.context.Set<Log>().Add(log);
            await this.context.SaveChangesAsync();
        }
    }
}
