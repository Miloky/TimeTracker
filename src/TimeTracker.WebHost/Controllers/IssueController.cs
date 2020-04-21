using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TimeTracker.Application.Issues.Commands.CreateIssue;
using TimeTracker.Application.Issues.Queries.IssueDetails;
using TimeTracker.Application.Issues.Queries.IssueList;
using TimeTracker.Application.WorkLogs.Commands.StartWorkLog;
using TimeTracker.Application.WorkLogs.Commands.StopWorkLog;

namespace TimeTracker.WebHost.Controllers
{
    public class IssueController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> New(CreateIssueCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> List(IssueListQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Details(IssueDetailsQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> StartLog(StartLogCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> StopLog(StopLogCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
