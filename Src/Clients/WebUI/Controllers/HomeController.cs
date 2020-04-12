using Microsoft.AspNetCore.Mvc;
using TeamProject.Clients.Common.Tools;

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