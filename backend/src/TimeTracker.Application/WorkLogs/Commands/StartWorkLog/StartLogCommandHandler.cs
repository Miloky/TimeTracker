using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Application.Interfaces;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Application.WorkLogs.Commands.StartWorkLog
{
    public class StartLogCommandHandler : IRequestHandler<StartLogCommand, StartLogResult>
    {
        private readonly ITimeTrackerDbContext _context;

        public StartLogCommandHandler(ITimeTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<StartLogResult> Handle(StartLogCommand request, CancellationToken cancellationToken)
        {
            // TODO: Throw error if null
            Issue issue = await _context.Issues.FirstOrDefaultAsync(x => x.Identifier == request.Identifier,cancellationToken);
            var workLog = await _context.WorkLogs.FirstOrDefaultAsync(x => x.IssueId == issue.Id&&x.EndDate==null,cancellationToken);



            // TODO: Check if  activeWorkLog exist and throw error
            if (workLog!=null)
            {
                throw new InvalidOperationException("Stop previous time logging.");
            }

            WorkLog log = new WorkLog
            {
                IssueId = issue.Id,
                StartDate = request.Start,
            };

            await _context.WorkLogs.AddAsync(log, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return new StartLogResult
            {
                Id = log.Id,
                Start = log.StartDate,
                Identifier = issue.Identifier
            };
        }
    }
}