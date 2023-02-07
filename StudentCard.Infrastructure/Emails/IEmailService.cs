using StudentCard.Data.Emails;
using StudentCard.Infrastructure.Interfaces;
using StudentCard.Infrastructure.Interfaces.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentCard.Infrastructure.Emails
{
    public interface IEmailService<TContext>
        where TContext : IBaseContext
    {
        IEnumerable<Email> GetPendingEmails(int limit);

        Task<Email> ComposeEmailAsync(string alias, object templateData, params string[] recipients);

        bool SendEmail(Email email, IEmailConfiguration emailConfiguration);
    }
}
