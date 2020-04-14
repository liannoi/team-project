using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Common.Interfaces.Infrastructure;
using TeamProject.Clients.Common;
using TeamProject.Clients.Common.Models.Storage.Actors.Returnable;

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
        public async Task<IActionResult> Actors()
        {
            var model =( await _apiTools.FetchAsync<List<ActorBindingModel>>(CommonClientsDefaults.WebApiAcotrsControllerGetAll)).TakeLast(10);
            return View(model);
        }

        [HttpGet]
        public ActionResult AddActor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddActor(ActorBindingModel actor)
        {
            if (!ModelState.IsValid) return View(actor);
            
                await _apiTools.PostAsync<ActorBindingModel>(CommonClientsDefaults.WebApiActorsControllerAdd, actor);
                return RedirectToAction("Actors");               
        }

        [HttpGet]
        public async Task<ActionResult> UpdateActor(int id)
        {
            var model = await _apiTools.FetchAsync<ActorBindingModel>(CommonClientsDefaults.WebApiActorsControllerGet+id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateActor(ActorBindingModel _actor)
        {
            try
            {
                await _apiTools.PostAsync<ActorBindingModel>(CommonClientsDefaults.WebApiActorsControllerUpdate, _actor);
                return RedirectToAction("Actors");
            }
            catch
            {
                throw new Exception();
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _apiTools.DeleteAsync($"{CommonClientsDefaults.WebApiActorsControllerDelete}{id}");
                return Ok();
            }
            catch
            {
                throw new Exception();
            }
        }

    }
}