using System;
using MediatR;

namespace TimeTracker.Application.WorkLogs.Commands.StartWorkLog
{
    public class StartLogCommand:IRequest<StartLogResult>
    {
        public DateTime Start { get; set; }
        public int Id { get; set; }
    }
}