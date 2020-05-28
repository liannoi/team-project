using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TeamProject.Clients.Common.Models.Storage.Actors;

namespace TeamProject.Clients.WebUI.Common.Pagination.Models.ViewModels
{
    public class ActorsBindingModelViewModel : GenericViewModel<ActorBindingModel>
    {
        public override Expression<Func<ActorBindingModel, bool>> Predicate
        {
            get { return e => e.ActorId == EntityId; }
        }

        public override IEnumerable<ActorBindingModel> EntitiesPerPage
        {
            get
            {
                return Collection.OrderBy(e => e.FirstName)
                    .Skip((PagingInfo.CurrentPage - 1) * PagingInfo.ItemsPerPage)
                    .Take(PagingInfo.ItemsPerPage);
            }
        }
    }
}