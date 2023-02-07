namespace StudentCard.Infrastructure.Configurations
{
    public class StudentConfiguration
    {
        public int JobPeriod { get; set; }

        public int JobLimit { get; set; }

        public bool JobEnabled { get; set; }

        public string JobSchedule { get; set; }
    }
}
