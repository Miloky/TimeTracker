using System.Collections.Generic;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Application.Issues.Queries.IssueDetails
{
    public class IssueDetailsQueryResult
    {
        public IEnumerable<WorkLog> WorkLogs { get; set; }
    }
}
