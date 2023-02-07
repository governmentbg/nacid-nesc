using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentCard.Application.Users.Dtos;
using StudentCard.Data.Rdpzsd.Students;
using StudentCard.Data.Students;
using StudentCard.Hosting.Models;
using StudentCard.Infrastructure.Interfaces.Contexts;
using StudentCard.Infrastructure.Users.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCard.Hosting.EAuthentication
{
    [Route("api/EAuthentication")]
	[ApiController]
	[AllowAnonymous]
	public class EAuthenticationController : ControllerBase
	{
		private readonly IOptions<ProxyPath> config;
		private readonly IAppDbContext context;
		private readonly IJWTService jwtService;
		private readonly IRdpzsdDbContext rdpzsdDbContext;

		public EAuthenticationController(IOptions<ProxyPath> config, IAppDbContext context, IJWTService jwtService, IRdpzsdDbContext rdpzsdDbContext)
		{
			this.config = config;
			this.context = context;
			this.jwtService = jwtService;
			this.rdpzsdDbContext = rdpzsdDbContext;
		}

		[HttpPost("EAuthLogin")]
		public async Task<RedirectResult> EAuthLogin([FromForm] SamlResponse dto)
		{
			string url;
			if (!string.IsNullOrEmpty(dto.SAMLResponse))
			{
				var decodedResponseStream = new MemoryStream(Convert.FromBase64String(dto.SAMLResponse));
				var eAuthLoginDataDto = SamlHelper.ParseEAuthResponse(decodedResponseStream);

				var name = !string.IsNullOrEmpty(eAuthLoginDataDto.Name) ? eAuthLoginDataDto.Name : null;

				var identifier = eAuthLoginDataDto.Egn.Split('-').Last();

				var student = await this.context.Set<Student>()
					.Where(s => s.Uin == identifier)
					.Include(s => s.User)
					.SingleOrDefaultAsync();

				if (student != null)
				{
					var personBasic = await this.rdpzsdDbContext.Set<PersonLot>()
						.Where(pl => pl.Uan == student.UAN)
						.Select(pl => pl.PersonBasic)
						.SingleOrDefaultAsync();

					var loginDto = new UserLoginInfoDto
					{
						Username = student.User.Username,
						Uan = student.UAN,
						Token = this.jwtService.CreateToken(student.User.Id, student.User.Username),
						FullName = personBasic.FirstName + " " + personBasic.LastName,
						FullNameAlt = personBasic.FirstNameAlt + " " + personBasic.LastNameAlt,
                    };

					url = this.config.Value.ClientUrl + "/eAuth?responseStatus=" + eAuthLoginDataDto.ResponseStatus
						+ "&token=" + loginDto.Token + "&username=" + loginDto.Username + "&uan=" + loginDto.Uan 
						+ "&fullname=" + loginDto.FullName + "&fullnamealt=" + loginDto.FullNameAlt;
                }
                else
                {
					url = this.config.Value.ClientUrl + "/eAuth?responseStatus=" + EAuthResponseStatus.NoEgnMatch;
				}
			}
			else
			{
                url = this.config.Value.ClientUrl + "/eAuth?responseStatus=" + EAuthResponseStatus.InvalidResponseXML;
			}

			return Redirect(url);
		}

		[HttpGet("EAuthMetadata")]
		public FileStreamResult GetEAuthMetadata()
		{
			var xmlResponse = SamlHelper.GenerateXmlMetadata("device.pfx", "12345");

			var stream = new MemoryStream();
			var writer = new StreamWriter(stream);
			writer.Write(xmlResponse);
			writer.Flush();
			stream.Position = 0;

			return new FileStreamResult(stream, "text/xml");
		}
	}
}
