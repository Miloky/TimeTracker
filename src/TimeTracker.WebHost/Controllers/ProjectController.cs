using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Application.Projects.Commands.CreateProject;
using TimeTracker.Application.Projects.Queries.GetProjectList;

namespace TimeTracker.WebHost.Controllers
{
    [Produces("application/json")]
    [Route("api/projects")]
    public class ProjectController : BaseController
    {
        [HttpPost]
        [Route("create-project")]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(new { id = result });
        }

        [HttpPost]
        [Route("project-list")]
        public async Task<IActionResult> GetProjectList()
        {
            var result = await Mediator.Send(new GetProjectListQuery());
            return Ok(result);
        }
    }
}