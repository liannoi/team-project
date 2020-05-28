using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Common.Interfaces.Infrastructure;
using TeamProject.Clients.Common;
using TeamProject.Clients.Common.Models.Storage.Genres;
using TeamProject.Clients.WebUI.Controllers.Common;

namespace TeamProject.Clients.WebUI.Controllers.Storage
{
    public class GenresWebUiController : BaseController
    {
        private readonly IApiTools _apiTools;
        private readonly IAuthorizeApiTools _authorizeApiTools;

        public GenresWebUiController(IApiTools apiTools, IAuthorizeApiTools authorizeApiTools)
        {
            _apiTools = apiTools;
            _authorizeApiTools = authorizeApiTools;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Genres()
        {
            var model = await _authorizeApiTools.FetchAsync<List<GenreBindingModel>>(
                CommonClientsDefaults.WebApiGenresControllerGetAll, JwtToken);
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult CreateGenre()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre(GenreBindingModel genre)
        {
            if (!ModelState.IsValid) return View(genre);
            await _authorizeApiTools.PostAsync<GenreBindingModel>(CommonClientsDefaults.WebApiActorsControllerAdd,
                genre, JwtToken);
            return RedirectToAction("Genres");
        }

        [HttpGet]
        public async Task<ActionResult> UpdateGenre(int id)
        {
            var model = await _authorizeApiTools.FetchAsync<GenreBindingModel>(
                $"{CommonClientsDefaults.WebApiActorsControllerGet}/{id}", JwtToken);

            return View(model);
        }
    }
}