using Microsoft.AspNetCore.Mvc;

namespace TeamProject.Clients.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
    }
}