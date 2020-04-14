using System;

namespace TeamProject.Clients.Common.Models.Storage.Actors
{
    public class ActorBindingModel : ValueObject
    {
        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
}