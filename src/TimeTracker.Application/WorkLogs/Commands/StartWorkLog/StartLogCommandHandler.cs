using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Application.Interfaces;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Application.WorkLogs.Commands.StartWorkLog
{
    public class StartLogCommandHandler:IRequestHandler<StartLogCommand, StartLogResult>
    {
        private readonly ITimeTrackerDbContext _context;

        public StartLogCommandHandler(ITimeTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<StartLogResult> Handle(StartLogCommand request, CancellationToken cancellationToken)
        {
           WorkLog activeWorkLog =  await _context.WorkLogs.FirstOrDefaultAsync(x => x.IssueId == request.Id && x.EndDate == null,
                cancellationToken);

            // TODO: Check if  activeWorkLog exist and throw error
            if (activeWorkLog != null)
            {
                throw  new InvalidOperationException("Stop previous time logging.");
            }

            WorkLog workLog = new WorkLog
            {
                IssueId = request.Id,
                StartDate = request.Start,
            };

            await _context.WorkLogs.AddAsync(workLog, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return new StartLogResult
            {
                Id = workLog.Id,
                StartDate = workLog.StartDate
            };
        }
    }
}