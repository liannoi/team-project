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