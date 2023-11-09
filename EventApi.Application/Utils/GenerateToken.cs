using EventApi.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EventApi.Application.Utils
{
   
        public static class GenerateToken
        {

            public static string generateJwtToken(User user)
            {
                string key = "986ghgrgtru989ASdsaerew13434545435";
                string issuer = "atul1234";
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                // Here you  can fill claim information from database for the users as well
                var claims = new[] {
                new Claim("id", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, "atul"),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("UniqueIdentifier", user.TenantId.ToString())
            };
                var token = new JwtSecurityToken(key, issuer, claims, expires: DateTime.Now.AddHours(24), signingCredentials: credentials);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
    }
