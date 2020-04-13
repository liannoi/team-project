using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Common.Interfaces.Infrastructure;
using TeamProject.Clients.Common;
using TeamProject.Clients.Common.Models.Core.Returnable;

namespace TeamProject.Clients.WebUI.Controllers
{
    public class ActorsWebUIController : BaseController
    {
        private readonly IApiTools _apiTools;

        public ActorsWebUIController(IApiTools apiTools)
        {
            _apiTools = apiTools;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Actors()
        {
            var model = await _apiTools.FetchAsync<List<ActorReturnModel>>(CommonClientsDefaults.WebApiAcotrsControllerGetAll);
            return View(model);
        }

        public ActionResult AddActor()
        {
            return View(new ActorReturnModel());
        }
        //[HttpPost]
        //public async Task<IActionResult> AddActor(ActorReturnModel _actor)
        //{
        //    await _apiTools.PostAsync<ActorReturnModel>(CommonClientsDefaults., _actor);
        //    return RedirectToAction("Actors");
        //}
        //public ActionResult UpdateActor(int id)
        //{

        //}
    }
}