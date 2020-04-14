using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamProject.Application.Common.Interfaces;
using TeamProject.Application.Common.Interfaces.Storage;
using TeamProject.Application.Storage.Films;

namespace TeamProject.Clients.WebApi.Controllers
{
    public class FilmController : BaseController
    {
        private readonly IBusinessService<FilmLookupDto> _repository;

        public FilmController(IBusinessService<FilmLookupDto> repository)
        {
            _repository = repository;
        }
    }
}