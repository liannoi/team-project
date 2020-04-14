using AutoMapper;
using TeamProject.Application.Common.Interfaces.Storage;
using TeamProject.Domain.Entities.Film;

namespace TeamProject.Application.Storage.Films
{
    public class FilmRepository : BaseBusinessService<Film, FilmLookupDto>
    {
        public FilmRepository(IDataService<Film> dataService, IMapper mapper) : base(dataService, mapper)
        {
        }
    }
}