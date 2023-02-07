using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentCard.Infrastructure.Configurations;

namespace StudentCard.Infrastructure.ConfigurationExtensions
{
    public static class ApplicationConfigurationExtension
    {
        public static IConfiguration ConfigureApplicationConfiguration(this IServiceCollection services, IWebHostEnvironment environment)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

            IConfiguration configuration = configurationBuilder.Build();

            services
                .Configure<AuthConfiguration>(config => configuration.GetSection("AuthConfiguration").Bind(config))
                .Configure<EmailsConfiguration>(config => configuration.GetSection("EmailConfiguration").Bind(config))
                .AddOptions();

            return configuration;
        }
    }
}
