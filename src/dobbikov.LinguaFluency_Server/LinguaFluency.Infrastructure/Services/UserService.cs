using LinguaFluency.Domain.Models;
using LinguaFluency.Domain.ServiceIntefraces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace LinguaFluency.Infrastructure.Services
{
    public class UserService : IUserService
    {
        public string GenerateJWTToken(string username, string userId, string siteRoleId)
        {
            var securityKey = authJwtOptions.SecretKey;
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, username),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, userId)
            };
            claims.Add(new Claim("role", siteRoleId));

            var token = new JwtSecurityToken(authJwtOptions.Issuer, authJwtOptions.Audience, claims, expires: DateTime.Now.AddSeconds(3600), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string PasswordToHash(string password)
        {
            SHA256 hash = SHA256.Create();
            var returnPassword = string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("X2")));

            return returnPassword;
        }
    }
}
