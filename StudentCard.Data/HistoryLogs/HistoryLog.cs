using System;
using StudentCard.Data.Common.Interfaces;

namespace StudentCard.Data.HistoryLogs
{
    public class HistoryLog : IEntity
    {
        public int Id { get; set; }

        public string UAN { get; set; }

        public string IPAddress { get; set; }

        public DateTime Date { get; set; }
    }
}
