using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Common.Interfaces.Storage;
using TeamProject.Application.Storage.Actors;
using TeamProject.Application.Storage.ActorsPhotos;

namespace TeamProject.Clients.WebApi.Controllers
{
    public class ActorsController : BaseController
    {
        private readonly IBusinessService<ActorLookupDto> _repository;
        private readonly IBusinessService<ActorPhotoLookupDto> _actorPhotosRepository;

        public ActorsController(IBusinessService<ActorLookupDto> repository, IBusinessService<ActorPhotoLookupDto> actorPhotosRepository)
        {
            _repository = repository;
            _actorPhotosRepository = actorPhotosRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IQueryable<ActorLookupDto>> GetAll()
        {
            return Ok(_repository.Select().AsQueryable());
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ActorLookupDto> Get(int id)
        {
            var result = _repository.Find(e => e.ActorId == id).FirstOrDefault();
            result.Photos = _actorPhotosRepository.Find(e => e.ActorId == id);

            if (result != null) return Ok(result);

            return BadRequest("Not found");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ActorLookupDto>> Delete(int id)
        {
            try
            {
                return Ok(await _repository.RemoveAsync(_repository.Find(e => e.ActorId == id).FirstOrDefault()));
            }
            // TODO: Specify more specific exceptions.
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ActorLookupDto>> Add([FromBody] ActorLookupDto actor)
        {   if (!ModelState.IsValid) return BadRequest(new ActorLookupDtoValidator().Validate(actor).Errors);

            try
            {
                var model = await _repository.AddAsync(actor);
                await _actorPhotosRepository.AddAsync(new ActorPhotoLookupDto { ActorId = model.ActorId, Path ="Hello path" });
                //foreach(var photo in actor.Photos)
                //{
                //    await _actorPhotosRepository.AddAsync(new ActorPhotoLookupDto { ActorId = model.ActorId, Path = photo.Path });
                //}
                model.Photos = _actorPhotosRepository.Find(e => e.ActorId == model.ActorId);
                return Ok(model);
            }
            // TODO: Specify more specific exceptions.
            catch (Exception e)
            {
                return BadRequest(new ActorLookupDto { Errors = new List<string> { "Error at add entity." } });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ActorLookupDto>> Update([FromBody] ActorLookupDto obj)
        {
            if (!ModelState.IsValid) return BadRequest(new ActorLookupDtoValidator().Validate(obj).Errors);

            try
            {
                return Ok(await _repository.UpdateAsync(e => e.ActorId == obj.ActorId, obj));
            }
            // TODO: Specify more specific exceptions.
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}