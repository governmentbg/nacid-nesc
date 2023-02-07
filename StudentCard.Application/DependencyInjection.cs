using Microsoft.Extensions.DependencyInjection;
using StudentCard.Application.Portal.Services;
using StudentCard.Application.Common.Interfaces;
using StudentCard.Application.Common.Services;
using StudentCard.Application.HistoryLogs;
using StudentCard.Application.HistoryLogs.Interfaces;
using StudentCard.Application.Portal.Interfaces;
using StudentCard.Application.Students;
using StudentCard.Application.Students.Interfaces;
using StudentCard.Application.Users;
using StudentCard.Application.Users.Interfaces;
using StudentCard.Infrastructure.Captcha;
using StudentCard.Application.Feedback.Interfaces;
using StudentCard.Application.Feedback;

namespace StudentCard.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddTransient<IActivationService, ActivationService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<QrCodeService>()
                .AddTransient<IPdfFileService, PdfFileService>()
                ;

            services
                .AddTransient<IStudentService, StudentService>()
                .AddTransient<IElectronicCardService, ElectronicCardService>()
                .AddTransient<IHistoryLogService, HistoryLogService>()
                .AddTransient<IRdpzsdService, RdpzsdService>();
                ;

            services
                .AddTransient<IRegisterService, RegisterService>()
                .AddTransient<IFeedbackService, FeedbackService>()
                ;

            return services;
        }

        public static IServiceCollection AddPublicServices(this IServiceCollection services)
        {
            services
                .AddTransient<IStudentPortalService, StudentPortalService>()
                .AddTransient<IHistoryLogService, HistoryLogService>()
            ;

            services
                .AddScoped<CaptchaService>();

            return services;
        }
    }
}
