using TeamProject.Domain;

namespace TeamProject.Clients.WebApi.Models.Identity.Returnable
{
    public class JwtTokenReturnModel : ValueObject
    {
        public string Token { get; set; }
    }
}