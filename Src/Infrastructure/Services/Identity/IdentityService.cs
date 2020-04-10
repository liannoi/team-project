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
        private Claim[] _claims;
        private SigningCredentials _credentials;
        private DateTime? _expires;
        private string _issuer;
        private SecurityKey _securityKey;

        public IdentityService(IOptions<IdentitySettings> identitySettings)
        {
            _identitySettings = identitySettings.Value;
        }

        public IIdentityService Key(SecurityKey key)
        {
            _securityKey = key;

            return this;
        }

        public IIdentityService Credentials(SigningCredentials credentials)
        {
            _credentials = credentials;

            return this;
        }

        public string CreateJsonWebToken(AppUser user)
        {
            return new JwtSecurityTokenHandler().WriteToken(PrepareJsonWebToken(user));
        }

        public IIdentityService Expires(DateTime expires)
        {
            _expires = expires;

            return this;
        }

        public IIdentityService Claims(params Claim[] claim)
        {
            _claims = claim;

            return this;
        }

        public IIdentityService Issuer(string issuer)
        {
            _issuer = issuer;

            return this;
        }

        private JwtSecurityToken PrepareJsonWebToken(AppUser user)
        {
            if (_securityKey == null)
                _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_identitySettings.Secret));

            if (_credentials == null)
                _credentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);

            if (_claims == null)
                _claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            if (_expires == null) _expires = DateTime.Now.AddMinutes(15);

            if (_issuer == null) _issuer = _identitySettings.Issuer;

            return new JwtSecurityToken(_issuer, _issuer, _claims, expires: _expires, signingCredentials: _credentials);
        }
    }
}