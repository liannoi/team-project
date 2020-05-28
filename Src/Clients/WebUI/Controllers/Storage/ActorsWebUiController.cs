﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Common.Interfaces.Infrastructure;
using TeamProject.Clients.Common;
using TeamProject.Clients.Common.Models.Storage.ActorPhoto;
using TeamProject.Clients.Common.Models.Storage.Actors;
using TeamProject.Clients.WebUI.Common.Pagination.Models.ViewModels;
using TeamProject.Clients.WebUI.Controllers.Common;
using static System.Net.Mime.MediaTypeNames;

namespace TeamProject.Clients.WebUI.Controllers.Storage
{
    [Authorize(Roles = "Administrator")]
    public class ActorsWebUiController : BaseController
    {
        private readonly IApiTools _apiTools;
        private HttpClient httpClient;
        private readonly IAuthorizeApiTools _authorizeApiTools;

        public ActorsWebUiController(IApiTools apiTools, IAuthorizeApiTools authorizeApiTools)
        {
            _apiTools = apiTools;
            _authorizeApiTools = authorizeApiTools;
            httpClient = new HttpClient();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        public async Task<IActionResult> Actors(int currentPage = 1)
        {
            var model = new ActorsBindingModelViewModel { PagingInfo = { CurrentPage = currentPage } };


            model.Collection =
                (await _authorizeApiTools.FetchAsync<List<ActorBindingModel>>(
                    CommonClientsDefaults.WebApiActorsControllerGetAll, JwtToken))
                .TakeLast(100)
                .AsQueryable();
            //TempData["PageInfo"] = model.PagingInfo.CurrentPage;

            return PartialView("Actors", model);
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

            await _authorizeApiTools.PostAsync<ActorBindingModel>(CommonClientsDefaults.WebApiActorsControllerAdd, actor, JwtToken);
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
        [HttpGet]
        public async Task<IActionResult> More(int id)
        {
            var model = await _authorizeApiTools.FetchAsync<ActorBindingModel>($"{CommonClientsDefaults.WebApiActorsControllerGet}/{id}", JwtToken);
            
            var tmp = await _authorizeApiTools.FetchAsync<List<ActorPhotoBindingModel>>($"{CommonClientsDefaults.WebApiApiActorsPhotoControllerGetAllByActor}/{id}", JwtToken);
            model.Photos = tmp;

            tmp.ForEach(async e =>
            {
                var fetched = await (await new HttpClient().GetAsync($"{CommonClientsDefaults.WebApiApiActorsPhotoControllerGet}/{e.PhotoId}").ConfigureAwait(false)).Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                string basePath = Path.Combine(Directory.GetCurrentDirectory(), "actorsPhotosDir");
                var path = $@"{basePath}\{e.Path}";
                await System.IO.File.WriteAllBytesAsync(path, fetched).ConfigureAwait(false);
            });

            await Task.Delay(20);
            return View(model);
        }
        [HttpGet]
        public IActionResult AddPhoto(int id)
        {
            var model = id;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UploadPhoto(IEnumerable<IFormFile> photosUploadMulti, [FromForm] int id)
        {          
            
            foreach (var item in photosUploadMulti)
            {
                if (item == null) continue;
                byte[] bytes = new byte[item.OpenReadStream().Length + 1];
                item.OpenReadStream().Read(bytes, 0, bytes.Length);
                var content = new ByteArrayContent(bytes);
                content.Headers.Add("name", "photosUploadMulti");
                MultipartFormDataContent formDataContent = new MultipartFormDataContent();
                formDataContent.Add(content, "file", item.FileName);
                var client = new HttpClient();
                var result = client.PostAsync($"{CommonClientsDefaults.WebApiApiActorsPhotoControllerPhotoUpload}/{id}", formDataContent).Result;
                //return StatusCode((int)result.StatusCode);
                //await _authorizeApiTools.PostAsync<ActorBindingModel>($"{CommonClientsDefaults.WebApiApiActorsPhotoControllerPhotoUpload}/{id}",
                 //formDataContent, JwtToken);
            }

            return RedirectToAction("Index");            //return RedirectToAction("More",id);//($"{ CommonClientsDefaults.WebApiActorsControllerGet}/{id}");
            

        }

    }
}