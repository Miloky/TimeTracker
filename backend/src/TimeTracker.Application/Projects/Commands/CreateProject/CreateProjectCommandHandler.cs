using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TimeTracker.Application.Interfaces;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly ITimeTrackerDbContext _context;

        public CreateProjectCommandHandler(ITimeTrackerDbContext context) => _context = context;

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.Projects.AddAsync(new Project
            {
                Title = request.Name
            }, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return result.Entity.Id;
        }
    }
}