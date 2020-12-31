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
        [Route("new")]
        public async Task<IActionResult> Create([FromBody] CreateProjectCommand command)
        {
            // TODO: Fluent Validator
            var result = await Mediator.Send(command);
            return Ok(new { id = result });
        }

        [HttpPost]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            // TODO: Add SmartListParams
            // TODO: Fluent Validator
            var result = await Mediator.Send(new GetProjectListQuery());
            return Ok(result);
        }
    }
}
