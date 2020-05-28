using AutoMapper;
using TeamProject.Application.Common.Interfaces.Storage;
using TeamProject.Domain.Entities.Actor;

namespace TeamProject.Application.Storage.Actors
{
    /// <summary>
    ///     Actor Business Service (DTO Type).
    /// </summary>
    public class ActorRepository : BaseBusinessService<Actor, ActorLookupDto>
    {
        public ActorRepository(IDataService<Actor> dataService, IMapper mapper) : base(dataService, mapper)
        {
        }
    }
}