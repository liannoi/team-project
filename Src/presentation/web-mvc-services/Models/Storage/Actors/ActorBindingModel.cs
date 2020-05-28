using System;
using System.Collections.Generic;
using TeamProject.Clients.Common.Models.Storage.ActorPhoto;

namespace TeamProject.Clients.Common.Models.Storage.Actors
{
    public class ActorBindingModel : ValueObject
    {
        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public ICollection<ActorPhotoBindingModel> Photos { get; set; }
    }
}