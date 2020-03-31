using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Application.Issues.Commands.CreateIssue;

namespace TimeTracker.WebHost.Controllers
{
    public class IssueController : BaseController
    {
        public async Task<IActionResult> New(CreateIssueCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
