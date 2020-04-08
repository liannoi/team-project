using Microsoft.AspNetCore.Mvc;

namespace TeamProject.Clients.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}