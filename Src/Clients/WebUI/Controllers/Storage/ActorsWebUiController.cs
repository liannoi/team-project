using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Common.Interfaces.Infrastructure;
using TeamProject.Clients.Common;
using TeamProject.Clients.Common.Models.Storage.Actors;
using TeamProject.Clients.WebUI.Common.Pagination.Models.ViewModels;
using TeamProject.Clients.WebUI.Controllers.Common;

namespace TeamProject.Clients.WebUI.Controllers.Storage
{
    [Authorize(Roles = "Administrator")]
    public class ActorsWebUiController : BaseController
    {
        private readonly IApiTools _apiTools;
        private readonly IAuthorizeApiTools _authorizeApiTools;

        public ActorsWebUiController(IApiTools apiTools, IAuthorizeApiTools authorizeApiTools)
        {
            _apiTools = apiTools;
            _authorizeApiTools = authorizeApiTools;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        public async Task<IActionResult> Actors(int currentPage = 1)
        {
            var model = new ActorsBindingModelViewModel {PagingInfo = {CurrentPage = currentPage}};
            TempData["PageInfo"] = model.PagingInfo.CurrentPage;

            model.Collection =
                (await _authorizeApiTools.FetchAsync<List<ActorBindingModel>>(
                    CommonClientsDefaults.WebApiActorsControllerGetAll, JwtToken))
                .TakeLast(100)
                .AsQueryable();

            return PartialView("_Actors", model);
        }

        [HttpGet]
        public ActionResult CreateActor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateActor(ActorBindingModel actor)
        {
            if (!ModelState.IsValid) return View(actor);

            await _apiTools.PostAsync<ActorBindingModel>(CommonClientsDefaults.WebApiActorsControllerAdd, actor);
            return RedirectToAction("Actors");
        }

        [HttpGet]
        public async Task<ActionResult> UpdateActor(int id)
        {
            var model = await _authorizeApiTools.FetchAsync<ActorBindingModel>(
                $"{CommonClientsDefaults.WebApiActorsControllerGet}/{id}", JwtToken);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateActor(ActorBindingModel actor)
        {
            await _authorizeApiTools.PostAsync<ActorBindingModel>(CommonClientsDefaults.WebApiActorsControllerUpdate,
                actor, JwtToken);

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteActor(int id)
        {
            await _authorizeApiTools.DeleteAsync($"{CommonClientsDefaults.WebApiActorsControllerDelete}/{id}",
                JwtToken);

            return Ok();
        }
    }
}