using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Common.Interfaces.Storage;
using TeamProject.Application.Storage.Actors;
using TeamProject.Application.Storage.Films;
using TeamProject.Domain.Entities.ManyToMany;

namespace TeamProject.Clients.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FilmsController : BaseController
    {
        private readonly IBusinessService<FilmLookupDto> _repository;
        private readonly IBusinessService<ActorFilmLookupDto> _actorFilms;
        private readonly IMapper _mapper;

        public FilmsController(IBusinessService<FilmLookupDto> repository, IBusinessService<ActorFilmLookupDto> actorFilms, IMapper mapper)
        {
            _repository = repository;
            _actorFilms = actorFilms;
            _mapper = mapper;
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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<FilmLookupDto>> GetAllByActor(int id)
        {
            return _actorFilms.Find(e => e.ActorId == id)
                .Select(item => _repository.Select()
                    .ProjectTo<FilmLookupDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefault(e => e.FilmId == item.FilmId))
                .ToList()
                .GroupBy(x => x.FilmId)
                .Select(x => x.FirstOrDefault())
                .ToList();
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