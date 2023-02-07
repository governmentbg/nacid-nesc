using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentCard.Application.Common.Interfaces;
using StudentCard.Application.Common.Services;
using StudentCard.Application.Students.Dtos;
using StudentCard.Application.Students.Interfaces;
using StudentCard.Data.Rdpzsd.Students;
using StudentCard.Data.Rdpzsd.Students.Parts;
using StudentCard.Data.Students;
using StudentCard.Infrastructure.Configurations;
using StudentCard.Infrastructure.Interfaces;
using StudentCard.Infrastructure.Interfaces.Contexts;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Application.Students
{
    public class ElectronicCardService : IElectronicCardService
    {
        private readonly IRdpzsdDbContext rdpzsdContext;
        private readonly IAppDbContext context;
        private readonly IPdfFileService pdfFileService;
        private readonly PublicPortalConfiguration publicPortalConfiguration;
        private readonly QrCodeService qrCodeService;
        private readonly IUserContext userContext;

        public ElectronicCardService(
            IRdpzsdDbContext rdpzsdContext,
            IAppDbContext context,
            IPdfFileService pdfFileService,
            IOptions<PublicPortalConfiguration> publicPortalOptions,
            QrCodeService qrCodeService,
            IUserContext userContext
            )
        {
            this.rdpzsdContext = rdpzsdContext;
            this.context = context;
            this.pdfFileService = pdfFileService;
            this.publicPortalConfiguration = publicPortalOptions.Value;
            this.qrCodeService = qrCodeService;
            this.userContext = userContext;
        }

        public async Task<ElectronicCardDto> GetStudentElectronicCardInfo(bool inBulgarian, CancellationToken cancellationToken)
        {
            var studentUan = await this.context.Set<Student>()
                .Where(s => s.Id == this.userContext.UserId)
                .Select(s => s.UAN)
                .SingleOrDefaultAsync(cancellationToken);

            return await this.rdpzsdContext.Set<PersonLot>()
                .Where(pl => pl.Uan == studentUan)
                .Select(pl => new ElectronicCardDto
                {
                    FullName = pl.PersonBasic.FullName,
                    FullNameAlt = pl.PersonBasic.FullNameAlt,
                    QrCodeImageBg = this.qrCodeService.Create(this.publicPortalConfiguration.QrCodeUrlTemplate + $"{pl.Uan}" + "&lg=bg"),
                    QrCodeImageEn = this.qrCodeService.Create(this.publicPortalConfiguration.QrCodeUrlTemplate + $"{pl.Uan}" + "&lg=en"),
                    Uan = pl.Uan,
                    BirthDate = pl.PersonBasic.BirthDate,
                    FormatedBirthDate = inBulgarian 
                        ? pl.PersonBasic.BirthDate.ToString("dd MMMM yyy", new CultureInfo("bg-BG")) 
                        : pl.PersonBasic.BirthDate.ToString("dd MMMM yyy", new CultureInfo("en-US")),
                    HasActiveSpecialities = pl.PersonStudents.Any(ps => ps.StudentStatus.Alias == "active"),
                    HasActiveDoctorals = pl.PersonDoctorals.Any(ps => ps.StudentStatus.Alias == "active")
                })
                .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<string> GetStudentElectronicCardPdf(bool inBulgarian, CancellationToken cancellationToken)
        {
            byte[] template;

            if (inBulgarian)
            {
                template = await File.ReadAllBytesAsync("./HtmlFileTemplates/ElectronicCardTemplate.html", cancellationToken);
            }
            else
            {
                template = await File.ReadAllBytesAsync("./HtmlFileTemplates/ElectronicCardTemplateEn.html", cancellationToken);
            }

            var studentInfo = await this.GetStudentElectronicCardInfo(inBulgarian, cancellationToken);

            return Convert.ToBase64String(await this.pdfFileService.GeneratePdfFile(studentInfo, template, false));
        }
    }
}
