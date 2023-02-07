using System.Collections.Generic;

namespace StudentCard.Infrastructure.Helpers.Dtos
{
    public class SearchResultItemDto<T>
    {
        public int? TotalCount { get; set; }

        public List<T> Items { get; set; } = new List<T>();
    }
}
