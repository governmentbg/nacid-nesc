using Microsoft.EntityFrameworkCore;
using StudentCard.Infrastructure.Interfaces.Contexts;

namespace StudentCard.Persistence
{
    public class AppLogContext : LogContext<AppLogContext>, IAppLogContext
    {
        public AppLogContext(DbContextOptions<AppLogContext> options)
            : base(options)
        {
        }
    }
}
