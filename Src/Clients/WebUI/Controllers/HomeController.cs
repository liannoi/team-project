using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Common.Interfaces;
using TeamProject.Clients.WebUI.Common.Models.Returnable;
using TeamProject.Infrastructure.ApiTools;

namespace TeamProject.Clients.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiTools _apiTools;

        public HomeController()
        {
            // TODO: Invert control by injecting dependencies.
            _apiTools = new ApiTools();
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Actors()
        {
            var model = await _apiTools.FetchAsync<List<ActorReturnModel>>("https://localhost:5001/api/actors/getall");
            return View(model);
        }
    }
}