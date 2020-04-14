using AutoMapper;
using TeamProject.Application.Common.Interfaces.Storage;
using TeamProject.Domain.Entities.Actor;

namespace TeamProject.Application.Storage.ActorsPhotos
{
    public class ActorPhotoRepository : BaseBusinessService<ActorPhoto, ActorPhotoLookupDto>
    {
        public ActorPhotoRepository(IDataService<ActorPhoto> dataService, IMapper mapper) : base(dataService, mapper)
        {
        }
    }
}
