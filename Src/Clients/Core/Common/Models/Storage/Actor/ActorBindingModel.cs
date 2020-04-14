using System;
using System.Collections.Generic;

namespace TeamProject.Clients.Common.Models.Storage.Actor
{
    public class ActorBindingModel
    {
        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}