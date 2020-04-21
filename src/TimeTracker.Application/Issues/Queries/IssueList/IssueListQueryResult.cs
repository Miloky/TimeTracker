using System;
using System.Collections.Generic;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Application.Issues.Queries.IssueList
{
    public class IssueListQueryResult
    {
        public IList<IssueViewModel> Issues { get; set; }
    }

    public class IssueViewModel
    {
        public string Identifier { get; set; }
        public string Title { get; set; }
        public IList<WorklogViewModel> Worklogs { get; set; }
    }

    public class WorklogViewModel
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public int Duration { get; set; }
    }
}