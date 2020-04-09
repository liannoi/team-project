using AutoMapper;
using TeamProject.Application.Common.Interfaces;
using TeamProject.Domain.Entities;

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