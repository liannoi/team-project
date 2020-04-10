using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Common.Interfaces;
using TeamProject.Application.Storage.Genere;

namespace TeamProject.Clients.WebApi.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class GenreController : BaseController
    {
        private readonly IBusinessService<GenreDTO> _repository;
        public GenreController(IBusinessService<GenreDTO> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<GenreDTO>> GetAll()
        {
            return Ok(_repository.Select());
        }
        [HttpGet("{Id}")]
        public ActionResult<GenreDTO> GetInstance(int id)
        {
            var obj = _repository.Find(e => e.GenreId == id).FirstOrDefault();
            if (obj != null)
            {
                return Ok(obj);
            }
            return BadRequest("Not found");
        }
        [HttpPost]
        public async Task<ActionResult<GenreDTO>> Add([FromBody]GenreDTO obj)
        {
            try
            {
                var returnObj = await _repository.AddAsync(obj);
                return Ok(returnObj);
            }
            catch
            {
                return BadRequest("Unable to add");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<GenreDTO>> Delete(int id)
        {
            try
            {
                return Ok(await _repository.RemoveAsync(_repository.Find(e => e.GenreId == id).FirstOrDefault()));
            }
            catch
            {
                return BadRequest("Unable to delete");
            }
        }
        [HttpPost]
        public async Task<ActionResult<GenreDTO>> Update([FromBody]GenreDTO obj)
        {
            try
            {
                return Ok(await _repository.UpdateAsync(e => e.GenreId == obj.GenreId, obj));
            }
            catch
            {
                return BadRequest("Unable to update");
            }
        }
    }
}