using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using SSL.API.Services;
using StudentCard.Infrastructure.Auth;
using StudentCard.Infrastructure.ConfigurationExtensions;
using StudentCard.Infrastructure.Interfaces;
using StudentCard.Infrastructure.Interfaces.Contexts;
using StudentCard.Persistence;
using StudentCard.Persistence.Extensions;
using System.Security.Claims;

namespace SSL.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

            IConfiguration configuration = configurationBuilder.Build();

            // Add services to the container.

            builder.Services
                .AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme)
                .AddCertificate(options =>
                    {
                        options.AllowedCertificateTypes = CertificateTypes.All;

                        options.Events = new CertificateAuthenticationEvents
                        {
                            OnCertificateValidated = context =>
                            {
                                var validationService = context.HttpContext.RequestServices
                                    .GetRequiredService<ICertificateValidationService>();

                                if (validationService.ValidateCertificate(context.ClientCertificate))
                                {
                                    var claims = new[]
                                    {
                                        new Claim(
                                            ClaimTypes.NameIdentifier,
                                            context.ClientCertificate.Subject,
                                            ClaimValueTypes.String, context.Options.ClaimsIssuer),
                                        new Claim(
                                            ClaimTypes.Name,
                                            context.ClientCertificate.Subject,
                                            ClaimValueTypes.String, context.Options.ClaimsIssuer)
                                    };

                                    context.Principal = new ClaimsPrincipal(
                                        new ClaimsIdentity(claims, context.Scheme.Name));
                                    context.Success();
                                }

                                return Task.CompletedTask;
                            }
                        };
                    });

            builder.Services
                .AddControllers(options =>
                {
                    options.OutputFormatters.Add(new HttpNoContentOutputFormatter());
                    options.Filters.Add(new ProducesAttribute("application/json"));
                })
                .AddJson();

            builder.Services
                .AddPersistence<IAppDbContext, AppDbContext>(configuration.GetSection("DbConfiguration:ConnectionString").Value, builder.Environment.IsDevelopment())
                .AddPersistence<IRdpzsdDbContext, RdpzsdDbContext>(configuration.GetSection("DbConfiguration:RdpzsdConnectionString").Value, builder.Environment.IsDevelopment());

            builder.Services
                .AddScoped<ICertificateValidationService, CertificateValidationService>()
                .AddHttpContextAccessor()
                .AddScoped<IUserContext, UserContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}