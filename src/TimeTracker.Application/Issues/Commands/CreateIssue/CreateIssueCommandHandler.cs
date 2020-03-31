using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Application.Interfaces;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Application.Issues.Commands.CreateIssue
{
    public class CreateIssueCommandHandler: IRequestHandler<CreateIssueCommand,string>
    {
        private readonly ITimeTrackerDbContext _context;

        public CreateIssueCommandHandler(ITimeTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {
            Project project =
                await _context.Projects.FirstOrDefaultAsync(x => x.Prefix == request.Prefix, cancellationToken);
           // TODO: Find out how to case if project don't exist
           if (project == null) return null;

           Issue issue = new Issue
           {
               Project = project,
               Title = request.Title,
               // TODO: Add auto numbering
               Identifier = $"{project.Prefix}-222"
           };


           await _context.Issues.AddAsync(issue, cancellationToken);
           await _context.SaveChangesAsync(cancellationToken);

           return issue.Identifier;
        }
    }
}