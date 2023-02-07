using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentCard.Application.Feedback.Dtos;
using StudentCard.Application.Feedback.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Hosting.Controllers.Feedback
{
    [AllowAnonymous]
    [ApiController]
	[Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        [HttpPost]
        public async Task SendFeedback([FromBody] FeedbackDto model, CancellationToken cancellationToken)
          => await this.feedbackService.SendFeedback(model, cancellationToken);
    }
}
