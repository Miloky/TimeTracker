using MediatR;

namespace TimeTracker.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}