using System.Collections.Generic;

namespace TeamProject.Domain
{
    public abstract class ValueObject
    {
        public IEnumerable<string> Errors { get; set; }
    }
}