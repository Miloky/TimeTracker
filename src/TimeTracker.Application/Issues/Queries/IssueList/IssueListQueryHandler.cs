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
            IList<Issue> issues = await _context.Issues.Where(x => x.Project.Prefix == request.Prefix).ToListAsync(cancellationToken);
            return new IssueListQueryResult
            {
                Issues = issues
            };
        }
    }
}