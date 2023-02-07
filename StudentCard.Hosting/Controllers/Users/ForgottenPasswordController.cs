using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentCard.Application.Users.Dtos;
using StudentCard.Infrastructure.Interfaces.Contexts;
using StudentCard.Infrastructure.Users.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Hosting.Controllers.Users
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class ForgottenPasswordController : ControllerBase
    {
        private readonly IForgottenPasswordService<IAppDbContext> forgottenPasswordService;

        public ForgottenPasswordController(IForgottenPasswordService<IAppDbContext> forgottenPasswordService)
        {
            this.forgottenPasswordService = forgottenPasswordService;
        }

        [HttpPost]
        public async Task SendForgottenPasswordMail([FromBody] EmailForgottenPasswordDto model, CancellationToken cancellationToken)
            => await this.forgottenPasswordService.SendMail(model, cancellationToken);

        [HttpPost("Recovery")]
        public async Task RecoverPassword([FromBody] ForgottenPasswordDto model, CancellationToken cancellationToken)
            => await this.forgottenPasswordService.RecoverPassword(model, cancellationToken);
    }
}
