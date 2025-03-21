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
        private readonly JWTSettings _jwtSettings; // Keep IConfiguration

        public const string ClubIdClaimType = "ClubId";

        public JWTService(JWTSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public string IssueToken(UserModel data, int ClubId, string Role)
        {

            var claims = new[]
            {
                new Claim("Id",data.Id.ToString()+"@"+ClubId),
                new Claim(ClaimTypes.Role, Role),
                new Claim("Role",Role),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, Role),
                new Claim(ClaimsIdentity.DefaultNameClaimType,data.Email)
            };

            var secKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddDays(120),
                    signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}