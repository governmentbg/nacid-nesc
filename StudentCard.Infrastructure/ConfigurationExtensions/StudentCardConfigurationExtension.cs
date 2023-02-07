using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentCard.Infrastructure.Configurations;

namespace StudentCard.Infrastructure.ConfigurationExtensions
{
    public static class StudentCardConfigurationExtension
    {
        public static IConfiguration ConfigureStudentCardConfiguration(this IServiceCollection services, IWebHostEnvironment environment)
        {
            var configuration = services.ConfigureApplicationConfiguration(environment);

            services
                .Configure<StudentConfiguration>(config => configuration.GetSection("StudentConfiguration").Bind(config))
                .Configure<PublicPortalConfiguration>(config => configuration.GetSection("PublicPortalConfiguration").Bind(config))
                .AddOptions();

            return configuration;
        }
    }
}
