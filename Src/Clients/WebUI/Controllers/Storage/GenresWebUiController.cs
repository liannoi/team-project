using System;
using System.Collections.Generic;
using System.Linq;
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
                CommonClientsDefaults.WebApiGenresControllerGetAll,JwtToken);
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
            await _authorizeApiTools.PostAsync<GenreBindingModel>(CommonClientsDefaults.WebApiGenresControllerAdd, genre, JwtToken);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> UpdateGenre(int id)
        {
            var model = await _authorizeApiTools.FetchAsync<GenreBindingModel>(
                $"{CommonClientsDefaults.WebApiGenresControllerGet}/{id}", JwtToken);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGenre(GenreBindingModel genre)
        {
            await _authorizeApiTools.PostAsync<GenreBindingModel>(CommonClientsDefaults.WebApiGenresControllerUpdate,
                genre, JwtToken);
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            await _authorizeApiTools.DeleteAsync($"{CommonClientsDefaults.WebApiGenresControllerDelete}/{id}",
                JwtToken);
            return Ok();
        }
    }
}