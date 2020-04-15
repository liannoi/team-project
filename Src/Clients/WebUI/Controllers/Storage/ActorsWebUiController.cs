using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeamProject.Application.Common.Interfaces.Infrastructure;
using TeamProject.Clients.Common;
using TeamProject.Clients.Common.Models.Storage.Actors;
using TeamProject.Clients.Common.Models.Storage.Films;
using TeamProject.Clients.WebUI.Controllers.Common;
using TeamProject.Clients.WebUI.Models;

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
        public async Task<ActionResult> Create()
        {
            return View(await PrepareAsync(0));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActorViewModel actor)
        {
            if (!ModelState.IsValid) return View(actor);

            await PrepareAsync(actor);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            var model = await _apiTools.FetchAsync<ActorBindingModel>(
                $"{CommonClientsDefaults.WebApiActorsControllerGet}{id}");

            return View(await PrepareAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ActorViewModel actor)
        {
            await PrepareAsync(actor);

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _apiTools.DeleteAsync($"{CommonClientsDefaults.WebApiActorsControllerDelete}{id}");

            return Ok();
        }

        #region Helpers

        private async Task<ActorViewModel> PrepareAsync(int id)
        {
            ActorBindingModel actor;
            IEnumerable<int> selectedFilms = null;

            if (id == 0)
            {
                actor = new ActorBindingModel();
            }
            else
            {
                actor = await _apiTools.FetchAsync<ActorBindingModel>($"{CommonClientsDefaults.WebApiActorsControllerGet}/{id}");
                selectedFilms =
                    (await _apiTools.FetchAsync<List<FilmBindingModel>>(
                        $"{CommonClientsDefaults.WebApiFilmsControllerGetAllByActor}/{id}")).Select(x => x.FilmId);
            }

            return new ActorViewModel
            {
                Actor = actor,

                Films = (await _authorizeApiTools.FetchAsync<List<FilmBindingModel>>(CommonClientsDefaults.WebApiFilmsControllerGetAll,JwtToken))
                    .TakeLast(10)
                    .Select(x => new SelectListItem
                    {
                        Value = x.FilmId.ToString(),
                        Text = $"{x.Title} ({x.PublishYear.Year})"
                    }),

                SelectedFilms = selectedFilms
            };
        }

        private async Task<IEnumerable<FilmBindingModel>> FetchSelectedFilmsAsync(ActorViewModel model)
        {
            var actors = new List<FilmBindingModel>();

            if (model.IsNopeFilms) return actors;
            if (model.SelectedFilms == null) return actors;

            foreach (var selectedFilmId in model.SelectedFilms)
                actors.Add(await _apiTools.FetchAsync<FilmBindingModel>($"{CommonClientsDefaults.WebApiFilmsControllerGet}/{selectedFilmId}"));

            return actors;
        }

        private async Task PrepareAsync(ActorViewModel model)
        {
            var selectedFilms = await FetchSelectedFilmsAsync(model);

            if (model.Actor.ActorId == 0)
                await _apiTools.PostAsync<ActorBindingModel>(CommonClientsDefaults.WebApiActorsControllerAdd,
                    new { model.Actor.FirstName, model.Actor.LastName, model.Actor.Birthday, Films = selectedFilms });
            else
                await _apiTools.PostAsync<ActorBindingModel>(CommonClientsDefaults.WebApiActorsControllerUpdate,
                    new
                    {
                        model.Actor.ActorId,
                        model.Actor.FirstName,
                        model.Actor.LastName,
                        model.Actor.Birthday,
                        Films = selectedFilms
                    });
        }

        #endregion
    }
}