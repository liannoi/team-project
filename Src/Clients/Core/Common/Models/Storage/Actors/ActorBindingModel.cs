using System;
using System.Collections.Generic;
using System.Text;

namespace TeamProject.Clients.Common.Models.Storage.Actors.Returnable
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
