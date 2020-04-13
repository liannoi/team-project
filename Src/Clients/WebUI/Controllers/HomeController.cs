using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Clients.Common.Tools;
using TeamProject.Clients.WebUI.Common.Models.Returnable;

namespace TeamProject.Clients.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiTools _apiTools;

        public HomeController(IApiTools apiTools)
        {
            _apiTools = apiTools;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Actors()
        {
            var model = await _apiTools.FetchAsync<List<ActorReturnModel>>("https://localhost:44378/api/actors/getall");
            return View(model);
        }
       
        public ActionResult AddActor()
        {            
            return View(new ActorReturnModel());
        }
        [HttpPost]
        public async Task<IActionResult> AddActor(ActorReturnModel _actor)
        {
            await _apiTools.PostAsync<ActorReturnModel>("https://localhost:44378/api/actors/add", _actor);
            return RedirectToAction("Actors");
        }
    }
}