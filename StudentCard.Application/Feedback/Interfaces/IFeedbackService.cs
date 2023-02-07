using StudentCard.Application.Feedback.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Application.Feedback.Interfaces
{
    public interface IFeedbackService
    {
        Task SendFeedback(FeedbackDto model, CancellationToken cancellationToken);
    }
}
