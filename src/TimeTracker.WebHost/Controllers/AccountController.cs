using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TimeTracker.WebHost.Controllers
{
    public class AccountController : BaseController
    {
        public async Task<IActionResult> Login()
        {
            return Ok();
        }
    }
}