using System;

namespace TimeTracker.Application.WorkLogs.Commands.StartWorkLog
{
    public class StartLogResult
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public string Identifier { get; set; }
    }
}