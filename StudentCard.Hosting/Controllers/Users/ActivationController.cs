using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentCard.Application.Users.Dtos;
using StudentCard.Application.Users.Interfaces;
using StudentCard.Data.Emails.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Hosting.Controllers.Users
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class ActivationController : ControllerBase
    {
        private readonly IActivationService activationService;

        public ActivationController(IActivationService activationService)
        {
            this.activationService = activationService;
        }

        [HttpGet("userActivation")]
        public async Task SendActivationLink([FromQuery] int userId, CancellationToken cancellationToken)
            => await this.activationService.SendActivationLink(userId, cancellationToken);

        [HttpGet]
        public async Task CheckToken([FromQuery] string token, [FromQuery] TypeOfActivation typeOfActivation, CancellationToken cancellationToken)
            => await this.activationService.CheckToken(token, typeOfActivation, cancellationToken);

        [HttpPost]
        public async Task ActivateUser([FromBody] UserActivationDto model, CancellationToken cancellationToken)
           => await this.activationService.ActivateUser(model, cancellationToken);

        [HttpPost("newEmail")]
        public async Task ActivateUserNewEmail([FromBody] UserActivationNewEmailAddressDto model, CancellationToken cancellationToken)
          => await this.activationService.ActivateUserNewEmail(model, cancellationToken);
    }
}
