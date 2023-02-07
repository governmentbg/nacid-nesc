using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentCard.Application.Users.Interfaces;
using StudentCard.Application.Users.Models;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Hosting.Controllers.Users
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService registerService;

        public RegisterController(IRegisterService registerService)
        {
            this.registerService = registerService;
        }

        [HttpPost]
        public async Task<string> RegisterUser([FromBody] UserRegisterInfoDto model, CancellationToken cancellationToken)
            => await this.registerService.Register(model, cancellationToken);
    }
}
