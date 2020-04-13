using System.Collections.Generic;

namespace TeamProject.Clients.Common.Models.Identity.Returnable
{
    public class JwtTokenReturnModel
    {
        public string Token { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}