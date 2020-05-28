using AutoMapper;
using TeamProject.Application.Common.Interfaces.Storage;
using TeamProject.Domain.Entities.ManyToMany;

namespace TeamProject.Application.Storage.Actors
{
    public class ActorFilmRepository : BaseBusinessService<ActorsFilms, ActorFilmLookupDto>
    {
        public ActorFilmRepository(IDataService<ActorsFilms> dataService, IMapper mapper) : base(dataService, mapper)
        {
        }
    }
}