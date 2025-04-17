using EaseShop.Application.Dtos.Auth;
using EaseShop.Application.Interfaces;
using EaseShop.Application.Settings;
using EaseShop.Domain.Common.ResultPattern;
using EaseShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EaseShop.Application.Features.Auth.Commands.AppUserLogin;

public class AppUserLoginCommandHandler : IRequestHandler<AppUserLoginCommand, Result<AuthResponseDto>>
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly JwtSettings _jwtSettings;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AppUserLoginCommandHandler(SignInManager<AppUser> signInManager, ITokenService tokenService, UserManager<AppUser> userManager, JwtSettings jwtSettings, IHttpContextAccessor httpContextAccessor)
    {
        _signInManager = signInManager;
        _tokenService = tokenService;
        _userManager = userManager;
        _jwtSettings = jwtSettings;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Result<AuthResponseDto>> Handle(AppUserLoginCommand request, CancellationToken cancellationToken)
    {
        var existUer = await _userManager
            .Users
            .FirstOrDefaultAsync(u => u.UserName == request.UserName, cancellationToken: cancellationToken);
        if (existUer is null)
            return Result<AuthResponseDto>.Failure(Error.Custom("NotFound","User Not Found"), null,ErrorType.NotFoundError);
        var result = await _userManager.CheckPasswordAsync(existUer, request.Password);
        if(!result)
            return Result<AuthResponseDto>.Failure(Error.Custom("Password", "Password or email is wrong\""), null, ErrorType.ValidationError);
        IList<string> roles = await _userManager.GetRolesAsync(existUer);
        var Audience = _jwtSettings.Audience;
        var SecretKey = _jwtSettings.secretKey;
        var Issuer = _jwtSettings.Issuer;
        return Result<AuthResponseDto>.Success(new AuthResponseDto
        {
            Token = _tokenService.GetToken(SecretKey, Audience, Issuer, existUer, roles)
        },null);
    }
    
    private async Task<Result<bool>> CheckLockOutStatus(AppUser user,string password)
    {
        SignInResult signInResult = await _signInManager.CheckPasswordSignInAsync(user, password, true);

        if (signInResult.IsLockedOut)
        {
            TimeSpan? timeSpan = user.LockoutEnd - DateTime.UtcNow;
            if (timeSpan is not null)
                return Result<bool>.Failure(Error.Custom(null,$"Şifrenizi 5 defa yanlış girdiğiniz için kullanıcı {Math.Ceiling(timeSpan.Value.TotalMinutes)} dakika süreyle bloke edilmiştir"),null,ErrorType.BusinessLogicError);
            else
                return Result<bool>.Failure(Error.Custom(null, $"Şifrenizi 5 defa yanlış girdiğiniz için kullanıcı {Math.Ceiling(timeSpan.Value.TotalMinutes)} dakika süreyle bloke edilmiştir"), null, ErrorType.BusinessLogicError);
        }
        return Result<bool>.Success(true,null);
    }
}