using MediatR;

namespace TimeTracker.Application.Issues.Queries.IssueDetails
{
    public class IssueDetailsQuery : IRequest<IssueDetailsQueryResult>
    {
        public string Identifier { get; set; }
    }
}
