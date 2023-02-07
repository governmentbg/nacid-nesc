using Microsoft.AspNetCore.Http;
using StudentCard.Data.Logs.Enums;
using System;
using System.Threading.Tasks;

namespace StudentCard.Infrastructure.Logs
{
    public interface ILoggingService
    {
        Task LogRequestAsync(HttpRequest request);

        Task LogExceptionAsync(Exception ex, LogType type, HttpRequest request = null);

        Task LogMessageAsync(string message, HttpRequest request = null);
    }
}
