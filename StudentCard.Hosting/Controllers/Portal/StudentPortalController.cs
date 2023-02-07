using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentCard.Application.HistoryLogs.Interfaces;
using StudentCard.Application.Portal.Dtos;
using StudentCard.Application.Portal.Interfaces;
using StudentCard.Infrastructure.Captcha;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Hosting.Controllers.Portal
{
	[ApiController]
	[Route("api/[controller]")]
	public class StudentPortalController : ControllerBase
	{
		private readonly IStudentPortalService studentPortalService;
		private readonly IHistoryLogService historyLogService;

		public StudentPortalController(IStudentPortalService studentPortalService, IHistoryLogService historyLogService)
		{
			this.studentPortalService = studentPortalService;
			this.historyLogService = historyLogService;
		}

		[AllowAnonymous]
		[HttpGet]
		[TypeFilter(typeof(CaptchaFilter))]
		public async Task<StudentPortalBasicDto> GetStudentPortalBasicByUan([FromQuery] string uan, [FromQuery] string captcha, CancellationToken cancellationToken)
		{
			var student = await this.studentPortalService.GetStudentPortalBasicByUan(uan, cancellationToken);

			await this.historyLogService.LogHistory(uan, cancellationToken);

			return student;
		}
	}
}
