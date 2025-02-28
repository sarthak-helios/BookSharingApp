using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using System.Security.Claims;
using BookSharingApp.Models;
using System.IdentityModel.Tokens.Jwt;

namespace BookSharingApp.Services
{
    public class JWTService
    {
        private readonly IConfiguration _config; // Keep IConfiguration

        public const string ClubIdClaimType = "ClubId";

        public JWTService(IConfiguration config)
        {
            _config = config;
        }

        public string IssueToken(UserModel data, int ClubId, string role)
        {
            string jwtKey = _config["JwtSettings:secret"] ?? string.Empty; // Get directly from config, handle nulls.

            if (string.IsNullOrWhiteSpace(jwtKey))
            {
                throw new InvalidOperationException("JWT secret key is missing or empty in JWTService.");
            }
            var secKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim("Id",data.Id.ToString()),
                new Claim(ClaimTypes.Email, data.Email),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.Name,ClubId.ToString())
            };

            var token = new JwtSecurityToken(
                    issuer: _config["JwtSettings:validIssuer"],
                    audience: _config["JwtSettings:validAudience"],
                    claims: claims,
                    expires: DateTime.Now.AddDays(120),
                    signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}