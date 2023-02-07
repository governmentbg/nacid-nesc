using Microsoft.Extensions.DependencyInjection;
using StudentCard.Infrastructure.Emails;
using StudentCard.Infrastructure.Users;
using StudentCard.Infrastructure.Users.Interfaces;

namespace StudentCard.Infrastructure.DIExtensions
{
    public static class ServicesDIExtension
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services
                .AddScoped<IJWTService, JWTService>()
                .AddTransient<IPasswordService, PasswordService>()
                .AddTransient(typeof(IForgottenPasswordService<>), typeof(ForgottenPasswordService<>))
                .AddTransient(typeof(IEmailService<>), typeof(EmailService<>))
                .AddTransient<ILoginService, LoginService>()
            ;

            return services;
        }
    }
}
