using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Common.Interfaces.Infrastructure;
using TeamProject.Clients.Common;
using TeamProject.Clients.Common.Models.Storage.Actors.Returnable;
using TeamProject.Clients.WebUI.Common.Pagination.Models;
using TeamProject.Clients.WebUI.Common.Pagination.Models.ViewModels;

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

        //[HttpGet]
        public async Task<IActionResult> Actors(int currentPage = 1)
        {
            //var model = await _apiTools.FetchAsync<List<ActorsBindingModelViewModel>>(CommonClientsDefaults.WebApiAcotrsControllerGetAll);
            //var model = new _ActorsBindingModelViewModel();

            
            //model.Collection = new List<ActorBindingModel>()
            //    {
            //        new ActorBindingModel
            //        {
            //            ActorId=1,
            //            Birthday=DateTime.Now,
            //            FirstName="Test CORS",
            //            LastName="Test CORS"
            //        }
            //}.AsQueryable();



            // model.Collection = (await _apiTools.FetchAsync<List<ActorBindingModel>>(CommonClientsDefaults.WebApiAcotrsControllerGetAll)).AsQueryable();
            //var model = new List<ActorBindingModel>()
            //{
            //    new ActorBindingModel
            //    {
            //        ActorId=1,
            //        Birthday=DateTime.Now,
            //        FirstName="Test CORS",
            //        LastName="Test CORS"
            //    }
            //};
            //var model = new _ActorsBindingModelViewModel();
            var model = new ActorsBindingModelViewModel();
            model.PagingInfo.CurrentPage = currentPage;
            //TempData["PageInfo"] = model;
            model.Collection = (await _apiTools.FetchAsync<List<ActorBindingModel>>(CommonClientsDefaults.WebApiAcotrsControllerGetAll)).TakeLast(100).AsQueryable();
            return PartialView("Actors",model);
        }

        public ActionResult HelloWorld()
            {
                return PartialView("_HelloWorld");
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