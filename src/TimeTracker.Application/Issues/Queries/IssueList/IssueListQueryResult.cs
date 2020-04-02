using System.Collections;
using System.Collections.Generic;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Application.Issues.Queries.IssueList
{
    public class IssueListQueryResult
    {
        public IList<Issue> Issues { get; set; }
    }
}