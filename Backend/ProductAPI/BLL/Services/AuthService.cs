using DAL.Interfaces;
using DAL.Models;
using DAL.Request_Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService : IAuthentication
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public User AddUser(User user)
        {
            var addUser = _context.Users.Add(user);
            _context.SaveChanges();
            return addUser.Entity;
        }

        public string Login(LoginRequest loginRequest)
        {
            if (loginRequest.Username != null && loginRequest.Password != null)
            {
                var user = _context.Users.SingleOrDefault(
                    s=>s.Username == loginRequest.Username 
                    && 
                    s.Password==loginRequest.Password);
                try
                {
                    var authenticatedUser = _context.Users.SingleOrDefault(
                        s => s.Username == loginRequest.Username && s.Password == loginRequest.Password);

                    if (authenticatedUser != null)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                            new Claim("UserName", authenticatedUser.Username)
                        };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(10),
                            signingCredentials: signIn);

                        var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                        return jwtToken;
                    }
                    else
                    {
                        return "Invalid user";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to authenticate user.", ex);
                }

            }
            else
            {
                throw new Exception("credentials are not valid");
            }
        }
    }
}
