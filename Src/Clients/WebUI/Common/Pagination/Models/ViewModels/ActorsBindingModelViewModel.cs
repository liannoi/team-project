using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TeamProject.Clients.Common.Models.Storage.Actors.Returnable;

namespace TeamProject.Clients.WebUI.Common.Pagination.Models.ViewModels
{
    public class ActorsBindingModelViewModel : GenericViewModel<ActorBindingModel>
    {
        //    // 1. Add collection (by default - {get; set;} and IEnumerable).        

        //    // 2. Add pagging info.
        
        //    // 3. Collection with padding.
        
        public override Expression<Func<ActorBindingModel, bool>> Predicate
        {
            get
            {
                return e => e.ActorId == EntityId;
            }
        }

        //    // 4. Add padding by entities.
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
