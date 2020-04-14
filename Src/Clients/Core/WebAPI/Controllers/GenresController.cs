using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Common.Interfaces.Storage;
using TeamProject.Application.Storage.Genres;

namespace TeamProject.Clients.WebApi.Controllers
{
    public class GenresController : BaseController
    {
        private readonly IBusinessService<GenreLookupDto> _repository;

        public GenresController(IBusinessService<GenreLookupDto> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<GenreLookupDto>> GetAll()
        {
            return Ok(_repository.Select());
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<GenreLookupDto> Get(int id)
        {
            var result = _repository.Find(e => e.GenreId == id).FirstOrDefault();
            if (result != null) return Ok(result);

            return BadRequest("Not found");
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GenreLookupDto>> Add([FromBody] GenreLookupDto genre)
        {
            try
            {
                return Ok(await _repository.AddAsync(genre));
            }
            // TODO: Specify more specific exceptions.
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GenreLookupDto>> Delete(int id)
        {
            try
            {
                return Ok(await _repository.RemoveAsync(_repository.Find(e => e.GenreId == id).FirstOrDefault()));
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
        public async Task<ActionResult<GenreLookupDto>> Update([FromBody] GenreLookupDto genre)
        {
            try
            {
                return Ok(await _repository.UpdateAsync(e => e.GenreId == genre.GenreId, genre));
            }
            // TODO: Specify more specific exceptions.
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}