using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using StudentCard.Data.Emails;
using StudentCard.Data.Emails.Enums;
using StudentCard.Infrastructure.Configurations;
using StudentCard.Infrastructure.Emails;
using StudentCard.Infrastructure.Interfaces.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Infrastructure.BackgroundServices
{
    public class EmailJob<TContext> : IHostedService, IDisposable
        where TContext : IBaseContext
    {
        private readonly IServiceProvider serviceProvider;
        private readonly EmailsConfiguration emailConfiguration;
        private Timer timer;

        public EmailJob(IServiceProvider serviceProvider, IOptions<EmailsConfiguration> options)
        {
            this.serviceProvider = serviceProvider;
            emailConfiguration = options.Value;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(emailConfiguration.JobPeriod));

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

        private void DoWork(object state)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<TContext>();
                var emailService = scope.ServiceProvider.GetRequiredService<IEmailService<TContext>>();

                var pendingEmails = emailService.GetPendingEmails(emailConfiguration.JobLimit);

                foreach (var email in pendingEmails)
                {
                    bool isSent = emailService.SendEmail(email, emailConfiguration);
                    foreach (EmailAddressee addressee in email.Addressees)
                    {
                        if (addressee.Status == EmailStatus.InProcess)
                        {
                            addressee.Status = isSent ? EmailStatus.Sent : EmailStatus.Failed;
                        }
                    }
                }

                dbContext.SaveChangesAsync();
            }
        }
    }
}
