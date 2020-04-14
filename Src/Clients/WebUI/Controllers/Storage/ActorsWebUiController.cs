using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Common.Interfaces.Infrastructure;
using TeamProject.Clients.Common;
using TeamProject.Clients.Common.Models.Storage.Actor;
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
        public async Task<IActionResult> Index()
        {
            List<ActorBindingModel> fetch;

            try
            {
                fetch = await _authorizeApiTools.FetchAsync<List<ActorBindingModel>>(
                    CommonClientsDefaults.WebApiActorsControllerGetAll,
                    HttpContext.Request.Cookies[MvcClientDefaults.InCookiesJwtTokenName]);
            }
            catch (AuthenticationException)
            {
                return RedirectToAction("Login", "Account");
            }

            var model = fetch.TakeLast(10);

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActorBindingModel actor)
        {
            if (!ModelState.IsValid) return View(actor);

            await _apiTools.PostAsync<ActorBindingModel>(CommonClientsDefaults.WebApiActorsControllerAdd, actor);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            var model = await _apiTools.FetchAsync<ActorBindingModel>(
                $"{CommonClientsDefaults.WebApiActorsControllerGet}{id}");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ActorBindingModel actor)
        {
            await _apiTools.PostAsync<ActorBindingModel>(CommonClientsDefaults.WebApiActorsControllerUpdate,
                actor);

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _apiTools.DeleteAsync($"{CommonClientsDefaults.WebApiActorsControllerDelete}{id}");

            return Ok();
        }
    }
}