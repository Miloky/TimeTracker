using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Application.Interfaces;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Application.Issues.Queries.IssueList
{
    public class IssueListQueryHandler:IRequestHandler<IssueListQuery,IssueListQueryResult>
    {
        private readonly ITimeTrackerDbContext _context;

        public IssueListQueryHandler(ITimeTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<IssueListQueryResult> Handle(IssueListQuery request, CancellationToken cancellationToken)
        {
            IList<IssueViewModel> issues = await _context.Issues.Include(x=>x.WorkLogs).Where(x => x.Project.Prefix == request.Prefix).Select(issue =>new IssueViewModel
            {
                Identifier = issue.Identifier,
                Title = issue.Title,
                Worklogs = issue.WorkLogs.Select(x=>new WorklogViewModel
                {
                    Id = x.Id,
                    End = x.EndDate,
                    Duration = x.Duration,
                    Start = x.StartDate
                }).ToList()
            }).ToListAsync(cancellationToken);
            return new IssueListQueryResult
            {
                Issues = issues
            };
        }
    }
}