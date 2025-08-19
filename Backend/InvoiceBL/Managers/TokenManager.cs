using InvoiceBL.DTOs;
using InvoiceBL.IManagers;
using InvoiceDAL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceBL.Managers
{
    public class TokenManager : ITokenManger
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey SecurityKey;
        public TokenManager(IConfiguration configuration)
        {
            _configuration = configuration;
            SecurityKey = new SymmetricSecurityKey(UTF8Encoding.UTF8.GetBytes(configuration.GetValue<string>("JWT:SigningKey")));
        }
        public string CreateToken(TokenDTOConfigurations tokenDTOConfigurations)
        {
            List<Claim> claims = new List<Claim>()
            {
                new(ClaimTypes.Name,tokenDTOConfigurations.UserName),
                new(ClaimTypes.Role,tokenDTOConfigurations.Role),
                new(ClaimTypes.NameIdentifier,tokenDTOConfigurations.UserId)
            };
            var signingCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = tokenDTOConfigurations.RememberMe ? DateTime.Now.AddDays(7) : DateTime.Now.AddHours(2),
                SigningCredentials = signingCredentials,
                Issuer = _configuration.GetValue<string>("JWT:Issuer"),
                Audience = _configuration.GetValue<string>("JWT:Audience")
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
