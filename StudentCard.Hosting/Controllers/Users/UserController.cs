using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RegiXConsumer;
using RegiXConsumer.Models;
using RegiXConsumer.Services;
using StudentCard.Application.Students.Interfaces;
using StudentCard.Application.Users.Dtos;
using StudentCard.Application.Users.Interfaces;
using StudentCard.Application.Users.Models;
using StudentCard.Infrastructure.Configurations;
using StudentCard.Infrastructure.DomainValidation;
using StudentCard.Infrastructure.DomainValidation.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using static RegiXServiceReference.RegiXEntryPointV2Client;

namespace StudentCard.Hosting.Controllers.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
		private readonly IRdpzsdService rdpzsdService;
		private readonly IStudentService studentService;
        private readonly IRegiXService regiXService;
        private readonly RegiXConfiguration regiXConfiguration;
		private readonly DomainValidationService validation;

		public UserController(
            IUserService userService,
            IRdpzsdService rdpzsdService,
            IStudentService studentService,
            IRegiXService regiXService,
            IOptions<RegiXConfiguration> options,
            DomainValidationService validation
            )
        {
            this.userService = userService;
			this.rdpzsdService = rdpzsdService;
			this.studentService = studentService;
            this.regiXService = regiXService;
            this.regiXConfiguration = options.Value;
			this.validation = validation;
		}

        [HttpPost("NewPassword")]
        public Task ChangePassword([FromBody] ChangePasswordDto dto, CancellationToken cancellationToken)
           => this.userService.ChangeUserPassword(dto, cancellationToken);

        [HttpPost("NewEmailAddress")]
        public Task SendUserChangeEmailAddressLink([FromBody] ChangeEmailAddressDto dto, CancellationToken cancellationToken)
           => this.userService.SendUserChangeEmailAddressLink(dto, cancellationToken);

        [HttpPost("TakeNameFromGRAO")]
        public async Task<RegiXGRAOResponse> TakeNameFromGRAO(CancellationToken cancellationToken)
        {
            var student = await this.studentService.GetLoggedInStudent();

            var requestParams = new RegiXParameters()
            {
                CertificateThumbprint = this.regiXConfiguration.CertificateThumbprint,
                OperationName = "TechnoLogica.RegiX.GraoNBDAdapter.APIService.INBDAPI.PersonDataSearch",
                RequestBody = string.Format(@"<PersonDataRequest
                xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
                xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
                xmlns=""http://egov.bg/RegiX/GRAO/NBD/PersonDataRequest"">
                <EGN>{0}</EGN>
                </PersonDataRequest>", student.Uin),
                EndpointConfiguration = EndpointConfiguration.BasicHttpBinding_IRegiXEntryPointV2
            };
           
            XmlSerializer serializer = new(typeof(RegiXGRAOResponse));
            var response = new RegiXGRAOResponse();

			try
			{
                var regixResult = await this.regiXService.GetData(requestParams);

                using (var reader = new XmlNodeReader(regixResult.ServiceResultData.Data.Response.Any))
                {
                    response = (RegiXGRAOResponse)serializer.Deserialize(reader);
                }
            }
			catch (Exception ex)
			{
                this.validation.ThrowErrorMessage(UserErrorCode.RegiXConnectionFailed, ex.Message);
            }

            if (response.PersonNames.FamilyName == null || response.LatinNames.FamilyName == null)
			{
                this.validation.ThrowErrorMessage(UserErrorCode.EmptyRegixResponse);
            }

            return this.userService.ResponseNamesToFirstUpper(response);
        }

        [HttpPost("changeUserName")]
        public async Task ChangeUserName([FromBody] RegiXGRAOResponse regiXGRAOResponse)
        {
            var student = await this.studentService.GetLoggedInStudent();

            await this.rdpzsdService.UpdateStudentName(student.UAN, regiXGRAOResponse);
        }
    }
}
