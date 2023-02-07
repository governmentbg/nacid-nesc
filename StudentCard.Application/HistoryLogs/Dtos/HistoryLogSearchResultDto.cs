using System.Collections.Generic;

namespace StudentCard.Application.HistoryLogs.Dtos
{
    public class HistoryLogSearchResultDto
    {
        public List<HistoryLogDto> HistoryLogs { get; set; }

        public int Count { get; set; }
    }
}
