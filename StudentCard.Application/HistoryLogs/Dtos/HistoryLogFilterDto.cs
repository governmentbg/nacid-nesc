using StudentCard.Infrastructure.Helpers.Dtos;

namespace StudentCard.Application.HistoryLogs.Dtos
{
	public class HistoryLogFilterDto : BaseSearchFilterDto
	{
		public HistoryLogFilterDto()
			: base(0, 10)
		{

		}
	}
}
