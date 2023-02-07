using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StudentCard.Infrastructure.Interfaces.Contexts;
using System.Threading.Tasks;
using System.Linq;
using StudentCard.Data.IpAddresses;

namespace StudentCard.Infrastructure.Captcha
{
	public class CaptchaFilter : IAsyncActionFilter
	{
		private readonly CaptchaService captchaService;
		private readonly IAppDbContext appDbContext;
		private readonly IHttpContextAccessor contextAccessor;

		public CaptchaFilter(CaptchaService captchaService, IAppDbContext appDbContext, IHttpContextAccessor contextAccessor)
		{
			this.captchaService = captchaService;
			this.appDbContext = appDbContext;
			this.contextAccessor = contextAccessor;
		}

		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var requestIpAddress = this.contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

			bool addressExist = this.appDbContext.Set<ExceptionIpAddress>()
				.Any(a => a.Address == requestIpAddress);

			if (!addressExist)
			{
				var captcha = context.ActionArguments["captcha"] as string;

				bool isValid = await this.captchaService.Verify(captcha);

				if (!isValid)
				{
					var controller = context.Controller as ControllerBase;
					context.Result = controller.Forbid();
					return;
				}
			}

			await next();
		}
	}
}
