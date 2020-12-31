using MediatR;
using System.Collections.Generic;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Application.Projects.Queries.GetProjectList
{
    public class GetProjectListQuery : IRequest<IEnumerable<Project>> { }
}
