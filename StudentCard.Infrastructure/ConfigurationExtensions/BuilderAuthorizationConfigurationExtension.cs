using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using StudentCard.Infrastructure.Constants;
using System.Security.Claims;

namespace StudentCard.Infrastructure.ConfigurationExtensions
{
    public static class BuilderAuthorizationConfigurationExtension
    {
        public static void ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy =
                    new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();

                options.AddPolicy("default",
                    p => p.RequireAuthenticatedUser());

                options.AddPolicy("RequireAdministratorRole", p =>
                {
                    p.RequireClaim(ClaimTypes.Role, UserRoleAliases.ADMINISTRATOR);
                });
            });
        }
    }
}
