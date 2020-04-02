using MediatR;

namespace TimeTracker.Application.Issues.Queries.IssueList
{
    public class IssueListQuery : IRequest<IssueListQueryResult>
    {
        public string Prefix { get; set; }
    }
}