using Microsoft.AspNetCore.Http;
using StudentCard.Data.HistoryLogs;
using StudentCard.Infrastructure.Interfaces;
using StudentCard.Infrastructure.Interfaces.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudentCard.Infrastructure.DomainValidation;
using StudentCard.Infrastructure.DomainValidation.Enums;
using StudentCard.Data.Students;
using StudentCard.Application.HistoryLogs.Dtos;
using StudentCard.Application.HistoryLogs.Interfaces;

namespace StudentCard.Application.HistoryLogs
{
	public class HistoryLogService : IHistoryLogService
	{
		private readonly IAppDbContext dbContext;
		private readonly IHttpContextAccessor contextAccessor;
		private readonly IUserContext userContext;
		private readonly DomainValidationService validatorService;

		public HistoryLogService(
			IAppDbContext dbContext,
			IHttpContextAccessor contextAccessor,
			IUserContext userContext,
			DomainValidationService validationService
			)
		{
			this.dbContext = dbContext;
			this.contextAccessor = contextAccessor;
			this.userContext = userContext;
			this.validatorService = validationService;
		}

		public async Task LogHistory(string uan, CancellationToken cancellationToken)
		{
			var log = new HistoryLog()
			{
				IPAddress = this.contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(),
				UAN = uan,
				Date = DateTime.Now
			};

			this.dbContext.Set<HistoryLog>().Add(log);

			await this.dbContext.SaveChangesAsync(cancellationToken);
		}

		public async Task<HistoryLogSearchResultDto> GetHistoryLogs(HistoryLogFilterDto filter, CancellationToken cancellationToken)
		{
			var student = await this.dbContext.Set<Student>()
				.Where(s => s.Id == this.userContext.UserId)
				.SingleOrDefaultAsync(cancellationToken);

			if (student == null)
			{
				validatorService.ThrowErrorMessage(StudentErrorCode.StudentNotFoundByUAN);
			}

			var logs = this.dbContext.Set<HistoryLog>()
				.Where(hl => hl.UAN == student.UAN)
				.OrderByDescending(hl => hl.Date);

			int count = logs.Count();
			var materializedlogs = logs
				.Skip(filter.Offset)
				.Take(filter.Limit)
				.Select(hl => new HistoryLogDto()
				{
					IPAddress = hl.IPAddress,
					Date = hl.Date
				})
				.ToList();

			return new HistoryLogSearchResultDto()
			{
				HistoryLogs = materializedlogs,
				Count = count
			};
		}
	}
}
