using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Application.Interfaces;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Application.Issues.Queries.IssueDetails
{
    public class IssueDetailsQueryHandler : IRequestHandler<IssueDetailsQuery, IssueDetailsQueryResult>
    {
        private readonly ITimeTrackerDbContext _context;
        public IssueDetailsQueryHandler(ITimeTrackerDbContext context) => _context = context;


        public async Task<IssueDetailsQueryResult> Handle(IssueDetailsQuery query, CancellationToken cancellationToken)
        {
            Issue issue = await _context.Issues.Include(x => x.WorkLogs).FirstOrDefaultAsync(x => x.Identifier == query.Identifier, cancellationToken);

            return new IssueDetailsQueryResult
            {
                WorkLogs = issue.WorkLogs.Select(x => { x.Issue = null; return x; })
            };
        }
    }
}
