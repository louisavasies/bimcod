﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Bimcod.Api.Models;

namespace Bimcod.Api.Utilities
{
    public class AuthenticationService
    {
        private readonly BimcodContext context;
        private readonly IConfiguration config;

        public AuthenticationService(IConfiguration config, BimcodContext context)
        {
            this.config = config;
            this.context = context;
        }

        /// <param name="role">Possible values: Player / Email / ResetPassword / Admin </param>
        public string GenerateTokenForUser(User user, int hoursToExpiry = 2, string role = "player")
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, role)
            };
            var token = new JwtSecurityToken(config["Jwt:Issuer"], config["Jwt:Issuer"], expires: DateTime.Now.AddHours(hoursToExpiry), signingCredentials: creds, claims: claims);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public User GetUserByCredentials(string email, string password)
        {
            return context.User.FirstOrDefault(u => (u.Email == email && u.Password == password));
        }
    }
}
