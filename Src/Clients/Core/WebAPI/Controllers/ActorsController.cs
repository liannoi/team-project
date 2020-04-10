using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Common.Interfaces;
using TeamProject.Application.Storage.Actors;

namespace TeamProject.Clients.WebApi.Controllers
{
    public class ActorsController : BaseController
    {
        private readonly IBusinessService<ActorLookupDto> _repository;

        public ActorsController(IBusinessService<ActorLookupDto> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ActorLookupDto>> GetAll()
        {
            return Ok(_repository.Select());
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
        public async Task<ActionResult<ActorLookupDto>> Add([FromBody] ActorLookupDto obj)
        {
            try
            {
                return Ok(await _repository.AddAsync(obj));
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
        public async Task<ActionResult<ActorLookupDto>> Update([FromBody] ActorLookupDto obj)
        {
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