namespace StudentCard.Infrastructure.Helpers.Dtos
{
    public class BaseSearchFilterDto
    {
        public BaseSearchFilterDto(int offset,int limit)
        {
            this.Offset = offset;
            this.Limit = limit;
        }
        public int Offset { get; set; }

        public int Limit { get; set; }
    }
}
