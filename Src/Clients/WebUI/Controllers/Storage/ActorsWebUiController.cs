using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ActorsWebUiController> _logger;

        public ActorsWebUiController(IApiTools apiTools, IAuthorizeApiTools authorizeApiTools,
            ILogger<ActorsWebUiController> logger)
        {
            _apiTools = apiTools;
            _authorizeApiTools = authorizeApiTools;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Request for access to the actor controller Index action method.");

            try
            {
                // Check the viability of the JWT token.
                var tmp = (await _authorizeApiTools.FetchAsync<List<ActorBindingModel>>(
                    CommonClientsDefaults.WebApiActorsControllerGetAll, JwtToken)).FirstOrDefault();
            }
            catch (AuthenticationException e)
            {
                _logger.LogWarning(e, e.Message);
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        // TODO: Specify attribute with HTTP method.
        public async Task<IActionResult> Actors(int currentPage = 1)
        {
            var model = new ActorsBindingModelViewModel {PagingInfo = {CurrentPage = currentPage}};
            TempData["PageInfo"] = model.PagingInfo.CurrentPage;

            try
            {
                model.Collection =
                    (await _authorizeApiTools.FetchAsync<List<ActorBindingModel>>(
                        CommonClientsDefaults.WebApiActorsControllerGetAll, JwtToken))
                    .TakeLast(100)
                    .AsQueryable();
            }
            catch (AuthenticationException e)
            {
                _logger.LogWarning(e.Message);
                throw;
            }

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