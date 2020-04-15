using System.Collections.Generic;

namespace TeamProject.Clients.Common.Models
{
    public abstract class ValueObject
    {
        public IEnumerable<string> Errors { get; set; }
    }
}