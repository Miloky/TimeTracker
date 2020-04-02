using MediatR;

namespace TimeTracker.Application.WorkLogs.Commands.StopWorkLog
{
    public class StopLogCommand:IRequest<StopLogCommandResult>
    {
        public int Id { get; set; }
    }
}