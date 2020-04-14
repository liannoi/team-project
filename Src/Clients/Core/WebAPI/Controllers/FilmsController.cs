using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Common.Interfaces.Storage;
using TeamProject.Application.Storage.Films;

namespace TeamProject.Clients.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FilmsController : BaseController
    {
        private readonly IBusinessService<FilmLookupDto> _repository;

        public FilmsController(IBusinessService<FilmLookupDto> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<FilmLookupDto>> GetAll()
        {
            return Ok(_repository.Select());
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FilmLookupDto> Get(int id)
        {
            var result = _repository.Find(e => e.FilmId == id).FirstOrDefault();

            return result != null
                ? (ActionResult<FilmLookupDto>) Ok(result)
                : BadRequest("Movie with transferred primary key not found in database.");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FilmLookupDto>> Delete(int id)
        {
            var result = await _repository.RemoveAsync(_repository.Find(e => e.FilmId == id).FirstOrDefault());

            return result != null
                ? (ActionResult<FilmLookupDto>) Ok(result)
                : BadRequest("Movie with transferred primary key not found in database.");
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FilmLookupDto>> Create([FromBody] FilmLookupDto film)
        {
            if (!ModelState.IsValid) return BadRequest(new FilmLookupDtoValidator().Validate(film).Errors);

            try
            {
                return Ok(await _repository.AddAsync(film));
            }
            // TODO: Specify more specific exceptions.
            catch (Exception)
            {
                return BadRequest(new FilmLookupDto {Errors = new List<string> {"Error at add entity."}});
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FilmLookupDto>> Update([FromBody] FilmLookupDto film)
        {
            if (!ModelState.IsValid) return BadRequest(new FilmLookupDtoValidator().Validate(film).Errors);

            try
            {
                return Ok(await _repository.UpdateAsync(e => e.FilmId == film.FilmId, film));
            }
            // TODO: Specify more specific exceptions.
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}