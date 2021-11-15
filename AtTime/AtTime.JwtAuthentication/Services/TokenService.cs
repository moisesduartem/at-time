using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AtTime.JwtAuthentication.Services
{
    public class TokenService : ITokenService
    {
        private readonly byte[] _secret;
        private readonly int _expireTimeInHours;

        public TokenService(byte[] secret, int expireTimeInHours = 2)
        {
            _secret = secret;
            _expireTimeInHours = expireTimeInHours;
        }

        public string GenerateToken(string name, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(_expireTimeInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
