using FileStorageNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentCard.Application;
using StudentCard.Hosting.BackgroundServices;
using StudentCard.Infrastructure.DIExtensions;
using StudentCard.Infrastructure.BackgroundServices;
using StudentCard.Infrastructure.ConfigurationExtensions;
using StudentCard.Infrastructure.Configurations;
using StudentCard.Infrastructure.Interfaces.Contexts;
using StudentCard.Infrastructure.Middlewares;
using StudentCard.Persistence;
using StudentCard.Persistence.Extensions;
using StudentCard.Hosting.Models;
using Microsoft.Extensions.Options;
using StudentCard.Hosting.Extensions;
using ProxyKit;
using RegiXConsumer;

namespace StudentCard.Hosting
{
    public class Startup
    {
        private readonly IWebHostEnvironment environment;

        public Startup(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services
                .AddControllers(options =>
                {
                    options.OutputFormatters.Add(new HttpNoContentOutputFormatter());
                    options.Filters.Add(new ProducesAttribute("application/json"));
                })
                .AddJson()
                ;

            var configuration = services.ConfigureStudentCardConfiguration(environment);

            var authConfig = configuration.GetSection("AuthConfiguration").Get<AuthConfiguration>();
            services.ConfigureJwtAuthService(authConfig.SecretKey, authConfig.Issuer, authConfig.Audience);

            services
                .AddPersistence<IAppDbContext, AppDbContext>(configuration.GetSection("DbConfiguration:ConnectionString").Value, environment.IsDevelopment())
                .AddPersistence<IAppLogContext, AppLogContext>(configuration.GetSection("DbConfiguration:LogConnectionString").Value, environment.IsDevelopment())
                .AddPersistence<IRdpzsdDbContext, RdpzsdDbContext>(configuration.GetSection("DbConfiguration:RdpzsdConnectionString").Value, environment.IsDevelopment())
                .AddApplication()
                .AddApiServices()
                .AddCommonServices()
                .AddPublicServices()
                ;

            services.Configure<RegiXConfiguration>(configuration.GetSection("RegiXConfiguration"));

            services.AddRegiXServices();

            services.Configure<ReCaptchaConfiguration>(configuration.GetSection("ReCaptchaConfiguration"));

            services.Configure<ProxyPath>(configuration.GetSection("ProxyPaths"));
            services.AddProxy();

            services.AddFileStorage(configuration.GetSection("DbConfiguration:Descriptors"), configuration.GetSection("DbConfiguration:Encryption"));

            services.ConfigureAuthorization();

            var emailConfiguration = configuration.GetSection("EmailConfiguration").Get<EmailsConfiguration>();
            if (emailConfiguration.JobEnabled)
            {
                services.AddHostedService<EmailJob<IAppDbContext>>();
            }

            var studentConfiguration = configuration.GetSection("StudentConfiguration").Get<StudentConfiguration>();
            if (studentConfiguration.JobEnabled)
            {
                services.AddHostedService<StudentJob>();
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<ProxyPath> proxyPathsOptions)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();

            app.ConfigureProxy(proxyPathsOptions.Value);

            app.UseMiddleware<RedirectionMiddleware>();
            app.UseMiddleware<RequestLoggingMiddleware>();

            app.UseRouting();

            app.UseDefaultFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = context =>
                {
                    if (context.File.Name == "index.html")
                    {
                        context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
                        context.Context.Response.Headers.Add("Expires", "-1");
                    }
                }
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints
               .MapControllers()
               .RequireAuthorization()
           );
        }
    }
}
