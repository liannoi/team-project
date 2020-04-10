using AutoMapper;
using TeamProject.Application.Common.Interfaces;
using TeamProject.Domain.Entities;

namespace TeamProject.Application.Storage.Genres
{
    public class GenreRepository : BaseBusinessService<Genre, GenreLookupDto>
    {
        public GenreRepository(IDataService<Genre> dataService, IMapper mapper) : base(dataService, mapper)
        {
        }
    }
}