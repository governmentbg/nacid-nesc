using Microsoft.Extensions.Options;
using StudentCard.Application.Feedback.Dtos;
using StudentCard.Application.Feedback.Interfaces;
using StudentCard.Data.Emails;
using StudentCard.Data.Nomenclatures.Constants;
using StudentCard.Infrastructure.Configurations;
using StudentCard.Infrastructure.Emails;
using StudentCard.Infrastructure.Interfaces.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Application.Feedback
{
	public class FeedbackService : IFeedbackService
	{
		private readonly IAppDbContext context;
		private readonly IEmailService<IAppDbContext> emailService;
		private readonly EmailsConfiguration emailConfiguration;

		public FeedbackService(
			IAppDbContext context,
			IEmailService<IAppDbContext> emailService,
			IOptions<EmailsConfiguration> options)
		{
			this.context = context;
			this.emailService = emailService;
			emailConfiguration = options.Value;
		}

		public async Task SendFeedback(FeedbackDto model, CancellationToken cancellationToken)
        {
			var payload = new
			{
				Email = model.Email,
				Topic = model.Topic,
				Text = model.Text
			};

			Email email = await this.emailService.ComposeEmailAsync(EmailTypeAlias.FEEDBACK, payload, emailConfiguration.FromAddress);

			this.context.Set<Email>().Add(email);

			await this.context.SaveChangesAsync(cancellationToken);
		}
	}
}
