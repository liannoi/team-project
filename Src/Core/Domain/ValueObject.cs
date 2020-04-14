using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamProject.Clients.WebApi.Models.Core.Returnable
{
    public abstract class ValueObject
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
