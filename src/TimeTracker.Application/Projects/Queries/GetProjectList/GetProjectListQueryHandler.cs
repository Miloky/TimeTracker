using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TimeTracker.Application.Interfaces;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Application.Projects.Queries.GetProjectList
{
    public class GetProjectListQueryHandler:IRequestHandler<GetProjectListQuery,IEnumerable<Project>>
    {
        private readonly ITimeTrackerDbContext _context;

        public GetProjectListQueryHandler(ITimeTrackerDbContext context) => _context = context;

        public async Task<IEnumerable<Project>> Handle(GetProjectListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Projects.ToListAsync(cancellationToken);
        }
    }
}