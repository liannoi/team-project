using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TeamProject.Application;
using TeamProject.Application.Common.Interfaces;
using TeamProject.Domain.Entities;

namespace TeamProject.Infrastructure.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IdentitySettings _identitySettings;

        public IdentityService(IOptions<IdentitySettings> identitySettings)
        {
            _identitySettings = identitySettings.Value;
        }

        public string CreateJsonWebToken(AppUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_identitySettings.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_identitySettings.Issuer, _identitySettings.Issuer, claims,
                expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);

            return encodeToken;
        }
    }
}