using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TimeTracker.WebHost.Controllers
{
    [Produces("application/json")]
    public class TimeTrackerController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Track()
        {
            return Ok();
        }
    }
}