using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Dotnet.API.Configurations;
using Microsoft.IdentityModel.Tokens;

namespace Dotnet.API.Services
{
    public interface IJWTService
    {
        string GenerateToken(string mobileNumber, JWTConfigurations jWTConfigurations);
    }

    public class JWTService : IJWTService
    {
        public string GenerateToken(string mobileNumber, JWTConfigurations jWTConfigurations)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jWTConfigurations.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("MobileNumber", mobileNumber) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = jWTConfigurations.Audience,
                Issuer = jWTConfigurations.Issuer
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}