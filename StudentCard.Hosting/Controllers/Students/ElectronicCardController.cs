using Microsoft.AspNetCore.Mvc;
using StudentCard.Application.Students.Dtos;
using StudentCard.Application.Students.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Hosting.Controllers.Students
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElectronicCardController
    {
        private readonly IElectronicCardService electronicCardService;

        public ElectronicCardController(IElectronicCardService electronicCardService)
        {
            this.electronicCardService = electronicCardService;
        }

        [HttpGet]
        public Task<ElectronicCardDto> GetStudentElectronicCardInfo(CancellationToken cancellationToken)
            => this.electronicCardService.GetStudentElectronicCardInfo(true, cancellationToken);

        [HttpGet("pdf")]
        public async Task<string> GetStudentElectronicCardPdf([FromQuery] bool inBulgarian, CancellationToken cancellationToken)
         => await this.electronicCardService.GetStudentElectronicCardPdf(inBulgarian, cancellationToken);
    }
}
