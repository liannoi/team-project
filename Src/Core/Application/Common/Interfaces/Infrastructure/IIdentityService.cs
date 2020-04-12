using System;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using TeamProject.Domain.Entities;

namespace TeamProject.Application.Common.Interfaces.Infrastructure
{
    public interface IIdentityService
    {
        IIdentityService Key(SecurityKey key);
        IIdentityService Credentials(SigningCredentials credentials);
        string CreateJsonWebToken(AppUser user);
        IIdentityService Expires(DateTime expires);
        IIdentityService Claims(params Claim[] claim);
        IIdentityService Issuer(string issuer);
    }
}