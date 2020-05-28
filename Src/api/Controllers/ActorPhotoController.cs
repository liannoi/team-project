using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Common.Interfaces.Storage;
using TeamProject.Application.Storage.ActorsPhotos;

namespace TeamProject.Clients.WebApi.Controllers
{
    public class ActorPhotoController : BaseController
    {
        private readonly IBusinessService<ActorPhotoLookupDto> _actorPhotosRepository;

        public ActorPhotoController(IBusinessService<ActorPhotoLookupDto> actorPhotosRepository)
        {
            _actorPhotosRepository = actorPhotosRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<List<ActorPhotoLookupDto>> GetAllByActor(int id)
        {
            return Ok(_actorPhotosRepository.Find(e => e.ActorId == id).ToList());
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> PhotoUpload(int id)
        {
            var photosUploadMulti = Request.Form.Files;
            foreach (var file in photosUploadMulti)
            {
                if (file == null) continue;

                var newFileName = $"{Guid.NewGuid()}{Path.GetExtension(Path.GetFileName(file.FileName))}";
                var path = Path.Combine(Directory.GetCurrentDirectory(), "actorsPhotosDir");
                await using (var fileStream = new FileStream(Path.Combine(path, newFileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                var tmp = new ActorPhotoLookupDto
                {
                    ActorId = id,
                    Path = $"{newFileName}"
                };
                await _actorPhotosRepository.AddAsync(tmp);
            }

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var photo = _actorPhotosRepository.Find(e => e.PhotoId == id).FirstOrDefault();
            var path = $"{AppDomain.CurrentDomain.BaseDirectory}/../../../actorsPhotosDir/{photo.Path}";
            var result = System.IO.File.OpenRead(path);
            return await Task.Run(() => File(result, "image/jpeg"));
        }
    }
}