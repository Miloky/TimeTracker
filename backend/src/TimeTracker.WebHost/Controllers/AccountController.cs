using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TimeTracker.WebHost.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserManager<IdentityUser> _userManager;
        public AccountController(IUserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] CredentialsViewModel credentials)
        {
            var user = await _userManager.FindByEmailAsync(credentials.Email);
            if(user==null){
                // TODO: Create api error model and return it
                return BadRequest();
            }
            return Ok();
        }
    }

    public class CredentialsViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class IdentityUser : IdentityUser<int>
    {

    }

    public class IdentityUser<T>
    {
        public T Id { get; set; }
    }

    public interface IUserManager<TUser>
    {
        Task<TUser> FindByNameAsync(string name);
        Task<TUser> FindByEmailAsync(string email);
    }
}