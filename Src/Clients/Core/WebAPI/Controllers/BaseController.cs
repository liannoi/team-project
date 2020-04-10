using Microsoft.AspNetCore.Mvc;

namespace TeamProject.Clients.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    // TODO: CORS.
    public abstract class BaseController : ControllerBase
    {
    }
}