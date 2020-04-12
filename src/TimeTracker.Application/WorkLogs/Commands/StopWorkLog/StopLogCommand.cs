using System;
using MediatR;

namespace TimeTracker.Application.WorkLogs.Commands.StopWorkLog
{
    public class StopLogCommand:IRequest<StopLogCommandResult>
    {
        public string Identifier { get; set; }
        public DateTime End { get; set; }
    }
}