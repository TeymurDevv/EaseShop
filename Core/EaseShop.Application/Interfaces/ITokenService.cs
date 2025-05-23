using EaseShop.Domain.Entities;

namespace EaseShop.Application.Interfaces;

public interface ITokenService
{
    string GetToken(string SecretKey, string Audience, string Issuer, AppUser existUser, IList<string> roles);
    string GenerateRefreshToken();
}