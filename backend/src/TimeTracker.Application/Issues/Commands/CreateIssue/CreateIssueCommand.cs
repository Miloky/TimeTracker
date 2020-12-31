using MediatR;

namespace TimeTracker.Application.Issues.Commands.CreateIssue
{
    public class CreateIssueCommand : IRequest<string>
    {
        public string Prefix { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}