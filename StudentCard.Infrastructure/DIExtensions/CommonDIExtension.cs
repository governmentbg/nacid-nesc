using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using StudentCard.Infrastructure.Auth;
using StudentCard.Infrastructure.DomainValidation;
using StudentCard.Infrastructure.Interfaces;
using StudentCard.Infrastructure.Logs;
using StudentCard.Infrastructure.Services;
using System;

namespace StudentCard.Infrastructure.DIExtensions
{
    public static class CommonDiExtension
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services)
        {
            services
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
            ;

            services
                .AddScoped<IUserContext, UserContext>();

            services
                .AddScoped<IImageFileService, ImageFileService>()
                .AddScoped<ILoggingService, DbLoggingService>()
                .AddScoped<DomainValidationService>()
            ;

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return services;
        }
    }
}
