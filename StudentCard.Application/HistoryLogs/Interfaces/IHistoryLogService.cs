using StudentCard.Application.HistoryLogs.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Application.HistoryLogs.Interfaces
{
	public interface IHistoryLogService
    {
        Task LogHistory(string uan, CancellationToken cancellationToken);

        Task<HistoryLogSearchResultDto> GetHistoryLogs(HistoryLogFilterDto filter, CancellationToken cancellationToken);
    }
}
