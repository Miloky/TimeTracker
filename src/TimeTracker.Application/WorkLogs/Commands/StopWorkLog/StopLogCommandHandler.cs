using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Application.Interfaces;

namespace TimeTracker.Application.WorkLogs.Commands.StopWorkLog
{
    public class StopLogCommandHandler:IRequestHandler<StopLogCommand,StopLogCommandResult>
    {
        private readonly ITimeTrackerDbContext _context;

        public StopLogCommandHandler(ITimeTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<StopLogCommandResult> Handle(StopLogCommand request, CancellationToken cancellationToken)
        {
            var activeWorkLog = await _context.WorkLogs.FirstOrDefaultAsync(x => x.EndDate == null && x.IssueId == request.Id, cancellationToken);
            if (activeWorkLog == null)
            {
                throw new InvalidOperationException("There is no active logging");
            }


            var now = DateTime.Now;
            var diff = now - activeWorkLog.StartDate;
            activeWorkLog.EndDate = now;
            activeWorkLog.Duration = diff.Minutes;


            await _context.SaveChangesAsync(cancellationToken);

            return new StopLogCommandResult
            {
                Duration = activeWorkLog.Duration,
                Start = activeWorkLog.StartDate,
                End = activeWorkLog.EndDate
            };
        }
    }
}