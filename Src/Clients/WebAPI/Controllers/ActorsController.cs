using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Common.Interfaces;
using TeamProject.Application.Storage.Actors;
using System.Linq;
using System.Net.Http;
using System.Net;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;

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
        //[Route("api/get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public ActionResult<IEnumerable<ActorLookupDto>> GetAll()
        {
            var result = _repository.Select();
            return Ok(result);
        }
        [HttpDelete("{id}")]        
        public async Task<ActionResult<ActorLookupDto>> Delete(int id)
        {
            try
            {
                return Ok(await _repository.RemoveAsync(_repository.Find(e => e.ActorId == id).FirstOrDefault()));
            }
            catch
            {
                return BadRequest("Unable to delete");
            }
        }
        [HttpPost]
        public async Task<ActionResult<ActorLookupDto>> Add([FromBody]ActorLookupDto obj)
        {
            try
            {
                ActorLookupDto @object = await _repository.AddAsync(obj);
                return Ok(@object);                
            }
            catch(Exception e)
            {
                return BadRequest("Unable to add");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ActorLookupDto>> Update([FromBody] ActorLookupDto obj)
        {
            try
            {
                return Ok(await _repository.UpdateAsync(e => e.ActorId == obj.ActorId, obj));
            }
            catch (Exception)
            {
                return BadRequest("Unable to update");
            }
        } 
        
    }
}