using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Common.Interfaces.Infrastructure;
using TeamProject.Clients.WebUI.Controllers.Common;

namespace TeamProject.Clients.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IApiTools _apiTools;

        public HomeController(IApiTools apiTools)
        {
            _apiTools = apiTools;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}