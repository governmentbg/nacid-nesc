using Microsoft.AspNetCore.Mvc;
using StudentCard.Application.HistoryLogs.Dtos;
using StudentCard.Application.HistoryLogs.Interfaces;
using StudentCard.Application.Students.Dtos.PersonLotDtos;
using StudentCard.Application.Students.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Hosting.Controllers.Students
{
	[ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;
        private readonly IHistoryLogService historyLogService;

        public StudentController(IStudentService studentService, IHistoryLogService historyLogService)
        {
            this.studentService = studentService;
            this.historyLogService = historyLogService;
        }


        [HttpGet]
        public Task<PersonLotDto> GetStudentByUan(CancellationToken cancellationToken)
            => this.studentService.GetStudentByUan(cancellationToken);

        [HttpGet("historyLogs")]
        public async Task<HistoryLogSearchResultDto> GetHistoryLogs([FromQuery] HistoryLogFilterDto filter, CancellationToken cancellationToken)
             => await this.historyLogService.GetHistoryLogs(filter, cancellationToken);
    }
}
