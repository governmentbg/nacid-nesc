using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NCrontab;
using StudentCard.Application.Students.Interfaces;
using StudentCard.Data.Logs.Enums;
using StudentCard.Infrastructure.Configurations;
using StudentCard.Infrastructure.Logs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Hosting.BackgroundServices
{
    public class StudentJob : IHostedService, IDisposable
    {
        private readonly IServiceProvider serviceProvider;
        private readonly StudentConfiguration studentConfiguration;
        private Timer timer;

        public StudentJob(IServiceProvider serviceProvider, IOptions<StudentConfiguration> options)
        {
            this.serviceProvider = serviceProvider;
            studentConfiguration = options.Value;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var schedule = CrontabSchedule.Parse(studentConfiguration.JobSchedule);
            var nextRun = schedule.GetNextOccurrence(DateTime.Now);
            var dueTime = nextRun - DateTime.Now;
            timer = new Timer(async o => await DoWork(o, cancellationToken), null, dueTime, TimeSpan.FromSeconds(studentConfiguration.JobPeriod));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timer?.Dispose();
        }

        private async Task DoWork(object state, CancellationToken cancellationToken)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var logService = scope.ServiceProvider.GetRequiredService<ILoggingService>();
                var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();

                try
                {
                    await studentService.CreateStudents(studentConfiguration.JobLimit, cancellationToken);
                }
                catch (Exception ex)
                {
                    await logService.LogExceptionAsync(ex, LogType.StudentJobExceptionLog);
                }
            }
        }
    }
}
