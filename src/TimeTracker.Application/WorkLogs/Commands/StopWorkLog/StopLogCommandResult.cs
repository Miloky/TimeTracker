using System;

namespace TimeTracker.Application.WorkLogs.Commands.StopWorkLog
{
    public class StopLogCommandResult
    {
        public int Duration { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}