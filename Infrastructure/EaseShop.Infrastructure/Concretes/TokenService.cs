using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using EaseShop.Application.Interfaces;
using EaseShop.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace EaseShop.Infrastructure.Concretes;

public class TokenService : ITokenService
{
    public string GetToken(string SecretKey, string Audience, string Issuer, AppUser existUser, IList<string> roles)
    {
        var handler = new JwtSecurityTokenHandler();
        var privateKey = Encoding.UTF8.GetBytes(SecretKey);
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(privateKey), SecurityAlgorithms.HmacSha256);
        var ci = new ClaimsIdentity();

        ci.AddClaim(new Claim(ClaimTypes.NameIdentifier, existUser.Id.ToString()));
        ci.AddClaim(new Claim(ClaimTypes.Name, existUser.UserName));
        ci.AddClaim(new Claim(ClaimTypes.GivenName, existUser.FullName));
        ci.AddClaim(new Claim(ClaimTypes.Email, existUser.Email));

        ci.AddClaims(roles.Select(r => new Claim(ClaimTypes.Role, r)).ToList());
        //foreach (var role in roles)
        //    ci.AddClaim(new Claim(ClaimTypes.Role, role));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddMinutes(5),
            Subject = ci,
            Audience = Audience,
            Issuer = Issuer,
            NotBefore = DateTime.UtcNow,
        };
        var tokenHandiling = handler.CreateToken(tokenDescriptor);
        var Token = handler.WriteToken(tokenHandiling);
        return Token;
    }
    public string GenerateRefreshToken()
    {
        var randomBytes = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }
    }
}