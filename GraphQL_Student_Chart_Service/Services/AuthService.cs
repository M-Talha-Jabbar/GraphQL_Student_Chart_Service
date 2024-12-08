using GraphQL_Student_Chart_Service.Interfaces;
using GraphQL_Student_Chart_Service.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GraphQL_Student_Chart_Service.Services
{
    public class AuthService : IAuthInterface
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public User Login(string username, string password)
        {
            if (username == _configuration["AuthSettings:Username"] && password == _configuration["AuthSettings:Password"])
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]);
                var tokenExpirationMinutes = int.Parse(_configuration["JwtSettings:ExpirationInMinutes"]);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim(JwtRegisteredClaimNames.Name, username) }),
                    Expires = DateTime.UtcNow.AddMinutes(tokenExpirationMinutes),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    Audience = _configuration["JwtSettings:Audience"],
                    Issuer = _configuration["JwtSettings:Issuer"]
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var user = new User
                {
                    Username = username,
                    Token = tokenHandler.WriteToken(token)
                };

                return user;
            }

            return null;
        }
    }
}
