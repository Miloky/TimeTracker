using System;

namespace TimeTracker.Application.WorkLogs.Commands.StartWorkLog
{
    public class StartLogResult
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
    }
}