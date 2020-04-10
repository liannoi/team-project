using TeamProject.Domain.Entities;

namespace TeamProject.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        string CreateJsonWebToken(AppUser user);
    }
}