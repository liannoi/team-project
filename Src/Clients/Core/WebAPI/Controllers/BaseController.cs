using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TeamProject.Clients.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    // TODO: CORS.
    public abstract class BaseController : ControllerBase
    {
        protected void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors) ModelState.AddModelError("", error.Description);
        }
    }
}