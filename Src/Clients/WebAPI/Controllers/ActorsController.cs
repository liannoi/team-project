using System.Collections.Generic;
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
        [ProducesDefaultResponseType]
        public ActionResult<IList<ActorLookupDto>> GetAll()
        {
            return Ok(_repository.Select());
        }
    }
}