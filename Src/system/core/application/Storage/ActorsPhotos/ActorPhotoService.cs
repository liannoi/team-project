using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TeamProject.Application.Common.Interfaces.Persistence;
using TeamProject.Domain.Entities.Actor;

namespace TeamProject.Application.Storage.ActorsPhotos
{
    public class ActorPhotoService : BaseDataService<ActorPhoto>
    {
        public ActorPhotoService(IFilmsDbContext context) : base(context, context.ActorPhotos)
        {
        }

        public override Task<ActorPhoto> UpdateAsync(Expression<Func<ActorPhoto, bool>> expressionToFindOld,
            ActorPhoto entity)
        {
            throw new NotImplementedException();
        }
    }
}